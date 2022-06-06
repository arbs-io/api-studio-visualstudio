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