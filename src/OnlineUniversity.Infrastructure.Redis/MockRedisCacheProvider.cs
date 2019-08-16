using OnlineUniversity.Application.Contracts.Cache;
using OnlineUniversity.Infrastructure.Redis.Exceptions;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineUniversity.Infrastructure.Redis
{
    public class MockRedisCacheProvider : ICacheProvider
    {
        public IDictionary<string, object> _mockDataStore = new ConcurrentDictionary<string, object>();

        public async Task<T> GetAsync<T>(string key)
        {
            if (_mockDataStore.ContainsKey(key))
            {
                return await Task.FromResult((T)_mockDataStore[key]);
            }
            else
            {
                return await Task.FromResult(default(T));
            }
        }

        public async Task SetAsync(string key, int cacheTime, object data)
        {
            await Task.Run(() =>
            {
                if (!_mockDataStore.ContainsKey(key))
                {
                    _mockDataStore.Add(key, data);
                }
                else
                {
                    throw new KeyAlreadyPresentException("Key already present in data store");
                }
            });
        }
    }
}
