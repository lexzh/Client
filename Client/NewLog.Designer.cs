namespace Client
{
    using PublicClass;
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Timers;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class NewLog
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
            // pnlSelect
            // 
            this.pnlSelect.Size = new System.Drawing.Size(967, 26);
            // 
            // pnlTool
            // 
            this.pnlTool.Size = new System.Drawing.Size(175, 26);
            // 
            // scData
            // 
            this.scData.Size = new System.Drawing.Size(967, 206);
            // 
            // NewLog
            // 
            this.Name = "NewLog";
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
        private dBatchName myBatchName;
    }
}