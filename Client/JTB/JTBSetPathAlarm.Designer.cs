namespace Client.JTB
{
    using Client;
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBSetPathAlarm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JTBSetPathAlarm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvPath = new WinFormsUI.Controls.DataGridViewEx();
            this.pathName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.begintm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endtm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pathattr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvPathSection = new WinFormsUI.Controls.DataGridViewEx();
            this.sectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxspeed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxspeedtm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxtm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mintm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LanLon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAddSection = new System.Windows.Forms.Button();
            this.picLoadMap = new System.Windows.Forms.PictureBox();
            this.wbMap = new WinFormsUI.Controls.GisMap();
            this.pnlAddPathSection = new System.Windows.Forms.Panel();
            this.grpPathSectionAdd = new System.Windows.Forms.GroupBox();
            this.btnCancelPathSectionAdd = new System.Windows.Forms.Button();
            this.btnAddPathSection = new System.Windows.Forms.Button();
            this.numMaxTm = new System.Windows.Forms.NumericUpDown();
            this.numMinTm = new System.Windows.Forms.NumericUpDown();
            this.lblPathSection = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPathSection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numMaxSpeed = new System.Windows.Forms.NumericUpDown();
            this.numMaxSpeedTm = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.pbPicWait = new System.Windows.Forms.PictureBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPath)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathSection)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).BeginInit();
            this.pnlAddPathSection.SuspendLayout();
            this.grpPathSectionAdd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeedTm)).BeginInit();
            this.pnlWait.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(986, 116);
            // 
            // pnlBtn
            // 
            this.pnlBtn.Controls.Add(this.pnlWait);
            this.pnlBtn.Location = new System.Drawing.Point(5, 720);
            this.pnlBtn.Size = new System.Drawing.Size(986, 28);
            this.pnlBtn.Controls.SetChildIndex(this.btnOK, 0);
            this.pnlBtn.Controls.SetChildIndex(this.btnCancel, 0);
            this.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.pnlAddPathSection);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(5, 121);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(986, 599);
            this.panel1.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.tabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.picLoadMap);
            this.splitContainer1.Panel2.Controls.Add(this.wbMap);
            this.splitContainer1.Size = new System.Drawing.Size(986, 599);
            this.splitContainer1.SplitterDistance = 452;
            this.splitContainer1.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(452, 599);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvPath);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(444, 573);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "路线信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvPath
            // 
            this.dgvPath.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPath.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pathName,
            this.begintm,
            this.endtm,
            this.pathattr});
            this.dgvPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPath.Location = new System.Drawing.Point(3, 3);
            this.dgvPath.Name = "dgvPath";
            this.dgvPath.NotMultiSelectedColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvPath.NotMultiSelectedColumnName")));
            this.dgvPath.RowHeadersVisible = false;
            this.dgvPath.RowTemplate.Height = 23;
            this.dgvPath.Size = new System.Drawing.Size(438, 567);
            this.dgvPath.TabIndex = 0;
            this.dgvPath.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPath_CellClick);
            this.dgvPath.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPath_CellMouseDoubleClick);
            this.dgvPath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPath_KeyDown);
            // 
            // pathName
            // 
            this.pathName.DataPropertyName = "pathname";
            this.pathName.HeaderText = "路线名称";
            this.pathName.Name = "pathName";
            // 
            // begintm
            // 
            this.begintm.DataPropertyName = "begintm";
            this.begintm.HeaderText = "开始时间";
            this.begintm.Name = "begintm";
            // 
            // endtm
            // 
            this.endtm.DataPropertyName = "endtm";
            this.endtm.HeaderText = "结束时间";
            this.endtm.Name = "endtm";
            // 
            // pathattr
            // 
            this.pathattr.DataPropertyName = "pathattr";
            this.pathattr.HeaderText = "路线属性";
            this.pathattr.Name = "pathattr";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPathSection);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(444, 573);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "路线对应路段信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvPathSection
            // 
            this.dgvPathSection.AllowUserToAddRows = false;
            this.dgvPathSection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPathSection.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sectionName,
            this.maxspeed,
            this.maxspeedtm,
            this.maxtm,
            this.mintm,
            this.LanLon});
            this.dgvPathSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPathSection.Location = new System.Drawing.Point(3, 3);
            this.dgvPathSection.Name = "dgvPathSection";
            this.dgvPathSection.NotMultiSelectedColumnName = ((System.Collections.Generic.List<string>)(resources.GetObject("dgvPathSection.NotMultiSelectedColumnName")));
            this.dgvPathSection.RowHeadersVisible = false;
            this.dgvPathSection.RowTemplate.Height = 23;
            this.dgvPathSection.Size = new System.Drawing.Size(438, 536);
            this.dgvPathSection.TabIndex = 1;
            this.dgvPathSection.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPathSection_CellClick);
            this.dgvPathSection.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPathSection_KeyDown);
            // 
            // sectionName
            // 
            this.sectionName.DataPropertyName = "sectionName";
            this.sectionName.HeaderText = "路段名称";
            this.sectionName.Name = "sectionName";
            this.sectionName.Width = 80;
            // 
            // maxspeed
            // 
            this.maxspeed.DataPropertyName = "maxspeed";
            this.maxspeed.HeaderText = "最高时速(km/h)";
            this.maxspeed.Name = "maxspeed";
            this.maxspeed.Width = 80;
            // 
            // maxspeedtm
            // 
            this.maxspeedtm.DataPropertyName = "maxspeedtm";
            this.maxspeedtm.HeaderText = "持续时长(秒)";
            this.maxspeedtm.Name = "maxspeedtm";
            this.maxspeedtm.Width = 80;
            // 
            // maxtm
            // 
            this.maxtm.DataPropertyName = "maxtm";
            this.maxtm.HeaderText = "行驶最长时间";
            this.maxtm.Name = "maxtm";
            // 
            // mintm
            // 
            this.mintm.DataPropertyName = "mintm";
            this.mintm.HeaderText = "行驶最短时间";
            this.mintm.Name = "mintm";
            // 
            // LanLon
            // 
            this.LanLon.DataPropertyName = "LanLon";
            this.LanLon.HeaderText = "经纬度";
            this.LanLon.Name = "LanLon";
            this.LanLon.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddSection);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 539);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(438, 31);
            this.panel2.TabIndex = 2;
            // 
            // btnAddSection
            // 
            this.btnAddSection.Location = new System.Drawing.Point(142, 3);
            this.btnAddSection.Name = "btnAddSection";
            this.btnAddSection.Size = new System.Drawing.Size(75, 23);
            this.btnAddSection.TabIndex = 2;
            this.btnAddSection.Text = "添加路段";
            this.btnAddSection.UseVisualStyleBackColor = true;
            this.btnAddSection.Click += new System.EventHandler(this.btnAddPathRegion_Click);
            // 
            // picLoadMap
            // 
            this.picLoadMap.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLoadMap.BackgroundImage")));
            this.picLoadMap.Location = new System.Drawing.Point(214, 277);
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
            this.wbMap.Size = new System.Drawing.Size(530, 599);
            this.wbMap.TabIndex = 1;
            this.wbMap.WebBrowserShortcutsEnabled = false;
            this.wbMap.MapDoubleClick += new System.Windows.Forms.HtmlElementEventHandler(this.wbMap_MapDoubleClick);
            this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
            // 
            // pnlAddPathSection
            // 
            this.pnlAddPathSection.Controls.Add(this.grpPathSectionAdd);
            this.pnlAddPathSection.Location = new System.Drawing.Point(218, 163);
            this.pnlAddPathSection.Name = "pnlAddPathSection";
            this.pnlAddPathSection.Size = new System.Drawing.Size(371, 237);
            this.pnlAddPathSection.TabIndex = 8;
            this.pnlAddPathSection.Visible = false;
            // 
            // grpPathSectionAdd
            // 
            this.grpPathSectionAdd.Controls.Add(this.btnCancelPathSectionAdd);
            this.grpPathSectionAdd.Controls.Add(this.btnAddPathSection);
            this.grpPathSectionAdd.Controls.Add(this.numMaxTm);
            this.grpPathSectionAdd.Controls.Add(this.numMinTm);
            this.grpPathSectionAdd.Controls.Add(this.lblPathSection);
            this.grpPathSectionAdd.Controls.Add(this.label4);
            this.grpPathSectionAdd.Controls.Add(this.txtPathSection);
            this.grpPathSectionAdd.Controls.Add(this.label1);
            this.grpPathSectionAdd.Controls.Add(this.label3);
            this.grpPathSectionAdd.Controls.Add(this.numMaxSpeed);
            this.grpPathSectionAdd.Controls.Add(this.numMaxSpeedTm);
            this.grpPathSectionAdd.Controls.Add(this.label2);
            this.grpPathSectionAdd.Location = new System.Drawing.Point(59, 19);
            this.grpPathSectionAdd.Name = "grpPathSectionAdd";
            this.grpPathSectionAdd.Size = new System.Drawing.Size(239, 195);
            this.grpPathSectionAdd.TabIndex = 10;
            this.grpPathSectionAdd.TabStop = false;
            this.grpPathSectionAdd.Text = "添加路段";
            // 
            // btnCancelPathSectionAdd
            // 
            this.btnCancelPathSectionAdd.Location = new System.Drawing.Point(126, 155);
            this.btnCancelPathSectionAdd.Name = "btnCancelPathSectionAdd";
            this.btnCancelPathSectionAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCancelPathSectionAdd.TabIndex = 11;
            this.btnCancelPathSectionAdd.Text = "取消";
            this.btnCancelPathSectionAdd.UseVisualStyleBackColor = true;
            this.btnCancelPathSectionAdd.Click += new System.EventHandler(this.btnCancelPathSectionAdd_Click);
            // 
            // btnAddPathSection
            // 
            this.btnAddPathSection.Location = new System.Drawing.Point(20, 155);
            this.btnAddPathSection.Name = "btnAddPathSection";
            this.btnAddPathSection.Size = new System.Drawing.Size(75, 23);
            this.btnAddPathSection.TabIndex = 10;
            this.btnAddPathSection.Text = "确定";
            this.btnAddPathSection.UseVisualStyleBackColor = true;
            this.btnAddPathSection.Click += new System.EventHandler(this.btnAddPathSection_Click);
            // 
            // numMaxTm
            // 
            this.numMaxTm.Location = new System.Drawing.Point(126, 95);
            this.numMaxTm.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMaxTm.Name = "numMaxTm";
            this.numMaxTm.Size = new System.Drawing.Size(100, 21);
            this.numMaxTm.TabIndex = 7;
            // 
            // numMinTm
            // 
            this.numMinTm.Location = new System.Drawing.Point(126, 120);
            this.numMinTm.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMinTm.Name = "numMinTm";
            this.numMinTm.Size = new System.Drawing.Size(100, 21);
            this.numMinTm.TabIndex = 9;
            // 
            // lblPathSection
            // 
            this.lblPathSection.AutoSize = true;
            this.lblPathSection.Location = new System.Drawing.Point(52, 17);
            this.lblPathSection.Name = "lblPathSection";
            this.lblPathSection.Size = new System.Drawing.Size(65, 12);
            this.lblPathSection.TabIndex = 0;
            this.lblPathSection.Text = "路段名称：";
            // 
            // lblWaitText
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "行驶最短时间：";
            // 
            // txtPathSection
            // 
            this.txtPathSection.Location = new System.Drawing.Point(126, 14);
            this.txtPathSection.MaxLength = 100;
            this.txtPathSection.Name = "txtPathSection";
            this.txtPathSection.Size = new System.Drawing.Size(100, 21);
            this.txtPathSection.TabIndex = 1;
            // 
            // lblLoginTitle
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "最高速度：";
            // 
            // lblLoginVersion
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "行驶最长时间：";
            // 
            // numMaxSpeed
            // 
            this.numMaxSpeed.Location = new System.Drawing.Point(126, 41);
            this.numMaxSpeed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numMaxSpeed.Name = "numMaxSpeed";
            this.numMaxSpeed.Size = new System.Drawing.Size(100, 21);
            this.numMaxSpeed.TabIndex = 3;
            // 
            // numMaxSpeedTm
            // 
            this.numMaxSpeedTm.Location = new System.Drawing.Point(126, 68);
            this.numMaxSpeedTm.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numMaxSpeedTm.Name = "numMaxSpeedTm";
            this.numMaxSpeedTm.Size = new System.Drawing.Size(100, 21);
            this.numMaxSpeedTm.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "最高速度持续时间：";
            // 
            // pnlWait
            // 
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(429, 3);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new System.Drawing.Size(129, 22);
            this.pnlWait.TabIndex = 13;
            this.pnlWait.Tag = "9999";
            // 
            // pbPicWait
            // 
            this.pbPicWait.BackColor = System.Drawing.Color.Transparent;
            this.pbPicWait.Image = global::Client.Properties.Resources.loading;
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
            // JTBSetPathAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(996, 751);
            this.Controls.Add(this.panel1);
            this.Name = "JTBSetPathAlarm";
            this.Text = "JTBSetPathAlarm";
            this.Load += new System.EventHandler(this.JTBSetPathAlarm_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPath)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathSection)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).EndInit();
            this.pnlAddPathSection.ResumeLayout(false);
            this.grpPathSectionAdd.ResumeLayout(false);
            this.grpPathSectionAdd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinTm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxSpeedTm)).EndInit();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPicWait)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private AutoDropDown _路线属性;
        private DataGridViewTextBoxColumn begintm;
        private Button btnAddPathSection;
        private Button btnAddSection;
        private Button btnCancelPathSectionAdd;
        private DataGridViewEx dgvPath;
        private DataGridViewEx dgvPathSection;
        private DataGridViewTextBoxColumn endtm;
        private GroupBox grpPathSectionAdd;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridViewTextBoxColumn LanLon;
        private Label lblPathSection;
        private Label lblWaitText;
        private DataGridViewTextBoxColumn maxspeed;
        private DataGridViewTextBoxColumn maxspeedtm;
        private DataGridViewTextBoxColumn maxtm;
        private DataGridViewTextBoxColumn mintm;
        private NumericUpDown numMaxSpeed;
        private NumericUpDown numMaxSpeedTm;
        private NumericUpDown numMaxTm;
        private NumericUpDown numMinTm;
        private Panel panel1;
        private Panel panel2;
        private DataGridViewTextBoxColumn pathattr;
        private DataGridViewTextBoxColumn pathName;
        private PictureBox pbPicWait;
        private PictureBox picLoadMap;
        private Panel pnlAddPathSection;
        private Panel pnlWait;
        private DataGridViewTextBoxColumn sectionName;
        private SplitContainer splitContainer1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox txtPathSection;
        private GisMap wbMap;
    }
}