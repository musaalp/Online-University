using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OnlineUniversity.Application.Cache;
using OnlineUniversity.Application.Contracts.Cache;
using System.Reflection;

namespace OnlineUniversity.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddMediatR(Assembly.GetExecutingAssembly())
                .AddSingleton<ICacheManager, CacheManager>();

            return services;
        }
    }
}
