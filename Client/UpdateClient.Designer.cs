namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    partial class UpdateClient
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.pbProgress = new ProgressBar();
            this.lblProgressText = new Label();
            this.btnCancelDown = new Button();
            this.groupBox1 = new GroupBox();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.pbProgress.Location = new Point(24, 54);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new Size(242, 24);
            this.pbProgress.TabIndex = 3;
            this.lblProgressText.AutoSize = true;
            this.lblProgressText.Location = new Point(22, 33);
            this.lblProgressText.Name = "lblProgressText";
            this.lblProgressText.Size = new Size(167, 12);
            this.lblProgressText.TabIndex = 2;
            this.lblProgressText.Text = "正在检测升级文件，请稍候...";
            this.btnCancelDown.Location = new Point(230, 102);
            this.btnCancelDown.Name = "btnCancelDown";
            this.btnCancelDown.Size = new Size(75, 23);
            this.btnCancelDown.TabIndex = 4;
            this.btnCancelDown.Text = "取消";
            this.btnCancelDown.UseVisualStyleBackColor = true;
            this.btnCancelDown.Click += new EventHandler(this.btnCancelDown_Click);
            this.groupBox1.Controls.Add(this.lblProgressText);
            this.groupBox1.Controls.Add(this.pbProgress);
            this.groupBox1.Location = new Point(0, -5);
            this.groupBox1.Margin = new Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(309, 103);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(309, 133);
            base.Controls.Add(this.groupBox1);
            base.Controls.Add(this.btnCancelDown);
            base.Name = "UpdateClient";
            base.Padding = new Padding(0, 0, 0, 5);
            base.ShowInTaskbar = true;
            this.Text = "GPS安全服务系统 升级程序";
            base.Load += new EventHandler(this.UpdateClient_Load);
            base.FormClosing += new FormClosingEventHandler(this.UpdateClient_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private bool bCancelDown;
        private Button btnCancelDown;
        private GroupBox groupBox1;
        private int iValue;
        private Label lblProgressText;
        private DShowLable myShowLable;
        private ProgressBar pbProgress;
        private SetControlText settext;
        private bool UpdateDownOk;
        private bool UpdateErr;
        private int UpdateState;
    }
}