using System;
using System.Linq;
using System.Net;
using ApiStudioIO.Common.Models.Http;
using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO.CodeGen.Utility
{
    public static class HttpApiExtension
    {
        public static string BuildHttpTriggerResponseStatusCodes(this HttpApi httpApi)
        {
            var statusCode = httpApi.ResponseStatusCodes
                .First(p => p.Type == "Success");
            var httpStatus = Enum.GetName(typeof(HttpStatusCode), statusCode.HttpStatus);

            return httpStatus != null ? $"HttpStatusCode.{httpStatus}" : $"(HttpStatusCode){statusCode.HttpStatus}";
        }

        public static string BuildHttpTriggerParametersPathSignature(this HttpApi httpApi)
        {
            return httpApi.RequestParameters
                .Where(parameter => parameter.FromType == HttpTypeParameterLocation.Path)
                .Aggregate("", (current, parameter) => current + $", {parameter.DataType} {parameter.Identifier.ToAlphaNumeric()}");
        }
        public static string BuildHttpTriggerParametersPathVariables(this HttpApi httpApi)
        {
            return httpApi.RequestParameters
                .Where(parameter => parameter.FromType == HttpTypeParameterLocation.Path)
                .Aggregate("", (current, parameter) => current + $", {parameter.Identifier.ToAlphaNumeric()}");
        }
    }
}
