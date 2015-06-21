namespace Client
{
    partial class CarList
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tvList = new WinFormsUI.Controls.ThreeStateTreeView();
            this.CarImageList = new System.Windows.Forms.ImageList(this.components);
            this.tsbRefreshList = new System.Windows.Forms.ToolStripButton();
            this.tsbAlarmAffirm = new System.Windows.Forms.ToolStripButton();
            this.tsBtn = new System.Windows.Forms.ToolStrip();
            this.pnlBtn = new System.Windows.Forms.Panel();
            this.tvTrackCar = new WinFormsUI.Controls.ThreeStateTreeView();
            this.gbAlarmList = new System.Windows.Forms.GroupBox();
            this.dgvTrackCar = new System.Windows.Forms.DataGridView();
            this.trackcarimg = new System.Windows.Forms.DataGridViewImageColumn();
            this.tpCarList = new System.Windows.Forms.TabPage();
            this.tcCarList = new System.Windows.Forms.TabControl();
            this.tpTrackCar = new System.Windows.Forms.TabPage();
            this.txtCarNo = new System.Windows.Forms.TextBox();
            this.lblValue = new System.Windows.Forms.Label();
            this.comType = new WinFormsUI.Controls.ComBox();
            this.rtxtCarDetail = new System.Windows.Forms.RichTextBox();
            this.pbRichText = new System.Windows.Forms.Panel();
            this.pnlSearch = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlSearchDetail = new System.Windows.Forms.Panel();
            this.pnlShowDetail = new System.Windows.Forms.Panel();
            this.tsDetail = new System.Windows.Forms.ToolStrip();
            this.tsbShowDetail = new System.Windows.Forms.ToolStripButton();
            this.pnlSelect = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.tsBtn.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.gbAlarmList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackCar)).BeginInit();
            this.tpCarList.SuspendLayout();
            this.tcCarList.SuspendLayout();
            this.tpTrackCar.SuspendLayout();
            this.pbRichText.SuspendLayout();
            this.pnlSearch.SuspendLayout();
            this.pnlSearchDetail.SuspendLayout();
            this.pnlShowDetail.SuspendLayout();
            this.tsDetail.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvList
            // 
            this.tvList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvList.CheckBoxes = true;
            this.tvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvList.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvList.HideSelection = false;
            this.tvList.ImageKey = "Folder_Collapse";
            this.tvList.ImageList = this.CarImageList;
            this.tvList.Indent = 17;
            this.tvList.IsMulSelect = true;
            this.tvList.ItemHeight = 18;
            this.tvList.Location = new System.Drawing.Point(3, 3);
            this.tvList.Name = "tvList";
            this.tvList.SelectedImageKey = "Folder_Collapse";
            this.tvList.ShowNodeToolTips = true;
            this.tvList.Size = new System.Drawing.Size(199, 326);
            this.tvList.TabIndex = 0;
            this.tvList.Tag = "9999";
            this.tvList.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvList_BeforeCheck);
            this.tvList.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterCollapse);
            this.tvList.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterExpand);
            this.tvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvList_AfterSelect);
            this.tvList.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvList_NodeMouseDoubleClick);
            this.tvList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvList_MouseUp);
            this.tvList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCarNo_PreviewKeyDown);
            // 
            // CarImageList
            // 
            this.CarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("CarImageList.ImageStream")));
            this.CarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.CarImageList.Images.SetKeyName(0, "Folder_Collapse");
            this.CarImageList.Images.SetKeyName(1, "Folder_Expand");
            this.CarImageList.Images.SetKeyName(2, "Down");
            this.CarImageList.Images.SetKeyName(3, "Up");
            this.CarImageList.Images.SetKeyName(4, "Car_r2");
            this.CarImageList.Images.SetKeyName(5, "Car_b2");
            this.CarImageList.Images.SetKeyName(6, "Car_g2");
            this.CarImageList.Images.SetKeyName(7, "Car_r");
            this.CarImageList.Images.SetKeyName(8, "Car_f");
            this.CarImageList.Images.SetKeyName(9, "Car_g");
            this.CarImageList.Images.SetKeyName(10, "Car_b");
            this.CarImageList.Images.SetKeyName(11, "Car_green");
            this.CarImageList.Images.SetKeyName(12, "stop_b");
            this.CarImageList.Images.SetKeyName(13, "stop_r");
            this.CarImageList.Images.SetKeyName(14, "stop_g");
            this.CarImageList.Images.SetKeyName(15, "stop_f");
            this.CarImageList.Images.SetKeyName(16, "fault");
            // 
            // tsbRefreshList
            // 
            this.tsbRefreshList.BackColor = System.Drawing.Color.Transparent;
            this.tsbRefreshList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefreshList.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefreshList.Image")));
            this.tsbRefreshList.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefreshList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshList.Margin = new System.Windows.Forms.Padding(0);
            this.tsbRefreshList.Name = "tsbRefreshList";
            this.tsbRefreshList.Size = new System.Drawing.Size(23, 25);
            this.tsbRefreshList.Text = "刷新列表";
            this.tsbRefreshList.Click += new System.EventHandler(this.tsbRefreshList_Click);
            // 
            // tsbAlarmAffirm
            // 
            this.tsbAlarmAffirm.BackColor = System.Drawing.Color.Transparent;
            this.tsbAlarmAffirm.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAlarmAffirm.Image = global::Client.Properties.Resources.AlarmCancel;
            this.tsbAlarmAffirm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAlarmAffirm.Margin = new System.Windows.Forms.Padding(0);
            this.tsbAlarmAffirm.Name = "tsbAlarmAffirm";
            this.tsbAlarmAffirm.Size = new System.Drawing.Size(23, 20);
            this.tsbAlarmAffirm.Text = "报警确认";
            this.tsbAlarmAffirm.Visible = false;
            this.tsbAlarmAffirm.Click += new System.EventHandler(this.tsbAlarmAffirm_Click);
            // 
            // tsBtn
            // 
            this.tsBtn.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsBtn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAlarmAffirm,
            this.tsbRefreshList});
            this.tsBtn.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsBtn.Location = new System.Drawing.Point(0, 0);
            this.tsBtn.Name = "tsBtn";
            this.tsBtn.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsBtn.Size = new System.Drawing.Size(24, 25);
            this.tsBtn.Stretch = true;
            this.tsBtn.TabIndex = 0;
            this.tsBtn.Tag = "";
            this.tsBtn.Text = "toolStrip1";
            // 
            // pnlBtn
            // 
            this.pnlBtn.BackColor = System.Drawing.Color.Transparent;
            this.pnlBtn.Controls.Add(this.tsBtn);
            this.pnlBtn.Location = new System.Drawing.Point(177, 0);
            this.pnlBtn.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new System.Drawing.Size(24, 22);
            this.pnlBtn.TabIndex = 5;
            // 
            // tvTrackCar
            // 
            this.tvTrackCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tvTrackCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTrackCar.HideSelection = false;
            this.tvTrackCar.ImageIndex = 0;
            this.tvTrackCar.ImageList = this.CarImageList;
            this.tvTrackCar.IsMulSelect = true;
            this.tvTrackCar.Location = new System.Drawing.Point(3, 3);
            this.tvTrackCar.Name = "tvTrackCar";
            this.tvTrackCar.SelectedImageIndex = 0;
            this.tvTrackCar.ShowNodeToolTips = true;
            this.tvTrackCar.Size = new System.Drawing.Size(199, 326);
            this.tvTrackCar.TabIndex = 3;
            this.tvTrackCar.Tag = "9999";
            this.tvTrackCar.Visible = false;
            this.tvTrackCar.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.tvTrackCar_AfterCollapse);
            this.tvTrackCar.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.tvTrackCar_AfterExpand);
            this.tvTrackCar.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTrackCar_AfterSelect);
            this.tvTrackCar.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTrackCar_NodeMouseClick);
            this.tvTrackCar.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvTrackCar_NodeMouseDoubleClick);
            this.tvTrackCar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tvTrackCar_MouseUp);
            this.tvTrackCar.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCarNo_PreviewKeyDown);
            // 
            // gbAlarmList
            // 
            this.gbAlarmList.Controls.Add(this.dgvTrackCar);
            this.gbAlarmList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAlarmList.Location = new System.Drawing.Point(3, 3);
            this.gbAlarmList.Name = "gbAlarmList";
            this.gbAlarmList.Size = new System.Drawing.Size(199, 326);
            this.gbAlarmList.TabIndex = 4;
            this.gbAlarmList.TabStop = false;
            this.gbAlarmList.Tag = "";
            this.gbAlarmList.Text = "报警列表";
            this.gbAlarmList.Visible = false;
            // 
            // dgvTrackCar
            // 
            this.dgvTrackCar.AllowUserToAddRows = false;
            this.dgvTrackCar.AllowUserToDeleteRows = false;
            this.dgvTrackCar.AllowUserToResizeColumns = false;
            this.dgvTrackCar.AllowUserToResizeRows = false;
            this.dgvTrackCar.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrackCar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrackCar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTrackCar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrackCar.ColumnHeadersVisible = false;
            this.dgvTrackCar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.trackcarimg});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrackCar.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTrackCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrackCar.Location = new System.Drawing.Point(3, 17);
            this.dgvTrackCar.Name = "dgvTrackCar";
            this.dgvTrackCar.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrackCar.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTrackCar.RowHeadersVisible = false;
            this.dgvTrackCar.RowTemplate.Height = 23;
            this.dgvTrackCar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrackCar.Size = new System.Drawing.Size(193, 306);
            this.dgvTrackCar.TabIndex = 0;
            this.dgvTrackCar.Tag = "9999";
            this.dgvTrackCar.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrackCar_CellDoubleClick);
            this.dgvTrackCar.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this.dgvTrackCar_CellToolTipTextNeeded);
            // 
            // trackcarimg
            // 
            this.trackcarimg.HeaderText = "";
            this.trackcarimg.Image = global::Client.Properties.Resources.Alarm;
            this.trackcarimg.Name = "trackcarimg";
            this.trackcarimg.ReadOnly = true;
            this.trackcarimg.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.trackcarimg.Width = 20;
            // 
            // tpCarList
            // 
            this.tpCarList.Controls.Add(this.tvList);
            this.tpCarList.Location = new System.Drawing.Point(4, 25);
            this.tpCarList.Name = "tpCarList";
            this.tpCarList.Padding = new System.Windows.Forms.Padding(3);
            this.tpCarList.Size = new System.Drawing.Size(205, 332);
            this.tpCarList.TabIndex = 0;
            this.tpCarList.Text = "车辆列表";
            this.tpCarList.UseVisualStyleBackColor = true;
            // 
            // tcCarList
            // 
            this.tcCarList.Controls.Add(this.tpCarList);
            this.tcCarList.Controls.Add(this.tpTrackCar);
            this.tcCarList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCarList.ItemSize = new System.Drawing.Size(60, 21);
            this.tcCarList.Location = new System.Drawing.Point(0, 0);
            this.tcCarList.Name = "tcCarList";
            this.tcCarList.SelectedIndex = 0;
            this.tcCarList.Size = new System.Drawing.Size(213, 361);
            this.tcCarList.TabIndex = 4;
            this.tcCarList.SelectedIndexChanged += new System.EventHandler(this.tcCarList_SelectedIndexChanged);
            // 
            // tpTrackCar
            // 
            this.tpTrackCar.Controls.Add(this.tvTrackCar);
            this.tpTrackCar.Controls.Add(this.gbAlarmList);
            this.tpTrackCar.Location = new System.Drawing.Point(4, 25);
            this.tpTrackCar.Name = "tpTrackCar";
            this.tpTrackCar.Padding = new System.Windows.Forms.Padding(3);
            this.tpTrackCar.Size = new System.Drawing.Size(205, 332);
            this.tpTrackCar.TabIndex = 1;
            this.tpTrackCar.Text = "报警列表";
            this.tpTrackCar.UseVisualStyleBackColor = true;
            // 
            // txtCarNo
            // 
            this.txtCarNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCarNo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCarNo.Location = new System.Drawing.Point(10, 69);
            this.txtCarNo.Margin = new System.Windows.Forms.Padding(10);
            this.txtCarNo.Name = "txtCarNo";
            this.txtCarNo.Size = new System.Drawing.Size(177, 21);
            this.txtCarNo.TabIndex = 13;
            this.txtCarNo.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtCarNo_PreviewKeyDown);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValue.Location = new System.Drawing.Point(10, 47);
            this.lblValue.Margin = new System.Windows.Forms.Padding(10);
            this.lblValue.Name = "lblValue";
            this.lblValue.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.lblValue.Size = new System.Drawing.Size(179, 22);
            this.lblValue.TabIndex = 14;
            this.lblValue.Text = "快速查询：(按Enter键继续查找)";
            // 
            // comType
            // 
            this.comType.DisplayMember = "Display";
            this.comType.Dock = System.Windows.Forms.DockStyle.Top;
            this.comType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comType.FormattingEnabled = true;
            this.comType.Location = new System.Drawing.Point(10, 27);
            this.comType.Margin = new System.Windows.Forms.Padding(10);
            this.comType.Name = "comType";
            this.comType.Size = new System.Drawing.Size(177, 20);
            this.comType.TabIndex = 11;
            this.comType.ValueMember = "Value";
            // 
            // rtxtCarDetail
            // 
            this.rtxtCarDetail.BackColor = System.Drawing.Color.White;
            this.rtxtCarDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtxtCarDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.rtxtCarDetail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.rtxtCarDetail.Location = new System.Drawing.Point(0, 0);
            this.rtxtCarDetail.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.rtxtCarDetail.Name = "rtxtCarDetail";
            this.rtxtCarDetail.ReadOnly = true;
            this.rtxtCarDetail.Size = new System.Drawing.Size(197, 42);
            this.rtxtCarDetail.TabIndex = 14;
            this.rtxtCarDetail.Tag = "9999";
            this.rtxtCarDetail.Text = "";
            // 
            // pbRichText
            // 
            this.pbRichText.AutoSize = true;
            this.pbRichText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbRichText.Controls.Add(this.rtxtCarDetail);
            this.pbRichText.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbRichText.Location = new System.Drawing.Point(6, 127);
            this.pbRichText.Name = "pbRichText";
            this.pbRichText.Size = new System.Drawing.Size(199, 44);
            this.pbRichText.TabIndex = 14;
            this.pbRichText.Visible = false;
            // 
            // pnlSearch
            // 
            this.pnlSearch.AutoSize = true;
            this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearch.Controls.Add(this.pbRichText);
            this.pnlSearch.Controls.Add(this.panel1);
            this.pnlSearch.Controls.Add(this.pnlSearchDetail);
            this.pnlSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSearch.Location = new System.Drawing.Point(0, 361);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSearch.Size = new System.Drawing.Size(213, 179);
            this.pnlSearch.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(6, 124);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(199, 3);
            this.panel1.TabIndex = 16;
            // 
            // pnlSearchDetail
            // 
            this.pnlSearchDetail.AutoSize = true;
            this.pnlSearchDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSearchDetail.Controls.Add(this.pnlShowDetail);
            this.pnlSearchDetail.Controls.Add(this.pnlSelect);
            this.pnlSearchDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSearchDetail.Location = new System.Drawing.Point(6, 6);
            this.pnlSearchDetail.Name = "pnlSearchDetail";
            this.pnlSearchDetail.Size = new System.Drawing.Size(199, 118);
            this.pnlSearchDetail.TabIndex = 15;
            // 
            // pnlShowDetail
            // 
            this.pnlShowDetail.Controls.Add(this.tsDetail);
            this.pnlShowDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlShowDetail.Location = new System.Drawing.Point(0, 100);
            this.pnlShowDetail.Margin = new System.Windows.Forms.Padding(0);
            this.pnlShowDetail.Name = "pnlShowDetail";
            this.pnlShowDetail.Size = new System.Drawing.Size(197, 16);
            this.pnlShowDetail.TabIndex = 12;
            // 
            // tsDetail
            // 
            this.tsDetail.BackColor = System.Drawing.Color.Transparent;
            this.tsDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsDetail.GripMargin = new System.Windows.Forms.Padding(0);
            this.tsDetail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsDetail.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbShowDetail});
            this.tsDetail.Location = new System.Drawing.Point(0, 0);
            this.tsDetail.Name = "tsDetail";
            this.tsDetail.Padding = new System.Windows.Forms.Padding(0);
            this.tsDetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tsDetail.Size = new System.Drawing.Size(197, 16);
            this.tsDetail.TabIndex = 0;
            this.tsDetail.Tag = "9999";
            this.tsDetail.Text = "tsBtn";
            // 
            // tsbShowDetail
            // 
            this.tsbShowDetail.AutoSize = false;
            this.tsbShowDetail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowDetail.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowDetail.Image")));
            this.tsbShowDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowDetail.Margin = new System.Windows.Forms.Padding(0);
            this.tsbShowDetail.Name = "tsbShowDetail";
            this.tsbShowDetail.Size = new System.Drawing.Size(16, 16);
            this.tsbShowDetail.Tag = "";
            this.tsbShowDetail.Text = "显示车辆详细信息";
            this.tsbShowDetail.ToolTipText = "显示车辆详细信息";
            this.tsbShowDetail.Click += new System.EventHandler(this.tsbShowDetail_Click);
            // 
            // pnlSelect
            // 
            this.pnlSelect.AutoSize = true;
            this.pnlSelect.Controls.Add(this.txtCarNo);
            this.pnlSelect.Controls.Add(this.lblValue);
            this.pnlSelect.Controls.Add(this.comType);
            this.pnlSelect.Controls.Add(this.lblType);
            this.pnlSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSelect.Location = new System.Drawing.Point(0, 0);
            this.pnlSelect.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Padding = new System.Windows.Forms.Padding(10);
            this.pnlSelect.Size = new System.Drawing.Size(197, 100);
            this.pnlSelect.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblType.Location = new System.Drawing.Point(10, 10);
            this.lblType.Margin = new System.Windows.Forms.Padding(10);
            this.lblType.Name = "lblType";
            this.lblType.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.lblType.Size = new System.Drawing.Size(65, 17);
            this.lblType.TabIndex = 12;
            this.lblType.Text = "查询方式：";
            // 
            // CarList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(213, 540);
            this.Controls.Add(this.pnlBtn);
            this.Controls.Add(this.tcCarList);
            this.Controls.Add(this.pnlSearch);
            this.Name = "CarList";
            this.DockStateChanged += new System.EventHandler(this.CarList_DockStateChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CarList_FormClosed);
            this.Load += new System.EventHandler(this.CarList_Load);
            this.SizeChanged += new System.EventHandler(this.CarList_SizeChanged);
            this.tsBtn.ResumeLayout(false);
            this.tsBtn.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.pnlBtn.PerformLayout();
            this.gbAlarmList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrackCar)).EndInit();
            this.tpCarList.ResumeLayout(false);
            this.tcCarList.ResumeLayout(false);
            this.tpTrackCar.ResumeLayout(false);
            this.pbRichText.ResumeLayout(false);
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.pnlSearchDetail.ResumeLayout(false);
            this.pnlSearchDetail.PerformLayout();
            this.pnlShowDetail.ResumeLayout(false);
            this.pnlShowDetail.PerformLayout();
            this.tsDetail.ResumeLayout(false);
            this.tsDetail.PerformLayout();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public WinFormsUI.Controls.ThreeStateTreeView tvList;
        private System.Windows.Forms.ImageList CarImageList;
        private System.Windows.Forms.ToolStripButton tsbRefreshList;
        private System.Windows.Forms.ToolStripButton tsbAlarmAffirm;
        private System.Windows.Forms.ToolStrip tsBtn;
        private System.Windows.Forms.Panel pnlBtn;
        public WinFormsUI.Controls.ThreeStateTreeView tvTrackCar;
        private System.Windows.Forms.GroupBox gbAlarmList;
        private System.Windows.Forms.DataGridView dgvTrackCar;
        private System.Windows.Forms.DataGridViewImageColumn trackcarimg;
        private System.Windows.Forms.TabPage tpCarList;
        private System.Windows.Forms.TabControl tcCarList;
        private System.Windows.Forms.TabPage tpTrackCar;
        public System.Windows.Forms.TextBox txtCarNo;
        public System.Windows.Forms.Label lblValue;
        public WinFormsUI.Controls.ComBox comType;
        private System.Windows.Forms.RichTextBox rtxtCarDetail;
        private System.Windows.Forms.Panel pbRichText;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnlSearchDetail;
        private System.Windows.Forms.Panel pnlShowDetail;
        private System.Windows.Forms.ToolStrip tsDetail;
        private System.Windows.Forms.ToolStripButton tsbShowDetail;
        private System.Windows.Forms.Panel pnlSelect;
        public System.Windows.Forms.Label lblType;
    }
}
