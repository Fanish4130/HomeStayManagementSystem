using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Policy;
using System.IO;

namespace GSTHMS
{
    public partial class frmMainReport : Form
    {
        Form currentForm = null;
        ToolStripMenuItem activeMenuItem = null;  // store currently active menu

        public frmMainReport()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load default form
            frmGuestReport form = new frmGuestReport();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None; // remove borders
            form.Dock = DockStyle.Fill; // fill panel
            PanneContainer.Controls.Add(form);
            form.Show();
            //IsMdiContainer = true;

            // 🎨 ----- MENU STRIP STYLING -----
            //menuStrip1.RenderMode = ToolStripRenderMode.System;
            //menuStrip1.BackColor = Color.FromArgb(240, 235, 255); // soft violet background
            //menuStrip1.ForeColor = Color.MediumVioletRed;
            menuStrip1.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            //foreach (ToolStripMenuItem item in menuStrip1.Items)
            //{
            //    item.BackColor = Color.Transparent;
            //    item.ForeColor = Color.MediumVioletRed;

            //    // Hover effect
            //    item.MouseEnter += (s, ev) =>
            //    {
            //        if (item != activeMenuItem) // don't override active item
            //        {
            //            item.BackColor = Color.MediumSlateBlue;
            //            item.ForeColor = Color.White;
            //        }
            //    };

            //    item.MouseLeave += (s, ev) =>
            //    {
            //        if (item != activeMenuItem) // keep active one highlighted
            //        {
            //            item.BackColor = Color.Transparent;
            //            item.ForeColor = Color.MediumVioletRed;
            //        }
            //    };
            //}
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White; 
            }

            // 🔹 Set this one as active
            activeMenuItem = guestReortToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            // 🔹 Load your form
            LoadFromInPannel(new frmGuestReport());
        }


        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void GuestReport_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guestReortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = guestReortToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            // 🔹 Load your form
            LoadFromInPannel(new frmGuestReport());
        }

        private void serviceReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.WhiteSmoke;
            }

            // 🔹 Set this one as active
            activeMenuItem = serviceReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            // 🔹 Load your form
            LoadFromInPannel(new frmServiceReport());
        }

        private void bookingReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = bookingReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmBookingReport());
        }

        private void inventoryReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = inventoryReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmInventoryReport());
        }

        private void paymentReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = paymentReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmPaymentReport());
        }

        private void eventReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = eventReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmEventReport());
        }

        private void roomReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = roomReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmRoomReport());
        }

        private void LoadFromInPannel(Form form)
        {
            PanneContainer.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            PanneContainer.Controls.Add(form);
            form.Show(); 
        }

        private void PanneContainer_Paint(object sender, PaintEventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void staffReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = staffReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmStaffReport());
        }

        private void receptionistReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
           // activeMenuItem = receptionistReportToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            //LoadFromInPannel(new frmVendorReport());
        }

        //private void recToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (activeMenuItem != null)
        //    {
        //        activeMenuItem.BackColor = Color.Transparent;
        //        activeMenuItem.ForeColor = Color.MediumVioletRed;
        //    }

        //    // 🔹 Set this one as active
        //    activeMenuItem = recToolStripMenuItem;
        //    activeMenuItem.BackColor = Color.BlueViolet;
        //    activeMenuItem.ForeColor = Color.White;

        //    LoadFromInPannel(new frmReceptiniost());
        //}

        // 🔹 Helper function to reset all menu colors
        //private void ResetMenuColors()
        //{
        //    foreach (ToolStripMenuItem item in menuStrip1.Items)
        //    {
        //        // if item is currently active, skip resetting
        //        if (item == activeMenuItem)
        //            continue;

        //        item.BackColor = Color.Transparent;
        //        item.ForeColor = Color.MediumVioletRed;
        //    }
        //}
    }
}
