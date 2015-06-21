using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ParamLibrary.Application;
using ParamLibrary.Entity;
using WinFormsUI.Controls;
using PublicClass;
using Remoting;
using System.Collections;

namespace Client
{
    public partial class CarForm : Client.FixedForm
    {
        public CmdParam.ParamType ParamType;

        protected Response reResult;

        public string sType = "";

        public string sValue = "";

        public string sPw = "";

        public string sCarId = "";

        public string sCarNum = "";

        public string sCarSimNum = "";

        private BackgroundWorker myWorker;

        protected CmdParam.OrderCode OrderCode
        {
            get;
            set;
        }

        public CarForm()
        {
            InitializeComponent();
            this.setComTypeValue();
        }

        protected virtual void btnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
        }

        protected virtual void btnOK_Click(object sender, EventArgs e)
        {
            this.sValue = this.txtCarNo.Text.Trim();
            if (!this.saveCarFormParam())
            {
                return;
            }
            DataTable allCarEx = MainForm.myCarList.GetAllCar();
            if (!this.cmbType.SelectedValue.ToString().Equals("3"))
            {
                this.ParamType = (CmdParam.ParamType)this.cmbType.SelectedValue;
            }
            else
            {
                this.ParamType = CmdParam.ParamType.CarId;
                string caridByWaybillCode = MainForm.myCarList.getCaridByWaybillCode(ref this.sValue);
                if (!string.IsNullOrEmpty(caridByWaybillCode))
                {
                    MessageBox.Show(caridByWaybillCode);
                    this.sValue = "";
                    return;
                }
            }
            this.sPw = this.txtPassword.Text;
            if (this.sValue.Length <= 0)
            {
                MessageBox.Show("请输入查询内容！");
                this.txtCarNo.Focus();
                return;
            }
            string str = "SimNum='{0}'";
            switch (this.ParamType)
            {
                case CmdParam.ParamType.CarNum:
                    {
                        if (this.sValue == this.sCarNum)
                        {
                            return;
                        }
                        str = "CarNum='{0}'";
                        break;
                    }
                case CmdParam.ParamType.CarId:
                    {
                        if (this.sValue == this.sCarId)
                        {
                            return;
                        }
                        str = "CarId='{0}'";
                        break;
                    }
                case CmdParam.ParamType.SimNum:
                    {
                        if (this.sValue == this.sCarSimNum)
                        {
                            return;
                        }
                        str = "SimNum='{0}'";
                        break;
                    }
            }
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string[] strArrays = this.sValue.Split(new char[] { ',' });
            try
            {
                string[] strArrays1 = strArrays;
                int num = 0;
                while (num < (int)strArrays1.Length)
                {
                    string str4 = strArrays1[num];
                    DataView dataViews = new DataView(allCarEx, string.Format(str, str4), "", DataViewRowState.CurrentRows);
                    if (dataViews.Count > 0)
                    {
                        str1 = string.Concat(str1, dataViews[0]["CarId"].ToString(), ",");
                        str2 = string.Concat(str2, dataViews[0]["CarNum"].ToString(), ",");
                        str3 = string.Concat(str3, dataViews[0]["SimNum"].ToString(), ",");
                        num++;
                    }
                    else
                    {
                        MessageBox.Show(string.Format("目标车辆：{0}，不存在。", str4));
                        this.sValue = "";
                        this.txtCarNo.Focus();
                        return;
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(string.Format("查询内容输入错误，请检查。", new object[0]));
                this.sValue = "";
                this.txtCarNo.Focus();
                return;
            }
            char[] chrArray = new char[] { ',' };
            this.sCarId = str1.Trim(chrArray);
            char[] chrArray1 = new char[] { ',' };
            this.sCarNum = str2.Trim(chrArray1);
            char[] chrArray2 = new char[] { ',' };
            this.sCarSimNum = str3.Trim(chrArray2);
        }

        private void CarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void comType_SelectedValueChanged(object sender, EventArgs e)
        {
            this.setCarValue();
        }

        private void getCarFormParam()
        {
            this.setCarValue();
            try
            {
                if (base.Controls.Count > 2)
                {
                    if (this.myWorker == null)
                    {
                        this.myWorker = new BackgroundWorker();
                        this.myWorker.DoWork += new DoWorkEventHandler(this.myWorker_DoWork);
                        this.myWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.myWorker_RunWorkerCompleted);
                    }
                    WaitForm.Show("正在初始化参数，请稍候...", this);
                    this.setControlEnable(false);
                    this.myWorker.RunWorkerAsync();
                }
            }
            catch (Exception exception)
            {
                Record.execFileRecord("取得界面参数异步", exception.Message);
            }
        }

        private string getChkText(bool isChecked)
        {
            return Check.getChkText(isChecked);
        }

        private string getCmnParam(Control ctrl)
        {
            string str = "";
            foreach (Control control in ctrl.Controls)
            {
                if (!control.Visible || control.Tag != null && (control.Tag.ToString().Equals("9999") || control.Tag.ToString().Equals("999") || control.Tag.ToString().Equals("99999")))
                {
                    continue;
                }
                string name = control.GetType().Name;
                string str1 = name;
                if (name != null)
                {
                    switch (str1)
                    {
                        case "TextBox":
                        case "DateTimePicker":
                            {
                                str = string.Concat(str, string.Format("{0}；", control.Text));
                                continue;
                            }
                        case "ComboBox":
                        case "ComBox":
                            {
                                str = string.Concat(str, control.Text, control.Tag);
                                continue;
                            }
                        case "Label":
                            {
                                str = string.Concat(str, control.Text, control.Tag);
                                continue;
                            }
                        case "NumericUpDown":
                            {
                                str = string.Concat(str, ((NumericUpDown)control).Text.ToString(), control.Tag);
                                continue;
                            }
                        case "TrackBar":
                            {
                                int value = ((TrackBar)control).Value;
                                str = string.Concat(str, value.ToString(), control.Tag);
                                continue;
                            }
                        case "CheckBox":
                            {
                                str = string.Concat(str, string.Format("{0}：{1}；", control.Text, this.getChkText(((CheckBox)control).Checked)));
                                continue;
                            }
                        case "RadioButton":
                            {
                                str = string.Concat(str, string.Format("{0}：{1}；", control.Text, this.getChkText(((RadioButton)control).Checked)));
                                continue;
                            }
                        case "CheckedListBox":
                            {
                                IEnumerator enumerator = ((CheckedListBox)control).CheckedItems.GetEnumerator();
                                try
                                {
                                    while (enumerator.MoveNext())
                                    {
                                        System.Web.UI.WebControls.ListItem current = (System.Web.UI.WebControls.ListItem)enumerator.Current;
                                        str = string.Concat(str, string.Format("{0}：{1}；", current.Text, this.getChkText(true)));
                                    }
                                    continue;
                                }
                                finally
                                {
                                    IDisposable disposable = enumerator as IDisposable;
                                    if (disposable != null)
                                    {
                                        disposable.Dispose();
                                    }
                                }
                                break;
                            }
                        case "DataGridView":
                            {
                                DataGridView dataGridView = (DataGridView)control;
                                string str2 = "";
                                bool flag = false;
                                bool flag1 = false;
                                IEnumerator enumerator1 = ((IEnumerable)dataGridView.Rows).GetEnumerator();
                                try
                                {
                                    while (enumerator1.MoveNext())
                                    {
                                        DataGridViewRow dataGridViewRow = (DataGridViewRow)enumerator1.Current;
                                        str2 = "";
                                        flag1 = false;
                                        flag = false;
                                        IEnumerator enumerator2 = dataGridView.Columns.GetEnumerator();
                                        try
                                        {
                                            while (enumerator2.MoveNext())
                                            {
                                                DataGridViewColumn dataGridViewColumn = (DataGridViewColumn)enumerator2.Current;
                                                if (!dataGridViewColumn.Visible)
                                                {
                                                    continue;
                                                }
                                                if (dataGridViewColumn.Tag != null && dataGridViewColumn.Tag.Equals("Chk"))
                                                {
                                                    flag1 = true;
                                                    if (dataGridViewRow.Cells[dataGridViewColumn.Name].Value.ToString() == "1" || dataGridViewRow.Cells[dataGridViewColumn.Name].Value.ToString().ToLower() == "true")
                                                    {
                                                        flag = true;
                                                    }
                                                }
                                                if (dataGridViewColumn.GetType().Name != "DataGridViewCheckBoxColumn")
                                                {
                                                    if (string.IsNullOrEmpty(string.Concat(dataGridViewRow.Cells[dataGridViewColumn.Name].Value)))
                                                    {
                                                        continue;
                                                    }
                                                    str2 = string.Concat(str2, string.Format("{0}：{1}；", dataGridViewColumn.HeaderText, dataGridViewRow.Cells[dataGridViewColumn.Name].Value));
                                                }
                                                else
                                                {
                                                    str2 = (dataGridViewRow.Cells[dataGridViewColumn.Name].Value.ToString() == "1" || dataGridViewRow.Cells[dataGridViewColumn.Name].Value.ToString().ToLower() == "true" ? string.Concat(str2, string.Format("{0}：{1}；", dataGridViewColumn.HeaderText, this.getChkText(true))) : string.Concat(str2, string.Format("{0}：{1}；", dataGridViewColumn.HeaderText, this.getChkText(false))));
                                                }
                                            }
                                        }
                                        finally
                                        {
                                            IDisposable disposable1 = enumerator2 as IDisposable;
                                            if (disposable1 != null)
                                            {
                                                disposable1.Dispose();
                                            }
                                        }
                                        if (flag1 && !flag)
                                        {
                                            continue;
                                        }
                                        str = string.Concat(str, str2);
                                    }
                                    continue;
                                }
                                finally
                                {
                                    IDisposable disposable2 = enumerator1 as IDisposable;
                                    if (disposable2 != null)
                                    {
                                        disposable2.Dispose();
                                    }
                                }
                                break;
                            }
                        case "ListView":
                            {
                                string str3 = "";
                                foreach (ListViewItem item in ((ListView)control).Items)
                                {
                                    if (item.Tag == null)
                                    {
                                        continue;
                                    }
                                    str3 = string.Concat(str3, string.Format(",{0}", item.Tag.ToString()));
                                }
                                char[] chrArray = new char[] { ',' };
                                str = string.Concat(str, str3.Trim(chrArray));
                                continue;
                            }
                        case "CheckBoxList":
                            {
                                CheckBoxItem[] items = ((CheckBoxList)control).Items;
                                for (int i = 0; i < (int)items.Length; i++)
                                {
                                    CheckBox checkBox = items[i];
                                    str = string.Concat(str, string.Format("{0}：{1}；", checkBox.Text, this.getChkText(checkBox.Checked)));
                                }
                                continue;
                            }
                        case "IPAddressTextBox":
                            {
                                str = string.Concat(str, control.Text, control.Tag);
                                continue;
                            }
                    }
                }
                if (control.Name == "grpCar")
                {
                    continue;
                }
                str = string.Concat(str, this.getCmnParam(control));
            }
            return str.Replace(";", "；").Replace("|", "｜");
        }

        private string getSetParam(Control ctrl)
        {
            string str = "";
            foreach (Control control in ctrl.Controls)
            {
                if (!control.Visible || control.Tag != null && (control.Tag.ToString().Equals("9999") || control.Tag.ToString().Equals("99999")))
                {
                    continue;
                }
                string name = control.GetType().Name;
                string str1 = name;
                if (name != null)
                {
                    switch (str1)
                    {
                        case "IPAddressTextBox":
                        case "TextBox":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, control.Text.Replace(";", "；").Replace("|", "｜")));
                                continue;
                            }
                        case "ComboBox":
                        case "ComBox":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((ComboBox)control).SelectedIndex));
                                continue;
                            }
                        case "DateTimePicker":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((DateTimePicker)control).Value));
                                continue;
                            }
                        case "NumericUpDown":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((NumericUpDown)control).Text));
                                continue;
                            }
                        case "TrackBar":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((TrackBar)control).Value));
                                continue;
                            }
                        case "CheckBox":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((CheckBox)control).Checked));
                                continue;
                            }
                        case "RadioButton":
                            {
                                str = string.Concat(str, string.Format("{0}={1}|;", control.Name, ((RadioButton)control).Checked));
                                continue;
                            }
                        case "CheckBoxList":
                            {
                                string str2 = "";
                                CheckBoxItem[] items = ((CheckBoxList)control).Items;
                                for (int i = 0; i < (int)items.Length; i++)
                                {
                                    CheckBox checkBox = items[i];
                                    if (checkBox.Checked)
                                    {
                                        str2 = string.Concat(str2, checkBox.Name, ",");
                                    }
                                }
                                string name1 = control.Name;
                                char[] chrArray = new char[] { ',' };
                                str = string.Concat(str, string.Format("{0}={1}|;", name1, str2.Trim(chrArray)));
                                continue;
                            }
                    }
                }
                if (control.Name == "grpCar")
                {
                    continue;
                }
                str = string.Concat(str, this.getSetParam(control));
            }
            return str;
        }

        private void myWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string str = "";
                string str1 = "";
                str1 = (this.sCarId.IndexOf(',') <= 0 ? this.sCarId : this.sCarId.Substring(0, this.sCarId.IndexOf(',') - 1));
                str = string.Concat(str, " Select  Param ");
                str = string.Concat(str, " From    GpsCarSetParam ");
                str = string.Concat(str, " Where   CarId = ", str1);
                object obj = str;
                object[] orderCode = new object[] { obj, " And     MsgType = '", (int)this.OrderCode, "'" };
                str = string.Concat(orderCode);
                DataTable dataTable = RemotingClient.ExecSql(str);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    e.Result = dataTable.Rows[0]["Param"].ToString();
                }
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                e.Result = null;
                Record.execFileRecord("取得界面参数异步方法", exception.Message);
            }
        }

        private void myWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null && !string.IsNullOrEmpty(e.Result.ToString()))
                {
                    this.setParam(e.Result.ToString());
                }
            }
            catch
            {
            }
            this.setControlEnable(true);
            WaitForm.Hide();
        }

        protected override void OnLoad(EventArgs e)
        {
            try
            {
                this.sCarNum = MainForm.myCarList.SelectedCarNum;
                this.sCarId = MainForm.myCarList.SelectedCarId;
                this.sCarSimNum = MainForm.myCarList.SelectedSimNum;
            }
            catch
            {
            }
            base.OnLoad(e);
            this.getCarFormParam();
        }

        private bool saveCarFormParam()
        {
            string setParam = "";
            string cmnParam = "";
            setParam = this.getSetParam(this);
            cmnParam = this.getCmnParam(this);
            int orderCode = (int)this.OrderCode;
            Response response = RemotingClient.SetParam(orderCode.ToString(), setParam, cmnParam);
            if (response.ResultCode != (long)0)
            {
                MessageBox.Show(response.ErrorMsg);
                return false;
            }
            Record.execFileRecord(this.OrderCode.ToString(), setParam);
            Record.execFileRecord(this.OrderCode.ToString(), cmnParam);
            return true;
        }

        private void setCarValue()
        {
            if (this.cmbType.SelectedValue == null)
            {
                return;
            }
            switch ((CmdParam.ParamType)this.cmbType.SelectedValue)
            {
                case CmdParam.ParamType.CarNum:
                    {
                        this.txtCarNo.Text = this.sCarNum;
                        return;
                    }
                case CmdParam.ParamType.CarId:
                    {
                        this.txtCarNo.Text = this.sCarId;
                        return;
                    }
                case CmdParam.ParamType.SimNum:
                    {
                        this.txtCarNo.Text = this.sCarSimNum;
                        return;
                    }
            }
            this.txtCarNo.Text = "";
            if (this.cmbType.SelectedValue.Equals(3))
            {
                try
                {
                    string str = "";
                    DataView dataViews = new DataView(MainForm.myCarList.m_dtShippingList, string.Format("CarId IN ({0})", this.sCarId), "WaybillCode", DataViewRowState.CurrentRows);
                    for (int i = 0; i < dataViews.Count; i++)
                    {
                        str = string.Concat(str, dataViews[i]["WaybillCode"].ToString(), ",");
                    }
                    TextBox textBox = this.txtCarNo;
                    char[] chrArray = new char[] { ',' };
                    textBox.Text = str.Trim(chrArray);
                }
                catch
                {
                }
            }
        }

        private void setComTypeValue()
        {
            this.cmbType.addItems("车牌号码", 0);
            this.cmbType.addItems("车辆编号", 1);
            this.cmbType.addItems("车载电话", 2);
            if (Variable.sShippingEnable.Equals("1"))
            {
                this.cmbType.addItems("运单号码", 3);
            }
        }

        private void setControlEnable(bool bEnable)
        {
            foreach (Control control in base.Controls)
            {
                control.Enabled = bEnable;
            }
        }

        private void setParam(string sParamList)
        {
            char[] chrArray = new char[] { '|', ';' };
            string[] strArrays = sParamList.Split(chrArray);
            if ((int)strArrays.Length <= 0)
            {
                return;
            }
            string[] strArrays1 = strArrays;
            for (int i = 0; i < (int)strArrays1.Length; i++)
            {
                string str = strArrays1[i];
                try
                {
                    string[] strArrays2 = str.Split(new char[] { '=' });
                    if ((int)strArrays2.Length > 1)
                    {
                        Control[] controlArray = base.Controls.Find(strArrays2[0], true);
                        if (controlArray != null && (int)controlArray.Length > 0)
                        {
                            Control control = controlArray[0];
                            Type type = control.GetType();
                            if (control.Tag == null || !control.Tag.ToString().Equals("9999") && !control.Tag.ToString().Equals("99999"))
                            {
                                string name = type.Name;
                                string str1 = name;
                                if (name != null)
                                {
                                    switch (str1)
                                    {
                                        case "IPAddressTextBox":
                                        case "TextBox":
                                        {
                                            control.Text = strArrays2[1];
                                            break;
                                        }
                                        case "ComboBox":
                                        case "ComBox":
                                        {
                                            ((ComboBox)control).SelectedIndex = int.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "DateTimePicker":
                                        {
                                            ((DateTimePicker)control).Value = DateTime.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "NumericUpDown":
                                        {
                                            ((NumericUpDown)control).Value = decimal.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "TrackBar":
                                        {
                                            ((TrackBar)control).Value = int.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "CheckBox":
                                        {
                                            ((CheckBox)control).Checked = bool.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "RadioButton":
                                        {
                                            ((RadioButton)control).Checked = bool.Parse(strArrays2[1]);
                                            break;
                                        }
                                        case "CheckBoxList":
                                        {
                                            CheckBoxItem[] items = ((CheckBoxList)control).Items;
                                            for (int j = 0; j < (int)items.Length; j++)
                                            {
                                                CheckBox checkBox = items[j];
                                                string[] strArrays3 = strArrays2[1].Split(new char[] { ',' });
                                                for (int k = 0; k < (int)strArrays3.Length; k++)
                                                {
                                                    string str2 = strArrays3[k];
                                                    if (checkBox.Name == str2)
                                                    {
                                                        checkBox.Checked = true;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        strArrays2 = null;
                        controlArray = null;
                    }
                }
                catch (Exception exception)
                {
                }
            }
        }

        private void setParam()
        {
            try
            {
                string str = "";
                string str1 = "";
                str1 = (this.sCarId.IndexOf(',') <= 0 ? this.sCarId : this.sCarId.Substring(0, this.sCarId.IndexOf(',') - 1));
                str = string.Concat(str, " Select  Param ");
                str = string.Concat(str, " From    GpsCarSetParam ");
                str = string.Concat(str, " Where   CarId = ", str1);
                object obj = str;
                object[] orderCode = new object[] { obj, " And     MsgType = '", (int)this.OrderCode, "'" };
                str = string.Concat(orderCode);
                DataTable dataTable = RemotingClient.ExecSql(str);
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    string str2 = dataTable.Rows[0]["Param"].ToString();
                    if (!string.IsNullOrEmpty(str2))
                    {
                        this.setParam(str2);
                    }
                }
            }
            catch
            {
            }
        }
    }
}
