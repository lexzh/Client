namespace Client
{
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class AdminDiv
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
            this.pnlAdminDiv = new Panel();
            this.txtPw = new TextBox();
            this.txtAdmin = new TextBox();
            this.lblPw = new Label();
            this.lblAdmin = new Label();
            this.lblAdminDiv = new Label();
            this.pnlBtn = new Panel();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.pnlAdminDiv.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            base.SuspendLayout();
            this.pnlAdminDiv.Controls.Add(this.txtPw);
            this.pnlAdminDiv.Controls.Add(this.txtAdmin);
            this.pnlAdminDiv.Controls.Add(this.lblPw);
            this.pnlAdminDiv.Controls.Add(this.lblAdmin);
            this.pnlAdminDiv.Controls.Add(this.lblAdminDiv);
            this.pnlAdminDiv.Dock = DockStyle.Top;
            this.pnlAdminDiv.Location = new Point(5, 5);
            this.pnlAdminDiv.Name = "pnlAdminDiv";
            this.pnlAdminDiv.Size = new Size(285, 130);
            this.pnlAdminDiv.TabIndex = 0;
            this.txtPw.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPw.Location = new Point(96, 88);
            this.txtPw.Name = "txtPw";
            this.txtPw.PasswordChar = '*';
            this.txtPw.Size = new Size(151, 21);
            this.txtPw.TabIndex = 1;
            this.txtAdmin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAdmin.Location = new Point(96, 48);
            this.txtAdmin.Name = "txtAdmin";
            this.txtAdmin.Size = new Size(151, 21);
            this.txtAdmin.TabIndex = 0;
            this.lblPw.AutoSize = true;
            this.lblPw.Location = new Point(37, 91);
            this.lblPw.Name = "lblPw";
            this.lblPw.Size = new Size(53, 12);
            this.lblPw.TabIndex = 3;
            this.lblPw.Text = "密  码：";
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new Point(37, 51);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new Size(53, 12);
            this.lblAdmin.TabIndex = 2;
            this.lblAdmin.Text = "管理员：";
            this.lblAdminDiv.AutoSize = true;
            this.lblAdminDiv.Location = new Point(12, 18);
            this.lblAdminDiv.Name = "lblAdminDiv";
            this.lblAdminDiv.Size = new Size(113, 12);
            this.lblAdminDiv.TabIndex = 1;
            this.lblAdminDiv.Text = "请输入管理员口令：";
            this.pnlBtn.Controls.Add(this.btnCancel);
            this.pnlBtn.Controls.Add(this.btnOK);
            this.pnlBtn.Dock = DockStyle.Top;
            this.pnlBtn.Location = new Point(5, 135);
            this.pnlBtn.Name = "pnlBtn";
            this.pnlBtn.Size = new Size(285, 28);
            this.pnlBtn.TabIndex = 1;
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(210, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.Location = new Point(125, 5);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(295, 168);
            base.Controls.Add(this.pnlBtn);
            base.Controls.Add(this.pnlAdminDiv);
            base.Name = "AdminDiv";
            base.Padding = new Padding(5);
            this.Text = "管理员登录";
            this.pnlAdminDiv.ResumeLayout(false);
            this.pnlAdminDiv.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            base.ResumeLayout(false);
        }
    
        private IContainer components;
        private Label lblAdmin;
        private Label lblAdminDiv;
        private Label lblPw;
        private System.Windows.Forms.Panel pnlAdminDiv;
        private TextBox txtAdmin;
        private TextBox txtPw;
    }
}