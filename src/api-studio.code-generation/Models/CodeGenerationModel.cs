// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration.Models
{
    internal class CodeGenerationModel
    {
        [JsonProperty("sdk")] public SdkInformationModel SdkInformationSegment { get; set; }

        [JsonProperty("build_target")] public BuildTargetModel BuildTarget { get; set; }

        [JsonProperty("resources")]
        public List<ResourcesInformationModel> ResourcesInfoSegment { get; set; } =
            new List<ResourcesInformationModel>();
    }
}