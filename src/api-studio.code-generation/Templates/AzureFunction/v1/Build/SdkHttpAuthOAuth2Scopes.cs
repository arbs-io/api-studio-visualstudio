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
using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.CodeGeneration.VisualStudio;

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
            }

            return sourceList;
        }

        private static string GenerateScopes(string authorisationRole)
        {
            return $"\t\t\tscopes.Add(\"{authorisationRole}\", \"{authorisationRole}\");";
        }
    }
}