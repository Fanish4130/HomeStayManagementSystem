using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Guna.UI2.Native.WinApi;
using System.IO;

namespace GSTHMS
{
    public partial class frmAgentDetails : Form
    {
        //Image maleimg = Properties.Resources.Profile_Photo;
        //Image femaleimg = Properties.Resources.Prifile_Photo_Women;
        public string AgentNameSJ;
        public string AgentCodeSJ;

        public frmAgentDetails(string agentName)
        {
            InitializeComponent();
            AgentNameSJ = agentName;
            // AgentCode = agent;
        }
        private void frmAgentDetails_Load(object sender, EventArgs e)
        {
            try
            {
                GetInfoSJ();
                frmAgent frmAgent = new frmAgent();
                frmAgent.LoadDocumentsSJ();
                //clsUser obj = new clsUser();
                GetDetailsSJ();

                string ImagePath = @"C:\HMSDocuments\aadhar.jpeg";
                if (!string.IsNullOrEmpty(ImagePath) && File.Exists(ImagePath))
                {
                    pctImage.Image = Image.FromFile("C:\\HMSDocuments\\aadhar.jpeg");
                    pctImage.SizeMode = PictureBoxSizeMode.StretchImage;
                }
                else
                {
                    MessageBox.Show("Image not found at:" + "C:\\HMSDocuments\\aadhar.jpeg");
                }

                // ================= Gender Image =================
                string gender = lblGender1.Text.Trim();

                if (gender.Equals("Male", StringComparison.OrdinalIgnoreCase))
                {
                    string malePath = @"C:\HMSDocuments\male.jpg";

                    if (File.Exists(malePath))
                    {
                        pctUploadPhoto.Image = Image.FromFile(malePath);
                        pctUploadPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Male image not found at: " + malePath);
                    }
                }
                else
                {
                    string femalePath = @"C:\HMSDocuments\female.jpg";

                    if (File.Exists(femalePath))
                    {
                        pctUploadPhoto.Image = Image.FromFile(femalePath);
                        pctUploadPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    }
                    else
                    {
                        MessageBox.Show("Female image not found at: " + femalePath);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error while loading information or images: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        public void GetInfoSJ()
        {
            try  
            {
                clsUser obj = new clsUser();
                obj.AgentNameSJ = AgentNameSJ;
                DataTable dt5 = obj.FetchAgentDetailsSJ();

                if (dt5.Rows.Count > 0)
                {
                    lblName.Text = dt5.Rows[0]["AgentName"].ToString();
                    lblEmail.Text = dt5.Rows[0]["EmailID"].ToString();
                    lblGender1.Text = dt5.Rows[0]["Gender"].ToString();
                    lblCNo.Text = dt5.Rows[0]["ContactNo"].ToString();
                    lblCountry1.Text = dt5.Rows[0]["CountryName"].ToString();
                    lblState1.Text = dt5.Rows[0]["StateName"].ToString();
                    lblCity1.Text = dt5.Rows[0]["CityName"].ToString();
                    lblPincode1.Text = dt5.Rows[0]["Pincode"].ToString();
                    lblAddress1.Text = dt5.Rows[0]["Address"].ToString();
                    lblJoinDate1.Text = dt5.Rows[0]["JoinDate"].ToString();
                    //lblCommission1.Text = dt5.Rows[0]["Commission_Rs"].ToString();
                    //lblBankName1.Text = dt5.Rows[0]["BankName"].ToString();
                    //lblBranchName1.Text = dt5.Rows[0]["BranchName"].ToString();
                    //lblAccountNo1.Text = dt5.Rows[0]["AccountNo"].ToString();
                    //lblAccountType1.Text = dt5.Rows[0]["AccountType"].ToString();
                    //lblIFSC.Text = dt5.Rows[0]["IFSCCode"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching agent details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void GetDetailsSJ()
        {
            try
            {
                clsUser obj1 = new clsUser();
                obj1.AgentNameSJ = AgentNameSJ;
                DataTable dt7 = obj1.DisplaySubTypeNameSJ();

                if (dt7.Rows.Count > 0)
                {
                    lblType1.Text = dt7.Rows[0]["TypeName"].ToString();
                    lblSubType1.Text = dt7.Rows[0]["SubTypeName"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching subtype details: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
