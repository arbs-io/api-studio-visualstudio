using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ApiStudioIO.VsOptions
{
    public class ResponseCodesSuccess
    {
        public enum HttpDefaultGetEnum
        {
            OK = 200,
        }
        [Category("Success Response Codes")]
        [DisplayName("GET")]
        [Description("Defaults success response code for HTTP GET method.")]
        [DefaultValue(HttpDefaultGetEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultGetEnum HttpDefaultGet
        {
            get { return (HttpDefaultGetEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessGet; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessGet = (int)value; }
        }

        public enum HttpDefaultPutEnum
        {
            OK = 200,
            Created = 201,
            Accepted = 202,
            NoContent = 204
        }
        [Category("Success Response Codes")]
        [DisplayName("PUT")]
        [Description("Defaults success response code for HTTP PUT method.")]
        [DefaultValue(HttpDefaultPutEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPutEnum HttpDefaultPut
        {
            get { return (HttpDefaultPutEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPut; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPut = (int)value; }
        }

        public enum HttpDefaultPostEnum
        {
            Created = 201,
        }
        [Category("Success Response Codes")]
        [DisplayName("POST")]
        [Description("Defaults success response code for HTTP POST method.")]
        [DefaultValue(HttpDefaultPostEnum.Created)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPostEnum HttpDefaultPost
        {
            get { return (HttpDefaultPostEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPost; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPost = (int)value; }
        }

        public enum HttpDefaultDeleteEnum
        {
            OK = 200,
            Accepted = 202,
            NoContent = 204
        }
        [Category("Success Response Codes")]
        [DisplayName("DELETE")]
        [Description("Defaults success response code for HTTP DELETE method.")]
        [DefaultValue(HttpDefaultDeleteEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultDeleteEnum HttpDefaultDelete
        {
            get { return (HttpDefaultDeleteEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessDelete; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessDelete = (int)value; }
        }

        public enum HttpDefaultPatchEnum
        {
            OK = 200,
            Created = 201,
            Accepted = 202,
            NoContent = 204
        }
        [Category("Success Response Codes")]
        [DisplayName("PATCH")]
        [Description("Defaults success response code for HTTP PATCH method.")]
        [DefaultValue(HttpDefaultPatchEnum.Accepted)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPatchEnum HttpDefaultPatch
        {
            get { return (HttpDefaultPatchEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPatch; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessPatch = (int)value; }
        }

        public enum HttpDefaultTraceEnum
        {
            OK = 200
        }
        [Category("Success Response Codes")]
        [DisplayName("TRACE")]
        [Description("Defaults success response code for HTTP TRACE method.")]
        [DefaultValue(HttpDefaultTraceEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultTraceEnum HttpDefaultTrace
        {
            get { return (HttpDefaultTraceEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessTrace; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessTrace = (int)value; }
        }

        public enum HttpDefaultHeadEnum
        {
            OK = 200
        }
        [Category("Success Response Codes")]
        [DisplayName("HEAD")]
        [Description("Defaults success response code for HTTP HEAD method.")]
        [DefaultValue(HttpDefaultHeadEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultHeadEnum HttpDefaultHead
        {
            get { return (HttpDefaultHeadEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessHead; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessHead = (int)value; }
        }

        public enum HttpDefaultOptionsEnum
        {
            NoContent = 204
        }
        [Category("Success Response Codes")]
        [DisplayName("OPTIONS")]
        [Description("Defaults success response code for HTTP OPTIONS method.")]
        [DefaultValue(HttpDefaultOptionsEnum.NoContent)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultOptionsEnum HttpDefaultOptions
        {
            get { return (HttpDefaultOptionsEnum)ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessOptions; }
            set { ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.SuccessOptions = (int)value; }
        }
    }
}
