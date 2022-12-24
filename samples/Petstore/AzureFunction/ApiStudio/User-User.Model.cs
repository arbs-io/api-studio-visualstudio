#nullable enable

namespace User
{
    using System.Runtime.Serialization;
    using System.Text;
    using Newtonsoft.Json;
    using YamlDotNet.Core.Tokens;
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    public class User
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "id")]
        [OpenApiProperty(Description = "Identification for the pet", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public long? Id { get; set; }

        /// <summary>
        /// Gets or Sets Username
        /// </summary>
        [DataMember(Name = "username", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "username")]
        [OpenApiProperty(Description = "Username of the user...", Default = "smithb", Nullable = false)]
        public string? Username { get; set; }

        /// <summary>
        /// Gets or Sets FirstName
        /// </summary>
        [DataMember(Name = "firstName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "firstName")]
        [OpenApiProperty(Description = "First name of the user...", Default = "bob", Nullable = false)]
        public string? FirstName { get; set; }

        /// <summary>
        /// Gets or Sets LastName
        /// </summary>
        [DataMember(Name = "lastName", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "lastName")]
        [OpenApiProperty(Description = "Surname of the user...", Default = "smith", Nullable = false)]
        public string? LastName { get; set; }

        /// <summary>
        /// Gets or Sets Email
        /// </summary>
        [DataMember(Name = "email", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "email")]
        [OpenApiProperty(Description = "Mail address for the user...", Default = "smithb@gmail.com", Nullable = false)]
        public string? Email { get; set; }

        /// <summary>
        /// Gets or Sets Password
        /// </summary>
        [DataMember(Name = "password", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "password")]
        [OpenApiProperty(Description = "User password???", Default = "Qwertyuiop", Nullable = false)]
        public string? Password { get; set; }

        /// <summary>
        /// Gets or Sets Phone
        /// </summary>
        [DataMember(Name = "phone", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "phone")]
        [OpenApiProperty(Description = "Phone number of the user...", Default = "+1-541-754-3010", Nullable = false)]
        public string? Phone { get; set; }

        /// <summary>
        /// User Status
        /// </summary>
        /// <value>User Status</value>
        [DataMember(Name = "userStatus", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "userStatus")]
        [OpenApiProperty(Description = "User status...", Default = "Alive", Nullable = false)]
        public int? UserStatus { get; set; }


        /// <summary>
        /// Get the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class User {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Username: ").Append(Username).Append("\n");
            sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("  Phone: ").Append(Phone).Append("\n");
            sb.Append("  UserStatus: ").Append(UserStatus).Append("\n");
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
