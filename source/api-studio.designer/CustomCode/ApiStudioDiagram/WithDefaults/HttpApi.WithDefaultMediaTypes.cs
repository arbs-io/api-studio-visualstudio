namespace ApiStudioIO
{
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
                var managedList = new List<ApiStudioComponentMediaTypeResponse>();
                var managed = new ApiStudioComponentMediaTypeResponse
                {
                    DiscreteType = ApiStudioComponentMediaTypeBase.AllowedDiscreteType.application,
                    SubType = "json"
                };
                managedList.Add(managed);
                ApiStudioComponentTransactionManager.Save(httpApi, managedList);
            }

            if (httpApi.HttpApiMediaTypeRequestd.Count == 0)
            {
                var managedList = new List<ApiStudioComponentMediaTypeRequest>();
                var managed = new ApiStudioComponentMediaTypeRequest
                {
                    DiscreteType = ApiStudioComponentMediaTypeBase.AllowedDiscreteType.application,
                    SubType = "json"
                };
                managedList.Add(managed);
                ApiStudioComponentTransactionManager.Save(httpApi, managedList);
            }
        }
    }
}