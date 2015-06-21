namespace Client.JTB
{
    partial class PlatformcheckRoadSpeedAndRank
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
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbPicWait).BeginInit();
            base.SuspendLayout();
            this.pnlBtn.Controls.Add(this.pnlWait);
            this.pnlBtn.Location = new System.Drawing.Point(5, 177);
            this.pnlBtn.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            this.grpParam.Controls.Add(this.chkOpen);
            this.grpParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParam.Location = new System.Drawing.Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(363, 56);
            this.grpParam.TabIndex = 11;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数设置";
            this.chkOpen.AutoSize = true;
            this.chkOpen.Location = new System.Drawing.Point(122, 21);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(156, 16);
            this.chkOpen.TabIndex = 0;
            this.chkOpen.Text = "开启分道路等级超速报警";
            this.chkOpen.UseVisualStyleBackColor = true;
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(3, 3);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new System.Drawing.Size(129, 22);
            this.pnlWait.TabIndex = 16;
            this.pnlWait.Tag = "9999";
            this.pbPicWait.BackColor = System.Drawing.Color.Transparent;
            this.pbPicWait.Image = Client.Properties.Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(3, 3);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new System.Drawing.Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.Location = new System.Drawing.Point(22, 5);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new System.Drawing.Size(89, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在执行中....";
            this.lblWaitText.Visible = false;
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(373, 210);
            base.Controls.Add(this.grpParam);
            base.Name = "PlatformcheckRoadSpeedAndRank";
            this.Text = "PlatformcheckRoadSpeedAndRank";
            base.Controls.SetChildIndex(this.grpCar, 0);
            base.Controls.SetChildIndex(this.grpParam, 0);
            base.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.pbPicWait).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grpParam;

        private System.Windows.Forms.CheckBox chkOpen;

        private System.Windows.Forms.Panel pnlWait;

        private System.Windows.Forms.PictureBox pbPicWait;

        private System.Windows.Forms.Label lblWaitText;
    }
}
