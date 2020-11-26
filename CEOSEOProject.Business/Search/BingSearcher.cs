namespace CEOSEOProject.Business.Search
{
    using System;
    using System.Threading.Tasks;

    class BingSearcher : Searcher
    {
        private readonly string engineUrl;

        public BingSearcher(string engineUrl)
        {
            this.engineUrl = engineUrl;
        }


        public override async Task<int> Search(string term, string resultUrl)
        {
            throw new NotImplementedException();
        }
    }
}
