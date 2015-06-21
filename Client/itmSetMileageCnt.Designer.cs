namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmSetMileageCnt
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
            this.grpMileageParam = new GroupBox();
            this.lblMileage = new Label();
            this.lblMileageCnt = new Label();
            this.numMileageCnt = new NumericUpDown();
            this.lblMeter = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpMileageParam.SuspendLayout();
            this.numMileageCnt.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 177);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpMileageParam.Controls.Add(this.lblMileage);
            this.grpMileageParam.Controls.Add(this.lblMileageCnt);
            this.grpMileageParam.Controls.Add(this.numMileageCnt);
            this.grpMileageParam.Controls.Add(this.lblMeter);
            this.grpMileageParam.Dock = DockStyle.Top;
            this.grpMileageParam.Location = new System.Drawing.Point(5, 121);
            this.grpMileageParam.Name = "grpMileageParam";
            this.grpMileageParam.Size = new Size(363, 56);
            this.grpMileageParam.TabIndex = 1;
            this.grpMileageParam.TabStop = false;
            this.grpMileageParam.Text = "设置总里程参数";
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(270, 25);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new Size(83, 12);
            this.lblMileage.TabIndex = 0;
            this.lblMileage.Tag = "9999";
            this.lblMileage.Text = "0～4294967.29";
            this.lblMileageCnt.AutoSize = true;
            this.lblMileageCnt.Location = new System.Drawing.Point(50, 25);
            this.lblMileageCnt.Name = "lblMileageCnt";
            this.lblMileageCnt.Size = new Size(65, 12);
            this.lblMileageCnt.TabIndex = 0;
            this.lblMileageCnt.Text = "总里程数：";
            this.numMileageCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMileageCnt.DecimalPlaces = 2;
            this.numMileageCnt.Location = new System.Drawing.Point(121, 21);
            int[] bits = new int[4];
            bits[0] = 429496729;
            bits[3] = 131072;
            this.numMileageCnt.Maximum = new decimal(bits);
            this.numMileageCnt.Name = "numMileageCnt";
            this.numMileageCnt.Size = new Size(109, 21);
            this.numMileageCnt.TabIndex = 0;
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(235, 25);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new Size(29, 12);
            this.lblMeter.TabIndex = 0;
            this.lblMeter.Text = "公里";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 210);
            base.Controls.Add(this.grpMileageParam);
            base.Name = "itmSetMileageCnt";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpMileageParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpMileageParam.ResumeLayout(false);
            this.grpMileageParam.PerformLayout();
            this.numMileageCnt.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private GroupBox grpMileageParam;
        private Label lblMeter;
        private Label lblMileage;
        private Label lblMileageCnt;
        private NumericUpDown numMileageCnt;
    }
}