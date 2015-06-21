namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class SetDateTime
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SetDateTime));
            this.chkSameTime = new CheckBox();
            this.dtpDate = new DateTimePicker();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.btnClear = new Button();
            this.dtpTime = new DateTimePicker();
            this.lblDate = new Label();
            this.lblTime = new Label();
            this.pnlDateTime = new Panel();
            this.pnlDateTime.SuspendLayout();
            base.SuspendLayout();
            this.chkSameTime.AutoSize = true;
            this.chkSameTime.Location = new Point(68, 24);
            this.chkSameTime.Name = "chkSameTime";
            this.chkSameTime.Size = new Size(72, 16);
            this.chkSameTime.TabIndex = 0;
            this.chkSameTime.Text = "固定时段";
            this.chkSameTime.UseVisualStyleBackColor = true;
            this.chkSameTime.CheckedChanged += new EventHandler(this.chkSameTime_CheckedChanged);
            this.dtpDate.CustomFormat = "yyyy-MM-dd";
            this.dtpDate.Format = DateTimePickerFormat.Custom;
            this.dtpDate.Location = new Point(68, 61);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new Size(111, 21);
            this.dtpDate.TabIndex = 1;
            this.btnOK.Location = new Point(194, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(194, 60);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnClear.Location = new Point(194, 99);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);
            this.dtpTime.CustomFormat = "HH:mm:ss";
            this.dtpTime.Format = DateTimePickerFormat.Custom;
            this.dtpTime.Location = new Point(68, 100);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.ShowUpDown = true;
            this.dtpTime.Size = new Size(111, 21);
            this.dtpTime.TabIndex = 2;
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new Point(21, 65);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(41, 12);
            this.lblDate.TabIndex = 3;
            this.lblDate.Text = "日期：";
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new Point(21, 104);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new Size(41, 12);
            this.lblTime.TabIndex = 3;
            this.lblTime.Text = "时间：";
            this.pnlDateTime.Controls.Add(this.lblTime);
            this.pnlDateTime.Controls.Add(this.lblDate);
            this.pnlDateTime.Controls.Add(this.btnClear);
            this.pnlDateTime.Controls.Add(this.btnCancel);
            this.pnlDateTime.Controls.Add(this.btnOK);
            this.pnlDateTime.Controls.Add(this.dtpTime);
            this.pnlDateTime.Controls.Add(this.dtpDate);
            this.pnlDateTime.Controls.Add(this.chkSameTime);
            this.pnlDateTime.Dock = DockStyle.Fill;
            this.pnlDateTime.Location = new Point(0, 0);
            this.pnlDateTime.Name = "pnlDateTime";
            this.pnlDateTime.Size = new Size(292, 149);
            this.pnlDateTime.TabIndex = 6;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(292, 149);
            base.Controls.Add(this.pnlDateTime);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "SetDateTime";
            this.Text = "SetDateTime";
            base.TopMost = true;
            base.Load += new EventHandler(this.SetDateTime_Load);
            this.pnlDateTime.ResumeLayout(false);
            this.pnlDateTime.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Button btnCancel;
        private Button btnClear;
        private Button btnOK;
        private CheckBox chkSameTime;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        private Label lblDate;
        private Label lblTime;
        private string m_sDateTime;
        private Panel pnlDateTime;
    }
}