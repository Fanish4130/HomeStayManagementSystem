//using HMSLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;

namespace GSTHMS
{
    public partial class frmVerifyOtp : Form
    {
        public static int sentOTPSM;

        int generateotp;
        int second = 120;
        string OTPText;
        public frmVerifyOtp(string nm, string mail)
        {
            InitializeComponent();
            NMSM = nm;
            MailSM = mail;

        }
        public string NMSM { get; set; }
        public string MailSM { get; set; }
        private void btnverifyotp_Click(object sender, EventArgs e)
        {


            try
            {
                string otpText = txtenterotp.Text.Trim();

                // Validation
                if (!System.Text.RegularExpressions.Regex.IsMatch(otpText, @"^\d{6}$"))
                {
                    MessageBox.Show("OTP must be exactly 6 digits!", "Warning",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int enteredOTP = int.Parse(otpText);

                // Compare with latest OTP
                if (enteredOTP == frmForgetPassward.sentOTPSM)
                {
                    MessageBox.Show("OTP Verified Successfully!", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmChangePassword frmChange = new frmChangePassword(NMSM);
                    frmChange.StartPosition = FormStartPosition.CenterScreen;
                    frmChange.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid OTP. Please try again.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void frmVerifyOtp_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            StartOTPtimer();



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            second--;
            if (second > 0)
            {
                lblsecond.Text = second + " seconds ";
            }
            else
            {
                timer1.Stop();
                lblsecond.Text = "OTP Expired!";
                btnresendotp.Enabled = true;
            }
        }

        private void lblsecond_Click(object sender, EventArgs e)
        {

        }

        private void btnresendotp_Click(object sender, EventArgs e)
        {

            try
            {
                // 1️⃣ Generate NEW OTP (old OTP automatically becomes invalid)
                GenerateSendOtpSM();  // This must update sentOTPSM with new OTP

                // 2️⃣ Validate User details
                clsUser obj1 = new clsUser();
                obj1.IsValidUsernameEmailSM();

                // 3️⃣ Clear previously entered wrong OTP (Optional but recommended)
                txtenterotp.Clear();

                // 4️⃣ Restart Timer (OTP validity)
                StartOTPtimer();

            //    MessageBox.Show("New OTP sent successfully!",
               //                 "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartOTPtimer()
        {
            second = 120;
            lblsecond.Text = second + " seconds";
            btnresendotp.Enabled = false;
            timer1.Start();
        }

        public void GenerateSendOtpSM()
        {
            //Random rnd = new Random();
            //frmForgetPassward.sentOTPSM = rnd.Next(100000, 999999); // New OTP

            // Send Email/SMS
            ResendOTPSM();

           // VerifyOTPSM();

        }

        //public void VerifyOTPSM()
        //{

        //    Random rnd = new Random();                 //use random class create OTP
        //    sentOTPSM = rnd.Next(100000, 999999);

        //    string from = "manesaurabh08624@gmail.com";          //from gmail password
        //    string appPassword = "tber ybhl ahvn lqtd";         // Gmail App Password
        //    string to = MailSM;
        //    string name = NMSM;
        //    frmChangePassword obj = new frmChangePassword(name);
        //    MailMessage mail = new MailMessage();               //use create email
        //    mail.From = new MailAddress(from);
        //    mail.To.Add(to);
        //    mail.Subject = "Your OTP Code";
        //    mail.Body = $"Hello {name},\n\n" +
        //                $"Your One-Time Password (OTP) for verification is: {sentOTPSM}\n\n" +
        //                $"Please enter this OTP to complete your process.\n" +
        //                $"Note: This OTP is valid for 5 minutes. Do not share it with anyone.\n\n" +
        //                $"Thank you,\n" +
        //                $"YourApp Team";
        //    SmtpClient smtp = new SmtpClient("smtp.gmail.com")    //use smtp server to sent otp
        //    {
        //        Port = 587,
        //        Credentials = new NetworkCredential(from, appPassword),
        //        EnableSsl = true
        //    };

        //    smtp.Send(mail);

        //    //   MessageBox.Show("OTP Resend successfully!");

        //    //frmVerifyOtp frmVerify = new frmVerifyOtp(name);
        //    //frmVerify.Show();


        //}

        public void ResendOTPSM()
        {
            try
            {
                // Generate OTP
                Random rnd = new Random();
                sentOTPSM = rnd.Next(100000, 999999);

                string from = "manesaurabh08624@gmail.com";     // Sender email
                string appPassword = "saty sxtw rarx ukxw";      // App password
                string to = MailSM;                              // Receiver email
                string name = NMSM;                              // Username

                if (string.IsNullOrEmpty(to))
                {
                    MessageBox.Show("Email address is empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from);
                mail.To.Add(to);
                mail.Subject = "Your OTP Code";
                mail.Body = $"Hello {name},\n\n" +
                            $"Your One-Time Password (OTP) for verification is: {sentOTPSM}\n\n" +
                            $"This OTP is valid for 5 minutes. Do not share it with anyone.\n\n" +
                            $"Thank you,\n" +
                            $"YourApp Team";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(from, appPassword),
                    EnableSsl = true
                };

                smtp.Send(mail);

                MessageBox.Show("OTP Sent Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SmtpException ex)
            {
                MessageBox.Show("SMTP Error: " + ex.Message,
                                "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtenterotp_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // 1️⃣ Characters not allowed
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true; // Block character

                    MessageBox.Show("Only numbers are allowed!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2️⃣ Limit 6 digits
                if (char.IsDigit(e.KeyChar) && txtenterotp.Text.Length >= 6)
                {
                    e.Handled = true; // Block extra digits

                    MessageBox.Show("OTP cannot be more than 6 digits!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }

    }
