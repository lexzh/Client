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
    using WinFormsUI.Controls;

    partial class m2mSetSpeedInTimeAlarm
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
            new ComponentResourceManager(typeof(m2mSetSpeedInTimeAlarm));
            this.grpMileageParam = new GroupBox();
            this.label1 = new Label();
            this.lblIndex = new Label();
            this.cmbSetIndex = new ComBox();
            this.lblSpeed = new Label();
            this.numSpeed = new NumericUpDown();
            this.lblMeter = new Label();
            this.lblStartTime = new Label();
            this.dtpStartTime = new DateTimePicker();
            this.lblEndTime = new Label();
            this.dtpEndTime = new DateTimePicker();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpMileageParam.SuspendLayout();
            this.numSpeed.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 239);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpMileageParam.Controls.Add(this.lblIndex);
            this.grpMileageParam.Controls.Add(this.cmbSetIndex);
            this.grpMileageParam.Controls.Add(this.lblSpeed);
            this.grpMileageParam.Controls.Add(this.numSpeed);
            this.grpMileageParam.Controls.Add(this.lblMeter);
            this.grpMileageParam.Controls.Add(this.label1);
            this.grpMileageParam.Controls.Add(this.lblStartTime);
            this.grpMileageParam.Controls.Add(this.dtpStartTime);
            this.grpMileageParam.Controls.Add(this.lblEndTime);
            this.grpMileageParam.Controls.Add(this.dtpEndTime);
            this.grpMileageParam.Dock = DockStyle.Top;
            this.grpMileageParam.Location = new System.Drawing.Point(5, 121);
            this.grpMileageParam.Name = "grpMileageParam";
            this.grpMileageParam.Size = new Size(363, 118);
            this.grpMileageParam.TabIndex = 1;
            this.grpMileageParam.TabStop = false;
            this.grpMileageParam.Text = "超速报警参数";
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 62);
            this.label1.Name = "label1";
            this.label1.Size = new Size(167, 12);
            this.label1.TabIndex = 0;
            this.label1.Tag = "9999";
            this.label1.Text = "(速度为0，表示取消超速报警)";
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(62, 17);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new Size(53, 12);
            this.lblIndex.TabIndex = 0;
            this.lblIndex.Text = "索引号：";
            this.cmbSetIndex.DisplayMember = "Display";
            this.cmbSetIndex.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSetIndex.FlatStyle = FlatStyle.Flat;
            this.cmbSetIndex.FormattingEnabled = true;
            this.cmbSetIndex.Location = new System.Drawing.Point(122, 13);
            this.cmbSetIndex.Name = "cmbSetIndex";
            this.cmbSetIndex.Size = new Size(161, 20);
            this.cmbSetIndex.TabIndex = 0;
            this.cmbSetIndex.Tag = "；";
            this.cmbSetIndex.ValueMember = "Value";
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(26, 41);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new Size(89, 12);
            this.lblSpeed.TabIndex = 0;
            this.lblSpeed.Text = "超速报警速度：";
            this.numSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSpeed.Location = new System.Drawing.Point(122, 37);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numSpeed.Maximum = new decimal(bits);
            this.numSpeed.Name = "numSpeed";
            this.numSpeed.Size = new Size(161, 21);
            this.numSpeed.TabIndex = 1;
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(289, 41);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new Size(59, 12);
            this.lblMeter.TabIndex = 0;
            this.lblMeter.Tag = "；";
            this.lblMeter.Text = "公里/小时";
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(50, 90);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 2;
            this.lblStartTime.Text = "起始时间：";
            this.dtpStartTime.CustomFormat = "HH:mm";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(122, 86);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new Size(57, 21);
            this.dtpStartTime.TabIndex = 2;
            this.dtpStartTime.Tag = "；";
            this.dtpStartTime.Value = new DateTime(2010, 8, 6, 0, 0, 0, 0);
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(183, 90);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 3;
            this.lblEndTime.Text = "结束时间：";
            this.dtpEndTime.CustomFormat = "HH:mm";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(253, 86);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new Size(57, 21);
            this.dtpEndTime.TabIndex = 3;
            this.dtpEndTime.Tag = "；";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 272);
            base.Controls.Add(this.grpMileageParam);
            base.Name = "m2mSetSpeedInTimeAlarm";
            this.Text = "时间段内超速报警设置";
            base.Load += new EventHandler(this.m2mSetSpeedInTimeAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpMileageParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpMileageParam.ResumeLayout(false);
            this.grpMileageParam.PerformLayout();
            this.numSpeed.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbSetIndex;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private GroupBox grpMileageParam;
        private Label label1;
        private Label lblEndTime;
        private Label lblIndex;
        private Label lblMeter;
        private Label lblSpeed;
        private Label lblStartTime;
        private NumericUpDown numSpeed;
    }
}