using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace Client
{
    public partial class SetParam : Client.FixedForm
    {
        private SetLogFilterAlarmType alarmType;
        private string setLogFilterAlarmTypeValue = "";

        public SetParam()
        {
            InitializeComponent();
        }
        private void btnApp_Click(object sender, EventArgs e)
        {
            if (this.execSaveIni())
            {
                MessageBox.Show("参数保存成功！");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        private void btnDefaultCenter_Click(object sender, EventArgs e)
        {
            this.txtServerIp.Text = Variable.sServerIp;
            this.numPort.Value = int.Parse(Variable.sPort);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.execSaveIni())
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void btnSetAlarmSound_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "wav声音文件 (*.wav)|*.wav",
                FilterIndex = 0,
                RestoreDirectory = true,
                FileName = "alarm.wav",
                InitialDirectory = this.txtAlarmSoundFilePath.Text.Remove(this.txtAlarmSoundFilePath.Text.LastIndexOf("\\"))
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.txtAlarmSoundFilePath.Text = dialog.FileName;
            }
        }

        private void btnSetLogFilterAlarmType_Click(object sender, EventArgs e)
        {
            EventHandler handler = null;
            if (!Variable.bLogin)
            {
                MessageBox.Show("对不起，请登录系统后设置该参数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                if (this.alarmType == null)
                {
                    SetLogFilterAlarmType type = new SetLogFilterAlarmType
                    {
                        Visible = false
                    };
                    this.alarmType = type;
                    base.Controls.Add(this.alarmType);
                    this.drpSetLogFilterAlarmType = new WinFormsUI.Controls.AutoDropDown(this.alarmType);
                    base.Controls.Add(this.drpSetLogFilterAlarmType);
                    if (handler == null)
                    {
                        handler = delegate(object obj, EventArgs e1)
                        {
                            this.setLogFilterAlarmTypeValue = obj.ToString();
                            this.drpSetLogFilterAlarmType.HideDropDown();
                        };
                    }
                    this.alarmType.SetParam += handler;
                }
                this.alarmType.Init();
                this.drpSetLogFilterAlarmType.ShowDropDown(new Point(this.gbAlarm.Location.X + 40, this.gbAlarm.Location.Y + 20));
            }
        }

        private void btnSetLogFilterAlarmType_MouseEnter(object sender, EventArgs e)
        {
            if (this.tip == null)
            {
                this.tip = new ToolTip();
            }
            this.tip.Hide(this.btnSetLogFilterAlarmType);
            this.tip.Show("设置日志列表中日志类型列表项，须登录后方可设置该选项！", this.btnSetLogFilterAlarmType, this.btnSetLogFilterAlarmType.PointToClient(Point.Empty), 1000);
        }

        private void btnSoundSelect_Click(object sender, EventArgs e)
        {
        }

        private bool execReadIni()
        {
            try
            {
                this.txtServerIp.Text = Variable.sServerIp;
                this.numPort.Value = int.Parse(Variable.sPort);
                this.txtMapIp.Text = Variable.sMapIp;
                this.numMapPort.Value = int.Parse(Variable.sMapPort);
                this.txtGpsAdminIp.Text = Variable.sGpsIp;
                this.numGpsAdminPort.Value = int.Parse(Variable.sGpsPort);
                this.cmbAlarmSound.Text = Variable.sAlarmSoundStatus;
                this.txtAlarmSoundFilePath.Text = Variable.sAlarmSoundStatusFilePath;
                if (Variable.sCompressDownCarInfo == "1")
                {
                    this.rdoInternet.Checked = true;
                }
                else
                {
                    this.rdoLan.Checked = true;
                }
                if ("0".Equals(Variable.sUseHttpProxy))
                {
                    this.rbtnTcp.Checked = true;
                    this.rbtnHttpProxy.Checked = false;
                    this.txtProxyIp.Enabled = false;
                    this.numProxyPort.Enabled = false;
                }
                else
                {
                    this.rbtnTcp.Checked = false;
                    this.rbtnHttpProxy.Checked = true;
                }
                this.txtProxyIp.Text = Variable.sHttpProxyIp;
                this.numProxyPort.Value = int.Parse(Variable.sHttpProxyPort);
                this.chkAlarmWin.Checked = Variable.sAlarmPopupWindow.Trim().Equals("1", StringComparison.OrdinalIgnoreCase);
                this.chkUrgencySound.Checked = Variable.sCustomAlarmSound.Trim().Equals("1", StringComparison.OrdinalIgnoreCase);
                this.setLogFilterAlarmTypeValue = Variable.sLogFilterAlarmType;
                this.chkMapCarLegend.Checked = Variable.sMapCarLegendShowAreaName.Equals("1", StringComparison.OrdinalIgnoreCase);
                this.chkCarServerTimeRemind.Checked = Variable.sCarServerTimeRemind.Equals("1", StringComparison.OrdinalIgnoreCase);
                this.chkLogListAreaVisible.Checked = Variable.sLogListAreaVisible.Equals("1", StringComparison.OrdinalIgnoreCase);
                this.chkShowManagerSystem.Checked = Variable.sShowManagerSystem.Equals("1", StringComparison.OrdinalIgnoreCase);
                
                //建工显示车牌选项
                this.rbJGCode.Checked = Variable.sJGShowCar.Equals("1");
                this.rbCarNum.Checked = Variable.sJGShowCar.Equals("2");
                this.rbOrg.Checked = Variable.sJGShowCar.Equals("0");
            }
            catch (Exception exception)
            {
                Record.execFileRecord("SetParam－>读取配置", exception.Message);
            }
            this.setCarDetailShowType();
            this.setCarTipShowType();
            return true;
        }

        private bool execSaveIni()
        {
            if (string.IsNullOrEmpty(this.txtServerIp.Text))
            {
                MessageBox.Show("服务器IP地址不能为空！");
                this.tcSetParam.SelectedTab = this.tpCenter;
                this.txtServerIp.Focus();
                return false;
            }
            //if (string.IsNullOrEmpty(this.txtMapIp.Text))
            //{
            //    MessageBox.Show("地图IP地址不能为空！");
            //    this.txtMapIp.Focus();
            //    return false;
            //}
            if (string.IsNullOrEmpty(this.txtGpsAdminIp.Text))
            {
                MessageBox.Show("管理分析系统IP地址不能为空！");
                this.txtGpsAdminIp.Focus();
                return false;
            }
            if ((Variable.sMapIp != this.txtMapIp.Text) || (Variable.sMapPort != Convert.ToInt32(this.numMapPort.Value).ToString()))
            {
                Variable.bMapRefresh = true;
            }
            if (this.rdoInternet.Checked)
            {
                Variable.sCompressDownCarInfo = "1";
            }
            else
            {
                Variable.sCompressDownCarInfo = "0";
            }
            Variable.sServerIp = this.txtServerIp.Text;
            Variable.sPort = Convert.ToInt32(this.numPort.Value).ToString();
            Variable.sMapIp = this.txtMapIp.Text;
            Variable.sMapPort = Convert.ToInt32(this.numMapPort.Value).ToString();
            Variable.sGpsIp = this.txtGpsAdminIp.Text;
            Variable.sGpsPort = Convert.ToInt32(this.numGpsAdminPort.Value).ToString();
            //Variable.sMapIp = Variable.sGpsIp + ":" + Variable.sGpsPort; //修改地图服务器地址默认为管理分析系统地址 huzh 2014.3.14
            Variable.sMapName = "StarGIS"; //地图服务器名称默认为 maps， huzh 2014.3.14
            Variable.sGetNodeDetailShowType = this.getNodeDetailShowTypw();
            Variable.sGetNodeTipShowType = this.getNodeTipShowType();
            Variable.sAlarmSoundStatus = this.cmbAlarmSound.Text;
            Variable.sAlarmSoundStatusFilePath = this.txtAlarmSoundFilePath.Text;
            Variable.sUseHttpProxy = this.rbtnTcp.Checked ? "0" : "1";
            Variable.sHttpProxyIp = this.txtProxyIp.Text;
            Variable.sHttpProxyPort = this.numProxyPort.Value.ToString();
            Variable.sAlarmPopupWindow = this.chkAlarmWin.Checked ? "1" : "0";
            Variable.sCustomAlarmSound = this.chkUrgencySound.Checked ? "1" : "0";
            Variable.sLogFilterAlarmType = this.setLogFilterAlarmTypeValue;
            Variable.sMapCarLegendShowAreaName = this.chkMapCarLegend.Checked ? "1" : "0";
            Variable.sCarServerTimeRemind = this.chkCarServerTimeRemind.Checked ? "1" : "0";
            Variable.sLogListAreaVisible = this.chkLogListAreaVisible.Checked ? "1" : "0";
            Variable.sShowManagerSystem = this.chkShowManagerSystem.Checked ? "1" : "0";
            Variable.sJGShowCar = this.rbJGCode.Checked ? "1" : (this.rbCarNum.Checked ? "2" : "0");
            IniFile.WriteIniFile();
            return true;
        }

        private string getNodeDetailShowTypw()
        {
            int num = 0;
            if (this.cboxCarShowCarName.Checked)
            {
                num++;
            }
            if (this.cboxCarShowReceTime.Checked)
            {
                num += 2;
            }
            if (this.cboxCarShowGpsTime.Checked)
            {
                num += 4;
            }
            if (this.cboxCarShowCurrentAddress.Checked)
            {
                num += 8;
            }
            if (this.cboxCarShowSpeed.Checked)
            {
                num += 16;
            }
            if (this.cboxCarShowALLDiff.Checked)
            {
                num += 32;
            }
            if (this.cboxCarShowLonLan.Checked)
            {
                num += 64;
            }
            if (this.cboxCarShowIsFill.Checked)
            {
                num += 128;
            }
            if (this.cboxCarShowDirection.Checked)
            {
                num += 256;
            }
            if (this.cboxCarShowEndTime.Checked)
            {
                num += 512;
            }
            return num.ToString();
        }

        private string getNodeTipShowType()
        {
            int num = 0;
            if (this.cboxCarTipCarArea.Checked)
            {
                num++;
            }
            if (this.cboxCarTipCarType.Checked)
            {
                num += 2;
            }
            if (this.cboxCarTipCarColor.Checked)
            {
                num += 4;
            }
            if (this.cboxCarTipCarPName.Checked)
            {
                num += 8;
            }
            if (this.cboxCarTipCarPTel.Checked)
            {
                num += 16;
            }
            if (this.cboxCarTipCarPCompany.Checked)
            {
                num += 32;
            }
            if (this.cboxCarTipCarPEmail.Checked)
            {
                num += 64;
            }
            if (this.cboxCarTipCarPID.Checked)
            {
                num += 128;
            }
            if (this.cboxCarTipFirstName.Checked)
            {
                num += 256;
            }
            if (this.cboxCarTipFirstTel.Checked)
            {
                num += 512;
            }
            if (this.cboxCarTipSecondName.Checked)
            {
                num += 1024;
            }
            if (this.cboxCarTipSecondTel.Checked)
            {
                num += 2048;
            }
            return num.ToString();
        }

        private void rbtnHttpProxy_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbtnTcp.Checked)
            {
                this.txtProxyIp.Enabled = false;
                this.numProxyPort.Enabled = false;
            }
            else
            {
                this.txtProxyIp.Enabled = true;
                this.numProxyPort.Enabled = true;
            }
        }

        private void setCarDetailShowType()
        {
            int num = int.Parse(Variable.sGetNodeDetailShowType);
            if (num != 0)
            {
                if ((num & 1) != 0)
                {
                    this.cboxCarShowCarName.Checked = true;
                }
                else
                {
                    this.cboxCarShowCarName.Checked = false;
                }
                if ((num & 2) != 0)
                {
                    this.cboxCarShowReceTime.Checked = true;
                }
                else
                {
                    this.cboxCarShowReceTime.Checked = false;
                }
                if ((num & 4) != 0)
                {
                    this.cboxCarShowGpsTime.Checked = true;
                }
                else
                {
                    this.cboxCarShowGpsTime.Checked = false;
                }
                if ((num & 8) != 0)
                {
                    this.cboxCarShowCurrentAddress.Checked = true;
                }
                else
                {
                    this.cboxCarShowCurrentAddress.Checked = false;
                }
                if ((num & 16) != 0)
                {
                    this.cboxCarShowSpeed.Checked = true;
                }
                else
                {
                    this.cboxCarShowSpeed.Checked = false;
                }
                if ((num & 32) != 0)
                {
                    this.cboxCarShowALLDiff.Checked = true;
                }
                else
                {
                    this.cboxCarShowALLDiff.Checked = false;
                }
                if ((num & 64) != 0)
                {
                    this.cboxCarShowLonLan.Checked = true;
                }
                else
                {
                    this.cboxCarShowLonLan.Checked = false;
                }
                if ((num & 128) != 0)
                {
                    this.cboxCarShowIsFill.Checked = true;
                }
                else
                {
                    this.cboxCarShowIsFill.Checked = false;
                }
                if ((num & 256) != 0)
                {
                    this.cboxCarShowDirection.Checked = true;
                }
                else
                {
                    this.cboxCarShowDirection.Checked = false;
                }
                if ((num & 512) != 0)
                {
                    this.cboxCarShowEndTime.Checked = true;
                }
                else
                {
                    this.cboxCarShowEndTime.Checked = false;
                }
            }
        }

        private void setCarTipShowType()
        {
            int num = int.Parse(Variable.sGetNodeTipShowType);
            if (num == 0)
            {
                this.cboxCarTipCarType.Checked = false;
            }
            else
            {
                this.cboxCarTipCarArea.Checked = false;
                if ((num & 1) != 0)
                {
                    this.cboxCarTipCarArea.Checked = true;
                }
                this.cboxCarTipCarType.Checked = false;
                if ((num & 2) != 0)
                {
                    this.cboxCarTipCarType.Checked = true;
                }
                this.cboxCarTipCarColor.Checked = false;
                if ((num & 4) != 0)
                {
                    this.cboxCarTipCarColor.Checked = true;
                }
                this.cboxCarTipCarPName.Checked = false;
                if ((num & 8) != 0)
                {
                    this.cboxCarTipCarPName.Checked = true;
                }
                this.cboxCarTipCarPTel.Checked = false;
                if ((num & 16) != 0)
                {
                    this.cboxCarTipCarPTel.Checked = true;
                }
                this.cboxCarTipCarPCompany.Checked = false;
                if ((num & 32) != 0)
                {
                    this.cboxCarTipCarPCompany.Checked = true;
                }
                this.cboxCarTipCarPEmail.Checked = false;
                if ((num & 64) != 0)
                {
                    this.cboxCarTipCarPEmail.Checked = true;
                }
                this.cboxCarTipCarPID.Checked = false;
                if ((num & 128) != 0)
                {
                    this.cboxCarTipCarPID.Checked = true;
                }
                this.cboxCarTipFirstName.Checked = false;
                if ((num & 256) != 0)
                {
                    this.cboxCarTipFirstName.Checked = true;
                }
                this.cboxCarTipFirstTel.Checked = false;
                if ((num & 512) != 0)
                {
                    this.cboxCarTipFirstTel.Checked = true;
                }
                this.cboxCarTipSecondName.Checked = false;
                if ((num & 1024) != 0)
                {
                    this.cboxCarTipSecondName.Checked = true;
                }
                this.cboxCarTipSecondTel.Checked = false;
                if ((num & 2048) != 0)
                {
                    this.cboxCarTipSecondTel.Checked = true;
                }
            }
        }

        private void setManagerSystemState()
        {
            if (Variable.sShowManagerSystem.Equals("0", StringComparison.OrdinalIgnoreCase))
            {
                this.tcSetParam.TabPages.Remove(this.tcSetParam.TabPages["tbGpsAdmin"]);
            }
        }

        private void SetParam_Load(object sender, EventArgs e)
        {
            Variable.bMapRefresh = false;
            this.execReadIni();
            this.setManagerSystemState();
        }

        public enum NodeDetailShowType
        {
            当前位置 = 8,
            到期时间 = 512,
            定位时间 = 4,
            方向角 = 256,
            基本信息 = 1,
            经纬度 = 64,
            上报时间 = 2,
            速度 = 16,
            运营状态 = 128,
            总里程 = 32
        }

        public enum NodeTipShowType
        {
            车辆类型 = 2,
            车辆颜色 = 4,
            车主EMAIL = 64,
            车主电话 = 16,
            车主身份证号码 = 128,
            车主姓名 = 8,
            第二联系人电话 = 2048,
            第二联系人姓名 = 1024,
            第一联系人电话 = 512,
            第一联系人姓名 = 256,
            工作单位 = 32,
            所属区域 = 1
        }
    
    }
}
