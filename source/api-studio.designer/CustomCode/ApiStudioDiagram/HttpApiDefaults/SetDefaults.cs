namespace ApiStudioIO
{
    using ApiStudioIO.HttpApiDefaults;

    internal static class HttpApiDefaultsExtension
    {
        internal static void SetDefaults(this Api api)
        {
            (api as HttpApi)?.SetDefaults();
        }

        internal static void SetDefaults(this HttpApi httpApi)
        {
            httpApi
                .WithDefaultProperties()
                .WithDefaultHeaders()
                .WithDefaultParameters()
                .WithDefaultMediaTypes()
                .WithDefaultResponses();
        }
    }
}