using System.ComponentModel;

namespace ApiStudioIO
{
    internal partial class OptionsProvider
    {
        // Register the options with these attributes on your package class:
        // [ProvideOptionPage(typeof(OptionsProvider.General1Options), "ApiStudioIO", "General1", 0, 0, true)]
        // [ProvideProfile(typeof(OptionsProvider.General1Options), "ApiStudioIO", "General1", 0, 0, true)]
        public class General1Options : BaseOptionPage<General1> { }
    }

    public class General1 : BaseOptionModel<General1>
    {
        [Category("My category")]
        [DisplayName("My Option")]
        [Description("An informative description.")]
        [DefaultValue(true)]
        public bool MyOption { get; set; } = true;
    }
}
