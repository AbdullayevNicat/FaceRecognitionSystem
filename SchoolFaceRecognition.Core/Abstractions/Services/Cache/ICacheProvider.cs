using Microsoft.Extensions.Caching.Distributed;

namespace SchoolFaceRecognition.Core.Abstractions.Services.Cache
{
    public interface ICacheProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, int minute, int slidingMinute);
        void Set<T>(string key, T value, DistributedCacheEntryOptions distributedCacheEntryOptions);
        void Remove<T>(string key);
        void Refresh(string key);

        Task<T> GetAsync<T>(string key, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, DistributedCacheEntryOptions distributedCacheEntryOptions, CancellationToken cancellationToken = default);
        Task SetAsync<T>(string key, T value, int minute, int slidingMinute, CancellationToken cancellationToken = default);
        Task RemoveAsync<T>(string key, CancellationToken cancellationToken = default);
        Task RefreshAsync(string key, CancellationToken cancellationToken = default);
    }
}
