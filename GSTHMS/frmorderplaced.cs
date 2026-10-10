using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CheckBox = System.Windows.Forms.CheckBox;
using Color = System.Drawing.Color;
using Document = iTextSharp.text.Document;
using PageSize = iTextSharp.text.PageSize;

namespace GSTHMS
{
    public partial class frmorderplaced : Form
    {
        DataTable filteredDT = null;
        public string RoomNameSRM;
        public string GuestNameSRM;

        public int pageSizeSRM = 20;   // Rows per page
        public int currentPageSRM = 1;
        public int totalRecordsSRM = 0;
        public int totalPagesSRM = 0;
        public int startIndexSRM = 1;
        public DataTable FullData;
      
        CheckBox headerCheckBox = new CheckBox();
        DataTable dt1 = new DataTable();

        public Form dimFormSRM;

        public frmorderplaced()
        {
            InitializeComponent();
            //this.FormBorderStyle = FormBorderStyle.None;
        }

        private Form CreateDimBackgroundSRM()
        {
            Form bg = new Form();
            bg.StartPosition = FormStartPosition.Manual;
            bg.FormBorderStyle = FormBorderStyle.None;
            bg.Opacity = 0.6;
            bg.BackColor = Color.Black;
            bg.WindowState = FormWindowState.Maximized;
            bg.TopMost = true;

            return bg;
        }

        //DataTable dt1 = new DataTable();
        private void frmorderplaced_Load(object sender, EventArgs e)
        {
            //this.Size = new Size(1050, 620);
            //grdOrderFoodShow.Size = new Size(980, 360);
            //grdOrderFoodShow.Height = 500;
           

            pnlFilter.Visible = true;
            lblFromDate.Visible = true;
            lblToDate.Visible = true;
            dtpFromDate.Visible = true;
            dtpEndDate.Visible = true;
            // Hide booking filter initially
            //cmbbxBooking.Visible = false;
            //lblBooking.Visible = false;

            this.TopMost = true;

            // Tooltips
            toolTip1.SetToolTip(pctRefresh, "Refresh");
            toolTip1.SetToolTip(pctPDF, "Download PDF");
            toolTip1.SetToolTip(pctExcel, "Export To Excel");
            toolTip1.SetToolTip(pctFilter, "Filters");
           ;
            // Grid formatting
            grdOrderFoodShow.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdOrderFoodShow.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdOrderFoodShow.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdOrderFoodShow.GridColor = Color.Gray;
            grdOrderFoodShow.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdOrderFoodShow.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdOrderFoodShow.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdOrderFoodShow.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            FetchFromDateToDateSRM();

            clsUser obj = new clsUser();

            // ---------------------------------------------------
            // LOAD HISTORY OR ACTIVE GUEST ORDERS
            // ---------------------------------------------------
            if (string.IsNullOrEmpty(RoomNameSRM) && string.IsNullOrEmpty(GuestNameSRM))
            {
                // No guest / room passed → show ALL ORDER HISTORY
                dt1 = obj.DisplayOrderHistorySRM();
            }
            else
            {
                // Guest passed → show only that guest's active order list
                obj.RoomNameSRM = RoomNameSRM;
                obj.GuestNameSRM = GuestNameSRM;
               
               // pnlFilter.Visible = false;
               
               // pctFilter.Visible = false;  
                dt1 = obj.DisplayFoodOrdersSRM();
               
                pnlFilter.Visible = false;
                pctFilter.Visible = false;
                lblFromDate.Visible = false;
                lblToDate.Visible = false;
                dtpFromDate.Visible = false;
                dtpEndDate.Visible = false;
            }

            // ---------------------------------------------------
            // BACKUP DATA (needed for search & pagination)
            // ---------------------------------------------------
            FullData = dt1.Copy();
            filteredDT = null;

           
            // ---------------------------------------------------
            // PAGINATION SETUP
            // ---------------------------------------------------
            totalRecordsSRM = dt1.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // Load first page
            LoadPageSRM();

            // Format TotalPrice Column
            if (grdOrderFoodShow.Columns.Contains("TotalPrice"))
                grdOrderFoodShow.Columns["TotalPrice"].HeaderText = "Total Price (₹)";

            // Create page buttons
            CreatePageButtonSRM();

            // Add checkbox in header
            AddHeaderCheckBoxSRM();
          

            // Lock all columns except checkbox column
            foreach (DataGridViewColumn col in grdOrderFoodShow.Columns)
                col.ReadOnly = true;

            if (grdOrderFoodShow.Columns.Contains("Check"))
                grdOrderFoodShow.Columns["Check"].ReadOnly = false;
        }

