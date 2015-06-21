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

    partial class JTBSetEngineOverspeed
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
            this.grpEngineOverspeed = new GroupBox();
            this.lblRevolution = new Label();
            this.numRevolution = new NumericUpDown();
            this.lblRevolutionContent = new Label();
            this.lblTimes = new Label();
            this.numTimes = new NumericUpDown();
            this.lblTimesContent = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpEngineOverspeed.SuspendLayout();
            this.numRevolution.BeginInit();
            this.numTimes.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 217);
            this.grpEngineOverspeed.Controls.Add(this.lblRevolution);
            this.grpEngineOverspeed.Controls.Add(this.numRevolution);
            this.grpEngineOverspeed.Controls.Add(this.lblRevolutionContent);
            this.grpEngineOverspeed.Controls.Add(this.lblTimes);
            this.grpEngineOverspeed.Controls.Add(this.numTimes);
            this.grpEngineOverspeed.Controls.Add(this.lblTimesContent);
            this.grpEngineOverspeed.Dock = DockStyle.Top;
            this.grpEngineOverspeed.Location = new System.Drawing.Point(5, 121);
            this.grpEngineOverspeed.Name = "grpEngineOverspeed";
            this.grpEngineOverspeed.Size = new Size(363, 96);
            this.grpEngineOverspeed.TabIndex = 12;
            this.grpEngineOverspeed.TabStop = false;
            this.grpEngineOverspeed.Text = "设置发动机超转参数";
            this.lblRevolution.AutoSize = true;
            this.lblRevolution.Location = new System.Drawing.Point(74, 27);
            this.lblRevolution.Name = "lblRevolution";
            this.lblRevolution.Size = new Size(41, 12);
            this.lblRevolution.TabIndex = 0;
            this.lblRevolution.Text = "阀值：";
            this.numRevolution.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRevolution.Location = new System.Drawing.Point(122, 23);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numRevolution.Maximum = new decimal(bits);
            this.numRevolution.Name = "numRevolution";
            this.numRevolution.Size = new Size(161, 21);
            this.numRevolution.TabIndex = 1;
            int[] numArray2 = new int[4];
            numArray2[0] = 60;
            this.numRevolution.Value = new decimal(numArray2);
            this.lblRevolutionContent.AutoSize = true;
            this.lblRevolutionContent.Location = new System.Drawing.Point(284, 27);
            this.lblRevolutionContent.Name = "lblRevolutionContent";
            this.lblRevolutionContent.Size = new Size(17, 12);
            this.lblRevolutionContent.TabIndex = 2;
            this.lblRevolutionContent.Tag = "；";
            this.lblRevolutionContent.Text = "转";
            this.lblTimes.AutoSize = true;
            this.lblTimes.Location = new System.Drawing.Point(50, 60);
            this.lblTimes.Name = "lblTimes";
            this.lblTimes.Size = new Size(65, 12);
            this.lblTimes.TabIndex = 3;
            this.lblTimes.Text = "允许时长：";
            this.numTimes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTimes.Location = new System.Drawing.Point(122, 56);
            int[] numArray3 = new int[4];
            numArray3[0] = 255;
            this.numTimes.Maximum = new decimal(numArray3);
            this.numTimes.Name = "numTimes";
            this.numTimes.Size = new Size(161, 21);
            this.numTimes.TabIndex = 4;
            int[] numArray4 = new int[4];
            numArray4[0] = 60;
            this.numTimes.Value = new decimal(numArray4);
            this.lblTimesContent.AutoSize = true;
            this.lblTimesContent.Location = new System.Drawing.Point(284, 60);
            this.lblTimesContent.Name = "lblTimesContent";
            this.lblTimesContent.Size = new Size(17, 12);
            this.lblTimesContent.TabIndex = 5;
            this.lblTimesContent.Tag = "；";
            this.lblTimesContent.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 250);
            base.Controls.Add(this.grpEngineOverspeed);
            base.Name = "JTBSetEngineOverspeed";
            this.Text = "JTBSetEngineOverspeed";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpEngineOverspeed, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpEngineOverspeed.ResumeLayout(false);
            this.grpEngineOverspeed.PerformLayout();
            this.numRevolution.EndInit();
            this.numTimes.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private GroupBox grpEngineOverspeed;
        private Label lblRevolution;
        private Label lblRevolutionContent;
        private Label lblTimes;
        private Label lblTimesContent;
        private NumericUpDown numRevolution;
        private NumericUpDown numTimes;
    }
}