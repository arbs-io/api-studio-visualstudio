﻿namespace ApiStudioIO
{
    using System;

    internal static class ApiStudioComponentExtension
    {
        internal static ApiStudioComponentHeaderRequest Convert(this HttpApiHeaderRequest domain)
        {
            var apiStudioComponent = new ApiStudioComponentHeaderRequest
            {
                Name = domain.Name,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                AllowEmptyValue = domain.AllowEmptyValue,
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

        internal static ApiStudioComponentHeaderResponse Convert(this HttpApiHeaderResponse domain)
        {
            var apiStudioComponent = new ApiStudioComponentHeaderResponse
            {
                Name = domain.Name,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                AllowEmptyValue = domain.AllowEmptyValue,
                IsAutoGenerated = domain.IsAutoGenerated,
                IncludeOn = domain.IncludeOn
            };
            return apiStudioComponent;
        }

        internal static ApiStudioComponentMediaTypeRequest ConvertRequest(this HttpApiMediaType domain)
        {
            var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
                MediaTypeAllowedDiscrete.application : (MediaTypeAllowedDiscrete)Enum.Parse(typeof(MediaTypeAllowedDiscrete), domain.DiscreteType);

            var apiStudioComponent = new ApiStudioComponentMediaTypeRequest
            {
                DiscreteType = DiscreteType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }

        internal static ApiStudioComponentMediaTypeResponse ConvertResponse(this HttpApiMediaType domain)
        {
            var DiscreteType = (string.IsNullOrEmpty(domain.DiscreteType) || string.IsNullOrEmpty(domain.SubType)) ?
                MediaTypeAllowedDiscrete.application : (MediaTypeAllowedDiscrete)Enum.Parse(typeof(MediaTypeAllowedDiscrete), domain.DiscreteType);

            var apiStudioComponent = new ApiStudioComponentMediaTypeResponse
            {
                DiscreteType = DiscreteType,
                SubType = domain.SubType
            };
            return apiStudioComponent;
        }


        internal static ApiStudioComponentParameter Convert(this HttpApiParameter domain)
        {
            string fromType = Enum.GetName(typeof(HttpApiParameterTypes), domain.FromType);
            var apiStudioComponent = new ApiStudioComponentParameter
            {
                Identifier = domain.Identifier,
                DataType = domain.DataType,
                Description = domain.Description,
                IsRequired = domain.IsRequired,
                FromType = (HttpApiParameterTypes)Enum.Parse(typeof(HttpApiParameterTypes), fromType),
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

        internal static ApiStudioComponentResponseStatusCode Convert(this HttpApiResponseStatusCode domain)
        {
            var apiStudioComponent = new ApiStudioComponentResponseStatusCode
            {
                HttpStatus = domain.HttpStatus,
                IsAutoGenerated = domain.IsAutoGenerated
            };
            return apiStudioComponent;
        }

    }
}