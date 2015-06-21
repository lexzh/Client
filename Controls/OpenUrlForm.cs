namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    internal partial class OpenUrlForm : Form
    {

        public OpenUrlForm()
        {
            this.InitializeComponent();
        }

 private void okButton_Click(object sender, EventArgs e)
        {
            Uri uri = null;
            try
            {
                uri = new Uri(this.addressTextBox.Text);
            }
            catch (UriFormatException)
            {
            }
            if (uri == null)
            {
                try
                {
                    uri = new Uri("http://" + this.addressTextBox.Text);
                }
                catch (UriFormatException)
                {
                }
                if (uri == null)
                {
                    this.invalidAddressLabel.Visible = true;
                    return;
                }
            }
            if (((uri.Scheme == "http") || (uri.Scheme == "https")) || (uri.Scheme == "file"))
            {
                this._url = uri;
                base.DialogResult = DialogResult.OK;
                base.Close();
            }
            else
            {
                this.invalidAddressLabel.Visible = false;
            }
        }

        private void OpenUrlForm_Load(object sender, EventArgs e)
        {
            this.invalidAddressLabel.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.invalidAddressLabel.Visible = false;
        }

        public Uri Url
        {
            get
            {
                return this._url;
            }
        }
    }
}

