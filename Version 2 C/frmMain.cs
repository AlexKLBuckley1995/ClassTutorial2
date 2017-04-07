using System;
using System.Windows.Forms;
using System.Linq;

namespace Version_2_C
{
    sealed public partial class frmMain : Form
    {
        private static readonly frmMain _Instance = new frmMain();

        private frmMain()
        {
            InitializeComponent();
        }

        private clsArtistList _ArtistList = new clsArtistList();

        public static frmMain Instance
        {
            get
            {
                return _Instance;
            }
        }

        public void UpdateDisplay()
        {
            lstArtists.DataSource = null;  //Make lstArtist null
            // lstArtists.DataSource = _ArtistList.Values.ToList(); //This displays all values in the ArtistList in the lstbox on frmMain
            string[] lcDisplayList = new string[_ArtistList.Count]; //Make string var lcDisplayList to hold the contents of the ArtistList
            _ArtistList.Keys.CopyTo(lcDisplayList, 0); //Display keys from ArtistList in lcDisplayList
            lstArtists.DataSource = lcDisplayList; //Display lcDisplayList in ArtistList
            lblValue.Text = Convert.ToString(_ArtistList.GetTotalValue());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            try
            {
                frmArtist.Run(new clsArtist(_ArtistList)); //Add a new clsArtist to clsArtistList
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error adding new artist");
            }
        }

        private void lstArtists_DoubleClick(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null)
                try
                {
                    frmArtist.Run(_ArtistList[lcKey]); //Call the Run function in frmArtist to determine whether to instanitate a new frmArtist or show and activate a existing one in the _ArtistFormList dictionary
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "This should never occur");
                }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            try
            {
                _ArtistList.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File Save Error");
            }
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string lcKey;

            lcKey = Convert.ToString(lstArtists.SelectedItem);
            if (lcKey != null && MessageBox.Show("Are you sure?", "Deleting artist", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                try
                {
                    _ArtistList.Remove(lcKey);
                    lstArtists.ClearSelected();
                    UpdateDisplay();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error deleing artist");
                }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                _ArtistList = clsArtistList.RetrieveArtistList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "File retrieve error");
            }
            UpdateDisplay();
        }
    }
}