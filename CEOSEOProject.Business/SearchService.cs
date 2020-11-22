namespace CEOSEOProject.Business
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly AppSettings appSettings;

        public SearchService(IOptions<AppSettings> options)
        {
            this.appSettings = options.Value;
        }

        public async Task<int> Search(string engine, string term, string resultUrl)
        {
            throw new NotImplementedException();
        }
    }
}
