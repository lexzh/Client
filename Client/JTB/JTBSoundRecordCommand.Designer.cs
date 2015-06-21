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

    partial class JTBSoundRecordCommand
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
            this.cmbSoundRatio = new ComboBox();
            this.lblSoundRatio = new Label();
            this.cmbStoreFlag = new ComboBox();
            this.lblStoreFlag = new Label();
            this.lblExplain1 = new Label();
            this.numRecordTimeLong = new NumericUpDown();
            this.cmbRecordCmd = new ComboBox();
            this.lblRecordTimeLong = new Label();
            this.lblRecordCmd = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numRecordTimeLong.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 235);
            this.grpWatchProperty.Controls.Add(this.cmbSoundRatio);
            this.grpWatchProperty.Controls.Add(this.lblSoundRatio);
            this.grpWatchProperty.Controls.Add(this.cmbStoreFlag);
            this.grpWatchProperty.Controls.Add(this.lblStoreFlag);
            this.grpWatchProperty.Controls.Add(this.lblExplain1);
            this.grpWatchProperty.Controls.Add(this.numRecordTimeLong);
            this.grpWatchProperty.Controls.Add(this.cmbRecordCmd);
            this.grpWatchProperty.Controls.Add(this.lblRecordTimeLong);
            this.grpWatchProperty.Controls.Add(this.lblRecordCmd);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 114);
            this.grpWatchProperty.TabIndex = 12;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.cmbSoundRatio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSoundRatio.FormattingEnabled = true;
            this.cmbSoundRatio.Items.AddRange(new object[] { "8K", "11K", "23K", "32K" });
            this.cmbSoundRatio.Location = new System.Drawing.Point(122, 83);
            this.cmbSoundRatio.Name = "cmbSoundRatio";
            this.cmbSoundRatio.Size = new Size(161, 20);
            this.cmbSoundRatio.TabIndex = 46;
            this.lblSoundRatio.AutoSize = true;
            this.lblSoundRatio.Location = new System.Drawing.Point(39, 86);
            this.lblSoundRatio.Name = "lblSoundRatio";
            this.lblSoundRatio.Size = new Size(77, 12);
            this.lblSoundRatio.TabIndex = 45;
            this.lblSoundRatio.Text = "音频采样率：";
            this.cmbStoreFlag.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStoreFlag.FormattingEnabled = true;
            this.cmbStoreFlag.Items.AddRange(new object[] { "实时上传", "保存" });
            this.cmbStoreFlag.Location = new System.Drawing.Point(122, 59);
            this.cmbStoreFlag.Name = "cmbStoreFlag";
            this.cmbStoreFlag.Size = new Size(161, 20);
            this.cmbStoreFlag.TabIndex = 44;
            this.lblStoreFlag.AutoSize = true;
            this.lblStoreFlag.Location = new System.Drawing.Point(50, 61);
            this.lblStoreFlag.Name = "lblStoreFlag";
            this.lblStoreFlag.Size = new Size(65, 12);
            this.lblStoreFlag.TabIndex = 43;
            this.lblStoreFlag.Text = "保存标志：";
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(247, 38);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(83, 12);
            this.lblExplain1.TabIndex = 42;
            this.lblExplain1.Text = "0表示一直录音";
            this.numRecordTimeLong.Location = new System.Drawing.Point(122, 35);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numRecordTimeLong.Maximum = new decimal(bits);
            this.numRecordTimeLong.Name = "numRecordTimeLong";
            this.numRecordTimeLong.Size = new Size(120, 21);
            this.numRecordTimeLong.TabIndex = 37;
            this.cmbRecordCmd.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbRecordCmd.FormattingEnabled = true;
            this.cmbRecordCmd.Items.AddRange(new object[] { "表示停止录音", "表示开始录音" });
            this.cmbRecordCmd.Location = new System.Drawing.Point(122, 11);
            this.cmbRecordCmd.Name = "cmbRecordCmd";
            this.cmbRecordCmd.Size = new Size(161, 20);
            this.cmbRecordCmd.TabIndex = 36;
            this.lblRecordTimeLong.AutoSize = true;
            this.lblRecordTimeLong.Location = new System.Drawing.Point(50, 38);
            this.lblRecordTimeLong.Name = "lblRecordTimeLong";
            this.lblRecordTimeLong.Size = new Size(65, 12);
            this.lblRecordTimeLong.TabIndex = 33;
            this.lblRecordTimeLong.Text = "录音时间：";
            this.lblRecordCmd.AutoSize = true;
            this.lblRecordCmd.Location = new System.Drawing.Point(50, 13);
            this.lblRecordCmd.Name = "lblRecordCmd";
            this.lblRecordCmd.Size = new Size(65, 12);
            this.lblRecordCmd.TabIndex = 34;
            this.lblRecordCmd.Text = "录音命令：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 268);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSoundRecordCommand";
            this.Text = "JTBSoundRecordCommand";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numRecordTimeLong.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private ComboBox cmbRecordCmd;
        private ComboBox cmbSoundRatio;
        private ComboBox cmbStoreFlag;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblExplain1;
        private Label lblRecordCmd;
        private Label lblRecordTimeLong;
        private Label lblSoundRatio;
        private Label lblStoreFlag;
        private NumericUpDown numRecordTimeLong;
    }
}