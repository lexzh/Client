namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class itmSetOilRefValue : CarForm
    {
        private DataTable m_dtOilBox = new DataTable();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public itmSetOilRefValue(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            string str = "";
            string str2 = "";
            int count = 0;
            if (this.dgvOilReference.Rows[0].Cells[1].Value.Equals(""))
            {
                MessageBox.Show("油箱参考值信息不完整");
                return false;
            }
            int num2 = (int.Parse(this.m_dtOilBox.Rows[0]["PowerType"].ToString()) / 12) - 1;
            if (num2 < 0)
            {
                num2 = 0;
            }
            if ((num2 != 0) && (num2 != 1))
            {
                MessageBox.Show("电瓶类型错误");
                return false;
            }
            this.m_SimpleCmd.PowerType = byte.Parse(num2.ToString());
            this.m_SimpleCmd.EmptyAD = int.Parse(this.m_dtOilBox.Rows[0]["EmptyAD"].ToString()) * 100;
            this.m_SimpleCmd.FullAD = int.Parse(this.m_dtOilBox.Rows[0]["FullAD"].ToString()) * 100;
            this.m_SimpleCmd.OilBoxVol = int.Parse(this.m_dtOilBox.Rows[0]["OilBoxVol"].ToString()) * 100;
            count = this.m_dtOilBox.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                str = str + this.m_dtOilBox.Rows[i]["Percentage"].ToString() + ",";
                str2 = str2 + this.m_dtOilBox.Rows[i]["AD"].ToString() + ",";
            }
            this.m_SimpleCmd.RefCount = this.m_dtOilBox.Rows.Count;
            this.m_SimpleCmd.RefPercentage = str.Trim(new char[] { ',' });
            this.m_SimpleCmd.RefAD = str2.Trim(new char[] { ',' });
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            return true;
        }

 private void itmSetOilRefValue_Load(object sender, EventArgs e)
        {
            this.setGridView();
        }

        private void setGridView()
        {
            string str = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            int count = 0;
            this.m_dtOilBox = RemotingClient.CarOil_GetOilBoxInfo(base.sCarId);
            if ((this.m_dtOilBox == null) || (this.m_dtOilBox.Rows.Count <= 0))
            {
                MessageBox.Show("获取油箱检测参考值失败");
            }
            else
            {
                str = this.m_dtOilBox.Rows[0]["EmptyAD"].ToString();
                str2 = this.m_dtOilBox.Rows[0]["FullAD"].ToString();
                str3 = this.m_dtOilBox.Rows[0]["PowerType"].ToString();
                str4 = this.m_dtOilBox.Rows[0]["OilBoxVol"].ToString();
                count = this.m_dtOilBox.Rows.Count;
            }
            int num2 = 0;
            this.dgvOilReference.Rows.Add();
            this.dgvOilReference.Rows[num2].Cells[0].Value = "电瓶类型(V)";
            this.dgvOilReference.Rows[num2].Cells[1].Value = str3;
            num2++;
            this.dgvOilReference.Rows.Add();
            this.dgvOilReference.Rows[num2].Cells[0].Value = "油箱总容积(升)";
            this.dgvOilReference.Rows[num2].Cells[1].Value = str4;
            num2++;
            this.dgvOilReference.Rows.Add();
            this.dgvOilReference.Rows[num2].Cells[0].Value = "加油前AD值(V)";
            this.dgvOilReference.Rows[num2].Cells[1].Value = str;
            num2++;
            this.dgvOilReference.Rows.Add();
            this.dgvOilReference.Rows[num2].Cells[0].Value = "加满油后AD值(V)";
            this.dgvOilReference.Rows[num2].Cells[1].Value = str2;
            num2++;
            this.dgvOilReference.Rows.Add();
            this.dgvOilReference.Rows[num2].Cells[0].Value = "参考点个数";
            this.dgvOilReference.Rows[num2].Cells[1].Value = count.ToString();
            num2++;
            for (int i = 1; i < count; i++)
            {
                this.dgvOilReference.Rows.Add();
                this.dgvOilReference.Rows[num2].Cells[0].Value = string.Format("参考点{0}百分比", i.ToString());
                this.dgvOilReference.Rows[num2].Cells[1].Value = this.m_dtOilBox.Rows[i - 1]["Percentage"].ToString();
                num2++;
            }
        }
    }
}

