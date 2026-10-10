using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmGuest : Form
    {
        public int pageSizeSC = 20;
        public int currentPageSC = 1;
        public int totalPageNumberSC = 3;
        public int totalRecordsSC = 0;
        public int totalPagesSC = 0;

        clsUser objUser = new clsUser();
        DataTable dt1 = new DataTable();
        CheckBox headerCheckBox = new CheckBox();
        DataTable dtFiltered = null;
        public string code;

        // FIX: dtFiltered != null is always true once assigned even if empty.
        // Use Rows.Count > 0 to correctly fall back to dt1 when no filter is active.
        private DataTable CurrentData =>
            (dtFiltered != null && dtFiltered.Rows.Count > 0) ? dtFiltered : dt1;

        public frmGuest()
        {
            InitializeComponent();
        }

        // ── Form load ──────────────────────────────────────────────────────────────

        private void frmGuest_Load(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = true;

                grdGuestDetails.DefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11);
                grdGuestDetails.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11);
                grdGuestDetails.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                grdGuestDetails.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                grdGuestDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdGuestDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdGuestDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdGuestDetails.GridColor = System.Drawing.Color.Gray;
                grdGuestDetails.AllowUserToAddRows = false;
                grdGuestDetails.EditMode = DataGridViewEditMode.EditOnEnter;

                LoadGridSC();
                AddHeaderCheckBoxSC();

                // Column readonly settings
                if (grdGuestDetails.Columns.Contains("Guest Name"))
                    grdGuestDetails.Columns["Guest Name"].ReadOnly = true;
                if (grdGuestDetails.Columns.Contains("Contact No"))
                    grdGuestDetails.Columns["Contact No"].ReadOnly = true;
                if (grdGuestDetails.Columns.Contains("Email"))
                    grdGuestDetails.Columns["Email"].ReadOnly = true;
                if (grdGuestDetails.Columns.Contains("Registration Date"))
                    grdGuestDetails.Columns["Registration Date"].ReadOnly = true;
                if (grdGuestDetails.Columns.Contains("SrNo"))
                    grdGuestDetails.Columns["SrNo"].ReadOnly = true;

                FixGridColumnOrderPSS();

                // DateTimePicker format
                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "dd/MM/yyyy";
                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "dd/MM/yyyy";
                dtpToDate.MinDate = dtpFromDate.Value;

                // Add Edit icon column
                if (!grdGuestDetails.Columns.Contains("imgEdit"))
                {
                    DataGridViewImageColumn imgEdit = new DataGridViewImageColumn();
                    imgEdit.Name = "imgEdit";
                    imgEdit.HeaderText = "Edit";
                    imgEdit.Image = Properties.Resources.Edit_icon;
                    imgEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdGuestDetails.Columns.Add(imgEdit);
                }

                // Add View icon column
                if (!grdGuestDetails.Columns.Contains("imgView"))
                {
                    DataGridViewImageColumn imgView = new DataGridViewImageColumn();
                    imgView.Name = "imgView";
                    imgView.HeaderText = "View";
                    imgView.Image = Properties.Resources.view_icon;
                    imgView.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdGuestDetails.Columns.Add(imgView);
                }

                grdGuestDetails.Columns["imgEdit"].DisplayIndex =
                    grdGuestDetails.Columns.Count - 2;
                grdGuestDetails.Columns["imgView"].DisplayIndex =
                    grdGuestDetails.Columns.Count - 1;

                if (grdGuestDetails.Columns.Contains("GuestID"))
                    grdGuestDetails.Columns["GuestID"].Visible = false;
                if (grdGuestDetails.Columns.Contains("GuestCode"))
                    grdGuestDetails.Columns["GuestCode"].Visible = false;

                // Tooltips
                tipGuest.SetToolTip(pctRefresh, "Refresh");
                tipGuest.SetToolTip(pctPDF, "Download The PDF");
                tipGuest.SetToolTip(pctExcel, "Export To Excel");
                tipGuest.SetToolTip(pctFilter, "Filters");
                tipGuest.SetToolTip(pctAddGuest, "Add Guest");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Header checkbox ────────────────────────────────────────────────────────

        private void AddHeaderCheckBoxSC()
        {
            try
            {
                if (!grdGuestDetails.Columns.Contains("check")) return;

                System.Drawing.Rectangle rect =
                    grdGuestDetails.GetCellDisplayRectangle(
                        grdGuestDetails.Columns["check"].Index, -1, true);

                headerCheckBox.Size = new System.Drawing.Size(16, 16);
                headerCheckBox.BackColor = System.Drawing.Color.Transparent;
                headerCheckBox.Cursor = Cursors.Hand;
                headerCheckBox.Location = new System.Drawing.Point(
                    rect.X + 56, rect.Y + (rect.Height - headerCheckBox.Height) / 2);

                headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

                if (!grdGuestDetails.Controls.Contains(headerCheckBox))
                    grdGuestDetails.Controls.Add(headerCheckBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding header checkbox: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = headerCheckBox.Checked;
                grdGuestDetails.EndEdit();

                foreach (DataGridViewRow row in grdGuestDetails.Rows)
                {
                    DataGridViewCheckBoxCell chk =
                        row.Cells["check"] as DataGridViewCheckBoxCell;
                    if (chk != null)
                        chk.Value = isChecked;
                }

                grdGuestDetails.RefreshEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating checkboxes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid column order ──────────────────────────────────────────────────────

        private void FixGridColumnOrderPSS()
        {
            try
            {
                if (grdGuestDetails.Columns.Contains("check"))
                    grdGuestDetails.Columns["check"].DisplayIndex = 0;
                if (grdGuestDetails.Columns.Contains("SrNo"))
                    grdGuestDetails.Columns["SrNo"].DisplayIndex = 1;
                if (grdGuestDetails.Columns.Contains("Guest Name"))
                    grdGuestDetails.Columns["Guest Name"].DisplayIndex = 2;
                if (grdGuestDetails.Columns.Contains("Contact No"))
                    grdGuestDetails.Columns["Contact No"].DisplayIndex = 3;
                if (grdGuestDetails.Columns.Contains("Email"))
                    grdGuestDetails.Columns["Email"].DisplayIndex = 4;
                if (grdGuestDetails.Columns.Contains("Registration Date"))
                    grdGuestDetails.Columns["Registration Date"].DisplayIndex = 5;

                // Always keep icons at the end
                if (grdGuestDetails.Columns.Contains("imgEdit"))
                    grdGuestDetails.Columns["imgEdit"].DisplayIndex =
                        grdGuestDetails.Columns.Count - 2;
                if (grdGuestDetails.Columns.Contains("imgView"))
                    grdGuestDetails.Columns["imgView"].DisplayIndex =
                        grdGuestDetails.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fixing column order: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Data loading ───────────────────────────────────────────────────────────

        public void LoadGridSC()
        {
            try
            {
                clsUser obj = new clsUser();
                dt1 = obj.FetchGuestDetailsSC();
                dtFiltered = null;

                totalRecordsSC = dt1.Rows.Count;
                totalPagesSC = (int)Math.Ceiling((double)totalRecordsSC / pageSizeSC);
                currentPageSC = 1;

                LoadPageSC();
                CreatePageButtonSC();
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grid: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPageSC()
        {
            try
            {
                int startIndex = (currentPageSC - 1) * pageSizeSC;
                DataTable dtPage = CurrentData.Clone();

                for (int i = startIndex;
                     i < startIndex + pageSizeSC && i < CurrentData.Rows.Count; i++)
                    dtPage.ImportRow(CurrentData.Rows[i]);

                grdGuestDetails.DataSource = dtPage;
                FixGridColumnOrderPSS();
                AddHeaderCheckBoxSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Pagination buttons ─────────────────────────────────────────────────────

        public void CreatePageButtonSC()
        {
            try
            {
                int bwidth = 40, bheight = 35, spacing = 5;
                pnlPages.Controls.Clear();

                int totalpages = (int)Math.Ceiling(
                    (double)CurrentData.Rows.Count / pageSizeSC);
                totalPagesSC = totalpages;

                int totalButtonsWidth = totalpages * (bwidth + spacing) - spacing;
                int start = (pnlPages.Width - totalButtonsWidth) / 2;
                if (start < 0) start = 10;

                for (int i = 1; i <= totalpages; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new System.Drawing.Size(bwidth, bheight);
                    btnPage.Location = new System.Drawing.Point(start, 5);
                    btnPage.FillColor = (i == currentPageSC)
                        ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentPageSC)
                        ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    btnPage.Click += btnPage_Click;
                    pnlPages.Controls.Add(btnPage);
                    start += bwidth + spacing;
                }

                btnPrevious.Enabled = currentPageSC > 1;
                btnNext.Enabled = currentPageSC < totalPagesSC;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating page buttons: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                if (btn != null)
                {
                    currentPageSC = Convert.ToInt32(btn.Text);
                    LoadPageSC();
                    CreatePageButtonSC();
                    FixGridColumnOrderPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageSC > 1)
                {
                    currentPageSC--;
                    LoadPageSC();
                    CreatePageButtonSC();
                    FixGridColumnOrderPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to previous page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageSC < totalPagesSC)
                {
                    currentPageSC++;
                    LoadPageSC();
                    CreatePageButtonSC();
                    FixGridColumnOrderPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to next page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Date filter ────────────────────────────────────────────────────────────

        public void FilterGridByDateSC()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                clsUser objCls = new clsUser();
                objCls.FromDateSC = fromDate;
                objCls.ToDateSC = toDate;

                dtFiltered = objCls.FetchGuestByDateSC();

                currentPageSC = 1;
                totalRecordsSC = dtFiltered.Rows.Count;
                totalPagesSC = (int)Math.Ceiling((double)totalRecordsSC / pageSizeSC);

                LoadPageSC();
                CreatePageButtonSC();
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value;
                FilterGridByDateSC();
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying from-date filter: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    dtpToDate.Value = dtpFromDate.Value;
                    return;
                }

                FilterGridByDateSC();
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying to-date filter: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = !pnlFilter.Visible;
                if (pnlFilter.Visible)
                    pnlFilter.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error toggling filter panel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Search ─────────────────────────────────────────────────────────────────

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBox.Text.Trim().Replace("'", "''");

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dtFiltered = null;
                    currentPageSC = 1;
                    LoadPageSC();
                    CreatePageButtonSC();
                    FixGridColumnOrderPSS();
                    return;
                }

                StringBuilder filter = new StringBuilder();

                foreach (DataColumn col in dt1.Columns)
                {
                    string colName = col.ColumnName.ToLower();
                    if (colName == "check" || colName == "imgview" || colName == "imgedit")
                        continue;

                    filter.Append(
                        $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{searchText}%' OR ");
                }

                if (filter.Length > 4)
                    filter.Length -= 4;

                DataView dv = new DataView(dt1);
                dv.RowFilter = filter.ToString();
                dtFiltered = dv.ToTable();

                // Re-number SrNo after filter
                if (!dtFiltered.Columns.Contains("SrNo"))
                    dtFiltered.Columns.Add("SrNo", typeof(int));

                int sr = 1;
                foreach (DataRow row in dtFiltered.Rows)
                    row["SrNo"] = sr++;

                currentPageSC = 1;
                LoadPageSC();
                CreatePageButtonSC();
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh ────────────────────────────────────────────────────────────────

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearchBox.Clear();
                LoadGridSC();
                //pnlFilter.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete ─────────────────────────────────────────────────────────────────

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                grdGuestDetails.EndEdit();

                var selectedRows = grdGuestDetails.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow &&
                                 Convert.ToBoolean(r.Cells["check"].Value) == true)
                    .ToList();

                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to delete.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(
                        "Are you sure you want to delete selected guest(s)?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes)
                    return;

                foreach (var row in selectedRows)
                {
                    try
                    {
                        int id = Convert.ToInt32(row.Cells["GuestId"].Value);
                        clsUser obj = new clsUser();
                        obj.FidPSS = id;
                        obj.DeleteFeedbackPSS();
                    }
                    catch (Exception rowEx)
                    {
                        MessageBox.Show(
                            "Error deleting guest ID " +
                            row.Cells["GuestId"].Value + ": " + rowEx.Message,
                            "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Selected guest(s) deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGridSC();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during delete: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid click ─────────────────────────────────────────────────────────────

        private void grdGuestDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataRow selectedRow =
                    ((DataRowView)grdGuestDetails.Rows[e.RowIndex].DataBoundItem).Row;
                code = selectedRow["GuestCode"].ToString();

                if (grdGuestDetails.Columns[e.ColumnIndex].Name == "imgView")
                {
                    frmViewGuestinfo obj = new frmViewGuestinfo(code);
                    obj.Show();
                }
                else if (grdGuestDetails.Columns[e.ColumnIndex].Name == "imgEdit")
                {
                    frmEditGuestDetails obj = new frmEditGuestDetails(code);
                    obj.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error handling grid click: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdGuestDetails_DataBindingComplete(
            object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                FixGridColumnOrderPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error after data binding: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdGuestDetails_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        { }

        // ── Add Guest ──────────────────────────────────────────────────────────────

        private void ptr_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddGuest frm = new frmAddGuest();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Add Guest form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Export PDF ─────────────────────────────────────────────────────────────

        private void ExportCheckedRowsToPDF(DataGridView grid)
        {
            try
            {
                if (grid == null)
                {
                    MessageBox.Show("No grid provided.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                grid.EndEdit();

                var skipColumnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                { "check", "Action", "imgView", "imgEdit", "SrNo" };

                var orderedCols = grid.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !skipColumnNames.Contains(c.Name))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (orderedCols.Count == 0)
                {
                    MessageBox.Show("No exportable columns found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Determine rows to export
                List<DataRow> rowsToExport;

                if (headerCheckBox.Checked)
                {
                    rowsToExport = CurrentData.AsEnumerable().ToList();
                }
                else
                {
                    rowsToExport = grid.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow
                                 && r.Cells["check"].Value != null
                                 && Convert.ToBoolean(r.Cells["check"].Value))
                        .Select(r => ((DataRowView)r.DataBoundItem).Row)
                        .ToList();

                    if (rowsToExport.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row to export.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF File|*.pdf";
                    sfd.FileName = "GuestDetails_Report.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    Document doc = null;
                    try
                    {
                        // A4 Landscape
                        doc = new Document(PageSize.A4.Rotate(), 36f, 36f, 36f, 36f);
                        PdfWriter.GetInstance(
                            doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        // ── Fonts ──────────────────────────────────────────────────
                        Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                        Font fontSmall = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                        Font fontSmallBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

                        // ── Colors ─────────────────────────────────────────────────
                        BaseColor headerBg = new BaseColor(220, 220, 220);
                        BaseColor borderColor = new BaseColor(180, 180, 180);
                        BaseColor rowAltBg = new BaseColor(245, 245, 245);

                        // ── Header section ─────────────────────────────────────────
                        PdfPTable headerTable = new PdfPTable(1);
                        headerTable.WidthPercentage = 100;

                        // Title
                        PdfPCell titleCell = new PdfPCell(
                            new Phrase("Guest Details Report", fontTitle))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            PaddingBottom = 4f
                        };
                        headerTable.AddCell(titleCell);

                        // Generated On (right-aligned)
                        PdfPCell generatedCell = new PdfPCell(
                            new Phrase("Generated On : " +
                                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fontSmall))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            PaddingBottom = 2f
                        };
                        headerTable.AddCell(generatedCell);

                        // Filter date info (left-aligned)
                        string filterText = (dtFiltered != null && dtFiltered.Rows.Count > 0)
                            ? "Filter Date : " +
                              dtpFromDate.Value.ToString("dd/MM/yyyy") +
                              " To " +
                              dtpToDate.Value.ToString("dd/MM/yyyy")
                            : "Filter Date : All Records";

                        PdfPCell filterCell = new PdfPCell(
                            new Phrase(filterText, fontSmallBold))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            PaddingBottom = 6f
                        };
                        headerTable.AddCell(filterCell);
                        headerTable.SpacingAfter = 10f;
                        doc.Add(headerTable);

                        // ── Data table ─────────────────────────────────────────────
                        PdfPTable table = new PdfPTable(orderedCols.Count + 1);
                        table.WidthPercentage = 100;

                        // Helper: header cell
                        Func<string, PdfPCell> MakeHeaderCell = text =>
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(text, fontHeader));
                            cell.BackgroundColor = headerBg;
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 6f;
                            cell.BorderColor = borderColor;
                            cell.BorderWidth = 0.5f;
                            return cell;
                        };

                        // Helper: data cell
                        Func<string, PdfPCell> MakeDataCell = text =>
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(text, fontData));
                            cell.HorizontalAlignment = Element.ALIGN_CENTER;
                            cell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            cell.Padding = 5f;
                            cell.BorderColor = borderColor;
                            cell.BorderWidth = 0.5f;
                            return cell;
                        };

                        // Header row
                        table.AddCell(MakeHeaderCell("SrNo"));
                        foreach (var col in orderedCols)
                            table.AddCell(MakeHeaderCell(col.HeaderText));

                        // Data rows
                        int srNo = 1;
                        foreach (DataRow row in rowsToExport)
                        {
                            bool isAlt = (srNo % 2 == 0);

                            PdfPCell srCell = MakeDataCell(srNo.ToString());
                            if (isAlt) srCell.BackgroundColor = rowAltBg;
                            table.AddCell(srCell);

                            foreach (var col in orderedCols)
                            {
                                object value = DBNull.Value;

                                if (!string.IsNullOrEmpty(col.DataPropertyName)
                                    && row.Table.Columns.Contains(col.DataPropertyName))
                                    value = row[col.DataPropertyName];
                                else if (row.Table.Columns.Contains(col.Name))
                                    value = row[col.Name];

                                string text = "";
                                if (value != DBNull.Value && value != null)
                                    text = (value is DateTime dt)
                                        ? dt.ToString("dd/MM/yyyy")
                                        : value.ToString();

                                PdfPCell dataCell = MakeDataCell(text);
                                if (isAlt) dataCell.BackgroundColor = rowAltBg;
                                table.AddCell(dataCell);
                            }

                            srNo++;
                        }

                        doc.Add(table);

                        MessageBox.Show("PDF generated successfully!",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception pdfEx)
                    {
                        MessageBox.Show("Error writing PDF: " + pdfEx.Message,
                            "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (doc != null && doc.IsOpen())
                            doc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ExportCheckedRowsToPDF(grdGuestDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Export Excel ───────────────────────────────────────────────────────────

        private void ExportCheckedRowsToExcel(DataGridView grid)
        {
            try
            {
                if (grid == null)
                {
                    MessageBox.Show("Grid not found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                grid.EndEdit();

                var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "check", "Action", "SrNo", "Edit", "View", "imgView", "imgEdit" };

                // Build column list from grid (for headers / display order)
                var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (exportColumns.Count == 0)
                {
                    MessageBox.Show("No exportable columns found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Determine rows to export ───────────────────────────────────────────
                List<DataRow> rowsToExport;

                if (headerCheckBox.Checked)
                {
                    // Header checkbox checked → export ALL pages from CurrentData
                    rowsToExport = CurrentData.AsEnumerable().ToList();
                }
                else
                {
                    // Only export rows checked on the current page
                    rowsToExport = grid.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow
                                 && r.Cells["check"].Value != null
                                 && Convert.ToBoolean(r.Cells["check"].Value))
                        .Select(r => ((DataRowView)r.DataBoundItem).Row)
                        .ToList();

                    if (rowsToExport.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row to export.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "GuestDetails.xlsx";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Guest Details");

                            int totalCols = exportColumns.Count + 1; // +1 for SrNo

                            // ── Row 1 : Title ──────────────────────────────────────────
                            ws.Cell(1, 1).Value = "Guest Details";
                            ws.Range(1, 1, 1, totalCols).Merge();
                            ws.Row(1).Style
                                .Font.SetBold(true)
                                .Font.SetFontSize(16)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Row(1).Height = 28;

                            // ── Row 2 : Filter info (left) + Generated On (right) ──────
                            string filterText = (dtFiltered != null && dtFiltered.Rows.Count > 0)
                                ? "Filter Date : " +
                                  dtpFromDate.Value.ToString("dd/MM/yyyy") +
                                  " To " +
                                  dtpToDate.Value.ToString("dd/MM/yyyy")
                                : "Filter Date : All Records";

                            ws.Cell(2, 1).Value = filterText;
                            ws.Cell(2, 1).Style
                                .Font.SetBold(true)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                            ws.Cell(2, totalCols).Value =
                                "Generated On: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                            ws.Cell(2, totalCols).Style
                                .Font.SetBold(true)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                            // ── Row 3 : Total Records ──────────────────────────────────
                            ws.Cell(3, 1).Value = "Total Records : " + rowsToExport.Count;
                            ws.Cell(3, 1).Style
                                .Font.SetItalic(true)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                            // ── Row 4 : Column headers ─────────────────────────────────
                            int headerRow = 4;
                            int currentCol = 1;

                            ws.Cell(headerRow, currentCol).Value = "SrNo";
                            ws.Cell(headerRow, currentCol).Style
                                .Font.SetBold(true)
                                .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            currentCol++;

                            foreach (var col in exportColumns)
                            {
                                ws.Cell(headerRow, currentCol).Value = col.HeaderText;
                                ws.Cell(headerRow, currentCol).Style
                                    .Font.SetBold(true)
                                    .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                currentCol++;
                            }

                            ws.Row(headerRow).Height = 22;

                            // ── Rows 5+ : Data (from ALL pages via rowsToExport) ────────
                            int currentRow = headerRow;
                            int sr = 1;

                            XLColor altColor = XLColor.FromHtml("#F5F5F5");

                            foreach (DataRow row in rowsToExport)
                            {
                                currentRow++;
                                currentCol = 1;
                                bool isAlt = (sr % 2 == 0);

                                // SrNo
                                ws.Cell(currentRow, currentCol).Value = sr++;
                                ws.Cell(currentRow, currentCol).Style
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                if (isAlt)
                                    ws.Cell(currentRow, currentCol).Style
                                        .Fill.SetBackgroundColor(altColor);
                                currentCol++;

                                foreach (var col in exportColumns)
                                {
                                    // Read directly from DataRow (works across all pages)
                                    object cellValue = DBNull.Value;

                                    if (!string.IsNullOrEmpty(col.DataPropertyName)
                                        && row.Table.Columns.Contains(col.DataPropertyName))
                                        cellValue = row[col.DataPropertyName];
                                    else if (row.Table.Columns.Contains(col.Name))
                                        cellValue = row[col.Name];

                                    string displayText = "";
                                    if (cellValue != DBNull.Value && cellValue != null)
                                        displayText = (cellValue is DateTime dtVal)
                                            ? dtVal.ToString("dd/MM/yyyy")
                                            : cellValue.ToString();

                                    ws.Cell(currentRow, currentCol).Value = displayText;
                                    ws.Cell(currentRow, currentCol).Style
                                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    if (isAlt)
                                        ws.Cell(currentRow, currentCol).Style
                                            .Fill.SetBackgroundColor(altColor);
                                    currentCol++;
                                }
                            }

                            // ── Border on header + data block ──────────────────────────
                            if (currentRow >= headerRow)
                            {
                                var dataRange = ws.Range(headerRow, 1, currentRow, totalCols);
                                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                dataRange.Style.Border.OutsideBorderColor = XLColor.Gray;
                                dataRange.Style.Border.InsideBorderColor = XLColor.Gray;
                            }

                            // ── Auto-fit columns ───────────────────────────────────────
                            ws.Columns().AdjustToContents();

                            // Give SrNo a fixed narrow width
                            ws.Column(1).Width = 8;

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show("Excel file generated successfully!\n" +
                            "Total rows exported: " + rowsToExport.Count,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show(
                            "File is already open or cannot be written.\n" + ioEx.Message,
                            "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception excelEx)
                    {
                        MessageBox.Show("Error writing Excel file: " + excelEx.Message,
                            "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pctExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportCheckedRowsToExcel(grdGuestDetails);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Misc unused stubs ──────────────────────────────────────────────────────

        private void pnlPages_Paint(object sender, PaintEventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}