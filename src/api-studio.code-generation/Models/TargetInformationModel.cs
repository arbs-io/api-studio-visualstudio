namespace ApiStudioIO.CodeGeneration.Models
{
    using Newtonsoft.Json;
    using System;

    internal class TargetInformationModel
    {
        [JsonProperty("language")]
        public String Language { get; set; }

        [JsonProperty("host")]
        public String Host { get; set; }

        [JsonProperty("framework")]
        public String Framework { get; set; }
    }
}