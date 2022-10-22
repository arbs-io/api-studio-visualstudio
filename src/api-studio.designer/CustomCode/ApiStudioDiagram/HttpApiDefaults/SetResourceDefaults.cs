// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Linq;

namespace ApiStudioIO
{
    internal static class ResourceDefaultsExtension
    {
        internal static void SetResourceDefaults(this Resource resource)
        {
            resource.Apis
                .ToList()
                .ForEach(x => (x as HttpApi)?.SetDefaults());

            foreach (var childResource in resource.Resources) SetResourceDefaults(childResource);
        }
    }
}