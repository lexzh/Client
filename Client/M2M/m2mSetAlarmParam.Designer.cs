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

    partial class m2mSetAlarmParam
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
            new ComponentResourceManager(typeof(m2mSetAlarmParam));
            this.lblAlarmType = new Label();
            this.cmbAlarmType = new ComBox();
            this.lblDuration = new Label();
            this.numDuration = new NumericUpDown();
            this.lblInterval = new Label();
            this.numInterval = new NumericUpDown();
            this.lblSecond = new Label();
            this.lblSecond2 = new Label();
            this.lblAlarmTime = new Label();
            this.numAlarmTime = new NumericUpDown();
            this.groupBox1 = new GroupBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.numDuration.BeginInit();
            this.numInterval.BeginInit();
            this.numAlarmTime.BeginInit();
            this.groupBox1.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 272);
            this.lblAlarmType.AutoSize = true;
            this.lblAlarmType.Location = new System.Drawing.Point(50, 23);
            this.lblAlarmType.Name = "lblAlarmType";
            this.lblAlarmType.Size = new Size(65, 12);
            this.lblAlarmType.TabIndex = 0;
            this.lblAlarmType.Text = "报警类型：";
            this.cmbAlarmType.DisplayMember = "Display";
            this.cmbAlarmType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbAlarmType.FlatStyle = FlatStyle.Flat;
            this.cmbAlarmType.FormattingEnabled = true;
            this.cmbAlarmType.Location = new System.Drawing.Point(121, 19);
            this.cmbAlarmType.Name = "cmbAlarmType";
            this.cmbAlarmType.Size = new Size(162, 20);
            this.cmbAlarmType.TabIndex = 1;
            this.cmbAlarmType.Tag = "；";
            this.cmbAlarmType.ValueMember = "Value";
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(50, 55);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new Size(65, 12);
            this.lblDuration.TabIndex = 0;
            this.lblDuration.Text = "持续时间：";
            this.numDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDuration.Location = new System.Drawing.Point(121, 51);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numDuration.Maximum = new decimal(bits);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new Size(162, 21);
            this.numDuration.TabIndex = 2;
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(50, 87);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new Size(65, 12);
            this.lblInterval.TabIndex = 0;
            this.lblInterval.Text = "间隔时间：";
            this.numInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numInterval.Location = new System.Drawing.Point(121, 83);
            int[] numArray2 = new int[4];
            numArray2[0] = 65535;
            this.numInterval.Maximum = new decimal(numArray2);
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new Size(162, 21);
            this.numInterval.TabIndex = 2;
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(296, 55);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new Size(17, 12);
            this.lblSecond.TabIndex = 0;
            this.lblSecond.Tag = "；";
            this.lblSecond.Text = "秒";
            this.lblSecond2.AutoSize = true;
            this.lblSecond2.Location = new System.Drawing.Point(296, 87);
            this.lblSecond2.Name = "lblSecond2";
            this.lblSecond2.Size = new Size(17, 12);
            this.lblSecond2.TabIndex = 0;
            this.lblSecond2.Tag = "；";
            this.lblSecond2.Text = "秒";
            this.lblAlarmTime.AutoSize = true;
            this.lblAlarmTime.Location = new System.Drawing.Point(50, 119);
            this.lblAlarmTime.Name = "lblAlarmTime";
            this.lblAlarmTime.Size = new Size(65, 12);
            this.lblAlarmTime.TabIndex = 0;
            this.lblAlarmTime.Text = "报警次数：";
            this.numAlarmTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAlarmTime.Location = new System.Drawing.Point(121, 115);
            int[] numArray3 = new int[4];
            numArray3[0] = 65535;
            this.numAlarmTime.Maximum = new decimal(numArray3);
            this.numAlarmTime.Name = "numAlarmTime";
            this.numAlarmTime.Size = new Size(162, 21);
            this.numAlarmTime.TabIndex = 2;
            this.groupBox1.Controls.Add(this.lblAlarmType);
            this.groupBox1.Controls.Add(this.cmbAlarmType);
            this.groupBox1.Controls.Add(this.lblDuration);
            this.groupBox1.Controls.Add(this.numDuration);
            this.groupBox1.Controls.Add(this.lblSecond);
            this.groupBox1.Controls.Add(this.lblInterval);
            this.groupBox1.Controls.Add(this.numInterval);
            this.groupBox1.Controls.Add(this.lblSecond2);
            this.groupBox1.Controls.Add(this.lblAlarmTime);
            this.groupBox1.Controls.Add(this.numAlarmTime);
            this.groupBox1.Dock = DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(5, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new Size(363, 151);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 305);
            base.Controls.Add(this.groupBox1);
            base.Name = "m2mSetAlarmParam";
            this.Text = "报警参数设置";
            base.Load += new EventHandler(this.itmSetAlarmParam_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.groupBox1, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.numDuration.EndInit();
            this.numInterval.EndInit();
            this.numAlarmTime.EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbAlarmType;
        private GroupBox groupBox1;
        private Label lblAlarmTime;
        private Label lblAlarmType;
        private Label lblDuration;
        private Label lblInterval;
        private Label lblSecond;
        private Label lblSecond2;
        private NumericUpDown numAlarmTime;
        private NumericUpDown numDuration;
        private NumericUpDown numInterval;
    }
}