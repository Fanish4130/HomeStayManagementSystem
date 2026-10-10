using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Guna.UI2.WinForms;


namespace GSTHMS
{
    public partial class frmInventoryOverView : Form
    {
        public frmInventoryOverView()
        {
            InitializeComponent();
            lstLowStockAlert.MouseUp += (s, e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    // BLOCK system context menu
                    return;
                }
            };
        }
        protected override void WndProc(ref Message m)
        {
            try {
                const int WM_CONTEXTMENU = 0x7B;

                // BLOCK Right-click context menu anywhere
                if (m.Msg == WM_CONTEXTMENU)
                    return;

                base.WndProc(ref m);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try {
                lstLowStockAlert.OwnerDraw = true;

                lstLowStockAlert.LabelEdit = false;
                lstLowStockAlert.ContextMenuStrip = null;

                LoadOverviewData();
                //LoadDashboardCards();
                // StyleDashboardPanels();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void LoadOverviewData()
        {
            TypebindVK();
            TotalItemVK();
            LowCountVK();
            TotalValueCountVK();
        }
        public void TypebindVK()
        {
            try {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetLowStockVK();

                lstLowStockAlert.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["InventoryName"].ToString());
                    item.SubItems.Add(row["Quantity"].ToString());

                    lstLowStockAlert.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void TotalItemVK()
        {
            try {
                clsUser obj = new clsUser();
                DataTable dt = obj.DisplayTotalItemsVK();

                if (dt.Rows.Count > 0)
                {
                    lbltotalcount.Text = dt.Rows[0]["TotalCount"].ToString();
                }
                else
                {
                    lbltotalcount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public void LowCountVK()
        {
            try {
                clsUser obj = new clsUser();
                DataTable dt = obj.DisplayLowStockItemsVK();

                if (dt.Rows.Count > 0)
                {
                    lblLowStockItems.Text = dt.Rows[0]["Quantity"].ToString();
                }
                else
                {
                    lblLowStockItems.Text = "0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void TotalValueCountVK()
        {
            try {
                clsUser obj = new clsUser();
                DataTable dt = obj.DisplayTotalValueVK();

                if (dt.Rows.Count > 0 && dt.Rows[0]["TotalStockValue"] != DBNull.Value)
                {
                    decimal totalValue = Convert.ToDecimal(dt.Rows[0]["TotalStockValue"]);
                    lblTotalStockValue.Text = "₹" + totalValue.ToString("N0"); // comma format
                }
                else
                {
                    lblTotalStockValue.Text = "₹0";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            } 
        }
        private void btnViewAllVendor_Click(object sender, EventArgs e)
        {
            try
            {
                frmVendorList obj = new frmVendorList();
                obj.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnViewAllInventory_Click(object sender, EventArgs e)
        {
            try
            {
                frmInventoryList obj = new frmInventoryList();
                obj.Show();
                //this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnAddNewInventory_Click(object sender, EventArgs e)
        {
            try {
                frmAddNewInventory obj = new frmAddNewInventory();
                obj.Owner = this;
                obj.Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        
        private void lstLowStockAlert_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            try
            {
                using (StringFormat sf = new StringFormat())
                {
                    // Required
                    // CENTER ALIGN HEADER
                    sf.Alignment = StringAlignment.Center;
                    sf.LineAlignment = StringAlignment.Center;

                    e.DrawBackground();
                    e.Graphics.DrawString(e.Header.Text, lstLowStockAlert.Font, Brushes.Black, e.Bounds, sf);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void lstLowStockAlert_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            try {
                e.DrawDefault = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            } 
        }

        private void lstLowStockAlert_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            try
            {
                e.DrawDefault = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void lstLowStockAlert_BeforeLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                e.CancelEdit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void lstLowStockAlert_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            try
            {
                e.CancelEdit = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void lstLowStockAlert_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                // Block ALL editing shortcuts
                if (e.Control && (e.KeyCode == Keys.X || e.KeyCode == Keys.C || e.KeyCode == Keys.V))
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }

                if (e.KeyCode == Keys.F2) // Rename key
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void lstLowStockAlert_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    return; // BLOCK context menu
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void lblTotalStockValue_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
 