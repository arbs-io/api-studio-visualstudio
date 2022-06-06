// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

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
            if (domainEntity is HttpApi httpApi)
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