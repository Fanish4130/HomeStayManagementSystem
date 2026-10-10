using ClosedXML.Excel;
using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Wordprocessing;
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

namespace GSTHMS
{
    public partial class frmFeedback : Form
    {
        public int pageSizePSS = 20;
        public int currentPagePSS = 1;
        public int totalPageNumberPSS = 3;
        public int totalRecordsPSS = 0;
        public int totalPagesPSS = 0;

        DataTable dt1 = new DataTable();
        DataTable dtFiltered = new DataTable();
        System.Windows.Forms.CheckBox headerCheckBox = new System.Windows.Forms.CheckBox();
        bool isHeaderCheckBoxClicked = false;
        bool isDateFilterActive = false;

        string code;
        private DataTable CurrentData => dtFiltered != null ? dtFiltered : dt1;

        public frmFeedback()
        {
            InitializeComponent();
        }

        public void AddActionColumnPSS()
        {
            try
            {
                DataGridViewImageColumn actionCol = new DataGridViewImageColumn();
                actionCol.Name = "imgView";
                actionCol.HeaderText = "View";
                actionCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                actionCol.Width = 20;
                actionCol.Image = Properties.Resources.view_icon;
                grdFeedback.Columns.Add(actionCol);
                actionCol.DisplayIndex = grdFeedback.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding action column: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddHeaderCheckBoxPSS()
        {
            try
            {
                if (!grdFeedback.Columns.Contains("check")) return;

                System.Drawing.Rectangle rect = grdFeedback.GetCellDisplayRectangle(
                    grdFeedback.Columns["check"].Index, -1, true);

                headerCheckBox.Size = new Size(16, 16);
                headerCheckBox.BackColor = System.Drawing.Color.Transparent;
                headerCheckBox.Cursor = Cursors.Hand;
                headerCheckBox.Location = new Point(rect.X + 60, rect.Y + (rect.Height - headerCheckBox.Height) / 2);

                headerCheckBox.MouseDown -= HeaderCheckBox_MouseDown;
                headerCheckBox.MouseDown += HeaderCheckBox_MouseDown;

                headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

                if (!grdFeedback.Controls.Contains(headerCheckBox))
                    grdFeedback.Controls.Add(headerCheckBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding header checkbox: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HeaderCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            isHeaderCheckBoxClicked = true;
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isHeaderCheckBoxClicked) return;

                grdFeedback.EndEdit();

                foreach (DataGridViewRow row in grdFeedback.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                        if (chk != null)
                            chk.Value = headerCheckBox.Checked;
                    }
                }

                grdFeedback.RefreshEdit();
                isHeaderCheckBoxClicked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating checkboxes: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFeedback_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (grdFeedback.Columns[e.ColumnIndex].Name == "check")
                {
                    bool allChecked = grdFeedback.Rows
                        .Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow)
                        .All(r => Convert.ToBoolean(r.Cells["check"].Value));

                    headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                    headerCheckBox.Checked = allChecked;
                    headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on cell value change: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPagePSS()
        {
            try
            {
                int startIndex = (currentPagePSS - 1) * pageSizePSS;
                DataTable dtPage = CurrentData.Clone();

                for (int i = startIndex; i < startIndex + pageSizePSS && i < CurrentData.Rows.Count; i++)
                    dtPage.ImportRow(CurrentData.Rows[i]);

                grdFeedback.DataSource = dtPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePageButtonPSS()
        {
            try
            {
                int bwidth = 40;
                int bheight = 35;
                int spacing = 5;

                pnlPages.Controls.Clear();

                int totalpages = (int)Math.Ceiling((double)CurrentData.Rows.Count / pageSizePSS);
                totalPagesPSS = totalpages;

                int totalButtonsWidth = totalpages * (bwidth + spacing) - spacing;
                int start = (pnlPages.Width - totalButtonsWidth) / 2;
                if (start < 0) start = 10;

                for (int i = 1; i <= totalpages; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidth, bheight);
                    btnPage.Location = new Point(start, 5);
                    btnPage.FillColor = (i == currentPagePSS) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentPagePSS) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    btnPage.Click += btnPage_Click;

                    pnlPages.Controls.Add(btnPage);
                    start += bwidth + spacing;
                }

                btnPrevious.Enabled = currentPagePSS > 1;
                btnNext.Enabled = currentPagePSS < totalPagesPSS;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating page buttons: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating page: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }

        public void LoadGridPSS()
        {
            try
            {
                clsUser objfe = new clsUser();
                dt1 = objfe.FeedbackPaginationPSS();


                dtFiltered = dt1.Copy();

                totalRecordsPSS = dtFiltered.Rows.Count;
                totalPagesPSS = (int)Math.Ceiling((double)totalRecordsPSS / pageSizePSS);

                LoadPagePSS();
                CreatePageButtonPSS();

                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading feedback grid: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetSrNo(DataTable table)
        {
            try
            {
                if (table == null) return;

                if (!table.Columns.Contains("SrNo"))
                    table.Columns.Add("SrNo", typeof(int));

                int sr = 1;
                foreach (DataRow row in table.Rows)
                    row["SrNo"] = sr++;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting SrNo: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void FilterGridByDatePSS()
        {
            try
            {
                if (dt1 == null || dt1.Rows.Count == 0)
                {
                    dtFiltered = dt1?.Clone();
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    return;
                }

                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date.AddDays(1).AddSeconds(-1);

                string dateColumn = "Feedback Date";

                var rows = dt1.AsEnumerable()
                              .Where(r => Convert.ToDateTime(r[dateColumn]) >= fromDate &&
                                          Convert.ToDateTime(r[dateColumn]) <= toDate)
                              .ToList();

                dtFiltered = rows.Count > 0 ? rows.CopyToDataTable() : dt1.Clone();

                ResetSrNo(dtFiltered);

                isDateFilterActive = true;

                currentPagePSS = 1;
                LoadPagePSS();
                CreatePageButtonPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filtering grid: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmFeedback_Load(object sender, EventArgs e)
        {
            try
            {
                this.grdFeedback.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                this.grdFeedback.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdFeedback.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdFeedback.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdFeedback.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdFeedback.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdFeedback.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdFeedback.GridColor = System.Drawing.Color.Gray;

                AddActionColumnPSS();
                LoadGridPSS();
                AddHeaderCheckBoxPSS();

                grdFeedback.Columns["Guest Name"].ReadOnly = true;
                grdFeedback.Columns["Overall Rating"].ReadOnly = true;
                grdFeedback.Columns["Feedback Date"].ReadOnly = true;
                grdFeedback.Columns["Description"].ReadOnly = true;
                grdFeedback.Columns["SrNo"].ReadOnly = true;

                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;

                dtpFromDate.ValueChanged += dtpFromDate_ValueChanged;
                dtpToDate.ValueChanged += dtpToDate_ValueChanged;

                grdFeedback.EditMode = DataGridViewEditMode.EditOnEnter;

                grdFeedback.CurrentCellDirtyStateChanged += (s, ev) =>
                {
                    if (grdFeedback.IsCurrentCellDirty)
                        grdFeedback.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };

                if (grdFeedback.Columns.Contains("GuestCode"))
                    grdFeedback.Columns["GuestCode"].Visible = false;

                grdFeedback.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdFeedback.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdFeedback.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdFeedback.GridColor = System.Drawing.Color.Gray;

                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "dd/MM/yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "dd/MM/yyyy";

                dtpToDate.MinDate = dtpFromDate.Value;

                grdFeedback.CellValueChanged += grdFeedback_CellValueChanged;

                isDateFilterActive = false;
                pnlFilter.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing feedback form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value;
                FilterGridByDatePSS();
                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on From Date change: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value;

                if (dtpToDate.Value < dtpFromDate.Value)
                    dtpToDate.Value = dtpFromDate.Value;

                FilterGridByDatePSS();
                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on To Date change: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPagePSS > 1)
                {
                    currentPagePSS--;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error going to previous page: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPagePSS < totalPagesPSS)
                {
                    currentPagePSS++;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error going to next page: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFeedback_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                grdFeedback.Columns["check"].ReadOnly = false;

                if (e.RowIndex >= 0 && grdFeedback.Columns[e.ColumnIndex].Name == "imgView")
                {
                    if (e.RowIndex < 0) return;

                    DataRow selectedRow = ((DataRowView)grdFeedback.Rows[e.RowIndex].DataBoundItem).Row;
                    code = selectedRow["GuestCode"].ToString();

                    frmViewFeedback f = new frmViewFeedback(code);
                    f.Show();
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == grdFeedback.Columns["check"].Index)
                {
                    if (!isHeaderCheckBoxClicked)
                    {
                        bool allChecked = true;

                        foreach (DataGridViewRow row1 in grdFeedback.Rows)
                        {
                            if (Convert.ToBoolean(row1.Cells["check"].Value) == false)
                            {
                                allChecked = false;
                                break;
                            }
                        }

                        headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                        headerCheckBox.Checked = allChecked;
                        headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
                    }
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == grdFeedback.Columns["check"].Index)
                    grdFeedback.Rows[e.RowIndex].Selected = true;

                grdFeedback.Columns["Guest Name"].ReadOnly = true;
                grdFeedback.Columns["Overall Rating"].ReadOnly = true;
                grdFeedback.Columns["Feedback Date"].ReadOnly = true;
                grdFeedback.Columns["Description"].ReadOnly = true;
                grdFeedback.Columns["SrNo"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error on cell click: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFeedback_CellPainting(object sender, DataGridViewCellPaintingEventArgs e) { }

        private void btnAddFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddFeedback objfrmU = new frmAddFeedback();
                objfrmU.MdiParent = this.MdiParent;
                objfrmU.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Add Feedback form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error toggling filter panel: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportCheckedRowsToPDF(DataGridView grid)
        {
            try
            {
                if (grid == null)
                {
                    MessageBox.Show("No grid found.");
                    return;
                }

                grid.EndEdit();

                var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    "check", "imgEdit", "imgView", "Action", "SrNo"
                };

                var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (exportColumns.Count == 0)
                {
                    MessageBox.Show("No columns available for export.");
                    return;
                }

                List<DataRow> rowsToExport = new List<DataRow>();

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
                        MessageBox.Show("Please select at least one row.");
                        return;
                    }
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF Files (*.pdf)|*.pdf";
                sfd.FileName = "GuestDetails_Report.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                iTextSharp.text.Document pdfDoc =
                    new iTextSharp.text.Document(
                        iTextSharp.text.PageSize.A4.Rotate(), 20f, 20f, 20f, 20f);

                PdfWriter.GetInstance(pdfDoc, new FileStream(sfd.FileName, FileMode.Create));
                pdfDoc.Open();

                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(
                    new Phrase("Feedback Report",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16)))
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                headerTable.AddCell(titleCell);

                PdfPCell generatedCell = new PdfPCell(
                    new Phrase("Generated On : " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"),
                        FontFactory.GetFont(FontFactory.HELVETICA, 10)))
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_RIGHT
                };
                headerTable.AddCell(generatedCell);

                if (isDateFilterActive)
                {
                    string filterText = "Filter Date : "
                        + dtpFromDate.Value.ToString("dd/MM/yyyy")
                        + " To "
                        + dtpToDate.Value.ToString("dd/MM/yyyy");

                    PdfPCell filterCell = new PdfPCell(
                        new Phrase(filterText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    {
                        Border = PdfPCell.NO_BORDER,
                        HorizontalAlignment = Element.ALIGN_LEFT
                    };
                    headerTable.AddCell(filterCell);
                }

                headerTable.SpacingAfter = 15f;
                pdfDoc.Add(headerTable);

                PdfPTable table = new PdfPTable(exportColumns.Count + 1);
                table.WidthPercentage = 100;

                float[] widths = new float[exportColumns.Count + 1];
                widths[0] = 8f;
                for (int i = 1; i < widths.Length; i++)
                    widths[i] = 18f;
                table.SetWidths(widths);

                PdfPCell srHeader = new PdfPCell(
                    new Phrase("SrNo", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                {
                    BackgroundColor = BaseColor.LIGHT_GRAY,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                table.AddCell(srHeader);

                foreach (DataGridViewColumn col in exportColumns)
                {
                    PdfPCell headerCell = new PdfPCell(
                        new Phrase(col.HeaderText, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10)))
                    {
                        BackgroundColor = BaseColor.LIGHT_GRAY,
                        HorizontalAlignment = Element.ALIGN_CENTER
                    };
                    table.AddCell(headerCell);
                }

                int srNo = 1;
                foreach (DataRow row in rowsToExport)
                {
                    table.AddCell(new PdfPCell(
                        new Phrase(srNo.ToString(), FontFactory.GetFont(FontFactory.HELVETICA, 9)))
                    {
                        HorizontalAlignment = Element.ALIGN_CENTER
                    });

                    foreach (DataGridViewColumn col in exportColumns)
                    {
                        object value = DBNull.Value;

                        if (!string.IsNullOrEmpty(col.DataPropertyName)
                            && row.Table.Columns.Contains(col.DataPropertyName))
                            value = row[col.DataPropertyName];
                        else if (row.Table.Columns.Contains(col.Name))
                            value = row[col.Name];

                        string text = "";
                        if (value != DBNull.Value && value != null)
                        {
                            if (value is DateTime)
                                text = Convert.ToDateTime(value).ToString("dd/MM/yyyy");
                            else
                                text = value.ToString();
                        }

                        table.AddCell(new PdfPCell(
                            new Phrase(text, FontFactory.GetFont(FontFactory.HELVETICA, 9)))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER
                        });
                    }

                    srNo++;
                }

                pdfDoc.Add(table);
                pdfDoc.Close();

                MessageBox.Show("PDF generated successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDF(grdFeedback);
        }

        private void ExportCheckedRowsToExcel(DataGridView grid)
        {
            try
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

                if (exportColumns.Count == 0)
                {
                    MessageBox.Show("No exportable columns found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    // Only export rows checked on the current visible page
                    rowsToExport = grid.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow
                                 && r.Cells["check"].Value != null
                                 && Convert.ToBoolean(r.Cells["check"].Value))
                        .Select(r => ((DataRowView)r.DataBoundItem).Row)
                        .ToList();

                    if (rowsToExport.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row to export.", "No Selection",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "FeedbackDetails.xlsx";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Feedback Details");

                            int totalCols = exportColumns.Count + 1; // +1 for SrNo

                            // ── Row 1 : Title ──────────────────────────────────────────
                            ws.Cell(1, 1).Value = "Feedback Details";
                            ws.Range(1, 1, 1, totalCols).Merge();
                            ws.Row(1).Style
                                .Font.SetBold(true)
                                .Font.SetFontSize(16)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Row(1).Height = 28;

                            // ── Row 2 : Filter info (left) + Generated On (right) ──────
                            string filterText = isDateFilterActive
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
                            int currentRow = headerRow;
                            int currentCol = 1;

                            ws.Cell(currentRow, currentCol).Value = "SrNo";
                            ws.Cell(currentRow, currentCol).Style
                                .Font.SetBold(true)
                                .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            currentCol++;

                            foreach (var col in exportColumns)
                            {
                                ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                                ws.Cell(currentRow, currentCol).Style
                                    .Font.SetBold(true)
                                    .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                currentCol++;
                            }

                            ws.Row(headerRow).Height = 22;

                            // ── Rows 5+ : Data (reads from DataRow, works across all pages) ──
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
                                    // Read from DataRow directly — not from grid cell
                                    // so pagination doesn't affect the export
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

                            // ── Auto-fit + fix SrNo width ──────────────────────────────
                            ws.Columns().AdjustToContents();
                            ws.Column(1).Width = 8;

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show(
                            "Excel file generated successfully!\nTotal rows exported: " + rowsToExport.Count,
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
                MessageBox.Show("Excel Export Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcel(grdFeedback);
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                grdFeedback.EndEdit();

                var selectedRows = grdFeedback.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["check"].Value) == true)
                    .ToList();

                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to delete.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Are you sure you want to delete selected feedback?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                foreach (var row in selectedRows)
                {
                    int id = Convert.ToInt32(row.Cells["FeedbackID"].Value);
                    clsUser obj = new clsUser();
                    obj.FidPSS = id;
                    obj.DeleteFeedbackPSS();
                }

                MessageBox.Show("Selected feedback deleted successfully.", "Deleted",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGridPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting feedback: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                currentPagePSS = 1;
                dtFiltered = null;
                isDateFilterActive = false;

                LoadGridPSS();

                if (grdFeedback.Columns.Contains("FeedbackID"))
                    grdFeedback.Columns["FeedbackID"].Visible = false;

                grdFeedback.Columns["SrNo"].DisplayIndex = 1;
                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;

                txtSearchBox.Clear();
                //pnlFilter.Visible = false;
                pnlFilter.BringToFront();
                pnlFilter.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing feedback grid: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dtFiltered = null;
                    currentPagePSS = 1;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    return;
                }

                string[] words = searchText.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                bool hasAlphabet = words.Any(w => w.Any(char.IsLetter));

                if (!hasAlphabet)
                {
                    dtFiltered = null;
                    currentPagePSS = 1;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    return;
                }

                searchText = searchText.Replace("'", "''");

                StringBuilder filter = new StringBuilder();

                foreach (DataColumn col in dt1.Columns)
                {
                    string colName = col.ColumnName.ToLower();

                    if (colName == "check" ||
                        colName.Contains("id") ||
                        colName == "imgview" ||
                        colName == "imgedit" ||
                        colName == "srno")
                        continue;

                    if (col.DataType == typeof(string))
                        filter.Append($"[{col.ColumnName}] LIKE '%{searchText}%' OR ");
                }

                if (filter.Length > 4)
                    filter.Length -= 4;

                DataView dv = new DataView(dt1);
                dv.RowFilter = filter.ToString();
                dtFiltered = dv.ToTable();

                if (!dtFiltered.Columns.Contains("SrNo"))
                    dtFiltered.Columns.Add("SrNo", typeof(int));

                int sr = 1;
                foreach (DataRow row in dtFiltered.Rows)
                    row["SrNo"] = sr++;

                currentPagePSS = 1;
                LoadPagePSS();
                CreatePageButtonPSS();

                grdFeedback.Columns["imgView"].DisplayIndex = grdFeedback.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdFeedback_CurrentCellDirtyStateChanged(object sender, EventArgs e) { }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddFeedback frm = new frmAddFeedback();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Add Feedback form: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e) { }
        private void pnlPages_Paint(object sender, PaintEventArgs e) { }
    }
}