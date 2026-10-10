using Guna.UI2.WinForms;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmEmail : Form
    {
        public int EmailTemplateIdSRM { get; set; }
        public string selectedFilePathSRM = "";

        Guna2Elipse guna2Elipse1 = new Guna2Elipse();

        public frmEmail()
        {
            InitializeComponent();
        }

        private void frmEmail_Load(object sender, EventArgs e)
        {
            
            pnlEmailButtons.Visible = false;
            guna2Elipse1.TargetControl = this;

            foreach (Control c in this.Controls)
            {
                if (c is Guna2TextBox tb)
                {
                    tb.BorderColor = Color.Silver;
                    tb.BorderRadius = 3;
                    tb.FillColor = Color.White;
                }
            }

            clsUser obj = new clsUser();
            DataTable dt1 = obj.FetchEmailSRM();

            cmbbxTO.DisplayMember = "EmailID";
            cmbbxTO.ValueMember = "EnquiryCode";
            cmbbxTO.DataSource = dt1;

            cmbbxTO.IntegralHeight = false;
            cmbbxTO.DropDownHeight = 200;
            cmbbxTO.MaxDropDownItems = 8;

            txtCc.Text = "sayali1212mohite@gmail.com";
        }

        private void LoadEmailTemplate(string templateName)
        {
            clsUser obj = new clsUser();
            DataTable dt = new DataTable();

            if (templateName == "Enquiry")
                dt = obj.FetchEnquiryTemplateSRM();
            else if (templateName == "Offer")
                dt = obj.FetchOfferTemplateSRM();
            else if (templateName == "Event")
                dt = obj.FetchEventTemplateSRM();

            if (dt.Rows.Count > 0)
            {
                txtSubject.Text = dt.Rows[0]["Subject"].ToString();
                rtbEmailTemplate.Text = dt.Rows[0]["Body"].ToString();
                EmailTemplateIdSRM = Convert.ToInt32(dt.Rows[0]["TempleteID"]);
            }

            pnlEmailButtons.Visible = false;
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            pnlEmailButtons.Visible = !pnlEmailButtons.Visible;
        }

        private void btmEnquiry_Click(object sender, EventArgs e)
        {
            LoadEmailTemplate("Enquiry");
        }

        private void btnOffer_Click(object sender, EventArgs e)
        {
            LoadEmailTemplate("Offer");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            LoadEmailTemplate("Event");
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cmbbxTO.SelectedValue == null)
            {
                MessageBox.Show("Please select email");
                return;
            }

            if (txtSubject.Text == "")
            {
                MessageBox.Show("Please select email template");
                return;
            }

            MimeMessage message = new MimeMessage();

            message.From.Add(
                new MailboxAddress(
                    "Tathastuu Workers",
                    "sayali1212mohite@gmail.com"
                )
            );

            message.To.Add(MailboxAddress.Parse(cmbbxTO.Text));

            if (!string.IsNullOrWhiteSpace(txtCc.Text))
            {
                string[] ccEmails = txtCc.Text.Split(',');

                foreach (string email in ccEmails)
                {
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        message.Cc.Add(
                            MailboxAddress.Parse(email.Trim())
                        );
                    }
                }
            }

            if (!string.IsNullOrWhiteSpace(txtBcc.Text))
            {
                string[] bccEmails = txtBcc.Text.Split(',');

                foreach (string email in bccEmails)
                {
                    if (!string.IsNullOrWhiteSpace(email))
                    {
                        message.Bcc.Add(
                            MailboxAddress.Parse(email.Trim())
                        );
                    }
                }
            }

            message.Subject = txtSubject.Text;

            BodyBuilder builder = new BodyBuilder();

            builder.HtmlBody = GetEmailHtmlBody(
                txtSubject.Text,
                rtbEmailTemplate.Text
            );

            if (!string.IsNullOrEmpty(selectedFilePathSRM))
            {
                builder.Attachments.Add(selectedFilePathSRM);
            }

            message.Body = builder.ToMessageBody();

            try
            {
                using (SmtpClient client = new SmtpClient())
                {
                    client.Connect(
                        "smtp.gmail.com",
                        587,
                        SecureSocketOptions.StartTls
                    );

                    client.Authenticate(
                        "sayali1212mohite@gmail.com",
                        "joso zdnp lkoy damj"
                    );

                    client.Send(message);
                    client.Disconnect(true);
                }

                clsUser obj = new clsUser();
                DataRowView drv = (DataRowView)cmbbxTO.SelectedItem;

                obj.EmailIDSRM = cmbbxTO.Text;
                obj.EnquiryCodeSRM = drv["EnquiryCode"].ToString();
                obj.EmailTemplateIDSRM = EmailTemplateIdSRM;
                obj.CCSRM = txtCc.Text;
                obj.BCCSRM = txtBcc.Text;

                obj.SaveEmailSRM();

                MessageBox.Show("Email sent & saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private string GetEmailHtmlBody(string subject, string body)
        {
            body = body.Replace("\n", "<br>");

            return @"
                <html>
                <body style='margin:0;padding:0;background:#f4f7fb;font-family:Segoe UI, Arial, sans-serif;'>

                <div style='max-width:700px;margin:20px auto;background:#ffffff;
                border-radius:15px;
                overflow:hidden;
                box-shadow:0 4px 15px rgba(0,0,0,0.12);'>

                <div style='background:#003366;
                color:white;
                padding:25px;
                text-align:center;'>

                <h1 style='margin:0;font-size:28px;'>🏡 Tathastu Homestay</h1>

                <p style='margin-top:8px;
                color:#ffd700;
                font-size:16px;'>
                Comfort Like Home
                </p>

                </div>

                <div style='padding:30px;'>

                <h2 style='color:#003366;margin-top:0;'>
                " + subject + @"
                </h2>

                <p style='font-size:16px;
                line-height:1.8;
                color:#333333;'>
                " + body + @"
                </p>

                <div style='margin-top:20px;
                padding:15px;
                background:#fff8e1;
                border-left:5px solid #ffc107;
                border-radius:6px;'>

                <b>✨ Our Services</b><br><br>

                ✔ Comfortable Accommodation<br>
                ✔ Delicious Food Service<br>
                ✔ Parking Facility<br>
                ✔ Event Management Support<br>
                ✔ Family Gatherings<br>
                ✔ Corporate Events

                </div>

                </div>

                <div style='background:#003366;
                color:white;
                text-align:center;
                padding:16px;
                font-size:14px;'>

                📞 Contact Us<br>
                📧 tathastuhomestay@gmail.com<br>
                📍 Panchgani, Maharashtra

                </div>

                </div>

                </body>
                </html>";
        }

        private void btnDiscard_Click(object sender, EventArgs e)
        {
            cmbbxTO.SelectedIndex = 0;
            txtCc.Clear();
            txtBcc.Clear();
            txtSubject.Clear();
            rtbEmailTemplate.Clear();

            selectedFilePathSRM = "";
            guna2Button1.Text = "Select File";

            pnlEmailButtons.Visible = false;

            MessageBox.Show("All fields are cleared");
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Title = "Select Attachment";
            ofd.Filter = "All Files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                selectedFilePathSRM = ofd.FileName;

                guna2Button1.Text =
                    System.IO.Path.GetFileName(selectedFilePathSRM);

                MessageBox.Show("File selected successfully");
            }
        }

        private void frmEmail_Deactivate(object sender, EventArgs e)
        {
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label8_Click(object sender, EventArgs e)
        {
        }

        private void pnlEmailButtons_Paint(object sender, PaintEventArgs e)
        {
        }

        private void rtbEmailTemplate_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtBcc_TextChanged(object sender, EventArgs e)
        {
        }
    }
}