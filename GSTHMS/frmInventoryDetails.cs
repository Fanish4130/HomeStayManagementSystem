using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmInventoryDetails : Form
    {
        public string InventoryNameVK;
        private int CurrentInventoryIDVK;
        int inventoryIdVK;
        public frmInventoryDetails(string inventorynm )
        {
            InitializeComponent();

            InventoryNameVK = inventorynm;
           CurrentInventoryIDVK = inventoryIdVK;

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void frmInventoryDetails_Load(object sender, EventArgs e)
        {
            try {
                clsUser obj = new clsUser();
                obj.InventoryNameVK = InventoryNameVK;
                DataTable dt = obj.InventoryDetailsVK();

                if (dt.Rows.Count > 0)
                {
                    lblPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
                    lblVendorName.Text = dt.Rows[0]["VendorName"].ToString();
                    lblVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                    lblInventoryType.Text = dt.Rows[0]["InventoryTypeName"].ToString();
                    lblInventoryName.Text = dt.Rows[0]["InventoryName"].ToString();
                    lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    lblUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                    lblTotalPrice.Text = dt.Rows[0]["TotalPrice"].ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try {
                //for view bill in vendor code throw
                clsUser obj = new clsUser();
                obj.VendorNameVK = lblVendorName.Text;
                obj.VendorCodeVK = obj.GetVCodeVK();
                string billPath = obj.GetBillPathVK();
                // billPath = billPath;

                if (System.IO.File.Exists(billPath))
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = new System.Diagnostics.ProcessStartInfo()
                    {
                        FileName = billPath,
                        UseShellExecute = true
                    };
                    proc.Start();
                }
                else
                {
                    MessageBox.Show("Bill file not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }
    }    
}
