// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Vs.Options.Models.Headers;
using ApiStudioIO.Vs.Options.Models.ResponseCodes;
using ApiStudioIO.Vs.Options.Models.Security;
using ApiStudioIO.Vs.Options.Models.Specification;
using Newtonsoft.Json;

namespace ApiStudioIO.Vs.Options.Models
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