using System.Collections.Generic;
using Newtonsoft.Json;

namespace ApiStudioIO.VsOptions.ConfigurationV1.Models.ResponseCodes
{
    public sealed class DefaultResponseCodes
    {
        [JsonProperty("standard")]
        public HashSet<int> StandardResponseCodes { get; set; } =
            new HashSet<int> { 400, 401, 403, 404, 415, 422, 500 };

        [JsonProperty("success_get")] public int SuccessGet { get; set; } = 200;

        [JsonProperty("success_put")] public int SuccessPut { get; set; } = 202;

        [JsonProperty("success_post")] public int SuccessPost { get; set; } = 201;

        [JsonProperty("success_delete")] public int SuccessDelete { get; set; } = 202;

        [JsonProperty("success_patch")] public int SuccessPatch { get; set; } = 202;

        [JsonProperty("success_trace")] public int SuccessTrace { get; set; } = 200;

        [JsonProperty("success_head")] public int SuccessHead { get; set; } = 200;

        [JsonProperty("success_options")] public int SuccessOptions { get; set; } = 204;

        public void LoadDefaults()
        {
            StandardResponseCodes = new HashSet<int> { 400, 401, 403, 404, 415, 422, 500 };
            SuccessGet = 200;
            SuccessPut = 202;
            SuccessPost = 201;
            SuccessDelete = 202;
            SuccessPatch = 202;
            SuccessTrace = 200;
            SuccessHead = 200;
            SuccessOptions = 204;
        }
    }
}