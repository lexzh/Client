namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBTravellingClock
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
            this.dtpRecodeRealtime = new DateTimePicker();
            this.lblRecodeRealtime = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 168);
            this.grpWatchProperty.Controls.Add(this.dtpRecodeRealtime);
            this.grpWatchProperty.Controls.Add(this.lblRecodeRealtime);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 47);
            this.grpWatchProperty.TabIndex = 15;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.dtpRecodeRealtime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpRecodeRealtime.Format = DateTimePickerFormat.Custom;
            this.dtpRecodeRealtime.Location = new System.Drawing.Point(122, 17);
            this.dtpRecodeRealtime.Name = "dtpRecodeRealtime";
            this.dtpRecodeRealtime.Size = new Size(161, 21);
            this.dtpRecodeRealtime.TabIndex = 28;
            this.lblRecodeRealtime.AutoSize = true;
            this.lblRecodeRealtime.Location = new System.Drawing.Point(19, 21);
            this.lblRecodeRealtime.Name = "lblRecodeRealtime";
            this.lblRecodeRealtime.Size = new Size(101, 12);
            this.lblRecodeRealtime.TabIndex = 27;
            this.lblRecodeRealtime.Text = "记录仪实时时钟：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 201);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBTravellingClock";
            this.Text = "JTBTravellingClock";
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
        private DateTimePicker dtpRecodeRealtime;
        private GroupBox grpWatchProperty;
        private Label lblRecodeRealtime;
    }
}