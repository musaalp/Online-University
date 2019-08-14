﻿using System;
using System.Threading.Tasks;

namespace OnlineUniversity.Application.Contracts.Cache
{
    public interface ICacheManager
    {
        Task<T> GetOrSetAsync<T>(string key, Func<Task<T>> acquireAsync);

        Task<T> GetOrSetAsync<T>(string key, int cacheTime, Func<Task<T>> acquireAsync);
    }
}
