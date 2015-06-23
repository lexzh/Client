using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace Client
{
    public partial class itmPreSetStation : SizableForm
    {
        private itmPreSetPath.PreType preType;
        private static string m_sRegionKong = "(无)";
        private bool isModify;
        private bool isAdd;
        private int currentRegionType;
        private string sPoints = "";
        public int iRadius = 500;
        private string sRegionStr = "";
        private string sRegionName = "";
        private DataTable dt;
        private string id = "";
        private double tempsCenterPointX;
        private double tempsCenterPointY;
        private int tempsRadius;
        private string tempsRegionName = "";
        public DataTable dtType = new DataTable();
        public StationDAL dal = new StationDAL();
        private bool fnext;
        private int row;

        public itmPreSetStation()
        {
            InitializeComponent();
        }

        private void itmPreSetRegions_Load(object sender, EventArgs e)
        {
            Point location = new Point((this.wbMap.Location.X + this.wbMap.Width) / 2, (this.wbMap.Location.Y + this.wbMap.Height) / 2 - 17);
            this.picLoadMap.Location = location;
            this.picLoadMap.Visible = true;
            this.pnlConent.Visible = false;
            try
            {
                this.wbMap.Url = new Uri(Variable.MapUrl);
                this.Text = this.preType.ToString();
            }
            catch (Exception)
            {
            }
            this.btnCancel.Enabled = false;
            this.btnDel.Enabled = false;
            this.btnModify.Enabled = false;
            this.btnSave.Enabled = false;
            this.pnlOperator.Height = this.pnlSetRegion.Height;
            try
            {
                this.dt = this.dal.GetList("", "");
                this.dt.PrimaryKey = new DataColumn[]
				{
					this.dt.Columns["ID"]
				};
                this.LoadData(this.dt);
            }
            catch (Exception)
            {
            }
            this.dtType.Columns.Add("ID", Type.GetType("System.Int32"));
            this.dtType.Columns.Add("Type", Type.GetType("System.String"));
            DataRow dataRow = this.dtType.NewRow();
            dataRow["ID"] = "-1";
            dataRow["Type"] = "--请选择--";
            this.dtType.Rows.InsertAt(dataRow, 0);
            dataRow = this.dtType.NewRow();
            dataRow["ID"] = "0";
            dataRow["Type"] = "站点";
            this.dtType.Rows.InsertAt(dataRow, 1);
            dataRow = this.dtType.NewRow();
            dataRow["ID"] = "1";
            dataRow["Type"] = "工程点";
            this.dtType.Rows.InsertAt(dataRow, 2);
            this.cmbType.DataSource = this.dtType;
            this.cmbType.DisplayMember = this.dtType.Columns[1].ToString();
            this.cmbType.ValueMember = this.dtType.Columns[0].ToString();
            this.cmbType.SelectedIndex = 0;
        }
        private void wbMap_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                this.wbMap.Document.Window.Error += delegate(object sender1, HtmlElementErrorEventArgs e1)
                {
                    e1.Handled = true;
                };
                if (this.wbMap.Url.ToString().Equals("about:blank"))
                {
                    this.picLoadMap.Visible = false;
                    return;
                }
                HtmlDocument document = this.wbMap.Document;
                if (document.GetElementById("map") == null)
                {
                    this.picLoadMap.Visible = false;
                    this.wbMap.Url = new Uri("about:blank");
                    MessageBox.Show("地图初始化失败！");
                    Record.execFileRecord("加载地图", "地图初始化失败！");
                    return;
                }
                this.wbMap.setMap(MainForm.myMap.getMapView());
                this.pnlSetRegion.Enabled = true;
            }
            catch
            {
                this.picLoadMap.Visible = false;
            }
            this.picLoadMap.Visible = false;
        }
        private void wbMap_MapDoubleClick(object sender, HtmlElementEventArgs e)
        {
            object mapClicked = this.wbMap.getMapClicked();
            if (mapClicked == null || !bool.Parse(mapClicked.ToString()))
            {
                return;
            }
            try
            {
                string text = this.wbMap.getSketchPoints().ToString().Trim(new char[]
				{
					';'
				});
                if (!string.IsNullOrEmpty(text))
                {
                    string[] array = text.Split(new char[]
					{
						';'
					});
                    if (array.Length >= 2 && (array.Length != 2 || !(array[0] == array[1])))
                    {
                        MessageBox.Show(array[0] + "," + array[1]);
                    }
                }
            }
            catch
            {
            }
        }
        private void wbMap_MapMouseUp(object sender, HtmlElementEventArgs e)
        {
            object mapClicked = this.wbMap.getMapClicked();
            if (mapClicked == null || !bool.Parse(mapClicked.ToString()))
            {
                return;
            }
            try
            {
                this.sPoints = this.wbMap.getCurrentPoint().ToString().Trim(new char[]
				{
					';'
				});
                if (!string.IsNullOrEmpty(this.sPoints))
                {
                    string[] array = this.sPoints.Split(new char[]
					{
						';'
					});
                    if (array.Length <= 2)
                    {
                        this.sPoints = array[0] + "," + array[1];
                        this.txtRegionDot.Text = this.sPoints;
                        this.wbMap.execClearAllPolygon();
                        double centerPointX = double.Parse(array[0]);
                        double centerPointY = double.Parse(array[1]);
                        int radius = int.Parse(this.numDistance.Value.ToString());
                        this.sRegionName = this.txtRegionName.Text.Trim();
                        this.wbMap.showCircle(this.sRegionName, centerPointX, centerPointY, radius);
                    }
                }
            }
            catch (Exception ex)
            {
                Record.execFileRecord("预设区域", ex.Message);
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.ClearValue();
            try
            {
                if (this.dgvData.Rows.Count > 0)
                {
                    this.dgvData.Rows[0].Selected = false;
                    this.dgvData.Rows[this.dgvData.RowCount - 1].Selected = false;
                }
            }
            catch (Exception)
            {
            }
            MessageBox.Show("请在地图上点击圆形的中心点所在位置。");
            this.wbMap.setCircleTool();
            this.pnlConent.Visible = true;
            this.btnSave.Enabled = true;
            this.btnCancel.Enabled = true;
            this.btnAdd.Enabled = false;
            this.pnlOperator.Height = this.pnlSetRegion.Height - this.pnlConent.Height;
            this.isAdd = true;
            this.isModify = false;
            this.txtRegionName.Enabled = true;
            this.numDistance.Enabled = true;
            this.btnGetLocation.Enabled = true;
            this.cmbType.Enabled = true;
            this.wbMap.execClearAllPolygon();
        }
        private void tsBtnMove_Click(object sender, EventArgs e)
        {
            this.wbMap.setPanTool();
        }
        private void tsBtnZoomIn_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomUpTool();
        }
        private void tsBtnZoomOut_Click(object sender, EventArgs e)
        {
            this.wbMap.setZoomDownTool();
        }
        private void execRefRegion(string PathDot, Station models)
        {
            this.iRadius = int.Parse(this.numDistance.Value.ToString());
            string[] array = PathDot.Split(new char[]
			{
				','
			});
            this.sRegionStr = string.Concat(new string[]
			{
				this.getDotStr(array[0]),
				"\\",
				this.getDotStr(array[1]),
				"\\",
				this.iRadius.ToString(),
				"*"
			});
            models.RegionDot = this.sRegionStr;
            models.RegionName = this.txtRegionName.Text.Trim();
            models.RegionType = new int?(0);
            if (this.cmbType.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("请选择类型");
                return;
            }
            models.StationType = new int?(int.Parse(this.cmbType.SelectedValue.ToString()));
            this.sRegionName = models.RegionName;
            if (this.isAdd && this.dal.Exists("RegionName='" + models.RegionName + "'"))
            {
                MessageBox.Show("存在相同的区域命名！", "提示");
                return;
            }
            if (this.isModify)
            {
                DataRow dataRow = this.dt.Rows.Find(int.Parse(this.id));
                models.ID = int.Parse(this.id);
                if (dataRow != null)
                {
                    if (this.dal.Update(models))
                    {
                        MessageBox.Show("修改成功", "提示");
                        dataRow["RegionDot"] = models.RegionDot;
                        dataRow["RegionName"] = models.RegionName;
                        dataRow["RegionType"] = models.RegionType;
                        dataRow["StationType"] = models.StationType;
                        this.LoadData(this.dt);
                        this.sRegionName = models.RegionName;
                        this.ShowLocation(this.sRegionStr);
                        this.wbMap.setPanTool();
                        this.ClearValue();
                        this.SetEnableBtn(true);
                        string[] array2 = PathDot.Split(new char[]
						{
							','
						});
                        this.tempsCenterPointX = double.Parse(array2[0]);
                        this.tempsCenterPointY = double.Parse(array2[1]);
                        this.tempsRadius = int.Parse(this.iRadius.ToString());
                        this.tempsRegionName = this.sRegionName;
                        return;
                    }
                    MessageBox.Show("修改失败", "提示");
                    return;
                }
            }
            else if (this.isAdd)
            {
                if (this.dal.Add(models) > 0)
                {
                    MessageBox.Show("添加成功", "提示");
                    if (this.dt != null)
                    {
                        Station model = this.dal.GetModel("RegionName='" + models.RegionName + "'");
                        DataRow dataRow2 = this.dt.NewRow();
                        dataRow2["ID"] = model.ID;
                        dataRow2["RegionDot"] = model.RegionDot;
                        dataRow2["RegionName"] = model.RegionName;
                        dataRow2["RegionType"] = model.RegionType;
                        dataRow2["StationType"] = model.StationType;
                        this.dt.Rows.Add(dataRow2);
                        this.pnlOperator.Height = this.pnlSetRegion.Height;
                        this.LoadData(this.dt);
                        this.dgvData.ClearSelection();
                        this.dgvData.Rows[this.dgvData.RowCount - 1].Selected = true;
                        this.wbMap.setPanTool();
                    }
                    this.ShowLocation(this.sRegionStr);
                    this.ClearValue();
                    this.SetEnableBtn(true);
                    return;
                }
                MessageBox.Show("添加失败", "提示");
                this.ClearValue();
            }
        }
        private void SetEnableBtn(bool f)
        {
            this.btnAdd.Enabled = f;
            this.btnCancel.Enabled = !f;
            this.btnDel.Enabled = !f;
            this.btnModify.Enabled = !f;
            this.btnSave.Enabled = !f;
            this.pnlConent.Visible = !f;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.isModify || this.isAdd)
            {
                if (this.txtRegionDot.Text.Trim() == "")
                {
                    MessageBox.Show("请拾取坐标", "提示");
                    return;
                }
                if (this.txtRegionName.Text.Trim() == "")
                {
                    MessageBox.Show("区域名称不能为空", "提示");
                    return;
                }
                if (this.txtRegionName.Text.Trim().IndexOf('^') >= 0)
                {
                    MessageBox.Show("区域命名中不能包含字符('^')！");
                    this.txtRegionName.Focus();
                    return;
                }
                Station models = new Station();
                if (this.isModify)
                {
                    this.sPoints = this.txtRegionDot.Text.Trim();
                }
                this.execRefRegion(this.sPoints, models);
            }
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.id == "" || this.id == "0")
            {
                MessageBox.Show("请先选择要删除的信息", "提示信息");
                return;
            }
            DialogResult dialogResult = MessageBox.Show("是否要删除当前的内容?", "提示信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes && this.dal != null)
            {
                bool flag = this.dal.Delete(int.Parse(this.id));
                if (flag)
                {
                    MessageBox.Show("删除成功", "提示信息");
                    DataRow dataRow = this.dt.Rows.Find(int.Parse(this.id));
                    this.wbMap.setPanTool();
                    if (dataRow != null && this.dt.Rows.Count > 0)
                    {
                        this.dt.Rows.Remove(dataRow);
                        this.LoadData(this.dt);
                        this.wbMap.execClearAllPolygon();
                        if (this.dgvData.RowCount > 0)
                        {
                            this.dgvData.Rows[this.dgvData.RowCount - 1].Selected = true;
                            this.dgvData_CellClick(null, null);
                        }
                        this.SetEnableBtn(true);
                    }
                    this.id = "";
                    return;
                }
                MessageBox.Show("删除失败", "提示信息");
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.pnlConent.Visible = false;
            this.pnlOperator.Height = this.pnlSetRegion.Height;
            this.btnAdd.Enabled = true;
            this.btnModify.Enabled = false;
            this.btnSave.Enabled = false;
            this.btnDel.Enabled = false;
            this.btnCancel.Enabled = false;
            this.cmbType.Enabled = false;
            this.ClearValue();
            if (this.isModify)
            {
                this.wbMap.execClearAllPolygon();
                double centerPointX = this.tempsCenterPointX;
                double centerPointY = this.tempsCenterPointY;
                int num = this.tempsRadius;
                this.sRegionName = this.tempsRegionName;
                if (num > 0)
                {
                    this.wbMap.showCircle(this.sRegionName, centerPointX, centerPointY, num);
                }
            }
            if (this.isAdd)
            {
                this.wbMap.execClearAllPolygon();
                try
                {
                    if (this.dgvData.Rows.Count > 0)
                    {
                        this.dgvData.Rows[0].Selected = false;
                        this.dgvData.Rows[this.dgvData.RowCount - 1].Selected = false;
                    }
                }
                catch (Exception)
                {
                }
            }
            this.tempsCenterPointX = (this.tempsCenterPointY = 0.0);
            this.tempsRadius = 0;
            this.sRegionName = "";
            this.isModify = false;
            this.isAdd = false;
        }
        private void itmPreSetRegions_Resize(object sender, EventArgs e)
        {
            this.groupBox2.Width = this.pnlOperator.Width;
            this.txtKey.Width = this.groupBox2.Width - this.btnSearch.Width;
            if (this.pnlConent.Visible)
            {
                this.pnlOperator.Height = this.pnlSetRegion.Height - this.pnlConent.Height;
                return;
            }
            this.pnlOperator.Height = this.pnlSetRegion.Height;
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            this.tempsCenterPointX = (this.tempsCenterPointY = 0.0);
            this.tempsRadius = 0;
            this.sRegionName = "";
            this.isModify = true;
            this.isAdd = false;
            this.btnAdd.Enabled = false;
            this.btnCancel.Enabled = true;
            this.btnDel.Enabled = false;
            this.btnSave.Enabled = true;
            this.btnModify.Enabled = false;
            this.txtRegionName.Enabled = true;
            this.numDistance.Enabled = true;
            this.btnGetLocation.Enabled = true;
            this.wbMap.setCircleTool();
            string[] array = this.txtRegionDot.Text.Trim().Split(new char[]
			{
				','
			});
            this.tempsCenterPointX = double.Parse(array[0]);
            this.tempsCenterPointY = double.Parse(array[1]);
            this.tempsRadius = int.Parse(this.numDistance.Value.ToString());
            this.tempsRegionName = this.txtRegionName.Text.Trim();
            this.cmbType.Enabled = true;
        }
        private void btnGetLocation_Click(object sender, EventArgs e)
        {
            this.wbMap.setCircleTool();
        }
        public void ShowLocation(string sRegionDots)
        {
            if (sRegionDots == "")
            {
                return;
            }
            this.wbMap.execClearAllPolygon();
            string[] array = sRegionDots.Trim(new char[]
			{
				'*'
			}).Split(new char[]
			{
				'*'
			});
            try
            {
                string[] array2 = array[0].Split(new char[]
				{
					'\\'
				});
                double centerPointX = double.Parse(array2[0]);
                double centerPointY = double.Parse(array2[1]);
                int radius = int.Parse(array2[2]);
                this.wbMap.showCircle(this.sRegionName, centerPointX, centerPointY, radius);
            }
            catch
            {
            }
        }
        private static int GetPoint(string sRegionDots, out string sCenterPointX, out string sCenterPointY)
        {
            string[] array = sRegionDots.Trim(new char[]
			{
				'*'
			}).Split(new char[]
			{
				'*'
			});
            string[] array2 = array[0].Split(new char[]
			{
				'\\'
			});
            sCenterPointX = double.Parse(array2[0]).ToString();
            sCenterPointY = double.Parse(array2[1]).ToString();
            return int.Parse(array2[2]);
        }
        public void LoadData(DataTable dts)
        {
            this.dgvData.AutoGenerateColumns = false;
            this.dgvData.DataSource = dts;
            try
            {
                if (this.dgvData.Rows.Count > 0)
                {
                    this.dgvData.Rows[0].Selected = false;
                }
            }
            catch (Exception)
            {
            }
        }
        private string getDotStr(string sDot)
        {
            string result = "";
            try
            {
                result = double.Parse(sDot).ToString("0.000000");
            }
            catch
            {
            }
            return result;
        }
        private void dgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.id = "";
            if (this.dgvData.SelectedRows.Count > 0)
            {
                this.id = this.dgvData.CurrentRow.Cells["RegionID"].Value.ToString();
                this.sRegionStr = this.dgvData.CurrentRow.Cells["RegionDot"].Value.ToString();
                this.sRegionName = this.dgvData.CurrentRow.Cells["RegionName"].Value.ToString();
                string str = "";
                string str2 = "";
                int point = itmPreSetStation.GetPoint(this.sRegionStr, out str, out str2);
                this.pnlConent.Visible = true;
                this.pnlOperator.Height = this.pnlSetRegion.Height - this.pnlConent.Height;
                this.txtRegionName.Enabled = false;
                this.numDistance.Enabled = false;
                this.btnDel.Enabled = true;
                this.btnSave.Enabled = false;
                this.btnModify.Enabled = true;
                this.btnAdd.Enabled = false;
                this.btnCancel.Enabled = true;
                this.btnGetLocation.Enabled = false;
                this.cmbType.Enabled = false;
                this.ShowLocation(this.sRegionStr);
                this.numDistance.Value = point;
                this.txtRegionDot.Text = str + "," + str2;
                this.txtRegionName.Text = this.dgvData.CurrentRow.Cells["RegionName"].Value.ToString();
                this.cmbType.SelectedValue = this.dgvData.CurrentRow.Cells["StationType"].Value.ToString();
                this.wbMap.setPanTool();
            }
        }
        public void ClearValue()
        {
            this.numDistance.Value = 500m;
            this.txtRegionDot.Text = "";
            this.txtRegionName.Text = "";
            this.cmbType.SelectedIndex = 0;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.dgvData.RowCount <= 0)
                {
                    return;
                }
            }
            catch (Exception)
            {
                return;
            }
            if (!(this.txtKey.Text.Trim() == ""))
            {
                if (!this.fnext)
                {
                    this.row = this.dgvData.CurrentRow.Index;
                    this.search(this.row);
                    return;
                }
                this.search(this.row);
                return;
            }
        }
        public int search(int rowin)
        {
            int count = this.dgvData.Rows.Count;
            int num = this.row;
            for (int i = rowin; i < count; i++)
            {
                if (this.dgvData.Rows[i].Cells["RegionName"].Value.ToString().Trim().IndexOf(this.txtKey.Text.Trim()) >= 0)
                {
                    this.dgvData.CurrentCell = this.dgvData.Rows[i].Cells["RegionName"];
                    this.dgvData.Rows[i].Selected = true;
                    rowin = i + 1;
                    this.row = rowin;
                    this.fnext = true;
                    return this.row;
                }
            }
            if (rowin != num)
            {
                this.fnext = true;
                return this.row;
            }
            for (int j = 0; j < num; j++)
            {
                if (this.txtKey.Text.Trim().Contains(this.dgvData.Rows[j].Cells["RegionName"].Value.ToString().Trim()))
                {
                    this.dgvData.CurrentCell = this.dgvData.Rows[j].Cells["RegionName"];
                    this.dgvData.Rows[j].Selected = true;
                    num = j + 1;
                    this.row = num;
                    this.fnext = true;
                    return this.row;
                }
            }
            this.fnext = false;
            return this.row;
        }
        private void txtKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                this.btnSearch_Click(null, null);
            }
        }
	
    }
}
