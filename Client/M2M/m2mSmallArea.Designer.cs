﻿namespace Client.M2M
{
    using Client;
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class m2mSmallArea
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
            new ComponentResourceManager(typeof(m2mSmallArea));
            this.lblLon = new Label();
            this.gbSmall = new GroupBox();
            this.txtRightLat = new TextBox();
            this.txtRightLon = new TextBox();
            this.label2 = new Label();
            this.label3 = new Label();
            this.txtLeftLat = new TextBox();
            this.txtLeftLon = new TextBox();
            this.lblLat = new Label();
            this.txtPhone = new TextBox();
            this.lblTelNumber = new Label();
            this.txtContent = new TextBox();
            this.lblContent = new Label();
            this.btnOk = new Button();
            this.btnCancel = new Button();
            this.gbCar = new GroupBox();
            this.lvCar = new ListView();
            this.btnSendOrder = new Button();
            this.lblResWay = new Label();
            this.cmbResWay = new ComBox();
            this.txtOrderId = new TextBox();
            this.label4 = new Label();
            this.pnlSending = new Panel();
            this.pbPicWait = new PictureBox();
            this.lblSending = new Label();
            this.gbSmall.SuspendLayout();
            this.gbCar.SuspendLayout();
            this.pnlSending.SuspendLayout();
            ((ISupportInitialize) this.pbPicWait).BeginInit();
            base.SuspendLayout();
            this.lblLon.AutoSize = true;
            this.lblLon.Location = new System.Drawing.Point(8, 20);
            this.lblLon.Name = "lblLon";
            this.lblLon.Size = new Size(65, 12);
            this.lblLon.TabIndex = 0;
            this.lblLon.Text = "起始经度：";
            this.gbSmall.Controls.Add(this.txtRightLat);
            this.gbSmall.Controls.Add(this.txtRightLon);
            this.gbSmall.Controls.Add(this.label2);
            this.gbSmall.Controls.Add(this.label3);
            this.gbSmall.Controls.Add(this.txtLeftLat);
            this.gbSmall.Controls.Add(this.txtLeftLon);
            this.gbSmall.Controls.Add(this.lblLat);
            this.gbSmall.Controls.Add(this.lblLon);
            this.gbSmall.Location = new System.Drawing.Point(8, 8);
            this.gbSmall.Name = "gbSmall";
            this.gbSmall.Size = new Size(250, 122);
            this.gbSmall.TabIndex = 0;
            this.gbSmall.TabStop = false;
            this.gbSmall.Text = "电召范围";
            this.txtRightLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightLat.Location = new System.Drawing.Point(79, 94);
            this.txtRightLat.MaxLength = 50;
            this.txtRightLat.Name = "txtRightLat";
            this.txtRightLat.ReadOnly = true;
            this.txtRightLat.Size = new Size(156, 21);
            this.txtRightLat.TabIndex = 6;
            this.txtRightLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRightLon.Location = new System.Drawing.Point(79, 70);
            this.txtRightLon.MaxLength = 50;
            this.txtRightLon.Name = "txtRightLon";
            this.txtRightLon.ReadOnly = true;
            this.txtRightLon.Size = new Size(156, 21);
            this.txtRightLon.TabIndex = 5;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 97);
            this.label2.Name = "label2";
            this.label2.Size = new Size(65, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "结束纬度：";
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 73);
            this.label3.Name = "label3";
            this.label3.Size = new Size(65, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "结束经度：";
            this.txtLeftLat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeftLat.Location = new System.Drawing.Point(79, 44);
            this.txtLeftLat.MaxLength = 50;
            this.txtLeftLat.Name = "txtLeftLat";
            this.txtLeftLat.ReadOnly = true;
            this.txtLeftLat.Size = new Size(156, 21);
            this.txtLeftLat.TabIndex = 2;
            this.txtLeftLon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLeftLon.Location = new System.Drawing.Point(79, 20);
            this.txtLeftLon.MaxLength = 50;
            this.txtLeftLon.Name = "txtLeftLon";
            this.txtLeftLon.ReadOnly = true;
            this.txtLeftLon.Size = new Size(156, 21);
            this.txtLeftLon.TabIndex = 1;
            this.lblLat.AutoSize = true;
            this.lblLat.Location = new System.Drawing.Point(8, 47);
            this.lblLat.Name = "lblLat";
            this.lblLat.Size = new Size(65, 12);
            this.lblLat.TabIndex = 1;
            this.lblLat.Text = "起始纬度：";
            this.txtPhone.BackColor = Color.White;
            this.txtPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhone.Location = new System.Drawing.Point(86, 185);
            this.txtPhone.MaxLength = 20;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(156, 21);
            this.txtPhone.TabIndex = 2;
            this.lblTelNumber.AutoSize = true;
            this.lblTelNumber.Location = new System.Drawing.Point(16, 188);
            this.lblTelNumber.Name = "lblTelNumber";
            this.lblTelNumber.Size = new Size(65, 12);
            this.lblTelNumber.TabIndex = 7;
            this.lblTelNumber.Text = "抢答电话：";
            this.txtContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContent.Location = new System.Drawing.Point(86, 210);
            this.txtContent.MaxLength = 175;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = ScrollBars.Vertical;
            this.txtContent.Size = new Size(156, 100);
            this.txtContent.TabIndex = 1;
            this.txtContent.Text = "请在此输入电召内容";
            this.txtContent.MouseDown += new MouseEventHandler(this.txtContent_MouseDown);
            this.lblContent.AutoSize = true;
            this.lblContent.Location = new System.Drawing.Point(16, 213);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new Size(65, 12);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "抢答信息：";
            this.btnOk.Location = new System.Drawing.Point(322, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "确定抢答";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new EventHandler(this.btnOk_Click);
            this.btnCancel.DialogResult =  System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(408, 324);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);
            this.gbCar.Controls.Add(this.lvCar);
            this.gbCar.Location = new System.Drawing.Point(260, 8);
            this.gbCar.Name = "gbCar";
            this.gbCar.Size = new Size(223, 310);
            this.gbCar.TabIndex = 1;
            this.gbCar.TabStop = false;
            this.gbCar.Text = "抢答车辆信息";
            this.lvCar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvCar.Dock = DockStyle.Fill;
            this.lvCar.Location = new System.Drawing.Point(3, 17);
            this.lvCar.Name = "lvCar";
            this.lvCar.Size = new Size(217, 290);
            this.lvCar.TabIndex = 1;
            this.lvCar.UseCompatibleStateImageBehavior = false;
            this.lvCar.View = View.List;
            this.btnSendOrder.Location = new System.Drawing.Point(236, 324);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new Size(75, 23);
            this.btnSendOrder.TabIndex = 2;
            this.btnSendOrder.Text = "发送抢答";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new EventHandler(this.btnSend_Click);
            this.lblResWay.AutoSize = true;
            this.lblResWay.Location = new System.Drawing.Point(16, 163);
            this.lblResWay.Name = "lblResWay";
            this.lblResWay.Size = new Size(65, 12);
            this.lblResWay.TabIndex = 9;
            this.lblResWay.Text = "抢答方式：";
            this.cmbResWay.DisplayMember = "Display";
            this.cmbResWay.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbResWay.FlatStyle = FlatStyle.Flat;
            this.cmbResWay.FormattingEnabled = true;
            this.cmbResWay.Location = new System.Drawing.Point(86, 160);
            this.cmbResWay.Name = "cmbResWay";
            this.cmbResWay.Size = new Size(156, 20);
            this.cmbResWay.TabIndex = 10;
            this.cmbResWay.ValueMember = "Value";
            this.txtOrderId.BackColor = Color.White;
            this.txtOrderId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderId.Enabled = false;
            this.txtOrderId.Location = new System.Drawing.Point(86, 135);
            this.txtOrderId.MaxLength = 20;
            this.txtOrderId.Name = "txtOrderId";
            this.txtOrderId.ReadOnly = true;
            this.txtOrderId.Size = new Size(156, 21);
            this.txtOrderId.TabIndex = 11;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 138);
            this.label4.Name = "label4";
            this.label4.Size = new Size(65, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "定 单 号：";
            this.pnlSending.Controls.Add(this.pbPicWait);
            this.pnlSending.Controls.Add(this.lblSending);
            this.pnlSending.Location = new System.Drawing.Point(8, 316);
            this.pnlSending.Name = "pnlSending";
            this.pnlSending.Size = new Size(210, 30);
            this.pnlSending.TabIndex = 13;
            this.pbPicWait.BackColor = Color.Transparent;
            this.pbPicWait.Image = Resources.loading;
            this.pbPicWait.InitialImage = null;
            this.pbPicWait.Location = new System.Drawing.Point(10, 6);
            this.pbPicWait.Name = "pbPicWait";
            this.pbPicWait.Size = new Size(16, 16);
            this.pbPicWait.TabIndex = 11;
            this.pbPicWait.TabStop = false;
            this.pbPicWait.Tag = "9999";
            this.pbPicWait.Visible = false;
            this.lblSending.AutoSize = true;
            this.lblSending.Location = new System.Drawing.Point(32, 8);
            this.lblSending.Name = "lblSending";
            this.lblSending.Size = new Size(149, 12);
            this.lblSending.TabIndex = 0;
            this.lblSending.Tag = "9999";
            this.lblSending.Text = "正在发送抢答，请稍候……";
            base.AcceptButton = this.btnSendOrder;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.CancelButton = this.btnCancel;
            base.ClientSize = new Size(495, 355);
            base.Controls.Add(this.pnlSending);
            base.Controls.Add(this.label4);
            base.Controls.Add(this.txtOrderId);
            base.Controls.Add(this.cmbResWay);
            base.Controls.Add(this.lblResWay);
            base.Controls.Add(this.lblTelNumber);
            base.Controls.Add(this.txtPhone);
            base.Controls.Add(this.gbCar);
            base.Controls.Add(this.lblContent);
            base.Controls.Add(this.txtContent);
            base.Controls.Add(this.btnSendOrder);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.btnOk);
            base.Controls.Add(this.gbSmall);
            base.Name = "m2mSmallArea";
            base.Padding = new Padding(5);
            this.Text = "小范围电召";
            base.Load += new EventHandler(this.itmSmallArea_Load);
            base.FormClosing += new FormClosingEventHandler(this.m2mSmallArea_FormClosing);
            this.gbSmall.ResumeLayout(false);
            this.gbSmall.PerformLayout();
            this.gbCar.ResumeLayout(false);
            this.pnlSending.ResumeLayout(false);
            this.pnlSending.PerformLayout();
            ((ISupportInitialize) this.pbPicWait).EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private bool bDenyRes;
        private Button btnCancel;
        private Button btnOk;
        private Button btnSendOrder;
        private ComBox cmbResWay;
        private GroupBox gbCar;
        private GroupBox gbSmall;
        private int i;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label lblContent;
        private Label lblLat;
        private Label lblLon;
        private Label lblResWay;
        private Label lblSending;
        private Label lblTelNumber;
        private ListView lvCar;
        private PictureBox pbPicWait;
        private Panel pnlSending;
        private TextBox txtContent;
        private TextBox txtLeftLat;
        private TextBox txtLeftLon;
        private TextBox txtOrderId;
        private TextBox txtPhone;
        private TextBox txtRightLat;
        private TextBox txtRightLon;
    }
}