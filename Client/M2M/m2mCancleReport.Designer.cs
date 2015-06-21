namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class m2mCancleReport
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
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            base.SuspendLayout();
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 154);
            base.Name = "m2mCancleReport";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.m2mCancleReport_Load);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private SimpleCmd m_SimpleCmd;
        private string m_sTitle;
    }
}