namespace Client
{
    using ParamLibrary.Application;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;

    public partial class SetAlarmCondition : FixedForm
    {
        private string m_sCustName = "";

        public SetAlarmCondition(string sCustName)
        {
            this.InitializeComponent();
            this.m_sCustName = sCustName;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.AlarmCondition = "";
            foreach (System.Web.UI.WebControls.ListItem item in this.clbAlarmCondition.CheckedItems)
            {
                this.AlarmCondition = this.AlarmCondition + item.Text + ",";
            }
            base.DialogResult = DialogResult.OK;
        }

        private void chkDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDefault.Checked)
            {
                for (int i = 0; i < this.clbAlarmCondition.Items.Count; i++)
                {
                    this.clbAlarmCondition.SetItemChecked(i, false);
                }
                this.clbAlarmCondition.Enabled = false;
            }
            else
            {
                this.clbAlarmCondition.Enabled = true;
            }
        }

 private bool getAlarmState(string sAlarmName)
        {
            foreach (string str in this.AlarmCondition.Split(new char[] { ',' }))
            {
                if (str == sAlarmName)
                {
                    return true;
                }
            }
            return false;
        }

        private string getCustName(string sName, CmdParam.CarAlarmState state)
        {
            string[] strArray = this.m_sCustName.Split(new char[] { '*' });
            string str = string.Empty;
            if ((this.m_sCustName.Length > 0) && (strArray.Length > 0))
            {
                for (int i = 0; i < strArray.Length; i++)
                {
                    string[] strArray2 = strArray[i].Split(new char[] { '/' });
                    if (long.Parse(strArray2[0]) == (long)state)
                    {
                        return strArray2[1];
                    }
                }
                return str;
            }
            return sName;
        }

        private void InitAlarmCondition()
        {
            string text = "";
            if (this.AlarmCondition.Length <= 0)
            {
                this.chkDefault.Checked = true;
            }
            else
            {
                this.chkDefault.Checked = false;
            }
            System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem("紧急报警", "2") {
                Selected = this.getAlarmState("紧急报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("紧急报警"));
            item = new System.Web.UI.WebControls.ListItem("求助报警", "16") {
                Selected = this.getAlarmState("求助报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("求助报警"));
            item = new System.Web.UI.WebControls.ListItem("位移报警", "32") {
                Selected = this.getAlarmState("位移报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("位移报警"));
            item = new System.Web.UI.WebControls.ListItem("欠压报警", "256") {
                Selected = this.getAlarmState("欠压报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("欠压报警"));
            item = new System.Web.UI.WebControls.ListItem("超速报警", "4096") {
                Selected = this.getAlarmState("超速报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("超速报警"));
            item = new System.Web.UI.WebControls.ListItem("掉电报警", "512") {
                Selected = this.getAlarmState("掉电报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("掉电报警"));
            item = new System.Web.UI.WebControls.ListItem("探测报警", "2097152") {
                Selected = this.getAlarmState("探测报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("探测报警"));
            item = new System.Web.UI.WebControls.ListItem("防盗报警", "32768") {
                Selected = this.getAlarmState("防盗报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("防盗报警"));
            item = new System.Web.UI.WebControls.ListItem("开油箱盖", "4194304") {
                Selected = this.getAlarmState("开油箱盖")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("开油箱盖"));
            item = new System.Web.UI.WebControls.ListItem("刹车报警", "8388608") {
                Selected = this.getAlarmState("刹车报警")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("刹车报警"));
            item = new System.Web.UI.WebControls.ListItem("非法点火", "65536") {
                Selected = this.getAlarmState("非法点火")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("非法点火"));
            item = new System.Web.UI.WebControls.ListItem("超时停车", "64") {
                Selected = this.getAlarmState("超时停车")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("超时停车"));
            item = new System.Web.UI.WebControls.ListItem("超时驾驶", "128") {
                Selected = this.getAlarmState("超时驾驶")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("超时驾驶"));
            item = new System.Web.UI.WebControls.ListItem("开车门", "131072") {
                Selected = this.getAlarmState("开车门")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("开车门"));
            item = new System.Web.UI.WebControls.ListItem("开车窗", "262144") {
                Selected = this.getAlarmState("开车窗")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("开车窗"));
            item = new System.Web.UI.WebControls.ListItem("开前盖", "524288") {
                Selected = this.getAlarmState("开前盖")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("开前盖"));
            item = new System.Web.UI.WebControls.ListItem("开后盖", "1048576") {
                Selected = this.getAlarmState("开后盖")
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState("开后盖"));
            text = this.getCustName("自定义1", CmdParam.CarAlarmState.终端IO1输入);
            item = new System.Web.UI.WebControls.ListItem(text, "16777216") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
            text = this.getCustName("自定义2", CmdParam.CarAlarmState.适配器S0);
            item = new System.Web.UI.WebControls.ListItem(text, "33554432") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
            text = this.getCustName("自定义3", CmdParam.CarAlarmState.适配器S1);
            item = new System.Web.UI.WebControls.ListItem(text, "67108864") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
            text = this.getCustName("自定义4", CmdParam.CarAlarmState.适配器S2);
            item = new System.Web.UI.WebControls.ListItem(text, "134217728") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
            text = this.getCustName("自定义5", CmdParam.CarAlarmState.适配器S3);
            item = new System.Web.UI.WebControls.ListItem(text, "268435456") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
            text = this.getCustName("自定义6", CmdParam.CarAlarmState.适配器S4);
            item = new System.Web.UI.WebControls.ListItem(text, "536870912") {
                Selected = this.getAlarmState(text)
            };
            this.clbAlarmCondition.Items.Add(item, this.getAlarmState(text));
        }

 private void SetAlarmCondition_Load(object sender, EventArgs e)
        {
            this.InitAlarmCondition();
        }

        public string AlarmCondition { get; set; }
    }
}

