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
        private bool _isInitialized = false;

        public void Initialize()
        {
            _isInitialized = false;

            lvwResponseCodes.Items.Clear();
            foreach (var httpResponseCode in HttpResponseExtension.HttpResponseCodes)
            {
                var lvItem = new ListViewItem();
                
                lvItem.Text = httpResponseCode.Key.ToString();
                lvItem.SubItems.Add(httpResponseCode.Value.Description);
                lvItem.SubItems.Add(httpResponseCode.Value.RfcReference);

                if (responseCodesDialogPage.ResponseCodes.Contains(httpResponseCode.Key))
                    lvItem.Checked = true;

                lvwResponseCodes.Items.Add(lvItem);
            }
            
            autoResizeColumns(lvwResponseCodes);
            _isInitialized = true;
        }

        private static void autoResizeColumns(ListView lv)
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

        private void lvwResponseCodes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (_isInitialized)
            {
                if (e.Item.Checked)
                    responseCodesDialogPage.ResponseCodes.Add(int.Parse(e.Item.Text));
                else
                    responseCodesDialogPage.ResponseCodes.Remove(int.Parse(e.Item.Text));
            }
        }
    }
}
