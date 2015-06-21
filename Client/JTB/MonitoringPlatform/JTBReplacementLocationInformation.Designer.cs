namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBReplacementLocationInformation
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
            this.grpWatchProperty = new GroupBox();
            this.dtpEndTime = new DateTimePicker();
            this.lblEndTime = new Label();
            this.dtpStartTime = new DateTimePicker();
            this.lblStartTime = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 188);
            this.grpWatchProperty.Controls.Add(this.dtpEndTime);
            this.grpWatchProperty.Controls.Add(this.lblEndTime);
            this.grpWatchProperty.Controls.Add(this.dtpStartTime);
            this.grpWatchProperty.Controls.Add(this.lblStartTime);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 67);
            this.grpWatchProperty.TabIndex = 11;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(122, 40);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new Size(161, 21);
            this.dtpEndTime.TabIndex = 17;
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(50, 44);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 16;
            this.lblEndTime.Text = "结束时间：";
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(122, 13);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new Size(161, 21);
            this.dtpStartTime.TabIndex = 15;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(50, 17);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 14;
            this.lblStartTime.Text = "开始时间：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 221);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBReplacementLocationInformation";
            this.Text = "JTBReplacementLocationInformation";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblEndTime;
        private Label lblStartTime;
    }
}