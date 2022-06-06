using ApiStudioIO.HttpApiDefaults;

namespace ApiStudioIO
{
    internal static class HttpApiDefaultsExtension
    {
        internal static void SetDefaults(this Api api)
        {
            (api as HttpApi)?.SetDefaults();
        }

        internal static void SetDefaults(this HttpApi httpApi)
        {
            httpApi
                .WithDefaultResponses()
                .WithDefaultHeaders()
                .WithDefaultProperties()
                .WithDefaultParameters()
                .WithDefaultMediaTypes();
        }
    }
}