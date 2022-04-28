namespace ApiStudioIO.HttpApiDefaults
{
    using ApiStudioIO.Common.Models.Http;
    using System.Collections.Generic;

    internal static class HttpApiMediaTypeExtension
    {
        internal static HttpApi WithDefaultMediaTypes(this HttpApi httpApi)
        {
            CreateDefaults(httpApi);

            return httpApi;
        }

        private static void CreateDefaults(HttpApi httpApi)
        {
            if (httpApi.HttpApiMediaTypeResponsed.Count == 0)
            {
                var managedList = new List<HttpResourceMediaTypeResponse>();
                var managed = new HttpResourceMediaTypeResponse
                {
                    DiscreteType = HttpTypeMimeAllowedDiscrete.application,
                    SubType = "json"
                };
                managedList.Add(managed);
                ApiStudioComponentTransactionManager.Save(httpApi, managedList);
            }

            if (httpApi.HttpApiMediaTypeRequestd.Count == 0)
            {
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
}