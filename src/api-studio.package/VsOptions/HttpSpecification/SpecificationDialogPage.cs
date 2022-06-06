// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using ApiStudioIO.VsOptions.ConfigurationV1;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.VsOptions.HttpSpecification
{
    [Guid("66d04e60-dba3-45b2-a3da-37445efaa696")]
    public class SpecificationDialogPage : DialogPage
    {
        [Category("Organisation")]
        [DisplayName("Vendor")]
        [Description(
            "The name of the organisation providing the API specification. This will form part of the contract title.")]
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
        [Description(
            "The name of the API. Normally based on the subdomain and/or feature for the API contract. This will form part of the contract title.")]
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
        [Description(
            "The audience category flags if the consumers are Private (Internal), Partner (Trusted/VPN), Public (Public Domain).")]
        [Editor(typeof(AudienceUITypeEditor), typeof(UITypeEditor))]
        public string Audience
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Audience;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Audience = value;
        }

        [Category("Template")]
        [DisplayName("Description")]
        [Description(
            "The value is used as the description for the resource tree and will form part of the OpenAPI specification.")]
        [Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
        public string Description
        {
            get => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Description;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Description = value;
        }

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
    }
}