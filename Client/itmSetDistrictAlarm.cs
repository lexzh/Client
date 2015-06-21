namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmSetDistrictAlarm : CarForm
    {
        private string m_sContent = "";
        private string m_sExecSql = "";

        public itmSetDistrictAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (!string.IsNullOrEmpty(base.sValue) && this.getParam())
            {
                base.reResult = RemotingClient.ExecNoQuery(this.m_sExecSql);
                string sOrderResult = "成功";
                if (base.reResult.ResultCode != 0L)
                {
                    sOrderResult = "失败";
                }
                string str2 = "";
                foreach (string str3 in base.sCarId.Split(new char[] { ',' }))
                {
                    str2 = str2 + "0|" + str3 + ";";
                }
                base.reResult.OrderIDParam = str2;
                string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                if (string.IsNullOrEmpty(dBCurrentDateTime))
                {
                    dBCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                }
                string sOrderId = "0";
                string sOrderType = "发送";
                string sOrderName = base.OrderCode.ToString();
                string sContent = this.m_sContent;
                MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, base.sCarNum, sOrderId, sOrderType, sOrderName, sOrderResult, sContent);
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

        private void cmbDistrict1_SelectedValueChanged(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(((ComBox) sender).Tag);
            if (num < 3)
            {
                ComBox box = this.grpDistrict.Controls[string.Format("cmbDistrict{0}", num)] as ComBox;
                if (this.grpDistrict.Controls[string.Format("cmbDistrict{0}", num + 1)] != null)
                {
                    ComBox box2 = this.grpDistrict.Controls[string.Format("cmbDistrict{0}", num + 1)] as ComBox;
                    if (box2 != null)
                    {
                        box2.clearItems();
                        if (box.SelectedIndex > 0)
                        {
                            object regionNames = GisService.GetRegionNames(box.SelectedValue.ToString());
                            if (regionNames != null)
                            {
                                string[] strArray = regionNames as string[];
                                box2.addItems("请选择行政区", "");
                                foreach (string str in strArray)
                                {
                                    string[] strArray2 = str.Split(new char[] { ':' });
                                    if (strArray2.Length >= 2)
                                    {
                                        box2.addItems(strArray2[1], strArray2[0]);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

 private bool getParam()
        {
            try
            {
                if (this.rdoCancel.Checked)
                {
                    this.m_sContent = base.OrderCode.ToString() + "-类型:取消";
                    this.m_sExecSql = string.Format("exec GpsPicServer_DelAdminRegoionAlarm '{0}'", base.sCarSimNum);
                    return true;
                }
                string str = "";
                string text = "";
                int num = 1;
                while (true)
                {
                    ComBox box = this.grpDistrict.Controls[string.Format("cmbDistrict{0}", num)] as ComBox;
                    if ((box == null) || (box.SelectedIndex <= 0))
                    {
                        break;
                    }
                    str = box.SelectedValue.ToString();
                    text = box.Text;
                    num++;
                }
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("选择行政区！");
                    this.cmbDistrict1.Focus();
                    return false;
                }
                if (this.rdoIn.Checked)
                {
                    this.m_sContent = base.OrderCode.ToString() + "-类型:禁入-行政区:" + text;
                    this.m_sExecSql = string.Format("exec GpsPicServer_UpdateAdminRegoionAlarm '{0}', '{1}', '{2}', 0", base.sCarSimNum, str, text);
                }
                else
                {
                    this.m_sContent = base.OrderCode.ToString() + "-类型:禁出-行政区:" + text;
                    this.m_sExecSql = string.Format("exec GpsPicServer_UpdateAdminRegoionAlarm '{0}', '{1}', '{2}', 1", base.sCarSimNum, str, text);
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        private void initDistrict()
        {
            try
            {
                this.cmbDistrict1.clearItems();
                this.cmbDistrict1.addItems("请选择行政区", "");
                object regionNames = GisService.GetRegionNames("");
                if (regionNames != null)
                {
                    string[] strArray = regionNames as string[];
                    foreach (string str in strArray)
                    {
                        string[] strArray2 = str.Split(new char[] { ':' });
                        if (strArray2.Length >= 2)
                        {
                            this.cmbDistrict1.addItems(strArray2[1], strArray2[0]);
                        }
                    }
                    try
                    {
                        DataTable table = RemotingClient.ExecSql(string.Format("exec GpsPicServer_FindAdminRegoionAlarm {0}", base.sCarSimNum));
                        if ((table != null) && (table.Rows.Count > 0))
                        {
                            string str2 = table.Rows[0]["AlarmStatus"].ToString();
                            string[] strArray3 = table.Rows[0]["AdminRegionId"].ToString().Split(new char[] { '/' });
                            if ("0".Equals(str2))
                            {
                                this.rdoIn.Checked = true;
                            }
                            else
                            {
                                this.rdoOut.Checked = true;
                            }
                            string str4 = "";
                            int index = 0;
                            while (index <= strArray3.Length)
                            {
                                if (!string.IsNullOrEmpty(str4))
                                {
                                    str4 = str4 + "/";
                                }
                                str4 = str4 + strArray3[index];
                                index++;
                                ComBox sender = this.grpDistrict.Controls[string.Format("cmbDistrict{0}", index)] as ComBox;
                                if (sender == null)
                                {
                                    return;
                                }
                                sender.SelectedValue = str4;
                                this.cmbDistrict1_SelectedValueChanged(sender, new EventArgs());
                            }
                        }
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord(string.Format("{0}-初始化行政区域", base.OrderCode.ToString()), exception.Message);
            }
        }

 private void itmSetDistrictAlarm_Load(object sender, EventArgs e)
        {
            this.initDistrict();
        }
    }
}

