//using HMSLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmChangePassword : Form
    {
        public static class GlobalData
        {
            public static string Email {  get; set; }
        }
        public frmChangePassword(string nm)
        {
            InitializeComponent();
            NM = nm;    
        }
        public string NM { get;set; }
        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            txtconfirmpassword.PasswordChar = '*';   //confirm password

            btnShowpass.Visible = true;
            btnhidepass.Visible = false;

            txtnewpassword.PasswordChar = '*';   //new password

            btnshownewp.Visible = true;
            btnhidenewp.Visible = false;

        }

          private bool IsValidPassword(string password)    //Password validation method  new
        {
            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecial = password.Any(ch => "@#$%&*!".Contains(ch));
            bool hasMinLength = password.Length >= 8;

            return hasUpper && hasLower && hasDigit && hasSpecial && hasMinLength;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            //string newPass = txtnewpassword.Text.Trim();
            //string confirmPass = txtconfirmpassword.Text.Trim();

            //// ----- Validation -----

            //if (string.IsNullOrEmpty(newPass))
            //{
            //    MessageBox.Show("Please Enter New Password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtnewpassword.Focus();
            //    return;
            //}

            //if (string.IsNullOrEmpty(confirmPass))
            //{
            //    MessageBox.Show("PLease Confirm Password Fill", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtconfirmpassword.Focus();
            //    return;
            //}

            //if (newPass != confirmPass)
            //{
            //    MessageBox.Show("New Password And Confirm Password Not Match", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtconfirmpassword.Focus();
            //    return;
            //}

            //clsUser obj = new clsUser();
            //string password = txtconfirmpassword.Text;
            //obj.PasswordSM = password;
            //obj.UserNameSM = NM;
            //obj.NewPasswordSM();

            //MessageBox.Show("Password Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //txtnewpassword.Text = "";
            //txtconfirmpassword.Text = "";
            //this.Close();


            try
            {
                string newPass = txtnewpassword.Text.Trim();
                string confirmPass = txtconfirmpassword.Text.Trim();

                // ----- Validation -----

                if (string.IsNullOrEmpty(newPass))
                {
                    MessageBox.Show("Please Enter New Password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtnewpassword.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(confirmPass))
                {
                    MessageBox.Show("Please Confirm Password", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtconfirmpassword.Focus();
                    return;
                }

                if (newPass != confirmPass)
                {
                    MessageBox.Show("New Password and Confirm Password do not match!",
                                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtconfirmpassword.Focus();
                    return;
                }

            //    Password Strength Validation  new

                if (!IsValidPassword(txtnewpassword.Text))
                {
                    MessageBox.Show("Password must contain:\n" +
                                    "• At least 1 Capital Letter (A-Z)\n" +
                                    "• At least 1 Small Letter (a-z)\n" +
                                    "• At least 1 Number (0-9)\n" +
                                    "• At least 1 Special Character (@, #, $, %, &, *, !)\n" +
                                    "• Minimum 10 Characters",
                                    "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     txtnewpassword.Focus();
                    return;
                }

                // ----- Update Password in DB -----
                clsUser obj = new clsUser();
                obj.PasswordSM = confirmPass;
                obj.UserNameSM = NM;

                obj.NewPasswordSM();   // DB Update Function

                MessageBox.Show("Password Updated Successfully!",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear Fields
                txtnewpassword.Text = "";
                txtconfirmpassword.Text = "";

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            txtnewpassword.Clear();
            txtconfirmpassword.Clear();
        }

        private void btnhidepass_Click(object sender, EventArgs e)
        {
            txtconfirmpassword.PasswordChar = '*';    // password hide

            btnShowpass.Visible = true;        // show icon 
            btnhidepass.Visible = false;
        }

        private void btnShowpass_Click(object sender, EventArgs e)
        {
            txtconfirmpassword.PasswordChar = '\0';   // password show

            btnShowpass.Visible = false;       // show icon hide
            btnhidepass.Visible = true;
        }

        private void btnshownewp_Click(object sender, EventArgs e)
        {
            txtnewpassword.PasswordChar = '\0';   // password show

            btnshownewp.Visible = false;       // show icon hide
            btnhidenewp.Visible = true;
        }

        private void btnhidenewp_Click(object sender, EventArgs e)
        {
            txtnewpassword.PasswordChar = '*'; 
            // password hide
            btnshownewp.Visible = true;        // show icon 
            btnhidenewp.Visible = false;
        }
    }
    
}
