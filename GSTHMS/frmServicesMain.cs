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
    public partial class frmServicesMain : Form
    {
        //Form currentform=null;
        ToolStripMenuItem activeMenuItem=null;
        public frmServicesMain()
        {
            InitializeComponent();
        }

        private void viewFoodServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmFoodService food = new frmFoodService();
            //food.MdiParent = this.MdiParent;
            //food.ShowDialog();

            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = viewFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmFoodService());

        }

        private void provideFoodServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {


            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = provideFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmActiveGuest());
        }

        private void parkingServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = parkingServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmParking());
             // 🔹 OPEN AS POPUP
    //frmParking frm = new frmParking();
    //frm.StartPosition = FormStartPosition.CenterScreen;
    //frm.ShowDialog();  
        }
        private void LoadFromInPannel(Form form)
        {
            pnlMainServices.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlMainServices.Controls.Add(form);
            form.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void frmServicesMain_Load(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = viewFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmFoodService());


        }

        private void pnlMainServices_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
