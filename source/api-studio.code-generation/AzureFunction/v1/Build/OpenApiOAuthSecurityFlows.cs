using ApiStudioIO.CodeGeneration.VisualStudio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    internal static class OpenApiOAuthSecurityFlows
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var scopeList = new List<string>();
            apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                            (resource, httpApi) => new { resource, httpApi })
                .GroupBy(x => x.httpApi.AuthorisationRole)
                .Select(x => x.Key)
                .ToList()
                .ForEach(x => scopeList.Add(GenerateScopes(x)));
            string scopes = string.Join($",{Environment.NewLine}", scopeList);

            var sourceList = new List<SourceCodeEntity>();
            var sourceCode = Templates.Resource.OpenApiOAuthSecurityFlows
                .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                .Replace("{{TOKEN_OAS_SCOPES}}", scopes);
            sourceList.Add(new SourceCodeEntity($"{modelName}-OpenApiOAuthSecurityFlows.Security.cs", sourceCode, false));
            return sourceList;
        }
        private static string GenerateScopes(string authorisationRole)
        {
            return "\t\t\t\t\t{ " + $"\"{authorisationRole}\", \"TODO\"" + "}";
        }
    }
}