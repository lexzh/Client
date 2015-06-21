namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class SetDateTime : FixedForm
    {

        public SetDateTime(string sDateTime)
        {
            this.m_sDateTime = DateTime.Now.ToString();
            this.InitializeComponent();
            if (sDateTime.Length > 0)
            {
                this.m_sDateTime = sDateTime;
            }
        }

        public SetDateTime(string sDateTime, bool isFixedDate) : this(sDateTime)
        {
            if (!isFixedDate)
            {
                this.chkSameTime.Visible = false;
            }
            else
            {
                this.chkSameTime.Checked = true;
                this.chkSameTime.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.m_sDateTime = "";
            base.DialogResult = DialogResult.OK;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string str = "";
            string text = "";
            if (this.chkSameTime.Checked)
            {
                str = "0000-00-00";
            }
            else
            {
                str = this.dtpDate.Text;
            }
            text = this.dtpTime.Text;
            this.m_sDateTime = str + " " + text;
            base.DialogResult = DialogResult.OK;
        }

        private void chkSameTime_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSameTime.Checked)
            {
                this.dtpDate.Enabled = false;
            }
            else
            {
                this.dtpDate.Enabled = true;
            }
        }

 private void SetDateTime_Load(object sender, EventArgs e)
        {
            bool flag = true;
            string[] strArray = this.m_sDateTime.Split(new char[] { ' ' });
            if (strArray[0] == "0000-00-00")
            {
                this.chkSameTime.Checked = true;
            }
            else
            {
                try
                {
                    this.dtpDate.Value = DateTime.Parse(strArray[0]);
                }
                catch
                {
                    flag = false;
                    MessageBox.Show("日期格式不正确！");
                }
            }
            if (flag)
            {
                try
                {
                    this.dtpTime.Value = DateTime.Parse(strArray[1]);
                }
                catch
                {
                    MessageBox.Show("时间格式不正确！");
                }
            }
        }

        public string Time
        {
            get
            {
                return this.m_sDateTime;
            }
            set
            {
                this.m_sDateTime = value;
            }
        }
    }
}

