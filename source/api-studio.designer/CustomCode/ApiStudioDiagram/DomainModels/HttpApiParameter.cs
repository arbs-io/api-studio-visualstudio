namespace ApiStudioIO
{
    using System;
    using Microsoft.VisualStudio.Modeling;

    public partial class HttpApiParameter
    {
        protected string GetDisplayNameValue()
        {
            return $"{Identifier} ({DataType}) [{ Enum.GetName(typeof(HttpApiParameterTypes), FromType)}]";
        }
    }
}