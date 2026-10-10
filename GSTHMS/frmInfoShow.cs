using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Guna.UI2.WinForms;

namespace GSTHMS
{
    public partial class frmInfoShow : Form
    {
        string filterValue;
        string filterType;
        DateTime fromDate;
        DateTime toDate;
        bool isDateFilter = false;
        private DataTable masterTable;

        int pageSize = 10;
        int currentPage = 1;
        int totalRecords = 0;
        int totalPages = 0;

        private DataTable searchTable;
        DataTable filteredTable; // optional

        private DataTable currentFilteredRoomData;

        // ---------------- CONSTRUCTORS ----------------

        public frmInfoShow(string value, string type)
        {
            InitializeComponent();
            filterValue = value;
            filterType = type;
            isDateFilter = false;
        }

        public frmInfoShow(string value, string type, DateTime from, DateTime to)
        {
            InitializeComponent();
            filterValue = value;
            filterType = type;
            fromDate = from;
            toDate = to;
            isDateFilter = true;
        }

        public frmInfoShow(string value, string type, DataTable filteredData)
        {
            InitializeComponent();
            filterValue = value;
            filterType = type;
            currentFilteredRoomData = filteredData;
        }

        // ---------------- FORM LOAD ----------------

        private void frmInfoShow_Load(object sender, EventArgs e)
        {
            grdInfo.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInfo.GridColor = Color.Gray;

            grdInfo.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdInfo.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);




            if (filterType == "YEAR" || filterType == "GENDER")
                LoadFilteredData();
            else if (filterType == "Services")
                LoadServices(filterValue);
            else if (filterType == "ROOMSTATUS")
                LoadRoomStatus();
            else if (filterType == "PAYMENT_STATUS")
                LoadPaymentStatus();
            else if (filterType == "PAYMENT_MODE")
                LoadPaymentMode();
            else if (filterType == "BOOKING_MONTH")
                LoadBookingByMonth();
            else if (filterType == "INVENTORY_STATUS")
                LoadInventoryByStatus();
            else if (filterType == "EVENT_STATUS")
                LoadEventByStatus();
            else if (filterType == "STAFF_POSITION")
                LoadStaffByPosition();
            else if (filterType == "VENDOR_CITY")
                LoadVendorByCity();
            else if (filterType == "GUEST_ENQUIRY")
                LoadGuestEnquiryData();
            else if (filterType == "INVENTORY_SUBTYPE")
                LoadInventoryBySubType();
            // Sorting नंतर SrNo correct राहील
            grdInfo.Sorted += (s, ev) => AddSequentialSrNo();

            SetInfoLabel();
        }

        // ---------------- COMMON GRID FINALIZER ----------------

        private void FinalizeGrid()
        {
            HideDatabaseSrNo();
            AddSequentialSrNo();
        }

        // ---------------- SR NO LOGIC ----------------

        private void HideDatabaseSrNo()
        {
            string[] srColumns = { "SrNo", "SRNO", "S.No", "SNo", "SerialNo", "Sr No" };

            foreach (DataGridViewColumn col in grdInfo.Columns)
            {
                if (srColumns.Any(x =>
                    col.Name.Equals(x, StringComparison.OrdinalIgnoreCase) ||
                    col.HeaderText.Equals(x, StringComparison.OrdinalIgnoreCase)))
                {
                    col.Visible = false;
                }
            }
        }

        private void AddSequentialSrNo()
        {
            if (grdInfo.Columns.Contains("SrNo_New"))
                grdInfo.Columns.Remove("SrNo_New");

            DataGridViewTextBoxColumn srCol = new DataGridViewTextBoxColumn
            {
                Name = "SrNo_New",
                HeaderText = "Sr No",
                Width = 60,
                ReadOnly = true,
                DefaultCellStyle = { Alignment = DataGridViewContentAlignment.MiddleCenter }
            };

            grdInfo.Columns.Insert(0, srCol);

            for (int i = 0; i < grdInfo.Rows.Count; i++)
            {
                if (!grdInfo.Rows[i].IsNewRow)
                    grdInfo.Rows[i].Cells["SrNo_New"].Value = i + 1;
            }
        }
        //INventory Asset And ll
        private void LoadInventoryBySubType()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.InventoryAP();

            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["SubTypeName"].ToString()
                        .Equals(filterValue,
                        StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(
                        row["PurchaseDate"].ToString(),
                        out DateTime pdate) &&
                    (pdate.Date < fromDate.Date ||
                     pdate.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }
        // ---------------- REPORT METHODS ----------------
        private void LoadGuestEnquiryData()
        {
            DataTable filtered;

            // ================= GUESTS =================
            if (filterValue.Equals("Guests", StringComparison.OrdinalIgnoreCase))
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GuestAP();

                filtered = dt.Clone();

                foreach (DataRow row in dt.Rows)
                {
                    if (isDateFilter)
                    {
                        if (DateTime.TryParse(row["RegistrationDate"].ToString(), out DateTime reg))
                        {
                            if (reg.Date < fromDate.Date || reg.Date > toDate.Date)
                                continue;
                        }
                    }

                    filtered.ImportRow(row);
                }

                grdInfo.DataSource = filtered;
            }

            // ================= ENQUIRIES =================
            else
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.EnquiryAP();

                filtered = dt.Copy();

                grdInfo.DataSource = filtered;
            }

