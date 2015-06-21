﻿namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using Sunisoft.IrisSkin;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class QueryCarInfo
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
            this.components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(QueryCarInfo));
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            DataGridViewCellStyle style2 = new DataGridViewCellStyle();
            this.btnClose = new Button();
            this.btnOK = new Button();
            this.dtpStartTime1 = new DateTimePicker();
            this.lblStartTime1 = new Label();
            this.dtpEndTime1 = new DateTimePicker();
            this.dtpStartDate1 = new DateTimePicker();
            this.lblEndTime1 = new Label();
            this.lblStartDate1 = new Label();
            this.dtpEndDate1 = new DateTimePicker();
            this.lblEndDate1 = new Label();
            this.grpLonLat1 = new GroupBox();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.btnAdd = new Button();
            this.lblRadius1 = new Label();
            this.btnGetLatLon1 = new Button();
            this.cmbRegionType1 = new ComBox();
            this.txtLat12 = new TextBox();
            this.txtLon12 = new TextBox();
            this.lblRegionType1 = new Label();
            this.txtLat11 = new TextBox();
            this.txtLon11 = new TextBox();
            this.lblLat12 = new Label();
            this.lblLon12 = new Label();
            this.lblLat11 = new Label();
            this.lblLon11 = new Label();
            this.pbHandle = new Panel();
            this.grpProgress = new GroupBox();
            this.pbDownLoad = new ProgressBar();
            this.panelLoading = new Panel();
            this.pbPicWait = new PictureBox();
            this.lblWaitText = new Label();
            this.CarImageList = new System.Windows.Forms.ImageList(this.components);
            this.grpSetResult = new GroupBox();
            this.dgvLonLat = new DataGridView();
            this.RegionId = new DataGridViewTextBoxColumn();
            this.RegionType = new DataGridViewTextBoxColumn();
            this.LonLat = new DataGridViewTextBoxColumn();
            this.StartTime = new DataGridViewTextBoxColumn();
            this.EndTime = new DataGridViewTextBoxColumn();
            this.pnlCarName = new Panel();
            this.txtCarName = new TextBox();
            this.lblCarResult = new Label();
            this.lblCarName = new Label();
            this.btnClearRegionData = new Button();
            this.pnlTop = new Panel();
            this.gbSelectArea = new GroupBox();
            this.tvAreaList = new ThreeStateTreeView();
            this.groupBox2 = new GroupBox();
            this.gbArea = new GroupBox();
            this.dgvQueryResult = new DataGridView();
            this.CarId = new DataGridViewTextBoxColumn();
            this.CarNum = new DataGridViewTextBoxColumn();
            this.SimNum = new DataGridViewTextBoxColumn();
            this.AreaName = new DataGridViewTextBoxColumn();
            this.GpsTime = new DataGridViewTextBoxColumn();
            this.Longitude = new DataGridViewTextBoxColumn();
            this.Latitude = new DataGridViewTextBoxColumn();
            this.Speed = new DataGridViewTextBoxColumn();
            this.CarStatu = new DataGridViewTextBoxColumn();
            this.Direct = new DataGridViewTextBoxColumn();
            this.btnStop = new Button();
            this.btnLoad = new Button();
            this.pnlBtn = new Panel();
            this.chkShowCar = new CheckBox();
            this.grpLonLat1.SuspendLayout();
            this.pbHandle.SuspendLayout();
            this.grpProgress.SuspendLayout();
            this.panelLoading.SuspendLayout();
            ((ISupportInitialize) this.pbPicWait).BeginInit();
            this.grpSetResult.SuspendLayout();
            ((ISupportInitialize) this.dgvLonLat).BeginInit();
            this.pnlCarName.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.gbSelectArea.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbArea.SuspendLayout();
            ((ISupportInitialize) this.dgvQueryResult).BeginInit();
            this.pnlBtn.SuspendLayout();
            base.SuspendLayout();
            this.btnClose.BackColor = SystemColors.Control;
            this.btnClose.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new Point(694, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(60, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            this.btnOK.Location = new Point(562, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(60, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "查询";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            this.dtpStartTime1.CustomFormat = "HH:mm:ss";
            this.dtpStartTime1.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime1.Location = new Point(550, 42);
            this.dtpStartTime1.Name = "dtpStartTime1";
            this.dtpStartTime1.ShowUpDown = true;
            this.dtpStartTime1.Size = new Size(81, 21);
            this.dtpStartTime1.TabIndex = 1;
            this.dtpStartTime1.Value = new DateTime(2009, 10, 10, 0, 0, 0, 0);
            this.lblStartTime1.AutoSize = true;
            this.lblStartTime1.Location = new Point(511, 46);
            this.lblStartTime1.Name = "lblStartTime1";
            this.lblStartTime1.Size = new Size(41, 12);
            this.lblStartTime1.TabIndex = 0;
            this.lblStartTime1.Text = "时间：";
            this.dtpEndTime1.CustomFormat = "HH:mm:ss";
            this.dtpEndTime1.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime1.Location = new Point(550, 69);
            this.dtpEndTime1.Name = "dtpEndTime1";
            this.dtpEndTime1.ShowUpDown = true;
            this.dtpEndTime1.Size = new Size(81, 21);
            this.dtpEndTime1.TabIndex = 3;
            this.dtpStartDate1.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate1.Format = DateTimePickerFormat.Custom;
            this.dtpStartDate1.Location = new Point(402, 42);
            this.dtpStartDate1.Name = "dtpStartDate1";
            this.dtpStartDate1.Size = new Size(87, 21);
            this.dtpStartDate1.TabIndex = 0;
            this.lblEndTime1.AutoEllipsis = true;
            this.lblEndTime1.AutoSize = true;
            this.lblEndTime1.Location = new Point(511, 73);
            this.lblEndTime1.Name = "lblEndTime1";
            this.lblEndTime1.Size = new Size(41, 12);
            this.lblEndTime1.TabIndex = 0;
            this.lblEndTime1.Text = "时间：";
            this.lblStartDate1.AutoSize = true;
            this.lblStartDate1.Location = new Point(360, 46);
            this.lblStartDate1.Name = "lblStartDate1";
            this.lblStartDate1.Size = new Size(41, 12);
            this.lblStartDate1.TabIndex = 0;
            this.lblStartDate1.Text = "开始：";
            this.dtpEndDate1.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate1.Format = DateTimePickerFormat.Custom;
            this.dtpEndDate1.Location = new Point(402, 69);
            this.dtpEndDate1.Name = "dtpEndDate1";
            this.dtpEndDate1.Size = new Size(87, 21);
            this.dtpEndDate1.TabIndex = 2;
            this.lblEndDate1.AutoSize = true;
            this.lblEndDate1.Location = new Point(360, 73);
            this.lblEndDate1.Name = "lblEndDate1";
            this.lblEndDate1.Size = new Size(41, 12);
            this.lblEndDate1.TabIndex = 0;
            this.lblEndDate1.Text = "结束：";
            this.grpLonLat1.Controls.Add(this.btnDelete);
            this.grpLonLat1.Controls.Add(this.btnUpdate);
            this.grpLonLat1.Controls.Add(this.btnAdd);
            this.grpLonLat1.Controls.Add(this.lblRadius1);
            this.grpLonLat1.Controls.Add(this.dtpStartTime1);
            this.grpLonLat1.Controls.Add(this.btnGetLatLon1);
            this.grpLonLat1.Controls.Add(this.lblStartTime1);
            this.grpLonLat1.Controls.Add(this.dtpEndTime1);
            this.grpLonLat1.Controls.Add(this.cmbRegionType1);
            this.grpLonLat1.Controls.Add(this.dtpStartDate1);
            this.grpLonLat1.Controls.Add(this.txtLat12);
            this.grpLonLat1.Controls.Add(this.lblEndTime1);
            this.grpLonLat1.Controls.Add(this.txtLon12);
            this.grpLonLat1.Controls.Add(this.lblStartDate1);
            this.grpLonLat1.Controls.Add(this.lblRegionType1);
            this.grpLonLat1.Controls.Add(this.dtpEndDate1);
            this.grpLonLat1.Controls.Add(this.txtLat11);
            this.grpLonLat1.Controls.Add(this.lblEndDate1);
            this.grpLonLat1.Controls.Add(this.txtLon11);
            this.grpLonLat1.Controls.Add(this.lblLat12);
            this.grpLonLat1.Controls.Add(this.lblLon12);
            this.grpLonLat1.Controls.Add(this.lblLat11);
            this.grpLonLat1.Controls.Add(this.lblLon11);
            this.grpLonLat1.Dock = DockStyle.Top;
            this.grpLonLat1.Location = new Point(3, 44);
            this.grpLonLat1.Name = "grpLonLat1";
            this.grpLonLat1.Size = new Size(688, 97);
            this.grpLonLat1.TabIndex = 0;
            this.grpLonLat1.TabStop = false;
            this.grpLonLat1.Text = "区域时间范围（最多可以设置三个）";
            this.btnDelete.Location = new Point(556, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.btnUpdate.Location = new Point(474, 12);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(75, 23);
            this.btnUpdate.TabIndex = 15;
            this.btnUpdate.Text = "更新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);
            this.btnAdd.Location = new Point(393, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(75, 23);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "增加";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new EventHandler(this.btnAdd_Click);
            this.lblRadius1.AutoSize = true;
            this.lblRadius1.Location = new Point(329, 46);
            this.lblRadius1.Name = "lblRadius1";
            this.lblRadius1.Size = new Size(17, 12);
            this.lblRadius1.TabIndex = 14;
            this.lblRadius1.Text = "米";
            this.lblRadius1.Visible = false;
            this.btnGetLatLon1.Location = new Point(221, 13);
            this.btnGetLatLon1.Name = "btnGetLatLon1";
            this.btnGetLatLon1.Size = new Size(101, 23);
            this.btnGetLatLon1.TabIndex = 13;
            this.btnGetLatLon1.Text = "获取位置范围";
            this.btnGetLatLon1.UseVisualStyleBackColor = true;
            this.btnGetLatLon1.Click += new EventHandler(this.btnGetLatLon1_Click);
            this.cmbRegionType1.AccessibleRole =  System.Windows.Forms.AccessibleRole.None;
            this.cmbRegionType1.DisplayMember = "Display";
            this.cmbRegionType1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRegionType1.FlatStyle = FlatStyle.Flat;
            this.cmbRegionType1.FormattingEnabled = true;
            this.cmbRegionType1.Location = new Point(74, 15);
            this.cmbRegionType1.Name = "cmbRegionType1";
            this.cmbRegionType1.Size = new Size(118, 20);
            this.cmbRegionType1.TabIndex = 12;
            this.cmbRegionType1.ValueMember = "Value";
            this.cmbRegionType1.SelectedIndexChanged += new EventHandler(this.cmdRegionType_SelectedIndexChanged);
            this.txtLat12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat12.Enabled = false;
            this.txtLat12.Location = new Point(222, 69);
            this.txtLat12.Name = "txtLat12";
            this.txtLat12.ReadOnly = true;
            this.txtLat12.Size = new Size(100, 21);
            this.txtLat12.TabIndex = 3;
            this.txtLon12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLon12.Enabled = false;
            this.txtLon12.Location = new Point(222, 42);
            this.txtLon12.Name = "txtLon12";
            this.txtLon12.ReadOnly = true;
            this.txtLon12.Size = new Size(100, 21);
            this.txtLon12.TabIndex = 1;
            this.lblRegionType1.AutoSize = true;
            this.lblRegionType1.Location = new Point(10, 19);
            this.lblRegionType1.Name = "lblRegionType1";
            this.lblRegionType1.Size = new Size(65, 12);
            this.lblRegionType1.TabIndex = 11;
            this.lblRegionType1.Text = "区域类型：";
            this.txtLat11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLat11.Enabled = false;
            this.txtLat11.Location = new Point(74, 69);
            this.txtLat11.Name = "txtLat11";
            this.txtLat11.ReadOnly = true;
            this.txtLat11.Size = new Size(100, 21);
            this.txtLat11.TabIndex = 2;
            this.txtLon11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLon11.Enabled = false;
            this.txtLon11.Location = new Point(74, 42);
            this.txtLon11.Name = "txtLon11";
            this.txtLon11.ReadOnly = true;
            this.txtLon11.Size = new Size(100, 21);
            this.txtLon11.TabIndex = 0;
            this.lblLat12.AutoSize = true;
            this.lblLat12.Location = new Point(183, 73);
            this.lblLat12.Name = "lblLat12";
            this.lblLat12.Size = new Size(17, 12);
            this.lblLat12.TabIndex = 3;
            this.lblLat12.Text = "到";
            this.lblLon12.AutoSize = true;
            this.lblLon12.Location = new Point(183, 46);
            this.lblLon12.Name = "lblLon12";
            this.lblLon12.Size = new Size(17, 12);
            this.lblLon12.TabIndex = 2;
            this.lblLon12.Text = "到";
            this.lblLat11.AutoSize = true;
            this.lblLat11.Location = new Point(32, 73);
            this.lblLat11.Name = "lblLat11";
            this.lblLat11.Size = new Size(41, 12);
            this.lblLat11.TabIndex = 1;
            this.lblLat11.Text = "纬度：";
            this.lblLon11.AutoSize = true;
            this.lblLon11.Location = new Point(32, 46);
            this.lblLon11.Name = "lblLon11";
            this.lblLon11.Size = new Size(41, 12);
            this.lblLon11.TabIndex = 0;
            this.lblLon11.Text = "经度：";
            this.pbHandle.AllowDrop = true;
            this.pbHandle.Controls.Add(this.grpProgress);
            this.pbHandle.Dock = DockStyle.Top;
            this.pbHandle.Location = new Point(5, 420);
            this.pbHandle.Name = "pbHandle";
            this.pbHandle.Size = new Size(927, 42);
            this.pbHandle.TabIndex = 5;
            this.grpProgress.Controls.Add(this.pbDownLoad);
            this.grpProgress.Dock = DockStyle.Fill;
            this.grpProgress.Location = new Point(0, 0);
            this.grpProgress.Name = "grpProgress";
            this.grpProgress.Size = new Size(927, 42);
            this.grpProgress.TabIndex = 4;
            this.grpProgress.TabStop = false;
            this.grpProgress.Text = "进度";
            this.pbDownLoad.Dock = DockStyle.Fill;
            this.pbDownLoad.Location = new Point(3, 17);
            this.pbDownLoad.Name = "pbDownLoad";
            this.pbDownLoad.Size = new Size(921, 22);
            this.pbDownLoad.TabIndex = 0;
            this.panelLoading.Controls.Add(this.pbPicWait);
            this.panelLoading.Controls.Add(this.lblWaitText);
            this.panelLoading.Location = new Point(6, 2);
            this.panelLoading.Name = "panelLoading";
            this.panelLoading.Size = new Size(238, 27);
            this.panelLoading.TabIndex = 13;
            this.panelLoading.Tag = "999";
            this.pbPicWait.BackColor = SystemColors.Control;
            this.pbPicWait.Image = Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new Point(8, 5);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new Size(16, 16);
            this.pbPicWait.TabIndex = 12;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.lblWaitText.BackColor = SystemColors.Control;
            this.lblWaitText.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.lblWaitText.Location = new Point(33, 8);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new Size(119, 12);
            this.lblWaitText.TabIndex = 11;
            this.lblWaitText.Text = "正在查找，请稍候...";
            this.CarImageList.ImageStream = (ImageListStreamer)resources.GetObject("CarImageList.ImageStream");
            this.CarImageList.TransparentColor = Color.Transparent;
            this.CarImageList.Images.SetKeyName(0, "Folder_Collapse");
            this.CarImageList.Images.SetKeyName(1, "Folder_Expand");
            this.grpSetResult.BackColor = SystemColors.Control;
            this.grpSetResult.Controls.Add(this.dgvLonLat);
            this.grpSetResult.Dock = DockStyle.Top;
            this.grpSetResult.Location = new Point(3, 141);
            this.grpSetResult.Name = "grpSetResult";
            this.grpSetResult.Size = new Size(688, 90);
            this.grpSetResult.TabIndex = 1;
            this.grpSetResult.TabStop = false;
            this.dgvLonLat.AllowUserToAddRows = false;
            this.dgvLonLat.AllowUserToDeleteRows = false;
            this.dgvLonLat.AllowUserToResizeRows = false;
            this.dgvLonLat.BackgroundColor = SystemColors.Window;
            style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style.BackColor = SystemColors.Control;
            style.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            style.ForeColor = SystemColors.WindowText;
            style.SelectionBackColor = SystemColors.Highlight;
            style.SelectionForeColor = SystemColors.HighlightText;
            style.WrapMode = DataGridViewTriState.True;
            this.dgvLonLat.ColumnHeadersDefaultCellStyle = style;
            this.dgvLonLat.ColumnHeadersHeight = 17;
            this.dgvLonLat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLonLat.Columns.AddRange(new DataGridViewColumn[] { this.RegionId, this.RegionType, this.LonLat, this.StartTime, this.EndTime });
            this.dgvLonLat.Dock = DockStyle.Fill;
            this.dgvLonLat.Location = new Point(3, 17);
            this.dgvLonLat.Name = "dgvLonLat";
            this.dgvLonLat.ReadOnly = true;
            this.dgvLonLat.RowHeadersVisible = false;
            this.dgvLonLat.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvLonLat.RowTemplate.Height = 17;
            this.dgvLonLat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvLonLat.Size = new Size(682, 70);
            this.dgvLonLat.TabIndex = 18;
            this.dgvLonLat.Tag = "9999";
            this.dgvLonLat.CurrentCellChanged += new EventHandler(this.dgvLonLat_CurrentCellChanged);
            this.RegionId.DataPropertyName = "RegionId";
            this.RegionId.HeaderText = "RegionId";
            this.RegionId.Name = "RegionId";
            this.RegionId.ReadOnly = true;
            this.RegionId.Visible = false;
            this.RegionType.DataPropertyName = "RegionType";
            this.RegionType.HeaderText = "区域类型";
            this.RegionType.Name = "RegionType";
            this.RegionType.ReadOnly = true;
            this.RegionType.Width = 80;
            this.LonLat.DataPropertyName = "LonLat";
            this.LonLat.HeaderText = "经纬度";
            this.LonLat.Name = "LonLat";
            this.LonLat.ReadOnly = true;
            this.LonLat.Width = 310;
            this.StartTime.DataPropertyName = "StartTime";
            this.StartTime.HeaderText = "开始时间";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 120;
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "结束时间";
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 120;
            this.pnlCarName.Controls.Add(this.txtCarName);
            this.pnlCarName.Controls.Add(this.lblCarResult);
            this.pnlCarName.Controls.Add(this.lblCarName);
            this.pnlCarName.Dock = DockStyle.Top;
            this.pnlCarName.Location = new Point(3, 17);
            this.pnlCarName.Name = "pnlCarName";
            this.pnlCarName.Size = new Size(688, 27);
            this.pnlCarName.TabIndex = 17;
            this.txtCarName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarName.Location = new Point(74, 2);
            this.txtCarName.Name = "txtCarName";
            this.txtCarName.Size = new Size(103, 21);
            this.txtCarName.TabIndex = 12;
            this.lblCarResult.AutoSize = true;
            this.lblCarResult.ForeColor = Color.Red;
            this.lblCarResult.Location = new Point(183, 6);
            this.lblCarResult.Name = "lblCarResult";
            this.lblCarResult.Size = new Size(209, 12);
            this.lblCarResult.TabIndex = 11;
            this.lblCarResult.Text = "(注：为空表示查询当前帐号所有车辆)";
            this.lblCarName.AutoSize = true;
            this.lblCarName.Location = new Point(11, 6);
            this.lblCarName.Name = "lblCarName";
            this.lblCarName.Size = new Size(65, 12);
            this.lblCarName.TabIndex = 11;
            this.lblCarName.Text = "模糊车牌：";
            this.btnClearRegionData.Location = new Point(826, 5);
            this.btnClearRegionData.Name = "btnClearRegionData";
            this.btnClearRegionData.Size = new Size(100, 23);
            this.btnClearRegionData.TabIndex = 14;
            this.btnClearRegionData.Text = "清空查询结果";
            this.btnClearRegionData.UseVisualStyleBackColor = true;
            this.btnClearRegionData.Click += new EventHandler(this.btnClearRegionData_Click);
            this.pnlTop.Controls.Add(this.gbSelectArea);
            this.pnlTop.Controls.Add(this.groupBox2);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(5, 5);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(927, 415);
            this.pnlTop.TabIndex = 6;
            this.gbSelectArea.Controls.Add(this.tvAreaList);
            this.gbSelectArea.Dock = DockStyle.Fill;
            this.gbSelectArea.Location = new Point(694, 0);
            this.gbSelectArea.Name = "gbSelectArea";
            this.gbSelectArea.Size = new Size(233, 415);
            this.gbSelectArea.TabIndex = 11;
            this.gbSelectArea.TabStop = false;
            this.gbSelectArea.Text = "区域范围";
            this.tvAreaList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvAreaList.CheckBoxes = true;
            this.tvAreaList.Dock = DockStyle.Fill;
            this.tvAreaList.ImageKey = "Folder_Collapse";
            this.tvAreaList.ImageList = this.CarImageList;
            this.tvAreaList.Indent = 19;
            this.tvAreaList.IsMulSelect = false;
            this.tvAreaList.ItemHeight = 18;
            this.tvAreaList.Location = new Point(3, 17);
            this.tvAreaList.Name = "tvAreaList";
            this.tvAreaList.SelectedImageIndex = 0;
            this.tvAreaList.Size = new Size(227, 395);
            this.tvAreaList.TabIndex = 0;
            this.tvAreaList.Tag = "9999";
            this.tvAreaList.AfterCheck += new TreeViewEventHandler(this.tvAreaList_AfterCheck);
            this.tvAreaList.AfterCollapse += new TreeViewEventHandler(this.tvAreaList_AfterCollapse);
            this.tvAreaList.AfterExpand += new TreeViewEventHandler(this.tvAreaList_AfterExpand);
            this.groupBox2.Controls.Add(this.gbArea);
            this.groupBox2.Controls.Add(this.grpSetResult);
            this.groupBox2.Controls.Add(this.grpLonLat1);
            this.groupBox2.Controls.Add(this.pnlCarName);
            this.groupBox2.Dock = DockStyle.Left;
            this.groupBox2.Location = new Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new Size(694, 415);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.gbArea.Controls.Add(this.dgvQueryResult);
            this.gbArea.Dock = DockStyle.Fill;
            this.gbArea.Location = new Point(3, 231);
            this.gbArea.Name = "gbArea";
            this.gbArea.Size = new Size(688, 181);
            this.gbArea.TabIndex = 18;
            this.gbArea.TabStop = false;
            this.gbArea.Text = "查询结果";
            this.dgvQueryResult.AllowUserToAddRows = false;
            this.dgvQueryResult.AllowUserToDeleteRows = false;
            this.dgvQueryResult.AllowUserToResizeRows = false;
            this.dgvQueryResult.BackgroundColor = SystemColors.Window;
            style2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            style2.BackColor = SystemColors.Control;
            style2.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 134);
            style2.ForeColor = SystemColors.WindowText;
            style2.SelectionBackColor = SystemColors.Highlight;
            style2.SelectionForeColor = SystemColors.HighlightText;
            style2.WrapMode = DataGridViewTriState.True;
            this.dgvQueryResult.ColumnHeadersDefaultCellStyle = style2;
            this.dgvQueryResult.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQueryResult.Columns.AddRange(new DataGridViewColumn[] { this.CarId, this.CarNum, this.SimNum, this.AreaName, this.GpsTime, this.Longitude, this.Latitude, this.Speed, this.CarStatu, this.Direct });
            this.dgvQueryResult.Dock = DockStyle.Fill;
            this.dgvQueryResult.Location = new Point(3, 17);
            this.dgvQueryResult.Name = "dgvQueryResult";
            this.dgvQueryResult.ReadOnly = true;
            this.dgvQueryResult.RowHeadersVisible = false;
            this.dgvQueryResult.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvQueryResult.RowTemplate.Height = 17;
            this.dgvQueryResult.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvQueryResult.Size = new Size(682, 161);
            this.dgvQueryResult.TabIndex = 0;
            this.dgvQueryResult.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvQueryResult_CellDoubleClick);
            this.CarId.DataPropertyName = "CarId";
            this.CarId.HeaderText = "车辆ID";
            this.CarId.Name = "CarId";
            this.CarId.ReadOnly = true;
            this.CarId.Width = 68;
            this.CarNum.DataPropertyName = "CarNum";
            this.CarNum.HeaderText = "车牌号";
            this.CarNum.Name = "CarNum";
            this.CarNum.ReadOnly = true;
            this.CarNum.Width = 70;
            this.SimNum.DataPropertyName = "SimNum";
            this.SimNum.HeaderText = "车载电话";
            this.SimNum.Name = "SimNum";
            this.SimNum.ReadOnly = true;
            this.SimNum.Width = 95;
            this.AreaName.DataPropertyName = "AreaName";
            this.AreaName.HeaderText = "所属区域";
            this.AreaName.Name = "AreaName";
            this.AreaName.ReadOnly = true;
            this.GpsTime.DataPropertyName = "GPSTIME";
            this.GpsTime.HeaderText = "定位时间";
            this.GpsTime.Name = "GpsTime";
            this.GpsTime.ReadOnly = true;
            this.GpsTime.Width = 120;
            this.Longitude.DataPropertyName = "Longitude";
            this.Longitude.HeaderText = "经度";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.Width = 75;
            this.Latitude.DataPropertyName = "Latitude";
            this.Latitude.HeaderText = "纬度";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Latitude.Width = 75;
            this.Speed.DataPropertyName = "Speed";
            this.Speed.HeaderText = "速度";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.Speed.Width = 60;
            this.CarStatu.DataPropertyName = "CarStatu";
            this.CarStatu.HeaderText = "定位状态";
            this.CarStatu.Name = "CarStatu";
            this.CarStatu.ReadOnly = true;
            this.CarStatu.Visible = false;
            this.Direct.DataPropertyName = "Direct";
            this.Direct.HeaderText = "方向";
            this.Direct.Name = "Direct";
            this.Direct.ReadOnly = true;
            this.Direct.Visible = false;
            this.Direct.Width = 60;
            this.btnStop.Enabled = false;
            this.btnStop.Location = new Point(628, 5);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new Size(60, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new EventHandler(this.btnCancel_Click);
            this.btnLoad.BackColor = SystemColors.Control;
            this.btnLoad.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnLoad.Location = new Point(760, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new Size(60, 23);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "导出";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new EventHandler(this.btnLoad_Click);
            this.pnlBtn.Controls.Add(this.chkShowCar);
            this.pnlBtn.Controls.Add(this.panelLoading);
            this.pnlBtn.Controls.Add(this.btnLoad);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Controls.Add(this.btnClose);
            this.pnlBtn.Controls.Add(this.btnClearRegionData);
            this.pnlBtn.Controls.Add(this.btnStop);
            this.pnlBtn.Dock = DockStyle.Top;
            this.pnlBtn.Location = new Point(5, 462);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new Size(927, 29);
            this.pnlBtn.TabIndex = 15;
            this.chkShowCar.AutoSize = true;
            this.chkShowCar.Location = new Point(396, 9);
            this.chkShowCar.Name = "chkShowCar";
            this.chkShowCar.Size = new Size(156, 16);
            this.chkShowCar.TabIndex = 15;
            this.chkShowCar.Text = "查询结果是否显示到地图";
            this.chkShowCar.UseVisualStyleBackColor = true;
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.CancelButton = this.btnClose;
            base.ClientSize = new Size(937, 496);
            base.Controls.Add(this.pnlBtn);
            base.Controls.Add(this.pbHandle);
            base.Controls.Add(this.pnlTop);
            base.Icon = (Icon) resources.GetObject("$this.Icon");
            base.Name = "QueryCarInfo";
            base.Padding = new Padding(5);
            this.Text = "查询车辆信息";
            base.Load += new EventHandler(this.MapFlag_Load);
            base.FormClosing += new FormClosingEventHandler(this.QueryCarInfo_FormClosing);
            this.grpLonLat1.ResumeLayout(false);
            this.grpLonLat1.PerformLayout();
            this.pbHandle.ResumeLayout(false);
            this.grpProgress.ResumeLayout(false);
            this.panelLoading.ResumeLayout(false);
            ((ISupportInitialize) this.pbPicWait).EndInit();
            this.grpSetResult.ResumeLayout(false);
            ((ISupportInitialize) this.dgvLonLat).EndInit();
            this.pnlCarName.ResumeLayout(false);
            this.pnlCarName.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.gbSelectArea.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbArea.ResumeLayout(false);
            ((ISupportInitialize) this.dgvQueryResult).EndInit();
            this.pnlBtn.ResumeLayout(false);
            this.pnlBtn.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private DataGridViewTextBoxColumn AreaName;
        private bool bSearchResult;
        private Button btnAdd;
        private Button btnClearRegionData;
        private Button btnDelete;
        private Button btnGetLatLon1;
        private Button btnUpdate;
        private DataGridViewTextBoxColumn CarId;
        private System.Windows.Forms.ImageList CarImageList;
        private DataGridViewTextBoxColumn CarNum;
        private DataGridViewTextBoxColumn CarStatu;
        private CheckBox chkShowCar;
        private ComBox cmbRegionType1;
        private DataGridView dgvLonLat;
        private DataGridView dgvQueryResult;
        private DataGridViewTextBoxColumn Direct;
        private DataTable dtLonLatList;
        private DateTimePicker dtpEndDate1;
        private DateTimePicker dtpEndTime1;
        private DateTimePicker dtpStartDate1;
        private DateTimePicker dtpStartTime1;
        private DataTable dtSearchCar;
        private DataGridViewTextBoxColumn EndTime;
        private BackgroundWorker excelWorker;
        private GroupBox gbArea;
        private GroupBox gbSelectArea;
        private DataGridViewTextBoxColumn GpsTime;
        private GroupBox groupBox2;
        private GroupBox grpLonLat1;
        private GroupBox grpProgress;
        private GroupBox grpSetResult;
        private int iCntPerPage;
        private int iPage;
        private DataGridViewTextBoxColumn Latitude;
        private Label lblCarName;
        private Label lblCarResult;
        private Label lblEndDate1;
        private Label lblEndTime1;
        private Label lblLat11;
        private Label lblLat12;
        private Label lblLon11;
        private Label lblLon12;
        private Label lblRadius1;
        private Label lblRegionType1;
        private Label lblStartDate1;
        private Label lblStartTime1;
        private Label lblWaitText;
        private DataGridViewTextBoxColumn Longitude;
        private DataGridViewTextBoxColumn LonLat;
        private dAddProgress myAddProgress;
        private dShowCar myShowCar;
        private object objLock;
        private object objLockProgress;
        private Panel panelLoading;
        private ProgressBar pbDownLoad;
        private Panel pbHandle;
        private PictureBox pbPicWait;
        private Panel pnlBtn;
        private Panel pnlCarName;
        private Panel pnlTop;
        private DataGridViewTextBoxColumn RegionId;
        private DataGridViewTextBoxColumn RegionType;
        private SkinEngine seSkin;
        private string sExecSql;
        private DataGridViewTextBoxColumn SimNum;
        private DataGridViewTextBoxColumn Speed;
        private DataGridViewTextBoxColumn StartTime;
        private ThreeStateTreeView tvAreaList;
        private TextBox txtCarName;
        private TextBox txtLat11;
        private TextBox txtLat12;
        private TextBox txtLon11;
        private TextBox txtLon12;
    }
}