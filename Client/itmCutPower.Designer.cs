namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmCutPower
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
            new ComponentResourceManager(typeof(itmCutPower));
            this.grpSendType = new GroupBox();
            this.lblExplain = new Label();
            this.lblTel = new Label();
            this.cmbSendType = new ComBox();
            this.grpEnable = new GroupBox();
            this.dtpEnableTime = new DateTimePicker();
            this.dtpEnableDate = new DateTimePicker();
            this.lblEnableTime = new Label();
            this.lblEnableDate = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSendType.SuspendLayout();
            this.grpEnable.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 268);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpSendType.Controls.Add(this.lblExplain);
            this.grpSendType.Controls.Add(this.lblTel);
            this.grpSendType.Controls.Add(this.cmbSendType);
            this.grpSendType.Dock = DockStyle.Top;
            this.grpSendType.Location = new System.Drawing.Point(5, 121);
            this.grpSendType.Name = "grpSendType";
            this.grpSendType.Size = new Size(363, 73);
            this.grpSendType.TabIndex = 1;
            this.grpSendType.TabStop = false;
            this.grpSendType.Text = "设置通讯方式";
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = Color.Red;
            this.lblExplain.Location = new System.Drawing.Point(65, 47);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new Size(281, 12);
            this.lblExplain.TabIndex = 17;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = "注：［短信］或者［混合］方式可能会造成命令廷时";
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(50, 21);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new Size(65, 12);
            this.lblTel.TabIndex = 18;
            this.lblTel.Text = "通讯方式：";
            this.cmbSendType.DisplayMember = "Display";
            this.cmbSendType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSendType.FlatStyle = FlatStyle.Flat;
            this.cmbSendType.FormattingEnabled = true;
            this.cmbSendType.Location = new System.Drawing.Point(122, 18);
            this.cmbSendType.Name = "cmbSendType";
            this.cmbSendType.Size = new Size(161, 20);
            this.cmbSendType.TabIndex = 0;
            this.cmbSendType.Tag = "；";
            this.cmbSendType.ValueMember = "Value";
            this.grpEnable.Controls.Add(this.dtpEnableTime);
            this.grpEnable.Controls.Add(this.dtpEnableDate);
            this.grpEnable.Controls.Add(this.lblEnableTime);
            this.grpEnable.Controls.Add(this.lblEnableDate);
            this.grpEnable.Dock = DockStyle.Top;
            this.grpEnable.Location = new System.Drawing.Point(5, 194);
            this.grpEnable.Name = "grpEnable";
            this.grpEnable.Size = new Size(363, 74);
            this.grpEnable.TabIndex = 3;
            this.grpEnable.TabStop = false;
            this.grpEnable.Text = "时效参数";
            this.dtpEnableTime.CustomFormat = "HH:mm:ss";
            this.dtpEnableTime.Format = DateTimePickerFormat.Custom;
            this.dtpEnableTime.Location = new System.Drawing.Point(122, 44);
            this.dtpEnableTime.Name = "dtpEnableTime";
            this.dtpEnableTime.ShowUpDown = true;
            this.dtpEnableTime.Size = new Size(161, 21);
            this.dtpEnableTime.TabIndex = 19;
            this.dtpEnableDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEnableDate.Format = DateTimePickerFormat.Custom;
            this.dtpEnableDate.Location = new System.Drawing.Point(122, 16);
            this.dtpEnableDate.Name = "dtpEnableDate";
            this.dtpEnableDate.Size = new Size(161, 21);
            this.dtpEnableDate.TabIndex = 19;
            this.lblEnableTime.AutoSize = true;
            this.lblEnableTime.Location = new System.Drawing.Point(50, 48);
            this.lblEnableTime.Name = "lblEnableTime";
            this.lblEnableTime.Size = new Size(65, 12);
            this.lblEnableTime.TabIndex = 18;
            this.lblEnableTime.Text = "有效时间：";
            this.lblEnableDate.AutoSize = true;
            this.lblEnableDate.Location = new System.Drawing.Point(50, 20);
            this.lblEnableDate.Name = "lblEnableDate";
            this.lblEnableDate.Size = new Size(65, 12);
            this.lblEnableDate.TabIndex = 18;
            this.lblEnableDate.Text = "有效日期：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 301);
            base.Controls.Add(this.grpEnable);
            base.Controls.Add(this.grpSendType);
            base.Name = "itmCutPower";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmCutPower_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSendType, 0);
            base.Controls.SetChildIndex(this.grpEnable, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSendType.ResumeLayout(false);
            this.grpSendType.PerformLayout();
            this.grpEnable.ResumeLayout(false);
            this.grpEnable.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbSendType;
        private DateTimePicker dtpEnableDate;
        private DateTimePicker dtpEnableTime;
        private GroupBox grpEnable;
        private GroupBox grpSendType;
        private Label lblEnableDate;
        private Label lblEnableTime;
        private Label lblExplain;
        private Label lblTel;
    }
}