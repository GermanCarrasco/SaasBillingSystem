using System.Net.Http.Headers;
using System.Text;
using SaaSBillingSystem.WebApi.Configurations;

namespace SaaSBillingSystem.WebApi.Midlewares
{
    public sealed class SwaggerBasicAuthMiddleware (RequestDelegate next,SwaggerAuth options)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Path.StartsWithSegments("/swagger"))
            {
                await next(context);
                return;
            }

            if(!context.Request.Headers.TryGetValue("Authorization",out var authorizationHeader))
            {
                await ChallengeAsync(context);
                return;
            }

            try
            {
                var authenticationHeader = 
                        AuthenticationHeaderValue.Parse(authorizationHeader!);

                if (!authenticationHeader.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
                {
                    await ChallengeAsync(context);
                    return;
                }

                var credentialBytes = Convert.FromBase64String(authenticationHeader.Parameter ?? string.Empty);

                var credentials = Encoding.UTF8.GetString(credentialBytes);

                var separatorIndex = credentials.IndexOf(':');

                if(separatorIndex <= 0)
                {
                    await ChallengeAsync(context);
                    return;
                }

                var userName = credentials[..separatorIndex];
                var password = credentials[(separatorIndex + 1)..];

                if(userName != options.Username ||
                password != options.Password)
                {
                    await ChallengeAsync(context);
                    return;
                }

                await next(context);
            }
            catch (FormatException)
            {
                await ChallengeAsync(context);
                
            }
            catch (ArgumentException)
            {
                await ChallengeAsync(context);
            }
        }

        private static async Task ChallengeAsync(HttpContext context)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.Headers["WWW-Authenticate"] = "Basic realm=\"Swagger\"";
            await context.Response.WriteAsync("Authentication required.");
        }
    }
}