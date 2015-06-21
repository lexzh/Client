namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBMultimediaDataRetrieval
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
            this.grpWatchProperty = new GroupBox();
            this.dtpEndTime = new DateTimePicker();
            this.lblEndTime = new Label();
            this.dtpStartTime = new DateTimePicker();
            this.lblStartTime = new Label();
            this.cmbEventCode = new ComboBox();
            this.lblEventCode = new Label();
            this.lblExplain1 = new Label();
            this.numChannelNumber = new NumericUpDown();
            this.lblChannelNumber = new Label();
            this.cmbMultimediaType = new ComboBox();
            this.lblMultimediaType = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numChannelNumber.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 256);
            this.grpWatchProperty.Controls.Add(this.dtpEndTime);
            this.grpWatchProperty.Controls.Add(this.lblEndTime);
            this.grpWatchProperty.Controls.Add(this.dtpStartTime);
            this.grpWatchProperty.Controls.Add(this.lblStartTime);
            this.grpWatchProperty.Controls.Add(this.cmbEventCode);
            this.grpWatchProperty.Controls.Add(this.lblEventCode);
            this.grpWatchProperty.Controls.Add(this.lblExplain1);
            this.grpWatchProperty.Controls.Add(this.numChannelNumber);
            this.grpWatchProperty.Controls.Add(this.lblChannelNumber);
            this.grpWatchProperty.Controls.Add(this.cmbMultimediaType);
            this.grpWatchProperty.Controls.Add(this.lblMultimediaType);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 135);
            this.grpWatchProperty.TabIndex = 12;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(122, 108);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new Size(161, 21);
            this.dtpEndTime.TabIndex = 47;
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(50, 115);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 46;
            this.lblEndTime.Text = "结束时间：";
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(122, 84);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new Size(161, 21);
            this.dtpStartTime.TabIndex = 45;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(50, 91);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 44;
            this.lblStartTime.Text = "开始时间：";
            this.cmbEventCode.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEventCode.FormattingEnabled = true;
            this.cmbEventCode.Items.AddRange(new object[] { "平台下发指令", "定时动作", "抢劫报警触发", "碰撞侧翻报警触发" });
            this.cmbEventCode.Location = new System.Drawing.Point(122, 61);
            this.cmbEventCode.Name = "cmbEventCode";
            this.cmbEventCode.Size = new Size(161, 20);
            this.cmbEventCode.TabIndex = 43;
            this.lblEventCode.AutoSize = true;
            this.lblEventCode.Location = new System.Drawing.Point(39, 67);
            this.lblEventCode.Name = "lblEventCode";
            this.lblEventCode.Size = new Size(77, 12);
            this.lblEventCode.TabIndex = 42;
            this.lblEventCode.Text = "事件项编码：";
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(224, 43);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(107, 12);
            this.lblExplain1.TabIndex = 41;
            this.lblExplain1.Text = "0表示检索所有通道";
            this.numChannelNumber.Location = new System.Drawing.Point(123, 37);
            int[] bits = new int[4];
            bits[0] = 255;
            this.numChannelNumber.Maximum = new decimal(bits);
            this.numChannelNumber.Name = "numChannelNumber";
            this.numChannelNumber.Size = new Size(95, 21);
            this.numChannelNumber.TabIndex = 40;
            this.lblChannelNumber.AutoSize = true;
            this.lblChannelNumber.Location = new System.Drawing.Point(15, 43);
            this.lblChannelNumber.Name = "lblChannelNumber";
            this.lblChannelNumber.Size = new Size(101, 12);
            this.lblChannelNumber.TabIndex = 39;
            this.lblChannelNumber.Text = "媒体类型通道号：";
            this.cmbMultimediaType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMultimediaType.FormattingEnabled = true;
            this.cmbMultimediaType.Items.AddRange(new object[] { "图像", "音频", "视频" });
            this.cmbMultimediaType.Location = new System.Drawing.Point(122, 14);
            this.cmbMultimediaType.Name = "cmbMultimediaType";
            this.cmbMultimediaType.Size = new Size(161, 20);
            this.cmbMultimediaType.TabIndex = 38;
            this.lblMultimediaType.AutoSize = true;
            this.lblMultimediaType.Location = new System.Drawing.Point(39, 19);
            this.lblMultimediaType.Name = "lblMultimediaType";
            this.lblMultimediaType.Size = new Size(77, 12);
            this.lblMultimediaType.TabIndex = 37;
            this.lblMultimediaType.Text = "多媒体类型：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 289);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBMultimediaDataRetrieval";
            this.Text = "JTBMultimediaDataRetrieval";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numChannelNumber.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private ComboBox cmbEventCode;
        private ComboBox cmbMultimediaType;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblChannelNumber;
        private Label lblEndTime;
        private Label lblEventCode;
        private Label lblExplain1;
        private Label lblMultimediaType;
        private Label lblStartTime;
        private NumericUpDown numChannelNumber;
    }
}