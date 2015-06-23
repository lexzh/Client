namespace PublicClass
{
    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class PrintOption
    {
        private Bitmap bmp;
        private int m_iCurPageIndex;
        private Bitmap m_oBitmap;
        private PageSetupDialog m_oPgSetupDlg;
        private PrintDialog m_oPntDlg;
        private PrintDocument m_oPntDoc;
        private PrintPreviewDialog m_oPntPvwDlg;

        public PrintOption(Bitmap right)
        {
            this.bmp = right;
        }

        public PrintOption(Control control)
        {
            this.bmp = this.CaptureScreen(control, 0, 0);
        }

        [DllImport("gdi32.dll")]
        internal static extern long BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        public Bitmap CaptureScreen(Control con, int fromX, int fromY)
        {
            Size size = con.Size;
            Graphics g = con.CreateGraphics();
            Bitmap image = new Bitmap(size.Width - fromX, size.Height - fromY, g);
            Graphics graphics2 = Graphics.FromImage(image);
            IntPtr hdc = g.GetHdc();
            IntPtr hdcDest = graphics2.GetHdc();
            BitBlt(hdcDest, 0, 0, con.ClientRectangle.Width - fromX, con.ClientRectangle.Height - fromY, hdc, fromX, fromY, 0xcc0020);
            g.ReleaseHdc(hdc);
            graphics2.ReleaseHdc(hdcDest);
            return image;
        }

        private void m_oPntDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            int num = (e.PageSettings.Bounds.Width - e.PageSettings.Margins.Left) - e.PageSettings.Margins.Right;
            int num2 = (e.PageSettings.Bounds.Height - e.PageSettings.Margins.Top) - e.PageSettings.Margins.Bottom;
            int num3 = Convert.ToInt32(Math.Ceiling((double) (((Convert.ToDouble(this.m_oBitmap.Width) * 100.0) / ((double) this.m_oBitmap.HorizontalResolution)) / ((double) num))));
            int x = Convert.ToInt32((float) (((((this.m_iCurPageIndex - 1) % num3) * num) * this.m_oBitmap.HorizontalResolution) / 100f));
            int y = Convert.ToInt32((float) (((((this.m_iCurPageIndex - 1) / num3) * num2) * this.m_oBitmap.VerticalResolution) / 100f));
            Convert.ToInt32((float) ((num * this.m_oBitmap.HorizontalResolution) / 100f));
            Convert.ToInt32((float) ((num2 * this.m_oBitmap.VerticalResolution) / 100f));
            Rectangle srcRect = new Rectangle(x, y, this.m_oBitmap.Size.Width, this.m_oBitmap.Size.Height);
            e.Graphics.DrawImage(this.m_oBitmap, e.PageSettings.Margins.Left, e.PageSettings.Margins.Top, srcRect, GraphicsUnit.Pixel);
            if (this.m_iCurPageIndex >= e.PageSettings.PrinterSettings.MaximumPage)
            {
                this.m_iCurPageIndex = e.PageSettings.PrinterSettings.MinimumPage;
                e.HasMorePages = false;
            }
            else
            {
                this.m_iCurPageIndex++;
                e.HasMorePages = true;
            }
        }

        public void PageSetup()
        {
            this.printInit();
            if (this.m_oPgSetupDlg == null)
            {
                this.m_oPgSetupDlg = new PageSetupDialog();
                this.m_oPgSetupDlg.Document = this.m_oPntDoc;
                this.m_oPgSetupDlg.PageSettings = this.m_oPntDoc.DefaultPageSettings;
                this.m_oPgSetupDlg.PageSettings.Landscape = true;
            }
            try
            {
                new PageSettings();
                Margins margins = this.m_oPntDoc.DefaultPageSettings.Margins;
                if (RegionInfo.CurrentRegion.IsMetric)
                {
                    margins = PrinterUnitConvert.Convert(margins, PrinterUnit.Display, PrinterUnit.TenthsOfAMillimeter);
                }
                PageSettings settings = (PageSettings) this.m_oPntDoc.DefaultPageSettings.Clone();
                this.m_oPgSetupDlg.PageSettings = settings;
                this.m_oPgSetupDlg.PageSettings.Margins = margins;
                if (this.m_oPgSetupDlg.ShowDialog() == DialogResult.OK)
                {
                    PageSettings pageSettings = this.m_oPgSetupDlg.PageSettings;
                    this.m_oPntDoc.DefaultPageSettings = this.m_oPgSetupDlg.PageSettings;
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("未安装打印机，请进入系统控制面版添加打印机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void Print()
        {
            this.printInit();
            try
            {
                this.m_oPntDoc.PrinterSettings.MaximumPage = this.m_oPntDoc.PrinterSettings.ToPage = Convert.ToInt32((double) (Math.Ceiling((double) (Convert.ToDouble(this.m_oBitmap.Width) / ((double) ((this.m_oPntDoc.DefaultPageSettings.Bounds.Width - this.m_oPntDoc.DefaultPageSettings.Margins.Left) - this.m_oPntDoc.DefaultPageSettings.Margins.Right)))) * Math.Ceiling((double) (Convert.ToDouble(this.m_oBitmap.Height) / ((double) ((this.m_oPntDoc.DefaultPageSettings.Bounds.Height - this.m_oPntDoc.DefaultPageSettings.Margins.Top) - this.m_oPntDoc.DefaultPageSettings.Margins.Bottom))))));
                if (this.m_oPntDlg == null)
                {
                    this.m_oPntDlg = new PrintDialog();
                    this.m_oPntDlg.AllowSomePages = true;
                    this.m_oPntDlg.Document = this.m_oPntDoc;
                }
                if (this.m_oPntDlg.ShowDialog() == DialogResult.OK)
                {
                    this.m_oPntDoc.Print();
                }
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("未安装打印机，请进入系统控制面版添加打印机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void printInit()
        {
            this.m_oBitmap = this.bmp;
            if (this.m_oPntDoc == null)
            {
                this.m_oPntDoc = new PrintDocument();
                this.m_oPntDoc.DocumentName = "";
                this.m_oPntDoc.DefaultPageSettings.Landscape = true;
                this.m_iCurPageIndex = this.m_oPntDoc.PrinterSettings.MinimumPage = this.m_oPntDoc.PrinterSettings.FromPage = 1;
                this.m_oPntDoc.PrintPage += new PrintPageEventHandler(this.m_oPntDoc_PrintPage);
            }
        }

        public void PrintPreview()
        {
            this.printInit();
            try
            {
                this.m_oPntDoc.PrinterSettings.MaximumPage = this.m_oPntDoc.PrinterSettings.ToPage = Convert.ToInt32((double) (Math.Ceiling((double) (Convert.ToDouble(this.m_oBitmap.Width) / ((double) ((this.m_oPntDoc.DefaultPageSettings.Bounds.Width - this.m_oPntDoc.DefaultPageSettings.Margins.Left) - this.m_oPntDoc.DefaultPageSettings.Margins.Right)))) * Math.Ceiling((double) (Convert.ToDouble(this.m_oBitmap.Height) / ((double) ((this.m_oPntDoc.DefaultPageSettings.Bounds.Height - this.m_oPntDoc.DefaultPageSettings.Margins.Top) - this.m_oPntDoc.DefaultPageSettings.Margins.Bottom))))));
                if (this.m_oPntPvwDlg == null)
                {
                    this.m_oPntPvwDlg = new PrintPreviewDialog();
                    this.m_oPntPvwDlg.Document = this.m_oPntDoc;
                }
                this.m_oPntPvwDlg.ShowDialog();
            }
            catch (InvalidPrinterException)
            {
                MessageBox.Show("未安装打印机，请进入系统控制面版添加打印机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        public void RefleshPrintImage(Control con, int fromX, int fromY)
        {
            this.bmp = this.CaptureScreen(con, fromX, fromY);
        }

        public Bitmap PrintImage
        {
            get
            {
                return this.bmp;
            }
            set
            {
                this.bmp = value;
            }
        }
    }
}

