using ApiStudioIO.VsOptions.General;
using ApiStudioIO.VsOptions.HttpHeaders;
using ApiStudioIO.VsOptions.HttpResponseCodes;
using ApiStudioIO.VsOptions.HttpSecurity;
using ApiStudioIO.VsOptions.HttpSpecification;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(SpecificationDialogPage), "Api Studio", "Api Specification", 0, 0, true)]
    [ProvideOptionPage(typeof(SecurityDialogPage), "Api Studio", "Api Security", 0, 0, true)]
    [ProvideOptionPage(typeof(HttpResponseCodesDialogPage), "Api Studio", "HTTP Response Codes", 0, 0, true)]
    [ProvideOptionPage(typeof(HttpHeadersDialogPage), "Api Studio", "HTTP Headers", 0, 0, true)]
    internal sealed partial class ApiStudioIOPackage
    {
    }
}