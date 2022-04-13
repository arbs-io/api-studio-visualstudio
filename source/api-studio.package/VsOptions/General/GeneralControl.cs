using ApiStudioIO.VsOptions.ConfigurationV1;
using System;
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

        private void BtnInput_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "api studio (*.api-studio)|All files (*.*)|*.*",
                Multiselect = false
            };
            openFileDialog.ShowDialog();
            var filename = openFileDialog.FileName;
            _ = MessageBox.Show(filename);
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.ShowDialog();
            var filename = saveFileDialog.FileName;
            _ = MessageBox.Show(filename);

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            ApiStudioUserSettingsStore.Instance.ResetDefaults();
        }
    }
}
