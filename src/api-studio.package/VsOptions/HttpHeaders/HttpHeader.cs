// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.ComponentModel;
using ApiStudioIO.Vs.Options;
using ApiStudioIO.VsOptions.HttpDefaults;

namespace ApiStudioIO.VsOptions.HttpHeaders
{
    public class HttpHeader
    {
        [Category("Success Response Codes")]
        [DisplayName("GET")]
        [Description("Defaults success response code for HTTP GET method.")]
        [DefaultValue(HttpDefaultGet.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultGet HttpDefaultGet
        {
            get => (HttpDefaultGet)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessGet;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessGet = (int)value;
        }
    }
}