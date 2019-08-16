using Microsoft.Extensions.DependencyInjection;
using OnlineUniversity.Domain;
using OnlineUniversity.Domain.Courses;
using OnlineUniversity.Domain.Students;
using OnlineUniversity.Infrastructure.Persistence.Context;
using OnlineUniversity.Infrastructure.Persistence.Courses;
using OnlineUniversity.Infrastructure.Persistence.Processing;
using System;

namespace OnlineUniversity.Infrastructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceModule(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddDbContext<MockOnlineUniversityContext>(options =>
            {
                // specify db context options here like connection string etc..
            });

            services
                .AddTransient<ICourseRepository, CourseRepository>()
                .AddTransient<IStudentRepository, StudentRepository>()
                .AddTransient<IDomainEventsDispatcher, DomainEventsDispatcher>();

            return services;
        }
    }
}
