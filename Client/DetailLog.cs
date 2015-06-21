namespace Client
{
    using PublicClass;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class DetailLog : FixedForm
    {
        public Button btnClose;
        public Button btnDown;
        public Button btnUp;
        public static LogForm myLogForm;

        public DetailLog()
        {
            this.InitializeComponent();
            base.seSkin.SkinFile = Variable.sSkinFiles[int.Parse(Variable.sSkinDataIndex)];
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            base.Close();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            myLogForm.execMoveSelected(1);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            myLogForm.execMoveSelected(-1);
        }

 public void setShowDetail(DataGridViewRow drvDetail)
        {
            this.lblGpsTimeValue.Text = drvDetail.Cells["ReceTime"].Value.ToString();
            this.lblOrderIdValue.Text = drvDetail.Cells["OrderId"].Value.ToString();
            this.lblCarNumValue.Text = drvDetail.Cells["CarNum"].Value.ToString();
            this.lblOrderTypeValue.Text = drvDetail.Cells["OrderType"].Value.ToString();
            this.lblOrderNameValue.Text = drvDetail.Cells["OrderName"].Value.ToString();
            this.lblOrderResultValue.Text = drvDetail.Cells["OrderResult"].Value.ToString();
            this.lblCommFlagValue.Text = drvDetail.Cells["CommFlag"].Value.ToString();
            this.txtDescribe.Text = drvDetail.Cells["Describe"].Value.ToString();
        }
    }
}

