using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration.Models
{
    internal class CodeGenerationModel
    {
        [JsonProperty("sdk")] public SdkInformationModel SdkInformationSegment { get; set; }

        [JsonProperty("target")] public TargetInformationModel TargetInformationSegment { get; set; }

        [JsonProperty("resources")]
        public List<ResourcesInformationModel> ResourcesInfoSegment { get; set; } =
            new List<ResourcesInformationModel>();
    }
}