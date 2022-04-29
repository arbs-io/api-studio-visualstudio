namespace ApiStudioIO.VsOptions.HttpHeaders
{
    partial class HttpHeadersControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HttpHeadersControl));
            this.tabPageResponse = new System.Windows.Forms.TabPage();
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRequest = new System.Windows.Forms.TabPage();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckboxAllowEmpty = new System.Windows.Forms.CheckBox();
            this.CheckboxIsRequired = new System.Windows.Forms.CheckBox();
            this.TextboxName = new System.Windows.Forms.TextBox();
            this.ListviewRequestHeaders = new System.Windows.Forms.ListView();
            this.columnRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEmpty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabResponseCodes = new System.Windows.Forms.TabControl();
            this.ControlImages = new System.Windows.Forms.ImageList(this.components);
            this.tabPageRequest.SuspendLayout();
            this.tabResponseCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageResponse
            // 
            this.tabPageResponse.Location = new System.Drawing.Point(4, 22);
            this.tabPageResponse.Name = "tabPageResponse";
            this.tabPageResponse.Size = new System.Drawing.Size(413, 341);
            this.tabPageResponse.TabIndex = 3;
            this.tabPageResponse.Text = "Response";
            this.tabPageResponse.UseVisualStyleBackColor = true;
            // 
            // columnDescription
            // 
            this.columnDescription.Text = "Description";
            this.columnDescription.Width = 169;
            // 
            // columnName
            // 
            this.columnName.Text = "Name";
            this.columnName.Width = 50;
            // 
            // tabPageRequest
            // 
            this.tabPageRequest.Controls.Add(this.ButtonAdd);
            this.tabPageRequest.Controls.Add(this.ButtonReset);
            this.tabPageRequest.Controls.Add(this.label2);
            this.tabPageRequest.Controls.Add(this.TextboxDescription);
            this.tabPageRequest.Controls.Add(this.label1);
            this.tabPageRequest.Controls.Add(this.CheckboxAllowEmpty);
            this.tabPageRequest.Controls.Add(this.CheckboxIsRequired);
            this.tabPageRequest.Controls.Add(this.TextboxName);
            this.tabPageRequest.Controls.Add(this.ListviewRequestHeaders);
            this.tabPageRequest.Location = new System.Drawing.Point(4, 22);
            this.tabPageRequest.Name = "tabPageRequest";
            this.tabPageRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRequest.Size = new System.Drawing.Size(413, 341);
            this.tabPageRequest.TabIndex = 0;
            this.tabPageRequest.Text = "Request";
            this.tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonAdd.Location = new System.Drawing.Point(251, 305);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 14;
            this.ButtonAdd.Text = "Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // ButtonReset
            // 
            this.ButtonReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonReset.Location = new System.Drawing.Point(332, 305);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 13;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 250);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextboxDescription
            // 
            this.TextboxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxDescription.Location = new System.Drawing.Point(77, 247);
            this.TextboxDescription.Multiline = true;
            this.TextboxDescription.Name = "TextboxDescription";
            this.TextboxDescription.Size = new System.Drawing.Size(330, 49);
            this.TextboxDescription.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckboxAllowEmpty
            // 
            this.CheckboxAllowEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxAllowEmpty.AutoSize = true;
            this.CheckboxAllowEmpty.Location = new System.Drawing.Point(324, 224);
            this.CheckboxAllowEmpty.Name = "CheckboxAllowEmpty";
            this.CheckboxAllowEmpty.Size = new System.Drawing.Size(83, 17);
            this.CheckboxAllowEmpty.TabIndex = 9;
            this.CheckboxAllowEmpty.Text = "Allow Empty";
            this.CheckboxAllowEmpty.UseVisualStyleBackColor = true;
            // 
            // CheckboxIsRequired
            // 
            this.CheckboxIsRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxIsRequired.AutoSize = true;
            this.CheckboxIsRequired.Location = new System.Drawing.Point(249, 224);
            this.CheckboxIsRequired.Name = "CheckboxIsRequired";
            this.CheckboxIsRequired.Size = new System.Drawing.Size(69, 17);
            this.CheckboxIsRequired.TabIndex = 8;
            this.CheckboxIsRequired.Text = "Required";
            this.CheckboxIsRequired.UseVisualStyleBackColor = true;
            // 
            // TextboxName
            // 
            this.TextboxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxName.Location = new System.Drawing.Point(77, 221);
            this.TextboxName.Name = "TextboxName";
            this.TextboxName.Size = new System.Drawing.Size(163, 20);
            this.TextboxName.TabIndex = 7;
            // 
            // ListviewRequestHeaders
            // 
            this.ListviewRequestHeaders.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListviewRequestHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListviewRequestHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnName,
            this.columnRequired,
            this.columnEmpty,
            this.columnDescription});
            this.ListviewRequestHeaders.FullRowSelect = true;
            this.ListviewRequestHeaders.HideSelection = false;
            this.ListviewRequestHeaders.Location = new System.Drawing.Point(6, 6);
            this.ListviewRequestHeaders.MultiSelect = false;
            this.ListviewRequestHeaders.Name = "ListviewRequestHeaders";
            this.ListviewRequestHeaders.OwnerDraw = true;
            this.ListviewRequestHeaders.ShowItemToolTips = true;
            this.ListviewRequestHeaders.Size = new System.Drawing.Size(401, 204);
            this.ListviewRequestHeaders.SmallImageList = this.ControlImages;
            this.ListviewRequestHeaders.TabIndex = 6;
            this.ListviewRequestHeaders.UseCompatibleStateImageBehavior = false;
            this.ListviewRequestHeaders.View = System.Windows.Forms.View.Details;
            this.ListviewRequestHeaders.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListviewRequestHeaders_DrawColumnHeader);
            this.ListviewRequestHeaders.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListviewRequestHeaders_DrawSubItem);
            // 
            // columnRequired
            // 
            this.columnRequired.Text = "Required";
            // 
            // columnEmpty
            // 
            this.columnEmpty.Text = "Empty";
            // 
            // tabResponseCodes
            // 
            this.tabResponseCodes.Controls.Add(this.tabPageRequest);
            this.tabResponseCodes.Controls.Add(this.tabPageResponse);
            this.tabResponseCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResponseCodes.Location = new System.Drawing.Point(0, 0);
            this.tabResponseCodes.Name = "tabResponseCodes";
            this.tabResponseCodes.SelectedIndex = 0;
            this.tabResponseCodes.Size = new System.Drawing.Size(421, 367);
            this.tabResponseCodes.TabIndex = 6;
            // 
            // ControlImages
            // 
            this.ControlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ControlImages.ImageStream")));
            this.ControlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ControlImages.Images.SetKeyName(0, "item-unchecked.ico");
            this.ControlImages.Images.SetKeyName(1, "item-checked.ico");
            this.ControlImages.Images.SetKeyName(2, "header-request.ico");
            this.ControlImages.Images.SetKeyName(3, "header-response.ico");
            // 
            // HttpHeadersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabResponseCodes);
            this.Name = "HttpHeadersControl";
            this.Size = new System.Drawing.Size(421, 367);
            this.tabPageRequest.ResumeLayout(false);
            this.tabPageRequest.PerformLayout();
            this.tabResponseCodes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabPage tabPageResponse;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnName;
        private System.Windows.Forms.TabPage tabPageRequest;
        private System.Windows.Forms.ListView ListviewRequestHeaders;
        private System.Windows.Forms.TabControl tabResponseCodes;
        private System.Windows.Forms.ImageList ControlImages;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextboxDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckboxAllowEmpty;
        private System.Windows.Forms.CheckBox CheckboxIsRequired;
        private System.Windows.Forms.TextBox TextboxName;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.ColumnHeader columnRequired;
        private System.Windows.Forms.ColumnHeader columnEmpty;
    }
}
