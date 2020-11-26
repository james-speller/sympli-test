namespace CEOSEOProject.Business
{
    public class AppSettings
    {
        public string GoogleUrl { get; set; }

        public string GoogleAPIKey { get; set; }

        public string GoogleEngineKey { get; set; }

        public string BingUrl { get; set; }

        public int CacheHours { get; set; }

        public string RedisHost { get; set; }

        public int RedisPort { get; set; }
    }
}
