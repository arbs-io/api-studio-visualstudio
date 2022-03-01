using ApiStudioIO.VsOptions;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(VsOptions.General.GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpResponseCodes.HttpResponseCodesDialogPage), "Api Studio", "Response Codes", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpHeaders.HttpHeadersDialogPage), "Api Studio", "Headers", 0, 0, true)]
    internal sealed partial class ApiStudioIOPackage
    {
    }
}
