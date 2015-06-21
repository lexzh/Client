namespace Client.M2M
{
    using Client;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class m2mMapPath : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;
        public ComboBox cmbGroup;
        public GroupBox grpPoint;
        public int iRadius = 500;
        public Label lblBeginName;
        public Label lblEndName;
        public Label lblGroup;
        public Label lblMeter;
        public Label lblName;
        public Label lblPathType;
        public Label lblRadius;
        public Panel pnlBtn;
        public TextBox txtBeginName;
        public TextBox txtEndName;
        public TextBox txtName;

        public m2mMapPath(itmPreSetPath.PreType type)
        {
            this.InitializeComponent();
            this.preType = type;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string text = this.cmbGroup.Text;
            string pathName = this.txtName.Text.Trim();
            if (text.Length <= 0)
            {
                MessageBox.Show("请选择组别");
                this.cmbGroup.Focus();
            }
            else if (text == "(无)")
            {
                MessageBox.Show("没有组别");
                this.cmbGroup.Focus();
            }
            else if (pathName.Length <= 0)
            {
                MessageBox.Show("请输入名称");
                this.txtName.Focus();
            }
            else if (this.preType == itmPreSetPath.PreType.预设报警路线)
            {
                int pathType = int.Parse(this.cmbPathType.SelectedValue.ToString());
                string factoryName = this.txtBeginName.Text.Trim();
                string buildingSitName = this.txtEndName.Text.Trim();
                int num2 = int.Parse(this.numRadius.Value.ToString());
                double num3 = 0.0;
                double num4 = 0.0;
                double num5 = 0.0;
                string pathStr = "";
                if (pathName.IndexOf('^') >= 0)
                {
                    MessageBox.Show("路线名称中不允许包含字符('^')！");
                    this.txtName.Focus();
                }
                else
                {
                    if (pathType == 1)
                    {
                        if (factoryName.Length <= 0)
                        {
                            MessageBox.Show("请输入起点名称");
                            this.txtBeginName.Focus();
                            return;
                        }
                        if (buildingSitName.Length <= 0)
                        {
                            MessageBox.Show("请输入终点名称");
                            this.txtEndName.Focus();
                            return;
                        }
                    }
                    string[] strArray = this.PathDot.Split(new char[] { ';' });
                    string[] strArray2 = strArray[0].Split(new char[] { ',' });
                    num3 = double.Parse(strArray2[0]);
                    num4 = double.Parse(strArray2[1]);
                    strArray2 = strArray[strArray.Length - 1].Split(new char[] { ',' });
                    num5 = double.Parse(strArray2[0]);
                    double.Parse(strArray2[1]);
                    foreach (string str6 in strArray)
                    {
                        string[] strArray3 = str6.Split(new char[] { ',' });
                        pathStr = (pathStr + this.getDotStr(strArray3[0]) + "*") + this.getDotStr(strArray3[1]) + "/";
                    }
                    switch (this.PreSetPath(pathStr, pathName, pathType, num2, factoryName, num3, num4, buildingSitName, num5, num5))
                    {
                        case 0:
                            this.PathDot = pathStr;
                            this.PathName = pathName;
                            base.DialogResult = DialogResult.OK;
                            return;

                        case 1:
                            base.DialogResult = DialogResult.Cancel;
                            return;
                    }
                }
            }
            else
            {
                string regionStr = "";
                int iRegionFeature = 0;
                if (pathName.IndexOf('^') >= 0)
                {
                    MessageBox.Show("区域命名中不能包含字符('^')！");
                    this.txtName.Focus();
                }
                else
                {
                    if (this.PathDot.Split(new char[] { ';' }).Length == 1)
                    {
                        this.iRadius = int.Parse(this.numDistance.Value.ToString());
                        string[] strArray4 = this.PathDot.Split(new char[] { ',' });
                        regionStr = this.getDotStr(strArray4[0]) + @"\" + this.getDotStr(strArray4[1]) + @"\" + this.iRadius.ToString() + "*";
                    }
                    else
                    {
                        foreach (string str8 in this.PathDot.Split(new char[] { ';' }))
                        {
                            string[] strArray6 = str8.Split(new char[] { ',' });
                            regionStr = (regionStr + this.getDotStr(strArray6[0]) + @"\") + this.getDotStr(strArray6[1]) + "*";
                        }
                    }
                    if (this.preType == itmPreSetPath.PreType.预设多功能报警区域)
                    {
                        iRegionFeature = 1;
                    }
                    switch (this.PreSetRegion(regionStr, pathName, iRegionFeature))
                    {
                        case 0:
                            this.PathDot = regionStr;
                            this.PathName = pathName;
                            base.DialogResult = DialogResult.OK;
                            return;

                        case 1:
                            base.DialogResult = DialogResult.Cancel;
                            break;
                    }
                }
            }
        }

        private void cmbPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbPathType.SelectedIndex == 1)
            {
                this.txtBeginName.Enabled = true;
                this.txtEndName.Enabled = true;
                this.numRadius.Enabled = true;
            }
            else
            {
                this.txtBeginName.Enabled = false;
                this.txtEndName.Enabled = false;
                this.numRadius.Enabled = false;
            }
        }

 private string getDotStr(string sDot)
        {
            string str = "";
            try
            {
                str = double.Parse(sDot).ToString("0.000000");
            }
            catch
            {
            }
            return str;
        }

        private void initForm()
        {
            DataTable table = RemotingClient.Alarm_ShowGroupType();
            if ((table == null) || (table.Rows.Count <= 0))
            {
                this.cmbGroup.Items.Add("(无)");
                this.cmbGroup.Text = "(无)";
            }
            else
            {
                this.cmbGroup.DataSource = table;
                if ((this._pathGroupID != null) && (this._pathGroupID.Trim().Length > 0))
                {
                    this.cmbGroup.SelectedValue = this._pathGroupID;
                }
            }
            if (this.PathDot.Split(new char[] { ';' }).Length == 1)
            {
                this.pnlCircel.Visible = true;
            }
            else
            {
                this.pnlCircel.Visible = false;
            }
            if (this.preType == itmPreSetPath.PreType.预设报警路线)
            {
                this.cmbPathType.addItems("普通", 0);
                this.cmbPathType.addItems("混凝土", 1);
                this.cmbPathType.SelectedIndex = 0;
                this.Text = "请输入路线名称";
            }
            else
            {
                this.pnlPath.Visible = false;
                this.Text = "请输入区域名称";
            }
        }

 private void MapPath_Load(object sender, EventArgs e)
        {
            this.initForm();
        }

        private int PreSetPath(string pathStr, string pathName, int pathType, int region_Radius, string factoryName, double lon_Factory, double lat_Factory, string buildingSitName, double lon_BuildingSit, double lat_BuildingSit)
        {
            try
            {
                DataTable table = RemotingClient.Alarm_PreSetPath(pathStr, pathName, pathType, region_Radius, factoryName, lon_Factory, lat_Factory, buildingSitName, lon_BuildingSit, lat_BuildingSit);
                if ((table == null) || (table.Rows.Count <= 0))
                {
                    if (MessageBox.Show("上传路线信息失败，是否重新上传？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        return this.PreSetPath(pathStr, pathName, pathType, region_Radius, factoryName, lon_Factory, lat_Factory, buildingSitName, lon_BuildingSit, lat_BuildingSit);
                    }
                    return 1;
                }
                switch (int.Parse(table.Rows[0][0].ToString()))
                {
                    case -1:
                        MessageBox.Show("存在相同的路线命名！");
                        this.txtName.Focus();
                        return 2;

                    case -2:
                        MessageBox.Show("存在相同的起点名称或者终点名称！");
                        this.txtBeginName.Focus();
                        return 2;
                }
                int pathId = int.Parse(table.Rows[0]["PathId"].ToString());
                int selectedValue = (int) this.cmbGroup.SelectedValue;
                if (RemotingClient.Alarm_InsertPathRelatedType(selectedValue, pathId) < 0)
                {
                    MessageBox.Show("上传路线信息,更新数据库时发生异常！");
                    return 1;
                }
                MessageBox.Show("上传路线信息成功！");
                this.PathId = pathId.ToString();
                return 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 2;
            }
        }

        private int PreSetRegion(string regionStr, string regionName, int iRegionFeature)
        {
            try
            {
                if (!this.IsUpdate)
                {
                    DataTable table = RemotingClient.Alarm_PreSetRegion(regionStr, regionName, iRegionFeature);
                    if ((table == null) || (table.Rows.Count <= 0))
                    {
                        if (MessageBox.Show("上传区域信息失败，是否重新上传？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            return this.PreSetRegion(regionStr, regionName, iRegionFeature);
                        }
                        return 1;
                    }
                    if (int.Parse(table.Rows[0][0].ToString()) == -1)
                    {
                        MessageBox.Show("存在相同的区域命名！");
                        this.txtName.Focus();
                        return 2;
                    }
                    int regionId = int.Parse(table.Rows[0]["regionID"].ToString());
                    int selectedValue = (int) this.cmbGroup.SelectedValue;
                    if (RemotingClient.Alarm_InsertRelatedType(selectedValue, regionId) < 0)
                    {
                        MessageBox.Show("上传区域信息,更新数据库时发生异常！");
                        return 1;
                    }
                    MessageBox.Show("上传区域信息成功！");
                    this.PathId = regionId.ToString();
                    return 0;
                }
                if (RemotingClient.Alarm_UdateRegionDot(this.PathId, regionStr, regionName, (int) this.cmbGroup.SelectedValue).ResultCode != 0L)
                {
                    MessageBox.Show("修改区域信息失败！");
                    return 2;
                }
                this.PathDot = regionStr;
                return 0;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 2;
            }
        }

        public bool IsUpdate
        {
            get
            {
                return this.isUpdate;
            }
            set
            {
                this.isUpdate = value;
            }
        }

        public string PathDot { get; set; }

        public string PathGroupID
        {
            get
            {
                return this.cmbGroup.SelectedValue.ToString();
            }
            set
            {
                this._pathGroupID = value;
            }
        }

        public string PathId { get; set; }

        public string PathName
        {
            get
            {
                return this.txtName.Text;
            }
            set
            {
                this._pathName = value;
                this.txtName.Text = value;
            }
        }
    }
}

