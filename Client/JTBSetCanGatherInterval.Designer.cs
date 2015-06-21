namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBSetCanGatherInterval
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
            this.lblReportInterval = new Label();
            this.numReportInterval = new NumericUpDown();
            this.lblExplain1 = new Label();
            this.lblGatherInterval = new Label();
            this.numGatherInterval = new NumericUpDown();
            this.lblExplain2 = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numReportInterval.BeginInit();
            this.numGatherInterval.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 206);
            this.grpWatchProperty.Controls.Add(this.lblReportInterval);
            this.grpWatchProperty.Controls.Add(this.numReportInterval);
            this.grpWatchProperty.Controls.Add(this.lblExplain1);
            this.grpWatchProperty.Controls.Add(this.lblGatherInterval);
            this.grpWatchProperty.Controls.Add(this.numGatherInterval);
            this.grpWatchProperty.Controls.Add(this.lblExplain2);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 85);
            this.grpWatchProperty.TabIndex = 15;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.lblReportInterval.AutoSize = true;
            this.lblReportInterval.Location = new System.Drawing.Point(8, 26);
            this.lblReportInterval.Name = "lblReportInterval";
            this.lblReportInterval.Size = new Size(107, 12);
            this.lblReportInterval.TabIndex = 34;
            this.lblReportInterval.Text = "CAN数据上报间隔：";
            this.numReportInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numReportInterval.Location = new System.Drawing.Point(122, 20);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numReportInterval.Maximum = new decimal(bits);
            this.numReportInterval.Name = "numReportInterval";
            this.numReportInterval.Size = new Size(161, 21);
            this.numReportInterval.TabIndex = 32;
            int[] numArray2 = new int[4];
            numArray2[0] = 30;
            this.numReportInterval.Value = new decimal(numArray2);
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(289, 25);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(17, 12);
            this.lblExplain1.TabIndex = 37;
            this.lblExplain1.Tag = "；";
            this.lblExplain1.Text = "秒";
            this.lblGatherInterval.AutoSize = true;
            this.lblGatherInterval.Location = new System.Drawing.Point(8, 55);
            this.lblGatherInterval.Name = "lblGatherInterval";
            this.lblGatherInterval.Size = new Size(107, 12);
            this.lblGatherInterval.TabIndex = 35;
            this.lblGatherInterval.Text = "CAN数据采样间隔：";
            this.numGatherInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numGatherInterval.Location = new System.Drawing.Point(122, 51);
            int[] numArray3 = new int[4];
            numArray3[0] = 65535;
            this.numGatherInterval.Maximum = new decimal(numArray3);
            this.numGatherInterval.Name = "numGatherInterval";
            this.numGatherInterval.Size = new Size(161, 21);
            this.numGatherInterval.TabIndex = 33;
            int[] numArray4 = new int[4];
            numArray4[0] = 30;
            this.numGatherInterval.Value = new decimal(numArray4);
            this.lblExplain2.AutoSize = true;
            this.lblExplain2.Location = new System.Drawing.Point(289, 55);
            this.lblExplain2.Name = "lblExplain2";
            this.lblExplain2.Size = new Size(17, 12);
            this.lblExplain2.TabIndex = 36;
            this.lblExplain2.Tag = "；";
            this.lblExplain2.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 239);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetCanGatherInterval";
            this.Text = "JTBSetCanGatherInterval";
            base.Load += new EventHandler(this.JTBSetCanGatherInterval_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numReportInterval.EndInit();
            this.numGatherInterval.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblExplain1;
        private Label lblExplain2;
        private Label lblGatherInterval;
        private Label lblReportInterval;
        private NumericUpDown numGatherInterval;
        private NumericUpDown numReportInterval;
    }
}