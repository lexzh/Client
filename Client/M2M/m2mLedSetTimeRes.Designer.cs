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
    using WinFormsUI.Controls;

    partial class m2mLedSetTimeRes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(m2mLedSetTimeRes));
            this.grpReturnTime = new System.Windows.Forms.GroupBox();
            this.pnlLEDLight = new System.Windows.Forms.Panel();
            this.lblLight = new System.Windows.Forms.Label();
            this.cmbLight = new WinFormsUI.Controls.ComBox();
            this.pnlTime = new System.Windows.Forms.Panel();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.pnlLEDState = new System.Windows.Forms.Panel();
            this.lblLEDState = new System.Windows.Forms.Label();
            this.rbtnStart = new System.Windows.Forms.RadioButton();
            this.rbtnClose = new System.Windows.Forms.RadioButton();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpReturnTime.SuspendLayout();
            this.pnlLEDLight.SuspendLayout();
            this.pnlTime.SuspendLayout();
            this.pnlLEDState.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 306);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpReturnTime
            // 
            this.grpReturnTime.AutoSize = true;
            this.grpReturnTime.Controls.Add(this.pnlLEDLight);
            this.grpReturnTime.Controls.Add(this.pnlTime);
            this.grpReturnTime.Controls.Add(this.pnlLEDState);
            this.grpReturnTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpReturnTime.Location = new System.Drawing.Point(5, 121);
            this.grpReturnTime.Name = "grpReturnTime";
            this.grpReturnTime.Size = new System.Drawing.Size(363, 185);
            this.grpReturnTime.TabIndex = 1;
            this.grpReturnTime.TabStop = false;
            // 
            // pnlLEDLight
            // 
            this.pnlLEDLight.Controls.Add(this.lblLight);
            this.pnlLEDLight.Controls.Add(this.cmbLight);
            this.pnlLEDLight.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLEDLight.Location = new System.Drawing.Point(3, 152);
            this.pnlLEDLight.Name = "pnlLEDLight";
            this.pnlLEDLight.Size = new System.Drawing.Size(357, 30);
            this.pnlLEDLight.TabIndex = 5;
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(47, 8);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(65, 12);
            this.lblLight.TabIndex = 2;
            this.lblLight.Text = "屏幕亮度：";
            // 
            // cmbLight
            // 
            this.cmbLight.DisplayMember = "Display";
            this.cmbLight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLight.FormattingEnabled = true;
            this.cmbLight.Location = new System.Drawing.Point(119, 4);
            this.cmbLight.Name = "cmbLight";
            this.cmbLight.Size = new System.Drawing.Size(161, 20);
            this.cmbLight.TabIndex = 2;
            this.cmbLight.Tag = "；";
            this.cmbLight.ValueMember = "Value";
            // 
            // pnlTime
            // 
            this.pnlTime.Controls.Add(this.lblStartDate);
            this.pnlTime.Controls.Add(this.dtpStartDate);
            this.pnlTime.Controls.Add(this.lblStartTime);
            this.pnlTime.Controls.Add(this.dtpStartTime);
            this.pnlTime.Controls.Add(this.lblEndDate);
            this.pnlTime.Controls.Add(this.dtpEndDate);
            this.pnlTime.Controls.Add(this.lblEndTime);
            this.pnlTime.Controls.Add(this.dtpEndTime);
            this.pnlTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTime.Location = new System.Drawing.Point(3, 41);
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Size = new System.Drawing.Size(357, 111);
            this.pnlTime.TabIndex = 4;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(47, 8);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(65, 12);
            this.lblStartDate.TabIndex = 7;
            this.lblStartDate.Text = "开始日期：";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(119, 4);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(161, 21);
            this.dtpStartDate.TabIndex = 8;
            this.dtpStartDate.Tag = "；";
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(47, 33);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(65, 12);
            this.lblStartTime.TabIndex = 6;
            this.lblStartTime.Text = "开始时间：";
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(119, 29);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(161, 21);
            this.dtpStartTime.TabIndex = 9;
            this.dtpStartTime.TabStop = false;
            this.dtpStartTime.Tag = "；";
            this.dtpStartTime.Value = new System.DateTime(2010, 8, 5, 0, 0, 0, 0);
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(47, 60);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(65, 12);
            this.lblEndDate.TabIndex = 5;
            this.lblEndDate.Text = "结束日期：";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(119, 56);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(161, 21);
            this.dtpEndDate.TabIndex = 10;
            this.dtpEndDate.Tag = "；";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(47, 87);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(65, 12);
            this.lblEndTime.TabIndex = 4;
            this.lblEndTime.Text = "结束时间：";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(119, 83);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(161, 21);
            this.dtpEndTime.TabIndex = 11;
            this.dtpEndTime.Tag = "；";
            // 
            // pnlLEDState
            // 
            this.pnlLEDState.Controls.Add(this.lblLEDState);
            this.pnlLEDState.Controls.Add(this.rbtnStart);
            this.pnlLEDState.Controls.Add(this.rbtnClose);
            this.pnlLEDState.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLEDState.Location = new System.Drawing.Point(3, 17);
            this.pnlLEDState.Name = "pnlLEDState";
            this.pnlLEDState.Size = new System.Drawing.Size(357, 24);
            this.pnlLEDState.TabIndex = 3;
            // 
            // lblLEDState
            // 
            this.lblLEDState.AutoSize = true;
            this.lblLEDState.Location = new System.Drawing.Point(53, 8);
            this.lblLEDState.Name = "lblLEDState";
            this.lblLEDState.Size = new System.Drawing.Size(59, 12);
            this.lblLEDState.TabIndex = 0;
            this.lblLEDState.Text = "LED开关：";
            // 
            // rbtnStart
            // 
            this.rbtnStart.AutoSize = true;
            this.rbtnStart.Checked = true;
            this.rbtnStart.Location = new System.Drawing.Point(136, 6);
            this.rbtnStart.Name = "rbtnStart";
            this.rbtnStart.Size = new System.Drawing.Size(47, 16);
            this.rbtnStart.TabIndex = 1;
            this.rbtnStart.TabStop = true;
            this.rbtnStart.Text = "开启";
            this.rbtnStart.UseVisualStyleBackColor = true;
            // 
            // rbtnClose
            // 
            this.rbtnClose.AutoSize = true;
            this.rbtnClose.Location = new System.Drawing.Point(218, 6);
            this.rbtnClose.Name = "rbtnClose";
            this.rbtnClose.Size = new System.Drawing.Size(47, 16);
            this.rbtnClose.TabIndex = 2;
            this.rbtnClose.TabStop = true;
            this.rbtnClose.Text = "关闭";
            this.rbtnClose.UseVisualStyleBackColor = true;
            // 
            // m2mLedSetTimeRes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 339);
            this.Controls.Add(this.grpReturnTime);
            this.Name = "m2mLedSetTimeRes";
            this.Text = "m2mLedSetReturnTime";
            this.Load += new System.EventHandler(this.m2mLedSetTimeRes_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpReturnTime, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpReturnTime.ResumeLayout(false);
            this.pnlLEDLight.ResumeLayout(false);
            this.pnlLEDLight.PerformLayout();
            this.pnlTime.ResumeLayout(false);
            this.pnlTime.PerformLayout();
            this.pnlLEDState.ResumeLayout(false);
            this.pnlLEDState.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private ComBox cmbLight;
        private DateTimePicker dtpEndDate;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpStartTime;
        private GroupBox grpReturnTime;
        private Label lblEndDate;
        private Label lblEndTime;
        private Label lblLEDState;
        private Label lblLight;
        private Label lblStartDate;
        private Label lblStartTime;
        private Panel pnlLEDLight;
        private Panel pnlLEDState;
        private Panel pnlTime;
        private RadioButton rbtnClose;
        private RadioButton rbtnStart;
    }
}