namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class NoticeDetailLog
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
            this.gbRepeat = new GroupBox();
            this.txtReNotice = new TextBox();
            this.cboxCloseOwner = new CheckBox();
            this.btnSend = new Button();
            this.grpDetail = new GroupBox();
            this.txtDescribe = new TextBox();
            this.btnDown = new Button();
            this.btnUp = new Button();
            this.lblOrderNameValue = new Label();
            this.lblOrderName = new Label();
            this.lblDescribe = new Label();
            this.lblCarNumValue = new Label();
            this.lblCarNum = new Label();
            this.lblGpsTimeValue = new Label();
            this.lblGpsTime = new Label();
            this.btnClose = new Button();
            this.gbRepeat.SuspendLayout();
            this.grpDetail.SuspendLayout();
            base.SuspendLayout();
            this.gbRepeat.Controls.Add(this.txtReNotice);
            this.gbRepeat.Location = new System.Drawing.Point(13, 240);
            this.gbRepeat.Name = "gbRepeat";
            this.gbRepeat.Size = new Size(386, 106);
            this.gbRepeat.TabIndex = 4;
            this.gbRepeat.TabStop = false;
            this.gbRepeat.Text = "回复";
            this.txtReNotice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtReNotice.Dock = DockStyle.Top;
            this.txtReNotice.Location = new System.Drawing.Point(3, 17);
            this.txtReNotice.Multiline = true;
            this.txtReNotice.Name = "txtReNotice";
            this.txtReNotice.Size = new Size(380, 83);
            this.txtReNotice.TabIndex = 0;
            this.cboxCloseOwner.AutoSize = true;
            this.cboxCloseOwner.Location = new System.Drawing.Point(13, 354);
            this.cboxCloseOwner.Name = "cboxCloseOwner";
            this.cboxCloseOwner.Size = new Size(96, 16);
            this.cboxCloseOwner.TabIndex = 3;
            this.cboxCloseOwner.Text = "本次不再提醒";
            this.cboxCloseOwner.UseVisualStyleBackColor = true;
            this.cboxCloseOwner.CheckedChanged += new EventHandler(this.cboxCloseOwner_CheckedChanged);
            this.btnSend.Location = new System.Drawing.Point(258, 352);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new Size(66, 21);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new EventHandler(this.btnSend_Click);
            this.grpDetail.Controls.Add(this.txtDescribe);
            this.grpDetail.Controls.Add(this.btnDown);
            this.grpDetail.Controls.Add(this.btnUp);
            this.grpDetail.Controls.Add(this.lblOrderNameValue);
            this.grpDetail.Controls.Add(this.lblOrderName);
            this.grpDetail.Controls.Add(this.lblDescribe);
            this.grpDetail.Controls.Add(this.lblCarNumValue);
            this.grpDetail.Controls.Add(this.lblCarNum);
            this.grpDetail.Controls.Add(this.lblGpsTimeValue);
            this.grpDetail.Controls.Add(this.lblGpsTime);
            this.grpDetail.Location = new System.Drawing.Point(13, 12);
            this.grpDetail.Name = "grpDetail";
            this.grpDetail.Size = new Size(386, 226);
            this.grpDetail.TabIndex = 5;
            this.grpDetail.TabStop = false;
            this.grpDetail.Text = "日志详细信息";
            this.txtDescribe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescribe.Location = new System.Drawing.Point(14, 95);
            this.txtDescribe.Multiline = true;
            this.txtDescribe.Name = "txtDescribe";
            this.txtDescribe.ReadOnly = true;
            this.txtDescribe.ScrollBars = ScrollBars.Vertical;
            this.txtDescribe.Size = new Size(364, 117);
            this.txtDescribe.TabIndex = 6;
            this.btnDown.Location = new System.Drawing.Point(305, 53);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new Size(75, 23);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "下一条";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new EventHandler(this.btnDown_Click);
            this.btnUp.Location = new System.Drawing.Point(305, 25);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new Size(75, 23);
            this.btnUp.TabIndex = 5;
            this.btnUp.Text = "上一条";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new EventHandler(this.btnUp_Click);
            this.lblOrderNameValue.AutoSize = true;
            this.lblOrderNameValue.Location = new System.Drawing.Point(237, 58);
            this.lblOrderNameValue.Name = "lblOrderNameValue";
            this.lblOrderNameValue.Size = new Size(53, 12);
            this.lblOrderNameValue.TabIndex = 1;
            this.lblOrderNameValue.Text = "掉线通知";
            this.lblOrderName.AutoSize = true;
            this.lblOrderName.Location = new System.Drawing.Point(166, 58);
            this.lblOrderName.Name = "lblOrderName";
            this.lblOrderName.Size = new Size(65, 12);
            this.lblOrderName.TabIndex = 0;
            this.lblOrderName.Text = "操作类型：";
            this.lblDescribe.AutoSize = true;
            this.lblDescribe.Location = new System.Drawing.Point(24, 80);
            this.lblDescribe.Name = "lblDescribe";
            this.lblDescribe.Size = new Size(41, 12);
            this.lblDescribe.TabIndex = 0;
            this.lblDescribe.Text = "描述：";
            this.lblCarNumValue.AutoSize = true;
            this.lblCarNumValue.Location = new System.Drawing.Point(71, 58);
            this.lblCarNumValue.Name = "lblCarNumValue";
            this.lblCarNumValue.Size = new Size(35, 12);
            this.lblCarNumValue.TabIndex = 1;
            this.lblCarNumValue.Text = "52496";
            this.lblCarNum.AutoSize = true;
            this.lblCarNum.Location = new System.Drawing.Point(12, 58);
            this.lblCarNum.Name = "lblCarNum";
            this.lblCarNum.Size = new Size(53, 12);
            this.lblCarNum.TabIndex = 0;
            this.lblCarNum.Text = "车牌号：";
            this.lblGpsTimeValue.AutoSize = true;
            this.lblGpsTimeValue.Location = new System.Drawing.Point(71, 30);
            this.lblGpsTimeValue.Name = "lblGpsTimeValue";
            this.lblGpsTimeValue.Size = new Size(107, 12);
            this.lblGpsTimeValue.TabIndex = 1;
            this.lblGpsTimeValue.Text = "09-09-15 13:15:50";
            this.lblGpsTime.AutoSize = true;
            this.lblGpsTime.Location = new System.Drawing.Point(24, 30);
            this.lblGpsTime.Name = "lblGpsTime";
            this.lblGpsTime.Size = new Size(41, 12);
            this.lblGpsTime.TabIndex = 0;
            this.lblGpsTime.Text = "时间：";
            this.btnClose.Location = new System.Drawing.Point(330, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new Size(66, 21);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new EventHandler(this.btnClose_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(412, 386);
            base.Controls.Add(this.grpDetail);
            base.Controls.Add(this.cboxCloseOwner);
            base.Controls.Add(this.gbRepeat);
            base.Controls.Add(this.btnClose);
            base.Controls.Add(this.btnSend);
            base.Name = "NoticeDetailLog";
            base.Padding = new Padding(10);
            this.Text = "掉线通知";
            this.gbRepeat.ResumeLayout(false);
            this.gbRepeat.PerformLayout();
            this.grpDetail.ResumeLayout(false);
            this.grpDetail.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private Button btnClose;
        private Button btnSend;
        private CheckBox cboxCloseOwner;
        private GroupBox gbRepeat;
        private GroupBox grpDetail;
        private Label lblCarNum;
        private Label lblCarNumValue;
        private Label lblDescribe;
        private Label lblGpsTime;
        private Label lblGpsTimeValue;
        private Label lblOrderName;
        private Label lblOrderNameValue;
        private string m_sCarId;
        private string m_sCarPw;
        private TextBox txtDescribe;
        private TextBox txtReNotice;
    }
}