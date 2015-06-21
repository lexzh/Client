namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mLedSetLight
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(m2mLedSetLight));
            this.grpReturnTime = new GroupBox();
            this.pnlAddDel = new Panel();
            this.tsAddDel = new ToolStrip();
            this.tsbAdd = new ToolStripButton();
            this.tsbDel = new ToolStripButton();
            this.lblBeginTime = new Label();
            this.dtpBeginTime = new DateTimePicker();
            this.lblEndTime = new Label();
            this.dtpEndTime = new DateTimePicker();
            this.lblLight = new Label();
            this.cmbLight = new ComBox();
            this.lvLedLight = new ListView();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpReturnTime.SuspendLayout();
            this.pnlAddDel.SuspendLayout();
            this.tsAddDel.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 354);
            base.pnlBtn.TabIndex = 2;
            this.grpReturnTime.Controls.Add(this.pnlAddDel);
            this.grpReturnTime.Controls.Add(this.lblBeginTime);
            this.grpReturnTime.Controls.Add(this.dtpBeginTime);
            this.grpReturnTime.Controls.Add(this.lblEndTime);
            this.grpReturnTime.Controls.Add(this.dtpEndTime);
            this.grpReturnTime.Controls.Add(this.lblLight);
            this.grpReturnTime.Controls.Add(this.cmbLight);
            this.grpReturnTime.Controls.Add(this.lvLedLight);
            this.grpReturnTime.Dock = DockStyle.Top;
            this.grpReturnTime.Location = new System.Drawing.Point(5, 121);
            this.grpReturnTime.Name = "grpReturnTime";
            this.grpReturnTime.Size = new Size(363, 233);
            this.grpReturnTime.TabIndex = 1;
            this.grpReturnTime.TabStop = false;
            this.grpReturnTime.Text = "亮度设置";
            this.pnlAddDel.Controls.Add(this.tsAddDel);
            this.pnlAddDel.Location = new System.Drawing.Point(288, 76);
            this.pnlAddDel.Name = "pnlAddDel";
            this.pnlAddDel.Size = new Size(44, 22);
            this.pnlAddDel.TabIndex = 3;
            this.tsAddDel.BackColor = Color.Transparent;
            this.tsAddDel.Dock = DockStyle.None;
            this.tsAddDel.GripStyle = ToolStripGripStyle.Hidden;
            this.tsAddDel.ImageScalingSize = new Size(17, 20);
            this.tsAddDel.Items.AddRange(new ToolStripItem[] { this.tsbAdd, this.tsbDel });
            this.tsAddDel.Location = new System.Drawing.Point(0, -1);
            this.tsAddDel.Name = "tsAddDel";
            this.tsAddDel.Padding = new Padding(0);
            this.tsAddDel.Size = new Size(48, 25);
            this.tsAddDel.TabIndex = 0;
            this.tsAddDel.Tag = "";
            this.tsbAdd.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbAdd.Image = (Image) resources.GetObject("tsbAdd.Image");
            this.tsbAdd.ImageScaling = ToolStripItemImageScaling.None;
            this.tsbAdd.ImageTransparentColor = Color.Magenta;
            this.tsbAdd.Margin = new Padding(0, 0, 0, 1);
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Padding = new Padding(2, 0, 1, 0);
            this.tsbAdd.Size = new Size(23, 24);
            this.tsbAdd.Text = "添加";
            this.tsbAdd.Click += new EventHandler(this.tsbAdd_Click);
            this.tsbDel.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbDel.Image = (Image) resources.GetObject("tsbDel.Image");
            this.tsbDel.ImageScaling = ToolStripItemImageScaling.None;
            this.tsbDel.ImageTransparentColor = Color.Magenta;
            this.tsbDel.Margin = new Padding(0, 0, 0, 1);
            this.tsbDel.Name = "tsbDel";
            this.tsbDel.Padding = new Padding(2, 0, 1, 0);
            this.tsbDel.Size = new Size(23, 24);
            this.tsbDel.Text = "删除";
            this.tsbDel.Click += new EventHandler(this.tsbDel_Click);
            this.lblBeginTime.AutoSize = true;
            this.lblBeginTime.Location = new System.Drawing.Point(50, 24);
            this.lblBeginTime.Name = "lblBeginTime";
            this.lblBeginTime.Size = new Size(65, 12);
            this.lblBeginTime.TabIndex = 1;
            this.lblBeginTime.Tag = "999";
            this.lblBeginTime.Text = "开始时间：";
            this.dtpBeginTime.CustomFormat = "HH:mm:ss";
            this.dtpBeginTime.Format = DateTimePickerFormat.Custom;
            this.dtpBeginTime.Location = new System.Drawing.Point(122, 20);
            this.dtpBeginTime.Name = "dtpBeginTime";
            this.dtpBeginTime.ShowUpDown = true;
            this.dtpBeginTime.Size = new Size(161, 21);
            this.dtpBeginTime.TabIndex = 0;
            this.dtpBeginTime.Tag = "999";
            this.dtpBeginTime.Value = new DateTime(2010, 8, 9, 0, 0, 0, 0);
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(50, 53);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 1;
            this.lblEndTime.Tag = "999";
            this.lblEndTime.Text = "结束时间：";
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(122, 49);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new Size(161, 21);
            this.dtpEndTime.TabIndex = 1;
            this.dtpEndTime.Tag = "999";
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(50, 81);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new Size(65, 12);
            this.lblLight.TabIndex = 2;
            this.lblLight.Tag = "999";
            this.lblLight.Text = "屏幕亮度：";
            this.cmbLight.DisplayMember = "Display";
            this.cmbLight.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbLight.FlatStyle = FlatStyle.Flat;
            this.cmbLight.FormattingEnabled = true;
            this.cmbLight.Location = new System.Drawing.Point(122, 77);
            this.cmbLight.Name = "cmbLight";
            this.cmbLight.Size = new Size(161, 20);
            this.cmbLight.TabIndex = 2;
            this.cmbLight.Tag = "999";
            this.cmbLight.ValueMember = "Value";
            this.lvLedLight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvLedLight.FullRowSelect = true;
            this.lvLedLight.HeaderStyle = ColumnHeaderStyle.None;
            this.lvLedLight.HideSelection = false;
            this.lvLedLight.Location = new System.Drawing.Point(52, 106);
            this.lvLedLight.MultiSelect = false;
            this.lvLedLight.Name = "lvLedLight";
            this.lvLedLight.Size = new Size(231, 118);
            this.lvLedLight.TabIndex = 4;
            this.lvLedLight.Tag = "；";
            this.lvLedLight.UseCompatibleStateImageBehavior = false;
            this.lvLedLight.View = View.SmallIcon;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 387);
            base.Controls.Add(this.grpReturnTime);
            base.Name = "m2mLedSetLight";
            this.Text = "m2mLedSetReturnTime";
            base.Load += new EventHandler(this.m2mLedSetLight_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpReturnTime, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpReturnTime.ResumeLayout(false);
            this.grpReturnTime.PerformLayout();
            this.pnlAddDel.ResumeLayout(false);
            this.pnlAddDel.PerformLayout();
            this.tsAddDel.ResumeLayout(false);
            this.tsAddDel.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbLight;
        private DataTable dt;
        private DateTimePicker dtpBeginTime;
        private DateTimePicker dtpEndTime;
        private GroupBox grpReturnTime;
        private Label lblBeginTime;
        private Label lblEndTime;
        private Label lblLight;
        private ListView lvLedLight;
        private Panel pnlAddDel;
        private ToolStrip tsAddDel;
        private ToolStripButton tsbAdd;
        private ToolStripButton tsbDel;
    }
}