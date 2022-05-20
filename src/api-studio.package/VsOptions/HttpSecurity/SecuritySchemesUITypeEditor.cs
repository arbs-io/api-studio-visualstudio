namespace ApiStudioIO.VsOptions.HttpSecurity
{
    using ApiStudioIO.VsOptions.Helper;

    class SecuritySchemesUITypeEditor : ApiStudioUITypeEditor
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
