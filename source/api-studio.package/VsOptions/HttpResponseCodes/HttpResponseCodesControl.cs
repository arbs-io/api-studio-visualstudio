using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiStudioIO.Utility.Extensions;

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
                var lsv = new ListView();
                if (httpResponseCode.Key < 200)
                    lsv = lsvResponseCodesInformation;
                if (httpResponseCode.Key >= 200 && httpResponseCode.Key < 300)
                    continue;   // No success defaults
                if (httpResponseCode.Key >= 300 && httpResponseCode.Key < 400)
                    lsv = lsvResponseCodesRedirection;
                if (httpResponseCode.Key >= 400 && httpResponseCode.Key < 500)
                    lsv = lsvResponseCodesClientError;
                if (httpResponseCode.Key >= 500)
                    lsv = lsvResponseCodesServerError;

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

            AutoResizeColumns(lsvResponseCodesInformation);
            AutoResizeColumns(lsvResponseCodesRedirection);
            AutoResizeColumns(lsvResponseCodesClientError);
            AutoResizeColumns(lsvResponseCodesServerError);
        }

        private static void AutoResizeColumns(ListView lv)
        {
            lv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            ListView.ColumnHeaderCollection cc = lv.Columns;
            for (int i = 0; i < cc.Count; i++)
            {
                int colWidth = TextRenderer.MeasureText(cc[i].Text, lv.Font).Width + 10;
                if (colWidth > cc[i].Width)
                {
                    cc[i].Width = colWidth;
                }
            }
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
