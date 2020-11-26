namespace CEOSEOProject.Business.Search
{
    class GoogleSearcherFactory : SearcherFactory
    {
        private readonly string engineUrl;

        private readonly string apiKey;

        private readonly string engineKey;

        public GoogleSearcherFactory(string engineUrl, string apiKey, string engineKey)
        {
            this.engineUrl = engineUrl;
            this.apiKey = apiKey;
            this.engineKey = engineKey;
        }

        public override Searcher GetSearcher()
        {
            return new GoogleSearcher(this.engineUrl, this.apiKey, this.engineKey);
        }
    }
}
