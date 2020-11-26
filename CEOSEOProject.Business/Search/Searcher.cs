namespace CEOSEOProject.Business.Search
{
    using System.Threading.Tasks;

    abstract class Searcher
    {
        public abstract Task<int> Search(string term, string resultUrl);
    }
}
