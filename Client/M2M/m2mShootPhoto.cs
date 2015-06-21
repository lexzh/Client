using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.Application;
using ParamLibrary.CmdParamInfo;
using System.Collections;
using System.Threading;
using Remoting;
using PublicClass;

namespace Client.M2M
{
    public partial class m2mShootPhoto : CarForm
    {
        private BackgroundWorker _worker = new BackgroundWorker();
        private List<int> _选中摄像头 = new List<int>();
        private SimpleCmd m_SimpleCmd = new SimpleCmd();

        public m2mShootPhoto(CmdParam.OrderCode OrderCode)
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
                int[] numArray = this._选中摄像头.ToArray();
                int length = numArray.Length;
                int num2 = 0;
                if (length > 1)
                {
                    foreach (int num3 in numArray)
                    {
                        for (int i = 0; i < this.m_SimpleCmd.CmdParams.Count; i++)
                        {
                            (this.m_SimpleCmd.CmdParams[i] as string[])[0] = num3.ToString();
                        }
                        base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                        num2++;
                        this._worker.ReportProgress((int)((((double)num2) / ((double)length)) * 100.0));
                        Thread.Sleep(1500);
                    }
                }
                else
                {
                    for (int j = 0; j < this.m_SimpleCmd.CmdParams.Count; j++)
                    {
                        (this.m_SimpleCmd.CmdParams[j] as string[])[0] = this._选中摄像头[0].ToString();
                    }
                    base.reResult = RemotingClient.DownData_SetCommonCmd_FJYD(base.ParamType, base.sValue, base.sPw, CmdParam.CommMode.未知方式, this.m_SimpleCmd);
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("设置图像-->", exception.Message);
            }
        }

        private void _worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            double num = ((double)e.ProgressPercentage) / 100.0;
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

        private bool getParam()
        {
            this.m_SimpleCmd.OrderCode = base.OrderCode;
            int num = 0;
            this._选中摄像头.Clear();
            for (int i = 0; i < this.grpCamera.Controls.Count; i++)
            {
                CheckBox box = (CheckBox)this.grpCamera.Controls[i];
                if (box.Checked)
                {
                    num = i + 1;
                    this._选中摄像头.Add(Convert.ToInt16(box.Tag.ToString()));
                }
            }
            if (this._选中摄像头.Count == 0)
            {
                MessageBox.Show("请选择摄像头!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            if (base.OrderCode == CmdParam.OrderCode.图像设置指令)
            {
                int num3 = -1;
                for (int j = 0; j < this.grpModle.Controls.Count; j++)
                {
                    RadioButton button = (RadioButton)this.grpModle.Controls[j];
                    if (button.Checked)
                    {
                        num3 = j;
                        break;
                    }
                }
                if (num3 == -1)
                {
                    MessageBox.Show("拍照模式未选中");
                    return false;
                }
                if (this.rdoSequence.Checked)
                {
                    ArrayList list = new ArrayList();
                    string[] strArray = new string[] { num.ToString(), num3.ToString(), this.trkQuality.Value.ToString(), this.numInterval.Value.ToString() };
                    list.Add(strArray);
                    this.m_SimpleCmd.CmdParams = list;
                }
                else if (this.rdoCondition.Checked)
                {
                    num3 = 4;
                    ArrayList list2 = new ArrayList();
                    for (int k = 0; k < this.grpCondition.Controls.Count; k++)
                    {
                        CheckBox box2 = (CheckBox)this.grpCondition.Controls[k];
                        if (box2.Checked)
                        {
                            string[] strArray2 = new string[] { num.ToString(), num3.ToString(), this.trkQuality.Value.ToString(), box2.Tag.ToString() };
                            list2.Add(strArray2);
                        }
                    }
                    this.m_SimpleCmd.CmdParams = list2;
                    if (this.m_SimpleCmd.CmdParams.Count <= 0)
                    {
                        MessageBox.Show("请选择拍照条件！");
                        return false;
                    }
                }
                else
                {
                    ArrayList list3 = new ArrayList();
                    string[] strArray3 = new string[] { num.ToString(), num3.ToString(), this.trkQuality.Value.ToString(), "0" };
                    list3.Add(strArray3);
                    this.m_SimpleCmd.CmdParams = list3;
                }
            }
            return true;
        }

        private void m2mShootPhoto_Load(object sender, EventArgs e)
        {
            this.setGroupVisible();
            CmdParam.OrderCode orderCode = base.OrderCode;
        }

        private void rdoSequence_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoSequence.Checked)
            {
                this.numInterval.Value = 5M;
                this.numInterval.Minimum = 1M;
                this.numInterval.Enabled = true;
            }
            else
            {
                this.numInterval.Minimum = 0M;
                this.numInterval.Value = 0M;
                this.numInterval.Enabled = false;
            }
            if (this.rdoCondition.Checked)
            {
                this.grpCondition.Enabled = true;
            }
            else
            {
                this.grpCondition.Enabled = false;
            }
        }

        private void SetControlEnable(bool isuse)
        {
            this.pbPicWait.Visible = this.lblWaitText.Visible = !isuse;
            base.ControlBox = isuse;
            base.grpCar.Enabled = this.groupBox1.Enabled = base.btnCancel.Enabled = base.btnOK.Enabled = isuse;
        }

        private void setGroupVisible()
        {
            if (base.OrderCode != CmdParam.OrderCode.终端图片上传)
            {
                this.pnlPhoto.Visible = false;
            }
            if (base.OrderCode != CmdParam.OrderCode.图像设置指令)
            {
                this.pnlPhotoParam.Visible = false;
            }
        }

        private void trkQuality_ValueChanged(object sender, EventArgs e)
        {
            this.lblQualityValue.Text = this.trkQuality.Value.ToString();
        }
    }
}
