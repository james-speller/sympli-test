namespace CEOSEOProject.Business
{
    using Microsoft.Extensions.Options;
    using StackExchange.Redis.Extensions.Core.Abstractions;
    using System;
    using System.Threading.Tasks;

    public class CacheProvider : ICacheProvider
    {
        private readonly IRedisCacheClient redisCacheClient;
        private readonly AppSettings appSettings;

        public CacheProvider(IRedisCacheClient redisCacheClient,
            IOptions<AppSettings> options)
        {
            this.redisCacheClient = redisCacheClient;
            this.appSettings = options.Value;
        }

        public async Task<int?> GetValue(string key)
        {
            return await redisCacheClient.Db0.GetAsync<int>(key);
        }

        public async Task SetValue(string key, int value)
        {
            var ttl = new TimeSpan(this.appSettings.CacheHours, 0, 0);
            await redisCacheClient.Db0.AddAsync<int>(key, value, ttl);
        }
    }
}
