﻿// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace ApiStudioIO.CodeGeneration.Models
{
    internal class BuildTargetModel
    {
        [JsonProperty("language")] public string Language { get; set; }

        [JsonProperty("azure_functions_version")] public string AzureFunctionsVersion { get; set; }

        [JsonProperty("target_framework")] public string TargetFramework { get; set; }
    }
}