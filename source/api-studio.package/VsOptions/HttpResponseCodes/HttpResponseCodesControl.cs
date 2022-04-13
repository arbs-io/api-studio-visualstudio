using ApiStudioIO.Utility.Extensions;
using System;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions.HttpResponseCodes
{
    public partial class HttpResponseCodesControl : UserControl
    {
        internal HttpResponseCodesDialogPage DlgPage { get; set; }
        public HttpResponseCodesControl()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            lsvResponseCodesInformation.BeginUpdate();
            lsvResponseCodesRedirection.BeginUpdate();
            lsvResponseCodesClientError.BeginUpdate();
            lsvResponseCodesServerError.BeginUpdate();

            SuccessPropertyGrid.SelectedObject = new HttpHeader();
            lsvResponseCodesInformation.SmallImageList = ControlImages;
            lsvResponseCodesRedirection.SmallImageList = ControlImages;
            lsvResponseCodesClientError.SmallImageList = ControlImages;
            lsvResponseCodesServerError.SmallImageList = ControlImages;

            lsvResponseCodesInformation.Items.Clear();
            lsvResponseCodesRedirection.Items.Clear();
            lsvResponseCodesClientError.Items.Clear();
            lsvResponseCodesServerError.Items.Clear();


            foreach (var httpResponseCode in HttpResponseExtension.HttpResponseCodes)
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

                if (httpResponseCode.Key < 200)
                    lsvResponseCodesInformation.Items.Add(lvItem);
                if (httpResponseCode.Key >= 200 && httpResponseCode.Key < 300)
                    continue;   // No success defaults
                if (httpResponseCode.Key >= 300 && httpResponseCode.Key < 400)
                    lsvResponseCodesRedirection.Items.Add(lvItem);
                if (httpResponseCode.Key >= 400 && httpResponseCode.Key < 500)
                    lsvResponseCodesClientError.Items.Add(lvItem);
                if (httpResponseCode.Key >= 500)
                    lsvResponseCodesServerError.Items.Add(lvItem);
            }
            
            HttpResponseCodesControlHelpers.AutoResizeColumns(lsvResponseCodesInformation);
            HttpResponseCodesControlHelpers.AutoResizeColumns(lsvResponseCodesRedirection);
            HttpResponseCodesControlHelpers.AutoResizeColumns(lsvResponseCodesClientError);
            HttpResponseCodesControlHelpers.AutoResizeColumns(lsvResponseCodesServerError);

            lsvResponseCodesInformation.EndUpdate();
            lsvResponseCodesRedirection.EndUpdate();
            lsvResponseCodesClientError.EndUpdate();
            lsvResponseCodesServerError.EndUpdate();
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
