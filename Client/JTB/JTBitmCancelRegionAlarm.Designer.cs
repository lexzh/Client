namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBitmCancelRegionAlarm
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
            this.cbRegionType = new ComboBox();
            this.lblRegionType = new Label();
            this.chkLstArea = new CheckBoxList();
            this.lblAreaId = new Label();
            this.cbAllSelect = new CheckBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpCancelParam.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Controls.Add(this.cbAllSelect);
            base.pnlBtn.Location = new System.Drawing.Point(5, 306);
            base.pnlBtn.Controls.SetChildIndex(this.cbAllSelect, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnOK, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnCancel, 0);
            this.grpCancelParam.Controls.Add(this.cbRegionType);
            this.grpCancelParam.Controls.Add(this.lblRegionType);
            this.grpCancelParam.Controls.Add(this.chkLstArea);
            this.grpCancelParam.Controls.Add(this.lblAreaId);
            this.grpCancelParam.Dock = DockStyle.Top;
            this.grpCancelParam.Location = new System.Drawing.Point(5, 121);
            this.grpCancelParam.Name = "grpCancelParam";
            this.grpCancelParam.Size = new Size(363, 185);
            this.grpCancelParam.TabIndex = 11;
            this.grpCancelParam.TabStop = false;
            this.grpCancelParam.Text = "取消区域报警参数";
            this.cbRegionType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbRegionType.FormattingEnabled = true;
            this.cbRegionType.Items.AddRange(new object[] { "", "圆形", "矩形", "多边形" });
            this.cbRegionType.Location = new System.Drawing.Point(75, 18);
            this.cbRegionType.Name = "cbRegionType";
            this.cbRegionType.Size = new Size(160, 20);
            this.cbRegionType.TabIndex = 19;
            this.cbRegionType.Tag = "99999";
            this.cbRegionType.SelectedIndexChanged += new EventHandler(this.cbRegionType_SelectedIndexChanged);
            this.lblRegionType.AutoSize = true;
            this.lblRegionType.Location = new System.Drawing.Point(7, 22);
            this.lblRegionType.Name = "lblRegionType";
            this.lblRegionType.Size = new Size(65, 12);
            this.lblRegionType.TabIndex = 18;
            this.lblRegionType.Text = "区域类型：";
            this.chkLstArea.AutoScroll = true;
            this.chkLstArea.BackColor = Color.White;
            this.chkLstArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkLstArea.Location = new System.Drawing.Point(75, 47);
            this.chkLstArea.Name = "chkLstArea";
            this.chkLstArea.Padding = new Padding(1);
            this.chkLstArea.Size = new Size(282, 132);
            this.chkLstArea.TabIndex = 17;
            this.chkLstArea.Tag = "99999";
            this.lblAreaId.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Location = new System.Drawing.Point(19, 50);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new Size(53, 12);
            this.lblAreaId.TabIndex = 14;
            this.lblAreaId.Text = "区域ID：";
            this.cbAllSelect.AutoSize = true;
            this.cbAllSelect.Location = new System.Drawing.Point(75, 7);
            this.cbAllSelect.Name = "cbAllSelect";
            this.cbAllSelect.Size = new Size(48, 16);
            this.cbAllSelect.TabIndex = 5;
            this.cbAllSelect.Tag = "99999";
            this.cbAllSelect.Text = "全选";
            this.cbAllSelect.UseVisualStyleBackColor = true;
            this.cbAllSelect.CheckedChanged += new EventHandler(this.cbAllSelect_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 339);
            base.Controls.Add(this.grpCancelParam);
            base.Name = "JTBitmCancelRegionAlarm";
            this.Text = "JTBitmCancelRegionAlarm";
            base.Load += new EventHandler(this.JTBitmCancelRegionAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpCancelParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            base.pnlBtn.PerformLayout();
            this.grpCancelParam.ResumeLayout(false);
            this.grpCancelParam.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private CheckBox cbAllSelect;
        private ComboBox cbRegionType;
        private CheckBoxList chkLstArea;
        private System.Windows.Forms.GroupBox grpCancelParam;
        private Label lblAreaId;
        private Label lblRegionType;
    }
}