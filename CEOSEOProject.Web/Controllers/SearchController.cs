namespace CEOSEOProject.Web.Controllers
{
    using System.Threading.Tasks;
    using CEOSEOProject.Business;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService searchService;

        public SearchController(ISearchService searchService)
        {
            this.searchService = searchService;
        }

        [HttpGet]
        public async Task<int> Get(string engine, string term, string resultUrl)
        {
            return await this.searchService.Search(engine, term, resultUrl);
        }
    }
}
