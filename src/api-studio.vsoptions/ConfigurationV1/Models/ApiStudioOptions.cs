namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Specification;
    using Headers;
    using ResponseCodes;
    using Security;
    using Newtonsoft.Json;

    public sealed class ApiStudioOptions
    {
        [JsonProperty("response_codes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();

        [JsonProperty("security")]
        public DefaultSecurity DefaultSecurity { get; set; } = new DefaultSecurity();

        [JsonProperty("specification")]
        public DefaultSpecification DefaultSpecification { get; set; } = new DefaultSpecification();

        [JsonProperty("headers")]
        public DefaultHeaders DefaultHeaders { get; set; } = new DefaultHeaders();

        public void LoadDefaults()
        {
            DefaultResponseCodes.LoadDefaults();
            DefaultSecurity.LoadDefaults();
            DefaultSpecification.LoadDefaults();
            DefaultHeaders.LoadDefaults();
        }
    }
}
