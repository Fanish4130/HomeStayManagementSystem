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
    public partial class frmAssetInventoryDetails : Form
    {
        public string InventoryNameVK;
        public frmAssetInventoryDetails(string inventorynm)
        {
            InitializeComponent();

            InventoryNameVK = inventorynm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public int InventoryID;
        private void frmAssetInventoryDetails_Load(object sender, EventArgs e)
        {
            try {
                if (!string.IsNullOrEmpty(InventoryID.ToString()))
                {
                    clsUser obj = new clsUser();
                    obj.InventoryNameVK = InventoryNameVK;
                    DataTable dt = obj.InventoryDetailsVK();

                    if (dt.Rows.Count > 0)
                    {
                        lblPurchaseDate.Text = dt.Rows[0]["PurchaseDate"].ToString();
                        lblVendorName.Text = dt.Rows[0]["VendorName"].ToString();
                        lblVendorAddress.Text = dt.Rows[0]["Address"].ToString();
                        lblAssetInventoryType.Text = dt.Rows[0]["InventoryTypeName"].ToString();
                        lblAssetInventoryName.Text = dt.Rows[0]["InventoryName"].ToString();
                        lblQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                        lblUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                        lblTotalPrice.Text = dt.Rows[0]["TotalPrice"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
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
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try { 
                clsUser obj = new clsUser();
                obj.VendorNameVK = lblVendorName.Text;
                obj.VendorCodeVK = obj.GetVCodeVK();
                string billPath = obj.GetBillPathVK();
                // billPath = billPath + ".pdf";

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
    }
}
