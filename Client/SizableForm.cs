using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Sunisoft.IrisSkin;
using PublicClass;

namespace Client
{
    public partial class SizableForm : Form
    {
        public SkinEngine seSkin;
        public SizableForm()
        {
            InitializeComponent();
            this.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
        }

        private void SizableForm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessMemory.SetProcessMemoryToMin();
        }
    }
}
