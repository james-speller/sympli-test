namespace CEOSEOProject.Business
{
    using CEOSEOProject.Business.Search;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    public class SearchService : ISearchService
    {
        private readonly ICacheProvider cacheProvider;

        private readonly AppSettings appSettings;

        public SearchService(IOptions<AppSettings> options, ICacheProvider cacheProvider)
        {
            this.appSettings = options.Value;
            this.cacheProvider = cacheProvider;
        }

        public async Task<int> Search(string engine, string term, string resultUrl)
        {
            // Create a cache key for the value
            var cacheKey = GetCacheKey(engine, term, resultUrl);

            // Try to match the value in cache, if found then return it
            var cachedResult = await this.cacheProvider.GetValue(cacheKey);
            if (cachedResult != null)
            {
                return cachedResult.Value;
            }

            // If we don't find the value in cache then have to run the query
            var webResult = await this.GetResultsFromWeb(engine, term, resultUrl);

            // After the query completes cache the results
            await cacheProvider.SetValue(cacheKey, webResult);
            return webResult;
        }

        private string GetCacheKey(string engine, string term, string resultUrl)
        {
            return $"{engine}:{term}:{resultUrl}";
        }

        private async Task<int> GetResultsFromWeb(string engine, string term, string resultUrl)
        {
            // Decided to put a factory in here because I expect different things will need to be done
            // to crawl different search engines and to allow the project to be extended later to add
            // in additional engines.
            SearcherFactory searcherFactory = engine switch
            {
                "google" => new GoogleSearcherFactory(appSettings.GoogleUrl, appSettings.GoogleAPIKey, appSettings.GoogleEngineKey),
                "bing" => new BingSearcherFactory(appSettings.BingUrl),
                _ => throw new NotSupportedException("The requested search engine is not currently supported."),
            };

            var searcher = searcherFactory.GetSearcher();
            var result = await searcher.Search(term, resultUrl);
            return result;
        }
    }
}
