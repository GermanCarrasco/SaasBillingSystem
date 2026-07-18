using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaaSBillingSystem.Infrastructure.Persistence;

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
            

            return services;
        }
    }
}