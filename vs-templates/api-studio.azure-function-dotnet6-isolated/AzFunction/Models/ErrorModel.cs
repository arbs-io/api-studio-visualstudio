#nullable enable
namespace Models
{
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    internal class ErrorModel
    {
        [OpenApiProperty(Description = "Machine-friendly error code, which could be used in error handling", Default = 404, Nullable = false)]
        public int statusCode { get; set; } = 200;

        [OpenApiProperty(Description = "Human-readable error description.", Default = "Useful information about the failure e.g. Resource not found", Nullable = false)]
        public string? Message { get; set; } = "";
    }
}
