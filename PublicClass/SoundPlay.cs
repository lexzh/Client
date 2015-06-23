namespace PublicClass
{
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class SoundPlay
    {
        private const int SND_ASYNC = 1;
        private const int SND_FILENAME = 0x20000;

        [DllImport("winmm.dll")]
        private static extern bool PlaySound(string pszSound, int hmod, int fdwSound);
        public static void PlaySoundEx(string path)
        {
            if (!string.IsNullOrEmpty(path) && File.Exists(path))
            {
                try
                {
                    PlaySound(path, 0, 0x20001);
                }
                catch (Exception)
                {
                }
            }
        }
    }
}

