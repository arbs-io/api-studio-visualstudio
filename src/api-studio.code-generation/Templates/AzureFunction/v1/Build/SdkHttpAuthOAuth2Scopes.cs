// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Vs.VisualStudio;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    internal static class SdkHttpAuthOAuth2Scopes
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            if (apiStudio.SecuritySchemeType == SecuritySchemeTypes.OAuth2 ||
                apiStudio.SecuritySchemeType == SecuritySchemeTypes.OpenIdConnect)
            {
                var scopeList = new List<string>();
                apiStudio.Resourced
                    .SelectMany(resource => resource.HttpApis,
                        (resource, httpApi) => new { resource, httpApi })
                    .GroupBy(x => x.httpApi.AuthorisationRole)
                    .Select(x => x.Key)
                    .ToList()
                    .ForEach(x => scopeList.Add(GenerateScopes(x)));
                var scopes = string.Join($"{Environment.NewLine}", scopeList);

                var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
                var sourceCode = Templates.Resource.HttpAuthOAuth2Scopes
                    .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                    .Replace("{{TOKEN_OAS_CLASS_NAME}}", modelName)
                    .Replace("{{TOKEN_OAS_SCOPES}}", scopes);
                sourceList.Add(new SourceCodeEntity($"{namespaceHelper.Solution}.OAuth2.Scopes.cs", sourceCode, true,
                    $"{namespaceHelper.Solution}.OAuth2.cs"));

                VisualStudioDebug.OutputString($"[SdkHttpAuthOAuth2Scopes]: OAuth2/OpenIdConnect");
            }

            return sourceList;
        }

        private static string GenerateScopes(string authorisationRole)
        {
            return $"\t\t\tscopes.Add(\"{authorisationRole}\", \"{authorisationRole}\");";
        }
    }
}