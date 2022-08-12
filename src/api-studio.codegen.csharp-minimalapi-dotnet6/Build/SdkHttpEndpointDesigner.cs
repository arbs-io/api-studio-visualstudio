// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using ApiStudioIO.Common.Models.Build;
using ApiStudioIO.Common.Models.Http;
using ApiStudioIO.Utility.Extensions;
using ApiStudioIO.Vs.Options;
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

            var attributes = new List<string>();
            attributes.AddRange(BuildHttpTriggerParameters(httpApi));
            attributes.AddRange(BuildHttpTriggerResponseStatusCodes(httpApi));
            var openapiAttributes = string.Join(Environment.NewLine, attributes);

            var httpTriggerDesignerSourceCode = Templates.MinimalApiResource.HttpEndpointDesigner
                .Replace("{{TOKEN_OAS_PROJECTNAME}}", buildTargetModel.ProjectName)
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_NAMESPACE_DATAMODEL}}", namespaceHelper.DataModel)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb)
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_ATTRIBUTE}}", openapiAttributes);

            VsLogger.Log($"[SdkHttpEndpointDesigner]: {namespaceHelper.Solution}-{httpApi.DisplayName}.HttpEndpoint.Designer");

            return new SourceCodeEntity($"{namespaceHelper.Solution}-{httpApi.DisplayName}.HttpEndpoint.Designer.cs",
                httpTriggerDesignerSourceCode, true, $"{modelName}-{httpApi.DisplayName}.HttpEndpoint.cs");
        }
        

        private static List<string> BuildHttpTriggerResponseStatusCodes(HttpApi httpApi)
        {
            var attributes = new List<string>();
            foreach (var statusCode in httpApi.ResponseStatusCodes)
            {
                var responseHeader = "ResponseHeader";
                if (statusCode.Type == "Information") responseHeader += "OnInformation";
                else if (statusCode.Type == "Success") responseHeader += "OnSuccess";
                else if (statusCode.Type == "Redirection") responseHeader += "OnRedirection";
                else if (statusCode.Type == "Client Error") responseHeader += "OnClientError";
                else if (statusCode.Type == "Server Error") responseHeader += "OnServerError";

                var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);
                httpStatus = httpStatus != null
                    ? $"HttpStatusCode.{httpStatus}"
                    : $"(HttpStatusCode){statusCode.HttpStatus}";

                if (httpApi.DataModels != null && statusCode.Type == "Success" && httpApi.DataModels.Count > 0)
                    attributes.Add(
                        $"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof({httpApi.DataModels?[0].Name}), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                else if (httpApi.DataModels != null && statusCode.Type == "Success" && httpApi.DataModels.Count == 0)
                    attributes.Add(
                        $"\t\t[OpenApiResponseWithoutBody(statusCode: {httpStatus}, Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                else
                    attributes.Add(
                        $"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof(ErrorModel), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
            }

            return attributes;
        }

        private static List<string> BuildHttpTriggerParameters(HttpApi httpApi)
        {
            var attributes = new List<string>();
            foreach (var header in httpApi.RequestHeaders)
            {
                var attribute = "\t\t[OpenApiParameter(";
                attribute += $"name: \"{header.Name}\", ";
                attribute += "In = ParameterLocation.Header, ";
                attribute += $"Required = {header.IsRequired.ToString().ToLower()}, ";
                attribute += "Type = typeof(string), ";
                attribute += $"Summary = \"{header.Description}\", ";
                attribute += $"Description = \"{header.Description}\", ";
                attribute += "Visibility = OpenApiVisibilityType.Important)]";
                attributes.Add(attribute);
            }

            foreach (var parameter in httpApi.RequestParameters)
            {
                var parameterType = parameter.FromType.ConvertOpenApiAttribute();
                if (parameterType == "ParameterLocation.Body")
                {
                    var attribute = "\t\t[OpenApiRequestBody(";
                    attribute += "contentType: \"application/json\", ";
                    attribute += $"bodyType: typeof({parameter.DataType}), ";
                    attribute += $"Required = {parameter.IsRequired.ToString().ToLower()}, ";
                    attribute += $"Description = \"{parameter.Description}\")]";
                    attributes.Add(attribute);
                }
                else
                {
                    var attribute = "\t\t[OpenApiParameter(";
                    attribute += $"name: \"{parameter.Name.ToAlphaNumeric()}\", ";
                    attribute += $"In = {parameter.FromType.ConvertOpenApiAttribute()}, ";
                    attribute += $"Required = {parameter.IsRequired.ToString().ToLower()}, ";
                    attribute += $"Type = typeof({parameter.DataType}), ";
                    attribute += $"Summary = \"{parameter.Description}\", ";
                    attribute += $"Description = \"{parameter.Description}\", ";
                    attribute += "Visibility = OpenApiVisibilityType.Important)]";
                    attributes.Add(attribute);
                }
            }

            return attributes;
        }

        private static string ConvertOpenApiAttribute(this HttpTypeParameterLocation httpTypeParameterLocation)
        {
            switch (httpTypeParameterLocation)
            {
                case HttpTypeParameterLocation.Query: return "ParameterLocation.Query";
                case HttpTypeParameterLocation.Path: return "ParameterLocation.Path";
                case HttpTypeParameterLocation.Body: return "ParameterLocation.Body";

                default:
                    throw new InvalidEnumArgumentException(nameof(httpTypeParameterLocation),
                        (int)httpTypeParameterLocation, typeof(HttpTypeParameterLocation));
            }
        }
    }
}