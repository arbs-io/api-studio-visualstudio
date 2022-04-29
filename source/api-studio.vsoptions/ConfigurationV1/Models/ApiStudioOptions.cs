﻿namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;

    public sealed class ApiStudioOptions
    {
        [JsonProperty("response_codes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();

        [JsonProperty("security")]
        public DefaultSecurity DefaultSecurity { get; set; } = new DefaultSecurity();
    }
}
