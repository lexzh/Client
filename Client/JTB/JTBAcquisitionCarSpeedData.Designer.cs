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

    partial class JTBAcquisitionCarSpeedData
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
            this.cmbAcquisitionType = new ComboBox();
            this.lblAcquisitionType = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.Size = new Size(368, 116);
            base.pnlBtn.Location = new System.Drawing.Point(5, 165);
            base.pnlBtn.Size = new Size(368, 28);
            this.grpWatchProperty.Controls.Add(this.cmbAcquisitionType);
            this.grpWatchProperty.Controls.Add(this.lblAcquisitionType);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(368, 44);
            this.grpWatchProperty.TabIndex = 11;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.cmbAcquisitionType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAcquisitionType.FormattingEnabled = true;
            this.cmbAcquisitionType.Items.AddRange(new object[] { "采集最近2个日历天内的行驶速度数据", "采集最近360小时内的速度数据" });
            this.cmbAcquisitionType.Location = new System.Drawing.Point(122, 14);
            this.cmbAcquisitionType.Name = "cmbAcquisitionType";
            this.cmbAcquisitionType.Size = new Size(198, 20);
            this.cmbAcquisitionType.TabIndex = 38;
            this.lblAcquisitionType.AutoSize = true;
            this.lblAcquisitionType.Location = new System.Drawing.Point(50, 17);
            this.lblAcquisitionType.Name = "lblAcquisitionType";
            this.lblAcquisitionType.Size = new Size(65, 12);
            this.lblAcquisitionType.TabIndex = 37;
            this.lblAcquisitionType.Text = "查询类型：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(378, 198);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBAcquisitionCarSpeedData";
            this.Text = "JTBAcquisitionCarSpeedData";
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
        private ComboBox cmbAcquisitionType;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblAcquisitionType;
    }
}