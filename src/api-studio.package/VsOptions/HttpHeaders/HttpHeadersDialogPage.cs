// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ApiStudioIO.Common.Models.Http;
using ApiStudioIO.VsOptions.ConfigurationV1;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.VsOptions.HttpHeaders
{
    [Guid("cad156f0-dfca-431f-8828-bdb84d992ad8")]
    public class HttpHeadersDialogPage : DialogPage
    {
        private HttpHeadersControl control;

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

        internal void AddResponseHeader(string Name, string Description, bool IsRequired, bool AllowEmptyValue)
        {
            var header = new HttpResourceHeaderResponse
            {
                Name = Name,
                Description = Description,
                IsRequired = IsRequired,
                AllowEmptyValue = AllowEmptyValue
            };
            if (ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.ContainsKey(Name))
                ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.Remove(Name);

            ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.Add(Name, header);
        }

        internal void RemoveResponseHeader(string Name)
        {
            if (ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.ContainsKey(Name))
                ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.Remove(Name);
        }

        internal void AddRequestHeader(string Name, string Description, bool IsRequired, bool AllowEmptyValue)
        {
            var header = new HttpResourceHeaderRequest
            {
                Name = Name,
                Description = Description,
                IsRequired = IsRequired,
                AllowEmptyValue = AllowEmptyValue
            };
            if (ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.ContainsKey(Name))
                ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.Remove(Name);

            ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.Add(Name, header);
        }

        internal void RemoveRequestHeader(string Name)
        {
            if (ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.ContainsKey(Name))
                ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.Remove(Name);
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