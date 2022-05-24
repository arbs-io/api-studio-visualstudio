namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel;

    public sealed class DefaultSecurity
    {
        [JsonProperty("scheme")]
        public string SecurityScheme { get; set; }

        [JsonProperty("scope_pattern")]
        public string SecurityScopePattern { get; set; }

        [JsonProperty("openid_connect_url")]
        public string OpenIdConnectUrl { get; set; }

        public void LoadDefaults()
        {
            SecurityScheme = "None";
            SecurityScopePattern = "{Resource}::{Action}";
            OpenIdConnectUrl = "http://api-studio.io/.well-known/openid-configuration";
        }
    }
}
