namespace Library
{
    using System;
    using System.Diagnostics;

    public class MemeroyHelper
    {
        public static void CollectMemerory()
        {
            if (AppMemerorySize >= 500L)
            {
                GC.Collect();
            }
        }

        public static long AppMemerorySize
        {
            get
            {
                long num = -1L;
                try
                {
                    num = (Process.GetCurrentProcess().WorkingSet64 / 0x400L) / 0x3e8L;
                }
                catch
                {
                }
                return num;
            }
        }

        public static long AppVirtualMemerorySize
        {
            get
            {
                long num = -1L;
                try
                {
                    num = (Process.GetCurrentProcess().PrivateMemorySize64 / 0x400L) / 0x3e8L;
                }
                catch
                {
                }
                return num;
            }
        }

        public static int ThreadCount
        {
            get
            {
                int count = -1;
                try
                {
                    count = Process.GetCurrentProcess().Threads.Count;
                }
                catch
                {
                }
                return count;
            }
        }

    }
}

