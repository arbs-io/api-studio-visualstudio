using Microsoft.VisualStudio.Shell;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions.General
{
    [Guid("3fbe168a-cba9-4cb3-a6e0-a919dfaa3710")]
    public class GeneralDialogPage : DialogPage
    {
        public string Version { get; set; } = "alpha";
        public string Description { get; set; } = "todo";
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
