using ClosedXML.Excel;
using demosidebar;
using DocumentFormat.OpenXml.Spreadsheet;
//using HMSLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Messaging.Design;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;



namespace GSTHMS
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private const string USER_PLACEHOLDER = "";
        private const string PASS_PLACEHOLDER = "";



        private void btnLogin_Click(object sender, EventArgs e)
        {
     
            string username = txtUsername.Text.Trim();
            string password = txtPassward.Text.Trim();


            //  Username Validation

            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Enter the Username!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }


            // Password Empty Check

            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter the Password!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassward.Focus();
                return;
            }


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
                ShowSuccessPopup("✔ Login Successfully!");    // Timer From login Successfully 2 sec

                Timer openFormTimer = new Timer();
                openFormTimer.Interval = 2000;
                openFormTimer.Tick += (s, ev) =>
                {
                    openFormTimer.Stop();

                    frmUIDesign frmUI = new frmUIDesign();
                    frmUI.LoggedUserCodeVM = username;
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

        //private bool IsValidPassword(string password)    //Password validation method
        //{
        //    bool hasUpper = password.Any(char.IsUpper);
        //    bool hasLower = password.Any(char.IsLower);
        //    bool hasDigit = password.Any(char.IsDigit);
        //    bool hasSpecial = password.Any(ch => "@#$%&*!".Contains(ch));
        //    bool hasMinLength = password.Length >= 10;

        //    return hasUpper && hasLower && hasDigit && hasSpecial && hasMinLength;
        //}


        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Clear();
            txtPassward.Clear();
        }

        private void lnklblforgetpassward_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgetPassward forgetPassward = new frmForgetPassward();

            forgetPassward.Show();
        }




        private void Form1_Load(object sender, EventArgs e)
        {
            txtUsername.MaxLength = 20;

            // Password max 15 characters
            txtPassward.MaxLength = 15;


            SetUsernamePlaceholder();
            SetPasswordPlaceholder();

            txtPassward.PasswordChar = '*';

            btnShowpass.Visible = true;   
            btnhidepass.Visible = false;

            pnlforgate.Visible = false;
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
                txtPassward.UseSystemPasswordChar = false; // show placeholder text 
                txtPassward.Text = PASS_PLACEHOLDER;
                txtPassward.ForeColor = System.Drawing.Color.Gray;
            }           
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsername_Enter(object sender, EventArgs e)
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

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text.Trim()))
            {
                lblforgate.ForeColor =System.Drawing.Color.Red;
                lblforgate.Text = "Please enter username!";
                lblforgate.Visible = true;

                pnlforgate.Visible = true;

                timerdrag.Start(); // Timer start

                return;
            }

            frmForgetPassward forgetPassward = new frmForgetPassward();
            forgetPassward.Show();
        }

      

        private void txtPassword_Enter(object sender, EventArgs e)
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

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassward.Text))
            {
                SetPasswordPlaceholder();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

       
     

        private void txtPassward_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassward.Text))
            {
                txtPassward.Text = "Enter Password";
                txtPassward.ForeColor = System.Drawing.Color.Gray;
                txtPassward.UseSystemPasswordChar = false;
            }
        }

        private void txtPassward_Enter(object sender, EventArgs e)
        {
            if (txtPassward.Text == "Enter Password")
            {
                txtPassward.Text = "";
                txtPassward.ForeColor = System.Drawing.Color.Black;
                txtPassward.UseSystemPasswordChar = false;
            }
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

       

        private void btnhidepass_Click(object sender, EventArgs e)
        {
            txtPassward.PasswordChar = '*';    // password hide

            btnShowpass.Visible = true;        // show icon 
            btnhidepass.Visible = false;
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
    }
}

