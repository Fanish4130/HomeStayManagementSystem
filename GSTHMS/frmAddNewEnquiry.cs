using ClosedXML.Excel;
using demosidebar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace GSTHMS
{
    public partial class frmAddNewEnquiry : Form
    {
        public event EventHandler EnquiryAdded;
        public frmAddNewEnquiry()
        {
            InitializeComponent();
        }

        public int CountryIdAB;
        public int StateIdAB;
        public int CityIdAB;
        public Panel blurPanel;
        //public event Action EnquiryAdded;
        private void frmAddNewEnquiry_Load(object sender, EventArgs e)
        {
            try
            {
                clsUser obj1 = new clsUser();
                DataTable dt = obj1.FetchCountryAB();

               
                DataRow placeholderRow = dt.NewRow();
                placeholderRow["CountryID"] = 0;
                placeholderRow["CountryName"] = "-- Select Country --";

                
                dt.Rows.InsertAt(placeholderRow, 0);

               
                cmbbxCountry.DisplayMember = "CountryName";
                cmbbxCountry.ValueMember = "CountryID";
                cmbbxCountry.DataSource = dt;


                cmbbxCountry.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading form:\n" + ex.Message, "Load Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbbxState.DataSource = null;
                cmbbxCity.DataSource = null;
                cmbbxState.Items.Clear();
                cmbbxCity.Items.Clear();

                if (cmbbxCountry.SelectedValue != null)
                    CountryIdAB = Convert.ToInt32(cmbbxCountry.SelectedValue);

                clsUser obj1 = new clsUser { CountryIdAB = CountryIdAB };
                DataTable dt = obj1.StateDisplayAB();

                // Create placeholder row
                DataRow placeholderRow = dt.NewRow();
                placeholderRow["StateID"] = 0;
                placeholderRow["StateName"] = "-- Select State --";
                dt.Rows.InsertAt(placeholderRow, 0);

                // Bind ComboBox
                cmbbxState.DisplayMember = "StateName";
                cmbbxState.ValueMember = "StateID";
                cmbbxState.DataSource = dt;

                // Set default selection to placeholder
                cmbbxState.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching States:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxState_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbbxCity.DataSource = null;
                cmbbxCity.Items.Clear();

                if (cmbbxState.SelectedValue != null)
                    StateIdAB = Convert.ToInt32(cmbbxState.SelectedValue);

                cmbbxCity.DataSource = null;
                cmbbxCity.Items.Clear();

                if (cmbbxState.SelectedValue != null)
                    StateIdAB = Convert.ToInt32(cmbbxState.SelectedValue);

                // Fetch city list based on selected State
                clsUser obj1 = new clsUser { CityIDAB = StateIdAB };
                DataTable dt = obj1.CityDisplayAB();

                // Create placeholder row
                DataRow placeholderRow = dt.NewRow();
                placeholderRow["CityID"] = 0;
                placeholderRow["CityName"] = "-- Select City --";
                dt.Rows.InsertAt(placeholderRow, 0);

                // Bind ComboBox
                cmbbxCity.DisplayMember = "CityName";
                cmbbxCity.ValueMember = "CityID";
                cmbbxCity.DataSource = dt;

                // Select placeholder by default
                cmbbxCity.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching Cities:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // VALIDATIONS
                if (string.IsNullOrWhiteSpace(txtGuestName.Text))
                {
                    MessageBox.Show("Please enter Guest Name.");
                    txtGuestName.Focus();
                    lbl1.Visible = true;
                    return;
                }
                if (!Regex.IsMatch(txtGuestName.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Guest Name can only contain letters.");
                    lbl1.Visible = true;
                    return;
                }
                if (!IsEmailValidAB(txtEmail.Text))
                {
                    MessageBox.Show("Please enter valid Email.");
                    txtEmail.Focus();
                    lbl2.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtContactNo.Text))
                {
                    MessageBox.Show("Please enter Contact Number.");
                    txtContactNo.Focus();
                    lbl3.Visible = true;
                    return;
                }
                if (!rdbbtnMale.Checked && !rdbbtnFemale.Checked)
                {
                    MessageBox.Show("Please select Gender.");
                    lbl4.Visible = true;
                    return;
                }
                if (cmbbxCountry.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Country.");
                    lbl5.Visible = true;
                    return;
                }
                if (cmbbxState.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select State.");
                    lbl6.Visible = true;
                    return;
                }
                if (cmbbxCity.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select City.");
                    lbl7.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(rtfAddress.Text))
                {
                    MessageBox.Show("Please enter Address.");
                    lbl8.Visible = true;
                    return;
                }
                if (!Regex.IsMatch(rtfAddress.Text, @"^[a-zA-Z\s]+$"))
                {
                    MessageBox.Show("Address can only contain letters only.");
                    rtfAddress.Focus();
                    lbl8.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtPinCode.Text))
                {
                    MessageBox.Show("Please enter Pin Code.");
                    lbl9.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(rtfReasonOfEnquiry.Text))
                {
                    MessageBox.Show("Please enter Reason of Enquiry.");
                    lbl10.Visible = true;
                    return;
                }
               

                AddEnquiryAB();
                EnquiryAdded?.Invoke(this, EventArgs.Empty);

               
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error while validating data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEnquiryAB()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtGuestName.Text))
                {
                    MessageBox.Show("Please enter the guest name.");
                    txtGuestName.Focus();
                    return;
                }
                DialogResult dr = MessageBox.Show("Are you sure you want to add this enquiry?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
                if (dr == DialogResult.No)
                    return;
                clsUser obj = new clsUser();
                obj.GuestNameAB = txtGuestName.Text;
                obj.EmailIDAB = txtEmail.Text;
                obj.ContactNoAB = Convert.ToInt64(txtContactNo.Text);
                obj.AddressAB = rtfAddress.Text;
                obj.PincodeAB = Convert.ToInt64(txtPinCode.Text);
                obj.Date1AB = DateTime.Now;
                obj.ReasonAB = rtfReasonOfEnquiry.Text;

                obj.GenderAB = rdbbtnMale.Checked ? 1 : 2;
                obj.CityIDAB = Convert.ToInt32(cmbbxCity.SelectedValue);
                obj.StateIDAB = Convert.ToInt32(cmbbxState.SelectedValue);
                obj.CountryIdAB = Convert.ToInt32(cmbbxCountry.SelectedValue);

                obj.StatusIDAB = obj.ReasonAB.ToLower().Contains("cold") ? 30
                                : obj.ReasonAB.ToLower().Contains("warm") ? 29
                                : 31;

                obj.AddEnquiryAB();

                MessageBox.Show("Enquiry added successfully!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while saving enquiry:\n" + ex.Message,
                    "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Email Validation
        private bool IsEmailValidAB(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email)) return false;

                string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$";
                return Regex.IsMatch(email, emailPattern);
            }
            catch
            {
                return false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtContactNo.Text = txtEmail.Text = txtGuestName.Text = txtPinCode.Text = "";
            rtfAddress.Text = rtfReasonOfEnquiry.Text = "";
            cmbbxCountry.SelectedIndex = cmbbxState.SelectedIndex = cmbbxCity.SelectedIndex = 0;
            rdbbtnMale.Checked = rdbbtnFemale.Checked = false;
        }

        private void txtContactNo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtContactNo_Validating(object sender, CancelEventArgs e)
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

        private void txtPinCode_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPinCode.Text))
            {
                if (txtPinCode.Text.Length != 6)
                {
                    MessageBox.Show("Please enter 6 digits for the Pinocde.");
                    e.Cancel = true;
                }
            }
        }

        private void txtPinCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Please enter Digits..");
            }
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            if (txtContactNo.Text.Length > 10)
            {
                MessageBox.Show("Contact No. cannot exceed 10 digits.");
                txtContactNo.Text = txtContactNo.Text.Substring(0, 10);
                txtContactNo.SelectionStart = txtContactNo.Text.Length;
                txtContactNo.SelectionLength = 0;
            }
        }

        private void txtPinCode_TextChanged(object sender, EventArgs e)
        {
            if (txtPinCode.Text.Length > 6)
            {
                MessageBox.Show("pinocde. cannot exceed 6 digits.");
                txtPinCode.Text = txtPinCode.Text.Substring(0, 6);
                txtPinCode.SelectionStart = txtPinCode.Text.Length;
                txtPinCode.SelectionLength = 0;
            }
        }

        private void txtGuestName_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtGuestName.Text, @"\d"))
            {
                MessageBox.Show("Guest Name cannot contain digits.");
                if (txtGuestName.Text.Length > 0)
                {
                    txtGuestName.Text = txtGuestName.Text.Remove(txtGuestName.Text.Length - 1);
                    txtGuestName.SelectionStart = txtGuestName.Text.Length;
                }
            }
        }

        private void rtfAddress_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(rtfAddress.Text, @"\d"))
            {
                MessageBox.Show("Address cannot contain digits.");
                if (rtfAddress.Text.Length > 0)
                {
                    rtfAddress.Text = rtfAddress.Text.Remove(rtfAddress.Text.Length - 1);
                    rtfAddress.SelectionStart = rtfAddress.Text.Length;
                }
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
