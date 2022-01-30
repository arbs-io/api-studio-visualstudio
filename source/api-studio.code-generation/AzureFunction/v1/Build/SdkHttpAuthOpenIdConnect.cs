﻿using ApiStudioIO.CodeGeneration.VisualStudio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    internal static class SdkHttpAuthOpenIdConnect
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            if (apiStudio.SecuritySchemeType == SecuritySchemeTypes.OpenIdConnect)
            {
                var sourceCode = Templates.Resource.HttpAuthOAuth2
                    .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName);
                sourceList.Add(new SourceCodeEntity($"{modelName}.OpenIdConnect.cs", sourceCode, false));
            }
            return sourceList;
        }
    }
}