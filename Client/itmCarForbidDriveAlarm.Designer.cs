namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class itmCarForbidDriveAlarm
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
            this.lblStartTime = new Label();
            this.dtpStartTime = new DateTimePicker();
            this.lblEndTime = new Label();
            this.dtpEndTime = new DateTimePicker();
            this.lblText = new Label();
            this.txtText = new TextBox();
            this.chkCancelAlarm = new CheckBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new Point(5, 334);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpParam.Controls.Add(this.lblStartTime);
            this.grpParam.Controls.Add(this.dtpStartTime);
            this.grpParam.Controls.Add(this.lblEndTime);
            this.grpParam.Controls.Add(this.dtpEndTime);
            this.grpParam.Controls.Add(this.lblText);
            this.grpParam.Controls.Add(this.txtText);
            this.grpParam.Controls.Add(this.chkCancelAlarm);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 213);
            this.grpParam.TabIndex = 1;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "禁驾报警参数";
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new Point(50, 24);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "开始时间：";
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new Point(122, 20);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new Size(161, 21);
            this.dtpStartTime.TabIndex = 0;
            this.dtpStartTime.Tag = "";
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new Point(50, 52);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "结束时间：";
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new Point(122, 48);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new Size(161, 21);
            this.dtpEndTime.TabIndex = 1;
            this.dtpEndTime.Tag = "";
            this.lblText.AutoSize = true;
            this.lblText.Location = new Point(50, 80);
            this.lblText.Name = "lblText";
            this.lblText.Size = new Size(65, 12);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "提示信息：";
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtText.Location = new Point(122, 76);
            this.txtText.MaxLength = 64;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new Size(161, 104);
            this.txtText.TabIndex = 2;
            this.txtText.Tag = "";
            this.chkCancelAlarm.AutoSize = true;
            this.chkCancelAlarm.Location = new Point(122, 187);
            this.chkCancelAlarm.Name = "chkCancelAlarm";
            this.chkCancelAlarm.Size = new Size(96, 16);
            this.chkCancelAlarm.TabIndex = 6;
            this.chkCancelAlarm.Tag = "；";
            this.chkCancelAlarm.Text = "取消禁驾报警";
            this.chkCancelAlarm.UseVisualStyleBackColor = true;
            this.chkCancelAlarm.CheckedChanged += new EventHandler(this.chkCancelAlarm_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 367);
            base.Controls.Add(this.grpParam);
            base.Name = "itmCarForbidDriveAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmCarForbidDriveInTimeAlarm_Load);
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
        private CheckBox chkCancelAlarm;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private GroupBox grpParam;
        private Label lblEndTime;
        private Label lblStartTime;
        private Label lblText;
        private TextBox txtText;
    }
}