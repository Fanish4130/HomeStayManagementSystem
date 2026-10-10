using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmInformationAM : Form
    {
        DateTime FD;
        DateTime TD;
        int pagesizeAM = 10;
        int currentpageAM = 1;
        int totrecordsAM = 0;
        int totpageAM = 0;
        string PDFTitleAM;
        string RoomTypeAM;
        DataTable dtAM = new DataTable();
        private System.Windows.Forms.CheckBox headerCheckBoxAM;
        public DataTable FullData;

        // Flag to prevent recursive checkbox events
        private bool isHeaderCheckBoxUpdating = false;

        public frmInformationAM(string nameAM)
        {
            InitializeComponent();
            lblInfo.Text = nameAM;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public frmInformationAM(string nameAM, DateTime fd, DateTime td)
        {
            InitializeComponent();
            lblInfo.Text = nameAM;
            FD = fd;
            TD = td;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void frmInformationAM_Load(object sender, EventArgs e)
        {
            try
            {
                grdInformation.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grdInformation.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdInformation.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdInformation.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdInformation.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdInformation.GridColor = System.Drawing.Color.Gray;

                pctTodaysPayment.Visible = false;

                AddHeaderCheckBoxAM();

                // Wire up Cell content events for persistent selection
                grdInformation.CellValueChanged += GrdInformation_CellValueChanged;
                grdInformation.CurrentCellDirtyStateChanged += GrdInformation_CurrentCellDirtyStateChanged;

                MainLoadAM();
                pnlFilters.Visible = true;
                FilterShowAM();
                grdInformation.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainLoadAM()
        {
            try
            {
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "Download The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Excel");
                toolTip1.SetToolTip(pctFilter, "Filters");
                toolTip1.SetToolTip(pctTodaysPayment, "Todays Payments");

                clsUser objAM = new clsUser();
                this.grdInformation.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);

                if (headerCheckBoxAM != null)
                    headerCheckBoxAM.Checked = false;

                if (lblInfo.Text == "Total Guest")
                {
                    objAM.FromDAM = FD;
                    objAM.ToDAM = TD;
                    dtpTo1.Value = TD;
                    dtpFrom1.Value = FD;
                    dtAM = objAM.GetGuestInfoAM();
                }
                else if (lblInfo.Text == "Active Bookings")
                {
                    dtAM = objAM.GetActiveBookingInfoAM();
                    DataTable d1 = objAM.GetRoomAM();
                    cmbbxFilters.DisplayMember = "RoomName";
                    cmbbxFilters.ValueMember = "RoomName";
                    cmbbxFilters.DataSource = d1;
                }
                else if (lblInfo.Text == "Total Payment")
                {
                    objAM.FromDAM = FD;
                    objAM.ToDAM = TD;
                    dtpTo1.Value = TD;
                    dtpFrom1.Value = FD;
                    dtAM = objAM.GetTotalPaymentInfoAM();
                    CalculateTotalFromAllPagesAM(dtAM);
                }
                else if (lblInfo.Text == "Todays Events")
                {
                    dtAM = objAM.GetTodaysEventInfoAM();
                    DataTable d1 = objAM.GetEventNameAM();
                    cmbbxFilters.DisplayMember = "EventName";
                    cmbbxFilters.ValueMember = "EventName";
                    cmbbxFilters.DataSource = d1;
                    lblTotalIncome1.Visible = false;
                    pnlFilters.Visible = false;
                    pctTodaysPayment.Visible = false;
                    pctFilter.Visible = false;
                }
                else if (lblInfo.Text == "Low-Stock Inventory List")
                {
                    objAM.StatusAM = "Low-Stock";
                    dtAM = objAM.GetInventoryInfoByStatusAM();
                }
                else if (lblInfo.Text == "In-Stock Inventory List")
                {
                    objAM.StatusAM = "In-Stock";
                    dtAM = objAM.GetInventoryInfoByStatusAM();
                }
                else if (lblInfo.Text == "Todays Check-Out")
                {
                    dtAM = objAM.GetTodaysCheckOutInfoAM();
                }
                else if (lblInfo.Text == "Present Employee Count")
                {
                    objAM.StatusAM = "Present";
                    dtAM = objAM.GetAttendanceByStatusAM();
                    lblTotalIncome1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                }
                else if (lblInfo.Text == "Absent Employee Count")
                {
                    objAM.StatusAM = "Absent";
                    dtAM = objAM.GetAttendanceByStatusAM();
                    pnlFilters.Visible = false;
                    pctFilter.Visible = false;
                    lblTotalIncome1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                    pctTodaysPayment.Visible = false;
                }
                else if (lblInfo.Text == "On Leave Employee Count")
                {
                    objAM.StatusAM = "On Leave";
                    dtAM = objAM.GetAttendanceByStatusAM();
                    lblTotalIncome1.Text = DateTime.Today.ToString("dd/MM/yyyy");
                }
                else if (lblInfo.Text == "Paid Payment Information")
                {
                    if (FD.Date == DateTime.Today && TD.Date == DateTime.Today)
                    {
                        objAM.StatusIDAM = 22;
                        dtAM = objAM.GuestPaymentInfoByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                    else
                    {
                        objAM.StatusIDAM = 22;
                        objAM.FromDAM = FD;
                        objAM.ToDAM = TD;
                        dtAM = objAM.GuestPaymentInfoDTByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                }
                else if (lblInfo.Text == "Pending Payment Information")
                {
                    if (FD.Date == DateTime.Today && TD.Date == DateTime.Today)
                    {
                        objAM.StatusIDAM = 4;
                        dtAM = objAM.GuestPaymentInfoByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                    else
                    {
                        objAM.StatusIDAM = 4;
                        objAM.FromDAM = FD;
                        objAM.ToDAM = TD;
                        dtAM = objAM.GuestPaymentInfoDTByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                }
                else if (lblInfo.Text == "Occupied Room Information")
                {
                    objAM.StatusIDAM = 12;
                    dtAM = objAM.RoomInfoByStatusAM();
                }
                else if (lblInfo.Text == "Unclean Room Information")
                {
                    objAM.StatusIDAM = 19;
                    dtAM = objAM.RoomInfoByStatusAM();
                }
                else if (lblInfo.Text == "Available Room Information")
                {
                    objAM.StatusIDAM = 16;
                    dtAM = objAM.RoomInfoByStatusAM();
                }
                else if (lblInfo.Text == "Cleaning Room Information")
                {
                    objAM.StatusIDAM = 18;
                    dtAM = objAM.RoomInfoByStatusAM();
                }
                else if (lblInfo.Text == "Parking Information Of Slot - A1")
                {
                    objAM.ForSearchAM = "Slot-A1";
                    dtAM = objAM.ParkingInfoOfSlot(); 
                }
                else if (lblInfo.Text == "Parking Information Of Slot - A2")
                {
                    objAM.ForSearchAM = "Slot-A2";
                    dtAM = objAM.ParkingInfoOfSlot();
                }
                else if (lblInfo.Text == "Parking Information Of Slot - B1")
                {
                    objAM.ForSearchAM = "Slot-B1";
                    dtAM = objAM.ParkingInfoOfSlot();
                }
                else if (lblInfo.Text == "Parking Information Of Slot - B2")
                {
                    objAM.ForSearchAM = "Slot-B2";
                    dtAM = objAM.ParkingInfoOfSlot();
                }
                else if (lblInfo.Text == "Parking Information Of Slot - C1")
                {
                    objAM.ForSearchAM = "Slot-C1";
                    dtAM = objAM.ParkingInfoOfSlot();
                }

                InitializeGlobalSelectionState();

                FullData = dtAM.Copy();
                totrecordsAM = dtAM.Rows.Count;
                totpageAM = (int)Math.Ceiling((double)totrecordsAM / pagesizeAM);

                LoadPageAM();
                CreatePagiButtonAM();
                FilterShowAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- GLOBAL SELECTION LOGIC ---
        private void InitializeGlobalSelectionState()
        {
            if (dtAM == null) return;

            if (!dtAM.Columns.Contains("IsSelected"))
            {
                DataColumn colSelect = new DataColumn("IsSelected", typeof(bool)) { DefaultValue = false };
                dtAM.Columns.Add(colSelect);
                colSelect.SetOrdinal(0);
            }

            if (!dtAM.Columns.Contains("GlobalRowID"))
            {
                DataColumn colID = new DataColumn("GlobalRowID", typeof(int));
                dtAM.Columns.Add(colID);
                for (int i = 0; i < dtAM.Rows.Count; i++)
                {
                    dtAM.Rows[i]["GlobalRowID"] = i;
                }
            }
        }

        public void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentpageAM > 1)
            {
                currentpageAM--;
                LoadPageAM();
                CreatePagiButtonAM();
            }
        }

        public void bntNext_Click(object sender, EventArgs e)
        {
            totpageAM = (int)Math.Ceiling((double)totrecordsAM / pagesizeAM);
            if (currentpageAM < totpageAM)
            {
                currentpageAM++;
                LoadPageAM();
                CreatePagiButtonAM();
            }
        }

        public void LoadPageAM()
        {
            try
            {
                // Modification: Bind empty cloned table if there are 0 records so columns still display
                if (dtAM == null || dtAM.Rows.Count == 0)
                {
                    if (dtAM != null)
                    {
                        DataTable dtEmpty = dtAM.Clone();
                        grdInformation.DataSource = dtEmpty;

                        if (grdInformation.Columns.Contains("GlobalRowID"))
                            grdInformation.Columns["GlobalRowID"].Visible = false;

                        if (grdInformation.Columns.Contains("IsSelected"))
                        {
                            grdInformation.Columns["IsSelected"].HeaderText = "";
                            grdInformation.Columns["IsSelected"].Width = 40;
                        }
                    }
                    else
                    {
                        grdInformation.DataSource = null;
                    }

                    UpdateHeaderCheckboxState();
                    return;
                }

                int startIndexAM = (currentpageAM - 1) * pagesizeAM;
                DataTable dttempAM = dtAM.Clone();

                for (int i = startIndexAM; i < startIndexAM + pagesizeAM && i < dtAM.Rows.Count; i++)
                {
                    dttempAM.ImportRow(dtAM.Rows[i]);
                }

                grdInformation.DataSource = dttempAM;

                if (grdInformation.Columns.Contains("GlobalRowID"))
                    grdInformation.Columns["GlobalRowID"].Visible = false;

                if (grdInformation.Columns.Contains("IsSelected"))
                {
                    grdInformation.Columns["IsSelected"].HeaderText = "";
                    grdInformation.Columns["IsSelected"].Width = 40;
                }

                UpdateHeaderCheckboxState();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error formatting page data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePagiButtonAM()
        {
            int bwidthAM = 40;
            int bheightAM = 35;
            int spacingAM = 5;
            int startXAM = 10;
            pnlPagination.Controls.Clear();

            foreach (System.Windows.Forms.Control ctr in pnlPagination.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
            {
                if (ctr.Name.StartsWith("btnPage"))
                    pnlPagination.Controls.Remove(ctr);
            }

            if (dtAM == null) return;

            int totalPagesAM = (int)Math.Ceiling((double)dtAM.Rows.Count / pagesizeAM);
            totpageAM = totalPagesAM;

            for (int i = 1; i <= totalPagesAM; i++)
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidthAM, bheightAM);
                btnPage.Location = new Point(startXAM, 5);
                btnPage.FillColor = (i == currentpageAM) ? System.Drawing.Color.DimGray : System.Drawing.Color.White;
                btnPage.ForeColor = (i == currentpageAM) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                btnPage.Click += BtnPage_Click;

                pnlPagination.Controls.Add(btnPage);
                startXAM += bwidthAM + spacingAM;
            }

            btnPrevious.Enabled = currentpageAM > 1;
            btnNext.Enabled = currentpageAM < totpageAM;
        }

        public void BtnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                int pageNumberAM = Convert.ToInt32(btn.Text);
                currentpageAM = pageNumberAM;
                LoadPageAM();
                CreatePagiButtonAM();
            }
        }

        public void AddHeaderCheckBoxAM()
        {
            grdInformation.AllowUserToAddRows = false;
            grdInformation.ReadOnly = false;
            grdInformation.EditMode = DataGridViewEditMode.EditOnEnter;

            headerCheckBoxAM = new System.Windows.Forms.CheckBox();
            headerCheckBoxAM.BackColor = System.Drawing.Color.Transparent;
            headerCheckBoxAM.Size = new Size(18, 18);

            grdInformation.Controls.Add(headerCheckBoxAM);
            PositionHeaderCheckbox();

            grdInformation.ColumnWidthChanged += (s, e) => PositionHeaderCheckbox();

            headerCheckBoxAM.CheckedChanged += (s, e1) =>
            {
                if (isHeaderCheckBoxUpdating) return;

                bool checkAll = headerCheckBoxAM.Checked;

                if (dtAM != null)
                {
                    foreach (DataRow row in dtAM.Rows)
                    {
                        row["IsSelected"] = checkAll;
                    }
                }

                LoadPageAM();
            };
        }

        private void PositionHeaderCheckbox()
        {
            if (grdInformation.Columns.Count > 0)
            {
                System.Drawing.Rectangle rect = grdInformation.GetCellDisplayRectangle(0, -1, true);
                headerCheckBoxAM.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 8);
            }
        }

        private void GrdInformation_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdInformation.IsCurrentCellDirty && grdInformation.CurrentCell is DataGridViewCheckBoxCell)
            {
                grdInformation.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void GrdInformation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && grdInformation.Columns[e.ColumnIndex].Name == "IsSelected")
            {
                int globalID = Convert.ToInt32(grdInformation.Rows[e.RowIndex].Cells["GlobalRowID"].Value);
                bool isChecked = Convert.ToBoolean(grdInformation.Rows[e.RowIndex].Cells["IsSelected"].Value);

                DataRow targetRow = dtAM.AsEnumerable().FirstOrDefault(r => r.Field<int>("GlobalRowID") == globalID);
                if (targetRow != null)
                {
                    targetRow["IsSelected"] = isChecked;
                }

                UpdateHeaderCheckboxState();
            }
        }

        private void UpdateHeaderCheckboxState()
        {
            if (dtAM == null || dtAM.Rows.Count == 0)
            {
                if (headerCheckBoxAM != null) headerCheckBoxAM.Checked = false;
                return;
            }

            isHeaderCheckBoxUpdating = true;
            bool allSelected = dtAM.AsEnumerable().All(r => r.Field<bool>("IsSelected"));
            headerCheckBoxAM.Checked = allSelected;
            isHeaderCheckBoxUpdating = false;
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlFilters.Visible = !pnlFilters.Visible;
            FilterShowAM();
        }

        public void FilterShowAM()
        {
            if (lblInfo.Text == "Todays Events" || lblInfo.Text == "Low-Stock Inventory List" || lblInfo.Text == "In-Stock Inventory List" || lblInfo.Text == "Out Of Stock Inventory List" || lblInfo.Text == "Todays Check-Out" || lblInfo.Text == "Occupied Room Information" || lblInfo.Text == "Unclean Room Information" || lblInfo.Text == "Available Room Information" || lblInfo.Text == "Cleaning Room Information" || lblInfo.Text == "Parking Information Of Slot - A1" || lblInfo.Text == "Parking Information Of Slot - A2" || lblInfo.Text == "Parking Information Of Slot - B1" || lblInfo.Text == "Parking Information Of Slot - B2" || lblInfo.Text == "Parking Information Of Slot - C1")
            {
                pctFilter.Visible = false;
                pnlFilters.Visible = false;
                pctTodaysPayment.Visible = false;
                lblTotalIncome1.Visible = false;
            }
            else if (lblInfo.Text == "Active Bookings")
            {
                lblFilters.Text = "Room Name : ";
                cmbbxFilters.SelectedIndex = -1;
                lblFrom.Visible = false;
                lblTo.Visible = false;
                dtpFrom1.Visible = false;
                dtpTo1.Visible = false;
                lblTotalIncome1.Visible = false;
                pctTodaysPayment.Visible = false;
            }
            else if (lblInfo.Text == "Total Guest")
            {
                lblFilters.Visible = false;
                cmbbxFilters.Visible = false;
                lblFrom.Visible = true;
                lblTo.Visible = true;
                dtpFrom1.Visible = true;
                dtpTo1.Visible = true;
                pctTodaysPayment.Visible = false;
                lblTotalIncome1.Visible = false;
            }
            else if (lblInfo.Text == "Total Payment")
            {
                lblFilters.Visible = false;
                cmbbxFilters.Visible = false;
                pctTodaysPayment.Visible = true;
            }
            else if (lblInfo.Text == "Present Employee Count" || lblInfo.Text == "Absent Employee Count" || lblInfo.Text == "On Leave Employee Count")
            {
                pctFilter.Visible = false;
                pnlFilters.Visible = false;
                pctTodaysPayment.Visible = false;
                lblTotalIncome1.Visible = true;
            }
            else if (lblInfo.Text == "Todays Payment" || lblInfo.Text == "Paid Payment Information" || lblInfo.Text == "Pending Payment Information")
            {
                pctFilter.Visible = false;
                pnlFilters.Visible = false;
                pctTodaysPayment.Visible = false;
                lblTotalIncome1.Visible = true;
            }
        }

        public DataTable GetSelectedRowsAM()
        {
            DataTable dtExport = dtAM.Clone();

            foreach (DataRow row in dtAM.Rows)
            {
                if (row.Field<bool>("IsSelected"))
                {
                    dtExport.ImportRow(row);
                }
            }

            if (dtExport.Columns.Contains("IsSelected")) dtExport.Columns.Remove("IsSelected");
            if (dtExport.Columns.Contains("GlobalRowID")) dtExport.Columns.Remove("GlobalRowID");
            if (dtExport.Columns.Contains("SrNo")) dtExport.Columns.Remove("SrNo");
            if (dtExport.Columns.Contains("Sr No")) dtExport.Columns.Remove("Sr No");

            dtExport.Columns.Add("SrNo", typeof(int));
            dtExport.Columns["SrNo"].SetOrdinal(0);

            int sr = 1;
            foreach (DataRow r in dtExport.Rows)
            {
                r["SrNo"] = sr++;
            }

            return dtExport;
        }

        // --- HELPER: Parse Decimal values safely ---
        private decimal ParseAmount(object value)
        {
            if (value == null || value == DBNull.Value) return 0;
            string strVal = value.ToString().Replace("₹", "").Replace(",", "").Trim();
            if (decimal.TryParse(strVal, out decimal val)) return val;
            return 0;
        }

        // --- HELPER: Format Extracted Column Details ---
        private string GetFormattedCellValue(DataColumn col, object val)
        {
            if (val == null || val == DBNull.Value || string.IsNullOrWhiteSpace(val.ToString()))
                return "---";

            // DateTime formatting (No time if 00:00:00)
            if (val is DateTime dt)
            {
                if (dt.TimeOfDay == TimeSpan.Zero)
                    return dt.ToString("dd-MMM-yyyy");
                else
                    return dt.ToString("dd-MMM-yyyy HH:mm:ss");
            }
            else if (col.DataType == typeof(DateTime) || col.ColumnName.ToLower().Contains("date"))
            {
                if (DateTime.TryParse(val.ToString(), out DateTime parsedDt))
                {
                    if (parsedDt.TimeOfDay == TimeSpan.Zero)
                        return parsedDt.ToString("dd-MMM-yyyy");
                    else
                        return parsedDt.ToString("dd-MMM-yyyy HH:mm:ss");
                }
            }

            // Amount formatting (Add ₹)
            string colName = col.ColumnName.ToLower();
            if (colName.Contains("amount") || colName.Contains("pay") || colName.Contains("price") || colName.Contains("revenue"))
            {
                decimal amountVal = ParseAmount(val);
                return $"₹{amountVal:N2}";
            }

            return val.ToString();
        }

        private string GetFormattedColumnName(string originalName)
        {
            string lowerName = originalName.ToLower();
            if ((lowerName.Contains("amount") || lowerName.Contains("pay") || lowerName.Contains("price") || lowerName.Contains("revenue")) && !originalName.Contains("(₹)"))
            {
                return originalName + " (₹)";
            }
            return originalName;
        }

        // --- DYNAMIC HEADER EXTRACTION HELPER ---
        private void GetDynamicExportHeaders(DataTable dtSelected, out string title, out string generatedDate, out string dateRange, out string amountDisplay)
        {
            title = lblInfo.Text;
            generatedDate = $"Generated Date : {DateTime.Now:dd-MMM-yyyy HH:mm}";
            dateRange = "";
            amountDisplay = "";

            if (lblInfo.Text == "Total Guest") title = "Guest Information";
            else if (lblInfo.Text.Contains("Inventory")) title = "Inventory Information";
            else if (lblInfo.Text.Contains("Employee")) title = "Employee Information";

            // Date processing
            DateTime? minDate = null;
            DateTime? maxDate = null;

            foreach (DataRow row in dtSelected.Rows)
            {
                foreach (DataColumn col in dtSelected.Columns)
                {
                    if (col.DataType == typeof(DateTime) || col.ColumnName.ToLower().Contains("date"))
                    {
                        if (DateTime.TryParse(row[col].ToString(), out DateTime parsedDate))
                        {
                            if (minDate == null || parsedDate < minDate) minDate = parsedDate;
                            if (maxDate == null || parsedDate > maxDate) maxDate = parsedDate;
                        }
                    }
                }
            }

            if (minDate.HasValue && maxDate.HasValue && (title.Contains("Payment") || title == "Guest Information"))
            {
                dateRange = $"From Date : {minDate.Value:dd-MMM-yyyy}   To Date : {maxDate.Value:dd-MMM-yyyy}";
            }

            // Calculation Logic for Payments
            if (lblInfo.Text == "Pending Payment Information")
            {
                title = "Pending Payment Information";
                decimal totalPending = 0;
                foreach (DataRow row in dtSelected.Rows)
                {
                    decimal amtToPay = dtSelected.Columns.Contains("Amount To Pay (₹)") ? ParseAmount(row["Amount To Pay (₹)"]) : 0;
                    decimal paidAmt = dtSelected.Columns.Contains("Paid Amount (₹)") ? ParseAmount(row["Paid Amount (₹)"]) : 0;
                    totalPending += (amtToPay - paidAmt);
                }
                amountDisplay = $"Total Pending Amount : ₹{totalPending:N2}";
            }
            else if (lblInfo.Text == "Paid Payment Information")
            {
                title = "Paid Payment Information";
                decimal totalPaid = 0;
                foreach (DataRow row in dtSelected.Rows)
                {
                    totalPaid += dtSelected.Columns.Contains("Paid Amount (₹)") ? ParseAmount(row["Paid Amount (₹)"]) : ParseAmount(row["Amount"]);
                }
                amountDisplay = $"Total Paid Payment : ₹{totalPaid:N2}";
            }
            else if (title.Contains("Payment"))
            {
                string targetCol = dtSelected.Columns.Cast<DataColumn>().FirstOrDefault(c => c.ColumnName.ToLower().Contains("amount") || c.ColumnName.ToLower().Contains("revenue"))?.ColumnName;
                if (!string.IsNullOrEmpty(targetCol))
                {
                    decimal sum = 0;
                    foreach (DataRow row in dtSelected.Rows)
                    {
                        sum += ParseAmount(row[targetCol]);
                    }
                    string customLabel = targetCol.Replace("(₹)", "").Trim();
                    amountDisplay = $"{customLabel} : ₹{sum:N2}";
                }
            }
        }

        public void ConvertToPDFAM()
        {
            DataTable dtToExport = GetSelectedRowsAM();

            if (dtToExport == null || dtToExport.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one record to export to PDF.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Files (.pdf)|*.pdf",
                Title = "Save PDF File",
                FileName = lblInfo.Text.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".pdf"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10, 10, 20, 20);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    writer.PageEvent = new PDFPageEventHelper();
                    doc.Open();

                    GetDynamicExportHeaders(dtToExport, out string titleTxt, out string genDateTxt, out string dateRangeTxt, out string amountTxt);

                    // HEADER INFO SECTION
                    Paragraph title = new Paragraph(titleTxt, FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    title.SpacingAfter = 5f;
                    doc.Add(title);

                    if (!string.IsNullOrEmpty(amountTxt))
                    {
                        Paragraph amtPara = new Paragraph(amountTxt, FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD));
                        amtPara.Alignment = Element.ALIGN_CENTER;
                        doc.Add(amtPara);
                    }

                    iTextSharp.text.Font headerFont = FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.NORMAL);
                    Paragraph genDatePara = new Paragraph(genDateTxt, headerFont);
                    genDatePara.Alignment = Element.ALIGN_CENTER;
                    doc.Add(genDatePara);

                    if (!string.IsNullOrEmpty(dateRangeTxt))
                    {
                        Paragraph datePara = new Paragraph(dateRangeTxt, headerFont);
                        datePara.Alignment = Element.ALIGN_CENTER;
                        doc.Add(datePara);
                    }

                    doc.Add(new Paragraph("\n"));

                    // TABLE STRUCTURE
                    PdfPTable table = new PdfPTable(dtToExport.Columns.Count) { WidthPercentage = 100 };

                    foreach (DataColumn col in dtToExport.Columns)
                    {
                        string headerName = GetFormattedColumnName(col.ColumnName);
                        PdfPCell cell = new PdfPCell(new Phrase(headerName, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)))
                        {
                            BackgroundColor = new BaseColor(220, 220, 220),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 6
                        };
                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dtToExport.Rows)
                    {
                        for (int i = 0; i < dtToExport.Columns.Count; i++)
                        {
                            string valStr = GetFormattedCellValue(dtToExport.Columns[i], row[i]);
                            PdfPCell cell = new PdfPCell(new Phrase(valStr, FontFactory.GetFont("Arial", 10)))
                            {
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 5
                            };
                            table.AddCell(cell);
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }
                MessageBox.Show("PDF Downloaded Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while generating PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ConvertToPDFAM();
        }

        public void ExportToExcelAM()
        {
            DataTable dtSelectRowAM = GetSelectedRowsAM();

            if (dtSelectRowAM == null || dtSelectRowAM.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one record to export to Excel.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                FileName = lblInfo.Text.Replace(" ", "_") + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Data");
                        GetDynamicExportHeaders(dtSelectRowAM, out string titleTxt, out string genDateTxt, out string dateRangeTxt, out string amountTxt);

                        int currentRow = 1;

                        var titleRange = ws.Range(currentRow, 1, currentRow, dtSelectRowAM.Columns.Count);
                        titleRange.Merge().Value = titleTxt;
                        titleRange.Style.Font.Bold = true;
                        titleRange.Style.Font.FontSize = 16;
                        titleRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentRow++;

                        if (!string.IsNullOrEmpty(amountTxt))
                        {
                            var amtRange = ws.Range(currentRow, 1, currentRow, dtSelectRowAM.Columns.Count);
                            amtRange.Merge().Value = amountTxt;
                            amtRange.Style.Font.Bold = true;
                            amtRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            currentRow++;
                        }

                        var dateRange = ws.Range(currentRow, 1, currentRow, dtSelectRowAM.Columns.Count);
                        dateRange.Merge().Value = genDateTxt;
                        dateRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentRow++;

                        if (!string.IsNullOrEmpty(dateRangeTxt))
                        {
                            var drRange = ws.Range(currentRow, 1, currentRow, dtSelectRowAM.Columns.Count);
                            drRange.Merge().Value = dateRangeTxt;
                            drRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            currentRow++;
                        }

                        currentRow++;

                        for (int j = 0; j < dtSelectRowAM.Columns.Count; j++)
                        {
                            var cell = ws.Cell(currentRow, j + 1);
                            cell.Value = GetFormattedColumnName(dtSelectRowAM.Columns[j].ColumnName);
                            cell.Style.Font.Bold = true;
                            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                            cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                            cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        currentRow++;

                        for (int i = 0; i < dtSelectRowAM.Rows.Count; i++)
                        {
                            for (int j = 0; j < dtSelectRowAM.Columns.Count; j++)
                            {
                                var cell = ws.Cell(currentRow, j + 1);
                                cell.Value = GetFormattedCellValue(dtSelectRowAM.Columns[j], dtSelectRowAM.Rows[i][j]);
                                cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            currentRow++;
                        }

                        ws.Columns().AdjustToContents();
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Excel Exported Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error generating Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelAM();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearch(txtSearchBox.Text);
        }

        public void ApplySearch(string searchText)
        {
            if (FullData == null) return;

            try
            {
                searchText = searchText.Trim().Replace("'", "''");
                DataView dv = new DataView(FullData);

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dtAM = FullData.Copy();
                }
                else
                {
                    string filter = "";
                    foreach (DataColumn col in FullData.Columns)
                    {
                        if (col.ColumnName != "IsSelected" && col.ColumnName != "GlobalRowID")
                        {
                            filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
                        }
                    }

                    if (filter.Length > 0)
                    {
                        filter = filter.Substring(0, filter.Length - 4);
                        dv.RowFilter = filter;
                    }

                    dtAM = dv.ToTable();
                }

                currentpageAM = 1;
                totrecordsAM = dtAM.Rows.Count;
                totpageAM = (int)Math.Ceiling((double)totrecordsAM / pagesizeAM);

                LoadPageAM();
                CreatePagiButtonAM();
                CalculateTotalFromAllPagesAM(dtAM);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing search: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FilterGridByDateAM()
        {
            try
            {
                DateTime fromDateAM = dtpFrom1.Value.Date;
                DateTime toDateAM = dtpTo1.Value.Date;

                clsUser objCls = new clsUser();
                objCls.FromDAM = fromDateAM;
                objCls.ToDAM = toDateAM;

                if (lblInfo.Text == "Total Payment")
                {
                    dtAM = objCls.GetTotalPaymentInfoFilterAM();
                    CalculateTotalFromAllPagesAM(dtAM);
                }
                else if (lblInfo.Text == "Total Guest")
                    dtAM = objCls.GetGuestInfoFilterAM();
                else if (lblInfo.Text == "Active Bookings")
                {
                    if(cmbbxFilters.Text=="")
                    {
                        dtAM = objCls.GetActiveBookingInfoAM();
                    }
                    else
                    {
                        objCls.RoomNameAM = cmbbxFilters.Text;
                        dtAM = objCls.GetActiveBookingInfoFilterAM();
                    }
                     
                }
                else if (lblInfo.Text == "Todays Events")
                {
                    objCls.EventNameAM = cmbbxFilters.Text;
                    dtAM = objCls.GetTodaysEventFilterAM();
                }
                else if (lblInfo.Text == "Todays Check-Out")
                {        
                    dtAM = objCls.GetTodaysCheckOutInfoAM();
                }
                else if (lblInfo.Text == "Paid Payment Information")
                {
                    if (FD.Date == DateTime.Today && TD.Date == DateTime.Today)
                    {
                        objCls.StatusIDAM = 22;
                        dtAM = objCls.GuestPaymentInfoByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                    else
                    {
                        objCls.StatusIDAM = 22;
                        objCls.FromDAM = FD;
                        objCls.ToDAM = TD;
                        dtAM = objCls.GuestPaymentInfoDTByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                }
                else if (lblInfo.Text == "Pending Payment Information")
                {
                    if (FD.Date == DateTime.Today && TD.Date == DateTime.Today)
                    {
                        objCls.StatusIDAM = 4;
                        dtAM = objCls.GuestPaymentInfoByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                    else
                    {
                        objCls.StatusIDAM = 4;
                        objCls.FromDAM = FD;
                        objCls.ToDAM = TD;
                        dtAM = objCls.GuestPaymentInfoDTByStatusAM();
                        CalculateTotalFromAllPagesAM(dtAM);
                    }
                }

                InitializeGlobalSelectionState();

                currentpageAM = 1;
                totrecordsAM = dtAM.Rows.Count;
                totpageAM = (int)Math.Ceiling((double)totrecordsAM / pagesizeAM);

                LoadPageAM();
                CreatePagiButtonAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering data by date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFrom1.Value.Date > dtpTo1.Value.Date)
                {
                    MessageBox.Show("'From Date' cannot be later than 'To Date'. Resetting value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpFrom1.Value = dtpTo1.Value.Date;
                    return;
                }
                FilterGridByDateAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing From Date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpTo1.Value.Date < dtpFrom1.Value.Date)
                {
                    MessageBox.Show("'To Date' cannot be earlier than 'From Date'. Resetting value.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpTo1.Value = dtpFrom1.Value.Date;
                    return;
                }
                FilterGridByDateAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error processing To Date: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            if (lblInfo.Text == "Todays Payments")
                lblInfo.Text = "Total Payment";

            txtSearchBox.Text = "";
            txtSearchBox.PlaceholderText = "Search Here.......";
            MainLoadAM();
            FilterGridByDateAM();
        }

        private void cmbbxFilters_SelectionChangeCommitted(object sender, EventArgs e)
        {
            FilterGridByDateAM();
        }

        private void CalculateTotalFromAllPagesAM(DataTable dt)
        {
            if (dt == null) return;
            decimal totalIncome = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (lblInfo.Text == "Total Payment" || lblInfo.Text == "Todays Payments" || lblInfo.Text == "Paid Payment Information")
                {
                    if (dt.Columns.Contains("Paid Amount (₹)"))
                    {
                        totalIncome += ParseAmount(row["Paid Amount (₹)"]);
                    }
                }
                else if (lblInfo.Text == "Pending Payment Information")
                {
                    if (dt.Columns.Contains("Amount To Pay (₹)") && dt.Columns.Contains("Paid Amount (₹)"))
                    {
                        decimal amtToPay = ParseAmount(row["Amount To Pay (₹)"]);
                        decimal paidAmt = ParseAmount(row["Paid Amount (₹)"]);
                        totalIncome += (amtToPay - paidAmt);
                    }
                }
            }

            if (lblInfo.Text == "Total Payment" || lblInfo.Text == "Todays Payments" || lblInfo.Text == "Paid Payment Information")
                lblTotalIncome1.Text = " Total Income: ₹ " + totalIncome.ToString("N2");
            else if (lblInfo.Text == "Pending Payment Information")
                lblTotalIncome1.Text = "Pending Amount: ₹ " + totalIncome.ToString("N2");
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlTodaysPayment_Click(object sender, EventArgs e)
        {
            clsUser o1 = new clsUser();
            lblInfo.Text = "Todays Payments";
            dtAM = o1.GetTodaysPaymentInfoAM();
            InitializeGlobalSelectionState();

            pnlFilters.Visible = false;
            FullData = dtAM.Copy();
            totrecordsAM = dtAM.Rows.Count;
            totpageAM = (int)Math.Ceiling((double)totrecordsAM / pagesizeAM);

            LoadPageAM();
            CreatePagiButtonAM();
            CalculateTotalFromAllPagesAM(dtAM);
        }
    }

    // PDF Page Event Helper for Footers
    public class PDFPageEventHelper : PdfPageEventHelper
    {
        public override void OnEndPage(PdfWriter writer, iTextSharp.text.Document document)
        {
            PdfPTable footerTbl = new PdfPTable(1);
            footerTbl.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            footerTbl.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cell = new PdfPCell(new Phrase($"Page {writer.PageNumber}", FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)))
            {
                Border = 0,
                HorizontalAlignment = Element.ALIGN_CENTER
            };
            footerTbl.AddCell(cell);
            footerTbl.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 5, writer.DirectContent);
        }
    }
}