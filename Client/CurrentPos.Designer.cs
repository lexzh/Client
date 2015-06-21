namespace Client
{
    using PublicClass;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    partial class CurrentPos
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
            base.m_dtLogData.BeginInit();
            base.m_dvLogData.BeginInit();
            base.pnlLog.SuspendLayout();
            base.pnlSelect.SuspendLayout();
            base.pnlCarNum.SuspendLayout();
            base.pnlWorkType.SuspendLayout();
            base.pnlSendResult.SuspendLayout();
            base.pnlLogType.SuspendLayout();
            base.scData.SuspendLayout();
            base.pnlLogCnt.SuspendLayout();
            base.SuspendLayout();
            base.pnlLog.Size = new Size(967, 232);
            base.pnlSelect.Size = new Size(967, 26);
            base.pnlSendResult.Visible = false;
            base.pnlTool.Location = new Point(849, 0);
            base.pnlTool.Size = new Size(118, 26);
            base.scData.Size = new Size(967, 206);
            base.pnlLogCnt.Size = new Size(215, 26);
            base.txtNewLogCnt2.Visible = true;
            base.Size = new Size(967, 232);
            this.Text = "最新位置";
            base.m_dtLogData.EndInit();
            base.m_dvLogData.EndInit();
            base.pnlLog.ResumeLayout(false);
            base.pnlSelect.ResumeLayout(false);
            base.pnlCarNum.ResumeLayout(false);
            base.pnlCarNum.PerformLayout();
            base.pnlWorkType.ResumeLayout(false);
            base.pnlWorkType.PerformLayout();
            base.pnlSendResult.ResumeLayout(false);
            base.pnlSendResult.PerformLayout();
            base.pnlLogType.ResumeLayout(false);
            base.pnlLogType.PerformLayout();
            base.scData.ResumeLayout(false);
            base.pnlLogCnt.ResumeLayout(false);
            base.pnlLogCnt.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
    }
}