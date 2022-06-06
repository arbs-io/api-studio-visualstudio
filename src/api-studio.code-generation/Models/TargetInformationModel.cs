using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration.Models
{
    internal class TargetInformationModel
    {
        [JsonProperty("language")] public string Language { get; set; }

        [JsonProperty("host")] public string Host { get; set; }

        [JsonProperty("framework")] public string Framework { get; set; }
    }
}