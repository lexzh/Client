namespace Client.M2M
{
    using Client;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;
    using Library;

    public partial class m2mSetRegionSpeedAlarm : CarForm
    {
        private static string ERRORPATHAlARM = "解析区域失败！";
        private DataTable m_dtRegion = new DataTable();
        private static int m_iSelectCntMax = 64;
        private RegionAlarmList m_RegionAlarmList = new RegionAlarmList();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mSetRegionSpeedAlarm(CmdParam.OrderCode cmdOrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = cmdOrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(base.sValue))
                {
                    this.getParam();
                    if ((this.m_SimpleCmd.CmdParams != null) && (this.m_SimpleCmd.CmdParams.Count != 0))
                    {
                        base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
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
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private bool chkSeletRegion()
        {
            int num = 0;
            foreach (CheckBoxItem item in this.chkListRegion.Items)
            {
                if (item.Checked)
                {
                    num++;
                }
            }
            if (num <= 0)
            {
                MessageBox.Show("没有选择任何区域");
                return false;
            }
            if (num > m_iSelectCntMax)
            {
                MessageBox.Show(string.Format("选择区域个数超过{0}个！", m_iSelectCntMax.ToString()));
                return false;
            }
            return true;
        }

 private void getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            ArrayList list = new ArrayList();
            if (base.OrderCode == CmdParam.OrderCode.区域内超速报警设置)
            {
                string str = this.numSpeed.Value.ToString();
                if ("0".Equals(str))
                {
                    string[] strArray = new string[] { "0", "0", "0", "0" };
                    list.Add(strArray);
                    this.m_SimpleCmd.CmdParams = list;
                    return;
                }
                string str2 = "";
                if (!this.chkSeletRegion())
                {
                    return;
                }
                int num = 1;
                foreach (CheckBoxItem item in this.chkListRegion.Items)
                {
                    if (item.Checked)
                    {
                        str2 = item.Tag.ToString();
                        string name = item.Name;
                        string[] strArray2 = new string[] { "1", num.ToString(), str, str2.Replace("*", ",").Replace(@"\", ",").Trim(new char[] { ',' }) };
                        list.Add(strArray2);
                        num++;
                    }
                }
            }
            this.m_SimpleCmd.CmdParams = list;
        }

        private void InitData()
        {
            DataTable table = RemotingClient.Car_GetRegionInfo(MainForm.myCarList.SelectedCarId, 0);
            if (table != null)
            {
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    string str2 = table.Rows[i]["regionName"].ToString();
                    string str3 = table.Rows[i]["RegionId"].ToString();
                    string sRegionDot = table.Rows[i]["regionDot"].ToString();
                    table.Rows[i]["regionType"].ToString();
                    if (Check.isRectangle(sRegionDot))
                    {
                        CheckBoxItem chk = new CheckBoxItem {
                            Name = str3,
                            Text = str2,
                            Tag = sRegionDot
                        };
                        this.chkListRegion.Add(chk);
                    }
                }
            }
        }

        private void initForm()
        {
            if (base.OrderCode == CmdParam.OrderCode.区域内超速报警设置)
            {
                this.InitData();
                this.grpSet.Visible = true;
                this.pnlSet1.Visible = true;
                this.grpArea.Visible = true;
                this.lblSpeed.Text = "超速速度:";
                this.lblSpeed2.Text = "公里";
                this.numSpeed.Value = 60M;
            }
        }

 private void m2mSetRegionSpeedAlarm_Load(object sender, EventArgs e)
        {
            this.initForm();
        }
    }
}

