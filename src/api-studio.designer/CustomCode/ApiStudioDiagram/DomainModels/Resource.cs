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