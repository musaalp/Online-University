using Microsoft.Extensions.DependencyInjection;
using OnlineUniversity.Application.Contracts.Cache;
using OnlineUniversity.Infrastructure.Redis.Configuration;
using System;

namespace OnlineUniversity.Infrastructure.Redis.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRedisCacheModule(this IServiceCollection services, Action<RedisCacheOptions> configureOptions)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            services.Configure(configureOptions);

            services.AddSingleton<ICacheProvider, MockRedisCacheProvider>();

            return services;
        }
    }
}
