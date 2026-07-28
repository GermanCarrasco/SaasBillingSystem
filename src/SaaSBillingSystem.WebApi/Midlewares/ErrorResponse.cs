namespace SaaSBillingSystem.WebApi.Midlewares
{
    public sealed class ErrorResponse
    {
        public required int Status { get; init; }

        public required string Code { get; init; }

        public required string Title { get; init; }

        public required string Detail { get; init; }
    }
}