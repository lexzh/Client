namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mCancelRegionAlarm
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
            this.grpCancelParam = new GroupBox();
            this.pnlRegionAlarmType = new Panel();
            this.cbxMainRegion = new CheckBox();
            this.cbxExpandRegion = new CheckBox();
            this.pnlRegionAlarmValue = new Panel();
            this.chkLstArea = new CheckBoxList();
            this.lblAreaId = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpCancelParam.SuspendLayout();
            this.pnlRegionAlarmType.SuspendLayout();
            this.pnlRegionAlarmValue.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 306);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpCancelParam.Controls.Add(this.pnlRegionAlarmType);
            this.grpCancelParam.Controls.Add(this.pnlRegionAlarmValue);
            this.grpCancelParam.Dock = DockStyle.Top;
            this.grpCancelParam.Location = new System.Drawing.Point(5, 121);
            this.grpCancelParam.Name = "grpCancelParam";
            this.grpCancelParam.Size = new Size(363, 185);
            this.grpCancelParam.TabIndex = 1;
            this.grpCancelParam.TabStop = false;
            this.grpCancelParam.Text = "取消区域报警参数";
            this.pnlRegionAlarmType.Controls.Add(this.cbxMainRegion);
            this.pnlRegionAlarmType.Controls.Add(this.cbxExpandRegion);
            this.pnlRegionAlarmType.Dock = DockStyle.Top;
            this.pnlRegionAlarmType.Location = new System.Drawing.Point(3, 17);
            this.pnlRegionAlarmType.Name = "pnlRegionAlarmType";
            this.pnlRegionAlarmType.Size = new Size(357, 40);
            this.pnlRegionAlarmType.TabIndex = 19;
            this.cbxMainRegion.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.cbxMainRegion.AutoSize = true;
            this.cbxMainRegion.Location = new System.Drawing.Point(52, 1);
            this.cbxMainRegion.Name = "cbxMainRegion";
            this.cbxMainRegion.Size = new Size(60, 16);
            this.cbxMainRegion.TabIndex = 12;
            this.cbxMainRegion.Text = "主区域";
            this.cbxMainRegion.UseVisualStyleBackColor = true;
            this.cbxExpandRegion.Anchor = AnchorStyles.Left | AnchorStyles.Bottom;
            this.cbxExpandRegion.AutoSize = true;
            this.cbxExpandRegion.Location = new System.Drawing.Point(52, 22);
            this.cbxExpandRegion.Name = "cbxExpandRegion";
            this.cbxExpandRegion.Size = new Size(72, 16);
            this.cbxExpandRegion.TabIndex = 13;
            this.cbxExpandRegion.Text = "扩展区域";
            this.cbxExpandRegion.UseVisualStyleBackColor = true;
            this.cbxExpandRegion.CheckedChanged += new EventHandler(this.cbxExpandRegion_CheckedChanged);
            this.pnlRegionAlarmValue.Controls.Add(this.chkLstArea);
            this.pnlRegionAlarmValue.Controls.Add(this.lblAreaId);
            this.pnlRegionAlarmValue.Dock = DockStyle.Bottom;
            this.pnlRegionAlarmValue.Location = new System.Drawing.Point(3, 57);
            this.pnlRegionAlarmValue.Name = "pnlRegionAlarmValue";
            this.pnlRegionAlarmValue.Size = new Size(357, 125);
            this.pnlRegionAlarmValue.TabIndex = 19;
            this.chkLstArea.AutoScroll = true;
            this.chkLstArea.BackColor = Color.White;
            this.chkLstArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkLstArea.Location = new System.Drawing.Point(107, 4);
            this.chkLstArea.Name = "chkLstArea";
            this.chkLstArea.Padding = new Padding(1);
            this.chkLstArea.Size = new Size(216, 112);
            this.chkLstArea.TabIndex = 17;
            this.chkLstArea.Tag = "";
            this.lblAreaId.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Location = new System.Drawing.Point(51, 7);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new Size(53, 12);
            this.lblAreaId.TabIndex = 14;
            this.lblAreaId.Text = "区域ID：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 339);
            base.Controls.Add(this.grpCancelParam);
            base.Name = "m2mCancelRegionAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmCancelRegionAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpCancelParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpCancelParam.ResumeLayout(false);
            this.pnlRegionAlarmType.ResumeLayout(false);
            this.pnlRegionAlarmType.PerformLayout();
            this.pnlRegionAlarmValue.ResumeLayout(false);
            this.pnlRegionAlarmValue.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private CheckBox cbxExpandRegion;
        private CheckBox cbxMainRegion;
        private CheckBoxList chkLstArea;
        private GroupBox grpCancelParam;
        private int iRegionFeature;
        private Label lblAreaId;
        private Panel pnlRegionAlarmType;
        private Panel pnlRegionAlarmValue;
    }
}