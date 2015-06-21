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
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class db44SetRemoteInit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(db44SetRemoteInit));
            this.grpInit = new System.Windows.Forms.GroupBox();
            this.pnlSetParam = new System.Windows.Forms.Panel();
            this.chkCarId = new System.Windows.Forms.CheckBox();
            this.txtCarId = new System.Windows.Forms.TextBox();
            this.chkCarNum = new System.Windows.Forms.CheckBox();
            this.txtCarNum = new System.Windows.Forms.TextBox();
            this.chkCarType = new System.Windows.Forms.CheckBox();
            this.txtCarType = new System.Windows.Forms.TextBox();
            this.chkDriveCode = new System.Windows.Forms.CheckBox();
            this.txtDriveCode = new System.Windows.Forms.TextBox();
            this.chkDriveCId = new System.Windows.Forms.CheckBox();
            this.txtDriveCId = new System.Windows.Forms.TextBox();
            this.chkInitDate = new System.Windows.Forms.CheckBox();
            this.dtpInitDate = new System.Windows.Forms.DateTimePicker();
            this.chkRealTime = new System.Windows.Forms.CheckBox();
            this.lblRealTime = new System.Windows.Forms.Label();
            this.chkAdminCenter = new System.Windows.Forms.CheckBox();
            this.txtAdminCenter = new WinFormsUI.Controls.IPAddressTextBox();
            this.numAdminCenter = new System.Windows.Forms.NumericUpDown();
            this.chkBakCenter = new System.Windows.Forms.CheckBox();
            this.txtBakCenter = new WinFormsUI.Controls.IPAddressTextBox();
            this.numBakCenter = new System.Windows.Forms.NumericUpDown();
            this.chkMessageCenter = new System.Windows.Forms.CheckBox();
            this.txtMessageCenter = new System.Windows.Forms.TextBox();
            this.chkMessageNum1 = new System.Windows.Forms.CheckBox();
            this.txtMessageNum1 = new System.Windows.Forms.TextBox();
            this.chkMessageNum2 = new System.Windows.Forms.CheckBox();
            this.txtMessageNum2 = new System.Windows.Forms.TextBox();
            this.chkSpeedType = new System.Windows.Forms.CheckBox();
            this.cmbSpeedType = new WinFormsUI.Controls.ComBox();
            this.chkGpsSwitch = new System.Windows.Forms.CheckBox();
            this.cmbGpsSwitch = new WinFormsUI.Controls.ComBox();
            this.pnlReadOnly = new System.Windows.Forms.Panel();
            this.chkParam = new System.Windows.Forms.CheckBox();
            this.chkVersion = new System.Windows.Forms.CheckBox();
            this.chkMIDId = new System.Windows.Forms.CheckBox();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpInit.SuspendLayout();
            this.pnlSetParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdminCenter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBakCenter)).BeginInit();
            this.pnlReadOnly.SuspendLayout();
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
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 646);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpInit
            // 
            this.grpInit.AutoSize = true;
            this.grpInit.Controls.Add(this.pnlSetParam);
            this.grpInit.Controls.Add(this.pnlReadOnly);
            this.grpInit.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInit.Location = new System.Drawing.Point(5, 121);
            this.grpInit.Name = "grpInit";
            this.grpInit.Size = new System.Drawing.Size(363, 525);
            this.grpInit.TabIndex = 1;
            this.grpInit.TabStop = false;
            this.grpInit.Text = "参数";
            // 
            // pnlSetParam
            // 
            this.pnlSetParam.Controls.Add(this.chkCarId);
            this.pnlSetParam.Controls.Add(this.txtCarId);
            this.pnlSetParam.Controls.Add(this.chkCarNum);
            this.pnlSetParam.Controls.Add(this.txtCarNum);
            this.pnlSetParam.Controls.Add(this.chkCarType);
            this.pnlSetParam.Controls.Add(this.txtCarType);
            this.pnlSetParam.Controls.Add(this.chkDriveCode);
            this.pnlSetParam.Controls.Add(this.txtDriveCode);
            this.pnlSetParam.Controls.Add(this.chkDriveCId);
            this.pnlSetParam.Controls.Add(this.txtDriveCId);
            this.pnlSetParam.Controls.Add(this.chkInitDate);
            this.pnlSetParam.Controls.Add(this.dtpInitDate);
            this.pnlSetParam.Controls.Add(this.chkRealTime);
            this.pnlSetParam.Controls.Add(this.lblRealTime);
            this.pnlSetParam.Controls.Add(this.chkAdminCenter);
            this.pnlSetParam.Controls.Add(this.txtAdminCenter);
            this.pnlSetParam.Controls.Add(this.numAdminCenter);
            this.pnlSetParam.Controls.Add(this.chkBakCenter);
            this.pnlSetParam.Controls.Add(this.txtBakCenter);
            this.pnlSetParam.Controls.Add(this.numBakCenter);
            this.pnlSetParam.Controls.Add(this.chkMessageCenter);
            this.pnlSetParam.Controls.Add(this.txtMessageCenter);
            this.pnlSetParam.Controls.Add(this.chkMessageNum1);
            this.pnlSetParam.Controls.Add(this.txtMessageNum1);
            this.pnlSetParam.Controls.Add(this.chkMessageNum2);
            this.pnlSetParam.Controls.Add(this.txtMessageNum2);
            this.pnlSetParam.Controls.Add(this.chkSpeedType);
            this.pnlSetParam.Controls.Add(this.cmbSpeedType);
            this.pnlSetParam.Controls.Add(this.chkGpsSwitch);
            this.pnlSetParam.Controls.Add(this.cmbGpsSwitch);
            this.pnlSetParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetParam.Location = new System.Drawing.Point(3, 17);
            this.pnlSetParam.Name = "pnlSetParam";
            this.pnlSetParam.Size = new System.Drawing.Size(357, 415);
            this.pnlSetParam.TabIndex = 3;
            // 
            // chkCarId
            // 
            this.chkCarId.AutoSize = true;
            this.chkCarId.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCarId.Checked = true;
            this.chkCarId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCarId.Location = new System.Drawing.Point(16, 3);
            this.chkCarId.Name = "chkCarId";
            this.chkCarId.Size = new System.Drawing.Size(96, 16);
            this.chkCarId.TabIndex = 0;
            this.chkCarId.Text = "车辆识别代号";
            this.chkCarId.UseVisualStyleBackColor = true;
            this.chkCarId.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkCarId.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtCarId
            // 
            this.txtCarId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarId.Location = new System.Drawing.Point(119, 1);
            this.txtCarId.MaxLength = 17;
            this.txtCarId.Name = "txtCarId";
            this.txtCarId.Size = new System.Drawing.Size(161, 21);
            this.txtCarId.TabIndex = 0;
            this.txtCarId.Tag = "；";
            // 
            // chkCarNum
            // 
            this.chkCarNum.AutoSize = true;
            this.chkCarNum.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCarNum.Checked = true;
            this.chkCarNum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCarNum.Location = new System.Drawing.Point(40, 33);
            this.chkCarNum.Name = "chkCarNum";
            this.chkCarNum.Size = new System.Drawing.Size(72, 16);
            this.chkCarNum.TabIndex = 1;
            this.chkCarNum.Text = "车牌号码";
            this.chkCarNum.UseVisualStyleBackColor = true;
            this.chkCarNum.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkCarNum.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtCarNum
            // 
            this.txtCarNum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarNum.Location = new System.Drawing.Point(119, 31);
            this.txtCarNum.MaxLength = 12;
            this.txtCarNum.Name = "txtCarNum";
            this.txtCarNum.Size = new System.Drawing.Size(161, 21);
            this.txtCarNum.TabIndex = 1;
            this.txtCarNum.Tag = "；";
            // 
            // chkCarType
            // 
            this.chkCarType.AutoSize = true;
            this.chkCarType.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCarType.Checked = true;
            this.chkCarType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCarType.Location = new System.Drawing.Point(40, 63);
            this.chkCarType.Name = "chkCarType";
            this.chkCarType.Size = new System.Drawing.Size(72, 16);
            this.chkCarType.TabIndex = 2;
            this.chkCarType.Text = "车牌分类";
            this.chkCarType.UseVisualStyleBackColor = true;
            this.chkCarType.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkCarType.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtCarType
            // 
            this.txtCarType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarType.Location = new System.Drawing.Point(119, 63);
            this.txtCarType.MaxLength = 12;
            this.txtCarType.Name = "txtCarType";
            this.txtCarType.Size = new System.Drawing.Size(161, 21);
            this.txtCarType.TabIndex = 2;
            this.txtCarType.Tag = "；";
            // 
            // chkDriveCode
            // 
            this.chkDriveCode.AutoSize = true;
            this.chkDriveCode.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDriveCode.Checked = true;
            this.chkDriveCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDriveCode.Location = new System.Drawing.Point(28, 93);
            this.chkDriveCode.Name = "chkDriveCode";
            this.chkDriveCode.Size = new System.Drawing.Size(84, 16);
            this.chkDriveCode.TabIndex = 3;
            this.chkDriveCode.Text = "驾驶员代码";
            this.chkDriveCode.UseVisualStyleBackColor = true;
            this.chkDriveCode.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkDriveCode.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtDriveCode
            // 
            this.txtDriveCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDriveCode.Location = new System.Drawing.Point(119, 91);
            this.txtDriveCode.MaxLength = 7;
            this.txtDriveCode.Name = "txtDriveCode";
            this.txtDriveCode.Size = new System.Drawing.Size(161, 21);
            this.txtDriveCode.TabIndex = 3;
            this.txtDriveCode.Tag = "；";
            this.txtDriveCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageCenter_KeyPress);
            // 
            // chkDriveCId
            // 
            this.chkDriveCId.AutoSize = true;
            this.chkDriveCId.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkDriveCId.Checked = true;
            this.chkDriveCId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDriveCId.Location = new System.Drawing.Point(40, 123);
            this.chkDriveCId.Name = "chkDriveCId";
            this.chkDriveCId.Size = new System.Drawing.Size(72, 16);
            this.chkDriveCId.TabIndex = 4;
            this.chkDriveCId.Text = "驾驶证号";
            this.chkDriveCId.UseVisualStyleBackColor = true;
            this.chkDriveCId.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkDriveCId.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtDriveCId
            // 
            this.txtDriveCId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDriveCId.Location = new System.Drawing.Point(119, 121);
            this.txtDriveCId.MaxLength = 18;
            this.txtDriveCId.Name = "txtDriveCId";
            this.txtDriveCId.Size = new System.Drawing.Size(161, 21);
            this.txtDriveCId.TabIndex = 4;
            this.txtDriveCId.Tag = "；";
            // 
            // chkInitDate
            // 
            this.chkInitDate.AutoSize = true;
            this.chkInitDate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInitDate.Checked = true;
            this.chkInitDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInitDate.Location = new System.Drawing.Point(16, 153);
            this.chkInitDate.Name = "chkInitDate";
            this.chkInitDate.Size = new System.Drawing.Size(96, 16);
            this.chkInitDate.TabIndex = 5;
            this.chkInitDate.Text = "初次安装日期";
            this.chkInitDate.UseVisualStyleBackColor = true;
            this.chkInitDate.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkInitDate.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // dtpInitDate
            // 
            this.dtpInitDate.CustomFormat = "yyyy-MM-dd";
            this.dtpInitDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInitDate.Location = new System.Drawing.Point(119, 151);
            this.dtpInitDate.Name = "dtpInitDate";
            this.dtpInitDate.Size = new System.Drawing.Size(161, 21);
            this.dtpInitDate.TabIndex = 5;
            this.dtpInitDate.Tag = "；";
            this.dtpInitDate.Value = new System.DateTime(2010, 12, 22, 0, 0, 0, 0);
            // 
            // chkRealTime
            // 
            this.chkRealTime.AutoSize = true;
            this.chkRealTime.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRealTime.Checked = true;
            this.chkRealTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRealTime.Location = new System.Drawing.Point(40, 183);
            this.chkRealTime.Name = "chkRealTime";
            this.chkRealTime.Size = new System.Drawing.Size(72, 16);
            this.chkRealTime.TabIndex = 6;
            this.chkRealTime.Text = "实时时钟";
            this.chkRealTime.UseVisualStyleBackColor = true;
            this.chkRealTime.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkRealTime.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // lblRealTime
            // 
            this.lblRealTime.AutoSize = true;
            this.lblRealTime.ForeColor = System.Drawing.Color.Red;
            this.lblRealTime.Location = new System.Drawing.Point(119, 184);
            this.lblRealTime.Name = "lblRealTime";
            this.lblRealTime.Size = new System.Drawing.Size(125, 12);
            this.lblRealTime.TabIndex = 16;
            this.lblRealTime.Tag = "9999";
            this.lblRealTime.Text = "注：数据库服务器时间";
            // 
            // chkAdminCenter
            // 
            this.chkAdminCenter.AutoSize = true;
            this.chkAdminCenter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAdminCenter.Checked = true;
            this.chkAdminCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAdminCenter.Location = new System.Drawing.Point(16, 213);
            this.chkAdminCenter.Name = "chkAdminCenter";
            this.chkAdminCenter.Size = new System.Drawing.Size(96, 16);
            this.chkAdminCenter.TabIndex = 7;
            this.chkAdminCenter.Text = "运营管理中心";
            this.chkAdminCenter.UseVisualStyleBackColor = true;
            this.chkAdminCenter.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkAdminCenter.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtAdminCenter
            // 
            this.txtAdminCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdminCenter.Location = new System.Drawing.Point(119, 211);
            this.txtAdminCenter.Margin = new System.Windows.Forms.Padding(0);
            this.txtAdminCenter.Name = "txtAdminCenter";
            this.txtAdminCenter.Size = new System.Drawing.Size(126, 21);
            this.txtAdminCenter.TabIndex = 8;
            this.txtAdminCenter.Tag = ":";
            // 
            // numAdminCenter
            // 
            this.numAdminCenter.Location = new System.Drawing.Point(248, 211);
            this.numAdminCenter.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAdminCenter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAdminCenter.Name = "numAdminCenter";
            this.numAdminCenter.Size = new System.Drawing.Size(61, 21);
            this.numAdminCenter.TabIndex = 9;
            this.numAdminCenter.Tag = "；";
            this.numAdminCenter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkBakCenter
            // 
            this.chkBakCenter.AutoSize = true;
            this.chkBakCenter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBakCenter.Checked = true;
            this.chkBakCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBakCenter.Location = new System.Drawing.Point(16, 243);
            this.chkBakCenter.Name = "chkBakCenter";
            this.chkBakCenter.Size = new System.Drawing.Size(96, 16);
            this.chkBakCenter.TabIndex = 8;
            this.chkBakCenter.Text = "备用运营中心";
            this.chkBakCenter.UseVisualStyleBackColor = true;
            this.chkBakCenter.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkBakCenter.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtBakCenter
            // 
            this.txtBakCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBakCenter.Location = new System.Drawing.Point(119, 241);
            this.txtBakCenter.Margin = new System.Windows.Forms.Padding(0);
            this.txtBakCenter.Name = "txtBakCenter";
            this.txtBakCenter.Size = new System.Drawing.Size(126, 21);
            this.txtBakCenter.TabIndex = 10;
            this.txtBakCenter.Tag = ":";
            // 
            // numBakCenter
            // 
            this.numBakCenter.Location = new System.Drawing.Point(248, 241);
            this.numBakCenter.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numBakCenter.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBakCenter.Name = "numBakCenter";
            this.numBakCenter.Size = new System.Drawing.Size(61, 21);
            this.numBakCenter.TabIndex = 11;
            this.numBakCenter.Tag = "；";
            this.numBakCenter.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // chkMessageCenter
            // 
            this.chkMessageCenter.AutoSize = true;
            this.chkMessageCenter.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMessageCenter.Checked = true;
            this.chkMessageCenter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMessageCenter.Location = new System.Drawing.Point(16, 273);
            this.chkMessageCenter.Name = "chkMessageCenter";
            this.chkMessageCenter.Size = new System.Drawing.Size(96, 16);
            this.chkMessageCenter.TabIndex = 9;
            this.chkMessageCenter.Text = "短信服务中心";
            this.chkMessageCenter.UseVisualStyleBackColor = true;
            this.chkMessageCenter.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkMessageCenter.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtMessageCenter
            // 
            this.txtMessageCenter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageCenter.Location = new System.Drawing.Point(119, 271);
            this.txtMessageCenter.MaxLength = 15;
            this.txtMessageCenter.Name = "txtMessageCenter";
            this.txtMessageCenter.Size = new System.Drawing.Size(161, 21);
            this.txtMessageCenter.TabIndex = 12;
            this.txtMessageCenter.Tag = "；";
            this.txtMessageCenter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageCenter_KeyPress);
            // 
            // chkMessageNum1
            // 
            this.chkMessageNum1.AutoSize = true;
            this.chkMessageNum1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMessageNum1.Checked = true;
            this.chkMessageNum1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMessageNum1.Location = new System.Drawing.Point(4, 303);
            this.chkMessageNum1.Name = "chkMessageNum1";
            this.chkMessageNum1.Size = new System.Drawing.Size(108, 16);
            this.chkMessageNum1.TabIndex = 10;
            this.chkMessageNum1.Text = "短信服务号码一";
            this.chkMessageNum1.UseVisualStyleBackColor = true;
            this.chkMessageNum1.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkMessageNum1.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtMessageNum1
            // 
            this.txtMessageNum1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageNum1.Location = new System.Drawing.Point(119, 301);
            this.txtMessageNum1.MaxLength = 15;
            this.txtMessageNum1.Name = "txtMessageNum1";
            this.txtMessageNum1.Size = new System.Drawing.Size(161, 21);
            this.txtMessageNum1.TabIndex = 13;
            this.txtMessageNum1.Tag = "；";
            this.txtMessageNum1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageCenter_KeyPress);
            // 
            // chkMessageNum2
            // 
            this.chkMessageNum2.AutoSize = true;
            this.chkMessageNum2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMessageNum2.Checked = true;
            this.chkMessageNum2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMessageNum2.Location = new System.Drawing.Point(4, 333);
            this.chkMessageNum2.Name = "chkMessageNum2";
            this.chkMessageNum2.Size = new System.Drawing.Size(108, 16);
            this.chkMessageNum2.TabIndex = 11;
            this.chkMessageNum2.Text = "短信服务号码二";
            this.chkMessageNum2.UseVisualStyleBackColor = true;
            this.chkMessageNum2.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkMessageNum2.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // txtMessageNum2
            // 
            this.txtMessageNum2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessageNum2.Location = new System.Drawing.Point(119, 331);
            this.txtMessageNum2.MaxLength = 15;
            this.txtMessageNum2.Name = "txtMessageNum2";
            this.txtMessageNum2.Size = new System.Drawing.Size(161, 21);
            this.txtMessageNum2.TabIndex = 14;
            this.txtMessageNum2.Tag = "；";
            this.txtMessageNum2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMessageCenter_KeyPress);
            // 
            // chkSpeedType
            // 
            this.chkSpeedType.AutoSize = true;
            this.chkSpeedType.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSpeedType.Checked = true;
            this.chkSpeedType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSpeedType.Location = new System.Drawing.Point(40, 363);
            this.chkSpeedType.Name = "chkSpeedType";
            this.chkSpeedType.Size = new System.Drawing.Size(72, 16);
            this.chkSpeedType.TabIndex = 10;
            this.chkSpeedType.Text = "速度类型";
            this.chkSpeedType.UseVisualStyleBackColor = true;
            this.chkSpeedType.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkSpeedType.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // cmbSpeedType
            // 
            this.cmbSpeedType.DisplayMember = "Display";
            this.cmbSpeedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpeedType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSpeedType.FormattingEnabled = true;
            this.cmbSpeedType.Location = new System.Drawing.Point(119, 361);
            this.cmbSpeedType.Name = "cmbSpeedType";
            this.cmbSpeedType.Size = new System.Drawing.Size(161, 20);
            this.cmbSpeedType.TabIndex = 15;
            this.cmbSpeedType.Tag = "；";
            this.cmbSpeedType.ValueMember = "Value";
            // 
            // chkGpsSwitch
            // 
            this.chkGpsSwitch.AutoSize = true;
            this.chkGpsSwitch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkGpsSwitch.Checked = true;
            this.chkGpsSwitch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGpsSwitch.Location = new System.Drawing.Point(10, 393);
            this.chkGpsSwitch.Name = "chkGpsSwitch";
            this.chkGpsSwitch.Size = new System.Drawing.Size(102, 16);
            this.chkGpsSwitch.TabIndex = 11;
            this.chkGpsSwitch.Text = "上传GPS开关量";
            this.chkGpsSwitch.UseVisualStyleBackColor = true;
            this.chkGpsSwitch.CheckedChanged += new System.EventHandler(this.chkCarId_CheckedChanged);
            this.chkGpsSwitch.CheckStateChanged += new System.EventHandler(this.chkCarId_CheckStateChanged);
            // 
            // cmbGpsSwitch
            // 
            this.cmbGpsSwitch.DisplayMember = "Display";
            this.cmbGpsSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGpsSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbGpsSwitch.FormattingEnabled = true;
            this.cmbGpsSwitch.Location = new System.Drawing.Point(119, 391);
            this.cmbGpsSwitch.Name = "cmbGpsSwitch";
            this.cmbGpsSwitch.Size = new System.Drawing.Size(161, 20);
            this.cmbGpsSwitch.TabIndex = 15;
            this.cmbGpsSwitch.Tag = "；";
            this.cmbGpsSwitch.ValueMember = "Value";
            // 
            // pnlReadOnly
            // 
            this.pnlReadOnly.Controls.Add(this.chkParam);
            this.pnlReadOnly.Controls.Add(this.chkVersion);
            this.pnlReadOnly.Controls.Add(this.chkMIDId);
            this.pnlReadOnly.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlReadOnly.Location = new System.Drawing.Point(3, 432);
            this.pnlReadOnly.Name = "pnlReadOnly";
            this.pnlReadOnly.Size = new System.Drawing.Size(357, 90);
            this.pnlReadOnly.TabIndex = 1;
            // 
            // chkParam
            // 
            this.chkParam.AutoSize = true;
            this.chkParam.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkParam.Checked = true;
            this.chkParam.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParam.Location = new System.Drawing.Point(40, 67);
            this.chkParam.Name = "chkParam";
            this.chkParam.Size = new System.Drawing.Size(72, 16);
            this.chkParam.TabIndex = 2;
            this.chkParam.Text = "特征系数";
            this.chkParam.UseVisualStyleBackColor = true;
            // 
            // chkVersion
            // 
            this.chkVersion.AutoSize = true;
            this.chkVersion.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkVersion.Checked = true;
            this.chkVersion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVersion.Location = new System.Drawing.Point(28, 38);
            this.chkVersion.Name = "chkVersion";
            this.chkVersion.Size = new System.Drawing.Size(84, 16);
            this.chkVersion.TabIndex = 1;
            this.chkVersion.Text = "固件版本号";
            this.chkVersion.UseVisualStyleBackColor = true;
            // 
            // chkMIDId
            // 
            this.chkMIDId.AutoSize = true;
            this.chkMIDId.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMIDId.Checked = true;
            this.chkMIDId.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMIDId.Location = new System.Drawing.Point(34, 8);
            this.chkMIDId.Name = "chkMIDId";
            this.chkMIDId.Size = new System.Drawing.Size(78, 16);
            this.chkMIDId.TabIndex = 0;
            this.chkMIDId.Text = "MDT主机ID";
            this.chkMIDId.UseVisualStyleBackColor = true;
            // 
            // db44SetRemoteInit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(373, 679);
            this.Controls.Add(this.grpInit);
            this.Name = "db44SetRemoteInit";
            this.Text = "远程参数设置";
            this.Load += new System.EventHandler(this.db44SetRemoteInit_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpInit, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpInit.ResumeLayout(false);
            this.pnlSetParam.ResumeLayout(false);
            this.pnlSetParam.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAdminCenter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBakCenter)).EndInit();
            this.pnlReadOnly.ResumeLayout(false);
            this.pnlReadOnly.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private CheckBox chkAdminCenter;
        private CheckBox chkBakCenter;
        private CheckBox chkCarId;
        private CheckBox chkCarNum;
        private CheckBox chkCarType;
        private CheckBox chkDriveCId;
        private CheckBox chkDriveCode;
        private CheckBox chkGpsSwitch;
        private CheckBox chkInitDate;
        private CheckBox chkMessageCenter;
        private CheckBox chkMessageNum1;
        private CheckBox chkMessageNum2;
        private CheckBox chkMIDId;
        private CheckBox chkParam;
        private CheckBox chkRealTime;
        private CheckBox chkSpeedType;
        private CheckBox chkVersion;
        private ComBox cmbGpsSwitch;
        private ComBox cmbSpeedType;
        private DateTimePicker dtpInitDate;
        private GroupBox grpInit;
        private Label lblRealTime;
        private NumericUpDown numAdminCenter;
        private NumericUpDown numBakCenter;
        private Panel pnlReadOnly;
        private Panel pnlSetParam;
        private IPAddressTextBox txtAdminCenter;
        private IPAddressTextBox txtBakCenter;
        private TextBox txtCarId;
        private TextBox txtCarNum;
        private TextBox txtCarType;
        private TextBox txtDriveCId;
        private TextBox txtDriveCode;
        private TextBox txtMessageCenter;
        private TextBox txtMessageNum1;
        private TextBox txtMessageNum2;
    }
}