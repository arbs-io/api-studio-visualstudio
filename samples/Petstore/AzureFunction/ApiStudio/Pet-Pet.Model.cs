#nullable enable

namespace Pet
{
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using YamlDotNet.Core.Tokens;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    public class Pet
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        [OpenApiProperty(Description = "Identification for the pet", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [DataMember(Name = "name", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "name")]
        [OpenApiProperty(Description = "Name of the pet...", Default = "bob", Nullable = false)]
        public string? Name { get; set; }

        /// <summary>
        /// Gets or Sets Category
        /// </summary>
        [DataMember(Name = "category", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "category")]
        [OpenApiProperty(Description = "Category of the pet...", Default = "Dog", Nullable = false)]
        public Category? Category { get; set; }

        /// <summary>
        /// Gets or Sets PhotoUrls
        /// </summary>
        [DataMember(Name = "photoUrls", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "photoUrls")]
        [OpenApiProperty(Description = "Urls for for the pet...", Default = "https://somewhere.com/id", Nullable = false)]
        public List<string>? PhotoUrls { get; set; }

        /// <summary>
        /// Gets or Sets Tags
        /// </summary>
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "tags")]
        [OpenApiProperty(Description = "Tags for for the pet...", Default = "Furry", Nullable = false)]
        public List<Tag>? Tags { get; set; }

        /// <summary>
        /// pet status in the store
        /// </summary>
        /// <value>pet status in the store</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        [OpenApiProperty(Description = "The status of the pet...", Default = "alive", Nullable = false)]
        public string? Status { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Pet {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Category: ").Append(Category).Append("\n");
            sb.Append("  PhotoUrls: ").Append(PhotoUrls).Append("\n");
            sb.Append("  Tags: ").Append(Tags).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
