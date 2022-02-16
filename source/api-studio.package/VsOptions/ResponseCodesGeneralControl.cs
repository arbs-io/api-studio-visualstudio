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

namespace ApiStudioIO.VsOptions
{
    public partial class ResponseCodesGeneralControl : UserControl
    {
        public ResponseCodesGeneralControl()
        {
            InitializeComponent();
            ListviewResponseCodes.SmallImageList = ControlImages;
        }

        internal ResponseCodesGeneralDialogPage DlgPage;

        public void Initialize()
        {
            ListviewResponseCodes.Items.Clear();
            foreach (var httpResponseCode in HttpResponseExtension.HttpResponseCodes)
            {
                if (httpResponseCode.Key >= 200 && httpResponseCode.Key < 300)
                    continue;   // No success defaults

                var lvItem = new ListViewItem
                {
                    Text = httpResponseCode.Key.ToString()
                };
                lvItem.SubItems.Add(httpResponseCode.Value.Description);
                lvItem.ToolTipText = httpResponseCode.Value.RfcReference;
                lvItem.ImageIndex = 0;

                if (DlgPage.ResponseCodeContains(httpResponseCode.Key))
                    lvItem.ImageIndex = 1;

                ListviewResponseCodes.Items.Add(lvItem);
            }
            
            AutoResizeColumns(ListviewResponseCodes);
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

        private void ListviewResponseCodes_Click(object sender, EventArgs e)
        {
            if (ListviewResponseCodes.SelectedItems.Count > 0)
            {
                var item = ListviewResponseCodes.SelectedItems[0];
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
