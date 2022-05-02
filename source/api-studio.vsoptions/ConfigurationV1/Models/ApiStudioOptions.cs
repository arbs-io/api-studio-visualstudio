namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;

    public sealed class ApiStudioOptions
    {
        [JsonProperty("response_codes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();

        [JsonProperty("security")]
        public DefaultSecurity DefaultSecurity { get; set; } = new DefaultSecurity();

        [JsonProperty("headers")]
        public DefaultHeaders DefaultHeaders { get; set; } = new DefaultHeaders();

        public void LoadDefaults()
        {
            DefaultResponseCodes.LoadDefaults();
            DefaultSecurity.LoadDefaults();
            DefaultHeaders.LoadDefaults();
        }
    }
}
