using demosidebar;
//using HMSLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace GSTHMS
{
    public partial class frmForgetPassward : Form
    {
        string randomCode;
        public static string toSM;
        public static int sentOTPSM;
        public frmForgetPassward()
        {
            InitializeComponent();
        }

     
      

        private void btnSendOTP_Click(object sender, EventArgs e)
        {

           

            try
            {
                lblmsgs.Visible = false;

                string username = txtEnterusername.Text.Trim();
                string enteredEmail = txtEmail.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(enteredEmail))
                {
                    lblmsgs.ForeColor = Color.Red;
                    lblmsgs.Text = "Please enter Username and Email !";
                    lblmsgs.Visible = true;
                    

                    pnlmsg.Visible = true;

                    timerdragmsg.Start(); // Timer start

                    return;
                }

                clsUser obj = new clsUser();
                obj.UserNameSM = username;

                DataTable dt = obj.IsValidUsernameEmailSM();  // Fetch record using username


                if (dt == null || dt.Rows.Count == 0)
                {
                 //   panelotp.Visible = true;        // Panel show
                    lblmsgs.ForeColor = Color.Red;   // 
                    lblmsg2.Text = "Invalid Username !";
                    lblmsg2.Visible = true;

                    pnlmsg2.Visible = true;

                    timerdragmsg.Start(); // Timer start

                    return;

                }

                // Extract Email From DB
                string emailFromDB = dt.Rows[0]["Email"].ToString().Trim().ToLower();

                // Email mismatch
                if (enteredEmail != emailFromDB)
                {
                    lblmsgs.ForeColor = Color.Red;
                    lblmsgs.Text = "Username and Email do not match !";
                    lblmsgs.Font = new Font(lblmsg.Font.FontFamily, 14, FontStyle.Bold);   // BIG SIZE
                    lblmsgs.Visible = true;

                    pnlmsg.Visible = true;

                    timerdragmsg.Start(); // Timer start

                    return;

                }

                // Email & Username Valid → Send OTP
                VerifyOTPSM();

                // Open Verify OTP Form
                frmVerifyOtp frmVerify = new frmVerifyOtp(username, enteredEmail);
                frmVerify.StartPosition = FormStartPosition.CenterScreen;
                frmVerify.Show();

                this.Close();
            }
            catch (Exception ex)
            {
                lblmsg.ForeColor = Color.Red;
                lblmsg.Text = "Error: " + ex.Message;
                lblmsg.Visible = true;
            }

        }

     


        public void VerifyOTPSM()
        {
            try
            {
                // Generate New OTP (Old OTP automatically invalid)
                Random rnd = new Random();
                frmForgetPassward.sentOTPSM = rnd.Next(100000, 999999);

                string from = "sahilgurav233@gmail.com";
                string appPassword = "dqoebrgklhfheukv";
                string to = txtEmail.Text.Trim();
                string name = txtEnterusername.Text.Trim();

                if (string.IsNullOrEmpty(to))
                {
                    MessageBox.Show("Please enter Email address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = "Your OTP Code";
                mail.Body =
                    $"Dear User {name},\n\n" +
                    $"We received a request to reset your Homestay account password.\n" +
                    $"Your One-Time Password (OTP) is: {frmForgetPassward.sentOTPSM}\n\n" +
                    $"This OTP is valid for 1 minutes.\n" +
                    $"Do not share it with anyone.\n\n" +
                    $"Thank you,\n" +
                    $"Tathastu Homestay Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from, appPassword),
                    EnableSsl = true
                };

                smtp.Send(mail);

                MessageBox.Show("OTP Sent Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void frmForgetPassward_Load(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();

            panelotp.Visible = false;
            pnlmsg.Visible = false;
            pnlmsg2.Visible = false;

            lblmsgs.Visible = false;
        }

        private void txtEnterusername_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEnterusername_Click(object sender, EventArgs e)
        {
            
        }

        private void txtMobilenumber_Click(object sender, EventArgs e)
        {
         
        }

        private void ShowOTPPopup(string msg)    // OTP Timer
        {
            //lblOtpsentsuccess.Text = msg;
            //panelotp.Visible = true;
            //panelotp.BringToFront();


            //Timer t = new Timer();
            //t.Interval = 2000;
            //t.Tick += (s, ev) =>
            //{
            //    panelotp.Visible = false;
            //    t.Stop();
            //};
            //t.Start();

            try
            {
                lblOtpsentsuccess.Text = msg;
                panelotp.Visible = true;
                panelotp.BringToFront();

                Timer t = new Timer();
                t.Interval = 2000;     // 2 seconds

                t.Tick += (s, ev) =>
                {
                    try
                    {
                        panelotp.Visible = false;
                        t.Stop();
                        t.Dispose();   // Best Practice
                    }
                    catch (Exception exTimer)
                    {
                        MessageBox.Show("Timer Error: " + exTimer.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                t.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblmsgs_Click(object sender, EventArgs e)
        {

        }

        private void timerdragmsg_Tick(object sender, EventArgs e)
        {
            pnlmsg.Visible = false;
            pnlmsg2.Visible = false;
            lblmsgs.Visible = false;

            timerdragmsg.Stop();   // Timer stop
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
