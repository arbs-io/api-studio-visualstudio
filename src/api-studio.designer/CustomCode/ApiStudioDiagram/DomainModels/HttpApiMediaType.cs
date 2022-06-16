// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

namespace ApiStudioIO
{
    public partial class HttpApiMediaType
    {
        public string GetDisplayNameValue()
        {
            return $"{DiscreteType}/{SubType}";
        }
    }
}