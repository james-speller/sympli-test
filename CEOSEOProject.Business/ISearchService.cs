namespace CEOSEOProject.Business
{
    using System.Threading.Tasks;

    public interface ISearchService
    {
        Task<int> Search(string engine, string term, string resultUrl);
    }
}
