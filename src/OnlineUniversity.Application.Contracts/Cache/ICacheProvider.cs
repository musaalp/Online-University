using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Contracts.Cache
{
    public interface ICacheProvider
    {
        Task<T> GetAsync<T>(string key);
        Task SetAsync(string key, int cacheTime, object data);
    }
}
