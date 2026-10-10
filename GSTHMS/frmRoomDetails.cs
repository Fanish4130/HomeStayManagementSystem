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
    public partial class frmRoomDetails : Form
    {
        public frmRoomDetails()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }
        public string RoomNameSY {  get; set; }
        public string RoomTypeSY {  get; set; }
        public string BasePriceSY {  get; set; }
        public string CapacitySY {  get; set; }
        public string AmentitiesSY {  get; set; }
        public string DescriptionSY {  get; set; }

        private void frmRoomDetails_Load(object sender, EventArgs e)
        {
            lblRoomName.Text = RoomNameSY;
            lblRoomType.Text = RoomTypeSY;
            lblBasePrice.Text = BasePriceSY;
            lblCapacity.Text = CapacitySY;
            lblAmentities.Text = AmentitiesSY;
            lblDescription.Text = DescriptionSY;

        }

        private void frmRoomDetails_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
