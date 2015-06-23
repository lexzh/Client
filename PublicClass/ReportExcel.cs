namespace PublicClass
{
    using Microsoft.Office.Interop.Excel;
    using NPOI.HPSF;
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.SS.Util;
    using System;
    using System.Collections;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    public class ReportExcel
    {
        public static void OutputExcel(DataGridView dgvCarPlay, string Title, string savePath, string sSTName)
        {
            OutputExcel(dgvCarPlay, Title, savePath, sSTName, false);
        }

        public static void OutputExcel(DataGridView dgv, string Title, string savePath, string sSTName, bool IsConver)
        {
            try
            {
                HSSFWorkbook workbook = new HSSFWorkbook();
                {
                    int num = 5;
                    int num2 = 0x106;
                    DocumentSummaryInformation information = PropertySetFactory.CreateDocumentSummaryInformation();
                    information.Company = "";
                    workbook.DocumentSummaryInformation = information;
                    SummaryInformation information2 = PropertySetFactory.CreateSummaryInformation();
                    information2.Subject = "";
                    workbook.SummaryInformation = information2;
                    if (sSTName.Length > 0x1f)
                    {
                        sSTName = "报表";
                    }
                    ISheet sheet = workbook.CreateSheet(sSTName);
                    int rownum = 3;
                    int num4 = 0;
                    int num5 = 0;
                    int num6 = 1;
                    ICellStyle style = workbook.CreateCellStyle();
                    style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    style.VerticalAlignment = VerticalAlignment.CENTER;
                    style.ShrinkToFit = true;
                    NPOI.SS.UserModel.IFont font = workbook.CreateFont();
                    font.FontName = "宋体";
                    font.FontHeightInPoints = 11;
                    style.SetFont(font);
                    IRow row = sheet.CreateRow(rownum);
                    num5 = num4;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        if (column.Visible && (column.CellType != typeof(DataGridViewCheckBoxCell)))
                        {
                            num5++;
                            ICell cell = row.CreateCell(num5);
                            cell.SetCellValue(column.HeaderText);
                            cell.CellStyle = style;
                            style.WrapText = true;
                            sheet.AutoSizeColumn(num5);
                        }
                    }
                    if (IsConver)
                    {
                        for (int i = dgv.Rows.Count - 1; i >= 0; i--)
                        {
                            DataGridViewRow row2 = dgv.Rows[i];
                            if (!row2.IsNewRow)
                            {
                                rownum++;
                                num5 = num4;
                                IRow row3 = sheet.CreateRow(rownum);
                                foreach (DataGridViewColumn column2 in dgv.Columns)
                                {
                                    if (column2.Visible && (column2.CellType != typeof(DataGridViewCheckBoxCell)))
                                    {
                                        num5++;
                                        if ((row2.Cells[column2.Index].Value != null) && !row2.IsNewRow)
                                        {
                                            row3.CreateCell(num5).SetCellValue(row2.Cells[column2.Index].Value.ToString());
                                            int num8 = sheet.GetColumnWidth(row3.GetCell(num5).ColumnIndex);
                                            int num9 = (Encoding.GetEncoding("gb2312").GetBytes(row2.Cells[column2.Index].Value.ToString()).Length + num) * num2;
                                            num8 = (num9 < num8) ? num8 : num9;
                                            sheet.SetColumnWidth(num5, num8);
                                            if (column2.CellType == typeof(DataGridViewTextBoxCell))
                                            {
                                                sheet.GetRow(rownum).GetCell(num5).CellStyle = style;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow row4 in (IEnumerable) dgv.Rows)
                        {
                            if (!row4.IsNewRow)
                            {
                                rownum++;
                                num5 = num4;
                                IRow row5 = sheet.CreateRow(rownum);
                                foreach (DataGridViewColumn column3 in dgv.Columns)
                                {
                                    if (column3.Visible && (column3.CellType != typeof(DataGridViewCheckBoxCell)))
                                    {
                                        num5++;
                                        if ((row4.Cells[column3.Index].Value != null) && !row4.IsNewRow)
                                        {
                                            row5.CreateCell(num5).SetCellValue(row4.Cells[column3.Index].Value.ToString());
                                            int num10 = sheet.GetColumnWidth(row5.GetCell(num5).ColumnIndex);
                                            int num11 = (Encoding.GetEncoding("gb2312").GetBytes(row4.Cells[column3.Index].Value.ToString()).Length + num) * num2;
                                            num10 = (num11 < num10) ? num10 : num11;
                                            sheet.SetColumnWidth(num5, num10);
                                            if (column3.CellType == typeof(DataGridViewTextBoxCell))
                                            {
                                                sheet.GetRow(rownum).GetCell(num5).CellStyle = style;
                                            }
                                        }
                                    }
                                }
                                continue;
                            }
                        }
                    }
                    int num12 = rownum + 1;
                    num5 = num4;
                    foreach (DataGridViewColumn column4 in dgv.Columns)
                    {
                        if (column4.Visible)
                        {
                            num5++;
                        }
                    }
                    num12 = rownum + 2;
                    IRow row6 = sheet.CreateRow(num12);
                    ICell cell2 = row6.CreateCell(1);
                    cell2.SetCellValue("合计:");
                    ICellStyle style2 = workbook.CreateCellStyle();
                    style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    style2.VerticalAlignment = VerticalAlignment.CENTER;
                    cell2.CellStyle = style2;
                    int columnWidth = sheet.GetColumnWidth(1);
                    int num14 = (Encoding.GetEncoding("gb2312").GetBytes("合计:").Length + num) * num2;
                    columnWidth = (num14 < columnWidth) ? columnWidth : num14;
                    sheet.SetColumnWidth(1, columnWidth);
                    cell2 = row6.CreateCell(2);
                    cell2.SetCellValue(dgv.Rows.Count.ToString() + "条记录");
                    style2 = workbook.CreateCellStyle();
                    style2.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
                    style2.VerticalAlignment = VerticalAlignment.CENTER;
                    cell2.CellStyle = style2;
                    int width = sheet.GetColumnWidth(2);
                    int num16 = (Encoding.GetEncoding("gb2312").GetBytes(dgv.Rows.Count.ToString() + "条记录").Length + num) * num2;
                    width = (num16 < columnWidth) ? width : num16;
                    sheet.SetColumnWidth(2, width);
                    num6 = 1;
                    ICell cell3 = sheet.CreateRow(1).CreateCell(num6);
                    cell3.SetCellValue(Title);
                    ICellStyle style3 = workbook.CreateCellStyle();
                    style3.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                    style3.VerticalAlignment = VerticalAlignment.CENTER;
                    NPOI.SS.UserModel.IFont font2 = workbook.CreateFont();
                    font2.FontName = "宋体";
                    font2.FontHeightInPoints = 11;
                    style3.SetFont(font2);
                    cell3.CellStyle = style3;
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, num6, num5));
                    sheet.GetRow(1).HeightInPoints = 35f;
                    if (string.IsNullOrEmpty(savePath))
                    {
                        savePath = @"C:\Documents and Settings\Administrator\My Documents\Report.xls";
                    }
                    FileStream stream = new FileStream(savePath, FileMode.Create);
                    workbook.Write(stream);
                    stream.Close();
                    MessageBox.Show("数据已经成功导出到：" + savePath, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                Record.execFileRecord("导出报表", exception.ToString());
            }
        }

        public static void OutputExcel_Microsoft(DataGridView dgvCarPlay, string Title, string savePath, string sSTName, bool IsConver)
        {
            Microsoft.Office.Interop.Excel.Application o = null;
            _Workbook workbook;
            _Worksheet activeSheet;
            try
            {
                o = new ApplicationClass();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Excel无法启动，请确保已安装Excel 2003 及以上版本！");
                Record.execFileRecord("导出报表", exception.ToString());
                return;
            }
            try
            {
                int num = 4;
                int num2 = 1;
                int num3 = 0;
                int num4 = 2;
                workbook = o.Workbooks.Add(true);
                activeSheet = (_Worksheet) workbook.ActiveSheet;
                if (sSTName.Length > 0x1f)
                {
                    sSTName = "报表";
                }
                activeSheet.Name = sSTName;
                num3 = num2;
                foreach (DataGridViewColumn column in dgvCarPlay.Columns)
                {
                    if (column.Visible && (column.CellType != typeof(DataGridViewCheckBoxCell)))
                    {
                        num3++;
                        activeSheet.Cells[num, num3] = column.HeaderText;
                        activeSheet.get_Range(activeSheet.Cells[num, num3], activeSheet.Cells[num, num3]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
                        if (column.CellType == typeof(DataGridViewTextBoxCell))
                        {
                            activeSheet.get_Range(activeSheet.Cells[num, num3], activeSheet.Cells[num + dgvCarPlay.Rows.Count, num3]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
                        }
                    }
                }
                if (IsConver)
                {
                    for (int i = dgvCarPlay.Rows.Count - 1; i >= 0; i--)
                    {
                        DataGridViewRow row = dgvCarPlay.Rows[i];
                        num++;
                        num3 = num2;
                        foreach (DataGridViewColumn column2 in dgvCarPlay.Columns)
                        {
                            if (column2.Visible && (column2.CellType != typeof(DataGridViewCheckBoxCell)))
                            {
                                num3++;
                                activeSheet.Cells[num, num3] = "'" + row.Cells[column2.Index].Value;
                            }
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow row2 in (IEnumerable) dgvCarPlay.Rows)
                    {
                        num++;
                        num3 = num2;
                        foreach (DataGridViewColumn column3 in dgvCarPlay.Columns)
                        {
                            if (column3.Visible && (column3.CellType != typeof(DataGridViewCheckBoxCell)))
                            {
                                num3++;
                                activeSheet.Cells[num, num3] = "'" + row2.Cells[column3.Index].Value;
                            }
                        }
                    }
                }
                int num6 = num + 1;
                num3 = num2;
                foreach (DataGridViewColumn column4 in dgvCarPlay.Columns)
                {
                    if (column4.Visible)
                    {
                        num3++;
                    }
                }
                num6 = num + 2;
                activeSheet.Cells[num6, 2] = "合计:";
                activeSheet.get_Range(activeSheet.Cells[num6, 2], activeSheet.Cells[num6, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                activeSheet.Cells[num6, 3] = dgvCarPlay.Rows.Count.ToString() + "条记录";
                activeSheet.get_Range(activeSheet.Cells[num6, 3], activeSheet.Cells[num6, 3]).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                activeSheet.Cells[2, num4] = Title;
                num4 = 1;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.Bold = true;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.Size = 0x16;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.ColorIndex = 14;
                activeSheet.get_Range(activeSheet.Cells[4, num4], activeSheet.Cells[num6, num3]).Select();
                activeSheet.get_Range(activeSheet.Cells[4, num4], activeSheet.Cells[num6, num3]).Columns.AutoFit();
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num3]).Select();
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num3]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                if (string.IsNullOrEmpty(savePath))
                {
                    savePath = @"C:\Documents and Settings\Administrator\My Documents\Report.xls";
                }
                workbook.SaveCopyAs(savePath);
                workbook.Close(false, null, null);
                o.Quit();
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(activeSheet);
                workbook = null;
                o = null;
                activeSheet = null;
                MessageBox.Show("数据已经成功导出到：" + savePath, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message);
                Record.execFileRecord("导出报表", exception2.ToString());
            }
            finally
            {
                if (o != null)
                {
                    workbook = null;
                    o = null;
                    activeSheet = null;
                }
                GC.Collect();
            }
        }

        public static void OutputExcelChk(DataGridView dgvCarPlay, string Title, string savePath)
        {
            OutputExcel(dgvCarPlay, Title, savePath, Title, false);
        }

        public static void OutputExcelChk_Microsoft(DataGridView dgvCarPlay, string Title, string savePath)
        {
            Microsoft.Office.Interop.Excel.Application o = null;
            try
            {
                o = new ApplicationClass();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Excel无法启动，请确保已安装Excel 2003 及以上版本！");
                Record.execFileRecord("导出报表", exception.ToString());
                return;
            }
            try
            {
                int num = 4;
                int num2 = 1;
                int num3 = 0;
                int num4 = 2;
                _Workbook workbook = o.Workbooks.Add(true);
                _Worksheet activeSheet = (_Worksheet) workbook.ActiveSheet;
                activeSheet.Name = Title;
                num3 = num2;
                foreach (DataGridViewColumn column in dgvCarPlay.Columns)
                {
                    if (column.Visible && (column.CellType != typeof(DataGridViewCheckBoxCell)))
                    {
                        num3++;
                        activeSheet.Cells[num, num3] = column.HeaderText;
                        activeSheet.get_Range(activeSheet.Cells[num, num3], activeSheet.Cells[num, num3]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
                        if (column.CellType == typeof(DataGridViewTextBoxCell))
                        {
                            activeSheet.get_Range(activeSheet.Cells[num, num3], activeSheet.Cells[num + dgvCarPlay.Rows.Count, num3]).HorizontalAlignment = XlVAlign.xlVAlignCenter;
                        }
                    }
                }
                foreach (DataGridViewRow row in (IEnumerable) dgvCarPlay.Rows)
                {
                    if ((row.Cells["colSelect"].Value != null) && "true".Equals(row.Cells["colSelect"].Value.ToString().ToLower()))
                    {
                        num++;
                        num3 = num2;
                        foreach (DataGridViewColumn column2 in dgvCarPlay.Columns)
                        {
                            if (column2.Visible && (column2.CellType != typeof(DataGridViewCheckBoxCell)))
                            {
                                num3++;
                                activeSheet.Cells[num, num3] = "'" + row.Cells[column2.Index].Value;
                            }
                        }
                        continue;
                    }
                }
                int num5 = num + 1;
                num3 = num2;
                foreach (DataGridViewColumn column3 in dgvCarPlay.Columns)
                {
                    if (column3.Visible)
                    {
                        num3++;
                    }
                }
                num5 = num + 2;
                activeSheet.Cells[num5, 2] = "合计:";
                activeSheet.get_Range(activeSheet.Cells[num5, 2], activeSheet.Cells[num5, 2]).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                activeSheet.Cells[num5, 3] = ((num - 4)).ToString() + "条记录";
                activeSheet.get_Range(activeSheet.Cells[num5, 3], activeSheet.Cells[num5, 3]).HorizontalAlignment = XlHAlign.xlHAlignLeft;
                activeSheet.Cells[2, num4] = Title;
                num4 = 1;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.Bold = true;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.Size = 0x16;
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num4]).Font.ColorIndex = 14;
                activeSheet.get_Range(activeSheet.Cells[4, num4], activeSheet.Cells[num5, num3]).Select();
                activeSheet.get_Range(activeSheet.Cells[4, num4], activeSheet.Cells[num5, num3]).Columns.AutoFit();
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num3]).Select();
                activeSheet.get_Range(activeSheet.Cells[2, num4], activeSheet.Cells[2, num3]).HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                if (string.IsNullOrEmpty(savePath))
                {
                    savePath = @"C:\Documents and Settings\Administrator\My Documents\Report.xls";
                }
                workbook.SaveCopyAs(savePath);
                workbook.Close(false, null, null);
                o.Quit();
                Marshal.ReleaseComObject(workbook);
                Marshal.ReleaseComObject(o);
                Marshal.ReleaseComObject(activeSheet);
                workbook = null;
                o = null;
                activeSheet = null;
                GC.Collect();
                MessageBox.Show("数据已经成功导出到：" + savePath, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception2)
            {
                MessageBox.Show(exception2.Message);
            }
        }
    }
}

