namespace Version_2_C
{
    sealed public partial class frmSculpture : Version_2_C.frmWork
    {

        public static readonly frmSculpture Instance = new frmSculpture();


        public frmSculpture()
        {
              InitializeComponent();
        }

        public static void Run(clsSculpture prSculpture) //This function prevents the instantiation of frmSculpture forms we may never use
        {
            Instance.SetDetails(prSculpture);
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsSculpture lcWork = (clsSculpture)this._Work;
            txtWeight.Text = lcWork.Weight.ToString();
            txtMaterial.Text = lcWork.Material;
        }

        protected override void pushData()
        {
            base.pushData();
            clsSculpture lcWork = (clsSculpture)_Work;
            lcWork.Weight = float.Parse(txtWeight.Text);
            lcWork.Material = txtMaterial.Text;
        }
    }
}

