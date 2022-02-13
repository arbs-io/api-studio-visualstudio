namespace ApiStudioIO.VsOptions
{
    partial class ResponseCodesControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResponseCodesControl));
            this.chkShowSelected = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Label();
            this.lvwResponseCodes = new System.Windows.Forms.ListView();
            this.Code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ControlImages = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // chkShowSelected
            // 
            this.chkShowSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkShowSelected.AutoSize = true;
            this.chkShowSelected.Location = new System.Drawing.Point(261, 12);
            this.chkShowSelected.Name = "chkShowSelected";
            this.chkShowSelected.Size = new System.Drawing.Size(98, 17);
            this.chkShowSelected.TabIndex = 1;
            this.chkShowSelected.Text = "Show Selected";
            this.chkShowSelected.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(58, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(197, 20);
            this.textBox1.TabIndex = 2;
            // 
            // Search
            // 
            this.Search.AutoSize = true;
            this.Search.Location = new System.Drawing.Point(13, 14);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(44, 13);
            this.Search.TabIndex = 3;
            this.Search.Text = "Search:";
            // 
            // lvwResponseCodes
            // 
            this.lvwResponseCodes.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvwResponseCodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwResponseCodes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Code,
            this.Description});
            this.lvwResponseCodes.FullRowSelect = true;
            this.lvwResponseCodes.HideSelection = false;
            this.lvwResponseCodes.Location = new System.Drawing.Point(16, 36);
            this.lvwResponseCodes.MultiSelect = false;
            this.lvwResponseCodes.Name = "lvwResponseCodes";
            this.lvwResponseCodes.ShowItemToolTips = true;
            this.lvwResponseCodes.Size = new System.Drawing.Size(343, 209);
            this.lvwResponseCodes.TabIndex = 4;
            this.lvwResponseCodes.UseCompatibleStateImageBehavior = false;
            this.lvwResponseCodes.View = System.Windows.Forms.View.Details;
            this.lvwResponseCodes.Click += new System.EventHandler(this.lvwResponseCodes_Click);
            // 
            // Code
            // 
            this.Code.Text = "Code";
            this.Code.Width = 50;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 268;
            // 
            // ControlImages
            // 
            this.ControlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ControlImages.ImageStream")));
            this.ControlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ControlImages.Images.SetKeyName(0, "empty.ico");
            this.ControlImages.Images.SetKeyName(1, "plus_button.ico");
            // 
            // ResponseCodesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lvwResponseCodes);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.chkShowSelected);
            this.Name = "ResponseCodesControl";
            this.Size = new System.Drawing.Size(371, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkShowSelected;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label Search;
        private System.Windows.Forms.ListView lvwResponseCodes;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ImageList ControlImages;
    }
}
