namespace ApiStudioIO.Common.Models.Http
{
    using System.ComponentModel;
    using Newtonsoft.Json;

    public class HttpResourceHeaderResponse : HttpResourceHeaderBase
    {
        [Category("Scope")]
        [JsonProperty("on_response")]
        public HttpTypeHeaderOnResponse IncludeOn { get; set; }
    }
}