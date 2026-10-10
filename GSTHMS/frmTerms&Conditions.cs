using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmTerms_ConditionsVM : Form
    {
        public frmTerms_ConditionsVM()
        {
            InitializeComponent();
        }

        // 🔹 Load Terms from Database
        public void LoadTerms()
        {
            try
            {
                clsUser clsUser = new clsUser();
                DataTable dt = clsUser.FetchTermsAndConditionsTableVM();

                StringBuilder sb = new StringBuilder();

                foreach (DataRow row in dt.Rows)
                {
                    string desc = row["Description"]?.ToString();

                    if (!string.IsNullOrWhiteSpace(desc))
                    {
                        sb.AppendLine("• " + desc);
                        sb.AppendLine();
                    }
                }

                rtbTermsndcondVM.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Terms: " + ex.Message);
            }
        }

        // 🔹 Accept Button
        public void btnAcceptVM_Click(object sender, EventArgs e)
        {
            if (!chkbxTermVM.Checked)
            {
                MessageBox.Show("Please accept Terms & Conditions first!");
                return;
            }

            MessageBox.Show("Terms Accepted ✅");
            this.Close();
        }



        public void frmTerms_ConditionsVM_Load_1(object sender, EventArgs e)
        {
            LoadTerms();
            btnAcceptVM.Enabled = false; 
        }

        public void chkbxTermVM_CheckedChanged(object sender, EventArgs e)
        {
            btnAcceptVM.Enabled = chkbxTermVM.Checked;
        }

        public void btnCancelVM_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "You must accept Terms & Conditions to continue. Exit?",
               "Warning",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
           );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void lblTermsnCondVM_Click(object sender, EventArgs e)
        {

        }
    }
}