using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EmployeeManagementSystemApi.Cache
{
    public class RedisCache : ICache
    {
        private readonly IDistributedCache _cache;
        public RedisCache(IDistributedCache cache)
        {
            _cache = cache;
        }

        public async Task SetObjectAsync<T>(string key, T value)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(value),new DistributedCacheEntryOptions() { AbsoluteExpiration= DateTime.UtcNow.AddMinutes(1)});
        }

        public async Task<T> GetObjectAsync<T>(string key)
        {
            string value = await _cache.GetStringAsync(key);
            return value==null? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
