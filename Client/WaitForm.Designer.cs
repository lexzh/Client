namespace Client
{
    partial class WaitForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitForm));
            this.pnlWait = new System.Windows.Forms.Panel();
            this.lblCompany = new System.Windows.Forms.Label();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblText = new System.Windows.Forms.Label();
            this.pbPic = new System.Windows.Forms.PictureBox();
            this.pnlWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlWait
            // 
            this.pnlWait.AutoSize = true;
            this.pnlWait.Controls.Add(this.lblCompany);
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblText);
            this.pnlWait.Controls.Add(this.pbPic);
            this.pnlWait.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWait.Location = new System.Drawing.Point(0, 0);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new System.Drawing.Size(251, 42);
            this.pnlWait.TabIndex = 1;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCompany.Location = new System.Drawing.Point(184, 16);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(0, 16);
            this.lblCompany.TabIndex = 9;
            this.lblCompany.Tag = "9999";
            // 
            // pbPicWait
            // 
            this.pbPicWait.BackColor = System.Drawing.Color.CadetBlue;
            this.pbPicWait.Image = global::Client.Properties.Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(20, 13);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new System.Drawing.Size(16, 16);
            this.pbPicWait.TabIndex = 8;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblText.Location = new System.Drawing.Point(42, 13);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(49, 13);
            this.lblText.TabIndex = 7;
            this.lblText.Tag = "";
            this.lblText.Text = "label1";
            // 
            // pbPic
            // 
            this.pbPic.BackColor = System.Drawing.Color.CadetBlue;
            this.pbPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPic.Image = global::Client.Properties.Resources.loading;
            this.pbPic.InitialImage = null;
            this.pbPic.Location = new System.Drawing.Point(0, 0);
            this.pbPic.Name = "pbPic";
            this.pbPic.Size = new System.Drawing.Size(251, 42);
            this.pbPic.TabIndex = 5;
            this.pbPic.TabStop = false;
            this.pbPic.Tag = "9999";
            this.pbPic.Visible = false;
            // 
            // WaitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(251, 42);
            this.Controls.Add(this.pnlWait);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WaitForm";
            this.ShowIcon = true;
            this.Text = "GPS监控工作站 StarGis版 Beta1";
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPic;
        private System.Windows.Forms.PictureBox pbPicWait;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Panel pnlWait;
    }
}
