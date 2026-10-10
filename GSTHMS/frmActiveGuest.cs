using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmActiveGuest : Form
    {
        DataTable filteredDT = null;
        public int pageSizeSRM = 9; 
        public int currentPageSRM = 1;
        public int totalPageNumberSRM = 3;
        public int totalRecordsSRM = 0;
        public int totalPagesSRM = 0;
        public int startIndexSRM = 1;
        public string RoomNameSRM;
        public string BookingCodeSRM;
        public int endindexSRM  ;
        bool isRoomLoadedSRM = false;
        public string FoodTypeSRM;
        public string FoodNameSRM;
        public decimal FoodPriceSRM;
        public DataTable FullData;
        //Form background;
        public System.Data.DataTable dt = new System.Data.DataTable();

        CheckBox headerCheckBox = new CheckBox();
        public frmActiveGuest()
        {
            InitializeComponent();
        }
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            frmParking park = new frmParking();
            park.MdiParent = this.MdiParent;
            park.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmFoodService food = new frmFoodService();
            food.MdiParent = this.MdiParent;
            food.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void btnProvideService_Click(object sender, EventArgs e)
        {

        }
           // Declare at top of class

        //private Form CreateDimBackgroundSRM()
        //{
        //    Form bg = new Form();
        //    bg.StartPosition = FormStartPosition.Manual;
        //    bg.FormBorderStyle = FormBorderStyle.None;
        //    bg.Opacity = 0.6;
        //    bg.BackColor = Color.Black;
        //    bg.WindowState = FormWindowState.Maximized;
        //    bg.TopMost = true;

        //    return bg;
        //}

        DataTable dt1 = new DataTable();

        private void frmActiveGuest_Load_1(object sender, EventArgs e)
        {
            cmbbxRoomNo.Visible = true;
            lblRoomNo.Visible = true;
            pnlPages.Visible = true;
            pnlFilter.Visible = true;

           
          
            toolTip1.SetToolTip(pctRefresh, "Refresh");
            //toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            //toolTip1.SetToolTip(pctExcel, "Export To Exel");
            //toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip1.SetToolTip(pctFilter, "Filters");
            grdProvideFood.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdProvideFood.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
           grdProvideFood.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdProvideFood.GridColor = System.Drawing.Color.Gray;

            this.grdProvideFood.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdProvideFood.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            isRoomLoadedSRM = false;   // STOP event firing
            pnlPages.Visible = true;
            clsUser provideFood = new clsUser();
            DataTable dt = provideFood.FetchRoomSRM();
            DataRow dr = dt.NewRow();
            dr["RoomID"] = 0;            // placeholder value
            dr["Room Name"] = "-- Select --"; // placeholder text
            dt.Rows.InsertAt(dr, 0);
            cmbbxRoomNo.DisplayMember = "Room Name";
            cmbbxRoomNo.ValueMember = "RoomID";
            cmbbxRoomNo.DataSource = dt;
            //grdProvideFood.AllowUserToAddRows = false;
            cmbbxRoomNo.SelectedIndex = 0;

            isRoomLoadedSRM = true;    // now event can fire

            dt1 = provideFood.DisplayActiveGuestSRM();
            FullData = dt1.Copy();
            grdProvideFood.AllowUserToAddRows = false;
            //this is show data on gridview

            totalRecordsSRM = dt1.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);
            LoadPageSRM();
            CreatePageButtonSRM();
            AddApplyIconSRM();

            // Make all columns readonly except checkbox
            foreach (DataGridViewColumn col in grdProvideFood.Columns)
                col.ReadOnly = true;

            if (grdProvideFood.Columns.Contains("Check"))
                grdProvideFood.Columns["Check"].ReadOnly = false;

            AddHeaderCheckBoxSRM();
        }

        private void grdProvideFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if Apply button clicked
            if (e.RowIndex < 0) return;

            if (grdProvideFood.Columns[e.ColumnIndex].Name == "Apply")
            {
                string guestName = grdProvideFood.Rows[e.RowIndex].Cells["Guest Name"].Value?.ToString();
                string roomName = grdProvideFood.Rows[e.RowIndex].Cells["Room Name"].Value?.ToString();

                if (!string.IsNullOrEmpty(guestName))
                {
                    frmOrderFood orderFood = new frmOrderFood
                    {
                        GuestNameSRM = guestName,
                        RoomNameSRM = roomName,
                        StartPosition = FormStartPosition.CenterScreen,
                        TopMost = true
                    };
                   
                
            
            //background = CreateDimBackgroundSRM();
            //background.Show();

            // --- CLICK OUTSIDE → ONLY CLOSE POPUP ---
            //background.Click += (s, a) =>
            //{
            //    orderFood.Close();
            //};

            //// --- WHEN POPUP CLOSES → Remove Dark Background ---
            //orderFood.FormClosed += (s, a) =>
            //{
            //    background.Close();
            //};

            orderFood.Show();
                }

                else
                {
                    MessageBox.Show("Please select a guest first.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        private void AddApplyIconSRM()
        {
            if (grdProvideFood.Columns.Contains("Apply"))
                return;

            DataGridViewImageColumn imgCol = new DataGridViewImageColumn
            {
                Name = "Apply",
                HeaderText = "Order",
                Image = Properties.Resources.Apply_Icon, // your icon
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 40,
                ReadOnly = true
            };

            grdProvideFood.Columns.Add(imgCol);

            // Optional: align center
            grdProvideFood.Columns["Apply"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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

            grdProvideFood.DataSource = dtPage;
            AddSrNoSRM();
        }

        private void AddSrNoSRM()
        {
            if (grdProvideFood.Rows.Count == 0) return;

            int startNumber = ((currentPageSRM - 1) * pageSizeSRM) + 1;

            for (int i = 0; i < grdProvideFood.Rows.Count; i++)
            {
                grdProvideFood.Rows[i].Cells["Sr No"].Value = startNumber + i;
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

                btnPage.FillColor = (i == currentPageSRM)
                    ? Color.DimGray
                    : Color.White;

                btnPage.ForeColor = (i == currentPageSRM)
                    ? Color.White
                    : Color.Black;

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
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPageSRM = pageNumber;
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

        private void pnlPages_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbbxRoomNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!isRoomLoadedSRM) return; // STOP unwanted firing

            if (cmbbxRoomNo.SelectedIndex != -1)
            {
                string roomName = cmbbxRoomNo.Text.Trim();
                ApplyFilterSRM(roomName);
                
            }
        }
        private void ApplyFilterSRM(string roomName)
        {
            if (dt1 == null || dt1.Rows.Count == 0)
            {
                MessageBox.Show("Data not loaded!");
                return;
            }

            DataView dv = new DataView(dt1);

            string safeRoom = roomName.Replace("'", "''").Trim();

            // This MATCHES even if DB has spaces/case differences
            dv.RowFilter = $"[Room Name] = '{safeRoom}'";

            filteredDT = dv.ToTable();

            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);
            currentPageSRM = 1;

            LoadPageSRM();
            CreatePageButtonSRM();
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
            bool isChecked = headerCheckBox.Checked;
            grdProvideFood.EndEdit();
            foreach (DataGridViewRow row in grdProvideFood.Rows)
            {
               
                DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = isChecked; 
            }
           grdProvideFood.RefreshEdit();
        }
        private void AddHeaderCheckBoxSRM()
        {
            if (!grdProvideFood.Columns.Contains("check"))
                return;

            grdProvideFood.Refresh();

            int colIndex = grdProvideFood.Columns["check"].Index;

            // Get the rectangle of the header cell
            System.Drawing.Rectangle rect = grdProvideFood.GetCellDisplayRectangle(colIndex, -1, true);

            headerCheckBox.Size = new Size(18, 18); // checkbox size

            // ---- CENTERING THE CHECKBOX ----
            int x = rect.X + (rect.Width - headerCheckBox.Width) / 2;
            int y = rect.Y + (rect.Height - headerCheckBox.Height) / 2;

            headerCheckBox.Location = new Point(x, y);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;

            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            if (!grdProvideFood.Controls.Contains(headerCheckBox))
                grdProvideFood.Controls.Add(headerCheckBox);

            headerCheckBox.BringToFront();
        }


        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFSRM(grdProvideFood);
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
                sfd.FileName = this.Text.Replace(" ", "_") + "_Report.pdf";

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string filePath = sfd.FileName;

                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // ---------------- HEADER ----------------
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(
                    new Phrase("Total Guest ", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
                );
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(titleCell);

                string dateOnly = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
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
        private void ExportCheckedRowsToExcel(DataGridView grid)
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

                    ws.Cell(currentRow, 1).Value = "Total Active Guest";
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

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcel(grdProvideFood);
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchSRM(txtSearchBox.Text);

        }

        public void ApplySearchSRM(string searchText)
        {
            if (FullData == null)
                return;

            searchText = searchText.Trim().Replace("'", "''");

            DataView dv = new DataView(FullData);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dt1 = FullData.Copy();
            }
            else
            {
                string filter = "";

                foreach (DataColumn col in FullData.Columns)
                {
                    filter += $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{searchText}%' OR ";
                }

                filter = filter.Substring(0, filter.Length - 4);

                dv.RowFilter = filter;

                dt1 = dv.ToTable();
            }

            currentPageSRM = 1;
            LoadPageSRM();
            CreatePageButtonSRM();
        }






        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdProvideFood.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdProvideFood.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdProvideFood.Rows.RemoveAt(i);
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

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;

            lblRoomNo.Visible = pnlFilter.Visible;
            cmbbxRoomNo.Visible = pnlFilter.Visible;
            // Optional: bring it above grid
            // pnlFilter.BringToFront();
            //  lblRoomNo.BringToFront();

        }
        private void pctRefresh_Click(object sender, EventArgs e)
        {
           
            isRoomLoadedSRM = false; // stop triggering filter during refresh

            clsUser provideFood = new clsUser();

            // Reload full data
            dt1 = provideFood.DisplayActiveGuestSRM();

            // Clear search and filters
            txtSearchBox.Text = "";
            filteredDT = null;   // remove filter
            cmbbxRoomNo.SelectedIndex = -1;  // reset dropdown

            // Reset pagination
            currentPageSRM = 1;
            totalRecordsSRM = dt1.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // Reload first page & buttons
            LoadPageSRM(); 
            CreatePageButtonSRM();
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged; // stop event firing
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            //  Make sure all row checkboxes also become unchecked
            foreach (DataGridViewRow row in grdProvideFood.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = false;
            }

            isRoomLoadedSRM = true;
            lblRoomNo.Visible = true;
            cmbbxRoomNo.Visible = true;

            pnlFilter.Visible = true;
        }

        private void cmbbxRoomNo_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
       
        private void btnHistory_Click(object sender, EventArgs e)
        {
            frmorderplaced frm = new frmorderplaced();

            // ✔ Force History Mode (load all orders)
            frm.RoomNameSRM = null;
            frm.GuestNameSRM = null;

            frm.Show();
        
        }

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlPages_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }

}



