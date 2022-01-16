namespace ApiStudioIO
{
    public partial class HttpApiMediaType
    {
        public string GetDisplayNameValue()
        {
            return $"{PrimaryType}/{SubType}";
        }
    }
}