using System;
using System.Collections.Generic;
using DslModeling = Microsoft.VisualStudio.Modeling;

namespace ApiStudioIO
{
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
                    case List<ApiStudioComponentMediaTypeResponse> HttpApiMediaTypeResponses:
                        httpApi.StoreDomainModel(HttpApiMediaTypeResponses);
                        break;

                    case List<ApiStudioComponentMediaTypeRequest> HttpApiMediaTypeRequests:
                        httpApi.StoreDomainModel(HttpApiMediaTypeRequests);
                        break;

                    case List<ApiStudioComponentParameter> httpApiParameter:
                        httpApi.StoreDomainModel(httpApiParameter);
                        break;

                    case List<ApiStudioComponentResponseStatusCode> httpApiResponseStatusCode:
                        httpApi.StoreDomainModel(httpApiResponseStatusCode);
                        break;

                    case List<ApiStudioComponentHeaderResponse> HttpApiHeaderResponse:
                        httpApi.StoreDomainModel(HttpApiHeaderResponse);
                        break;

                    case List<ApiStudioComponentHeaderRequest> HttpApiHeaderRequest:
                        httpApi.StoreDomainModel(HttpApiHeaderRequest);
                        break;
                }
            }
        }
    }
}