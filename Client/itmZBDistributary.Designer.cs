namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmZBDistributary
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
            new ComponentResourceManager(typeof(itmZBDistributary));
            this.grpParam = new GroupBox();
            this.lblMsgType = new Label();
            this.cmbMsgType = new ComBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblLonLat = new Label();
            this.txtLonLat = new TextBox();
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblText = new Label();
            this.txtText = new TextBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new Point(5, 343);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpParam.Controls.Add(this.lblMsgType);
            this.grpParam.Controls.Add(this.cmbMsgType);
            this.grpParam.Controls.Add(this.lblPhone);
            this.grpParam.Controls.Add(this.txtPhone);
            this.grpParam.Controls.Add(this.lblLonLat);
            this.grpParam.Controls.Add(this.txtLonLat);
            this.grpParam.Controls.Add(this.lblTitle);
            this.grpParam.Controls.Add(this.txtTitle);
            this.grpParam.Controls.Add(this.lblText);
            this.grpParam.Controls.Add(this.txtText);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 222);
            this.grpParam.TabIndex = 1;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数";
            this.lblMsgType.AutoSize = true;
            this.lblMsgType.Location = new Point(50, 19);
            this.lblMsgType.Name = "lblMsgType";
            this.lblMsgType.Size = new Size(65, 12);
            this.lblMsgType.TabIndex = 0;
            this.lblMsgType.Text = "栏目类型：";
            this.cmbMsgType.DisplayMember = "Display";
            this.cmbMsgType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMsgType.FlatStyle = FlatStyle.Flat;
            this.cmbMsgType.FormattingEnabled = true;
            this.cmbMsgType.Location = new Point(122, 16);
            this.cmbMsgType.Name = "cmbMsgType";
            this.cmbMsgType.Size = new Size(161, 20);
            this.cmbMsgType.TabIndex = 0;
            this.cmbMsgType.Tag = "；";
            this.cmbMsgType.ValueMember = "Value";
            this.cmbMsgType.SelectedIndexChanged += new EventHandler(this.cmbSendType_SelectedIndexChanged);
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new Point(50, 49);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(65, 12);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "商家电话：";
            this.txtPhone.Location = new Point(122, 46);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(161, 21);
            this.txtPhone.TabIndex = 1;
            this.txtPhone.KeyPress += new KeyPressEventHandler(this.txtPhone_KeyPress);
            this.lblLonLat.AutoSize = true;
            this.lblLonLat.Location = new Point(62, 79);
            this.lblLonLat.Name = "lblLonLat";
            this.lblLonLat.Size = new Size(53, 12);
            this.lblLonLat.TabIndex = 0;
            this.lblLonLat.Text = "经纬度：";
            this.txtLonLat.Location = new Point(122, 76);
            this.txtLonLat.Name = "txtLonLat";
            this.txtLonLat.ReadOnly = true;
            this.txtLonLat.Size = new Size(161, 21);
            this.txtLonLat.TabIndex = 2;
            this.txtLonLat.Tag = "9999";
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new Point(74, 106);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(41, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "标题：";
            this.txtTitle.Location = new Point(122, 103);
            this.txtTitle.MaxLength = 60;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(161, 21);
            this.txtTitle.TabIndex = 3;
            this.lblText.AutoSize = true;
            this.lblText.Location = new Point(74, 133);
            this.lblText.Name = "lblText";
            this.lblText.Size = new Size(41, 12);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "正文：";
            this.txtText.Location = new Point(122, 130);
            this.txtText.MaxLength = 140;
            this.txtText.Multiline = true;
            this.txtText.Name = "txtText";
            this.txtText.Size = new Size(161, 81);
            this.txtText.TabIndex = 4;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 376);
            base.Controls.Add(this.grpParam);
            base.Name = "itmZBDistributary";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmZBDistributary_Load);
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
        private ComBox cmbMsgType;
        private GroupBox grpParam;
        private Label lblLonLat;
        private Label lblMsgType;
        private Label lblPhone;
        private Label lblText;
        private Label lblTitle;
        private TextBox txtLonLat;
        private TextBox txtPhone;
        private TextBox txtText;
        private TextBox txtTitle;
    }
}