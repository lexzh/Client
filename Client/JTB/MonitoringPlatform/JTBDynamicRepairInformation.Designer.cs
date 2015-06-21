namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class JTBDynamicRepairInformation
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
            this.lblRepairType = new Label();
            this.cmbRepairType = new ComboBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.Size = new Size(371, 116);
            base.pnlBtn.Location = new System.Drawing.Point(5, 213);
            base.pnlBtn.Size = new Size(371, 28);
            this.grpWatchProperty.Controls.Add(this.cmbRepairType);
            this.grpWatchProperty.Controls.Add(this.lblRepairType);
            this.grpWatchProperty.Controls.Add(this.dtpEndTime);
            this.grpWatchProperty.Controls.Add(this.lblEndTime);
            this.grpWatchProperty.Controls.Add(this.dtpStartTime);
            this.grpWatchProperty.Controls.Add(this.lblStartTime);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(371, 92);
            this.grpWatchProperty.TabIndex = 12;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "设置参数";
            this.dtpEndTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEndTime.Format = DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(122, 67);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new Size(161, 21);
            this.dtpEndTime.TabIndex = 17;
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(50, 71);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new Size(65, 12);
            this.lblEndTime.TabIndex = 16;
            this.lblEndTime.Text = "结束时间：";
            this.dtpStartTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStartTime.Format = DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(122, 40);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new Size(161, 21);
            this.dtpStartTime.TabIndex = 15;
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(50, 44);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new Size(65, 12);
            this.lblStartTime.TabIndex = 14;
            this.lblStartTime.Text = "开始时间：";
            this.lblRepairType.AutoSize = true;
            this.lblRepairType.Location = new System.Drawing.Point(50, 19);
            this.lblRepairType.Name = "lblRepairType";
            this.lblRepairType.Size = new Size(65, 12);
            this.lblRepairType.TabIndex = 18;
            this.lblRepairType.Text = "补报类型：";
            this.cmbRepairType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRepairType.FormattingEnabled = true;
            this.cmbRepairType.Items.AddRange(new object[] { "当前指定终端", "所有终端" });
            this.cmbRepairType.Location = new System.Drawing.Point(122, 14);
            this.cmbRepairType.Name = "cmbRepairType";
            this.cmbRepairType.Size = new Size(161, 20);
            this.cmbRepairType.TabIndex = 19;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(381, 246);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBDynamicRepairInformation";
            this.Text = "JTBDynamicRepairInformation";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private ComboBox cmbRepairType;
        private DateTimePicker dtpEndTime;
        private DateTimePicker dtpStartTime;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblEndTime;
        private Label lblRepairType;
        private Label lblStartTime;
    }
}