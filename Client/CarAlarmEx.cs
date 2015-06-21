namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class CarAlarmEx : CarAlerm
    {

        public CarAlarmEx(string _carID, string alermType, string gpsTime, string Longitude, string Latitude) : base(_carID, alermType, gpsTime, Longitude, Latitude)
        {
            this._报警车数量 = -2147483648;
            this._显示当前车辆 = -2147483648;
            this.InitializeComponent();
            this.InitControl(_carID);
        }

        protected override void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnNextInfo_Click(object sender, EventArgs e)
        {
            try
            {
                base.Enabled = false;
                if ((this._报警车数量 == -2147483648) || (this._报警车数量 != MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count))
                {
                    this._报警车数量 = MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count;
                    this._显示当前车辆 = 0;
                }
                bool flag = false;
                bool flag2 = false;
                while (this._显示当前车辆 < MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count)
                {
                    if (MainForm.myCarList.tvTrackCar.Nodes[0].Nodes[this._显示当前车辆].ForeColor == Color.Red)
                    {
                        flag = true;
                        break;
                    }
                    this._显示当前车辆++;
                    if ((this._显示当前车辆 == MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count) && !flag2)
                    {
                        this._显示当前车辆 = 0;
                        flag2 = true;
                    }
                }
                if (!flag)
                {
                    for (int i = 0; i < MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count; i++)
                    {
                        if (MainForm.myCarList.tvTrackCar.Nodes[0].Nodes[i].ForeColor == Color.Red)
                        {
                            this._显示当前车辆 = i;
                            flag = true;
                            break;
                        }
                    }
                }
                if (!flag)
                {
                    MessageBox.Show("已查看所有车辆最新报警信息!");
                }
                else
                {
                    TreeNode node = MainForm.myCarList.tvTrackCar.Nodes[0].Nodes[this._显示当前车辆];
                    string name = node.Name;
                    DataRow row = MainForm.myCarList.m_dtCarAlermList.Rows.Find(name);
                    if (row != null)
                    {
                        string alermType = row["statuName"].ToString();
                        string gpsTime = row["ReceTime"].ToString();
                        string longitude = row["Longitude"].ToString();
                        string latitude = row["Latitude"].ToString();
                        base.ResetControl(name, alermType, gpsTime, longitude, latitude);
                        MainForm.myCarList.tvTrackCar.SetSelectedNodes(node as ThreeStateTreeNode);
                        MainForm.myCarList.setNodeFontDefault(node as ThreeStateTreeNode);
                    }
                    if (this._显示当前车辆 < (MainForm.myCarList.tvTrackCar.Nodes[0].Nodes.Count - 1))
                    {
                        this._显示当前车辆++;
                    }
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("车辆警报弹出窗口==>", exception.Message);
            }
            finally
            {
                base.Enabled = true;
            }
        }

        protected override void CarAlerm_FormClosing(object sender, FormClosingEventArgs e)
        {
            base.CarAlerm_FormClosing(sender, e);
        }

 private void InitControl(string carid)
        {
            Button button;
            Size s = new Size(69, 23);  ///add   ->  strdistanceDiff.Width
            button = new Button {
                Text = "下一条",
                Size = new Size(69, 23),
                Location = new Point((base.btnStopReport.Location.X - s.Width) - 10, base.btnStopReport.Location.Y)
            };
            button.Click += new EventHandler(this.btnNextInfo_Click);
            base.pnlBtn.Controls.Add(button);
            base.btnClose.Text = "关闭";
            MainForm.myCarList.tvTrackCar.SetSelectedNodes(MainForm.myCarList.tvTrackCar.getNodeById(carid));
        }


    }
}