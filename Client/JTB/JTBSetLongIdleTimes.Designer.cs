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

    partial class JTBSetLongIdleTimes
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
            this.grpLongIdleTimes = new GroupBox();
            this.lblTimes = new Label();
            this.numTimes = new NumericUpDown();
            this.lblTimesContent = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpLongIdleTimes.SuspendLayout();
            this.numTimes.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 183);
            this.grpLongIdleTimes.Controls.Add(this.lblTimes);
            this.grpLongIdleTimes.Controls.Add(this.numTimes);
            this.grpLongIdleTimes.Controls.Add(this.lblTimesContent);
            this.grpLongIdleTimes.Dock = DockStyle.Top;
            this.grpLongIdleTimes.Location = new System.Drawing.Point(5, 121);
            this.grpLongIdleTimes.Name = "grpLongIdleTimes";
            this.grpLongIdleTimes.Size = new Size(363, 62);
            this.grpLongIdleTimes.TabIndex = 12;
            this.grpLongIdleTimes.TabStop = false;
            this.grpLongIdleTimes.Text = "设置超长怠速参数";
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(50, 27);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new Size(65, 12);
            this.lblTimes.TabIndex = 0;
            this.lblTimes.Text = "允许时长：";
            this.numTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTimes.Location = new System.Drawing.Point(122, 23);
            int[] bits = new int[4];
            bits[0] = 255;
            this.numTimes.Maximum = new decimal(bits);
            this.numTimes.Name = "numTimes";
            this.numTimes.Size = new Size(161, 21);
            this.numTimes.TabIndex = 1;
            int[] numArray2 = new int[4];
            numArray2[0] = 60;
            this.numTimes.Value = new decimal(numArray2);
            this.lblTimesContent.AutoSize = true;
            this.lblTimesContent.Location = new System.Drawing.Point(284, 27);
            this.lblTimesContent.Name = "lblTimesContent";
            this.lblTimesContent.Size = new Size(17, 12);
            this.lblTimesContent.TabIndex = 2;
            this.lblTimesContent.Tag = "；";
            this.lblTimesContent.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 216);
            base.Controls.Add(this.grpLongIdleTimes);
            base.Name = "JTBSetLongIdleTimes";
            this.Text = "JTBSetLongIdleTimes";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpLongIdleTimes, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpLongIdleTimes.ResumeLayout(false);
            this.grpLongIdleTimes.PerformLayout();
            this.numTimes.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpLongIdleTimes;
        private Label lblTimes;
        private Label lblTimesContent;
        private NumericUpDown numTimes;
    }
}