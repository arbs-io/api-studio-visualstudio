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
            this.ControlImages = new System.Windows.Forms.ImageList(this.components);
            this.tabResponseCodes = new System.Windows.Forms.TabControl();
            this.tabPageInformation = new System.Windows.Forms.TabPage();
            this.lsvResponseCodesInformation = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageRedirection = new System.Windows.Forms.TabPage();
            this.lsvResponseCodesRedirection = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageClientError = new System.Windows.Forms.TabPage();
            this.lsvResponseCodesClientError = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageServerError = new System.Windows.Forms.TabPage();
            this.lsvResponseCodesServerError = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPageSuccess = new System.Windows.Forms.TabPage();
            this.SuccessPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tabResponseCodes.SuspendLayout();
            this.tabPageInformation.SuspendLayout();
            this.tabPageRedirection.SuspendLayout();
            this.tabPageClientError.SuspendLayout();
            this.tabPageServerError.SuspendLayout();
            this.tabPageSuccess.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlImages
            // 
            this.ControlImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ControlImages.ImageStream")));
            this.ControlImages.TransparentColor = System.Drawing.Color.Transparent;
            this.ControlImages.Images.SetKeyName(0, "item-unchecked.ico");
            this.ControlImages.Images.SetKeyName(1, "item-checked.ico");
            // 
            // tabResponseCodes
            // 
            this.tabResponseCodes.Controls.Add(this.tabPageInformation);
            this.tabResponseCodes.Controls.Add(this.tabPageSuccess);
            this.tabResponseCodes.Controls.Add(this.tabPageRedirection);
            this.tabResponseCodes.Controls.Add(this.tabPageClientError);
            this.tabResponseCodes.Controls.Add(this.tabPageServerError);
            this.tabResponseCodes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabResponseCodes.Location = new System.Drawing.Point(0, 0);
            this.tabResponseCodes.Name = "tabResponseCodes";
            this.tabResponseCodes.SelectedIndex = 0;
            this.tabResponseCodes.Size = new System.Drawing.Size(371, 260);
            this.tabResponseCodes.TabIndex = 5;
            // 
            // tabPageInformation
            // 
            this.tabPageInformation.Controls.Add(this.lsvResponseCodesInformation);
            this.tabPageInformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageInformation.Name = "tabPageInformation";
            this.tabPageInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInformation.Size = new System.Drawing.Size(363, 234);
            this.tabPageInformation.TabIndex = 0;
            this.tabPageInformation.Text = "Information";
            this.tabPageInformation.UseVisualStyleBackColor = true;
            // 
            // lsvResponseCodesInformation
            // 
            this.lsvResponseCodesInformation.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvResponseCodesInformation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.lsvResponseCodesInformation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResponseCodesInformation.FullRowSelect = true;
            this.lsvResponseCodesInformation.HideSelection = false;
            this.lsvResponseCodesInformation.Location = new System.Drawing.Point(3, 3);
            this.lsvResponseCodesInformation.MultiSelect = false;
            this.lsvResponseCodesInformation.Name = "lsvResponseCodesInformation";
            this.lsvResponseCodesInformation.ShowItemToolTips = true;
            this.lsvResponseCodesInformation.Size = new System.Drawing.Size(357, 228);
            this.lsvResponseCodesInformation.TabIndex = 6;
            this.lsvResponseCodesInformation.UseCompatibleStateImageBehavior = false;
            this.lsvResponseCodesInformation.View = System.Windows.Forms.View.Details;
            this.lsvResponseCodesInformation.Click += new System.EventHandler(this.ResponseCodesInformation_Click);
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Code";
            this.columnHeader7.Width = 50;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Description";
            this.columnHeader8.Width = 268;
            // 
            // tabPageRedirection
            // 
            this.tabPageRedirection.Controls.Add(this.lsvResponseCodesRedirection);
            this.tabPageRedirection.Location = new System.Drawing.Point(4, 22);
            this.tabPageRedirection.Name = "tabPageRedirection";
            this.tabPageRedirection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRedirection.Size = new System.Drawing.Size(363, 234);
            this.tabPageRedirection.TabIndex = 1;
            this.tabPageRedirection.Text = "Redirection";
            this.tabPageRedirection.UseVisualStyleBackColor = true;
            // 
            // lsvResponseCodesRedirection
            // 
            this.lsvResponseCodesRedirection.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvResponseCodesRedirection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvResponseCodesRedirection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResponseCodesRedirection.FullRowSelect = true;
            this.lsvResponseCodesRedirection.HideSelection = false;
            this.lsvResponseCodesRedirection.Location = new System.Drawing.Point(3, 3);
            this.lsvResponseCodesRedirection.MultiSelect = false;
            this.lsvResponseCodesRedirection.Name = "lsvResponseCodesRedirection";
            this.lsvResponseCodesRedirection.ShowItemToolTips = true;
            this.lsvResponseCodesRedirection.Size = new System.Drawing.Size(357, 228);
            this.lsvResponseCodesRedirection.TabIndex = 5;
            this.lsvResponseCodesRedirection.UseCompatibleStateImageBehavior = false;
            this.lsvResponseCodesRedirection.View = System.Windows.Forms.View.Details;
            this.lsvResponseCodesRedirection.Click += new System.EventHandler(this.ResponseCodesRedirection_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Description";
            this.columnHeader2.Width = 268;
            // 
            // tabPageClientError
            // 
            this.tabPageClientError.Controls.Add(this.lsvResponseCodesClientError);
            this.tabPageClientError.Location = new System.Drawing.Point(4, 22);
            this.tabPageClientError.Name = "tabPageClientError";
            this.tabPageClientError.Size = new System.Drawing.Size(363, 234);
            this.tabPageClientError.TabIndex = 2;
            this.tabPageClientError.Text = "Client Error";
            this.tabPageClientError.UseVisualStyleBackColor = true;
            // 
            // lsvResponseCodesClientError
            // 
            this.lsvResponseCodesClientError.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvResponseCodesClientError.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvResponseCodesClientError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResponseCodesClientError.FullRowSelect = true;
            this.lsvResponseCodesClientError.HideSelection = false;
            this.lsvResponseCodesClientError.Location = new System.Drawing.Point(0, 0);
            this.lsvResponseCodesClientError.MultiSelect = false;
            this.lsvResponseCodesClientError.Name = "lsvResponseCodesClientError";
            this.lsvResponseCodesClientError.ShowItemToolTips = true;
            this.lsvResponseCodesClientError.Size = new System.Drawing.Size(363, 234);
            this.lsvResponseCodesClientError.TabIndex = 5;
            this.lsvResponseCodesClientError.UseCompatibleStateImageBehavior = false;
            this.lsvResponseCodesClientError.View = System.Windows.Forms.View.Details;
            this.lsvResponseCodesClientError.Click += new System.EventHandler(this.ResponseCodesClientError_Click);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Code";
            this.columnHeader3.Width = 50;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Description";
            this.columnHeader4.Width = 268;
            // 
            // tabPageServerError
            // 
            this.tabPageServerError.Controls.Add(this.lsvResponseCodesServerError);
            this.tabPageServerError.Location = new System.Drawing.Point(4, 22);
            this.tabPageServerError.Name = "tabPageServerError";
            this.tabPageServerError.Size = new System.Drawing.Size(363, 234);
            this.tabPageServerError.TabIndex = 3;
            this.tabPageServerError.Text = "Server Error";
            this.tabPageServerError.UseVisualStyleBackColor = true;
            // 
            // lsvResponseCodesServerError
            // 
            this.lsvResponseCodesServerError.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lsvResponseCodesServerError.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6});
            this.lsvResponseCodesServerError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvResponseCodesServerError.FullRowSelect = true;
            this.lsvResponseCodesServerError.HideSelection = false;
            this.lsvResponseCodesServerError.Location = new System.Drawing.Point(0, 0);
            this.lsvResponseCodesServerError.MultiSelect = false;
            this.lsvResponseCodesServerError.Name = "lsvResponseCodesServerError";
            this.lsvResponseCodesServerError.ShowItemToolTips = true;
            this.lsvResponseCodesServerError.Size = new System.Drawing.Size(363, 234);
            this.lsvResponseCodesServerError.TabIndex = 5;
            this.lsvResponseCodesServerError.UseCompatibleStateImageBehavior = false;
            this.lsvResponseCodesServerError.View = System.Windows.Forms.View.Details;
            this.lsvResponseCodesServerError.Click += new System.EventHandler(this.ResponseCodesServerError_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Code";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Description";
            this.columnHeader6.Width = 268;
            // 
            // tabPageSuccess
            // 
            this.tabPageSuccess.Controls.Add(this.SuccessPropertyGrid);
            this.tabPageSuccess.Location = new System.Drawing.Point(4, 22);
            this.tabPageSuccess.Name = "tabPageSuccess";
            this.tabPageSuccess.Size = new System.Drawing.Size(363, 234);
            this.tabPageSuccess.TabIndex = 4;
            this.tabPageSuccess.Text = "Success";
            this.tabPageSuccess.UseVisualStyleBackColor = true;
            // 
            // SuccessPropertyGrid
            // 
            this.SuccessPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuccessPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.SuccessPropertyGrid.Name = "SuccessPropertyGrid";
            this.SuccessPropertyGrid.Size = new System.Drawing.Size(363, 234);
            this.SuccessPropertyGrid.TabIndex = 0;
            // 
            // ResponseCodesGeneralControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabResponseCodes);
            this.Name = "ResponseCodesGeneralControl";
            this.Size = new System.Drawing.Size(371, 260);
            this.tabResponseCodes.ResumeLayout(false);
            this.tabPageInformation.ResumeLayout(false);
            this.tabPageRedirection.ResumeLayout(false);
            this.tabPageClientError.ResumeLayout(false);
            this.tabPageServerError.ResumeLayout(false);
            this.tabPageSuccess.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList ControlImages;
        private System.Windows.Forms.TabControl tabResponseCodes;
        private System.Windows.Forms.TabPage tabPageInformation;
        private System.Windows.Forms.TabPage tabPageRedirection;
        private System.Windows.Forms.TabPage tabPageClientError;
        private System.Windows.Forms.TabPage tabPageServerError;
        private System.Windows.Forms.ListView lsvResponseCodesRedirection;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView lsvResponseCodesClientError;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListView lsvResponseCodesServerError;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ListView lsvResponseCodesInformation;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TabPage tabPageSuccess;
        private System.Windows.Forms.PropertyGrid SuccessPropertyGrid;
    }
}
