using System.Linq;

namespace ApiStudioIO.HttpApiDefaults
{
    internal static class HttpApiExtension
    {
        internal static HttpApi WithDefaultProperties(this HttpApi httpApi)
        {
            httpApi.ImperativeVerb = SuggestImperativeVerb(httpApi);
            return httpApi;
        }

        private static string SuggestImperativeVerb(HttpApi httpApi)
        {
            var source = httpApi.Resourced.FirstOrDefault();
            var successCode = httpApi.GetSuccessCode();
            var imperativeVerb = "Undefined";

            switch (httpApi)
            {
                case HttpApiGet _:
                    if (source is ResourceCollection)
                        imperativeVerb = "Find";
                    else if (source is ResourceInstance)
                        imperativeVerb = "Request";
                    else if (source is ResourceAttribute) imperativeVerb = "Retrieve";

                    break;

                case HttpApiPut _:
                    if (source is ResourceInstance)
                        imperativeVerb = "Change";
                    else if (source is ResourceAttribute) imperativeVerb = "Adjust";

                    break;

                case HttpApiPatch _:
                    if (source is ResourceInstance)
                        imperativeVerb = "Change";
                    else if (source is ResourceAttribute) imperativeVerb = "Adjust";

                    break;

                case HttpApiPost _:
                    if (source is ResourceCollection)
                        imperativeVerb = "Create";
                    else if (source is ResourceAction && successCode == 200)
                        imperativeVerb = "Generate";
                    else if (source is ResourceAction && successCode == 201)
                        imperativeVerb = "Make";
                    else if (source is ResourceAction && successCode == 202) imperativeVerb = "Prepare";

                    break;

                case HttpApiDelete _:
                    if (source is ResourceInstance && successCode == 200)
                        imperativeVerb = "Remove";
                    else if (source is ResourceInstance && successCode == 202) imperativeVerb = "Deactivate";

                    break;


                case HttpApiOptions _:
                    imperativeVerb = "Options";
                    break;

                case HttpApiHead _:
                    imperativeVerb = "Head";
                    break;

                case HttpApiTrace _:
                    imperativeVerb = "Trace";
                    break;

                default:
                    imperativeVerb = "Undefined";
                    break;
            }

            return imperativeVerb;
        }
    }
}