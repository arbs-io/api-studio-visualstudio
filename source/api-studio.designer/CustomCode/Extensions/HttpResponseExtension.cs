namespace ApiStudioIO
{
    internal static class HttpResponseExtension
    {
        internal static string GetHttpResponseCodeCategory(int httpStatus)
        {
            var statusType = "Unknown";
            switch (httpStatus)
            {
                case int n when (n >= 100 && n < 200):
                    statusType = "Information";
                    break;

                case int n when (n >= 200 && n < 300):
                    statusType = "Success";
                    break;

                case int n when (n >= 300 && n < 400):
                    statusType = "Redirection";
                    break;

                case int n when (n >= 400 && n < 500):
                    statusType = "Client Error";
                    break;

                case int n when (n >= 500 && n < 600):
                    statusType = "Server Error";
                    break;
            }
            return statusType;
        }

        internal static string GetHttpResponseCodeDescription(int httpStatus)
        {
            var statusDescription = "";
            switch (httpStatus)
            {
                case 100: statusDescription = "Continue"; break;                            //[RFC7231, Section 6.2.1]
                case 101: statusDescription = "Switching Protocols"; break;                 //[RFC7231, Section 6.2.2]
                case 102: statusDescription = "Processing"; break;                          //[RFC2518]
                case 103: statusDescription = "Early Hints"; break;                         //[RFC8297]

                case 200: statusDescription = "OK"; break;                                  //[RFC7231, Section 6.3.1]
                case 201: statusDescription = "Created"; break;                             //[RFC7231, Section 6.3.2]
                case 202: statusDescription = "Accepted"; break;                            //[RFC7231, Section 6.3.3]
                case 203: statusDescription = "Non-Authoritative Information"; break;       //[RFC7231, Section 6.3.4]
                case 204: statusDescription = "No Content"; break;                          //[RFC7231, Section 6.3.5]
                case 205: statusDescription = "Reset Content"; break;                       //[RFC7231, Section 6.3.6]
                case 206: statusDescription = "Partial Content"; break;                     //[RFC7233, Section 4.1]
                case 207: statusDescription = "Multi-Status"; break;                        //[RFC4918]
                case 208: statusDescription = "Already Reported"; break;                    //[RFC5842]

                case 226: statusDescription = "IM Used"; break;                             //[RFC3229]

                case 300: statusDescription = "Multiple Choices"; break;                    //[RFC7231, Section 6.4.1]
                case 301: statusDescription = "Moved Permanently"; break;                   //[RFC7231, Section 6.4.2]
                case 302: statusDescription = "Found"; break;                               //[RFC7231, Section 6.4.3]
                case 303: statusDescription = "See Other"; break;                           //[RFC7231, Section 6.4.4]
                case 304: statusDescription = "Not Modified"; break;                        //[RFC7232, Section 4.1]
                case 305: statusDescription = "Use Proxy"; break;                           //[RFC7231, Section 6.4.5]
                case 306: statusDescription = "(Unused)"; break;                            //[RFC7231, Section 6.4.6]
                case 307: statusDescription = "Temporary Redirect"; break;                  //[RFC7231, Section 6.4.7]
                case 308: statusDescription = "Permanent Redirect"; break;                  //[RFC7538]

                case 400: statusDescription = "Bad Request"; break;                         //[RFC7231, Section 6.5.1]
                case 401: statusDescription = "Unauthorized"; break;                        //[RFC7235, Section 3.1]
                case 402: statusDescription = "Payment Required"; break;                    //[RFC7231, Section 6.5.2]
                case 403: statusDescription = "Forbidden"; break;                           //[RFC7231, Section 6.5.3]
                case 404: statusDescription = "Not Found"; break;                           //[RFC7231, Section 6.5.4]
                case 405: statusDescription = "Method Not Allowed"; break;                  //[RFC7231, Section 6.5.5]
                case 406: statusDescription = "Not Acceptable"; break;                      //[RFC7231, Section 6.5.6]
                case 407: statusDescription = "Proxy Authentication Required"; break;       //[RFC7235, Section 3.2]
                case 408: statusDescription = "Request Timeout"; break;                     //[RFC7231, Section 6.5.7]
                case 409: statusDescription = "Conflict"; break;                            //[RFC7231, Section 6.5.8]
                case 410: statusDescription = "Gone"; break;                                //[RFC7231, Section 6.5.9]
                case 411: statusDescription = "Length Required"; break;                     //[RFC7231, Section 6.5.10]
                case 412: statusDescription = "Precondition Failed"; break;                 //[RFC7232, Section 4.2][RFC8144, Section 3.2]
                case 413: statusDescription = "Payload Too Large"; break;                   //[RFC7231, Section 6.5.11]
                case 414: statusDescription = "URI Too Long"; break;                        //[RFC7231, Section 6.5.12]
                case 415: statusDescription = "Unsupported Media Type"; break;              //[RFC7231, Section 6.5.13][RFC7694, Section 3]
                case 416: statusDescription = "Range Not Satisfiable"; break;               //[RFC7233, Section 4.4]
                case 417: statusDescription = "Expectation Failed"; break;                  //[RFC7231, Section 6.5.14]

                case 421: statusDescription = "Misdirected Request"; break;                 //[RFC7540, Section 9.1.2]
                case 422: statusDescription = "Unprocessable Entity"; break;                //[RFC4918]
                case 423: statusDescription = "Locked"; break;                              //[RFC4918]
                case 424: statusDescription = "Failed Dependency"; break;                   //[RFC4918]
                case 425: statusDescription = "Too Early"; break;                           //[RFC8470]
                case 426: statusDescription = "Upgrade Required"; break;                    //[RFC7231, Section 6.5.15]
                case 427: statusDescription = "Unassigned"; break;                          //
                case 428: statusDescription = "Precondition Required"; break;               //[RFC6585]
                case 429: statusDescription = "Too Many Requests"; break;                   //[RFC6585]
                case 430: statusDescription = "Unassigned"; break;                          //
                case 431: statusDescription = "Request Header Fields Too Large"; break;     //[RFC6585]

                case 451: statusDescription = "Unavailable For Legal Reasons"; break;       //[RFC7725]

                case 500: statusDescription = "Internal Server Error"; break;               //[RFC7231, Section 6.6.1]
                case 501: statusDescription = "Not Implemented"; break;                     //[RFC7231, Section 6.6.2]
                case 502: statusDescription = "Bad Gateway"; break;                         //[RFC7231, Section 6.6.3]
                case 503: statusDescription = "Service Unavailable"; break;                 //[RFC7231, Section 6.6.4]
                case 504: statusDescription = "Gateway Timeout"; break;                     //[RFC7231, Section 6.6.5]
                case 505: statusDescription = "HTTP Version Not Supported"; break;          //[RFC7231, Section 6.6.6]
                case 506: statusDescription = "Variant Also Negotiates"; break;             //[RFC2295]
                case 507: statusDescription = "Insufficient Storage"; break;                //[RFC4918]
                case 508: statusDescription = "Loop Detected"; break;                       //[RFC5842]
                case 509: statusDescription = "Unassigned"; break;                          //
                case 510: statusDescription = "Not Extended"; break;                        //[RFC2774]
                case 511: statusDescription = "Network Authentication Required"; break;     //[RFC6585]
            }
            return statusDescription;
        }
    }
}