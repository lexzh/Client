namespace Client
{
    partial class LogForms
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tpNewLog = new System.Windows.Forms.TabPage();
            this.myNewLog = new Client.NewLog();
            this.myImageList = new Client.ImageList();
            this.tpCurrentLog = new System.Windows.Forms.TabPage();
            this.myCurrentPos = new Client.CurrentPos();
            this.myAlarmLog = new Client.AlarmLog();
            this.tpAlarmLog = new System.Windows.Forms.TabPage();
            this.tpNotice = new System.Windows.Forms.TabPage();
            this.myNoticeLog = new Client.NoticeLog();
            this.tcLogs = new System.Windows.Forms.TabControl();
            this.tpPicLog = new System.Windows.Forms.TabPage();
            this.tpNewLog.SuspendLayout();
            this.tpCurrentLog.SuspendLayout();
            this.tpAlarmLog.SuspendLayout();
            this.tpNotice.SuspendLayout();
            this.tcLogs.SuspendLayout();
            this.tpPicLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tpNewLog
            // 
            this.tpNewLog.Controls.Add(this.myNewLog);
            this.tpNewLog.Location = new System.Drawing.Point(4, 25);
            this.tpNewLog.Name = "tpNewLog";
            this.tpNewLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpNewLog.Size = new System.Drawing.Size(829, 163);
            this.tpNewLog.TabIndex = 0;
            this.tpNewLog.Text = "最新日志";
            this.tpNewLog.UseVisualStyleBackColor = true;
            // 
            // myNewLog
            // 
            this.myNewLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myNewLog.Location = new System.Drawing.Point(3, 3);
            this.myNewLog.Name = "myNewLog";
            this.myNewLog.Size = new System.Drawing.Size(823, 157);
            this.myNewLog.TabIndex = 0;
            // 
            // myImageList
            // 
            this.myImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myImageList.Location = new System.Drawing.Point(3, 3);
            this.myImageList.Name = "myImageList";
            this.myImageList.Size = new System.Drawing.Size(823, 164);
            this.myImageList.TabIndex = 0;
            // 
            // tpCurrentLog
            // 
            this.tpCurrentLog.Controls.Add(this.myCurrentPos);
            this.tpCurrentLog.Location = new System.Drawing.Point(4, 25);
            this.tpCurrentLog.Name = "tpCurrentLog";
            this.tpCurrentLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpCurrentLog.Size = new System.Drawing.Size(829, 170);
            this.tpCurrentLog.TabIndex = 1;
            this.tpCurrentLog.Text = "最新位置";
            this.tpCurrentLog.UseVisualStyleBackColor = true;
            // 
            // myCurrentPos
            // 
            this.myCurrentPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myCurrentPos.Location = new System.Drawing.Point(3, 3);
            this.myCurrentPos.Name = "myCurrentPos";
            this.myCurrentPos.Size = new System.Drawing.Size(823, 164);
            this.myCurrentPos.TabIndex = 0;
            // 
            // myAlarmLog
            // 
            this.myAlarmLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myAlarmLog.Location = new System.Drawing.Point(3, 3);
            this.myAlarmLog.Name = "myAlarmLog";
            this.myAlarmLog.Size = new System.Drawing.Size(823, 164);
            this.myAlarmLog.TabIndex = 0;
            // 
            // tpAlarmLog
            // 
            this.tpAlarmLog.Controls.Add(this.myAlarmLog);
            this.tpAlarmLog.Location = new System.Drawing.Point(4, 25);
            this.tpAlarmLog.Name = "tpAlarmLog";
            this.tpAlarmLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpAlarmLog.Size = new System.Drawing.Size(829, 170);
            this.tpAlarmLog.TabIndex = 2;
            this.tpAlarmLog.Text = "报警日志";
            this.tpAlarmLog.UseVisualStyleBackColor = true;
            // 
            // tpNotice
            // 
            this.tpNotice.Controls.Add(this.myNoticeLog);
            this.tpNotice.Location = new System.Drawing.Point(4, 25);
            this.tpNotice.Name = "tpNotice";
            this.tpNotice.Padding = new System.Windows.Forms.Padding(3);
            this.tpNotice.Size = new System.Drawing.Size(829, 170);
            this.tpNotice.TabIndex = 4;
            this.tpNotice.Text = "掉线通知";
            this.tpNotice.UseVisualStyleBackColor = true;
            // 
            // myNoticeLog
            // 
            this.myNoticeLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myNoticeLog.Location = new System.Drawing.Point(3, 3);
            this.myNoticeLog.Name = "myNoticeLog";
            this.myNoticeLog.PopWinType = 0;
            this.myNoticeLog.Size = new System.Drawing.Size(823, 164);
            this.myNoticeLog.TabIndex = 0;
            // 
            // tcLogs
            // 
            this.tcLogs.Controls.Add(this.tpNewLog);
            this.tcLogs.Controls.Add(this.tpCurrentLog);
            this.tcLogs.Controls.Add(this.tpAlarmLog);
            this.tcLogs.Controls.Add(this.tpPicLog);
            this.tcLogs.Controls.Add(this.tpNotice);
            this.tcLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcLogs.ItemSize = new System.Drawing.Size(60, 21);
            this.tcLogs.Location = new System.Drawing.Point(0, 0);
            this.tcLogs.Name = "tcLogs";
            this.tcLogs.SelectedIndex = 0;
            this.tcLogs.Size = new System.Drawing.Size(837, 192);
            this.tcLogs.TabIndex = 1;
            // 
            // tpPicLog
            // 
            this.tpPicLog.Controls.Add(this.myImageList);
            this.tpPicLog.Location = new System.Drawing.Point(4, 25);
            this.tpPicLog.Name = "tpPicLog";
            this.tpPicLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpPicLog.Size = new System.Drawing.Size(829, 170);
            this.tpPicLog.TabIndex = 3;
            this.tpPicLog.Text = "图像列表";
            this.tpPicLog.UseVisualStyleBackColor = true;
            // 
            // LogForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(837, 192);
            this.Controls.Add(this.tcLogs);
            this.Name = "LogForms";
            this.Load += new System.EventHandler(this.LogForms_Load);
            this.tpNewLog.ResumeLayout(false);
            this.tpCurrentLog.ResumeLayout(false);
            this.tpAlarmLog.ResumeLayout(false);
            this.tpNotice.ResumeLayout(false);
            this.tcLogs.ResumeLayout(false);
            this.tpPicLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tpNewLog;
        public NewLog myNewLog;
        public ImageList myImageList;
        private System.Windows.Forms.TabPage tpCurrentLog;
        public CurrentPos myCurrentPos;
        public AlarmLog myAlarmLog;
        private System.Windows.Forms.TabPage tpAlarmLog;
        private System.Windows.Forms.TabPage tpNotice;
        public NoticeLog myNoticeLog;
        public System.Windows.Forms.TabControl tcLogs;
        private System.Windows.Forms.TabPage tpPicLog;
    }
}
