// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace ApiStudioIO.Utility.Extensions
{
    public static class HttpResponseExtension
    {
        public static Dictionary<int, ResponseInformation> HttpResponseCodes { get; } =
            new Dictionary<int, ResponseInformation>
            {
                { 100, new ResponseInformation{ Description = "Continue", RfcReference = "[RFC7231, Section 6.2.1]"} },
                { 101, new ResponseInformation{ Description = "Switching Protocols", RfcReference = "[RFC7231, Section 6.2.2]"} },
                { 102, new ResponseInformation{ Description = "Processing", RfcReference = "[RFC2518]"} },
                { 103, new ResponseInformation{ Description = "Early Hints", RfcReference = "[RFC8297]"} },

                { 200, new ResponseInformation{ Description = "OK", RfcReference = "[RFC7231, Section 6.3.1]"} },
                { 201, new ResponseInformation{ Description = "Created", RfcReference = "[RFC7231, Section 6.3.2]"} },
                { 202, new ResponseInformation{ Description = "Accepted", RfcReference = "[RFC7231, Section 6.3.3]"} },
                { 203, new ResponseInformation{ Description = "Non-Authoritative Information", RfcReference = "[RFC7231, Section 6.3.4]"} },
                { 204, new ResponseInformation{ Description = "No Content", RfcReference = "[RFC7231, Section 6.3.5]"} },
                { 205, new ResponseInformation{ Description = "Reset Content", RfcReference = "[RFC7231, Section 6.3.6]"} },
                { 206, new ResponseInformation{ Description = "Partial Content", RfcReference = "[RFC7233, Section 4.1]"} },
                { 207, new ResponseInformation{ Description = "Multi-Status", RfcReference = "[RFC4918]"} },
                { 208, new ResponseInformation{ Description = "Already Reported", RfcReference = "[RFC5842]"} },

                { 226, new ResponseInformation{ Description = "IM Used", RfcReference = "[RFC3229]"} },

                { 300, new ResponseInformation{ Description = "Multiple Choices", RfcReference = "[RFC7231, Section 6.4.1]"} },
                { 301, new ResponseInformation{ Description = "Moved Permanently", RfcReference = "[RFC7231, Section 6.4.2]"} },
                { 302, new ResponseInformation{ Description = "Found", RfcReference = "[RFC7231, Section 6.4.3]"} },
                { 303, new ResponseInformation{ Description = "See Other", RfcReference = "[RFC7231, Section 6.4.4]"} },
                { 304, new ResponseInformation{ Description = "Not Modified", RfcReference = "[RFC7232, Section 4.1]"} },
                { 305, new ResponseInformation{ Description = "Use Proxy", RfcReference = "[RFC7231, Section 6.4.5]"} },
                { 306, new ResponseInformation{ Description = "(Unused)", RfcReference = "[RFC7231, Section 6.4.6]"} },
                { 307, new ResponseInformation{ Description = "Temporary Redirect", RfcReference = "[RFC7231, Section 6.4.7]"} },
                { 308, new ResponseInformation{ Description = "Permanent Redirect", RfcReference = "[RFC7538]"} },

                { 400, new ResponseInformation{ Description = "Bad Request", RfcReference = "[RFC7231, Section 6.5.1]"} },
                { 401, new ResponseInformation{ Description = "Unauthorized", RfcReference = "[RFC7235, Section 3.1]"} },
                { 402, new ResponseInformation{ Description = "Payment Required", RfcReference = "[RFC7231, Section 6.5.2]"} },
                { 403, new ResponseInformation{ Description = "Forbidden", RfcReference = "[RFC7231, Section 6.5.3]"} },
                { 404, new ResponseInformation{ Description = "Not Found", RfcReference = "[RFC7231, Section 6.5.4]"} },
                { 405, new ResponseInformation{ Description = "Method Not Allowed", RfcReference = "[RFC7231, Section 6.5.5]"} },
                { 406, new ResponseInformation{ Description = "Not Acceptable", RfcReference = "[RFC7231, Section 6.5.6]"} },
                { 407, new ResponseInformation{ Description = "Proxy Authentication Required", RfcReference = "[RFC7235, Section 3.2]"} },
                { 408, new ResponseInformation{ Description = "Request Timeout", RfcReference = "[RFC7231, Section 6.5.7]"} },
                { 409, new ResponseInformation{ Description = "Conflict", RfcReference = "[RFC7231, Section 6.5.8]"} },
                { 410, new ResponseInformation{ Description = "Gone", RfcReference = "[RFC7231, Section 6.5.9]"} },
                { 411, new ResponseInformation{ Description = "Length Required", RfcReference = "[RFC7231, Section 6.5.10]"} },
                { 412, new ResponseInformation{ Description = "Precondition Failed", RfcReference = "[RFC8144, Section 3.2]"} },
                { 413, new ResponseInformation{ Description = "Payload Too Large", RfcReference = "[RFC7231, Section 6.5.11]"} },
                { 414, new ResponseInformation{ Description = "URI Too Long", RfcReference = "[RFC7231, Section 6.5.12]"} },
                { 415, new ResponseInformation{ Description = "Unsupported Media Type", RfcReference = "[RFC7694, Section 3]"} },
                { 416, new ResponseInformation{ Description = "Range Not Satisfiable", RfcReference = "[RFC7233, Section 4.4]"} },
                { 417, new ResponseInformation{ Description = "Expectation Failed", RfcReference = "[RFC7231, Section 6.5.14]"} },

                { 421, new ResponseInformation{ Description = "Misdirected Request", RfcReference = "[RFC7540, Section 9.1.2]"} },
                { 422, new ResponseInformation{ Description = "Unprocessable Entity", RfcReference = "[RFC4918]"} },
                { 423, new ResponseInformation{ Description = "Locked", RfcReference = "[RFC4918]"} },
                { 424, new ResponseInformation{ Description = "Failed Dependency", RfcReference = "[RFC4918]"} },
                { 425, new ResponseInformation{ Description = "Too Early", RfcReference = "[RFC8470]"} },
                { 426, new ResponseInformation{ Description = "Upgrade Required", RfcReference = "[RFC7231, Section 6.5.15]"} },
                { 427, new ResponseInformation{ Description = "Unassigned", RfcReference = ""} },
                { 428, new ResponseInformation{ Description = "Precondition Required", RfcReference = "[RFC6585]"} },
                { 429, new ResponseInformation{ Description = "Too Many Requests", RfcReference = "[RFC6585]"} },
                { 430, new ResponseInformation{ Description = "Unassigned", RfcReference = ""} },
                { 431, new ResponseInformation{ Description = "Request Header Fields Too Large", RfcReference = "[RFC6585]"} },

                { 451, new ResponseInformation{ Description = "Unavailable For Legal Reasons", RfcReference = "[RFC7725]"} },

                { 500, new ResponseInformation{ Description = "Internal Server Error", RfcReference = "[RFC7231, Section 6.6.1]"} },
                { 501, new ResponseInformation{ Description = "Not Implemented", RfcReference = "[RFC7231, Section 6.6.2]"} },
                { 502, new ResponseInformation{ Description = "Bad Gateway", RfcReference = "[RFC7231, Section 6.6.3]"} },
                { 503, new ResponseInformation{ Description = "Service Unavailable", RfcReference = "[RFC7231, Section 6.6.4]"} },
                { 504, new ResponseInformation{ Description = "Gateway Timeout", RfcReference = "[RFC7231, Section 6.6.5]"} },
                { 505, new ResponseInformation{ Description = "HTTP Version Not Supported", RfcReference = "[RFC7231, Section 6.6.6]"} },
                { 506, new ResponseInformation{ Description = "Variant Also Negotiates", RfcReference = "[RFC2295]"} },
                { 507, new ResponseInformation{ Description = "Insufficient Storage", RfcReference = "[RFC4918]"} },
                { 508, new ResponseInformation{ Description = "Loop Detected", RfcReference = "[RFC5842]"} },
                { 509, new ResponseInformation{ Description = "Unassigned", RfcReference = ""} },
                { 510, new ResponseInformation{ Description = "Not Extended", RfcReference = "[RFC2774]"} },
                { 511, new ResponseInformation{ Description = "Network Authentication Required", RfcReference = "[RFC6585]"} },
            };

        public static string GetHttpResponseCodeCategory(int httpStatus)
        {
            var statusType = "Unknown";
            switch (httpStatus)
            {
                case int n when n >= 100 && n < 200:
                    statusType = "Information";
                    break;

                case int n when n >= 200 && n < 300:
                    statusType = "Success";
                    break;

                case int n when n >= 300 && n < 400:
                    statusType = "Redirection";
                    break;

                case int n when n >= 400 && n < 500:
                    statusType = "Client Error";
                    break;

                case int n when n >= 500 && n < 600:
                    statusType = "Server Error";
                    break;
            }

            return statusType;
        }

        public static string GetHttpResponseCodeDescription(int httpStatus)
        {
            return HttpResponseCodes[httpStatus].Description;
        }

        public class ResponseInformation
        {
            public string Description { get; set; }
            public string RfcReference { get; set; }
        }
    }
}