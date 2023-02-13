// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace ApiStudioIO.Common.Models.Http
{
    public abstract class HttpResourceMediaTypeBase : IHttpResource
    {
        [Category("Hidden")]
        [Browsable(false)]
        public string Name => $"{Enum.GetName(typeof(HttpTypeMimeAllowedDiscrete), DiscreteType)}/{SubType}";

        [Category("Hidden")]
        [Browsable(false)]
        public string DiscreteTypeName => $"{Enum.GetName(typeof(HttpTypeMimeAllowedDiscrete), DiscreteType)}";

        [Category("Definition")]
        public HttpTypeMimeAllowedDiscrete DiscreteType { get; set; } = HttpTypeMimeAllowedDiscrete.application;

        [Category("Definition")] public string SubType { get; set; } = "json";
    }
}