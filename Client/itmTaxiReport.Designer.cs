namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmTaxiReport
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
            this.grpWatchParam = new GroupBox();
            this.lblExplain2 = new Label();
            this.lblEmptyReport = new Label();
            this.numEmptyReport = new NumericUpDown();
            this.lblEmptySecond = new Label();
            this.lblFullReport = new Label();
            this.numFullReport = new NumericUpDown();
            this.lblFullSecond = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchParam.SuspendLayout();
            this.numEmptyReport.BeginInit();
            this.numFullReport.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 208);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpWatchParam.Controls.Add(this.lblExplain2);
            this.grpWatchParam.Controls.Add(this.lblEmptyReport);
            this.grpWatchParam.Controls.Add(this.numEmptyReport);
            this.grpWatchParam.Controls.Add(this.lblEmptySecond);
            this.grpWatchParam.Controls.Add(this.lblFullReport);
            this.grpWatchParam.Controls.Add(this.numFullReport);
            this.grpWatchParam.Controls.Add(this.lblFullSecond);
            this.grpWatchParam.Dock = DockStyle.Top;
            this.grpWatchParam.Location = new System.Drawing.Point(5, 121);
            this.grpWatchParam.Name = "grpWatchParam";
            this.grpWatchParam.Size = new Size(363, 87);
            this.grpWatchParam.TabIndex = 1;
            this.grpWatchParam.TabStop = false;
            this.grpWatchParam.Text = "监控参数";
            this.lblExplain2.AutoSize = true;
            this.lblExplain2.Location = new System.Drawing.Point(50, 69);
            this.lblExplain2.Name = "lblExplain2";
            this.lblExplain2.Size = new Size(215, 12);
            this.lblExplain2.TabIndex = 8;
            this.lblExplain2.Tag = "9999";
            this.lblExplain2.Text = "当时间间隔为0时，将停止空车重车汇报";
            this.lblEmptyReport.AutoSize = true;
            this.lblEmptyReport.Location = new System.Drawing.Point(50, 17);
            this.lblEmptyReport.Name = "lblEmptyReport";
            this.lblEmptyReport.Size = new Size(113, 12);
            this.lblEmptyReport.TabIndex = 8;
            this.lblEmptyReport.Text = "空车汇报时间间隔：";
            this.numEmptyReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numEmptyReport.Location = new System.Drawing.Point(164, 13);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numEmptyReport.Maximum = new decimal(bits);
            this.numEmptyReport.Name = "numEmptyReport";
            this.numEmptyReport.Size = new Size(96, 21);
            this.numEmptyReport.TabIndex = 0;
            this.lblEmptySecond.AutoSize = true;
            this.lblEmptySecond.Location = new System.Drawing.Point(266, 17);
            this.lblEmptySecond.Name = "lblEmptySecond";
            this.lblEmptySecond.Size = new Size(17, 12);
            this.lblEmptySecond.TabIndex = 12;
            this.lblEmptySecond.Tag = "；";
            this.lblEmptySecond.Text = "秒";
            this.lblFullReport.AutoSize = true;
            this.lblFullReport.Location = new System.Drawing.Point(50, 44);
            this.lblFullReport.Name = "lblFullReport";
            this.lblFullReport.Size = new Size(113, 12);
            this.lblFullReport.TabIndex = 8;
            this.lblFullReport.Text = "重车汇报时间间隔：";
            this.numFullReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numFullReport.Location = new System.Drawing.Point(164, 40);
            int[] numArray2 = new int[4];
            numArray2[0] = 65535;
            this.numFullReport.Maximum = new decimal(numArray2);
            this.numFullReport.Name = "numFullReport";
            this.numFullReport.Size = new Size(96, 21);
            this.numFullReport.TabIndex = 1;
            this.lblFullSecond.AutoSize = true;
            this.lblFullSecond.Location = new System.Drawing.Point(266, 44);
            this.lblFullSecond.Name = "lblFullSecond";
            this.lblFullSecond.Size = new Size(17, 12);
            this.lblFullSecond.TabIndex = 12;
            this.lblFullSecond.Tag = "；";
            this.lblFullSecond.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 241);
            base.Controls.Add(this.grpWatchParam);
            base.Name = "itmTaxiReport";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchParam.ResumeLayout(false);
            this.grpWatchParam.PerformLayout();
            this.numEmptyReport.EndInit();
            this.numFullReport.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private GroupBox grpWatchParam;
        private Label lblEmptyReport;
        private Label lblEmptySecond;
        private Label lblExplain2;
        private Label lblFullReport;
        private Label lblFullSecond;
        private NumericUpDown numEmptyReport;
        private NumericUpDown numFullReport;
    }
}