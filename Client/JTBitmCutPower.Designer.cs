namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBitmCutPower
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
            this.grpWatchProperty = new GroupBox();
            this.cmbCmdType = new ComboBox();
            this.cmbCutType = new ComboBox();
            this.lblCmdType = new Label();
            this.lblCutType = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 201);
            this.grpWatchProperty.Controls.Add(this.cmbCmdType);
            this.grpWatchProperty.Controls.Add(this.cmbCutType);
            this.grpWatchProperty.Controls.Add(this.lblCmdType);
            this.grpWatchProperty.Controls.Add(this.lblCutType);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 80);
            this.grpWatchProperty.TabIndex = 14;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.cmbCmdType.DisplayMember = "Name";
            this.cmbCmdType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCmdType.FormattingEnabled = true;
            this.cmbCmdType.Location = new System.Drawing.Point(122, 48);
            this.cmbCmdType.Name = "cmbCmdType";
            this.cmbCmdType.Size = new Size(161, 20);
            this.cmbCmdType.TabIndex = 3;
            this.cmbCmdType.ValueMember = "Value";
            this.cmbCutType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCutType.FormattingEnabled = true;
            this.cmbCutType.Items.AddRange(new object[] { "CAN", "2.5V", "0.5V" });
            this.cmbCutType.Location = new System.Drawing.Point(122, 20);
            this.cmbCutType.Name = "cmbCutType";
            this.cmbCutType.Size = new Size(161, 20);
            this.cmbCutType.TabIndex = 2;
            this.cmbCutType.SelectedIndexChanged += new EventHandler(this.cmbCutType_SelectedIndexChanged);
            this.lblCmdType.AutoSize = true;
            this.lblCmdType.Location = new System.Drawing.Point(75, 51);
            this.lblCmdType.Name = "lblCmdType";
            this.lblCmdType.Size = new Size(41, 12);
            this.lblCmdType.TabIndex = 1;
            this.lblCmdType.Text = "命令：";
            this.lblCutType.AutoSize = true;
            this.lblCutType.Location = new System.Drawing.Point(74, 23);
            this.lblCutType.Name = "lblCutType";
            this.lblCutType.Size = new Size(41, 12);
            this.lblCutType.TabIndex = 0;
            this.lblCutType.Text = "类型：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 234);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBitmCutPower";
            this.Text = "JTBitmCutPower";
            base.Load += new EventHandler(this.JTBitmCutPower_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComboBox cmbCmdType;
        private ComboBox cmbCutType;
        private DataTable dt;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblCmdType;
        private Label lblCutType;
    }
}