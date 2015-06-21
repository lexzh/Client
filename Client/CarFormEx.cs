namespace Client
{
    using ParamLibrary.Application;
    using ParamLibrary.Entity;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class CarFormEx : CarForm
    {
        public System.Windows.Forms.Panel pnlContainer;

        public CarFormEx(CmdParam.OrderCode OrderCode)
        {
            this.InitializeComponent();
            base.OrderCode = OrderCode;
        }

        protected override void btnOK_Click(object sender, EventArgs e)
        {
            base.btnOK_Click(sender, e);
            if (this._carparam.Send(this))
            {
                base.DialogResult = DialogResult.OK;
            }
        }

        private void CarFormEx_Load(object sender, EventArgs e)
        {
            this._carparam.Init(this);
        }

 private void pnlBtn_SizeChanged(object sender, EventArgs e)
        {
            base.btnCancel.Left = (base.pnlBtn.Width - base.btnCancel.Width) - 3;
            base.btnOK.Left = ((base.pnlBtn.Width - base.btnCancel.Width) - base.btnOK.Width) - 10;
        }

        public CarFormBaseControl CarParam
        {
            get
            {
                return this._carparam;
            }
            set
            {
                this._carparam = value;
            }
        }

        public string CmdCarParam
        {
            get
            {
                return base.sValue;
            }
        }

        public string CmdCarPassword
        {
            get
            {
                return base.sPw;
            }
        }

        public CmdParam.ParamType CmdParamType
        {
            get
            {
                return base.ParamType;
            }
        }

        public Response Repose
        {
            get
            {
                return base.reResult;
            }
            set
            {
                base.reResult = value;
            }
        }
    }
}

