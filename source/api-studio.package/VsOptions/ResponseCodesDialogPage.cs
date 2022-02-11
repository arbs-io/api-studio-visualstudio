using Microsoft.VisualStudio.Shell;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions
{
    [Guid("d69fefa9-3add-4219-af38-2d9f01a8c314")]
    public class ResponseCodesDialogPage : DialogPage
    { 
        public List<int> ResponseCodes { get; set; } = new List<int>() { 401, 403 };
        
        protected override IWin32Window Window
        {
            get
            {
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
