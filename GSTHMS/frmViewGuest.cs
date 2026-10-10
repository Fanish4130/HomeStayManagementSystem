using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using Image = System.Drawing.Image;
//using Image = iTextSharp.text.Image;

namespace GSTHMS
{
    public partial class frmViewGuest : Form
    {
        public string GuestNameAP {  get; set; }
        public string EmailAP { get; set; }
       
        public string GenderAP {  get; set; }
        public string CheckIn {  get; set; }

        public string CheckOut {  get; set; }
        public frmViewGuest()
        {
            InitializeComponent();
        }

        private void frmViewGuest_Load(object sender, EventArgs e)
        {
            clsUser obj=new clsUser();
            DataTable dt = obj.GuestAP();

            lblName.Text = GuestNameAP;
            lblEmail.Text = EmailAP;
            lblEnail1.Text = GenderAP;
            lblCheckIn.Text = CheckIn;  
           // lblCheckOut.Text = CheckOut;

            LoadProfilePhoto();



        }
       

        private void LoadProfilePhoto()
        {
            try
            {
                string gender = lblEnail1.Text.Trim().ToLower();

                // Your image folder path
                string malePath = @"C:\Images\Male.jpg";
                string femalePath = @"C:\Images\Female.jpg";

                // ---- Pick image based on gender ----
                if (gender == "male")
                {
                  
                    if (File.Exists(malePath))
                        pctPP.Image = Image.FromFile(malePath);
                }
                else if (gender == "female")
                {
                    if (File.Exists(femalePath))
                        pctPP.Image = Image.FromFile(femalePath);
                }
                else
                {
                    pctPP.Image = null;   // In case of invalid gender
                }

                pctPP.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }


        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
