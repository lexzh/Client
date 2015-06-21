namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class itmSetOilAlarm
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
            this.grpOilParam = new GroupBox();
            this.lblExplain1 = new Label();
            this.lblOilCubage = new Label();
            this.txtOilCubage = new TextBox();
            this.lblLitre = new Label();
            this.lblAlarmCubage = new Label();
            this.numAlarmCubage = new NumericUpDown();
            this.lblLitre2 = new Label();
            this.lblDuration = new Label();
            this.numDuration = new NumericUpDown();
            this.lblSecond = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpOilParam.SuspendLayout();
            this.numAlarmCubage.BeginInit();
            this.numDuration.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 249);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpOilParam.Controls.Add(this.lblExplain1);
            this.grpOilParam.Controls.Add(this.lblOilCubage);
            this.grpOilParam.Controls.Add(this.txtOilCubage);
            this.grpOilParam.Controls.Add(this.lblLitre);
            this.grpOilParam.Controls.Add(this.lblAlarmCubage);
            this.grpOilParam.Controls.Add(this.numAlarmCubage);
            this.grpOilParam.Controls.Add(this.lblLitre2);
            this.grpOilParam.Controls.Add(this.lblDuration);
            this.grpOilParam.Controls.Add(this.numDuration);
            this.grpOilParam.Controls.Add(this.lblSecond);
            this.grpOilParam.Dock = DockStyle.Top;
            this.grpOilParam.Location = new System.Drawing.Point(5, 121);
            this.grpOilParam.Name = "grpOilParam";
            this.grpOilParam.Size = new Size(363, 128);
            this.grpOilParam.TabIndex = 1;
            this.grpOilParam.TabStop = false;
            this.grpOilParam.Text = "油量报警参数";
            this.lblExplain1.AutoSize = true;
            this.lblExplain1.Location = new System.Drawing.Point(120, 46);
            this.lblExplain1.Name = "lblExplain1";
            this.lblExplain1.Size = new Size(137, 12);
            this.lblExplain1.TabIndex = 25;
            this.lblExplain1.Tag = "9999";
            this.lblExplain1.Text = "(多车时为最小油箱容积)";
            this.lblOilCubage.AutoSize = true;
            this.lblOilCubage.Location = new System.Drawing.Point(50, 23);
            this.lblOilCubage.Name = "lblOilCubage";
            this.lblOilCubage.Size = new Size(65, 12);
            this.lblOilCubage.TabIndex = 22;
            this.lblOilCubage.Text = "油箱容积：";
            this.txtOilCubage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOilCubage.Location = new System.Drawing.Point(122, 20);
            this.txtOilCubage.Name = "txtOilCubage";
            this.txtOilCubage.ReadOnly = true;
            this.txtOilCubage.Size = new Size(161, 21);
            this.txtOilCubage.TabIndex = 0;
            this.lblLitre.AutoSize = true;
            this.lblLitre.Location = new System.Drawing.Point(288, 23);
            this.lblLitre.Name = "lblLitre";
            this.lblLitre.Size = new Size(17, 12);
            this.lblLitre.TabIndex = 27;
            this.lblLitre.Tag = "；";
            this.lblLitre.Text = "升";
            this.lblAlarmCubage.AutoSize = true;
            this.lblAlarmCubage.Location = new System.Drawing.Point(50, 65);
            this.lblAlarmCubage.Name = "lblAlarmCubage";
            this.lblAlarmCubage.Size = new Size(65, 12);
            this.lblAlarmCubage.TabIndex = 20;
            this.lblAlarmCubage.Text = "报警阈值：";
            this.numAlarmCubage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numAlarmCubage.Location = new System.Drawing.Point(122, 63);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numAlarmCubage.Maximum = new decimal(bits);
            this.numAlarmCubage.Name = "numAlarmCubage";
            this.numAlarmCubage.Size = new Size(161, 21);
            this.numAlarmCubage.TabIndex = 1;
            this.lblLitre2.AutoSize = true;
            this.lblLitre2.Location = new System.Drawing.Point(288, 65);
            this.lblLitre2.Name = "lblLitre2";
            this.lblLitre2.Size = new Size(17, 12);
            this.lblLitre2.TabIndex = 25;
            this.lblLitre2.Tag = "；";
            this.lblLitre2.Text = "升";
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(50, 93);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new Size(65, 12);
            this.lblDuration.TabIndex = 21;
            this.lblDuration.Text = "持续时间：";
            this.numDuration.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numDuration.Location = new System.Drawing.Point(121, 91);
            int[] numArray2 = new int[4];
            numArray2[0] = 65535;
            this.numDuration.Maximum = new decimal(numArray2);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new Size(161, 21);
            this.numDuration.TabIndex = 2;
            this.lblSecond.AutoSize = true;
            this.lblSecond.Location = new System.Drawing.Point(288, 93);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new Size(17, 12);
            this.lblSecond.TabIndex = 26;
            this.lblSecond.Tag = "；";
            this.lblSecond.Text = "秒";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 282);
            base.Controls.Add(this.grpOilParam);
            base.Name = "itmSetOilAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmSetOilAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpOilParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpOilParam.ResumeLayout(false);
            this.grpOilParam.PerformLayout();
            this.numAlarmCubage.EndInit();
            this.numDuration.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpOilParam;
        private Label lblAlarmCubage;
        private Label lblDuration;
        private Label lblExplain1;
        private Label lblLitre;
        private Label lblLitre2;
        private Label lblOilCubage;
        private Label lblSecond;
        private NumericUpDown numAlarmCubage;
        private NumericUpDown numDuration;
        private TextBox txtOilCubage;
    }
}