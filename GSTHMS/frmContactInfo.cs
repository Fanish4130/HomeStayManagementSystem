using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace GSTHMS
{
    public partial class frmProfileSetting : Form
      {
       


        public int pageSizePSS = 4;   //number of rows
        public int currentPagePSS = 1;
        public int totalPageNumberPSS = 3;

        public int totalRecordsPSS = 0;
        public int totalPagesPSS = 0;

        clsUser objUser = new clsUser();
        DataTable dt1 = new DataTable();

        CheckBox headerCheckBox = new CheckBox();
        DataTable dtFiltered = new DataTable();

        Form background;
        private DataTable CurrentData => dtFiltered != null && dtFiltered.Rows.Count > 0 ? dtFiltered : dt1;
        public frmProfileSetting()
        {
            InitializeComponent();
           //IsMdiContainer = true;

        }
        private void AddHeaderCheckBoxPSS()//// Add Check Box////////////////
        {
            if (!grdContact.Columns.Contains("check")) return;

            System.Drawing.Rectangle rect = grdContact.GetCellDisplayRectangle(grdContact.Columns["check"].Index, -1, true);

            headerCheckBox.Size = new Size(16, 16);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;
            headerCheckBox.Location = new Point(rect.X + 45, rect.Y + (rect.Height - headerCheckBox.Height) / 2);

            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            if (!grdContact.Controls.Contains(headerCheckBox))
                grdContact.Controls.Add(headerCheckBox);
        }


        private void LoadPagePSS()
        {
            int startIndex = (currentPagePSS - 1) * pageSizePSS;
            DataTable dtPage = CurrentData.Clone();

            for (int i = startIndex; i < startIndex + pageSizePSS && i < CurrentData.Rows.Count; i++)
                dtPage.ImportRow(CurrentData.Rows[i]);

            grdContact.DataSource = dtPage;
        }

       
        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPagePSS = pageNumber;
                LoadPagePSS();
                CreatePageButtonPSS();
            }
        }

        public void CreatePageButtonPSS()
        {
            int bwidth = 40;
            int bheight = 35;
            int spacing = 5;
            int start = 10;

            pnlPages.Controls.Clear();

            int totalpages = (int)Math.Ceiling((double)CurrentData.Rows.Count / pageSizePSS);
            totalPagesPSS = totalpages;

            for (int i = 1; i <= totalpages; i++)
            {
                var btnPage = new Guna.UI2.WinForms.Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidth, bheight);
                btnPage.Location = new Point(start, 5);
                btnPage.FillColor = (i == currentPagePSS) ? Color.DeepSkyBlue : Color.White;
                btnPage.ForeColor = (i == currentPagePSS) ? Color.White : Color.Black;
                btnPage.Click += btnPage_Click;

                pnlPages.Controls.Add(btnPage);
                start += bwidth + spacing;
            }

            btnPrevious.Enabled = currentPagePSS > 1;
            btnNext.Enabled = currentPagePSS < totalPagesPSS;
        }
      
        private void LoadGridPSS()
        {
            clsUser SlotA1 = new clsUser();
            dt1 = SlotA1.ContactPaginationPSS(); // Load full data
            dtFiltered = null; // Reset filter

            totalRecordsPSS = dt1.Rows.Count;
            totalPagesPSS = (int)Math.Ceiling((double)totalRecordsPSS / pageSizePSS);

            currentPagePSS = 1;
            LoadPagePSS();
            CreatePageButtonPSS();

            grdContact.AllowUserToAddRows = false;
            grdContact.EditMode = DataGridViewEditMode.EditOnEnter;
        }

       

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void maskedTextBox1_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load the data into the grid
            LoadGridPSS();
            grdContact.Columns["ContactName"].ReadOnly = true;
          //  grdContact.Columns["Action"].ReadOnly = true;
            grdContact.Columns["Description"].ReadOnly = true;
            grdContact.Columns["Email"].ReadOnly = true;
            grdContact.Columns["ContactNo"].ReadOnly = true;
            grdContact.Columns["SrNo"].ReadOnly = true;

            AddHeaderCheckBoxPSS();
            // Attach the CellPainting event to draw custom icons in the "Action" column
            grdContact.CellPainting += grdContact_CellPainting;
            
            // Disable the option to add new rows by the user
            grdContact.AllowUserToAddRows = false;

           
            // Make checkboxes editable when the cell is entered
            grdContact.EditMode = DataGridViewEditMode.EditOnEnter;

            ////////////////// for contactid invisible in grid///////////
            if (grdContact.Columns.Contains("ContactId"))
            {
                grdContact.Columns["ContactId"].Visible = false;
            }

            // Add Pay icon column///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (!grdContact.Columns.Contains("imgEdit"))
            {
                DataGridViewImageColumn imgPay = new DataGridViewImageColumn();
                imgPay.Name = "imgEdit";
                imgPay.HeaderText = "Edit";
                imgPay.Image = Properties.Resources.Edit_icon; // Replace with your actual icon
                imgPay.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grdContact.Columns.Add(imgPay); 
            }

            // Add Invoice icon column 
            if (!grdContact.Columns.Contains("imgView"))
            {
                DataGridViewImageColumn imgPay = new DataGridViewImageColumn();
                imgPay.Name = "imgView";
                imgPay.HeaderText = "view";
                imgPay.Image = Properties.Resources.view_icon; // Replace with your actual icon
                imgPay.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grdContact.Columns.Add(imgPay);
            }

            //   Move Pay and Invoice columns to the end
            grdContact.Columns["imgEdit"].DisplayIndex = grdContact.Columns.Count - 1;
            grdContact.Columns["imgView"].DisplayIndex = grdContact.Columns.Count - 1;


        
        }

        private void btnAddContact_Click(object sender, EventArgs e)
        {
            frmAddContact objfrmU = new frmAddContact();
            objfrmU.MdiParent = this.MdiParent;
            objfrmU.Show();
        }
        private void LoadFilteredPagePSS()
        {
            int startIndex = (currentPagePSS - 1) * pageSizePSS;

            DataTable dtPage = dtFiltered.Clone();

            for (int i = startIndex; i < startIndex + pageSizePSS && i < dtFiltered.Rows.Count; i++)
            {
                dtPage.ImportRow(dtFiltered.Rows[i]);
            }

            grdContact.DataSource = dtPage;
        }
        private void FilterByNameEmailPSS()
        {
            if (dt1 == null || dt1.Rows.Count == 0)
                return;

            string name = txtName.Text.Trim().ToLower();
            string email = txtEmail.Text.Trim().ToLower();

            string filter = "";

            if (!string.IsNullOrEmpty(name))
                filter += $"ContactName LIKE '%{name}%'";

            if (!string.IsNullOrEmpty(email))
            {
                if (filter != "") filter += " AND ";
                filter += $"Email LIKE '%{email}%'";
            }

            DataView dv = dt1.DefaultView;
            dv.RowFilter = filter;

            // STORE FILTERED DATA HERE
            dtFiltered = dv.ToTable();

            // reset pagination
            currentPagePSS = 1;
            totalRecordsPSS = dtFiltered.Rows.Count;
            totalPagesPSS = (int)Math.Ceiling((double)totalRecordsPSS / pageSizePSS);

            LoadFilteredPagePSS();
            CreatePageButtonPSS();

            if (grdContact.Columns.Contains("Action"))
                grdContact.Columns["Action"].DisplayIndex = grdContact.Columns.Count - 1;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            
            FilterByNameEmailPSS();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            FilterByNameEmailPSS();
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Get the current state of the header checkbox (checked or unchecked)
            bool isChecked = headerCheckBox.Checked;

            /// End any ongoing edit in the grid to avoid conflicts
            grdContact.EndEdit();

            // Loop through all rows in the DataGridView
            foreach (DataGridViewRow row in grdContact.Rows)
            {
                // Get the checkbox cell in this row
                DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = isChecked; // Set it to the same state as the header checkbox
            }

            // Refresh the grid so the changes are displayed immediatelysss
            grdContact.RefreshEdit();
        }

        private void grdContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           

            if (e.RowIndex < 0) return; // Ignore header row

            var row = grdContact.Rows[e.RowIndex];

            
             if (grdContact.Columns[e.ColumnIndex].Name == "imgView")
            {
                // Open View form
               // frmViewContact frm = new frmViewContact();

                background = new Form();
                background.StartPosition = FormStartPosition.Manual;
                background.FormBorderStyle = FormBorderStyle.None;
                background.Opacity = 0.6;
                background.BackColor = System.Drawing.Color.Black;
                background.WindowState = FormWindowState.Maximized;
                background.TopMost = true;
                background.Show();

                // frmAddContact f = new frmAddContact();
                frmViewContact f = new frmViewContact();

                f.StartPosition = FormStartPosition.CenterScreen;
                f.TopMost = true;
                f.FormClosed += (s, args) =>
                {
                    background.Close(); // close dim background
                    this.Enabled = true;
                    this.Opacity = 1;
                };
               // f.Show();

                f.ContactNoPSS = Convert.ToInt64(row.Cells["ContactNo"].Value);
                f.ContactNamePSS = row.Cells["ContactName"].Value.ToString();
                f.DescriptionPSS = row.Cells["Description"].Value.ToString();
                f.EmailPSS = row.Cells["Email"].Value.ToString();
                f.Show();
            }
            else if (grdContact.Columns[e.ColumnIndex].Name == "imgEdit")
            {
                // Open Edit form
               // frmEditContact frm = new frmEditContact();

                background = new Form();
                background.StartPosition = FormStartPosition.Manual;
                background.FormBorderStyle = FormBorderStyle.None;
                background.Opacity = 0.6;
                background.BackColor = System.Drawing.Color.Black;
                background.WindowState = FormWindowState.Maximized;
                background.TopMost = true;
                background.Show();

                // frmAddContact f = new frmAddContact();
                frmEditContact f = new frmEditContact();
                f.StartPosition = FormStartPosition.CenterScreen;
                f.TopMost = true;
                f.FormClosed += (s, args) =>
                {
                    background.Close(); // close dim background
                    this.Enabled = true;
                    this.Opacity = 1;
                };
                //f.Show();

                f.ContactNoPSS = Convert.ToInt64(row.Cells["ContactNo"].Value);
                f.ContactNamePSS = row.Cells["ContactName"].Value.ToString();
                f.DescriptionPSS = row.Cells["Description"].Value.ToString();
                f.EmailPSS = row.Cells["Email"].Value.ToString();
                f.Show();
            }
        }

        private void grdContact_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          
           

        }
       
        private void btnPrevious_Click(object sender, EventArgs e)
        {
           
            if (currentPagePSS > 1)
            {
                currentPagePSS--;
                LoadPagePSS();
                CreatePageButtonPSS();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
           
            if (currentPagePSS < totalPagesPSS)
            {
                currentPagePSS++;
                LoadPagePSS();
                CreatePageButtonPSS();
            }

        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;
            if (pnlFilter.Visible)
            {
                pnlFilter.BringToFront();
            }
          
        }
       

        private void ExportCheckedRowsToPDF(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("No grid provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit();

            var skipColumnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
           {
         "Select", "check", "Action","imgView","imgEdit"
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
                    new Phrase("Contact", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16))
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
        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDF(grdContact);
        }

       

        private void ExportCheckedRowsToExcel(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("Grid not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit();

            var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "check", "Action", "SrNo", "Edit", "View", "imgView", "imgEdit"
    };

            var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                                 .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                                 .OrderBy(c => c.DisplayIndex)
                                 .ToList();

            var selectedRows = grid.Rows.Cast<DataGridViewRow>()
                                 .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["check"].Value) == true)
                                 .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "SelectedRows.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Selected Rows");

                    int headerRow = 3;  // Data table starts on row 3
                    int currentRow = headerRow;
                    int currentCol = 1;

                    // ---------------------- TITLE ----------------------
                    ws.Cell(1, 1).Value = "Contact";
                    ws.Range(1, 1, 1, exportColumns.Count + 1).Merge();
                    ws.Row(1).Style
                        .Font.SetBold()
                        .Font.SetFontSize(16)
                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                    // ---------------------- DATE ------------------------
                    string today = DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(2, exportColumns.Count + 1).Value = "Date: " + today;
                    ws.Cell(2, exportColumns.Count + 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Cell(2, exportColumns.Count + 1).Style.Font.Bold = true;

                    // ---------------------- HEADERS ---------------------
                    // Add SrNo as the first header
                    ws.Cell(currentRow, currentCol).Value = "SrNo";
                    ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                    ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    currentCol++;

                    // Other headers
                    foreach (var col in exportColumns)
                    {
                        ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                        ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                        ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentCol++;
                    }

                    // ---------------------- DATA ------------------------
                    int sr = 1;

                    foreach (var row in selectedRows)
                    {
                        currentRow++;
                        currentCol = 1;

                        // Add SrNo
                        ws.Cell(currentRow, currentCol).Value = sr++;
                        currentCol++;

                        // Add other data
                        foreach (var col in exportColumns)
                        {
                            ws.Cell(currentRow, currentCol).Value =
                                row.Cells[col.Index].Value?.ToString() ?? "";
                            currentCol++;
                        }
                    }

                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel file generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcel(grdContact);
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchBox.Text.Trim().Replace("'", "''");

            // If no data loaded OR grid is not bound
            if (grdContact.DataSource == null)
                return;
            
            // Get table
             DataTable dt = (DataTable)grdContact.DataSource;

            // If search box is empty show all
            if (string.IsNullOrWhiteSpace(searchText))
            {
                dt.DefaultView.RowFilter = "";
                return;
            }

            // Build filter for all columns (LIKE windows search)
            string filter = "";

            foreach (DataColumn col in dt.Columns)
            {
                // Skip checkbox or image/icon columns:
                if (col.ColumnName.Equals("check", StringComparison.OrdinalIgnoreCase) ||
                    col.ColumnName.Equals("Action", StringComparison.OrdinalIgnoreCase))
                    continue;

                filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
            }

            // Remove last OR
            filter = filter.Substring(0, filter.Length - 4);

            // Apply filter
            dt.DefaultView.RowFilter = filter;
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            LoadGridPSS();
            txtName.Clear();
            txtEmail.Clear();
           // MessageBox.Show("Grid data refreshed successfully!", "Refreshed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtName.Clear();
            txtEmail.Clear(); 
            txtSearchBox.Clear();
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            grdContact.EndEdit();

            // Find selected rows (checkbox column name = "check")
            var selectedRows = grdContact.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                 Convert.ToBoolean(r.Cells["check"].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirm delete
            if (MessageBox.Show("Are you sure you want to delete selected Contact?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            // Delete rows one by one                                                                                                                                                                            
            foreach (var row in selectedRows)
            {
                int id = Convert.ToInt32(row.Cells["ContactId"].Value);

                clsUser obj = new clsUser();
                obj.CidPSS = id;
                obj.DeleteContactPSS();   // your delete method
            }

            MessageBox.Show("Selected Contact deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Refresh grid
            LoadGridPSS();
        }

        private void grdContact_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            //frmAddContact frm = new frmAddContact();
            //frm.ShowDialog();
            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmAddContact f = new frmAddContact();
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void grdContact_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
