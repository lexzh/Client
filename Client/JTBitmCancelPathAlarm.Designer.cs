namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class JTBitmCancelPathAlarm
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
            this.chkLstArea = new CheckBoxList();
            this.lblAreaId = new Label();
            this.chkCheckAll = new CheckBox();
            this.pnlWait = new Panel();
            this.pbPicWait = new PictureBox();
            this.lblWaitText = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpCancelParam.SuspendLayout();
            this.pnlWait.SuspendLayout();
            ((ISupportInitialize) this.pbPicWait).BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Controls.Add(this.pnlWait);
            base.pnlBtn.Controls.Add(this.chkCheckAll);
            base.pnlBtn.Location = new System.Drawing.Point(5, 306);
            base.pnlBtn.Controls.SetChildIndex(this.chkCheckAll, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnOK, 0);
            base.pnlBtn.Controls.SetChildIndex(base.btnCancel, 0);
            base.pnlBtn.Controls.SetChildIndex(this.pnlWait, 0);
            this.grpCancelParam.Controls.Add(this.chkLstArea);
            this.grpCancelParam.Controls.Add(this.lblAreaId);
            this.grpCancelParam.Dock = DockStyle.Top;
            this.grpCancelParam.Location = new System.Drawing.Point(5, 121);
            this.grpCancelParam.Name = "grpCancelParam";
            this.grpCancelParam.Size = new Size(363, 185);
            this.grpCancelParam.TabIndex = 12;
            this.grpCancelParam.TabStop = false;
            this.grpCancelParam.Text = "取消路线报警参数";
            this.chkLstArea.AutoScroll = true;
            this.chkLstArea.BackColor = Color.White;
            this.chkLstArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chkLstArea.Location = new System.Drawing.Point(62, 20);
            this.chkLstArea.Name = "chkLstArea";
            this.chkLstArea.Padding = new Padding(1);
            this.chkLstArea.Size = new Size(295, 159);
            this.chkLstArea.TabIndex = 17;
            this.chkLstArea.Tag = "";
            this.lblAreaId.Anchor = AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Top;
            this.lblAreaId.AutoSize = true;
            this.lblAreaId.Location = new System.Drawing.Point(6, 20);
            this.lblAreaId.Name = "lblAreaId";
            this.lblAreaId.Size = new Size(53, 12);
            this.lblAreaId.TabIndex = 14;
            this.lblAreaId.Text = "路线ID：";
            this.chkCheckAll.AutoSize = true;
            this.chkCheckAll.Location = new System.Drawing.Point(140, 6);
            this.chkCheckAll.Name = "chkCheckAll";
            this.chkCheckAll.Size = new Size(48, 16);
            this.chkCheckAll.TabIndex = 5;
            this.chkCheckAll.Text = "全选";
            this.chkCheckAll.UseVisualStyleBackColor = true;
            this.chkCheckAll.CheckedChanged += new EventHandler(this.chkCheckAll_CheckedChanged);
            this.pnlWait.Controls.Add(this.pbPicWait);
            this.pnlWait.Controls.Add(this.lblWaitText);
            this.pnlWait.Location = new System.Drawing.Point(5, 3);
            this.pnlWait.Name = "pnlWait";
            this.pnlWait.Size = new Size(129, 22);
            this.pnlWait.TabIndex = 14;
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
            base.ClientSize = new Size(373, 339);
            base.Controls.Add(this.grpCancelParam);
            base.Name = "JTBitmCancelPathAlarm";
            this.Text = "JTBitmCancelPathAlarm";
            base.Load += new EventHandler(this.JTBitmCancelPathAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpCancelParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            base.pnlBtn.PerformLayout();
            this.grpCancelParam.ResumeLayout(false);
            this.grpCancelParam.PerformLayout();
            this.pnlWait.ResumeLayout(false);
            this.pnlWait.PerformLayout();
            ((ISupportInitialize) this.pbPicWait).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private CheckBox chkCheckAll;
        private CheckBoxList chkLstArea;
        private System.Windows.Forms.GroupBox grpCancelParam;
        private Label lblAreaId;
        private Label lblWaitText;
        private PictureBox pbPicWait;
        private Panel pnlWait;
    }
}