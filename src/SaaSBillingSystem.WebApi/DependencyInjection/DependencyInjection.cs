using Microsoft.OpenApi;
using SaaSBillingSystem.WebApi.Configurations;

namespace SaaSBillingSystem.WebApi.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.Configure<SwaggerAuth>(
                configuration.GetSection(SwaggerAuth.SectionName)
            );

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