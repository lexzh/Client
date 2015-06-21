namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.Bussiness;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    partial class itmZBNavigation
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
            this.grpParam = new GroupBox();
            this.txtLonLat = new TextBox();
            this.lblLonLat = new Label();
            this.txtDestinationName = new TextBox();
            this.lblDestinationName = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpParam.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new Point(5, 197);
            this.grpParam.Controls.Add(this.txtLonLat);
            this.grpParam.Controls.Add(this.lblLonLat);
            this.grpParam.Controls.Add(this.txtDestinationName);
            this.grpParam.Controls.Add(this.lblDestinationName);
            this.grpParam.Dock = DockStyle.Top;
            this.grpParam.Location = new Point(5, 121);
            this.grpParam.Name = "grpParam";
            this.grpParam.Size = new Size(363, 76);
            this.grpParam.TabIndex = 11;
            this.grpParam.TabStop = false;
            this.grpParam.Text = "参数";
            this.txtLonLat.Location = new Point(122, 20);
            this.txtLonLat.Name = "txtLonLat";
            this.txtLonLat.ReadOnly = true;
            this.txtLonLat.Size = new Size(161, 21);
            this.txtLonLat.TabIndex = 1;
            this.txtLonLat.Tag = "9999";
            this.lblLonLat.AutoSize = true;
            this.lblLonLat.Location = new Point(62, 23);
            this.lblLonLat.Name = "lblLonLat";
            this.lblLonLat.Size = new Size(53, 12);
            this.lblLonLat.TabIndex = 0;
            this.lblLonLat.Text = "经纬度：";
            this.txtDestinationName.Location = new Point(122, 47);
            this.txtDestinationName.MaxLength = 20;
            this.txtDestinationName.Name = "txtDestinationName";
            this.txtDestinationName.Size = new Size(161, 21);
            this.txtDestinationName.TabIndex = 1;
            this.lblDestinationName.AutoSize = true;
            this.lblDestinationName.Location = new Point(38, 51);
            this.lblDestinationName.Name = "lblDestinationName";
            this.lblDestinationName.Size = new Size(77, 12);
            this.lblDestinationName.TabIndex = 0;
            this.lblDestinationName.Text = "目的地名称：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.ClientSize = new Size(373, 230);
            base.Controls.Add(this.grpParam);
            base.Name = "itmZBNavigation";
            this.Text = "位置查询";
            base.Load += new EventHandler(this.itmScreenMess_Load);
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpParam, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpParam.ResumeLayout(false);
            this.grpParam.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private GroupBox grpParam;
        private Label lblDestinationName;
        private Label lblLonLat;
        private TextBox txtDestinationName;
        private TextBox txtLonLat;
    }
}