// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.VsOptions.Helper;

namespace ApiStudioIO.VsOptions.HttpSecurity
{
    internal class SecurityScopeUITypeEditor : ApiStudioUITypeEditor
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