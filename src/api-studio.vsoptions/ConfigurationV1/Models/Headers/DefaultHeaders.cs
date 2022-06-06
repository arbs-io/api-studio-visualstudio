// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.Collections.Generic;
using ApiStudioIO.Common.Models.Http;
using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1.Models.Headers
{
    public sealed class DefaultHeaders
    {
        [JsonProperty("request")]
        public Dictionary<string, HttpResourceHeaderRequest> Request { get; set; } =
            new Dictionary<string, HttpResourceHeaderRequest>();

        [JsonProperty("response")]
        public Dictionary<string, HttpResourceHeaderResponse> Response { get; set; } =
            new Dictionary<string, HttpResourceHeaderResponse>();

        public void LoadDefaults()
        {
            LoadResponseDefaults();
            LoadRequestDefaults();
        }

        private void LoadResponseDefaults()
        {
            if (!Response.ContainsKey("Content-Type"))
                Response.Add("Content-Type", new HttpResourceHeaderResponse
                    {
                        Name = "Content-Type",
                        Description =
                            "The Content-Type representation header is used to indicate the original media type of the resource (prior to any content encoding applied for sending).",
                        AllowEmptyValue = false,
                        IsRequired = true,
                        IncludeOn = HttpTypeHeaderOnResponse.OnAlways
                    }
                );
            if (!Response.ContainsKey("Content-Length"))
                Response.Add("Content-Length", new HttpResourceHeaderResponse
                    {
                        Name = "Content-Length",
                        Description =
                            "The Content-Length header indicates the size of the message body, in bytes, sent to the recipient.",
                        AllowEmptyValue = false,
                        IsRequired = true,
                        IncludeOn = HttpTypeHeaderOnResponse.OnAlways
                    }
                );
        }

        private void LoadRequestDefaults()
        {
            if (!Request.ContainsKey("User-Agent"))
                Request.Add("User-Agent", new HttpResourceHeaderRequest
                    {
                        Name = "User-Agent",
                        Description =
                            "The User-Agent request header is a characteristic string that lets servers and network peers identify the application, operating system, vendor, and/or version of the requesting user agent.",
                        AllowEmptyValue = false,
                        IsRequired = true
                    }
                );
            if (!Request.ContainsKey("Accept"))
                Request.Add("Accept", new HttpResourceHeaderRequest
                    {
                        Name = "Accept",
                        Description =
                            "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand",
                        AllowEmptyValue = false,
                        IsRequired = true
                    }
                );
        }
    }
}