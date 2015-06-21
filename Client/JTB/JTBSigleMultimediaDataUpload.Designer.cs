namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class JTBSigleMultimediaDataUpload
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
            this.grpWatchProperty = new GroupBox();
            this.cmbSetType = new ComboBox();
            this.lblSetType = new Label();
            this.numMultimediaId = new NumericUpDown();
            this.lblMultimediaId = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            this.numMultimediaId.BeginInit();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 200);
            this.grpWatchProperty.Controls.Add(this.cmbSetType);
            this.grpWatchProperty.Controls.Add(this.lblSetType);
            this.grpWatchProperty.Controls.Add(this.numMultimediaId);
            this.grpWatchProperty.Controls.Add(this.lblMultimediaId);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 79);
            this.grpWatchProperty.TabIndex = 13;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.cmbSetType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSetType.FormattingEnabled = true;
            this.cmbSetType.Items.AddRange(new object[] { "保留", "删除" });
            this.cmbSetType.Location = new System.Drawing.Point(122, 51);
            this.cmbSetType.Name = "cmbSetType";
            this.cmbSetType.Size = new Size(161, 20);
            this.cmbSetType.TabIndex = 64;
            this.lblSetType.AutoSize = true;
            this.lblSetType.Location = new System.Drawing.Point(50, 56);
            this.lblSetType.Name = "lblSetType";
            this.lblSetType.Size = new Size(65, 12);
            this.lblSetType.TabIndex = 63;
            this.lblSetType.Text = "删除标志：";
            this.numMultimediaId.Location = new System.Drawing.Point(122, 20);
            int[] bits = new int[4];
            bits[0] = -1;
            this.numMultimediaId.Maximum = new decimal(bits);
            this.numMultimediaId.Name = "numMultimediaId";
            this.numMultimediaId.Size = new Size(161, 21);
            this.numMultimediaId.TabIndex = 62;
            this.lblMultimediaId.AutoSize = true;
            this.lblMultimediaId.Location = new System.Drawing.Point(50, 25);
            this.lblMultimediaId.Name = "lblMultimediaId";
            this.lblMultimediaId.Size = new Size(65, 12);
            this.lblMultimediaId.TabIndex = 33;
            this.lblMultimediaId.Text = "多媒体ID：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 233);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSigleMultimediaDataUpload";
            this.Text = "位置查询";
            base.Controls.SetChildIndex(base.grpCar, 0);
            base.Controls.SetChildIndex(this.grpWatchProperty, 0);
            base.Controls.SetChildIndex(base.pnlBtn, 0);
            base.grpCar.ResumeLayout(false);
            base.grpCar.PerformLayout();
            base.pnlBtn.ResumeLayout(false);
            this.grpWatchProperty.ResumeLayout(false);
            this.grpWatchProperty.PerformLayout();
            this.numMultimediaId.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    
        private IContainer components;
        private ComboBox cmbSetType;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblMultimediaId;
        private Label lblSetType;
        private NumericUpDown numMultimediaId;
    }
}