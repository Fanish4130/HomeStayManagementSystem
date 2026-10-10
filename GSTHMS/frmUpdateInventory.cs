using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmUpdateInventory : Form
    {
        public int InventoryIDVK;
        public string InventoryNameVK;
        string VendorCodeVK;
        string filePathVK;
        public frmUpdateInventory(string invetorynm)
        {
            InitializeComponent();

            InventoryNameVK = invetorynm;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void frmUpdateInventory_Load(object sender, EventArgs e)
        {
            try {
                //lbl14.Visible = false;
                lbl8.Visible = false;

                view.Visible = false;

                clsUser obj = new clsUser();
                obj.InventoryNameVK = InventoryNameVK;
                DataTable dt = obj.UpdateInventoryVK();

                if (dt.Rows.Count > 0)
                {
                    InventoryIDVK = Convert.ToInt32(dt.Rows[0]["InventoryID"]);

                    lblVendorName.Text = dt.Rows[0]["VendorName"].ToString();
                    lblInventoryType.Text = dt.Rows[0]["InventoryTypeName"].ToString();
                    lblInventoryName.Text = dt.Rows[0]["InventoryName"].ToString();
                    txtQuantity.Text = dt.Rows[0]["Quantity"].ToString();
                    lblUnitPrice.Text = dt.Rows[0]["UnitPrice"].ToString();
                    lblTotalPrice.Text = dt.Rows[0]["TotalPrice"].ToString();

                    // Read numeric values from DB
                    decimal unitPriceFromDB = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                    decimal totalPriceFromDB = Convert.ToDecimal(dt.Rows[0]["TotalPrice"]);

                    //  Display with ₹ symbol
                    lblUnitPrice.Text = "₹ " + unitPriceFromDB.ToString("0.00");
                    lblTotalPrice.Text = "₹ " + totalPriceFromDB.ToString("0.00");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try {
                string unitPriceText = lblUnitPrice.Text.Replace("₹", "").Trim();

                if (decimal.TryParse(txtQuantity.Text, out decimal quantity) &&
                    decimal.TryParse(unitPriceText, out decimal unitPrice))
                {
                    decimal totalPrice = quantity * unitPrice;

                    // Add ₹ symbol when displaying
                    lblTotalPrice.Text = "₹" + totalPrice.ToString("0.00");
                }
                else
                {
                    lblTotalPrice.Text = "₹ 0.00";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            try {
                txtQuantity.Text = string.Empty;

                view.Visible = false;
                //lblUnitPrice.Text = "0.00";
                // lblTotalPrice.Text = "0.00";

                // this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtQuantity.Text))
                {
                    MessageBox.Show("Please Enter the Quantity", "Validation");
                    txtQuantity.Focus();
                    return;
                }
                clsUser obj = new clsUser();
                obj.VendorNameVK = lblVendorName.Text;

                obj.VendorCodeVK = obj.GetVCodeVK();
                obj.filePathVK = filePathVK;
                obj.UploadBillVK();

                obj.InventoryNameVK = InventoryNameVK;
                obj.QuantityVK = Convert.ToInt32(txtQuantity.Text);
                string tpVK = lblTotalPrice.Text;
                obj.TotalPriceVK = decimal.Parse(tpVK, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-IN"));

                obj.GetUpdateInventoryVK();
                obj.InventoryIDVK = InventoryIDVK;
                obj.AutoLowStockStatusVK();
                MessageBox.Show("Updated Successfully...!!!");

                //when add inventory then automatic add the inventory in grid
                if (Application.OpenForms["frmInventoryList"] != null)
                {
                    frmInventoryList frm = (frmInventoryList)Application.OpenForms["frmInventoryList"];
                    frm.MainFormLoad();
                }
                if (Application.OpenForms["frmInventoryOverView"] != null)
                {
                    frmInventoryOverView frm =
                    (frmInventoryOverView)Application.OpenForms["frmInventoryOverView"];

                    frm.LoadOverviewData();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter the correct Quantity...");
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
                //upload bill
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePathVK = ofd.FileName;       //  Full Path

                    MessageBox.Show("Upload Document Successfully!");

                    view.Visible = true;
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
        private void view_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePathVK))
                {
                    Process.Start(filePathVK);
                }
                else
                {
                    MessageBox.Show("No file uploaded.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

