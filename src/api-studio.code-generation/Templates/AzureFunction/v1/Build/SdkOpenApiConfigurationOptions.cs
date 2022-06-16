// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.CodeGeneration.VisualStudio;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    internal static class SdkOpenApiConfigurationOptions
    {
        internal static List<SourceCodeEntity> Build(ApiStudio eai, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            var template = Templates.Resource.OpenApiConfigurationOptions;

            var output = template
                .Replace("{{TOKEN_OAS_TITLE}}", eai?.Title)
                .Replace("{{TOKEN_OAS_VERSION}}", eai?.Version)
                .Replace("{{TOKEN_OAS_DESCRIPTION}}", eai?.Description)
                .Replace("{{TOKEN_OAS_CONTACT_URL}}", eai?.ContactUrl)
                .Replace("{{TOKEN_OAS_CONTACT_NAME}}", eai?.ContactName);

            sourceList.Add(
                new SourceCodeEntity("ApiStudio.OpenApiConfigurationOptions.cs", output, true));

            return sourceList;
        }
    }
}