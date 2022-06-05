namespace ApiStudioIO.VsOptions.HttpSpecification
{
    using ApiStudioIO.VsOptions.ConfigurationV1;
    using ApiStudioIO.VsOptions.ConfigurationV1.Models;
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;

    [Guid("66d04e60-dba3-45b2-a3da-37445efaa696")]
    public class SpecificationDialogPage : DialogPage
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

        [Category("Organisation")]
        [DisplayName("Vendor")]
        [Description("The name of the organisation providing the API specification. This will form part of the contract title.")]
        public string VendorName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.VendorName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.VendorName = value;
        }

        [Category("Organisation")]
        [DisplayName("Product")]
        [Description("The name of the product the api is part a member. This will form part of the contract title.")]
        public string ProductName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ProductName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ProductName = value;
        }

        [Category("Organisation")]
        [DisplayName("Api")]
        [Description("The name of the API. Normally based on the subdomain and/or feature for the API contract. This will form part of the contract title.")]
        public string ApiName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ApiName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ApiName = value;
        }

        [Category("Contact")]
        [DisplayName("Contact Name")]
        [Description("The name of the solution provider e.g. a shared mailbox.")]
        public string ContactName
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ContactName;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ContactName = value;
        }

        [Category("Contact")]
        [DisplayName("Contact Url")]
        [Description("The url which provides additional information about the solution or team.")]
        public string ContactUrl
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ContactUrl;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.ContactUrl = value;
        }

        [Category("Template")]
        [DisplayName("Audience")]
        [Description("The audience category flags if the consumers are Private (Internal), Partner (Trusted/VPN), Public (Public Domain).")]
        [Editor(typeof(AudienceUITypeEditor), typeof(UITypeEditor))]
        public string Audience
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Audience;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Audience = value;
        }

        [Category("Template")]
        [DisplayName("Description")]
        [Description("The value is used as the description for the resource tree and will form part of the OpenAPI specification.")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Description;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Description = value;
        }
    }
}