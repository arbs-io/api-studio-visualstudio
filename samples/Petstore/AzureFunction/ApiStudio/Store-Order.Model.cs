#nullable enable

namespace Store
{
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    public class Order
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        [OpenApiProperty(Description = "Identification for the order", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets PetId
        /// </summary>
        [DataMember(Name = "petId", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "petId")]
        [OpenApiProperty(Description = "Identification for the ordered pet", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public long? PetId { get; set; }

        /// <summary>
        /// Gets or Sets Quantity
        /// </summary>
        [DataMember(Name = "quantity", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "quantity")]
        [OpenApiProperty(Description = "Number of pet(s), clones availible...", Default = "78", Nullable = false)]
        public int? Quantity { get; set; }

        /// <summary>
        /// Gets or Sets ShipDate
        /// </summary>
        [DataMember(Name = "shipDate", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "shipDate")]
        [OpenApiProperty(Description = "Date when the pet was shipped", Default = "2021-12-21T15:35:31Z", Nullable = false)]
        public DateTime? ShipDate { get; set; }

        /// <summary>
        /// Order Status
        /// </summary>
        /// <value>Order Status</value>
        [DataMember(Name = "status", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "status")]
        [OpenApiProperty(Description = "The status of the order...", Default = "accepted", Nullable = false)]
        public string? Status { get; set; }

        /// <summary>
        /// Gets or Sets Complete
        /// </summary>
        [DataMember(Name = "complete", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "complete")]
        [OpenApiProperty(Description = "Is this not a status?", Default = "true", Nullable = false)]
        public bool? Complete { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Order {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  PetId: ").Append(PetId).Append("\n");
            sb.Append("  Quantity: ").Append(Quantity).Append("\n");
            sb.Append("  ShipDate: ").Append(ShipDate).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Complete: ").Append(Complete).Append("\n");
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