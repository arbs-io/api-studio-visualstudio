// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

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
                httpApi.HttpApiMediaTypeRequest.Clear();
                value.OrderBy(x => x.Name)
                    .ToList()
                    .ForEach(domainModel =>
                        httpApi.HttpApiMediaTypeRequest.Add(domainModel.ToHttpApiMediaTypeRequest(httpApi.Store)));
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