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

    partial class m2mGetPhoto
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
            this.pnlDate = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.grpParam = new System.Windows.Forms.GroupBox();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.lblLEDState = new System.Windows.Forms.Label();
            this.rbtnGetImg = new System.Windows.Forms.RadioButton();
            this.rbtnStop = new System.Windows.Forms.RadioButton();
            this.lblPhotoName = new System.Windows.Forms.Label();
            this.txtPhotoName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.pnlDate.SuspendLayout();
            this.grpParam.SuspendLayout();
            this.pnlImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.Size = new System.Drawing.Size(366, 116);
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 337);
            this.pnlBtn.Size = new System.Drawing.Size(366, 28);
            this.pnlBtn.TabIndex = 2;
            // 
            // pnlDate
            // 
            this.pnlDate.Controls.Add(this.lblStartDate);
            this.pnlDate.Controls.Add(this.dtpStartDate);
            this.pnlDate.Controls.Add(this.lblStartTime);
            this.pnlDate.Controls.Add(this.dtpStartTime);
            this.pnlDate.Controls.Add(this.lblEndDate);
            this.pnlDate.Controls.Add(this.dtpEndDate);
            this.pnlDate.Controls.Add(this.lblEndTime);
            this.pnlDate.Controls.Add(this.dtpEndTime);
            this.pnlDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDate.Location = new System.Drawing.Point(3, 17);
            this.pnlDate.Name = "pnlDate";
            this.pnlDate.Size = new System.Drawing.Size(360, 115);
            this.pnlDate.TabIndex = 1;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 11);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 0;
            this.lblStartDate.Text = "开始日期：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(119, 7);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(161, 21);
            this.dtpStartDate.TabIndex = 0;
            this.dtpStartDate.Tag = "；";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(47, 38);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(119, 34);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(161, 21);
            this.dtpStartTime.TabIndex = 1;
            this.dtpStartTime.TabStop = false;
            this.dtpStartTime.Tag = "；";
            this.dtpStartTime.Value = new System.DateTime(2010, 8, 5, 0, 0, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(47, 65);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(65, 12);
            this.lblEndDate.TabIndex = 0;
            this.lblEndDate.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(119, 61);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(161, 21);
            this.dtpEndDate.TabIndex = 2;
            this.dtpEndDate.Tag = "；";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(47, 92);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 12);
            this.lblEndTime.TabIndex = 0;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(119, 88);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(161, 21);
            this.dtpEndTime.TabIndex = 3;
            this.dtpEndTime.Tag = "；";
            // 
            // grpParam
            // 
            this.grpParam.AutoSize = true;
            this.grpParam.Controls.Add(this.pnlDate);
            this.grpParam.Controls.Add(this.pnlImage);
            this.grpParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpParam.Location = new System.Drawing.Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new System.Drawing.Size(366, 216);
            this.grpParam.TabIndex = 1;
            this.grpParam.TabStop = false;
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.lblLEDState);
            this.pnlImage.Controls.Add(this.rbtnGetImg);
            this.pnlImage.Controls.Add(this.rbtnStop);
            this.pnlImage.Controls.Add(this.lblPhotoName);
            this.pnlImage.Controls.Add(this.txtPhotoName);
            this.pnlImage.Controls.Add(this.label1);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlImage.Location = new System.Drawing.Point(3, 132);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(360, 81);
            this.pnlImage.TabIndex = 2;
            // 
            // lblLEDState
            // 
            this.lblLEDState.AutoSize = true;
            this.lblLEDState.Location = new System.Drawing.Point(71, 13);
            this.lblLEDState.Name = "lblLEDState";
            this.lblLEDState.Size = new System.Drawing.Size(41, 12);
            this.lblLEDState.TabIndex = 3;
            this.lblLEDState.Text = "开关：";
            // 
            // rbtnGetImg
            // 
            this.rbtnGetImg.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.rbtnGetImg.AutoSize = true;
            this.rbtnGetImg.Checked = true;
            this.rbtnGetImg.Location = new System.Drawing.Point(119, 11);
            this.rbtnGetImg.Name = "rbtnGetImg";
            this.rbtnGetImg.Size = new System.Drawing.Size(71, 16);
            this.rbtnGetImg.TabIndex = 4;
            this.rbtnGetImg.TabStop = true;
            this.rbtnGetImg.Text = "获取图片";
            this.rbtnGetImg.UseVisualStyleBackColor = true;
            this.rbtnGetImg.CheckedChanged += new System.EventHandler(this.rbtnGetImg_CheckedChanged);
            // 
            // rbtnStop
            // 
            this.rbtnStop.AutoSize = true;
            this.rbtnStop.Location = new System.Drawing.Point(209, 11);
            this.rbtnStop.Name = "rbtnStop";
            this.rbtnStop.Size = new System.Drawing.Size(71, 16);
            this.rbtnStop.TabIndex = 5;
            this.rbtnStop.TabStop = true;
            this.rbtnStop.Text = "停止上传";
            this.rbtnStop.UseVisualStyleBackColor = true;
            // 
            // lblPhotoName
            // 
            this.lblPhotoName.AutoSize = true;
            this.lblPhotoName.Location = new System.Drawing.Point(47, 37);
            this.lblPhotoName.Name = "lblPhotoName";
            this.lblPhotoName.Size = new System.Drawing.Size(65, 12);
            this.lblPhotoName.TabIndex = 2;
            this.lblPhotoName.Text = "图像名称：";
            // 
            // txtPhotoName
            // 
            this.txtPhotoName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPhotoName.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPhotoName.Location = new System.Drawing.Point(119, 33);
            this.txtPhotoName.MaxLength = 256;
            this.txtPhotoName.Name = "txtPhotoName";
            this.txtPhotoName.Size = new System.Drawing.Size(161, 21);
            this.txtPhotoName.TabIndex = 0;
            this.txtPhotoName.Tag = "；";
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(94, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 12);
            this.label1.TabIndex = 2;
            this.label1.Tag = "9999";
            this.label1.Text = "注：格式如20080712153236多个图片用逗号分隔";
            // 
            // m2mGetPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(376, 373);
            this.Controls.Add(this.grpParam);
            this.Name = "m2mGetPhoto";
            this.Text = "位置查询";
            this.Load += new System.EventHandler(this.m2mGetPhoto_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpParam, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.pnlDate.ResumeLayout(false);
            this.pnlDate.PerformLayout();
            this.grpParam.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.pnlImage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpStartTime;
        private GroupBox grpParam;
        private Label label1;
        private Label lblEndDate;
        private Label lblEndTime;
        private Label lblLEDState;
        private Label lblPhotoName;
        private Label lblStartDate;
        private Label lblStartTime;
        private System.Windows.Forms.Panel pnlDate;
        private Panel pnlImage;
        private RadioButton rbtnGetImg;
        private RadioButton rbtnStop;
        private TextBox txtPhotoName;
    }
}