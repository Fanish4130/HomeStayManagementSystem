using demosidebar;
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
    public partial class log : Form
    {
        public log()
        {
            InitializeComponent();
        }

        //private const string USER_PLACEHOLDER = "";  //old
        //private const string PASS_PLACEHOLDER = "";

        private const string USER_PLACEHOLDER = "Enter The UserName";
        private const string PASS_PLACEHOLDER = "Enter Password";


        private void log_Load(object sender, EventArgs e)
        {
            //txtUsername.MaxLength = 20;   //old

            //// Password max 15 characters
            //txtPassward.MaxLength = 15;


            //SetUsernamePlaceholder();
            //SetPasswordPlaceholder();

            //txtPassward.PasswordChar = '*';

            //btnShowpass.Visible = true;
            //btnhidepass.Visible = false;

            //pnlforgate.Visible = false;

            txtUsername.MaxLength = 20;  //new
            txtPassward.MaxLength = 15;

            // Username Placeholder
            txtUsername.Text = USER_PLACEHOLDER;
            txtUsername.ForeColor = Color.Gray;

            // Password Placeholder
            txtPassward.Text = PASS_PLACEHOLDER;
            txtPassward.ForeColor = Color.Gray;
            txtPassward.UseSystemPasswordChar = false;

            txtPassward.PasswordChar = '*';

            btnShowpass.Visible = true;
            btnhidepass.Visible = false;

            pnlforgate.Visible = false;
        }

        private void btnhidepass_Click(object sender, EventArgs e)
        {
            txtPassward.PasswordChar = '*';    // password hide

            btnShowpass.Visible = true;        // show icon 
            btnhidepass.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassward.Text.Trim();


            if (txtUsername.Text == USER_PLACEHOLDER ||  string.IsNullOrWhiteSpace(txtUsername.Text))  //new
            {
                ShowForgotError("Please Enter UserName!");
                txtUsername.Focus();
                return;
            }

            if (txtPassward.Text == PASS_PLACEHOLDER ||
                string.IsNullOrWhiteSpace(txtPassward.Text))
            {
                ShowForgotError("Please Enter Password!");
                txtPassward.Focus();
                return;
            }


            //  Username Validation

            //if (string.IsNullOrWhiteSpace(username))   //old
            //{
            //    ShowForgotError("Please Enter UserName!");
            //    txtUsername.Focus();
            //    return;
            //}


            //// Password Empty Check

            //if (string.IsNullOrWhiteSpace(password))
            //{
            //    ShowForgotError("Please Enter Password!");
            //    txtPassward.Focus();
            //    return;
            //}




            //    Password Strength Validation

            //if (!IsValidPassword(password))
            //{
            //    MessageBox.Show("Password must contain:\n" +
            //                    "• At least 1 Capital Letter (A-Z)\n" +
            //                    "• At least 1 Small Letter (a-z)\n" +
            //                    "• At least 1 Number (0-9)\n" +
            //                    "• At least 1 Special Character (@, #, $, %, &, *, !)\n" +
            //                    "• Minimum 10 Characters",
            //                    "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtPassward.Focus();
            //    return;
            //}


            //  Call Login Method

            clsUser obj = new clsUser();
            obj.UserNameSM = username;
            obj.PasswordSM = password;
            Program.UserName = username;

            bool success = obj.LoginSM();

            if (success)
            {
                ShowSuccessPopup(" Login Successfully!");    // Timer From login Successfully 2 sec

                Timer openFormTimer = new Timer();
                openFormTimer.Interval = 2000;
                openFormTimer.Tick += (s, ev) =>
                {
                    openFormTimer.Stop();

                    frmUIDesign frmUI = new frmUIDesign();
                    frmUI.Show();
                    this.Hide();
                };
                openFormTimer.Start();
            }
            else
            {
                ShowErrorPopup("✘ Invalid Username or Password!");
            }

        }

        public void ShowForgotError(string msg)
        {
            // Label 
            lblforgate.Text = msg;
            lblforgate.ForeColor = System.Drawing.Color.Red;
            lblforgate.TextAlign = ContentAlignment.MiddleCenter;
            lblforgate.Visible = true;

            // Panel show
            pnlforgate.Visible = true;
            pnlforgate.BringToFront();

            // Timer restart 
            timerdrag.Stop();
            timerdrag.Start();
        }

        private void ShowSuccessPopup(string message)   //timer for success Login msg
        {
            lblsuccess.Text = message;
            panelsuccess.Visible = true;
            panelsuccess.BringToFront();


            Timer t = new Timer();
            t.Interval = 3000;
            t.Tick += (s, e) =>
            {
                panelsuccess.Visible = false;
                t.Stop();
            };
            t.Start();
        }
        private void ShowErrorPopup(string msg)     // timer for invalid u and p msg
        {
            lblerror.Text = msg;
            panelerroe.Visible = true;
            panelerroe.BringToFront();


            Timer t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, ev) =>
            {
                panelerroe.Visible = false;
                t.Stop();
            };
            t.Start();
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassward.Clear();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                lblforgate.ForeColor = System.Drawing.Color.Red;
                lblforgate.Text = "Please enter username!";
                lblforgate.Visible = true;

                pnlforgate.Visible = true;

                timerdrag.Start(); // Timer start

                return;
            }

            frmForgetPassward forgetPassward = new frmForgetPassward();
            forgetPassward.StartPosition = FormStartPosition.CenterScreen;
            forgetPassward.Show();
        }

        private void SetUsernamePlaceholder()     //Placeholder username
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                txtUsername.Text = USER_PLACEHOLDER;
                txtUsername.ForeColor = System.Drawing.Color.Gray;
            }

        }

        private void SetPasswordPlaceholder()    //placeholder password
        {
            if (string.IsNullOrWhiteSpace(txtPassward.Text))
            {
                txtPassward.Clear();
                txtPassward.UseSystemPasswordChar = false; // show placeholder text 
                txtPassward.Text = PASS_PLACEHOLDER;
                txtPassward.ForeColor = System.Drawing.Color.Gray;
            }

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            if (txtUsername.Text == USER_PLACEHOLDER)
            {
                txtUsername.Text = string.Empty;
                txtUsername.ForeColor = System.Drawing.Color.Black;
            }
            // Put caret at end so editing resumes naturally
            txtUsername.SelectionStart = txtUsername.Text.Length;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                SetUsernamePlaceholder();
            }
        }

        private void txtPassward_TextChanged(object sender, EventArgs e)
        {
          
            if (txtPassward.Text == PASS_PLACEHOLDER)
            {
                
                txtPassward.Text = string.Empty;
                txtPassward.ForeColor = System.Drawing.Color.Black;
                txtPassward.UseSystemPasswordChar = false; // enable password masking for typed text
            }
            // caret at end
            txtPassward.SelectionStart = txtPassward.Text.Length;
            
        }

        private void txtPassward_Leave(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtPassward.Text))  //old
            //{
            //    txtPassward.Text = "Enter Password";
            //    txtPassward.ForeColor = System.Drawing.Color.Gray;
            //    txtPassward.UseSystemPasswordChar = false;
            //}

            if (string.IsNullOrWhiteSpace(txtPassward.Text))  //old
            {
                txtPassward.UseSystemPasswordChar = false;
                txtPassward.Text = PASS_PLACEHOLDER;
                txtPassward.ForeColor = Color.Gray;
            }
        }

        private void txtUsername_Leave_1(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(txtUsername.Text))
            //{
            //    SetUsernamePlaceholder();
            //}

            if (string.IsNullOrWhiteSpace(txtUsername.Text))  //new 
            {
                txtUsername.Text = USER_PLACEHOLDER;
                txtUsername.ForeColor = Color.Gray;
            }
        }

        private void btnShowpass_Click(object sender, EventArgs e)
        {
            txtPassward.PasswordChar = '\0';   // password show

            btnShowpass.Visible = false;       // show icon hide
            btnhidepass.Visible = true;
        }

        private void timerdrag_Tick(object sender, EventArgs e)
        {
            pnlforgate.Visible = false;
            lblforgate.Visible = false;

            timerdrag.Stop();   // Timer stop
        }

        private void panelsuccess_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPassward_Enter(object sender, EventArgs e)
        {
            if (txtPassward.Text == PASS_PLACEHOLDER)  //new
            {
                txtPassward.Text = "";
                txtPassward.ForeColor = Color.Black;
                txtPassward.UseSystemPasswordChar = true;
            }
        }

        private void txtUsername_Enter(object sender, EventArgs e)
        {
            if (txtUsername.Text == USER_PLACEHOLDER) //new
            {
                txtUsername.Text = "";
                txtUsername.ForeColor = Color.Black;
            }
        }
    }
}
