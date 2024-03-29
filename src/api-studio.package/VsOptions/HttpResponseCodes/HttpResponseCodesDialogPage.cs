﻿// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApiStudioIO.Vs.Options;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
{
    [Guid("d69fefa9-3add-4219-af38-2d9f01a8c314")]
    public class HttpResponseCodesDialogPage : DialogPage
    {
        private HttpResponseCodesControl control;

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

        internal void AddResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.StandardResponseCodes.Add(ResponseCode);
        }

        internal void RemoveResponseCode(int ResponseCode)
        {
            ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.StandardResponseCodes.Remove(ResponseCode);
        }

        internal bool ResponseCodeContains(int ResponseCode)
        {
            return ApiStudioUserSettingsStore.Instance.Data.DefaultResponseCodes.StandardResponseCodes.Contains(
                ResponseCode);
        }

        public override void SaveSettingsToStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.SaveSettingsToStorage();
            ApiStudioUserSettingsStore.Instance.VsOptionStoreSave();
        }

        public override void LoadSettingsFromStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();
            base.LoadSettingsFromStorage();
            ApiStudioUserSettingsStore.Instance.VsOptionStoreLoad();
        }

        protected override void OnActivate(CancelEventArgs e)
        {
            base.OnActivate(e);

            if (control != null)
                control.Initialize();
        }
    }
}