namespace ApiStudioIO.VsOptions.HttpHeaders
{
    using ApiStudioIO.VsOptions.Helper;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class HttpHeadersControl : UserControl
    {
        internal HttpHeadersDialogPage DlgPage { get; set; }

        public HttpHeadersControl()
        {
            InitializeComponent();
        }
        public void Initialize()
        {
            ListviewRequestHeaders.SmallImageList = ControlImages;
        }
        
        private void ButtonAdd_Click(object sender, System.EventArgs e)
        {
            var lvItem = new ListViewItem
            {
                Text = TextboxName.Text,
                ImageIndex = 2,
            };
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = CheckboxIsRequired.Checked ? 1 : 0 });
            lvItem.SubItems.Add(new ListViewItem.ListViewSubItem { Tag = CheckboxAllowEmpty.Checked ? 1 : 0 });
            lvItem.SubItems.Add(TextboxDescription.Text);

            ListviewRequestHeaders.Items.Add(lvItem);

            ListViewControlHelpers.AutoResizeColumns(ListviewRequestHeaders);
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
                Size sz = ControlImages.ImageSize;
                int idx = 0;
                if (e.SubItem.Tag != null) idx = (int)e.SubItem.Tag;
                Bitmap bmp = (Bitmap)ControlImages.Images[idx];
                Rectangle rTgt = new Rectangle(e.Bounds.Location, sz);
                if (bmp != null) e.Graphics.DrawImage(bmp, rTgt);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}
