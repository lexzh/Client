namespace Client
{
    using PublicClass;
    using Remoting;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class MapPath : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;
        public ComboBox cmbGroup;
        public GroupBox grpPoint;
        public int iRadius;
        public Label lblBeginName;
        public Label lblEndName;
        public Label lblGroup;
        public Label lblMark;
        public Label lblMeter;
        public Label lblName;
        public Label lblPathType;
        public Label lblRadius;
        public Panel pnlBtn;
        public TextBox txtBeginName;
        public TextBox txtEndName;
        public TextBox txtMark;
        public TextBox txtName;

        public MapPath(itmPreSetPath.PreType type)
        {
            this.iRadius = 500;
            this.InitializeComponent();
            this.preType = type;
        }

        public MapPath(itmPreSetPath.PreType type, DataTable dtPath)
        {
            this.iRadius = 500;
            this.InitializeComponent();
            this.preType = type;
            this.dtPath = dtPath;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
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
                double num6 = 0.0;
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
                    num6 = double.Parse(strArray2[1]);
                    foreach (string str6 in strArray)
                    {
                        string[] strArray3 = str6.Split(new char[] { ',' });
                        pathStr = (pathStr + this.getDotStr(strArray3[0]) + "*") + this.getDotStr(strArray3[1]) + "/";
                    }
                    if (!this._isUpdate)
                    {
                        switch (this.PreSetPath(pathStr, pathName, pathType, num2, factoryName, num3, num4, buildingSitName, num5, num6))
                        {
                            case 0:
                                this.PathDot = pathStr;
                                this.PathName = pathName;
                                this._group = this.cmbGroup.SelectedValue.ToString();
                                this._pathType = this.cmbPathType.SelectedValue.ToString();
                                this._beginName = this.txtBeginName.Text;
                                this._endName = this.txtEndName.Text;
                                this._mark = this.txtMark.Text;
                                if (!base.Modal)
                                {
                                    if (this.dtPath != null)
                                    {
                                        DataRow row = this.dtPath.NewRow();
                                        row["PathId"] = this.PathId;
                                        row["PathName"] = this.PathName;
                                        row["AlarmPathDot"] = this.PathDot;
                                        this.dtPath.Rows.Add(row);
                                    }
                                    base.Close();
                                }
                                base.DialogResult = DialogResult.OK;
                                return;

                            case 1:
                                base.DialogResult = DialogResult.Cancel;
                                base.Close();
                                return;
                        }
                    }
                    else
                    {
                        try
                        {
                            TrafficPath pathinfo = new TrafficPath {
                                pathStr = pathStr,
                                pathName = pathName,
                                PathId = Convert.ToInt32(this.PathId),
                                pathType = pathType,
                                region_Radius = num2,
                                factoryName = factoryName,
                                lon_Factory = num3,
                                lat_Factory = num4,
                                buildingSitName = buildingSitName,
                                lon_BuildingSit = num5,
                                lat_BuildingSit = num6,
                                isNewPath = this.PathLonLatChange,
                                pathgroupID = Convert.ToInt32(this.cmbGroup.SelectedValue),
                                PathSegments = this.getSegment(),
                                remark = this.txtMark.Text
                            };
                            switch (this.UpdatePathEx(pathinfo))
                            {
                                case 1:
                                    this.PathDot = pathStr;
                                    this.PathName = pathName;
                                    this._group = this.cmbGroup.SelectedValue.ToString();
                                    this._pathType = this.cmbPathType.SelectedValue.ToString();
                                    this._beginName = this.txtBeginName.Text;
                                    this._endName = this.txtEndName.Text;
                                    this._mark = this.txtMark.Text;
                                    base.DialogResult = DialogResult.OK;
                                    return;

                                case 0:
                                    base.DialogResult = DialogResult.Cancel;
                                    base.Close();
                                    return;
                            }
                        }
                        catch (Exception exception)
                        {
                            Record.execFileRecord("预设路线-->路线添加页面", exception.Message);
                        }
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
                        case 1:
                            this.PathDot = regionStr;
                            this.PathName = pathName;
                            this._group = this.cmbGroup.SelectedValue.ToString();
                            base.DialogResult = DialogResult.OK;
                            return;

                        case 0:
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

        private string[][] getSegment()
        {
            if ((this.PathSegment == null) || (this.PathSegment.Count == 0))
            {
                return null;
            }
            string[][] strArray = new string[this.PathSegment.Count][];
            int index = 0;
            foreach (KeyValuePair<string, string> pair in this.PathSegment)
            {
                string[] strArray2 = new string[2];
                strArray2[0] = this._isMapDirection ? this.txtName.Text : pair.Key;
                string str = "";
                foreach (string str2 in pair.Value.Split(new char[] { ';' }))
                {
                    string[] strArray4 = str2.Split(new char[] { ',' });
                    if (strArray4.Length >= 2)
                    {
                        str = (str + this.getDotStr(strArray4[0]) + "*") + this.getDotStr(strArray4[1]) + "/";
                    }
                }
                strArray2[1] = str;
                strArray[index] = strArray2;
                index++;
            }
            return strArray;
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
            }
            if (this.PathDot.Split(new char[] { ';' }).Length == 1)
            {
                this.pnlCircel.Visible = true;
            }
            else
            {
                this.pnlCircel.Visible = false;
            }
            if (this.preType != itmPreSetPath.PreType.预设报警路线)
            {
                this.pnlPath.Visible = false;
                if (this._group != null)
                {
                    this.cmbGroup.SelectedValue = this._group;
                }
                this.Text = "请输入区域名称";
            }
            else
            {
                this.cmbPathType.addItems("普通", 0);
                this.cmbPathType.addItems("混凝土", 1);
                this.cmbPathType.SelectedIndex = 0;
                this.Text = "请输入路线名称";
                if ((this._pathType != null) && (this._pathType.Trim().Length > 0))
                {
                    for (int i = 0; i < this.cmbPathType.Items.Count; i++)
                    {
                        if ((this.cmbPathType.Items[i] as DataRowView)[1].ToString().Equals(this._pathType))
                        {
                            this.cmbPathType.SelectedIndex = i;
                            break;
                        }
                    }
                    this.cmbGroup.SelectedValue = this._group;
                }
                if (this.cmbPathType.SelectedIndex == 0)
                {
                    this.txtBeginName.Text = this.txtEndName.Text = "";
                }
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
                DataTable table = RemotingClient.Alarm_PreSetPathEx(pathStr, pathName, pathType, region_Radius, factoryName, lon_Factory, lat_Factory, buildingSitName, lon_BuildingSit, lat_BuildingSit, this.txtMark.Text, this.getSegment());
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
                Record.execFileRecord("添加路线", exception.Message);
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
                        return 0;
                    }
                    MessageBox.Show("上传区域信息成功！");
                    this.PathId = regionId.ToString();
                    return 1;
                }
                if (RemotingClient.Alarm_UdateRegionDot(this.PathId, regionStr, regionName, (int) this.cmbGroup.SelectedValue).ResultCode != 0L)
                {
                    MessageBox.Show("修改区域信息失败！");
                    return 0;
                }
                this.PathDot = regionStr;
                return 1;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return 2;
            }
        }

        private int UpdatePathEx(TrafficPath pathinfo)
        {
            try
            {
                if (RemotingClient.UpdatePathEx(pathinfo) < 0)
                {
                    if (MessageBox.Show("上传路线信息失败，是否重新上传？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        return this.UpdatePathEx(pathinfo);
                    }
                    return 0;
                }
                MessageBox.Show("上传路线信息成功！");
                return 1;
            }
            catch (Exception exception)
            {
                Record.execFileRecord("路线修改", exception.Message);
                return 0;
            }
        }

        public string BeginName
        {
            get
            {
                return this._beginName;
            }
            set
            {
                this._beginName = value;
                this.txtBeginName.Text = value;
            }
        }

        public string EndName
        {
            get
            {
                return this._endName;
            }
            set
            {
                this._endName = value;
                this.txtEndName.Text = value;
            }
        }

        public string Group
        {
            get
            {
                return this._group;
            }
            set
            {
                this._group = value;
            }
        }

        public bool IsMapDirection
        {
            get
            {
                return this._isMapDirection;
            }
            set
            {
                this._isMapDirection = value;
            }
        }

        public bool IsUpdate
        {
            get
            {
                return this._isUpdate;
            }
            set
            {
                this._isUpdate = value;
            }
        }

        public string PathDot { get; set; }

        public string PathId { get; set; }

        public bool PathLonLatChange
        {
            get
            {
                return this._pathLonLatChange;
            }
            set
            {
                this._pathLonLatChange = value;
            }
        }

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

        public Dictionary<string, string> PathSegment { get; set; }

        public string PathType
        {
            get
            {
                return this._pathType;
            }
            set
            {
                this._pathType = value;
            }
        }

        public decimal Radius
        {
            get
            {
                return this.numRadius.Value;
            }
            set
            {
                this._radius = value;
                this.numRadius.Value = value;
            }
        }

        public string ReMark
        {
            get
            {
                return this._mark;
            }
            set
            {
                this._mark = value;
                this.txtMark.Text = this._mark;
            }
        }
    }
}

