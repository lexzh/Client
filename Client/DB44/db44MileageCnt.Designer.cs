namespace Client.DB44
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    partial class db44MileageCnt
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
            new ComponentResourceManager(typeof(db44MileageCnt));
            this.grpViewType = new GroupBox();
            this.lblViewType = new Label();
            this.cmbViewType = new ComBox();
            this.grpParam = new GroupBox();
            this.lblParam = new Label();
            this.numParam = new NumericUpDown();
            this.lblParamMeter = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpViewType.SuspendLayout();
            this.grpParam.SuspendLayout();
            this.numParam.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 229);
            this.grpViewType.Controls.Add(this.lblViewType);
            this.grpViewType.Controls.Add(this.cmbViewType);
            this.grpViewType.Dock = DockStyle.Top;
            this.grpViewType.Location = new System.Drawing.Point(5, 121);
            this.grpViewType.Name = "grpViewType";
            this.grpViewType.Size = new Size(363, 54);
            this.grpViewType.TabIndex = 13;
            this.grpViewType.TabStop = false;
            this.grpViewType.Text = "参数";
            this.lblViewType.AutoSize = true;
            this.lblViewType.Location = new System.Drawing.Point(50, 24);
            this.lblViewType.Name = "lblViewType";
            this.lblViewType.Size = new Size(65, 12);
            this.lblViewType.TabIndex = 2;
            this.lblViewType.Text = "查询类型：";
            this.cmbViewType.DisplayMember = "Display";
            this.cmbViewType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbViewType.FlatStyle = FlatStyle.Flat;
            this.cmbViewType.Location = new System.Drawing.Point(122, 20);
            this.cmbViewType.Name = "cmbViewType";
            this.cmbViewType.Size = new Size(161, 20);
            this.cmbViewType.TabIndex = 3;
            this.cmbViewType.Tag = "；";
            this.cmbViewType.ValueMember = "Value";
            this.grpParam.Controls.Add(this.lblParam);
            this.grpParam.Controls.Add(this.numParam);
            this.grpParam.Controls.Add(this.lblParamMeter);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new System.Drawing.Point(5, 175);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 54);
            this.grpParam.TabIndex = 14;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数";
            this.lblParam.AutoSize = true;
            this.lblParam.Location = new System.Drawing.Point(50, 24);
            this.lblParam.Name = "lblParam";
            this.lblParam.Size = new Size(65, 12);
            this.lblParam.TabIndex = 2;
            this.lblParam.Text = "特征系数：";
            this.numParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numParam.Location = new System.Drawing.Point(122, 20);
            int[] bits = new int[4];
            bits[0] = 16777215;
            this.numParam.Maximum = new decimal(bits);
            this.numParam.Name = "numParam";
            this.numParam.Size = new Size(160, 21);
            this.numParam.TabIndex = 3;
            this.numParam.Tag = "；";
            this.lblParamMeter.AutoSize = true;
            this.lblParamMeter.Location = new System.Drawing.Point(278, 24);
            this.lblParamMeter.Name = "lblParamMeter";
            this.lblParamMeter.Size = new Size(83, 12);
            this.lblParamMeter.TabIndex = 6;
            this.lblParamMeter.Tag = "9999";
            this.lblParamMeter.Text = "(0～16777215)";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 262);
            base.Controls.Add(this.grpParam);
            base.Controls.Add(this.grpViewType);
            base.Name = "db44MileageCnt";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.db44MileageCnt_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpViewType, 0);
            base.Controls.SetChildIndex(this.grpParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpViewType.ResumeLayout(false);
            this.grpViewType.PerformLayout();
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            this.numParam.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbViewType;
        private GroupBox grpParam;
        private GroupBox grpViewType;
        private Label lblParam;
        private Label lblParamMeter;
        private Label lblViewType;
        private NumericUpDown numParam;
    }
}