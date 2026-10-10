using System;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmupdateAttendance : Form
    {
        public string StaffCodeRP { get; set; }
        public string StaffName { get; set; }
        public string CheckIn { get; set; }
        public DateTime AttendDate { get; set; }

        public frmupdateAttendance(string staffCode, string staffName, DateTime attendDate, string checkIn)
        {
            try
            {
                InitializeComponent();

                StaffCodeRP = staffCode;
                StaffName = staffName;
                AttendDate = attendDate;
                CheckIn = checkIn;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmupdateAttendance_Load(object sender, EventArgs e)
        {
            try
            {
                GetInfoSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GetInfoSC()
        {
            try
            {
                lblstaffname1.Text = StaffName;
                lbldate11.Text = AttendDate.ToString("dd-MM-yyyy");
                lblcheckin.Text = CheckIn;
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

        private void btnupdate1_Click(object sender, EventArgs e)
        {
            try
            {
                clsUser obj = new clsUser();
                obj.StaffCodeRP = StaffCodeRP;
                obj.AttendDateRP = AttendDate;
                obj.CheckInRP = DateTime.Parse(lblcheckin.Text);
                obj.CheckOutRP = DateTime.Parse(dtpCheckout.Text);

                obj.UpdateARP();

                MessageBox.Show("Attendance Updated Successfully",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                    "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void connAttendace1_Click(object sender, EventArgs e)
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                var result = MessageBox.Show(
                    "Do you want to clear checkout time?",
                    "Confirm",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dtpCheckout.Value = DateTime.Now;

                    MessageBox.Show("Checkout time cleared successfully!",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}