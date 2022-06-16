// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.ComponentModel;
using ApiStudioIO.VsOptions.ConfigurationV1;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
{
    public class HttpHeader
    {
        public enum HttpDefaultDeleteEnum
        {
            OK = 200,
            Accepted = 202,
            NoContent = 204
        }

        public enum HttpDefaultGetEnum
        {
            OK = 200
        }

        public enum HttpDefaultHeadEnum
        {
            OK = 200
        }

        public enum HttpDefaultOptionsEnum
        {
            NoContent = 204
        }

        public enum HttpDefaultPatchEnum
        {
            OK = 200,
            Created = 201,
            Accepted = 202,
            NoContent = 204
        }

        public enum HttpDefaultPostEnum
        {
            Created = 201
        }

        public enum HttpDefaultPutEnum
        {
            OK = 200,
            Created = 201,
            Accepted = 202,
            NoContent = 204
        }

        public enum HttpDefaultTraceEnum
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

        [Category("Success Response Codes")]
        [DisplayName("PUT")]
        [Description("Defaults success response code for HTTP PUT method.")]
        [DefaultValue(HttpDefaultPutEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPutEnum HttpDefaultPut
        {
            get => (HttpDefaultPutEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPut;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPut = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("POST")]
        [Description("Defaults success response code for HTTP POST method.")]
        [DefaultValue(HttpDefaultPostEnum.Created)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPostEnum HttpDefaultPost
        {
            get => (HttpDefaultPostEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPost;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPost = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("DELETE")]
        [Description("Defaults success response code for HTTP DELETE method.")]
        [DefaultValue(HttpDefaultDeleteEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultDeleteEnum HttpDefaultDelete
        {
            get => (HttpDefaultDeleteEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessDelete;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessDelete = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("PATCH")]
        [Description("Defaults success response code for HTTP PATCH method.")]
        [DefaultValue(HttpDefaultPatchEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPatchEnum HttpDefaultPatch
        {
            get => (HttpDefaultPatchEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPatch;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPatch = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("TRACE")]
        [Description("Defaults success response code for HTTP TRACE method.")]
        [DefaultValue(HttpDefaultTraceEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultTraceEnum HttpDefaultTrace
        {
            get => (HttpDefaultTraceEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessTrace;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessTrace = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("HEAD")]
        [Description("Defaults success response code for HTTP HEAD method.")]
        [DefaultValue(HttpDefaultHeadEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultHeadEnum HttpDefaultHead
        {
            get => (HttpDefaultHeadEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessHead;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessHead = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("OPTIONS")]
        [Description("Defaults success response code for HTTP OPTIONS method.")]
        [DefaultValue(HttpDefaultOptionsEnum.NoContent)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultOptionsEnum HttpDefaultOptions
        {
            get => (HttpDefaultOptionsEnum)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessOptions;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessOptions = (int)value;
        }
    }
}