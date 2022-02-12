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
    public partial class ResponseCodesControl : UserControl
    {
        public ResponseCodesControl()
        {
            InitializeComponent();
        }

        internal ResponseCodesDialogPage responseCodesDialogPage;

        public void Initialize()
        {
            lvwResponseCodes.Items.Clear();
            foreach (var httpResponseCode in HttpResponseExtension.HttpResponseCodes)
            {
                var lvItem = new ListViewItem
                {
                    Text = httpResponseCode.Key.ToString()
                };
                lvItem.SubItems.Add(httpResponseCode.Value.Description);
                lvItem.ToolTipText = httpResponseCode.Value.RfcReference;

                if (responseCodesDialogPage.ResponseCodeContains(httpResponseCode.Key))
                    lvItem.Checked = true;

                lvwResponseCodes.Items.Add(lvItem);
            }
            
            AutoResizeColumns(lvwResponseCodes);
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


        private void lvwResponseCodes_Click(object sender, EventArgs e)
        {
            if (lvwResponseCodes.SelectedItems.Count > 0)
            {
                var item = lvwResponseCodes.SelectedItems[0];
                item.Checked = !item.Checked;
                if (item.Checked)
                    responseCodesDialogPage.AddResponseCode(int.Parse(item.Text));
                else
                    responseCodesDialogPage.RemoveResponseCode(int.Parse(item.Text));
            }
        }
    }
}
