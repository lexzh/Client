namespace Client.JTB
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

    partial class JTBSetCarVinAndClass
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
            this.lblCarClassify = new Label();
            this.txtCarClassify = new TextBox();
            this.lblCarNumber = new Label();
            this.txtCarNumber = new TextBox();
            this.lblCarVinNumber = new Label();
            this.txtCarVinNumber = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 217);
            this.grpWatchProperty.Controls.Add(this.lblCarClassify);
            this.grpWatchProperty.Controls.Add(this.txtCarClassify);
            this.grpWatchProperty.Controls.Add(this.lblCarNumber);
            this.grpWatchProperty.Controls.Add(this.txtCarNumber);
            this.grpWatchProperty.Controls.Add(this.lblCarVinNumber);
            this.grpWatchProperty.Controls.Add(this.txtCarVinNumber);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 96);
            this.grpWatchProperty.TabIndex = 15;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.lblCarClassify.AutoSize = true;
            this.lblCarClassify.Location = new System.Drawing.Point(50, 19);
            this.lblCarClassify.Name = "lblCarClassify";
            this.lblCarClassify.Size = new Size(65, 12);
            this.lblCarClassify.TabIndex = 30;
            this.lblCarClassify.Text = "车牌分类：";
            this.txtCarClassify.Location = new System.Drawing.Point(117, 14);
            this.txtCarClassify.MaxLength = 12;
            this.txtCarClassify.Name = "txtCarClassify";
            this.txtCarClassify.Size = new Size(161, 21);
            this.txtCarClassify.TabIndex = 29;
            this.txtCarClassify.Tag = "；";
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(62, 47);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new Size(53, 12);
            this.lblCarNumber.TabIndex = 28;
            this.lblCarNumber.Text = "车牌号：";
            this.txtCarNumber.Location = new System.Drawing.Point(117, 41);
            this.txtCarNumber.MaxLength = 12;
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new Size(161, 21);
            this.txtCarNumber.TabIndex = 27;
            this.txtCarNumber.Tag = "；";
            this.lblCarVinNumber.AutoSize = true;
            this.lblCarVinNumber.Location = new System.Drawing.Point(43, 71);
            this.lblCarVinNumber.Name = "lblCarVinNumber";
            this.lblCarVinNumber.Size = new Size(71, 12);
            this.lblCarVinNumber.TabIndex = 26;
            this.lblCarVinNumber.Text = "车辆VIN号：";
            this.txtCarVinNumber.Location = new System.Drawing.Point(117, 68);
            this.txtCarVinNumber.MaxLength = 17;
            this.txtCarVinNumber.Name = "txtCarVinNumber";
            this.txtCarVinNumber.Size = new Size(161, 21);
            this.txtCarVinNumber.TabIndex = 25;
            this.txtCarVinNumber.Tag = "；";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 250);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetCarVinAndClass";
            this.Text = "JTBSetCarVinAndClass";
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
        private Label lblCarClassify;
        private Label lblCarNumber;
        private Label lblCarVinNumber;
        private TextBox txtCarClassify;
        private TextBox txtCarNumber;
        private TextBox txtCarVinNumber;
    }
}