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