        private void AddHeaderCheckBoxSRM()
        {
            if (!grdOrderFoodShow.Columns.Contains("Check"))
                return;

            // Remove old checkbox if exists
            grdOrderFoodShow.Controls.Remove(headerCheckBox);

            headerCheckBox = new CheckBox();
            headerCheckBox.Size = new Size(18, 18);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;

            int colIndex = grdOrderFoodShow.Columns["Check"].Index;

            // Get header cell rectangle
            System.Drawing.Rectangle rect = grdOrderFoodShow.GetCellDisplayRectangle(colIndex, -1, true);

            // Center checkbox
            headerCheckBox.Location = new Point(
                rect.X + (rect.Width - headerCheckBox.Width) / 2,
                rect.Y + (rect.Height - headerCheckBox.Height) / 2
            );

            // Event
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            grdOrderFoodShow.Controls.Add(headerCheckBox);
            headerCheckBox.BringToFront();
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = headerCheckBox.Checked;

            foreach (DataGridViewRow row in grdOrderFoodShow.Rows)
            {
                if (row.Cells["Check"] is DataGridViewCheckBoxCell chk)
                    chk.Value = isChecked;
            }

            grdOrderFoodShow.RefreshEdit();
        }


        public void LoadPageSRM()
        {
            DataTable source = (filteredDT != null) ? filteredDT : dt1;

            startIndexSRM = (currentPageSRM - 1) * pageSizeSRM;

            DataTable dtPage = source.Clone();

            for (int i = startIndexSRM; i < startIndexSRM + pageSizeSRM && i < source.Rows.Count; i++)
            {
                dtPage.ImportRow(source.Rows[i]);
            }

            grdOrderFoodShow.DataSource = dtPage;
            AddHeaderCheckBoxSRM();
            AddSrNoSRM();
        }

        private void AddSrNoSRM()
        {
            if (grdOrderFoodShow.Rows.Count == 0) return;

            int startNumber = ((currentPageSRM - 1) * pageSizeSRM) + 1;

            for (int i = 0; i < grdOrderFoodShow.Rows.Count; i++)
            {
               grdOrderFoodShow.Rows[i].Cells["Sr No"].Value = startNumber + i;
            }
        }
        public void CreatePageButtonSRM()
        {
            pnlPages.Controls.Clear();

            DataTable source = (filteredDT != null) ? filteredDT : dt1;

            totalRecordsSRM = source.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            int bwidth = 40, bheight = 35, spacing = 5, start = 10;

            for (int i = 1; i <= totalPagesSRM; i++)
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidth, bheight);
                btnPage.Location = new Point(start, 5);

                btnPage.FillColor = (i == currentPageSRM) ? Color.DimGray : Color.White;
                btnPage.ForeColor = (i == currentPageSRM) ? Color.White : Color.Black;

                btnPage.Click += btnPage_Click;

                pnlPages.Controls.Add(btnPage);
                start += bwidth + spacing;
            }

