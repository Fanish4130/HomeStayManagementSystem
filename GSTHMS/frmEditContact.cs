using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmEditContact : Form
    {
        public long ContactNoPSS { get; set; }
        public string DescriptionPSS { get; set; }

        public string ContactNamePSS { get; set; }

        public string ContactTypePSS { get; set; }

        public string EmailPSS { get; set; }

        public frmEditContact()
        {
            InitializeComponent();

           
        }

        private void frmEditContact_Load(object sender, EventArgs e)
        {
            txtContact.Text = Convert.ToString(ContactNoPSS);
            lblEName.Text = ContactNamePSS;
            lblEType.Text = ContactTypePSS;
            txtEmail.Text = EmailPSS;
            rtfDescription.Text = DescriptionPSS;
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateContact_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                MessageBox.Show("Please enter the contact number", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Focus();
                return;
            }

            // Contact must be numeric
            if (!long.TryParse(txtContact.Text, out long contactNo))
            {
                MessageBox.Show("Please enter a valid numeric contact number", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Focus();
                return;
            }
            if (txtContact.Text.Length != 10)
            {
                MessageBox.Show("Contact No must be exactly 10 digits!",
                    "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Focus();
                return;
            }

            //if (string.IsNullOrWhiteSpace(txtEmail.Text))
            //{
            //    MessageBox.Show("Please enter the email", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtEmail.Focus();
            //    return;
            //}
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Please enter a valid email address", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(rtfDescription.Text))
            {
                MessageBox.Show("Please enter the description", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                rtfDescription.Focus();
                return;
            }


           
            //   Edit CONTACT Code
            
            clsUser objCon = new clsUser();

            objCon.NamePSS = lblEName.Text;
            objCon.ContactNoPSS = contactNo;      
            objCon.EmailPSS = txtEmail.Text;
            objCon.DescriptionPSS = rtfDescription.Text;

            objCon.EditContactPSS();
            if (Application.OpenForms["Form1"] != null)
            {
                frmContact frm = (frmContact)Application.OpenForms["Form1"];
                frm.LoadGridPSS();
            }

            MessageBox.Show("Update Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
           


        }

        private void rtfDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtfDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = false; // allow
            }
            else if (char.IsDigit(e.KeyChar))
            {
                // Block digits and show messages
                e.Handled = true;
                MessageBox.Show("Integers are not allowed");
            }
            else
            {
                // Block any other non-letter characters (like punctuation)
                e.Handled = true;
            }
        }

        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Block key

                MessageBox.Show("Only numbers are allowed in Contact No.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Limit to 10 digits
            if (txtContact.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;  // Stop typing more than 10 digits

                MessageBox.Show("Contact No. must be exactly 10 digits.", "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtContact.Clear();
           txtEmail.Clear();
           // rtfDescription.Clear();
            //this.Close();

        }

        private void lblstar1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connWhite_Click(object sender, EventArgs e)
        {

        }
    }
}
  