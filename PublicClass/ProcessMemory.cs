namespace PublicClass
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;

    public class ProcessMemory
    {
        public static int SetProcessMemoryToMin()
        {
            return SetProcessMemoryToMin(Process.GetCurrentProcess().Handle);
        }

        private static int SetProcessMemoryToMin(IntPtr SetProcess)
        {
            if ((Environment.OSVersion.Platform == PlatformID.Win32NT) || (Environment.OSVersion.Platform == PlatformID.Win32Windows))
            {
                try
                {
                    return SetProcessWorkingSetSize(SetProcess, -1, -1);
                }
                catch
                {
                }
            }
            return -1;
        }

        public static void SetProcessMemoryToMin2(int maxMemory)
        {
            try
            {
                long num = (Process.GetCurrentProcess().WorkingSet64 / 0x400L) / 0x3e8L;
                if (num > maxMemory)
                {
                    SetProcessMemoryToMin();
                }
            }
            catch
            {
            }
        }

        [DllImport("kernel32.dll")]
        private static extern int SetProcessWorkingSetSize(IntPtr hProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);
    }
}

