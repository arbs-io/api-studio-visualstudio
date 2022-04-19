namespace ApiStudioIO
{
    using System;

    public partial class HttpApiParameter
    {
        protected string GetDisplayNameValue()
        {
            return $"{Identifier} ({DataType}) [{ Enum.GetName(typeof(HttpApiParameterTypes), FromType)}]";
        }
    }
}