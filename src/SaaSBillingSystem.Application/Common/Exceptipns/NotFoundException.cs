using System.Net;

namespace SaaSBillingSystem.Application.Common.Exceptipns
{
    public class NotFoundException : BaseException

    {
        public NotFoundException(string message)
        : base(
            message,
            HttpStatusCode.NotFound,
            "RESOURCE_NOT_FOUND")
        {
        }


    }
}