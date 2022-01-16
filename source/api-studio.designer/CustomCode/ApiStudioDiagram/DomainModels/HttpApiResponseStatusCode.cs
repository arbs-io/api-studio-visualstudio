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