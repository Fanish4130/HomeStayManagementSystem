using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmAssetInventoryProvide : Form
    {
        public frmAssetInventoryProvide()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        int inventoryidVK;
        public string GuestNameVK;      
        int RoomIDVK;
        int InventoryTypeIDVK;

        private void frmAssetInventoryProvide_Load(object sender, EventArgs e)
        {
            try {
                lbl14.Visible = false;
                lbl2.Visible = false;
                lbl3.Visible = false;

                // display room type and room name of providetiguest form on the labels
                if (!string.IsNullOrEmpty(GuestNameVK))
                {
                    clsUser obj = new clsUser();
                    obj.GuestNameVK = GuestNameVK;
                    DataTable dt = obj.GetARoomDetailsVK();

                    if (dt.Rows.Count > 0)
                    {
                        lblRoomType.Text = dt.Rows[0]["RoomTypeName"].ToString();
                        lblRoomName.Text = dt.Rows[0]["RoomName"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("No active room found for this guest!");
                    }
                }
                lblUnitPrice.Text = "₹ 0.00"; // Display the unit price 0.00 when open form or clear 
                lblTotalPrice.Text = "₹ 0.00";

                LoadInventoryTypeVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void LoadInventoryTypeVK()
        {
            //Display Inventory Type on combobox
            try {
                clsUser obj = new clsUser();
                DataTable dt = obj.AssetInventoryTypeVK();

                DataRow newRow = dt.NewRow();  // when we open form display on combobox select inventory type
                newRow["InventoryTypeName"] = "select inventory type";
                newRow["InventoryTypeID"] = 0;
                dt.Rows.InsertAt(newRow, 0);

                cmbbxInventoryType.DisplayMember = "InventoryTypeName";
                cmbbxInventoryType.ValueMember = "InventoryTypeID";
                cmbbxInventoryType.DataSource = dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void cmbbxInventoryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Display inventory Name on combobox
            try {
                if (cmbbxInventoryType.SelectedValue != null)
                {
                    System.Data.DataRowView selectedRow = (System.Data.DataRowView)cmbbxInventoryType.SelectedItem;//
                    InventoryTypeIDVK = Convert.ToInt32(selectedRow["InventoryTypeID"]);
                }
                clsUser obj = new clsUser();
                obj.InventoryTypeIDVK = InventoryTypeIDVK;
                DataTable dt = obj.AssetInventoryNameVK();

                DataRow newRow = dt.NewRow();  //when we open form display on combobox select inventory name
                newRow["InventoryName"] = "select inventory name";
                newRow["InventoryID"] = 0;
                dt.Rows.InsertAt(newRow, 0);

                cmbbxInventoryName.DataSource = dt;
                cmbbxInventoryName.DisplayMember = "InventoryName";
                cmbbxInventoryName.ValueMember = "InventoryID";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private int availableQty = 0;
        private void cmbbxInventoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //for Display untiprice on label 
            try {
                if (cmbbxInventoryName.SelectedIndex != -1)
                {
                    string selectedInventory = cmbbxInventoryName.Text;

                    clsUser obj = new clsUser();
                    obj.InventoryNameVK = selectedInventory;

                    // GET INVENTORY QUANTITY FROM DB
                    DataTable dtQty = obj.GetInventoryquantityVK();
                    if (dtQty.Rows.Count > 0)
                    {
                        availableQty = Convert.ToInt32(dtQty.Rows[0]["Quantity"]);
                    }
                    else
                    {
                        availableQty = 0;
                    }

                    // GET UNIT PRICE
                    DataTable dt = obj.AssetUnitPriceVK();
                    if (dt.Rows.Count > 0)
                    {
                        decimal unitPrice = Convert.ToDecimal(dt.Rows[0]["UnitPrice"]);
                        lblUnitPrice.Text = "₹" + unitPrice.ToString("0.00");
                    }
                    else
                    {
                        lblUnitPrice.Text = "₹ 0.00";
                    }
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
                if (!int.TryParse(txtQuantity.Text, out int qty))
                {
                    lblTotalPrice.Text = "₹ 0.00";
                    return;
                }

                // VALIDATION
                if (qty > availableQty)
                {
                    MessageBox.Show("You can enter quantity up to: " + availableQty);
                    txtQuantity.Text = "";
                    return;
                }

                // PRICE CALCULATION
                string unitPriceText = lblUnitPrice.Text.Replace("₹", "").Trim();

                if (decimal.TryParse(unitPriceText, out decimal unitPrice))
                {
                    decimal total = qty * unitPrice;
                    lblTotalPrice.Text = "₹" + total.ToString("0.00");
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
            //validations when we click provide button then  not enter or select the data in combobox and textbox then show the message
            try
            {
                if (cmbbxInventoryType.SelectedIndex == 0 ||
                 Convert.ToInt32(cmbbxInventoryType.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select Inventory Type.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxInventoryType.Focus();
                    return;
                }
                if (cmbbxInventoryName.SelectedIndex == 0 ||
                 Convert.ToInt32(cmbbxInventoryName.SelectedValue) == 0)
                {
                    MessageBox.Show("Please select Inventory Name.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxInventoryName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtQuantity.Text.Trim()))
                {
                    MessageBox.Show("Please Enter the  Quantity");
                    return;
                }

                // insert the data providetoguest form to provideclick provide button 
                if (cmbbxInventoryName.SelectedValue != null)
                {
                    System.Data.DataRowView selectedRow = (System.Data.DataRowView)cmbbxInventoryName.SelectedItem;
                    inventoryidVK = Convert.ToInt32(selectedRow["InventoryID"]);
                }

                clsUser obj = new clsUser();
                obj.RoomNameVK = lblRoomName.Text;

                obj.RoomIDVK = obj.GetRoomIdVK(); 
                string bcode = obj.GetBookingCodeVK();
                obj.BookingCodeVK = bcode;
                obj.InventoryIDVK = inventoryidVK;
                string upVK = lblUnitPrice.Text;
                obj.UnitPriceVK = decimal.Parse(upVK, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-IN"));

                obj.QuantityVK = Convert.ToInt32(txtQuantity.Text);
                string tpVK = lblTotalPrice.Text;
                obj.TotalPriceVK = decimal.Parse(tpVK, NumberStyles.Currency, CultureInfo.GetCultureInfo("en-IN"));
                obj.DecreamentOfQuanityVK();
                obj.AutoLowStockStatusVK();
                obj.ProvideInventoryVK();             
                MessageBox.Show("Provide Successfully...!!!");

                if (Application.OpenForms["frmAssetInventoryManagement"] != null)
                {
                    frmAssetInventoryManagement frm = (frmAssetInventoryManagement)Application.OpenForms["frmAssetInventoryManagement"];
                    frm.MainLoad();
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
        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clear dropdown , textboxes , labels
            try {
                cmbbxInventoryType.SelectedIndex = 0;
                cmbbxInventoryName.SelectedIndex = 0;

                txtQuantity.Text = string.Empty;
                lblUnitPrice.Text = "₹ 0.00";
                lblTotalPrice.Text = "₹ 0.00";

                //this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            //validations when we not enter or select the data in combobox and textbox
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

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
