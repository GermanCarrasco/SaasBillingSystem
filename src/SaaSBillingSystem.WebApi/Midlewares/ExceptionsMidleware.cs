using System.Text.Json;
using SaaSBillingSystem.Application.Common.Exceptipns;

namespace SaaSBillingSystem.WebApi.Midlewares
{
    public sealed class ExceptionsMidleware
    (RequestDelegate next, ILogger<ExceptionsMidleware> logger)
    {
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);

            }
            catch (BaseException ex)
            {
                await HandleCustomExceptionAsync(context, ex);

            }
            catch (Exception ex)
            {
                await HandleUnhandledExceptionAsync(context, ex);
            }
        }

        private async Task HandleCustomExceptionAsync(HttpContext context, BaseException ex)
        {
            logger.LogWarning(ex, ex.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)ex.StatusCode;

            var response = new ErrorResponse
            {
                Status = (int)ex.StatusCode,
                Code = ex.ErrorCode,
                Title = ex.GetType().Name,
                Detail = ex.Message
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
        }

        private async Task HandleUnhandledExceptionAsync(
        HttpContext context,
        Exception exception)
        {
            logger.LogError(exception, exception.Message);

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)System.Net.HttpStatusCode.InternalServerError;

            var response = new ErrorResponse
            {
                Status = StatusCodes.Status500InternalServerError,
                Code = "INTERNAL_SERVER_ERROR",
                Title = "Internal Server Error",
                Detail = "An unexpected error occurred."
            };

            await context.Response.WriteAsync(
                JsonSerializer.Serialize(response));
        }
    }
}