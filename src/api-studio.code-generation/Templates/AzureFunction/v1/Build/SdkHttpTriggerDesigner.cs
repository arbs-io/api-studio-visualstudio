namespace ApiStudioIO.CodeGeneration.Templates.AzureFunction.v1
{
    using ApiStudioIO.CodeGeneration.VisualStudio;
    using ApiStudioIO.Utility.Extensions;
    using ApiStudioIO.VsOptions.ConfigurationV1;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Net;
    using System.Text;

    internal static class SdkHttpTriggerDesigner
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

            var attributes = new List<string>();
            attributes.AddRange(BuildHttpTriggerSecurity(modelName, httpApi));
            attributes.AddRange(BuildHttpTriggerParameters(httpApi));
            attributes.AddRange(BuildHttpTriggerResponseStatusCodes(httpApi));
            string openapiAttributes = string.Join(Environment.NewLine, attributes);
            
            var httpTriggerDesignerSourceCode = Templates.Resource.HttpTriggerDesigner
                .Replace("{{TOKEN_OAS_NAMESPACE}}", namespaceHelper.Solution)
                .Replace("{{TOKEN_OAS_MODEL}}", modelName)
                .Replace("{{TOKEN_OAS_NAMESPACE_DATAMODEL}}", namespaceHelper.DataModel)
                .Replace("{{TOKEN_OAS_CLASS_NAME}}", $"Http{httpApi.DisplayName.ToAlphaNumeric()}")
                .Replace("{{TOKEN_OAS_FUNCTION_NAME}}", httpApi.DisplayName.ToAlphaNumeric())
                .Replace("{{TOKEN_OAS_FUNCTION_DESCRIPTION}}", httpApi.Description)
                .Replace("{{TOKEN_OAS_HTTP_VERB}}", httpApi.HttpVerb.ToUpper())
                .Replace("{{TOKEN_OAS_HTTP_URI}}", resource.HttpApiUri)
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_ATTRIBUTE}}", openapiAttributes)
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_INFORMATION}}", BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes.OnInformation, "OnInformation", httpApi))
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_SUCCESS}}", BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes.OnSuccess, "OnSuccess", httpApi))
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_REDIRECTION}}", BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes.OnRedirection, "OnRedirection", httpApi))
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_CLIENTERROR}}", BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes.OnClientError, "OnClientError", httpApi))
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_SERVERERROR}}", BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes.OnServerError, "OnServerError", httpApi));
            return new SourceCodeEntity($"{namespaceHelper.Solution}-{httpApi.DisplayName}.HttpTrigger.Designer.cs", httpTriggerDesignerSourceCode, true, $"{modelName}-{httpApi.DisplayName}.HttpTrigger.cs");
        }
        
        private static string BuildHttpTriggerResponseHeader(HttpApiHeaderResponseOnTypes onTypes, string className, HttpApi httpApi)
        {
            StringBuilder responseHeaderItems = new StringBuilder("");           

            foreach (var responseHeader in httpApi.HttpApiHeaderResponses)
            {
                if (responseHeader.IncludeOn == HttpApiHeaderResponseOnTypes.OnAlways || responseHeader.IncludeOn == onTypes)
                {
                    var responseHeaderItem = Templates.Resource.HttpTriggerDesignerResponseHeaderItem
                        .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_NAME}}", responseHeader.Name)
                        .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_DESCRIPTION}}", responseHeader.Description)
                        .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_ALLOWEMPTY}}", responseHeader.AllowEmptyValue.ToString().ToLower())
                        .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_REQUIRED}}", responseHeader.IsRequired.ToString().ToLower());
                    responseHeaderItems.Append(responseHeaderItem);
                }
            }

            var responseHeaderClass = Templates.Resource.HttpTriggerDesignerResponseHeaderClass
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_CLASS_NAME}}", $"ResponseHeader{className}")
                .Replace("{{TOKEN_OAS_HTTP_OPENAPI_HEADER_ITEMS}}", responseHeaderItems.ToString());

            return responseHeaderClass;
        }

        private static List<string> BuildHttpTriggerSecurity(string modelName, HttpApi httpApi)
        {
            var attributes = new List<string>();
            var securityApiKey = httpApi.ApiStudio.SecurityApiKey;
            if (!string.IsNullOrEmpty(securityApiKey))
            {
                attributes.Add($"\t\t[OpenApiSecurity(\"ApiKey\", SecuritySchemeType.ApiKey, Name = \"{securityApiKey}\", In = OpenApiSecurityLocationType.Header)]");
            }

            if (httpApi.ApiStudio.SecuritySchemeType == SecuritySchemeTypes.OAuth2)
            {
                attributes.Add($"\t\t[OpenApiSecurity(\"ApiStudioOAuth2\", SecuritySchemeType.OAuth2, Flows = typeof({modelName}OpenApiOAuthSecurityFlows))]");
            }
            else if (httpApi.ApiStudio.SecuritySchemeType == SecuritySchemeTypes.OpenIdConnect)
            {
                var openIdConnectUrl = ApiStudioUserSettingsStore.Instance.Data.DefaultSecurity.OpenIdConnectUrl;
                attributes.Add($"\t\t[OpenApiSecurity(\"ApiStudioOpenIdConnect\", SecuritySchemeType.OpenIdConnect, OpenIdConnectUrl = \"{openIdConnectUrl}\", OpenIdConnectScopes = \"{httpApi.AuthorisationRole}\")]");
            }
            return attributes;
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
                    attributes.Add($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof({httpApi.DataModels?[0].Name}), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                }
                else if (statusCode.Type == "Success" && httpApi.DataModels.Count == 0)
                {
                    attributes.Add($"\t\t[OpenApiResponseWithoutBody(statusCode: {httpStatus}, Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
                }
                else
                {
                    attributes.Add($"\t\t[OpenApiResponseWithBody(statusCode: {httpStatus}, contentType: \"application/json\", bodyType: typeof(ErrorModel), Summary = \"{statusCode.Description}\", Description = \"{statusCode.Description}\", CustomHeaderType = typeof({responseHeader}))]");
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

        private static string ConvertOpenApiAttribute(this HttpTypeParameterLocation httpTypeParameterLocation)
        {
            switch (httpTypeParameterLocation)
            {
                case HttpTypeParameterLocation.Query: return "ParameterLocation.Query";
                case HttpTypeParameterLocation.Path: return "ParameterLocation.Path";
                case HttpTypeParameterLocation.Body: return "ParameterLocation.Body";

                default:
                    throw new InvalidEnumArgumentException(nameof(httpTypeParameterLocation), (int)httpTypeParameterLocation, typeof(HttpTypeParameterLocation));
            }
        }
    }
}