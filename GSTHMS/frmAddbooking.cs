using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmAddbooking : Form
    {
        private bool isLoading = true;
        public string BasePriceFL;
        public int ParkingSlotIDFL;
        private bool isHandling = false;
        clsUser obj = new clsUser();

        public frmAddbooking()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            cmbbxAgentNameFL.SelectedIndex = -1;
            cmbbxvehicletypeFL.SelectedIndex = -1;
            cmbbxparkingslotFL.SelectedIndex = -1;
            dtpCheckinFL.Value = DateTime.Today;
            dtpCheckinFL.Enabled = false;
            dtpcheckoutFL.MinDate = DateTime.Today;
            isLoading = true;

            connAgent.Visible = false;
            connVehicle.Visible = false;

            // Compact size
            this.Width = 460;

            // Load guest data
            clsUser obj = new clsUser();
            DataTable dt = new DataTable();
            dt = obj.FetchGuestFL();

            DataRow dr = dt.NewRow();
            dr["GuestCode"] = 0;
            dr["GuestName"] = "-- Select Guest --";
            dt.Rows.InsertAt(dr, 0);    

            cmbbxguestnameFL.DisplayMember = "GuestName";
            cmbbxguestnameFL.ValueMember = "GuestCode";
            cmbbxguestnameFL.DataSource = dt;
            
            cmbbxguestnameFL.Show();


            dt = obj.FetchAgentsFL();

            DataRow dr1 = dt.NewRow();
            dr1["AgentCode"] = 0;
            dr1["AgentName"] = "-- Select Agent --";
            dt.Rows.InsertAt(dr1, 0);

            cmbbxAgentNameFL.DisplayMember = "AgentName";
            //cmbbxAgentNameFL.ValueMember = "AgentCode";
            cmbbxAgentNameFL.ValueMember = "AgentCode";
            cmbbxAgentNameFL.DataSource = dt;
            cmbbxAgentNameFL.Show();

            // Load room type data
            clsUser objRt = new clsUser();
            DataTable dt1 = objRt.FetchRoomTypeFL();

            // ✅ ALWAYS NewRow from SAME DataTable
            DataRow do1 = dt1.NewRow();
            do1["RoomTypeID"] = 0;
            do1["RoomTypeName"] = "-- Select Room Type --";
            dt1.Rows.InsertAt(do1, 0);

            cmbbxroomtypeFL.DisplayMember = "RoomTypeName";
            cmbbxroomtypeFL.ValueMember = "RoomTypeID";
            cmbbxroomtypeFL.DataSource = dt1;
            cmbbxroomtypeFL.Show();



            dt = obj.FetchVehicleTypeFL();

            DataRow drv = dt.NewRow();
            drv["vehicleTypeID"] = 0;
            drv["VehicleType"] = "-- Select Vehicle --";
            dt.Rows.InsertAt(drv, 0);

            cmbbxvehicletypeFL.DisplayMember = "VehicleType";
            cmbbxvehicletypeFL.ValueMember = "vehicleTypeID";
            cmbbxvehicletypeFL.DataSource = dt;
            cmbbxvehicletypeFL.Show();

            dt = obj.FetchOfferFL();

            DataRow do2 = dt.NewRow();
            do2["OfferID"] = 0;
            do2["OfferName"] = "-- Select Offer Name --";
            dt.Rows.InsertAt(do2, 0);

            cmbbxOfferFL.DisplayMember = "OfferName";
            cmbbxOfferFL.ValueMember = "OfferID";
            cmbbxOfferFL.DataSource = dt;

            isLoading = false;

        }




        //private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (isHandling) return;

        //    isHandling = true;

        //    if (chkisagentFL.Checked)
        //    {
        //        connAgent.Visible = true;
        //        chkisagentnoFL.Checked = false;
        //    }
        //    else
        //    {
        //        connAgent.Visible = false;
        //    }

        //    isHandling = false;
        //}

        private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandling) return;

            isHandling = true;

            connAgent.Visible = chkisagentFL.Checked;

            if (chkisagentFL.Checked)
                chkisagentnoFL.Checked = false;

            AdjustFormWidthFL();

            isHandling = false;
        }
        private int availableQty = 0;
        private void cmbbxroomtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RoomTypeIDFL = Convert.ToInt32(cmbbxroomtypeFL.SelectedValue);
            clsUser objRn = new clsUser();
            DataTable dt2 = new DataTable();
            objRn.roomTypeIDFL = RoomTypeIDFL;
            dt2 = objRn.GetRoomnameByRoomTypeFL();

            // ✅ ALWAYS NewRow from SAME DataTable
            DataRow do1 = dt2.NewRow();
            do1["RoomID"] = 0;
            do1["RoomName"] = "-- Select Room Name --";
            dt2.Rows.InsertAt(do1, 0);

            cmbbxroomnameFL.DisplayMember = "RoomName";
            cmbbxroomnameFL.ValueMember = "RoomID";
            cmbbxroomnameFL.DataSource = dt2;
            cmbbxroomnameFL.Show();

            if (cmbbxroomnameFL.SelectedIndex != -1)
            {
                clsUser user = new clsUser();
                user.RoomTypeNameFL = cmbbxroomtypeFL.Text;
                user.FetchRoomPriceFL();
                lblRoomPFL.Text = $"₹{user.BasePriceFL:N0}";

            }
            //---------------Room Capacity Check-----------------
            if (cmbbxroomtypeFL.SelectedIndex != -1)
            {
                string selectedInventory = cmbbxroomtypeFL.Text;

                clsUser obj = new clsUser();
                obj.RoomTypeFL = selectedInventory;
                DataTable dtQty = obj.GetRCapacityFL();
                if (dtQty.Rows.Count > 0)
                {
                    availableQty = Convert.ToInt32(dtQty.Rows[0]["Capacity"]);
                    txtonofguestFL.MaxLength = availableQty;
                }
                else
                {
                    availableQty = 0;
                }
            }
        }

        //private void chkisvehicle_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (isHandling) return;

        //    isHandling = true;

        //    if (chkisvehicleFL.Checked)
        //    {
        //        connVehicle.Visible = true;
        //        chkisvehiclenoFL.Checked = false;
        //    }
        //    else
        //    {
        //        connVehicle.Visible = false;
        //    }

        //    isHandling = false;
        //}

        private void chkisvehicle_CheckedChanged(object sender, EventArgs e)
        {
            if (isHandling) return;

            isHandling = true;

            connVehicle.Visible = chkisvehicleFL.Checked;

            if (chkisvehicleFL.Checked)
                chkisvehiclenoFL.Checked = false;

            AdjustFormWidthFL();

            isHandling = false;
        }

        private void btnbook_Click(object sender, EventArgs e)
        {
            // ---------------- GUEST ----------------
            if (cmbbxguestnameFL.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select a guest.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxguestnameFL.Focus();
                return;
            }
           
            // ---------------- ROOM NAME ----------------
            if (cmbbxroomnameFL.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select room name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxroomnameFL.Focus();
                return;
            }

            // ---------------- OFFER ----------------
            if (cmbbxOfferFL.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select an offer.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxOfferFL.Focus();
                return;
            }

            // ---------------- AGENT ----------------
            if (chkisagentFL.Checked && cmbbxAgentNameFL.SelectedIndex <= 0)
            {
                MessageBox.Show("Please select agent name.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbbxAgentNameFL.Focus();
                return;
            }

            // ---------------- VEHICLE ----------------
            if (chkisvehicleFL.Checked)
            {
                if (cmbbxvehicletypeFL.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select vehicle type.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxvehicletypeFL.Focus();
                    return;
                }

                if (cmbbxparkingslotFL.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select parking slot.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxparkingslotFL.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtVehicleNoFL.Text))
                {
                    MessageBox.Show("Please enter vehicle number.",
                                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVehicleNoFL.Focus();
                    return;
                }
            }

            // ---------------- TERMS ----------------
            if (!chktermsandconditionFL.Checked)
            {
                MessageBox.Show("Please accept Terms & Conditions.",
                                "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ================= ALL VALID =================
            clsUser obj = new clsUser();
            SaveBooking();
          
        }

        private void SaveBooking()
        {
            obj.GuestCodeFL = cmbbxguestnameFL.SelectedValue.ToString();
            obj.RoomIDFL = Convert.ToInt32(cmbbxroomnameFL.SelectedValue);
            obj.NoOfGuestFL = Convert.ToInt32(txtonofguestFL.Text);

            obj.CheckInFL = dtpCheckinFL.Value;
            obj.CheckOutFL = dtpcheckoutFL.Value;
            obj.CheckInFL = dtpCheckinFL.Value;
            obj.checkInTimeFL = DateTime.Now.TimeOfDay;
            obj.checkOutTimeFL = DateTime.Now.TimeOfDay;


            // AGENT
            obj.agentCodeFL = chkisagentFL.Checked
                ? cmbbxAgentNameFL.SelectedValue.ToString()
                : null;

            // VEHICLE
            if (chkisvehicleFL.Checked)
            {
                obj.ParkingSlotID = Convert.ToInt32(cmbbxparkingslotFL.SelectedValue);
                obj.VehicleNoFL = txtVehicleNoFL.Text.Trim();
                obj.VehicleTypeNoFL = Convert.ToInt32(cmbbxvehicletypeFL.SelectedValue);
            }
            else
            {
                obj.ParkingSlotID = 0;   // ✅ NOT NULL SAFE
                obj.VehicleNoFL = null;
            }

            // OFFER
            obj.offerIDFL = Convert.ToInt32(cmbbxOfferFL.SelectedValue);


            string code = obj.AddBookingFL();

            if (Application.OpenForms["frmBooking"] != null)
            {
                frmBooking frm = (frmBooking)Application.OpenForms["frmBooking"];
                frm.RefreshBookingGridFL();   // ✅ AUTO REFRESH GRID
            }

            MessageBox.Show("Booking Saved Successfully : " + code,
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

           

            this.Close();
        }



        private void cmbbxvehicletypeFL_SelectedIndexChanged(object sender, EventArgs e)
        {
            int VehicleTypeIDFL = Convert.ToInt32(cmbbxvehicletypeFL.SelectedValue.ToString());
                clsUser obj = new clsUser();
                obj.VehicleTypeIDFL = VehicleTypeIDFL;

                DataTable dt1 = obj.FetchParkingSlotFL();
            DataRow do1 = dt1.NewRow();
            do1["ParkingSlotID"] = 0;
            do1["SlotName"] = "-- Select Slot --";
            dt1.Rows.InsertAt(do1, 0);

            cmbbxparkingslotFL.DisplayMember = "SlotName";
                cmbbxparkingslotFL.ValueMember = "ParkingSlotID";
                cmbbxparkingslotFL.DataSource = dt1;
            
        }

        private void btnsaveagentnameFL_Click(object sender, EventArgs e)
        {
            connAgent.Visible = false;
        }

        private void btnSaveFL_Click(object sender, EventArgs e)
        {
            connVehicle.Visible = false;
        }

        private bool isGuestMsgShown = false;

        private void txtonofguestFL_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtonofguestFL.Text))
                return;

            // ROOM TYPE NOT SELECTED
            if (cmbbxroomtypeFL.SelectedIndex <= 0)
            {
                if (!isGuestMsgShown)
                {
                    MessageBox.Show("Please select Room Type first.");
                    isGuestMsgShown = true;
                }
                txtonofguestFL.Clear();
                return;
            }

            isGuestMsgShown = false;

            if (!int.TryParse(txtonofguestFL.Text, out int noOfGuests))
                return;

            string roomType = cmbbxroomtypeFL.Text;

            switch (roomType)
            {
                case "Single":
                    if (noOfGuests != 1)
                    {
                        MessageBox.Show("Single room allows only 1 guest.");
                        txtonofguestFL.Text = "1";
                    }
                    break;

                case "Standard":
                    if (noOfGuests < 1 || noOfGuests > 2)
                    {
                        MessageBox.Show("Standard room allows 1 or 2 guests.");
                        txtonofguestFL.Clear();
                    }
                    break;

                case "Family":
                    if (noOfGuests < 1 || noOfGuests >= 5)
                    {
                        MessageBox.Show("Family room allows up to 4 guests.");
                        txtonofguestFL.Text = "4";
                    }
                    break;

                case "Hall":
                    if (noOfGuests < 1 || noOfGuests > 21)
                    {
                        MessageBox.Show("Hall allows up to 20 guests.");
                        txtonofguestFL.Text = "20";
                    }
                    break;
            }
        }


        private void btnclearFL_Click(object sender, EventArgs e)
        {
            cmbbxroomtypeFL.SelectedIndex = -1;
            cmbbxroomnameFL.SelectedIndex = -1;
            cmbbxAgentNameFL.SelectedIndex = -1;
            cmbbxguestnameFL.SelectedIndex = -1;
            cmbbxOfferFL.SelectedIndex = -1;
            txtonofguestFL.Text = "";
        }

        //private void chkisvehiclenoFL_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (isHandling) return;

        //    isHandling = true;

        //    if (chkisvehiclenoFL.Checked)
        //    {
        //        chkisvehicleFL.Checked = false;
        //        connVehicle.Visible = false;
        //    }

        //    isHandling = false;
        //}

        private void chkisvehiclenoFL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkisvehiclenoFL.Checked)
            {
                chkisvehicleFL.Checked = false;
                connVehicle.Visible = false;

                AdjustFormWidthFL();
            }
        }

        //private void chkisagentnoFL_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (isHandling) return;

        //    isHandling = true;

        //    if (chkisagentnoFL.Checked)
        //    {
        //        chkisagentFL.Checked = false;
        //        connAgent.Visible = false;
        //    }

        //    isHandling = false;
        //}

        private void chkisagentnoFL_CheckedChanged(object sender, EventArgs e)
        {
            if (chkisagentnoFL.Checked)
            {
                chkisagentFL.Checked = false;
                connAgent.Visible = false;

                AdjustFormWidthFL();
            }
        }

        private void txtonofguestFL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // block the key
                                  // No popup here, just silently ignore non-digit input
            }
        }

        private void PctBackFL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxguestnameFL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AdjustFormWidthFL()
        {
            // Default compact size
            int formWidth = 460;

            // Only one panel open
            if (connAgent.Visible || connVehicle.Visible)
                formWidth = 600;

            // Both panels open
            if (connAgent.Visible && connVehicle.Visible)
                formWidth = 900;

            this.Width = formWidth;
        }

        private void chktermsandconditionFL_CheckedChanged(object sender, EventArgs e)
        {
            frmTerms_ConditionsVM obj=new frmTerms_ConditionsVM();
            obj.Show();
        }
    }
}
