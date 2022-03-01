using System;
using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;

namespace ApiStudioIO.VsOptions.HttpHeaders
{
    [Guid("cad156f0-dfca-431f-8828-bdb84d992ad8")]
    public class HttpHeadersDialogPage : DialogPage
    {
        private HttpHeadersControl control;

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
                control = new HttpHeadersControl
                {
                    DlgPage = this
                };
                return control;
            }
        }
    }
}
