using Microsoft.Extensions.Options;
using OnlineUniversity.Application.Contracts.Cache;
using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Cache
{
    public class CacheManager : ICacheManager
    {
        private readonly ICacheProvider _cacheProvider;
        private readonly CacheOptions _options;

        public CacheManager(ICacheProvider cacheProvider, IOptions<CacheOptions> options)
        {
            _cacheProvider = cacheProvider;
            _options = options.Value;
        }

        public Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> acquireAsync)
        {
            return GetOrSetAsync(key, _options.DefaultCacheTime, acquireAsync);
        }

        public async Task<T> GetOrSetAsync<T>(string key, int cacheTime, Func<Task<T>> acquireAsync)
        {
            var data = await _cacheProvider.GetAsync<T>(key);

            if (data != null)
            {
                return data;
            }

            var result = await acquireAsync();

            await _cacheProvider.SetAsync(key, cacheTime, result);

            return result;
        }
    }
}
