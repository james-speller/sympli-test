namespace CEOSEOProject.Business
{
    using StackExchange.Redis.Extensions.Core.Abstractions;
    using System.Threading.Tasks;

    public class CacheProvider : ICacheProvider
    {
        private readonly IRedisCacheClient redisCacheClient;

        public CacheProvider(IRedisCacheClient redisCacheClient)
        {
            this.redisCacheClient = redisCacheClient;
        }

        public async Task<int> GetValue(string key)
        {
            return await redisCacheClient.Db0.GetAsync<int>(key);
        }

        public async Task SetValue(string key, int value)
        {
            await redisCacheClient.Db0.AddAsync<int>(key, value);
        }
    }
}
