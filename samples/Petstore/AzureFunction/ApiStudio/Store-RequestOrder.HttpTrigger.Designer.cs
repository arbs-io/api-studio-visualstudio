namespace Store
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
    

    public partial class HttpRequestOrder
    {
        [Function(nameof(HttpRequestOrder.RequestOrder))]
        [OpenApiOperation(operationId: "RequestOrder", tags: new[] { "Store" }, Summary = "RequestOrder", Description = "This is a description of the rest verbs actions", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiParameter(name: "Accept", In = ParameterLocation.Header, Required = true, Type = typeof(string), Summary = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand", Description = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiParameter(name: "User-Agent", In = ParameterLocation.Header, Required = true, Type = typeof(string), Summary = "The User-Agent request header is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting user agent.", Description = "The User-Agent request header is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting user agent.", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiParameter(name: "OrderId", In = ParameterLocation.Path, Required = true, Type = typeof(Guid), Summary = "A unique, immutable identifier that identifies a resource", Description = "A unique, immutable identifier that identifies a resource", Visibility = OpenApiVisibilityType.Important)]
		[OpenApiResponseWithoutBody(statusCode: HttpStatusCode.OK, Summary = "OK", Description = "OK", CustomHeaderType = typeof(ResponseHeaderOnSuccess))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Bad Request", Description = "Bad Request", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.Unauthorized, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Unauthorized", Description = "Unauthorized", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.Forbidden, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Forbidden", Description = "Forbidden", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.NotFound, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Not Found", Description = "Not Found", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.UnsupportedMediaType, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Unsupported Media Type", Description = "Unsupported Media Type", CustomHeaderType = typeof(ResponseHeaderOnClientError))]
		[OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ErrorModel), Summary = "Internal Server Error", Description = "Internal Server Error", CustomHeaderType = typeof(ResponseHeaderOnServerError))]
        public async Task<HttpResponseData> RequestOrder(
            [HttpTrigger(AuthorizationLevel.Anonymous, "GET", 
            Route = "store/orders/{OrderId}")] HttpRequestData httpRequestData)
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