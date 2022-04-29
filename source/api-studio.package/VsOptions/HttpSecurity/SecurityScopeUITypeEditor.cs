namespace ApiStudioIO.VsOptions.HttpSecurity
{
    using ApiStudioIO.VsOptions.Helper;

    class SecurityScopeUITypeEditor : ApiStudioUITypeEditor
    {
        private static readonly string[] securityPatterns =
            {
                "{Resource}::{Action}",
                "{ApiName}::{Resource}::{Action}",
                "{Provider}.{Product}.{ApiName}.{Resource}.{Action}",
                "{Product}.{ApiName}.{Resource}.{Action}",
                "{ApiName}.{Resource}.{Action}",
                "{Resource}.{Action}"
            };

        public SecurityScopeUITypeEditor() : base(securityPatterns)
        {
        }
    }
}
