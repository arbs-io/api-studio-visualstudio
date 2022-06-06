using System;
using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration.Models
{
    internal class SdkInformationModel
    {
        [JsonProperty("timestamp")] public DateTime UtcTimestamp { get; set; }

        [JsonProperty("version")] public string Version { get; set; }
    }
}