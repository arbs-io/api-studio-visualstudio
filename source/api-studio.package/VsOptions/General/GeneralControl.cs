using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions.General
{
    public partial class GeneralControl : UserControl
    {
        public GeneralControl()
        {
            InitializeComponent();
        }

        internal GeneralDialogPage generalDialogPage;

        public void Initialize()
        {
            VersionValue.Text = generalDialogPage.Version;
            Description.Text = generalDialogPage.Description;
        }

        private void VersionValue_TextChanged(object sender, EventArgs e)
        {
            generalDialogPage.Version = VersionValue.Text;
        }

        private void Description_TextChanged(object sender, EventArgs e)
        {
            generalDialogPage.Description = Description.Text;
        }
    }
}
