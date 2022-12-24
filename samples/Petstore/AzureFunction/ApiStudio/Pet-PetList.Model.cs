#nullable enable
namespace Pet
{
    using System;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;

    public class PetList
    {
        [OpenApiProperty(Description = "Example of required uuid", Default = "5571596d-dd42-4fb6-8c20-2620cc43d432", Nullable = false)]
        public Guid Identifier { get; set; } = new Guid("5571596d-dd42-4fb6-8c20-2620cc43d432");

        [OpenApiProperty(Description = "Example of optional string", Default = "obj-12345", Nullable = true)]
        public string? Name { get; set; } = "obj-12345";

        [OpenApiProperty(Description = "Example of optional datetime", Default = "2021-12-21T15:35:31Z", Nullable = true)]
        public DateTime? UtcTimeStamp { get; set; } = DateTime.UtcNow;

        [OpenApiProperty(Description = "Example of optional boolean", Default = true, Nullable = true)]
        public bool? Boolean { get; set; } = true;

        //Demonstrate nested numbers
        [OpenApiProperty(Description = "Example of a (Required) Numbers Object ", Nullable = false)]
        public NumbersObjectModel NumbersObjectRequired { get; set; } = new NumbersObjectModel();

        //Demonstrate nested objects type(s)
        [OpenApiProperty(Description = "Example of a (Required) Nested Object ", Nullable = false)]
        public NestedObjectModel NestedObjectRequired { get; set; } = new NestedObjectModel();

        [OpenApiProperty(Description = "Example of a (Optional) Nested Object ", Nullable = false)]
        public NestedObjectModel? NestedObjectOptional { get; set; }

        //Demonstrate array type(s)
        [OpenApiProperty(Description = "Example of a (Optional) Nested Object ", Nullable = false)]
        public List<NestedObjectModel> NestedObjectArray { get; set; } = new List<NestedObjectModel>();


        public class NumbersObjectModel
        {
            [OpenApiProperty(Description = "Example of optional float", Default = "1.401298E-45", Nullable = true)]
            public float? Float { get; set; } = float.Epsilon;

            [OpenApiProperty(Description = "Example of optional double", Default = "1.7976931348623157E+308", Nullable = true)]
            public double? Double { get; set; } = double.MaxValue;

            [OpenApiProperty(Description = "Example of optional int32", Default = "2147483647", Nullable = true)]
            public Int32? Integer32 { get; set; } = Int32.MaxValue;

            [OpenApiProperty(Description = "Example of optional int64", Default = "9223372036854775807", Nullable = true)]
            public Int64? Integer64 { get; set; } = Int64.MaxValue;
        }

        public class NestedObjectModel
        {
            [OpenApiProperty(Description = "This property is required!", Default = "Example RequiredData", Nullable = false)]
            public string RequiredData { get; set; } = string.Empty;

            [OpenApiProperty(Description = "This property is optional!", Default = "Example OptionalData", Nullable = true)]
            public string? OptionalData { get; set; }
        }
    }
}
