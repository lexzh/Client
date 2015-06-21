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

    partial class JTBTemporaryPositionTracking
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
            this.lblTimeInterval = new Label();
            this.numTimeInterval = new NumericUpDown();
            this.lblExplain1 = new Label();
            this.lblTimePeriod = new Label();
            this.numTimePeriod = new NumericUpDown();
            this.lblExplain2 = new Label();
            this.label1 = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numTimeInterval.BeginInit();
            this.numTimePeriod.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 214);
            this.grpWatchProperty.Controls.Add(this.label1);
            this.grpWatchProperty.Controls.Add(this.lblTimeInterval);
            this.grpWatchProperty.Controls.Add(this.numTimeInterval);
            this.grpWatchProperty.Controls.Add(this.lblExplain1);
            this.grpWatchProperty.Controls.Add(this.lblTimePeriod);
            this.grpWatchProperty.Controls.Add(this.numTimePeriod);
            this.grpWatchProperty.Controls.Add(this.lblExplain2);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 93);
            this.grpWatchProperty.TabIndex = 11;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "临时位置跟踪参数";
            this.lblTimeInterval.AutoSize = true;
            this.lblTimeInterval.Location = new System.Drawing.Point(50, 22);
            this.lblTimeInterval.Name = "lblTimeInterval";
            this.lblTimeInterval.Size = new Size(65, 12);
            this.lblTimeInterval.TabIndex = 27;
            this.lblTimeInterval.Text = "时间间隔：";
            this.numTimeInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTimeInterval.Location = new System.Drawing.Point(122, 20);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numTimeInterval.Maximum = new decimal(bits);
            this.numTimeInterval.Name = "numTimeInterval";
            this.numTimeInterval.Size = new Size(161, 21);
            this.numTimeInterval.TabIndex = 25;
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(289, 25);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(17, 12);
            this.lblExplain1.TabIndex = 30;
            this.lblExplain1.Tag = "；";
            this.lblExplain1.Text = "秒";
            this.lblTimePeriod.AutoSize = true;
            this.lblTimePeriod.Location = new System.Drawing.Point(62, 62);
            this.lblTimePeriod.Name = "lblTimePeriod";
            this.lblTimePeriod.Size = new Size(53, 12);
            this.lblTimePeriod.TabIndex = 28;
            this.lblTimePeriod.Text = "有效期：";
            this.numTimePeriod.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTimePeriod.Location = new System.Drawing.Point(122, 60);
            int[] numArray2 = new int[4];
            numArray2[0] = 65535;
            this.numTimePeriod.Maximum = new decimal(numArray2);
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numTimePeriod.Minimum = new decimal(numArray3);
            this.numTimePeriod.Name = "numTimePeriod";
            this.numTimePeriod.Size = new Size(161, 21);
            this.numTimePeriod.TabIndex = 26;
            int[] numArray4 = new int[4];
            numArray4[0] = 1;
            this.numTimePeriod.Value = new decimal(numArray4);
            this.lblExplain2.AutoSize = true;
            this.lblExplain2.Location = new System.Drawing.Point(289, 64);
            this.lblExplain2.Name = "lblExplain2";
            this.lblExplain2.Size = new Size(17, 12);
            this.lblExplain2.TabIndex = 29;
            this.lblExplain2.Tag = "；";
            this.lblExplain2.Text = "秒";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 44);
            this.label1.Name = "label1";
            this.label1.Size = new Size(83, 12);
            this.label1.TabIndex = 31;
            this.label1.Tag = "；";
            this.label1.Text = "0表示停止跟踪";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 247);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBTemporaryPositionTracking";
            this.Text = "JTBTemporaryPositionTracking";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numTimeInterval.EndInit();
            this.numTimePeriod.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label label1;
        private Label lblExplain1;
        private Label lblExplain2;
        private Label lblTimeInterval;
        private Label lblTimePeriod;
        private NumericUpDown numTimeInterval;
        private NumericUpDown numTimePeriod;
    }
}