namespace Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using WinFormsUI.Controls;

    public partial class SetPathSegment : UserControl
    {
        private Dictionary<string, int> seghi = new Dictionary<string, int>();

        public event PathSegmentChange PathSegmentChanged;

        public SetPathSegment()
        {
            this.InitializeComponent();
            this.Add路线属性();
        }

        private void _路线属性_VisibilityChange(bool isvisible)
        {
            ListBoxEx innerControl = this._路线属性.InnerControl as ListBoxEx;
            if (!isvisible)
            {
                ListBox.SelectedObjectCollection selectedItems = innerControl.SelectedItems;
                string str = "";
                int count = innerControl.Items.Count;
                int num2 = 0;
                for (int i = 0; i < count; i++)
                {
                    if (selectedItems.Contains(innerControl.Items[i]))
                    {
                        ListBoxItem item = innerControl.Items[i] as ListBoxItem;
                        num2 |= Convert.ToInt32(item.Tag.ToString());
                        str = str + item.Name.ToString() + ",";
                    }
                }
                string str2 = Convert.ToString(num2, 2).PadLeft(4, '0');
                this.dgvPathSegment.CurrentRow.Cells["SegmentFlagValue"].Value = num2;
                this.setTimeSpeedReadOnly(this.dgvPathSegment.CurrentRow, num2);
                this.seghi[this.dgvPathSegment.CurrentRow.Cells["PathID"].Value.ToString() + "," + this.dgvPathSegment.CurrentRow.Cells["PathSegmentID"].Value.ToString()] = Convert.ToInt32(str2, 2);
                if (this.dgvPathSegment.CurrentCell != null)
                {
                    try
                    {
                        this.dgvPathSegment.CurrentCell.Value = str.Trim(new char[] { ',' });
                        this.dgvPathSegment.CurrentCell.Tag = str2;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                innerControl.ClearSelected();
                if (this.dgvPathSegment.CurrentCell.Value.ToString().Length > 0)
                {
                    List<string> list = new List<string>();
                    string[] collection = this.dgvPathSegment.CurrentCell.Value.ToString().Split(new char[] { ',' });
                    list.AddRange(collection);
                    int num4 = innerControl.Items.Count;
                    for (int j = 0; j < num4; j++)
                    {
                        ListBoxItem item2 = innerControl.Items[j] as ListBoxItem;
                        if (list.Contains(item2.Name))
                        {
                            innerControl.SetSelected(j, true);
                        }
                    }
                }
            }
        }

        private void Add路线属性()
        {
            ListBoxEx con = new ListBoxEx {
                Width = 80,
                Height = 100,
                ItemHeight = 16
            };
            ListBoxItem item = new ListBoxItem("行驶时间", "0") {
                Tag = 1
            };
            ListBoxItem item2 = new ListBoxItem("限速", "1") {
                Tag = 2
            };
            ListBoxItem item3 = new ListBoxItem("南纬", "2") {
                Tag = 4
            };
            ListBoxItem item4 = new ListBoxItem("西经", "3") {
                Tag = 8
            };
            con.DrawMode = DrawMode.OwnerDrawFixed;
            con.FormattingEnabled = true;
            con.IsCheckBox = true;
            con.SelectionMode = SelectionMode.MultiSimple;
            con.Items.AddRange(new object[] { item, item2, item3, item4 });
            this._路线属性 = new AutoDropDown(con);
            base.Controls.Add(this._路线属性);
            this._路线属性.VisibilityChange += new VisibleChanged(this._路线属性_VisibilityChange);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in (IEnumerable) this.dgvPathSegment.Rows)
                {
                    row.Cells["HoldTime"].Value = DBNull.Value;
                    row.Cells["DriEnough"].Value = DBNull.Value;
                    row.Cells["TopSpeed"].Value = DBNull.Value;
                    row.Cells["DriNoEnough"].Value = DBNull.Value;
                    row.Cells["路宽"].Value = DBNull.Value;
                    row.Cells["路段属性"].Value = DBNull.Value;
                }
                PathSegmentChangeArgs arg = new PathSegmentChangeArgs {
                    IsClose = false,
                    IsSet = false
                };
                this.PathSegmentChanging(arg);
            }
            catch
            {
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            PathSegmentChangeArgs arg = new PathSegmentChangeArgs {
                IsClose = true
            };
            this.PathSegmentChanging(arg);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (this._data.Rows.Count == 0)
                {
                    MessageBox.Show("该路线没有路段信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    foreach (DataRow row in this._data.Rows)
                    {
                        int result = -111;
                        int num2 = -111;
                        int num3 = -999;
                        int num4 = -999;
                        int num5 = -999;
                        if ((row["Flag"].ToString().IndexOf("行驶时间") >= 0) && ((row["DriEnough"].ToString().Trim().Length == 0) || !int.TryParse(row["DriEnough"].ToString(), out result)))
                        {
                            MessageBox.Show("请检查路段\"" + row["PathSegmentName"].ToString() + "\"的行驶最长时间数据是否正确且不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("行驶时间") >= 0) && ((row["DriNoEnough"].ToString().Trim().Length == 0) || !int.TryParse(row["DriNoEnough"].ToString(), out num2)))
                        {
                            MessageBox.Show("请检查路段\"" + row["PathSegmentName"].ToString() + "\"的行驶最短时间数据是否正确且不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("限速") >= 0) && ((row["TopSpeed"].ToString().Trim().Length == 0) || !int.TryParse(row["TopSpeed"].ToString(), out num4)))
                        {
                            MessageBox.Show("请检查路段\"" + row["PathSegmentName"].ToString() + "\"的最高时速数据是否正确且不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("限速") >= 0) && ((row["HoldTime"].ToString().Trim().Length == 0) || !int.TryParse(row["HoldTime"].ToString(), out num3)))
                        {
                            MessageBox.Show("请检查路段\"" + row["PathSegmentName"].ToString() + "\"的持续时长数据是否正确且不能为空!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        int.TryParse(row["DriEnough"].ToString(), out result);
                        int.TryParse(row["DriNoEnough"].ToString(), out num2);
                        int.TryParse(row["HoldTime"].ToString(), out num3);
                        int.TryParse(row["TopSpeed"].ToString(), out num4);
                        if (!int.TryParse(row["PathWidth"].ToString(), out num5))
                        {
                            MessageBox.Show("请检查路段\"" + row["PathSegmentName"].ToString() + "\"参数输入是否正确!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("限速") >= 0) && ((num4 < 0) || (num4 > 255)))
                        {
                            MessageBox.Show("最高速度不能小于0且不能大于255!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("限速") >= 0) && ((num3 < 0) || (num3 > 255)))
                        {
                            MessageBox.Show("持续时长不能小于0且不能大于255!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((num5 <= 0) || (num5 > 255))
                        {
                            MessageBox.Show("路宽不能小于0且不能大于255!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("行驶时间") >= 0) && ((result < 0) || (num2 < 0)))
                        {
                            MessageBox.Show("行驶最长时间和行驶最短时间不能小于0!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                        if ((row["Flag"].ToString().IndexOf("行驶时间") >= 0) && (result < num2))
                        {
                            MessageBox.Show("行驶最长时间不能小于行驶最短时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            return;
                        }
                    }
                    PathSegmentChangeArgs arg = new PathSegmentChangeArgs {
                        IsClose = false,
                        IsSet = true
                    };
                    this.PathSegmentChanging(arg);
                    arg.IsClose = true;
                    this.PathSegmentChanging(arg);
                }
            }
            catch
            {
            }
        }

        private void dgvPathSegment_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView) sender).CurrentCell.OwningColumn.Name.Equals("路段属性"))
            {
                Point location = this.dgvPathSegment.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                this._路线属性.ShowDropDown(new Point(location.X + 3, location.Y + this._路线属性.Height));
            }
        }

        private void dgvPathSegment_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }

        private void dgvSubSpeedParam_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = this.dgvPathSegment.CurrentCell.ColumnIndex;
            if ((this.dgvPathSegment.Columns[columnIndex].DataPropertyName.Equals("TopSpeed", StringComparison.OrdinalIgnoreCase) || this.dgvPathSegment.Columns[columnIndex].DataPropertyName.Equals("HoldTime", StringComparison.OrdinalIgnoreCase)) || ((this.dgvPathSegment.Columns[columnIndex].DataPropertyName.Equals("DriEnough", StringComparison.OrdinalIgnoreCase) || this.dgvPathSegment.Columns[columnIndex].DataPropertyName.Equals("DriNoEnough", StringComparison.OrdinalIgnoreCase)) || this.dgvPathSegment.Columns[columnIndex].DataPropertyName.Equals("PathWidth", StringComparison.OrdinalIgnoreCase)))
            {
                this.EditingControl = (DataGridViewTextBoxEditingControl) e.Control;
                this.EditingControl.KeyPress += new KeyPressEventHandler(this.EditingControl_KeyPress);
            }
        }

 private void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != '\b'))
            {
                e.Handled = true;
            }
        }

        private int GeneralValue(char[] list)
        {
            string str = "";
            for (int i = 0; i < list.Length; i++)
            {
                str = str + list[i].ToString();
            }
            return this.ToShijin(Convert.ToInt32(str));
        }

        public void Init(DataTable data)
        {
            this._data = data;
            this.dgvPathSegment.DataSource = data;
            this.InitTimeSpeedReadOnly();
        }

 private void InitTimeSpeedReadOnly()
        {
            try
            {
                for (int i = 0; i < this.dgvPathSegment.Rows.Count; i++)
                {
                    this.setTimeSpeedReadOnly(this.dgvPathSegment.Rows[i], Convert.ToInt32(this.dgvPathSegment.Rows[i].Cells["SegmentFlagValue"].Value));
                }
            }
            catch (Exception)
            {
            }
        }

        private void PathSegmentChanging(PathSegmentChangeArgs arg)
        {
            if (this.PathSegmentChanged != null)
            {
                this.PathSegmentChanged(arg);
            }
        }

        private void setTimeSpeedReadOnly(DataGridViewRow dgvr, int val)
        {
            if ((val & 1) == 0)
            {
                dgvr.Cells["DriEnough"].ReadOnly = true;
                dgvr.Cells["DriNoEnough"].ReadOnly = true;
                dgvr.Cells["DriEnough"].Value = DBNull.Value;
                dgvr.Cells["DriNoEnough"].Value = DBNull.Value;
            }
            else
            {
                dgvr.Cells["DriEnough"].ReadOnly = false;
                dgvr.Cells["DriNoEnough"].ReadOnly = false;
            }
            if ((val & 2) == 0)
            {
                dgvr.Cells["TopSpeed"].ReadOnly = true;
                dgvr.Cells["HoldTime"].ReadOnly = true;
                dgvr.Cells["TopSpeed"].Value = DBNull.Value;
                dgvr.Cells["HoldTime"].Value = DBNull.Value;
            }
            else
            {
                dgvr.Cells["TopSpeed"].ReadOnly = false;
                dgvr.Cells["HoldTime"].ReadOnly = false;
            }
        }

        public int ToErJin(int value)
        {
            int num = 0;
            int num2 = 1;
            while (num2 != 0)
            {
                num2 = value / 2;
                int num3 = value % 2;
                value = num2;
                num += num3;
                if (num2 != 0)
                {
                    num *= 10;
                }
            }
            string str = num.ToString();
            int length = str.Length;
            string s = string.Empty;
            for (int i = 0; i < length; i++)
            {
                s = str[i] + s;
            }
            return int.Parse(s);
        }

        public int ToShijin(int value)
        {
            string str = value.ToString();
            int length = str.Length;
            int num2 = 0;
            for (int i = 0; i < length; i++)
            {
                char ch = str[i];
                num2 += int.Parse(ch.ToString()) * ((int) Math.Pow(2.0, (double) ((length - 1) - i)));
            }
            return num2;
        }

        public int ToShijin2(int value)
        {
            int num = 0;
            int num2 = value;
            for (int i = 0; num2 != 0; i++)
            {
                int num3 = num2 % 10;
                num2 /= 10;
                num += num3 * ((int) Math.Pow(2.0, (double) i));
            }
            return num;
        }

        public DataTable SegmentData
        {
            get
            {
                return this._data;
            }
        }
    }
}

