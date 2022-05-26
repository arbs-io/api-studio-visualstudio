﻿namespace ApiStudioIO
{
    using ApiStudioIO.Common.Models.Http;
    using System;
    using System.ComponentModel;

    internal static class HttpResourceHelpers
    {
        internal static HttpResourceHeaderRequest ToHttpResourceHeaderRequest(this HttpApiHeaderRequest domain)
        {
            var apiStudioComponent = new HttpResourceHeaderRequest
            {
                Name = domain.Name,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                AllowEmptyValue = domain.AllowEmptyValue,
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

        internal static HttpResourceHeaderResponse ToHttpResourceHeaderResponse(this HttpApiHeaderResponse domain)
        {
            var apiStudioComponent = new HttpResourceHeaderResponse
            {
                Name = domain.Name,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                AllowEmptyValue = domain.AllowEmptyValue,
                IsAutoGenerated = domain.IsAutoGenerated,
                IncludeOn = domain.IncludeOn.ToHttpTypeHeaderOnResponse()
            };
            return apiStudioComponent;
        }

        internal static HttpResourceParameter ToHttpResourceParameter(this HttpApiParameter domain)
        {
            string fromType = Enum.GetName(typeof(HttpApiParameterTypes), domain.FromType);
            var apiStudioComponent = new HttpResourceParameter
            {
                Identifier = domain.Identifier,
                DataType = domain.DataType,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                FromType = (HttpTypeParameterLocation)Enum.Parse(typeof(HttpTypeParameterLocation), fromType),
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

        internal static HttpResourceResponseStatusCode ToHttpResourceResponseStatusCode(this HttpApiResponseStatusCode domain)
        {
            var apiStudioComponent = new HttpResourceResponseStatusCode
            {
                HttpStatus = domain.HttpStatus,
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

        internal static HttpResourceMediaTypeRequest ToHttpResourceMediaTypeRequest(this HttpApiMediaType domain)
        {
            var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
                HttpTypeMimeAllowedDiscrete.application : (HttpTypeMimeAllowedDiscrete)Enum.Parse(typeof(HttpTypeMimeAllowedDiscrete), domain.DiscreteType);

            var apiStudioComponent = new HttpResourceMediaTypeRequest
            {
                DiscreteType = DiscreteType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }

        internal static HttpResourceMediaTypeResponse ToHttpResourceMediaTypeResponse(this HttpApiMediaType domain)
        {
            var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
                HttpTypeMimeAllowedDiscrete.application : (HttpTypeMimeAllowedDiscrete)Enum.Parse(typeof(HttpTypeMimeAllowedDiscrete), domain.DiscreteType);

            var apiStudioComponent = new HttpResourceMediaTypeResponse
            {
                DiscreteType = DiscreteType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }


        internal static HttpTypeHeaderOnResponse ToHttpTypeHeaderOnResponse(this HttpApiHeaderResponseOnTypes httpApiHeaderResponseOnTypes)
        {
            switch (httpApiHeaderResponseOnTypes)
            {
                case HttpApiHeaderResponseOnTypes.OnAlways: return HttpTypeHeaderOnResponse.OnAlways;
                case HttpApiHeaderResponseOnTypes.OnInformation: return HttpTypeHeaderOnResponse.OnInformation;
                case HttpApiHeaderResponseOnTypes.OnSuccess: return HttpTypeHeaderOnResponse.OnSuccess;
                case HttpApiHeaderResponseOnTypes.OnRedirection: return HttpTypeHeaderOnResponse.OnRedirection;
                case HttpApiHeaderResponseOnTypes.OnClientError: return HttpTypeHeaderOnResponse.OnClientError;
                case HttpApiHeaderResponseOnTypes.OnServerError: return HttpTypeHeaderOnResponse.OnServerError;

                default:
                    throw new InvalidEnumArgumentException(nameof(httpApiHeaderResponseOnTypes), (int)httpApiHeaderResponseOnTypes, typeof(HttpApiHeaderResponseOnTypes));
            }
        }

        internal static HttpTypeParameterLocation ToHttpTypeParameterLocation(this HttpApiParameterTypes httpApiParameterTypes)
        {
            switch (httpApiParameterTypes)
            {
                case HttpApiParameterTypes.Body: return HttpTypeParameterLocation.Body;
                case HttpApiParameterTypes.Query: return HttpTypeParameterLocation.Query;
                case HttpApiParameterTypes.Path: return HttpTypeParameterLocation.Path;

                default:
                    throw new InvalidEnumArgumentException(nameof(httpApiParameterTypes), (int)httpApiParameterTypes, typeof(HttpApiParameterTypes));
            }
        }
    }
}