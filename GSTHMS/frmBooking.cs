using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmBooking : Form
    {
        private bool isProcessingCheckout = false;
        public frmBooking()
        {
            InitializeComponent();
        }
        public int pageSizeFL = 20;
        public int currentPageFL = 1;
        public int totalPagesFL = 0;
        public int totalRecordsFL = 0;
        public string bookingcode;

        public System.Data.DataTable dt = new System.Data.DataTable();
        CheckBox headerCheckBox = new CheckBox();
        DataTable dtFiltered = new DataTable();

       
        private void frmBooking_Load(object sender, EventArgs e)
        {

            timerRoom.Interval = 60000;
            timerRoom.Tick += timerRoom_Tick;
            timerRoom.Start();

            pnlFilter.Visible = true;
            // ----------------- GRID STYLING -----------------
            grdAllBookingsFL.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAllBookingsFL.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdAllBookingsFL.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdAllBookingsFL.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            headerCheckBox.CheckAlign = ContentAlignment.MiddleCenter;

            // ----------------- LOAD MASTER DATA -----------------
            clsUser obj = new clsUser();
            dt = obj.AllBookingDetailsFL(); // Full data
            dtFiltered = dt.Copy();

            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            // ----------------- LOAD ROOM TYPE COMBO -----------------
            DataTable dtRoomType = obj.FetchRoomTypeFL();
            cmbbxRoomTypeFL.DisplayMember = "RoomTypeName";
            cmbbxRoomTypeFL.ValueMember = "RoomTypeID";

            DataRow dr = dtRoomType.NewRow();
            dr["RoomTypeName"] = "All";
            dr["RoomTypeID"] = 0;
            dtRoomType.Rows.InsertAt(dr, 0);

            cmbbxRoomTypeFL.DataSource = dtRoomType;
            //cmbbxRoomTypeFL.SelectedIndex = 0;

            cmbbxByBookingFL.SelectedIndex = -1;
            cmbbxRoomTypeFL.SelectedIndex = -1;

            // ----------------- UPDATE ByBooking COMBO -----------------
            UpdateByBookingComboFL();

            // ----------------- ADD HEADER CHECKBOX -----------------
            AddHeaderCheckBoxFL();

            // ----------------- ADD ACTION COLUMNS -----------------
            AddViewEditColumnsFL();

            // ----------------- MAKE COLUMNS READONLY EXCEPT CHECKBOX -----------------
            foreach (DataGridViewColumn col in grdAllBookingsFL.Columns)
                col.ReadOnly = true;

            if (grdAllBookingsFL.Columns.Contains("check"))
                grdAllBookingsFL.Columns["check"].ReadOnly = false;

            // ----------------- COMMIT CHECKBOX IMMEDIATELY -----------------
            grdAllBookingsFL.CurrentCellDirtyStateChanged += (s, ev) =>
            {
                if (grdAllBookingsFL.IsCurrentCellDirty)
                    grdAllBookingsFL.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            // ----------------- GRID STYLE -----------------
            grdAllBookingsFL.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdAllBookingsFL.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdAllBookingsFL.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdAllBookingsFL.GridColor = Color.Gray;

            // ----------------- MOVE ACTION COLUMNS TO END -----------------
            MoveActionColumnsToEnd();

            // ----------------- APPLY INITIAL FILTER -----------------
            ApplyCombinedFilterFL();
            //grdAllBookingsFL.CellClick += grdAllBookingsFL_CellClick;

        }



        public void LoadPageFL()
        {
            int start = (currentPageFL - 1) * pageSizeFL;
            DataTable dtPage = dtFiltered.Clone();

            for (int i = start; i < start + pageSizeFL && i < dtFiltered.Rows.Count; i++)
                dtPage.ImportRow(dtFiltered.Rows[i]);

            grdAllBookingsFL.DataSource = dtPage;
        }
     



        private void AddHeaderCheckBoxFL()
        {
            if (!grdAllBookingsFL.Columns.Contains("check")) return;

            
            System.Drawing.Rectangle rect = grdAllBookingsFL.GetCellDisplayRectangle(grdAllBookingsFL.Columns["check"].Index, -1, true);

            // Header checkbox size
            headerCheckBox.Size = new Size(16, 16);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;

            
            headerCheckBox.Location = new Point(
                rect.X + (rect.Width - headerCheckBox.Width) / 2,
                rect.Y + (rect.Height - headerCheckBox.Height) / 2
            );

            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            if (!grdAllBookingsFL.Controls.Contains(headerCheckBox))
                grdAllBookingsFL.Controls.Add(headerCheckBox);
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            grdAllBookingsFL.EndEdit();
            bool isChecked = headerCheckBox.Checked;
            foreach (DataGridViewRow row in grdAllBookingsFL.Rows)
            {
                if (row.Cells["check"] is DataGridViewCheckBoxCell chk)
                    chk.Value = isChecked;
            }
            grdAllBookingsFL.RefreshEdit();
        }
        private void AddViewEditColumnsFL()
        {
            // VIEW COLUMN
            if (!grdAllBookingsFL.Columns.Contains("View"))
            {
                DataGridViewImageColumn viewCol = new DataGridViewImageColumn
                {
                    Name = "View",
                    HeaderText = "View",
                    Image = Properties.Resources.view_icon,
                    Width = 40,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                grdAllBookingsFL.Columns.Add(viewCol);
            }

            //  CHECKOUT ACTION COLUMN (IMPORTANT)
            if (!grdAllBookingsFL.Columns.Contains("btnCheckOut"))
            {
                DataGridViewImageColumn checkoutCol = new DataGridViewImageColumn
                {
                    Name = "btnCheckOut",          // ✅ ACTION NAME
                    HeaderText = "",
                    Image = Properties.Resources.Edit_icon, // checkout icon
                    Width = 40,
                    ImageLayout = DataGridViewImageCellLayout.Zoom
                };
                grdAllBookingsFL.Columns.Add(checkoutCol);
            }

            // Always keep icons at end
            grdAllBookingsFL.Columns["View"].DisplayIndex = grdAllBookingsFL.Columns.Count - 2;
            grdAllBookingsFL.Columns["btnCheckOut"].DisplayIndex = grdAllBookingsFL.Columns.Count - 1;

            grdAllBookingsFL.Columns["View"].Visible = false;
            grdAllBookingsFL.Columns["btnCheckOut"].Visible = false;
        }


        public void CreatePageButtonFL()
        {
            pnlPagesFL.Controls.Clear();
            pnlPagesFL.Visible = true;

            if (totalPagesFL < 1) totalPagesFL = 1;

            for (int i = 1; i <= totalPagesFL; i++)
            {
                Guna2Button btn = new Guna2Button
                {
                    Text = i.ToString(),
                    Name = "btnPage" + i,
                    Width = 40,
                    Height = 40,
                    BorderRadius = 5,
                    Margin = new Padding(5),
                    FillColor = (i == currentPageFL) ? Color.Gray : Color.White,
                    ForeColor = (i == currentPageFL) ? Color.White : Color.Black,
                };
                btn.Click += btnPage_Click;
                pnlPagesFL.Controls.Add(btn);
            }
            pnlPagesFL.Refresh();
        }
        private void btnPage_Click(object sender, EventArgs e)///
        {
            Guna2Button btn = sender as Guna2Button;
            currentPageFL = int.Parse(btn.Text);
            LoadPageFL();
            CreatePageButtonFL();
        }

        private void btnBackFL_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchTextFL = txtSearchBoxFL.Text.Trim().Replace("'", "''");

            // If no data loaded OR grid is not bound
            if (grdAllBookingsFL.DataSource == null)
                return;

            // Get table
            DataTable dt = (DataTable)grdAllBookingsFL.DataSource;

            // If search box is empty → show all
            if (string.IsNullOrWhiteSpace(searchTextFL))
            {
                dt.DefaultView.RowFilter = "";
                return;
            }

            // Build filter for all columns (LIKE windows search)
            string filterFL = "";

            foreach (DataColumn col in dt.Columns)
            {
                // Skip checkbox or image/icon columns:
                if (col.ColumnName.Equals("check", StringComparison.OrdinalIgnoreCase) ||
                    col.ColumnName.Equals("Action", StringComparison.OrdinalIgnoreCase))
                    continue;

                filterFL += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchTextFL}%' OR ";
            }

            // Remove last OR
            filterFL = filterFL.Substring(0, filterFL.Length - 4);

            // Apply filter
            dt.DefaultView.RowFilter = filterFL;
        }
        private void ExportCheckedRowsToPDFFL(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("Grid not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit();

            // Columns to skip (checkbox, icons, actions)
            var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "check","Select","Action","View","CheckOut","Sr.No",
        "imgView","imgEdit","Apply","Details"
    };

            // Get exportable columns
            var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (exportColumns.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Checkbox column
            var checkCol = grid.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.Name.Equals("check", StringComparison.OrdinalIgnoreCase));

            if (checkCol == null)
            {
                MessageBox.Show("Checkbox column not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Selected rows
            var selectedRows = grid.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                            r.Cells[checkCol.Index].Value != null &&
                            Convert.ToBoolean(r.Cells[checkCol.Index].Value))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = "Booking_List.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                iTextSharp.text.Document doc =
                    new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 20, 20, 20, 20);

                PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                doc.Open();

                // ---------------- FONTS ----------------
                iTextSharp.text.Font headerFont =
                    GetUnicodeFont(16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font boldFont =
                    GetUnicodeFont(11, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont =
                    GetUnicodeFont(10, iTextSharp.text.Font.NORMAL);

                // ---------------- TITLE (COMBOBOX WISE) ----------------
                string bookingTitle = "Booking List";

                if (cmbbxByBookingFL.SelectedItem != null)
                {
                    string sel = cmbbxByBookingFL.SelectedItem.ToString();

                    if (sel == "Active Booking")
                        bookingTitle = "Active Booking List";
                    else if (sel == "Today's Booking")
                        bookingTitle = "Today's Booking List";
                    else
                        bookingTitle = "All Booking List";
                }

                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(new Phrase(bookingTitle, headerFont));
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(titleCell);

                PdfPCell dateCell = new PdfPCell(
                    new Phrase("Generated On : " + DateTime.Now.ToString("dd-MM-yyyy"), boldFont));
                dateCell.Border = PdfPCell.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                headerTable.AddCell(dateCell);

                headerTable.SpacingAfter = 15;
                doc.Add(headerTable);

                // ---------------- TABLE ----------------
                // +1 for SrNo
                PdfPTable table = new PdfPTable(exportColumns.Count + 1);
                table.WidthPercentage = 100;

                // Header : SrNo
                PdfPCell srHeader = new PdfPCell(new Phrase("SrNo", boldFont));
                srHeader.BackgroundColor = BaseColor.LIGHT_GRAY;
                srHeader.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(srHeader);

                // Other headers
                foreach (var col in exportColumns)
                {
                    PdfPCell hcell = new PdfPCell(
                        new Phrase(col.HeaderText ?? col.Name, boldFont));
                    hcell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    hcell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(hcell);
                }

                // Data rows
                int srNo = 1;

                foreach (var row in selectedRows)
                {
                    // SrNo cell
                    PdfPCell srCell = new PdfPCell(new Phrase(srNo.ToString(), normalFont));
                    srCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(srCell);

                    foreach (var col in exportColumns)
                    {
                        string value = row.Cells[col.Index].Value?.ToString() ?? "";
                        PdfPCell cell = new PdfPCell(new Phrase(value, normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    srNo++;
                }

                doc.Add(table);
                doc.Close();

                MessageBox.Show("PDF generated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFFL(grdAllBookingsFL);
        }
        private iTextSharp.text.Font GetUnicodeFont(float size = 10, int style = iTextSharp.text.Font.NORMAL)
        {
            // Ensure this font exists on the system
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            return new iTextSharp.text.Font(bf, size, style);
        }

        private void ExportCheckedRowsToExcelFL(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("Grid not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit(); // commit checkbox values

            // Columns to skip (checkbox, icons, actions)
            var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "check","Select","Action","View","CheckOut",
        "imgView","imgEdit","Apply","Details","Sr.No"
    };

            // Exportable columns
            var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (exportColumns.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Checkbox column
            var checkCol = grid.Columns.Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.Name.Equals("check", StringComparison.OrdinalIgnoreCase));

            if (checkCol == null)
            {
                MessageBox.Show("Checkbox column not found.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Selected rows
            var selectedRows = grid.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                            r.Cells[checkCol.Index].Value != null &&
                            Convert.ToBoolean(r.Cells[checkCol.Index].Value))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "Booking_List.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Bookings");
                    int currentRow = 1;

                    // ---------------- TITLE (COMBOBOX WISE) ----------------
                    string bookingTitle = "Booking List";

                    if (cmbbxByBookingFL.SelectedItem != null)
                    {
                        string sel = cmbbxByBookingFL.SelectedItem.ToString();

                        if (sel == "Active Booking")
                            bookingTitle = "Active Booking List";
                        else if (sel == "Today's Booking")
                            bookingTitle = "Today's Booking List";
                        else
                            bookingTitle = "All Booking List";
                    }

                    ws.Cell(currentRow, 1).Value = bookingTitle;
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1)
                      .Merge()
                      .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow++;

                    // Date row
                    ws.Cell(currentRow, 1).Value =
                        "Genarated On : " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1)
                      .Merge()
                      .Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow += 2;

                    // ---------------- TABLE HEADER ----------------
                    int currentCol = 1;

                    ws.Cell(currentRow, currentCol).Value = "SrNo";
                    ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                    ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal =
                        XLAlignmentHorizontalValues.Center;
                    currentCol++;

                    foreach (var col in exportColumns)
                    {
                        ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                        ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                        ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        currentCol++;
                    }

                    // ---------------- DATA ROWS ----------------
                    int srNo = 1;

                    foreach (var row in selectedRows)
                    {
                        currentRow++;
                        currentCol = 1;

                        ws.Cell(currentRow, currentCol).Value = srNo++;
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal =
                            XLAlignmentHorizontalValues.Center;
                        currentCol++;

                        foreach (var col in exportColumns)
                        {
                            ws.Cell(currentRow, currentCol).Value =
                                row.Cells[col.Index].Value?.ToString() ?? "";
                            currentCol++;
                        }
                    }

                    // Auto-fit
                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file generated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcelFL(grdAllBookingsFL);
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = true;

            clsUser obj = new clsUser();
            dt = obj.AllBookingDetailsFL();
            dtFiltered = dt.Copy();

            txtSearchBoxFL.Text = "";

            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            // 🔥 STOP EVENTS
            cmbbxRoomTypeFL.SelectedIndexChanged -= cmbbxRoomTypeFL_SelectedIndexChanged;
            cmbbxByBookingFL.SelectedIndexChanged -= cmbbxByBookingFL_SelectedIndexChanged;

            // 🔥 FORCE EMPTY STATE
            cmbbxRoomTypeFL.SelectedIndex = -1;
            cmbbxRoomTypeFL.Text = "";
            cmbbxByBookingFL.SelectedIndex = -1;
            cmbbxByBookingFL.Text = "";

            // 🔥 START EVENTS AGAIN
            cmbbxRoomTypeFL.SelectedIndexChanged += cmbbxRoomTypeFL_SelectedIndexChanged;
            cmbbxByBookingFL.SelectedIndexChanged += cmbbxByBookingFL_SelectedIndexChanged;

            LoadPageFL();
            CreatePageButtonFL();

            if (headerCheckBox != null)
                headerCheckBox.Checked = false;

            ToggleActionColumns(false);
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;  // toggle visibility
            if (pnlFilter.Visible)
                
               pnlFilter.BringToFront();
        }
        private void btnPreviousFL_Click(object sender, EventArgs e)
        {
            if (currentPageFL > 1)
            {
                currentPageFL--;
                 LoadPageFL();   
                CreatePageButtonFL();
            }
        }

        private void btnNextFL_Click(object sender, EventArgs e)
        {
            if (currentPageFL < totalPagesFL)
            {
                currentPageFL++;
                LoadPageFL();
                CreatePageButtonFL();
            }
        }

        private void cmbbxRoomTypeFL_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateByBookingComboFL();
            ApplyCombinedFilterFL();
            ApplyRoomTypeFilter();
        }
        private void ApplyRoomTypeFilter()
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            // ✅ WRITE IT HERE
            string selectedRoomType = cmbbxRoomTypeFL.Text.Trim();

            // Show all records
            if (string.IsNullOrWhiteSpace(selectedRoomType) ||
                selectedRoomType == "--Select--" ||
                selectedRoomType == "All")
            {
                dtFiltered = dt.Copy();
            }
            else
            {
                DataView dv = new DataView(dt);

                // Safety for single quotes
                string safeValue = selectedRoomType.Replace("'", "''");

                dv.RowFilter = $"RoomTypeName = '{safeValue}'";

                dtFiltered = dv.ToTable();
            }

            // Reset paging
            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            LoadPageFL();
            CreatePageButtonFL();
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbbxByBookingFL_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedFilter = cmbbxByBookingFL.SelectedItem?.ToString();
            clsUser obj = new clsUser();

            // Load filtered data
            if (selectedFilter == "Today's Booking")
                dtFiltered = obj.FetchTodaysBookingsFL();

            else if (selectedFilter == "Active Booking")
                dtFiltered = obj.GetActiveBookings();

            else
                dtFiltered = obj.AllBookingDetailsFL();

            // IMPORTANT
            dt = dtFiltered.Copy();

            // Paging
            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            LoadPageFL();
            CreatePageButtonFL();

            if (headerCheckBox != null)
                headerCheckBox.Checked = false;

            bool showActions =
                selectedFilter == "Today's Booking"
                || selectedFilter == "Active Booking";

            ToggleActionColumns(showActions);
        }
        private void MoveActionColumnsToEnd()
        {
            // Only move action columns (View & btnCheckOut) to the end
            if (!grdAllBookingsFL.Columns.Contains("View") ||
                !grdAllBookingsFL.Columns.Contains("btnCheckOut"))
                return;

            int lastIndex = grdAllBookingsFL.Columns.Count - 1;

            grdAllBookingsFL.Columns["btnCheckOut"].DisplayIndex = lastIndex;
            grdAllBookingsFL.Columns["View"].DisplayIndex = lastIndex - 1;
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
          frmAddbooking obj=new frmAddbooking();
            obj.Show();
        }
        private void ToggleActionColumns(bool visible)
        {
            if (grdAllBookingsFL.Columns.Contains("View"))
                grdAllBookingsFL.Columns["View"].Visible = visible;

            if (grdAllBookingsFL.Columns.Contains("btnCheckOut"))
                grdAllBookingsFL.Columns["btnCheckOut"].Visible = visible;

            if (visible)
            {
                grdAllBookingsFL.Columns["btnCheckOut"].DisplayIndex = grdAllBookingsFL.Columns.Count - 1;
                grdAllBookingsFL.Columns["View"].DisplayIndex = grdAllBookingsFL.Columns.Count - 2;
            }
        }
        private void grdAllBookingsFL_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            grdAllBookingsFL.Refresh();

            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            DataGridViewRow row = grdAllBookingsFL.Rows[e.RowIndex];
            string colName = grdAllBookingsFL.Columns[e.ColumnIndex].Name;

            // =========================
            // VIEW BUTTON
            // =========================
            if (colName == "View")
            {
                frmBookingDetails view = new frmBookingDetails();
                view.BookingCodeFL = row.Cells["BookingCode"].Value.ToString();
                view.ShowDialog();
                return;
            }

            // =========================
            // CHECKOUT BUTTON
            // =========================
            if (colName != "btnCheckOut")
                return;

            // Prevent double click
            if (isProcessingCheckout) return;
            isProcessingCheckout = true;

            try
            {
                // Check existing checkout
                object checkoutObj = row.Cells["Checkout"].Value;
                DateTime? checkoutDate = (checkoutObj == null || checkoutObj == DBNull.Value)
                    ? (DateTime?)null
                    : Convert.ToDateTime(checkoutObj);

                if (checkoutDate.HasValue && checkoutDate.Value.Date == DateTime.Today)
                {
                    MessageBox.Show("Already checked out today!");
                    return;
                }

                clsUser obj = new clsUser
                {
                    BookingCodeFL = row.Cells["BookingCode"].Value.ToString(),
                    RoomNameFL = row.Cells["RoomName"].Value.ToString(),
                    CheckOutFL = DateTime.Today,
                    checkOutTimeFL = DateTime.Now.TimeOfDay
                };

                string result = obj.CheckoutFL();

                if (result == "SUCCESS")
                {
                    obj.BookingCodeVK = row.Cells["BookingCode"].Value.ToString();
                    obj.IncrementOfQuanityVK();

                    row.Cells["Checkout"].Value = DateTime.Now;
                    row.Cells["btnCheckOut"].ReadOnly = true;
                    row.Cells["btnCheckOut"].Style.BackColor = Color.LightGray;
                    row.Cells["btnCheckOut"].ToolTipText =
                        "Already checked out on " + DateTime.Now.ToString("dd-MM-yyyy HH:mm");

                    MessageBox.Show("Guest checked out successfully");
                }
                else
                {
                    MessageBox.Show("Checkout failed: " + result);
                }
            }
            finally
            {
                isProcessingCheckout = false;
            }
        }
        private void UpdateByBookingComboFL()
        {
            if (dt == null || dt.Rows.Count == 0)
                return;

            string selectedRoomType = cmbbxRoomTypeFL.Text.Trim();
            DataView dv = new DataView(dt);

            // Room Type filter
            if (!string.IsNullOrWhiteSpace(selectedRoomType) && selectedRoomType != "--Select--" && selectedRoomType != "All")
            {
                string safeValue = selectedRoomType.Replace("'", "''");
                dv.RowFilter = $"RoomTypeName = '{safeValue}'";
            }

            DataTable dtRoomFiltered = dv.ToTable();

            // Clear existing items
            cmbbxByBookingFL.Items.Clear();

            // Always include all three booking types
            cmbbxByBookingFL.Items.Add("All Booking");
            cmbbxByBookingFL.Items.Add("Today's Booking");
            cmbbxByBookingFL.Items.Add("Active Booking");

            // Default selection = "All Booking"
            cmbbxByBookingFL.SelectedIndex = -1;
        }


        private void ApplyCombinedFilterFL()
        {
            if (dt == null || dt.Rows.Count == 0) return;

            DataView dv = new DataView(dt);

            // ------------------ ROOM TYPE FILTER ------------------
            string roomTypeFilter = "";
            string selectedRoomType = cmbbxRoomTypeFL.Text.Trim();
            if (!string.IsNullOrWhiteSpace(selectedRoomType) && selectedRoomType != "--Select--" && selectedRoomType != "All")
                roomTypeFilter = $"RoomTypeName = '{selectedRoomType.Replace("'", "''")}'";

            // ------------------ BY BOOKING FILTER ------------------
            string bookingFilter = "";
            string selectedBooking = cmbbxByBookingFL.SelectedItem?.ToString();
            if (selectedBooking == "Today's Booking")
            {
                bookingFilter = $"Checkin >= #{DateTime.Now:MM/dd/yyyy}# AND Checkin < #{DateTime.Now.AddDays(1):MM/dd/yyyy}#";
            }
            else if (selectedBooking == "Active Booking")
            {
                bookingFilter =
                    "(Checkout IS NULL OR Checkout >= #" + DateTime.Today.ToString("MM/dd/yyyy") + "#)";
            }
            else if (selectedBooking == "All Booking" || string.IsNullOrWhiteSpace(selectedBooking))
            {
                bookingFilter = ""; // No filter → take all records
            }

            // ------------------ COMBINE FILTERS ------------------
            string finalFilter = "";
            if (!string.IsNullOrEmpty(roomTypeFilter))
                finalFilter = roomTypeFilter;
            if (!string.IsNullOrEmpty(bookingFilter))
                finalFilter = string.IsNullOrEmpty(finalFilter) ? bookingFilter : finalFilter + " AND " + bookingFilter;

            dv.RowFilter = finalFilter;
            dtFiltered = dv.ToTable();

            // ------------------ RESET PAGING ------------------
            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            LoadPageFL();
            CreatePageButtonFL();

            if (headerCheckBox != null)
                headerCheckBox.Checked = false;
        }
        public void RefreshBookingGridFL()
        {
            clsUser obj = new clsUser();

            // Reload full data
            dt = obj.AllBookingDetailsFL();
            dtFiltered = dt.Copy();

            // Reset paging
            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            // Reload grid
            LoadPageFL();
            CreatePageButtonFL();

            // Reset header checkbox
            if (headerCheckBox != null)
                headerCheckBox.Checked = false;
        }

        private void timerRoom_Tick(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            obj.AutoRoomStatusFL();

            // safer refresh (avoid filter overwrite issues)
            dt = obj.AllBookingDetailsFL();
            dtFiltered = dt.Copy();

            totalRecordsFL = dtFiltered.Rows.Count;
            totalPagesFL = (int)Math.Ceiling((double)totalRecordsFL / pageSizeFL);
            currentPageFL = 1;

            LoadPageFL();
            CreatePageButtonFL();
        }
    }
}
