using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSTHMS.frmChangePassword;

namespace GSTHMS
{
    public partial class frmAddFeedback : Form
    {
        public string UserNamePSS { get; set; }

        public frmAddFeedback()
        {
            InitializeComponent();
        }

        private void cmbbxName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                cmbbxName.ForeColor = Color.Black;
                rtgRoom.Value = 0;
                rtgFood.Value = 0;
                rtgParking.Value = 0;
                rtgEvent.Value = 0;
                rtgInventory.Value = 0;
                rtgOverallRating.Value = 0;

                rtfDescriptionfeedback.Text = "Write feedback...";
                rtfDescriptionfeedback.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on guest selection: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAddFeedback_Load(object sender, EventArgs e)
        {
            try
            {
                string currentUserCode = "RCPT001";

                cmbbxName.Text = "Select an option";
                cmbbxName.ForeColor = Color.Gray;

                clsUser obj = new clsUser();
                obj.UserCodePSS = currentUserCode;
                DataTable dt = obj.ShowGuestNamePSS();

                DataRow dr = dt.NewRow();
                dr["GuestCode"] = "";
                dr["GuestName"] = "Select Guest Name";
                dt.Rows.InsertAt(dr, 0);

                cmbbxName.DisplayMember = "GuestName";
                cmbbxName.ValueMember = "GuestCode";
                cmbbxName.DataSource = dt;
                cmbbxName.SelectedIndex = 0;

                rtfDescriptionfeedback.Text = "Write feedback...";
                rtfDescriptionfeedback.ForeColor = Color.Gray;

                rtgOverallRating.ReadOnly = true;
                rtgOverallRating.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading guest list: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxName.SelectedIndex == -1 || string.IsNullOrEmpty(cmbbxName.SelectedValue?.ToString()))
                {
                    MessageBox.Show("Please select a guest name.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtfDescriptionfeedback.Text)
                    || rtfDescriptionfeedback.Text.Trim() == "Write feedback...")
                {
                    MessageBox.Show("Please enter feedback description.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfDescriptionfeedback.Focus();
                    return;
                }

                clsUser objuser = new clsUser();
                objuser.GuestCodePSS = cmbbxName.SelectedValue.ToString();
                objuser.RoomRatingPSS = Convert.ToDecimal(rtgRoom.Value);
                objuser.FoodRatingPSS = Convert.ToDecimal(rtgFood.Value);
                objuser.parkingRatingPSS = Convert.ToDecimal(rtgParking.Value);
                objuser.EventRatingPSS = Convert.ToDecimal(rtgEvent.Value);
                objuser.InventoryRatingPSS = Convert.ToDecimal(rtgInventory.Value);
                objuser.FeedbackDatePSS = DateTime.Now;
                objuser.OverallRatingPSS = Convert.ToDecimal(rtgOverallRating.Value);
                objuser.DescriptionPSS = rtfDescriptionfeedback.Text.Trim();

                objuser.SaveFeedbackPSS();

                MessageBox.Show("Feedback saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmFeedback frm = Application.OpenForms
                              .OfType<frmFeedback>()
                              .FirstOrDefault();

                if (frm != null)
                {
                    frm.LoadGridPSS();
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving feedback: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            try
            {
                cmbbxName.SelectedIndex = 0;
                cmbbxName.ForeColor = Color.Gray;

                rtgRoom.Value = 0;
                rtgFood.Value = 0;
                rtgParking.Value = 0;
                rtgEvent.Value = 0;
                rtgInventory.Value = 0;
                rtgOverallRating.Value = 0;

                rtfDescriptionfeedback.Text = "Write feedback...";
                rtfDescriptionfeedback.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtfDescriptionfeedback_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (rtfDescriptionfeedback.ForeColor == Color.Gray)
                {
                    e.Handled = true;
                    return;
                }

                if (char.IsLetter(e.KeyChar) || char.IsControl(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    MessageBox.Show("Integers are not allowed.", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on key press: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateOverallRating()
        {
            try
            {
                decimal RoomRating = Convert.ToDecimal(rtgRoom.Value);
                decimal FoodRating = Convert.ToDecimal(rtgFood.Value);
                decimal ParkingRating = Convert.ToDecimal(rtgParking.Value);
                decimal EventRating = Convert.ToDecimal(rtgEvent.Value);
                decimal InventoryRating = Convert.ToDecimal(rtgInventory.Value);

                decimal OverallRating = (RoomRating + FoodRating + ParkingRating + EventRating + InventoryRating) / 5;
                rtgOverallRating.Value = (float)Math.Round(OverallRating, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error calculating overall rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgOverallRating_ValueChanged(object sender, EventArgs e) { }
        private void rtfDescriptionfeedback_TextChanged(object sender, EventArgs e) { }
        private void guna2ContainerControl2_Click(object sender, EventArgs e) { }

        private void rtgRoom_ValueChanged(object sender, EventArgs e)
        {
            try { CalculateOverallRating(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating room rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgFood_ValueChanged(object sender, EventArgs e)
        {
            try { CalculateOverallRating(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating food rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgParking_ValueChanged(object sender, EventArgs e)
        {
            try { CalculateOverallRating(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating parking rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgEvent_ValueChanged(object sender, EventArgs e)
        {
            try { CalculateOverallRating(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating event rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgInventory_ValueChanged(object sender, EventArgs e)
        {
            try { CalculateOverallRating(); }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating inventory rating: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtfDescriptionfeedback_Enter(object sender, EventArgs e)
        {
            try
            {
                if (rtfDescriptionfeedback.ForeColor == Color.Gray)
                {
                    rtfDescriptionfeedback.Clear();
                    rtfDescriptionfeedback.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on description focus: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtfDescriptionfeedback_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(rtfDescriptionfeedback.Text))
                {
                    rtfDescriptionfeedback.Text = "Write feedback...";
                    rtfDescriptionfeedback.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on description leave: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label7_Click(object sender, EventArgs e) { }

        private void cmbbxName_DropDown(object sender, EventArgs e)
        {
            try
            {
                cmbbxName.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on dropdown open: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxName_Leave(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxName.SelectedIndex == -1)
                {
                    cmbbxName.Text = "Select Guest Name";
                    cmbbxName.ForeColor = Color.Gray;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on name leave: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rtgOverallRating_MouseClick(object sender, MouseEventArgs e) { }
        private void rtgOverallRating_KeyPress(object sender, KeyPressEventArgs e) { }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error closing form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}