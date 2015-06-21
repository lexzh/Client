namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmCarOverTimeStop
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
            this.pnlDriveTime = new System.Windows.Forms.Panel();
            this.cmbTelType = new System.Windows.Forms.ComboBox();
            this.lblTelType = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDriveTime = new System.Windows.Forms.Label();
            this.numDriveTime = new System.Windows.Forms.NumericUpDown();
            this.lblMinute1 = new System.Windows.Forms.Label();
            this.grpCar.SuspendLayout();
            this.pnlBtn.SuspendLayout();
            this.grpSetOverTimeDrive.SuspendLayout();
            this.pnlDriveTime.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDriveTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBtn
            // 
            this.pnlBtn.Location = new System.Drawing.Point(5, 210);
            // 
            // grpSetOverTimeDrive
            // 
            this.grpSetOverTimeDrive.AutoSize = true;
            this.grpSetOverTimeDrive.Controls.Add(this.pnlDriveTime);
            this.grpSetOverTimeDrive.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSetOverTimeDrive.Location = new System.Drawing.Point(5, 121);
            this.grpSetOverTimeDrive.Margin = new System.Windows.Forms.Padding(0);
            this.grpSetOverTimeDrive.Name = "grpSetOverTimeDrive";
            this.grpSetOverTimeDrive.Size = new System.Drawing.Size(363, 89);
            this.grpSetOverTimeDrive.TabIndex = 11;
            this.grpSetOverTimeDrive.TabStop = false;
            this.grpSetOverTimeDrive.Text = "超时驾驶参数";
            // 
            // pnlDriveTime
            // 
            this.pnlDriveTime.Controls.Add(this.cmbTelType);
            this.pnlDriveTime.Controls.Add(this.lblTelType);
            this.pnlDriveTime.Controls.Add(this.label1);
            this.pnlDriveTime.Controls.Add(this.lblDriveTime);
            this.pnlDriveTime.Controls.Add(this.numDriveTime);
            this.pnlDriveTime.Controls.Add(this.lblMinute1);
            this.pnlDriveTime.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlDriveTime.Location = new System.Drawing.Point(3, 17);
            this.pnlDriveTime.Name = "pnlDriveTime";
            this.pnlDriveTime.Size = new System.Drawing.Size(357, 69);
            this.pnlDriveTime.TabIndex = 0;
            // 
            // cmbTelType
            // 
            this.cmbTelType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTelType.FormattingEnabled = true;
            this.cmbTelType.Items.AddRange(new object[] {
            "每次最长通话时间",
            "当月最长通话时间"});
            this.cmbTelType.Location = new System.Drawing.Point(119, 5);
            this.cmbTelType.Name = "cmbTelType";
            this.cmbTelType.Size = new System.Drawing.Size(161, 20);
            this.cmbTelType.TabIndex = 33;
            this.cmbTelType.Visible = false;
            this.cmbTelType.SelectedIndexChanged += new System.EventHandler(this.cmbTelType_SelectedIndexChanged_1);
            // 
            // lblTelType
            // 
            this.lblTelType.AutoSize = true;
            this.lblTelType.Location = new System.Drawing.Point(25, 10);
            this.lblTelType.Name = "lblTelType";
            this.lblTelType.Size = new System.Drawing.Size(89, 12);
            this.lblTelType.TabIndex = 32;
            this.lblTelType.Text = "通话限制类别：";
            this.lblTelType.Visible = false;
            // 
            // lblVersion
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(45, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 12);
            this.label1.TabIndex = 30;
            this.label1.Tag = "9999";
            this.label1.Text = "*当时长为65535时，表示不限制(0-65535)";
            // 
            // lblDriveTime
            // 
            this.lblDriveTime.AutoSize = true;
            this.lblDriveTime.Location = new System.Drawing.Point(23, 36);
            this.lblDriveTime.Name = "lblDriveTime";
            this.lblDriveTime.Size = new System.Drawing.Size(89, 12);
            this.lblDriveTime.TabIndex = 27;
            this.lblDriveTime.Text = "驾驶持续时长：";
            // 
            // numDriveTime
            // 
            this.numDriveTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDriveTime.Location = new System.Drawing.Point(119, 31);
            this.numDriveTime.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numDriveTime.Name = "numDriveTime";
            this.numDriveTime.Size = new System.Drawing.Size(161, 21);
            this.numDriveTime.TabIndex = 0;
            // 
            // lblMinute1
            // 
            this.lblMinute1.AutoSize = true;
            this.lblMinute1.Location = new System.Drawing.Point(286, 33);
            this.lblMinute1.Name = "lblMinute1";
            this.lblMinute1.Size = new System.Drawing.Size(29, 12);
            this.lblMinute1.TabIndex = 29;
            this.lblMinute1.Tag = "；";
            this.lblMinute1.Text = "分钟";
            // 
            // itmCarOverTimeStop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(373, 243);
            this.Controls.Add(this.grpSetOverTimeDrive);
            this.Name = "itmCarOverTimeStop";
            this.Text = "位置查询";
            this.Load += new System.EventHandler(this.itmCarOverTimeStop_Load);
            this.Controls.SetChildIndex(this.grpCar, 0);
            this.Controls.SetChildIndex(this.grpSetOverTimeDrive, 0);
            this.Controls.SetChildIndex(this.pnlBtn, 0);
            this.grpCar.ResumeLayout(false);
            this.grpCar.PerformLayout();
            this.pnlBtn.ResumeLayout(false);
            this.grpSetOverTimeDrive.ResumeLayout(false);
            this.pnlDriveTime.ResumeLayout(false);
            this.pnlDriveTime.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDriveTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

       
        private IContainer components;
        private ComboBox cmbTelType;
        private GroupBox grpSetOverTimeDrive;
        private Label label1;
        private Label lblDriveTime;
        private Label lblMinute1;
        private Label lblTelType;
        private NumericUpDown numDriveTime;
        private Panel pnlDriveTime;
    }
}