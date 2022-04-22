namespace ApiStudioIO.VsOptions.HttpSecurity
{
    using Microsoft.VisualStudio.Shell;
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Runtime.InteropServices;

    [Guid("8dda9af5-90e5-43bc-9983-d4604664cb7c")]
    public class SecurityDialogPage : DialogPage
    {
        [Category("Roles")]
        [DisplayName("Security Scheme")]
        [Description("My integer option")]
        public SecuritySchemeTypes SecurityScheme { get; set; } = SecuritySchemeTypes.None;

        [Category("Roles")]
        [DisplayName("Pattern")]
        [Description("The pattern to be used for roles")]
        [Editor(typeof(UITypeEditorDropDown), typeof(UITypeEditor))]
        public string RolePattern { get; set; } = "{Resource}::{Action}";
    }
}
