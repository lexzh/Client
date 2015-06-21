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

    partial class JTBTerminalHeartInterval
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
            this.lblFullReport = new Label();
            this.numFullReport = new NumericUpDown();
            this.lblFullSecond = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numFullReport.BeginInit();
            base.SuspendLayout();
            base.grpCar.Size = new Size(366, 116);
            base.pnlBtn.Location = new System.Drawing.Point(5, 169);
            base.pnlBtn.Size = new Size(366, 28);
            this.grpWatchProperty.Controls.Add(this.lblFullReport);
            this.grpWatchProperty.Controls.Add(this.numFullReport);
            this.grpWatchProperty.Controls.Add(this.lblFullSecond);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(366, 48);
            this.grpWatchProperty.TabIndex = 9;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.lblFullReport.AutoSize = true;
            this.lblFullReport.Location = new System.Drawing.Point(47, 23);
            this.lblFullReport.Name = "lblFullReport";
            this.lblFullReport.Size = new Size(113, 12);
            this.lblFullReport.TabIndex = 14;
            this.lblFullReport.Text = "终端心跳发送间隔：";
            this.numFullReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numFullReport.Location = new System.Drawing.Point(161, 19);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numFullReport.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 10;
            this.numFullReport.Minimum = new decimal(numArray2);
            this.numFullReport.Name = "numFullReport";
            this.numFullReport.Size = new Size(96, 21);
            this.numFullReport.TabIndex = 13;
            int[] numArray3 = new int[4];
            numArray3[0] = 60;
            this.numFullReport.Value = new decimal(numArray3);
            this.lblFullSecond.AutoSize = true;
            this.lblFullSecond.Location = new System.Drawing.Point(263, 23);
            this.lblFullSecond.Name = "lblFullSecond";
            this.lblFullSecond.Size = new Size(17, 12);
            this.lblFullSecond.TabIndex = 15;
            this.lblFullSecond.Tag = "；";
            this.lblFullSecond.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(376, 202);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBTerminalHeartInterval";
            this.Text = "JTBTerminalHeartInterval";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numFullReport.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblFullReport;
        private Label lblFullSecond;
        private NumericUpDown numFullReport;
    }
}