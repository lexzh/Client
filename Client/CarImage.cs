namespace Client
{
    using Properties;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CarImage : FixedForm
    {

        public CarImage()
        {
            this.InitializeComponent();
        }

        private void CarImage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\x001b')
            {
                base.Close();
            }
        }


    }
}