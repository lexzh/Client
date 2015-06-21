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

    partial class JTBSetDriverCodeAndLicense
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
            this.numDriveCode = new NumericUpDown();
            this.lblDriveCId = new Label();
            this.lblDriveCode = new Label();
            this.txtDriveCId = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numDriveCode.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 198);
            this.grpWatchProperty.Controls.Add(this.numDriveCode);
            this.grpWatchProperty.Controls.Add(this.lblDriveCId);
            this.grpWatchProperty.Controls.Add(this.lblDriveCode);
            this.grpWatchProperty.Controls.Add(this.txtDriveCId);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 77);
            this.grpWatchProperty.TabIndex = 14;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.numDriveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDriveCode.Location = new System.Drawing.Point(117, 18);
            int[] bits = new int[4];
            bits[0] = 16777215;
            this.numDriveCode.Maximum = new decimal(bits);
            this.numDriveCode.Name = "numDriveCode";
            this.numDriveCode.Size = new Size(161, 21);
            this.numDriveCode.TabIndex = 22;
            this.numDriveCode.Tag = "；";
            this.lblDriveCId.AutoSize = true;
            this.lblDriveCId.Location = new System.Drawing.Point(37, 48);
            this.lblDriveCId.Name = "lblDriveCId";
            this.lblDriveCId.Size = new Size(77, 12);
            this.lblDriveCId.TabIndex = 21;
            this.lblDriveCId.Text = "驾驶证号码：";
            this.lblDriveCode.AutoSize = true;
            this.lblDriveCode.Location = new System.Drawing.Point(37, 22);
            this.lblDriveCode.Name = "lblDriveCode";
            this.lblDriveCode.Size = new Size(77, 12);
            this.lblDriveCode.TabIndex = 20;
            this.lblDriveCode.Text = "驾驶员代码：";
            this.txtDriveCId.Location = new System.Drawing.Point(116, 45);
            this.txtDriveCId.MaxLength = 18;
            this.txtDriveCId.Name = "txtDriveCId";
            this.txtDriveCId.Size = new Size(161, 21);
            this.txtDriveCId.TabIndex = 19;
            this.txtDriveCId.Tag = "；";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 231);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetDriverCodeAndLicense";
            this.Text = "JTBSetDriverCodeAndLicense";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numDriveCode.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblDriveCId;
        private Label lblDriveCode;
        private NumericUpDown numDriveCode;
        private TextBox txtDriveCId;
    }
}