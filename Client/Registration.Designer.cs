namespace Client
{
    //using GlsService;
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class Registration
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
            this.groupBox1 = new GroupBox();
            this.txtIp = new TextBox();
            this.lblIp = new Label();
            this.txtMachineCode = new TextBox();
            this.lblState = new Label();
            this.lblMachineCode = new Label();
            this.btnCancel = new Button();
            this.btnOK = new Button();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            this.groupBox1.Controls.Add(this.txtIp);
            this.groupBox1.Controls.Add(this.lblIp);
            this.groupBox1.Controls.Add(this.txtMachineCode);
            this.groupBox1.Controls.Add(this.lblState);
            this.groupBox1.Controls.Add(this.lblMachineCode);
            this.groupBox1.Location = new Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(334, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.txtIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIp.Location = new Point(80, 87);
            this.txtIp.Name = "txtIp";
            this.txtIp.ReadOnly = true;
            this.txtIp.Size = new Size(228, 21);
            this.txtIp.TabIndex = 1;
            this.txtIp.TabStop = false;
            this.lblIp.AutoSize = true;
            this.lblIp.Location = new Point(21, 91);
            this.lblIp.Name = "lblIp";
            this.lblIp.Size = new Size(53, 12);
            this.lblIp.TabIndex = 0;
            this.lblIp.Text = "IP地址：";
            this.txtMachineCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineCode.Location = new Point(80, 44);
            this.txtMachineCode.Name = "txtMachineCode";
            this.txtMachineCode.ReadOnly = true;
            this.txtMachineCode.Size = new Size(228, 21);
            this.txtMachineCode.TabIndex = 1;
            this.txtMachineCode.TabStop = false;
            this.lblState.AutoSize = true;
            this.lblState.ForeColor = Color.Red;
            this.lblState.Location = new Point(21, 125);
            this.lblState.Name = "lblState";
            this.lblState.Size = new Size(0, 12);
            this.lblState.TabIndex = 0;
            this.lblState.Tag = "9999";
            this.lblMachineCode.AutoSize = true;
            this.lblMachineCode.Location = new Point(21, 48);
            this.lblMachineCode.Name = "lblMachineCode";
            this.lblMachineCode.Size = new Size(53, 12);
            this.lblMachineCode.TabIndex = 0;
            this.lblMachineCode.Text = "机器码：";
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new Point(272, 172);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.btnOK.Location = new Point(195, 172);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "注册";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new EventHandler(this.btnOK_Click);
            base.AcceptButton = this.btnOK;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(369, 208);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.groupBox1);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.FixedSingle;
            base.Name = "Registration";
            base.Padding = new Padding(10);
            this.Text = "软件注册";
            base.Load += new EventHandler(this.Registration_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox groupBox1;
        private Label lblIp;
        private Label lblMachineCode;
        private Label lblState;
        private TextBox txtIp;
        private TextBox txtMachineCode;
    }
}