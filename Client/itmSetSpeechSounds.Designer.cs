namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class itmSetSpeechSounds
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
            this.grpParam = new GroupBox();
            this.lblText = new Label();
            this.txtText = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new Point(5, 249);
            base.pnlBtn.TabIndex = 2;
            this.grpParam.Controls.Add(this.lblText);
            this.grpParam.Controls.Add(this.txtText);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 128);
            this.grpParam.TabIndex = 1;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "设置语音播报";
            this.lblText.AutoSize = true;
            this.lblText.Location = new Point(52, 28);
            this.lblText.Name = "lblText";
            this.lblText.Size = new Size(65, 12);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "播报内容：";
            this.txtText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtText.Location = new Point(122, 23);
            this.txtText.MaxLength = 64;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new Size(161, 92);
            this.txtText.TabIndex = 1;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 282);
            base.Controls.Add(this.grpParam);
            base.Name = "itmSetSpeechSounds";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmSetSpeechSounds_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpParam;
        private Label lblText;
        private TextBox txtText;
    }
}