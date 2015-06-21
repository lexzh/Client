namespace Client
{
    using Remoting;
    using ParamLibrary.CmdParamInfo;
    using ParamLibrary.Entity;
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;

    public class testcmd : CarFormBaseControl
    {
        private TrafficSimpleCmd cmd = new TrafficSimpleCmd();

        public override void Init(CarFormEx carform)
        {
            base.Init(carform);
            GroupBox box = new GroupBox {
                Text = "参数设置",
                Dock = DockStyle.Fill
            };
            carform.pnlContainer.Controls.Add(box);
            TableLayoutPanel tb = new TableLayoutPanel {
                Dock = DockStyle.Fill,
                RowCount = 1,
                ColumnCount = 2
            };
            tb.RowStyles.Clear();
            tb.ColumnStyles.Clear();
            tb.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 0; i < 1; i++)
            {
                RowStyle rowStyle = new RowStyle {
                    Height = 25f,
                    SizeType = SizeType.Absolute
                };
                ColumnStyle columnStyle = new ColumnStyle {
                    Width = 113f,
                    SizeType = SizeType.Absolute
                };
                tb.RowStyles.Add(rowStyle);
                tb.ColumnStyles.Add(columnStyle);
            }
            Label con = new Label {
                Text = "通道类型：",
                TextAlign = ContentAlignment.MiddleRight,
                Dock = DockStyle.Fill
            };
            this.SetControl(tb, con, 0, 0);
            StarNetTextBox box2 = new StarNetTextBox {
                Name = "txtip",
                MaxLength = 100,
                Width = 160,
                Dock = DockStyle.Left,
                DestinationMarshalByRefObject = this.cmd,
                PropertyName = "RepeatTimes",
                PropertyType = System.Type.GetType("System.Int32")
            };
            this.SetControl(tb, box2, 0, 1);
            box.Controls.Add(tb);
        }

        public override bool Send(CarFormEx carform)
        {
            StarNetTextBox box = carform.Controls.Find("txtbox", true)[0] as StarNetTextBox;
            bool check = box.Check;
            carform.Repose = typeof(RemotingClient).InvokeMember("car_IDownLoadData", BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static, null, null, new object[0]) as Response;
            if (carform.Repose.ResultCode != 0L)
            {
                return false;
            }
            return true;
        }

        private void SetControl(TableLayoutPanel tb, Control con, int row, int col)
        {
            tb.Controls.Add(con);
            tb.SetRow(con, row);
            tb.SetColumn(con, col);
        }
    }
}

