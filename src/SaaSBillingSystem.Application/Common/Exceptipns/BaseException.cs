using System.Net;

namespace SaaSBillingSystem.Application.Common.Exceptipns
{
    public abstract class BaseException : Exception
    {
        protected BaseException(
        string message,
        HttpStatusCode statusCode,
        string errorCode)
        : base(message)
    {
        StatusCode = statusCode;
        ErrorCode = errorCode;
    }

    public HttpStatusCode StatusCode { get; }

    public string ErrorCode { get; }

    }
}