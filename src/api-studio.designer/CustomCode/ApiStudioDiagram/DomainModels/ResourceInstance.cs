// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO
{
    public partial class ResourceInstance
    {
        protected override string GetHttpApiUriValue()
        {
            string documentId;
            switch (ApiStudio.CodeGenerationVariableCaseType)
            {
                case CodeGenerationVariableCaseTypes.CamelCase:
                    documentId = InstanceIdentity.ToCamelCase();
                    break;

                case CodeGenerationVariableCaseTypes.PascalCase:
                    documentId = InstanceIdentity.ToPascalCase();
                    break;

                case CodeGenerationVariableCaseTypes.SnakeCase:
                    documentId = InstanceIdentity.ToSnakeCase();
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }

            var uri = "";
            if (SourceResource.Count > 0) uri = SourceResource[0].HttpApiUri;

            uri += $"/{{{documentId}}}";
            return FormatUri(uri);
        }

        internal partial class InstanceDataTypePropertyHandler
        {
            protected override void OnValueChanged(ResourceInstance element, string oldValue, string newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);
                element.SetResourceDefaults();
            }
        }
        internal partial class InstanceIdentityPropertyHandler
        {
            protected override void OnValueChanged(ResourceInstance element, string oldValue, string newValue)
            {
                base.OnValueChanged(element, oldValue, newValue);
                element.SetResourceDefaults();
            }
        }
    }
}