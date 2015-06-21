namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;

    public partial class IPAddressTextBox : UserControl
    {

        public IPAddressTextBox()
        {
            this.InitializeComponent();
        }

        public void Clear()
        {
            this.txt1.Text = "";
            this.txt2.Text = "";
            this.txt3.Text = "";
            this.txt4.Text = "";
        }

 private void IPAddressTextBox_Load(object sender, EventArgs e)
        {
            int num = ((this.panel1.Width - (this.label1.Width * 3)) / 4) - 1;
            this.txt1.Width = num;
            this.txt2.Width = num;
            this.txt3.Width = num;
        }

        private void txt_Enter(object sender, EventArgs e)
        {
            ((TextBox) sender).SelectAll();
        }

        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox) sender;
            try
            {
                e.KeyChar.ToString();
                if (((e.KeyChar.ToString() == ".") || (e.KeyChar.ToString() == "。")) || (e.KeyChar.ToString() == " "))
                {
                    if (((box.SelectedText.ToString() == "") && (box.Text.ToString() != "")) && (box.Name != this.txt4.Name))
                    {
                        SendKeys.Send("{Tab}");
                    }
                    e.Handled = true;
                }
                else if (Regex.Match(e.KeyChar.ToString(), "[0-9]").Success)
                {
                    if ((box.Text.Length == 2) && (box.SelectionLength == 0))
                    {
                        box.Text.Insert(box.SelectionStart, e.KeyChar.ToString());
                        if (int.Parse(box.Text.Insert(box.SelectionStart, e.KeyChar.ToString())) > 255)
                        {
                            e.Handled = true;
                        }
                        else if ((box.Text.Length == 2) && (box.Name != this.txt4.Name))
                        {
                            SendKeys.Send("{Tab}");
                        }
                        else
                        {
                            box.Focus();
                        }
                    }
                    if ((box.Text.Length == 3) && (box.SelectionLength == 1))
                    {
                        box.Text.Insert(box.SelectionStart, e.KeyChar.ToString());
                        if (int.Parse(box.Text.Remove(box.SelectionStart, 1).Insert(box.SelectionStart, e.KeyChar.ToString())) > 255)
                        {
                            e.Handled = true;
                        }
                    }
                }
                else if (!(e.KeyChar.ToString() == "\b"))
                {
                    e.Handled = true;
                }
            }
            catch
            {
                e.Handled = true;
            }
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            TextBox box = (TextBox) sender;
            while ((box.Text.Length > 1) && (box.Text.ToString().Substring(0, 1) == "0"))
            {
                box.Text = box.Text.ToString().Remove(0, 1);
            }
        }

        public System.Windows.Forms.BorderStyle BorderStyle
        {
            get
            {
                return this.panel1.BorderStyle;
            }
            set
            {
                try
                {
                    this.panel1.BorderStyle = value;
                }
                catch
                {
                }
            }
        }

        public IPAddress IPaddress
        {
            get
            {
                try
                {
                    return IPAddress.Parse(this.Text.ToString());
                }
                catch
                {
                    return IPAddress.Parse("0.0.0.0");
                }
            }
        }

        public override string Text
        {
            get
            {
                return (this.txt1.Text.ToString().Trim() + "." + this.txt2.Text.ToString().Trim() + "." + this.txt3.Text.ToString().Trim() + "." + this.txt4.Text.ToString().Trim()).Trim(new char[] { '.' });
            }
            set
            {
                try
                {
                    string[] strArray = new string[4];
                    strArray = value.Split(new char[] { char.Parse(".") });
                    for (int i = 0; i < 4; i++)
                    {
                        if ((int.Parse(strArray[i]) > -1) && (int.Parse(strArray[i]) < 256))
                        {
                            this.txt1.Text = strArray[0];
                            this.txt2.Text = strArray[1];
                            this.txt3.Text = strArray[2];
                            this.txt4.Text = strArray[3];
                        }
                    }
                }
                catch
                {
                    this.txt1.Text = "";
                    this.txt2.Text = "";
                    this.txt3.Text = "";
                    this.txt4.Text = "";
                }
            }
        }

        public IPType Type
        {
            get
            {
                if (int.Parse(this.txt1.Text.ToString().Trim()) < 128)
                {
                    return IPType.A;
                }
                if (int.Parse(this.txt1.Text.ToString().Trim()) < 192)
                {
                    return IPType.B;
                }
                if (int.Parse(this.txt1.Text.ToString().Trim()) < 224)
                {
                    return IPType.C;
                }
                return IPType.D;
            }
        }
    }
}

