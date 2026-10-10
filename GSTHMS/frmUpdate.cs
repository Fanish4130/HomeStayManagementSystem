using ClosedXML.Excel;
using demosidebar;
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
using System.Windows.Interop;
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters;
using static System.Windows.Forms.AxHost;

namespace GSTHMS
{
    public partial class frmUpdate : Form
    {
        public string G_Name1AB;

        public frmUpdate()
        {
            InitializeComponent();
        }

        public frmUpdate(string gname)
        {
            InitializeComponent();
            G_Name1AB = gname;
        }

        public int CountryIdAB;
        public int StateIdAB;
        public int CityIDAB;

        private void btnSaveChange_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter the E-Mail Address.");
                    txtEmail.Focus();
                    lbl1.Visible = true;
                    return;
                }

                if (!IsEmailValidAB(txtEmail.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid E-Mail address in the format: user@domain.com");
                    txtEmail.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    MessageBox.Show("Please enter Contact Number.");
                    txtContactNo.Focus();
                    lbl2.Visible = true;
                    return;
                }

                if (txtContactNo.Text.Length != 10)
                {
                    MessageBox.Show("Contact Number must be exactly 10 digits.");
                    txtContactNo.Focus();
                    return;
                }

                DialogResult dr = MessageBox.Show("Are you sure you want to Update this enquiry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;
                clsUser obj = new clsUser();
                obj.GuestNameAB = G_Name1AB;
                obj.EmailIDAB = txtEmail.Text.Trim();
                obj.ContactNoAB = Convert.ToInt64(txtContactNo.Text);
                obj.ReasonAB = lblReasonOfEnquiry12.Text.Trim();
                obj.UpdateEnquiryAB();
                MessageBox.Show("Record updated successfully!");
                this.Close();
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Error converting contact number: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during Updating: " + ex.Message);
            }
        }

        private void txtContactNo_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (txtContactNo.Text.Length > 10)
                {
                   // MessageBox.Show("Contact No. cannot exceed 10 digits.");
                    txtContactNo.Text = txtContactNo.Text.Substring(0, 10);
                    txtContactNo.SelectionStart = txtContactNo.Text.Length;
                    txtContactNo.SelectionLength = 0;
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in ContactNo TextChanged: " + ex.Message);
            }
        }

        private void txtContactNo_Validating_1(object sender, CancelEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtContactNo.Text))
                {
                    if (txtContactNo.Text.Length != 10)
                    {
                        MessageBox.Show("Please enter 10 digits for the Contact No.");
                        e.Cancel = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in ContactNo Validating: " + ex.Message);
            }
        }

        private void txtContactNo_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter Digits..");
                }
                if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in ContactNo KeyPress: " + ex.Message);
            }
        }

        private void txtPinCode_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Please enter Digits..");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in PinCode KeyPress: " + ex.Message);
            }
        }

        private bool IsEmailValidAB(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return false;
                }

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during email validation: " + ex.Message);
                return false;
            }
        }

        private void frmUpdate_Load(object sender, EventArgs e)
        {
            try
            {
                lbl3.Visible = false;
                lbl4.Visible = false;
                lbl5.Visible = false;
                lbl6.Visible = false;
                lbl7.Visible = false;
                clsUser obj1 = new clsUser();
                obj1.GuestNameAB = G_Name1AB;
                DataTable dt = obj1.FetchUpdatedDateAB();

                if (dt != null && dt.Rows.Count > 0)
                {
                    lblGuestName.Text = dt.Rows[0]["GuestName"].ToString();
                    txtContactNo.Text = dt.Rows[0]["ContactNo"].ToString();
                    txtEmail.Text = dt.Rows[0]["EmailID"].ToString();
                    lblReasonOfEnquiry12.Text = dt.Rows[0]["Reason"].ToString();
                    lblCountry1.Text = dt.Rows[0]["CountryName"].ToString();
                    lblState1.Text = dt.Rows[0]["StateName"].ToString();
                    lblCity1.Text = dt.Rows[0]["CityName"].ToString();
                    lblAddress1.Text = dt.Rows[0]["Address"].ToString();
                    lblpincode1.Text = dt.Rows[0]["Pincode"].ToString();
                    lblGender1.Text = dt.Rows[0]["Gender"].ToString();
                }
                else
                {
                    MessageBox.Show("No data found to load for update.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during form load: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                txtEmail.Text = null;
                txtContactNo.Text = null;
                //lblReasonOfEnquiry12.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred during clear: " + ex.Message);
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblGuestNamee_Click(object sender, EventArgs e)
        {

        }
    }            
}