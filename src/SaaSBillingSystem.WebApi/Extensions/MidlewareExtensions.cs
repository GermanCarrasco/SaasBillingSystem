using SaaSBillingSystem.WebApi.Midlewares;

namespace SaaSBillingSystem.WebApi.Extensions
{
    public static class MidlewareExtensions
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionsMidleware>();
        }
    }
}