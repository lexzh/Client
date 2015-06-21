namespace Client
{
    using Properties;
    using PublicClass;
    using Remoting;
    using System;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;
    using WinFormsUI.Docking;

    partial class SearchCarList
    {
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

       
        private void InitializeComponent()
        {
            this.grbSearchCarList = new GroupBox();
            this.dgvSearchCarList = new DataGridView();
            this.Column1 = new DataGridViewImageColumn();
            this.CarNum = new DataGridViewTextBoxColumn();
            this.SimNum = new DataGridViewTextBoxColumn();
            this.Longitude = new DataGridViewTextBoxColumn();
            this.Latitude = new DataGridViewTextBoxColumn();
            this.Speed = new DataGridViewTextBoxColumn();
            this.GpsTime = new DataGridViewTextBoxColumn();
            this.grbSearchCarList.SuspendLayout();
            ((ISupportInitialize) this.dgvSearchCarList).BeginInit();
            base.SuspendLayout();
            this.grbSearchCarList.Controls.Add(this.dgvSearchCarList);
            this.grbSearchCarList.Dock = DockStyle.Fill;
            this.grbSearchCarList.Location = new Point(0, 0);
            this.grbSearchCarList.Name = "grbSearchCarList";
            this.grbSearchCarList.Size = new Size(723, 663);
            this.grbSearchCarList.TabIndex = 1;
            this.grbSearchCarList.TabStop = false;
            this.grbSearchCarList.Text = "查车结果(0)";
            this.dgvSearchCarList.AllowUserToAddRows = false;
            this.dgvSearchCarList.AllowUserToDeleteRows = false;
            this.dgvSearchCarList.AllowUserToResizeRows = false;
            this.dgvSearchCarList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSearchCarList.BackgroundColor = Color.White;
            this.dgvSearchCarList.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dgvSearchCarList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSearchCarList.Columns.AddRange(new DataGridViewColumn[] { this.Column1, this.CarNum, this.SimNum, this.Longitude, this.Latitude, this.Speed, this.GpsTime });
            this.dgvSearchCarList.Dock = DockStyle.Fill;
            this.dgvSearchCarList.Location = new Point(3, 17);
            this.dgvSearchCarList.Name = "dgvSearchCarList";
            this.dgvSearchCarList.ReadOnly = true;
            this.dgvSearchCarList.RowHeadersVisible = false;
            this.dgvSearchCarList.RowTemplate.Height = 23;
            this.dgvSearchCarList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSearchCarList.Size = new Size(717, 643);
            this.dgvSearchCarList.TabIndex = 1;
            this.dgvSearchCarList.CellMouseDoubleClick += new DataGridViewCellMouseEventHandler(this.dgvSearchCarList_CellMouseDoubleClick);
            this.dgvSearchCarList.CellToolTipTextNeeded += new DataGridViewCellToolTipTextNeededEventHandler(this.dataGridView1_CellToolTipTextNeeded);
            this.Column1.FillWeight = 20f;
            this.Column1.HeaderText = "";
            this.Column1.Image = Resources.CarImage蓝;
            this.Column1.MinimumWidth = 20;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = DataGridViewTriState.False;
            this.CarNum.DataPropertyName = "CarNum";
            this.CarNum.HeaderText = "车牌";
            this.CarNum.Name = "CarNum";
            this.CarNum.ReadOnly = true;
            this.SimNum.DataPropertyName = "SimNum";
            this.SimNum.HeaderText = "车载电话";
            this.SimNum.Name = "SimNum";
            this.SimNum.ReadOnly = true;
            this.Longitude.DataPropertyName = "Longitude";
            this.Longitude.FillWeight = 130f;
            this.Longitude.HeaderText = "经度";
            this.Longitude.Name = "Longitude";
            this.Longitude.ReadOnly = true;
            this.Latitude.DataPropertyName = "Latitude";
            this.Latitude.FillWeight = 130f;
            this.Latitude.HeaderText = "纬度";
            this.Latitude.Name = "Latitude";
            this.Latitude.ReadOnly = true;
            this.Speed.DataPropertyName = "Speed";
            this.Speed.FillWeight = 60f;
            this.Speed.HeaderText = "速度";
            this.Speed.Name = "Speed";
            this.Speed.ReadOnly = true;
            this.GpsTime.DataPropertyName = "GpsTime";
            this.GpsTime.FillWeight = 150f;
            this.GpsTime.HeaderText = "定位时间";
            this.GpsTime.Name = "GpsTime";
            this.GpsTime.ReadOnly = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(723, 663);
            base.Controls.Add(this.grbSearchCarList);
            base.Name = "SearchCarList";
            base.TabText = "拉框查车列表";
            this.Text = "SearchCarList";
            base.DockStateChanged += new EventHandler(this.SearchCarList_DockStateChanged);
            this.grbSearchCarList.ResumeLayout(false);
            ((ISupportInitialize) this.dgvSearchCarList).EndInit();
            base.ResumeLayout(false);
        }

       
        private IContainer components;
        private DataGridViewTextBoxColumn CarNum;
        private DataGridViewImageColumn Column1;
        private DataGridView dgvSearchCarList;
        private DataTable dtSearchCar;
        private DataGridViewTextBoxColumn GpsTime;
        private GroupBox grbSearchCarList;
        private int iCarCnt;
        private DataGridViewTextBoxColumn Latitude;
        private DataGridViewTextBoxColumn Longitude;
        private CompleteGetRefRegion myCompleteGetRefRegion;
        private CompleteGetRefRegionDataTable myCompleteGetRefRegionDataTable;
        private DelegateMsgBox myMsgBox;
        private DataGridViewTextBoxColumn SimNum;
        private DataGridViewTextBoxColumn Speed;
        private Thread thread;
    }
}