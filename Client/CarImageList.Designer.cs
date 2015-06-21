﻿namespace Client
{
    using Other;
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class CarImageList
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
            this.pnlTop = new Panel();
            this.cmbType = new ComboBox();
            this.toolStrip1 = new ToolStrip();
            this.btnSearchCar = new ToolStripButton();
            this.txtSearchCar = new TextBox();
            this.lblEndTime = new Label();
            this.dtpEndTime = new DateTimePicker();
            this.lblStartTime = new Label();
            this.dtpStartTime = new DateTimePicker();
            this.cmbCar = new ComboBox();
            this.btnQuery = new Button();
            this.lblCar = new Label();
            this.flpnl = new FlowLayoutPanel();
            this.grp1 = new GroupBox();
            this.pic1 = new PictureBox();
            this.grp2 = new GroupBox();
            this.pic2 = new PictureBox();
            this.gpr3 = new GroupBox();
            this.pic3 = new PictureBox();
            this.grp4 = new GroupBox();
            this.pic4 = new PictureBox();
            this.grp5 = new GroupBox();
            this.pic5 = new PictureBox();
            this.grp6 = new GroupBox();
            this.pic6 = new PictureBox();
            this.grp7 = new GroupBox();
            this.pic7 = new PictureBox();
            this.grp8 = new GroupBox();
            this.pic8 = new PictureBox();
            this.grp9 = new GroupBox();
            this.pic9 = new PictureBox();
            this.btnUpPage = new Button();
            this.btnNextPage = new Button();
            this.pnlBottom = new Panel();
            this.lblPageInfo = new Label();
            this.lblInfo = new Label();
            this.lblNoPicInfo = new Label();
            this.pnlMiddle = new Panel();
            this.pnlVideoAndSound = new Panel();
            this.mediaPlayer1 = new MediaPlayer();
            this.dgvMedia = new DataGridView();
            this.GpsTime = new DataGridViewTextBoxColumn();
            this.cameraID = new DataGridViewTextBoxColumn();
            this.phonecar = new DataGridViewTextBoxColumn();
            this.recetime = new DataGridViewTextBoxColumn();
            this.pnlTop.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.flpnl.SuspendLayout();
            this.grp1.SuspendLayout();
            ((ISupportInitialize) this.pic1).BeginInit();
            this.grp2.SuspendLayout();
            ((ISupportInitialize) this.pic2).BeginInit();
            this.gpr3.SuspendLayout();
            ((ISupportInitialize) this.pic3).BeginInit();
            this.grp4.SuspendLayout();
            ((ISupportInitialize) this.pic4).BeginInit();
            this.grp5.SuspendLayout();
            ((ISupportInitialize) this.pic5).BeginInit();
            this.grp6.SuspendLayout();
            ((ISupportInitialize) this.pic6).BeginInit();
            this.grp7.SuspendLayout();
            ((ISupportInitialize) this.pic7).BeginInit();
            this.grp8.SuspendLayout();
            ((ISupportInitialize) this.pic8).BeginInit();
            this.grp9.SuspendLayout();
            ((ISupportInitialize) this.pic9).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.pnlVideoAndSound.SuspendLayout();
            ((ISupportInitialize) this.dgvMedia).BeginInit();
            base.SuspendLayout();
            this.pnlTop.Controls.Add(this.cmbType);
            this.pnlTop.Controls.Add(this.toolStrip1);
            this.pnlTop.Controls.Add(this.txtSearchCar);
            this.pnlTop.Controls.Add(this.lblEndTime);
            this.pnlTop.Controls.Add(this.dtpEndTime);
            this.pnlTop.Controls.Add(this.lblStartTime);
            this.pnlTop.Controls.Add(this.dtpStartTime);
            this.pnlTop.Controls.Add(this.cmbCar);
            this.pnlTop.Controls.Add(this.btnQuery);
            this.pnlTop.Controls.Add(this.lblCar);
            this.pnlTop.Dock = DockStyle.Top;
            this.pnlTop.Location = new Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new Size(1035, 33);
            this.pnlTop.TabIndex = 0;
            this.cmbType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] { "图像", "音频", "视频" });
            this.cmbType.Location = new Point(329, 7);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new Size(68, 20);
            this.cmbType.TabIndex = 9;
            this.toolStrip1.Dock = DockStyle.None;
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.btnSearchCar });
            this.toolStrip1.Location = new Point(300, 4);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(26, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            this.btnSearchCar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.btnSearchCar.Image = Resources.find;
            this.btnSearchCar.ImageTransparentColor = Color.Magenta;
            this.btnSearchCar.Name = "btnSearchCar";
            this.btnSearchCar.Size = new Size(23, 22);
            this.btnSearchCar.Text = "过滤";
            this.btnSearchCar.ToolTipText = "车辆列表过滤查找";
            this.btnSearchCar.Click += new EventHandler(this.btnSearchCar_Click);
            this.txtSearchCar.Location = new Point(197, 7);
            this.txtSearchCar.MaxLength = 30;
            this.txtSearchCar.Name = "txtSearchCar";
            this.txtSearchCar.Size = new Size(100, 21);
            this.txtSearchCar.TabIndex = 7;
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new Point(642, 11);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 6;
            this.lblEndTime.Text = "结束时间：";
            this.dtpEndTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new Point(713, 7);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new Size(162, 21);
            this.dtpEndTime.TabIndex = 5;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new Point(403, 11);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 4;
            this.lblStartTime.Text = "开始时间：";
            this.dtpStartTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new Point(474, 7);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new Size(162, 21);
            this.dtpStartTime.TabIndex = 3;
            this.cmbCar.FormattingEnabled = true;
            this.cmbCar.Location = new Point(74, 7);
            this.cmbCar.Name = "cmbCar";
            this.cmbCar.Size = new Size(121, 20);
            this.cmbCar.TabIndex = 2;
            this.btnQuery.Location = new Point(881, 6);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new Size(75, 23);
            this.btnQuery.TabIndex = 1;
            this.btnQuery.Text = "查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new EventHandler(this.btnQuery_Click);
            this.lblCar.AutoSize = true;
            this.lblCar.Location = new Point(3, 10);
            this.lblCar.Name = "lblCar";
            this.lblCar.Size = new Size(65, 12);
            this.lblCar.TabIndex = 0;
            this.lblCar.Text = "车辆列表：";
            this.flpnl.AutoScroll = true;
            this.flpnl.Controls.Add(this.grp1);
            this.flpnl.Controls.Add(this.grp2);
            this.flpnl.Controls.Add(this.gpr3);
            this.flpnl.Controls.Add(this.grp4);
            this.flpnl.Controls.Add(this.grp5);
            this.flpnl.Controls.Add(this.grp6);
            this.flpnl.Controls.Add(this.grp7);
            this.flpnl.Controls.Add(this.grp8);
            this.flpnl.Controls.Add(this.grp9);
            this.flpnl.Dock = DockStyle.Fill;
            this.flpnl.Location = new Point(0, 0);
            this.flpnl.Name = "flpnl";
            this.flpnl.Size = new Size(1035, 535);
            this.flpnl.TabIndex = 0;
            this.grp1.Controls.Add(this.pic1);
            this.grp1.Location = new Point(3, 3);
            this.grp1.Name = "grp1";
            this.grp1.Size = new Size(330, 261);
            this.grp1.TabIndex = 0;
            this.grp1.TabStop = false;
            this.grp1.Visible = false;
            this.pic1.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic1.Location = new Point(6, 15);
            this.pic1.Name = "pic1";
            this.pic1.Size = new Size(320, 240);
            this.pic1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic1.TabIndex = 0;
            this.pic1.TabStop = false;
            this.grp2.Controls.Add(this.pic2);
            this.grp2.Location = new Point(339, 3);
            this.grp2.Name = "grp2";
            this.grp2.Size = new Size(330, 261);
            this.grp2.TabIndex = 1;
            this.grp2.TabStop = false;
            this.grp2.Visible = false;
            this.pic2.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic2.Location = new Point(6, 15);
            this.pic2.Name = "pic2";
            this.pic2.Size = new Size(320, 240);
            this.pic2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic2.TabIndex = 0;
            this.pic2.TabStop = false;
            this.gpr3.Controls.Add(this.pic3);
            this.gpr3.Location = new Point(675, 3);
            this.gpr3.Name = "gpr3";
            this.gpr3.Size = new Size(330, 261);
            this.gpr3.TabIndex = 2;
            this.gpr3.TabStop = false;
            this.gpr3.Visible = false;
            this.pic3.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic3.Location = new Point(6, 15);
            this.pic3.Name = "pic3";
            this.pic3.Size = new Size(320, 240);
            this.pic3.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic3.TabIndex = 0;
            this.pic3.TabStop = false;
            this.grp4.Controls.Add(this.pic4);
            this.grp4.Location = new Point(3, 270);
            this.grp4.Name = "grp4";
            this.grp4.Size = new Size(330, 261);
            this.grp4.TabIndex = 3;
            this.grp4.TabStop = false;
            this.grp4.Visible = false;
            this.pic4.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic4.Location = new Point(6, 15);
            this.pic4.Name = "pic4";
            this.pic4.Size = new Size(320, 240);
            this.pic4.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic4.TabIndex = 0;
            this.pic4.TabStop = false;
            this.grp5.Controls.Add(this.pic5);
            this.grp5.Location = new Point(339, 270);
            this.grp5.Name = "grp5";
            this.grp5.Size = new Size(330, 261);
            this.grp5.TabIndex = 4;
            this.grp5.TabStop = false;
            this.grp5.Visible = false;
            this.pic5.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic5.Location = new Point(6, 15);
            this.pic5.Name = "pic5";
            this.pic5.Size = new Size(320, 240);
            this.pic5.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic5.TabIndex = 0;
            this.pic5.TabStop = false;
            this.grp6.Controls.Add(this.pic6);
            this.grp6.Location = new Point(675, 270);
            this.grp6.Name = "grp6";
            this.grp6.Size = new Size(330, 261);
            this.grp6.TabIndex = 5;
            this.grp6.TabStop = false;
            this.grp6.Visible = false;
            this.pic6.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic6.Location = new Point(6, 15);
            this.pic6.Name = "pic6";
            this.pic6.Size = new Size(320, 240);
            this.pic6.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic6.TabIndex = 0;
            this.pic6.TabStop = false;
            this.grp7.Controls.Add(this.pic7);
            this.grp7.Location = new Point(3, 537);
            this.grp7.Name = "grp7";
            this.grp7.Size = new Size(330, 261);
            this.grp7.TabIndex = 6;
            this.grp7.TabStop = false;
            this.grp7.Visible = false;
            this.pic7.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic7.Location = new Point(6, 15);
            this.pic7.Name = "pic7";
            this.pic7.Size = new Size(320, 240);
            this.pic7.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic7.TabIndex = 0;
            this.pic7.TabStop = false;
            this.grp8.Controls.Add(this.pic8);
            this.grp8.Location = new Point(339, 537);
            this.grp8.Name = "grp8";
            this.grp8.Size = new Size(330, 261);
            this.grp8.TabIndex = 7;
            this.grp8.TabStop = false;
            this.grp8.Visible = false;
            this.pic8.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic8.Location = new Point(6, 15);
            this.pic8.Name = "pic8";
            this.pic8.Size = new Size(320, 240);
            this.pic8.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic8.TabIndex = 0;
            this.pic8.TabStop = false;
            this.grp9.Controls.Add(this.pic9);
            this.grp9.Location = new Point(675, 537);
            this.grp9.Name = "grp9";
            this.grp9.Size = new Size(330, 261);
            this.grp9.TabIndex = 8;
            this.grp9.TabStop = false;
            this.grp9.Visible = false;
            this.pic9.BackgroundImageLayout = ImageLayout.Zoom;
            this.pic9.Location = new Point(6, 15);
            this.pic9.Name = "pic9";
            this.pic9.Size = new Size(320, 240);
            this.pic9.SizeMode = PictureBoxSizeMode.Zoom;
            this.pic9.TabIndex = 0;
            this.pic9.TabStop = false;
            this.btnUpPage.Location = new Point(681, 9);
            this.btnUpPage.Name = "btnUpPage";
            this.btnUpPage.Size = new Size(75, 23);
            this.btnUpPage.TabIndex = 7;
            this.btnUpPage.Text = "上一页";
            this.btnUpPage.UseVisualStyleBackColor = true;
            this.btnUpPage.Visible = false;
            this.btnUpPage.Click += new EventHandler(this.btnUpPage_Click);
            this.btnNextPage.Location = new Point(762, 9);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new Size(75, 23);
            this.btnNextPage.TabIndex = 8;
            this.btnNextPage.Text = "下一页";
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Visible = false;
            this.btnNextPage.Click += new EventHandler(this.btnNextPage_Click);
            this.pnlBottom.Controls.Add(this.btnNextPage);
            this.pnlBottom.Controls.Add(this.lblPageInfo);
            this.pnlBottom.Controls.Add(this.btnUpPage);
            this.pnlBottom.Controls.Add(this.lblInfo);
            this.pnlBottom.Dock = DockStyle.Bottom;
            this.pnlBottom.Location = new Point(0, 568);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new Size(1035, 38);
            this.pnlBottom.TabIndex = 1;
            this.lblPageInfo.AutoSize = true;
            this.lblPageInfo.Location = new Point(432, 14);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new Size(0, 12);
            this.lblPageInfo.TabIndex = 1;
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new Point(9, 14);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new Size(0, 12);
            this.lblInfo.TabIndex = 0;
            this.lblNoPicInfo.BackColor = Color.Transparent;
            this.lblNoPicInfo.Font = new Font("宋体", 21.75f, FontStyle.Bold, GraphicsUnit.Point, 134);
            this.lblNoPicInfo.ForeColor = Color.Red;
            this.lblNoPicInfo.Location = new Point(279, 250);
            this.lblNoPicInfo.Name = "lblNoPicInfo";
            this.lblNoPicInfo.Size = new Size(387, 34);
            this.lblNoPicInfo.TabIndex = 2;
            this.lblNoPicInfo.Tag = "9999";
            this.lblNoPicInfo.Text = "该时间段内没有图像信息！";
            this.pnlMiddle.Controls.Add(this.flpnl);
            this.pnlMiddle.Controls.Add(this.pnlVideoAndSound);
            this.pnlMiddle.Controls.Add(this.lblNoPicInfo);
            this.pnlMiddle.Dock = DockStyle.Fill;
            this.pnlMiddle.Location = new Point(0, 33);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new Size(1035, 535);
            this.pnlMiddle.TabIndex = 3;
            this.pnlVideoAndSound.Controls.Add(this.mediaPlayer1);
            this.pnlVideoAndSound.Controls.Add(this.dgvMedia);
            this.pnlVideoAndSound.Dock = DockStyle.Fill;
            this.pnlVideoAndSound.Location = new Point(0, 0);
            this.pnlVideoAndSound.Name = "pnlVideoAndSound";
            this.pnlVideoAndSound.Size = new Size(1035, 535);
            this.pnlVideoAndSound.TabIndex = 3;
            this.mediaPlayer1.Location = new Point(205, 0);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.Size = new Size(830, 535);
            this.mediaPlayer1.TabIndex = 1;
            this.dgvMedia.AllowUserToAddRows = false;
            this.dgvMedia.AllowUserToDeleteRows = false;
            this.dgvMedia.BackgroundColor = Color.White;
            this.dgvMedia.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedia.Columns.AddRange(new DataGridViewColumn[] { this.GpsTime, this.cameraID, this.phonecar, this.recetime });
            this.dgvMedia.Dock = DockStyle.Left;
            this.dgvMedia.Location = new Point(0, 0);
            this.dgvMedia.Name = "dgvMedia";
            this.dgvMedia.RowHeadersVisible = false;
            this.dgvMedia.RowTemplate.Height = 23;
            this.dgvMedia.Size = new Size(205, 535);
            this.dgvMedia.TabIndex = 0;
            this.dgvMedia.CellContentClick += new DataGridViewCellEventHandler(this.dgvMedia_CellContentClick);
            this.GpsTime.DataPropertyName = "GpsTime";
            this.GpsTime.HeaderText = "GPS时间";
            this.GpsTime.Name = "GpsTime";
            this.GpsTime.ReadOnly = true;
            this.GpsTime.Width = 120;
            this.cameraID.DataPropertyName = "cameraID";
            this.cameraID.HeaderText = "摄像头ID";
            this.cameraID.Name = "cameraID";
            this.cameraID.ReadOnly = true;
            this.cameraID.Width = 80;
            this.phonecar.DataPropertyName = "carphone";
            this.phonecar.HeaderText = "carphone";
            this.phonecar.Name = "phonecar";
            this.phonecar.ReadOnly = true;
            this.phonecar.Visible = false;
            this.recetime.DataPropertyName = "recetime";
            this.recetime.HeaderText = "recetime";
            this.recetime.Name = "recetime";
            this.recetime.ReadOnly = true;
            this.recetime.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(1035, 606);
            base.Controls.Add(this.pnlMiddle);
            base.Controls.Add(this.pnlBottom);
            base.Controls.Add(this.pnlTop);
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "CarImageList";
            this.Text = "多媒体信息查询";
            base.Load += new EventHandler(this.CarImageList_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flpnl.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            ((ISupportInitialize) this.pic1).EndInit();
            this.grp2.ResumeLayout(false);
            ((ISupportInitialize) this.pic2).EndInit();
            this.gpr3.ResumeLayout(false);
            ((ISupportInitialize) this.pic3).EndInit();
            this.grp4.ResumeLayout(false);
            ((ISupportInitialize) this.pic4).EndInit();
            this.grp5.ResumeLayout(false);
            ((ISupportInitialize) this.pic5).EndInit();
            this.grp6.ResumeLayout(false);
            ((ISupportInitialize) this.pic6).EndInit();
            this.grp7.ResumeLayout(false);
            ((ISupportInitialize) this.pic7).EndInit();
            this.grp8.ResumeLayout(false);
            ((ISupportInitialize) this.pic8).EndInit();
            this.grp9.ResumeLayout(false);
            ((ISupportInitialize) this.pic9).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.pnlMiddle.ResumeLayout(false);
            this.pnlVideoAndSound.ResumeLayout(false);
            ((ISupportInitialize) this.dgvMedia).EndInit();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private BackgroundWorker _mediaDownLoadThread;
        private Button btnNextPage;
        private Button btnQuery;
        private ToolStripButton btnSearchCar;
        private Button btnUpPage;
        private DataGridViewTextBoxColumn cameraID;
        private string carnum;
        private string carphone;
        private ComboBox cmbCar;
        private ComboBox cmbType;
        private int currentPage;
        private DataTable data;
        private DataGridView dgvMedia;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private FlowLayoutPanel flpnl;
        private GroupBox gpr3;
        private DataGridViewTextBoxColumn GpsTime;
        private GroupBox grp1;
        private GroupBox grp2;
        private GroupBox grp4;
        private GroupBox grp5;
        private GroupBox grp6;
        private GroupBox grp7;
        private GroupBox grp8;
        private GroupBox grp9;
        private Label lblCar;
        private Label lblEndTime;
        private Label lblInfo;
        private Label lblNoPicInfo;
        private Label lblPageInfo;
        private Label lblStartTime;
        private MediaPlayer mediaPlayer1;
        private int pageCount;
        private DataGridViewTextBoxColumn phonecar;
        private PictureBox pic1;
        private PictureBox pic2;
        private PictureBox pic3;
        private PictureBox pic4;
        private PictureBox pic5;
        private PictureBox pic6;
        private PictureBox pic7;
        private PictureBox pic8;
        private PictureBox pic9;
        private Panel pnlBottom;
        private Panel pnlMiddle;
        private Panel pnlTop;
        private System.Windows.Forms.Panel pnlVideoAndSound;
        private int progress;
        private DataGridViewTextBoxColumn recetime;
        private BackgroundWorker showPicWorker;
        private ToolStrip toolStrip1;
        private TextBox txtSearchCar;
        private BackgroundWorker worker;
    }
}