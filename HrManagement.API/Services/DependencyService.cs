using HrManagement.Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HrManagement.API.Services
{
    public static class DependencyService
    {
        public static IServiceCollection AddDependencyService(this IServiceCollection services, IConfiguration configuration)
        {
            // Dependency Injection Configuration
            //services.AddScoped<IHomeRepository, HomeRepository>();


            //MediatR configuration
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
               // cfg.RegisterServicesFromAssembly(typeof(HomeHandler).Assembly);

            });
            services.AddDbContext<EntityFrameworkDbContext>(c =>
               c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("HrManagement.API")));

            return services;
        }
    }
}
