using Microsoft.Extensions.DependencyInjection;
using OnlineUniversity.Domain.Courses;
using System;

namespace OnlineUniversity.Domain.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainModule(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddTransient<ICourseSignUpPolicy, CoursesSignupPolicy>();

            return services;
        }
    }
}
