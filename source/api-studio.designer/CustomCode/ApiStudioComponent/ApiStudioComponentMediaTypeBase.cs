namespace ApiStudioIO
{
    using System;
    using System.ComponentModel;

    public abstract class ApiStudioComponentMediaTypeBase : IApiStudioComponent
    {
        [Category("Hidden")]
        [Browsable(false)]
        public string Name => $"{Enum.GetName(typeof(PrimaryTypeEnum), PrimaryType)}/{SubType}";

        [Category("Hidden")]
        [Browsable(false)]
        public string PrimaryTypeName => $"{Enum.GetName(typeof(PrimaryTypeEnum), PrimaryType)}";

        [Category("Definition")]
        public PrimaryTypeEnum PrimaryType { get; set; } = PrimaryTypeEnum.application;

        [Category("Definition")]
        public string SubType { get; set; } = "json";

        public enum PrimaryTypeEnum
        {
            application, audio, example, font, image, model, text, video, message, multipart
        };
    }
}