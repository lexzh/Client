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

    partial class JTBSetProvincesDomainID
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
            this.numCityID = new NumericUpDown();
            this.numProvinceId = new NumericUpDown();
            this.lblProvinceId = new Label();
            this.lblCityID = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numCityID.BeginInit();
            this.numProvinceId.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 195);
            this.grpWatchProperty.Controls.Add(this.numCityID);
            this.grpWatchProperty.Controls.Add(this.numProvinceId);
            this.grpWatchProperty.Controls.Add(this.lblProvinceId);
            this.grpWatchProperty.Controls.Add(this.lblCityID);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 74);
            this.grpWatchProperty.TabIndex = 10;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.numCityID.Location = new System.Drawing.Point(121, 43);
            int[] bits = new int[4];
            bits[0] = 9999;
            this.numCityID.Maximum = new decimal(bits);
            this.numCityID.Name = "numCityID";
            this.numCityID.Size = new Size(161, 21);
            this.numCityID.TabIndex = 38;
            this.numProvinceId.Location = new System.Drawing.Point(121, 16);
            int[] numArray2 = new int[4];
            numArray2[0] = 99;
            this.numProvinceId.Maximum = new decimal(numArray2);
            this.numProvinceId.Name = "numProvinceId";
            this.numProvinceId.Size = new Size(161, 21);
            this.numProvinceId.TabIndex = 37;
            this.lblProvinceId.AutoSize = true;
            this.lblProvinceId.Location = new System.Drawing.Point(62, 19);
            this.lblProvinceId.Name = "lblProvinceId";
            this.lblProvinceId.Size = new Size(53, 12);
            this.lblProvinceId.TabIndex = 33;
            this.lblProvinceId.Text = "省域ID：";
            this.lblCityID.AutoSize = true;
            this.lblCityID.Location = new System.Drawing.Point(62, 46);
            this.lblCityID.Name = "lblCityID";
            this.lblCityID.Size = new Size(53, 12);
            this.lblCityID.TabIndex = 34;
            this.lblCityID.Text = "市域ID：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 228);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetProvincesDomainID";
            this.Text = "JTBSetProvincesDomainID";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numCityID.EndInit();
            this.numProvinceId.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblCityID;
        private Label lblProvinceId;
        private NumericUpDown numCityID;
        private NumericUpDown numProvinceId;
    }
}