namespace CEOSEOProject.Business.Result.Google
{
    using Newtonsoft.Json;

    public class GoogleItem
    {
        [JsonProperty("link")]
        public string Link { get; set; }
    }
}
