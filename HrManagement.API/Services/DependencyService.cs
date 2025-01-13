using HrManagement.Application.Handlers.CandidateHandler;
using HrManagement.Core.Repositories;
using HrManagement.Infrastructure.DBContext;
using HrManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HrManagement.API.Services
{
    public static class DependencyService
    {
        public static IServiceCollection AddDependencyService(this IServiceCollection services, IConfiguration configuration)
        {
            // Dependency Injection Configuration
            services.AddScoped<ICandidateRepository, CandidateRepository>();


            //MediatR configuration
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
               cfg.RegisterServicesFromAssembly(typeof(CandidateCommandHandler).Assembly);

            });
            services.AddDbContext<EntityFrameworkDbContext>(c =>
               c.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),b=>b.MigrationsAssembly("HrManagement.API")));

            return services;
        }
    }
}
