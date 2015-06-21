namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmPointToPoint
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
            this.grpMsg = new GroupBox();
            this.lblExplain1 = new Label();
            this.lblSendText = new Label();
            this.txtMsgValue = new TextBox();
            this.grpTel = new GroupBox();
            this.lblTel = new Label();
            this.txtTel = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpMsg.SuspendLayout();
            this.grpTel.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 374);
            base.pnlBtn.TabIndex = 3;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpMsg.Controls.Add(this.lblExplain1);
            this.grpMsg.Controls.Add(this.lblSendText);
            this.grpMsg.Controls.Add(this.txtMsgValue);
            this.grpMsg.Dock = DockStyle.Top;
            this.grpMsg.Location = new System.Drawing.Point(5, 178);
            this.grpMsg.Name = "grpMsg";
            this.grpMsg.Size = new Size(363, 196);
            this.grpMsg.TabIndex = 2;
            this.grpMsg.TabStop = false;
            this.grpMsg.Text = "发送内容";
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(10, 169);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(173, 12);
            this.lblExplain1.TabIndex = 1;
            this.lblExplain1.Tag = "9999";
            this.lblExplain1.Text = "*(最多可发送175个汉字和字符)";
            this.lblSendText.AutoSize = true;
            this.lblSendText.Location = new System.Drawing.Point(85, 169);
            this.lblSendText.Name = "lblSendText";
            this.lblSendText.Size = new Size(65, 12);
            this.lblSendText.TabIndex = 1;
            this.lblSendText.Tag = "";
            this.lblSendText.Text = "发送内容：";
            this.txtMsgValue.AcceptsReturn = true;
            this.txtMsgValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMsgValue.Location = new System.Drawing.Point(12, 20);
            this.txtMsgValue.MaxLength = 175;
            this.txtMsgValue.Multiline = true;
            this.txtMsgValue.Name = "txtMsgValue";
            this.txtMsgValue.ScrollBars = ScrollBars.Horizontal;
            this.txtMsgValue.Size = new Size(340, 142);
            this.txtMsgValue.TabIndex = 0;
            this.grpTel.Controls.Add(this.lblTel);
            this.grpTel.Controls.Add(this.txtTel);
            this.grpTel.Dock = DockStyle.Top;
            this.grpTel.Location = new System.Drawing.Point(5, 121);
            this.grpTel.Name = "grpTel";
            this.grpTel.Size = new Size(363, 57);
            this.grpTel.TabIndex = 1;
            this.grpTel.TabStop = false;
            this.grpTel.Text = "设置号码参数";
            this.lblTel.AutoSize = true;
            this.lblTel.Location = new System.Drawing.Point(50, 23);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new Size(65, 12);
            this.lblTel.TabIndex = 9;
            this.lblTel.Text = "电话号码：";
            this.txtTel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTel.ImeMode =  System.Windows.Forms.ImeMode.Disable;
            this.txtTel.Location = new System.Drawing.Point(122, 20);
            this.txtTel.MaxLength = 15;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new Size(161, 21);
            this.txtTel.TabIndex = 10;
            this.txtTel.Tag = "；";
            this.txtTel.KeyPress += new KeyPressEventHandler(this.txtTel_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 407);
            base.Controls.Add(this.grpMsg);
            base.Controls.Add(this.grpTel);
            base.Name = "itmPointToPoint";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.PointToPoint_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpTel, 0);
            base.Controls.SetChildIndex(this.grpMsg, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpMsg.ResumeLayout(false);
            this.grpMsg.PerformLayout();
            this.grpTel.ResumeLayout(false);
            this.grpTel.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.GroupBox grpMsg;
        private GroupBox grpTel;
        private Label lblExplain1;
        private Label lblSendText;
        private Label lblTel;
        private TextBox txtMsgValue;
        private TextBox txtTel;
    }
}