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
    public partial class frmParkinDetails : Form
    {

        public string SlotNameSRM;
        public string RoomNameSRM;
        public string GuestNameSRM;
        public string VehicleTypeSRM;
        public string VehicleNoSRM;
        public string BookingCodeSRM;
        private Form dimForm;

        public frmParkinDetails()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }


        //public void ShowAsPopupSRM()
        //{
        //    dimForm = new Form
        //    {
        //        BackColor = Color.Black,
        //        Opacity = 0.4,
        //        FormBorderStyle = FormBorderStyle.None,
        //        ShowInTaskbar = false,
        //        WindowState = FormWindowState.Maximized,
        //        StartPosition = FormStartPosition.Manual,
        //        TopMost = true
        //    };

        //    // Close popup when clicking outside
        //    dimForm.Click += (s, e) => { this.Close(); };

        //    dimForm.Show();

        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.TopMost = true;

        //    this.FormClosed += (s, e) =>
        //    {
        //        if (dimForm != null && !dimForm.IsDisposed)
        //            dimForm.Close();
        //    };

        //    this.Show();
        //}

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {


        }

        private void frmParkinDetails_Load(object sender, EventArgs e)
        {
            lblSlotName.Text = SlotNameSRM;
            lblRoomNo.Text = RoomNameSRM;
            lblOccupName.Text = GuestNameSRM;
            lblVehicleType.Text = VehicleTypeSRM;
            lblVehicleNo.Text = VehicleNoSRM;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
