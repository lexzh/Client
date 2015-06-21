namespace Client
{
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CarEntity;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class CarAlerm : FixedForm
    {
        public Button btnClose;
        public Button btnRealTimeReport;
        public Button btnStopReport;
        public Panel pnlBtn;

        private CarAlerm()
        {
            this.sCarID = string.Empty;
            this.InitializeComponent();
        }

        public CarAlerm(string _carID, string alermType, string gpsTime, string Longitude, string Latitude) : this()
        {
            this.sCarID = _carID;
            this.lblAlermTypeValue.Text = alermType;
            this.lblAlermTimeValue.Text = gpsTime;
            this.lblLongitudeValue.Text = Longitude;
            this.lblLatitudeValue.Text = Latitude;
        }

        protected virtual void btnClose_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnRealTimeReport_Click(object sender, EventArgs e)
        {
            ThreeStateTreeNode myNode = MainForm.myCarList.tvList.getNodeById(this.sCarID);
            if (myNode != null)
            {
                MainForm.myCarList.tvList.SetSelectedNodes(myNode);
                ThreeStateTreeNode node2 = MainForm.myCarList.tvTrackCar.getNodeById(this.sCarID);
                if (node2 != null)
                {
                    MainForm.myCarList.tvTrackCar.SetSelectedNodes(node2);
                }
                itmRealTimeReport report2 = new itmRealTimeReport(CmdParam.OrderCode.实时监控) {
                    Text = "实时监控"
                };
                report2.ShowDialog();
            }
        }

        private void btnStopReport_Click(object sender, EventArgs e)
        {
            ThreeStateTreeNode myNode = MainForm.myCarList.tvList.getNodeById(this.sCarID);
            if (myNode != null)
            {
                MainForm.myCarList.tvList.SetSelectedNodes(myNode);
                ThreeStateTreeNode node2 = MainForm.myCarList.tvTrackCar.getNodeById(this.sCarID);
                if (node2 != null)
                {
                    MainForm.myCarList.tvTrackCar.SetSelectedNodes(node2);
                }
                int platalarmType = -1;
                if (this.lblAlermTypeValue.Text.IndexOf("平台偏离路线") >= 0)
                {
                    platalarmType = 0;
                    itmStopReport report2 = new itmStopReport(CmdParam.OrderCode.停止报警, platalarmType) {
                        Text = "停止报警"
                    };
                    report2.ShowDialog();
                }
                else if (this.lblAlermTypeValue.Text.IndexOf("平台区域") >= 0)
                {
                    platalarmType = 1;
                    itmStopReport report4 = new itmStopReport(CmdParam.OrderCode.停止报警, platalarmType) {
                        Text = "停止报警"
                    };
                    report4.ShowDialog();
                }
                else if (this.lblAlermTypeValue.Text.IndexOf("平台分路段限速") >= 0)
                {
                    platalarmType = 2;
                    itmStopReport report6 = new itmStopReport(CmdParam.OrderCode.停止报警, platalarmType) {
                        Text = "停止报警"
                    };
                    report6.ShowDialog();
                }
                else
                {
                    itmStopReport report8 = new itmStopReport(CmdParam.OrderCode.停止报警) {
                        Text = "停止报警"
                    };
                    report8.ShowDialog();
                }
            }
        }

        protected virtual void CarAlerm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

 private void InitControl()
        {
            string sCarID = this.sCarID;
            CommonCar car = new CommonCar();
            car = RemotingClient.Car_GetCarDetailInfoByCarId(sCarID);
            if (car != null)
            {
                this.lblAreaValue.Text = car.areaName;
                this.lblCarNumValue.Text = car.carNum;
                this.lblCarIdValue.Text = car.id.ToString();
                this.lblSimNumValue.Text = car.tele;
                this.lblOwnerNameValue.Text = car.OwnerName;
                this.lblOwnerSimNumValue.Text = car.OwnerSimNum;
                this.lblCompanyValue.Text = car.CorpName;
                this.lblFirstLinkmanValue.Text = car.FirstConnectorName;
                this.lblFirstLinkmanTelValue.Text = car.FirstConnectTele;
                this.lblCarBrandValue.Text = car.CarModel;
                this.lblColorValue.Text = car.CarColor;
                this.lblSecondLinkmanValue.Text = car.ConnectorName;
                this.lblSecondLinkmanTelValue.Text = car.ConnectTele;
                this.lblIdentityCardValue.Text = car.PersonID;
                this.lblAddressValue.Text = car.HomeAddress;
                this.lblOwnerSimNumValue.Text = car.OwnerSimNum;
                this.lblOwnerSexValue.Text = car.Sex;
                this.lblPostCodeValue.Text = car.PostCode;
            }
        }

 private void itmCarAlerm_Load(object sender, EventArgs e)
        {
            this.InitControl();
        }

        internal void ResetControl(string _carID, string alermType, string gpsTime, string Longitude, string Latitude)
        {
            this.sCarID = _carID;
            this.lblAlermTypeValue.Text = alermType;
            this.lblAlermTimeValue.Text = gpsTime;
            this.lblLongitudeValue.Text = Longitude;
            this.lblLatitudeValue.Text = Latitude;
            this.InitControl();
        }
    }
}