            FinalizeGrid();
        }
        private void LoadFilteredData()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.GuestAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!DateTime.TryParse(row["RegistrationDate"].ToString(), out DateTime regDate))
                    continue;

                if (isDateFilter &&
                    (regDate.Date < fromDate.Date || regDate.Date > toDate.Date))
                    continue;

                if (filterType == "YEAR" && regDate.Year.ToString() == filterValue)
                    filtered.ImportRow(row);
                else if (filterType == "GENDER" &&
                    row["Gender"].ToString().Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }
        private bool IsValidService(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Trim() != "No Services" &&
                   value.Trim() != "--";
        }
        private void LoadServices(string filterValue)
        {
            clsUser obj = new clsUser();

            DataTable dt;

            if (isDateFilter)
            {
                obj.fromdateAP = fromDate.Date;
                obj.todateAP = toDate.Date;

                clsUser copyObj = new clsUser(obj);
                dt = copyObj.ServiceSerchAP();
            }
            else
            {
                dt = obj.ServiceAP();
            }

            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                string inventory = row["Inventory"]?.ToString();
                string food = row["Food"]?.ToString();
                string parking = row["Parking"]?.ToString();

                if (filterValue.Equals("Inventory", StringComparison.OrdinalIgnoreCase))
                {
                    if (IsValidService(inventory))
                        filtered.ImportRow(row);
                }
                else if (filterValue.Equals("Food", StringComparison.OrdinalIgnoreCase))
                {
                    if (IsValidService(food))
                        filtered.ImportRow(row);
                }
                else if (filterValue.Equals("Parking", StringComparison.OrdinalIgnoreCase))
                {
                    if (IsValidService(parking))
                        filtered.ImportRow(row);
                }
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }
        private void LoadRoomStatus()
        {
            if (currentFilteredRoomData == null) return;

            DataTable filtered = currentFilteredRoomData.Clone();

            foreach (DataRow row in currentFilteredRoomData.Rows)
            {
                if (row["Status"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }

        private void LoadPaymentStatus()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.PaymentAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["Status"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(row["PaymentDate"].ToString(), out DateTime pdate) &&
                    (pdate.Date < fromDate.Date || pdate.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }


            grdInfo.DataSource = filtered;
            FinalizeGrid();
            // CalculateStatusPaidAmount();
           // CalculateTotalPendingAmount();
        }
        private void CalculateTotalPendingAmount()
        {
            decimal totalPending = 0;

            foreach (DataGridViewRow row in grdInfo.Rows)
            {
                if (row.IsNewRow) continue;

                decimal paidAmount = 0;
                decimal amtToPay = 0;

                // Paid Amount
                if (row.Cells["Paid Amount (₹)"].Value != null)
                {
                    decimal.TryParse(
                        row.Cells["Paid Amount (₹)"].Value.ToString()
                            .Replace("₹", "")
                            .Replace(",", ""),
                        out paidAmount
                    );
                }

                // Amount To Pay
                if (row.Cells["Amt To Pay (₹)"].Value != null)
                {
                    decimal.TryParse(
                        row.Cells["Amt To Pay (₹)"].Value.ToString()
                            .Replace("₹", "")
                            .Replace(",", ""),
                        out amtToPay
                    );
                }

                // Pending = AmtToPay - PaidAmount
                decimal pending = amtToPay - paidAmount;

                if (pending > 0)
                    totalPending += pending;
            }

            lblTotalAmount.Text = "Pending Amount : ₹ " + totalPending.ToString("N2");
            lblTotalAmount.Visible = true;
        }

        private void LoadPaymentMode()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.PaymentAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["PaymentMethodType"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(row["PaymentDate"].ToString(), out DateTime pdate) &&
                    (pdate.Date < fromDate.Date || pdate.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
            CalculateTotalPaidAmount();
        }

        private void LoadBookingByMonth()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.BookingAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!DateTime.TryParse(row["Checkin"].ToString(), out DateTime checkin))
                    continue;

                if (isDateFilter &&
                    (checkin.Date < fromDate.Date || checkin.Date > toDate.Date))
                    continue;

                if (checkin.Month.ToString() == filterValue)
                    filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }

        private void LoadInventoryByStatus()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.InventoryAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["Status"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(row["PurchaseDate"].ToString(), out DateTime pdate) &&
                    (pdate.Date < fromDate.Date || pdate.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }

        private void LoadEventByStatus()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.EventAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["Status"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(row["StartDate"].ToString(), out DateTime sdate) &&
                    (sdate.Date < fromDate.Date || sdate.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }

        private void LoadStaffByPosition()
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.StaffAP();
            DataTable filtered = dt.Clone();

            foreach (DataRow row in dt.Rows)
            {
                if (!row["PositionName"].ToString()
                    .Equals(filterValue, StringComparison.OrdinalIgnoreCase))
                    continue;

                if (isDateFilter &&
                    DateTime.TryParse(row["JoinDate"].ToString(), out DateTime join) &&
                    (join.Date < fromDate.Date || join.Date > toDate.Date))
                    continue;

                filtered.ImportRow(row);
            }

            grdInfo.DataSource = filtered;
            FinalizeGrid();
        }

        private void LoadVendorByCity()
        {
            if (currentFilteredRoomData == null) return;

            grdInfo.DataSource = currentFilteredRoomData;
            FinalizeGrid();

            lblTotalAmount.Visible = false;
        }

        // ---------------- AMOUNT CALCULATIONS ----------------

        private void CalculateTotalPaidAmount()
        {
            decimal total = 0;

            foreach (DataGridViewRow row in grdInfo.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Paid Amount (₹)"]?.Value != null &&
                    decimal.TryParse(row.Cells["Paid Amount (₹)"].Value
                        .ToString().Replace("₹", "").Replace(",", ""), out decimal amt))
                {
                    total += amt;
                }
            }

            lblTotalAmount.Text = "Total Amount : ₹ " + total.ToString("N2");
            lblTotalAmount.Visible = true;
        }

        private void CalculateStatusPaidAmount()
        {
            decimal total = 0, paid = 0;

            foreach (DataGridViewRow row in grdInfo.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["Amt To Pay (₹)"]?.Value != null &&
                    decimal.TryParse(row.Cells["Amt To Pay (₹)"].Value
                        .ToString().Replace("₹", "").Replace(",", ""), out decimal amt))
                    total += amt;

                if (row.Cells["Paid Amount (₹)"]?.Value != null &&
                    decimal.TryParse(row.Cells["Paid Amount (₹)"].Value
                        .ToString().Replace("₹", "").Replace(",", ""), out decimal p))
                    paid += p;
            }

            lblTotalAmount.Text = $"Pending : ₹ {(total - paid):N2}";
            lblTotalAmount.Visible = true;
        }

        // ---------------- BACK BUTTON ----------------


        private void SetInfoLabel()
        {
            string title = "";

            switch (filterType)
            {
                case "YEAR":
                    title = $"Guest Report - Year : {filterValue}";
                    break;

                case "GENDER":
                    title = $"Guest Report - Gender : {filterValue}";
                    break;

                case "Services":
                    title = $"Service Usage Report - Service : {filterValue}";
                    break;

                case "ROOMSTATUS":
                    title = $"Room Report - Status : {filterValue}";
                    break;

                case "PAYMENT_STATUS":
                    title = $"Payment Report - Status : {filterValue}";
                    break;

                case "PAYMENT_MODE":
                    title = $"Payment Report - Mode : {filterValue}";
                    break;

                case "BOOKING_MONTH":
                    title = $"Booking Report - Month : {filterValue}";
                    break;

                case "INVENTORY_STATUS":
                    title = $"Inventory Report - Status : {filterValue}";
                    break;

                case "EVENT_STATUS":
                    title = $"Event Report - Status : {filterValue}";
                    break;

                case "STAFF_POSITION":
                    title = $"Staff Report - Position : {filterValue}";
                    break;

                case "VENDOR_CITY":
                    title = $"Vendor Report - City : {filterValue}";
                    break;

                default:
                    title = "Information Report";
                    break;
            }

            // Date filter असल्यास append करा
            if (isDateFilter)
            {
                title += $"  ( {fromDate:dd-MMM-yyyy} to {toDate:dd-MMM-yyyy} )";
            }

            lblInfoTitle.Text = title;
        }

        private void pctBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

        }

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {

        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportToPDF();
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel();
        }
        private DataTable GetGridData()
        {
            DataTable dt = new DataTable();

            // Skip hidden columns if needed
            foreach (DataGridViewColumn col in grdInfo.Columns)
            {
                if (col.Visible)
                    dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in grdInfo.Rows)
            {
                if (row.IsNewRow) continue;

                DataRow dr = dt.NewRow();

                int colIndex = 0;

                foreach (DataGridViewColumn col in grdInfo.Columns)
                {
                    if (col.Visible)
                    {
                        dr[colIndex] = row.Cells[col.Index].Value?.ToString() ?? "";
                        colIndex++;
                    }
                }

                dt.Rows.Add(dr);
            }

            return dt;
        }
        private void ExportToExcel()
        {
            DataTable dt = GetGridData();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data found!");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = GetReportName() + ".xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Report");

                    // TITLE
                    ws.Cell(1, 1).Value = lblInfoTitle.Text;
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 18;

                    ws.Range(1, 1, 1, dt.Columns.Count).Merge();

                    // DATE
                    ws.Cell(2, 1).Value =
                        "Generated On : " + DateTime.Now.ToString("dd-MM-yyyy");

                    ws.Range(2, 1, 2, dt.Columns.Count).Merge();

                    // TABLE
                    ws.Cell(4, 1).InsertTable(dt);

                    // HEADER STYLE
                    var header = ws.Range(4, 1, 4, dt.Columns.Count);

                    header.Style.Font.Bold = true;
                    header.Style.Fill.BackgroundColor = XLColor.LightGray;
                    header.Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Center;

                    ws.Columns().AdjustToContents();

                    wb.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel Exported Successfully!");
            }

        }
        private void ExportToPDF()
        {
            DataTable dt = GetGridData();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data found!");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = GetReportName() + ".pdf";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Document doc =
                new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);

            PdfWriter.GetInstance(doc,
                new FileStream(save.FileName, FileMode.Create));

            doc.Open();

            // TITLE
            Paragraph title = new Paragraph(
                lblInfoTitle.Text,
                FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    18));

            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;

            doc.Add(title);

            // DATE
            Paragraph date = new Paragraph(
                "Generated On : " +
                DateTime.Now.ToString("dd-MM-yyyy"),

                FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    10));

            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 10;

            doc.Add(date);

            // TABLE
            PdfPTable table =
                new PdfPTable(dt.Columns.Count);

            table.WidthPercentage = 100;

            // HEADERS
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(
                    new Phrase(
                        col.ColumnName,
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            10)));

                cell.BackgroundColor =
                    new BaseColor(220, 220, 220);

                cell.HorizontalAlignment =
                    Element.ALIGN_CENTER;

                table.AddCell(cell);
            }

            // ROWS
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    table.AddCell(
                        new Phrase(
                            item.ToString(),
                            FontFactory.GetFont(
                                FontFactory.HELVETICA,
                                9)));
                }
            }

            doc.Add(table);

            doc.Close();

            MessageBox.Show("PDF Saved Successfully!");
        }
        private string GetReportName()
        {
            string reportName = "Information_Report";

            switch (filterType)
            {
                case "YEAR":
                    reportName = $"Guest_Report_Year_{filterValue}";
                    break;

                case "GENDER":
                    reportName = $"Guest_Report_Gender_{filterValue}";
                    break;

                case "Services":
                    reportName = $"Service_Report_{filterValue}";
                    break;

                case "ROOMSTATUS":
                    reportName = $"Room_Report_{filterValue}";
                    break;

                case "PAYMENT_STATUS":
                    reportName = $"Payment_Status_{filterValue}";
                    break;

                case "PAYMENT_MODE":
                    reportName = $"Payment_Mode_{filterValue}";
                    break;

                case "BOOKING_MONTH":
                    reportName = $"Booking_Report_Month_{filterValue}";
                    break;

                case "INVENTORY_STATUS":
                    reportName = $"Inventory_Report_{filterValue}";
                    break;

                case "EVENT_STATUS":
                    reportName = $"Event_Report_{filterValue}";
                    break;

                case "STAFF_POSITION":
                    reportName = $"Staff_Report_{filterValue}";
                    break;

                case "VENDOR_CITY":
                    reportName = $"Vendor_Report_{filterValue}";
                    break;

                case "GUEST_ENQUIRY":
                    reportName = $"{filterValue}_Report";
                    break;
            }

            return reportName.Replace(" ", "_");
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBox.Text.Trim().ToLower();

                // Current Grid Data
                DataTable dt = ((DataTable)grdInfo.DataSource);

                if (dt == null)
                    return;

                // Original table store once
                if (searchTable == null)
                    searchTable = dt.Copy();

                // Empty search = show all data
                if (string.IsNullOrWhiteSpace(searchText))
                {
                    grdInfo.DataSource = searchTable;
                    FinalizeGrid();
                    return;
                }

                DataTable filteredTable = searchTable.Clone();

                foreach (DataRow row in searchTable.Rows)
                {
                    bool found = false;

                    foreach (DataColumn col in searchTable.Columns)
                    {
                        if (row[col] != null &&
                            row[col].ToString().ToLower().Contains(searchText))
                        {
                            found = true;
                            break;
                        }
                    }

                    if (found)
                        filteredTable.ImportRow(row);
                }

                grdInfo.DataSource = filteredTable;

                FinalizeGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
