using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Remoting;
using PublicClass;
using ParamLibrary.Application;

namespace Client.JTB
{
    public partial class PlatformcheckRoadSpeedAndRank : Client.CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();

        private string subsql = "delete from GpsCarCheckRoadSpeedAndRank where CarId = [A];";

        private string sql = "insert into GpsCarCheckRoadSpeedAndRank(CarId) select [A] ;";

        public PlatformcheckRoadSpeedAndRank(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
            this._worker.WorkerReportsProgress = true;
            this._worker.DoWork += new DoWorkEventHandler(this._worker_DoWork);
            this._worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this._worker_RunWorkerCompleted);
            this._worker.ProgressChanged += new ProgressChangedEventHandler(this._worker_ProgressChanged);
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string[] strArrays = this.sValue.Split(new char[] { ',' });
                int length = (int)strArrays.Length;
                int num = 0;
                string[] strArrays1 = strArrays;
                for (int i = 0; i < (int)strArrays1.Length; i++)
                {
                    string str = strArrays1[i];
                    string str1 = MainForm.myCarList.execChangeCarValue((int)this.ParamType, 0, str);
                    string str2 = MainForm.myCarList.execChangeCarValue((int)this.ParamType, 1, str);
                    this.reResult = RemotingClient.ExecNoQuery(this.subsql.Replace("[A]", str2));
                    string str3 = (this.reResult.ResultCode != (long)0 ? "失败" : "成功");
                    string dBCurrentDateTime = RemotingClient.GetDBCurrentDateTime();
                    if (string.IsNullOrEmpty(dBCurrentDateTime))
                    {
                        dBCurrentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    }
                    string str4 = "0";
                    string str5 = "发送";
                    string str6 = "设置分道路等级超速报警";
                    string str7 = "设置分道路等级超速报警";
                    str7 = str7.Trim(new char[] { '-' });
                    base.Invoke(new MethodInvoker(() => MainForm.myLogForms.myNewLog.AddUserMessageToNewLog(dBCurrentDateTime, str1, str4, str5, str6, str3, str7)));
                    num++;
                    this._worker.ReportProgress((int)((double)num / (double)length * 100));
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置分道路等级超速报警-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Label label = this.lblWaitText;
            double progressPercentage = (double)e.ProgressPercentage / 100;
            label.Text = string.Concat("已完成：", progressPercentage.ToString("P").Replace(".00", ""));
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            if (this.reResult.ResultCode == (long)0)
            {
                base.DialogResult = DialogResult.OK;
                return;
            }
            MessageBox.Show(this.reResult.ErrorMsg);
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if (!string.IsNullOrEmpty(this.sValue))
                {
                    if (this.getParam())
                    {
                        if (!this._worker.IsBusy)
                        {
                            this.SetControlEnable(false);
                            this._worker.RunWorkerAsync();
                        }
                    }
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                this.SetControlEnable(true);
                MessageBox.Show(exception.Message);
            }
        }

        private bool getParam()
        {
            if (this.chkOpen.Checked)
            {
                PlatformcheckRoadSpeedAndRank platformcheckRoadSpeedAndRank = this;
                platformcheckRoadSpeedAndRank.subsql = string.Concat(platformcheckRoadSpeedAndRank.subsql, this.sql);
            }
            return true;
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                if (RemotingClient.ExecSql(string.Format("select * from GpsCarCheckRoadSpeedAndRank where CarId = {0}", MainForm.myCarList.SelectedCarId)).Rows.Count > 0)
                {
                    this.chkOpen.Checked = true;
                }
            }
            catch
            {
            }
            base.OnLoad(e);
        }

        private void SetControlEnable(bool isuse)
        {
            PictureBox pictureBox = this.pbPicWait;
            bool flag = !isuse;
            bool flag1 = flag;
            this.lblWaitText.Visible = flag;
            pictureBox.Visible = flag1;
            base.ControlBox = isuse;
            GroupBox groupBox = this.grpCar;
            GroupBox groupBox1 = this.grpParam;
            Button button = this.btnCancel;
            bool flag2 = isuse;
            bool flag3 = flag2;
            this.btnOK.Enabled = flag2;
            bool flag4 = flag3;
            bool flag5 = flag4;
            button.Enabled = flag4;
            bool flag6 = flag5;
            bool flag7 = flag6;
            groupBox1.Enabled = flag6;
            groupBox.Enabled = flag7;
        }
    
    }
}
