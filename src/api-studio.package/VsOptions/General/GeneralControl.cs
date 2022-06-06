// The MIT License (MIT)
//
// Copyright (c) 2022 Andrew Butson
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ApiStudioIO.VsOptions.ConfigurationV1;

namespace ApiStudioIO.VsOptions.General
{
    public partial class GeneralControl : UserControl
    {
        internal GeneralDialogPage generalDialogPage;

        public GeneralControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            SetInformationText();
        }

        private void SetInformationText()
        {
            SetInformationText("Easy to use: ",
                "A well-designed API will be easy to work with.Its resources and associated operations can quickly be memorized by developers who work with it constantly.\r\n\r\n");
            SetInformationText("Hard to misuse: ",
                "Implementing and integrating with an API with good design will be straightforward, and writing incorrect code will be less likely.It has informative feedback and doesn’t enforce strict guidelines on the API’s end consumer.\r\n\r\n");
            SetInformationText("Complete and concise: ",
                "A comprehensive API will allow developers to make fully - fledged applications against your exposed data.Completeness happens over time usually, and most API designers and developers incrementally build on top of existing APIs.");
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
                AddExtension = true
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