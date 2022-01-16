using ApiStudioIO.CodeGeneration.VisualStudio;
using ApiStudioIO.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace ApiStudioIO.CodeGeneration.AzureFunction.v1
{
    internal static class SdkHttpTrigger
    {
        internal static List<SourceCodeEntity> Build(ApiStudio apiStudio, string modelName)
        {
            var sourceList = new List<SourceCodeEntity>();
            apiStudio?.Resourced
                .SelectMany(resource => resource.HttpApis,
                            (resource, httpApi) => new { resource, httpApi })
                .ToList()
                .ForEach(x => sourceList.AddRange(GenerateHttpTrigger(modelName, x.resource, x.httpApi)));

            return sourceList;
        }

        private static IEnumerable<SourceCodeEntity> GenerateHttpTrigger(string modelName, Resource resource, HttpApi httpApi)
        {
            var sourceList = new List<SourceCodeEntity>();

            var httpTriggerSourceCode = Templates.Resource.HttpTrigger
                .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb.ToUpper())
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri);
            sourceList.Add(new SourceCodeEntity($"{modelName}-{httpApi.DisplayName}.HttpTrigger.cs", httpTriggerSourceCode, false));

            var httpTriggerDesignerSourceCode = Templates.Resource.HttpTriggerDesigner
                .Replace("{{TOKEN_OAS_NAMESPACE}}", modelName)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb.ToUpper())
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_PARAMETERS}}", BuildHttpTriggerParameters(httpApi))
                .Replace("{{TOKEN_OAS_HTTP_RESPONSE}}", BuildHttpTriggerResponseStatusCodes(httpApi));

            sourceList.Add(new SourceCodeEntity($"{modelName}-{httpApi.DisplayName}.HttpTrigger.Designer.cs", httpTriggerDesignerSourceCode, true, $"{modelName}-{httpApi.DisplayName}.HttpTrigger.cs"));

            return sourceList;
        }


        private static string BuildHttpTriggerResponseStatusCodes(HttpApi httpApi)
        {
            var sb = new StringBuilder();
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
                    sb.AppendLine($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof({httpApi.DataModels?[0].Name}), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
                else if (statusCode.Type == "Success" && httpApi.DataModels.Count == 0)
                {
                    sb.AppendLine($"\t\t[OpenApiResponseWithoutBody(statusCode: {httpStatus}, Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
                else if (statusCode.Type == "Client Error")
                {
                    sb.AppendLine($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof(ErrorModel), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\")]");
                }
            }
            return sb.ToString();
        }

        private static string BuildHttpTriggerParameters(HttpApi httpApi)
        {
            var sb = new StringBuilder();
            foreach (var header in httpApi.RequestHeaders)
            {
                sb.Append($"\t\t[OpenApiParameter(");
                sb.Append($"name: \"{header.Name.ToAlphaNumeric()}\", ");
                sb.Append($"In = ParameterLocation.Header, ");
                sb.Append($"Required = {header.IsRequired.ToString().ToLower()}, ");
                sb.Append($"Type = typeof(string), ");
                sb.Append($"Summary = \"{header.Description}\", ");
                sb.Append($"Description = \"{header.Description}\", ");
                sb.AppendLine($"Visibility = OpenApiVisibilityType.Important)]");
            }

            foreach (var parameter in httpApi.RequestParameters)
            {
                var parameterType = parameter.FromType.ConvertOpenApiAttribute();
                if (parameterType == "ParameterLocation.Body")
                {
                    sb.Append($"\t\t[OpenApiRequestBody(");
                    sb.Append($"contentType: \"application/json\", ");
                    sb.Append($"bodyType: typeof({parameter.DataType}), ");
                    sb.Append($"Required = {parameter.IsRequired.ToString().ToLower()}, ");
                    sb.Append($"Description = \"{parameter.Description}\")]");
                }
                else
                {
                    sb.Append($"\t\t[OpenApiParameter(");
                    sb.Append($"name: \"{parameter.Name.ToAlphaNumeric()}\", ");
                    sb.Append($"In = {parameter.FromType.ConvertOpenApiAttribute()}, ");
                    sb.Append($"Required = {parameter.IsRequired.ToString().ToLower()}, ");
                    sb.Append($"Type = typeof({parameter.DataType}), ");
                    sb.Append($"Summary = \"{parameter.Description}\", ");
                    sb.Append($"Description = \"{parameter.Description}\", ");
                    sb.AppendLine($"Visibility = OpenApiVisibilityType.Important)]");
                }
            }
            return sb.ToString();
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