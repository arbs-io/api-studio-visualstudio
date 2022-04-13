namespace ApiStudioIO
{
    using System;
    using System.ComponentModel;

    public abstract class ApiStudioComponentMediaTypeBase : IApiStudioComponent
    {
        [Category("Hidden")]
        [Browsable(false)]
        public string Name => $"{Enum.GetName(typeof(AllowedDiscreteType), DiscreteType)}/{SubType}";

        [Category("Hidden")]
        [Browsable(false)]
        public string DiscreteTypeName => $"{Enum.GetName(typeof(AllowedDiscreteType), DiscreteType)}";

        [Category("Definition")]
        public AllowedDiscreteType DiscreteType { get; set; } = AllowedDiscreteType.application;

        [Category("Definition")]
        public string SubType { get; set; } = "json";

        public enum AllowedDiscreteType
        {
            application, audio, example, font, image, model, text, video, message, multipart
        };
    }
}