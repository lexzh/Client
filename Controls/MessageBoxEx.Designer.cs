namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class MessageBoxEx
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
            this.label1 = new Label();
            this.panel4 = new Panel();
            this.pictureBox1 = new PictureBox();
            this.panel1 = new Panel();
            this.panel2 = new Panel();
            this.btn2 = new Button();
            this.btn1 = new Button();
            this.btn3 = new Button();
            this.panel3 = new Panel();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((ISupportInitialize) this.pictureBox1).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            base.SuspendLayout();
            this.panel3.AutoSize = true;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = DockStyle.Fill;
            this.panel3.Location = new Point(53, 0);
            this.panel3.MinimumSize = new Size(162, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new Size(162, 61);
            this.panel3.TabIndex = 9;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0, 12);
            this.label1.TabIndex = 3;
            this.label1.TextAlign = ContentAlignment.MiddleLeft;
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Dock = DockStyle.Left;
            this.panel4.Location = new Point(0, 0);
            this.panel4.MinimumSize = new Size(53, 61);
            this.panel4.Name = "panel4";
            this.panel4.Size = new Size(53, 61);
            this.panel4.TabIndex = 10;
            this.pictureBox1.Location = new Point(12, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = DockStyle.Bottom;
            this.panel1.Location = new Point(0, 61);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(215, 47);
            this.panel1.TabIndex = 8;
            this.panel2.BackColor = SystemColors.Control;
            this.panel2.Controls.Add(this.btn2);
            this.panel2.Controls.Add(this.btn1);
            this.panel2.Controls.Add(this.btn3);
            this.panel2.Location = new Point(-1, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new Size(217, 31);
            this.panel2.TabIndex = 0;
            this.btn2.Location = new Point(71, 3);
            this.btn2.Name = "btn2";
            this.btn2.Size = new Size(75, 23);
            this.btn2.TabIndex = 4;
            this.btn2.Text = "重试";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Visible = false;
            this.btn2.Click += new EventHandler(this.button2_Click);
            this.btn1.Location = new Point(35, 3);
            this.btn1.Name = "btn1";
            this.btn1.Size = new Size(75, 23);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "确定";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new EventHandler(this.button1_Click);
            this.btn3.Location = new Point(116, 3);
            this.btn3.Name = "btn3";
            this.btn3.Size = new Size(75, 23);
            this.btn3.TabIndex = 1;
            this.btn3.Text = "取消";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Visible = false;
            this.btn3.Click += new EventHandler(this.button3_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            base.ClientSize = new Size(215, 108);
            base.ControlBox = false;
            base.Controls.Add(this.panel3);
            base.Controls.Add(this.panel4);
            base.Controls.Add(this.panel1);
            base.FormBorderStyle =  System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.MaximizeBox = false;
            base.MinimizeBox = false;
            base.Name = "MessageBoxEx";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = " ";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((ISupportInitialize) this.pictureBox1).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

       
        private IContainer components;
        private MessageBoxButtons _msgbtn;
        private MessageBoxDefaultButton _msgdefaultbtn;
        private MessageBoxIcon _msgico;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox pictureBox1;
    }
}