using Microsoft.Extensions.DependencyInjection;
using OnlineUniversity.Application.Contracts.Bus;
using System;

namespace OnlineUniversity.Infrastructure.RabbitMQ.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRabbitMQModule(this IServiceCollection services, Action<BusOptions> configureOptions)
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

            services
                .AddTransient<IBusProvider, MockRabbitMQBusProvider>();

            return services;
        }
    }
}
