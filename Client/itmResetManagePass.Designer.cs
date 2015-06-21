namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmResetManagePass
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
            this.grpPassWord = new GroupBox();
            this.txtValidate = new TextBox();
            this.txtPw = new TextBox();
            this.lblValidate = new Label();
            this.lblPw = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpPassWord.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 202);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpPassWord.Controls.Add(this.txtValidate);
            this.grpPassWord.Controls.Add(this.txtPw);
            this.grpPassWord.Controls.Add(this.lblValidate);
            this.grpPassWord.Controls.Add(this.lblPw);
            this.grpPassWord.Dock = DockStyle.Top;
            this.grpPassWord.Location = new System.Drawing.Point(5, 121);
            this.grpPassWord.Name = "grpPassWord";
            this.grpPassWord.Size = new Size(363, 81);
            this.grpPassWord.TabIndex = 1;
            this.grpPassWord.TabStop = false;
            this.grpPassWord.Text = "设置车台超级密码";
            this.txtValidate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValidate.ImeMode =  System.Windows.Forms.ImeMode.Disable;
            this.txtValidate.Location = new System.Drawing.Point(122, 48);
            this.txtValidate.MaxLength = 8;
            this.txtValidate.Name = "txtValidate";
            this.txtValidate.PasswordChar = '*';
            this.txtValidate.Size = new Size(161, 21);
            this.txtValidate.TabIndex = 1;
            this.txtValidate.Tag = "9999";
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPw.ImeMode =  System.Windows.Forms.ImeMode.Disable;
            this.txtPw.Location = new System.Drawing.Point(122, 20);
            this.txtPw.MaxLength = 8;
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new Size(161, 21);
            this.txtPw.TabIndex = 0;
            this.txtPw.Tag = "9999";
            this.txtPw.KeyPress += new KeyPressEventHandler(this.txtPw_KeyPress);
            this.lblValidate.AutoSize = true;
            this.lblValidate.Location = new System.Drawing.Point(50, 51);
            this.lblValidate.Name = "lblValidate";
            this.lblValidate.Size = new Size(65, 12);
            this.lblValidate.TabIndex = 0;
            this.lblValidate.Tag = "9999";
            this.lblValidate.Text = "确认密码：";
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new System.Drawing.Point(74, 23);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new Size(41, 12);
            this.lblPw.TabIndex = 0;
            this.lblPw.Tag = "9999";
            this.lblPw.Text = "密码：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 235);
            base.Controls.Add(this.grpPassWord);
            base.Name = "itmResetManagePass";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpPassWord, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpPassWord.ResumeLayout(false);
            this.grpPassWord.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox grpPassWord;
        private Label lblPw;
        private Label lblValidate;
        private TextBox txtPw;
        private TextBox txtValidate;
    }
}