namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    internal class DefaultHeaders
    {
        [JsonProperty("standard")]
        public List<int> StandardResponseCodes { get; set; } = new List<int>() { 400, 401, 403, 404, 415, 422, 500 };
    }
}
