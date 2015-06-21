namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itemsettemp
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
            this.grpTemperatureParam = new GroupBox();
            this.lblMinTemperature = new Label();
            this.numMinTemperature = new NumericUpDown();
            this.lblExplain1 = new Label();
            this.lblMaxTemperature = new Label();
            this.numMaxTemperature = new NumericUpDown();
            this.lblExplain2 = new Label();
            this.chkStopAlarm = new CheckBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpTemperatureParam.SuspendLayout();
            this.numMinTemperature.BeginInit();
            this.numMaxTemperature.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 224);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpTemperatureParam.Controls.Add(this.lblMinTemperature);
            this.grpTemperatureParam.Controls.Add(this.numMinTemperature);
            this.grpTemperatureParam.Controls.Add(this.lblExplain1);
            this.grpTemperatureParam.Controls.Add(this.lblMaxTemperature);
            this.grpTemperatureParam.Controls.Add(this.numMaxTemperature);
            this.grpTemperatureParam.Controls.Add(this.lblExplain2);
            this.grpTemperatureParam.Controls.Add(this.chkStopAlarm);
            this.grpTemperatureParam.Dock = DockStyle.Top;
            this.grpTemperatureParam.Location = new System.Drawing.Point(5, 121);
            this.grpTemperatureParam.Name = "grpTemperatureParam";
            this.grpTemperatureParam.Size = new Size(363, 103);
            this.grpTemperatureParam.TabIndex = 1;
            this.grpTemperatureParam.TabStop = false;
            this.grpTemperatureParam.Text = "温度参数";
            this.lblMinTemperature.AutoSize = true;
            this.lblMinTemperature.Location = new System.Drawing.Point(50, 24);
            this.lblMinTemperature.Name = "lblMinTemperature";
            this.lblMinTemperature.Size = new Size(65, 12);
            this.lblMinTemperature.TabIndex = 19;
            this.lblMinTemperature.Text = "最低温度：";
            this.numMinTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMinTemperature.Location = new System.Drawing.Point(122, 22);
            int[] bits = new int[4];
            bits[0] = 327;
            this.numMinTemperature.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 327;
            numArray2[3] = -2147483648;
            this.numMinTemperature.Minimum = new decimal(numArray2);
            this.numMinTemperature.Name = "numMinTemperature";
            this.numMinTemperature.Size = new Size(161, 21);
            this.numMinTemperature.TabIndex = 0;
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(289, 24);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(17, 12);
            this.lblExplain1.TabIndex = 24;
            this.lblExplain1.Tag = "；";
            this.lblExplain1.Text = "度";
            this.lblMaxTemperature.AutoSize = true;
            this.lblMaxTemperature.Location = new System.Drawing.Point(50, 51);
            this.lblMaxTemperature.Name = "lblMaxTemperature";
            this.lblMaxTemperature.Size = new Size(65, 12);
            this.lblMaxTemperature.TabIndex = 20;
            this.lblMaxTemperature.Text = "最高温度：";
            this.numMaxTemperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMaxTemperature.Location = new System.Drawing.Point(122, 49);
            int[] numArray3 = new int[4];
            numArray3[0] = 327;
            this.numMaxTemperature.Maximum = new decimal(numArray3);
            int[] numArray4 = new int[4];
            numArray4[0] = 327;
            numArray4[3] = -2147483648;
            this.numMaxTemperature.Minimum = new decimal(numArray4);
            this.numMaxTemperature.Name = "numMaxTemperature";
            this.numMaxTemperature.Size = new Size(161, 21);
            this.numMaxTemperature.TabIndex = 1;
            this.lblExplain2.AutoSize = true;
            this.lblExplain2.Location = new System.Drawing.Point(289, 51);
            this.lblExplain2.Name = "lblExplain2";
            this.lblExplain2.Size = new Size(17, 12);
            this.lblExplain2.TabIndex = 23;
            this.lblExplain2.Tag = "；";
            this.lblExplain2.Text = "度";
            this.chkStopAlarm.AutoSize = true;
            this.chkStopAlarm.Location = new System.Drawing.Point(122, 78);
            this.chkStopAlarm.Name = "chkStopAlarm";
            this.chkStopAlarm.Size = new Size(96, 16);
            this.chkStopAlarm.TabIndex = 2;
            this.chkStopAlarm.Text = "停止温度报警";
            this.chkStopAlarm.UseVisualStyleBackColor = true;
            this.chkStopAlarm.CheckedChanged += new EventHandler(this.chkStopAlarm_CheckedChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 257);
            base.Controls.Add(this.grpTemperatureParam);
            base.Name = "itemsettemp";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpTemperatureParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpTemperatureParam.ResumeLayout(false);
            this.grpTemperatureParam.PerformLayout();
            this.numMinTemperature.EndInit();
            this.numMaxTemperature.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private CheckBox chkStopAlarm;
        private GroupBox grpTemperatureParam;
        private Label lblExplain1;
        private Label lblExplain2;
        private Label lblMaxTemperature;
        private Label lblMinTemperature;
        private NumericUpDown numMaxTemperature;
        private NumericUpDown numMinTemperature;
    }
}