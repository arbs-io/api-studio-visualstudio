namespace ApiStudioIO.CodeGeneration.Models
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    internal class CodeGenerationModel
    {
        [JsonProperty("sdk")]
        public SdkInformationModel SdkInformationSegment { get; set; }

        [JsonProperty("target")]
        public TargetInformationModel TargetInformationSegment { get; set; }

        [JsonProperty("resources")]
        public List<ResourcesInformationModel> ResourcesInfoSegment { get; set; } = new List<ResourcesInformationModel>();
    }
}