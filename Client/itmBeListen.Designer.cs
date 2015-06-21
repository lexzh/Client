namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmBeListen
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
            this.grpTel = new GroupBox();
            this.lblTel = new Label();
            this.txtTel = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpTel.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 178);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpTel.Controls.Add(this.lblTel);
            this.grpTel.Controls.Add(this.txtTel);
            this.grpTel.Dock = DockStyle.Top;
            this.grpTel.Location = new System.Drawing.Point(5, 121);
            this.grpTel.Name = "grpTel";
            this.grpTel.Size = new Size(363, 57);
            this.grpTel.TabIndex = 1;
            this.grpTel.TabStop = false;
            this.grpTel.Text = "被动监听号码";
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(50, 23);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new Size(65, 12);
            this.lblTel.TabIndex = 9;
            this.lblTel.Text = "电话号码：";
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtTel.Location = new System.Drawing.Point(122, 20);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new Size(161, 21);
            this.txtTel.TabIndex = 0;
            this.txtTel.Tag = "；";
            this.txtTel.KeyPress += new KeyPressEventHandler(this.txtTel_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 211);
            base.Controls.Add(this.grpTel);
            base.Name = "itmBeListen";
            this.Text = "itmBeListen";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpTel, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpTel.ResumeLayout(false);
            this.grpTel.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox grpTel;
        private Label lblTel;
        private TextBox txtTel;
    }
}