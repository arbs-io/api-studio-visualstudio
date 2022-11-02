namespace Pet
{
    using System.Net;
    using System.Threading.Tasks;
    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Extensions.Logging;

    public partial class HttpFindPets
    {
        private readonly ILogger _logger;
        public HttpFindPets(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<HttpFindPets>();
        }

        public async Task<HttpResponseData> RunAsync(HttpRequestData httpRequestData)
        {
            HttpResponseData response = httpRequestData.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            await response.WriteStringAsync($"Welcome to Azure Functions!").ConfigureAwait(false);

            return await Task.FromResult(response).ConfigureAwait(false);
        }
    }
}