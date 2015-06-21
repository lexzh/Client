namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class itmSetOverSpeed
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
            new ComponentResourceManager(typeof(itmSetOverSpeed));
            this.grpSpeedParam = new GroupBox();
            this.lblMaxSpeed = new Label();
            this.numMaxSpeed = new NumericUpDown();
            this.lblExplain1 = new Label();
            this.lblDuration = new Label();
            this.numDuration = new NumericUpDown();
            this.lblExplain2 = new Label();
            this.lblCueInterval = new Label();
            this.cmbCueInterval = new ComBox();
            this.lblExplain3 = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSpeedParam.SuspendLayout();
            this.numMaxSpeed.BeginInit();
            this.numDuration.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 225);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpSpeedParam.Controls.Add(this.lblMaxSpeed);
            this.grpSpeedParam.Controls.Add(this.numMaxSpeed);
            this.grpSpeedParam.Controls.Add(this.lblExplain1);
            this.grpSpeedParam.Controls.Add(this.lblDuration);
            this.grpSpeedParam.Controls.Add(this.numDuration);
            this.grpSpeedParam.Controls.Add(this.lblExplain2);
            this.grpSpeedParam.Controls.Add(this.lblCueInterval);
            this.grpSpeedParam.Controls.Add(this.cmbCueInterval);
            this.grpSpeedParam.Controls.Add(this.lblExplain3);
            this.grpSpeedParam.Dock = DockStyle.Top;
            this.grpSpeedParam.Location = new System.Drawing.Point(5, 121);
            this.grpSpeedParam.Name = "grpSpeedParam";
            this.grpSpeedParam.Size = new Size(363, 104);
            this.grpSpeedParam.TabIndex = 1;
            this.grpSpeedParam.TabStop = false;
            this.grpSpeedParam.Text = "超速参数";
            this.lblMaxSpeed.AutoSize = true;
            this.lblMaxSpeed.Location = new System.Drawing.Point(50, 21);
            this.lblMaxSpeed.Name = "lblMaxSpeed";
            this.lblMaxSpeed.Size = new Size(65, 12);
            this.lblMaxSpeed.TabIndex = 14;
            this.lblMaxSpeed.Text = "最高限速：";
            this.numMaxSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numMaxSpeed.Location = new System.Drawing.Point(122, 19);
            int[] bits = new int[4];
            bits[0] = 255;
            this.numMaxSpeed.Maximum = new decimal(bits);
            this.numMaxSpeed.Name = "numMaxSpeed";
            this.numMaxSpeed.Size = new Size(161, 21);
            this.numMaxSpeed.TabIndex = 0;
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(289, 21);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(29, 12);
            this.lblExplain1.TabIndex = 18;
            this.lblExplain1.Tag = "；";
            this.lblExplain1.Text = "km/h";
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(50, 48);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new Size(65, 12);
            this.lblDuration.TabIndex = 13;
            this.lblDuration.Text = "持续时间：";
            this.numDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            int[] numArray2 = new int[4];
            numArray2[0] = 5;
            this.numDuration.Increment = new decimal(numArray2);
            this.numDuration.Location = new System.Drawing.Point(122, 46);
            int[] numArray3 = new int[4];
            numArray3[0] = 250;
            this.numDuration.Maximum = new decimal(numArray3);
            int[] numArray4 = new int[4];
            numArray4[0] = 5;
            this.numDuration.Minimum = new decimal(numArray4);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new Size(161, 21);
            this.numDuration.TabIndex = 1;
            this.numDuration.Tag = "；";
            int[] numArray5 = new int[4];
            numArray5[0] = 5;
            this.numDuration.Value = new decimal(numArray5);
            this.numDuration.ValueChanged += new EventHandler(this.numDuration_ValueChanged);
            this.lblExplain2.AutoSize = true;
            this.lblExplain2.Location = new System.Drawing.Point(289, 43);
            this.lblExplain2.Name = "lblExplain2";
            this.lblExplain2.Size = new Size(17, 12);
            this.lblExplain2.TabIndex = 17;
            this.lblExplain2.Tag = "9999";
            this.lblExplain2.Text = "秒";
            this.lblCueInterval.AutoSize = true;
            this.lblCueInterval.Location = new System.Drawing.Point(26, 76);
            this.lblCueInterval.Name = "lblCueInterval";
            this.lblCueInterval.Size = new Size(89, 12);
            this.lblCueInterval.TabIndex = 13;
            this.lblCueInterval.Text = "手柄提示间隔：";
            this.lblCueInterval.Visible = false;
            this.cmbCueInterval.DisplayMember = "Display";
            this.cmbCueInterval.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCueInterval.FlatStyle = FlatStyle.Flat;
            this.cmbCueInterval.FormattingEnabled = true;
            this.cmbCueInterval.Location = new System.Drawing.Point(122, 73);
            this.cmbCueInterval.Name = "cmbCueInterval";
            this.cmbCueInterval.Size = new Size(161, 20);
            this.cmbCueInterval.TabIndex = 2;
            this.cmbCueInterval.ValueMember = "Value";
            this.cmbCueInterval.Visible = false;
            this.lblExplain3.AutoSize = true;
            this.lblExplain3.Location = new System.Drawing.Point(289, 76);
            this.lblExplain3.Name = "lblExplain3";
            this.lblExplain3.Size = new Size(17, 12);
            this.lblExplain3.TabIndex = 17;
            this.lblExplain3.Tag = "；";
            this.lblExplain3.Text = "秒";
            this.lblExplain3.Visible = false;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 258);
            base.Controls.Add(this.grpSpeedParam);
            base.Name = "itmSetOverSpeed";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmSetOverSpeed_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSpeedParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSpeedParam.ResumeLayout(false);
            this.grpSpeedParam.PerformLayout();
            this.numMaxSpeed.EndInit();
            this.numDuration.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbCueInterval;
        private GroupBox grpSpeedParam;
        private Label lblCueInterval;
        private Label lblDuration;
        private Label lblExplain1;
        private Label lblExplain2;
        private Label lblExplain3;
        private Label lblMaxSpeed;
        private NumericUpDown numDuration;
        private NumericUpDown numMaxSpeed;
    }
}