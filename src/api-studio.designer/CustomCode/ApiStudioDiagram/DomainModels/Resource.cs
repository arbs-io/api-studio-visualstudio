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
using System.Text.RegularExpressions;

namespace ApiStudioIO
{
    public partial class Resource
    {
        //This property is to help code gen map resource to HttpApis (via ApiStudio and Containers)
        public List<HttpApi> HttpApis => Apis.OfType<HttpApi>().ToList();

        protected virtual string GetHttpApiUriValue()
        {
            var name = Regex.Replace(Name, @"(?<=[a-z])([A-Z])", @"-$1").ToLower();

            var uri = "";
            if (SourceResource.Count == 0)
                //Check if the first resource item should be treated as root e.g. "/" rather than "/some-resource"
                name = ApiStudio.InitialResourceIsRoot
                    ? @""
                    : name;
            else
                uri = $"{SourceResource[0].HttpApiUri}/";

            uri += $@"{name}";
            return FormatUri(uri);
        }

        protected virtual string GetImplementationNameValue()
        {
            if (string.IsNullOrEmpty(Name)) return "";

            return Name.First().ToString().ToUpper() + Name.Substring(1);
        }

        //Implementation
        public bool HasParameters()
        {
            if (Apis.Count == 0) return false;

            foreach (var api in Apis)
                if (((HttpApi)api).RequestParameters.Any())
                    return true;

            return false;
        }

        public static string FormatUri(string uri)
        {
            uri = uri.Replace(@"//", @"/");
            if (uri.StartsWith("/")) //Remove leading "/"
                uri = uri.Substring(1);

            return uri;
        }
    }
}