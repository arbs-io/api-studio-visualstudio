// Copyright (c) Andrew Butson.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ApiStudioIO.Utility.Extensions;
using ApiStudioIO.VsOptions.Helper;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
{
    public partial class HttpResponseCodesControl : UserControl
    {
        public HttpResponseCodesControl()
        {
            InitializeComponent();
        }

        internal HttpResponseCodesDialogPage DlgPage { get; set; }

        public void Initialize()
        {
            var responseCodesInformation = HttpResponseExtension.HttpResponseCodes
                .Where(a => a.Key < 200);
            InitializeResponseCodes(lsvResponseCodesInformation, responseCodesInformation);

            var responseCodesRedirection = HttpResponseExtension.HttpResponseCodes
                .Where(a => a.Key >= 300 && a.Key < 400);
            InitializeResponseCodes(lsvResponseCodesRedirection, responseCodesRedirection);

            var responseCodesClientError = HttpResponseExtension.HttpResponseCodes
                .Where(a => a.Key >= 400 && a.Key < 500);
            InitializeResponseCodes(lsvResponseCodesClientError, responseCodesClientError);

            var responseCodesServerError = HttpResponseExtension.HttpResponseCodes
                .Where(a => a.Key >= 500);
            InitializeResponseCodes(lsvResponseCodesServerError, responseCodesServerError);
        }

        private void InitializeResponseCodes(ListView lsv, IEnumerable<KeyValuePair<int, HttpResponseExtension.ResponseInformation>> httpResponseCodes)
        {
            lsv.BeginUpdate();
            lsv.SmallImageList = ControlImages;
            lsv.Items.Clear();

            foreach (var httpResponseCode in httpResponseCodes)
            {
                var lvItem = new ListViewItem
                {
                    Text = httpResponseCode.Key.ToString()
                };
                lvItem.SubItems.Add(httpResponseCode.Value.Description);
                lvItem.ToolTipText = httpResponseCode.Value.RfcReference;
                lvItem.ImageIndex = 0;

                if (DlgPage.ResponseCodeContains(httpResponseCode.Key))
                    lvItem.ImageIndex = 1;

                lsv.Items.Add(lvItem);
            }

            ListViewControlHelpers.AutoResizeColumns(lsv);
            lsv.EndUpdate();
        }

        private void ResponseCodesRedirection_Click(object sender, EventArgs e)
        {
            ListviewClicked(lsvResponseCodesRedirection);
        }

        private void ResponseCodesInformation_Click(object sender, EventArgs e)
        {
            ListviewClicked(lsvResponseCodesInformation);
        }

        private void ResponseCodesClientError_Click(object sender, EventArgs e)
        {
            ListviewClicked(lsvResponseCodesClientError);
        }

        private void ResponseCodesServerError_Click(object sender, EventArgs e)
        {
            ListviewClicked(lsvResponseCodesServerError);
        }


        private void ListviewClicked(ListView listview)
        {
            _ = listview ?? throw new ArgumentNullException(nameof(listview));

            if (listview.SelectedItems.Count > 0)
            {
                var item = listview.SelectedItems[0];
                if (item.ImageIndex == 0)
                {
                    item.ImageIndex = 1;
                    DlgPage.AddResponseCode(int.Parse(item.Text));
                }
                else
                {
                    item.ImageIndex = 0;
                    DlgPage.RemoveResponseCode(int.Parse(item.Text));
                }
            }
        }
    }
}