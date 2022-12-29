// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using ApiStudioIO.Common.Models.Http;

namespace ApiStudioIO
{
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public static class ApiStudioComponentTransactionManager
    {
        internal static void Save<TDomainEntity, TPropertyEntity>(TDomainEntity domainEntity,
            List<TPropertyEntity> propertyEntityList)
            where TDomainEntity : DslModeling.ModelElement
        {
            _ = domainEntity ?? throw new ArgumentNullException(nameof(domainEntity));
            _ = propertyEntityList ?? throw new ArgumentNullException(nameof(propertyEntityList));

            //arb review just use override...
            if (!(domainEntity is HttpApi httpApi)) return;
            switch (propertyEntityList)
            {
                case List<HttpResourceMediaTypeResponse> httpApiMediaTypeResponses:
                    httpApi.StoreDomainModel(httpApiMediaTypeResponses);
                    break;

                case List<HttpResourceMediaTypeRequest> httpApiMediaTypeRequests:
                    httpApi.StoreDomainModel(httpApiMediaTypeRequests);
                    break;

                case List<HttpResourceParameter> httpApiParameter:
                    httpApi.StoreDomainModel(httpApiParameter);
                    break;

                case List<HttpResourceResponseStatusCode> httpApiResponseStatusCode:
                    httpApi.StoreDomainModel(httpApiResponseStatusCode);
                    break;

                case List<HttpResourceHeaderResponse> httpApiHeaderResponse:
                    httpApi.StoreDomainModel(httpApiHeaderResponse);
                    break;

                case List<HttpResourceHeaderRequest> httpApiHeaderRequest:
                    httpApi.StoreDomainModel(httpApiHeaderRequest);
                    break;
            }
        }
    }
}