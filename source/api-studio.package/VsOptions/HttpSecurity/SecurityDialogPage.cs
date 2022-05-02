namespace ApiStudioIO.VsOptions.HttpSecurity
{
    using ApiStudioIO.VsOptions.ConfigurationV1;
    using ApiStudioIO.VsOptions.ConfigurationV1.Models;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;

    [Guid("8dda9af5-90e5-43bc-9983-d4604664cb7c")]
    public class SecurityDialogPage : DialogPage
    {
        public override void SaveSettingsToStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.SaveSettingsToStorage();
            ApiStudioUserSettingsStore.Instance.VsOptionStoreSave();
        }

        public override void LoadSettingsFromStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.LoadSettingsFromStorage();
            ApiStudioUserSettingsStore.Instance.VsOptionStoreLoad();
        }

        [Category("Roles")]
        [DisplayName("Security Scheme")]
        [Description("Defines a security scheme that can be used by the operations. Supported schemes are HTTP authentication, an API key (either as a header or as a query parameter), OAuth2's common flows (implicit, password, application and access code) as defined in RFC6749, and OpenID Connect Discovery.")]
        [Editor(typeof(SecuritySchemesUITypeEditor), typeof(UITypeEditor))]
        public string SecurityScheme
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.SecurityScheme;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.SecurityScheme = value;
        }

        [Category("Roles")]
        [DisplayName("Pattern")]
        [Description("The pattern to be used when building roles within the API specification")]
        [Editor(typeof(SecurityScopeUITypeEditor), typeof(UITypeEditor))]
        public string SecurityScopePattern
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.SecurityScopePattern;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.SecurityScopePattern = value;
        }
    }
}
