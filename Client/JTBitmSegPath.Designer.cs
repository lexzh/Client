namespace Client
{
    partial class JTBitmSegPath
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpSetSubSpeedAlarmParam = new System.Windows.Forms.GroupBox();
            this.setPathSegment1 = new Client.SetPathSegment();
            this.dgvSubSpeedParam = new WinFormsUI.Controls.DataGridViewEx();
            this.PathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Choose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.TopSpeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoldTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsChoose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BeginTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EndTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.路线属性 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.路段属性 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.txtFindRegion = new System.Windows.Forms.TextBox();
            this.lblFindRegion = new System.Windows.Forms.Label();
            this.comboBoxLines = new System.Windows.Forms.ComboBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsBtnFilter = new System.Windows.Forms.ToolStripButton();
            this.lbLine = new System.Windows.Forms.Label();
            this.btmAllSelect = new System.Windows.Forms.Button();
            this.btnCopyToSelected = new System.Windows.Forms.Button();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.lblExplain = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpSetSubSpeedAlarmParam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubSpeedParam)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).BeginInit();
            this.pnlWait.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(271, 24);
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(186, 24);
            this.btnOK.TabIndex = 0;
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(674, 116);
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.lblExplain);
            this.pnlBtn.Controls.Add(this.btmAllSelect);
            this.pnlBtn.Controls.Add(this.btnCopyToSelected);
            this.pnlBtn.Controls.Add(this.pnlWait);
            this.pnlBtn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBtn.Location = new System.Drawing.Point(5, 380);
            this.pnlBtn.Size = new System.Drawing.Size(674, 52);
            this.pnlBtn.TabIndex = 2;
            this.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnCopyToSelected, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btmAllSelect, 0);
            this.pnlBtn.Controls.SetChildIndex(this.lblExplain, 0);
            // 
            // grpSetSubSpeedAlarmParam
            // 
            this.grpSetSubSpeedAlarmParam.Controls.Add(this.setPathSegment1);
            this.grpSetSubSpeedAlarmParam.Controls.Add(this.dgvSubSpeedParam);
            this.grpSetSubSpeedAlarmParam.Controls.Add(this.pnlFilter);
            this.grpSetSubSpeedAlarmParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSetSubSpeedAlarmParam.Location = new System.Drawing.Point(5, 121);
            this.grpSetSubSpeedAlarmParam.Name = "grpSetSubSpeedAlarmParam";
            this.grpSetSubSpeedAlarmParam.Size = new System.Drawing.Size(674, 259);
            this.grpSetSubSpeedAlarmParam.TabIndex = 1;
            this.grpSetSubSpeedAlarmParam.TabStop = false;
            this.grpSetSubSpeedAlarmParam.Text = "设置分段超速报警参数";
            // 
            // setPathSegment1
            // 
            this.setPathSegment1.Location = new System.Drawing.Point(0, 19);
            this.setPathSegment1.Name = "setPathSegment1";
            this.setPathSegment1.Size = new System.Drawing.Size(579, 234);
            this.setPathSegment1.TabIndex = 3;
            this.setPathSegment1.Visible = false;
            // 
            // dgvSubSpeedParam
            // 
            this.dgvSubSpeedParam.AllowUserToAddRows = false;
            this.dgvSubSpeedParam.AllowUserToDeleteRows = false;
            this.dgvSubSpeedParam.AllowUserToResizeRows = false;
            this.dgvSubSpeedParam.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSubSpeedParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvSubSpeedParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSubSpeedParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PathName,
            this.Choose,
            this.TopSpeed,
            this.HoldTime,
            this.PathID,
            this.carID,
            this.IsChoose,
            this.BeginTime,
            this.EndTime,
            this.路线属性,
            this.路段属性});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvSubSpeedParam.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvSubSpeedParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSubSpeedParam.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.dgvSubSpeedParam.Location = new System.Drawing.Point(3, 43);
            this.dgvSubSpeedParam.Name = "dgvSubSpeedParam";
            this.dgvSubSpeedParam.NotMultiSelectedColumnName = null;
            this.dgvSubSpeedParam.RowHeadersVisible = false;
            this.dgvSubSpeedParam.RowTemplate.Height = 20;
            this.dgvSubSpeedParam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSubSpeedParam.Size = new System.Drawing.Size(668, 213);
            this.dgvSubSpeedParam.TabIndex = 0;
            this.dgvSubSpeedParam.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubSpeedParam_CellClick);
            this.dgvSubSpeedParam.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubSpeedParam_CellContentClick);
            this.dgvSubSpeedParam.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubSpeedParam_CellDoubleClick);
            this.dgvSubSpeedParam.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSubSpeedParam_CellMouseUp);
            this.dgvSubSpeedParam.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSubSpeedParam_CellValueChanged);
            this.dgvSubSpeedParam.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvSubSpeedParam_DataError);
            this.dgvSubSpeedParam.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgvSubSpeedParam_EditingControlShowing);
            // 
            // PathName
            // 
            this.PathName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PathName.DataPropertyName = "PathName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.PathName.DefaultCellStyle = dataGridViewCellStyle2;
            this.PathName.Frozen = true;
            this.PathName.HeaderText = "路线名称";
            this.PathName.MinimumWidth = 78;
            this.PathName.Name = "PathName";
            this.PathName.ReadOnly = true;
            this.PathName.Width = 78;
            // 
            // Choose
            // 
            this.Choose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Choose.DataPropertyName = "Choose";
            this.Choose.FalseValue = "0";
            this.Choose.HeaderText = "选择";
            this.Choose.MinimumWidth = 35;
            this.Choose.Name = "Choose";
            this.Choose.TrueValue = "1";
            this.Choose.Width = 35;
            // 
            // TopSpeed
            // 
            this.TopSpeed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.TopSpeed.DataPropertyName = "TopSpeed";
            this.TopSpeed.HeaderText = "最高时速(km/h)";
            this.TopSpeed.MaxInputLength = 3;
            this.TopSpeed.MinimumWidth = 100;
            this.TopSpeed.Name = "TopSpeed";
            this.TopSpeed.ReadOnly = true;
            this.TopSpeed.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.TopSpeed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.TopSpeed.Visible = false;
            // 
            // HoldTime
            // 
            this.HoldTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.HoldTime.DataPropertyName = "HoldTime";
            this.HoldTime.HeaderText = "持续时长(秒)";
            this.HoldTime.MaxInputLength = 3;
            this.HoldTime.MinimumWidth = 90;
            this.HoldTime.Name = "HoldTime";
            this.HoldTime.ReadOnly = true;
            this.HoldTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.HoldTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HoldTime.Visible = false;
            // 
            // PathID
            // 
            this.PathID.DataPropertyName = "PathID";
            this.PathID.HeaderText = "区域ID";
            this.PathID.Name = "PathID";
            this.PathID.Visible = false;
            // 
            // carID
            // 
            this.carID.DataPropertyName = "carID";
            this.carID.HeaderText = "车辆ID";
            this.carID.Name = "carID";
            this.carID.Visible = false;
            // 
            // IsChoose
            // 
            this.IsChoose.DataPropertyName = "IsChoose";
            this.IsChoose.HeaderText = "选择";
            this.IsChoose.Name = "IsChoose";
            this.IsChoose.Visible = false;
            // 
            // BeginTime
            // 
            this.BeginTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.BeginTime.DataPropertyName = "BeginTime";
            this.BeginTime.HeaderText = "起始时间";
            this.BeginTime.MinimumWidth = 78;
            this.BeginTime.Name = "BeginTime";
            this.BeginTime.ReadOnly = true;
            this.BeginTime.Width = 78;
            // 
            // EndTime
            // 
            this.EndTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.EndTime.DataPropertyName = "EndTime";
            this.EndTime.HeaderText = "终止时间";
            this.EndTime.MinimumWidth = 78;
            this.EndTime.Name = "EndTime";
            this.EndTime.ReadOnly = true;
            this.EndTime.Width = 78;
            // 
            // 路线属性
            // 
            this.路线属性.DataPropertyName = "PathFlag";
            this.路线属性.HeaderText = "路线属性";
            this.路线属性.MaxInputLength = 200;
            this.路线属性.Name = "路线属性";
            this.路线属性.ReadOnly = true;
            // 
            // 路段属性
            // 
            this.路段属性.DataPropertyName = "PathSegment";
            this.路段属性.HeaderText = "路段属性";
            this.路段属性.Name = "路段属性";
            this.路段属性.ReadOnly = true;
            this.路段属性.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.路段属性.Text = "设置";
            this.路段属性.ToolTipText = "设置各个路段报警条件";
            this.路段属性.Width = 80;
            // 
            // pnlFilter
            // 
            this.pnlFilter.Controls.Add(this.txtFindRegion);
            this.pnlFilter.Controls.Add(this.lblFindRegion);
            this.pnlFilter.Controls.Add(this.comboBoxLines);
            this.pnlFilter.Controls.Add(this.toolStrip1);
            this.pnlFilter.Controls.Add(this.lbLine);
            this.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 17);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(668, 26);
            this.pnlFilter.TabIndex = 2;
            // 
            // txtFindRegion
            // 
            this.txtFindRegion.Location = new System.Drawing.Point(385, 3);
            this.txtFindRegion.Name = "txtFindRegion";
            this.txtFindRegion.Size = new System.Drawing.Size(100, 21);
            this.txtFindRegion.TabIndex = 5;
            this.txtFindRegion.Tag = "9999";
            this.txtFindRegion.TextChanged += new System.EventHandler(this.txtFindRegion_TextChanged);
            // 
            // lblFindRegion
            // 
            this.lblFindRegion.AutoSize = true;
            this.lblFindRegion.Location = new System.Drawing.Point(324, 7);
            this.lblFindRegion.Name = "lblFindRegion";
            this.lblFindRegion.Size = new System.Drawing.Size(65, 12);
            this.lblFindRegion.TabIndex = 4;
            this.lblFindRegion.Tag = "999";
            this.lblFindRegion.Text = "查找路线：";
            // 
            // comboBoxLines
            // 
            this.comboBoxLines.DisplayMember = "PathgroupName";
            this.comboBoxLines.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLines.FormattingEnabled = true;
            this.comboBoxLines.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxLines.Location = new System.Drawing.Point(123, 3);
            this.comboBoxLines.Name = "comboBoxLines";
            this.comboBoxLines.Size = new System.Drawing.Size(157, 20);
            this.comboBoxLines.TabIndex = 3;
            this.comboBoxLines.Tag = "999";
            this.comboBoxLines.ValueMember = "PathgroupID";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnFilter});
            this.toolStrip1.Location = new System.Drawing.Point(285, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(26, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsBtnFilter
            // 
            this.tsBtnFilter.BackgroundImage = global::Client.Properties.Resources.find;
            this.tsBtnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnFilter.Name = "tsBtnFilter";
            this.tsBtnFilter.Size = new System.Drawing.Size(23, 22);
            this.tsBtnFilter.Text = "搜索 ";
            this.tsBtnFilter.Click += new System.EventHandler(this.tsBtnFilter_Click);
            // 
            // lbLine
            // 
            this.lbLine.AutoSize = true;
            this.lbLine.Location = new System.Drawing.Point(23, 7);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new System.Drawing.Size(89, 12);
            this.lbLine.TabIndex = 1;
            this.lbLine.Tag = "999";
            this.lbLine.Text = "路线分组名称：";
            // 
            // btmAllSelect
            // 
            this.btmAllSelect.Location = new System.Drawing.Point(16, 24);
            this.btmAllSelect.Name = "btmAllSelect";
            this.btmAllSelect.Size = new System.Drawing.Size(75, 23);
            this.btmAllSelect.TabIndex = 2;
            this.btmAllSelect.Text = "全选";
            this.btmAllSelect.UseVisualStyleBackColor = true;
            this.btmAllSelect.Click += new System.EventHandler(this.btmAllSelect_Click);
            // 
            // btnCopyToSelected
            // 
            this.btnCopyToSelected.Location = new System.Drawing.Point(101, 24);
            this.btnCopyToSelected.Name = "btnCopyToSelected";
            this.btnCopyToSelected.Size = new System.Drawing.Size(75, 23);
            this.btnCopyToSelected.TabIndex = 3;
            this.btnCopyToSelected.Text = "应用到所选";
            this.btnCopyToSelected.UseVisualStyleBackColor = true;
            this.btnCopyToSelected.Visible = false;
            this.btnCopyToSelected.Click += new System.EventHandler(this.btnCopyToSelected_Click);
            // 
            // pbPicWait
            // 
            this.pbPicWait.BackColor = System.Drawing.Color.Transparent;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(3, 3);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new System.Drawing.Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            // 
            // lblWaitText
            // 
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.Location = new System.Drawing.Point(22, 5);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new System.Drawing.Size(89, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在执行中....";
            this.lblWaitText.Visible = false;
            // 
            // pnlWait
            // 
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(347, 24);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new System.Drawing.Size(129, 22);
            this.pnlWait.TabIndex = 12;
            this.pnlWait.Tag = "9999";
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = System.Drawing.Color.Red;
            this.lblExplain.Location = new System.Drawing.Point(15, 7);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(293, 12);
            this.lblExplain.TabIndex = 13;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = "备注：\"选择\"相应路线，双击单元格可设置\"路线属性\"";
            // 
            // JTBitmSegPath1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(684, 437);
            this.Controls.Add(this.grpSetSubSpeedAlarmParam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.MaximizeBox = true;
            this.Name = "JTBitmSegPath1";
            this.Text = "SetSubSpeedAlarm";
            this.Load += new System.EventHandler(this.itmSegPath_Load);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpSetSubSpeedAlarmParam, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.pnlBtn.PerformLayout();
            this.grpSetSubSpeedAlarmParam.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSubSpeedParam)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).EndInit();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSetSubSpeedAlarmParam;

        private WinFormsUI.Controls.DataGridViewEx dgvSubSpeedParam;

        private System.Windows.Forms.Panel pnlFilter;

        private System.Windows.Forms.ComboBox comboBoxLines;

        private System.Windows.Forms.ToolStrip toolStrip1;

        private System.Windows.Forms.ToolStripButton tsBtnFilter;

        private System.Windows.Forms.Label lbLine;

        private System.Windows.Forms.Button btmAllSelect;

        private System.Windows.Forms.Button btnCopyToSelected;

        private System.Windows.Forms.Label lblFindRegion;

        private System.Windows.Forms.TextBox txtFindRegion;

        private System.Windows.Forms.PictureBox pbPicWait;

        private System.Windows.Forms.Panel pnlWait;

        private System.Windows.Forms.Label lblWaitText;

        private System.Windows.Forms.DataGridViewTextBoxColumn PathName;

        private System.Windows.Forms.DataGridViewCheckBoxColumn Choose;

        private System.Windows.Forms.DataGridViewTextBoxColumn TopSpeed;

        private System.Windows.Forms.DataGridViewTextBoxColumn HoldTime;

        private System.Windows.Forms.DataGridViewTextBoxColumn PathID;

        private System.Windows.Forms.DataGridViewTextBoxColumn carID;

        private System.Windows.Forms.DataGridViewTextBoxColumn IsChoose;

        private System.Windows.Forms.DataGridViewTextBoxColumn BeginTime;

        private System.Windows.Forms.DataGridViewTextBoxColumn EndTime;

        private System.Windows.Forms.DataGridViewTextBoxColumn 路线属性;

        private System.Windows.Forms.DataGridViewButtonColumn 路段属性;

        private System.Windows.Forms.Label lblExplain;

        private SetPathSegment setPathSegment1;
    }
}
