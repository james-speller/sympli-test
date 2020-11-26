namespace CEOSEOProject.Business.Search
{
    class BingSearcherFactory : SearcherFactory
    {
        private readonly string engineUrl;

        public BingSearcherFactory(string engineUrl)
        {
            this.engineUrl = engineUrl;
        }

        public override Searcher GetSearcher()
        {
            return new BingSearcher(this.engineUrl);
        }
    }
}
