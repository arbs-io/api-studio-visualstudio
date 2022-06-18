// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO.VsOptions.General
{
    [Guid("3fbe168a-cba9-4cb3-a6e0-a919dfaa3710")]
    public class GeneralDialogPage : DialogPage
    {
        protected override IWin32Window Window
        {
            get
            {
                var page = new GeneralControl
                {
                    generalDialogPage = this
                };
                page.Initialize();
                return page;
            }
        }
    }
}