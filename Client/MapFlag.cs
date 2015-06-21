namespace Client
{
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class MapFlag : FixedForm
    {
        public Button btnCancel;
        public Button btnOK;
        public ComBox cmbArea;
        public ComBox cmbFlagType;
        public GroupBox grpPoint;
        public Label lblAddress;
        public Label lblArea;
        public Label lblFlagType;
        public Label lblLat;
        public Label lblLon;
        public Panel pnlBtn;
        public TextBox txtAddress;
        private BackgroundWorker worker = new BackgroundWorker();

        public MapFlag(string sLon, string sLat, GisMap CurrentMap)
        {
            this.InitializeComponent();
            base.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
            this.numLon.Value = decimal.Parse(sLon);
            this.numLat.Value = decimal.Parse(sLat);
            this.m_CurrentMap = CurrentMap;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((this.cmbFlagType.SelectedValue == null) || (this.cmbArea.SelectedValue == null))
            {
                MessageBox.Show("标注类别或所属区域不能为空！");
            }
            else
            {
                string source = this.txtAddress.Text.Trim();
                string s = this.numLon.Value.ToString();
                string str2 = this.numLat.Value.ToString();
                string str4 = this.cmbFlagType.SelectedValue.ToString();
                string areaCode = this.cmbArea.SelectedValue.ToString();
                if (source == "")
                {
                    MessageBox.Show("名称不能为空！");
                }
                else if (this.cmbFlagType.Text == "(无)")
                {
                    MessageBox.Show("标注类别非法，请确定你是否有添加标注的权限!");
                }
                else
                {
                    if (chkString(source))
                    {
                        if (source.Length >= 50)
                        {
                            MessageBox.Show("字符长度不能超过50个！");
                            this.txtAddress.Focus();
                            return;
                        }
                        WaitForm.Show("正在更新地图标注，请稍候...", this);
                        if (RemotingClient.MapFlag_AddFlagMap(float.Parse(s), float.Parse(str2), source, areaCode, int.Parse(str4)) <= 0)
                        {
                            WaitForm.Hide();
                            MessageBox.Show("名称已存在！");
                            this.txtAddress.Focus();
                            return;
                        }
                        MainForm.myMap.showFlagMap(this.m_CurrentMap);
                        WaitForm.Hide();
                        base.DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("不许输入特殊字符！");
                        this.txtAddress.Focus();
                        return;
                    }
                    base.DialogResult = DialogResult.OK;
                }
            }
        }

        public static bool chkString(string source)
        {
            Regex regex = new Regex("[~!@#$%^&*()=+[\\]{}'\";:/?.,><`|！\x00b7￥…—（）\\、；：。，》《]");
            return !regex.IsMatch(source);
        }

 private void MapFlag_FormClosing(object sender, FormClosingEventArgs e)
        {
            WaitForm.Hide2();
        }

        private void MapFlag_Load(object sender, EventArgs e)
        {
            this.btnOK.Enabled = false;
            this.dtArea = new DataTable();
            this.dtArea.Columns.Add("AreaName", typeof(string));
            this.dtArea.Columns.Add("AreaCode", typeof(string));
            this.grpPoint.Enabled = false;
            base.Show();
            WaitForm.Show("正在加载类别与所属区域信息...", this);
            try
            {
                this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
                this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork);
                this.worker.WorkerReportsProgress = true;
                this.worker.RunWorkerAsync();
            }
            catch (Exception exception)
            {
                WaitForm.Hide();
                Record.execFileRecord("MapFlag->初期化", exception.ToString());
            }
        }

        private void setComValue()
        {
            this.dtFlag = RemotingClient.MapFlag_FlagMapType();
            DataTable allArea = MainForm.myCarList.GetAllArea();
            if ((allArea != null) && (allArea.Rows.Count > 0))
            {
                foreach (DataRow row in allArea.Rows)
                {
                    this.dtArea.Rows.Add(new object[] { row["areaName"].ToString() + "(" + row["areaCode"].ToString() + ")", row["areaCode"].ToString() });
                }
            }
            this.worker.ReportProgress(100);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.setComValue();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if ((this.dtFlag == null) || (this.dtFlag.Rows.Count <= 0))
                {
                    this.cmbFlagType.addItems("(无)", 0);
                }
                else
                {
                    foreach (DataRow row in this.dtFlag.Rows)
                    {
                        this.cmbFlagType.addItems(row["name"].ToString(), row["id"].ToString());
                    }
                    this.cmbFlagType.SelectedIndex = 0;
                }
                if ((this.dtArea != null) && (this.dtArea.Rows.Count > 0))
                {
                    this.dtArea.Columns["AreaName"].ColumnName = "Display";
                    this.dtArea.Columns["AreaCode"].ColumnName = "Value";
                    this.cmbArea.DataSource = this.dtArea;
                }
                this.btnOK.Enabled = true;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Record.execFileRecord("MapFlag->异步加裁完成事件", exception.StackTrace);
            }
            finally
            {
                this.grpPoint.Enabled = true;
                WaitForm.Hide();
            }
        }
    }
}

