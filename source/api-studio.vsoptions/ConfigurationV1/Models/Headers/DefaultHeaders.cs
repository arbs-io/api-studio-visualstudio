namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using ApiStudioIO.Common.Models.Http;    
    using Newtonsoft.Json;
    using System.Collections.Generic;

    public sealed class DefaultHeaders
    {
        [JsonProperty("request")]
        public List<HttpResourceHeaderRequest> Request { get; set; } = new List<HttpResourceHeaderRequest>();

        [JsonProperty("response")]
        public List<HttpResourceHeaderResponse> Response { get; set; } = new List<HttpResourceHeaderResponse>();

        public DefaultHeaders()
        {
            LoadDefaults();
        }

        public void LoadDefaults()
        {
            Request.Add(new HttpResourceHeaderRequest
            {
                Name = "User-Agent",
                Description = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand",
                AllowEmptyValue = false,
                IsRequired = true,
            }
            );

            Request.Add(new HttpResourceHeaderRequest
            {
                Name = "Accept",
                Description = "The Accept request HTTP header indicates which content types, expressed as MIME types, the client is able to understand",
                AllowEmptyValue = false,
                IsRequired = true,
            }
            );
        }
    }
}