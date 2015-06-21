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

    public partial class JTBSetPictureParam : CarForm
    {
        private TrafficSimpleCmd m_SimpleCmd = new TrafficSimpleCmd();

        public JTBSetPictureParam(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.icar_SetCommonCmdTraffic(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                if (base.reResult.ResultCode != 0L)
                {
                    MessageBox.Show(base.reResult.ErrorMsg);
                }
                else
                {
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            this.m_SimpleCmd.PicQuality = this.trkQuality.Value;
            this.m_SimpleCmd.PicBrightness = this.trkLight.Value;
            this.m_SimpleCmd.PicContrast = this.trkContrast.Value;
            this.m_SimpleCmd.PicSaturation = this.trkSaturation.Value;
            this.m_SimpleCmd.PicChroma = this.trkChroma.Value;
            return true;
        }

 private void trkChroma_ValueChanged(object sender, EventArgs e)
        {
            this.lblChromaValue.Text = this.trkChroma.Value.ToString();
        }

        private void trkContrast_ValueChanged(object sender, EventArgs e)
        {
            this.lblContrastValue.Text = this.trkContrast.Value.ToString();
        }

        private void trkImageLight_ValueChanged(object sender, EventArgs e)
        {
            this.lblImageLightValue.Text = this.trkLight.Value.ToString();
        }

        private void trkQuality_ValueChanged(object sender, EventArgs e)
        {
            this.lblQualityValue.Text = this.trkQuality.Value.ToString();
        }

        private void trkSaturation_ValueChanged(object sender, EventArgs e)
        {
            this.lblSaturationValue.Text = this.trkSaturation.Value.ToString();
        }
    }
}

