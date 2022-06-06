using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1.Models.Security
{
    public sealed class DefaultSecurity
    {
        [JsonProperty("scheme")] public string SecurityScheme { get; set; }

        [JsonProperty("scope_pattern")] public string SecurityScopePattern { get; set; }

        [JsonProperty("openid_connect_url")] public string OpenIdConnectUrl { get; set; }

        [JsonProperty("scheme_name_oauth2")] public string OAuth2SchemeName { get; set; }

        [JsonProperty("scheme_name_open_id_connect")]
        public string OpenIdConnectSchemeName { get; set; }

        [JsonProperty("scheme_name_basic")] public string BasicSchemeName { get; set; }

        public void LoadDefaults()
        {
            SecurityScheme = "None";
            SecurityScopePattern = "{Resource}::{Action}";
            OpenIdConnectUrl = "http://api-studio.io/.well-known/openid-configuration";
            OAuth2SchemeName = "OAuth2";
            OpenIdConnectSchemeName = "OpenIdConnect";
            BasicSchemeName = "basic_auth";
        }
    }
}