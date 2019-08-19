using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineUniversity.Application.Extensions;
using OnlineUniversity.Domain.Extensions;
using OnlineUniversity.Infrastructure.Persistence.Extensions;
using OnlineUniversity.Infrastructure.Quartz.Extensions;
using OnlineUniversity.Infrastructure.RabbitMQ.Extensions;
using OnlineUniversity.Infrastructure.Redis.Extensions;
using OnlineUniversity.Web.Middlewares;

namespace OnlineUniversity.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationModule();

            services.AddDomainModule();

            AddInfrastructureModules(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCustomExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void AddInfrastructureModules(IServiceCollection services)
        {
            services.AddPersistenceModule();

            services.AddRabbitMQModule(options =>
            {
                // specify rabbitmq options
            });

            services.AddRedisCacheModule(options =>
            {
                // specify redis cache options
            });

            services.AddQuartzModule();
        }
    }
}
