namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class m2mSetCarInit
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(m2mSetCarInit));
            this.grpGPRSTime = new GroupBox();
            this.lblGPRSTime = new Label();
            this.numTime = new NumericUpDown();
            this.lblTimeMeter = new Label();
            this.tpCallPhone = new ToolTip(this.components);
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpGPRSTime.SuspendLayout();
            this.numTime.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 178);
            base.btnCancel.Location = new System.Drawing.Point(288, 4);
            base.btnOK.Location = new System.Drawing.Point(198, 5);
            this.grpGPRSTime.Controls.Add(this.lblGPRSTime);
            this.grpGPRSTime.Controls.Add(this.numTime);
            this.grpGPRSTime.Controls.Add(this.lblTimeMeter);
            this.grpGPRSTime.Dock = DockStyle.Top;
            this.grpGPRSTime.Location = new System.Drawing.Point(5, 121);
            this.grpGPRSTime.Name = "grpGPRSTime";
            this.grpGPRSTime.Size = new Size(363, 57);
            this.grpGPRSTime.TabIndex = 2;
            this.grpGPRSTime.TabStop = false;
            this.grpGPRSTime.Text = "GPRS链接维持报文的回传时间间隔设置";
            this.lblGPRSTime.AutoSize = true;
            this.lblGPRSTime.Location = new System.Drawing.Point(73, 25);
            this.lblGPRSTime.Name = "lblGPRSTime";
            this.lblGPRSTime.Size = new Size(89, 12);
            this.lblGPRSTime.TabIndex = 13;
            this.lblGPRSTime.Tag = "";
            this.lblGPRSTime.Text = "回传时间间隔：";
            this.numTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numTime.Location = new System.Drawing.Point(168, 21);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numTime.Maximum = new decimal(bits);
            this.numTime.Name = "numTime";
            this.numTime.Size = new Size(121, 21);
            this.numTime.TabIndex = 11;
            int[] numArray2 = new int[4];
            numArray2[0] = 60;
            this.numTime.Value = new decimal(numArray2);
            this.lblTimeMeter.AutoSize = true;
            this.lblTimeMeter.Location = new System.Drawing.Point(295, 25);
            this.lblTimeMeter.Name = "lblTimeMeter";
            this.lblTimeMeter.Size = new Size(17, 12);
            this.lblTimeMeter.TabIndex = 13;
            this.lblTimeMeter.Tag = "；";
            this.lblTimeMeter.Text = "秒";
            base.AcceptButton = null;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 211);
            base.Controls.Add(this.grpGPRSTime);
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "m2mSetCarInit";
            this.Text = "车台初始化参数设置";
            base.Load += new EventHandler(this.itmSetCarInit_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpGPRSTime, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpGPRSTime.ResumeLayout(false);
            this.grpGPRSTime.PerformLayout();
            this.numTime.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpGPRSTime;
        private Label lblGPRSTime;
        private Label lblTimeMeter;
        private NumericUpDown numTime;
        private ToolTip tpCallPhone;
    }
}