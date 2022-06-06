using ApiStudioIO.VsOptions.Helper;

namespace ApiStudioIO.VsOptions.HttpSecurity
{
    internal class SecuritySchemesUITypeEditor : ApiStudioUITypeEditor
    {
        private static readonly string[] securityPatterns =
        {
            "None",
            "Basic",
            "OAuth2",
            "OpenIdConnect"
        };

        public SecuritySchemesUITypeEditor() : base(securityPatterns)
        {
        }
    }
}