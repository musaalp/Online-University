using Microsoft.Extensions.DependencyInjection;
using System;

namespace OnlineUniversity.Infrastructure.Quartz.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddQuartzModule(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            // inject quartz dependencies

            return services;
        }
    }
}
