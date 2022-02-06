using ApiStudioIO.VsOptions;
using Microsoft.VisualStudio.Shell;

namespace ApiStudioIO
{
    [ProvideOptionPage(typeof(GeneralDialogPage), "Api Studio", "General", 0, 0, true)]
    [ProvideOptionPage(typeof(PropertyDialogPage), "Api Studio", "Properties", 0, 0, true)]
    internal sealed partial class ApiStudioIOPackage
    {
    }
}
