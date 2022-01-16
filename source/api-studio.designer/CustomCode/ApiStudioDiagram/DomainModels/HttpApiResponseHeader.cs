namespace ApiStudioIO
{
    using System;

    public partial class HttpApiHeaderResponse
    {
        public string GetIncludeOnNameValue()
        {
            return $"{Enum.GetName(typeof(HttpApiHeaderResponseOnTypes), IncludeOn)}";
        }
    }
}