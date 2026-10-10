using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GSTHMS
{
    public partial class frmParking : Form
    {
        public string SlotName;
        public string SelectedSlotName;
       
     
        public frmParking()
        {
            InitializeComponent();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmFoodService food = new frmFoodService();
            food.MdiParent = this.MdiParent;
            food.Show();
        }

        private void btnProvideService_Click(object sender, EventArgs e)
        {
            frmActiveGuest provide = new frmActiveGuest();
            provide.MdiParent = this.MdiParent;
            provide.Show();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
       
        private void frmParking_Load(object sender, EventArgs e)
        {


            LoadSlotStatusSRM();
        }
        private void LoadSlotStatusSRM()
        {
            clsUser parking = new clsUser();
            DataTable dt = parking.ParkingSlotStatusSRM();

            if (dt == null || dt.Rows.Count == 0) return;

            SetSlotSRM(dt, "Slot-A1", lblgroud, btnSlotA);
            SetSlotSRM(dt, "Slot-A2", lblnear, btnSlotA2);
            SetSlotSRM(dt, "Slot-B1", lblfront, btnSlotB1);
            SetSlotSRM(dt, "Slot-B2", lbllobby, btnSlotB2);
            SetSlotSRM(dt, "Slot-C1", lblnearback, btnSlotC1);
        }

        private void SetSlotSRM(DataTable dt, string slotName, Label lblCount, Guna2Button btn)
        {
            DataRow[] rows = dt.Select($"SlotName = '{slotName}'");
            if (rows.Length == 0) return;

            int used = Convert.ToInt32(rows[0]["UsedCount"]);
            int capacity = Convert.ToInt32(rows[0]["Capacity"]);
            string status = rows[0]["SlotStatus"].ToString();

            lblCount.Text = $"{used}/{capacity}";

            if (status == "Occupied")
            {
                btn.Text = "Occupied";
                btn.FillColor = Color.Red;
            }
            else
            {
                btn.Text = "Available";
                btn.FillColor = Color.LimeGreen;
            }

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SelectedSlotName = "Slot-A1";
            frmslotGridView frm = new frmslotGridView(SelectedSlotName);
            frm.ShowDialog();
        }

        private void btnFetchStatus_Click(object sender, EventArgs e)
        {
           

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
       
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SelectedSlotName = "Slot-A2";
            frmslotGridView slotGrid = new frmslotGridView("Slot-A2");
            //slotGrid.ShowWithDimSRM();
            slotGrid.ShowDialog();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {

            SelectedSlotName = "Slot-B1";
            frmslotGridView slotGrid = new frmslotGridView("Slot-B1");
            // slotGrid.ShowWithDimSRM();
            slotGrid.ShowDialog();
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            SelectedSlotName = "Slot-B2";
            frmslotGridView slotGrid = new frmslotGridView("Slot-B2");
            //slotGrid.ShowWithDimSRM();
            slotGrid.ShowDialog();

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            SelectedSlotName = "Slot-C1";
            frmslotGridView slotGrid = new frmslotGridView("Slot-C1");
            //slotGrid.ShowWithDimSRM();
            slotGrid.ShowDialog();
        }

        private void lblFrontDesk_Click(object sender, EventArgs e)
        {

        }
    }
}
