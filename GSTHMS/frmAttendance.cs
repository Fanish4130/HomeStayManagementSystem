using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using WinTimer = System.Windows.Forms.Timer;

namespace GSTHMS
{
    public partial class frmAttendance : Form
    {
        public string TotalHoursRP { get; set; }
        string staffCode;

        public frmAttendance()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbxemployeid.SelectedIndex == -1 || cmbxemployeid.SelectedValue == null)
                {
                    MessageBox.Show("Please select Staff Name.",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbxemployeid.Focus();
                    return;
                }

                if (!rdbbtnPresent.Checked && !rdbbtnAbsent.Checked && !rdbbtnonleave.Checked)
                {
                    MessageBox.Show("Please select Attendance Status",
                        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpDate.Value.Date != DateTime.Today.Date)
                {
                    MessageBox.Show("Attendance can only be marked for Today.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    dtpDate.Value = DateTime.Today;
                    return;
                }

                if (dtpDate.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Future dates are not Allowed.",
                        "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime checkIn = dtpCheckin.Value;
                DateTime checkOut = dtpCheckout.Value;
                string totalHours = "00:00";

                if (rdbbtnAbsent.Checked || rdbbtnonleave.Checked)
                {
                    checkIn = dtpDate.Value.Date;
                    checkOut = dtpDate.Value.Date;
                    totalHours = "00:00";
                }
                else
                {
                    if (checkOut.TimeOfDay <= checkIn.TimeOfDay)
                    {
                        if (checkOut.TimeOfDay.TotalHours < 12)
                            checkOut = checkOut.AddHours(12);
                    }

                    if (checkOut <= checkIn)
                    {
                        MessageBox.Show("Check-Out time must be later than Check-In.",
                            "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    TimeSpan workingHours = checkOut - checkIn;
                    totalHours = workingHours.ToString(@"hh\:mm");
                }

                clsUser obj = new clsUser();

                obj.StaffCodeRP = staffCode;
                obj.AttendDateRP = dtpDate.Value.Date;

                if (obj.IsAttendanceExistsRP())
                {
                    MessageBox.Show(
                        "This staff attendance is already added for Today",
                        "Duplicate Attendance",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                if (rdbbtnPresent.Checked)
                    obj.statusIDRP = 32;
                else if (rdbbtnAbsent.Checked)
                    obj.statusIDRP = 33;
                else if (rdbbtnonleave.Checked)
                    obj.statusIDRP = 36;

                obj.CheckInRP = checkIn;
                obj.CheckOutRP = checkOut;
                obj.TotalHoursRP = totalHours;

                obj.AddAttendanceRP();

                MessageBox.Show(
                    "Attendance Added Successfully!\nTotal Working Hours: " + totalHours,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "An error occurred: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error
                );
            }
        }

        private void connAttendace1_Click(object sender, EventArgs e)
        {
            try
            {
                dtpCheckin.Format = DateTimePickerFormat.Custom;
                dtpCheckin.CustomFormat = "hh:mm tt";
                dtpCheckin.ShowUpDown = true;

                dtpCheckout.Format = DateTimePickerFormat.Custom;
                dtpCheckout.CustomFormat = "hh:mm tt";
                dtpCheckout.ShowUpDown = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                dtpDate.Format = DateTimePickerFormat.Custom;
                dtpDate.CustomFormat = "dd MMMM yyyy";
                dtpDate.Value = DateTime.Today;

                dtpCheckin.Format = DateTimePickerFormat.Custom;
                dtpCheckin.CustomFormat = "HH:mm:ss";
                dtpCheckin.ShowUpDown = true;
                dtpCheckin.Value = DateTime.Now;

                dtpCheckout.Format = DateTimePickerFormat.Custom;
                dtpCheckout.CustomFormat = "HH:mm:ss";
                dtpCheckout.ShowUpDown = true;
                dtpCheckout.Value = dtpCheckin.Value.AddHours(9);

                clsUser objs = new clsUser();
                DataTable dt = objs.AddemployeeRP();

                cmbxemployeid.DisplayMember = "StaffName";
                cmbxemployeid.ValueMember = "StaffCode";
                cmbxemployeid.DataSource = dt;
                cmbxemployeid.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cmbxemployeid.Text))
                {
                    MessageBox.Show("Please enter Employee ID.");
                    cmbxemployeid.Focus();
                    return false;
                }

                if (dtpDate.Value == null)
                {
                    MessageBox.Show("Please select a date.");
                    return false;
                }

                if (dtpCheckin.Value == null)
                {
                    MessageBox.Show("Please select Check-In time.");
                    return false;
                }

                if (dtpCheckout.Value == null)
                {
                    MessageBox.Show("Please select Check-Out time.");
                    return false;
                }

                if (!rdbbtnPresent.Checked && !rdbbtnAbsent.Checked && !rdbbtnonleave.Checked)
                {
                    MessageBox.Show("Please select status (Present / Absent / On Leave).");
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void ClearControls(Control c)
        {
            try
            {
                if (c is System.Windows.Forms.TextBox)
                    (c as System.Windows.Forms.TextBox).Clear();

                if (c.GetType().Name == "Guna2TextBox")
                    c.Text = "";

                if (c is RichTextBox)
                    (c as RichTextBox).Clear();

                if (c is System.Windows.Forms.ComboBox)
                    (c as System.Windows.Forms.ComboBox).SelectedIndex = -1;

                if (c.GetType().Name == "Guna2ComboBox")
                    c.Text = "";

                if (c is DateTimePicker)
                    (c as DateTimePicker).Value = DateTime.Now;

                if (c.GetType().Name == "Guna2DateTimePicker")
                    c.GetType().GetProperty("Value").SetValue(c, DateTime.Now);

                if (c is CheckBox)
                    (c as CheckBox).Checked = false;

                if (c.GetType().Name == "Guna2CheckBox")
                    c.GetType().GetProperty("Checked").SetValue(c, false);

                if (c is RadioButton)
                    (c as RadioButton).Checked = false;

                if (c.GetType().Name == "Guna2RadioButton")
                    c.GetType().GetProperty("Checked").SetValue(c, false);

                if (c is DataGridView)
                    (c as DataGridView).ClearSelection();

                foreach (Control child in c.Controls)
                    ClearControls(child);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                cmbxemployeid.SelectedIndex = -1;
                cmbxemployeid.Text = "";

                dtpDate.Value = DateTime.Today;

                dtpCheckin.Value = DateTime.Now;
                dtpCheckout.Value = DateTime.Now;

                rdbbtnPresent.Checked = false;
                rdbbtnAbsent.Checked = false;
                rdbbtnonleave.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rdbbtnAbsent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbxemployeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsUser obj = new clsUser();

                if (cmbxemployeid.SelectedValue != null)
                {
                    System.Data.DataRowView selectedRow =
                        (System.Data.DataRowView)cmbxemployeid.SelectedItem;

                    staffCode = selectedRow["StaffCode"].ToString();
                }

                obj.StaffCodeRP = staffCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connAttendace1_Click_1(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpCheckin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpCheckout.Value = dtpCheckin.Value.AddHours(9);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpCheckout_ValueChanged(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}