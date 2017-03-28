using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Version_2_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        //Instantiate a dictionary container to hold several artist forms. Each artist form is associated with a single artist instance
        private static Dictionary<clsArtist, frmArtist> _ArtistFormList = new Dictionary<clsArtist, frmArtist>();

        private clsArtist _Artist;
        private clsWorksList _WorksList;


        private void updateDisplay()
        {
        //    txtName.Enabled = txtName.Text == "";
            if (_WorksList.SortOrder == 0)
            {
                _WorksList.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _WorksList.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _WorksList;
            lblTotal.Text = Convert.ToString(_WorksList.GetTotalValue());
        }

        public static void Run(clsArtist prArtist) //This Run function checks if a form is associated with an artist and either instantiates a new form or shows and activates an existing form
        {
            frmArtist lcArtistForm;
            if (!_ArtistFormList.TryGetValue(prArtist, out lcArtistForm)) //Check if a form is associated with an artist
            {
                lcArtistForm = new frmArtist(); //If there is no form associated with an artist then instantiate a new form
                _ArtistFormList.Add(prArtist, lcArtistForm);
                lcArtistForm.SetDetails(prArtist);
            }
            else
            { //If a form is associated with an artist then show and activate that form
                lcArtistForm.Show();
                lcArtistForm.Activate();
            }
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            txtName.Enabled = string.IsNullOrEmpty(_Artist.Name);
            updateForm();
            updateDisplay();
            Show(); //Using Show() rather than ShowDialog() creates asynchroous threads of execution
        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            _WorksList = _Artist.WorksList;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;

            if (lcIndex >= 0 && MessageBox.Show("Are you sure?", "Deleting work", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _WorksList.RemoveAt(lcIndex);
                updateDisplay();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string lcReply = new InputBox(clsWork.FACTORY_PROMPT).Answer;
            if (!string.IsNullOrEmpty(lcReply))
            {
                _WorksList.AddWork(lcReply[0]);
                updateDisplay();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid() == true)
                try
                {
                    pushData();
                    if (txtName.Enabled) //If txtName is enabled we are adding a new artist
                    {
                        _Artist.NewArtist(); //Create a new artist
                        MessageBox.Show("Artist added!", "Success");
                        frmMain.Instance.UpdateDisplay(); //We call UpdateDisplay() to ensure the artist list on the main form is refreshed
                        txtName.Enabled = false; //If the new artist was created successfully we disable the txtName to indicate the artist exists
                    }
                    Hide(); //Hide the frmArtist if the new artist was created successfully
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); //If the artist was not successfully created then the exception error is printed out on a messagebox
                }
        }

        private Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!", "Error adding artist");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                _WorksList.EditWork(lstWorks.SelectedIndex);
                updateDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _WorksList.SortOrder = Convert.ToByte(rbByDate.Checked);
            updateDisplay();
        }
    }
}