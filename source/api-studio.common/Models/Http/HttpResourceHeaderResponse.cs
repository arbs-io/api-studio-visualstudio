namespace ApiStudioIO.Common.Models.Http
{
    using System;
    using System.ComponentModel;

    public class HttpResourceHeaderResponse : HttpResourceHeaderBase
    {
        [Category("Scope")]
        public HttpResourceHeaderOnResponse IncludeOn { get; set; }

        [Category("Hidden")]
        [Browsable(false)]
        public string IncludeOnName => $"{Enum.GetName(typeof(HttpResourceHeaderOnResponse), IncludeOn)}";
    }
}