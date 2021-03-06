﻿namespace Client
{
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
    using System.Text;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    partial class itmSetPathAlarm
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
            this.grpSelectRoute = new GroupBox();
            this.clbSelectRoute = new CheckedListBox();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.toolStrip2 = new ToolStrip();
            this.tsBtnSearchdata = new ToolStripButton();
            this.txtFindRoad = new System.Windows.Forms.TextBox();
            this.lblFindRoad = new System.Windows.Forms.Label();
            this.comboBoxLines = new ComboBox();
            this.toolStrip1 = new ToolStrip();
            this.tsBtnFilter = new ToolStripButton();
            this.lbLine = new System.Windows.Forms.Label();
            this.pnlSelectAll = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.pnlWait = new System.Windows.Forms.Panel();
            this.pbPicWait = new PictureBox();
            this.lblWaitText = new System.Windows.Forms.Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSelectRoute.SuspendLayout();
            this.pnlFilter.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlSelectAll.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((ISupportInitialize) this.pbPicWait).BeginInit();
            base.SuspendLayout();
            base.grpCar.Size = new Size(535, 116);
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Controls.Add(this.pnlWait);
            base.pnlBtn.Location = new System.Drawing.Point(5, 324);
            base.pnlBtn.Size = new Size(535, 28);
            base.pnlBtn.TabIndex = 2;
            base.pnlBtn.Controls.SetChildIndex(base.btnOK, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnCancel, 0);
            base.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpSelectRoute.Controls.Add(this.clbSelectRoute);
            this.grpSelectRoute.Controls.Add(this.pnlFilter);
            this.grpSelectRoute.Controls.Add(this.pnlSelectAll);
            this.grpSelectRoute.Dock = DockStyle.Top;
            this.grpSelectRoute.Location = new System.Drawing.Point(5, 121);
            this.grpSelectRoute.Margin = new Padding(0);
            this.grpSelectRoute.Name = "grpSelectRoute";
            this.grpSelectRoute.Size = new Size(535, 203);
            this.grpSelectRoute.TabIndex = 1;
            this.grpSelectRoute.TabStop = false;
            this.grpSelectRoute.Text = "选择预设路线名称";
            this.clbSelectRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbSelectRoute.CheckOnClick = true;
            this.clbSelectRoute.Dock = DockStyle.Fill;
            this.clbSelectRoute.FormattingEnabled = true;
            this.clbSelectRoute.Location = new System.Drawing.Point(3, 43);
            this.clbSelectRoute.Name = "clbSelectRoute";
            this.clbSelectRoute.Size = new Size(529, 130);
            this.clbSelectRoute.TabIndex = 0;
            this.pnlFilter.Controls.Add(this.toolStrip2);
            this.pnlFilter.Controls.Add(this.txtFindRoad);
            this.pnlFilter.Controls.Add(this.lblFindRoad);
            this.pnlFilter.Controls.Add(this.comboBoxLines);
            this.pnlFilter.Controls.Add(this.toolStrip1);
            this.pnlFilter.Controls.Add(this.lbLine);
            this.pnlFilter.Dock = DockStyle.Top;
            this.pnlFilter.Location = new System.Drawing.Point(3, 17);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new Size(529, 26);
            this.pnlFilter.TabIndex = 3;
            this.toolStrip2.Dock = DockStyle.None;
            this.toolStrip2.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new ToolStripItem[] { this.tsBtnSearchdata });
            this.toolStrip2.Location = new System.Drawing.Point(380, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new Size(26, 25);
            this.toolStrip2.TabIndex = 9;
            this.toolStrip2.Text = "toolStrip2";
            this.tsBtnSearchdata.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsBtnSearchdata.Image = Resources.find;
            this.tsBtnSearchdata.ImageTransparentColor = Color.Magenta;
            this.tsBtnSearchdata.Name = "tsBtnSearchdata";
            this.tsBtnSearchdata.Size = new Size(23, 22);
            this.tsBtnSearchdata.Text = "路线过滤查找";
            this.tsBtnSearchdata.Click += new EventHandler(this.tsBtnSearchdata_Click);
            this.txtFindRoad.Location = new System.Drawing.Point(310, 3);
            this.txtFindRoad.Name = "txtFindRoad";
            this.txtFindRoad.Size = new Size(67, 21);
            this.txtFindRoad.TabIndex = 5;
            this.txtFindRoad.Tag = "9999";
            this.txtFindRoad.TextChanged += new EventHandler(this.txtFindRoad_TextChanged);
            this.lblFindRoad.AutoSize = true;
            this.lblFindRoad.Location = new System.Drawing.Point(243, 7);
            this.lblFindRoad.Name = "lblFindRoad";
            this.lblFindRoad.Size = new Size(65, 12);
            this.lblFindRoad.TabIndex = 4;
            this.lblFindRoad.Text = "查找路线：";
            this.comboBoxLines.DisplayMember = "PathgroupName";
            this.comboBoxLines.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBoxLines.FormattingEnabled = true;
            this.comboBoxLines.ImeMode =  System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxLines.Location = new System.Drawing.Point(101, 3);
            this.comboBoxLines.Name = "comboBoxLines";
            this.comboBoxLines.Size = new Size(106, 20);
            this.comboBoxLines.TabIndex = 3;
            this.comboBoxLines.Tag = "999";
            this.comboBoxLines.ValueMember = "PathgroupID";
            this.toolStrip1.Dock = DockStyle.None;
            this.toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new ToolStripItem[] { this.tsBtnFilter });
            this.toolStrip1.Location = new System.Drawing.Point(210, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new Size(26, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            this.tsBtnFilter.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsBtnFilter.Image = Resources.find;
            this.tsBtnFilter.ImageTransparentColor = Color.Magenta;
            this.tsBtnFilter.Name = "tsBtnFilter";
            this.tsBtnFilter.Size = new Size(23, 22);
            this.tsBtnFilter.Text = "搜索 ";
            this.tsBtnFilter.Click += new EventHandler(this.tsBtnFilter_Click);
            this.lbLine.AutoSize = true;
            this.lbLine.Location = new System.Drawing.Point(5, 7);
            this.lbLine.Name = "lbLine";
            this.lbLine.Size = new Size(89, 12);
            this.lbLine.TabIndex = 1;
            this.lbLine.Tag = "999";
            this.lbLine.Text = "路线分组名称：";
            this.pnlSelectAll.Controls.Add(this.chkSelectAll);
            this.pnlSelectAll.Dock = DockStyle.Bottom;
            this.pnlSelectAll.Location = new System.Drawing.Point(3, 179);
            this.pnlSelectAll.Name = "pnlSelectAll";
            this.pnlSelectAll.Size = new Size(529, 21);
            this.pnlSelectAll.TabIndex = 2;
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(266, 0);
            this.chkSelectAll.Margin = new Padding(0);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new Size(72, 16);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Tag = "9999";
            this.chkSelectAll.Text = "全部选择";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new EventHandler(this.chkSelectAll_CheckedChanged);
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(11, 3);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new Size(129, 22);
            this.pnlWait.TabIndex = 13;
            this.pnlWait.Tag = "9999";
            this.pbPicWait.BackColor = Color.Transparent;
            this.pbPicWait.Image = Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(3, 3);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            this.lblWaitText.AutoSize = true;
            this.lblWaitText.Location = new System.Drawing.Point(22, 5);
            this.lblWaitText.Name = "lblWaitText";
            this.lblWaitText.Size = new Size(89, 12);
            this.lblWaitText.TabIndex = 9;
            this.lblWaitText.Text = "正在执行中....";
            this.lblWaitText.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(545, 357);
            base.Controls.Add(this.grpSelectRoute);
            base.Name = "itmSetPathAlarm";
            this.Text = "SetExcursionAlarm";
            base.Load += new EventHandler(this.itmSetPathAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSelectRoute, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSelectRoute.ResumeLayout(false);
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlSelectAll.ResumeLayout(false);
            this.pnlSelectAll.PerformLayout();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((ISupportInitialize) this.pbPicWait).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private CheckedListBox clbSelectRoute;
        private ComboBox comboBoxLines;
        private System.Windows.Forms.GroupBox grpSelectRoute;
        private System.Windows.Forms.Label lblFindRoad;
        private System.Windows.Forms.Label lbLine;
        private System.Windows.Forms.Label lblWaitText;
        private PictureBox pbPicWait;
        private System.Windows.Forms.Panel pnlFilter;
        private System.Windows.Forms.Panel pnlSelectAll;
        private System.Windows.Forms.Panel pnlWait;
        private ToolStrip toolStrip1;
        private ToolStrip toolStrip2;
        private ToolStripButton tsBtnFilter;
        private ToolStripButton tsBtnSearchdata;
        private System.Windows.Forms.TextBox txtFindRoad;
    }
}