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

        public void LoadDefaults()
        {
            SecurityScheme = "OpenIdConnect";
            SecurityScopePattern = "{Resource}::{Action}";
        }
    }
}
