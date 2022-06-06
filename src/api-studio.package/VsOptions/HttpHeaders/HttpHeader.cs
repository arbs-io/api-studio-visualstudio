﻿using System.ComponentModel;
using ApiStudioIO.VsOptions.ConfigurationV1;

namespace ApiStudioIO.VsOptions.HttpHeaders
{
    public class HttpHeader
    {
        public enum HttpDefaultGetEnum
        {
            OK = 200
        }

        [Category("Success Response Codes")]
        [DisplayName("GET")]
        [Description("Defaults success response code for HTTP GET method.")]
        [DefaultValue(HttpDefaultGetEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultGetEnum HttpDefaultGet
        {
            get => (HttpDefaultGetEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessGet;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessGet = (int)value;
        }
    }
}