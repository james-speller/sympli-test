namespace CEOSEOProject.Business.Search
{
    using CEOSEOProject.Business.Result.Google;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    class GoogleSearcher : Searcher
    {
        private readonly string engineUrl;

        private readonly string apiKey;

        private readonly string engineKey;

        public GoogleSearcher(string engineUrl, string apiKey, string engineKey)
        {
            this.engineUrl = engineUrl;
            this.apiKey = apiKey;
            this.engineKey = engineKey;
        }

        public override async Task<int> Search(string term, string resultUrl)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(this.engineUrl);

            var items = new List<GoogleItem>();
            for (var start = 1; start < 100; start +=10)
            {
                var path = $@"?key={apiKey}&cx={engineKey}&q={term}&start={start}";
                var result = await httpClient.GetAsync(path);
                var response = await result.Content.ReadAsStringAsync();
                var pagedResult = JsonConvert.DeserializeObject<GoogleResult>(response);

                items.AddRange(pagedResult.Items.Where(i => i.Link.Contains(resultUrl)));
            }

            return items.Count;
        }
    }
}
