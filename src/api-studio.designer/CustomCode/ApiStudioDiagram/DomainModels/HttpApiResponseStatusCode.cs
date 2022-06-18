// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using ApiStudioIO.Utility.Extensions;

namespace ApiStudioIO
{
    public partial class HttpApiResponseStatusCode
    {
        protected string GetDisplayNameValue()
        {
            return $@"({HttpStatus}) {GetDescriptionValue()}";
        }

        protected string GetTypeValue()
        {
            return HttpResponseExtension.GetHttpResponseCodeCategory(HttpStatus);
        }

        protected string GetDescriptionValue()
        {
            return HttpResponseExtension.GetHttpResponseCodeDescription(HttpStatus);
        }
    }
}