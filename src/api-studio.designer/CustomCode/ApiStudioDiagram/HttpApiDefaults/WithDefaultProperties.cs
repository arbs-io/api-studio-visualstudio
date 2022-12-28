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
            string imperativeVerb = "Undefined";

            if (source is ResourceInstance && successCode == 200)
                imperativeVerb = "Remove";
            else if (source is ResourceInstance && successCode == 202)
                imperativeVerb = "Deactivate";

            return imperativeVerb;
        }

        private static string GetHttpApiPostImperativeVerb(Resource source, int successCode)
        {
            string imperativeVerb = "Undefined";

            if (source is ResourceCollection)
                imperativeVerb = "Create";
            else if (source is ResourceAction && successCode == 200)
                imperativeVerb = "Generate";
            else if (source is ResourceAction && successCode == 201)
                imperativeVerb = "Make";
            else if (source is ResourceAction && successCode == 202) imperativeVerb = "Prepare";

            return imperativeVerb;
        }

        private static string GetHttpApiPutPatchImperativeVerb(Resource source)
        {
            string imperativeVerb = "Undefined";

            if (source is ResourceInstance)
                imperativeVerb = "Change";
            else if (source is ResourceAttribute)
                imperativeVerb = "Adjust";

            return imperativeVerb;
        }

        private static string GetHttpApiGetImperativeVerb(Resource source)
        {
            string imperativeVerb = "Undefined";

            if (source is ResourceCollection)
                imperativeVerb = "Find";
            else if (source is ResourceInstance)
                imperativeVerb = "Request";
            else if (source is ResourceAttribute)
                imperativeVerb = "Retrieve";

            return imperativeVerb;
        }
    }
}