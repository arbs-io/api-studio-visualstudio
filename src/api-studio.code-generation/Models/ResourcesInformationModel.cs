namespace ApiStudioIO.CodeGeneration.Models
{
    using Newtonsoft.Json;

    internal class ResourcesInformationModel
    {
        [JsonProperty("name")]
        public string Filename { get; set; }

        [JsonProperty("checksum")]
        public string Checksum { get; set; }

        [JsonProperty("always_overwrite")]
        public bool AlwaysOverwrite { get; set; }
    }
}