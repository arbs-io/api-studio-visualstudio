namespace ApiStudioIO.VsOptions.ConfigurationV1.Models
{
    using Newtonsoft.Json;
    using System.ComponentModel;

    public sealed class DefaultSecurity
    {
        [JsonProperty("SecurityScheme")]
        public SecuritySchemes SecurityScheme { get; set; }

        [JsonProperty("SecurityScopePattern")]
        public string SecurityScopePattern { get; set; }

        public void LoadDefaults()
        {
            SecurityScheme = SecuritySchemes.None;
            SecurityScopePattern = "{Resource}::{Action}";
        }
    }
}
