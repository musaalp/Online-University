using OnlineUniversity.Application.Contracts.Cache;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineUniversity.Infrastructure.Redis.Configuration
{
    public class RedisCacheOptions : CacheOptions
    {
        public string ConnectionString { get; set; }
        public int Db { get; set; } = -1;
        public object AsyncState { get; set; } = null;
    }
}
