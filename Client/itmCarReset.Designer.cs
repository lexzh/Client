namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmCarReset
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
            new ComponentResourceManager(typeof(itmCarReset));
            this.grpSetType = new GroupBox();
            this.lblSetType = new Label();
            this.cmbSetType = new ComBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSetType.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 175);
            this.grpSetType.Controls.Add(this.lblSetType);
            this.grpSetType.Controls.Add(this.cmbSetType);
            this.grpSetType.Dock = DockStyle.Top;
            this.grpSetType.Location = new System.Drawing.Point(5, 121);
            this.grpSetType.Name = "grpSetType";
            this.grpSetType.Size = new Size(363, 54);
            this.grpSetType.TabIndex = 14;
            this.grpSetType.TabStop = false;
            this.grpSetType.Text = "参数";
            this.lblSetType.AutoSize = true;
            this.lblSetType.Location = new System.Drawing.Point(50, 24);
            this.lblSetType.Name = "lblSetType";
            this.lblSetType.Size = new Size(65, 12);
            this.lblSetType.TabIndex = 2;
            this.lblSetType.Text = "查询类型：";
            this.cmbSetType.DisplayMember = "Display";
            this.cmbSetType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSetType.FlatStyle = FlatStyle.Flat;
            this.cmbSetType.Location = new System.Drawing.Point(122, 20);
            this.cmbSetType.Name = "cmbSetType";
            this.cmbSetType.Size = new Size(205, 20);
            this.cmbSetType.TabIndex = 3;
            this.cmbSetType.Tag = "；";
            this.cmbSetType.ValueMember = "Value";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 208);
            base.Controls.Add(this.grpSetType);
            base.Name = "itmCarReset";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmCarReset_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSetType, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSetType.ResumeLayout(false);
            this.grpSetType.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbSetType;
        private GroupBox grpSetType;
        private Label lblSetType;
    }
}