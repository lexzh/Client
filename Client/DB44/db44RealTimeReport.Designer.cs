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

    partial class db44RealTimeReport
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
            new ComponentResourceManager(typeof(db44RealTimeReport));
            this.grpWatchProperty = new GroupBox();
            this.lblWatchType = new Label();
            this.cmbWatchType = new ComBox();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.grpCar.TabIndex = 0;
            base.cmbType.TabIndex = 1;
            base.txtPassword.TabIndex = 5;
            base.txtCarNo.TabIndex = 3;
            base.lblPassword.TabIndex = 4;
            base.lblValue.TabIndex = 2;
            base.lblType.TabIndex = 0;
            base.pnlBtn.Location = new System.Drawing.Point(5, 168);
            base.pnlBtn.TabIndex = 2;
            base.btnCancel.TabIndex = 1;
            base.btnOK.TabIndex = 0;
            this.grpWatchProperty.Controls.Add(this.lblWatchType);
            this.grpWatchProperty.Controls.Add(this.cmbWatchType);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 47);
            this.grpWatchProperty.TabIndex = 1;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "监控属性";
            this.lblWatchType.AutoSize = true;
            this.lblWatchType.Location = new System.Drawing.Point(50, 20);
            this.lblWatchType.Name = "lblWatchType";
            this.lblWatchType.Size = new Size(65, 12);
            this.lblWatchType.TabIndex = 0;
            this.lblWatchType.Text = "监控方式：";
            this.cmbWatchType.DisplayMember = "Display";
            this.cmbWatchType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbWatchType.FlatStyle = FlatStyle.Flat;
            this.cmbWatchType.Location = new System.Drawing.Point(122, 16);
            this.cmbWatchType.Name = "cmbWatchType";
            this.cmbWatchType.Size = new Size(161, 20);
            this.cmbWatchType.TabIndex = 1;
            this.cmbWatchType.Tag = "；";
            this.cmbWatchType.ValueMember = "Value";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            this.AutoSize = true;
            base.ClientSize = new Size(373, 201);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "db44RealTimeReport";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.db44RealTimeReport_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private ComBox cmbWatchType;
        private GroupBox grpWatchProperty;
        private Label lblWatchType;
    }
}