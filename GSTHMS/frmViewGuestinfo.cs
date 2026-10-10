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
    public partial class frmViewGuestinfo : Form
    {
        public string GuestCodeSC;
        public frmViewGuestinfo(string code)
        {
            InitializeComponent();
            GuestCodeSC = code;
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        public void GetInfoSC()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestCodeSC = GuestCodeSC;
                DataTable dt5 = obj.ViewGuestDetailsSC();

                if (dt5.Rows.Count > 0)
                {
                    lblVName.Text = dt5.Rows[0]["GuestName"].ToString();
                    lblVEmail.Text = dt5.Rows[0]["Email"].ToString();
                    lblVGender.Text = dt5.Rows[0]["Gender"].ToString();
                    lblVContactNo.Text = dt5.Rows[0]["ContactNo"].ToString();
                    lblVCountry.Text = dt5.Rows[0]["CountryName"].ToString();
                    lblVState.Text = dt5.Rows[0]["StateName"].ToString();
                    lblVCity.Text = dt5.Rows[0]["CityName"].ToString();
                    lblVPincode.Text = dt5.Rows[0]["Pincode"].ToString();
                    lblVAddress.Text = dt5.Rows[0]["Address"].ToString();
                    lblVRegisteration.Text = Convert.ToDateTime(dt5.Rows[0]["RegistrationDate"]).ToString("dd-MM-yyyy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading guest info: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetDetailsSC()
        {
            try
            {
                clsUser obj1 = new clsUser();
                obj1.GuestCodeSC = GuestCodeSC;
                DataTable dt7 = obj1.DisplaySubTypeNameSC();

                if (dt7.Rows.Count > 0)
                {
                    string docSubType = dt7.Rows[0]["SubTypeName"]?.ToString();
                    lblVSubtype.Text = string.IsNullOrWhiteSpace(docSubType) ? "N/A" : docSubType;

                    pnlDocument.Visible = true;
                    lblVSubtype.Visible = true;
                    pctGuestDocument.Visible = false;
                }
                else
                {
                    lblVSubtype.Text = "N/A";
                    pnlDocument.Visible = true;
                    pctGuestDocument.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading document details: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ShowDocumentSC()
        {
            try
            {
                clsUser obj1 = new clsUser();
                obj1.GuestCodeSC = GuestCodeSC;
                DataTable dt7 = obj1.DisplaySubTypeNameSC();

                if (dt7.Rows.Count > 0)
                {
                    string docPath = dt7.Rows[0]["Path"]?.ToString();

                    if (!string.IsNullOrEmpty(docPath) && File.Exists(docPath))
                    {
                        pctGuestDocument.Image = Image.FromFile(docPath);
                        pctGuestDocument.SizeMode = PictureBoxSizeMode.StretchImage;
                        pctGuestDocument.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Document file not found.", "Not Found",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying document: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadProfilePhotoSC()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestCodeSC = GuestCodeSC;

                DataTable dtDocs = obj.DisplayPhotoSC();
                string profilePhotoPath = null;

                foreach (DataRow row in dtDocs.Rows)
                {
                    if (row["SubTypeID"] != DBNull.Value && Convert.ToInt32(row["SubTypeID"]) == 12)
                    {
                        profilePhotoPath = row["Path"]?.ToString();
                        break;
                    }
                }

                if (!string.IsNullOrEmpty(profilePhotoPath) && File.Exists(profilePhotoPath))
                    pctProfilePicture.Image = Image.FromFile(profilePhotoPath);
                else
                    SetDefaultProfilePicture();

                pctProfilePicture.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading profile photo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultProfilePicture()
        {
            try
            {
                string gender = lblVGender.Text.Trim();
                string malePath = @"C:\recover data\Images\male.jpg";
                string femalePath = @"C:\recover data\Images\female.jpg";

                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                    pctProfilePicture.Image = File.Exists(malePath)
                        ? Image.FromFile(malePath)
                        : Properties.Resources.MalePicture;
                else
                    pctProfilePicture.Image = File.Exists(femalePath)
                        ? Image.FromFile(femalePath)
                        : Properties.Resources.FemalePicture;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting default profile picture: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmViewGuest_Load(object sender, EventArgs e)
        {
            try
            {
                GetInfoSC();
                LoadProfilePhotoSC();
                GetDetailsSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctProfilePicture_Click(object sender, EventArgs e) { }
        private void lblEmail_Click(object sender, EventArgs e) { }
        private void pctGuestDocument_Click(object sender, EventArgs e) { }

        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnshow_Click(object sender, EventArgs e)
        {
            try
            {
                if (pctGuestDocument.Visible)
                {
                    pctGuestDocument.Visible = false;
                    return;
                }

                ShowDocumentSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling document view: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}