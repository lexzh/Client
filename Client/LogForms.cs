using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace Client
{
    public partial class LogForms : Client.ToolWindow
    {
        public NoticeLog myNoticeLogEx = new NoticeLog();
        private TabPage tpNoticeEx = new TabPage("上下线通知");

        public LogForms()
        {
            InitializeComponent();
            this.tpNotice.Text = Variable.sNoticeLogText;
        }

        public void setCurrentTabPage()
        {
            if (this.tcLogs.SelectedTab != this.tpNotice)
            {
                this.tcLogs.SelectedTab = this.tpNotice;
            }
        }

        public void setCurrentTabPageEx()
        {
            if (this.tcLogs.SelectedTab != this.tpNoticeEx)
            {
                this.tcLogs.SelectedTab = this.tpNoticeEx;
            }
        }

        private void LogForms_Load(object sender, EventArgs e)
        {
            this.myImageList.InitImageList();
            this.myNoticeLog.initDataGrid();
            for (int i = 0; i < this.tcLogs.TabPages.Count; i++)
            {
                if (this.tcLogs.TabPages[i].Controls[0] is LogForm)
                {
                    (this.tcLogs.TabPages[i].Controls[0] as LogForm).Init();
                }
            }
        }
    }
}
