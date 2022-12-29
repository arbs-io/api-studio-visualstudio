// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Linq;

namespace ApiStudioIO.HttpApiDefaults
{
    internal static class HttpApiExtension
    {
        internal static HttpApi WithDefaultProperties(this HttpApi httpApi)
        {
            SetImperativeVerb(httpApi);
            return httpApi;
        }

        private static void SetImperativeVerb(HttpApi httpApi)
        {
            var source = httpApi.Resourced.FirstOrDefault();
            var successCode = httpApi.GetSuccessCode();

            switch (httpApi)
            {
                case HttpApiGet _:
                    httpApi.ImperativeVerb = GetHttpApiGetImperativeVerb(source);
                    break;

                case HttpApiPut _:
                case HttpApiPatch _:
                    httpApi.ImperativeVerb = GetHttpApiPutPatchImperativeVerb(source);
                    break;

                case HttpApiPost _:
                    httpApi.ImperativeVerb = GetHttpApiPostImperativeVerb(source, successCode);
                    break;

                case HttpApiDelete _:
                    httpApi.ImperativeVerb = GetHttpApiDeleteImperativeVerb(source, successCode);
                    break;


                case HttpApiOptions _:
                    httpApi.ImperativeVerb = "Options";
                    break;

                case HttpApiHead _:
                    httpApi.ImperativeVerb = "Head";
                    break;

                case HttpApiTrace _:
                    httpApi.ImperativeVerb = "Trace";
                    break;

                default:
                    httpApi.ImperativeVerb = "Undefined";
                    break;
            }
        }

        private static string GetHttpApiDeleteImperativeVerb(Resource source, int successCode)
        {
            switch (source)
            {
                case ResourceInstance _ when successCode == 200:
                    return "Remove";
                case ResourceInstance _ when successCode == 202:
                    return "Deactivate";
                default:
                    return "Undefined";
            }
        }

        private static string GetHttpApiPostImperativeVerb(Resource source, int successCode)
        {
            switch (source)
            {
                case ResourceCollection _:
                    return "Create";
                case ResourceAction _ when successCode == 200:
                    return "Generate";
                case ResourceAction _ when successCode == 201:
                    return "Make";
                case ResourceAction _ when successCode == 202:
                    return "Prepare";
                default:
                    return "Undefined";
            }
        }

        private static string GetHttpApiPutPatchImperativeVerb(Resource source)
        {
            switch (source)
            {
                case ResourceInstance _:
                    return "Change";
                case ResourceAttribute _:
                    return "Adjust";
                default:
                    return "Undefined";
            }
        }

        private static string GetHttpApiGetImperativeVerb(Resource source)
        {
            switch (source)
            {
                case ResourceCollection _:
                    return "Find";
                case ResourceInstance _:
                    return "Request";
                case ResourceAttribute _:
                    return "Retrieve";
                default:
                    return "Undefined";
            }
        }
    }
}