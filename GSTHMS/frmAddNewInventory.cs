using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmAddNewInventory : Form
    {
        public frmAddNewInventory()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        int inventorytypeidVK;
        string  VendorCodeVK;
        string filePathVK;
        private void frmAddNewInventory_Load(object sender, EventArgs e)
        {
            try {
                view.Visible = false;

                lbl9.Visible = false;
                lbl10.Visible = false;
                lbl11.Visible = false;
                lbl12.Visible = false;
                lbl13.Visible = false;
                lbl14.Visible = false;

                // Display Vendor Name on combobox
                clsUser obj = new clsUser();
                DataTable dt = obj.GetVendorNameVK();

                DataRow newRow = dt.NewRow();  // when we open form display on combobox select Vendor Name
                newRow["VendorName"] = "select Vendor Name";
                newRow["VendorCode"] = 0;
                dt.Rows.InsertAt(newRow, 0);

                cmbbxVendorName.DisplayMember = "VendorName";
                cmbbxVendorName.ValueMember = "VendorCode";
                cmbbxVendorName.DataSource = dt;

                LoadInventoryTypeVK();


                lblTotalPrice.Text = "₹ 0.00"; // Display the total price 0.00 when open form or clear 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void LoadInventoryTypeVK()
        {
            try 
            {
                //Display Inventory Type on combobox

                clsUser obj = new clsUser();
                DataTable dt = obj.GetInventoryTypeAddVK();

                DataRow newRow = dt.NewRow();  // when we open form display on combobox select inventory type
                newRow["InventoryTypeName"] = "select inventory type";
                newRow["InventoryTypeID"] = 0;
                dt.Rows.InsertAt(newRow, 0);

                cmbbxInventoryType.DataSource = dt;
                cmbbxInventoryType.DisplayMember = "InventoryTypeName";
                cmbbxInventoryType.ValueMember = "InventoryTypeID";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalPriceVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void txtUnitPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                CalculateTotalPriceVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void CalculateTotalPriceVK()
        {
            try
            {
                // Display Total Price in label
                if (decimal.TryParse(txtQuantity.Text, out decimal quantity) && decimal.TryParse(txtUnitPrice.Text, out decimal unitPrice))
                {
                    decimal totalPrice = quantity * unitPrice;
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
        private void btnProvide_Click(object sender, EventArgs e)
        {
            try
            {
                // Vendor Name validation
                if (cmbbxVendorName.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select  Vendor Name.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxVendorName.Focus();
                    return;
                }
                if (cmbbxInventoryType.SelectedIndex == 0 ||
                   Convert.ToInt32(cmbbxInventoryType.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select Inventory Type.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxInventoryType.Focus();
                    return;
                }                

                if (string.IsNullOrEmpty(txtInventoryName.Text.Trim()))
                {
                    MessageBox.Show("Please Enter the Inventory Name\n");
                    return;
                }
                if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
                {
                    MessageBox.Show("Please Enter the Quantity\n");
                    return;
                }
                if (string.IsNullOrEmpty(txtUnitPrice.Text.Trim()))
                {
                    MessageBox.Show("Please Enter the Unit Price\n");
                    return;
                }
                if (string.IsNullOrEmpty(filePathVK))
                {
                    MessageBox.Show("Please upload the Product Bill.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                clsUser obj = new clsUser();
               //  obj.VendorCodeVK = VendorCodeVK;

                if (cmbbxInventoryType.SelectedValue != null)
                {
                    System.Data.DataRowView selectedRow = (System.Data.DataRowView)cmbbxInventoryType.SelectedItem;  // insert the data providetoguest form to provideclick provide button 
                    inventorytypeidVK = Convert.ToInt32(selectedRow["InventoryTypeID"]);
                }
                obj.VendorCodeVK = cmbbxVendorName.SelectedValue.ToString();
                obj.filePathVK = filePathVK;
                obj.UploadBillVK();
                obj.InventoryTypeIDVK = inventorytypeidVK;   //Convert.ToInt32(cmbbxInventoryType.SelectedValue);
                //int SubTypeId = obj.GetSubTypeVK();
                //obj.SubTypeIDVK = SubTypeId;
                obj.InventoryNameVK = txtInventoryName.Text;
                obj.UnitPriceVK = Convert.ToDecimal(txtUnitPrice.Text);
                obj.QuantityVK = Convert.ToInt32(txtQuantity.Text);
                string tpVK = lblTotalPrice.Text;
                obj.TotalPriceVK = decimal.Parse(tpVK, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-IN"));
                obj.BDateVK = DateTime.Now;
                obj.GetAddNewVK();
                MessageBox.Show("Saved Successfully...!!!");

                if (Application.OpenForms["frmInventoryOverView"] != null)
                {
                    frmInventoryOverView frm = (frmInventoryOverView)Application.OpenForms["frmInventoryOverView"];

                    frm.TotalItemVK();
                    frm.LowCountVK();
                    frm.TotalValueCountVK();
                    frm.TypebindVK();
                }

                if (Application.OpenForms["frmInventoryList"] != null)
                {
                    frmInventoryList frm = (frmInventoryList)Application.OpenForms["frmInventoryList"];
                    frm.MainFormLoad();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            try
            {
                cmbbxVendorName.SelectedIndex = 0;
                cmbbxInventoryType.SelectedIndex = 0;
                txtInventoryName.Text = string.Empty;
                txtQuantity.Text = string.Empty;
                txtUnitPrice.Text = string.Empty;
                lblTotalPrice.Text = "₹ 0.00";
                view.Visible = false;

                //this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void cmbbxVendorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxVendorName.SelectedValue != null)
                {
                    System.Data.DataRowView selectedRow = (System.Data.DataRowView)cmbbxVendorName.SelectedItem; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
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

        private void txtInventoryName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Correct Invetory Name....");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void txtUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Please Enter Correct Unit Price....");
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
            try
            {
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
        private void guna2PictureBox3_Click(object sender, EventArgs e)
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
    }
}
        
   