namespace Client.JTB
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    partial class JTBSetCarNumberAndColor
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
            this.cmbCarColor = new ComboBox();
            this.txtCarNumber = new TextBox();
            this.lblCarNumber = new Label();
            this.lblCarColor = new Label();
            base.grpCar.SuspendLayout();
            base.pnlBtn.SuspendLayout();
            this.grpWatchProperty.SuspendLayout();
            base.SuspendLayout();
            base.pnlBtn.Location = new System.Drawing.Point(5, 195);
            this.grpWatchProperty.Controls.Add(this.cmbCarColor);
            this.grpWatchProperty.Controls.Add(this.txtCarNumber);
            this.grpWatchProperty.Controls.Add(this.lblCarNumber);
            this.grpWatchProperty.Controls.Add(this.lblCarColor);
            this.grpWatchProperty.Dock = DockStyle.Top;
            this.grpWatchProperty.Location = new System.Drawing.Point(5, 121);
            this.grpWatchProperty.Name = "grpWatchProperty";
            this.grpWatchProperty.Size = new Size(363, 74);
            this.grpWatchProperty.TabIndex = 11;
            this.grpWatchProperty.TabStop = false;
            this.grpWatchProperty.Text = "参数设置";
            this.cmbCarColor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCarColor.FormattingEnabled = true;
            this.cmbCarColor.Items.AddRange(new object[] { "蓝色", "黄色", "黑色", "白色", "其他" });
            this.cmbCarColor.Location = new System.Drawing.Point(122, 44);
            this.cmbCarColor.Name = "cmbCarColor";
            this.cmbCarColor.Size = new Size(161, 20);
            this.cmbCarColor.TabIndex = 36;
            this.txtCarNumber.Location = new System.Drawing.Point(122, 16);
            this.txtCarNumber.MaxLength = 20;
            this.txtCarNumber.Name = "txtCarNumber";
            this.txtCarNumber.Size = new Size(161, 21);
            this.txtCarNumber.TabIndex = 35;
            this.txtCarNumber.KeyPress += new KeyPressEventHandler(this.txtCarNumber_KeyPress);
            this.lblCarNumber.AutoSize = true;
            this.lblCarNumber.Location = new System.Drawing.Point(62, 19);
            this.lblCarNumber.Name = "lblCarNumber";
            this.lblCarNumber.Size = new Size(53, 12);
            this.lblCarNumber.TabIndex = 33;
            this.lblCarNumber.Text = "车牌号：";
            this.lblCarColor.AutoSize = true;
            this.lblCarColor.Location = new System.Drawing.Point(50, 46);
            this.lblCarColor.Name = "lblCarColor";
            this.lblCarColor.Size = new Size(65, 12);
            this.lblCarColor.TabIndex = 34;
            this.lblCarColor.Text = "车牌颜色：";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(373, 228);
            base.Controls.Add(this.grpWatchProperty);
            base.Name = "JTBSetCarNumberAndColor";
            this.Text = "JTBSetCarNumberAndColor";
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
        private ComboBox cmbCarColor;
        private System.Windows.Forms.GroupBox grpWatchProperty;
        private Label lblCarColor;
        private Label lblCarNumber;
        private TextBox txtCarNumber;
    }
}