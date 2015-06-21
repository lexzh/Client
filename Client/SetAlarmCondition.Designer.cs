namespace Client
{
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    partial class SetAlarmCondition
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SetAlarmCondition));
            this.clbAlarmCondition = new CheckedListBox();
            this.chkDefault = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlAlarmCondition = new System.Windows.Forms.Panel();
            this.pnlAlarmCondition.SuspendLayout();
            base.SuspendLayout();
            this.clbAlarmCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbAlarmCondition.CheckOnClick = true;
            this.clbAlarmCondition.Dock = DockStyle.Top;
            this.clbAlarmCondition.FormattingEnabled = true;
            this.clbAlarmCondition.HorizontalScrollbar = true;
            this.clbAlarmCondition.Location = new Point(5, 5);
            this.clbAlarmCondition.MultiColumn = true;
            this.clbAlarmCondition.Name = "clbAlarmCondition";
            this.clbAlarmCondition.ScrollAlwaysVisible = true;
            this.clbAlarmCondition.Size = new Size(285, 98);
            this.clbAlarmCondition.TabIndex = 0;
            this.chkDefault.AutoSize = true;
            this.chkDefault.Location = new Point(48, 116);
            this.chkDefault.Name = "chkDefault";
            this.chkDefault.Size = new Size(156, 16);
            this.chkDefault.TabIndex = 1;
            this.chkDefault.Text = "默认(全部为未选中状态)";
            this.chkDefault.UseVisualStyleBackColor = true;
            this.chkDefault.CheckedChanged += new EventHandler(this.chkDefault_CheckedChanged);
            this.btnOK.Location = new Point(126, 135);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(212, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.pnlAlarmCondition.Controls.Add(this.btnCancel);
            this.pnlAlarmCondition.Controls.Add(this.btnOK);
            this.pnlAlarmCondition.Controls.Add(this.chkDefault);
            this.pnlAlarmCondition.Controls.Add(this.clbAlarmCondition);
            this.pnlAlarmCondition.Dock = DockStyle.Fill;
            this.pnlAlarmCondition.Location = new Point(0, 0);
            this.pnlAlarmCondition.Name = "pnlAlarmCondition";
            this.pnlAlarmCondition.Padding = new Padding(5);
            this.pnlAlarmCondition.Size = new Size(295, 168);
            this.pnlAlarmCondition.TabIndex = 5;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(295, 168);
            base.Controls.Add(this.pnlAlarmCondition);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.None;
            base.Icon = (Icon)resources.GetObject("$this.Icon");
            base.Name = "SetAlarmCondition";
            this.Text = "SetAlarmCondition";
            base.Load += new EventHandler(this.SetAlarmCondition_Load);
            this.pnlAlarmCondition.ResumeLayout(false);
            this.pnlAlarmCondition.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.CheckBox chkDefault;
        private CheckedListBox clbAlarmCondition;
        private System.Windows.Forms.Panel pnlAlarmCondition;
    }
}