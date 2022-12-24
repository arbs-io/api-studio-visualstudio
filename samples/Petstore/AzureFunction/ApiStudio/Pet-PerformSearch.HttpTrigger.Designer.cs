namespace Pet
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;

    using Microsoft.Azure.Functions.Worker;
    using Microsoft.Azure.Functions.Worker.Http;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Abstractions;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
    using Microsoft.OpenApi.Models;

    using Models;
    

    public partial class HttpPerformSearch
    {
        [Function(nameof(HttpPerformSearch.PerformSearch))]
        [OpenApiOperation(operationId: "PerformSearch", tags: new[] { "Pet" }, Summary = "PerformSearch", Description = "This is a description of the rest verbs actions", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiParameter(name: "Accept", In = ParameterLocation.Header, Required = true, Type = typeof(string), Summary = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand", Description = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiParameter(name: "User-Agent", In = ParameterLocation.Header, Required = true, Type = typeof(string), Summary = "The User-Agent request header is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting user agent.", Description = "The User-Agent request header is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting user agent.", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(PetList), Summary = "Created", Description = "Created", CustomHeaderType = typeof(ResponseHeaderOnSuccess))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Bad Request", Description = "Bad Request", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Unauthorized", Description = "Unauthorized", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.Forbidden, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Forbidden", Description = "Forbidden", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.UnsupportedMediaType, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Unsupported Media Type", Description = "Unsupported Media Type", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: (HttpStatusCode)422, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Unprocessable Entity", Description = "Unprocessable Entity", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Internal Server Error", Description = "Internal Server Error", CustomHeaderType = typeof(ResponseHeaderOnServerError))]
        public async Task<HttpResponseData> PerformSearch(
            [HttpTrigger(AuthorizationLevel.Anonymous, "POST", 
            Route = "pets/search")] HttpRequestData httpRequestData)
        {
            return await RunAsync(httpRequestData);
        }

        #region IOpenApiCustomResponseHeader
        private class ResponseHeaderOnInformation : IOpenApiCustomResponseHeader
        {
            public Dictionary<string, OpenApiHeader> Headers { get; set; } =
                new Dictionary<string, OpenApiHeader>()
                {
                    {
                        "Content-Length",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Content-Type",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },

                };
        }
        private class ResponseHeaderOnSuccess : IOpenApiCustomResponseHeader
        {
            public Dictionary<string, OpenApiHeader> Headers { get; set; } =
                new Dictionary<string, OpenApiHeader>()
                {
                    {
                        "Content-Length",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Content-Type",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Location",
                        new OpenApiHeader()
                        {
                            Description = "The Location response header indicates the URL to redirect a page to. It only provides a meaning when served with a 3xx (redirection) or 201 (created) status response. In cases of resource creation (201), it indicates the URL to the newly created resource.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },

                };
        }
        private class ResponseHeaderOnRedirection : IOpenApiCustomResponseHeader
        {
            public Dictionary<string, OpenApiHeader> Headers { get; set; } =
                new Dictionary<string, OpenApiHeader>()
                {
                    {
                        "Content-Length",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Content-Type",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },

                };
        }
        private class ResponseHeaderOnClientError : IOpenApiCustomResponseHeader
        {
            public Dictionary<string, OpenApiHeader> Headers { get; set; } =
                new Dictionary<string, OpenApiHeader>()
                {
                    {
                        "Content-Length",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Content-Type",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },

                };
        }
        private class ResponseHeaderOnServerError : IOpenApiCustomResponseHeader
        {
            public Dictionary<string, OpenApiHeader> Headers { get; set; } =
                new Dictionary<string, OpenApiHeader>()
                {
                    {
                        "Content-Length",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },
                    {
                        "Content-Type",
                        new OpenApiHeader()
                        {
                            Description = "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                            Schema = new OpenApiSchema() { Type = "string" },
                            AllowEmptyValue = false,
                            Required = true,
                        }
                    },

                };
        }
        #endregion IOpenApiCustomResponseHeader
    }
}