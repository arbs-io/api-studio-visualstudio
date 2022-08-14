// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Utility.Extensions;
using ApiStudioIO.Vs.Output;

namespace ApiStudioIO.CodeGen.CSharpMinimalApiDotNet6.Build
{
    internal static class SdkHttpEndpointDesigner
    {
        internal static List<SourceCodeEntity> Build(BuildTargetModel buildTargetModel, ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();

            var namespaceHelper = new NamespaceHelper(apiStudio, modelName);
            apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                    (resource, httpApi) => new { resource, httpApi })
                .ToList()
                .ForEach(x => sourceList.Add(GenerateHttpTrigger(buildTargetModel, modelName, x.resource, x.httpApi, namespaceHelper)));

            return sourceList;
        }

        private static SourceCodeEntity GenerateHttpTrigger(BuildTargetModel buildTargetModel, string modelName, Resource resource, HttpApi httpApi,
            NamespaceHelper namespaceHelper)
        {
            if (string.IsNullOrWhiteSpace(modelName))
                throw new ArgumentException(
                    string.Format(
                        Templates.MinimalApiResource
                            .SdkHttpDesigner_GenerateHttp___0___cannot_be_null_or_whitespace_,
                        nameof(modelName)), nameof(modelName));
            _ = resource ?? throw new ArgumentNullException(nameof(resource));
            _ = httpApi ?? throw new ArgumentNullException(nameof(httpApi));

            var httpEndpointResponses = BuildHttpEndpointResponseStatusCodes(httpApi);

            var httpTriggerDesignerSourceCode = Templates.MinimalApiResource.HttpEndpointDesigner
                .Replace("{{TOKEN_OAS_PROJECT_NAME}}", buildTargetModel.ProjectName)
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb)
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_TAG}}", $"{modelName}")
                .Replace("{{TOKEN_OAS_HTTP_NAME}}", $"{httpApi.DisplayName}")
                .Replace("{{TOKEN_OAS_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_PRODUCES}}", string.Join(Environment.NewLine, httpEndpointResponses));

            VsLogger.Log($"[SdkHttpEndpointDesigner]: {namespaceHelper.Solution}-{httpApi.DisplayName}.HttpEndpoint.Designer");

            return new SourceCodeEntity($"{namespaceHelper.Solution}-{httpApi.DisplayName}.HttpEndpoint.Designer.cs",
                httpTriggerDesignerSourceCode, true, $"{modelName}-{httpApi.DisplayName}.HttpEndpoint.cs");
        }
        

        private static List<string> BuildHttpEndpointResponseStatusCodes(HttpApi httpApi)
        {
            var applicationJson = "\"application/json\"";
            var attributes = new List<string>();
            foreach (var statusCode in httpApi.ResponseStatusCodes)
            {
                var httpStatus = Enum.GetName(typeof(HttpStatusCodes), statusCode.HttpStatus);
                httpStatus = httpStatus != null
                    ? $"StatusCodes.{httpStatus}"
                    : $"{statusCode.HttpStatus}";

                if (httpApi.DataModels != null && statusCode.Type == "Success" && httpApi.DataModels.Count > 0)
                    attributes.Add(
                        $"\t\t\t\t.Produces<{httpApi.DataModels?[0].Name}>(statusCode: {httpStatus}, contentType: {applicationJson})");
                        //$"\t\t\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof({httpApi.DataModels?[0].Name}), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                else if (httpApi.DataModels != null && statusCode.Type == "Success" && httpApi.DataModels.Count == 0)
                    attributes.Add(
                        $"\t\t\t\t.Produces(statusCode: {httpStatus}, contentType: {applicationJson})");
                        //$"\t\t\t\t[OpenApiResponseWithoutBody(statusCode: {httpStatus}, Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                else
                    attributes.Add(
                        $"\t\t\t\t.Produces<ErrorModel>(statusCode: {httpStatus}, contentType: {applicationJson})");
            }
            return attributes;
        }
    }
}