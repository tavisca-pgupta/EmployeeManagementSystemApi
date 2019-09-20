using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementSystemApi.Cache
{
    public class RedisCache
    {

        public static async Task SetObjectAsync<T>(IDistributedCache cache,string key, T value)
        {
            await cache.SetStringAsync(key, JsonConvert.SerializeObject(value),new DistributedCacheEntryOptions() { AbsoluteExpiration= DateTime.UtcNow.AddMinutes(1)});
        }

        public static async Task<T> GetObjectAsync<T>(IDistributedCache cache,string key)
        {
            string value = await cache.GetStringAsync(key);
            return value==null? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
