using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSBillingSystem.Application.Repositories;
using SaaSBillingSystem.Infrastructure.Persistence;
using SaaSBillingSystem.Infrastructure.Repositories;

namespace SaaSBillingSystem.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            //Dbcontext
            services.AddDbContext<ApplicationDbcontext>(options =>
            {
                options.UseNpgsql(
                    configuration.GetConnectionString("DefaultConnection")
                );
            });

            //Repos
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}