using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.OpenApi;

namespace SaaSBillingSystem.WebApi.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo {
                            Version = "v1",
                            Title = "Saas Billing API",
                            Description = "REST API para la administración de suscripciones, planes, facturación y pagos del sistema SaaS Billing.",

                        });
            });



            return services;
        }
    }
}