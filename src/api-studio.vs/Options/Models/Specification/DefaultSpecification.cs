// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace ApiStudioIO.Vs.Options.Models.Specification
{
    public sealed class DefaultSpecification
    {
        [JsonProperty("vendor_name")] public string VendorName { get; set; }

        [JsonProperty("product_name")] public string ProductName { get; set; }

        [JsonProperty("api_name")] public string ApiName { get; set; }

        [JsonProperty("contact_name")] public string ContactName { get; set; }

        [JsonProperty("contact_url")] public string ContactUrl { get; set; }

        [JsonProperty("description")] public string Description { get; set; }

        [JsonProperty("audience")] public string Audience { get; set; }

        public void LoadDefaults()
        {
            VendorName = "VendorName";
            ProductName = "ProductName";
            ApiName = "ApiName";
            ContactName = "info@vendor.com";
            ContactUrl = "https://vendor.com";
            Audience = "Private";
            Description =
                "This is a simple example of common aspects you should consider covering when documenting your API. But, of course, the API documentation can include other topics, and the more information you provide consumers, the faster they can get started.\r\n\r\n## Overview\r\nThe **<API_NAME>** API is organized around RESTful resources. Our API has predictable resource-oriented URLs, accepts form-encoded request bodies, returns JSON-encoded responses, and uses standard HTTP response codes, authentication, and verbs. You can use the **<API_NAME>** API in test mode, not affecting your live data. The API token you use to authenticate the request determines whether the request is live or test mode.\r\n\r\nThe API supports idempotency for safely retrying requests without performing the same operation twice. This is useful when an API call is disrupted in transit and not receiving a response. For example, if a request to create a charge does not respond due to a network connection error, you can retry the request with the same ETag key to guaranteeing that no more than one charge is created.\r\n\r\nAll **POST** requests accept ETag keys. However, sending ETag keys in **GET** and **DELETE** requests has no effect and should be avoided, as these requests are idempotent by definition.\r\n\r\n## Security\r\nAuthentication to the API is performed via OAuth2. The **<API_NAME>** API uses an Authorization header with each request. Your API token carry many privileges, so be sure to keep them secure! Do not share your secret API keys in publicly accessible areas such as GitHub, client-side code, and so forth.\r\n\r\n| Name              | Value     |\r\n| ----------------- | --------- |\r\n| **Authorization** | Bearer ***eyJ0eXAiOiJKV1QifQ==.eyJhdWQiOiJhcGktc3R1ZGlvLmlvIn0=.eMiOUrS_qAcfTcChjMmg*** |\r\n\r\nAll API requests must be made over HTTPS. Calls made over plain HTTP will be rejected. In addition, API requests without an Authorization header will be rejected (response 401).\r\n\r\n## Pagination\r\nAll collection API resources support bulk fetches via **GET** requests against a collection resource. The find API methods share a standard structure, taking at least these three parameters: limit and offset.\r\n\r\n## Error\r\n**<API_NAME>** uses conventional HTTP response codes to indicate the success or failure of an API request. In general: Codes in the 2xx range indicate success. Codes in the 4xx range indicate an error that failed given the information provided (e.g., a required parameter was omitted, a charge failed, etc.). Codes in the 5xx range indicate an error with Stripe's servers (these are rare).";
        }
    }
}