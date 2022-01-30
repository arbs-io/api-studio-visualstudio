using ApiStudioIO.CodeGeneration.VisualStudio;
using ApiStudioIO.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    internal static class SdkHttpTriggerDesigner
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                            (resource, httpApi) => new { resource, httpApi })
                .ToList()
                .ForEach(x => sourceList.Add(GenerateHttpTrigger(modelName, x.resource, x.httpApi)));

            return sourceList;
        }

        private static SourceCodeEntity GenerateHttpTrigger(string modelName, Resource resource, HttpApi httpApi)
        {
            var attributes = new List<string>();
            attributes.AddRange(BuildHttpTriggerSecurity(modelName, httpApi));
            attributes.AddRange(BuildHttpTriggerParameters(httpApi));
            attributes.AddRange(BuildHttpTriggerResponseStatusCodes(httpApi));
            string openapiAttributes = string.Join(Environment.NewLine, attributes);

            var httpTriggerDesignerSourceCode = Templates.Resource.HttpTriggerDesigner
                .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb.ToUpper())
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_ATTRIBUTE}}", openapiAttributes);
            return new SourceCodeEntity($"{modelName}-{httpApi.DisplayName}.HttpTrigger.Designer.cs", httpTriggerDesignerSourceCode, true, $"{modelName}-{httpApi.DisplayName}.HttpTrigger.cs");
        }

        private static List<string> BuildHttpTriggerSecurity(string modelName, HttpApi httpApi)
        {
            var attributes = new List<string>();
            var securityApiKey = httpApi.ApiStudio.SecurityApiKey;
            if (!string.IsNullOrEmpty(securityApiKey))
            {
                attributes.Add($"\t\t[OpenApiSecurity(\"ApiKey\", SecuritySchemeType.ApiKey, Name = \"{securityApiKey}\", In = OpenApiSecurityLocationType.Header)]");
            }

            if(httpApi.ApiStudio.SecuritySchemeType == SecuritySchemeTypes.OAuth2)
            {
                attributes.Add($"[OpenApiSecurity(\"ApiStudioAuthentication\", SecuritySchemeType.OAuth2, Flows = typeof({modelName}OpenApiOAuthSecurityFlows))]");
            }
            return attributes;
        }

        private static List<string> BuildHttpTriggerResponseStatusCodes(HttpApi httpApi)
        {
            var attributes = new List<string>();
            foreach (var statusCode in httpApi.ResponseStatusCodes)
            {
                var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);
                if (httpStatus != null)
                {
                    httpStatus = $"HttpStatusCode.{httpStatus}";
                }
                else
                {
                    httpStatus = $"(HttpStatusCode){statusCode.HttpStatus}";
                }

                if (statusCode.Type == "Success" && httpApi.DataModels.Count > 0)
                {
                    attributes.Add($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof({httpApi.DataModels?[0].Name}), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
                else if (statusCode.Type == "Success" && httpApi.DataModels.Count == 0)
                {
                    attributes.Add($"\t\t[OpenApiResponseWithoutBody(statusCode: {httpStatus}, Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
                else if (statusCode.Type == "Client Error")
                {
                    attributes.Add($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof(ErrorModel), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
            }
            return attributes;
        }

        private static List<string> BuildHttpTriggerParameters(HttpApi httpApi)
        {
            var attributes = new List<string>();
            foreach (var header in httpApi.RequestHeaders)
            {
                var attribute = $"\t\t[OpenApiParameter(";
                attribute += $"name: \"{header.Name.ToAlphaNumeric()}\", ";
                attribute += $"In = ParameterLocation.Header, ";
                attribute += $"Required = {header.IsRequired.ToString().ToLower()}, ";
                attribute += $"Type = typeof(string), ";
                attribute += $"Summary = \"{header.Description}\", ";
                attribute += $"Description = \"{header.Description}\", ";
                attribute += $"Visibility = OpenApiVisibilityType.Important)]";
                attributes.Add(attribute);
            }

            foreach (var parameter in httpApi.RequestParameters)
            {
                var parameterType = parameter.FromType.ConvertOpenApiAttribute();
                if (parameterType == "ParameterLocation.Body")
                {
                    var attribute = $"\t\t[OpenApiRequestBody(";
                    attribute += $"contentType: \"application/json\", ";
                    attribute += $"bodyType: typeof({parameter.DataType}), ";
                    attribute += $"Required = {parameter.IsRequired.ToString().ToLower()}, ";
                    attribute += $"Description = \"{parameter.Description}\")]";
                    attributes.Add(attribute);
                }
                else
                {
                    var attribute = $"\t\t[OpenApiParameter(";
                    attribute += $"name: \"{parameter.Name.ToAlphaNumeric()}\", ";
                    attribute += $"In = {parameter.FromType.ConvertOpenApiAttribute()}, ";
                    attribute += $"Required = {parameter.IsRequired.ToString().ToLower()}, ";
                    attribute += $"Type = typeof({parameter.DataType}), ";
                    attribute += $"Summary = \"{parameter.Description}\", ";
                    attribute += $"Description = \"{parameter.Description}\", ";
                    attribute += $"Visibility = OpenApiVisibilityType.Important)]";
                    attributes.Add(attribute);
                }
            }
            return attributes;
        }

        private static string ConvertOpenApiAttribute(this HttpApiParameterTypes httpApiParameterTypes)
        {
            switch (httpApiParameterTypes)
            {
                case HttpApiParameterTypes.Query:
                    return "ParameterLocation.Query";
                case HttpApiParameterTypes.Path:
                    return "ParameterLocation.Path";
                case HttpApiParameterTypes.Body:
                    return "ParameterLocation.Body";
                default:
                    return "ParameterLocation.Undefined";
            }
        }
    }
}