using System;

namespace ApiStudioIO
{
    public partial class HttpApiHeaderResponse
    {
        public string GetIncludeOnNameValue()
        {
            return $"{Enum.GetName(typeof(HttpApiHeaderResponseOnTypes), IncludeOn)}";
        }
    }
}