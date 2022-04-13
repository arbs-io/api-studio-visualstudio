﻿namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;

    public sealed class ApiStudioOptions
    {
        [JsonProperty("DefaultResponseCodes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();
    }
}