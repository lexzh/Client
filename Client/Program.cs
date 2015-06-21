namespace Client
{
    //using GlsService;
    using PublicClass;
    using System;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Windows.Forms;

    public static class Program
    {
        public static MainForm mainForm;

        private static void HandleException(Exception ex)
        {
            Record.execFileRecord("启动程序", ex.ToString());
            MessageBox.Show("发生未知异常[" + ex.Message + "]");
        }

        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IniFile.ReadIniFile();
            mainForm = new MainForm();
            if (Variable.bLogin)
            {
                Application.ThreadException += (sender, args) => HandleException(args.Exception);
                AppDomain.CurrentDomain.UnhandledException += delegate (object sender, UnhandledExceptionEventArgs args) {
                    Exception ex = args.ExceptionObject as Exception;
                    if (ex != null)
                    {
                        if (mainForm.InvokeRequired)
                        {
                            mainForm.Invoke(new ExceptionDelegate(Program.HandleException), new object[] { ex });
                        }
                        else
                        {
                            HandleException(ex);
                        }
                    }
                };
                Application.Run(mainForm);
            }
            else
            {
                Application.Exit();
            }
        }

        private delegate void ExceptionDelegate(Exception ex);
    }
}

