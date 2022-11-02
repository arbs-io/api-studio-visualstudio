using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Configurations;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using System;

namespace Configurations
{
    public class OpenApiConfigurationOptions : DefaultOpenApiConfigurationOptions
    {
        public override OpenApiInfo Info { get; set; } = new OpenApiInfo()
        {
            Version = @"1.0.0",
            Title = @"Api Studio Petstore - Maintenance v1.0.0",
            Description = @"This is a simple example of common aspects you should consider covering when documenting your API. But, of course, the API documentation can include other topics, and the more information you provide consumers, the faster they can get started.

## Overview
The **<API_NAME>** API is organized around RESTful resources. Our API has predictable resource-oriented URLs, accepts form-encoded request bodies, returns JSON-encoded responses, and uses standard HTTP response codes, authentication, and verbs. You can use the **<API_NAME>** API in test mode, not affecting your live data. The API token you use to authenticate the request determines whether the request is live or test mode.

The API supports idempotency for safely retrying requests without performing the same operation twice. This is useful when an API call is disrupted in transit and not receiving a response. For example, if a request to create a charge does not respond due to a network connection error, you can retry the request with the same ETag key to guaranteeing that no more than one charge is created.

All **POST** requests accept ETag keys. However, sending ETag keys in **GET** and **DELETE** requests has no effect and should be avoided, as these requests are idempotent by definition.

## Security
Authentication to the API is performed via OAuth2. The **<API_NAME>** API uses an Authorization header with each request. Your API token carry many privileges, so be sure to keep them secure! Do not share your secret API keys in publicly accessible areas such as GitHub, client-side code, and so forth.

| Name              | Value     |
| ----------------- | --------- |
| **Authorization** | Bearer ***eyJ0eXAiOiJKV1QifQ==.eyJhdWQiOiJhcGktc3R1ZGlvLmlvIn0=.eMiOUrS_qAcfTcChjMmg*** |

All API requests must be made over HTTPS. Calls made over plain HTTP will be rejected. In addition, API requests without an Authorization header will be rejected (response 401).

## Pagination
All collection API resources support bulk fetches via **GET** requests against a collection resource. The find API methods share a standard structure, taking at least these three parameters: limit and offset.

## Error
**<API_NAME>** uses conventional HTTP response codes to indicate the success or failure of an API request. In general: Codes in the 2xx range indicate success. Codes in the 4xx range indicate an error that failed given the information provided (e.g., a required parameter was omitted, a charge failed, etc.). Codes in the 5xx range indicate an error with Stripe's servers (these are rare).",
            TermsOfService = new Uri(@"https://vendor.com"),
            Contact = new OpenApiContact()
            {
                Name = @"info@vendor.com",
                Email = @"info@vendor.com",
                Url = new Uri(@"https://vendor.com"),
            },
            License = new OpenApiLicense()
            {
                Name = "MIT",
                Url = new Uri("https://api-studio.io/licenses/MIT"),
            }
        };

        public override OpenApiVersionType OpenApiVersion { get; set; } = OpenApiVersionType.V3;
    }
}
