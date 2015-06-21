namespace Client
{
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class PerformanceView : FixedForm
    {

        public PerformanceView(string sMsg)
        {
            this.InitializeComponent();
            this.rtxtView.Text = sMsg;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnRefreshServer_Click(object sender, EventArgs e)
        {
            this.GetBufferSize();
        }

        private void btnServerBuffer_Click(object sender, EventArgs e)
        {
            this.grpServer.Visible = !this.grpServer.Visible;
            if (this.btnServerBuffer.Text.Contains(">>"))
            {
                this.btnServerBuffer.Text = "服务端<<";
                this.GetBufferSize();
                base.Height = 400;
            }
            else
            {
                this.btnServerBuffer.Text = "服务端>>";
                base.Height = 270;
            }
        }

 private void GetBufferSize()
        {
            string bufferSize = RemotingClient.GetBufferSize();
            if (string.IsNullOrEmpty(bufferSize))
            {
                bufferSize = "应用服务端不支持或获取应用服务端信息出错！";
            }
            this.rtxtServerBuffer.Text = bufferSize;
        }

 private void PerformanceView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                base.Close();
            }
        }

        public void SetViewText(string sMsg)
        {
            this.rtxtView.Text = sMsg;
        }
    }
}

