namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmCarOverTimeDrive
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
            this.grpSetOverTimeDrive = new System.Windows.Forms.GroupBox();
            this.pnlSetOverTimeDrive = new System.Windows.Forms.Panel();
            this.lblAlarmTime = new System.Windows.Forms.Label();
            this.numAlarmTime = new System.Windows.Forms.NumericUpDown();
            this.lblMinute2 = new System.Windows.Forms.Label();
            this.lblAlarmInterval = new System.Windows.Forms.Label();
            this.numAlarmInterval = new System.Windows.Forms.NumericUpDown();
            this.lblMinute3 = new System.Windows.Forms.Label();
            this.lblRestTime = new System.Windows.Forms.Label();
            this.numRestTime = new System.Windows.Forms.NumericUpDown();
            this.lblMinute4 = new System.Windows.Forms.Label();
            this.pnlDriveTime = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDriveTime = new System.Windows.Forms.Label();
            this.numDriveTime = new System.Windows.Forms.NumericUpDown();
            this.lblMinute1 = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpSetOverTimeDrive.SuspendLayout();
            this.pnlSetOverTimeDrive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestTime)).BeginInit();
            this.pnlDriveTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDriveTime)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.TabIndex = 0;
            // 
            // grpCar
            // 
            this.grpCar.TabIndex = 0;
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 273);
            this.pnlBtn.TabIndex = 2;
            // 
            // grpSetOverTimeDrive
            // 
            this.grpSetOverTimeDrive.AutoSize = true;
            this.grpSetOverTimeDrive.Controls.Add(this.pnlSetOverTimeDrive);
            this.grpSetOverTimeDrive.Controls.Add(this.pnlDriveTime);
            this.grpSetOverTimeDrive.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetOverTimeDrive.Location = new System.Drawing.Point(5, 121);
            this.grpSetOverTimeDrive.Margin = new System.Windows.Forms.Padding(0);
            this.grpSetOverTimeDrive.Name = "grpSetOverTimeDrive";
            this.grpSetOverTimeDrive.Size = new System.Drawing.Size(363, 152);
            this.grpSetOverTimeDrive.TabIndex = 1;
            this.grpSetOverTimeDrive.TabStop = false;
            this.grpSetOverTimeDrive.Text = "超时驾驶参数";
            // 
            // pnlSetOverTimeDrive
            // 
            this.pnlSetOverTimeDrive.Controls.Add(this.lblAlarmTime);
            this.pnlSetOverTimeDrive.Controls.Add(this.numAlarmTime);
            this.pnlSetOverTimeDrive.Controls.Add(this.lblMinute2);
            this.pnlSetOverTimeDrive.Controls.Add(this.lblAlarmInterval);
            this.pnlSetOverTimeDrive.Controls.Add(this.numAlarmInterval);
            this.pnlSetOverTimeDrive.Controls.Add(this.lblMinute3);
            this.pnlSetOverTimeDrive.Controls.Add(this.lblRestTime);
            this.pnlSetOverTimeDrive.Controls.Add(this.numRestTime);
            this.pnlSetOverTimeDrive.Controls.Add(this.lblMinute4);
            this.pnlSetOverTimeDrive.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSetOverTimeDrive.Location = new System.Drawing.Point(3, 65);
            this.pnlSetOverTimeDrive.Name = "pnlSetOverTimeDrive";
            this.pnlSetOverTimeDrive.Size = new System.Drawing.Size(357, 84);
            this.pnlSetOverTimeDrive.TabIndex = 1;
            // 
            // lblAlarmTime
            // 
            this.lblAlarmTime.AutoSize = true;
            this.lblAlarmTime.Location = new System.Drawing.Point(23, 3);
            this.lblAlarmTime.Name = "lblAlarmTime";
            this.lblAlarmTime.Size = new System.Drawing.Size(89, 12);
            this.lblAlarmTime.TabIndex = 26;
            this.lblAlarmTime.Text = "预警时间时长：";
            // 
            // numAlarmTime
            // 
            this.numAlarmTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAlarmTime.Location = new System.Drawing.Point(119, 1);
            this.numAlarmTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAlarmTime.Name = "numAlarmTime";
            this.numAlarmTime.Size = new System.Drawing.Size(161, 21);
            this.numAlarmTime.TabIndex = 0;
            // 
            // lblMinute2
            // 
            this.lblMinute2.AutoSize = true;
            this.lblMinute2.Location = new System.Drawing.Point(286, 3);
            this.lblMinute2.Name = "lblMinute2";
            this.lblMinute2.Size = new System.Drawing.Size(29, 12);
            this.lblMinute2.TabIndex = 32;
            this.lblMinute2.Tag = "；";
            this.lblMinute2.Text = "分钟";
            // 
            // lblAlarmInterval
            // 
            this.lblAlarmInterval.AutoSize = true;
            this.lblAlarmInterval.Location = new System.Drawing.Point(23, 30);
            this.lblAlarmInterval.Name = "lblAlarmInterval";
            this.lblAlarmInterval.Size = new System.Drawing.Size(89, 12);
            this.lblAlarmInterval.TabIndex = 25;
            this.lblAlarmInterval.Text = "预警间隔时长：";
            // 
            // numAlarmInterval
            // 
            this.numAlarmInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAlarmInterval.Location = new System.Drawing.Point(119, 28);
            this.numAlarmInterval.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numAlarmInterval.Name = "numAlarmInterval";
            this.numAlarmInterval.Size = new System.Drawing.Size(161, 21);
            this.numAlarmInterval.TabIndex = 1;
            // 
            // lblMinute3
            // 
            this.lblMinute3.AutoSize = true;
            this.lblMinute3.Location = new System.Drawing.Point(286, 30);
            this.lblMinute3.Name = "lblMinute3";
            this.lblMinute3.Size = new System.Drawing.Size(29, 12);
            this.lblMinute3.TabIndex = 31;
            this.lblMinute3.Tag = "；";
            this.lblMinute3.Text = "分钟";
            // 
            // lblRestTime
            // 
            this.lblRestTime.AutoSize = true;
            this.lblRestTime.Location = new System.Drawing.Point(23, 58);
            this.lblRestTime.Name = "lblRestTime";
            this.lblRestTime.Size = new System.Drawing.Size(89, 12);
            this.lblRestTime.TabIndex = 24;
            this.lblRestTime.Text = "休息时间时长：";
            // 
            // numRestTime
            // 
            this.numRestTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRestTime.Location = new System.Drawing.Point(119, 56);
            this.numRestTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numRestTime.Name = "numRestTime";
            this.numRestTime.Size = new System.Drawing.Size(161, 21);
            this.numRestTime.TabIndex = 2;
            this.numRestTime.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // lblMinute4
            // 
            this.lblMinute4.AutoSize = true;
            this.lblMinute4.Location = new System.Drawing.Point(286, 58);
            this.lblMinute4.Name = "lblMinute4";
            this.lblMinute4.Size = new System.Drawing.Size(29, 12);
            this.lblMinute4.TabIndex = 30;
            this.lblMinute4.Tag = "；";
            this.lblMinute4.Text = "分钟";
            // 
            // pnlDriveTime
            // 
            this.pnlDriveTime.Controls.Add(this.label1);
            this.pnlDriveTime.Controls.Add(this.lblDriveTime);
            this.pnlDriveTime.Controls.Add(this.numDriveTime);
            this.pnlDriveTime.Controls.Add(this.lblMinute1);
            this.pnlDriveTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDriveTime.Location = new System.Drawing.Point(3, 17);
            this.pnlDriveTime.Name = "pnlDriveTime";
            this.pnlDriveTime.Size = new System.Drawing.Size(357, 48);
            this.pnlDriveTime.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(119, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 12);
            this.label1.TabIndex = 30;
            this.label1.Tag = "9999";
            this.label1.Text = "*当时长为0时，表示不限制(0-65535)";
            // 
            // lblDriveTime
            // 
            this.lblDriveTime.AutoSize = true;
            this.lblDriveTime.Location = new System.Drawing.Point(23, 5);
            this.lblDriveTime.Name = "lblDriveTime";
            this.lblDriveTime.Size = new System.Drawing.Size(89, 12);
            this.lblDriveTime.TabIndex = 27;
            this.lblDriveTime.Text = "驾驶持续时长：";
            // 
            // numDriveTime
            // 
            this.numDriveTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDriveTime.Location = new System.Drawing.Point(119, 3);
            this.numDriveTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDriveTime.Name = "numDriveTime";
            this.numDriveTime.Size = new System.Drawing.Size(161, 21);
            this.numDriveTime.TabIndex = 0;
            this.numDriveTime.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // lblMinute1
            // 
            this.lblMinute1.AutoSize = true;
            this.lblMinute1.Location = new System.Drawing.Point(286, 5);
            this.lblMinute1.Name = "lblMinute1";
            this.lblMinute1.Size = new System.Drawing.Size(29, 12);
            this.lblMinute1.TabIndex = 29;
            this.lblMinute1.Tag = "；";
            this.lblMinute1.Text = "分钟";
            // 
            // itmCarOverTimeDrive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(373, 306);
            this.Controls.Add(this.grpSetOverTimeDrive);
            this.Name = "itmCarOverTimeDrive";
            this.Text = "SetOverTimeDrive";
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpSetOverTimeDrive, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpSetOverTimeDrive.ResumeLayout(false);
            this.pnlSetOverTimeDrive.ResumeLayout(false);
            this.pnlSetOverTimeDrive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAlarmInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRestTime)).EndInit();
            this.pnlDriveTime.ResumeLayout(false);
            this.pnlDriveTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDriveTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    
        private IContainer components;
        private System.Windows.Forms.GroupBox grpSetOverTimeDrive;
        private Label label1;
        private Label lblAlarmInterval;
        private Label lblAlarmTime;
        private Label lblDriveTime;
        private Label lblMinute1;
        private Label lblMinute2;
        private Label lblMinute3;
        private Label lblMinute4;
        private Label lblRestTime;
        private NumericUpDown numAlarmInterval;
        private NumericUpDown numAlarmTime;
        private NumericUpDown numDriveTime;
        private NumericUpDown numRestTime;
        private Panel pnlDriveTime;
        private Panel pnlSetOverTimeDrive;
    }
}