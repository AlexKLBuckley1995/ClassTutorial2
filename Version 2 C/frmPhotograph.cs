namespace Version_2_C
{
    sealed public partial class frmPhotograph : Version_2_C.frmWork
    {
        public static readonly frmPhotograph Instance = new frmPhotograph();

        public frmPhotograph()
        {
            InitializeComponent();
        }

        protected override void updateForm()
        {
            base.updateForm();
            clsPhotograph lcWork = (clsPhotograph)this._Work;
            txtWidth.Text = lcWork.Width.ToString();
            txtHeight.Text = lcWork.Height.ToString();
            txtType.Text = lcWork.Type;
        }

        protected override void pushData()
        {
            base.pushData();
            clsPhotograph lcWork = (clsPhotograph)_Work;
            lcWork.Width = float.Parse(txtWidth.Text);
            lcWork.Height = float.Parse(txtHeight.Text);
            lcWork.Type = txtType.Text;
        }
    }
}

