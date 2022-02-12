using System;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions
{
    [Guid("d69fefa9-3add-4219-af38-2d9f01a8c314")]
    public class ResponseCodesDialogPage : DialogPage
    {
        private const string collectionName = "ApiStudio";

        //internal List<int> ResponseCodes { get; set; }
        internal void AddResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.ResponseCodes.Add(ResponseCode);
        }

        internal void RemoveResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.ResponseCodes.Remove(ResponseCode);
        }

        internal bool ResponseCodeContains(int ResponseCode)
        {
            return ApiStudioUserSettingsStore.Instance.ResponseCodes.Contains(ResponseCode);
        }

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

        protected override IWin32Window Window
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                ResponseCodesControl page = new ResponseCodesControl
                {
                    responseCodesDialogPage = this
                };
                page.Initialize();
                return page;
            }
        }
    }
}
