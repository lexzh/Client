namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmCancelRegionAlarm
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
            this.txtAreaId = new TextBox();
            this.lblExplain = new Label();
            this.lblAreaId = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpCancelParam.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 190);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpCancelParam.Controls.Add(this.txtAreaId);
            this.grpCancelParam.Controls.Add(this.lblExplain);
            this.grpCancelParam.Controls.Add(this.lblAreaId);
            this.grpCancelParam.Dock = DockStyle.Top;
            this.grpCancelParam.Location = new System.Drawing.Point(5, 121);
            this.grpCancelParam.Name = "grpCancelParam";
            this.grpCancelParam.Size = new Size(363, 69);
            this.grpCancelParam.TabIndex = 1;
            this.grpCancelParam.TabStop = false;
            this.grpCancelParam.Text = "取消区域报警参数";
            this.txtAreaId.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.txtAreaId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAreaId.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtAreaId.Location = new System.Drawing.Point(92, 20);
            this.txtAreaId.Name = "txtAreaId";
            this.txtAreaId.Size = new Size(222, 21);
            this.txtAreaId.TabIndex = 0;
            this.txtAreaId.Tag = "；";
            this.txtAreaId.KeyPress += new KeyPressEventHandler(this.txtAreaId_KeyPress);
            this.lblExplain.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblExplain.AutoSize = true;
            this.lblExplain.Location = new System.Drawing.Point(60, 44);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new Size(215, 12);
            this.lblExplain.TabIndex = 16;
            this.lblExplain.Tag = "9999";
            this.lblExplain.Text = @"格式例如：1\2\或者1\;为空则全部取消";
            this.lblAreaId.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Location = new System.Drawing.Point(33, 24);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new Size(53, 12);
            this.lblAreaId.TabIndex = 14;
            this.lblAreaId.Text = "区域ID：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 223);
            base.Controls.Add(this.grpCancelParam);
            base.Name = "itmCancelRegionAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmCancelRegionAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpCancelParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpCancelParam.ResumeLayout(false);
            this.grpCancelParam.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox grpCancelParam;
        private int iRegionFeature;
        private Label lblAreaId;
        private Label lblExplain;
        private TextBox txtAreaId;
    }
}