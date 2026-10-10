using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;


namespace GSTHMS
{
    public partial class frmOrderFood : Form
    {
        public string GuestNameSRM;
        public string RoomNameSRM;
        public int RoomIDSRM;
        public decimal SelectedFoodPriceSRM;


        public frmOrderFood()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            listView.MouseClick += listView_MouseClick;

            cmbbxFood.SelectedIndexChanged += cmbbxFood_SelectedIndexChanged;
        }

        private void frmOrderFood_Load(object sender, EventArgs e)
        {
            txtFoodPrice.ReadOnly = true;
            txtTotalAmount.ReadOnly = true;

            clsUser foodtype = new clsUser();
            DataTable dt = foodtype.DisplayFoodTypeSRM();

            cmbbxFoodType.DisplayMember = "FoodTypeName";
            cmbbxFoodType.ValueMember = "FoodTypeID";
            cmbbxFoodType.DataSource = dt;

            lblGuestName1.Text = GuestNameSRM;
            lblRoomNo.Text = RoomNameSRM;

            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.Columns.Clear();

            listView.Columns.Add("Guest Name", 120);
            listView.Columns.Add("Room No", 80);
            listView.Columns.Add("Food Type", 100);
            listView.Columns.Add("Menu Name", 100);
            listView.Columns.Add("Quantity", 80);
            listView.Columns.Add("Food Price", 80);
            listView.Columns.Add("Total Price", 80);
            listView.Columns.Add("Action", 60);

            listView.OwnerDraw = true;
            listView.DrawColumnHeader += ListView_DrawColumnHeader;
            listView.DrawSubItem += ListView_DrawSubItem;
        }

        private void cmbbxFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbbxFood_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQty_TextChanged(object sender, EventArgs e)
        {


        }

        private void CalculateBeforeAddSRM()
        {
            int qty = 0;
            int.TryParse(txtQty.Text, out qty);

            txtTotalAmount.Text = "₹ " + (SelectedFoodPriceSRM * qty).ToString("0.00");
        }

        private void btnAddtoCard_Click(object sender, EventArgs e)
        {

        }

        private void CalculateGrandTotal()
        {
            decimal total = 0;

            foreach (ListViewItem i in listView.Items)
            {
                total += Convert.ToDecimal(i.SubItems[6].Text.Replace("₹", "").Trim());
            }

            txtTotalAmount.Text = "₹ " + total.ToString("0.00");
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo hit = listView.HitTest(e.Location);

            if (hit.Item == null || hit.SubItem == null)
                return;

            int colIndex = hit.Item.SubItems.IndexOf(hit.SubItem);

            // Action column index = 7
            if (colIndex == 7)
            {
                DialogResult dr = MessageBox.Show(
                    "Do you want to remove this food item?",
                    "Remove Item",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dr == DialogResult.Yes)
                {
                    hit.Item.Remove();   // exact clicked item remove
                    CalculateGrandTotal();
                }
            }
        }

