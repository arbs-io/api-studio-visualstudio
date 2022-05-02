﻿namespace ApiStudioIO.VsOptions.Helper
{
    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;

    class ApiStudioUITypeEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _editorService;

        public readonly string[] lookupValues;
        public ApiStudioUITypeEditor (string[] values)
        {
            lookupValues = values;
        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            // drop down mode (we'll host a listbox in the drop down)
            return UITypeEditorEditStyle.DropDown;
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));

            // use a list box
            ListBox lb = new ListBox();
            lb.SelectionMode = SelectionMode.One;
            lb.SelectedValueChanged += OnListBoxSelectedValueChanged;

            lb.DisplayMember = "Name";

            // get the analytic object from context
            // this is how we get the list of possible benchmarks
            foreach (var lookupValue in lookupValues)
            {
                // we store benchmarks objects directly in the listbox
                int index = lb.Items.Add(lookupValue);
                if (value.Equals(lookupValue))
                {
                    lb.SelectedIndex = index;
                }
            }

            // show this model stuff
            _editorService.DropDownControl(lb);
            if (lb.SelectedItem == null) // no selection, return the passed-in value as is
                return value;

            return lb.SelectedItem;
        }

        

        private void OnListBoxSelectedValueChanged(object sender, EventArgs e)
        {
            // close the drop down as soon as something is clicked
            _editorService.CloseDropDown();
        }
    }
}
