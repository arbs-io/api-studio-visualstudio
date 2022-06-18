// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.VsOptions.ConfigurationV1.Models.Headers;
using ApiStudioIO.VsOptions.ConfigurationV1.Models.ResponseCodes;
using ApiStudioIO.VsOptions.ConfigurationV1.Models.Security;
using ApiStudioIO.VsOptions.ConfigurationV1.Models.Specification;
using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    public sealed class ApiStudioOptions
    {
        [JsonProperty("response_codes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();

        [JsonProperty("security")] public DefaultSecurity DefaultSecurity { get; set; } = new DefaultSecurity();

        [JsonProperty("specification")]
        public DefaultSpecification DefaultSpecification { get; set; } = new DefaultSpecification();

        [JsonProperty("headers")] public DefaultHeaders DefaultHeaders { get; set; } = new DefaultHeaders();

        public void LoadDefaults()
        {
            DefaultResponseCodes.LoadDefaults();
            DefaultSecurity.LoadDefaults();
            DefaultSpecification.LoadDefaults();
            DefaultHeaders.LoadDefaults();
        }
    }
}