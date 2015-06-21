namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmSetBlackReport
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
            new ComponentResourceManager(typeof(itmSetBlackReport));
            this.grpSampleParam = new GroupBox();
            this.lblSampleType = new Label();
            this.cmbSampleType = new ComBox();
            this.lblDistance = new Label();
            this.numDistance = new NumericUpDown();
            this.lblMeter = new Label();
            this.lblRepair = new Label();
            this.numRepair = new NumericUpDown();
            this.lblAngle = new Label();
            this.chkAutoUp = new CheckBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSampleParam.SuspendLayout();
            this.numDistance.BeginInit();
            this.numRepair.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 232);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpSampleParam.Controls.Add(this.lblSampleType);
            this.grpSampleParam.Controls.Add(this.cmbSampleType);
            this.grpSampleParam.Controls.Add(this.lblDistance);
            this.grpSampleParam.Controls.Add(this.numDistance);
            this.grpSampleParam.Controls.Add(this.lblMeter);
            this.grpSampleParam.Controls.Add(this.lblRepair);
            this.grpSampleParam.Controls.Add(this.numRepair);
            this.grpSampleParam.Controls.Add(this.lblAngle);
            this.grpSampleParam.Controls.Add(this.chkAutoUp);
            this.grpSampleParam.Dock = DockStyle.Top;
            this.grpSampleParam.Location = new System.Drawing.Point(5, 121);
            this.grpSampleParam.Name = "grpSampleParam";
            this.grpSampleParam.Size = new Size(363, 111);
            this.grpSampleParam.TabIndex = 1;
            this.grpSampleParam.TabStop = false;
            this.grpSampleParam.Text = "黑匣子采样参数";
            this.lblSampleType.AutoSize = true;
            this.lblSampleType.Location = new System.Drawing.Point(50, 23);
            this.lblSampleType.Name = "lblSampleType";
            this.lblSampleType.Size = new Size(65, 12);
            this.lblSampleType.TabIndex = 13;
            this.lblSampleType.Text = "采样方式：";
            this.cmbSampleType.DisplayMember = "Display";
            this.cmbSampleType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSampleType.FlatStyle = FlatStyle.Flat;
            this.cmbSampleType.FormattingEnabled = true;
            this.cmbSampleType.Location = new System.Drawing.Point(122, 20);
            this.cmbSampleType.Name = "cmbSampleType";
            this.cmbSampleType.Size = new Size(161, 20);
            this.cmbSampleType.TabIndex = 0;
            this.cmbSampleType.Tag = "；";
            this.cmbSampleType.ValueMember = "Value";
            this.cmbSampleType.SelectedValueChanged += new EventHandler(this.cmbSampleType_SelectedValueChanged);
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(50, 55);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new Size(65, 12);
            this.lblDistance.TabIndex = 14;
            this.lblDistance.Text = "采样间隔：";
            this.numDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDistance.Location = new System.Drawing.Point(122, 52);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numDistance.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numDistance.Minimum = new decimal(numArray2);
            this.numDistance.Name = "numDistance";
            this.numDistance.Size = new Size(60, 21);
            this.numDistance.TabIndex = 1;
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numDistance.Value = new decimal(numArray3);
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(185, 55);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new Size(17, 12);
            this.lblMeter.TabIndex = 15;
            this.lblMeter.Tag = "；";
            this.lblMeter.Text = "秒";
            this.lblRepair.AutoSize = true;
            this.lblRepair.Location = new System.Drawing.Point(217, 56);
            this.lblRepair.Name = "lblRepair";
            this.lblRepair.Size = new Size(65, 12);
            this.lblRepair.TabIndex = 17;
            this.lblRepair.Text = "拐点补偿：";
            this.numRepair.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numRepair.Location = new System.Drawing.Point(289, 52);
            this.numRepair.Name = "numRepair";
            this.numRepair.Size = new Size(35, 21);
            this.numRepair.TabIndex = 2;
            this.lblAngle.AutoSize = true;
            this.lblAngle.Location = new System.Drawing.Point(330, 56);
            this.lblAngle.Name = "lblAngle";
            this.lblAngle.Size = new Size(17, 12);
            this.lblAngle.TabIndex = 18;
            this.lblAngle.Tag = "；";
            this.lblAngle.Text = "度";
            this.chkAutoUp.AutoSize = true;
            this.chkAutoUp.Checked = true;
            this.chkAutoUp.CheckState = CheckState.Checked;
            this.chkAutoUp.Location = new System.Drawing.Point(52, 84);
            this.chkAutoUp.Name = "chkAutoUp";
            this.chkAutoUp.Size = new Size(204, 16);
            this.chkAutoUp.TabIndex = 3;
            this.chkAutoUp.Tag = "；";
            this.chkAutoUp.Text = "黑匣子数据装满时，自动上传数据";
            this.chkAutoUp.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 265);
            base.Controls.Add(this.grpSampleParam);
            base.Name = "itmSetBlackReport";
            this.Text = "BlackBox";
            base.Load += new EventHandler(this.itmSetBlackReport_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSampleParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSampleParam.ResumeLayout(false);
            this.grpSampleParam.PerformLayout();
            this.numDistance.EndInit();
            this.numRepair.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private CheckBox chkAutoUp;
        private ComBox cmbSampleType;
        private GroupBox grpSampleParam;
        private Label lblAngle;
        private Label lblDistance;
        private Label lblMeter;
        private Label lblRepair;
        private Label lblSampleType;
        private NumericUpDown numDistance;
        private NumericUpDown numRepair;
    }
}