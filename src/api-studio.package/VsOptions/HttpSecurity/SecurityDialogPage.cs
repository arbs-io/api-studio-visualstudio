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

        [Category("Discovery Keys")]
        [DisplayName("OpenIdConnectUrl")]
        [Description("The OpenId Connect URL to discover OAuth2 configuration values. This MUST be provided when the SchemeType is set to SecuritySchemeType.OpenIdConnect")]
        public string OpenIdConnectUrl
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OpenIdConnectUrl;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OpenIdConnectUrl = value;
        }

        //Scheme Name
        [Category("Scheme Name")]
        [DisplayName("OAuth2")]
        [Description("The name of the OAuth2 schema within specification. This MUST be provided when the SchemeType is set to SecuritySchemeType.OAuth2")]
        public string OAuth2SchemeName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OAuth2SchemeName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OAuth2SchemeName = value;
        }

        [Category("Scheme Name")]
        [DisplayName("OpenId Connect")]
        [Description("The name of the OpenId Connect schema within specification. This MUST be provided when the SchemeType is set to SecuritySchemeType.OpenIdConnect")]
        public string OpenIdConnectSchemeName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OpenIdConnectSchemeName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OpenIdConnectSchemeName = value;
        }

        [Category("Scheme Name")]
        [DisplayName("Basic")]
        [Description("The name of the Basic schema within specification. This MUST be provided when the SchemeType is set to SecuritySchemeType.Basic")]
        public string BasicSchemeName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.BasicSchemeName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.BasicSchemeName = value;
        }



    }
}