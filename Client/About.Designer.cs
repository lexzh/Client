namespace Client
{
    partial class About
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
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblWelconme = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVersion.Location = new System.Drawing.Point(352, 9);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(270, 23);
            this.lblVersion.TabIndex = 12;
            this.lblVersion.Text = "V1.0";
            this.lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompany
            // 
            this.lblCompany.BackColor = System.Drawing.Color.Transparent;
            this.lblCompany.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompany.Location = new System.Drawing.Point(372, 235);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(273, 41);
            this.lblCompany.TabIndex = 10;
            this.lblCompany.Tag = "9999";
            this.lblCompany.Text = "重庆北斗导航应用技术股份有限公司";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWelconme
            // 
            this.lblWelconme.AutoSize = true;
            this.lblWelconme.BackColor = System.Drawing.Color.Transparent;
            this.lblWelconme.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblWelconme.Location = new System.Drawing.Point(35, 12);
            this.lblWelconme.Name = "lblWelconme";
            this.lblWelconme.Size = new System.Drawing.Size(72, 16);
            this.lblWelconme.TabIndex = 13;
            this.lblWelconme.Text = "欢迎使用";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoSize = true;
            this.BackgroundImage = global::Client.Properties.Resources.login;
            this.ClientSize = new System.Drawing.Size(700, 350);
            this.Controls.Add(this.lblWelconme);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblCompany);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "About";
            this.Click += new System.EventHandler(this.About1_Click);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.About1_KeyPress);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblWelconme;
    }
}
