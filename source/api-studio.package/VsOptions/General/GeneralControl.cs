using ApiStudioIO.VsOptions.ConfigurationV1;
using System;
using System.IO;
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

        private void ButtonInput_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "api studio (*.api-studio)|*.api-studio",
                Multiselect = false
            };
            openFileDialog.ShowDialog();
            var filename = openFileDialog.FileName;
            _ = MessageBox.Show(filename);
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "api studio (*.api-studio)|*.api-studio",
                DefaultExt = "api-studio",
                AddExtension = true,
            };
            dlg.ShowDialog();
            var filename = dlg.FileName;
            _ = MessageBox.Show(filename);

            var json = ApiStudioUserSettingsStore.Instance.SerializeJson();
            File.WriteAllText(filename, json);
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ApiStudioUserSettingsStore.Instance.ResetDefaults();
        }
    }
}
