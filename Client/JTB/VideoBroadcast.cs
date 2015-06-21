namespace Client.JTB
{
    using Client;
    using Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class VideoBroadcast : SizableForm
    {

        public VideoBroadcast(string url)
        {
            this.InitializeComponent();
            this.mediaPlayer1.VideoPlayer.URL = url;
        }


    }
}