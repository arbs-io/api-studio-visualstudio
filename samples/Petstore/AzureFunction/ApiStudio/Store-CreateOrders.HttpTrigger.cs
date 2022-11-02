namespace Store
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Extensions.Logging;

    public partial class HttpCreateOrders
    {
        private readonly ILogger _logger;
        public HttpCreateOrders(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpCreateOrders>();
        }

        public async Task<HttpResponseData> RunAsync(HttpRequestData httpRequestData)
        {
            HttpResponseData response = httpRequestData.CreateResponse(HttpStatusCode.Created);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            await response.WriteStringAsync($"Welcome to Azure Functions!").ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}