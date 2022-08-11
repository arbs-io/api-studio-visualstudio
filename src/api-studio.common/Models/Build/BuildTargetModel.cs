// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace ApiStudioIO.Common.Models.Build
{
    public class BuildTargetModel
    {
        [JsonProperty("language")] public string Language { get; set; }
        [JsonProperty("version")] public string Version { get; set; }
        [JsonProperty("azure_functions_version")] public string AzureFunctionsVersion { get; set; }
        [JsonProperty("target_framework")] public string TargetFramework { get; set; }
        [JsonProperty("target_library")] public string TargetLibrary { get; set; }
    }
}