using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml.Presentation;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    internal class clsUser
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-A84AP0RN;Initial Catalog=GSTHMS;Integrated Security=True;");


        public string ReceptionistCodeHMS { get; set; }

        public clsUser() { }
        public clsUser(clsUser obj)
        {
            NameHMS = obj.NameHMS;


            ///////////////////////////////////////////////////     [Anushka Mahadik]     ///////////////////////////////////////////////////

            obj.ToDAM = ToDAM;
            obj.FromDAM = FromDAM;
            obj.RoomNameAM = RoomNameAM;
            obj.EventNameAM = EventNameAM;

            ///////////////////////////////////////////////////     [Sanjivani   Pawar]    ///////////////////////////////////////////////////

            GuestNameSP = obj.GuestNameSP;
            FineSP = obj.FineSP;
            invoicecodeSP = obj.invoicecodeSP;
            homestaybankidSP = obj.homestaybankidSP;
            bookingcodeSP = obj.bookingcodeSP;
            orderfoodidSP = obj.orderfoodidSP;
            PaymentMethodidSP = obj.PaymentMethodidSP;
            statusidSP = obj.statusidSP;
            PaidAmountSP = obj.PaidAmountSP;
            FineSP = obj.FineSP;
            finediscriptionSP = obj.finediscriptionSP;
            PaymentDateSP = obj.PaymentDateSP;
            amttopaySP = obj.amttopaySP;
            oDiscountSP = obj.oDiscountSP;
            OrderFoodSP = obj.OrderFoodSP;
            paymentmethodSP = obj.paymentmethodSP;
            statusSP = obj.statusSP;
            bankSP = obj.bankSP;
            statusidSP = obj.statusidSP;
            onameSP = obj.onameSP;
            PageNumberSP = obj.PageNumberSP;
            PageSizeSP = obj.PageSizeSP;
            fromDateSP = obj.fromDateSP;
            toDateSP = obj.toDateSP;
            GuestCodeSP = obj.GuestCodeSP;
            RemainingAmountSP = obj.RemainingAmountSP;


            ///////////////////////////////////////////////////     [Anushka Bhosale]       ///////////////////////////////////////////////////
            IDAB = obj.IDAB;
            CityIDAB = obj.CityIDAB;
            GuestNameAB = obj.GuestNameAB;
            EnquiryCodeAB = obj.EnquiryCodeAB;
            CountryIdAB = obj.CountryIdAB;
            FollowUpNoteAB = obj.FollowUpNoteAB;
            StatusIDAB = obj.StatusIDAB;
            Date1AB = obj.Date1AB;
            StartDateAB = obj.StartDateAB;
            ToDateAB = obj.ToDateAB;
            NextDate = obj.NextDate;


            ///////////////////////////////////////////////////     [Smita Yadav]       ///////////////////////////////////////////////////

            TotalRoomsSY = obj.TotalRoomsSY;
            RoomTypeIDSY = obj.RoomTypeIDSY;
            StatusIDSY = obj.StatusIDSY;
            RoomNameSY = obj.RoomNameSY;
            CapacitySY = obj.CapacitySY;
            RoomIDSY = obj.RoomIDSY;

            ///////////////////////////////////////////////////     [Vaishnavi Mohite]       ///////////////////////////////////////////////////
            NameVM = obj.NameVM;
            EmailVM = obj.EmailVM;
            UserCodeVM = obj.UserCodeVM;
            TermIDVM = obj.TermIDVM;
            MobNoVM = obj.MobNoVM;
            GenderVM = obj.GenderVM;
            EducationVM = obj.EducationVM;
            PositionVM = obj.PositionVM;
            SelectedDocumentsVM = obj.SelectedDocumentsVM;
            SelectedPhotoVM = obj.SelectedPhotoVM;
            UploadDocVM = obj.UploadDocVM;
            CAddVM = obj.CAddVM;
            PAddVM = obj.PAddVM;
            CountryVM = obj.CountryVM;
            SubTypeNameVM = obj.SubTypeNameVM;
            RecpCodeVM = obj.RecpCodeVM;
            UpiIDVM = obj.UpiIDVM;
            StateVM = obj.StateVM;
            CityVM = obj.CityVM;
            PinCodeVM = obj.PinCodeVM;
            BirthDateVM = obj.BirthDateVM;
            AgeVM = obj.AgeVM;
            JoinDateVM = obj.JoinDateVM;
            BankVM = obj.BankVM;
            BranchVM = obj.BranchVM;
            AccountNoVM = obj.AccountNoVM;
            AccountTypeVM = obj.AccountTypeVM;
            IFSCCodeVM = obj.IFSCCodeVM;
            IdVM = obj.IdVM;
            DescriptionVM = obj.DescriptionVM;
            notificationIdVM = obj.notificationIdVM;
            BankIDVM = obj.BankIDVM;
            BranchIDVM = obj.BranchIDVM;
            TitleVM = obj.TitleVM;
            ReportedDateVM = obj.ReportedDateVM;
            StartDateVM = obj.StartDateVM;
            EndDateVM = obj.EndDateVM;
            ///////////////////////////////////////////////////     [Sakshi Pawar]       ///////////////////////////////////////////////////
            CidPSS = obj.CidPSS;
            FidPSS = obj.FidPSS;
            CNamePSS = obj.CNamePSS;
            UserCodePSS = obj.UserCodePSS;
            CEmailPSS = obj.CEmailPSS;
            GuestNamePSS = obj.GuestNamePSS;
            RoomRatingPSS = obj.RoomRatingPSS;
            FoodRatingPSS = obj.FoodRatingPSS;
            parkingRatingPSS = obj.parkingRatingPSS;
            EventRatingPSS = obj.EventRatingPSS;
            InventoryRatingPSS = obj.InventoryRatingPSS;
            OverallRatingPSS = obj.OverallRatingPSS;
            NamePSS = obj.NamePSS;
            ContactNoPSS = obj.ContactNoPSS;
            ContactTypePSS = obj.ContactTypePSS;
            EmailPSS = obj.EmailPSS;
            DescriptionPSS = obj.DescriptionPSS;
            PageNumberPSS = obj.PageNumberPSS;
            PageSizePSS = obj.PageSizePSS;
            DateTime FromDatePSS = obj.FromDatePSS;
            DateTime ToDatePSS = obj.ToDatePSS;
            DateTime FeedbackDatePSS = obj.FeedbackDatePSS;




            ///////////////////////////////////////////////////     [Saurabh Mane ]       ///////////////////////////////////////////////////
            UserNameSM = obj.UserNameSM;
            PasswordSM = obj.PasswordSM;
            EmailSM = obj.EmailSM;
            FromDateSM = obj.FromDateSM;
            ToDateSM = obj.ToDateSM;
            PagesizeSM = obj.CurrentPageSM;
            CurrentPageSM = obj.CurrentPageSM;
            PagenoSM = obj.PagenoSM;

            ///////////////////////////////////////////////////     [Arun Patil]     ///////////////////////////////////////////////////

            if (obj != null)
            {
                this.fromdateAP = obj.fromdateAP;
                this.todateAP = obj.todateAP;
                this.roomtypenameAP = obj.roomtypenameAP;
                this.citynameAP = obj.citynameAP;
            }

            ///////////////////////////////////////////////////     [Shravani Jadhav]       ///////////////////////////////////////////////////
            AgentNameSJ = obj.AgentNameSJ;
            EmailIDSJ = obj.EmailIDSJ;
            GenderSJ = obj.GenderSJ;
            ContactNoSJ = obj.ContactNoSJ;
            PincodeSJ = obj.PincodeSJ;
            AddressSJ = obj.AddressSJ;
            // Commission_RsSJ = obj.Commission_RsSJ;
            JoinDateSJ = obj.JoinDateSJ;
            AgentCodeSJ = obj.AgentCodeSJ;
            CountryNameSJ = obj.CountryNameSJ;
            StateNameSJ = obj.StateNameSJ;
            CityNameSJ = obj.CityNameSJ;
            BankNameSJ = obj.BankNameSJ;
            BranchNameSJ = obj.BranchNameSJ;
            AccountNoSJ = obj.AccountNoSJ;
            AccountTypeSJ = obj.AccountTypeSJ;
            IFSCCodeSJ = obj.IFSCCodeSJ;
            StatusIDSJ = obj.StatusIDSJ;
            StatusSJ = obj.StatusSJ;
            StatusSJ = obj.StatusSJ;
            SubTypeSJ = obj.SubTypeSJ;
            FromDateSJ = obj.FromDateSJ;
            ToDateSJ = obj.ToDateSJ;
            PersonCodeSJ = obj.PersonCodeSJ;
            TitleSJ = obj.TitleSJ;
            RelatedCodeSJ = obj.RelatedCodeSJ;
            AddedBySJ = obj.AddedBySJ;
            IsSeenSJ = obj.IsSeenSJ;
            CreatedAtSJ = obj.CreatedAtSJ;
            DescriptionSJ = obj.DescriptionSJ;
            RoomTypeIDSJ = obj.RoomTypeIDSJ;
            ServiceTypeSJ = obj.ServiceTypeSJ;
            ServiceTypeIDSJ = obj.ServiceTypeIDSJ;
            InventoryIDSJ = obj.InventoryIDSJ;
            InventoryNameSJ = obj.InventoryNameSJ;
            IDSJ = obj.IDSJ;
            DescriptionSJ = obj.DescriptionSJ;
            RoomDateSJ = obj.RoomDateSJ;
            InventoryDateSJ = obj.InventoryDateSJ;
            ServiceDateSJ = obj.ServiceDateSJ;


            ///////////////////////////////////////////////////     [Vishal Kokate]       ///////////////////////////////////////////////////
            InventoryNameVK = obj.InventoryNameVK;
            QuantityVK = obj.QuantityVK;
            VendorNameVK = obj.VendorNameVK;
            AddressVK = obj.AddressVK;
            Contact_NoVK = obj.Contact_NoVK;
            RoomTypeIDVK = obj.RoomTypeIDVK;
            InventoryTypeIDVK = obj.InventoryTypeIDVK;
            VendorCodeVK = obj.VendorCodeVK;
            GuestCodeVK = obj.GuestCodeVK;
            SubTypeIDVK = obj.SubTypeIDVK;
            UnitPriceVK = obj.UnitPriceVK;
            TotalPriceVK = obj.TotalPriceVK;
            SubTypeIDVK = obj.SubTypeIDVK;
            InventoryTypeNameVK = obj.InventoryTypeNameVK;
            StatusIDVK = obj.StatusIDVK;
            fileNameVK = obj.fileNameVK;
            filePathVK = obj.filePathVK;
            VendorIDVK = obj.VendorIDVK;
            StatusVK = obj.StatusVK;
            RoomNameVK = obj.RoomNameVK;



            ///////////////////////////////////////////////////     [Sayali Mohite ]//////////////////////////////////////////////////
            GuestNameSRM = obj.GuestNameSRM;
            RoomNoSRM = obj.RoomNoSRM;
            FoodTypeIDSRM = obj.FoodTypeIDSRM;
            MenuTypeSRM = obj.MenuTypeSRM;


            MenuNameSRM = obj.MenuNameSRM;
            FoodMenuIDSRM = obj.FoodMenuIDSRM;
            FoodNameSRM = obj.FoodNameSRM;
            ParkingIDSRM = obj.ParkingIDSRM;
            OrderFoodIDSRM = obj.OrderFoodIDSRM;
            BookingCodeSRM = obj.BookingCodeSRM;
            QuantitySRM = obj.QuantitySRM;
            OrderDateSRM = obj.OrderDateSRM;
            TotalPriceSRM = obj.TotalPriceSRM;
            SlotIDSRM = obj.SlotIDSRM;
            PageNumberSRM = obj.PageNumberSRM;
            PageSizeSRM = obj.PageSizeSRM;
            EmailTemplateIDSRM = obj.EmailTemplateIDSRM;
            SelectedSlotNameSRM = obj.SelectedSlotNameSRM;
            StartDateSRM = obj.StartDateSRM;
            EndDateSRM = obj.EndDateSRM;



            ///////////////////////////////////////////////////     [ Fanish Lad ]//////////////////////////////////////////////////
            GuestNameFL = obj.GuestNameFL;
            RoomTypeIDFL = obj.RoomTypeIDFL;
            RoomNameFL = obj.RoomNameFL;
            RoomIDFL = obj.RoomIDFL;
            RoomPriceFL = obj.RoomPriceFL;
            BookingCodeFL = obj.BookingCodeFL;
            NoOfGuestFL = obj.NoOfGuestFL;
            CheckInFL = obj.CheckInFL;
            CheckOutFL = obj.CheckOutFL;
            VehicleNoFL = obj.VehicleNoFL;
            RoomTypeNameFL = obj.RoomTypeNameFL;
            BookingIDFL = obj.BookingIDFL;
            BasePriceFL = obj.BasePriceFL;
            GuestCodeFL = obj.GuestCodeFL;
            agentCodeFL = obj.agentCodeFL;
            isvehicleFL = obj.isvehicleFL;
            isagentFL = obj.isagentFL;
            checkInTimeFL = obj.checkInTimeFL;
            checkOutTimeFL = obj.checkOutTimeFL;
            RoomPriceFL = (int)obj.RoomPriceFL;
            ParkingSlotID = obj.ParkingSlotID;
            ContactNoFL = obj.ContactNoFL;
            EmailFL = obj.EmailFL;
            GenderFL = obj.GenderFL;
            AddressFL = obj.AddressFL;
            /////////////////////////////////////////////////////// [Raj Patil]////////////////////////////////////////////////////
            obj.TotalChargesRP = TotalChargesRP;
            obj.StaffCodeRP = StaffCodeRP;
            obj.StaffID = StaffID;
            obj.StaffName = StaffName;
            obj.PositionId = PositionId;
            obj.code = code;
            obj.bookingcodeRP = bookingcodeRP;
            obj.eventIDRP = eventIDRP;
            obj.NoOfGuestRP = NoOfGuestRP;
            obj.GuestNameRP = GuestNameRP;
            obj.EventNameRP = EventNameRP;
            obj.FromDateRP = FromDateRP;
            obj.ToDateRP = ToDateRP;
            obj.DailyLeaveTypeRP = DailyLeaveTypeRP;
            ////////////////////////////////////////////////////////Soham///////////////////////////////////////////////////////////

            ////////////////Guest/////////////////////////////////////
            //Update///
            CityIDDSC = obj.CityIDDSC;
            GuestNameSC = obj.GuestNameSC;
            CountryIdSC = obj.CountryIdSC;
            AddressSC = obj.AddressSC;
            PincodeSC = obj.PincodeSC;
            EmailIDSC = obj.EmailIDSC;
            ContactNoSC = obj.ContactNoSC;
            StateIDSC = obj.StateIDSC;
            GeustCode = obj.GeustCode;
            FilePath = obj.FilePath;
            filePathPSC = obj.filePathPSC;
            ////Add//
            CntryIDSC = obj.CntryIDSC;
            StateIDSC = obj.StateIDSC;
            CityIDSC = obj.CityIDSC;
            //// VIEW//
            GuestCodeSC = obj.GuestCodeSC;

        }


        public string NameHMS { get; set; }
        public string RCPT { get; set; }
        public string GetRecCodeHMS()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetRecCodeHMS");
            com.Parameters.AddWithValue("@NameHMS", NameHMS);
            object result = com.ExecuteScalar();
            con.Close();
            return result.ToString();
        }

        ///////////////////////////////////////////////////     [Anushka Mahadik]      ///////////////////////////////////////////////////

        public DateTime FromDAM { get; set; }
        public DateTime ToDAM { get; set; }
        public int StatusIDAM { get; set; }
        public string RoomNameAM { get; set; }
        public string ForSearchAM { get; set; }
        public string EventNameAM { get; set; }
        public string StatusAM { get; set; }
        public int GetGuestCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetGuestCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);

        }

        public int GetTotalPaymentCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTotalPaymentCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public int GetTotalInventoryCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTotalInventoryCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public int GetTodaysCheckOutCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysCheckOutCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public int GetTodaysEventsCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysEventsCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public int GetActiveBookingCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetActiveBookingCountAM");
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public DataTable GetInventoryCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetInventoryCountAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetGuestInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetGuestInfoAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetGuestInfoFilterAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetGuestInfoFilterAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetPendingPaymentInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetPendingPaymentInfoAM");
            com.Parameters.AddWithValue("@StatusIDAM", StatusIDAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetTotalPaymentInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTotalPaymentInfoAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetTotalPaymentInfoFilterAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTotalPaymentInfoFilterAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable GuestPaymentCountByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GuestPaymentCountByStatusAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAttendanceCountAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetAttendanceCountAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetEventNameAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetEventNameAM");
            com.Parameters.AddWithValue("@RoomNameAM", RoomNameAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetTodaysEventInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysEventInfoAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetTodaysEventFilterAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysEventFilterAM");
            com.Parameters.AddWithValue("@EventNameAM", EventNameAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetActiveBookingInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetActiveBookingInfoAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetTodaysCheckOutInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysCheckOutInfoAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable RoomCountByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "RoomCountByStatusAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ParkingCountByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "ParkingCountByStatusAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable GetRoomAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetRoomAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable GetTodaysCheckOutFilterAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysCheckOutFilterAM");
            com.Parameters.AddWithValue("@RoomNameAM", RoomNameAM);

            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetInventoryInfoByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetInventoryInfoByStatusAM");
            com.Parameters.AddWithValue("@StatusAM", StatusAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable GetAttendanceByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetAttendanceByStatusAM");
            com.Parameters.AddWithValue("@StatusAM", StatusAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable ParkingInfoOfSlot()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "ParkingInfoOfSlot");
            com.Parameters.AddWithValue("SearchAM", ForSearchAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable ParkingCountByStatusDTAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "ParkingCountByStatusDTAM");
            com.Parameters.AddWithValue("@FromDateAM", FromDAM);
            com.Parameters.AddWithValue("@ToDateAM", ToDAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable GuestPaymentCountByStatusDTAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GuestPaymentCountByStatusDTAM");
            com.Parameters.AddWithValue("@FromDateAM", FromDAM);
            com.Parameters.AddWithValue("@ToDateAM", ToDAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GuestPaymentInfoByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GuestPaymentInfoByStatusAM");
            com.Parameters.AddWithValue("@StatusIDAM", StatusIDAM);

            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetTodaysPaymentInfoAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTodaysPaymentInfoAM");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable RoomInfoByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "RoomInfoByStatusAM");
            com.Parameters.AddWithValue("@StatusIDAM", StatusIDAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ParkingInfoByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "ParkingInfoByStatusAM");
            com.Parameters.AddWithValue("@StatusIDAM", StatusIDAM);

            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetActiveBookingInfoFilterAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetActiveBookingInfoFilterAM");
            com.Parameters.AddWithValue("@RoomNameAM", RoomNameAM);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GuestPaymentInfoDTByStatusAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GuestPaymentInfoDTByStatusAM");
            com.Parameters.AddWithValue("@StatusIDAM", StatusIDAM);
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public int GetGuestCountDTAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetGuestCountDTAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }
        public int GetTotalPaymentCountDTAM()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagAM", "GetTotalPaymentCountDTAM");
            com.Parameters.AddWithValue("@FromDateAM", SqlDbType.Date).Value = FromDAM;
            com.Parameters.AddWithValue("@ToDateAM", SqlDbType.Date).Value = ToDAM;
            object resultAM = com.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(resultAM);
        }


        /// ///////////////////////////////////////////////         [Sanjivani Pawar]           ///////////////////////////////////////

        public string invoicecodeSP { get; set; }
        public int homestaybankidSP { get; set; }
        public string bookingcodeSP { get; set; }
        public int orderfoodidSP { get; set; }
        public int PaymentMethodidSP { get; set; }
        public string PaymentDateSP { get; set; }
        public int statusidSP { get; set; }
        public decimal FineSP { get; set; }
        public string finediscriptionSP { get; set; }
        public decimal PaidAmountSP { get; set; }
        public decimal RemainingAmountSP { get; set; }
        public decimal amttopaySP { get; set; }
        public string GuestNameSP { get; set; }
        public decimal BasePriceSP { get; set; }
        public string OrderFoodSP { get; set; }
        public string paymentmethodSP { get; set; }
        public string statusSP { get; set; }
        public string bankSP { get; set; }
        public string oDiscountSP { get; set; }
        //public string bookingcode {get; set; }
        public string onameSP { get; set; }
        public int PageNumberSP { get; set; }
        public int PageSizeSP { get; set; }

        public DateTime fromDateSP { get; set; }
        public DateTime toDateSP { get; set; }
        public string GuestCodeSP { get; set; }


        //FetchData on grid
        public DataTable FetchPayDataSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FetchPayDataSP");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public int GetGuestPayCountSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetPayCountSP");

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }

        //change status
        public void UpdateAllPaymentPaidStatusSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSP", "UpdateAllPaymentPaidStatus");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        //Fecth data on payment form like BookingCode,OfferName etc.
        public DataTable PayInfoSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "ShowPayInfoSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Data Fetch on Combobox
        public DataTable PaymentSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "PaymentSP");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable AccountSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "AccountSP");
            cmd.Parameters.AddWithValue("@HomestayBankIDSP", homestaybankidSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Pay click
        public void PaySP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "PaySP");
            cmd.Parameters.AddWithValue("@InvoiceCodeSP", invoicecodeSP);
            cmd.Parameters.AddWithValue("@HomestayBankIDSP", homestaybankidSP);
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
            cmd.Parameters.AddWithValue("@OrderFoodIDSP", orderfoodidSP);
            cmd.Parameters.AddWithValue("@PaymentMethodIDSP", PaymentMethodidSP);
            cmd.Parameters.AddWithValue("@StatusIDSP", statusidSP);
            cmd.Parameters.AddWithValue("@PaidAmtSP", PaidAmountSP);
            cmd.Parameters.AddWithValue("@FineSP", FineSP);
            cmd.Parameters.AddWithValue("@FineDiscriptionSP", finediscriptionSP);
            string PaymentDate = DateTime.Now.ToString("yyyy-MM-dd");
            cmd.Parameters.AddWithValue("@PaymentDateSP", PaymentDate);
            cmd.Parameters.AddWithValue("@AmtToPaySP", amttopaySP);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //GetAlreadyPaid
        public decimal GetAlreadyPaidSP(string invoiceCode)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetAlreadyPaidSP");
            cmd.Parameters.AddWithValue("@InvoiceCodeSP", invoiceCode);
            object result = cmd.ExecuteScalar();
            con.Close();

            return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
        }
        public void PayInLogSP()
        {
            //string PaymentDate = DateTime.Now.ToString("dd-MM-yyyy");

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "SaveOnLogSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
            cmd.Parameters.AddWithValue("@GuestCodeSP", GuestCodeSP);
            cmd.Parameters.AddWithValue("@RemainingAmountSP", RemainingAmountSP);
            DateTime PaymentDate = DateTime.Now;
            cmd.Parameters.AddWithValue("@PaymentDateSP", PaymentDate);

            //cmd.Parameters.AddWithValue("@PaymentDateSP", PaymentDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public decimal GetRemainingAmountSP()
        {
            decimal remaining = 0;
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetRemainSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);

            object result = cmd.ExecuteScalar();

            if (result != null && result != DBNull.Value)
                remaining = Convert.ToDecimal(result);
            con.Close();
            return remaining;
        }

        //GetCurremnt Paid Amount
        public Decimal GetCurrentPaidAmtSP(string invoiceCode)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetCurrentPaidAmtSP");
            cmd.Parameters.AddWithValue("@InvoiceCodeSP", invoiceCode); // FIXED
            object result = cmd.ExecuteScalar();
            //SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            //DataTable dtc = new DataTable();
            //adpt.Fill(dtc);
            //return dtc;
            return Convert.ToDecimal(result);
        }
        //GetOrderFoodID in Database
        public int GetOrderFoodIdSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetOrderFoodIdSP");
            cmd.Parameters.AddWithValue("@OrderFoodSP", OrderFoodSP);
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
            object result = cmd.ExecuteScalar();
            con.Close();

            return Convert.ToInt32(result);
        }


        // GetPaymentMenthodId in Database
        public string GetPaymentMenthodIdSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetPaymentMenthodIdSP");
            cmd.Parameters.AddWithValue("@PaymentMethodSP", paymentmethodSP);
            object result = cmd.ExecuteScalar();
            con.Close();

            return result.ToString();
        }
        //GetFuestCode
        public string GetGuestCodeSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetGuestCodeSP");
            cmd.Parameters.AddWithValue("@GuestNameSP", GuestNameSP);
            object result = cmd.ExecuteScalar();
            con.Close();

            return result.ToString();
        }

        // GetPaymentMenthodId in Database
        //public string GetStatusIdSP()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@FlagSP", "GetStatusIdSP");
        //    cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
        //    //     cmd.Parameters.AddWithValue("@PaymentMethodID", PaymentMethodid);
        //    object result = cmd.ExecuteScalar();
        //    con.Close();

        //    return result.ToString();
        //}

        public DataTable GetRemPaidAmtSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetRemPaidAmtSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }
        //invoce
        public DataTable GetInvoiceDataSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "InvoiceeSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public string GetBookingCodeByInvoiceSP()
        {
            string bookingCode = "";

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetBookingByInvoiceSP");
            cmd.Parameters.AddWithValue("@InvoiceCodeSP", invoicecodeSP);

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                bookingCode = dr["BookingCode"].ToString();
            }
            dr.Close();
            con.Close();

            return bookingCode;
        }



        //info on pay grid
        public DataTable GetPayDataSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "GetPayDataSP");
            cmd.Parameters.AddWithValue("@BookingCodeSP", bookingcodeSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Status filter
        public DataTable StatusSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "StatusSP");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            adpt.Fill(dtt);
            con.Close();
            return dtt;
        }

        public DataTable FetchPayDataByStatusSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FetchPayDataByStatusSP");
            cmd.Parameters.AddWithValue("@StatusIDSP", statusidSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            adpt.Fill(dt1);

            con.Close();
            return dt1;
        }
        public DataTable FetchPayDataByStatusBothSP()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FetchPayDataByStatusBothSP");
            cmd.Parameters.AddWithValue("@PaymentMethodIDSP", this.PaymentMethodidSP);
            cmd.Parameters.AddWithValue("@StatusIDSP", this.statusidSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            adpt.Fill(dt1);
            return dt1;

        }

        //Filter cmbbxPaymentMode
        public DataTable FiterPaymentMethodSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FilterPaymentModeSP");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtP = new DataTable();
            adpt.Fill(dtP);
            con.Close();
            return dtP;

        }
        public DataTable FetchPayDataByPaymentModeSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FetchPayDataByPaymentModeSP");
            cmd.Parameters.AddWithValue("@PaymentMethodIDSP", PaymentMethodidSP);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt1 = new DataTable();
            adpt.Fill(dt1);

            con.Close();
            return dt1;
        }

        //FOR DATE
        public DataTable FetchPaymentsByDateSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "DateTimeSP");

            cmd.Parameters.AddWithValue("@FromDateSP", fromDateSP.Date);
            cmd.Parameters.AddWithValue("@ToDateSP", toDateSP.Date);


            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;
        }

        public DataTable InvoiceInfoSP()
        {
            //con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "ShowInvoiceInfoSP");
            cmd.Parameters.AddWithValue("@GuestNameSP", GuestNameSP);
            cmd.Parameters.AddWithValue("@FineSP", FineSP);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtI = new DataTable();
            adpt.Fill(dtI);
            // con.Close();
            return dtI;
        }
        public DataTable GetTodaysBookingSP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSP", "FetchUnpaidGuestSP");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        ///////////////////////////////////////////////////     [Anushka Bhosale]       ///////////////////////////////////////////////////
        public int IDAB { get; set; }
        public int CityIDAB { get; set; }
        public string GuestNameAB { get; set; }
        public int GenderAB { get; set; }
        public int StaffIDAB { get; set; }
        public string StaffCodeAB { get; set; }
        public string EnquiryCodeAB { get; set; }
        public int CountryIdAB { get; set; }
        public string FollowUpNoteAB { get; set; }
        public string AddressAB { get; set; }
        public long PincodeAB { get; set; }
        public int StatusIDAB { get; set; }
        public DateTime Date1AB { get; set; }
        public string stNameAB { get; set; }
        public string EmailIDAB { get; set; }
        public long ContactNoAB { get; set; }
        public string ReasonAB { get; set; }
        public DateTime StartDateAB { get; set; }
        public DateTime ToDateAB { get; set; }
        public int StateIDAB { get; set; }
        public int PageSizeAB { get; set; }
        public int pageNumberAB { get; set; }
        public string RecNameAB { get; set; }
        public DateTime NextDate { get; set; }

        //fetch Enquiry details on the gridview
        public DataTable FetchEnquiryDetailsAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchEnquiryDetailsAB");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        //Display details on view form
        public DataTable DisplayDataAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "DisplayDetailsAB");
            cmd.Parameters.AddWithValue("@GuestNameAB", GuestNameAB);
            cmd.Parameters.AddWithValue("@EnquiryCodeAB", EnquiryCodeAB);
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Fetch Country
        public DataTable FetchCountryAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchCountryAB");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Fetching State
        public DataTable StateDisplayAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "fetchStateAB");
            cmd.Parameters.AddWithValue("@CountryIDAB", CountryIdAB);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //SaveCity
        public DataTable CityDisplayAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "fetchcityAB");
            cmd.Parameters.AddWithValue("@StateIdAB", CityIDAB);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //InsertTheFollowUp
        public void AddFollowUpAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "AddFollowUpdAB");
            cmd.Parameters.AddWithValue("@NextGuestEnquiryCodeAB", EnquiryCodeAB);
            cmd.Parameters.AddWithValue("@FollowUpNoteAB", FollowUpNoteAB);
            cmd.Parameters.AddWithValue("@StatusIDAB", StatusIDAB);
            cmd.Parameters.AddWithValue("@DateeAB", Date1AB);
            cmd.Parameters.AddWithValue("@StaffCodeAB", StaffCodeAB);
            cmd.Parameters.AddWithValue("@NextDate", NextDate);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //Add Enquiry
        public void AddEnquiryAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagAB", "InsertRecordAB");
            cmd.Parameters.AddWithValue("@GuestNameAB", GuestNameAB);
            cmd.Parameters.AddWithValue("@GenderAB", GenderAB);
            cmd.Parameters.AddWithValue("@EmailAB", EmailIDAB);
            cmd.Parameters.AddWithValue("@CityIDAB", CityIDAB);
            cmd.Parameters.AddWithValue("@AddressAB", AddressAB);
            cmd.Parameters.AddWithValue("@PincodeAB", PincodeAB);
            cmd.Parameters.AddWithValue("@ContactNoAB", ContactNoAB);
            cmd.Parameters.AddWithValue("@EnquiryDateAB", Date1AB);
            cmd.Parameters.AddWithValue("@ReasonOfEnquiryAB", ReasonAB);
            cmd.Parameters.AddWithValue("@StatusIDAB", StatusIDAB);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        //fetch Enquirystatus
        public DataTable FetchEnquiryStatusAB()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchStatusAB");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }


        //Fetch Receptionist Name
        public DataTable FetchReceptionistNameAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchRecepNameAB");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Fetch FollowupHistory
        public DataTable FetchFollowUpAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchFollowUpHistoryAB");
            cmd.Parameters.AddWithValue("@GuestNameAB", GuestNameAB);
            cmd.Parameters.AddWithValue("@EnquiryCodeAB", EnquiryCodeAB);
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        //Fetch AddFollow up Enquiry code
        public string GetRecNMAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "GetRecNMAB");
            cmd.Parameters.AddWithValue("@RecCodeAB", stNameAB);
            object Result = cmd.ExecuteScalar();
            con.Close();
            return Result.ToString();
        }

        //Start Date To Date
        public DataTable FetchGuestDetailsByDateAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchGuestDetailsByDateAB");
            cmd.Parameters.AddWithValue("@StartDateAB", StartDateAB);
            cmd.Parameters.AddWithValue("@ToDateAB", ToDateAB);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        //Upadate Enquiry
        public void UpdateEnquiryAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "UpdateEnquiryAB");
            cmd.Parameters.AddWithValue("@GuestNameAB", GuestNameAB);
            cmd.Parameters.AddWithValue("@EmailAB", EmailIDAB);
            cmd.Parameters.AddWithValue("@ContactNoAB", ContactNoAB);
            cmd.Parameters.AddWithValue("@ReasonOfEnquiryAB", ReasonAB);
            cmd.ExecuteNonQuery();
            con.Close();

        }

        //Fetch Data for Update form
        public DataTable FetchUpdatedDateAB()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagAB", "FetchData");
            cmd.Parameters.AddWithValue("@GuestNameAB", GuestNameAB);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dte = new DataTable();
            da.Fill(dte);
            con.Close();
            return dte;
        }


        //// Count of FollowUp
        //public int FollowUpCountAB()
        //{
        //    int count = 0;
        //    if (con.State == ConnectionState.Closed)
        //        con.Open();

        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@FlagAB", "countofFollowUp");
        //    cmd.Parameters.AddWithValue("@EnquiryCodeAB", EnquiryCodeAB);

        //    count = Convert.ToInt32(cmd.ExecuteScalar());

        //    con.Close();
        //    return count;
        //}
        public int FollowUpCountAB()
        {
            int count = 0;
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagAB", "countofFollowUp");
            cmd.Parameters.AddWithValue("@EnquiryCodeAB", EnquiryCodeAB);

            object result = cmd.ExecuteScalar();
            if (result != null && result != DBNull.Value)
                count = Convert.ToInt32(result);
            con.Close();
            return count;
        }

        ///////////////////////////////////////////////////     [Smita Yadav]       ///////////////////////////////////////////////////

        public int TotalRoomsSY { get; set; }
        public int RoomTypeIDSY { get; set; }
        public int StatusIDSY { get; set; }
        public string RoomNameSY { get; set; }
        public int CapacitySY { get; set; }
        public int RoomIDSY { get; set; }



        /* for get Total Rooms Count on card */
        public int GetTotalRoomsSY()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetTotalRoomsSY");

            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);

        }


        /* for show totalRooms info data on gridview */
        public DataTable showTotalRoomsinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "showTotalRoomsinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        /* for get Available Rooms Count on card */
        public int GetAvailableRoomsSY()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetAvailableRoomsSY");

            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);

        }

        /* for show totalRooms info data on gridview */
        public DataTable showAvailableRoomsinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "showAvailableRoomsinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for get Occupied Rooms Count on card */
        public int GetOccupiedRoomsSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetOccupiedRoomsSY");

            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);

        }

        /* for show OccupiedRooms info data on gridview */
        public DataTable showOccupiedRoomsinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "showOccupiedRoomsinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt3 = new DataTable();
            adpt.Fill(dt3);
            con.Close();
            return dt3;

        }

        /* for get Cleaning Rooms Count on card */
        public int GetCleaningRoomsSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetCleaningRoomsSY");

            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);

        }

        /* for show Cleaning Rooms info data on gridview */
        public DataTable showCleaningRoomsinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "showCleaningRoomsinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt4 = new DataTable();
            adpt.Fill(dt4);
            con.Close();
            return dt4;

        }

        /* for get Check-In-Today Count on card */
        public int CheckInTodaySY()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "CheckInTodaySY");
            // cmd.Parameters.AddWithValue("@CheckInDateSY", CheckInDateSY);
            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);

        }


        /* for show CheckInToday Rooms info data on gridview */
        public DataTable ShowCheckInTodayinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowCheckInTodayinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            adpt.Fill(dt5);
            con.Close();
            return dt5;

        }

        /* for get Check-Out-Today Count on card */
        public int CheckOutTodaySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "CheckOutTodaySY");
            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);
        }

        /* for show CheckOutToday Rooms info data on gridview */
        public DataTable ShowCheckOutTodayinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowCheckOutTodayinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt6 = new DataTable();
            adpt.Fill(dt6);
            con.Close();
            return dt6;

        }


        /* for show room list on gridview */
        public DataTable ShowRoomListinfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomListinfoSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt7 = new DataTable();
            adpt.Fill(dt7);
            con.Close();
            return dt7;
        }



        /* for show room type wise info in gridview*/
        public DataTable ShowRoomTypeWiseInfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomTypeWiseInfoSY");
            cmd.Parameters.AddWithValue("@RoomTypeIDSY", RoomTypeIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Available room type wise info in gridview*/
        public DataTable ShowAvailableRoomTypeWiseInfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowAvailableRoomTypeWiseInfoSY");
            cmd.Parameters.AddWithValue("@RoomTypeIDSY", RoomTypeIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Occupied room type wise info in gridview*/
        public DataTable ShowOccupiedRoomTypeWiseInfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowOccupiedRoomTypeWiseInfoSY");
            cmd.Parameters.AddWithValue("@RoomTypeIDSY", RoomTypeIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Cleaning room type wise info in gridview*/
        public DataTable ShowCleaningRoomTypeWiseInfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowCleaningRoomTypeWiseInfoSY");
            cmd.Parameters.AddWithValue("@RoomTypeIDSY", RoomTypeIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }



        /* Get Room Type in combobox */
        public DataTable GetRoomTypeSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetRoomTypeSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* Get Room Status in combobox */
        public DataTable GetRoomStatusSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetRoomStatusSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }
        /* for show room Status wise info in gridview*/
        public DataTable ShowRoomTypeWiseStatusSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomTypeWiseStatusSY");
            cmd.Parameters.AddWithValue("@StatusIDSY", StatusIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show RoomName and Status on Cards*/
        public DataTable ShowRoomOverviewOnCardSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomOverviewOnCardSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt8 = new DataTable();
            adpt.Fill(dt8);
            con.Close();
            return dt8;

        }
        /* for show Room info on Form */
        public DataTable ShowRoomInfoOnFormSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomInfoOnFormSY");
            cmd.Parameters.AddWithValue("@RoomNameSY", RoomNameSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt9 = new DataTable();
            adpt.Fill(dt9);
            con.Close();
            return dt9;

        }
        /* Get Room Capacity in combobox */
        public DataTable GetRoomCapacitySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetRoomCapacitySY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt8 = new DataTable();
            adpt.Fill(dt8);
            con.Close();
            return dt8;

        }

        /* for show room Capacity wise info in gridview*/
        public DataTable ShowRoomCapacitySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomCapacitySY");
            cmd.Parameters.AddWithValue("@CapacitySY", CapacitySY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Available room Capacity wise info in gridview*/
        public DataTable ShowAvailableRoomCapacitySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowAvailableRoomCapacitySY");
            cmd.Parameters.AddWithValue("@CapacitySY", CapacitySY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Occupied room Capacity wise info in gridview*/
        public DataTable ShowOccupiedRoomCapacitySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowOccupiedRoomCapacitySY");
            cmd.Parameters.AddWithValue("@CapacitySY", CapacitySY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* for show Cleaning room Capacity wise info in gridview*/
        public DataTable ShowCleaningRoomCapacitySY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowCleaningRoomCapacitySY");
            cmd.Parameters.AddWithValue("@CapacitySY", CapacitySY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }


        /* Get Room Name in combobox */
        public DataTable GetRoomNameSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "GetRoomNameSY");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt9 = new DataTable();
            adpt.Fill(dt9);
            con.Close();
            return dt9;

        }

        /* for show room Name wise info in gridview*/
        public DataTable ShowRoomNameSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "ShowRoomNameSY");
            cmd.Parameters.AddWithValue("@RoomIDSY", RoomIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* show info when click on roomtype and status filter  */
        public DataTable showRoomTypeAndStatusWiseInfoSY()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSY", "showRoomTypeAndStatusWiseInfoSY");
            cmd.Parameters.AddWithValue("@StatusIDSY ", StatusIDSY);
            cmd.Parameters.AddWithValue("@RoomTypeIDSY", RoomTypeIDSY);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            adpt.Fill(dt2);
            con.Close();
            return dt2;

        }

        /* Update Status On button click  */
        public void UpdateRoomStatusSY()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GSTHMS", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlagSY", "UpdateStatusSY");
                cmd.Parameters.AddWithValue("@RoomNameSY", RoomNameSY);
                cmd.Parameters.AddWithValue("@StatusIDSY", StatusIDSY);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Updating Room Status : " + ex.Message);
            }
        }

        // ==================== DYNAMIC ROOM CARDS METHOD ====================
        public DataTable GetDynamicRoomCardsSY()
        {
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();

                SqlCommand cmd = new SqlCommand("GSTHMS", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlagSY", "GetDynamicRoomCardsSY");
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                con.Close();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetDynamicRoomCardsSY: " + ex.Message);
            }
        }



        ///////////////////////////////////////////////////     [Vaishnavi Mohite]       ///////////////////////////////////////////////////

        public int IdVM { get; set; }
        public string NameVM { get; set; }
        public string EmailVM { get; set; }
        public string MobNoVM { get; set; }
        public string SubTypeNameVM { get; set; }
        public int GenderVM { get; set; }
        public string EducationVM { get; set; }
        public string PositionVM { get; set; }
        public string SelectedDocumentsVM { get; set; }
        public string SelectedPhotoVM { get; set; }
        public string UploadDocVM { get; set; }
        public string PAddVM { get; set; }
        public string CAddVM { get; set; }
        public string CountryVM { get; set; }
        public string StateVM { get; set; }
        public string CityVM { get; set; }
        public int PinCodeVM { get; set; }
        public int TermIDVM { get; set; }
        public DateTime BirthDateVM { get; set; }
        public string AgeVM { get; set; }
        public DateTime JoinDateVM { get; set; }
        public string BankVM { get; set; }
        public string BranchVM { get; set; }
        public string AccountNoVM { get; set; }
        public string AccountTypeVM { get; set; }
        public string IFSCCodeVM { get; set; }
        public string UpiIDVM { get; set; }
        public string RecpCodeVM { get; set; }
        public string DescriptionVM { get; set; }
        public string PersonCodeVM { get; set; }
        public int notificationIdVM { get; set; }
        public int BankIDVM { get; set; }
        public int BranchIDVM { get; set; }

        public string UserCodeVM { get; set; }
        public string filePathVM { get; set; }

        public int CityID { get; set; }
        public int CntryIDVM { get; set; }
        public int StateIDVM { get; set; }
        public string TitleVM { get; set; }
        public DateTime ReportedDateVM { get; set; }
        public DateTime StartDateVM { get; set; }
        public DateTime EndDateVM { get; set; }

        public DataTable FetchProfileVM()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagVM", "FetchProfileVM");
            cmd.Parameters.AddWithValue("@nameVM", UserCodeVM);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        //------------------------------------Upload Receptionist Profile Image------------------------------   
        //public bool UploadProfileImageVM()
        //{
        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@FlagVM", "UploadProfileVM");
        //    cmd.Parameters.AddWithValue("@codeVM", UserCodeVM);
        //    cmd.Parameters.AddWithValue("@PathVM", filePathVM);

        //    con.Open();
        //    int rows = cmd.ExecuteNonQuery();
        //    con.Close();

        //    return rows > 0;
        //}

        public bool UploadProfileImageVM()
        {
            try
            {
                if (string.IsNullOrEmpty(filePathVM) || !File.Exists(filePathVM))
                {
                    MessageBox.Show("Invalid file selected.");
                    return false;
                }

                string folderPath = Path.Combine(Application.StartupPath, "GSTHMSImages");

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(filePathVM);

                string newPath = Path.Combine(folderPath, fileName);

                File.Copy(filePathVM, newPath, true);

                using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@FlagVM", "UploadProfileVM");
                    cmd.Parameters.AddWithValue("@codeVM", UserCodeVM);
                    cmd.Parameters.AddWithValue("@PathVM", newPath);

                    con.Open();

                    cmd.ExecuteNonQuery();

                    con.Close();

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload Error: " + ex.Message);

                if (con.State == ConnectionState.Open)
                    con.Close();

                return false;
            }
        }

        public string GetProfileImagePathVM()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FlagVM", "GetProfileImageVM");
                    cmd.Parameters.AddWithValue("@codeVM", UserCodeVM);

                    con.Open();
                    object result = cmd.ExecuteScalar();
                    con.Close();

                    return result != null ? result.ToString() : "";
                }
            }
            catch
            {
                return "";
            }
        }

        public bool UploadProfileVM()
        {
            using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlagVM", "UploadProfileVM");
                cmd.Parameters.AddWithValue("@codeVM", UserCodeVM);
                cmd.Parameters.AddWithValue("@PathVM", filePathVM);

                con.Open();

                int i = cmd.ExecuteNonQuery();

                con.Close();

                return i > 0;
            }
        }
        //------------------------------------Fetch Bank Details------------------------------
        public clsUser FetchBankDetailsVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "FetchBankDetVM");
            cmd.Parameters.AddWithValue("@nameVM", UserCodeVM);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                this.BankVM = dr["BankName"].ToString();
                this.BranchVM = dr["BranchName"].ToString();
                this.IFSCCodeVM = dr["IFSCCode"].ToString();
                this.AccountTypeVM = dr["AccountType"].ToString();
                this.AccountNoVM = dr["AccountNo"].ToString();
                this.RecpCodeVM = dr["PersonCode"].ToString();
                this.UpiIDVM = dr["UPIId"].ToString();
            }
            dr.Close();
            con.Close();
            return this;
        }

        public clsUser FetchBranchDetailsVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "FetchBranchDetVM");
            cmd.Parameters.AddWithValue("@codeVM", UserCodeVM);
            cmd.Parameters.AddWithValue("@idVM", BranchIDVM);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                // this.BankVM = dr["BankName"].ToString();
                this.BranchVM = dr["BranchName"].ToString();
                this.IFSCCodeVM = dr["IFSCCode"].ToString();
            }
            dr.Close();
            con.Close();
            return this;
        }
        //------------------------------------Update Bank Details------------------------------
        public bool UpdateBankDetailsVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagVM", "UpdateBankDetailsVM");
            cmd.Parameters.AddWithValue("@branchIdVM", BranchIDVM);
            cmd.Parameters.AddWithValue("@acctypeVM", AccountTypeVM);
            cmd.Parameters.AddWithValue("@accnoVM", AccountNoVM);
            cmd.Parameters.AddWithValue("@ifsccodeVM", IFSCCodeVM);
            cmd.Parameters.AddWithValue("@upiidVM", UpiIDVM);
            cmd.Parameters.AddWithValue("@nameVM", UserCodeVM);

            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0;
        }
        //----------------------TERMS AND CONDITIONS------------------------
        public DataTable FetchTermsAndConditionsTableVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "FetchTermsAndConditionsVM");
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;
        }
        //----------------------NOTIFICATIONS------------------------
        public DataTable GetNotificationsVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "FetchNotificationsVM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //-----------------------------Fetch All Notifications---------------------------
        public DataTable GetAllNotificationsVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "FetchALLNotificationsVM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //----------------------MARK AS READ NOTIFICATIONS------------------------
        public void MarkAsReadVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "MarkAsReadVM");
            cmd.Parameters.AddWithValue("@NotificationIDVM", notificationIdVM);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //----------------------GET UNREAD NOTIFICATIONS COUNT------------------------
        public int GetUnreadCountVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "UnreadCountVM");
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }
        //---------------------------------------Redirect to Maintenance Notification Form------------------------------

        public DataTable RedirectToMaintenanceNotificationVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "RedirectToMaintenanceVM");
            cmd.Parameters.AddWithValue("@NotificationIDVM", notificationIdVM);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchBranchNameVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "GetBranchName");
            cmd.Parameters.AddWithValue("@idVM", BankIDVM);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable FetchBankNameVM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagVM", "GetBankName");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }

        //////////////////////////////////////////[Sakshi Pawar]////////////////////////
        public int CidPSS { get; set; }

        public string CNamePSS { get; set; }

        public string CEmailPSS { get; set; }
        public string NamePSS { get; set; }
        public long ContactNoPSS { get; set; }
        public string ContactTypePSS { get; set; }
        public string EmailPSS { get; set; }
        public string DescriptionPSS { get; set; }
        public int FidPSS { get; set; }
        public string GuestNamePSS { get; set; }

        public string GuestCodePSS { get; set; }
        public decimal RoomRatingPSS { get; set; }
        public decimal FoodRatingPSS { get; set; }
        public decimal parkingRatingPSS { get; set; }
        public decimal EventRatingPSS { get; set; }
        public decimal InventoryRatingPSS { get; set; }

        public decimal OverallRatingPSS { get; set; }
        public DateTime FeedbackDatePSS { get; set; }
        public int PageNumberPSS { get; set; }
        public int PageSizePSS { get; set; }
        public DateTime FromDatePSS { get; set; }
        public DateTime ToDatePSS { get; set; }

        public String UserCodePSS { get; set; }

        public int GetContactCountPSS()///////////////////get Contact Count
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "GetContactCount");
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }


        public void SaveContactPSS()////////////////////save contact//////////////////
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "SaveContactPSS");
            cmd.Parameters.AddWithValue("@NamePSS", NamePSS);
            cmd.Parameters.AddWithValue("@ContactNoPSS", ContactNoPSS);
            cmd.Parameters.AddWithValue("@EmailPSS", EmailPSS);
            cmd.Parameters.AddWithValue("@DescriptionPSS", DescriptionPSS);
            cmd.Parameters.AddWithValue("@ContactTypePSS", ContactTypePSS);



            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void SaveFeedbackPSS()  //For adding guest feedback
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "SaveFeedbackPSS");
            cmd.Parameters.AddWithValue("@GuestCodePSS", GuestCodePSS);
            cmd.Parameters.AddWithValue("@RoomPSS", RoomRatingPSS);
            cmd.Parameters.AddWithValue("@FoodPSS", FoodRatingPSS);
            cmd.Parameters.AddWithValue("@ParkingPSS", parkingRatingPSS);
            cmd.Parameters.AddWithValue("@EventPSS", EventRatingPSS);
            cmd.Parameters.AddWithValue("@InventoryPSS", InventoryRatingPSS);
            cmd.Parameters.AddWithValue("@DatePSS", FeedbackDatePSS);
            cmd.Parameters.AddWithValue("@OverallRatingPSS", OverallRatingPSS);
            cmd.Parameters.AddWithValue("@DescriptionPSS", DescriptionPSS);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdateFeedbackPSS()  //For Update guest feedback
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "EditFeedbackPSS");
            cmd.Parameters.AddWithValue("@GuestCodePSS", GuestCodePSS);
            cmd.Parameters.AddWithValue("@RoomPSS", RoomRatingPSS);
            cmd.Parameters.AddWithValue("@FoodPSS", FoodRatingPSS);
            cmd.Parameters.AddWithValue("@ParkingPSS", parkingRatingPSS);
            cmd.Parameters.AddWithValue("@EventPSS", EventRatingPSS);
            cmd.Parameters.AddWithValue("@InventoryPSS", InventoryRatingPSS);
            //cmd.Parameters.AddWithValue("@DatePSS", FeedbackDatePSS);
            cmd.Parameters.AddWithValue("@OverallRatingPSS", OverallRatingPSS);
            cmd.Parameters.AddWithValue("@DescriptionPSS", DescriptionPSS);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public DataTable ShowContactPSS()  //for show guest feedback details on gridview
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "ShowContactPSS");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;
        }


        public void EditContactPSS() //for Update the contact info
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "EditContactPSS");
            cmd.Parameters.AddWithValue("@ContactNoPSS", ContactNoPSS);
            cmd.Parameters.AddWithValue("@NamePSS", NamePSS);
            cmd.Parameters.AddWithValue("@EmailPSS", EmailPSS);
            cmd.Parameters.AddWithValue("@DescriptionPSS", DescriptionPSS);

            cmd.ExecuteNonQuery();//performs INSERT, UPDATE, or Delete operations.
            con.Close();
        }
        public DataTable FeedbackPaginationPSS()  //for show guest feedback details on gridview
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "LoaddataPSS");
            cmd.Parameters.AddWithValue("@PageNumberPSS", PageNumberPSS);
            cmd.Parameters.AddWithValue("@PageSizePSS", PageSizePSS);


            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable ViewGuestDetailsPSS()  //for show guest feedback details on gridview
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "ViewFeedbackPSS");
            cmd.Parameters.AddWithValue("@GuestCodePSS", GuestCodePSS);


            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable ContactPaginationPSS()  //for show guest feedback details on gridview
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "ShowContactPSS");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;
        }
        public int GetFeedbackCountPSS()//////////////for feedback count
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "GetFeedbackCountPSS");
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count;
        }


        public DataTable FetchFeedbackByDatePSS()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "DateTimeFeedbackPSS");
            cmd.Parameters.AddWithValue("@FromDatePSS", FromDatePSS.Date);
            cmd.Parameters.AddWithValue("@ToDatePSS", ToDatePSS.Date);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;


        }
        public DataTable DeleteFeedbackPSS()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "DeleteFeedbackPSS");
            cmd.Parameters.AddWithValue("@FidPSS", @FidPSS);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;

        }

        public DataTable DeleteContactPSS()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "DeleteContactPSS");
            cmd.Parameters.AddWithValue("@CidPSS", @CidPSS);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;

        }
        public void UpdateContactInlinePSS()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "UpdateContactInlinePSS");
            cmd.Parameters.AddWithValue("@CidPSS", CidPSS);
            cmd.Parameters.AddWithValue("@ContactNoPSS", ContactNoPSS);
            cmd.Parameters.AddWithValue("@EmailPSS", EmailPSS);
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            if (rows == 0)
                throw new Exception("No record updated. ContactId " + CidPSS + " not found.");
        }
        public DataTable ShowGuestNamePSS()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "ShowGuestNamePSS");
            cmd.Parameters.AddWithValue("@UserCodePSS", UserCodePSS);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();

            return dt;
        }


        ///////////////////////////////////////////////////     [Arun Patil]     ///////////////////////////////////////////////////
        public DateTime fromdateAP { get; set; }
        public DateTime todateAP { get; set; }

        public string roomtypenameAP { get; set; }
        public string citynameAP { get; set; }
        public DataTable BookingAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "BookingAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable InventoryAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "InventoryAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable PaymentAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PaymentAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable RoomAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "RoomAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable GuestAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GuestAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable EventAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "EventAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable StaffAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "StaffAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable VendorAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "VendorAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable ServiceAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ServiceAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable EnquiryAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "EnquiryAP");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable SerachRoomAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchRoomAP");
            cmd.Parameters.AddWithValue("@RoomTypeNameAp", roomtypenameAP);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable SerachVendorAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchVendorAP");
            cmd.Parameters.AddWithValue("@CityNameAP", citynameAP);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable staffattendAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "staffattendenceap");
            //cmd.Parameters.AddWithValue("@FromDate", DBNull.Value);
            //cmd.Parameters.AddWithValue("@ToDate", DBNull.Value); //optinal use

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();


            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable GuestSerchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GuestSearchAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable ServiceSerchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ServiceSearchAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable BookingSearchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchBookingAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable InventorySearchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchInventoryAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable PaymentSerchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "PaymentSearchAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable EventSerchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchEventAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable StaffSerchAP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "SearchStaffAP");


            if (fromdateAP < new DateTime(1753, 1, 1))
                fromdateAP = new DateTime(1753, 1, 1);

            if (todateAP < new DateTime(1753, 1, 1))
                todateAP = DateTime.Now;

            cmd.Parameters.AddWithValue("@FromDateAP", fromdateAP);
            cmd.Parameters.AddWithValue("@ToDateAP", todateAP);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        ///////////////////////////////////////////////////     [Shravani Jadhav]       ///////////////////////////////////////////////////

        public string AgentNameSJ { get; set; }
        public string EmailIDSJ { get; set; }
        public int GenderSJ { get; set; }
        public int ContactNoSJ { get; set; }
        public int PincodeSJ { get; set; }
        public string AddressSJ { get; set; }
        // public int Commission_RsSJ { get; set; }
        public DateTime JoinDateSJ { get; set; }
        public string AgentCodeSJ { get; set; }
        public string CountryNameSJ { get; set; }
        public string StateNameSJ { get; set; }
        public string CityNameSJ { get; set; }
        public string BankNameSJ { get; set; }
        public string BranchNameSJ { get; set; }
        public string AccountNoSJ { get; set; }
        public string AccountTypeSJ { get; set; }
        public string IFSCCodeSJ { get; set; }
        public int StatusIDSJ { get; set; }
        public string StatusSJ { get; set; }
        public string TypeSJ { get; set; }
        public string RoomTypeNameSJ { get; set; }
        public string RoomNameSJ { get; set; }
        public string DescriptionSJ { get; set; }
        public DateTime ReportedDateSJ { get; set; }
        public string SubTypeSJ { get; set; }
        public DateTime FromDateSJ { get; set; }
        public DateTime ToDateSJ { get; set; }
        public string PersonCodeSJ { get; set; }
        public string TitleSJ { get; set; }
        public string RelatedCodeSJ { get; set; }
        public string AddedBySJ { get; set; }
        public int IsSeenSJ { get; set; }
        public DateTime CreatedAtSJ { get; set; }
        public int RoomTypeIDSJ { get; set; }
        public string ServiceTypeSJ { get; set; }
        public int ServiceTypeIDSJ { get; set; }
        public int InventoryIDSJ { get; set; }
        public string InventoryNameSJ { get; set; }
        public DateTime fromDateSJ { get; set; }
        public DateTime toDateSJ { get; set; }
        public int IDSJ { get; set; }
        public DateTime RoomDateSJ { get; set; }
        public DateTime InventoryDateSJ { get; set; }
        public DateTime ServiceDateSJ { get; set; }





        //For display agent details on gridview
        public DataTable FetchDataSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "FetchDataSJ");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataTable dt = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //For display room maintenance on gridview
        public DataTable DisplayRoomSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DisplayRoomSJ");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataTable dt1 = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dt1);
            con.Close();
            return dt1;
        }
        //For display inventorymaintenance on gridview
        public DataTable DisplayInventorySJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DisplayInventorySJ");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataTable dt2 = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dt2);
            con.Close();
            return dt2;
        }
        public DataTable DisplayServiceSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DisplayServiceSJ");
            SqlDataAdapter adpt = new SqlDataAdapter();
            DataTable dt3 = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dt3);
            con.Close();
            return dt3;
        }
        public DataTable FetchAgentDetailsSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "FetchAgentDetailsSJ");
            cmd.Parameters.AddWithValue("@AgentNameSJ", AgentNameSJ);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            adpt.Fill(dt5);
            con.Close();
            return dt5;
        }

        public DataTable DisplaySubTypeNameSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DisplaySubTypeNameSJ");
            cmd.Parameters.AddWithValue("@AgentNameSJ", AgentNameSJ);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt7 = new DataTable();
            adpt.Fill(dt7);
            con.Close();
            return dt7;
        }
        public DataTable GetDocumentSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetDocumentSJ");
            cmd.Parameters.AddWithValue("@PersonCodeSJ", AgentCodeSJ);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtt = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dtt);
            con.Close();
            return dtt;
        }
        public void SendMaintenanceSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "SendMaintenanceSJ");
            cmd.Parameters.AddWithValue("@TittleSJ", TitleSJ);
            cmd.Parameters.AddWithValue("@RelatedCodeSJ", RelatedCodeSJ);
            cmd.Parameters.AddWithValue("@AddedBySJ", AddedBySJ);
            cmd.Parameters.AddWithValue("@IsSeenSJ", 0);
            cmd.Parameters.AddWithValue("@CreatedAtSJ", CreatedAtSJ);
            cmd.Parameters.AddWithValue("@DescriptionSJ", DescriptionSJ);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetMaintenanceTypeSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetMaintenanceTypeSJ");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtm = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dtm);
            con.Close();
            return dtm;
        }

        public DataTable GetRoomTypeNameSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetRoomTypeNameSJ");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtr = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dtr);
            con.Close();
            return dtr;
        }

        public DataTable GetRoomNameSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetRoomNameSJ");
            cmd.Parameters.AddWithValue("@RoomTypeIDSJ", RoomTypeIDSJ);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtrm = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dtrm);
            con.Close();
            return dtrm;
        }

        public DataTable GetServiceTypeNameSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetServiceTypeNameSJ");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dts = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dts);
            con.Close();
            return dts;
        }

        public DataTable GetInventoryNameSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "GetInventoryNameSJ");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dti = new DataTable();
            adpt.SelectCommand = cmd;//Initialize SelectCommand Property
            adpt.Fill(dti);
            con.Close();
            return dti;
        }

        public DataTable FetchDateTimeSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DateTimeSJ");

            cmd.Parameters.AddWithValue("@FromDateSJ", fromDateSJ.Date);
            cmd.Parameters.AddWithValue("@ToDateSJ", toDateSJ.Date);


            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;
        }

        public DataTable DateTimeRoomSJ()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "DateTimeRoomSJ");

            // Start: beginning of day
            DateTime from = fromDateSJ.Date;

            // End: include full day (23:59:59.9999999)
            DateTime to = toDateSJ.Date.AddDays(1).AddTicks(-1);

            cmd.Parameters.AddWithValue("@FromDateSJ", from);
            cmd.Parameters.AddWithValue("@ToDateSJ", to);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime1 = new DataTable();
            adpt.Fill(dtTime1);

            con.Close();
            return dtTime1;
        }


        public DataTable DateTimeServiceSJ()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSJ", "DateTimeServiceSJ");

            // Build correct full-day date range
            DateTime from = fromDateSJ.Date;                                 // 00:00:00
            DateTime to = toDateSJ.Date.AddDays(1).AddTicks(-1);             // 23:59:59.9999999

            cmd.Parameters.AddWithValue("@FromDateSJ", from);
            cmd.Parameters.AddWithValue("@ToDateSJ", to);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;
        }


        public DataTable DateTimeInventorySJ()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSJ", "DateTimeInventorySJ");

            // Build correct full-day date range
            DateTime from = fromDateSJ.Date;                     // Start of day (00:00:00)
            DateTime to = toDateSJ.Date.AddDays(1).AddTicks(-1); // End of day (23:59:59.9999999)

            cmd.Parameters.AddWithValue("@FromDateSJ", from);
            cmd.Parameters.AddWithValue("@ToDateSJ", to);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtInventory = new DataTable();
            adpt.Fill(dtInventory);

            con.Close();
            return dtInventory;
        }

        public void SaveRoomMaintenance()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "SaveRoomMaintenanceSJ");
            cmd.Parameters.AddWithValue("@IDSJ", IDSJ);
            cmd.Parameters.AddWithValue("@UserCodeSJ", AddedBySJ);
            cmd.Parameters.AddWithValue("@ReportedDateSJ", RoomDateSJ);
            cmd.Parameters.AddWithValue("@DescriptionSJ", DescriptionSJ);
            cmd.ExecuteNonQuery();
            con.Close();


        }

        public void SaveInventoryMaintenance()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "SaveInventoryMaintenanceSJ");
            cmd.Parameters.AddWithValue("@IDSJ", IDSJ);
            cmd.Parameters.AddWithValue("@UserCodeSJ", AddedBySJ);
            cmd.Parameters.AddWithValue("@ReportedDateSJ", InventoryDateSJ);
            cmd.Parameters.AddWithValue("@DescriptionSJ", DescriptionSJ);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void SaveServiceMaintenance()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSJ", "SaveMaintenanceSJ");
            cmd.Parameters.AddWithValue("@UserCodeSJ", AddedBySJ);
            cmd.Parameters.AddWithValue("@ReportedDateSJ", ServiceDateSJ);
            cmd.Parameters.AddWithValue("@DescriptionSJ", DescriptionSJ);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///////////////////////////////////////////////////     [Vishal Kokate]       ///////////////////////////////////////////////////
        public string InventoryNameVK { get; set; }
        public int QuantityVK { get; set; }
        public string VendorNameVK { get; set; }
        public string AddressVK { get; set; }
        public int Contact_NoVK { get; set; }
        public int RoomTypeIDVK { get; set; }
        public int RoomIDVK { get; set; }
        public string BookingCodeVK { get; set; }
        public int InventoryIDVK { get; set; }
        public Decimal UnitPriceVK { get; set; }
        public Decimal TotalPriceVK { get; set; }
        public int InventoryTypeIDVK { get; set; }
        public DateTime BDateVK { get; set; }
        public string VendorCodeVK { get; set; }
        public string GuestCodeVK { get; set; }
        public int SubTypeIDVK { get; set; }
        public string InventoryTypeNameVK { get; set; }
        public int StatusIDVK { get; set; }
        public string GuestNameVK { get; set; }
        public string fileNameVK { get; set; }
        public string filePathVK { get; set; }
        public int VendorIDVK { get; set; }
        public string StatusVK { get; set; }
        public string RoomNameVK { get; set; }


        public DataTable GetLowStockVK()
        {
            //For Display Low Stock Alerts on the List View 
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayLowStockVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable DisplayTotalItemsVK()
        {
            //For Display Total items on Card
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalItemsVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable DisplayLowStockItemsVK()
        {
            //For Display Low Stock items on Card
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "LowStockItemsVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DisplayTotalValueVK()
        {
            //For Display Total Stock Value on Card
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "TotalValueVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // cmd.ExecuteScalar();//
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetVendorListVK()
        {
            //For Display Vendor List on GridView
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayVendorListVK");
            cmd.Parameters.AddWithValue("@VendorNameVK", VendorNameVK);
            cmd.Parameters.AddWithValue("@AddressVK", AddressVK);
            cmd.Parameters.AddWithValue("Contact_NoVK", Contact_NoVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetVendorNameVK()
        {
            //For Display Vendor Name on combobox
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayVendorNameVK");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetVendorFilterVK()
        {
            //For Display Vendor List by filterwise
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "VendorFilterVK");
            cmd.Parameters.AddWithValue("@VendorNameVK", VendorNameVK);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int GetRoomIdVK()
        {
            //For pass roomid on provide forms on when provide button click
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetRoomIdVK");
            cmd.Parameters.AddWithValue("@RoomNameVK", RoomNameVK);
            object result = cmd.ExecuteScalar();
            con.Close();
            return Convert.ToInt32(result);
        }

        public DataTable GetInventoryListVK()
        {
            //For Display Inventory List on GridView on inventory list form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayInventoryListVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable GetInventoryNFilterVK()
        {
            //For Display Inventory List on combo box by filter wise on inventory list form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayIFilterVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable GetGuestListVK()
        {
            //for Display GuestList on gridview on guest list form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayGuestListVK");


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable RoomDetailsVK()
        {
            // display room type and room name of providetiguest form on the labels
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ActiveRoomDetailsVK");
            cmd.Parameters.AddWithValue("@GuestNameVK", GuestNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable GetInventoryTypeNameVK()
        {
            //for Display InventoryTypeName on combo box on provide to guest form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayInventoryTypeVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }

        public DataTable GetInventoryNameVK()
        {
            //for Display Inventory on combobox on providetoguest form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayInventoryNameVK");
            cmd.Parameters.AddWithValue("@InventoryTypeIDVK", InventoryTypeIDVK);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }

        //public DataTable GetUnitPriceVK()
        //{
        //    //for Display untiprice on label on providetoguest form
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "DisplayUnitPriceVK");
        //    cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();

        //    return dt;
        //}
        public string GetBookingCodeVK()
        {

            // For pass BookingCode the BookingCode column in GSTtblProvideInventory table 
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetBookingCodeVK");
            cmd.Parameters.AddWithValue("@RoomIdVK", RoomIDVK);

            object result = cmd.ExecuteScalar();//

            con.Close();
            return result.ToString();//
        }
        public void ProvideInventoryVK()
        {
            // insert the data provide to guest form to provide inventory table when click provide button  
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "ProvideVK");
            cmd.Parameters.AddWithValue("@BookingcodeVK", BookingCodeVK);
            cmd.Parameters.AddWithValue("@InventoryIDVK", InventoryIDVK);
            cmd.Parameters.AddWithValue("@UnitPriceVK", UnitPriceVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);
            cmd.Parameters.AddWithValue("@TotalPriceVK", TotalPriceVK);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable GetVendorNmVK()
        {
            // Display Vendor Name on combo box on vendor list form filter
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayVendorNmVK");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetInventoryNmVK()
        {
            // Display Inventory Name on combo box on Inventory list form filter
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayINameVK");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //public DataTable GetIStatusVK()
        //{
        //    // Display Inventory Name on combo box on Inventory list form filter
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "DisplayIstatusVK");
        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    con.Close();
        //    return dt;
        //}
        public DataTable GetGNameVK()
        {
            // Display Guest Name on combo box on Guestlist form filter
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayGNameVK");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetInventoryTypeAddVK()
        {
            // Display Inventory type name on combo box of Add new inventory form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayInventoryTypeAddVK");
            cmd.Parameters.AddWithValue("@InventoryTypeNameVK", InventoryTypeNameVK);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        public int GetSubTypeVK()
        {
            // For pass SubType the  SubType column in GSTtblInventory table 

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplaySubTypeVK");
            cmd.Parameters.AddWithValue("@InventoryTypeIDVK", InventoryTypeIDVK);

            object result = cmd.ExecuteScalar();//

            con.Close();
            return Convert.ToInt32(result);//
        }
        public void GetAddNewVK()
        {
            // add new inventory of Add new Inventory form to inventory table when click add button  
            BDateVK = DateTime.Now;

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddNewInventoryVK");
            cmd.Parameters.AddWithValue("@VendorCodeVK", VendorCodeVK);
            //     cmd.Parameters.AddWithValue("@SubTypeIDVK", SubTypeIDVK);
            cmd.Parameters.AddWithValue("@InventoryTypeIDVK", InventoryTypeIDVK);
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);
            cmd.Parameters.AddWithValue("@UnitPriceVK", UnitPriceVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);
            cmd.Parameters.AddWithValue("@TotalPriceVK", TotalPriceVK);
            cmd.Parameters.AddWithValue("@PurchaseDateVK", BDateVK);
            // cmd.Parameters.AddWithValue("@StatusIDVK", StatusIDVK);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void GetAddNewAssetIVK()
        {
            // add new inventory of Add new Inventory form to inventory table when click add button  
            BDateVK = DateTime.Now;

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AddNewAssetInventoryVK");
            cmd.Parameters.AddWithValue("@VendorCodeVK", VendorCodeVK);
            cmd.Parameters.AddWithValue("@SubTypeIdVK", SubTypeIDVK);
            cmd.Parameters.AddWithValue("@InventoryTypeIDVK", InventoryTypeIDVK);
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);
            cmd.Parameters.AddWithValue("@UnitPriceVK", UnitPriceVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);
            cmd.Parameters.AddWithValue("@TotalPriceVK", TotalPriceVK);
            cmd.Parameters.AddWithValue("@PurchaseDateVK", BDateVK);
            cmd.Parameters.AddWithValue("@StatusIDVK", StatusIDVK);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable UpdateInventoryVK()
        {
            // display the data on update inventory form 
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayUpdateinventoryVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public void GetUpdateInventoryVK()
        {
            // insert the data update inventory form to inventory table when click update button  
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UpdateInventoryVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);
            cmd.Parameters.AddWithValue("@TotalPriceVK", TotalPriceVK);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void GetUpdateAssetInventoryVK()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag", "UpdateAssetInventoryByNameVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);
            cmd.Parameters.AddWithValue("@QuantityVK", QuantityVK);
            cmd.Parameters.AddWithValue("@TotalPriceVK", TotalPriceVK);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public DataTable InventoryDetailsVK()
        {
            // display the data on update inventory form labels
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayInventoryDetailsVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }
        public DataTable GetAssetInventoryListVK()
        {
            //For Display Asset Inventory List on GridView
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "DisplayAssetInventoryListVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }
        public DataTable GetAssetGuestListVK()
        {
            //for Display GuestList on grid view on guest list form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayAssetGuestListVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetARoomDetailsVK()
        {
            // display room type and room name of provide to guest form on the labels Asset inventory provide form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AssetRoomDetailsVK");
            cmd.Parameters.AddWithValue("@GuestNameVK", GuestNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable AssetInventoryTypeVK()
        {
            //for Display InventoryTypeName on combo box on Asset inventory provide form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AInventoryTypeVK");
            cmd.Parameters.AddWithValue("@InventoryTypeNameVK", InventoryTypeNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable AssetInventoryNameVK()
        {
            //for Display Inventory on combo box on provide to guest form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AInventoryNameVK");
            cmd.Parameters.AddWithValue("@InventoryTypeIDVK", InventoryTypeIDVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable AssetUnitPriceVK()
        {
            //for Display unti price on label on Asset inventory provide form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "AUnitPriceVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetANameVK()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DisplayANameVK");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void UploadBillVK()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "UploadBillVK");
            cmd.Parameters.AddWithValue("@VendorCodeVK", VendorCodeVK);
            cmd.Parameters.AddWithValue("@PathVK", filePathVK);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public string GetBillPathVK()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "BillPathVK");
            cmd.Parameters.AddWithValue("@VendorCodeVK", VendorCodeVK);
            object result = cmd.ExecuteScalar();
            con.Close();

            if (result != null && result != DBNull.Value)
            {
                return result.ToString();
            }
            return null;
        }
        public DataTable VGuestListVK()
        {
            //For Display Guest List by filter wise
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ValidGuestListVK");
            cmd.Parameters.AddWithValue("@GuestNameVK", GuestNameVK);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable ValidAssetIListVK()
        {
            //For Display List on combo box by filter wise on  form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "ValidAssetIListVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAGLVK()
        {
            //For Display Guest List by filter wise
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "AGLVK");
            cmd.Parameters.AddWithValue("@GuestNameVK", GuestNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();

            return dt;
        }
        public string GetVCodeVK()
        {
            // for pass vendor code from vendor name in update and details form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "GetVCodeVK");
            cmd.Parameters.AddWithValue("@VendorNameVK", VendorNameVK);
            object result = cmd.ExecuteScalar();
            con.Close();
            return result.ToString();
        }
        public DataTable GetInventoryquantityVK()
        {
            //for inventory quantity limit provide inventory & Asset form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@flag", "GetInventoryquantityVK");
            cmd.Parameters.AddWithValue("@InventoryNameVK", InventoryNameVK);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public void DecreamentOfQuanityVK()
        {
            //Decrement quantity when inventory provide to guest
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", "DecreamentofQuantityVK");
            cmd.Parameters.AddWithValue("@BookingCodeVK", BookingCodeVK);
            cmd.Parameters.AddWithValue("@InventoryIDVK", InventoryIDVK);
            cmd.Parameters.AddWithValue("@ProvidedQty", QuantityVK);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //public string IncrementOfQuanityVK()
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand("GSTHMS", con);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@Flag", "IncreamentofQuantity");
        //    cmd.Parameters.AddWithValue("@BookingCodeVK", BookingCodeVK);
        //    cmd.Parameters.AddWithValue("@InventoryIDVK", InventoryIDVK);
        //    object result = cmd.ExecuteScalar();
        //    con.Close();
        //    return result.ToString();
        //}
        public void IncrementOfQuanityVK()
        {
            //Increment inventory quantity when guest checked out
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag", "IncreamentofQuantity");
            cmd.Parameters.AddWithValue("@BookingCodeVK", BookingCodeVK);

            cmd.ExecuteNonQuery();
            con.Close();

            //checkout
            //obj.BookingCodeVK = bookingcode;
            //obj.IncrementOfQuanityVK();
        }
        public void AutoLowStockStatusVK()
        {
            //Auto low stock status Update
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Flag", "AutoLowStockStatusVK");
            cmd.Parameters.AddWithValue("@InventoryIDVK", InventoryIDVK);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }


        //////////////////////////////////////////[Saurabh Mane]////////////////////////
        public string UserNameSM { get; set; }
        public string PasswordSM { get; set; }
        public string UpdatePasswordSM { get; set; }
        public string EmailSM { get; set; }
        public DateTime FromDateSM { get; set; }
        public DateTime ToDateSM { get; set; }
        public int PagesizeSM { get; set; }
        public int CurrentPageSM { get; set; }
        public int PagenoSM { get; set; }



        public bool LoginSM()     //Login Method
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSM", "LoginSM");
            cmd.Parameters.AddWithValue("@UsernameSM", UserNameSM);
            cmd.Parameters.AddWithValue("@PasswardSM", PasswordSM);

            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            bool Validuser = dr.HasRows;

            con.Close();
            return Validuser;
        }
        public void NewPasswordSM()     //Update new Password Method
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FLagSM", "UpdatePassSM");
            cmd.Parameters.AddWithValue("@PasswardSM", PasswordSM);
            cmd.Parameters.AddWithValue("@UsernameSM", UserNameSM);

            cmd.ExecuteNonQuery();
        }


        public DataTable IsValidUsernameEmailSM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSM", "IsValidSM");
            cmd.Parameters.AddWithValue("@UsernameSM", UserNameSM);
            cmd.Parameters.AddWithValue("@EmailSM", EmailSM);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dte = new DataTable();
            da.Fill(dte);
            con.Close();

            return dte;


        }


        public DataTable DisplayOffersSM()    //DisplayOdffers grid
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FLagSM", "DisplayOffersSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplaytotalofferSM()   //DiplayTotaloffers Counts
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "TotalOffersSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayActiveofferSM()     //Display ActiveOfferCount
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "ActiveoffersSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayUpcomingofferSM()   //Display upcoming Count
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "UpcomingOffersSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayInActiveofferSM()    //Display Inactive Offers Counts
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "InActiveOffersSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            cmd.ExecuteScalar();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetDatabydatarangeSM()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSM", "FetchDateOfferSM");
            cmd.Parameters.AddWithValue("@StartDateSM", FromDateSM);   // ✔ Important
            cmd.Parameters.AddWithValue("@EndDateSM", ToDateSM);       // ✔ Important
                                                                       //  cmd.Parameters.AddWithValue("@PageSizeSM", PagesizeSM);
                                                                       //   cmd.Parameters.AddWithValue("@PageNoSM", PagenoSM);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();

            return dt;
        }





        public DataTable DisplayActiveoffergridSM()   //DiplayActiveoffers Panel grid
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "DisplayActiveOffergridSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayUpcomingoffergridSM()   //DiplayExpiredoffers Panel grid
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "DisplayUpcomingOffergridSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayInactivoffergridSM()   //DiplayInactivoffers Panel grid
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("FlagSM", "DisplayInactiveOffergridSM");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchGuestDetailsSM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSM", "FetchGuestDetailsSM");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        ///////////////////////////////////////////////////     [Sayali Mohite ]//////////////////////////////////////////////////
        public string GuestNameSRM { get; set; }
        public int RoomNoSRM { get; set; }
        public int ParkingIDSRM { get; set; }
        public int FoodTypeIDSRM { get; set; }
        public string MenuTypeSRM { get; set; }
        public string MenuNameSRM { get; set; }
        public int FoodMenuIDSRM { get; set; }
        public string FoodNameSRM { get; set; }
        public int OrderFoodIDSRM { get; set; }
        public string BookingCodeSRM { get; set; }
        public int QuantitySRM { get; set; }
        public DateTime OrderDateSRM { get; set; }
        public decimal TotalPriceSRM { get; set; }
        public int SlotIDSRM { get; set; }
        public int PageSizeSRM { get; set; }
        public int PageNumberSRM { get; set; }
        public int EmailTemplateIDSRM { get; set; }
        public string RoomNameSRM { get; set; }
        public string SlotNameSRM { get; set; }

        public string SelectedSlotNameSRM { get; set; }
        public string EnquiryCodeSRM { get; set; }

        public string StartDateSRM { get; set; }
        public string EmailIDSRM { get; set; }
        public string CCSRM { get; set; }
        public string BCCSRM { get; set; }
        public DateTime EmailDateSRM { get; set; }
        public string EndDateSRM { get; set; }


        public DataTable DisplayFoodSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayFoodSRM");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplayActiveGuestSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayActiveGuestSRM");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public void SaveEmailSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSRM", "SaveEmailSRM");
            cmd.Parameters.AddWithValue("@EnquiryCodeSRM", EnquiryCodeSRM);
            cmd.Parameters.AddWithValue("@TemplateIDSRM", EmailTemplateIDSRM);
            cmd.Parameters.AddWithValue("@CCSRM", CCSRM);
            cmd.Parameters.AddWithValue("@BCCSRM", BCCSRM);

            cmd.ExecuteNonQuery();

            con.Close();
        }
        public DataTable DisplayFoodTypeSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchFoodTypeSRM");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable DisplayMenuNameSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayFoodMenuNameSRM");
            cmd.Parameters.AddWithValue("@FoodTypeIDSRM", FoodTypeIDSRM);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetFoodPriceDataSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayFoodlistSRM");
            cmd.Parameters.AddWithValue("@FoodTypeIDSRM", FoodTypeIDSRM);
            cmd.Parameters.AddWithValue("@FoodMenuIDSRM", FoodMenuIDSRM);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            {
                da.Fill(dt);
            }
            return dt;
        }
        public DataTable ViewFoodSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FoodViewSRM");
            cmd.Parameters.AddWithValue("@FoodNameSRM", FoodNameSRM);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            {
                da.Fill(dt);
            }
            return dt;
        }
        public string FetchBookingCodeSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSRM", "FetchbookingcodeSRM");
            cmd.Parameters.AddWithValue("@GuestNameSRM", GuestNameSRM);  // ⭐ REQUIRED
            cmd.Parameters.AddWithValue("@RoomNameSRM", RoomNameSRM);

            object result = cmd.ExecuteScalar();
            con.Close();

            if (result == null || result == DBNull.Value)
                return "";

            return result.ToString();
        }

        public void OrderFoodSRM()
        {
            OrderDateSRM = DateTime.Now;
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "OrderFoodSRM");
            cmd.Parameters.AddWithValue("@BookingCodeSRM", BookingCodeSRM);
            cmd.Parameters.AddWithValue("@FoodMenuIDSRM", FoodMenuIDSRM);
            cmd.Parameters.AddWithValue("@QuantitySRM", QuantitySRM);
            cmd.Parameters.AddWithValue("@OrderDateSRM", OrderDateSRM);
            cmd.Parameters.AddWithValue("@TotalPriceSRM", TotalPriceSRM);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable ParkingSlotStatusSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "ParkingCountSRM");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable ViewPakingDetailsSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "ShowParkingDetailsSRM");
            cmd.Parameters.AddWithValue("@BookingCodeSRM", BookingCodeSRM);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            {
                da.Fill(dt);
            }
            return dt;
        }


        public DataTable FetchEmailTemplateSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchEmailTemplateSRM");
            //cmd.Parameters.AddWithValue("@EmailTemplateIDSRM", EmailTemplateIDSRM);
            SqlDataAdapter adpt = new SqlDataAdapter();
            adpt.SelectCommand = cmd;
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable FetchEmailSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchEmailID");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }
        public DataTable FetchRoomSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchActiveRoomSRM");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FetchBookingCodeOrderSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchBookingCodeSRM");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FetchMenuNameSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayFoodMenuSRM");
            cmd.Parameters.AddWithValue("@FoodTypeIDSRM", FoodTypeIDSRM);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplaySlotsSRM()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchSlotWiseDetailsSRM");
            cmd.Parameters.AddWithValue("@SlotName", SlotNameSRM);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;

        }

        public DataTable DisplayFoodOrdersSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DisplayFoodOrderSRM");
            cmd.Parameters.AddWithValue("@RoomNameSRM", RoomNameSRM);
            cmd.Parameters.AddWithValue("@GuestNameSRM", GuestNameSRM);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();

            return dt;
        }


        public DataTable DisplayOrderHistorySRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchActiveOrderSRM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();

            return dt;
        }


        public DataTable HistoryOfOrderFood()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "DateTimepickerforHistory");
            cmd.Parameters.AddWithValue("@StartDateSRM", StartDateSRM);
            cmd.Parameters.AddWithValue("@EndDateSRM", EndDateSRM);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchOfferTemplateSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchOfferTemplateSRM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable FetchEventTemplateSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchEventTemplateSRM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable FetchEnquiryTemplateSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "FetchEnquiryTemplateSRM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable GetMenuListSRM()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSRM", "GetMenuListSRM");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();

            return dt;
        }


        /// //////////////////////////////////////////////////////////////////////////////[ Fanish Lad  ]/////////////////////////////////////////////////////////////////////////

        public int noOfGuestFL { get; set; }
        public int provideParkingIDFL { get; set; }
        public int VehicleTypeNoFL { get; set; }
        public string BookingCodeFL { get; set; }
        public int BookingIDFL { get; set; }

        public string agentCodeFL;
        public object isvehicleFL { get; set; }
        public object isagentFL { get; set; }
        public string GuestCodeFL { get; set; }
        public int BasePriceFL { get; set; }
        public string RoomTypeNameFL { get; set; }
        public string GuestNameFL { get; set; }
        public string RoomTypeFL { get; set; }
        public string RoomNameFL { get; set; }
        public DateTime CheckInFL { get; set; }
        public DateTime CheckOutFL { get; set; }
        public TimeSpan checkInTimeFL { get; set; }
        public TimeSpan checkOutTimeFL { get; set; }
        public int NoOfGuestFL { get; set; }
        public int RoomPriceFL { get; set; }
        public bool AgentFL { get; set; }
        public bool VehicleFL { get; set; }
        public int RoomTypeIDFL { get; set; }
        public string VehicleNoFL { get; set; }
        public int RoomIDFL { get; set; }

        public string ContactNoFL { get; set; }

        public string EmailFL { get; set; }

        public string GenderFL { get; set; }

        public string AddressFL { get; set; }
        public int VehicleTypeIDFL { get; set; }
        public int ParkingSlotID { get; set; }

        public int offerIDFL { get; set; }
        public int roomTypeIDFL { get; set; }

        //------------------------------------FETCH GUEST NAME--------------------------------------------
        public DataTable FetchGuestFL()    //to fetch guest names from database
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchGuestNameFL");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //------------------------------------FETCH ROOM TYPE--------------------------------------------
        public DataTable FetchRoomTypeFL() // to fetch room types from database
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoomTypeFL");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //------------------------------------FETCH ROOM NAME BY ROOM TYPE--------------------------------------------
        public DataTable GetRoomnameByRoomTypeFL()  // to get RoomTypeID from RoomTypeName
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoomNameFL");
            cmd.Parameters.AddWithValue("@RoomIDFL", roomTypeIDFL);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //------------------------------------FETCH VEHICLE TYPE--------------------------------------------
        public DataTable FetchVehicleTypeFL() // to fetch Vehicle types from database
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchVehicleTypeFL");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //------------------------------------FETCH PARKING SLOT--------------------------------------------
        public DataTable FetchParkingSlotFL() // to fetch Parking Slot from database
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchParkingslotFL");
            cmd.Parameters.AddWithValue("@idFL", VehicleTypeIDFL);
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        //------------------------------------FETCH AGENT NAME--------------------------------------------
        public DataTable FetchAgentsFL() // to fetch Agent Name from database
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchAgentNameFL");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //------------------------------------FETCH ROOM PRICE--------------------------------------------
        public clsUser FetchRoomPriceFL() // to fetch Room Price from database
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoompriceFL");
            cmd.Parameters.AddWithValue("@RoomTypeNameFL", RoomTypeNameFL);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                BasePriceFL = Convert.ToInt32(dr["BasePrice"]);
            }
            dr.Close();
            con.Close();
            return this;
        }
        //------------------------------------ADD BOOKING--------------------------------------------
        public string AddBookingFL()
        {
            string bookingCode = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagFL", "AddBookingFL");
            cmd.Parameters.AddWithValue("@GuestCodeFL", GuestCodeFL);
            cmd.Parameters.AddWithValue("@RoomIDFL", RoomIDFL);
            cmd.Parameters.AddWithValue("@CheckInFL", CheckInFL);
            cmd.Parameters.AddWithValue("@CheckInTimeFL", checkInTimeFL);
            cmd.Parameters.AddWithValue("@CheckOutFL", CheckOutFL);
            cmd.Parameters.AddWithValue("@CheckInBFL", CheckInFL);
            cmd.Parameters.AddWithValue("@CheckOutTimeFL", checkOutTimeFL);
            cmd.Parameters.AddWithValue("@NoOfGuestFL", NoOfGuestFL);

            cmd.Parameters.AddWithValue("@AgentCodeFL",
                string.IsNullOrEmpty(agentCodeFL) ? (object)DBNull.Value : agentCodeFL);

            cmd.Parameters.AddWithValue("@OfferIDFL",
                offerIDFL == 0 ? (object)DBNull.Value : offerIDFL);

            cmd.Parameters.AddWithValue("@VehicleNumFL",
                string.IsNullOrEmpty(VehicleNoFL) ? (object)DBNull.Value : VehicleNoFL);

            cmd.Parameters.AddWithValue("@VehicleTypeIDFL",
                VehicleTypeNoFL == 0 ? (object)DBNull.Value : VehicleTypeNoFL);


            cmd.Parameters.AddWithValue("@ParkingSlotIDFL",
                ParkingSlotID == 0 ? (object)DBNull.Value : ParkingSlotID);
            // SP RETURNS BookingCode
            bookingCode = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return bookingCode;
        }
        //------------------------------------UPDATE CHECKOUT--------------------------------------------   
        public string CheckoutFL()
        {
            string result = "";
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagFL", "CheckoutFL");
            cmd.Parameters.AddWithValue("@BookingCodeFL", BookingCodeFL);
            cmd.Parameters.AddWithValue("@RoomNameFL", RoomNameFL.Trim());
            cmd.Parameters.Add("@CheckOutFL", SqlDbType.Date).Value = CheckOutFL.Date;
            cmd.Parameters.Add("@CheckOutTimeFL", SqlDbType.Time).Value = checkOutTimeFL;
            result = Convert.ToString(cmd.ExecuteScalar());
            con.Close();
            return result;
        }

        //----------------------------------------Update Room Status to Clean---------------------------------------

        public void AutoRoomStatusFL()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagFL", "AutoRoomStatusFL");

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //----------------------------------------------------------------------------------------------------------
        //----------------------------------------Validate RoomCapacity ---------------------------------------
        public DataTable GetRCapacityFL()
        {
            //for inventory quantity limit provide inventory & Asset form
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "GetCapacityCountFL");
            cmd.Parameters.AddWithValue("@RoomNameFL", RoomTypeFL);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        //-------------------------------------------------------------------------------------------------
        //----------------------TO UPDATE ROOM STATUS TO DIRTY--------------------
        public DataTable UpdAvailToDirty()
        {
            DataTable dt = new DataTable();
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "UpdateRoomToDirtyFL");
            cmd.Parameters.AddWithValue("@BookingCodeFL", BookingCodeFL);
            cmd.Parameters.AddWithValue("@RoomIDFL", RoomIDFL);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //-------------------------------------------------------------------------------------------------
        public DataTable FetchBookingByCodeFL(string bookingCode)
        {
            DataTable dt = new DataTable();
            con.Open();
            using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlagFL", "FetchBookingByCodeFL");
                cmd.Parameters.AddWithValue("@BookingCodeFL", bookingCode);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            con.Close();
            return dt;
        }

        //-----------------------------------------Fetch Booking Full Details----------------------------------------
        public DataTable FetchBookingFullDetailsFL()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagFL", "FetchBookingFullDetailsFL");
            cmd.Parameters.AddWithValue("@BookingCodeFL", BookingCodeFL);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //-----------------------------------------Fetch Booking Details----------------------------------------
        public DataTable AllBookingDetailsFL()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoomBookingDetailsFL");
            cmd.Parameters.AddWithValue("@ByBooking", "All");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //----------------------TO FETCH TODAY'S BOOKINGS FROM DATABASE--------------------
        public DataTable FetchTodaysBookingsFL()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoomBookingDetailsFL");
            cmd.Parameters.AddWithValue("@ByBooking", "Today");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        //----------------------TO FETCH ACTIVE BOOKINGS FROM DATABASE--------------------
        public DataTable GetActiveBookings()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchRoomBookingDetailsFL");
            cmd.Parameters.AddWithValue("@ByBooking", "Active");

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            return dt;
        }

        //--------------TO FETCH ACTIVE OFFERS FROM DATABASE--------------------
        public DataTable FetchOfferFL()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagFL", "FetchOfferFL");
            cmd.Parameters.AddWithValue("@idFL", offerIDFL);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;

        }

        ////////////////////////Raj Patil///////////////

        internal DateTime toDateRP1;
        internal string lblstaffname1RP;

        public string TotalHoursRP { get; set; }

        public string StaffCodeRP { get; set; }
        public int StaffID { get; set; }
        public int PositionId { get; set; }
        public string StaffName { get; set; }
        public DateTime formDateRP { get; set; }
        public DateTime toDateRP { get; set; }
        public string code { get; set; }
        public int LeaveTypeIDRP { get; set; }
        public DateTime StartDateRP { get; set; }
        public DateTime EndDateRP { get; set; }
        public DateTime ApplyDateRP { get; set; }
        public string DiscriptionRP { get; set; }
        public string DailyLeaveStatusRP { get; set; }
        public int statusIDRP { get; set; }
        public DateTime AttendDateRP { get; set; }
        public DateTime CheckInRP { get; set; }
        public DateTime CheckOutRP { get; set; }
        public string bookingcodeRP { get; set; }
        public int eventIDRP { get; set; }
        public int NoOfGuestRP { get; set; }
        public string GuestNameRP { get; set; }
        public string EventNameRP { get; set; }
        public DateTime FromDateRP { get; set; }
        public DateTime ToDateRP { get; set; }
        public string DailyLeaveTypeRP { get; set; }
        public int RoomTypeIDRP { get; set; }
        public string StaffNameRP { get; set; }
        public decimal ChargesRP { get; set; }
        public decimal TotalChargesRP { get; set; }
        public DateTime dtpFromDate { get; set; }
        public DateTime dtpToDate { get; set; }
        public string provideevent { get; set; }
        private int currentYear;
        private int currentMonth;

        public DataTable FetchNameRP(string staffname)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "FetchStaffRP");
            cmd.Parameters.AddWithValue("@StaffName", staffname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchPositionRP(string staffname)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetPosition12RP");
            cmd.Parameters.AddWithValue("@StaffName", StaffName);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchLeaveTypeRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "FetchLeaveTypeRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable YearLeaveRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "YearLeaveRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DailyLeaveRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DailyLeaveRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable PositionWiseLeaveRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "PositionWiseLeaveRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable AssignTaskRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GSTtblAssignTaskDataRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable EventRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "EventsRP");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable AssignedTaskRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "AssignedTaskRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FetchPaymentsByDateRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DateTimeRP");

            cmd.Parameters.AddWithValue("@FromDateRP", formDateRP.Date);
            cmd.Parameters.AddWithValue("@ToDateRP", toDateRP.Date);


            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;
        }

        public DataTable GetnameRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetnameRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetStaffNameRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetStaffnameRP");


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetpositionRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetPositionRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchStaffRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "FetchStaffNameRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchStaffPositionRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetPosition12RP");
            cmd.Parameters.AddWithValue("@StaffName", StaffName);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchPositionByCodeRP(string staffname)
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetPositionByCodeRP");
            cmd.Parameters.AddWithValue("@StaffName", staffname);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }
        public DataTable YearLeavePWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "YearLeavePWiseRP");
            cmd.Parameters.AddWithValue("@PositionID", PositionId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DailyLeavePWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DailyLeavePWiseRP");
            cmd.Parameters.AddWithValue("@PositionID", PositionId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable YearLeaveFPWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "YearLeaveFPWiseRP");
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            cmd.Parameters.AddWithValue("@PositionID", PositionId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DailyLeaveFPWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DailyLeaveFPWiseRP");
            cmd.Parameters.AddWithValue("@PositionID", PositionId);
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable PositionWiseLeavePWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "PositionWiseLeavePWiseRP");
            cmd.Parameters.AddWithValue("@PositionID", PositionId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public string StaffPRP()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "StaffPRP");
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            object result = cmd.ExecuteScalar();
            con.Close();

            return result == null ? "" : result.ToString();
        }

        public void ApplyLeaveRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagRP", "ApplyLeaveRP");
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            cmd.Parameters.AddWithValue("@LeaveTypeID", LeaveTypeIDRP);
            cmd.Parameters.AddWithValue("@FromDateRP", StartDateRP);
            cmd.Parameters.AddWithValue("@ToDateRP", EndDateRP);
            cmd.Parameters.AddWithValue("@ApplyDate", ApplyDateRP);
            cmd.Parameters.AddWithValue("@DailyLeaveStatus", DailyLeaveStatusRP);
            cmd.Parameters.AddWithValue("@Discription", DiscriptionRP);


            // cmd.Parameters.AddWithValue("@DailyLeaveType", DailyLeaveTypeRP);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            // paste reset code here
        }

        //ADD ATTENDANCE
        public void AddAttendanceRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "AddAttendanceRP");
            cmd.Parameters.AddWithValue("@StaffCodeRP", StaffCodeRP);
            cmd.Parameters.AddWithValue("StatusIDRP", statusIDRP);
            cmd.Parameters.AddWithValue("@AttendDateRP", AttendDateRP);
            cmd.Parameters.AddWithValue("@CheckInRP", CheckInRP);
            cmd.Parameters.AddWithValue("@CheckOutRP", CheckOutRP);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool IsAttendanceExistsRP()
        {
            bool exists = false;

            con.Open();

            SqlCommand cmd = new SqlCommand(
                @"SELECT COUNT(*) 
          FROM GSTtblAttendance
          WHERE StaffCode = @StaffCodeRP
          AND CAST(AttendDate AS DATE) = CAST(@AttendDateRP AS DATE)", con);

            cmd.Parameters.AddWithValue("@StaffCodeRP", StaffCodeRP);
            cmd.Parameters.AddWithValue("@AttendDateRP", AttendDateRP);

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            con.Close();

            if (count > 0)
            {
                exists = true;
            }

            return exists;
        }

        public void AutoMarkAbsentAfter12RP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "AutoMarkAbsentAfter12RP");
            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///DayWiseAttendance
        public DataTable DayWiseAttendanceOverViewRP()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagRP", "DayWiseAttendanceOverViewRP");
            com.Parameters.AddWithValue("@AttendDateRP", AttendDateRP);
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        public DataTable EventServiceRP()
        {
            DataTable dt = new DataTable();

            using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FlagRP", "EventServiceRP");

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        //GetGuestName
        public DataTable GetGuestNameRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetGuestNameRP");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //GetEventName
        public DataTable GetEventNameRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetEventNameRP");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //ProvideEvent

        public void ProvideEventRP()
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand("GSTHMS", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FlagRP", "TotalparticipateeventRP");
                cmd.Parameters.AddWithValue("@BookingCodeRP", bookingcodeRP);
                cmd.Parameters.AddWithValue("@EventIDRP", eventIDRP);
                cmd.Parameters.AddWithValue("@NoOfGuestRP", NoOfGuestRP);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public string BookingCodeRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "BookingCodeRP");
            cmd.Parameters.AddWithValue("@GuestNameRP", GuestNameRP);

            object result = cmd.ExecuteScalar();

            con.Close();

            return result == null ? string.Empty : result.ToString();
        }

        //AssingndTask
        public DataTable AssignedTasksRP()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagRP", "AssignedTaskRP");
            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }


        public void UpdateAttendanceRP()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagRP", "UpdatefromAttendance");
            com.Parameters.AddWithValue("@CheckOutRP", CheckOutRP);
            com.Parameters.AddWithValue("@StaffName", StaffName);
            com.ExecuteNonQuery();
            con.Close();
        }


        public DataTable AssignTaskDatefilterRP()
        {
            con.Open();
            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@FlagRP", "AssignTaskDatefilterRP");
            com.Parameters.AddWithValue("@FromDateRP", FromDateRP);
            com.Parameters.AddWithValue("@ToDateRP", ToDateRP);

            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable YearLeaveNameWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "YearLeaveNameWiseRP");
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DailyLeaveNameWiseRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DailyLeaveNameWiseRP");
            cmd.Parameters.AddWithValue("@StaffCode", StaffCodeRP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable AddemployeeRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "AddemployeeRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable DisplaydateattendanceRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "DisplaydateattendanceRP");
            cmd.Parameters.AddWithValue("@StaffNameRP", StaffNameRP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable UpdateAttendenceRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "UpdateAtttendenceRP");
            cmd.Parameters.AddWithValue("@StaffCodeRP", StaffCodeRP);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            adpt.Fill(dt5);
            con.Close();
            return dt5;
        }

        public bool UpdateARP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagRP", "UpdateARP");
            cmd.Parameters.AddWithValue("@StaffCodeRP", StaffCodeRP);
            cmd.Parameters.AddWithValue("@AttendDateRP", AttendDateRP.Date);
            cmd.Parameters.AddWithValue("@CheckOutRP", CheckOutRP);

            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows > 0; // true if updated
        }

        //internal DataTable FetchDateTimeSJ()
        //{
        //    throw new NotImplementedException();
        //}

        public DataTable FetchFromdatetodate()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "StartDateEndDate");
            cmd.Parameters.AddWithValue("@FromDateRP", StartDateRP);
            cmd.Parameters.AddWithValue("@ToDateRP", EndDateRP);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            adpt.Fill(dt5);
            con.Close();
            return dt5;
        }

        internal DataTable GetCustomerNameRP()
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetCustomerNameRP");

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable GetRoomTypeRP()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetRoomTypeRP");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchCalendarEvents(DateTime fromDate, DateTime toDate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagRP", "GetCalendarEventsRP");
            cmd.Parameters.AddWithValue("@FromDateRP", fromDate);
            cmd.Parameters.AddWithValue("@ToDateRP", toDate);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }

        public DataTable ShowStaffDetailsRP()
        {
            con.Open();

            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@FlagRP", "ShowStaffDetailsRP");

            SqlDataAdapter adpt = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();

            return dt;
        }

        public DataTable StaffCountRP()
        {
            con.Open();

            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.AddWithValue("@FlagRP", "StaffCountRP");

            SqlDataAdapter adpt = new SqlDataAdapter(com);

            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();

            return dt;
        }

        public DataTable GetPositionRP()
        {
            con.Open();

            SqlCommand com = new SqlCommand("GSTHMS", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@FlagRP", "GetPositionRP1");

            SqlDataAdapter adpt = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            adpt.Fill(dt);

            con.Close();
            return dt;
        }


        /////////////////////////////////////////////////Soham/////////////////
        ///////////////////////// Guest///////////////////////////////////
        //Grid//
        public DateTime FromDateSC { get; set; }
        public DateTime ToDateSC { get; set; }


        ///Add///
        public int CityIDSC { get; set; }
        public int CntryIDSC { get; set; }
        public int StateIDSC { get; set; }
        public string UserCodeSC { get; set; }
        public int IdSC { get; set; }
        public string NameSC { get; set; }
        public string EmailSC { get; set; }
        public string MobNoSC { get; set; }
        public int GenderSC { get; set; }
        public string CAddSC { get; set; }
        public string CountrySC { get; set; }
        public string StateSC { get; set; }
        public string CitySC { get; set; }
        public int PinCodeSC { get; set; }
        public DateTime JoinDateSC { get; set; }
        public string SelectedDocumentsSC { get; set; }
        //View//
        public string GuestCodeSC { get; set; }
        //Update//
        public string VendorCodeSC { get; set; }
        public string filePathSC { get; set; }
        public int CityIDDSC { get; set; }
        public string GuestNameSC { get; set; }
        public int CountryIdSC { get; set; }
        public string AddressSC { get; set; }
        public long PincodeSC { get; set; }
        public string EmailIDSC { get; set; }
        public long ContactNoSC { get; set; }
        public int StateIDDSC { get; set; }
        public int GeustCode { get; set; }
        public string FilePath { get; set; }
        public string filePathPSC { get; set; }

        public int SubTypeIdSC { get; set; }

        public string PersonCodeSC { get; set; }


        /////////////////////Guest Management///////////////////////////////
        ///
        //------------------Add Guest----------------------------

        //--------Fetch Country----------------
        public DataTable FetchCountrySC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchCountrySC");
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //--------Fetch State----------------
        public DataTable FetchStateSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchStateSC");
            cmd.Parameters.AddWithValue("@idSC", CntryIDSC);
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //--------Fetch City----------------
        public DataTable FetchCitySC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchCitySC");
            cmd.Parameters.AddWithValue("@idSC", StateIDSC);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //--------Fetch Gender----------------
        public DataTable FetchGenderSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchGenderSC");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //---------Fetch Sub Documents----------------
        public DataTable FetchSubDocSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchSubTypeDoc");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //---------Save Guest Details----------------
        public void SaveGuestDetailsSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlagSC", "SaveGuestSC");

            cmd.Parameters.AddWithValue("@nameSC", NameSC);
            cmd.Parameters.AddWithValue("@emailSC", EmailSC);
            cmd.Parameters.AddWithValue("@genderSC", GenderSC);
            cmd.Parameters.AddWithValue("@contactSC", MobNoSC);
            cmd.Parameters.AddWithValue("@pincodeSC", PinCodeSC);
            cmd.Parameters.AddWithValue("@CaddSC", CAddSC);
            cmd.Parameters.AddWithValue("@joindateSC", JoinDateSC);
            cmd.Parameters.AddWithValue("@idSC", CityIDSC);
            cmd.Parameters.AddWithValue("@codeSC", UserCodeSC);

            cmd.ExecuteNonQuery();
            con.Close();
        }

        ///////////////////// Update Guest//////////////
        public DataTable FetchGuestDetailsUSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchGuestDetailsUSC");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable FetchCountryUSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchCountrySC");
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //Fetching State
        public DataTable StateDisplaySC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "fetchUStateSC");
            cmd.Parameters.AddWithValue("@CountryIDSC", CountryIdSC);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }

        //SaveCity
        public DataTable CityDisplaySC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "fetchUcitySC");
            cmd.Parameters.AddWithValue("@StateIdSC ", StateIDSC);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        //GENDER
        public DataTable FetchGenderUSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchUGenderSC");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //Subtype
        public DataTable FetchSubDocUSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchSubTypeUDoc");
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            con.Close();
            return dt;

        }
        //Upadate Enquiry
        public void UpdateGeustDetailsSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "EditGuestDetails");
            // cmd.Parameters.AddWithValue("@GuestNameSC", GuestNameSC);
            cmd.Parameters.AddWithValue("@EmailUSC", EmailIDSC);
            // cmd.Parameters.AddWithValue("@genderSC", GenderSC);
            cmd.Parameters.AddWithValue("@ContactNoSC", ContactNoSC);
            // cmd.Parameters.AddWithValue("@CityIDSC", CityIDSC);
            // cmd.Parameters.AddWithValue("@AddressSC", AddressSC);
            // cmd.Parameters.AddWithValue("@pincodeSC", PincodeSC);
            cmd.Parameters.AddWithValue("@GuestCodeSC", GuestCodeSC);
            cmd.ExecuteNonQuery();
            con.Close();

        }
        public void UploadDocumentSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "UploadBillSC");
            cmd.Parameters.AddWithValue("@SubTypeIDSC", SubTypeIdSC);
            cmd.Parameters.AddWithValue("@PersonCodeSC", PersonCodeSC);
            cmd.Parameters.AddWithValue("@PathSC", filePathSC);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UploadPhotoSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "UploadPhotoSC");
            cmd.Parameters.AddWithValue("@PersonCodeSC", PersonCodeSC);
            cmd.Parameters.AddWithValue("@PathPSC", filePathPSC);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string DocGuestCode()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "DoctGuestCodeSC");
            object Result = cmd.ExecuteScalar();
            con.Close();
            return Result.ToString();
        }
        /////////////////////////////////////////////

        public void UpdateDocumentSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "EditDocumentSC");
            cmd.Parameters.AddWithValue("@SubTypeIDSC", SubTypeIdSC);
            cmd.Parameters.AddWithValue("@GuestCodeSC", PersonCodeSC);
            cmd.Parameters.AddWithValue("@PathSC", filePathSC);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void UpdatePhotoSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "EditPhotoSC");
            cmd.Parameters.AddWithValue("@PersonCodeSC", PersonCodeSC);
            cmd.Parameters.AddWithValue("@PathPSC", filePathPSC);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public DataTable CheckDuplicateDocumentSC()
        {
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "CheckDuplicateDocumentSC");
            cmd.Parameters.AddWithValue("@PersonCodeSC", PersonCodeSC);
            cmd.Parameters.AddWithValue("@SubTypeIDSC", SubTypeIdSC);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;
        }


        ///////////////////////////GusetViewDetails//////////////////////////
        public DataTable ViewGuestDetailsSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "ViewGuestDetailsSC");
            cmd.Parameters.AddWithValue("@GuestCodeSC", GuestCodeSC);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt5 = new DataTable();
            adpt.Fill(dt5);
            con.Close();
            return dt5;
        }
        public DataTable DisplaySubTypeNameSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "DisplaySubTypeNameSC");
            cmd.Parameters.AddWithValue("@GuestCodeSC", GuestCodeSC);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt7 = new DataTable();
            adpt.Fill(dt7);
            con.Close();
            return dt7;
        }
        public DataTable DisplayPhotoSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "DisplayPhoto");
            cmd.Parameters.AddWithValue("@GuestCodeSC", GuestCodeSC);
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt7 = new DataTable();
            adpt.Fill(dt7);
            con.Close();
            return dt7;
        }
        /////Grid///

        public DataTable FetchGuestDetailsSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "FetchGuestDetailsSC");
            DataTable dt = new DataTable();
            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            adpt.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable FetchGuestByDateSC()
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagSC", "DateTimeGuestSC");
            cmd.Parameters.AddWithValue("@FromDateSC", FromDateSC.Date);
            cmd.Parameters.AddWithValue("@ToDateSC", ToDateSC.Date);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dtTime = new DataTable();
            adpt.Fill(dtTime);

            con.Close();
            return dtTime;


        }
        public DataTable DeleteGuestSC()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("GSTHMS", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FlagPSS", "DeleteGuestSC");
            cmd.Parameters.AddWithValue("@GuestCodeSC", GuestCodeSC);

            SqlDataAdapter adpt = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            adpt.Fill(dt);

            con.Close();
            return dt;

        }

    }

}