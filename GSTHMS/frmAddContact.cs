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
    public partial class frmAddContact : Form
    {
        public frmAddContact()
        {
            InitializeComponent();
        }
       
        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Please enter the name", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

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
                MessageBox.Show("Contact No must be exactly 10 digits!", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContact.Focus();
                return;
            }

            
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


            
            //   SAVE CONTACT 
            
            clsUser objCon = new clsUser();

            objCon.NamePSS = txtName.Text;
            objCon.ContactTypePSS=txtContactType.Text;
            objCon.ContactNoPSS = contactNo;        
            objCon.EmailPSS = txtEmail.Text;
            objCon.DescriptionPSS = rtfDescription.Text;

            objCon.SaveContactPSS();

            MessageBox.Show("Save Successfully", "SUCCESS", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

            if (Application.OpenForms["frmContact"] != null)
            {
                frmContact frm = (frmContact)Application.OpenForms["frmContact"];
                frm.LoadGridPSS();
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            rtfDescription.Clear();

           // this.Close();
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) &&!char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only letters are allowed!","INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        
        private void rtfDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtfDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            // / Allow letters, control keys(like Backspace), and whitespace
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
            if (rtfDescription.ForeColor == Color.Gray)
            {
                e.Handled = true;
                return;
            }

        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

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

        private void frmAddContact_Load(object sender, EventArgs e)
        {
           
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
          

           
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void connWAdd(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtContactType_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContactType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only letters are allowed!", "INVALID", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
