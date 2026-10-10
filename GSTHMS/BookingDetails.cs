using ClosedXML.Excel;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmBookingDetails : Form
    {
        public string BookingCodeFL { get; set; }

        public frmBookingDetails()
        {
            InitializeComponent();
        }

        // ================= Safe DBNull Handler =================
        private string SafeValue(object value, string defaultText = "N/A")
        {
            return value == DBNull.Value ? defaultText : value.ToString();
        }

        private void BookingDetails_Load(object sender, EventArgs e)
        {
            clsUser detailsFL = new clsUser();
            detailsFL.BookingCodeFL = BookingCodeFL;
            DataTable dt = detailsFL.FetchBookingFullDetailsFL();
            
            if (dt.Rows.Count == 0) return;

            DataRow dr = dt.Rows[0];

            // ================= Guest =================
            lblGNameFL.Text = SafeValue(dr["GuestName"]);
            lblGContactFL.Text = SafeValue(dr["ContactNo"]);
            lblGEmailFL.Text = SafeValue(dr["GuestEmail"]);
            lblGAddressFL.Text = SafeValue(dr["GuestAddress"]);
            lblGGenderFL.Text = SafeValue(dr["GuestGender"]);
            lblNoOfGFL.Text = SafeValue(dr["No_of_Guest"]);

            // ================= Agent =================
            lblAGTNameFL.Text = SafeValue(dr["AgentName"]);
            lblAGTComissionFL.Text = SafeValue(dr["Commission_Rs"]);
            lblAEmailFL.Text = SafeValue(dr["AgentEmail"]);

            // ================= Room =================
            lblGRoomTypeFL.Text = SafeValue(dr["RoomTypeName"]);
            lblGRoomNameFL.Text = SafeValue(dr["RoomName"]);
            lblGRPriceFL.Text = SafeValue(dr["RoomPrice"]);
            lblGRAmenitiesFL.Text = SafeValue(dr["Amenities"]);

            // ================= Dates =================
            lblGCheckINFL.Text = dr["CheckInDate"] == DBNull.Value
                ? "N/A"
                : Convert.ToDateTime(dr["CheckInDate"]).ToString("dd-MMM-yyyy");

            lblGCheckOUTFL.Text = dr["CheckOutDate"] == DBNull.Value
                ? "N/A"
                : Convert.ToDateTime(dr["CheckOutDate"]).ToString("dd-MMM-yyyy");

            // ================= Parking =================
            lblGPVehicleTypeFL.Text = SafeValue(dr["VehicleType"]);
            lblGPVehicleFL.Text = SafeValue(dr["VehicleNumber"]);
            lblGPLocationFL.Text = SafeValue(dr["ParkingLocation"]);

            // ================= Load Guest ID Proof =================
            LoadGuestIdProof();
        }

        // ================= Image Loader =================
        private void LoadGuestIdProof()
        {
            string imagePath = @"C:\HMSDocuments\aadhar.jpeg"; // later load from DB

            if (!File.Exists(imagePath)) return;

            using (Image img = Image.FromFile(imagePath))
            {
                pctGuestIDProofFL.Image = new Bitmap(img);
            }

            pctGuestIDProofFL.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}
