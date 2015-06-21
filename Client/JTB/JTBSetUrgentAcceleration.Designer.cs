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

    partial class JTBSetUrgentAcceleration
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
            this.grpUrgentAcceleration = new GroupBox();
            this.lblAccPercentage = new Label();
            this.numAccPercentage = new NumericUpDown();
            this.lblAccPercentageContent = new Label();
            this.lblAcceleration = new Label();
            this.numAcceleration = new NumericUpDown();
            this.lblAccelerationContent = new Label();
            this.lblAcceTime = new Label();
            this.numAcceTime = new NumericUpDown();
            this.lblAcceTimeContent = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpUrgentAcceleration.SuspendLayout();
            this.numAccPercentage.BeginInit();
            this.numAcceleration.BeginInit();
            this.numAcceTime.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 251);
            this.grpUrgentAcceleration.Controls.Add(this.lblAccPercentage);
            this.grpUrgentAcceleration.Controls.Add(this.numAccPercentage);
            this.grpUrgentAcceleration.Controls.Add(this.lblAccPercentageContent);
            this.grpUrgentAcceleration.Controls.Add(this.lblAcceleration);
            this.grpUrgentAcceleration.Controls.Add(this.numAcceleration);
            this.grpUrgentAcceleration.Controls.Add(this.lblAccelerationContent);
            this.grpUrgentAcceleration.Controls.Add(this.lblAcceTime);
            this.grpUrgentAcceleration.Controls.Add(this.numAcceTime);
            this.grpUrgentAcceleration.Controls.Add(this.lblAcceTimeContent);
            this.grpUrgentAcceleration.Dock = DockStyle.Top;
            this.grpUrgentAcceleration.Location = new System.Drawing.Point(5, 121);
            this.grpUrgentAcceleration.Name = "grpUrgentAcceleration";
            this.grpUrgentAcceleration.Size = new Size(363, 130);
            this.grpUrgentAcceleration.TabIndex = 11;
            this.grpUrgentAcceleration.TabStop = false;
            this.grpUrgentAcceleration.Text = "设置急加速参数";
            this.lblAccPercentage.AutoSize = true;
            this.lblAccPercentage.Location = new System.Drawing.Point(50, 28);
            this.lblAccPercentage.Name = "lblAccPercentage";
            this.lblAccPercentage.Size = new Size(65, 12);
            this.lblAccPercentage.TabIndex = 0;
            this.lblAccPercentage.Text = "油门开度：";
            this.numAccPercentage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAccPercentage.Location = new System.Drawing.Point(122, 24);
            this.numAccPercentage.Name = "numAccPercentage";
            this.numAccPercentage.Size = new Size(161, 21);
            this.numAccPercentage.TabIndex = 1;
            int[] bits = new int[4];
            bits[0] = 50;
            this.numAccPercentage.Value = new decimal(bits);
            this.lblAccPercentageContent.AutoSize = true;
            this.lblAccPercentageContent.Location = new System.Drawing.Point(283, 28);
            this.lblAccPercentageContent.Name = "lblAccPercentageContent";
            this.lblAccPercentageContent.Size = new Size(11, 12);
            this.lblAccPercentageContent.TabIndex = 2;
            this.lblAccPercentageContent.Tag = "；";
            this.lblAccPercentageContent.Text = "%";
            this.lblAcceleration.AutoSize = true;
            this.lblAcceleration.Location = new System.Drawing.Point(74, 62);
            this.lblAcceleration.Name = "lblAcceleration";
            this.lblAcceleration.Size = new Size(41, 12);
            this.lblAcceleration.TabIndex = 3;
            this.lblAcceleration.Text = "阀值：";
            this.numAcceleration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAcceleration.Location = new System.Drawing.Point(122, 58);
            int[] numArray2 = new int[4];
            numArray2[0] = 255;
            this.numAcceleration.Maximum = new decimal(numArray2);
            this.numAcceleration.Name = "numAcceleration";
            this.numAcceleration.Size = new Size(161, 21);
            this.numAcceleration.TabIndex = 4;
            int[] numArray3 = new int[4];
            numArray3[0] = 60;
            this.numAcceleration.Value = new decimal(numArray3);
            this.lblAccelerationContent.AutoSize = true;
            this.lblAccelerationContent.Location = new System.Drawing.Point(283, 62);
            this.lblAccelerationContent.Name = "lblAccelerationContent";
            this.lblAccelerationContent.Size = new Size(47, 12);
            this.lblAccelerationContent.TabIndex = 5;
            this.lblAccelerationContent.Tag = "；";
            this.lblAccelerationContent.Text = "0.1m/s\x00b2";
            this.lblAcceTime.AutoSize = true;
            this.lblAcceTime.Location = new System.Drawing.Point(50, 96);
            this.lblAcceTime.Name = "lblAcceTime";
            this.lblAcceTime.Size = new Size(65, 12);
            this.lblAcceTime.TabIndex = 6;
            this.lblAcceTime.Text = "允许时长：";
            this.numAcceTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAcceTime.Location = new System.Drawing.Point(122, 92);
            int[] numArray4 = new int[4];
            numArray4[0] = 255;
            this.numAcceTime.Maximum = new decimal(numArray4);
            this.numAcceTime.Name = "numAcceTime";
            this.numAcceTime.Size = new Size(161, 21);
            this.numAcceTime.TabIndex = 7;
            int[] numArray5 = new int[4];
            numArray5[0] = 60;
            this.numAcceTime.Value = new decimal(numArray5);
            this.lblAcceTimeContent.AutoSize = true;
            this.lblAcceTimeContent.Location = new System.Drawing.Point(283, 96);
            this.lblAcceTimeContent.Name = "lblAcceTimeContent";
            this.lblAcceTimeContent.Size = new Size(17, 12);
            this.lblAcceTimeContent.TabIndex = 8;
            this.lblAcceTimeContent.Tag = "；";
            this.lblAcceTimeContent.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 284);
            base.Controls.Add(this.grpUrgentAcceleration);
            base.Name = "JTBSetUrgentAcceleration";
            this.Text = "JTBSetUrgentAcceleration";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpUrgentAcceleration, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpUrgentAcceleration.ResumeLayout(false);
            this.grpUrgentAcceleration.PerformLayout();
            this.numAccPercentage.EndInit();
            this.numAcceleration.EndInit();
            this.numAcceTime.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpUrgentAcceleration;
        private Label lblAcceleration;
        private Label lblAccelerationContent;
        private Label lblAcceTime;
        private Label lblAcceTimeContent;
        private Label lblAccPercentage;
        private Label lblAccPercentageContent;
        private NumericUpDown numAcceleration;
        private NumericUpDown numAcceTime;
        private NumericUpDown numAccPercentage;
    }
}