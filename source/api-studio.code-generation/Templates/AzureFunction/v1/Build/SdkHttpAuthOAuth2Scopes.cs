namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal static class SdkHttpAuthOAuth2Scopes
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            if (apiStudio.SecuritySchemeType == SecuritySchemeTypes.OAuth2 ||
                apiStudio.SecuritySchemeType == SecuritySchemeTypes.OpenIdConnect)
            {
                var scopeList = new List<string>();
                apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                            (resource, httpApi) => new { resource, httpApi })
                .GroupBy(x => x.httpApi.AuthorisationRole)
                .Select(x => x.Key)
                .ToList()
                .ForEach(x => scopeList.Add(GenerateScopes(x)));
                string scopes = string.Join($"{Environment.NewLine}", scopeList);

                var sourceCode = Templates.Resource.HttpAuthOAuth2Scopes
                    .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                    .Replace("{{TOKEN_OAS_SCOPES}}", scopes);
                sourceList.Add(new SourceCodeEntity($"{modelName}.OAuth2.Scopes.cs", sourceCode, true, $"{modelName}.OAuth2.cs"));
            }
            return sourceList;
        }
        private static string GenerateScopes(string authorisationRole)
        {
            return $"\t\t\tscopes.Add(\"{authorisationRole}\", \"{authorisationRole}\");";
        }
    }
}