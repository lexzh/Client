namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class FlagForm
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
            this.grpFlagType = new GroupBox();
            this.clbSelectFlagType = new CheckedListBox();
            this.pnlSelectAll = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpFlagType.SuspendLayout();
            this.pnlSelectAll.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            base.SuspendLayout();
            this.grpFlagType.Controls.Add(this.clbSelectFlagType);
            this.grpFlagType.Controls.Add(this.pnlSelectAll);
            this.grpFlagType.Dock = DockStyle.Top;
            this.grpFlagType.Location = new Point(5, 5);
            this.grpFlagType.Margin = new Padding(0);
            this.grpFlagType.Name = "grpFlagType";
            this.grpFlagType.Padding = new Padding(10);
            this.grpFlagType.Size = new Size(363, 203);
            this.grpFlagType.TabIndex = 12;
            this.grpFlagType.TabStop = false;
            this.grpFlagType.Text = "兴趣点类型显示控制";
            this.clbSelectFlagType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbSelectFlagType.CheckOnClick = true;
            this.clbSelectFlagType.Dock = DockStyle.Top;
            this.clbSelectFlagType.FormattingEnabled = true;
            this.clbSelectFlagType.Location = new Point(10, 24);
            this.clbSelectFlagType.Margin = new Padding(10);
            this.clbSelectFlagType.Name = "clbSelectFlagType";
            this.clbSelectFlagType.Size = new Size(343, 146);
            this.clbSelectFlagType.TabIndex = 0;
            this.pnlSelectAll.Controls.Add(this.chkSelectAll);
            this.pnlSelectAll.Dock = DockStyle.Bottom;
            this.pnlSelectAll.Location = new Point(10, 172);
            this.pnlSelectAll.Margin = new Padding(10);
            this.pnlSelectAll.Name = "pnlSelectAll";
            this.pnlSelectAll.Size = new Size(343, 21);
            this.pnlSelectAll.TabIndex = 2;
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new Point(266, 5);
            this.chkSelectAll.Margin = new Padding(0);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new Size(72, 16);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Text = "全部选择";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new EventHandler(this.chkSelectAll_CheckedChanged);
            this.pnlBtn.Controls.Add(this.btnCancel);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Dock = DockStyle.Top;
            this.pnlBtn.Location = new Point(5, 208);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new Size(363, 28);
            this.pnlBtn.TabIndex = 13;
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(286, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new Point(205, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(373, 241);
            base.Controls.Add(this.pnlBtn);
            base.Controls.Add(this.grpFlagType);
            base.Name = "FlagForm";
            base.Padding = new Padding(5);
            base.ShowInTaskbar = true;
            this.Text = "兴趣点类型显示控制";
            base.Load += new EventHandler(this.FlagForm_Load);
            this.grpFlagType.ResumeLayout(false);
            this.pnlSelectAll.ResumeLayout(false);
            this.pnlSelectAll.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private CheckedListBox clbSelectFlagType;
        private System.Windows.Forms.GroupBox grpFlagType;
        private GisMap m_CurrentMap;
        private System.Windows.Forms.Panel pnlSelectAll;
    }
}