namespace ApiStudioIO
{
    using ApiStudioIO.Utility.Extensions;
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