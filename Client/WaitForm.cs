using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using PublicClass;
using Client.Properties;

namespace Client
{
    public partial class WaitForm : Client.FixedForm
    {
        private static WaitForm myWaitForm;

        private static string sText;

        private Thread m_Thread;

        private bool bShow;

        private static WaitForm m_Form;

        static WaitForm()
        {
            WaitForm.myWaitForm = new WaitForm();
            WaitForm.sText = "";
            WaitForm.m_Form = null;
        }

        public WaitForm()
        {
            this.InitializeComponent();
            this.pbPic.SendToBack();
            this.lblText.BackColor = Color.Transparent;
            this.lblText.BringToFront();
            this.pbPicWait.BackColor = Color.FromArgb(0, 255, 0, 0);
            this.Text = string.Concat(Variable.sTitle, Variable.sVersion);
        }

        private PictureBox getPictureBox()
        {
            PictureBox pictureBox = new PictureBox()
            {
                Image = Resources.Wait,
                BackColor = Color.FromArgb(0, 255, 0, 0),
                SizeMode = PictureBoxSizeMode.CenterImage,
                Size = new Size(18, 18)
            };
            return pictureBox;
        }

        public static new void Hide()
        {
            try
            {
                WaitForm.myWaitForm.HideImage();
                WaitForm.Hide2();
            }
            catch
            {
            }
        }

        public static void Hide2()
        {
            try
            {
                if (WaitForm.m_Form != null)
                {
                    WaitForm.m_Form.Close();
                    WaitForm.m_Form = null;
                }
            }
            catch
            {
            }
        }

        private void HideImage()
        {
            try
            {
                this.bShow = false;
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("HideImage", exception.Message);
            }
        }

        public static void Show(string sValue)
        {
            try
            {
                WaitForm.myWaitForm.ShowText(sValue);
            }
            catch
            {
            }
        }

        public static void Show(string sValue, IWin32Window iWin)
        {
            try
            {
                WaitForm.myWaitForm.ShowText(sValue, iWin);
            }
            catch
            {
            }
        }

        private void ShowImage(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return;
            }
            WaitForm.sText = sValue;
            try
            {
                this.bShow = true;
                if (this.m_Thread == null || this.m_Thread.ThreadState == ThreadState.Stopped)
                {
                    this.m_Thread = new Thread(new ParameterizedThreadStart(this.ShowLoginingFormImage));
                    this.m_Thread.Start(sValue);
                }
                else
                {
                    Thread.Sleep(300);
                    WaitForm.sText = sValue;
                }
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("显示图形", exception.ToString());
            }
        }

        public static void ShowImageForm(string sValue)
        {
            try
            {
                WaitForm.myWaitForm.ShowImage(sValue);
            }
            catch
            {
            }
        }

        private void ShowLoginingForm(object sValue)
        {
            try
            {
                WaitForm waitForm = new WaitForm();
                waitForm.seSkin.SkinFile = Variable.sSkinFiles[Convert.ToInt32(Variable.sSkinDataIndex)];
                waitForm.TopLevel = true;
                waitForm.Show();
                while (this.bShow)
                {
                    waitForm.lblText.Text = WaitForm.sText;
                    Thread.Sleep(100);
                    Application.DoEvents();
                }
                waitForm.Close();
                waitForm = null;
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("ShowLoginingForm", exception.Message);
            }
        }

        private void ShowLoginingFormImage(object sValue)
        {
            try
            {
                while (this.bShow)
                {
                    Thread.Sleep(100);
                }
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("ShowLoginingFormImage", exception.Message);
            }
        }

        private void ShowLoginingTopForm(object sValue)
        {
            try
            {
                WaitForm waitForm = new WaitForm()
                {
                    Text = string.Concat(Variable.sTitle, Variable.sVersion)
                };
                waitForm.seSkin.SkinFile = Variable.sSkinFiles[Convert.ToInt32(Variable.sSkinDataIndex)];
                waitForm.Show();
                while (this.bShow)
                {
                    waitForm.lblText.Text = WaitForm.sText;
                    Thread.Sleep(100);
                    waitForm.TopMost = true;
                    Application.DoEvents();
                }
                waitForm.Close();
                waitForm = null;
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("ShowLoginingTopForm", exception.Message);
            }
        }

        private void ShowText(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return;
            }
            WaitForm.sText = sValue;
            try
            {
                this.bShow = true;
                if (this.m_Thread == null || this.m_Thread.ThreadState == ThreadState.Stopped)
                {
                    WaitForm.sText = sValue;
                    this.m_Thread = new Thread(new ParameterizedThreadStart(this.ShowLoginingForm));
                    this.m_Thread.Start(sValue);
                }
                else
                {
                    Thread.Sleep(300);
                    WaitForm.sText = sValue;
                }
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("显示提示信息", exception.ToString());
            }
        }

        private void ShowText(string sValue, IWin32Window iWin)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return;
            }
            WaitForm.sText = sValue;
            try
            {
                if (WaitForm.m_Form == null)
                {
                    WaitForm.m_Form = new WaitForm();
                }
                WaitForm.m_Form.seSkin.SkinFile = Variable.sSkinFiles[Convert.ToInt32(Variable.sSkinDataIndex)];
                WaitForm.m_Form.TopLevel = true;
                WaitForm.m_Form.lblText.Text = WaitForm.sText;
                try
                {
                    WaitForm.m_Form.Visible = false;
                    WaitForm.m_Form.Show(iWin);
                }
                catch (ArgumentException argumentException)
                {
                    WaitForm.m_Form.Show();
                }
                Application.DoEvents();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("显示提示信息", exception.ToString());
            }
        }

        public static void ShowTop(string sValue)
        {
            try
            {
                WaitForm.myWaitForm.ShowTopText(sValue);
            }
            catch
            {
            }
        }

        private void ShowTopText(string sValue)
        {
            if (string.IsNullOrEmpty(sValue))
            {
                return;
            }
            WaitForm.sText = sValue;
            try
            {
                this.bShow = true;
                if (this.m_Thread == null || this.m_Thread.ThreadState == ThreadState.Stopped)
                {
                    this.m_Thread = new Thread(new ParameterizedThreadStart(this.ShowLoginingTopForm));
                    this.m_Thread.Start(sValue);
                }
                else
                {
                    Thread.Sleep(300);
                    WaitForm.sText = sValue;
                }
            }
            catch (ThreadAbortException threadAbortException)
            {
                Thread.Sleep(300);
                Thread.ResetAbort();
            }
            catch (Exception exception)
            {
                Record.execFileRecord("置顶显示提示信息", exception.ToString());
            }
        }
    
    }
}
