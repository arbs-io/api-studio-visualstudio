// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.ComponentModel;
using Newtonsoft.Json;

namespace ApiStudioIO.Common.Models.Http
{
    public class HttpResourceHeaderResponse : HttpResourceHeaderBase
    {
        [Category("Scope")]
        [JsonProperty("on_response")]
        public HttpTypeHeaderOnResponse IncludeOn { get; set; }
    }
}