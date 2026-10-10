using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
   
    public partial class frmViewFeedback : Form
    {

        string GuestCodePSS;
        public frmViewFeedback( String code)
        {
            InitializeComponent();

            GuestCodePSS = code;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public void GetInfoSC()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestCodePSS = GuestCodePSS;

                DataTable dt5 = obj.ViewGuestDetailsPSS();

                if (dt5.Rows.Count > 0)
                {
                    lblName.Text = dt5.Rows[0]["Guest Name"].ToString();

                    rtgRoom.Value = float.Parse(dt5.Rows[0]["Room"].ToString());
                    rtgFood.Value = float.Parse(dt5.Rows[0]["Food"].ToString());
                    rtgParking.Value = float.Parse(dt5.Rows[0]["Parking"].ToString());
                    rtgEvent.Value = float.Parse(dt5.Rows[0]["Event"].ToString());
                    rtgInventory.Value = float.Parse(dt5.Rows[0]["Inventory"].ToString());

                    lblDate.Text = Convert.ToDateTime(dt5.Rows[0]["Feedback Date"]).ToString("dd-MM-yyyy");

                    rtgOverallRating.Value = float.Parse(dt5.Rows[0]["Overall Rating"].ToString());

                    rtbDescription.Text = dt5.Rows[0]["Description"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void ViewFeedback_Load(object sender, EventArgs e)
        {
           

            GetInfoSC();




        }

        private void frmViewFeedback_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = false;
        }

        private void rtfDescriptionfeedback_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblDescription_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
