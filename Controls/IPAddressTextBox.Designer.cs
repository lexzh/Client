namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    partial class IPAddressTextBox
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
            this.panel1 = new Panel();
            this.txt4 = new TextBox();
            this.label2 = new Label();
            this.txt3 = new TextBox();
            this.label3 = new Label();
            this.txt2 = new TextBox();
            this.label1 = new Label();
            this.txt1 = new TextBox();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt3);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt1);
            this.panel1.Dock = DockStyle.Fill;
            this.panel1.Location = new Point(0, 0);
            this.panel1.Margin = new Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new Padding(2);
            this.panel1.Size = new Size(126, 21);
            this.panel1.TabIndex = 11;
            this.txt4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt4.Dock = DockStyle.Fill;
            this.txt4.Font = new Font("宋体", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.txt4.Location = new Point(102, 2);
            this.txt4.Margin = new Padding(0);
            this.txt4.MaxLength = 3;
            this.txt4.Name = "txt4";
            this.txt4.Size = new Size(20, 15);
            this.txt4.TabIndex = 13;
            this.txt4.Tag = "9999";
            this.txt4.TextAlign = HorizontalAlignment.Center;
            this.txt4.Leave += new EventHandler(this.txt_Leave);
            this.txt4.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
            this.txt4.Enter += new EventHandler(this.txt_Enter);
            this.label2.BackColor = SystemColors.Window;
            this.label2.Dock = DockStyle.Left;
            this.label2.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label2.Location = new Point(92, 2);
            this.label2.Margin = new Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new Size(10, 15);
            this.label2.TabIndex = 15;
            this.label2.Tag = "9999";
            this.label2.Text = ".";
            this.label2.TextAlign = ContentAlignment.MiddleLeft;
            this.txt3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt3.Dock = DockStyle.Left;
            this.txt3.Font = new Font("宋体", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.txt3.Location = new Point(68, 2);
            this.txt3.Margin = new Padding(0);
            this.txt3.MaxLength = 3;
            this.txt3.Name = "txt3";
            this.txt3.Size = new Size(24, 15);
            this.txt3.TabIndex = 12;
            this.txt3.Tag = "9999";
            this.txt3.TextAlign = HorizontalAlignment.Center;
            this.txt3.Leave += new EventHandler(this.txt_Leave);
            this.txt3.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
            this.txt3.Enter += new EventHandler(this.txt_Enter);
            this.label3.BackColor = SystemColors.Window;
            this.label3.Dock = DockStyle.Left;
            this.label3.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label3.Location = new Point(58, 2);
            this.label3.Margin = new Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new Size(10, 15);
            this.label3.TabIndex = 16;
            this.label3.Tag = "9999";
            this.label3.Text = ".";
            this.label3.TextAlign = ContentAlignment.MiddleLeft;
            this.txt2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt2.Dock = DockStyle.Left;
            this.txt2.Font = new Font("宋体", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.txt2.Location = new Point(34, 2);
            this.txt2.Margin = new Padding(0);
            this.txt2.MaxLength = 3;
            this.txt2.Name = "txt2";
            this.txt2.Size = new Size(24, 15);
            this.txt2.TabIndex = 11;
            this.txt2.Tag = "9999";
            this.txt2.TextAlign = HorizontalAlignment.Center;
            this.txt2.Leave += new EventHandler(this.txt_Leave);
            this.txt2.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
            this.txt2.Enter += new EventHandler(this.txt_Enter);
            this.label1.BackColor = SystemColors.Window;
            this.label1.Dock = DockStyle.Left;
            this.label1.Font = new Font("宋体", 10f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.label1.Location = new Point(24, 2);
            this.label1.Margin = new Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(10, 15);
            this.label1.TabIndex = 14;
            this.label1.Tag = "9999";
            this.label1.Text = ".";
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.txt1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt1.Dock = DockStyle.Left;
            this.txt1.Font = new Font("宋体", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 134);
            this.txt1.Location = new Point(2, 2);
            this.txt1.Margin = new Padding(0);
            this.txt1.MaxLength = 3;
            this.txt1.Name = "txt1";
            this.txt1.Size = new Size(22, 15);
            this.txt1.TabIndex = 10;
            this.txt1.Tag = "9999";
            this.txt1.TextAlign = HorizontalAlignment.Center;
            this.txt1.Leave += new EventHandler(this.txt_Leave);
            this.txt1.KeyPress += new KeyPressEventHandler(this.txt_KeyPress);
            this.txt1.Enter += new EventHandler(this.txt_Enter);
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            base.Controls.Add(this.panel1);
            base.Margin = new Padding(0);
            base.Name = "IPAddressTextBox";
            base.Size = new Size(126, 21);
            base.Load += new EventHandler(this.IPAddressTextBox_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private Label label1;
        private Label label2;
        private Label label3;
        private Panel panel1;
        private TextBox txt1;
        private TextBox txt2;
        private TextBox txt3;
        private TextBox txt4;
    }
}