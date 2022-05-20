namespace ApiStudioIO.CodeGeneration.Models
{
    using Newtonsoft.Json;
    using System;

    internal class SdkInformationModel
    {
        [JsonProperty("timestamp")]
        public DateTime UtcTimestamp { get; set; }

        [JsonProperty("version")]
        public String Version { get; set; }

    }
}