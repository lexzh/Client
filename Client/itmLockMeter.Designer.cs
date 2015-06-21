namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmLockMeter
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
            this.grpParam = new GroupBox();
            this.dtpLockTime = new DateTimePicker();
            this.dtpLockDate = new DateTimePicker();
            this.lblLockTime = new Label();
            this.lblLockDate = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new Point(5, 201);
            this.grpParam.Controls.Add(this.dtpLockTime);
            this.grpParam.Controls.Add(this.dtpLockDate);
            this.grpParam.Controls.Add(this.lblLockTime);
            this.grpParam.Controls.Add(this.lblLockDate);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 80);
            this.grpParam.TabIndex = 11;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数";
            this.dtpLockTime.CustomFormat = "HH:mm:ss";
            this.dtpLockTime.Format = DateTimePickerFormat.Custom;
            this.dtpLockTime.Location = new Point(122, 49);
            this.dtpLockTime.Name = "dtpLockTime";
            this.dtpLockTime.ShowUpDown = true;
            this.dtpLockTime.Size = new Size(162, 21);
            this.dtpLockTime.TabIndex = 22;
            this.dtpLockDate.CustomFormat = "yyyy-MM-dd";
            this.dtpLockDate.Format = DateTimePickerFormat.Custom;
            this.dtpLockDate.Location = new Point(122, 21);
            this.dtpLockDate.Name = "dtpLockDate";
            this.dtpLockDate.Size = new Size(162, 21);
            this.dtpLockDate.TabIndex = 23;
            this.lblLockTime.AutoSize = true;
            this.lblLockTime.Location = new Point(50, 53);
            this.lblLockTime.Name = "lblLockTime";
            this.lblLockTime.Size = new Size(65, 12);
            this.lblLockTime.TabIndex = 20;
            this.lblLockTime.Text = "锁定时间：";
            this.lblLockDate.AutoSize = true;
            this.lblLockDate.Location = new Point(50, 25);
            this.lblLockDate.Name = "lblLockDate";
            this.lblLockDate.Size = new Size(65, 12);
            this.lblLockDate.TabIndex = 21;
            this.lblLockDate.Text = "锁定日期：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 234);
            base.Controls.Add(this.grpParam);
            base.Name = "itmLockMeter";
            this.Text = "itmLockMeter";
            base.Load += new EventHandler(this.itmLockMeter_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private DateTimePicker dtpLockDate;
        private DateTimePicker dtpLockTime;
        private System.Windows.Forms.GroupBox grpParam;
        private Label lblLockDate;
        private Label lblLockTime;
    }
}