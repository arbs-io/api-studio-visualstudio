namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using ApiStudioIO.Utility.Extensions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

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

        private static SourceCodeEntity GenerateHttpTrigger(string modelName, Resource resource, HttpApi httpApi, NamespaceHelper namespaceHelper)
        {
            if (string.IsNullOrWhiteSpace(modelName))
            {
                throw new ArgumentException($"'{nameof(modelName)}' cannot be null or whitespace.", nameof(modelName));
            }
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
            return new SourceCodeEntity($"{namespaceHelper.Solution}-{httpApi.DisplayName}.HttpTrigger.cs", httpTriggerSourceCode, false);
        }

        private static string BuildHttpTriggerResponseStatusCodes(HttpApi httpApi)
        {
            var statusCode = httpApi.ResponseStatusCodes
                .First(p => p.Type == "Success");
            var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);
            if (httpStatus != null)
                return $"HttpStatusCode.{httpStatus}";
            else if (statusCode != null)
                return $"(HttpStatusCode){statusCode.HttpStatus}";
            else
                return "HttpStatusCode.OK";
        }
    }
}