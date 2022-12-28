// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.ComponentModel;
using ApiStudioIO.Vs.Options;
using ApiStudioIO.VsOptions.HttpDefaults;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
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

        [Category("Success Response Codes")]
        [DisplayName("PUT")]
        [Description("Defaults success response code for HTTP PUT method.")]
        [DefaultValue(HttpDefaultPut.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPut HttpDefaultPut
        {
            get => (HttpDefaultPut)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPut;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPut = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("POST")]
        [Description("Defaults success response code for HTTP POST method.")]
        [DefaultValue(HttpDefaultPost.Created)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPost HttpDefaultPost
        {
            get => (HttpDefaultPost)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPost;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPost = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("DELETE")]
        [Description("Defaults success response code for HTTP DELETE method.")]
        [DefaultValue(HttpDefaultDelete.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultDelete HttpDefaultDelete
        {
            get => (HttpDefaultDelete)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessDelete;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessDelete = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("PATCH")]
        [Description("Defaults success response code for HTTP PATCH method.")]
        [DefaultValue(HttpDefaultPatch.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPatch HttpDefaultPatch
        {
            get => (HttpDefaultPatch)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPatch;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessPatch = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("TRACE")]
        [Description("Defaults success response code for HTTP TRACE method.")]
        [DefaultValue(HttpDefaultTrace.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultTrace HttpDefaultTrace
        {
            get => (HttpDefaultTrace)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessTrace;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessTrace = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("HEAD")]
        [Description("Defaults success response code for HTTP HEAD method.")]
        [DefaultValue(HttpDefaultHead.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultHead HttpDefaultHead
        {
            get => (HttpDefaultHead)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessHead;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessHead = (int)value;
        }

        [Category("Success Response Codes")]
        [DisplayName("OPTIONS")]
        [Description("Defaults success response code for HTTP OPTIONS method.")]
        [DefaultValue(HttpDefaultOptions.NoContent)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultOptions HttpDefaultOptions
        {
            get => (HttpDefaultOptions)ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessOptions;
            set => ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.SuccessOptions = (int)value;
        }
    }
}