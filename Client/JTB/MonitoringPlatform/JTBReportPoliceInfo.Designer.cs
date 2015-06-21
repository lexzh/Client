namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class JTBReportPoliceInfo
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
            this.txtPostResponse = new TextBox();
            this.lblPostResponse = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 216);
            this.grpWatchProperty.Controls.Add(this.txtPostResponse);
            this.grpWatchProperty.Controls.Add(this.lblPostResponse);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 95);
            this.grpWatchProperty.TabIndex = 13;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.txtPostResponse.Location = new System.Drawing.Point(89, 14);
            this.txtPostResponse.MaxLength = 300;
            this.txtPostResponse.Multiline = true;
            this.txtPostResponse.Name = "txtPostResponse";
            this.txtPostResponse.Size = new Size(229, 75);
            this.txtPostResponse.TabIndex = 15;
            this.lblPostResponse.AutoSize = true;
            this.lblPostResponse.Location = new System.Drawing.Point(18, 17);
            this.lblPostResponse.Name = "lblPostResponse";
            this.lblPostResponse.Size = new Size(65, 12);
            this.lblPostResponse.TabIndex = 14;
            this.lblPostResponse.Text = "报警信息：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 249);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBReportPoliceInfo";
            this.Text = "JTBReportPoliceInfo";
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
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblPostResponse;
        private TextBox txtPostResponse;
    }
}