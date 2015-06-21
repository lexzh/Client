namespace Client
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class SearchFeature : ToolWindow
    {
        private DataTable dtSearchSpace = new DataTable();
        public GroupBox grpResult;
        public System.Windows.Forms.GroupBox grpSearch;
        public TextBox txtKey;

        public SearchFeature()
        {
            this.InitializeComponent();
        }

        private void addSearchSpaceView(string sSpaceName, string sValue)
        {
            DataRow row = this.dtSearchSpace.NewRow();
            row["SpaceName"] = sSpaceName;
            row["Value"] = sValue;
            this.dtSearchSpace.Rows.Add(row);
        }

 private void lbResult_DoubleClick(object sender, EventArgs e)
        {
            if (this.lbResult.SelectedIndex >= 0)
            {
                string text = this.lbResult.Text;
                string[] strArray = this.lbResult.SelectedValue.ToString().Split(new char[] { ',' });
                MainForm.myMap.zoonmToLonLat(strArray[0], strArray[1], text);
            }
        }

        private void SearchFeature_DockStateChanged(object sender, EventArgs e)
        {
            if ((base.ParentForm != null) && (base.ParentForm.Name == "MainForm"))
            {
                ((MainForm) base.ParentForm).setMenuViewChecked();
            }
        }

        private void SearchFeature_Load(object sender, EventArgs e)
        {
            this.dtSearchSpace.Columns.Add(new DataColumn("SpaceName"));
            this.dtSearchSpace.Columns.Add(new DataColumn("Value"));
            this.lbResult.DataSource = this.dtSearchSpace;
            this.txtKey.Text = "";
            this.lbResult.Text = "";
            this.txtKey.Focus();
        }

        public void setSearchResult(string sResult)
        {
            this.dtSearchSpace.Clear();
            if ((sResult == null) || (sResult.Length == 0))
            {
                string str = this.txtKey.Text.Trim();
                this.addSearchSpaceView(string.Format("地图中没有找到关于［{0}］的内容", str), "0,0");
                this.txtKey.Focus();
            }
            else
            {
                string[] separator = new string[] { ":::" };
                foreach (string str2 in sResult.ToString().Split(separator, StringSplitOptions.None))
                {
                    try
                    {
                        string[] strArray3 = str2.Split(new char[] { ',' });
                        this.addSearchSpaceView(strArray3[0], strArray3[2] + "," + strArray3[1]);
                    }
                    catch
                    {
                    }
                }
                this.lbResult.Enabled = true;
            }
        }

        private void txtKey_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Return)
            {
                string sKey = this.txtKey.Text.Trim();
                if (sKey.Length == 0)
                {
                    MessageBox.Show("请输入关键字！");
                    this.txtKey.Focus();
                }
                else
                {
                    try
                    {
                        this.lbResult.Enabled = false;
                        this.dtSearchSpace.Clear();
                        this.addSearchSpaceView("正在查询，请稍候...", "0,0");
                        MainForm.myMap.execSelectSpace(sKey);
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
            }
        }
    }
}

