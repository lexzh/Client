namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class m2mOilReport
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
            this.grpOilParam = new GroupBox();
            this.label2 = new Label();
            this.lblModle = new Label();
            this.grpModle = new GroupBox();
            this.rdoNoUpload = new RadioButton();
            this.rdoUpload = new RadioButton();
            this.lblInterval = new Label();
            this.numInterval = new NumericUpDown();
            this.lblMinute = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpOilParam.SuspendLayout();
            this.grpModle.SuspendLayout();
            this.numInterval.BeginInit();
            base.SuspendLayout();
            base.grpCar.Size = new Size(364, 116);
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 247);
            base.pnlBtn.Size = new Size(364, 28);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpOilParam.Controls.Add(this.lblModle);
            this.grpOilParam.Controls.Add(this.grpModle);
            this.grpOilParam.Controls.Add(this.lblInterval);
            this.grpOilParam.Controls.Add(this.numInterval);
            this.grpOilParam.Controls.Add(this.lblMinute);
            this.grpOilParam.Controls.Add(this.label2);
            this.grpOilParam.Dock = DockStyle.Top;
            this.grpOilParam.Location = new System.Drawing.Point(5, 121);
            this.grpOilParam.Name = "grpOilParam";
            this.grpOilParam.Size = new Size(364, 126);
            this.grpOilParam.TabIndex = 1;
            this.grpOilParam.TabStop = false;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 98);
            this.label2.Name = "label2";
            this.label2.Size = new Size(275, 12);
            this.label2.TabIndex = 6;
            this.label2.Tag = "9999";
            this.label2.Text = "注：上传模式为上传，且时间间隔为0表示查询油量";
            this.lblModle.AutoSize = true;
            this.lblModle.Location = new System.Drawing.Point(50, 27);
            this.lblModle.Name = "lblModle";
            this.lblModle.Size = new Size(65, 12);
            this.lblModle.TabIndex = 0;
            this.lblModle.Text = "上传模式：";
            this.grpModle.Controls.Add(this.rdoNoUpload);
            this.grpModle.Controls.Add(this.rdoUpload);
            this.grpModle.Location = new System.Drawing.Point(122, 8);
            this.grpModle.Name = "grpModle";
            this.grpModle.Size = new Size(162, 44);
            this.grpModle.TabIndex = 0;
            this.grpModle.TabStop = false;
            this.rdoNoUpload.AutoSize = true;
            this.rdoNoUpload.Checked = true;
            this.rdoNoUpload.Location = new System.Drawing.Point(7, 17);
            this.rdoNoUpload.Name = "rdoNoUpload";
            this.rdoNoUpload.Size = new Size(59, 16);
            this.rdoNoUpload.TabIndex = 0;
            this.rdoNoUpload.TabStop = true;
            this.rdoNoUpload.Text = "不上传";
            this.rdoNoUpload.UseVisualStyleBackColor = true;
            this.rdoUpload.AutoSize = true;
            this.rdoUpload.Location = new System.Drawing.Point(81, 17);
            this.rdoUpload.Name = "rdoUpload";
            this.rdoUpload.Size = new Size(47, 16);
            this.rdoUpload.TabIndex = 1;
            this.rdoUpload.Text = "上传";
            this.rdoUpload.UseVisualStyleBackColor = true;
            this.rdoUpload.CheckedChanged += new EventHandler(this.rdoUpload_CheckedChanged);
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(50, 69);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new Size(65, 12);
            this.lblInterval.TabIndex = 0;
            this.lblInterval.Text = "间隔时间：";
            this.numInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numInterval.Enabled = false;
            this.numInterval.Location = new System.Drawing.Point(122, 65);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numInterval.Maximum = new decimal(bits);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new Size(161, 21);
            this.numInterval.TabIndex = 1;
            this.lblMinute.AutoSize = true;
            this.lblMinute.Location = new System.Drawing.Point(295, 69);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new Size(29, 12);
            this.lblMinute.TabIndex = 3;
            this.lblMinute.Tag = "；";
            this.lblMinute.Text = "分钟";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(374, 280);
            base.Controls.Add(this.grpOilParam);
            base.Name = "m2mOilReport";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpOilParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpOilParam.ResumeLayout(false);
            this.grpOilParam.PerformLayout();
            this.grpModle.ResumeLayout(false);
            this.grpModle.PerformLayout();
            this.numInterval.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpModle;
        private GroupBox grpOilParam;
        private Label label2;
        private Label lblInterval;
        private Label lblMinute;
        private Label lblModle;
        private NumericUpDown numInterval;
        private RadioButton rdoNoUpload;
        private RadioButton rdoUpload;
    }
}