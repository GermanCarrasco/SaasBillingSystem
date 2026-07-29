using SaaSBillingSystem.WebApi.Midlewares;

namespace SaaSBillingSystem.WebApi.Extensions
{
    public static class SwaggerBasicAuthExtensions
    {
        public static IApplicationBuilder UseSwaggerBasicAuthentication(this IApplicationBuilder app)
        {
            return app.UseMiddleware<SwaggerBasicAuthMiddleware>();
        }
    }
}