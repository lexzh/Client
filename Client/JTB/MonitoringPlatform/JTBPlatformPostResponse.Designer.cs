namespace Client.JTB.MonitoringPlatform
{
    partial class JTBPlatformPostResponse
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.grpReponse = new System.Windows.Forms.GroupBox();
            this.txtPostResponse = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.grpContent = new System.Windows.Forms.GroupBox();
            this.txtPostContent = new System.Windows.Forms.RichTextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpReponse.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpReponse
            // 
            this.grpReponse.Controls.Add(this.txtPostResponse);
            this.grpReponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpReponse.Location = new System.Drawing.Point(0, 78);
            this.grpReponse.Name = "grpReponse";
            this.grpReponse.Size = new System.Drawing.Size(423, 175);
            this.grpReponse.TabIndex = 0;
            this.grpReponse.TabStop = false;
            this.grpReponse.Text = "应答内容";
            // 
            // txtPostResponse
            // 
            this.txtPostResponse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPostResponse.Location = new System.Drawing.Point(3, 17);
            this.txtPostResponse.MaxLength = 300;
            this.txtPostResponse.Multiline = true;
            this.txtPostResponse.Name = "txtPostResponse";
            this.txtPostResponse.Size = new System.Drawing.Size(417, 155);
            this.txtPostResponse.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 253);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(423, 37);
            this.panel1.TabIndex = 1;
            // 
            // grpContent
            // 
            this.grpContent.Controls.Add(this.txtPostContent);
            this.grpContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpContent.Location = new System.Drawing.Point(0, 0);
            this.grpContent.Name = "grpContent";
            this.grpContent.Size = new System.Drawing.Size(423, 78);
            this.grpContent.TabIndex = 2;
            this.grpContent.TabStop = false;
            this.grpContent.Text = "查岗内容";
            // 
            // txtPostContent
            // 
            this.txtPostContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPostContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPostContent.Enabled = false;
            this.txtPostContent.Location = new System.Drawing.Point(3, 17);
            this.txtPostContent.Name = "txtPostContent";
            this.txtPostContent.Size = new System.Drawing.Size(417, 58);
            this.txtPostContent.TabIndex = 0;
            this.txtPostContent.Text = "";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(336, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(255, 7);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // JTBPlatformPostResponse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 290);
            this.Controls.Add(this.grpReponse);
            this.Controls.Add(this.grpContent);
            this.Controls.Add(this.panel1);
            this.Name = "JTBPlatformPostResponse";
            this.Text = "JTBPlatformPostResponse";
            this.Load += new System.EventHandler(this.JTBPlatformPostResponse_Load);
            this.grpReponse.ResumeLayout(false);
            this.grpReponse.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grpContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpContent;
        private System.Windows.Forms.GroupBox grpReponse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox txtPostContent;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtPostResponse;
    }
}
