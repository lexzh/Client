namespace Client.JTB
{
    using Client;
    using Other;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    partial class VideoBroadcast
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
            this.mediaPlayer1 = new MediaPlayer();
            base.SuspendLayout();
            this.mediaPlayer1.Dock = DockStyle.Fill;
            this.mediaPlayer1.Location = new Point(0, 0);
            this.mediaPlayer1.Name = "mediaPlayer1";
            this.mediaPlayer1.Size = new Size(371, 322);
            this.mediaPlayer1.TabIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode =  System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new Size(371, 322);
            base.Controls.Add(this.mediaPlayer1);
            base.MinimizeBox = false;
            base.Name = "VideoBroadcast";
            this.Text = "";
            base.ResumeLayout(false);
        }
    
        private IContainer components;
        private Other.MediaPlayer mediaPlayer1;
    }
}