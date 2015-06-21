namespace Client.JTB.MonitoringPlatform
{
    using Client;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class JTBCallPoliceSuperviseReponsion : SizableForm
    {
        private string _content = "";
        private string _discript = "";
        private string _repid = "";
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBCallPoliceSuperviseReponsion(CmdParam.OrderCode OrderCode, string ReponseID, string CarNum)
        {
            this.InitializeComponent();

            string[] strArray6 = ReponseID.ToString().Replace("报警督办ID：", "").Split(new char[] { ',' });

            for (int i = 1; i < strArray6.Length; i++)
            {
                txtDetails.AppendText(strArray6[i] + "\r\n");
            }
            this.OrderCode = OrderCode;
            this.Text = OrderCode.ToString();
            //this._repid = ReponseID;
            this._repid = strArray6[0];
            this._carNum = CarNum;
            this.cmbResolve.SelectedIndex = 0;
            DataRow[] rowArray = MainForm.myCarList.AllCar.Select("CarNum='" + CarNum + "'");
            this.txtCarNum.Text = CarNum;
            if ((rowArray != null) && (rowArray.Length > 0))
            {
                this.txtSimNum.Text = rowArray[0]["SimNum"].ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.getParam())
            {
                this.reResult = RemotingClient.Car_CommandParameterInsterToDB(CmdParam.ParamType.CarNum, this._carNum, "", this.m_SimpleCmd, this._content, this._discript);
                if (this.reResult.ResultCode != 0L)
                {
                    MessageBox.Show(this.reResult.ErrorMsg);
                }
                else
                {
                    base.Close();
                }
            }
        }

        private string convertStringToBase16String(int s)
        {
            string str = "";
            byte[] bytes = BitConverter.GetBytes(s);
            for (int i = bytes.Length - 1; i >= 0; i--)
            {
                str = str + bytes[i].ToString("X2");
            }
            return str;
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = this.OrderCode;
            this._content = this.convertStringToBase16String(Convert.ToInt32(this._repid));
            this._discript = "车牌号：" + this.txtCarNum.Text + "  手机号码：" + this.txtSimNum.Text + "  处理情况：" + this.cmbResolve.SelectedItem.ToString();
            if (this.cmbResolve.SelectedIndex == 0)
            {
                this._content = this._content + "00";
            }
            else if (this.cmbResolve.SelectedIndex == 1)
            {
                this._content = this._content + "01";
            }
            else if (this.cmbResolve.SelectedIndex == 2)
            {
                this._content = this._content + "02";
            }
            else if (this.cmbResolve.SelectedIndex == 3)
            {
                this._content = this._content + "03";
            }
            return true;
        }


    }
}