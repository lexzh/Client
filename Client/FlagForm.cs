namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class FlagForm : FixedForm
    {
        public System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.Panel pnlBtn;

        public FlagForm(GisMap CurrentMap)
        {
            this.InitializeComponent();
            this.m_CurrentMap = CurrentMap;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            WaitForm.Show("正在更新地图标注，请稍候...", this);
            MainForm.POITypes = this.getCheckFlagTypeName();
            MainForm.myMap.execClearAllFlag();
            MainForm.myMap.showSelectedFlagMap(this.m_CurrentMap);
            WaitForm.Hide();
            base.DialogResult = DialogResult.OK;
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < this.clbSelectFlagType.Items.Count; i++)
                {
                    this.clbSelectFlagType.SetItemChecked(i, this.chkSelectAll.Checked);
                }
            }
            catch
            {
            }
        }

 private void FlagForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.setListValue();
                this.InitListCheck();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("兴趣点类型显示控制", exception.Message);
            }
            this.btnOK.Enabled = true;
        }

        private string getCheckFlagTypeName()
        {
            string str = string.Empty;
            foreach (System.Web.UI.WebControls.ListItem item in this.clbSelectFlagType.CheckedItems)
            {
                str = str + item.Value + ",";
            }
            return str.Trim(new char[] { ',' });
        }

 private void InitListCheck()
        {
            if (this.clbSelectFlagType.Items.Count != 0)
            {
                if (MainForm.POITypes == null)
                {
                    for (int i = 0; i < this.clbSelectFlagType.Items.Count; i++)
                    {
                        this.clbSelectFlagType.SetItemChecked(i, true);
                    }
                    this.chkSelectAll.Checked = true;
                }
                else
                {
                    string[] strArray = MainForm.POITypes.Split(new char[] { ',' });
                    for (int j = 0; j < strArray.Length; j++)
                    {
                        for (int k = 0; k < this.clbSelectFlagType.Items.Count; k++)
                        {
                            System.Web.UI.WebControls.ListItem item = this.clbSelectFlagType.Items[k] as System.Web.UI.WebControls.ListItem;
                            if ((item != null) && item.Value.Equals(strArray[j]))
                            {
                                this.clbSelectFlagType.SetItemChecked(k, true);
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void setListValue()
        {
            this.clbSelectFlagType.Items.Clear();
            DataTable table = RemotingClient.MapFlag_FlagMapType();
            if ((table != null) && (table.Rows.Count > 0))
            {
                foreach (DataRow row in table.Rows)
                {
                    System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem(row["name"].ToString(), row["id"].ToString());
                    this.clbSelectFlagType.Items.Add(item);
                }
            }
        }
    }
}

