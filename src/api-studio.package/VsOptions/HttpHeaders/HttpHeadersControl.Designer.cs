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
            this.ButtonResponseAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TextboxResponseDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CheckboxResponseAllowEmpty = new System.Windows.Forms.CheckBox();
            this.CheckboxResponseIsRequired = new System.Windows.Forms.CheckBox();
            this.TextboxResponseName = new System.Windows.Forms.TextBox();
            this.ListviewResponseHeaders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ControlImages = new System.Windows.Forms.ImageList(this.components);
            this.columnDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRequest = new System.Windows.Forms.TabPage();
            this.ButtonRequestAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TextboxRequestDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CheckboxRequestAllowEmpty = new System.Windows.Forms.CheckBox();
            this.CheckboxRequestIsRequired = new System.Windows.Forms.CheckBox();
            this.TextboxRequestName = new System.Windows.Forms.TextBox();
            this.ListviewRequestHeaders = new System.Windows.Forms.ListView();
            this.columnRequired = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnEmpty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabResponseCodes = new System.Windows.Forms.TabControl();
            this.tabPageResponse.SuspendLayout();
            this.tabPageRequest.SuspendLayout();
            this.tabResponseCodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageResponse
            // 
            this.tabPageResponse.Controls.Add(this.ButtonResponseAdd);
            this.tabPageResponse.Controls.Add(this.label3);
            this.tabPageResponse.Controls.Add(this.TextboxResponseDescription);
            this.tabPageResponse.Controls.Add(this.label4);
            this.tabPageResponse.Controls.Add(this.CheckboxResponseAllowEmpty);
            this.tabPageResponse.Controls.Add(this.CheckboxResponseIsRequired);
            this.tabPageResponse.Controls.Add(this.TextboxResponseName);
            this.tabPageResponse.Controls.Add(this.ListviewResponseHeaders);
            this.tabPageResponse.Location = new System.Drawing.Point(4, 22);
            this.tabPageResponse.Name = "tabPageResponse";
            this.tabPageResponse.Size = new System.Drawing.Size(407, 346);
            this.tabPageResponse.TabIndex = 3;
            this.tabPageResponse.Text = "Response";
            this.tabPageResponse.UseVisualStyleBackColor = true;
            // 
            // ButtonResponseAdd
            // 
            this.ButtonResponseAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonResponseAdd.Location = new System.Drawing.Point(326, 314);
            this.ButtonResponseAdd.Name = "ButtonResponseAdd";
            this.ButtonResponseAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonResponseAdd.TabIndex = 22;
            this.ButtonResponseAdd.Text = "Add";
            this.ButtonResponseAdd.UseVisualStyleBackColor = true;
            this.ButtonResponseAdd.Click += new System.EventHandler(this.ButtonResponseAdd_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Description:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextboxResponseDescription
            // 
            this.TextboxResponseDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxResponseDescription.Location = new System.Drawing.Point(77, 255);
            this.TextboxResponseDescription.Multiline = true;
            this.TextboxResponseDescription.Name = "TextboxResponseDescription";
            this.TextboxResponseDescription.Size = new System.Drawing.Size(324, 49);
            this.TextboxResponseDescription.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 233);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckboxResponseAllowEmpty
            // 
            this.CheckboxResponseAllowEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxResponseAllowEmpty.AutoSize = true;
            this.CheckboxResponseAllowEmpty.Location = new System.Drawing.Point(318, 232);
            this.CheckboxResponseAllowEmpty.Name = "CheckboxResponseAllowEmpty";
            this.CheckboxResponseAllowEmpty.Size = new System.Drawing.Size(83, 17);
            this.CheckboxResponseAllowEmpty.TabIndex = 18;
            this.CheckboxResponseAllowEmpty.Text = "Allow Empty";
            this.CheckboxResponseAllowEmpty.UseVisualStyleBackColor = true;
            // 
            // CheckboxResponseIsRequired
            // 
            this.CheckboxResponseIsRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxResponseIsRequired.AutoSize = true;
            this.CheckboxResponseIsRequired.Location = new System.Drawing.Point(243, 232);
            this.CheckboxResponseIsRequired.Name = "CheckboxResponseIsRequired";
            this.CheckboxResponseIsRequired.Size = new System.Drawing.Size(69, 17);
            this.CheckboxResponseIsRequired.TabIndex = 17;
            this.CheckboxResponseIsRequired.Text = "Required";
            this.CheckboxResponseIsRequired.UseVisualStyleBackColor = true;
            // 
            // TextboxResponseName
            // 
            this.TextboxResponseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxResponseName.Location = new System.Drawing.Point(77, 229);
            this.TextboxResponseName.Name = "TextboxResponseName";
            this.TextboxResponseName.Size = new System.Drawing.Size(157, 20);
            this.TextboxResponseName.TabIndex = 16;
            // 
            // ListviewResponseHeaders
            // 
            this.ListviewResponseHeaders.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.ListviewResponseHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListviewResponseHeaders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.ListviewResponseHeaders.FullRowSelect = true;
            this.ListviewResponseHeaders.HideSelection = false;
            this.ListviewResponseHeaders.Location = new System.Drawing.Point(6, 9);
            this.ListviewResponseHeaders.MultiSelect = false;
            this.ListviewResponseHeaders.Name = "ListviewResponseHeaders";
            this.ListviewResponseHeaders.OwnerDraw = true;
            this.ListviewResponseHeaders.ShowItemToolTips = true;
            this.ListviewResponseHeaders.Size = new System.Drawing.Size(395, 209);
            this.ListviewResponseHeaders.SmallImageList = this.ControlImages;
            this.ListviewResponseHeaders.TabIndex = 15;
            this.ListviewResponseHeaders.UseCompatibleStateImageBehavior = false;
            this.ListviewResponseHeaders.View = System.Windows.Forms.View.Details;
            this.ListviewResponseHeaders.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListviewResponseHeaders_DrawColumnHeader);
            this.ListviewResponseHeaders.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListviewResponseHeaders_DrawSubItem);
            this.ListviewResponseHeaders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListviewResponseHeaders_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Required";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Empty";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 169;
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
            this.tabPageRequest.Controls.Add(this.ButtonRequestAdd);
            this.tabPageRequest.Controls.Add(this.label2);
            this.tabPageRequest.Controls.Add(this.TextboxRequestDescription);
            this.tabPageRequest.Controls.Add(this.label1);
            this.tabPageRequest.Controls.Add(this.CheckboxRequestAllowEmpty);
            this.tabPageRequest.Controls.Add(this.CheckboxRequestIsRequired);
            this.tabPageRequest.Controls.Add(this.TextboxRequestName);
            this.tabPageRequest.Controls.Add(this.ListviewRequestHeaders);
            this.tabPageRequest.Location = new System.Drawing.Point(4, 22);
            this.tabPageRequest.Name = "tabPageRequest";
            this.tabPageRequest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRequest.Size = new System.Drawing.Size(407, 346);
            this.tabPageRequest.TabIndex = 0;
            this.tabPageRequest.Text = "Request";
            this.tabPageRequest.UseVisualStyleBackColor = true;
            // 
            // ButtonRequestAdd
            // 
            this.ButtonRequestAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRequestAdd.Location = new System.Drawing.Point(326, 311);
            this.ButtonRequestAdd.Name = "ButtonRequestAdd";
            this.ButtonRequestAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonRequestAdd.TabIndex = 14;
            this.ButtonRequestAdd.Text = "Add";
            this.ButtonRequestAdd.UseVisualStyleBackColor = true;
            this.ButtonRequestAdd.Click += new System.EventHandler(this.ButtonRequestAdd_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Description:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TextboxRequestDescription
            // 
            this.TextboxRequestDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxRequestDescription.Location = new System.Drawing.Point(77, 252);
            this.TextboxRequestDescription.Multiline = true;
            this.TextboxRequestDescription.Name = "TextboxRequestDescription";
            this.TextboxRequestDescription.Size = new System.Drawing.Size(324, 49);
            this.TextboxRequestDescription.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 230);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CheckboxRequestAllowEmpty
            // 
            this.CheckboxRequestAllowEmpty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxRequestAllowEmpty.AutoSize = true;
            this.CheckboxRequestAllowEmpty.Location = new System.Drawing.Point(318, 229);
            this.CheckboxRequestAllowEmpty.Name = "CheckboxRequestAllowEmpty";
            this.CheckboxRequestAllowEmpty.Size = new System.Drawing.Size(83, 17);
            this.CheckboxRequestAllowEmpty.TabIndex = 9;
            this.CheckboxRequestAllowEmpty.Text = "Allow Empty";
            this.CheckboxRequestAllowEmpty.UseVisualStyleBackColor = true;
            // 
            // CheckboxRequestIsRequired
            // 
            this.CheckboxRequestIsRequired.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckboxRequestIsRequired.AutoSize = true;
            this.CheckboxRequestIsRequired.Location = new System.Drawing.Point(243, 229);
            this.CheckboxRequestIsRequired.Name = "CheckboxRequestIsRequired";
            this.CheckboxRequestIsRequired.Size = new System.Drawing.Size(69, 17);
            this.CheckboxRequestIsRequired.TabIndex = 8;
            this.CheckboxRequestIsRequired.Text = "Required";
            this.CheckboxRequestIsRequired.UseVisualStyleBackColor = true;
            // 
            // TextboxRequestName
            // 
            this.TextboxRequestName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextboxRequestName.Location = new System.Drawing.Point(77, 226);
            this.TextboxRequestName.Name = "TextboxRequestName";
            this.TextboxRequestName.Size = new System.Drawing.Size(157, 20);
            this.TextboxRequestName.TabIndex = 7;
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
            this.ListviewRequestHeaders.Size = new System.Drawing.Size(395, 209);
            this.ListviewRequestHeaders.SmallImageList = this.ControlImages;
            this.ListviewRequestHeaders.TabIndex = 6;
            this.ListviewRequestHeaders.UseCompatibleStateImageBehavior = false;
            this.ListviewRequestHeaders.View = System.Windows.Forms.View.Details;
            this.ListviewRequestHeaders.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ListviewRequestHeaders_DrawColumnHeader);
            this.ListviewRequestHeaders.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ListviewRequestHeaders_DrawSubItem);
            this.ListviewRequestHeaders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListviewRequestHeaders_KeyDown);
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
            this.tabResponseCodes.Size = new System.Drawing.Size(415, 372);
            this.tabResponseCodes.TabIndex = 6;
            // 
            // HttpHeadersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabResponseCodes);
            this.Name = "HttpHeadersControl";
            this.Size = new System.Drawing.Size(415, 372);
            this.tabPageResponse.ResumeLayout(false);
            this.tabPageResponse.PerformLayout();
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
        private System.Windows.Forms.TextBox TextboxRequestDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CheckboxRequestAllowEmpty;
        private System.Windows.Forms.CheckBox CheckboxRequestIsRequired;
        private System.Windows.Forms.TextBox TextboxRequestName;
        private System.Windows.Forms.Button ButtonRequestAdd;
        private System.Windows.Forms.ColumnHeader columnRequired;
        private System.Windows.Forms.ColumnHeader columnEmpty;
        private System.Windows.Forms.Button ButtonResponseAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextboxResponseDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox CheckboxResponseAllowEmpty;
        private System.Windows.Forms.CheckBox CheckboxResponseIsRequired;
        private System.Windows.Forms.TextBox TextboxResponseName;
        private System.Windows.Forms.ListView ListviewResponseHeaders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
