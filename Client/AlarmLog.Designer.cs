namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;

    partial class AlarmLog
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
            ((System.ComponentModel.ISupportInitialize)(this.m_dtLogData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dvLogData)).BeginInit();
            this.pnlCarNum.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlLogCnt.SuspendLayout();
            this.pnlLogType.SuspendLayout();
            this.pnlSelect.SuspendLayout();
            this.pnlSendResult.SuspendLayout();
            this.pnlWorkType.SuspendLayout();
            this.scData.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLog
            // 
            this.pnlLog.Size = new System.Drawing.Size(967, 232);
            // 
            // pnlLogCnt
            // 
            this.pnlLogCnt.Size = new System.Drawing.Size(215, 26);
            // 
            // pnlSelect
            // 
            this.pnlSelect.Size = new System.Drawing.Size(967, 26);
            // 
            // pnlSendResult
            // 
            this.pnlSendResult.Visible = false;
            // 
            // pnlTool
            // 
            this.pnlTool.Location = new System.Drawing.Point(849, 0);
            this.pnlTool.Size = new System.Drawing.Size(118, 26);
            // 
            // scData
            // 
            this.scData.Size = new System.Drawing.Size(967, 206);
            // 
            // txtNewLogCnt2
            // 
            this.txtNewLogCnt2.Visible = true;
            // 
            // AlarmLog
            // 
            this.Name = "AlarmLog";
            this.Size = new System.Drawing.Size(967, 232);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtLogData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dvLogData)).EndInit();
            this.pnlCarNum.ResumeLayout(false);
            this.pnlCarNum.PerformLayout();
            this.pnlLog.ResumeLayout(false);
            this.pnlLogCnt.ResumeLayout(false);
            this.pnlLogCnt.PerformLayout();
            this.pnlLogType.ResumeLayout(false);
            this.pnlLogType.PerformLayout();
            this.pnlSelect.ResumeLayout(false);
            this.pnlSendResult.ResumeLayout(false);
            this.pnlSendResult.PerformLayout();
            this.pnlWorkType.ResumeLayout(false);
            this.pnlWorkType.PerformLayout();
            this.scData.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    
        private IContainer components;
    }
}