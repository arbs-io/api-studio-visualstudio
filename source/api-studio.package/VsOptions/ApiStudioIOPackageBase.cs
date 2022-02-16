using ApiStudioIO.VsOptions;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(ResponseCodesSuccessDialogPage), "Api Studio", "Response Codes (Success)", 0, 0, true)]
    [ProvideOptionPage(typeof(ResponseCodesGeneralDialogPage), "Api Studio", "Response Codes (General)", 0, 0, true)]    
    internal sealed partial class ApiStudioIOPackage
    {
    }
}
