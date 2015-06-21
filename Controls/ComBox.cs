namespace WinFormsUI.Controls
{
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Windows.Forms;

    public partial class ComBox : ComboBox
    {
        private DataTable dtData = new DataTable();

        public ComBox()
        {
            this.InitializeComponent();
            DataColumn column = new DataColumn {
                ColumnName = "Display",
                DataType = System.Type.GetType("System.Object")
            };
            this.dtData.Columns.Add(column);
            column = new DataColumn {
                ColumnName = "Value",
                DataType = System.Type.GetType("System.Object")
            };
            this.dtData.Columns.Add(column);
            base.DataSource = this.dtData;
            base.DisplayMember = "Display";
            base.ValueMember = "Value";
        }

        public void addItems(object oDisplay, object oValue)
        {
            DataRow row = this.dtData.NewRow();
            row["Display"] = oDisplay;
            row["Value"] = oValue;
            this.dtData.Rows.Add(row);
        }

        public void clearItems()
        {
            this.dtData.Clear();
        }


    }
}