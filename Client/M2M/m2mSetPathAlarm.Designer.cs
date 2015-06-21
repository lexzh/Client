namespace Client.M2M
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    partial class m2mSetPathAlarm
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
            this.grpSelectRoute = new GroupBox();
            this.clbSelectRoute = new CheckedListBox();
            this.pnlSelectAll = new System.Windows.Forms.Panel();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grpExpand = new GroupBox();
            this.lblLineDis = new System.Windows.Forms.Label();
            this.numLineDis = new NumericUpDown();
            this.lblLineDisRmk = new System.Windows.Forms.Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpSelectRoute.SuspendLayout();
            this.pnlSelectAll.SuspendLayout();
            this.grpExpand.SuspendLayout();
            this.numLineDis.BeginInit();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 359);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpSelectRoute.Controls.Add(this.clbSelectRoute);
            this.grpSelectRoute.Controls.Add(this.pnlSelectAll);
            this.grpSelectRoute.Dock = DockStyle.Top;
            this.grpSelectRoute.Location = new System.Drawing.Point(5, 121);
            this.grpSelectRoute.Margin = new Padding(0);
            this.grpSelectRoute.Name = "grpSelectRoute";
            this.grpSelectRoute.Padding = new Padding(10);
            this.grpSelectRoute.Size = new Size(363, 194);
            this.grpSelectRoute.TabIndex = 1;
            this.grpSelectRoute.TabStop = false;
            this.grpSelectRoute.Text = "选择预设路线名称";
            this.clbSelectRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.clbSelectRoute.CheckOnClick = true;
            this.clbSelectRoute.Dock = DockStyle.Top;
            this.clbSelectRoute.FormattingEnabled = true;
            this.clbSelectRoute.Location = new System.Drawing.Point(10, 24);
            this.clbSelectRoute.Margin = new Padding(10);
            this.clbSelectRoute.Name = "clbSelectRoute";
            this.clbSelectRoute.Size = new Size(343, 130);
            this.clbSelectRoute.TabIndex = 0;
            this.pnlSelectAll.Controls.Add(this.chkSelectAll);
            this.pnlSelectAll.Dock = DockStyle.Bottom;
            this.pnlSelectAll.Location = new System.Drawing.Point(10, 163);
            this.pnlSelectAll.Margin = new Padding(10);
            this.pnlSelectAll.Name = "pnlSelectAll";
            this.pnlSelectAll.Size = new Size(343, 21);
            this.pnlSelectAll.TabIndex = 2;
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(266, 5);
            this.chkSelectAll.Margin = new Padding(0);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new Size(72, 16);
            this.chkSelectAll.TabIndex = 0;
            this.chkSelectAll.Tag = "9999";
            this.chkSelectAll.Text = "全部选择";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new EventHandler(this.chkSelectAll_CheckedChanged);
            this.grpExpand.Controls.Add(this.lblLineDis);
            this.grpExpand.Controls.Add(this.numLineDis);
            this.grpExpand.Controls.Add(this.lblLineDisRmk);
            this.grpExpand.Dock = DockStyle.Top;
            this.grpExpand.Location = new System.Drawing.Point(5, 315);
            this.grpExpand.Name = "grpExpand";
            this.grpExpand.Size = new Size(363, 44);
            this.grpExpand.TabIndex = 3;
            this.grpExpand.TabStop = false;
            this.grpExpand.Text = "扩展功能--设置偏离距离";
            this.lblLineDis.AutoSize = true;
            this.lblLineDis.Location = new System.Drawing.Point(50, 18);
            this.lblLineDis.Name = "lblLineDis";
            this.lblLineDis.Size = new Size(65, 12);
            this.lblLineDis.TabIndex = 5;
            this.lblLineDis.Text = "偏离距离：";
            this.numLineDis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numLineDis.Location = new System.Drawing.Point(122, 14);
            int[] bits = new int[4];
            bits[0] = 65535;
            this.numLineDis.Maximum = new decimal(bits);
            int[] numArray2 = new int[4];
            numArray2[0] = 1;
            this.numLineDis.Minimum = new decimal(numArray2);
            this.numLineDis.Name = "numLineDis";
            this.numLineDis.Size = new Size(161, 21);
            this.numLineDis.TabIndex = 2;
            this.numLineDis.Tag = "";
            int[] numArray3 = new int[4];
            numArray3[0] = 100;
            this.numLineDis.Value = new decimal(numArray3);
            this.lblLineDisRmk.AutoSize = true;
            this.lblLineDisRmk.Location = new System.Drawing.Point(289, 18);
            this.lblLineDisRmk.Name = "lblLineDisRmk";
            this.lblLineDisRmk.Size = new Size(17, 12);
            this.lblLineDisRmk.TabIndex = 7;
            this.lblLineDisRmk.Tag = "；";
            this.lblLineDisRmk.Text = "米";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(373, 392);
            base.Controls.Add(this.grpExpand);
            base.Controls.Add(this.grpSelectRoute);
            base.Name = "m2mSetPathAlarm";
            this.Text = "SetExcursionAlarm";
            base.Load += new EventHandler(this.itmSetPathAlarm_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpSelectRoute, 0);
            base.Controls.SetChildIndex(this.grpExpand, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpSelectRoute.ResumeLayout(false);
            this.pnlSelectAll.ResumeLayout(false);
            this.pnlSelectAll.PerformLayout();
            this.grpExpand.ResumeLayout(false);
            this.grpExpand.PerformLayout();
            this.numLineDis.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private CheckedListBox clbSelectRoute;
        private GroupBox grpExpand;
        private System.Windows.Forms.GroupBox grpSelectRoute;
        private System.Windows.Forms.Label lblLineDis;
        private System.Windows.Forms.Label lblLineDisRmk;
        private NumericUpDown numLineDis;
        private System.Windows.Forms.Panel pnlSelectAll;
    }
}