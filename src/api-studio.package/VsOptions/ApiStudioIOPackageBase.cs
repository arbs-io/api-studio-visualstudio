using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(VsOptions.General.GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpSpecification.SpecificationDialogPage), "Api Studio", "Api Specification", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpSecurity.SecurityDialogPage), "Api Studio", "Api Security", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpResponseCodes.HttpResponseCodesDialogPage), "Api Studio", "HTTP Response Codes", 0, 0, true)]
    [ProvideOptionPage(typeof(VsOptions.HttpHeaders.HttpHeadersDialogPage), "Api Studio", "HTTP Headers", 0, 0, true)]
    internal sealed partial class ApiStudioIOPackage
    {
    }
}
