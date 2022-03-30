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
            this.ListHeaders = new System.Windows.Forms.ListView();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonRemove = new System.Windows.Forms.Button();
            this.LabelName = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkRequired = new System.Windows.Forms.CheckBox();
            this.radioRequest = new System.Windows.Forms.RadioButton();
            this.radioResponse = new System.Windows.Forms.RadioButton();
            this.ButtonRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListHeaders
            // 
            this.ListHeaders.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListHeaders.HideSelection = false;
            this.ListHeaders.Location = new System.Drawing.Point(14, 14);
            this.ListHeaders.Name = "ListHeaders";
            this.ListHeaders.Size = new System.Drawing.Size(325, 128);
            this.ListHeaders.TabIndex = 0;
            this.ListHeaders.UseCompatibleStateImageBehavior = false;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(14, 148);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(80, 25);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "&Add";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            // 
            // ButtonRemove
            // 
            this.ButtonRemove.Location = new System.Drawing.Point(100, 148);
            this.ButtonRemove.Name = "ButtonRemove";
            this.ButtonRemove.Size = new System.Drawing.Size(80, 25);
            this.ButtonRemove.TabIndex = 2;
            this.ButtonRemove.Text = "R&emove";
            this.ButtonRemove.UseVisualStyleBackColor = true;
            // 
            // LabelName
            // 
            this.LabelName.AutoSize = true;
            this.LabelName.Location = new System.Drawing.Point(11, 191);
            this.LabelName.Name = "LabelName";
            this.LabelName.Size = new System.Drawing.Size(35, 13);
            this.LabelName.TabIndex = 3;
            this.LabelName.Text = "Name";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(77, 188);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(262, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(77, 237);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(262, 140);
            this.textBox2.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 237);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Description";
            // 
            // checkRequired
            // 
            this.checkRequired.AutoSize = true;
            this.checkRequired.Location = new System.Drawing.Point(77, 214);
            this.checkRequired.Name = "checkRequired";
            this.checkRequired.Size = new System.Drawing.Size(69, 17);
            this.checkRequired.TabIndex = 7;
            this.checkRequired.Text = "Required";
            this.checkRequired.UseVisualStyleBackColor = true;
            // 
            // radioRequest
            // 
            this.radioRequest.AutoSize = true;
            this.radioRequest.Location = new System.Drawing.Point(155, 213);
            this.radioRequest.Name = "radioRequest";
            this.radioRequest.Size = new System.Drawing.Size(65, 17);
            this.radioRequest.TabIndex = 8;
            this.radioRequest.TabStop = true;
            this.radioRequest.Text = "Request";
            this.radioRequest.UseVisualStyleBackColor = true;
            // 
            // radioResponse
            // 
            this.radioResponse.AutoSize = true;
            this.radioResponse.Location = new System.Drawing.Point(226, 213);
            this.radioResponse.Name = "radioResponse";
            this.radioResponse.Size = new System.Drawing.Size(73, 17);
            this.radioResponse.TabIndex = 9;
            this.radioResponse.TabStop = true;
            this.radioResponse.Text = "Response";
            this.radioResponse.UseVisualStyleBackColor = true;
            // 
            // ButtonRestore
            // 
            this.ButtonRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonRestore.Location = new System.Drawing.Point(259, 148);
            this.ButtonRestore.Name = "ButtonRestore";
            this.ButtonRestore.Size = new System.Drawing.Size(80, 25);
            this.ButtonRestore.TabIndex = 10;
            this.ButtonRestore.Text = "&Restore";
            this.ButtonRestore.UseVisualStyleBackColor = true;
            // 
            // HttpHeadersControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ButtonRestore);
            this.Controls.Add(this.radioResponse);
            this.Controls.Add(this.radioRequest);
            this.Controls.Add(this.checkRequired);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.LabelName);
            this.Controls.Add(this.ButtonRemove);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.ListHeaders);
            this.Name = "HttpHeadersControl";
            this.Size = new System.Drawing.Size(355, 392);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ListHeaders;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonRemove;
        private System.Windows.Forms.Label LabelName;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkRequired;
        private System.Windows.Forms.RadioButton radioRequest;
        private System.Windows.Forms.RadioButton radioResponse;
        private System.Windows.Forms.Button ButtonRestore;
    }
}
