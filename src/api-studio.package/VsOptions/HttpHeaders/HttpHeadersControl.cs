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
using System.Windows.Forms;
using ApiStudioIO.VsOptions.ConfigurationV1;
using ApiStudioIO.VsOptions.Helper;

namespace ApiStudioIO.VsOptions.HttpHeaders
{
    public partial class HttpHeadersControl : UserControl
    {
        public HttpHeadersControl()
        {
            InitializeComponent();
        }

        internal HttpHeadersDialogPage DlgPage { get; set; }

        public void Initialize()
        {
            ListviewRequestHeaders.SmallImageList = ControlImages;
            LoadRequestHeaders();
            LoadResponseHeaders();
        }

        #region Response Header

        public void LoadResponseHeaders()
        {
            ListviewResponseHeaders.BeginUpdate();
            ListviewResponseHeaders.Items.Clear();
            foreach (var item in ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Response.Values)
            {
                var lvItem = new ListViewItem
                {
                    Text = item.Name,
                    ImageIndex = 3
                };
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = item.IsRequired ? 1 : 0 });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = item.AllowEmptyValue ? 1 : 0 });
                lvItem.SubItems.Add(item.Description);
                ListviewResponseHeaders.Items.Add(lvItem);
                ListViewControlHelpers.AutoResizeColumns(ListviewResponseHeaders);
            }

            ListviewResponseHeaders.EndUpdate();
        }

        private void ListviewResponseHeaders_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListviewResponseHeaders_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.DrawBackground();
                var sz = ControlImages.ImageSize;
                var idx = 0;
                if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
                var bmp = (Bitmap)ControlImages.Images[idx];
                var rTgt = new Rectangle(e.Bounds.Location, sz);
                if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ListviewResponseHeaders_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                    DlgPage.RemoveResponseHeader(listViewItem.Text);
                LoadResponseHeaders();
            }
        }

        private void ButtonResponseAdd_Click(object sender, EventArgs e)
        {
            DlgPage.AddResponseHeader(TextboxResponseName.Text, TextboxResponseDescription.Text,
                CheckboxResponseIsRequired.Checked, CheckboxResponseAllowEmpty.Checked);
            LoadResponseHeaders();
        }

        #endregion //Response Header

        #region Request Header

        public void LoadRequestHeaders()
        {
            ListviewRequestHeaders.BeginUpdate();
            ListviewRequestHeaders.Items.Clear();
            foreach (var item in ApiStudioUserSettingsStore.Instance.Data.DefaultHeaders.Request.Values)
            {
                var lvItem = new ListViewItem
                {
                    Text = item.Name,
                    ImageIndex = 2
                };
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = item.IsRequired ? 1 : 0 });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = item.AllowEmptyValue ? 1 : 0 });
                lvItem.SubItems.Add(item.Description);
                ListviewRequestHeaders.Items.Add(lvItem);
                ListViewControlHelpers.AutoResizeColumns(ListviewRequestHeaders);
            }

            ListviewRequestHeaders.EndUpdate();
        }

        private void ListviewRequestHeaders_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListviewRequestHeaders_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
            {
                e.DrawBackground();
                var sz = ControlImages.ImageSize;
                var idx = 0;
                if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
                var bmp = (Bitmap)ControlImages.Images[idx];
                var rTgt = new Rectangle(e.Bounds.Location, sz);
                if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        private void ListviewRequestHeaders_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Delete == e.KeyCode)
            {
                foreach (ListViewItem listViewItem in ((ListView)sender).SelectedItems)
                    DlgPage.RemoveRequestHeader(listViewItem.Text);
                LoadRequestHeaders();
            }
        }

        private void ButtonRequestAdd_Click(object sender, EventArgs e)
        {
            DlgPage.AddRequestHeader(TextboxRequestName.Text, TextboxRequestDescription.Text,
                CheckboxRequestIsRequired.Checked, CheckboxRequestAllowEmpty.Checked);
            LoadRequestHeaders();
        }

        #endregion //Request Header
    }
}