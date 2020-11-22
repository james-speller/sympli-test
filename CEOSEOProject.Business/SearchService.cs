namespace CEOSEOProject.Business
{
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SearchService : ISearchService
    {
        public SearchService(IOptions<AppSettings> appSettings)
        {

        }
    }
}
