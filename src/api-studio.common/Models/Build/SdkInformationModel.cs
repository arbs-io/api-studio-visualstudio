// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json;

namespace ApiStudioIO.Common.Models.Build
{
    public class SdkInformationModel
    {
        [JsonProperty("timestamp")] public DateTime UtcTimestamp { get; set; }

        [JsonProperty("version")] public string Version { get; set; }
    }
}