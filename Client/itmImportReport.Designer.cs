namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Timers;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmImportReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(itmImportReport));
            this.wbMap = new WinFormsUI.Controls.GisMap();
            this.pnlTool = new System.Windows.Forms.Panel();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.lblSelectMap = new System.Windows.Forms.ToolStripLabel();
            this.cmbSelectMap = new System.Windows.Forms.ToolStripComboBox();
            this.tsbMove = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomUp = new System.Windows.Forms.ToolStripButton();
            this.tsbZoomDown = new System.Windows.Forms.ToolStripButton();
            this.tsbDistance = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.scForm = new System.Windows.Forms.SplitContainer();
            this.pnlHandle = new System.Windows.Forms.Panel();
            this.lbImportCar = new System.Windows.Forms.ListBox();
            this.pnlAddDel = new System.Windows.Forms.Panel();
            this.tsAddDel = new System.Windows.Forms.ToolStrip();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDel = new System.Windows.Forms.ToolStripButton();
            this.pnlCarList = new System.Windows.Forms.Panel();
            this.pnlTxt = new System.Windows.Forms.Panel();
            this.cmbAddCar = new WinFormsUI.Controls.ComBox();
            this.pnlLbl = new System.Windows.Forms.Panel();
            this.lblAddCar = new System.Windows.Forms.Label();
            this.picLoadMap = new System.Windows.Forms.PictureBox();
            this.pnlTool.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.scForm.Panel1.SuspendLayout();
            this.scForm.Panel2.SuspendLayout();
            this.scForm.SuspendLayout();
            this.pnlHandle.SuspendLayout();
            this.pnlAddDel.SuspendLayout();
            this.tsAddDel.SuspendLayout();
            this.pnlCarList.SuspendLayout();
            this.pnlTxt.SuspendLayout();
            this.pnlLbl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).BeginInit();
            this.SuspendLayout();
            // 
            // wbMap
            // 
            this.wbMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wbMap.IsWebBrowserContextMenuEnabled = false;
            this.wbMap.Location = new System.Drawing.Point(0, 29);
            this.wbMap.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbMap.Name = "wbMap";
            this.wbMap.ScrollBarsEnabled = false;
            this.wbMap.Size = new System.Drawing.Size(465, 469);
            this.wbMap.TabIndex = 2;
            this.wbMap.WebBrowserShortcutsEnabled = false;
            this.wbMap.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wbMap_DocumentCompleted);
            // 
            // pnlTool
            // 
            this.pnlTool.Controls.Add(this.tsMenu);
            this.pnlTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTool.Location = new System.Drawing.Point(0, 0);
            this.pnlTool.Name = "pnlTool";
            this.pnlTool.Size = new System.Drawing.Size(465, 29);
            this.pnlTool.TabIndex = 1;
            // 
            // tsMenu
            // 
            this.tsMenu.AutoSize = false;
            this.tsMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsMenu.ImageScalingSize = new System.Drawing.Size(17, 20);
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblSelectMap,
            this.cmbSelectMap,
            this.tsbMove,
            this.tsbZoomUp,
            this.tsbZoomDown,
            this.tsbDistance,
            this.tsbRefresh});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Padding = new System.Windows.Forms.Padding(0);
            this.tsMenu.Size = new System.Drawing.Size(465, 29);
            this.tsMenu.TabIndex = 0;
            // 
            // lblSelectMap
            // 
            this.lblSelectMap.Name = "lblSelectMap";
            this.lblSelectMap.Size = new System.Drawing.Size(68, 26);
            this.lblSelectMap.Text = "选择地图：";
            // 
            // cmbSelectMap
            // 
            this.cmbSelectMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectMap.Name = "cmbSelectMap";
            this.cmbSelectMap.Size = new System.Drawing.Size(150, 29);
            this.cmbSelectMap.SelectedIndexChanged += new System.EventHandler(this.cmbSelectMap_SelectedIndexChanged);
            // 
            // tsbMove
            // 
            this.tsbMove.Image = ((System.Drawing.Image)(resources.GetObject("tsbMove.Image")));
            this.tsbMove.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbMove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMove.Margin = new System.Windows.Forms.Padding(0);
            this.tsbMove.Name = "tsbMove";
            this.tsbMove.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbMove.Size = new System.Drawing.Size(55, 29);
            this.tsbMove.Text = "移动";
            this.tsbMove.ToolTipText = "移动地图";
            this.tsbMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // tsbZoomUp
            // 
            this.tsbZoomUp.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomUp.Image")));
            this.tsbZoomUp.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomUp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomUp.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomUp.Name = "tsbZoomUp";
            this.tsbZoomUp.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbZoomUp.Size = new System.Drawing.Size(55, 29);
            this.tsbZoomUp.Text = "放大";
            this.tsbZoomUp.ToolTipText = "地图放大";
            this.tsbZoomUp.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // tsbZoomDown
            // 
            this.tsbZoomDown.Image = ((System.Drawing.Image)(resources.GetObject("tsbZoomDown.Image")));
            this.tsbZoomDown.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbZoomDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbZoomDown.Margin = new System.Windows.Forms.Padding(0);
            this.tsbZoomDown.Name = "tsbZoomDown";
            this.tsbZoomDown.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbZoomDown.Size = new System.Drawing.Size(55, 29);
            this.tsbZoomDown.Text = "缩小";
            this.tsbZoomDown.ToolTipText = "地图缩小";
            this.tsbZoomDown.Click += new System.EventHandler(this.btnZoonOut_Click);
            // 
            // tsbDistance
            // 
            this.tsbDistance.Image = global::Client.Properties.Resources.ruler;
            this.tsbDistance.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDistance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDistance.Margin = new System.Windows.Forms.Padding(0);
            this.tsbDistance.Name = "tsbDistance";
            this.tsbDistance.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbDistance.Size = new System.Drawing.Size(55, 29);
            this.tsbDistance.Text = "测距";
            this.tsbDistance.ToolTipText = "测量距离";
            this.tsbDistance.Click += new System.EventHandler(this.tsbDistance_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Margin = new System.Windows.Forms.Padding(0);
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbRefresh.Size = new System.Drawing.Size(23, 20);
            this.tsbRefresh.Text = "刷新";
            this.tsbRefresh.Visible = false;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // scForm
            // 
            this.scForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scForm.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.scForm.Location = new System.Drawing.Point(5, 5);
            this.scForm.Name = "scForm";
            // 
            // scForm.Panel1
            // 
            this.scForm.Panel1.Controls.Add(this.pnlHandle);
            // 
            // scForm.Panel2
            // 
            this.scForm.Panel2.Controls.Add(this.picLoadMap);
            this.scForm.Panel2.Controls.Add(this.wbMap);
            this.scForm.Panel2.Controls.Add(this.pnlTool);
            this.scForm.Size = new System.Drawing.Size(660, 498);
            this.scForm.SplitterDistance = 191;
            this.scForm.TabIndex = 3;
            // 
            // pnlHandle
            // 
            this.pnlHandle.Controls.Add(this.lbImportCar);
            this.pnlHandle.Controls.Add(this.pnlAddDel);
            this.pnlHandle.Controls.Add(this.pnlCarList);
            this.pnlHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHandle.Location = new System.Drawing.Point(0, 0);
            this.pnlHandle.Name = "pnlHandle";
            this.pnlHandle.Padding = new System.Windows.Forms.Padding(5);
            this.pnlHandle.Size = new System.Drawing.Size(191, 498);
            this.pnlHandle.TabIndex = 0;
            // 
            // lbImportCar
            // 
            this.lbImportCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbImportCar.DisplayMember = "CarNum";
            this.lbImportCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbImportCar.FormattingEnabled = true;
            this.lbImportCar.ItemHeight = 12;
            this.lbImportCar.Location = new System.Drawing.Point(5, 61);
            this.lbImportCar.Margin = new System.Windows.Forms.Padding(5);
            this.lbImportCar.Name = "lbImportCar";
            this.lbImportCar.Size = new System.Drawing.Size(181, 432);
            this.lbImportCar.TabIndex = 1;
            this.lbImportCar.ValueMember = "SimNum";
            this.lbImportCar.SelectedIndexChanged += new System.EventHandler(this.lbImportCar_SelectedIndexChanged);
            // 
            // pnlAddDel
            // 
            this.pnlAddDel.Controls.Add(this.tsAddDel);
            this.pnlAddDel.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAddDel.Location = new System.Drawing.Point(5, 37);
            this.pnlAddDel.Name = "pnlAddDel";
            this.pnlAddDel.Size = new System.Drawing.Size(181, 24);
            this.pnlAddDel.TabIndex = 18;
            // 
            // tsAddDel
            // 
            this.tsAddDel.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsAddDel.ImageScalingSize = new System.Drawing.Size(17, 20);
            this.tsAddDel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd,
            this.toolStripSeparator1,
            this.tsbDel});
            this.tsAddDel.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.tsAddDel.Location = new System.Drawing.Point(118, 0);
            this.tsAddDel.Name = "tsAddDel";
            this.tsAddDel.Padding = new System.Windows.Forms.Padding(0);
            this.tsAddDel.Size = new System.Drawing.Size(63, 24);
            this.tsAddDel.TabIndex = 1;
            this.tsAddDel.Text = "toolStrip1";
            // 
            // tsbAdd
            // 
            this.tsbAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbAdd.Image")));
            this.tsbAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbAdd.Size = new System.Drawing.Size(23, 23);
            this.tsbAdd.Text = "添加";
            this.tsbAdd.Click += new System.EventHandler(this.tsbAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbDel
            // 
            this.tsbDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDel.Image = ((System.Drawing.Image)(resources.GetObject("tsbDel.Image")));
            this.tsbDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Padding = new System.Windows.Forms.Padding(2, 0, 1, 0);
            this.tsbDel.Size = new System.Drawing.Size(23, 23);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new System.EventHandler(this.tsbDel_Click);
            // 
            // pnlCarList
            // 
            this.pnlCarList.Controls.Add(this.pnlTxt);
            this.pnlCarList.Controls.Add(this.pnlLbl);
            this.pnlCarList.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlCarList.Location = new System.Drawing.Point(5, 5);
            this.pnlCarList.Name = "pnlCarList";
            this.pnlCarList.Size = new System.Drawing.Size(181, 32);
            this.pnlCarList.TabIndex = 0;
            // 
            // pnlTxt
            // 
            this.pnlTxt.Controls.Add(this.cmbAddCar);
            this.pnlTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTxt.Location = new System.Drawing.Point(68, 0);
            this.pnlTxt.Name = "pnlTxt";
            this.pnlTxt.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlTxt.Size = new System.Drawing.Size(113, 32);
            this.pnlTxt.TabIndex = 19;
            // 
            // cmbAddCar
            // 
            this.cmbAddCar.DisplayMember = "Display";
            this.cmbAddCar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbAddCar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddCar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cmbAddCar.FormattingEnabled = true;
            this.cmbAddCar.Location = new System.Drawing.Point(0, 6);
            this.cmbAddCar.Name = "cmbAddCar";
            this.cmbAddCar.Size = new System.Drawing.Size(113, 20);
            this.cmbAddCar.TabIndex = 0;
            this.cmbAddCar.ValueMember = "Value";
            this.cmbAddCar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAddCar_KeyDown);
            this.cmbAddCar.Leave += new System.EventHandler(this.cmbAddCar_Leave);
            // 
            // pnlLbl
            // 
            this.pnlLbl.Controls.Add(this.lblAddCar);
            this.pnlLbl.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLbl.Location = new System.Drawing.Point(0, 0);
            this.pnlLbl.Name = "pnlLbl";
            this.pnlLbl.Size = new System.Drawing.Size(68, 32);
            this.pnlLbl.TabIndex = 18;
            // 
            // lblAddCar
            // 
            this.lblAddCar.AutoSize = true;
            this.lblAddCar.Location = new System.Drawing.Point(3, 10);
            this.lblAddCar.Name = "lblAddCar";
            this.lblAddCar.Size = new System.Drawing.Size(65, 12);
            this.lblAddCar.TabIndex = 18;
            this.lblAddCar.Text = "添加车辆：";
            // 
            // picLoadMap
            // 
            this.picLoadMap.Image = ((System.Drawing.Image)(resources.GetObject("picLoadMap.Image")));
            this.picLoadMap.Location = new System.Drawing.Point(125, 199);
            this.picLoadMap.Name = "picLoadMap";
            this.picLoadMap.Size = new System.Drawing.Size(167, 33);
            this.picLoadMap.TabIndex = 3;
            this.picLoadMap.TabStop = false;
            // 
            // itmImportReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 508);
            this.Controls.Add(this.scForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "itmImportReport";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "重点监控";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.itmImportReport_FormClosing);
            this.Load += new System.EventHandler(this.itmImportReport_Load);
            this.pnlTool.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.scForm.Panel1.ResumeLayout(false);
            this.scForm.Panel2.ResumeLayout(false);
            this.scForm.ResumeLayout(false);
            this.pnlHandle.ResumeLayout(false);
            this.pnlAddDel.ResumeLayout(false);
            this.pnlAddDel.PerformLayout();
            this.tsAddDel.ResumeLayout(false);
            this.tsAddDel.PerformLayout();
            this.pnlCarList.ResumeLayout(false);
            this.pnlTxt.ResumeLayout(false);
            this.pnlLbl.ResumeLayout(false);
            this.pnlLbl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLoadMap)).EndInit();
            this.ResumeLayout(false);

        }

       
        private IContainer components;
        private ComBox cmbAddCar;
        private ToolStripComboBox cmbSelectMap;
        private ListBox lbImportCar;
        private Label lblAddCar;
        private ToolStripLabel lblSelectMap;
        private int m_iSelectedMapIndex;
        private System.Timers.Timer m_tMapLoadedTimer;
        private dTrackingCar myTrackingCar;
        private PictureBox picLoadMap;
        private Panel pnlAddDel;
        private Panel pnlCarList;
        private Panel pnlHandle;
        private Panel pnlLbl;
        private Panel pnlTool;
        private Panel pnlTxt;
        private SplitContainer scForm;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStrip tsAddDel;
        private ToolStripButton tsbAdd;
        private ToolStripButton tsbDel;
        private ToolStripButton tsbDistance;
        private ToolStripButton tsbMove;
        private ToolStripButton tsbRefresh;
        private ToolStripButton tsbZoomDown;
        private ToolStripButton tsbZoomUp;
        private ToolStrip tsMenu;
        private GisMap wbMap;
    }
}