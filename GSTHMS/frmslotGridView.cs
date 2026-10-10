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
using System.Web;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmslotGridView : Form
    {
        DataTable filteredDT = null;
        public int pageSizeSRM = 7;   //number of rows
        public int currentPageSRM = 1;
        public int totalPageNumberSRM = 3;

        public int totalRecordsSRM = 0;
        public int totalPagesSRM = 0;
        public int startIndexSRM = 1;
        public int endindexSRM;
        public bool DisableBackgroundDim = false;
        public string SlotNameSRM { get; set; }
        public int SlotUsedCountSRM { get; set; }
        public int SlotCapacitySRM { get; set; }
        public DataTable FullData;
        private Form dimForm = null; // The background dim
       
        public System.Data.DataTable dt = new System.Data.DataTable();
        CheckBox headerCheckBox = new CheckBox();

        public frmslotGridView(string slotname)
        {
            InitializeComponent();
           // this.FormBorderStyle = FormBorderStyle.None;
            SlotNameSRM = slotname;

            //grdAllSlotGrid.CellClick += grdAllSlotGrid_CellClick;
        }

        private void pnlPages_Paint(object sender, PaintEventArgs e)
        {

        }

        //public void ShowWithDimSRM()
        //{
        //    // Create the dim form
        //    dimForm = new Form
        //    {
        //        StartPosition = FormStartPosition.Manual,
        //        FormBorderStyle = FormBorderStyle.None,
        //        BackColor = Color.Black,
        //        Opacity = 0.5,
        //        WindowState = FormWindowState.Maximized,
        //        ShowInTaskbar = false,
        //        TopMost = true
        //    };

        //    // Clicking on dim closes the popup
        //    dimForm.Click += (s, e) =>
        //    {
        //        this.Close();  // Only close the popup
        //    };

        //    dimForm.Show();

        //    // Show the popup
        //    this.StartPosition = FormStartPosition.CenterScreen;
        //    this.TopMost = true;

        //    // Ensure dim closes when popup closes
        //    this.FormClosed += (s, e) =>
        //    {
        //        if (dimForm != null && !dimForm.IsDisposed)
        //        {
        //            dimForm.Close();
        //            dimForm = null;
        //        }
        //    };

        //    this.Show();
        //}



        DataTable dt1 = new DataTable();
        private void frmslotGridView_Load(object sender, EventArgs e)
        {
            lblSlotName.Text = ""+ SlotNameSRM;
            toolTip1.SetToolTip(pctRefresh, "Refresh");
            toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip1.SetToolTip(pctExcel, "Export To Exel");
            //toolTip1.SetToolTip(pctFilter, "Filters");
            // ---- LOAD SLOT DATA ON GRID ----
            grdAllSlotGrid.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdAllSlotGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdAllSlotGrid.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdAllSlotGrid.GridColor = System.Drawing.Color.Gray;

            this.grdAllSlotGrid.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdAllSlotGrid.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            clsUser parkinggrid = new clsUser();
            parkinggrid.SlotNameSRM = SlotNameSRM;

            dt1 = parkinggrid.DisplaySlotsSRM();
            grdAllSlotGrid.DataSource = dt1;

            // Count records in grid (Used parking count)
            SlotUsedCountSRM = dt1.Rows.Count;

            // ---- FETCH SLOT CAPACITY ----
            clsUser parking = new clsUser();
            DataTable dt = parking.ParkingSlotStatusSRM(); // Returns SlotName, UsedCount, Capacity

            // Find matching slot row
            DataRow[] row = dt.Select($"SlotName = '{SlotNameSRM}'");

            if (row.Length > 0)
            {
                SlotCapacitySRM = Convert.ToInt32(row[0]["Capacity"]);
            }

            filteredDT = dt1.Copy();

            grdAllSlotGrid.AllowUserToAddRows = false;

            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            LoadPageSRM();
            CreatePageButtonSRM();
            AddIconSRM();

            // Make all columns readonly except checkbox
            foreach (DataGridViewColumn col in grdAllSlotGrid.Columns)
                col.ReadOnly = true;

            if (grdAllSlotGrid.Columns.Contains("Check"))
               grdAllSlotGrid.Columns["Check"].ReadOnly = false;

            AddHeaderCheckBoxSRM();
        }
        public void AddIconSRM()
        {
            if (!grdAllSlotGrid.Columns.Contains("Action"))
            {
                DataGridViewImageColumn detailsColumn = new DataGridViewImageColumn();
                detailsColumn.HeaderText = "Action";
                detailsColumn.Name = "Action";
                detailsColumn.Image = Properties.Resources.view_icon; // your icon from resources
                detailsColumn.ImageLayout = DataGridViewImageCellLayout.Zoom;

                // Insert column after FoodPrice
                int colIndex = grdAllSlotGrid.Columns["Slot Name"].Index + 1;
                grdAllSlotGrid.Columns.Insert(colIndex, detailsColumn);
            }
            grdAllSlotGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdAllSlotGrid.RowTemplate.Height = 25;

        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFSRM(grdAllSlotGrid);
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
                "Select", "check", "Action","imgView","imgEdit","Apply","Details",
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

            // ---------------- FIND CHECK COLUMN ----------------
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

                // ---------------- HEADER ----------------
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(
                    new Phrase("Parking Slot ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                );
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(titleCell);

                string dateOnly = "Genarated Date: " + DateTime.Now.ToString("dd/MM/yyyy");
                PdfPCell dateCell = new PdfPCell(
                    new Phrase(dateOnly, FontFactory.GetFont(FontFactory.HELVETICA, 11, iTextSharp.text.Font.BOLD))
                );
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
                    var headerCell = new PdfPCell(
                        new Phrase(col.HeaderText ?? col.Name,
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD))
                    );
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
                            value = sr.ToString(); // force SrNo
                        }
                        else
                        {
                            value = row.Cells[col.Index].Value?.ToString() ?? "";
                        }

                        var cell = new PdfPCell(
                            new Phrase(value,
                            new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10))
                        );
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    sr++;
                }

                doc.Add(table);

                // NO FOOTER — Removed as requested

                doc.Close();

                MessageBox.Show("PDF generated successfully!\nSaved at: " + filePath,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcelSRM(grdAllSlotGrid);
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
                "check", "Action", "SrNo", "Edit", "View", "Details", "Apply"
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

                    ws.Cell(currentRow, 1).Value = "Parking Slot Information";
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow++;

                    ws.Cell(currentRow, 1).Value = "Date: " + DateTime.Now.ToString("dd-MM-yyyy");
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
        private void pctRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";         // Clear search
           
            filteredDT = null;
            clsUser objSrm = new clsUser();
            objSrm.SlotNameSRM = SlotNameSRM;   // ⭐ IMPORTANT FIX
            dt1 = objSrm.DisplaySlotsSRM();

            filteredDT = dt1.Copy();

            currentPageSRM = 1;
            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            LoadPageSRM();
            CreatePageButtonSRM();

            // ---- Add checkbox column ----
            if (!grdAllSlotGrid.Columns.Contains("check"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "check";
                chk.HeaderText = "";
                chk.Width = 50;
                grdAllSlotGrid.Columns.Insert(0, chk);
            }

            // ---- Add action icon column ----
            if (!grdAllSlotGrid.Columns.Contains("Action"))
            {
                DataGridViewImageColumn img = new DataGridViewImageColumn();
                img.Name = "Action";
                img.HeaderText = "Action";
                img.Image = Properties.Resources.view_icon;
                img.Width = 60;
                img.ImageLayout = DataGridViewImageCellLayout.Zoom;

                grdAllSlotGrid.Columns.Add(img);
            }

            // Reset header checkbox
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
        }
        public void LoadPageSRM()
        {

            if (filteredDT == null) return;

            int start = (currentPageSRM - 1) * pageSizeSRM;
            DataTable dtPage = filteredDT.Clone();

            for (int i = start; i < start + pageSizeSRM && i < filteredDT.Rows.Count; i++)
            {
                dtPage.ImportRow(filteredDT.Rows[i]);
            }

            grdAllSlotGrid.DataSource = dtPage;

            // Add/Update SrNo
            for (int i = 0; i < grdAllSlotGrid.Rows.Count; i++)
            {
                grdAllSlotGrid.Rows[i].Cells["SrNo"].Value = start + i + 1;
            }
        }

        private void AddSrNoSRM()
        {
            if (grdAllSlotGrid.Rows.Count == 0) return;

            int startNumber = ((currentPageSRM - 1) * pageSizeSRM) + 1;

            for (int i = 0; i < grdAllSlotGrid.Rows.Count; i++)
            {
                grdAllSlotGrid.Rows[i].Cells["Sr No"].Value = startNumber + i;
            }
        }



        public void CreatePageButtonSRM()
        {
            pnlPages.Controls.Clear();

            int btnWidth = 40, btnHeight = 35, spacing = 5, start = 10;

            totalPagesSRM = (int)Math.Ceiling((double)filteredDT.Rows.Count / pageSizeSRM);

            for (int i = 1; i <= totalPagesSRM; i++)
            {
                Guna2Button btn = new Guna2Button();
                btn.Name = "btnPage" + i;
                btn.Text = i.ToString();
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Location = new Point(start, 5);
                btn.FillColor = (i == currentPageSRM) ? Color.DimGray : Color.White;
                btn.ForeColor = (i == currentPageSRM) ? Color.White : Color.Black;
                btn.Click += btnPage_Click;

                pnlPages.Controls.Add(btn);
                start += btnWidth + spacing;
            }

            btnPrev.Enabled = currentPageSRM > 1;
            btnNextt.Enabled = currentPageSRM < totalPagesSRM;
        }
        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPageSRM = pageNumber;
                LoadPageSRM();
                CreatePageButtonSRM();
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = headerCheckBox.Checked;
            grdAllSlotGrid.EndEdit();
            foreach (DataGridViewRow row in grdAllSlotGrid.Rows)
            {

                DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = isChecked;
            }


            grdAllSlotGrid.RefreshEdit();
        }
        private void AddHeaderCheckBoxSRM()
        {
            if (!grdAllSlotGrid.Columns.Contains("check")) return;

            System.Drawing.Rectangle rect = grdAllSlotGrid.GetCellDisplayRectangle(grdAllSlotGrid.Columns["check"].Index, -1, true);

            headerCheckBox.Size = new Size(16, 16);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;
            headerCheckBox.Location = new Point(rect.X + 45, rect.Y + (rect.Height - headerCheckBox.Height) / 2);

            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            if (!grdAllSlotGrid.Controls.Contains(headerCheckBox))
                grdAllSlotGrid.Controls.Add(headerCheckBox);
        }

        private void grdAllSlotGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdAllSlotGrid.Columns[e.ColumnIndex].Name != "Action")
                return;

            if (grdAllSlotGrid.CurrentRow == null)
                return;

            string bookingCode = grdAllSlotGrid.CurrentRow.Cells["BookingCode"].Value.ToString();

            clsUser user = new clsUser();
            user.BookingCodeSRM = bookingCode;

            DataTable dt = user.ViewPakingDetailsSRM();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No details found.");
                return;
            }

            frmParkinDetails view = new frmParkinDetails();
            view.SlotNameSRM = dt.Rows[0]["Slot Name"].ToString();
            view.RoomNameSRM = dt.Rows[0]["Room Name"].ToString();
            view.GuestNameSRM = dt.Rows[0]["Guest Name"].ToString();
            view.VehicleTypeSRM = dt.Rows[0]["Vehicle Type"].ToString();
            view.VehicleNoSRM = dt.Rows[0]["Vehicle Number"].ToString();

            view.StartPosition = FormStartPosition.CenterScreen;
            view.TopMost = true;

            // Use Show() instead of ShowDialog()
            //view.ShowAsPopupSRM();
            view.MdiParent = this.MdiParent;
            view.Show();
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdAllSlotGrid.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdAllSlotGrid.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdAllSlotGrid.Rows.RemoveAt(i);
                    anyChecked = true;
                    MessageBox.Show("Record deleted successfullyyyyyy....!");
                }

            }
            if (!anyChecked)
            {
                MessageBox.Show("plz select a row to delete!", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchSRM(txtSearchBox.Text);
        }
        public void ApplySearchSRM(string searchText)
        {
            if (FullData == null) return;

            searchText = (searchText ?? "").Trim().ToLower();

            filteredDT = FullData.Clone();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                filteredDT = FullData.Copy();
            }
            else
            {
                foreach (DataRow row in FullData.Rows)
                {
                    bool match = false;

                    // Search SrNo
                    if (row.Table.Columns.Contains("SrNo") &&
                        row["SrNo"] != DBNull.Value &&
                        row["SrNo"].ToString().Contains(searchText))
                    {
                        match = true;
                    }

                    // Search other columns
                    if (!match)
                    {
                        foreach (DataColumn col in FullData.Columns)
                        {
                            if (col.ColumnName.Equals("Check", StringComparison.OrdinalIgnoreCase))
                                continue;

                            string value = row[col]?.ToString().ToLower() ?? "";
                            if (value.Contains(searchText))
                            {
                                match = true;
                                break;
                            }
                        }
                    }

                    if (match)
                        filteredDT.ImportRow(row);
                }
            }

            // Reset pagination
            currentPageSRM = 1;
            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            LoadPageSRM();
            CreatePageButtonSRM();

            // Reset header checkbox
            if (headerCheckBox != null)
            {
                headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                headerCheckBox.Checked = false;
                headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {

        }

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pctFilter_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pctPDF_Click_1(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFSRM(grdAllSlotGrid);
        }
    }

}






