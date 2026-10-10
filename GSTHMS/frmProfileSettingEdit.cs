//using HMSLibrary;
using demosidebar;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.SessionState;
using System.Windows.Forms;
using System.Xml.Linq;


namespace GSTHMS
{
   
    public partial class frmProfileSettingEdit : Form
    {
        public int IdVM;
        public string NameVM;
        public string EmailVM;
        public string MobNoVM;
        public string GenderVM;
        public string EducationVM;
        public string PinCodeVM;
        public string BirthDateVM;
        public string AgeVM;
        public string JoinDateVM;
        public string PositionVM;
        public string PAddressVM;
        public string CAddressVM;
        public string AccountNoVM;
        public string AccountTypeVM;
        public string BankVM;
        public string BranchVM;
        public string IFSCCodeVM;
        public string UpiIDVM;
        public string RecpCodeVM;
        public string imageVM;
        public string filePathVM;
        public string LoggedUserCodeVM { get; set; }
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmProfileSettingEdit()
        {
            InitializeComponent();
            errorProvider1.ContainerControl = this;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        Timer autoCloseTimer = new Timer();


        public delegate void ProfileImageUpdatedHandler(string imagePath);
        public event ProfileImageUpdatedHandler ProfileImageUpdated;


        private void frmProfileSetting_Load(object sender, EventArgs e)
        {
            cmbbxBankVM.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbbxBranchNameVM.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                // Open form in full screen only if not already maximized
                if (this.WindowState != FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Maximized;
                }
                pctUploadIDProofVM.Visible = false;

                clsUser obj = new clsUser();
                DataTable dt = new DataTable();
                dt = obj.FetchBankNameVM();
                cmbbxBankVM.DisplayMember = "BankName";
                cmbbxBankVM.ValueMember = "BankInfoID";
                cmbbxBankVM.DataSource = dt;

                // Read-only address fields
                rtfPerAddVM.ReadOnly = true;
                rtfCurrAddVM.ReadOnly = true;

                // Hide account number
                txtAccountNoVM.UseSystemPasswordChar = true;

                // Birth Date Picker
                dtpBirthDateVM.FillColor = Color.White;
                dtpBirthDateVM.ForeColor = Color.Black;
                dtpBirthDateVM.Enabled = false;

                // Join Date Picker
                dtpJoinDateVM.FillColor = Color.White;
                dtpJoinDateVM.ForeColor = Color.Black;
                dtpJoinDateVM.Enabled = false;

                // Auto close timer (prevent multiple event attach)
                autoCloseTimer.Tick -= AutoCloseTimer_Tick; // important
                autoCloseTimer.Tick += AutoCloseTimer_Tick;
                autoCloseTimer.Start();

                if (string.IsNullOrEmpty(LoggedUserCodeVM))
                {
                    MessageBox.Show("User ID not found!");
                    return;
                }

                obj.UserCodeVM = LoggedUserCodeVM;
                dt = obj.FetchProfileVM();

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblRNameVM.Text = row["FullName"].ToString();
                    lblREmailVM.Text = row["Email"].ToString();
                    lblRMobNoVM.Text = row["Mobile"].ToString();
                    lblRGenderVM.Text = row["Gender"].ToString();
                    lblRPositionVM.Text = row["Position"].ToString();
                    lblREducationVM.Text = row["Education"].ToString();
                    rtfCurrAddVM.Text = row["CurrentAddress"].ToString();
                    rtfPerAddVM.Text = row["PermanentAddress"].ToString();
                    lblRCountry.Text = row["Country"].ToString();
                    lblRState.Text = row["State"].ToString();
                    lblRCity.Text = row["City"].ToString();
                    lblRPinCode.Text = Convert.ToInt32(row["PinCode"]).ToString();
                    lblRSelectedDocVM.Text = row["SubTypeName"].ToString();
                    dtpBirthDateVM.Value = Convert.ToDateTime(row["BirthDate"]);
                    dtpJoinDateVM.Value = Convert.ToDateTime(row["JoinDate"]);

                    LoadProfileImageVM();



                    // Fetch Bank Details separately
                    obj.FetchBankDetailsVM();

                    cmbbxBankVM.Text = obj.BankVM;
                    cmbbxBranchNameVM.Text = obj.BranchVM;
                    txtAccountTypeVM.Text = obj.AccountTypeVM;
                    txtAccountNoVM.Text = obj.AccountNoVM;
                    txtIFSCVM.Text = obj.IFSCCodeVM;
                    txtUpiIdVM.Text = obj.UpiIDVM;
                    lblERC.Text = obj.RecpCodeVM;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading profile: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                clsUser objVM = new clsUser();
                objVM.UserCodeVM = LoggedUserCodeVM;

                if (string.IsNullOrEmpty(objVM.UserCodeVM))
                {
                    MessageBox.Show("Receptionist not found.");
                    return;
                }

                if (!ValidateBankDetailsVM())
                    return;

                // ✅ Use SelectedValue safely
                if (cmbbxBankVM.SelectedItem is DataRowView bankRow)
                    objVM.BankIDVM = Convert.ToInt32(bankRow["BankInfoID"]);

                if (cmbbxBranchNameVM.SelectedItem is DataRowView branchRow)
                    objVM.BranchIDVM = Convert.ToInt32(branchRow["BranchID"]);

                objVM.AccountTypeVM = txtAccountTypeVM.Text;
                objVM.AccountNoVM = txtAccountNoVM.Text;
                objVM.IFSCCodeVM = txtIFSCVM.Text;
                objVM.UpiIDVM = txtUpiIdVM.Text;

                bool resultVM = objVM.UpdateBankDetailsVM();

                MessageBox.Show(resultVM ? "Bank details updated successfully."
                                         : "Bank details updated successfully...!",
                                "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultVM)
                    this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating bank details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateBankDetailsVM()
        {
            // ------------------- Bank Name -------------------
            if (string.IsNullOrWhiteSpace(cmbbxBankVM.Text))
            {
                MessageBox.Show("Please Select Bank Name");
                cmbbxBankVM.Focus();
                return false;
            }


            //// ------------------- Branch Name -------------------
            if (string.IsNullOrWhiteSpace(cmbbxBranchNameVM.Text))
            {
                MessageBox.Show("Branch Name is required.");
                cmbbxBranchNameVM.Focus();
                return false;
            }

            // ------------------- UPI ID -------------------
            // Basic UPI format: name@bank
            if (string.IsNullOrWhiteSpace(txtUpiIdVM.Text) ||
                !Regex.IsMatch(txtUpiIdVM.Text, @"^[\w\.\-]{2,}@[\w]{2,}$"))
            {
                MessageBox.Show("Enter a valid UPI ID (Example: username@bank).");
                txtUpiIdVM.Focus();
                return false;
            }

            // ------------------- Account Type -------------------
            string accType = txtAccountTypeVM.Text.Trim().ToLower();
            if (!(accType == "saving" || accType == "current" || accType == "savings"))
            {
                MessageBox.Show("Account Type must be: Saving OR Current.");
                txtAccountTypeVM.Focus();
                return false;
            }

            // ------------------- Account Number -------------------
            if (!Regex.IsMatch(txtAccountNoVM.Text, @"^[0-9]{9,18}$"))
            {
                MessageBox.Show("Enter a valid Account Number (9 to 18 digits).");
                txtAccountNoVM.Focus();
                return false;
            }
            return true; // All validations passed
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxBankVM.SelectedIndex = -1;
            cmbbxBranchNameVM.SelectedIndex = -1;
            txtUpiIdVM.Text = "";
            txtAccountTypeVM.Text = "";
            txtAccountNoVM.Text = "";
            txtIFSCVM.Text = "";
            //this.Close();
        }
        private void btnUploadDoc_Click(object sender, EventArgs e)
        {
            string imagePathVM = @"C:\HMSDocuments\aadhar.jpeg";  

            // If PictureBox is currently hidden, load and show the image
            if (!pctUploadIDProofVM.Visible)
            {
                if (File.Exists(imagePathVM))
                {
                    pctUploadIDProofVM.Image = Image.FromFile(imagePathVM);
                    pctUploadIDProofVM.SizeMode = PictureBoxSizeMode.StretchImage;
                    pctUploadIDProofVM.Visible = true;
                }
                else
                {
                    MessageBox.Show("Image file not found at: " + imagePathVM);
                }
            }
            else
            {
                // If PictureBox is already visible, hide it
                pctUploadIDProofVM.Visible = false;
            }

        }
        private void AutoCloseTimer_Tick(object sender, EventArgs e)
        {
            //autoCloseTimer.Stop();
            //this.Close(); 
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {

            if (txtAccountNoVM.UseSystemPasswordChar)
            {
                // Currently hidden → show text
                txtAccountNoVM.UseSystemPasswordChar = false;
            }
            else
            {
                // Currently visible → hide text
                txtAccountNoVM.UseSystemPasswordChar = true;
            }
        }

        private void btnUploadImg_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() != DialogResult.OK) return;

                string selectedPath = ofd.FileName;

                if (pctUploadImgVM.Image != null)
                {
                    pctUploadImgVM.Image.Dispose();
                    pctUploadImgVM.Image = null;
                }

                using (FileStream fs = new FileStream(selectedPath, FileMode.Open, FileAccess.Read))
                {
                    Image img = Image.FromStream(fs);

                    pctUploadImgVM.Image = new Bitmap(img);
                }

                pctUploadImgVM.SizeMode = PictureBoxSizeMode.StretchImage;

                clsUser u = new clsUser();
                u.UserCodeVM = LoggedUserCodeVM;
                u.filePathVM = selectedPath;

                bool ok = u.UploadProfileImageVM();

                if (ok)
                {
                    LoadProfileImageVM();

                    frmUIDesign dashboard =
                        Application.OpenForms.OfType<frmUIDesign>().FirstOrDefault();

                    if (dashboard != null)
                    {
                        dashboard.LoadProfileIconVM();
                    }

                    frmProfileSettingView view =
                        Application.OpenForms.OfType<frmProfileSettingView>().FirstOrDefault();

                    if (view != null)
                    {
                        view.RefreshProfileImageVM();
                    }
                }


                else
                {
                    MessageBox.Show("Upload failed!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void LoadProfileImageVM()
        {
            try
            {
                clsUser u = new clsUser();

                u.UserCodeVM = LoggedUserCodeVM;

                string path = u.GetProfileImagePathVM();

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    // Dispose old image first
                    if (pctUploadImgVM.Image != null)
                    {
                        pctUploadImgVM.Image.Dispose();
                        pctUploadImgVM.Image = null;
                    }

                    byte[] imgBytes = File.ReadAllBytes(path);

                    using (MemoryStream ms = new MemoryStream(imgBytes))
                    {
                        pctUploadImgVM.Image = Image.FromStream(ms);
                    }

                    pctUploadImgVM.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    pctUploadImgVM.Image = null;
                    MessageBox.Show("Image path not found in database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
        private void pnlProfileVM_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblERC_Click(object sender, EventArgs e)
        {

        }

        private void pctBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxBranchNameVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxBranchNameVM.SelectedItem is DataRowView drv)
            {
                int branchID = Convert.ToInt32(drv["BranchID"]);

                clsUser obj = new clsUser();
                obj.BranchIDVM = branchID;
                obj.FetchBranchDetailsVM();

                txtIFSCVM.Text = obj.IFSCCodeVM;

                // Clear other fields
                txtAccountNoVM.Clear();
                txtAccountTypeVM.Clear();
                txtUpiIdVM.Clear();
            }
        }

        private void txtAccountNoVM_TextChanged(object sender, EventArgs e)
        {
            if (txtAccountNoVM.Text.Length < 11 || txtAccountNoVM.Text.Length > 15)
            {
                errorProvider1.SetError(txtAccountNoVM, "Account number must be between 11 and 15 digits");
            }
            else
            {
                errorProvider1.SetError(txtAccountNoVM, string.Empty);
            }

        }

        private void txtAccountNoVM_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block non-digit input
            }

        }

        private void txtUpiIdVM_TextChanged(object sender, EventArgs e)
        {
            string upi = txtUpiIdVM.Text;

            // Basic validation: must contain '@'
            if (!upi.Contains("@"))
            {
                errorProvider1.SetError(txtUpiIdVM, "UPI ID must contain '@' (e.g., name@bank)");
                return;
            }

            // Split into two parts
            string[] parts = upi.Split('@');
            if (parts.Length != 2 || string.IsNullOrWhiteSpace(parts[0]) || string.IsNullOrWhiteSpace(parts[1]))
            {
                errorProvider1.SetError(txtUpiIdVM, "Invalid UPI format. Use name@bank");
                return;
            }

            // Check allowed characters before '@'
            if (!System.Text.RegularExpressions.Regex.IsMatch(parts[0], @"^[a-zA-Z0-9._]+$"))
            {
                errorProvider1.SetError(txtUpiIdVM, "Only letters, digits, '.', '_' allowed before '@'");
                return;
            }

            // Check bank handle after '@'
            if (!System.Text.RegularExpressions.Regex.IsMatch(parts[1], @"^[a-zA-Z]+$"))
            {
                errorProvider1.SetError(txtUpiIdVM, "Bank handle must be letters only");
                return;
            }

            // ✅ Passed
            errorProvider1.SetError(txtUpiIdVM, string.Empty);
        }

        private void frmProfileSettingEdit_Resize(object sender, EventArgs e)
        {
            pnlProfileVM.Left = (this.ClientSize.Width - pnlProfileVM.Width) / 2;
            pnlProfileVM.Top = (this.ClientSize.Height - pnlProfileVM.Height) / 2;
        }

        private void cmbbxBankVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = new DataTable();
            obj.BankIDVM = Convert.ToInt32(cmbbxBankVM.SelectedValue);
            dt = obj.FetchBranchNameVM();
            cmbbxBranchNameVM.DisplayMember = "BranchName";
            cmbbxBranchNameVM.ValueMember = "BranchID";
            cmbbxBranchNameVM.DataSource = dt;
        }
    }

}
