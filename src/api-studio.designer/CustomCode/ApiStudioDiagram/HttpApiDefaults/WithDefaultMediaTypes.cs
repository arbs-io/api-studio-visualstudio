// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using ApiStudioIO.Common.Models.Http;

namespace ApiStudioIO.HttpApiDefaults
{
    internal static class HttpApiMediaTypeExtension
    {
        internal static HttpApi WithDefaultMediaTypes(this HttpApi httpApi)
        {
            CreateHttpApiMediaTypeResponsedDefaults(httpApi);
            CreateHttpApiMediaTypeRequestDefaults(httpApi);

            return httpApi;
        }

        private static void CreateHttpApiMediaTypeResponsedDefaults(HttpApi httpApi)
        {
            if (httpApi.HttpApiMediaTypeResponsed.Count != 0) return;

            var managedList = new List<HttpResourceMediaTypeResponse>();
            var managed = new HttpResourceMediaTypeResponse
            {
                DiscreteType = HttpTypeMimeAllowedDiscrete.application,
                SubType = "json"
            };
            managedList.Add(managed);
            ApiStudioComponentTransactionManager.Save(httpApi, managedList);
        }

        private static void CreateHttpApiMediaTypeRequestDefaults(HttpApi httpApi)
        {
            if (httpApi.HttpApiMediaTypeRequest.Count != 0) return;

            var managedList = new List<HttpResourceMediaTypeRequest>();
            var managed = new HttpResourceMediaTypeRequest
            {
                DiscreteType = HttpTypeMimeAllowedDiscrete.application,
                SubType = "json"
            };
            managedList.Add(managed);
            ApiStudioComponentTransactionManager.Save(httpApi, managedList);
        }
    }
}