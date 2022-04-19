﻿namespace ApiStudioIO
{
    using ApiStudioIO.Utility.Extensions;
    using System;
    using System.ComponentModel;

    public class ApiStudioComponentResponseStatusCode : IApiStudioComponent
    {
        // public static implicit operator ApiStudioComponentResponseStatusCode(HttpApiResponseStatusCode domain)
        // {
        //     var apiStudioComponent = new ApiStudioComponentResponseStatusCode
        //     {
        //         HttpStatus = domain.HttpStatus,
        //         IsAutoGenerated = domain.IsAutoGenerated
        //     };
        //     return apiStudioComponent;
        // }


        // public static implicit operator ApiStudioComponentResponseStatusCode(Int32 httpStatus)
        // {
        //     var apiStudioComponent = new ApiStudioComponentResponseStatusCode
        //     {
        //         HttpStatus = httpStatus,
        //         IsAutoGenerated = true
        //     };
        //     return apiStudioComponent;
        // }


        [Category("Hiddend")]
        [Browsable(false)]
        public string Name => $@"({HttpStatus}) {Description}";

        [Category("Definition")]
        public Int32 HttpStatus { get; set; } = 200;

        [Category("RFC 7231")]
        public string Type => $"{HttpResponseExtension.GetHttpResponseCodeCategory(HttpStatus)}";

        [Category("RFC 7231")]
        public string Description => $"{HttpResponseExtension.GetHttpResponseCodeDescription(HttpStatus)}";

        [Category("ApiStudio Metadata")]
        public bool IsAutoGenerated { get; internal set; } = false;
    }
}