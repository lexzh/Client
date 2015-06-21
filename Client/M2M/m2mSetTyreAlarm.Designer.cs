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

    partial class m2mSetTyreAlarm
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
            this.grpPressure = new GroupBox();
            this.lblPressure = new Label();
            this.numPressure = new NumericUpDown();
            this.lblKpa = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpPressure.SuspendLayout();
            this.numPressure.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 174);
            base.pnlBtn.TabIndex = 3;
            this.grpPressure.Controls.Add(this.lblPressure);
            this.grpPressure.Controls.Add(this.numPressure);
            this.grpPressure.Controls.Add(this.lblKpa);
            this.grpPressure.Dock = DockStyle.Top;
            this.grpPressure.Location = new System.Drawing.Point(5, 121);
            this.grpPressure.Name = "grpPressure";
            this.grpPressure.Size = new Size(363, 53);
            this.grpPressure.TabIndex = 1;
            this.grpPressure.TabStop = false;
            this.lblPressure.AutoSize = true;
            this.lblPressure.Location = new System.Drawing.Point(50, 23);
            this.lblPressure.Name = "lblPressure";
            this.lblPressure.Size = new Size(65, 12);
            this.lblPressure.TabIndex = 0;
            this.lblPressure.Text = "压力阈值：";
            this.numPressure.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numPressure.Location = new System.Drawing.Point(122, 19);
            int[] bits = new int[4];
            bits[0] = -1;
            this.numPressure.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numPressure.Minimum = new decimal(numArray2);
            this.numPressure.Name = "numPressure";
            this.numPressure.Size = new Size(161, 21);
            this.numPressure.TabIndex = 0;
            int[] numArray3 = new int[4];
            numArray3[0] = 1;
            this.numPressure.Value = new decimal(numArray3);
            this.lblKpa.AutoSize = true;
            this.lblKpa.Location = new System.Drawing.Point(289, 23);
            this.lblKpa.Name = "lblKpa";
            this.lblKpa.Size = new Size(29, 12);
            this.lblKpa.TabIndex = 0;
            this.lblKpa.Tag = "；";
            this.lblKpa.Text = "千帕";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 207);
            base.Controls.Add(this.grpPressure);
            base.Name = "m2mSetTyreAlarm";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.m2mSetTyreAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpPressure, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpPressure.ResumeLayout(false);
            this.grpPressure.PerformLayout();
            this.numPressure.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpPressure;
        private Label lblKpa;
        private Label lblPressure;
        private NumericUpDown numPressure;
    }
}