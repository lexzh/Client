namespace Client
{
    partial class itmCarPlayTrack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itmCarPlayTrack));
            this.pnlHandle = new System.Windows.Forms.Panel();
            this.pbPicture = new System.Windows.Forms.PictureBox();
            this.grpDetail = new System.Windows.Forms.GroupBox();
            this.lblIsBlackBoxValue = new System.Windows.Forms.Label();
            this.lblStateValue = new System.Windows.Forms.Label();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.lblLatitudeValue = new System.Windows.Forms.Label();
            this.lblLongitudeValue = new System.Windows.Forms.Label();
            this.lblGpsTimeValue = new System.Windows.Forms.Label();
            this.lblIsBlackBox = new System.Windows.Forms.Label();
            this.lblState = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblLatitude = new System.Windows.Forms.Label();
            this.lblLongitude = new System.Windows.Forms.Label();
            this.lblGpsTime = new System.Windows.Forms.Label();
            this.grpPlay = new System.Windows.Forms.GroupBox();
            this.txtWaitTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkWaitTime = new System.Windows.Forms.CheckBox();
            this.lblQuick = new System.Windows.Forms.Label();
            this.chkShowPointOnly = new System.Windows.Forms.CheckBox();
            this.chkUnShowTrack = new System.Windows.Forms.CheckBox();
            this.lblMileageValue = new System.Windows.Forms.Label();
            this.lblRecordValue = new System.Windows.Forms.Label();
            this.lblMileage = new System.Windows.Forms.Label();
            this.lblFileValue = new System.Windows.Forms.Label();
            this.lblRecord = new System.Windows.Forms.Label();
            this.lblPlaySpeed = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.tbPlaySpeed = new System.Windows.Forms.TrackBar();
            this.tbPlay = new System.Windows.Forms.TrackBar();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnLocal = new System.Windows.Forms.Button();
            this.grpEndTime = new System.Windows.Forms.GroupBox();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.grpStartTime = new System.Windows.Forms.GroupBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.grpCarNum = new System.Windows.Forms.GroupBox();
            this.cmbCarNum = new WinFormsUI.Controls.ComBox();
            this.lblCarNum = new System.Windows.Forms.Label();
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.picLoadMap = new System.Windows.Forms.PictureBox();
            this.dgvCarPlay = new System.Windows.Forms.DataGridView();
            this.messId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gpsTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.receTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Longitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Latitude = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CarAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pbCarPlay = new System.Windows.Forms.ProgressBar();
            this.wbMap = new WinFormsUI.Controls.GisMap();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.lblSelectMap = new System.Windows.Forms.ToolStripLabel();
            this.cmbSelectMap = new System.Windows.Forms.ToolStripComboBox();
            this.tsbSaveImage = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbArrowhead = new System.Windows.Forms.ToolStripButton();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomUp = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomDown = new System.Windows.Forms.ToolStripButton();
            this.tsbShowHint = new System.Windows.Forms.ToolStripButton();
            this.tsbCenter = new System.Windows.Forms.ToolStripButton();
            this.tsbDistance = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveLine = new System.Windows.Forms.ToolStripButton();
            this.tsbAddPoint = new System.Windows.Forms.ToolStripButton();
            this.tsbDelPoint = new System.Windows.Forms.ToolStripButton();
            this.tsbToGrid = new System.Windows.Forms.ToolStripButton();
            this.tsbToMap = new System.Windows.Forms.ToolStripButton();
            this.tsbShowAll = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.ofdLocal = new System.Windows.Forms.OpenFileDialog();
            this.ppdMap = new System.Windows.Forms.PrintPreviewDialog();
            this.scPlayTrack = new System.Windows.Forms.SplitContainer();
            this.sfdLocal = new System.Windows.Forms.SaveFileDialog();
            this.pdMap = new System.Drawing.Printing.PrintDocument();
            this.pnlHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).BeginInit();
            this.grpDetail.SuspendLayout();
            this.grpPlay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlaySpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlay)).BeginInit();
            this.grpEndTime.SuspendLayout();
            this.grpStartTime.SuspendLayout();
            this.grpCarNum.SuspendLayout();
            this.grpMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPlay)).BeginInit();
            this.pnlTool.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.scPlayTrack.Panel1.SuspendLayout();
            this.scPlayTrack.Panel2.SuspendLayout();
            this.scPlayTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHandle
            // 
            this.pnlHandle.Controls.Add(this.pbPicture);
            this.pnlHandle.Controls.Add(this.grpDetail);
            this.pnlHandle.Controls.Add(this.grpPlay);
            this.pnlHandle.Controls.Add(this.grpEndTime);
            this.pnlHandle.Controls.Add(this.grpStartTime);
            this.pnlHandle.Controls.Add(this.grpCarNum);
            this.pnlHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHandle.Location = new System.Drawing.Point(0, 0);
            this.pnlHandle.Name = "pnlHandle";
            this.pnlHandle.Padding = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pnlHandle.Size = new System.Drawing.Size(310, 631);
            this.pnlHandle.TabIndex = 0;
            // 
            // pbPicture
            // 
            this.pbPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbPicture.Location = new System.Drawing.Point(3, 594);
            this.pbPicture.Name = "pbPicture";
            this.pbPicture.Size = new System.Drawing.Size(304, 37);
            this.pbPicture.TabIndex = 8;
            this.pbPicture.TabStop = false;
            // 
            // grpDetail
            // 
            this.grpDetail.Controls.Add(this.lblIsBlackBoxValue);
            this.grpDetail.Controls.Add(this.lblStateValue);
            this.grpDetail.Controls.Add(this.lblSpeedValue);
            this.grpDetail.Controls.Add(this.lblLatitudeValue);
            this.grpDetail.Controls.Add(this.lblLongitudeValue);
            this.grpDetail.Controls.Add(this.lblGpsTimeValue);
            this.grpDetail.Controls.Add(this.lblIsBlackBox);
            this.grpDetail.Controls.Add(this.lblState);
            this.grpDetail.Controls.Add(this.lblSpeed);
            this.grpDetail.Controls.Add(this.lblLatitude);
            this.grpDetail.Controls.Add(this.lblLongitude);
            this.grpDetail.Controls.Add(this.lblGpsTime);
            this.grpDetail.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetail.Location = new System.Drawing.Point(3, 437);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new System.Drawing.Size(304, 157);
            this.grpDetail.TabIndex = 4;
            this.grpDetail.TabStop = false;
            // 
            // lblIsBlackBoxValue
            // 
            this.lblIsBlackBoxValue.AutoSize = true;
            this.lblIsBlackBoxValue.Location = new System.Drawing.Point(115, 129);
            this.lblIsBlackBoxValue.Name = "lblIsBlackBoxValue";
            this.lblIsBlackBoxValue.Size = new System.Drawing.Size(0, 12);
            this.lblIsBlackBoxValue.TabIndex = 4;
            // 
            // lblStateValue
            // 
            this.lblStateValue.AutoSize = true;
            this.lblStateValue.Location = new System.Drawing.Point(115, 107);
            this.lblStateValue.Name = "lblStateValue";
            this.lblStateValue.Size = new System.Drawing.Size(0, 12);
            this.lblStateValue.TabIndex = 4;
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Location = new System.Drawing.Point(115, 85);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(0, 12);
            this.lblSpeedValue.TabIndex = 4;
            // 
            // lblLatitudeValue
            // 
            this.lblLatitudeValue.AutoSize = true;
            this.lblLatitudeValue.Location = new System.Drawing.Point(115, 63);
            this.lblLatitudeValue.Name = "lblLatitudeValue";
            this.lblLatitudeValue.Size = new System.Drawing.Size(0, 12);
            this.lblLatitudeValue.TabIndex = 4;
            // 
            // lblLongitudeValue
            // 
            this.lblLongitudeValue.AutoSize = true;
            this.lblLongitudeValue.Location = new System.Drawing.Point(115, 41);
            this.lblLongitudeValue.Name = "lblLongitudeValue";
            this.lblLongitudeValue.Size = new System.Drawing.Size(0, 12);
            this.lblLongitudeValue.TabIndex = 4;
            // 
            // lblGpsTimeValue
            // 
            this.lblGpsTimeValue.AutoSize = true;
            this.lblGpsTimeValue.Location = new System.Drawing.Point(115, 19);
            this.lblGpsTimeValue.Name = "lblGpsTimeValue";
            this.lblGpsTimeValue.Size = new System.Drawing.Size(0, 12);
            this.lblGpsTimeValue.TabIndex = 4;
            // 
            // lblIsBlackBox
            // 
            this.lblIsBlackBox.AutoSize = true;
            this.lblIsBlackBox.Location = new System.Drawing.Point(11, 129);
            this.lblIsBlackBox.Name = "lblIsBlackBox";
            this.lblIsBlackBox.Size = new System.Drawing.Size(101, 12);
            this.lblIsBlackBox.TabIndex = 3;
            this.lblIsBlackBox.Text = "是否黑匣子数据：";
            // 
            // lblState
            // 
            this.lblState.AutoSize = true;
            this.lblState.Location = new System.Drawing.Point(71, 107);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(41, 12);
            this.lblState.TabIndex = 3;
            this.lblState.Text = "状态：";
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Location = new System.Drawing.Point(71, 85);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(41, 12);
            this.lblSpeed.TabIndex = 3;
            this.lblSpeed.Text = "速度：";
            // 
            // lblLatitude
            // 
            this.lblLatitude.AutoSize = true;
            this.lblLatitude.Location = new System.Drawing.Point(71, 63);
            this.lblLatitude.Name = "lblLatitude";
            this.lblLatitude.Size = new System.Drawing.Size(41, 12);
            this.lblLatitude.TabIndex = 3;
            this.lblLatitude.Text = "纬度：";
            // 
            // lblLongitude
            // 
            this.lblLongitude.AutoSize = true;
            this.lblLongitude.Location = new System.Drawing.Point(71, 41);
            this.lblLongitude.Name = "lblLongitude";
            this.lblLongitude.Size = new System.Drawing.Size(41, 12);
            this.lblLongitude.TabIndex = 3;
            this.lblLongitude.Text = "经度：";
            // 
            // lblGpsTime
            // 
            this.lblGpsTime.AutoSize = true;
            this.lblGpsTime.Location = new System.Drawing.Point(53, 19);
            this.lblGpsTime.Name = "lblGpsTime";
            this.lblGpsTime.Size = new System.Drawing.Size(59, 12);
            this.lblGpsTime.TabIndex = 3;
            this.lblGpsTime.Text = "GPS时间：";
            // 
            // grpPlay
            // 
            this.grpPlay.Controls.Add(this.txtWaitTime);
            this.grpPlay.Controls.Add(this.label1);
            this.grpPlay.Controls.Add(this.chkWaitTime);
            this.grpPlay.Controls.Add(this.lblQuick);
            this.grpPlay.Controls.Add(this.chkShowPointOnly);
            this.grpPlay.Controls.Add(this.chkUnShowTrack);
            this.grpPlay.Controls.Add(this.lblMileageValue);
            this.grpPlay.Controls.Add(this.lblRecordValue);
            this.grpPlay.Controls.Add(this.lblMileage);
            this.grpPlay.Controls.Add(this.lblFileValue);
            this.grpPlay.Controls.Add(this.lblRecord);
            this.grpPlay.Controls.Add(this.lblPlaySpeed);
            this.grpPlay.Controls.Add(this.lblFile);
            this.grpPlay.Controls.Add(this.tbPlaySpeed);
            this.grpPlay.Controls.Add(this.tbPlay);
            this.grpPlay.Controls.Add(this.btnExit);
            this.grpPlay.Controls.Add(this.btnSave);
            this.grpPlay.Controls.Add(this.btnStop);
            this.grpPlay.Controls.Add(this.btnPause);
            this.grpPlay.Controls.Add(this.btnPlay);
            this.grpPlay.Controls.Add(this.btnLocal);
            this.grpPlay.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPlay.Location = new System.Drawing.Point(3, 164);
            this.grpPlay.Name = "grpPlay";
            this.grpPlay.Size = new System.Drawing.Size(304, 273);
            this.grpPlay.TabIndex = 3;
            this.grpPlay.TabStop = false;
            // 
            // txtWaitTime
            // 
            this.txtWaitTime.Enabled = false;
            this.txtWaitTime.Location = new System.Drawing.Point(82, 186);
            this.txtWaitTime.MaxLength = 3;
            this.txtWaitTime.Name = "txtWaitTime";
            this.txtWaitTime.Size = new System.Drawing.Size(30, 21);
            this.txtWaitTime.TabIndex = 10;
            this.txtWaitTime.Text = "5";
            this.txtWaitTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWaitTime.WordWrap = false;
            this.txtWaitTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWaitTime_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "分";
            // 
            // chkWaitTime
            // 
            this.chkWaitTime.AutoSize = true;
            this.chkWaitTime.Checked = true;
            this.chkWaitTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWaitTime.Location = new System.Drawing.Point(13, 191);
            this.chkWaitTime.Name = "chkWaitTime";
            this.chkWaitTime.Size = new System.Drawing.Size(72, 16);
            this.chkWaitTime.TabIndex = 8;
            this.chkWaitTime.Text = "停留时间";
            this.chkWaitTime.UseVisualStyleBackColor = true;
            this.chkWaitTime.CheckedChanged += new System.EventHandler(this.chkWaitTime_CheckedChanged);
            // 
            // lblQuick
            // 
            this.lblQuick.AutoSize = true;
            this.lblQuick.Location = new System.Drawing.Point(241, 226);
            this.lblQuick.Name = "lblQuick";
            this.lblQuick.Size = new System.Drawing.Size(17, 12);
            this.lblQuick.TabIndex = 4;
            this.lblQuick.Text = "快";
            // 
            // chkShowPointOnly
            // 
            this.chkShowPointOnly.AutoSize = true;
            this.chkShowPointOnly.Location = new System.Drawing.Point(145, 164);
            this.chkShowPointOnly.Name = "chkShowPointOnly";
            this.chkShowPointOnly.Size = new System.Drawing.Size(96, 16);
            this.chkShowPointOnly.TabIndex = 3;
            this.chkShowPointOnly.Text = "只显示轨迹点";
            this.chkShowPointOnly.UseVisualStyleBackColor = true;
            this.chkShowPointOnly.Visible = false;
            // 
            // chkUnShowTrack
            // 
            this.chkUnShowTrack.AutoSize = true;
            this.chkUnShowTrack.Location = new System.Drawing.Point(13, 164);
            this.chkUnShowTrack.Name = "chkUnShowTrack";
            this.chkUnShowTrack.Size = new System.Drawing.Size(108, 16);
            this.chkUnShowTrack.TabIndex = 3;
            this.chkUnShowTrack.Text = "不显示车辆轨迹";
            this.chkUnShowTrack.UseVisualStyleBackColor = true;
            // 
            // lblMileageValue
            // 
            this.lblMileageValue.AutoSize = true;
            this.lblMileageValue.Location = new System.Drawing.Point(143, 140);
            this.lblMileageValue.Name = "lblMileageValue";
            this.lblMileageValue.Size = new System.Drawing.Size(0, 12);
            this.lblMileageValue.TabIndex = 2;
            // 
            // lblRecordValue
            // 
            this.lblRecordValue.AutoSize = true;
            this.lblRecordValue.Location = new System.Drawing.Point(143, 115);
            this.lblRecordValue.Name = "lblRecordValue";
            this.lblRecordValue.Size = new System.Drawing.Size(0, 12);
            this.lblRecordValue.TabIndex = 2;
            // 
            // lblMileage
            // 
            this.lblMileage.AutoSize = true;
            this.lblMileage.Location = new System.Drawing.Point(11, 140);
            this.lblMileage.Name = "lblMileage";
            this.lblMileage.Size = new System.Drawing.Size(131, 12);
            this.lblMileage.TabIndex = 2;
            this.lblMileage.Text = "当前公里数/总公里数：";
            // 
            // lblFileValue
            // 
            this.lblFileValue.AutoSize = true;
            this.lblFileValue.Location = new System.Drawing.Point(78, 91);
            this.lblFileValue.Name = "lblFileValue";
            this.lblFileValue.Size = new System.Drawing.Size(0, 12);
            this.lblFileValue.TabIndex = 2;
            // 
            // lblRecord
            // 
            this.lblRecord.AutoSize = true;
            this.lblRecord.Location = new System.Drawing.Point(11, 115);
            this.lblRecord.Name = "lblRecord";
            this.lblRecord.Size = new System.Drawing.Size(119, 12);
            this.lblRecord.TabIndex = 2;
            this.lblRecord.Text = "播放总数/总记录数：";
            // 
            // lblPlaySpeed
            // 
            this.lblPlaySpeed.AutoSize = true;
            this.lblPlaySpeed.Location = new System.Drawing.Point(11, 226);
            this.lblPlaySpeed.Name = "lblPlaySpeed";
            this.lblPlaySpeed.Size = new System.Drawing.Size(77, 12);
            this.lblPlaySpeed.TabIndex = 2;
            this.lblPlaySpeed.Text = "播放速度：慢";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(11, 91);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 2;
            this.lblFile.Text = "当前文件：";
            // 
            // tbPlaySpeed
            // 
            this.tbPlaySpeed.LargeChange = 1;
            this.tbPlaySpeed.Location = new System.Drawing.Point(85, 220);
            this.tbPlaySpeed.Margin = new System.Windows.Forms.Padding(0);
            this.tbPlaySpeed.Maximum = 14;
            this.tbPlaySpeed.Name = "tbPlaySpeed";
            this.tbPlaySpeed.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tbPlaySpeed.Size = new System.Drawing.Size(156, 45);
            this.tbPlaySpeed.SmallChange = 0;
            this.tbPlaySpeed.TabIndex = 7;
            this.tbPlaySpeed.Value = 5;
            this.tbPlaySpeed.ValueChanged += new System.EventHandler(this.tbPlaySpeed_ValueChanged);
            // 
            // tbPlay
            // 
            this.tbPlay.LargeChange = 1;
            this.tbPlay.Location = new System.Drawing.Point(5, 49);
            this.tbPlay.Margin = new System.Windows.Forms.Padding(0);
            this.tbPlay.Maximum = 100;
            this.tbPlay.Name = "tbPlay";
            this.tbPlay.Size = new System.Drawing.Size(280, 45);
            this.tbPlay.SmallChange = 0;
            this.tbPlay.TabIndex = 6;
            this.tbPlay.TickFrequency = 5;
            this.tbPlay.ValueChanged += new System.EventHandler(this.tbPlay_ValueChanged);
            this.tbPlay.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tbPlay_KeyUp);
            this.tbPlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tbPlay_MouseUp);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(238, 20);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "退出";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(193, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(40, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(148, 20);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(40, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(103, 20);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(40, 23);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "暂停";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(58, 20);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(40, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "播放";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnLocal
            // 
            this.btnLocal.Location = new System.Drawing.Point(13, 20);
            this.btnLocal.Name = "btnLocal";
            this.btnLocal.Size = new System.Drawing.Size(40, 23);
            this.btnLocal.TabIndex = 0;
            this.btnLocal.Text = "本地";
            this.btnLocal.UseVisualStyleBackColor = true;
            this.btnLocal.Click += new System.EventHandler(this.btnLocal_Click);
            // 
            // grpEndTime
            // 
            this.grpEndTime.Controls.Add(this.dtpEndTime);
            this.grpEndTime.Controls.Add(this.lblEndTime);
            this.grpEndTime.Controls.Add(this.dtpEndDate);
            this.grpEndTime.Controls.Add(this.lblEndDate);
            this.grpEndTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEndTime.Location = new System.Drawing.Point(3, 107);
            this.grpEndTime.Name = "grpEndTime";
            this.grpEndTime.Size = new System.Drawing.Size(304, 57);
            this.grpEndTime.TabIndex = 2;
            this.grpEndTime.TabStop = false;
            this.grpEndTime.Text = "GPS结束时间";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(193, 22);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(89, 21);
            this.dtpEndTime.TabIndex = 1;
            this.dtpEndTime.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(152, 26);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(41, 12);
            this.lblEndTime.TabIndex = 0;
            this.lblEndTime.Text = "时间：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(52, 22);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(89, 21);
            this.dtpEndDate.TabIndex = 0;
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(11, 26);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(41, 12);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "日期：";
            // 
            // grpStartTime
            // 
            this.grpStartTime.Controls.Add(this.dtpStartTime);
            this.grpStartTime.Controls.Add(this.lblStartTime);
            this.grpStartTime.Controls.Add(this.dtpStartDate);
            this.grpStartTime.Controls.Add(this.lblStartDate);
            this.grpStartTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpStartTime.Location = new System.Drawing.Point(3, 50);
            this.grpStartTime.Name = "grpStartTime";
            this.grpStartTime.Size = new System.Drawing.Size(304, 57);
            this.grpStartTime.TabIndex = 1;
            this.grpStartTime.TabStop = false;
            this.grpStartTime.Text = "GPS开始时间";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(193, 22);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(89, 21);
            this.dtpStartTime.TabIndex = 1;
            this.dtpStartTime.Value = new System.DateTime(2009, 10, 10, 0, 0, 0, 0);
            this.dtpStartTime.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(152, 26);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(41, 12);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "时间：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(52, 22);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(89, 21);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(11, 26);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(41, 12);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "日期：";
            // 
            // grpCarNum
            // 
            this.grpCarNum.Controls.Add(this.cmbCarNum);
            this.grpCarNum.Controls.Add(this.lblCarNum);
            this.grpCarNum.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCarNum.Location = new System.Drawing.Point(3, 0);
            this.grpCarNum.Name = "grpCarNum";
            this.grpCarNum.Size = new System.Drawing.Size(304, 50);
            this.grpCarNum.TabIndex = 0;
            this.grpCarNum.TabStop = false;
            // 
            // cmbCarNum
            // 
            this.cmbCarNum.DisplayMember = "Display";
            this.cmbCarNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCarNum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCarNum.FormattingEnabled = true;
            this.cmbCarNum.Location = new System.Drawing.Point(73, 17);
            this.cmbCarNum.Name = "cmbCarNum";
            this.cmbCarNum.Size = new System.Drawing.Size(137, 20);
            this.cmbCarNum.TabIndex = 0;
            this.cmbCarNum.ValueMember = "Value";
            this.cmbCarNum.SelectedValueChanged += new System.EventHandler(this.cmbCarNum_SelectedValueChanged);
            // 
            // lblCarNum
            // 
            this.lblCarNum.AutoSize = true;
            this.lblCarNum.Location = new System.Drawing.Point(10, 22);
            this.lblCarNum.Name = "lblCarNum";
            this.lblCarNum.Size = new System.Drawing.Size(65, 12);
            this.lblCarNum.TabIndex = 4;
            this.lblCarNum.Text = "车辆号码：";
            // 
            // grpMap
            // 
            this.grpMap.Controls.Add(this.picLoadMap);
            this.grpMap.Controls.Add(this.dgvCarPlay);
            this.grpMap.Controls.Add(this.pbCarPlay);
            this.grpMap.Controls.Add(this.wbMap);
            this.grpMap.Controls.Add(this.pnlTool);
            this.grpMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMap.Location = new System.Drawing.Point(0, 0);
            this.grpMap.Name = "grpMap";
            this.grpMap.Size = new System.Drawing.Size(817, 631);
            this.grpMap.TabIndex = 1;
            this.grpMap.TabStop = false;
            this.grpMap.Text = "轨迹显示";
            // 
            // picLoadMap
            // 
            this.picLoadMap.ErrorImage = null;
            this.picLoadMap.Image = ((System.Drawing.Image)(resources.GetObject("picLoadMap.Image")));
            this.picLoadMap.InitialImage = null;
            this.picLoadMap.Location = new System.Drawing.Point(214, 204);
            this.picLoadMap.Name = "picLoadMap";
            this.picLoadMap.Size = new System.Drawing.Size(167, 33);
            this.picLoadMap.TabIndex = 5;
            this.picLoadMap.TabStop = false;
            this.picLoadMap.Visible = false;
            // 
            // dgvCarPlay
            // 
            this.dgvCarPlay.AllowUserToAddRows = false;
            this.dgvCarPlay.AllowUserToDeleteRows = false;
            this.dgvCarPlay.AllowUserToResizeRows = false;
            this.dgvCarPlay.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvCarPlay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarPlay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.messId,
            this.gpsTime,
            this.receTime,
            this.Longitude,
            this.Latitude,
            this.Speed,
            this.CarStatus,
            this.CarAddress});
            this.dgvCarPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCarPlay.Location = new System.Drawing.Point(3, 41);
            this.dgvCarPlay.Name = "dgvCarPlay";
            this.dgvCarPlay.ReadOnly = true;
            this.dgvCarPlay.RowHeadersVisible = false;
            this.dgvCarPlay.RowTemplate.Height = 20;
            this.dgvCarPlay.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCarPlay.Size = new System.Drawing.Size(811, 564);
            this.dgvCarPlay.TabIndex = 0;
            this.dgvCarPlay.Visible = false;
            this.dgvCarPlay.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCarPlay_CellMouseDoubleClick);
            // 
            // messId
            // 
            this.messId.DataPropertyName = "messId";
            this.messId.HeaderText = "messId";
            this.messId.Name = "messId";
            this.messId.ReadOnly = true;
            this.messId.Visible = false;
            this.messId.Width = 60;
            // 
            // gpsTime
            // 
            this.gpsTime.DataPropertyName = "gpsTime";
            this.gpsTime.HeaderText = "GPS时间";
            this.gpsTime.MinimumWidth = 100;
            this.gpsTime.Name = "gpsTime";
            this.gpsTime.ReadOnly = true;
            this.gpsTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.gpsTime.Width = 130;
            // 
            // receTime
            // 
            this.receTime.DataPropertyName = "receTime";
            this.receTime.HeaderText = "接收时间";
            this.receTime.MinimumWidth = 100;
            this.receTime.Name = "receTime";
            this.receTime.ReadOnly = true;
            this.receTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.receTime.Width = 130;
            // 
            // Longitude
            // 
            this.Longitude.DataPropertyName = "Longitude";
            this.Longitude.HeaderText = "经度";
            this.Longitude.MinimumWidth = 50;
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Longitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Longitude.Width = 120;
            // 
            // Latitude
            // 
            this.Latitude.DataPropertyName = "Latitude";
            this.Latitude.HeaderText = "纬度";
            this.Latitude.MinimumWidth = 50;
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Latitude.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Latitude.Width = 120;
            // 
            // Speed
            // 
            this.Speed.DataPropertyName = "Speed";
            this.Speed.HeaderText = "速度";
            this.Speed.MinimumWidth = 50;
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.Speed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CarStatus
            // 
            this.CarStatus.DataPropertyName = "CarStatus";
            this.CarStatus.HeaderText = "状态";
            this.CarStatus.MinimumWidth = 50;
            this.CarStatus.Name = "CarStatus";
            this.CarStatus.ReadOnly = true;
            this.CarStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CarStatus.Width = 120;
            // 
            // CarAddress
            // 
            this.CarAddress.DataPropertyName = "CarAddress";
            this.CarAddress.HeaderText = "位置信息";
            this.CarAddress.Name = "CarAddress";
            this.CarAddress.ReadOnly = true;
            this.CarAddress.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CarAddress.Width = 250;
            // 
            // pbCarPlay
            // 
            this.pbCarPlay.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pbCarPlay.Location = new System.Drawing.Point(3, 605);
            this.pbCarPlay.Name = "pbCarPlay";
            this.pbCarPlay.Size = new System.Drawing.Size(811, 23);
            this.pbCarPlay.TabIndex = 4;
            this.pbCarPlay.Visible = false;
            // 
            // wbMap
            // 
            this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMap.IsWebBrowserContextMenuEnabled = false;
            this.wbMap.Location = new System.Drawing.Point(3, 41);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.ScriptErrorsSuppressed = true;
            this.wbMap.Size = new System.Drawing.Size(811, 587);
            this.wbMap.TabIndex = 2;
            this.wbMap.WebBrowserShortcutsEnabled = false;
            this.wbMap.MapMouseUp += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapMouseUp);
            this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.tsMenu);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(3, 17);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(811, 24);
            this.pnlTool.TabIndex = 3;
            // 
            // tsMenu
            // 
            this.tsMenu.AutoSize = false;
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(17, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelectMap,
            this.cmbSelectMap,
            this.tsbSaveImage,
            this.tsbPrint,
            this.tsbArrowhead,
            this.tsbMove,
            this.tsbZoomUp,
            this.tsbZoomDown,
            this.tsbShowHint,
            this.tsbCenter,
            this.tsbDistance,
            this.tsbSaveLine,
            this.tsbAddPoint,
            this.tsbDelPoint,
            this.tsbToGrid,
            this.tsbToMap,
            this.tsbShowAll,
            this.tsbRefresh,
            this.tsbExport});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(0);
            this.tsMenu.Size = new System.Drawing.Size(811, 24);
            this.tsMenu.TabIndex = 1;
            // 
            // lblSelectMap
            // 
            this.lblSelectMap.Name = "lblSelectMap";
            this.lblSelectMap.Size = new System.Drawing.Size(68, 21);
            this.lblSelectMap.Text = "选择地图：";
            // 
            // cmbSelectMap
            // 
            this.cmbSelectMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectMap.Name = "cmbSelectMap";
            this.cmbSelectMap.Size = new System.Drawing.Size(150, 24);
            this.cmbSelectMap.SelectedIndexChanged += new System.EventHandler(this.cmbSelectMap_SelectedIndexChanged);
            // 
            // tsbSaveImage
            // 
            this.tsbSaveImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSaveImage.Image = global::Client.Properties.Resources.Save;
            this.tsbSaveImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveImage.Name = "tsbSaveImage";
            this.tsbSaveImage.Size = new System.Drawing.Size(23, 21);
            this.tsbSaveImage.Text = "保存地图";
            this.tsbSaveImage.Click += new System.EventHandler(this.tsbSaveImage_Click);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Margin = new System.Windows.Forms.Padding(0);
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbPrint.Size = new System.Drawing.Size(23, 24);
            this.tsbPrint.Text = "打印";
            this.tsbPrint.Click += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbArrowhead
            // 
            this.tsbArrowhead.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbArrowhead.Enabled = false;
            this.tsbArrowhead.Image = ((System.Drawing.Image)(resources.GetObject("tsbArrowhead.Image")));
            this.tsbArrowhead.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbArrowhead.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbArrowhead.Margin = new System.Windows.Forms.Padding(0);
            this.tsbArrowhead.Name = "tsbArrowhead";
            this.tsbArrowhead.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbArrowhead.Size = new System.Drawing.Size(23, 24);
            this.tsbArrowhead.Text = "箭头";
            this.tsbArrowhead.Visible = false;
            this.tsbArrowhead.Click += new System.EventHandler(this.tsbArrowhead_Click);
            // 
            // tsbMove
            // 
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMove.Margin = new System.Windows.Forms.Padding(0);
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbMove.Size = new System.Drawing.Size(55, 24);
            this.tsbMove.Text = "移动";
            this.tsbMove.ToolTipText = "移动地图";
            this.tsbMove.Click += new System.EventHandler(this.tsbMove_Click);
            // 
            // tsbZoomUp
            // 
            this.tsbZoomUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomUp.Image")));
            this.tsbZoomUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomUp.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomUp.Name = "tsbZoomUp";
            this.tsbZoomUp.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbZoomUp.Size = new System.Drawing.Size(55, 24);
            this.tsbZoomUp.Text = "放大";
            this.tsbZoomUp.ToolTipText = "地图放大";
            this.tsbZoomUp.Click += new System.EventHandler(this.tsbZoomUp_Click);
            // 
            // tsbZoomDown
            // 
            this.tsbZoomDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomDown.Image")));
            this.tsbZoomDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomDown.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomDown.Name = "tsbZoomDown";
            this.tsbZoomDown.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbZoomDown.Size = new System.Drawing.Size(55, 24);
            this.tsbZoomDown.Text = "缩小";
            this.tsbZoomDown.ToolTipText = "地图缩小";
            this.tsbZoomDown.Click += new System.EventHandler(this.tsbZoomDown_Click);
            // 
            // tsbShowHint
            // 
            this.tsbShowHint.Image = ((System.Drawing.Image)(resources.GetObject("tsbShowHint.Image")));
            this.tsbShowHint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbShowHint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowHint.Margin = new System.Windows.Forms.Padding(0);
            this.tsbShowHint.Name = "tsbShowHint";
            this.tsbShowHint.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbShowHint.Size = new System.Drawing.Size(67, 24);
            this.tsbShowHint.Text = "轨迹点";
            this.tsbShowHint.ToolTipText = "查看轨迹点当前信息";
            this.tsbShowHint.Click += new System.EventHandler(this.tsbShowHint_Click);
            // 
            // tsbCenter
            // 
            this.tsbCenter.Image = global::Client.Properties.Resources.center;
            this.tsbCenter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tsbCenter.Name = "tsbCenter";
            this.tsbCenter.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbCenter.Size = new System.Drawing.Size(55, 24);
            this.tsbCenter.Text = "居中";
            this.tsbCenter.ToolTipText = "定位中心点";
            this.tsbCenter.Click += new System.EventHandler(this.tsbCenter_Click);
            // 
            // tsbDistance
            // 
            this.tsbDistance.Image = global::Client.Properties.Resources.ruler;
            this.tsbDistance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDistance.Margin = new System.Windows.Forms.Padding(0);
            this.tsbDistance.Name = "tsbDistance";
            this.tsbDistance.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbDistance.Size = new System.Drawing.Size(55, 24);
            this.tsbDistance.Text = "测距";
            this.tsbDistance.ToolTipText = "测量距离";
            this.tsbDistance.Click += new System.EventHandler(this.tsbDistance_Click);
            // 
            // tsbSaveLine
            // 
            this.tsbSaveLine.Image = global::Client.Properties.Resources.path;
            this.tsbSaveLine.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSaveLine.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveLine.Name = "tsbSaveLine";
            this.tsbSaveLine.Size = new System.Drawing.Size(52, 21);
            this.tsbSaveLine.Text = "预设";
            this.tsbSaveLine.ToolTipText = "保存为预设线路";
            this.tsbSaveLine.Click += new System.EventHandler(this.tsbSaveLine_Click);
            // 
            // tsbAddPoint
            // 
            this.tsbAddPoint.Image = global::Client.Properties.Resources.point;
            this.tsbAddPoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAddPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddPoint.Margin = new System.Windows.Forms.Padding(1);
            this.tsbAddPoint.Name = "tsbAddPoint";
            this.tsbAddPoint.Size = new System.Drawing.Size(52, 22);
            this.tsbAddPoint.Text = "标注";
            this.tsbAddPoint.ToolTipText = "增加地图标注";
            this.tsbAddPoint.Click += new System.EventHandler(this.tsbAddPoint_Click);
            // 
            // tsbDelPoint
            // 
            this.tsbDelPoint.Image = global::Client.Properties.Resources.delete;
            this.tsbDelPoint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDelPoint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelPoint.Margin = new System.Windows.Forms.Padding(1);
            this.tsbDelPoint.Name = "tsbDelPoint";
            this.tsbDelPoint.Size = new System.Drawing.Size(52, 22);
            this.tsbDelPoint.Text = "删除";
            this.tsbDelPoint.ToolTipText = "删除单个地图标注";
            this.tsbDelPoint.Click += new System.EventHandler(this.tsbDelPoint_Click);
            // 
            // tsbToGrid
            // 
            this.tsbToGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsbToGrid.Image")));
            this.tsbToGrid.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbToGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToGrid.Margin = new System.Windows.Forms.Padding(0);
            this.tsbToGrid.Name = "tsbToGrid";
            this.tsbToGrid.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbToGrid.Size = new System.Drawing.Size(55, 21);
            this.tsbToGrid.Text = "文本";
            this.tsbToGrid.ToolTipText = "切换到文本界面";
            this.tsbToGrid.Click += new System.EventHandler(this.tsbChange_Click);
            // 
            // tsbToMap
            // 
            this.tsbToMap.Image = ((System.Drawing.Image)(resources.GetObject("tsbToMap.Image")));
            this.tsbToMap.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbToMap.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbToMap.Margin = new System.Windows.Forms.Padding(0);
            this.tsbToMap.Name = "tsbToMap";
            this.tsbToMap.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbToMap.Size = new System.Drawing.Size(55, 21);
            this.tsbToMap.Text = "地图";
            this.tsbToMap.ToolTipText = "切换到地图界面";
            this.tsbToMap.Visible = false;
            this.tsbToMap.Click += new System.EventHandler(this.tsbChange_Click);
            // 
            // tsbShowAll
            // 
            this.tsbShowAll.Image = global::Client.Properties.Resources.fullextent;
            this.tsbShowAll.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbShowAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowAll.Margin = new System.Windows.Forms.Padding(0);
            this.tsbShowAll.Name = "tsbShowAll";
            this.tsbShowAll.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbShowAll.Size = new System.Drawing.Size(79, 21);
            this.tsbShowAll.Text = "全图显示";
            this.tsbShowAll.Click += new System.EventHandler(this.tsbShowAll_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbRefresh.Size = new System.Drawing.Size(23, 4);
            this.tsbRefresh.Text = "刷新地图";
            this.tsbRefresh.Visible = false;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // tsbExport
            // 
            this.tsbExport.Image = global::Client.Properties.Resources.Excel;
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(82, 24);
            this.tsbExport.Text = "导出Excel";
            this.tsbExport.Visible = false;
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // ofdLocal
            // 
            this.ofdLocal.DefaultExt = "cds";
            this.ofdLocal.Filter = "轨迹回放本地数据文件(*.cds)|*.cds";
            // 
            // ppdMap
            // 
            this.ppdMap.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdMap.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdMap.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdMap.Enabled = true;
            this.ppdMap.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdMap.Icon")));
            this.ppdMap.Name = "ppdMap";
            this.ppdMap.Visible = false;
            // 
            // scPlayTrack
            // 
            this.scPlayTrack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scPlayTrack.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scPlayTrack.Location = new System.Drawing.Point(5, 5);
            this.scPlayTrack.Name = "scPlayTrack";
            // 
            // scPlayTrack.Panel1
            // 
            this.scPlayTrack.Panel1.Controls.Add(this.pnlHandle);
            this.scPlayTrack.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scPlayTrack.Panel1MinSize = 293;
            // 
            // scPlayTrack.Panel2
            // 
            this.scPlayTrack.Panel2.Controls.Add(this.grpMap);
            this.scPlayTrack.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scPlayTrack.Size = new System.Drawing.Size(1131, 631);
            this.scPlayTrack.SplitterDistance = 310;
            this.scPlayTrack.TabIndex = 0;
            // 
            // sfdLocal
            // 
            this.sfdLocal.DefaultExt = "cds";
            this.sfdLocal.Filter = "轨迹回放本地数据文件(*.cds)|*.cds";
            // 
            // pdMap
            // 
            this.pdMap.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdMap_PrintPage);
            // 
            // itmCarPlayTrack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 641);
            this.Controls.Add(this.scPlayTrack);
            this.Name = "itmCarPlayTrack";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "回放轨迹";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.itmCarPlayTrack_FormClosing);
            this.Load += new System.EventHandler(this.itmCarPlayTrack_Load);
            this.pnlHandle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPicture)).EndInit();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            this.grpPlay.ResumeLayout(false);
            this.grpPlay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlaySpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbPlay)).EndInit();
            this.grpEndTime.ResumeLayout(false);
            this.grpEndTime.PerformLayout();
            this.grpStartTime.ResumeLayout(false);
            this.grpStartTime.PerformLayout();
            this.grpCarNum.ResumeLayout(false);
            this.grpCarNum.PerformLayout();
            this.grpMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarPlay)).EndInit();
            this.pnlTool.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.scPlayTrack.Panel1.ResumeLayout(false);
            this.scPlayTrack.Panel2.ResumeLayout(false);
            this.scPlayTrack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar tbPlay;
        private System.Windows.Forms.TrackBar tbPlaySpeed;
        private System.Windows.Forms.SaveFileDialog sfdLocal;
        private System.Drawing.Printing.PrintDocument pdMap;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnLocal;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn CarStatus;
        private System.Windows.Forms.CheckBox chkShowPointOnly;
        private System.Windows.Forms.CheckBox chkUnShowTrack;
        private System.Windows.Forms.ToolStripComboBox cmbSelectMap;
        private System.Windows.Forms.DataGridView dgvCarPlay;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn gpsTime;
        private System.Windows.Forms.GroupBox grpCarNum;
        private System.Windows.Forms.GroupBox grpDetail;
        private System.Windows.Forms.GroupBox grpEndTime;
        private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.GroupBox grpPlay;
        private System.Windows.Forms.GroupBox grpStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Latitude;
        private System.Windows.Forms.Label lblCarNum;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Label lblFileValue;
        private System.Windows.Forms.Label lblGpsTime;
        private System.Windows.Forms.Label lblGpsTimeValue;
        private System.Windows.Forms.Label lblIsBlackBox;
        private System.Windows.Forms.Label lblIsBlackBoxValue;
        private System.Windows.Forms.Label lblLatitude;
        private System.Windows.Forms.Label lblLatitudeValue;
        private System.Windows.Forms.Label lblLongitude;
        private System.Windows.Forms.Label lblLongitudeValue;
        private System.Windows.Forms.Label lblMileage;
        private System.Windows.Forms.Label lblMileageValue;
        private System.Windows.Forms.Label lblPlaySpeed;
        private System.Windows.Forms.Label lblQuick;
        private System.Windows.Forms.Label lblRecord;
        private System.Windows.Forms.Label lblRecordValue;
        private System.Windows.Forms.ToolStripLabel lblSelectMap;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblSpeedValue;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.Label lblStateValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Longitude;
        private System.Windows.Forms.DataGridViewTextBoxColumn messId;
        private System.Windows.Forms.OpenFileDialog ofdLocal;
        private System.Windows.Forms.ProgressBar pbCarPlay;
        private System.Windows.Forms.PictureBox pbPicture;
        private System.Windows.Forms.PictureBox picLoadMap;
        private System.Windows.Forms.Panel pnlHandle;
        private System.Windows.Forms.Panel pnlTool;
        private System.Windows.Forms.PrintPreviewDialog ppdMap;
        private System.Windows.Forms.DataGridViewTextBoxColumn receTime;
        private System.Windows.Forms.SplitContainer scPlayTrack;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed;
        private System.Windows.Forms.ToolStripButton tsbAddPoint;
        private System.Windows.Forms.ToolStripButton tsbArrowhead;
        private System.Windows.Forms.ToolStripButton tsbCenter;
        private System.Windows.Forms.ToolStripButton tsbDelPoint;
        private System.Windows.Forms.ToolStripButton tsbDistance;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripButton tsbMove;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbSaveLine;
        private System.Windows.Forms.ToolStripButton tsbShowAll;
        private System.Windows.Forms.ToolStripButton tsbShowHint;
        private System.Windows.Forms.ToolStripButton tsbToGrid;
        private System.Windows.Forms.ToolStripButton tsbToMap;
        private System.Windows.Forms.ToolStripButton tsbZoomDown;
        private System.Windows.Forms.ToolStripButton tsbZoomUp;
        private System.Windows.Forms.ToolStrip tsMenu;
        private WinFormsUI.Controls.GisMap wbMap;
        private System.Windows.Forms.TextBox txtWaitTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkWaitTime;
        private WinFormsUI.Controls.ComBox cmbCarNum;
        private System.Windows.Forms.ToolStripButton tsbSaveImage;
    }
}
