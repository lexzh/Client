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

    partial class JTBSetElectronicRailRadius
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
            this.lblCarNumber = new Label();
            this.EmergencyAlarmSecond = new Label();
            this.numRadius = new NumericUpDown();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numRadius.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 175);
            this.grpWatchProperty.Controls.Add(this.numRadius);
            this.grpWatchProperty.Controls.Add(this.EmergencyAlarmSecond);
            this.grpWatchProperty.Controls.Add(this.lblCarNumber);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 54);
            this.grpWatchProperty.TabIndex = 12;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(27, 25);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new Size(89, 12);
            this.lblCarNumber.TabIndex = 33;
            this.lblCarNumber.Text = "电子围栏半径：";
            this.EmergencyAlarmSecond.AutoSize = true;
            this.EmergencyAlarmSecond.Location = new System.Drawing.Point(289, 25);
            this.EmergencyAlarmSecond.Name = "EmergencyAlarmSecond";
            this.EmergencyAlarmSecond.Size = new Size(17, 12);
            this.EmergencyAlarmSecond.TabIndex = 61;
            this.EmergencyAlarmSecond.Tag = "；";
            this.EmergencyAlarmSecond.Text = "米";
            this.numRadius.Location = new System.Drawing.Point(122, 20);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numRadius.Maximum = new decimal(bits);
            this.numRadius.Name = "numRadius";
            this.numRadius.Size = new Size(161, 21);
            this.numRadius.TabIndex = 62;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 208);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetElectronicRailRadius";
            this.Text = "JTBSetElectronicRailRadius";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numRadius.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private Label EmergencyAlarmSecond;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblCarNumber;
        private NumericUpDown numRadius;
    }
}