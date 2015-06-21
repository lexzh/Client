namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class MessageBoxEx : Form
    {

        private MessageBoxEx()
        {
            this._msgico = MessageBoxIcon.Asterisk;
            this.InitializeComponent();
        }

        private MessageBoxEx(string text) : this(text, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3)
        {
        }

        private MessageBoxEx(string text, string title) : this(text, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3)
        {
        }

        private MessageBoxEx(string text, string title, MessageBoxButtons button) : this(text, title, button, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button3)
        {
        }

        private MessageBoxEx(string text, string title, MessageBoxButtons button, MessageBoxIcon ico) : this(text, title, button, ico, MessageBoxDefaultButton.Button3)
        {
        }

        private MessageBoxEx(string text, string title, MessageBoxButtons button, MessageBoxIcon ico, MessageBoxDefaultButton defaultbtn) : this()
        {
            this.Text = (title.Trim().Length == 0) ? " " : title;
            this.label1.Text = text;
            this._msgbtn = button;
            this._msgico = ico;
            this._msgdefaultbtn = defaultbtn;
            this.init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this._msgbtn == MessageBoxButtons.YesNo)
            {
                base.DialogResult = DialogResult.Yes;
            }
            else if (this._msgbtn == MessageBoxButtons.OKCancel)
            {
                base.DialogResult = DialogResult.OK;
            }
            else if (this._msgbtn == MessageBoxButtons.RetryCancel)
            {
                base.DialogResult = DialogResult.Retry;
            }
            else if (this._msgbtn == MessageBoxButtons.OK)
            {
                base.DialogResult = DialogResult.OK;
            }
            else if (this._msgbtn == MessageBoxButtons.YesNoCancel)
            {
                base.DialogResult = DialogResult.Yes;
            }
            else if (this._msgbtn == MessageBoxButtons.AbortRetryIgnore)
            {
                base.DialogResult = DialogResult.Abort;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this._msgbtn == MessageBoxButtons.YesNo)
            {
                base.DialogResult = DialogResult.No;
            }
            else if (this._msgbtn == MessageBoxButtons.OKCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else if (this._msgbtn == MessageBoxButtons.RetryCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else if (this._msgbtn == MessageBoxButtons.OK)
            {
                base.DialogResult = DialogResult.OK;
            }
            else if (this._msgbtn == MessageBoxButtons.YesNoCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else if (this._msgbtn == MessageBoxButtons.AbortRetryIgnore)
            {
                base.DialogResult = DialogResult.Ignore;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this._msgbtn == MessageBoxButtons.YesNo)
            {
                base.DialogResult = DialogResult.No;
            }
            else if (this._msgbtn == MessageBoxButtons.OKCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else if (this._msgbtn == MessageBoxButtons.RetryCancel)
            {
                base.DialogResult = DialogResult.Cancel;
            }
            else if (this._msgbtn == MessageBoxButtons.OK)
            {
                base.DialogResult = DialogResult.OK;
            }
            else if (this._msgbtn == MessageBoxButtons.YesNoCancel)
            {
                base.DialogResult = DialogResult.No;
            }
            else if (this._msgbtn == MessageBoxButtons.AbortRetryIgnore)
            {
                base.DialogResult = DialogResult.Retry;
            }
        }

 private void init()
        {
            Bitmap bitmap = null;
            if (this._msgico == MessageBoxIcon.Asterisk)
            {
                bitmap = SystemIcons.Asterisk.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Hand)
            {
                bitmap = SystemIcons.Error.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Exclamation)
            {
                bitmap = SystemIcons.Exclamation.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Hand)
            {
                bitmap = SystemIcons.Hand.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Asterisk)
            {
                bitmap = SystemIcons.Information.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Question)
            {
                bitmap = SystemIcons.Question.ToBitmap();
            }
            else if (this._msgico == MessageBoxIcon.Exclamation)
            {
                bitmap = SystemIcons.Warning.ToBitmap();
            }
            else
            {
                bitmap = new Bitmap(32, 32);
            }
            this.pictureBox1.BackgroundImage = bitmap;
            if (this._msgbtn == MessageBoxButtons.YesNo)
            {
                this.btn1.Visible = this.btn3.Visible = true;
                this.btn1.Text = "是";
                this.btn3.Text = "否";
                this.btn2.Visible = false;
            }
            else if (this._msgbtn == MessageBoxButtons.OKCancel)
            {
                this.btn1.Visible = this.btn3.Visible = true;
                this.btn1.Text = "确定";
                this.btn3.Text = "取消";
                this.btn2.Visible = false;
            }
            else if (this._msgbtn == MessageBoxButtons.RetryCancel)
            {
                this.btn1.Visible = this.btn3.Visible = true;
                this.btn1.Text = "重试";
                this.btn3.Text = "取消";
                this.btn2.Visible = false;
            }
            else if (this._msgbtn == MessageBoxButtons.OK)
            {
                this.btn1.Visible = true;
                this.btn1.Text = "确定";
                this.btn2.Visible = this.btn3.Visible = false;
            }
            else if (this._msgbtn == MessageBoxButtons.YesNoCancel)
            {
                this.btn1.Visible = this.btn3.Visible = this.btn2.Visible = true;
                this.btn1.Text = "是";
                this.btn2.Text = "否";
                this.btn3.Text = "取消";
            }
            else if (this._msgbtn == MessageBoxButtons.AbortRetryIgnore)
            {
                this.btn1.Visible = this.btn3.Visible = this.btn2.Visible = true;
                this.btn1.Text = "中止";
                this.btn2.Text = "重试";
                this.btn3.Text = "忽略";
            }
            if ((this._msgbtn == MessageBoxButtons.YesNoCancel) || (this._msgbtn == MessageBoxButtons.AbortRetryIgnore))
            {
                this.panel2.Width = 250;
                if (base.Width < this.panel2.Width)
                {
                    base.Width = 310;
                }
                this.btn1.Left = 15;
                this.btn3.Left = (this.btn1.Width + this.btn3.Width) + 25;
                this.btn2.Left = this.btn1.Width + 20;
                if (this._msgdefaultbtn == MessageBoxDefaultButton.Button1)
                {
                    this.btn1.Focus();
                }
                else if (this._msgdefaultbtn == MessageBoxDefaultButton.Button2)
                {
                    this.btn3.Focus();
                }
                else if (this._msgdefaultbtn == MessageBoxDefaultButton.Button3)
                {
                    this.btn2.Focus();
                }
            }
            else if (this._msgbtn == MessageBoxButtons.OK)
            {
                this.btn1.Left = (this.panel2.Width - this.btn1.Width) / 2;
                this.btn1.Focus();
            }
            else if (this._msgdefaultbtn == MessageBoxDefaultButton.Button1)
            {
                this.btn1.Focus();
            }
            else if (this._msgdefaultbtn == MessageBoxDefaultButton.Button2)
            {
                this.btn3.Focus();
            }
            this.panel2.Left = (base.Width - this.panel2.Width) / 2;
        }

 public static DialogResult Show(string text)
        {
            return new MessageBoxEx(text).ShowDialog();
        }

        public static DialogResult Show(string text, string title)
        {
            return new MessageBoxEx(text, title).ShowDialog();
        }

        public static DialogResult Show(string text, string title, MessageBoxButtons button)
        {
            return new MessageBoxEx(text, title, button).ShowDialog();
        }

        public static DialogResult Show(string text, string title, MessageBoxButtons button, MessageBoxIcon ico)
        {
            return new MessageBoxEx(text, title, button, ico).ShowDialog();
        }

        public static DialogResult Show(string text, string title, MessageBoxButtons button, MessageBoxIcon ico, MessageBoxDefaultButton defaultbtn)
        {
            return new MessageBoxEx(text, title, button, ico, defaultbtn).ShowDialog();
        }
    }
}

