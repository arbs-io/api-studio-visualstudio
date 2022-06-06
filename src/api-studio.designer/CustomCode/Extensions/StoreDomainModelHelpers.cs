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

using System.Collections.Generic;
using System.Linq;
using ApiStudioIO.Common.Models.Http;

namespace ApiStudioIO
{
    internal static class StoreDomainModelHelpers
    {
        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceParameter> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceParameter"))
            {
                httpApi.HttpApiParameters.Clear();
                value.OrderBy(x => x.FromType).ThenBy(x => x.Identifier)
                    .ToList()
                    .ForEach(
                        domainModel => httpApi.HttpApiParameters.Add(domainModel.ToHttpApiParameter(httpApi.Store)));

                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceHeaderRequest> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceHeaderRequest"))
            {
                httpApi.HttpApiHeaderRequests.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiHeaderRequests.Add(domainModel.ToHttpApiHeaderRequest(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceMediaTypeRequest> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceMediaTypeRequest"))
            {
                httpApi.HttpApiMediaTypeRequestd.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiMediaTypeRequestd.Add(domainModel.ToHttpApiMediaTypeRequest(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceHeaderResponse> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceHeaderResponse"))
            {
                httpApi.HttpApiHeaderResponses.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiHeaderResponses.Add(domainModel.ToHttpApiHeaderResponse(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceMediaTypeResponse> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceMediaTypeResponse"))
            {
                httpApi.HttpApiMediaTypeResponsed.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiMediaTypeResponsed.Add(domainModel.ToHttpApiMediaTypeResponse(httpApi.Store)));
                t.Commit();
            }
        }

        internal static void StoreDomainModel(this HttpApi httpApi, List<HttpResourceResponseStatusCode> value)
        {
            using (var t = httpApi.Store.TransactionManager.BeginTransaction(
                       "ApiStudioComponentStoreDomainModel.StoreDomainModel.HttpResourceResponseStatusCode"))
            {
                httpApi.HttpApiResponseStatusCodes.Clear();
                value.OrderBy(x => x.HttpStatus)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiResponseStatusCodes.Add(domainModel.ToHttpApiResponseStatusCode(httpApi.Store)));
                t.Commit();
            }
        }
    }
}