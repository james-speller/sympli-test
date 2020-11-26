namespace CEOSEOProject.Business.Result.Google
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public class GoogleResult
    {
        [JsonProperty("items")]
        public List<GoogleItem> Items { get; set; }
    }
}
