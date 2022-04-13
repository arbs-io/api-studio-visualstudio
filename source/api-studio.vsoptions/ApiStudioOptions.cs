namespace ApiStudioIO.VsOptions
{
    using Microsoft.VisualStudio.Settings;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Settings;
    using Newtonsoft.Json;

    public sealed class ApiStudioOptions
    {
        [JsonProperty("DefaultResponseCodes")]
        public DefaultResponseCodes DefaultResponseCodes { get; set; } = new DefaultResponseCodes();
    }
}
