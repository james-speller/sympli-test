namespace CEOSEOProject.Business
{
    using Microsoft.Extensions.Options;
    using StackExchange.Redis;
    using System;
    using System.Threading.Tasks;

    public class CacheProvider : ICacheProvider
    {
        private readonly AppSettings appSettings;
        private readonly ConnectionMultiplexer connection;

        public CacheProvider(IOptions<AppSettings> options)
        {
            this.appSettings = options.Value;

            var redisHost = appSettings.RedisHost;
            var redisPort = appSettings.RedisPort;
            var configuration = ConfigurationOptions.Parse($"{redisHost}:{redisPort}");
            configuration.AllowAdmin = true;
            configuration.Password = null;
            configuration.AbortOnConnectFail = false;
            configuration.ConnectTimeout = 5000;
            configuration.DefaultDatabase = 0;
            this.connection = ConnectionMultiplexer.Connect(configuration);
        }

        public async Task<int?> GetValue(string key)
        {
            var database = this.connection.GetDatabase();
            var value = database.StringGet(key);
            if (value.IsNullOrEmpty)
            {
                return null;
            }

            return (int)value;
        }

        public async Task SetValue(string key, int value)
        {
            var database = this.connection.GetDatabase();
            var ttl = new TimeSpan(this.appSettings.CacheHours, 0, 0);
            database.StringSet(key, value, ttl);
        }
    }
}
