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
using System.Net;
using ApiStudioIO.CodeGeneration.VisualStudio;
using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1.Build
{
    internal static class SdkHttpTrigger
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
            apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                    (resource, httpApi) => new { resource, httpApi })
                .ToList()
                .ForEach(x => sourceList.Add(GenerateHttpTrigger(modelName, x.resource, x.httpApi, namespaceHelper)));

            return sourceList;
        }

        private static SourceCodeEntity GenerateHttpTrigger(string modelName, Resource resource, HttpApi httpApi,
            NamespaceHelper namespaceHelper)
        {
            if (string.IsNullOrWhiteSpace(modelName))
                throw new ArgumentException(
                    string.Format(
                        Templates.Resource.SdkHttpTrigger_GenerateHttpTrigger___0___cannot_be_null_or_whitespace_,
                        nameof(modelName)), nameof(modelName));
            _ = resource ?? throw new ArgumentNullException(nameof(resource));
            _ = httpApi ?? throw new ArgumentNullException(nameof(httpApi));

            var responseMediaType = httpApi.HttpApiMediaTypeResponsed
                .FirstOrDefault()?.DisplayName ?? "application/json";

            var httpTriggerSourceCode = Templates.Resource.HttpTrigger
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb.ToUpper())
                .Replace("{{TOKEN_OAS_HTTP_RESPONSE_MIME}}", responseMediaType.ToLower())
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_STATUS_CODE}}", BuildHttpTriggerResponseStatusCodes(httpApi));
            return new SourceCodeEntity($"{namespaceHelper.Solution}-{httpApi.DisplayName}.HttpTrigger.cs",
                httpTriggerSourceCode, false);
        }

        private static string BuildHttpTriggerResponseStatusCodes(HttpApi httpApi)
        {
            var statusCode = httpApi.ResponseStatusCodes
                .First(p => p.Type == "Success");
            var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);
            if (httpStatus != null)
                return $"HttpStatusCode.{httpStatus}";
            return $"(HttpStatusCode){statusCode.HttpStatus}";
        }
    }
}