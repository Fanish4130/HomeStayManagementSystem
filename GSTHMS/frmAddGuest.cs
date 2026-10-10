using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace GSTHMS
{
    public partial class frmAddGuest : Form
    {
        public string UserCodeSC { get; set; }
        string filePathDocument;
        string filePathPSC;
        string GuestCodeSC;

        public frmAddGuest()
        {
            InitializeComponent();
        }

        // ── Form Load ──────────────────────────────────────────────────────────────

        private void frmAddGuest_Load(object sender, EventArgs e)
        {
            try
            {
                dtpRegistrationDateVM.Value = DateTime.Now;
                UserCodeSC = "RCPT001";

                clsUser obj = new clsUser();
                DataTable dt;

                // ── Country ────────────────────────────────────────────────────────
                dt = obj.FetchCountrySC();
                DataRow drCountry = dt.NewRow();
                drCountry["CountryName"] = "Select Country";
                drCountry["CountryID"] = 0;
                dt.Rows.InsertAt(drCountry, 0);
                cmbbxCountryVM.DisplayMember = "CountryName";
                cmbbxCountryVM.ValueMember = "CountryID";
                cmbbxCountryVM.DataSource = dt;
                cmbbxCountryVM.SelectedIndex = 0;

                // ── State (Placeholder) ────────────────────────────────────────────
                DataTable dtState = new DataTable();
                dtState.Columns.Add("StateID");
                dtState.Columns.Add("StateName");
                DataRow drState = dtState.NewRow();
                drState["StateID"] = 0;
                drState["StateName"] = "Select State";
                dtState.Rows.Add(drState);
                cmbbxStateVM.DisplayMember = "StateName";
                cmbbxStateVM.ValueMember = "StateID";
                cmbbxStateVM.DataSource = dtState;
                cmbbxStateVM.SelectedIndex = 0;

                // ── City (Placeholder) ─────────────────────────────────────────────
                DataTable dtCity = new DataTable();
                dtCity.Columns.Add("CityID");
                dtCity.Columns.Add("CityName");
                DataRow drCity = dtCity.NewRow();
                drCity["CityID"] = 0;
                drCity["CityName"] = "Select City";
                dtCity.Rows.Add(drCity);
                cmbbxCityVM.DisplayMember = "CityName";
                cmbbxCityVM.ValueMember = "CityID";
                cmbbxCityVM.DataSource = dtCity;
                cmbbxCityVM.SelectedIndex = 0;

                // ── Document Type ──────────────────────────────────────────────────
                dt = obj.FetchSubDocSC();
                DataRow drDoc = dt.NewRow();
                drDoc["SubTypeName"] = "Select Document";
                drDoc["SubTypeID"] = 0;
                dt.Rows.InsertAt(drDoc, 0);
                cmbbxSelectDocVM.DisplayMember = "SubTypeName";
                cmbbxSelectDocVM.ValueMember = "SubTypeID";
                cmbbxSelectDocVM.DataSource = dt;
                cmbbxSelectDocVM.SelectedIndex = 0;

                // ── Gender ─────────────────────────────────────────────────────────
                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Cascade Dropdowns ──────────────────────────────────────────────────────

        private void cmbbxCountryVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int cntryID = Convert.ToInt32(cmbbxCountryVM.SelectedValue);
                if (cntryID == 0) return;

                clsUser obj = new clsUser();
                obj.CntryIDSC = cntryID;
                DataTable dt = obj.FetchStateSC();

                DataRow dr = dt.NewRow();
                dr["StateName"] = "Select State";
                dr["StateID"] = 0;
                dt.Rows.InsertAt(dr, 0);

                cmbbxStateVM.DisplayMember = "StateName";
                cmbbxStateVM.ValueMember = "StateID";
                cmbbxStateVM.DataSource = dt;
                cmbbxStateVM.SelectedIndex = 0;
            }
            catch { }
        }

        private void cmbbxStateVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int stateID = Convert.ToInt32(cmbbxStateVM.SelectedValue);
                if (stateID == 0) return;

                clsUser obj = new clsUser();
                obj.StateIDSC = stateID;
                DataTable dt = obj.FetchCitySC();

                DataRow dr = dt.NewRow();
                dr["CityName"] = "Select City";
                dr["CityID"] = 0;
                dt.Rows.InsertAt(dr, 0);

                cmbbxCityVM.DisplayMember = "CityName";
                cmbbxCityVM.ValueMember = "CityID";
                cmbbxCityVM.DataSource = dt;
                cmbbxCityVM.SelectedIndex = 0;
            }
            catch { }
        }

        // ── Validation Helper ──────────────────────────────────────────────────────

        /// <summary>
        /// Runs all field validations in order.
        /// Returns false and shows the first error message if any validation fails.
        /// </summary>
        private bool ValidateAllFields()
        {
            // 1. Guest Name
            if (string.IsNullOrWhiteSpace(txtGuestNameVM.Text))
            {
                MessageBox.Show("Please enter Guest Name.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestNameVM.Focus();
                return false;
            }

            if (txtGuestNameVM.Text.Trim().Length < 2)
            {
                MessageBox.Show("Guest Name must be at least 2 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGuestNameVM.Focus();
                return false;
            }

            // 2. Contact Number
            if (string.IsNullOrWhiteSpace(txtContactVM.Text))
            {
                MessageBox.Show("Please enter Contact Number.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactVM.Focus();
                return false;
            }

            if (txtContactVM.Text.Length != 10)
            {
                MessageBox.Show("Contact Number must be exactly 10 digits.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactVM.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtContactVM.Text, @"^[6-9]\d{9}$"))
            {
                MessageBox.Show("Please enter a valid Indian mobile number (starting with 6–9).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactVM.Focus();
                return false;
            }

            // 3. Email (required + format check)
            if (string.IsNullOrWhiteSpace(txtEmailVM.Text))
            {
                MessageBox.Show("Please enter Email Address.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailVM.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtEmailVM.Text.Trim(),
                @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$",
                RegexOptions.IgnoreCase))
            {
                MessageBox.Show("Please enter a valid Email Address (e.g. abc@gmail.com).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmailVM.Focus();
                return false;
            }

            // 4. Address
            if (string.IsNullOrWhiteSpace(rtfAddressVM.Text))
            {
                MessageBox.Show("Please enter Address.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtfAddressVM.Focus();
                return false;
            }

            if (rtfAddressVM.Text.Trim().Length < 5)
            {
                MessageBox.Show("Address must be at least 5 characters.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                rtfAddressVM.Focus();
                return false;
            }

            // 5. PIN Code
            if (string.IsNullOrWhiteSpace(txtPINCodeVM.Text))
            {
                MessageBox.Show("Please enter PIN Code.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPINCodeVM.Focus();
                return false;
            }

            if (txtPINCodeVM.Text.Length != 6)
            {
                MessageBox.Show("PIN Code must be exactly 6 digits.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPINCodeVM.Focus();
                return false;
            }

            if (!Regex.IsMatch(txtPINCodeVM.Text, @"^[1-9]\d{5}$"))
            {
                MessageBox.Show("Please enter a valid PIN Code (cannot start with 0).", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPINCodeVM.Focus();
                return false;
            }

            // 6. Country
            if (Convert.ToInt32(cmbbxCountryVM.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a Country.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxCountryVM.Focus();
                return false;
            }

            // 7. State
            if (Convert.ToInt32(cmbbxStateVM.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a State.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxStateVM.Focus();
                return false;
            }

            // 8. City
            if (Convert.ToInt32(cmbbxCityVM.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a City.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxCityVM.Focus();
                return false;
            }

            // 9. Gender
            if (!rdbtnMale.Checked && !rdbtnFemale.Checked)
            {
                MessageBox.Show("Please select Gender.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 10. Document Type
            if (Convert.ToInt32(cmbbxSelectDocVM.SelectedValue) == 0)
            {
                MessageBox.Show("Please select a Document Type.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxSelectDocVM.Focus();
                return false;
            }

            // 11. Document File
            if (string.IsNullOrEmpty(filePathDocument))
            {
                MessageBox.Show("Please upload a Document.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 12. Guest Photo
            if (string.IsNullOrEmpty(filePathPSC))
            {
                MessageBox.Show("Please upload a Guest Photo.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // 13. Registration Date (must not be a future date)
            if (dtpRegistrationDateVM.Value.Date > DateTime.Today)
            {
                MessageBox.Show("Registration Date cannot be a future date.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpRegistrationDateVM.Focus();
                return false;
            }

            return true;
        }

        // ── Save Button ────────────────────────────────────────────────────────────

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateAllFields()) return;

                int cid = Convert.ToInt32(cmbbxCityVM.SelectedValue);

                clsUser obj = new clsUser();
                obj.NameSC = txtGuestNameVM.Text.Trim();
                obj.EmailSC = txtEmailVM.Text.Trim();
                obj.MobNoSC = txtContactVM.Text.Trim();
                obj.GenderSC = rdbtnMale.Checked ? 1 : 2;
                obj.CAddSC = rtfAddressVM.Text.Trim();
                obj.PinCodeSC = Convert.ToInt32(txtPINCodeVM.Text.Trim());
                obj.CityIDSC = cid;
                obj.JoinDateSC = dtpRegistrationDateVM.Value;
                obj.SelectedDocumentsSC = cmbbxSelectDocVM.Text;
                obj.UserCodeSC = UserCodeSC;

                obj.SaveGuestDetailsSC();

                string newGuestCode = obj.DocGuestCode();
                obj.PersonCodeSC = newGuestCode;

                if (!string.IsNullOrEmpty(filePathDocument))
                {
                    obj.SubTypeIdSC = Convert.ToInt32(cmbbxSelectDocVM.SelectedValue);
                    obj.filePathSC = filePathDocument;
                    obj.UploadDocumentSC();
                }

                obj.filePathPSC = filePathPSC;
                obj.UploadPhotoSC();

                MessageBox.Show("Guest Added Successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();

                if (Application.OpenForms["frmGuest"] != null)
                {
                    frmGuest frm = (frmGuest)Application.OpenForms["frmGuest"];
                    frm.LoadGridSC();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Clear Button ───────────────────────────────────────────────────────────

        private void btnClearVM_Click(object sender, EventArgs e)
        {
            try
            {
                txtGuestNameVM.Text = "";
                txtEmailVM.Text = "";
                txtContactVM.Text = "";
                rtfAddressVM.Text = "";
                txtPINCodeVM.Text = "";
                filePathDocument = "";
                filePathPSC = "";
                lblshowpath.Text = "";
                lblphoto.Text = "";

                cmbbxCountryVM.SelectedIndex = 0;
                cmbbxStateVM.SelectedIndex = 0;
                cmbbxCityVM.SelectedIndex = 0;
                cmbbxSelectDocVM.SelectedIndex = 0;

                rdbtnMale.Checked = false;
                rdbtnFemale.Checked = false;

                dtpRegistrationDateVM.Value = DateTime.Now;
            }
            catch { }
        }

        // ── KeyPress Handlers ──────────────────────────────────────────────────────

        private void txtGuestNameVM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only letters are allowed in Guest Name.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtContactVM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed in Contact No.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContactVM.Text.Length >= 10 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Contact No. must be exactly 10 digits.", "Limit Exceeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtPINCodeVM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Only numbers are allowed in PIN Code.", "Invalid Input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPINCodeVM.Text.Length >= 6 && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("PIN Code must be exactly 6 digits.", "Limit Exceeded",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ── File Upload Handlers ───────────────────────────────────────────────────

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Document (Image)";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName).ToLower();
                    if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".bmp")
                    {
                        MessageBox.Show("Only image files are allowed! (jpg, jpeg, png, bmp)",
                            "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    filePathDocument = ofd.FileName;
                    lblshowpath.Text = Path.GetFileName(filePathDocument);
                    MessageBox.Show("Document Selected Successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Document Upload Failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Guest Photo";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string ext = Path.GetExtension(ofd.FileName).ToLower();
                    if (ext != ".jpg" && ext != ".jpeg" && ext != ".png" && ext != ".bmp")
                    {
                        MessageBox.Show("Only image files are allowed! (jpg, jpeg, png, bmp)",
                            "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    filePathPSC = ofd.FileName;
                    lblphoto.Text = Path.GetFileName(filePathPSC);
                    MessageBox.Show("Photo Selected Successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("File Upload Failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Close Button ───────────────────────────────────────────────────────────

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ── Unused stubs ───────────────────────────────────────────────────────────

        private void cmbbxSelectDocVM_SelectedIndexChanged(object sender, EventArgs e) { }
        private void guna2ContainerControl1_Click(object sender, EventArgs e) { }
        private void guna2ContainerControl2_Click(object sender, EventArgs e) { }
        private void txtContactVM_TextChanged(object sender, EventArgs e) { }
        private void txtPINCodeVM_TextChanged(object sender, EventArgs e) { }
        private void rdbtmMale_CheckedChanged(object sender, EventArgs e) { }
        private void lblphoto_Click(object sender, EventArgs e) { }
    }
}