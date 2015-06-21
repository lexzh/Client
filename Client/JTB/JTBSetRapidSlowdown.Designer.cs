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

    partial class JTBSetRapidSlowdown
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
            this.grpRapidSlowdown = new GroupBox();
            this.lblAcceleration = new Label();
            this.numAcceleration = new NumericUpDown();
            this.lblAccelerationContent = new Label();
            this.lblAcceTime = new Label();
            this.numAcceTime = new NumericUpDown();
            this.lblAcceTimeContent = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpRapidSlowdown.SuspendLayout();
            this.numAcceleration.BeginInit();
            this.numAcceTime.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 217);
            this.grpRapidSlowdown.Controls.Add(this.lblAcceleration);
            this.grpRapidSlowdown.Controls.Add(this.numAcceleration);
            this.grpRapidSlowdown.Controls.Add(this.lblAccelerationContent);
            this.grpRapidSlowdown.Controls.Add(this.lblAcceTime);
            this.grpRapidSlowdown.Controls.Add(this.numAcceTime);
            this.grpRapidSlowdown.Controls.Add(this.lblAcceTimeContent);
            this.grpRapidSlowdown.Dock = DockStyle.Top;
            this.grpRapidSlowdown.Location = new System.Drawing.Point(5, 121);
            this.grpRapidSlowdown.Name = "grpRapidSlowdown";
            this.grpRapidSlowdown.Size = new Size(363, 96);
            this.grpRapidSlowdown.TabIndex = 11;
            this.grpRapidSlowdown.TabStop = false;
            this.grpRapidSlowdown.Text = "设置急减速参数";
            this.lblAcceleration.AutoSize = true;
            this.lblAcceleration.Location = new System.Drawing.Point(74, 27);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new Size(41, 12);
            this.lblAcceleration.TabIndex = 0;
            this.lblAcceleration.Text = "阀值：";
            this.numAcceleration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAcceleration.Location = new System.Drawing.Point(122, 23);
            int[] bits = new int[4];
            bits[0] = 255;
            this.numAcceleration.Maximum = new decimal(bits);
            this.numAcceleration.Name = "numAcceleration";
            this.numAcceleration.Size = new Size(161, 21);
            this.numAcceleration.TabIndex = 1;
            int[] numArray2 = new int[4];
            numArray2[0] = 60;
            this.numAcceleration.Value = new decimal(numArray2);
            this.lblAccelerationContent.AutoSize = true;
            this.lblAccelerationContent.Location = new System.Drawing.Point(284, 27);
            this.lblAccelerationContent.Name = "lblAccelerationContent";
            this.lblAccelerationContent.Size = new Size(47, 12);
            this.lblAccelerationContent.TabIndex = 2;
            this.lblAccelerationContent.Tag = "；";
            this.lblAccelerationContent.Text = "0.1m/s\x00b2";
            this.lblAcceTime.AutoSize = true;
            this.lblAcceTime.Location = new System.Drawing.Point(50, 60);
            this.lblAcceTime.Name = "lblAcceTime";
            this.lblAcceTime.Size = new Size(65, 12);
            this.lblAcceTime.TabIndex = 3;
            this.lblAcceTime.Text = "允许时长：";
            this.numAcceTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAcceTime.Location = new System.Drawing.Point(122, 56);
            int[] numArray3 = new int[4];
            numArray3[0] = 255;
            this.numAcceTime.Maximum = new decimal(numArray3);
            this.numAcceTime.Name = "numAcceTime";
            this.numAcceTime.Size = new Size(161, 21);
            this.numAcceTime.TabIndex = 4;
            int[] numArray4 = new int[4];
            numArray4[0] = 60;
            this.numAcceTime.Value = new decimal(numArray4);
            this.lblAcceTimeContent.AutoSize = true;
            this.lblAcceTimeContent.Location = new System.Drawing.Point(284, 60);
            this.lblAcceTimeContent.Name = "lblAcceTimeContent";
            this.lblAcceTimeContent.Size = new Size(17, 12);
            this.lblAcceTimeContent.TabIndex = 5;
            this.lblAcceTimeContent.Tag = "；";
            this.lblAcceTimeContent.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 250);
            base.Controls.Add(this.grpRapidSlowdown);
            base.Name = "JTBSetRapidSlowdown";
            this.Text = "JTBSetRapidSlowdown";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpRapidSlowdown, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpRapidSlowdown.ResumeLayout(false);
            this.grpRapidSlowdown.PerformLayout();
            this.numAcceleration.EndInit();
            this.numAcceTime.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpRapidSlowdown;
        private Label lblAcceleration;
        private Label lblAccelerationContent;
        private Label lblAcceTime;
        private Label lblAcceTimeContent;
        private NumericUpDown numAcceleration;
        private NumericUpDown numAcceTime;
    }
}