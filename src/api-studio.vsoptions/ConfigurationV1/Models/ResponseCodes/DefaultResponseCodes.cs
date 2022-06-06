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
using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1.Models.ResponseCodes
{
    public sealed class DefaultResponseCodes
    {
        [JsonProperty("standard")]
        public HashSet<int> StandardResponseCodes { get; set; } =
            new HashSet<int> { 400, 401, 403, 404, 415, 422, 500 };

        [JsonProperty("success_get")] public int SuccessGet { get; set; } = 200;

        [JsonProperty("success_put")] public int SuccessPut { get; set; } = 202;

        [JsonProperty("success_post")] public int SuccessPost { get; set; } = 201;

        [JsonProperty("success_delete")] public int SuccessDelete { get; set; } = 202;

        [JsonProperty("success_patch")] public int SuccessPatch { get; set; } = 202;

        [JsonProperty("success_trace")] public int SuccessTrace { get; set; } = 200;

        [JsonProperty("success_head")] public int SuccessHead { get; set; } = 200;

        [JsonProperty("success_options")] public int SuccessOptions { get; set; } = 204;

        public void LoadDefaults()
        {
            StandardResponseCodes = new HashSet<int> { 400, 401, 403, 404, 415, 422, 500 };
            SuccessGet = 200;
            SuccessPut = 202;
            SuccessPost = 201;
            SuccessDelete = 202;
            SuccessPatch = 202;
            SuccessTrace = 200;
            SuccessHead = 200;
            SuccessOptions = 204;
        }
    }
}