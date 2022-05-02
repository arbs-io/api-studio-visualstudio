﻿namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using System.Collections.Generic;

    internal static class SdkHttpAuthOAuth2
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            if (apiStudio.SecuritySchemeType == SecuritySchemeTypes.OAuth2 ||
                apiStudio.SecuritySchemeType == SecuritySchemeTypes.OpenIdConnect)
            {
                var sourceCode = Templates.Resource.HttpAuthOAuth2
                    .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName);
                sourceList.Add(new SourceCodeEntity($"{modelName}.OAuth2.cs", sourceCode, false));
            }
            return sourceList;
        }
    }
}