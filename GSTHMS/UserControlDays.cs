using System;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class UserControlDays : UserControl
    {
        public DateTime FullDate { get; set; }

        public UserControlDays()
        {
            try
            {
                InitializeComponent();

                // When clicking inside label/panel
                foreach (Control ctrl in this.Controls)
                {
                    ctrl.Click += Child_Click;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void SetDayNumber(int num)
        {
            try
            {
                lbldays.Text = num.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // This sends click to the USERCONTROL (not to itself again)
        private void Child_Click(object sender, EventArgs e)
        {
            try
            {
                this.InvokeOnClick(this, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}