namespace Client
{
    partial class itmPreSetStation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlSetRegion = new System.Windows.Forms.Panel();
            this.pnlOperator = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.RegionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StationType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionDot = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlConent = new System.Windows.Forms.Panel();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGetLocation = new System.Windows.Forms.Button();
            this.lblDis2 = new System.Windows.Forms.Label();
            this.numDistance = new System.Windows.Forms.NumericUpDown();
            this.lblDis = new System.Windows.Forms.Label();
            this.txtRegionDot = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRegionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMap = new System.Windows.Forms.Panel();
            this.tsMapTool = new System.Windows.Forms.ToolStrip();
            this.tsBtnMove = new System.Windows.Forms.ToolStripButton();
            this.tsBtnZoomIn = new System.Windows.Forms.ToolStripButton();
            this.tsBtnZoomOut = new System.Windows.Forms.ToolStripButton();
            this.picLoadMap = new System.Windows.Forms.PictureBox();
            this.wbMap = new WinFormsUI.Controls.GisMap();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlSetRegion.SuspendLayout();
            this.pnlOperator.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.pnlConent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).BeginInit();
            this.pnlMap.SuspendLayout();
            this.tsMapTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSetRegion
            // 
            this.pnlSetRegion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSetRegion.Controls.Add(this.pnlOperator);
            this.pnlSetRegion.Controls.Add(this.pnlConent);
            this.pnlSetRegion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSetRegion.Location = new System.Drawing.Point(0, 0);
            this.pnlSetRegion.Name = "pnlSetRegion";
            this.pnlSetRegion.Size = new System.Drawing.Size(170, 480);
            this.pnlSetRegion.TabIndex = 0;
            // 
            // pnlOperator
            // 
            this.pnlOperator.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlOperator.Controls.Add(this.groupBox2);
            this.pnlOperator.Controls.Add(this.groupBox1);
            this.pnlOperator.Controls.Add(this.dgvData);
            this.pnlOperator.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOperator.Location = new System.Drawing.Point(0, 0);
            this.pnlOperator.Name = "pnlOperator";
            this.pnlOperator.Size = new System.Drawing.Size(168, 344);
            this.pnlOperator.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.txtKey);
            this.groupBox2.Location = new System.Drawing.Point(-1, -3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(0, 31);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(-45, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Location = new System.Drawing.Point(0, 4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(0, 21);
            this.txtKey.TabIndex = 0;
            this.txtKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKey_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnModify);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 257);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 85);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(9, 18);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(89, 47);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(39, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(60, 18);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(39, 23);
            this.btnModify.TabIndex = 4;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(25, 47);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(39, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(39, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.AllowUserToResizeColumns = false;
            this.dgvData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.dgvData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvData.BackgroundColor = System.Drawing.Color.White;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.RegionID,
            this.StationType,
            this.RegionType,
            this.RegionDot,
            this.RegionName});
            this.dgvData.Location = new System.Drawing.Point(0, 31);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowHeadersVisible = false;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(166, 238);
            this.dgvData.TabIndex = 2;
            this.dgvData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellClick);
            // 
            // RegionID
            // 
            this.RegionID.DataPropertyName = "ID";
            this.RegionID.HeaderText = "ID编号";
            this.RegionID.Name = "RegionID";
            this.RegionID.ReadOnly = true;
            this.RegionID.Visible = false;
            // 
            // StationType
            // 
            this.StationType.DataPropertyName = "StationType";
            this.StationType.HeaderText = "类型";
            this.StationType.Name = "StationType";
            this.StationType.ReadOnly = true;
            this.StationType.Visible = false;
            // 
            // RegionType
            // 
            this.RegionType.DataPropertyName = "RegionType";
            this.RegionType.HeaderText = "区域类型";
            this.RegionType.Name = "RegionType";
            this.RegionType.ReadOnly = true;
            this.RegionType.Visible = false;
            // 
            // RegionDot
            // 
            this.RegionDot.DataPropertyName = "RegionDot";
            this.RegionDot.HeaderText = "经纬度";
            this.RegionDot.Name = "RegionDot";
            this.RegionDot.ReadOnly = true;
            this.RegionDot.Visible = false;
            // 
            // RegionName
            // 
            this.RegionName.DataPropertyName = "RegionName";
            this.RegionName.HeaderText = "站点名称";
            this.RegionName.Name = "RegionName";
            this.RegionName.ReadOnly = true;
            // 
            // pnlConent
            // 
            this.pnlConent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlConent.Controls.Add(this.cmbType);
            this.pnlConent.Controls.Add(this.label3);
            this.pnlConent.Controls.Add(this.btnGetLocation);
            this.pnlConent.Controls.Add(this.lblDis2);
            this.pnlConent.Controls.Add(this.numDistance);
            this.pnlConent.Controls.Add(this.lblDis);
            this.pnlConent.Controls.Add(this.txtRegionDot);
            this.pnlConent.Controls.Add(this.label2);
            this.pnlConent.Controls.Add(this.txtRegionName);
            this.pnlConent.Controls.Add(this.label1);
            this.pnlConent.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlConent.Location = new System.Drawing.Point(0, 347);
            this.pnlConent.Name = "pnlConent";
            this.pnlConent.Size = new System.Drawing.Size(168, 131);
            this.pnlConent.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(62, 56);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(95, 20);
            this.cmbType.TabIndex = 9;
            // 
            // lblWelconme
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "类型：";
            // 
            // btnGetLocation
            // 
            this.btnGetLocation.Location = new System.Drawing.Point(64, 104);
            this.btnGetLocation.Name = "btnGetLocation";
            this.btnGetLocation.Size = new System.Drawing.Size(69, 23);
            this.btnGetLocation.TabIndex = 16;
            this.btnGetLocation.Text = "拾取坐标";
            this.btnGetLocation.UseVisualStyleBackColor = true;
            this.btnGetLocation.Click += new System.EventHandler(this.btnGetLocation_Click);
            // 
            // lblDis2
            // 
            this.lblDis2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDis2.AutoSize = true;
            this.lblDis2.Location = new System.Drawing.Point(142, 82);
            this.lblDis2.Name = "lblDis2";
            this.lblDis2.Size = new System.Drawing.Size(17, 12);
            this.lblDis2.TabIndex = 15;
            this.lblDis2.Text = "米";
            // 
            // numDistance
            // 
            this.numDistance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDistance.Location = new System.Drawing.Point(64, 78);
            this.numDistance.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDistance.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new System.Drawing.Size(72, 21);
            this.numDistance.TabIndex = 14;
            this.numDistance.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDis
            // 
            this.lblDis.AutoSize = true;
            this.lblDis.Location = new System.Drawing.Point(2, 82);
            this.lblDis.Name = "lblDis";
            this.lblDis.Size = new System.Drawing.Size(65, 12);
            this.lblDis.TabIndex = 13;
            this.lblDis.Text = "圆形半径：";
            // 
            // txtRegionDot
            // 
            this.txtRegionDot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegionDot.Location = new System.Drawing.Point(65, 31);
            this.txtRegionDot.Name = "txtRegionDot";
            this.txtRegionDot.ReadOnly = true;
            this.txtRegionDot.Size = new System.Drawing.Size(94, 21);
            this.txtRegionDot.TabIndex = 10;
            // 
            // lblCompany
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "经维度：";
            // 
            // txtRegionName
            // 
            this.txtRegionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegionName.Location = new System.Drawing.Point(64, 2);
            this.txtRegionName.Name = "txtRegionName";
            this.txtRegionName.Size = new System.Drawing.Size(97, 21);
            this.txtRegionName.TabIndex = 8;
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "站点名称：";
            // 
            // pnlMap
            // 
            this.pnlMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMap.Controls.Add(this.tsMapTool);
            this.pnlMap.Controls.Add(this.picLoadMap);
            this.pnlMap.Controls.Add(this.wbMap);
            this.pnlMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMap.Location = new System.Drawing.Point(0, 0);
            this.pnlMap.Name = "pnlMap";
            this.pnlMap.Size = new System.Drawing.Size(523, 480);
            this.pnlMap.TabIndex = 8;
            // 
            // tsMapTool
            // 
            this.tsMapTool.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsMapTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnMove,
            this.tsBtnZoomIn,
            this.tsBtnZoomOut});
            this.tsMapTool.Location = new System.Drawing.Point(0, 0);
            this.tsMapTool.Name = "tsMapTool";
            this.tsMapTool.Size = new System.Drawing.Size(521, 25);
            this.tsMapTool.TabIndex = 8;
            this.tsMapTool.Text = "toolStrip1";
            // 
            // tsBtnMove
            // 
            this.tsBtnMove.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tsBtnMove.Image = global::Client.Properties.Resources.pan;
            this.tsBtnMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMove.Name = "tsBtnMove";
            this.tsBtnMove.Size = new System.Drawing.Size(52, 22);
            this.tsBtnMove.Text = "移动";
            this.tsBtnMove.Click += new System.EventHandler(this.tsBtnMove_Click);
            // 
            // tsBtnZoomIn
            // 
            this.tsBtnZoomIn.Image = global::Client.Properties.Resources.zoom_in;
            this.tsBtnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomIn.Name = "tsBtnZoomIn";
            this.tsBtnZoomIn.Size = new System.Drawing.Size(52, 22);
            this.tsBtnZoomIn.Text = "放大";
            this.tsBtnZoomIn.Click += new System.EventHandler(this.tsBtnZoomIn_Click);
            // 
            // tsBtnZoomOut
            // 
            this.tsBtnZoomOut.Image = global::Client.Properties.Resources.zoom_out;
            this.tsBtnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnZoomOut.Name = "tsBtnZoomOut";
            this.tsBtnZoomOut.Size = new System.Drawing.Size(52, 22);
            this.tsBtnZoomOut.Text = "缩小";
            this.tsBtnZoomOut.Click += new System.EventHandler(this.tsBtnZoomOut_Click);
            // 
            // picLoadMap
            // 
            this.picLoadMap.Location = new System.Drawing.Point(155, 174);
            this.picLoadMap.Name = "picLoadMap";
            this.picLoadMap.Size = new System.Drawing.Size(167, 33);
            this.picLoadMap.TabIndex = 7;
            this.picLoadMap.TabStop = false;
            this.picLoadMap.Visible = false;
            // 
            // wbMap
            // 
            this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMap.IsWebBrowserContextMenuEnabled = false;
            this.wbMap.Location = new System.Drawing.Point(0, 0);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.ScriptErrorsSuppressed = true;
            this.wbMap.Size = new System.Drawing.Size(521, 478);
            this.wbMap.TabIndex = 1;
            this.wbMap.WebBrowserShortcutsEnabled = false;
            this.wbMap.MapDoubleClick += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapDoubleClick);
            this.wbMap.MapMouseUp += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapMouseUp);
            this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(-1, 1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlSetRegion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlMap);
            this.splitContainer1.Size = new System.Drawing.Size(697, 480);
            this.splitContainer1.SplitterDistance = 170;
            this.splitContainer1.TabIndex = 9;
            // 
            // itmPreSetStation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 483);
            this.Controls.Add(this.splitContainer1);
            this.Name = "itmPreSetStation";
            this.Text = "工程点站点设置";
            this.Load += new System.EventHandler(this.itmPreSetRegions_Load);
            this.Resize += new System.EventHandler(this.itmPreSetRegions_Resize);
            this.pnlSetRegion.ResumeLayout(false);
            this.pnlOperator.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.pnlConent.ResumeLayout(false);
            this.pnlConent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDistance)).EndInit();
            this.pnlMap.ResumeLayout(false);
            this.pnlMap.PerformLayout();
            this.tsMapTool.ResumeLayout(false);
            this.tsMapTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSetRegion;
        private System.Windows.Forms.Panel pnlOperator;
        private System.Windows.Forms.Panel pnlConent;
        private System.Windows.Forms.Panel pnlMap;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numDistance;
        private System.Windows.Forms.Label lblDis2;
        private System.Windows.Forms.Label lblDis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtRegionName;
        private System.Windows.Forms.TextBox txtRegionDot;
        private System.Windows.Forms.ToolStrip tsMapTool;
        private System.Windows.Forms.ToolStripButton tsBtnMove;
        private System.Windows.Forms.ToolStripButton tsBtnZoomIn;
        private System.Windows.Forms.ToolStripButton tsBtnZoomOut;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn StationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionDot;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnGetLocation;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDel;
        private WinFormsUI.Controls.GisMap wbMap;
        private System.Windows.Forms.PictureBox picLoadMap;

    }
}