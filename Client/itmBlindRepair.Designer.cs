namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmBlindRepair
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
            this.grpBlind = new GroupBox();
            this.chkBlind = new CheckBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpBlind.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 178);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpBlind.Controls.Add(this.chkBlind);
            this.grpBlind.Dock = DockStyle.Top;
            this.grpBlind.Location = new System.Drawing.Point(5, 121);
            this.grpBlind.Name = "grpBlind";
            this.grpBlind.Size = new Size(363, 57);
            this.grpBlind.TabIndex = 1;
            this.grpBlind.TabStop = false;
            this.grpBlind.Text = "盲区补偿参数";
            this.chkBlind.AutoSize = true;
            this.chkBlind.Checked = true;
            this.chkBlind.CheckState = CheckState.Checked;
            this.chkBlind.Location = new System.Drawing.Point(122, 23);
            this.chkBlind.Name = "chkBlind";
            this.chkBlind.Size = new Size(48, 16);
            this.chkBlind.TabIndex = 0;
            this.chkBlind.Text = "盲区";
            this.chkBlind.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 211);
            base.Controls.Add(this.grpBlind);
            base.Name = "itmBlindRepair";
            this.Text = "SetBlind";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpBlind, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpBlind.ResumeLayout(false);
            this.grpBlind.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private CheckBox chkBlind;
        private System.Windows.Forms.GroupBox grpBlind;
    }
}