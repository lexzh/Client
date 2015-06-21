namespace Client.DB44
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class db44AccidentData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(db44AccidentData));
            this.grpWatchProperty = new System.Windows.Forms.GroupBox();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblDotCnt = new System.Windows.Forms.Label();
            this.numDotCnt = new System.Windows.Forms.NumericUpDown();
            this.lblDotMeter = new System.Windows.Forms.Label();
            this.pnlEndTime = new System.Windows.Forms.Panel();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.pnlBeginTime = new System.Windows.Forms.Panel();
            this.lblBeginDate = new System.Windows.Forms.Label();
            this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
            this.lblBeginTime = new System.Windows.Forms.Label();
            this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
            this.pnlAccidentData = new System.Windows.Forms.Panel();
            this.lblViewType = new System.Windows.Forms.Label();
            this.cmbViewType = new WinFormsUI.Controls.ComBox();
            this.lblStopIndex = new System.Windows.Forms.Label();
            this.numStopIndex = new System.Windows.Forms.NumericUpDown();
            this.lblStopIndexMeter = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDotCnt)).BeginInit();
            this.pnlEndTime.SuspendLayout();
            this.pnlBeginTime.SuspendLayout();
            this.pnlAccidentData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.TabIndex = 0;
            // 
            // cmbType
            // 
            this.cmbType.TabIndex = 1;
            // 
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // lblPassword
            // 
            this.lblPassword.TabIndex = 4;
            // 
            // lblType
            // 
            this.lblType.TabIndex = 0;
            // 
            // lblValue
            // 
            this.lblValue.TabIndex = 2;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 342);
            this.pnlBtn.TabIndex = 2;
            // 
            // txtCarNo
            // 
            this.txtCarNo.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.TabIndex = 5;
            // 
            // grpWatchProperty
            // 
            this.grpWatchProperty.AutoSize = true;
            this.grpWatchProperty.Controls.Add(this.pnlHistory);
            this.grpWatchProperty.Controls.Add(this.pnlEndTime);
            this.grpWatchProperty.Controls.Add(this.pnlBeginTime);
            this.grpWatchProperty.Controls.Add(this.pnlAccidentData);
            this.grpWatchProperty.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new System.Drawing.Size(363, 221);
            this.grpWatchProperty.TabIndex = 1;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            // 
            // pnlHistory
            // 
            this.pnlHistory.Controls.Add(this.lblDotCnt);
            this.pnlHistory.Controls.Add(this.numDotCnt);
            this.pnlHistory.Controls.Add(this.lblDotMeter);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHistory.Location = new System.Drawing.Point(3, 187);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Size = new System.Drawing.Size(357, 31);
            this.pnlHistory.TabIndex = 3;
            // 
            // lblDotCnt
            // 
            this.lblDotCnt.AutoSize = true;
            this.lblDotCnt.Location = new System.Drawing.Point(71, 8);
            this.lblDotCnt.Name = "lblDotCnt";
            this.lblDotCnt.Size = new System.Drawing.Size(41, 12);
            this.lblDotCnt.TabIndex = 0;
            this.lblDotCnt.Text = "点数：";
            // 
            // numDotCnt
            // 
            this.numDotCnt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDotCnt.Location = new System.Drawing.Point(119, 4);
            this.numDotCnt.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numDotCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDotCnt.Name = "numDotCnt";
            this.numDotCnt.Size = new System.Drawing.Size(161, 21);
            this.numDotCnt.TabIndex = 2;
            this.numDotCnt.Tag = "；";
            this.numDotCnt.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDotMeter
            // 
            this.lblDotMeter.AutoSize = true;
            this.lblDotMeter.Location = new System.Drawing.Point(286, 8);
            this.lblDotMeter.Name = "lblDotMeter";
            this.lblDotMeter.Size = new System.Drawing.Size(53, 12);
            this.lblDotMeter.TabIndex = 5;
            this.lblDotMeter.Tag = "9999";
            this.lblDotMeter.Text = "(1～255)";
            // 
            // pnlEndTime
            // 
            this.pnlEndTime.Controls.Add(this.lblEndDate);
            this.pnlEndTime.Controls.Add(this.dtpEndDate);
            this.pnlEndTime.Controls.Add(this.lblEndTime);
            this.pnlEndTime.Controls.Add(this.dtpEndTime);
            this.pnlEndTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlEndTime.Location = new System.Drawing.Point(3, 129);
            this.pnlEndTime.Name = "pnlEndTime";
            this.pnlEndTime.Size = new System.Drawing.Size(357, 58);
            this.pnlEndTime.TabIndex = 3;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(47, 7);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(65, 12);
            this.lblEndDate.TabIndex = 1;
            this.lblEndDate.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(119, 3);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowUpDown = true;
            this.dtpEndDate.Size = new System.Drawing.Size(161, 21);
            this.dtpEndDate.TabIndex = 3;
            this.dtpEndDate.Tag = "；";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(47, 34);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 12);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(119, 30);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(161, 21);
            this.dtpEndTime.TabIndex = 3;
            this.dtpEndTime.Tag = "；";
            // 
            // pnlBeginTime
            // 
            this.pnlBeginTime.Controls.Add(this.lblBeginDate);
            this.pnlBeginTime.Controls.Add(this.dtpBeginDate);
            this.pnlBeginTime.Controls.Add(this.lblBeginTime);
            this.pnlBeginTime.Controls.Add(this.dtpBeginTime);
            this.pnlBeginTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlBeginTime.Location = new System.Drawing.Point(3, 73);
            this.pnlBeginTime.Name = "pnlBeginTime";
            this.pnlBeginTime.Size = new System.Drawing.Size(357, 56);
            this.pnlBeginTime.TabIndex = 4;
            // 
            // lblBeginDate
            // 
            this.lblBeginDate.AutoSize = true;
            this.lblBeginDate.Location = new System.Drawing.Point(47, 7);
            this.lblBeginDate.Name = "lblBeginDate";
            this.lblBeginDate.Size = new System.Drawing.Size(65, 12);
            this.lblBeginDate.TabIndex = 1;
            this.lblBeginDate.Text = "起始日期：";
            // 
            // dtpBeginDate
            // 
            this.dtpBeginDate.CustomFormat = "yyyy-MM-dd";
            this.dtpBeginDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginDate.Location = new System.Drawing.Point(119, 3);
            this.dtpBeginDate.Name = "dtpBeginDate";
            this.dtpBeginDate.ShowUpDown = true;
            this.dtpBeginDate.Size = new System.Drawing.Size(161, 21);
            this.dtpBeginDate.TabIndex = 3;
            this.dtpBeginDate.Tag = "；";
            // 
            // lblBeginTime
            // 
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(47, 34);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new System.Drawing.Size(65, 12);
            this.lblBeginTime.TabIndex = 1;
            this.lblBeginTime.Text = "起始时间：";
            // 
            // dtpBeginTime
            // 
            this.dtpBeginTime.CustomFormat = "HH:mm:ss";
            this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(119, 30);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.ShowUpDown = true;
            this.dtpBeginTime.Size = new System.Drawing.Size(161, 21);
            this.dtpBeginTime.TabIndex = 4;
            this.dtpBeginTime.Tag = "；";
            this.dtpBeginTime.Value = new System.DateTime(2009, 10, 10, 0, 0, 0, 0);
            // 
            // pnlAccidentData
            // 
            this.pnlAccidentData.Controls.Add(this.lblViewType);
            this.pnlAccidentData.Controls.Add(this.cmbViewType);
            this.pnlAccidentData.Controls.Add(this.lblStopIndex);
            this.pnlAccidentData.Controls.Add(this.numStopIndex);
            this.pnlAccidentData.Controls.Add(this.lblStopIndexMeter);
            this.pnlAccidentData.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAccidentData.Location = new System.Drawing.Point(3, 17);
            this.pnlAccidentData.Name = "pnlAccidentData";
            this.pnlAccidentData.Size = new System.Drawing.Size(357, 56);
            this.pnlAccidentData.TabIndex = 2;
            // 
            // lblViewType
            // 
            this.lblViewType.AutoSize = true;
            this.lblViewType.Location = new System.Drawing.Point(47, 9);
            this.lblViewType.Name = "lblViewType";
            this.lblViewType.Size = new System.Drawing.Size(65, 12);
            this.lblViewType.TabIndex = 5;
            this.lblViewType.Text = "查询类型：";
            // 
            // cmbViewType
            // 
            this.cmbViewType.DisplayMember = "Display";
            this.cmbViewType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbViewType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbViewType.Location = new System.Drawing.Point(119, 5);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new System.Drawing.Size(161, 20);
            this.cmbViewType.TabIndex = 6;
            this.cmbViewType.Tag = "；";
            this.cmbViewType.ValueMember = "Value";
            this.cmbViewType.SelectedIndexChanged += new System.EventHandler(this.cmbViewType_SelectedIndexChanged);
            // 
            // lblStopIndex
            // 
            this.lblStopIndex.AutoSize = true;
            this.lblStopIndex.Location = new System.Drawing.Point(47, 35);
            this.lblStopIndex.Name = "lblStopIndex";
            this.lblStopIndex.Size = new System.Drawing.Size(65, 12);
            this.lblStopIndex.TabIndex = 0;
            this.lblStopIndex.Text = "停车序号：";
            // 
            // numStopIndex
            // 
            this.numStopIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numStopIndex.Location = new System.Drawing.Point(119, 31);
            this.numStopIndex.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numStopIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numStopIndex.Name = "numStopIndex";
            this.numStopIndex.Size = new System.Drawing.Size(161, 21);
            this.numStopIndex.TabIndex = 2;
            this.numStopIndex.Tag = "；";
            this.numStopIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblStopIndexMeter
            // 
            this.lblStopIndexMeter.AutoSize = true;
            this.lblStopIndexMeter.Location = new System.Drawing.Point(286, 35);
            this.lblStopIndexMeter.Name = "lblStopIndexMeter";
            this.lblStopIndexMeter.Size = new System.Drawing.Size(53, 12);
            this.lblStopIndexMeter.TabIndex = 4;
            this.lblStopIndexMeter.Tag = "9999";
            this.lblStopIndexMeter.Text = "(1～255)";
            // 
            // db44AccidentData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 375);
            this.Controls.Add(this.grpWatchProperty);
            this.Name = "db44AccidentData";
            this.Text = "位置查询";
            this.Load += new System.EventHandler(this.db44RealTimeReport_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpWatchProperty, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDotCnt)).EndInit();
            this.pnlEndTime.ResumeLayout(false);
            this.pnlEndTime.PerformLayout();
            this.pnlBeginTime.ResumeLayout(false);
            this.pnlBeginTime.PerformLayout();
            this.pnlAccidentData.ResumeLayout(false);
            this.pnlAccidentData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numStopIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private ComBox cmbViewType;
        private DateTimePicker dtpBeginDate;
        private DateTimePicker dtpBeginTime;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private GroupBox grpWatchProperty;
        private Label lblBeginDate;
        private Label lblBeginTime;
        private Label lblDotCnt;
        private Label lblDotMeter;
        private Label lblEndDate;
        private Label lblEndTime;
        private Label lblStopIndex;
        private Label lblStopIndexMeter;
        private Label lblViewType;
        private NumericUpDown numDotCnt;
        private NumericUpDown numStopIndex;
        private Panel pnlAccidentData;
        private Panel pnlBeginTime;
        private Panel pnlEndTime;
        private Panel pnlHistory;
    }
}