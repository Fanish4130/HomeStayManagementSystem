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

namespace GSTHMS
{
    public partial class frmProfileSettingView : Form
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

        public frmProfileSettingView()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmProfileSettingView_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                rtfPerAddVM.ReadOnly = true;
                rtfCurrAddVM.ReadOnly = true;

                dtpBirthDateVM.FillColor = Color.White;
                dtpBirthDateVM.ForeColor = Color.Black;
                dtpBirthDateVM.Enabled = false;

                dtpJoinDateVM.FillColor = Color.White;
                dtpJoinDateVM.ForeColor = Color.Black;
                dtpJoinDateVM.Enabled = false;

                if (string.IsNullOrEmpty(LoggedUserCodeVM))
                {
                    MessageBox.Show("User ID not found!");
                    return;
                }

                clsUser obj = new clsUser();
                obj.UserCodeVM = LoggedUserCodeVM;

                DataTable dt = obj.FetchProfileVM();

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

                    // Fetch Bank Details separately
                    obj.FetchBankDetailsVM();

                    lblBankNameVM.Text = obj.BankVM;
                    lblBranchNameVM.Text = obj.BranchVM;
                    lblAccountTypeVM.Text = obj.AccountTypeVM;
                    lblAccountNoVM.Text = obj.AccountNoVM;
                    lblIFSCVM.Text = obj.IFSCCodeVM;
                    lblUpiIdVm.Text = obj.UpiIDVM;
                    lblERC.Text = obj.RecpCodeVM;

                    // Load document image safely
                    string ImagePathVM = @"C:\HMSDocuments\aadhar.jpeg";
                    if (!string.IsNullOrEmpty(ImagePathVM) && File.Exists(ImagePathVM))
                    {
                        pctUploadDocVM.Image = Image.FromFile(ImagePathVM);
                        pctUploadDocVM.SizeMode = PictureBoxSizeMode.StretchImage;
                    }

                    // Load profile image safely
                    clsUser u = new clsUser();
                    u.UserCodeVM = LoggedUserCodeVM;

                    string path = u.GetProfileImagePathVM();

                    if (!string.IsNullOrEmpty(path) && File.Exists(path))
                    {
                        using (var img = Image.FromFile(path))
                        {
                            pctUploadImgVM.Image = new Bitmap(img);
                        }
                        pctUploadImgVM.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Profile image not found!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading profile: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RefreshProfileImageVM()
        {
            try
            {
                clsUser u = new clsUser();
                u.UserCodeVM = LoggedUserCodeVM;

                string path = u.GetProfileImagePathVM();

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    if (pctUploadImgVM.Image != null)
                    {
                        pctUploadImgVM.Image.Dispose();
                    }

                    using (var img = Image.FromFile(path))
                    {
                        pctUploadImgVM.Image = new Bitmap(img);
                    }

                    pctUploadImgVM.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch { }
        }


        private void btnEditProfileVM_Click(object sender, EventArgs e)
        {
            try
            {
                frmProfileSettingEdit frm = new frmProfileSettingEdit();

                frm.LoggedUserCodeVM = this.LoggedUserCodeVM;

                frm.ProfileImageUpdated += Frm_ProfileImageUpdated;

                frm.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening edit profile: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Frm_ProfileImageUpdated(string imagePath)
        {
            RefreshProfileImageVM();
        }


        private void pctBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while closing form: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connViewProfileVM_Click(object sender, EventArgs e)
        {
            try
            {
                // Future logic for connection view
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in connViewProfileVM: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connMainVM_Resize(object sender, EventArgs e)
        {
            connViewProfileVM.Left = (this.ClientSize.Width - connViewProfileVM.Width) / 2;
            connViewProfileVM.Top = (this.ClientSize.Height - connViewProfileVM.Height) / 2;
        }

        private void btnChangePasswordVM_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword(LoggedUserCodeVM);
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void connMainVM_Click(object sender, EventArgs e)
        {

        }
    }
}