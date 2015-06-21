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

    partial class m2mMeter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(m2mMeter));
            this.grpMeter = new System.Windows.Forms.GroupBox();
            this.pnlQueryMeter = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.pnlSetMeter = new System.Windows.Forms.Panel();
            this.lblMeterStart = new System.Windows.Forms.Label();
            this.pnlMeterStart = new System.Windows.Forms.Panel();
            this.rbtnOpen = new System.Windows.Forms.RadioButton();
            this.rbtnClose = new System.Windows.Forms.RadioButton();
            this.lblCarReport = new System.Windows.Forms.Label();
            this.cmbCarReport = new WinFormsUI.Controls.ComBox();
            this.lblDataUpdown = new System.Windows.Forms.Label();
            this.cmbDataUpdown = new WinFormsUI.Controls.ComBox();
            this.lblParams = new System.Windows.Forms.Label();
            this.numParams = new System.Windows.Forms.NumericUpDown();
            this.lblParamsUnit = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpMeter.SuspendLayout();
            this.pnlQueryMeter.SuspendLayout();
            this.pnlSetMeter.SuspendLayout();
            this.pnlMeterStart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParams)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(265, 2);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(180, 2);
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(354, 116);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 359);
            this.pnlBtn.Size = new System.Drawing.Size(354, 28);
            // 
            // grpMeter
            // 
            this.grpMeter.AutoSize = true;
            this.grpMeter.Controls.Add(this.pnlQueryMeter);
            this.grpMeter.Controls.Add(this.pnlSetMeter);
            this.grpMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpMeter.Location = new System.Drawing.Point(5, 121);
            this.grpMeter.Name = "grpMeter";
            this.grpMeter.Size = new System.Drawing.Size(354, 238);
            this.grpMeter.TabIndex = 11;
            this.grpMeter.TabStop = false;
            this.grpMeter.Text = "计价器参数";
            // 
            // pnlQueryMeter
            // 
            this.pnlQueryMeter.Controls.Add(this.lblStartDate);
            this.pnlQueryMeter.Controls.Add(this.dtpStartDate);
            this.pnlQueryMeter.Controls.Add(this.lblStartTime);
            this.pnlQueryMeter.Controls.Add(this.dtpStartTime);
            this.pnlQueryMeter.Controls.Add(this.lblEndDate);
            this.pnlQueryMeter.Controls.Add(this.dtpEndDate);
            this.pnlQueryMeter.Controls.Add(this.lblEndTime);
            this.pnlQueryMeter.Controls.Add(this.dtpEndTime);
            this.pnlQueryMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlQueryMeter.Location = new System.Drawing.Point(3, 129);
            this.pnlQueryMeter.Name = "pnlQueryMeter";
            this.pnlQueryMeter.Size = new System.Drawing.Size(348, 106);
            this.pnlQueryMeter.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 6);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "开始日期：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(121, 2);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(161, 21);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.Tag = "；";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(47, 33);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(121, 29);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(161, 21);
            this.dtpStartTime.TabIndex = 9;
            this.dtpStartTime.TabStop = false;
            this.dtpStartTime.Tag = "；";
            this.dtpStartTime.Value = new System.DateTime(2010, 8, 5, 0, 0, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(47, 60);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(65, 12);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(121, 56);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(161, 21);
            this.dtpEndDate.TabIndex = 10;
            this.dtpEndDate.Tag = "；";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(47, 87);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 12);
            this.lblEndTime.TabIndex = 4;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(121, 83);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(161, 21);
            this.dtpEndTime.TabIndex = 11;
            this.dtpEndTime.Tag = "；";
            // 
            // pnlSetMeter
            // 
            this.pnlSetMeter.Controls.Add(this.lblMeterStart);
            this.pnlSetMeter.Controls.Add(this.pnlMeterStart);
            this.pnlSetMeter.Controls.Add(this.lblCarReport);
            this.pnlSetMeter.Controls.Add(this.cmbCarReport);
            this.pnlSetMeter.Controls.Add(this.lblDataUpdown);
            this.pnlSetMeter.Controls.Add(this.cmbDataUpdown);
            this.pnlSetMeter.Controls.Add(this.lblParams);
            this.pnlSetMeter.Controls.Add(this.numParams);
            this.pnlSetMeter.Controls.Add(this.lblParamsUnit);
            this.pnlSetMeter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetMeter.Location = new System.Drawing.Point(3, 17);
            this.pnlSetMeter.Name = "pnlSetMeter";
            this.pnlSetMeter.Size = new System.Drawing.Size(348, 112);
            this.pnlSetMeter.TabIndex = 0;
            // 
            // lblMeterStart
            // 
            this.lblMeterStart.AutoSize = true;
            this.lblMeterStart.Location = new System.Drawing.Point(35, 9);
            this.lblMeterStart.Name = "lblMeterStart";
            this.lblMeterStart.Size = new System.Drawing.Size(77, 12);
            this.lblMeterStart.TabIndex = 0;
            this.lblMeterStart.Text = "计价器开关：";
            // 
            // pnlMeterStart
            // 
            this.pnlMeterStart.Controls.Add(this.rbtnOpen);
            this.pnlMeterStart.Controls.Add(this.rbtnClose);
            this.pnlMeterStart.Location = new System.Drawing.Point(119, 4);
            this.pnlMeterStart.Name = "pnlMeterStart";
            this.pnlMeterStart.Size = new System.Drawing.Size(161, 21);
            this.pnlMeterStart.TabIndex = 1;
            this.pnlMeterStart.Tag = "；";
            // 
            // rbtnOpen
            // 
            this.rbtnOpen.AutoSize = true;
            this.rbtnOpen.Checked = true;
            this.rbtnOpen.Location = new System.Drawing.Point(19, 3);
            this.rbtnOpen.Name = "rbtnOpen";
            this.rbtnOpen.Size = new System.Drawing.Size(47, 16);
            this.rbtnOpen.TabIndex = 0;
            this.rbtnOpen.TabStop = true;
            this.rbtnOpen.Text = "打开";
            this.rbtnOpen.UseVisualStyleBackColor = true;
            // 
            // rbtnClose
            // 
            this.rbtnClose.AutoSize = true;
            this.rbtnClose.Location = new System.Drawing.Point(93, 3);
            this.rbtnClose.Name = "rbtnClose";
            this.rbtnClose.Size = new System.Drawing.Size(47, 16);
            this.rbtnClose.TabIndex = 1;
            this.rbtnClose.TabStop = true;
            this.rbtnClose.Text = "关闭";
            this.rbtnClose.UseVisualStyleBackColor = true;
            // 
            // lblCarReport
            // 
            this.lblCarReport.AutoSize = true;
            this.lblCarReport.Location = new System.Drawing.Point(35, 35);
            this.lblCarReport.Name = "lblCarReport";
            this.lblCarReport.Size = new System.Drawing.Size(77, 12);
            this.lblCarReport.TabIndex = 2;
            this.lblCarReport.Text = "空重车汇报：";
            // 
            // cmbCarReport
            // 
            this.cmbCarReport.DisplayMember = "Display";
            this.cmbCarReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCarReport.FormattingEnabled = true;
            this.cmbCarReport.Location = new System.Drawing.Point(122, 31);
            this.cmbCarReport.Name = "cmbCarReport";
            this.cmbCarReport.Size = new System.Drawing.Size(161, 20);
            this.cmbCarReport.TabIndex = 5;
            this.cmbCarReport.Tag = "；";
            this.cmbCarReport.ValueMember = "Value";
            // 
            // lblDataUpdown
            // 
            this.lblDataUpdown.AutoSize = true;
            this.lblDataUpdown.Location = new System.Drawing.Point(23, 61);
            this.lblDataUpdown.Name = "lblDataUpdown";
            this.lblDataUpdown.Size = new System.Drawing.Size(89, 12);
            this.lblDataUpdown.TabIndex = 3;
            this.lblDataUpdown.Text = "数据上传设置：";
            // 
            // cmbDataUpdown
            // 
            this.cmbDataUpdown.DisplayMember = "Display";
            this.cmbDataUpdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDataUpdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDataUpdown.FormattingEnabled = true;
            this.cmbDataUpdown.Location = new System.Drawing.Point(122, 57);
            this.cmbDataUpdown.Name = "cmbDataUpdown";
            this.cmbDataUpdown.Size = new System.Drawing.Size(161, 20);
            this.cmbDataUpdown.TabIndex = 6;
            this.cmbDataUpdown.Tag = "；";
            this.cmbDataUpdown.ValueMember = "Value";
            this.cmbDataUpdown.SelectedValueChanged += new System.EventHandler(this.cmbDataUpdown_SelectedValueChanged);
            // 
            // lblParams
            // 
            this.lblParams.Location = new System.Drawing.Point(25, 88);
            this.lblParams.Name = "lblParams";
            this.lblParams.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblParams.Size = new System.Drawing.Size(87, 11);
            this.lblParams.TabIndex = 4;
            this.lblParams.Text = "时间间隔：";
            this.lblParams.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // numParams
            // 
            this.numParams.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numParams.Location = new System.Drawing.Point(122, 85);
            this.numParams.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numParams.Name = "numParams";
            this.numParams.Size = new System.Drawing.Size(161, 21);
            this.numParams.TabIndex = 9;
            this.numParams.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblParamsUnit
            // 
            this.lblParamsUnit.AutoSize = true;
            this.lblParamsUnit.Location = new System.Drawing.Point(289, 88);
            this.lblParamsUnit.Name = "lblParamsUnit";
            this.lblParamsUnit.Size = new System.Drawing.Size(29, 12);
            this.lblParamsUnit.TabIndex = 8;
            this.lblParamsUnit.Tag = "；";
            this.lblParamsUnit.Text = "分钟";
            // 
            // m2mMeter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(364, 395);
            this.Controls.Add(this.grpMeter);
            this.Name = "m2mMeter";
            this.Text = "计价器";
            this.Load += new System.EventHandler(this.m2mMeter_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpMeter, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpMeter.ResumeLayout(false);
            this.pnlQueryMeter.ResumeLayout(false);
            this.pnlQueryMeter.PerformLayout();
            this.pnlSetMeter.ResumeLayout(false);
            this.pnlSetMeter.PerformLayout();
            this.pnlMeterStart.ResumeLayout(false);
            this.pnlMeterStart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numParams)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private ComBox cmbCarReport;
        private ComBox cmbDataUpdown;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpStartTime;
        private GroupBox grpMeter;
        private Label lblCarReport;
        private Label lblDataUpdown;
        private Label lblEndDate;
        private Label lblEndTime;
        private Label lblMeterStart;
        private Label lblParams;
        private Label lblParamsUnit;
        private Label lblStartDate;
        private Label lblStartTime;
        private NumericUpDown numParams;
        private Panel pnlMeterStart;
        private Panel pnlQueryMeter;
        private Panel pnlSetMeter;
        private RadioButton rbtnClose;
        private RadioButton rbtnOpen;
    }
}