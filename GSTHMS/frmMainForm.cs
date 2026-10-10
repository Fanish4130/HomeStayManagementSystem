using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSTHMS.clsUser;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GSTHMS
{
    public partial class frmMainForm : Form
    {

        public frmMainForm()
        {

            InitializeComponent();


        }

        Form background;
        private void frmMainForm_Load(object sender, EventArgs e)
        {
            try
            {
                guna2MessageDialog1.Parent = this;

                clsUser clsUser = new clsUser();
                lblTotalRoomsCount.Text = clsUser.GetTotalRoomsSY().ToString(); /* for get Total Rooms Count on card */

                lblAvailableRoomsCount.Text = clsUser.GetAvailableRoomsSY().ToString(); /* for get Available Rooms Count on card */

                lblOccupiedRoomsCount.Text = clsUser.GetOccupiedRoomsSY().ToString();/* for get Occupied Rooms Count on card */

                lblCleaningCount.Text = clsUser.GetCleaningRoomsSY().ToString();/* for get Cleaning Rooms Count on card */

                lblCheckInTodayCount.Text = clsUser.CheckInTodaySY().ToString();/* for get Check-In-Today Count on card */

                lblCheckOutTodayCount.Text = clsUser.CheckOutTodaySY().ToString();/* for get Check-Out-Today Count on card */

                CardsDisplaySY();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in main form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // REPLACE your existing CardsDisplaySY() with this:
        public void CardsDisplaySY()
        {
            try
            {
                // Check if flowRoomCards exists
                if (flowRoomCards == null)
                {
                    // Fallback to old method if container not found
                    return;
                }

                flowRoomCards.Controls.Clear();

                clsUser clsUser = new clsUser();
                DataTable dtRooms = clsUser.GetDynamicRoomCardsSY();

                if (dtRooms != null && dtRooms.Rows.Count > 0)
                {
                    foreach (DataRow row in dtRooms.Rows)
                    {
                        string roomName = row["RoomName"].ToString();
                        string roomType = row["RoomTypeName"].ToString();
                        string status = row["Status"].ToString();

                        CreateRoomCard(roomName, roomType, status);
                    }
                }
                else
                {
                    Label lblNoRooms = new Label();
                    lblNoRooms.Text = "No rooms found in database";
                    lblNoRooms.ForeColor = Color.Gray;
                    lblNoRooms.TextAlign = ContentAlignment.MiddleCenter;
                    lblNoRooms.Size = new Size(200, 50);
                    flowRoomCards.Controls.Add(lblNoRooms);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CardsDisplay: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Add these new methods in frmMainForm.cs:

        private void CreateRoomCard(string roomName, string roomType, string status)
        {
            Panel cardPanel = new Panel();
            cardPanel.Size = new Size(120, 110);
            cardPanel.Margin = new Padding(7);
            cardPanel.BackColor = Color.LightCyan;  // LightCyan background
            //cardPanel.BorderStyle = BorderStyle.FixedSingle;

            Label lblRoomName = new Label();
            lblRoomName.Text = roomName;
            lblRoomName.Location = new Point(5, 5);
            lblRoomName.Size = new Size(110, 28);
            lblRoomName.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblRoomName.ForeColor = Color.Black;

            Label lblRoomType = new Label();
            lblRoomType.Text = roomType;
            lblRoomType.Location = new Point(5, 33);
            lblRoomType.Size = new Size(110, 20);
            lblRoomType.TextAlign = ContentAlignment.MiddleCenter;
            lblRoomType.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblRoomType.ForeColor = Color.DimGray;

            Guna2Button btnStatus = new Guna2Button();
            btnStatus.Text = status;
            btnStatus.Size = new Size(102, 32);
            btnStatus.Location = new Point(10, 58);
            btnStatus.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnStatus.ForeColor = Color.Black;
            btnStatus.Cursor = Cursors.Hand;
            btnStatus.Tag = roomName;
            btnStatus.BorderRadius = 10;  // Round corners for button
            btnStatus.BorderThickness = 0;

            switch (status)
            {
                case "Available":
                    btnStatus.FillColor = Color.SpringGreen;
                    break;
                case "Cleaning":
                    btnStatus.FillColor = Color.Orange;
                    break;
                case "Occupied":
                    btnStatus.FillColor = Color.OrangeRed;
                    break;
                case "Unclean":
                    btnStatus.FillColor = Color.Peru;
                    break;
                default:
                    btnStatus.FillColor = Color.Gray;
                    break;
            }

            btnStatus.Click += RoomButton_Click;

            cardPanel.Controls.Add(lblRoomName);
            cardPanel.Controls.Add(lblRoomType);
            cardPanel.Controls.Add(btnStatus);
            flowRoomCards.Controls.Add(cardPanel);
        }

        private void RoomButton_Click(object sender, EventArgs e)
        {
            var btn = sender as Guna2Button;
            if (btn == null) return;

            btn.Checked = false;
            string roomName = btn.Tag.ToString();

            if (ModifierKeys == Keys.Control)
            {
                ChangeRoomStatus(roomName, btn);
                return;
            }
            LoadRoomInfoSY(roomName);
        }

        // Keep your existing ChangeRoomStatus, LoadRoomInfoSY methods as they are

        // Fallback method if flowRoomCards doesn't exist
        //private void FallbackCardsDisplay()
        //{
        //    try
        //    {
        //        clsUser clsUser = new clsUser();
        //        DataTable dt8 = clsUser.ShowRoomOverviewOnCardSY();
        //        if (dt8.Rows.Count > 0)
        //        {
        //            //Label[] roomLables = {  lblR102, lblR103, lblR104, lblR105, lblR106, lblR107, lblR108, lblR109, lblR110, lblR111, lblR112, lblR113, lblR114, lblR115, lblR116, lblR117, lblR118, lblR119, lblR120, lblR121, lblR122, lblR123, lblR124 };
        //            //Guna2Button[] roomStatus = {  btn102, btn103, btn104, btn105, btn106, btn107, btn108, btn109, btn110, btn111, btn112, btn113, btn114, btn115, btn116, btn117, btn118, btn119, btn120, btn121, btn122, btn123, btn124 };

        //            //for (int i = 0; i < dt8.Rows.Count && i < 24; i++)
        //            //{
        //            //    string roomName = dt8.Rows[i]["RoomName"].ToString();
        //            //    string Status = dt8.Rows[i]["Status"].ToString();

        //            //    roomLables[i].Text = roomName;
        //            //    roomStatus[i].Text = Status;
        //            //    switch (Status)
        //            //    {
        //            //        case "Available":
        //            //            roomStatus[i].FillColor = Color.SpringGreen;
        //            //            break;
        //            //        case "Cleaning":
        //            //            roomStatus[i].FillColor = Color.Orange;
        //            //            break;
        //            //        case "Occupied":
        //            //            roomStatus[i].FillColor = Color.OrangeRed;
        //            //            break;
        //            //        case "Unclean":
        //            //            roomStatus[i].FillColor = Color.Peru;
        //            //            break;
        //            //    }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in FallbackCardsDisplay: " + ex.Message);
        //    }
        //}


        private void ChangeRoomStatus(string roomName, Guna2Button btn)
        {
            string currentStatus = btn.Text.Trim().ToLower();

            clsUser obj = new clsUser();
            obj.RoomNameSY = roomName;

            
            if (currentStatus == "unclean")
            {
                DialogResult result = MessageBox.Show(
                    "This room is currently marked as Unclean.\n\nDo you want to move it to Cleaning status?",
                    "🧹 Housekeeping Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    obj.StatusIDSY = 18; 
                    obj.UpdateRoomStatusSY();

                    MessageBox.Show(
                        "The room has been successfully moved to Cleaning status.",
                        "✅ Status Updated",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CardsDisplaySY();
                }
            }
            else if (currentStatus == "cleaning")
            {
                DialogResult result = MessageBox.Show(
                    "Cleaning has been completed for this room.\n\nDo you want to mark it as Available?",
                    "🏠 Room Ready",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2);

                if (result == DialogResult.Yes)
                {
                    obj.StatusIDSY = 16; // Available Status ID
                    obj.UpdateRoomStatusSY();

                    MessageBox.Show(
                        "The room is now available for booking.",
                        "✅ Room Available",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    CardsDisplaySY();
                }
            }
            else
            {
                return;
            }
        }
        private void btnAllRoomList_Click(object sender, EventArgs e)
        {
            frmRoomList objRoomList = new frmRoomList();
            objRoomList.Show();
        }

        public void LoadRoomInfoSY(string roomName)
        {
            try
            {
                clsUser clsUser = new clsUser();
                clsUser.RoomNameSY = roomName;

                DataTable dt9 = clsUser.ShowRoomInfoOnFormSY();

                if (dt9 != null && dt9.Rows.Count > 0)
                {
                    frmRoomDetails frm = new frmRoomDetails();

                    frm.RoomNameSY = dt9.Rows[0]["RoomName"].ToString();
                    frm.RoomTypeSY = dt9.Rows[0]["RoomTypeName"].ToString();
                    frm.BasePriceSY = dt9.Rows[0]["BasePrice"].ToString();
                    frm.CapacitySY = dt9.Rows[0]["Capacity"].ToString();
                    frm.AmentitiesSY = dt9.Rows[0]["Amenities"].ToString();
                    frm.DescriptionSY = dt9.Rows[0]["Description"].ToString();

                    //background = new Form();
                    //background.StartPosition = FormStartPosition.Manual;
                    //background.FormBorderStyle = FormBorderStyle.None;
                    //background.Opacity = 0.6;
                    //background.BackColor = System.Drawing.Color.Black;
                    //background.WindowState = FormWindowState.Maximized;
                    //background.TopMost = true;
                    //background.Show();

                    //frm.StartPosition = FormStartPosition.CenterScreen;
                    //frm.TopMost = true;
                    //frm.FormClosed += (s, args) =>
                    //{
                    //    background.Close();
                    //    this.Enabled = true;
                    //    this.Opacity = 1;
                    //};
                    frm.Show();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LoadRoomInfoSY: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


       


        private void pnlTotalRoom_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblTotalRoom1.Text);
            frmcardsinfo.Show();
        }

        private void pnlAvailableRooms_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblAvailableRooms.Text);
            frmcardsinfo.Show();
        }

        private void pnlOccupiedRooms_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblOccupiedRooms.Text);
            frmcardsinfo.Show();
        }

        private void pnlCleaning_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblCleaning.Text);
            frmcardsinfo.Show();
        }

        private void pnlCheckInToday_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblCheckInToday.Text);
            frmcardsinfo.Show();
        }

        private void pnlCheckOutToday_Click_1(object sender, EventArgs e)
        {
            frmcardsinfo frmcardsinfo = new frmcardsinfo(lblCheckOutToday.Text);
            frmcardsinfo.Show();
        }

        private void pnlcard_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

    

