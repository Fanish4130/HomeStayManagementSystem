using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmViewFood : Form
    {
        public string MenuTypeSRM;
        public string MenuNameSRM;
        public decimal PriceSRM;
        public string DescriptionSRM;
        public string FoodImageSRM;
        public frmFoodService ParentFoodServiceForm;

        public frmViewFood()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }

        private void frmViewFood_Load(object sender, EventArgs e)
        {
            lblMenutype.Text = MenuTypeSRM;
            lblMenuname.Text = MenuNameSRM;
            lblmenuprice.Text = string.Format("₹{0:N2}", PriceSRM);
            lbldiscription.AutoSize = false;
            lbldiscription.Size = new Size(360, 50);
            lbldiscription.MaximumSize = new Size(360, 50);
            lbldiscription.TextAlign = ContentAlignment.TopLeft;
            lbldiscription.ForeColor = Color.Gray;
            lbldiscription.Text = DescriptionSRM;

            LoadFoodImage();
        }

        private void LoadFoodImage()
        {
            pctimage.Image = null;
            pctimage.SizeMode = PictureBoxSizeMode.StretchImage;

            if (string.IsNullOrWhiteSpace(FoodImageSRM))
            {
                return;
            }

            string imagePath = FoodImageSRM;

            // If path is relative like Images/Manchurian.jpg
            if (!Path.IsPathRooted(imagePath))
            {
                imagePath = Path.Combine(Application.StartupPath, imagePath);
            }

            if (File.Exists(imagePath))
            {
                using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    pctimage.Image = Image.FromStream(fs);
                }
            }
            else
            {
                // MessageBox nahi dakhvaycha, blank image rahu de
                pctimage.Image = null;
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctimage_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnOrderFood_Click(object sender, EventArgs e)
        {
           
        }
    }
}