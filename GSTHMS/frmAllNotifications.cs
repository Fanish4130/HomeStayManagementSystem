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
    public partial class frmAllNotificationsVM : Form
    {
        public frmAllNotificationsVM()
        {
            InitializeComponent();
        }
        private void LoadNotificationsVM(string filter)
        {
            try
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetNotificationsVM();

                if (filter == "Unread")
                {
                    DataRow[] unread = dt.Select("IsSeen = 'FALSE'");
                    dt = unread.Length > 0 ? unread.CopyToDataTable() : dt.Clone();
                }
                else if (filter == "Read")
                {
                    DataRow[] read = dt.Select("IsSeen = 'TRUE'");
                    dt = read.Length > 0 ? read.CopyToDataTable() : dt.Clone();
                }

                // ✅ Create a new table with all required columns
                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("NotificationID", typeof(int));
                displayTable.Columns.Add("Sr.No");
                displayTable.Columns.Add("Title");
                displayTable.Columns.Add("Date");
                displayTable.Columns.Add("Description");
                displayTable.Columns.Add("IsSeen", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    string dateText = "";
                    if (row["Date"] != DBNull.Value && DateTime.TryParse(row["Date"].ToString(), out DateTime d))
                        dateText = d.ToString("g");

                    displayTable.Rows.Add(
                        row["NotificationID"],
                        row["Sr.No"],
                        row["Title"]?.ToString() ?? "",
                        dateText,
                        row["Description"]?.ToString() ?? "",
                        row["IsSeen"]?.ToString()?.ToUpper() ?? "FALSE"
                    );
                }

                grdAllNotificationsVM.DataSource = displayTable;

                // ✅ Optional: hide IsSeen column if you don’t want to show it
                if (grdAllNotificationsVM.Columns["IsSeen"] != null)
                    grdAllNotificationsVM.Columns["IsSeen"].Visible = false;

                if (grdAllNotificationsVM.Columns["NotificationID"] != null)
                    grdAllNotificationsVM.Columns["NotificationID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading notifications:\n" + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAllNotifications_Load(object sender, EventArgs e)
        {
            this.grdAllNotificationsVM.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdAllNotificationsVM.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            cmbbxFilterVM.SelectedIndex = 0;

            LoadNotificationsVM("All");
            // Auto-size all columns to fill the grid width
            grdAllNotificationsVM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Prevent extra white space by disabling row headers if not needed
            grdAllNotificationsVM.RowHeadersVisible = false;

            grdAllNotificationsVM.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            grdAllNotificationsVM.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            grdAllNotificationsVM.RowPrePaint += grdAllNotifications_RowPrePaint;
        }


        private void grdAllNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var row = grdAllNotificationsVM.Rows[e.RowIndex];
                if (row.Cells["NotificationID"]?.Value == null) return;

                int notificationId = Convert.ToInt32(row.Cells["NotificationID"].Value);

                //frmMaintenanceNotification frm = new frmMaintenanceNotification(notificationId);
                //frm.Show();

                clsUser obj = new clsUser();
                obj.notificationIdVM = notificationId;
                obj.MarkAsReadVM();
                
                MessageBox.Show("Notification marked as read.");

                string selectedFilter = cmbbxFilterVM.SelectedItem?.ToString() ?? "All";
                LoadNotificationsVM(selectedFilter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while processing notification: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdAllNotifications_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            var row = grdAllNotificationsVM.Rows[e.RowIndex];
            if (row.Cells["IsSeen"]?.Value == null) return;

            bool isSeen = row.Cells["IsSeen"].Value.ToString().ToUpper() == "TRUE";

            if (isSeen)
            {
                row.DefaultCellStyle.ForeColor = Color.Gray;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            }
            else
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxFilterVM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbbxFilterVM.SelectedItem.ToString();
            LoadNotificationsVM(selectedFilter);
        }

        private void pnlMainAllNotificationVM_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
