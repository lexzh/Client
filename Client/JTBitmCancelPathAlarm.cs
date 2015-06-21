namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using ParamLibrary.Application;
    using ParamLibrary.CmdParamInfo;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class JTBitmCancelPathAlarm : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public JTBitmCancelPathAlarm(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
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
                string[] strArray = base.sValue.Split(new char[] { ',' });
                int length = strArray.Length;
                int num2 = 0;
                if (length > 1)
                {
                    string[] strArray2 = strArray;
                    for (int i = 0; i < strArray2.Length; i++)
                    {
                        string text1 = strArray2[i];
                        base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                        num2++;
                        this._worker.ReportProgress((int) ((((double) num2) / ((double) length)) * 100.0));
                    }
                }
                else
                {
                    base.reResult = RemotingClient.DownData_SimpleCmd(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取消路线报警-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double num = ((double) e.ProgressPercentage) / 100.0;
            this.lblWaitText.Text = "已完成：" + num.ToString("P").Replace(".00", "");
        }

        private void _worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.SetControlEnable(true);
            if (base.reResult.ResultCode != 0L)
            {
                MessageBox.Show(base.reResult.ErrorMsg);
            }
            else
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                base.btnOK_Click(sender, e);
                if ((!string.IsNullOrEmpty(base.sValue) && this.getParam()) && !this._worker.IsBusy)
                {
                    this.SetControlEnable(false);
                    this._worker.RunWorkerAsync();
                }
            }
            catch (Exception exception)
            {
                this.SetControlEnable(true);
                MessageBox.Show(exception.Message);
            }
        }

        private void chkCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (CheckBoxItem item in this.chkLstArea.Items)
            {
                item.Checked = this.chkCheckAll.Checked;
            }
            this.chkLstArea.Enabled = !this.chkCheckAll.Checked;
        }

 private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            string str = "";
            if (!this.chkCheckAll.Checked)
            {
                foreach (CheckBoxItem item in this.chkLstArea.Items)
                {
                    if (item.Checked)
                    {
                        str = str + @"\" + item.Name;
                    }
                }
                if (string.IsNullOrEmpty(str))
                {
                    MessageBox.Show("未选中路线ID！");
                    return false;
                }
                this.m_SimpleCmd.RegionIds = str.Trim(new char[] { '\\' });
            }
            else
            {
                this.m_SimpleCmd.RegionIds = "0";
            }
            return true;
        }

 private void JTBitmCancelPathAlarm_Load(object sender, EventArgs e)
        {
            this.setGroupText();
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.grpCancelParam.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void setGroupText()
        {
            this.chkLstArea.Clear();
            DataTable pathAlarmChecked = RemotingClient.GetPathAlarmChecked(base.sCarId);
            if ((pathAlarmChecked != null) && (pathAlarmChecked.Rows.Count > 0))
            {
                DataRow[] rowArray = pathAlarmChecked.Select();
                int length = rowArray.Length;
                if ((pathAlarmChecked != null) && (length > 0))
                {
                    foreach (DataRow row in rowArray)
                    {
                        CheckBoxItem chk = new CheckBoxItem {
                            Text = row["pathname"].ToString(),
                            Name = row["newpathid"].ToString()
                        };
                        this.chkLstArea.Add(chk);
                    }
                }
            }
        }
    }
}

