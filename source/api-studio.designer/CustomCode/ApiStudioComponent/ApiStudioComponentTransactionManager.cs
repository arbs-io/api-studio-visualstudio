namespace ApiStudioIO
{
    using ApiStudioIO.Common.Models.Http;
    using System;
    using System.Collections.Generic;
    using DslModeling = Microsoft.VisualStudio.Modeling;

    public static class ApiStudioComponentTransactionManager
    {
        internal static void Save<TDomainEntity, TPropertyEntity>(TDomainEntity domainEntity, List<TPropertyEntity> propertyEntityList)
            where TDomainEntity : DslModeling::ModelElement
        {
            if (domainEntity == null)
            {
                throw new ArgumentNullException(nameof(domainEntity));
            }

            if (propertyEntityList == null)
            {
                throw new ArgumentNullException(nameof(propertyEntityList));
            }
            //arb review just use override...
            if (domainEntity is HttpApi httpApi)
            {
                switch (propertyEntityList)
                {
                    case List<HttpResourceMediaTypeResponse> HttpApiMediaTypeResponses:
                        httpApi.StoreDomainModel(HttpApiMediaTypeResponses);
                        break;

                    case List<HttpResourceMediaTypeRequest> HttpApiMediaTypeRequests:
                        httpApi.StoreDomainModel(HttpApiMediaTypeRequests);
                        break;

                    case List<HttpResourceParameter> httpApiParameter:
                        httpApi.StoreDomainModel(httpApiParameter);
                        break;

                    case List<HttpResourceResponseStatusCode> httpApiResponseStatusCode:
                        httpApi.StoreDomainModel(httpApiResponseStatusCode);
                        break;

                    case List<HttpResourceHeaderResponse> HttpApiHeaderResponse:
                        httpApi.StoreDomainModel(HttpApiHeaderResponse);
                        break;

                    case List<HttpResourceHeaderRequest> HttpApiHeaderRequest:
                        httpApi.StoreDomainModel(HttpApiHeaderRequest);
                        break;
                }
            }
        }
    }
}