﻿using System;
using System.Windows.Forms;

namespace ApiStudioIO.VsOptions.Helper
{
    internal static class ListViewControlHelpers
    {
        internal static void AutoResizeColumns(ListView lv)
        {
            _ = lv ?? throw new ArgumentNullException(nameof(lv));

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
    }
}