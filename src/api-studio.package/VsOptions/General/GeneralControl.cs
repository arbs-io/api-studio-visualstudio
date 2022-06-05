using ApiStudioIO.VsOptions.ConfigurationV1;
using System;
using System.Drawing;
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
            SetInformationText();
        }

        private void SetInformationText()
        {
            SetInformationText("Easy to use: ", "A well-designed API will be easy to work with.Its resources and associated operations can quickly be memorized by developers who work with it constantly.\r\n\r\n");
            SetInformationText("Hard to misuse: ", "Implementing and integrating with an API with good design will be straightforward, and writing incorrect code will be less likely.It has informative feedback and doesn’t enforce strict guidelines on the API’s end consumer.\r\n\r\n");
            SetInformationText("Complete and concise: ", "A comprehensive API will allow developers to make fully - fledged applications against your exposed data.Completeness happens over time usually, and most API designers and developers incrementally build on top of existing APIs.");
        }
        private void SetInformationText(string header, string message)
        {
            var length = richTextInformation.Text.Length;
            richTextInformation.AppendText($"{header}: {message}");
            richTextInformation.Select(length, header.Length);
            richTextInformation.SelectionFont = new Font(richTextInformation.Font, FontStyle.Bold);
        }
        
        private void ButtonInput_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = "api studio (*.api-studio)|*.api-studio",
                Multiselect = false
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filename = dlg.FileName;
                var apiStudioJson = File.ReadAllText(filename);
                ApiStudioUserSettingsStore.Instance.ImportVsOption(apiStudioJson);
            }
        }

        private void ButtonExport_Click(object sender, EventArgs e)
        {
            var dlg = new SaveFileDialog
            {
                Filter = "api studio (*.api-studio)|*.api-studio",
                DefaultExt = "api-studio",
                AddExtension = true,
            };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filename = dlg.FileName;
                var apiStudioJson = ApiStudioUserSettingsStore.Instance.ExportVsOption();
                File.WriteAllText(filename, apiStudioJson);
            }            
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            ApiStudioUserSettingsStore.Instance.ResetDefaults();
        }
    }
}
