namespace Client
{
    using Remoting;
    using ParamLibrary.CarEntity;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class itmCarDetail : FixedForm
    {
        public Button btnClose;
        private static DateTime NullDate = DateTime.Parse("0001-1-1 00:00:00");

        public itmCarDetail()
        {
            this.InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

 private void initControl()
        {
            string carId = MainForm.myCarList.SelectedCarId.Split(new char[] { ',' })[0];
            CommonCar car = new CommonCar();
            car = RemotingClient.Car_GetCarDetailInfoByCarId(carId);
            if (car != null)
            {
                this.lblAreaValue.Text = car.areaName;
                this.lblCarIdValue.Text = car.id.ToString();
                this.lblCarNumValue.Text = car.carNum;
                this.lblSimNumValue.Text = car.tele;
                this.lblCarTypeValue.Text = car.carType;
                if (car.svrBeginTime.CompareTo(NullDate) != 0)
                {
                    this.lblServerStartTimeValue.Text = string.Format("{0}", car.svrBeginTime.ToString());
                }
                if (car.svrEndTime.CompareTo(NullDate) != 0)
                {
                    this.lblServerEndTimeValue.Text = string.Format("{0}", car.svrEndTime.ToString());
                }
                this.lblAheadDateValue.Text = car.awokeDays.ToString();
                if (car.createTime.CompareTo(NullDate) != 0)
                {
                    this.lblRegistrationTimeValue.Text = string.Format("{0}", car.createTime.ToString());
                }
                this.lblColorValue.Text = car.CarColor;
                if (car.SimBeginTime.CompareTo(NullDate) != 0)
                {
                    this.lblSimStartTimeValue.Text = string.Format("{0}", car.SimBeginTime.ToString());
                }
                if (car.SimEndTime.CompareTo(NullDate) != 0)
                {
                    this.lblSimEndTimeValue.Text = string.Format("{0}", car.SimEndTime.ToString());
                }
                this.lblSimPasswordValue.Text = car.SIMpassport;
                DateTime now = DateTime.Now;
                bool result = false;
                if (bool.TryParse(this.lblServerEndTimeValue.Text, out result))
                {
                    if (Convert.ToDateTime(this.lblServerEndTimeValue.Text) >= DateTime.Now)
                    {
                        this.txtCarState.Text = "正常运营";
                    }
                    else
                    {
                        this.txtCarState.Text = "停运";
                    }
                }
                else
                {
                    this.txtCarState.Text = "正常运营";
                }
                
                this.txtPlateColor.Text = car.CarColor;
                
                //去掉新版本不存在的东西 周立山 2014.1.16
                //this.txtOperateTypeName.Text = car.OperateTypeName;
                this.lblTerminalTypeValue.Text = car.terminalName;
                this.lblTerminalVersionValue.Text = car.terminalSoftVersion;
                if (car.isSupportMSM)
                {
                    this.lblSupportMsgValue.Text = "是";
                }
                else
                {
                    this.lblSupportMsgValue.Text = "否";
                }
                if (car.isSupportGPRS)
                {
                    this.lblSupportGprsValue.Text = "是";
                }
                else
                {
                    this.lblSupportGprsValue.Text = "否";
                }
                if (car.isSupportCDMA)
                {
                    this.lblSupportCdmaValue.Text = "是";
                }
                else
                {
                    this.lblSupportCdmaValue.Text = "否";
                }
                this.txtTermSerial.Text = car.TermSerial;
                this.lblCarBrandValue.Text = car.CarModel;
                this.lblOwnerNameValue.Text = car.OwnerName;
                this.lblOwnerSimNumValue.Text = car.OwnerSimNum;
                this.lblOwnerEmailValue.Text = car.OwnerEmail;
                this.lblIdentityCardValue.Text = car.PersonID;
                this.lblAddressValue.Text = car.HomeAddress;
                this.lblCompanyValue.Text = car.CorpName;
                this.lblFirstLinkmanValue.Text = car.FirstConnectorName;
                this.lblFirstLinkmanTelValue.Text = car.FirstConnectTele;
                this.lblSecondLinkmanValue.Text = car.ConnectorName;
                this.lblSecondLinkmanTelValue.Text = car.ConnectTele;
                this.lblSteelGradeValue.Text = car.SteelGrade;
                this.lblDriverNameValue.Text = car.DrverName;
                this.lblDriverPhoneValue.Text = car.DriverPhone;
                this.lblRemarkValue.Text = car.Remark;
            }
        }

        private void initControlUi()
        {
            if (((MainForm.myCarList.tvList.SelectedNode != null) && (MainForm.myCarList.tvList.SelectedNode.Tag != null)) && "AREA".Equals(MainForm.myCarList.tvList.SelectedNode.Tag.ToString(), StringComparison.OrdinalIgnoreCase))
            {
                this.Text = "详细信息";
                this.tcAttribute.TabPages.RemoveByKey("tpBasic");
                this.tcAttribute.TabPages.RemoveByKey("tpTerminal");
                this.tcAttribute.TabPages.RemoveByKey("tpOther");
                this.tcAttribute.TabPages.RemoveByKey("tpRemark");
                ThreeStateTreeNode selectedNode = MainForm.myCarList.tvList.SelectedNode as ThreeStateTreeNode;
                string carId = selectedNode.CarId;
                DataRow[] rowArray = MainForm.myCarList.AreaList.Select("areacode='" + carId + "'");
                if ((rowArray != null) && (rowArray.Length > 0))
                {
                    foreach (Control control in this.tcAttribute.TabPages["tpRegion"].Controls)
                    {
                        if ((control is TextBox) && MainForm.myCarList.AreaList.Columns.Contains(control.Tag.ToString()))
                        {
                            control.Text = (rowArray[0][control.Tag.ToString()] != null) ? rowArray[0][control.Tag.ToString()].ToString() : " ";
                        }
                    }
                }
            }
            else
            {
                this.tcAttribute.TabPages.RemoveByKey("tpRegion");
                this.initControl();
            }
        }

 private void itmCarDetail_Load(object sender, EventArgs e)
        {
            this.initControlUi();
        }
    }
}

