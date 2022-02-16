using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ApiStudioIO.VsOptions
{
    public class ResponseCodesSuccessDialogPage : DialogPage
    {
        public override void SaveSettingsToStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.SaveSettingsToStorage();
            ApiStudioUserSettingsStore.Instance.Save();
        }

        public override void LoadSettingsFromStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.LoadSettingsFromStorage();
            ApiStudioUserSettingsStore.Instance.Load();
        }

        public enum HttpDefaultGetEnum
        {
            OK = 200,
        }
        [Category("Success Response Codes")]
        [DisplayName("GET")]
        [Description("Defaults success response code for HTTP GET method.")]
        [DefaultValue(HttpDefaultGetEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultGetEnum HttpDefaultGet { get; set; } 
            = (HttpDefaultGetEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultGet;

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
        public HttpDefaultPutEnum HttpDefaultPut { get; set; } 
            = (HttpDefaultPutEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultPut;


        public enum HttpDefaultPostEnum
        {
            Created = 201,
        }
        [Category("Success Response Codes")]
        [DisplayName("POST")]
        [Description("Defaults success response code for HTTP POST method.")]
        [DefaultValue(HttpDefaultPostEnum.Created)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultPostEnum HttpDefaultPost { get; set; } 
            = (HttpDefaultPostEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultPost;

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
        public HttpDefaultDeleteEnum HttpDefaultDelete { get; set; } 
            = (HttpDefaultDeleteEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultDelete;

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
        public HttpDefaultPatchEnum HttpDefaultPatch { get; set; } 
            = (HttpDefaultPatchEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultPatch;

        public enum HttpDefaultTraceEnum
        {
            OK = 200
        }
        [Category("Success Response Codes")]
        [DisplayName("TRACE")]
        [Description("Defaults success response code for HTTP TRACE method.")]
        [DefaultValue(HttpDefaultTraceEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultTraceEnum HttpDefaultTrace { get; set; } 
            = (HttpDefaultTraceEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultTrace;

        public enum HttpDefaultHeadEnum
        {
            OK = 200
        }
        [Category("Success Response Codes")]
        [DisplayName("HEAD")]
        [Description("Defaults success response code for HTTP HEAD method.")]
        [DefaultValue(HttpDefaultHeadEnum.OK)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultHeadEnum HttpDefaultHead { get; set; } 
            = (HttpDefaultHeadEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultHead;

        public enum HttpDefaultOptionsEnum
        {
            NoContent = 204
        }
        [Category("Success Response Codes")]
        [DisplayName("OPTIONS")]
        [Description("Defaults success response code for HTTP OPTIONS method.")]
        [DefaultValue(HttpDefaultOptionsEnum.NoContent)]
        [TypeConverter(typeof(EnumConverter))]
        public HttpDefaultOptionsEnum HttpDefaultOptions { get; set; } 
            = (HttpDefaultOptionsEnum)ApiStudioUserSettingsStore.Instance.HttpDefaultOptions;
    }
}