        private void ListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                Image img = Properties.Resources.Delete;
                int x = e.Bounds.Left + (e.Bounds.Width - 16) / 2;
                int y = e.Bounds.Top + (e.Bounds.Height - 16) / 2;
                e.Graphics.DrawImage(img, new Rectangle(x, y, 16, 16));
            }
            else
            {
                e.DrawText();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void cmbbxFoodType_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbbxFoodType.SelectedValue == null)
                return;

            if (cmbbxFoodType.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            clsUser obj = new clsUser();
            obj.FoodTypeIDSRM = Convert.ToInt32(cmbbxFoodType.SelectedValue);

            DataTable dt = obj.DisplayMenuNameSRM();

            DataRow dr = dt.NewRow();
            dr["FoodMenuID"] = 0;
            dr["FoodName"] = "-- Select Food --";
            dt.Rows.InsertAt(dr, 0);

            cmbbxFood.DisplayMember = "FoodName";
            cmbbxFood.ValueMember = "FoodMenuID";
            cmbbxFood.DataSource = dt;
            cmbbxFood.SelectedIndex = 0;
            txtQty.Clear();
            txtFoodPrice.Clear();
            txtTotalAmount.Clear();
            SelectedFoodPriceSRM = 0;
        }

        private void txtQty_TextChanged_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtQty.Text))
            {
                txtTotalAmount.Clear();
                return;
            }

            int qty;
            if (!int.TryParse(txtQty.Text, out qty))
            {
                MessageBox.Show("Only numbers allowed.");
                txtQty.Clear();
                txtTotalAmount.Clear();
                return;
            }

            if (qty > 25)
            {
                MessageBox.Show("Quantity cannot be more than 25.");
                txtQty.Text = "25";
                txtQty.SelectionStart = txtQty.Text.Length;
                qty = 25;
            }
            CalculateBeforeAddSRM();
        }

        private void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFoodPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddtoCard_Click_1(object sender, EventArgs e)
        {
            if (cmbbxFood.SelectedValue == null || Convert.ToInt32(cmbbxFood.SelectedValue) == 0)
            {
                MessageBox.Show("Please select food.");
                return;
            }

            int qty;
            if (!int.TryParse(txtQty.Text, out qty) || qty <= 0 || qty > 25)
            {
                MessageBox.Show("Please enter quantity between 1 to 25.");
                return;
            }

            int foodmenuID = Convert.ToInt32(cmbbxFood.SelectedValue);
            DataRowView row = (DataRowView)cmbbxFood.SelectedItem;
            string menuName = row["FoodName"].ToString();

            decimal price = SelectedFoodPriceSRM;
            decimal total = price * qty;

            foreach (ListViewItem i in listView.Items)
            {
                if (Convert.ToInt32(i.Tag) == foodmenuID)
                {
                    int oldQty = Convert.ToInt32(i.SubItems[4].Text);
                    int newQty = oldQty + qty;

                    if (newQty > 25)
                    {
                        MessageBox.Show("Total quantity cannot be more than 25.");
                        return;
                    }

                    i.SubItems[4].Text = newQty.ToString();
                    i.SubItems[6].Text = "₹ " + (newQty * price).ToString("0.00");
                    CalculateGrandTotal();
                    return;
                }
            }

            ListViewItem item = new ListViewItem(lblGuestName1.Text);
            item.SubItems.Add(lblRoomNo.Text);
            item.SubItems.Add(cmbbxFoodType.Text);
            item.SubItems.Add(menuName);
            item.SubItems.Add(qty.ToString());
            item.SubItems.Add("₹ " + price.ToString("0.00"));
            item.SubItems.Add("₹ " + total.ToString("0.00"));
            item.SubItems.Add("");

            item.Tag = foodmenuID;
            listView.Items.Add(item);

            CalculateGrandTotal();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtQty.Clear();
            txtTotalAmount.Clear();
            txtFoodPrice.Clear();
            listView.Items.Clear();

            if (cmbbxFood.Items.Count > 0)
                cmbbxFood.SelectedIndex = 0;
        }

        private void btnOrder_Click_1(object sender, EventArgs e)
        {
            if (listView.Items.Count == 0)
            {
                MessageBox.Show("No items in cart");
                return;
            }

            clsUser obj = new clsUser();
            obj.RoomNameSRM = lblRoomNo.Text;
            obj.GuestNameSRM = lblGuestName1.Text;

            string bookingCode = obj.FetchBookingCodeSRM();

            foreach (ListViewItem item in listView.Items)
            {
                obj.BookingCodeSRM = bookingCode;
                obj.FoodMenuIDSRM = Convert.ToInt32(item.Tag);
                obj.QuantitySRM = Convert.ToInt32(item.SubItems[4].Text);
                obj.TotalPriceSRM = Convert.ToDecimal(item.SubItems[6].Text.Replace("₹", "").Trim());

                obj.OrderFoodSRM();
            }

            MessageBox.Show("Order Saved Successfully!");
            frmorderplaced frm = new frmorderplaced();
            frm.GuestNameSRM = lblGuestName1.Text;
            frm.RoomNameSRM = lblRoomNo.Text;

            frm.Show();

            btnClear_Click_1(null, null);
            this.Close();
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxFood_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txtQty.Clear();
            txtTotalAmount.Clear();
            if (cmbbxFood.SelectedValue == null)
                return;

            if (cmbbxFood.SelectedValue.ToString() == "System.Data.DataRowView")
                return;

            int foodMenuID = Convert.ToInt32(cmbbxFood.SelectedValue);

            if (foodMenuID == 0)
            {
                txtFoodPrice.Clear();
                txtTotalAmount.Clear();
                SelectedFoodPriceSRM = 0;
                return;
            }

            clsUser obj = new clsUser();
            obj.FoodTypeIDSRM = Convert.ToInt32(cmbbxFoodType.SelectedValue);
            obj.FoodMenuIDSRM = foodMenuID;

            DataTable dt = obj.GetFoodPriceDataSRM();

            if (dt.Rows.Count > 0)
            {
                decimal.TryParse(dt.Rows[0]["FoodPrice"].ToString(), out SelectedFoodPriceSRM);
                txtFoodPrice.Text = "₹ " + SelectedFoodPriceSRM.ToString("0.00");
            }

            CalculateBeforeAddSRM();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            frmMenuList frm = new frmMenuList();
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopMost = true;

            frm.ShowDialog();
        }
    }
}
