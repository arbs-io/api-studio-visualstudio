﻿namespace ApiStudioIO
{
    using System;
    using System.ComponentModel;

    public abstract class ApiStudioComponentMediaTypeBase : IApiStudioComponent
    {
        [Category("Hidden")]
        [Browsable(false)]
        public string Name => $"{Enum.GetName(typeof(MediaTypeAllowedDiscrete), DiscreteType)}/{SubType}";

        [Category("Hidden")]
        [Browsable(false)]
        public string DiscreteTypeName => $"{Enum.GetName(typeof(MediaTypeAllowedDiscrete), DiscreteType)}";

        [Category("Definition")]
        public MediaTypeAllowedDiscrete DiscreteType { get; set; } = MediaTypeAllowedDiscrete.application;

        [Category("Definition")]
        public string SubType { get; set; } = "json";


    }
}