            btnPrevious.Enabled = currentPageSRM > 1;
            btnNext.Enabled = currentPageSRM < totalPagesSRM;
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                currentPageSRM = Convert.ToInt32(btn.Text);
                LoadPageSRM();
                CreatePageButtonSRM();
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPageSRM > 1)
            {
                currentPageSRM--;
                LoadPageSRM();
                CreatePageButtonSRM();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPageSRM < totalPagesSRM)
            {
                currentPageSRM++;
                LoadPageSRM();
                CreatePageButtonSRM();
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";         // Clear search
            //cmbbxBooking.SelectedIndex = -1; // Clear booking filter
            filteredDT = null;

            clsUser obj = new clsUser();

            // ---------------------------------------------------
            // SAME LOGIC AS frmorderplaced_Load
            // ---------------------------------------------------
            if (string.IsNullOrEmpty(RoomNameSRM) && string.IsNullOrEmpty(GuestNameSRM))
            {
                // Load FULL order history
                dt1 = obj.DisplayOrderHistorySRM();
            }
            else
            {
                // Load only that guest's active orders
                obj.RoomNameSRM = RoomNameSRM;
                obj.GuestNameSRM = GuestNameSRM;

                dt1 = obj.DisplayFoodOrdersSRM();
            }

            // Backup full data again
            FullData = dt1.Copy();
            filteredDT = null;

            // ---------------------------------------------------
            // SrNo Column
            //// ---------------------------------------------------
            //if (!dt1.Columns.Contains("SrNo"))
            //    dt1.Columns.Add("SrNo", typeof(int));

            //for (int i = 0; i < dt1.Rows.Count; i++)
            //    dt1.Rows[i]["SrNo"] = i + 1;

            // ---------------------------------------------------
            // Reset Pagination
            // ---------------------------------------------------
            currentPageSRM = 1;
            totalRecordsSRM = dt1.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // Reload grid
            LoadPageSRM();
            CreatePageButtonSRM();

            // ---------------------------------------------------
            // RESET HEADER CHECKBOX
            // ---------------------------------------------------
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            // reset individual row checkboxes
            foreach (DataGridViewRow row in grdOrderFoodShow.Rows)
            {
                if (row.Cells["Check"] is DataGridViewCheckBoxCell chk)
                    chk.Value = false;
            }

            // Hide booking filter again
           
           pnlFilter.Visible = true;
            lblFromDate.Visible = true;
            lblToDate.Visible = true;
            dtpFromDate.Visible = true;
            dtpEndDate.Visible = true;
        }
        

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;

            lblFromDate.Visible = pnlFilter.Visible;
            lblToDate.Visible = pnlFilter.Visible;
            dtpFromDate.Visible = pnlFilter.Visible;
            dtpEndDate.Visible = pnlFilter.Visible; 
           // pnlFilter.Visible = true;
           
        }

        private void frmorderplaced_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (dimFormSRM != null) dimFormSRM.Close();
        }

        private void pnlFilters_Paint(object sender, PaintEventArgs e)
        {

        }

        //public void FetchFromDateToDateSRM()
        //{
        //    try
        //    {


        //        DateTime fromDate = dtpFromDate.Value.Date;
        //        DateTime toDate = dtpEndDate.Value.Date;

        //        if (fromDate < new DateTime(1753, 1, 1))
        //            fromDate = DateTime.Now.Date;
        //        if (toDate < new DateTime(1753, 1, 1))
        //            toDate = DateTime.Now.Date;

        //        clsUser obj = new clsUser();


        //        //obj.StartDate = fromDate;
        //        //obj.EndDate = toDate;

        //        obj.StartDate = fromDate.ToString();
        //        obj.EndDate = toDate.ToString();
        //        dt1 = obj.HistoryOfOrderFood();
        //        totalRecordsSRM = dt1.Rows.Count;
        //        totalPagesSRM = (int)Math.Ceiling((Double)totalRecordsSRM / pageSizeSRM);

        //        currentPageSRM = 1;
        //        LoadPageSRM();
        //        CreatePageButtonSRM();
        //        AddHeaderCheckBoxSRM();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}
        public void FetchFromDateToDateSRM()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpEndDate.Value.Date;

                // Handling minimum SQL Date value (1753-01-01)
                if (fromDate < new DateTime(1753, 1, 1))
                    fromDate = DateTime.Now.Date;
                if (toDate < new DateTime(1753, 1, 1))
                    toDate = DateTime.Now.Date;

                clsUser obj = new clsUser();

                // **FIX:** Explicitly convert DateTime to string using the unambiguous ISO 8601 format (yyyy-MM-dd).
                // This format is safest for SQL Server and prevents regional setting conflicts.
                obj.StartDateSRM = fromDate.ToString("yyyy-MM-dd");
                obj.EndDateSRM = toDate.ToString("yyyy-MM-dd");

                // This method will now receive date strings in 'YYYY-MM-DD' format.
                dt1 = obj.HistoryOfOrderFood();

                totalRecordsSRM = dt1.Rows.Count;
                totalPagesSRM = (int)Math.Ceiling((Double)totalRecordsSRM / pageSizeSRM);

                currentPageSRM = 1;
                LoadPageSRM();
                CreatePageButtonSRM();
                AddHeaderCheckBoxSRM();
            }
            catch (Exception ex)
            {
                // Added proper error message structure for user feedback
                MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFSRM(grdOrderFoodShow);
        }
        private void ExportCheckedRowsToPDFSRM(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("No grid provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit();

            var skipColumnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "Select", "check", "Action","imgView","Sr No","imgEdit","Apply","Details",
    };

            var orderedCols = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumnNames.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (orderedCols.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewColumn checkCol = null;
            foreach (var name in new[] { "Select", "check" })
            {
                checkCol = grid.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                if (checkCol != null) break;
            }

            if (checkCol == null)
                checkCol = grid.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c is DataGridViewCheckBoxColumn);

            if (checkCol == null)
            {
                MessageBox.Show("Checkbox column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRows = grid.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                            r.Cells[checkCol.Index].Value != null &&
                            Convert.ToBoolean(r.Cells[checkCol.Index].Value))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = this.Text.Replace(" ", "_");

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string filePath = sfd.FileName;

                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // ---------------- FONT SETUP ----------------
                iTextSharp.text.Font headerFont = GetUnicodeFont(16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = GetUnicodeFont(10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = GetUnicodeFont(11, iTextSharp.text.Font.BOLD);

                // ---------------- HEADER ----------------
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(new Phrase("Order History List", headerFont));
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(titleCell);

                string dateOnly = "Genarated Date: " + DateTime.Now.ToString("dd-MM-yyyy");
                PdfPCell dateCell = new PdfPCell(new Phrase(dateOnly, boldFont));
                dateCell.Border = PdfPCell.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                headerTable.AddCell(dateCell);

                headerTable.SpacingAfter = 15;
                doc.Add(headerTable);

                // ---------------- SrNo COLUMN ----------------
                bool hasSrNo = orderedCols.Any(c =>
                    c.HeaderText.Equals("SrNo", StringComparison.OrdinalIgnoreCase) ||
                    c.Name.Equals("SrNo", StringComparison.OrdinalIgnoreCase));

                if (!hasSrNo)
                {
                    orderedCols.Insert(0,
                        new DataGridViewTextBoxColumn { Name = "SrNo", HeaderText = "SrNo" });
                }

                // ---------------- TABLE -----------------
                PdfPTable table = new PdfPTable(orderedCols.Count);
                table.WidthPercentage = 100;

                // Header cells
                foreach (var col in orderedCols)
                {
                    var headerCell = new PdfPCell(new Phrase(col.HeaderText ?? col.Name, boldFont));
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(headerCell);
                }

                // Data rows with SrNo starting from 1
                int sr = 1;

                foreach (var row in selectedRows)
                {
                    foreach (var col in orderedCols)
                    {
                        string value = "";

                        if (col.HeaderText.Equals("SrNo", StringComparison.OrdinalIgnoreCase) ||
                            col.Name.Equals("SrNo", StringComparison.OrdinalIgnoreCase))
                        {
                            value = sr.ToString();
                        }
                        else if (col.HeaderText.Equals("Total Price", StringComparison.OrdinalIgnoreCase) ||
                                 col.Name.Equals("Total Price", StringComparison.OrdinalIgnoreCase))
                        {
                            // Format FoodPrice with rupees
                            decimal price;
                            if (decimal.TryParse(row.Cells[col.Index].Value?.ToString(), out price))
                            {
                                value = "₹ " + price.ToString("N2");
                            }
                            else
                            {
                                value = row.Cells[col.Index].Value?.ToString() ?? "";
                            }
                        }
                        else
                        {
                            value = row.Cells[col.Index].Value?.ToString() ?? "";
                        }

                        var cell = new PdfPCell(new Phrase(value, normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    sr++;
                }

                doc.Add(table);

                doc.Close();

                MessageBox.Show("PDF generated successfully!\nSaved at: " + filePath,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ---------------- HELPER METHOD FOR UNICODE FONT ----------------
        private iTextSharp.text.Font GetUnicodeFont(float size = 10, int style = iTextSharp.text.Font.NORMAL)
        {
            // Ensure this font exists on the system
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            return new iTextSharp.text.Font(bf, size, style);
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcelSRM(grdOrderFoodShow);
        }
        private void ExportCheckedRowsToExcelSRM(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("Grid not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit(); // Commit checkbox state

            // Skip checkbox & icon columns
            var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "check", "Action", "Sr No", "Edit", "View", "Details", "Apply"
            };

            var exportColumns = grid.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (exportColumns.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Only selected rows
            var selectedRows = grid.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["check"].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "SelectedRows.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = sfd.FileName;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Selected Rows");

                    int currentRow = 1;

                    ws.Cell(currentRow, 1).Value = "Total Order History";
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow++;

                    ws.Cell(currentRow, 1).Value = "Genarated Date: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow += 2; // space after date

                    // -------------------------------
                    //  ADD TABLE HEADERS (SrNo + columns)
                    // -------------------------------

                    int currentCol = 1;

                    ws.Cell(currentRow, currentCol).Value = "SrNo";
                    ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                    ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentCol++;

                    foreach (var col in exportColumns)
                    {
                        ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                        ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                        ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentCol++;
                    }

                    // -------------------------------
                    //  ADD DATA ROWS
                    // -------------------------------
                    int srNo = 1;

                    foreach (var row in selectedRows)
                    {
                        currentRow++;
                        currentCol = 1;

                        // Add SrNo
                        ws.Cell(currentRow, currentCol).Value = srNo++;
                        currentCol++;

                        foreach (var col in exportColumns)
                        {
                            ws.Cell(currentRow, currentCol).Value = row.Cells[col.Index].Value?.ToString() ?? "";
                            currentCol++;
                        }
                    }

                    // Auto-fit
                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Excel file generated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchSRM(txtSearchBox.Text);  
        }
        public void ApplySearchSRM(string searchText)
        {
            if (FullData == null) return;

            searchText = searchText.Trim().Replace("'", "''");

            DataTable sourceDT;

            if (string.IsNullOrWhiteSpace(searchText))
            {
                // No search → show full data
                sourceDT = FullData.Copy();
            }
            else
            {
                // Apply search filter
                DataView dv = new DataView(FullData);
                string filter = "";

                foreach (DataColumn col in FullData.Columns)
                {
                    filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
                }

                filter = filter.Substring(0, filter.Length - 4); // remove last OR
                dv.RowFilter = filter;

                sourceDT = dv.ToTable();
            }

            // Set filtered data for pagination
            filteredDT = sourceDT.Copy();
            currentPageSRM = 1;

            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // Load first page
            LoadPageSRM();
            CreatePageButtonSRM();

            // Reset header checkbox
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
        }

        private void cmbbxBooking_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(cmbbxBooking.Text)) return;

            //clsUser obj = new clsUser();
            //obj.RoomNameSRM = RoomNameSRM;
            //obj.GuestNameSRM = GuestNameSRM;
            //obj.BookingCodeSRM = cmbbxBooking.Text;

            //DataTable dtFiltered;

            //if (string.IsNullOrEmpty(RoomNameSRM) && string.IsNullOrEmpty(GuestNameSRM))
            //{
            //    // Apply booking filter on full order history
            //    dtFiltered = obj.DisplayOrderHistorySRM().Clone();

            //    // Get all order history and filter by BookingCode
            //    foreach (DataRow row in obj.DisplayOrderHistorySRM().Rows)
            //    {
            //        if (row["BookingCode"].ToString() == cmbbxBooking.Text)
            //            dtFiltered.ImportRow(row);
            //    }
            //}
            //else
            //{
            //    // Apply booking filter on active guest orders
            //    dtFiltered = obj.DisplayFoodOrdersSRM().Clone();

            //    foreach (DataRow row in obj.DisplayFoodOrdersSRM().Rows)
            //    {
            //        if (row["BookingCode"].ToString() == cmbbxBooking.Text)
            //            dtFiltered.ImportRow(row);
            //    }
            //}

            //filteredDT = dtFiltered.Copy();
            //currentPageSRM = 1;

            //LoadPageSRM();
            //CreatePageButtonSRM();

            //// reset header checkbox
            //headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            //headerCheckBox.Checked = false;
            //headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;


            // if (string.IsNullOrEmpty(cmbbxBooking.Text)) return;

            //clsUser obj = new clsUser();
            //obj.RoomNameSRM = RoomNameSRM;
            //obj.GuestNameSRM = GuestNameSRM;
            //obj.BookingCodeSRM = cmbbxBooking.Text;

            //filteredDT = obj.DisplayFoodOrdersSRM().Copy();
            //currentPageSRM = 1;
            //LoadPageSRM();
            //CreatePageButtonSRM();

            //headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            //headerCheckBox.Checked = false;
            //headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdOrderFoodShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FetchFromDateToDateSRM();
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            FetchFromDateToDateSRM();
        }

        private void pnlPages_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}

