using System;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmEditGuestDetails : Form
    {
        public string GuestCodeSC;
        clsUser obj = new clsUser();

        string filePathSC;
        public string UserCodeSC { get; set; }
        string filePathDocument;
        string filePathPSC;

        public frmEditGuestDetails(string Code)
        {
            InitializeComponent();
            GuestCodeSC = Code;
        }

        // ── Form load ──────────────────────────────────────────────────────────────

        private void frmEditGuestDetails_Load(object sender, EventArgs e)
        {
            try
            {
                // Document type combo
                DataTable dt = obj.FetchSubDocSC();
                DataRow drDoc = dt.NewRow();
                drDoc["SubTypeName"] = "Select Document";
                drDoc["SubTypeID"] = 0;
                dt.Rows.InsertAt(drDoc, 0);

                cmbbxSelectDocVM.DisplayMember = "SubTypeName";
                cmbbxSelectDocVM.ValueMember = "SubTypeID";
                cmbbxSelectDocVM.DataSource = dt;
                cmbbxSelectDocVM.SelectedIndex = 0;

                LoadSubtypeSC();
                GetInfoSC();
                GetDetailsSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Data loading ───────────────────────────────────────────────────────────

        public void LoadGrid()
        {
            try
            {
                clsUser cls = new clsUser();
                DataTable dt = cls.FetchGuestDetailsSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grid: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetInfoSC()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestCodeSC = GuestCodeSC;
                DataTable dt = obj.ViewGuestDetailsSC();

                if (dt.Rows.Count > 0)
                {
                    lblEGuest.Text = dt.Rows[0]["GuestName"].ToString();
                    txtEmailVM.Text = dt.Rows[0]["Email"].ToString();
                    txtContactVM.Text = dt.Rows[0]["ContactNo"].ToString();
                    lblEpin.Text = dt.Rows[0]["Pincode"].ToString();
                    lblEAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblDate.Text = Convert.ToDateTime(
                        dt.Rows[0]["RegistrationDate"]).ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching guest info: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSubtypeSC()
        {
            try
            {
                DataTable dt = obj.FetchSubDocUSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document subtypes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetDetailsSC()
        {
            try
            {
                clsUser obj1 = new clsUser();
                obj1.GuestCodeSC = GuestCodeSC;
                DataTable dt = obj1.DisplaySubTypeNameSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching guest details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Validation ─────────────────────────────────────────────────────────────

        private bool IsEmailValidSC(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        // ── Update ─────────────────────────────────────────────────────────────────

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                // Email validation
                if (string.IsNullOrWhiteSpace(txtEmailVM.Text))
                {
                    MessageBox.Show("Please enter Email Address.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailVM.Focus();
                    return;
                }

                if (!IsEmailValidSC(txtEmailVM.Text.Trim()))
                {
                    MessageBox.Show("Please enter a valid Email Address.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEmailVM.Focus();
                    return;
                }

                // Contact validation
                if (string.IsNullOrWhiteSpace(txtContactVM.Text))
                {
                    MessageBox.Show("Please enter Contact Number.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactVM.Focus();
                    return;
                }

                if (txtContactVM.Text.Trim().Length != 10)
                {
                    MessageBox.Show("Contact Number must be 10 digits.",
                        "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContactVM.Focus();
                    return;
                }

                if (MessageBox.Show(
                        "Are you sure you want to update guest details?",
                        "Confirm Update",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.No)
                    return;

                clsUser updObj = new clsUser();
                updObj.GuestCodeSC = GuestCodeSC;
                updObj.EmailIDSC = txtEmailVM.Text.Trim();
                updObj.ContactNoSC = Convert.ToInt64(txtContactVM.Text.Trim());

                updObj.UpdateGeustDetailsSC();

                // Update document if one was selected
                if (!string.IsNullOrEmpty(filePathSC))
                {
                    try
                    {
                        updObj.PersonCodeSC = GuestCodeSC;
                        updObj.filePathSC = filePathSC;
                        updObj.SubTypeIdSC = Convert.ToInt32(cmbbxSelectDocVM.SelectedValue);
                        updObj.UpdateDocumentSC();
                    }
                    catch (Exception docEx)
                    {
                        MessageBox.Show("Error updating document: " + docEx.Message,
                            "Document Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                // Upload photo if one was selected
                if (!string.IsNullOrEmpty(filePathPSC))
                {
                    try
                    {
                        updObj.PersonCodeSC = GuestCodeSC;
                        updObj.filePathPSC = filePathPSC;
                        updObj.UpdatePhotoSC();
                    }
                    catch (Exception photoEx)
                    {
                        MessageBox.Show("Error uploading photo: " + photoEx.Message,
                            "Photo Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Guest details updated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Refresh parent grid if open
                if (Application.OpenForms["frmGuest"] != null)
                {
                    try
                    {
                        frmGuest frm = (frmGuest)Application.OpenForms["frmGuest"];
                        frm.LoadGridSC();
                    }
                    catch (Exception refreshEx)
                    {
                        MessageBox.Show("Error refreshing guest list: " + refreshEx.Message,
                            "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating guest details: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Clear ──────────────────────────────────────────────────────────────────

        private void btnClearVM_Click(object sender, EventArgs e)
        {
            try
            {
                txtContactVM.Clear();
                txtEmailVM.Clear();
                TimerClosePSS.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Contact number – key press validation ──────────────────────────────────

        private void txtContactVM_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Only numbers are allowed in Contact No.",
                        "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtContactVM.Text.Length >= 10 && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Contact No. must be exactly 10 digits.",
                        "Limit Exceeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Input validation error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Document upload ────────────────────────────────────────────────────────

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Document";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                string ext = Path.GetExtension(ofd.FileName).ToLower();

                if (ext != ".jpg" && ext != ".jpeg" &&
                    ext != ".png" && ext != ".bmp")
                {
                    MessageBox.Show("Only image files are allowed!",
                        "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                filePathSC = ofd.FileName;
                lblshowpath.Text = Path.GetFileName(filePathSC);

                MessageBox.Show("Document selected successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Document upload failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Photo upload ───────────────────────────────────────────────────────────

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Select Guest Photo";
                ofd.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                string ext = Path.GetExtension(ofd.FileName).ToLower();

                if (ext != ".jpg" && ext != ".jpeg" &&
                    ext != ".png" && ext != ".bmp")
                {
                    MessageBox.Show("Only image files are allowed! (jpg, jpeg, png, bmp)",
                        "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                filePathPSC = ofd.FileName;
                lblphoto.Text = Path.GetFileName(filePathPSC);

                MessageBox.Show("Photo selected successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Photo upload failed: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Close ──────────────────────────────────────────────────────────────────

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Misc unused stubs ──────────────────────────────────────────────────────

        private void lblAddGuestVM_Click(object sender, EventArgs e) { }
        private void cmbbxCountryVM_SelectionChangeCommitted(object sender, EventArgs e) { }
        private void cmbbxStateVM_SelectionChangeCommitted(object sender, EventArgs e) { }
        private void cmbbxCityVM_SelectionChangeCommitted(object sender, EventArgs e) { }
        private void cmbbxGenderVM_SelectionChangeCommitted(object sender, EventArgs e) { }
        private void rtfAddressVM_TextChanged(object sender, EventArgs e) { }
        private void btnUploadGDocVM_Click(object sender, EventArgs e) { }
        private void guna2PictureBox1_Click(object sender, EventArgs e) { }
        private void guna2ContainerControl1_Click(object sender, EventArgs e) { }
        private void guna2ContainerControl2_Click(object sender, EventArgs e) { }
        private void lblDocument_Click(object sender, EventArgs e) { }
    }
}