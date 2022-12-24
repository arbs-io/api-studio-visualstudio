#nullable enable
namespace Pet
{
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    public class ModelApiResponse
    {
        [DataMember(Name="code", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "code")]
        [OpenApiProperty(Description = "Code for the Request", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public int? Code { get; set; }

        /// <summary>
        /// Gets or Sets Type
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "type")]
        [OpenApiProperty(Description = "Mime type of the request", Default = "application/octet-stream", Nullable = false)]
        public string? Type { get; set; }

        /// <summary>
        /// Gets or Sets Message
        /// </summary>
        [DataMember(Name="message", EmitDefaultValue=false)]
        [JsonProperty(PropertyName = "message")]
        [OpenApiProperty(Description = "Additional information for the upload", Default = "successful request", Nullable = false)]
        public string? Message { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ModelApiResponse {\n");
            sb.Append("  Code: ").Append(Code).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  Message: ").Append(Message).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson() {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
