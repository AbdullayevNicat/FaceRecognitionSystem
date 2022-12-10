using Microsoft.Extensions.Caching.Distributed;
using SchoolFaceRecognition.Core.Abstractions.Services.Cache;
using System.Text;
using System.Text.Json;

namespace SchoolFaceRecognition.BL.Services.Cache
{
    public class CacheProvider : ICacheProvider
    {
        IDistributedCache _distributedCache;
        public CacheProvider(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public T Get<T>(string key)
        {
            string result = _distributedCache.GetString(key);

            return result == null ? default : JsonSerializer.Deserialize<T>(result);
        }
        public void Set<T>(string key, T value, int slidingMinute, int minute)
        {
            string json = JsonSerializer.Serialize(value);

            _distributedCache.SetString(key, json, new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(minute),
                SlidingExpiration = TimeSpan.FromMinutes(slidingMinute)
            });
        }

        public void Set<T>(string key, T value, DistributedCacheEntryOptions distributedCacheEntryOptions)
        {
            string json = JsonSerializer.Serialize(value);
            _distributedCache.SetString(key, json, distributedCacheEntryOptions);
        }

        public void Remove<T>(string key)
        {
            _distributedCache.Remove(key);
        }

        public void Refresh(string key)
        {
            _distributedCache.Refresh(key);
        }



        public async Task RefreshAsync(string key, CancellationToken cancellationToken = default)
        {
            await _distributedCache.RefreshAsync(key, cancellationToken);
        }

        public async Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default)
        {
            string result = await _distributedCache.GetStringAsync(key, cancellationToken);

            return result == null ? default : JsonSerializer.Deserialize<T>(result);
        }

        public async Task RemoveAsync<T>(string key, CancellationToken cancellationToken)
        {
            await _distributedCache.RemoveAsync(key, cancellationToken);
        }

        public async Task SetAsync<T>(string key, T value, int minute, int slidingMinute, CancellationToken cancellationToken = default)
        {
            string json = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, json, new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(minute)
            }, cancellationToken);
        }

        public async Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions distributedCacheEntryOptions, CancellationToken cancellationToken = default)
        {
            string json = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, json, distributedCacheEntryOptions, cancellationToken);
        }
    }
}
