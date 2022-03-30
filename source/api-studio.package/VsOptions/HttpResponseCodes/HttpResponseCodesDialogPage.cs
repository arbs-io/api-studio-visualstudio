using System;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
{
    [Guid("d69fefa9-3add-4219-af38-2d9f01a8c314")]
    public class HttpResponseCodesDialogPage : DialogPage
    {
        private HttpResponseCodesControl control;

        internal void AddResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.StandardResponseCodes.Add(ResponseCode);
        }

        internal void RemoveResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.StandardResponseCodes.Remove(ResponseCode);
        }

        internal bool ResponseCodeContains(int ResponseCode)
        {
            return ApiStudioUserSettingsStore.Instance.DefaultResponseCodes.StandardResponseCodes.Contains(ResponseCode);
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

        protected override void OnActivate(CancelEventArgs e)
        {
            base.OnActivate(e);

            if(control != null)
                control.Initialize();
        }

        protected override IWin32Window Window
        {
            get
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                control = new HttpResponseCodesControl
                {
                    DlgPage = this
                };
                return control;
            }
        }
    }
}
