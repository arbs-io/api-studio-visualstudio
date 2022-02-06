using Microsoft.VisualStudio.Shell;
using System.ComponentModel;

namespace ApiStudioIO.VsOptions
{
    public class PropertyDialogPage : DialogPage
    {
        [Category("My Category")]
        [DisplayName("My Integer Option")]
        [Description("My integer option")]
        public int OptionInteger { get; set; } = 256;
    }
}
