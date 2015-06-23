namespace PublicClass
{
    using Microsoft.Office.Interop.Excel;
    using System;
    using System.Data;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    

    public class ExportToExcel
    {
        [CompilerGenerated]

        private static System.Data.DataTable _ExportDataTable_k__BackingField;
        private static DataGridView gridView;
        private static SaveFileDialog saveFileDialog = new SaveFileDialog();
        private static SaveFileDialog saveFileDialog2 = new SaveFileDialog();
        private static ToolStripProgressBar toolStripProgressBar1 = new ToolStripProgressBar();

        public static void ExportDataToExcel()
        {
            if (ExportDataTable.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                saveFileDialog.Filter = "Execl files (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CreatePrompt = true;
                saveFileDialog.FileName = "车辆信息-" + DateTime.Now.ToString("yyyy-MM-dd");
                saveFileDialog.Title = "导出文件保存路径";
                string fileName = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = saveFileDialog.FileName;
                    if (!string.IsNullOrEmpty(fileName))
                    {
                        int num = 1;
                        int num2 = 3;
                        Missing fileFormat = Missing.Value;
                        ApplicationClass o = new ApplicationClass();
                        o.Visible = false;
                        if (o == null)
                        {
                            MessageBox.Show("EXCEL无法启动！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            Workbook workbook = o.Workbooks.Add(1);
                            Worksheet worksheet = (Worksheet) workbook.Worksheets[1];
                            if (gridView.Tag != null)
                            {
                                worksheet.Name = gridView.Tag.ToString();
                            }
                            else
                            {
                                worksheet.Name = "车辆信息" + DateTime.Now.ToString("yyyy-MM-dd-01");
                            }
                            for (int i = 0; i < ExportDataTable.Columns.Count; i++)
                            {
                                worksheet.Cells[num2 + 1, (num + i) + 1] = ExportDataTable.Columns[i].Caption.ToString();
                            }
                            for (int j = 0; j < ExportDataTable.Rows.Count; j++)
                            {
                                for (int k = 0; k < ExportDataTable.Columns.Count; k++)
                                {
                                    worksheet.Cells[(num2 + j) + 2, (num + k) + 1] = "'" + ExportDataTable.Rows[j][k].ToString();
                                }
                            }
                            worksheet.Columns.EntireColumn.AutoFit();
                            worksheet.SaveAs(fileName, fileFormat, fileFormat, fileFormat, fileFormat, fileFormat, XlSaveAsAccessMode.xlNoChange, fileFormat, fileFormat, fileFormat);
                            workbook.Close(false, fileFormat, fileFormat);
                            o.Quit();
                            Marshal.ReleaseComObject(worksheet);
                            Marshal.ReleaseComObject(workbook);
                            Marshal.ReleaseComObject(o);
                            GC.Collect();
                            MessageBox.Show("数据已经成功导出到：" + saveFileDialog.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
            }
        }

        public static DataGridView ExportDataGridView
        {
            get
            {
                return gridView;
            }
            set
            {
                gridView = value;
            }
        }

        public static System.Data.DataTable ExportDataTable
        {
            [CompilerGenerated]
            get
            {
                return _ExportDataTable_k__BackingField;
            }
            [CompilerGenerated]
            set
            {
                _ExportDataTable_k__BackingField = value;
            }
        }
    }
}

