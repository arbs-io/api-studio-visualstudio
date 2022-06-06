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

using System;
using ApiStudioIO.VsOptions.ConfigurationV1;

namespace ApiStudioIO
{
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public partial class ApiStudio
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="store">Store where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public ApiStudio(DslModeling.Store store, params DslModeling.PropertyAssignment[] propertyAssignments)
            : this(store?.DefaultPartitionForClass(DomainClassId), propertyAssignments)
        {
            SetDefaultsProperties();
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="partition">Partition where new element is to be created.</param>
        /// <param name="propertyAssignments">List of domain property id/value pairs to set once the element is created.</param>
        public ApiStudio(DslModeling.Partition partition, params DslModeling.PropertyAssignment[] propertyAssignments)
            : base(partition, propertyAssignments)
        {
            SetDefaultsProperties();
        }

        private void SetDefaultsProperties()
        {
            if (Identifier.ToString() == "00000000-0000-0000-0000-000000000000")
                using (var t = Store.TransactionManager.BeginTransaction("ApiStudio.SetIdentifierValue"))
                {
                    Identifier = Guid.NewGuid();
                    SecuritySchemeType = GetDefaultSecuritySchemeType();

                    var specification = ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification;
                    Vendor = specification.VendorName;
                    Product = specification.ProductName;
                    ApiName = specification.ApiName;
                    ContactName = specification.ContactName;
                    ContactUrl = specification.ContactUrl;
                    Description = specification.Description;
                    Audience = GetDefaultAudienceType();

                    t.Commit();
                }
        }

        private SecuritySchemeTypes GetDefaultSecuritySchemeType()
        {
            switch (ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.SecurityScheme)
            {
                case "None":
                    return SecuritySchemeTypes.None;
                case "Basic":
                    return SecuritySchemeTypes.Basic;
                case "OAuth2":
                    return SecuritySchemeTypes.OAuth2;
                case "OpenIdConnect":
                    return SecuritySchemeTypes.OpenIdConnect;
                default:
                    return SecuritySchemeTypes.None;
            }
        }

        private HttpApiAudienceTypes GetDefaultAudienceType()
        {
            switch (ApiStudioUserSettingsStore.Instance.Data.DefaultSpecification.Audience)
            {
                case "Private":
                    return HttpApiAudienceTypes.Private;
                case "Partner":
                    return HttpApiAudienceTypes.Partner;
                case "Public":
                    return HttpApiAudienceTypes.Public;
                default:
                    return HttpApiAudienceTypes.Public;
            }
        }

        public string GetTitleValue()
        {
            return $@"{Vendor} {Product} - {ApiName} v{Version}";
        }
    }
}