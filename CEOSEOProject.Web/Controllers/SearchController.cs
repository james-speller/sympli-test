namespace CEOSEOProject.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using CEOSEOProject.Business;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;

    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly ILogger<SearchController> _logger;

        private readonly ISearchService searchService;

        public SearchController(ILogger<SearchController> logger,
            ISearchService searchService,
            IOptions<AppSettings> appSettings)
        {
            _logger = logger;
            this.searchService = searchService;
        }

        [HttpGet]
        public int Get(string engine, string term, string resultUrl)
        {
            return 5;
        }
    }
}
