namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmSetDistrictAlarm
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
            new ComponentResourceManager(typeof(itmSetDistrictAlarm));
            this.grpDistrict = new GroupBox();
            this.grpInOut = new GroupBox();
            this.rdoOut = new RadioButton();
            this.rdoIn = new RadioButton();
            this.rdoCancel = new RadioButton();
            this.cmbDistrict3 = new ComBox();
            this.cmbDistrict2 = new ComBox();
            this.cmbDistrict1 = new ComBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpDistrict.SuspendLayout();
            this.grpInOut.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new Point(5, 231);
            this.grpDistrict.Controls.Add(this.grpInOut);
            this.grpDistrict.Controls.Add(this.cmbDistrict3);
            this.grpDistrict.Controls.Add(this.cmbDistrict2);
            this.grpDistrict.Controls.Add(this.cmbDistrict1);
            this.grpDistrict.Dock = DockStyle.Top;
            this.grpDistrict.Location = new Point(5, 121);
            this.grpDistrict.Name = "grpDistrict";
            this.grpDistrict.Size = new Size(363, 110);
            this.grpDistrict.TabIndex = 11;
            this.grpDistrict.TabStop = false;
            this.grpDistrict.Text = "行政区域";
            this.grpInOut.Controls.Add(this.rdoOut);
            this.grpInOut.Controls.Add(this.rdoIn);
            this.grpInOut.Controls.Add(this.rdoCancel);
            this.grpInOut.Location = new Point(39, 11);
            this.grpInOut.Name = "grpInOut";
            this.grpInOut.Size = new Size(76, 93);
            this.grpInOut.TabIndex = 2;
            this.grpInOut.TabStop = false;
            this.rdoOut.AutoSize = true;
            this.rdoOut.Location = new Point(13, 68);
            this.rdoOut.Name = "rdoOut";
            this.rdoOut.Size = new Size(47, 16);
            this.rdoOut.TabIndex = 0;
            this.rdoOut.TabStop = true;
            this.rdoOut.Text = "越出";
            this.rdoOut.UseVisualStyleBackColor = true;
            this.rdoIn.AutoSize = true;
            this.rdoIn.Location = new Point(13, 39);
            this.rdoIn.Name = "rdoIn";
            this.rdoIn.Size = new Size(47, 16);
            this.rdoIn.TabIndex = 0;
            this.rdoIn.TabStop = true;
            this.rdoIn.Text = "进入";
            this.rdoIn.UseVisualStyleBackColor = true;
            this.rdoCancel.AutoSize = true;
            this.rdoCancel.Checked = true;
            this.rdoCancel.Location = new Point(13, 10);
            this.rdoCancel.Name = "rdoCancel";
            this.rdoCancel.Size = new Size(47, 16);
            this.rdoCancel.TabIndex = 0;
            this.rdoCancel.TabStop = true;
            this.rdoCancel.Text = "取消";
            this.rdoCancel.UseVisualStyleBackColor = true;
            this.cmbDistrict3.DisplayMember = "Display";
            this.cmbDistrict3.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDistrict3.FlatStyle = FlatStyle.Flat;
            this.cmbDistrict3.FormattingEnabled = true;
            this.cmbDistrict3.Location = new Point(122, 78);
            this.cmbDistrict3.Name = "cmbDistrict3";
            this.cmbDistrict3.Size = new Size(161, 20);
            this.cmbDistrict3.TabIndex = 0;
            this.cmbDistrict3.Tag = "3";
            this.cmbDistrict3.ValueMember = "Value";
            this.cmbDistrict3.SelectedValueChanged += new EventHandler(this.cmbDistrict1_SelectedValueChanged);
            this.cmbDistrict2.DisplayMember = "Display";
            this.cmbDistrict2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDistrict2.FlatStyle = FlatStyle.Flat;
            this.cmbDistrict2.FormattingEnabled = true;
            this.cmbDistrict2.Location = new Point(122, 49);
            this.cmbDistrict2.Name = "cmbDistrict2";
            this.cmbDistrict2.Size = new Size(161, 20);
            this.cmbDistrict2.TabIndex = 0;
            this.cmbDistrict2.Tag = "2";
            this.cmbDistrict2.ValueMember = "Value";
            this.cmbDistrict2.SelectedValueChanged += new EventHandler(this.cmbDistrict1_SelectedValueChanged);
            this.cmbDistrict1.DisplayMember = "Display";
            this.cmbDistrict1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbDistrict1.FlatStyle = FlatStyle.Flat;
            this.cmbDistrict1.FormattingEnabled = true;
            this.cmbDistrict1.Location = new Point(122, 20);
            this.cmbDistrict1.Name = "cmbDistrict1";
            this.cmbDistrict1.Size = new Size(161, 20);
            this.cmbDistrict1.TabIndex = 0;
            this.cmbDistrict1.Tag = "1";
            this.cmbDistrict1.ValueMember = "Value";
            this.cmbDistrict1.SelectedValueChanged += new EventHandler(this.cmbDistrict1_SelectedValueChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 264);
            base.Controls.Add(this.grpDistrict);
            base.Name = "itmSetDistrictAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmSetDistrictAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpDistrict, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpDistrict.ResumeLayout(false);
            this.grpInOut.ResumeLayout(false);
            this.grpInOut.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbDistrict1;
        private ComBox cmbDistrict2;
        private ComBox cmbDistrict3;
        private GroupBox grpDistrict;
        private GroupBox grpInOut;
        private RadioButton rdoCancel;
        private RadioButton rdoIn;
        private RadioButton rdoOut;
    }
}