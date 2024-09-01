
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace SurveyBasket.Api.Services
{
    public class CacheService(IDistributedCache distributedCache) : ICacheService
    {
        private readonly IDistributedCache distributedCache = distributedCache;

        public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
        {
            var cachedValue=await distributedCache.GetStringAsync(key ,cancellationToken);
            return string.IsNullOrEmpty(cachedValue) 
                ? null 
                : JsonSerializer.Deserialize<T>(cachedValue);
        }
        public async Task SetAsync<T>(string key, T value, CancellationToken cancellationToken = default) where T : class
        {
            await distributedCache.SetStringAsync(key , JsonSerializer.Serialize(value) , cancellationToken);
        }
        public async Task RemoveAsync(string key, CancellationToken cancellationToken = default)
        {
           await distributedCache.RemoveAsync(key, cancellationToken);
        }

        
    }
}
