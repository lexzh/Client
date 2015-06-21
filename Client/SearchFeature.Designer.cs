namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class SearchFeature
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
            this.grpSearch = new GroupBox();
            this.txtKey = new TextBox();
            this.grpResult = new GroupBox();
            this.lbResult = new ListBox();
            this.grpSearch.SuspendLayout();
            this.grpResult.SuspendLayout();
            base.SuspendLayout();
            this.grpSearch.Controls.Add(this.txtKey);
            this.grpSearch.Dock = DockStyle.Top;
            this.grpSearch.Location = new Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Padding = new Padding(10);
            this.grpSearch.Size = new Size(262, 57);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询内容";
            this.txtKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtKey.Dock = DockStyle.Top;
            this.txtKey.Location = new Point(10, 24);
            this.txtKey.MaxLength = 100;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new Size(242, 21);
            this.txtKey.TabIndex = 0;
            this.txtKey.TabStop = false;
            this.txtKey.PreviewKeyDown += new PreviewKeyDownEventHandler(this.txtKey_PreviewKeyDown);
            this.grpResult.Controls.Add(this.lbResult);
            this.grpResult.Dock = DockStyle.Fill;
            this.grpResult.Location = new Point(0, 57);
            this.grpResult.Name = "grpResult";
            this.grpResult.Padding = new Padding(10);
            this.grpResult.Size = new Size(262, 360);
            this.grpResult.TabIndex = 1;
            this.grpResult.TabStop = false;
            this.grpResult.Text = "查询结果";
            this.lbResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbResult.DisplayMember = "SpaceName";
            this.lbResult.Dock = DockStyle.Fill;
            this.lbResult.Enabled = false;
            this.lbResult.FormattingEnabled = true;
            this.lbResult.ItemHeight = 12;
            this.lbResult.Location = new Point(10, 24);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new Size(242, 326);
            this.lbResult.TabIndex = 0;
            this.lbResult.ValueMember = "Value";
            this.lbResult.DoubleClick += new EventHandler(this.lbResult_DoubleClick);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(262, 417);
            base.Controls.Add(this.grpResult);
            base.Controls.Add(this.grpSearch);
            base.Name = "SearchFeature";
            base.TabText = "地物查询";
            this.Text = "地物查询";
            base.Load += new EventHandler(this.SearchFeature_Load);
            base.DockStateChanged += new EventHandler(this.SearchFeature_DockStateChanged);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpResult.ResumeLayout(false);
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private ListBox lbResult;
    }
}