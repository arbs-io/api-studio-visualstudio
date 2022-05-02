namespace ApiStudioIO.Common.Models.Http
{
    using System;
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class HttpResourceHeaderResponse : HttpResourceHeaderBase
    {
        [Category("Scope")]
        [JsonProperty("on_response")]
        public HttpTypeHeaderOnResponse IncludeOn { get; set; }

        [Category("Hidden")]
        [JsonIgnore]
        [Browsable(false)]
        public string IncludeOnName => $"{Enum.GetName(typeof(HttpTypeHeaderOnResponse), IncludeOn)}";
    }
}