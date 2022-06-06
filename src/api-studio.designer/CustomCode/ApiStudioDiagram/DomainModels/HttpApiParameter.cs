using System;

namespace ApiStudioIO
{
    public partial class HttpApiParameter
    {
        protected string GetDisplayNameValue()
        {
            return $"{Identifier} ({DataType}) [{Enum.GetName(typeof(HttpApiParameterTypes), FromType)}]";
        }
    }
}