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
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using CheckBox = System.Windows.Forms.CheckBox;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;


namespace GSTHMS
{
    public partial class frmEventReport : Form
    {
        int pagesizeAP = 10;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;
        private DateTime defaultFromDate;
        private DateTime defaultToDate;
        public frmEventReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private void EventReport_Load(object sender, EventArgs e)
        {

            clsUser obj = new clsUser();
            DataTable dt = obj.EventAP();
            fulldataAP = obj.EventAP();
            filteredAP = obj.EventAP();

            defaultFromDate = dtpFrom.Value.Date;
            defaultToDate = dtpTo.Value.Date;
            if (dt != null && dt.Rows.Count > 0)
            {

                grdEvent.DataSource = dt;
                GenerateChartFromGridAP();
                GenerateEventPieChartAP();

                MakeOnlyCheckBoxEditableAP();
            }

            if (fulldataAP != null && fulldataAP.Rows.Count > 0)
            {

                totalrecordsAP = fulldataAP.Rows.Count;

                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

            }
            else
            {
                MessageBox.Show("No orders found.");
            }
            grdEvent.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdEvent.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdEvent.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdEvent.GridColor = System.Drawing.Color.Gray;

            this.grdEvent.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdEvent.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
           // guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");
        }
        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdEvent.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdEvent.AllowUserToAddRows = false;
            grdEvent.ReadOnly = false;
            grdEvent.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdEvent.Columns)
            {
                col.ReadOnly = col.Index != 0;

            }
            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;
            Rectangle rect = grdEvent.GetCellDisplayRectangle(0, -1, true);

            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdEvent.Controls.Add(HederCheckboxAP);

              HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdEvent.EndEdit();
                grdEvent.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdEvent.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }

                }
                grdEvent.RefreshEdit();
            };
            grdEvent.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdEvent.CurrentCell is DataGridViewCheckBoxCell)
                    grdEvent.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }
        private void DisplayPageAP(int page)
        {
            DataTable source = filteredAP; // always use filtered or full

            int start = (page - 1) * pagesizeAP;
            int end = Math.Min(start + pagesizeAP, source.Rows.Count);

            DataTable dt = source.Clone();

            for (int i = start; i < end; i++)
                dt.ImportRow(source.Rows[i]);

            grdEvent.DataSource = dt;
        }

        private void GeneratePageButtonsAP()
        {
            pnlFlowPages.Controls.Clear();

            int totalPages = (int)Math.Ceiling((double)totalrecordsAP / pagesizeAP);

            for (int i = 1; i <= totalPages; i++)
            {
                CheckBox chk = new CheckBox();
                chk.Text = i.ToString();
                chk.Appearance = Appearance.Button;
                chk.Width = 40;
                chk.Height = 32;
                chk.TextAlign = ContentAlignment.MiddleCenter;
                chk.Tag = i;

                // --- Default style (white button) ---
                chk.BackColor = Color.White;
                chk.ForeColor = Color.Black;
                chk.FlatStyle = FlatStyle.Flat;
                chk.FlatAppearance.BorderSize = 1;
                chk.FlatAppearance.BorderColor = Color.White;

                // --- Active Page style (like your image - sky blue) ---
                if (i == currentpageAP)
                {
                    chk.BackColor = Color.Silver;  // Sky blue
                    chk.ForeColor = Color.White;
                    chk.FlatAppearance.BorderColor = Color.Silver;
                }


                chk.CheckedChanged += (s, e) =>
                {
                    if (((CheckBox)s).Checked)
                    {
                        currentpageAP = (int)((CheckBox)s).Tag;
                        DisplayPageAP(currentpageAP);
                        GeneratePageButtonsAP();  // Refresh buttons
                    }
                };

                pnlFlowPages.Controls.Add(chk);
                btnPrevious.Enabled = currentpageAP > 1;
                btnNext.Enabled = currentpageAP < totalPages;
            }
        }

        private void GenerateChartFromGridAP()
        {
            barEvent.Series.Clear();
            barEvent.Titles.Clear();
            barEvent.ChartAreas.Clear();
            barEvent.Legends.Clear();

            // ---------------- Chart Area ----------------
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;

            // ❌ No gridlines
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            // ✅ Axis visible (clean)
            area.AxisX.LineWidth = 1;
            area.AxisY.LineWidth = 1;
            area.AxisX.LineColor = Color.Gainsboro;
            area.AxisY.LineColor = Color.Gainsboro;

            // ✅ Axis labels visible
            area.AxisX.LabelStyle.Enabled = true;
            area.AxisY.LabelStyle.Enabled = true;

            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(90, 90, 90);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(90, 90, 90);

            // ✅ Tick marks (subtle)
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisY.MajorTickMark.Enabled = true;
            area.AxisY.MajorTickMark.LineColor = Color.Gainsboro;

            // Spacing
            area.AxisX.Interval = 1;

            barEvent.ChartAreas.Add(area);

            // ---------------- Title (Like Pie Chart Heading) ----------------
            Title title = new Title(
                "Event Charges Overview",
                Docking.Top,
                new Font("Segoe UI Semibold", 14),
                Color.FromArgb(90, 90, 160)
            );

            barEvent.Titles.Add(title);

            // ---------------- Series ----------------
            Series series = new Series("Event Charges");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            series.LabelForeColor = Color.FromArgb(80, 80, 80);

            // Thin & spaced bars
            series.CustomProperties = "PointWidth=0.35";

            // ---------------- Fill Data ----------------
            foreach (DataGridViewRow row in grdEvent.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells[2].Value != null && row.Cells[6].Value != null)
                {
                    string eventName = row.Cells[2].Value.ToString();

                    if (decimal.TryParse(row.Cells[6].Value.ToString(), out decimal charges))
                    {
                        int idx = series.Points.AddXY(eventName, charges);
                        series.Points[idx].ToolTip =
                            $"Event : {eventName}\nCharges : ₹ {charges}";
                    }
                }
            }

            Color singleColor = Color.FromArgb(170, 200, 235);

            // ---------------- Faint Single Color Shading ----------------
            Color[] softFades =
            {
                    Color.FromArgb(220, 230, 245),
                    Color.FromArgb(195, 215, 240),
                    Color.FromArgb(170, 200, 235),
                    Color.FromArgb(145, 185, 225),
                    Color.FromArgb(120, 170, 215)
               };

            for (int i = 0; i < series.Points.Count; i++)
            {
                series.Points[i].Color = singleColor;
                series.Points[i].BorderWidth = 0;
            }

            barEvent.Series.Add(series);

            barEvent.Invalidate();
        }

        private void GenerateEventPieChartAP()
        {
            // Reset chart
            pieEvent.Series.Clear();
            pieEvent.Titles.Clear();
            pieEvent.ChartAreas.Clear();
            pieEvent.Legends.Clear();

            // Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            chartArea.Area3DStyle.Enable3D = false; // flat view for clarity
            chartArea.BackSecondaryColor = Color.WhiteSmoke;
            chartArea.BackGradientStyle = GradientStyle.TopBottom;
            pieEvent.ChartAreas.Add(chartArea);

            // Title
            Title title = new Title("Event Status Distribution", Docking.Top,
                new Font("Segoe UI", 13, FontStyle.Bold), Color.MediumSlateBlue);
            pieEvent.Titles.Add(title);

            // Series setup
            Series series = new Series("Event Status");
            series.ChartType = SeriesChartType.Pie;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            series.LabelForeColor = Color.Black;
            series["PieLabelStyle"] = "Outside";
            series["PieLineColor"] = "Gray";
            series.BorderColor = Color.White;
            series.BorderWidth = 2;

            // Collect data from grid (EventName & Status)
            Dictionary<string, string> eventStatus = new Dictionary<string, string>();
            Dictionary<string, int> statusCount = new Dictionary<string, int>();

            foreach (DataGridViewRow row in grdEvent.Rows)
            {
                if (row.IsNewRow) continue;

                string eventName = row.Cells["EventName"].Value?.ToString();
                string status = row.Cells["Status"].Value?.ToString();

                if (!string.IsNullOrEmpty(status))
                {
                    // Count each status (Closed, Open, etc.)
                    if (statusCount.ContainsKey(status))
                        statusCount[status]++;
                    else
                        statusCount[status] = 1;
                }
            }

            // Add data to series (Status vs Count)
            foreach (var kvp in statusCount)
            {
                int idx = series.Points.AddXY(kvp.Key, kvp.Value);

                series.Points[idx].ToolTip =
                    $"{kvp.Key}: {kvp.Value} Event(s)";

                series.Points[idx].Label =
                    $"{kvp.Key} ({kvp.Value})";

                // ✅ VERY IMPORTANT
                series.Points[idx].Tag = kvp.Key;
            }

            // Color Palette
            pieEvent.Palette = ChartColorPalette.SeaGreen;
            pieEvent.Series.Add(series);

            // Legend setup
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Segoe UI", 9);
            legend.BackColor = Color.WhiteSmoke;
            legend.BorderColor = Color.LightGray;
            legend.Title = "Event Status";
            legend.TitleFont = new Font("Segoe UI", 10, FontStyle.Bold);
            pieEvent.Legends.Add(legend);

            // Chart border
            pieEvent.BackColor = Color.White;
            pieEvent.BorderlineColor = Color.LightGray;
            pieEvent.BorderlineDashStyle = ChartDashStyle.Solid;
        }



        private void barEvent_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentpageAP < Math.Ceiling((double)totalrecordsAP / pagesizeAP))
            {
                currentpageAP++;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP(); // ✅ highlight update
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentpageAP > 1)
            {
                currentpageAP--;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP(); // ✅ highlight update
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ConvertToPDFAP();
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelAP();
        }
        public DataTable GetSelectedRowsAP()
        {
            DataTable dtSelected = new DataTable();

            if (grdEvent.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select AT Least 1 Row........!!!!");
                return dtSelected;
            }

            // Columns for Export (WITHOUT Grid SrNo)
            string[] allowedColumns =
            {
        "EventName",
        "Description",
        "StartDate",
        "EndDate",
        "Charges",
        "Status"
    };

            foreach (string col in allowedColumns)
                dtSelected.Columns.Add(col);

            grdEvent.EndEdit();

            foreach (DataGridViewRow row in grdEvent.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dtSelected.NewRow();
                    int index = 0;

                    foreach (string col in allowedColumns)
                    {
                        if (col == "StartDate" || col == "EndDate")
                        {
                            DateTime d;
                            if (DateTime.TryParse(row.Cells[col].Value?.ToString(), out d))
                                dr[index] = d.ToString("dd-MM-yyyy");   // ONLY DATE
                            else
                                dr[index] = "";
                        }
                        else
                        {
                            dr[index] = row.Cells[col].Value?.ToString() ?? "";
                        }

                        index++;
                    }

                    dtSelected.Rows.Add(dr);
                }
            }

            return dtSelected;
        }

        public void ExportToExcelAP()
        {
            DataTable dt = GetSelectedRowsAP();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!", "Warning");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "EventReport.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Event Report");

                // Header Text
                ws.Cell(1, 1).Value = "Event Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 18;
                ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                // Generated Date
                ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                // Add SrNo column
                DataTable finalDT = new DataTable();
                finalDT.Columns.Add("SrNo");

                foreach (DataColumn c in dt.Columns)
                    finalDT.Columns.Add(c.ColumnName);

                int sr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    DataRow nr = finalDT.NewRow();
                    nr[0] = sr++;
                    for (int i = 0; i < dt.Columns.Count; i++)
                        nr[i + 1] = r[i];
                    finalDT.Rows.Add(nr);
                }

                ws.Cell(4, 1).InsertTable(finalDT);
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Excel Export Successful!");
        }

        public void ConvertToPDFAP()
        {
            DataTable dtSelectedRowPDF = GetSelectedRowsAP();

            if (dtSelectedRowPDF == null || dtSelectedRowPDF.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (.pdf)|*.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "EventReport.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePath = saveFileDialog.FileName;

            Document doc = new Document(PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            // ----------------- Title/Header -----------------
            Paragraph title = new Paragraph("Event Report",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 5;
            doc.Add(title);

            // ----------------- Date -----------------
            Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 10;
            doc.Add(date);

            // ----------------- Table -----------------
            PdfPTable table = new PdfPTable(dtSelectedRowPDF.Columns.Count + 1); // +1 for SrNo
            table.WidthPercentage = 100;

            // SrNo Header
            PdfPCell srCell = new PdfPCell(new Phrase("SrNo",
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
            srCell.BackgroundColor = new BaseColor(240, 240, 240);
            srCell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(srCell);

            // Other Headers
            foreach (DataColumn column in dtSelectedRowPDF.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                    FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                cell.BackgroundColor = new BaseColor(240, 240, 240); // Light Gray
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Data Rows with SrNo
            int srNo = 1;
            foreach (DataRow row in dtSelectedRowPDF.Rows)
            {
                // SrNo
                PdfPCell srDataCell = new PdfPCell(new Phrase(srNo.ToString(),
                    FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
                srDataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(srDataCell);

                // Other cells
                foreach (var value in row.ItemArray)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(value.ToString(),
                        FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)));
                    cell.HorizontalAlignment = Element.ALIGN_LEFT;
                    table.AddCell(cell);
                }

                srNo++;
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF File Saved Successfully!\n" + filePath,
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdEvent.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdEvent.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdEvent.Rows.RemoveAt(i);
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

            if (fulldataAP == null || fulldataAP.Rows.Count == 0)
                return;

            string search = txtSearchBox.Text.Trim().ToLower();

            // BACKSPACE / SEARCH EMPTY → RESET GRID AUTOMATICALLY
            if (string.IsNullOrEmpty(search))
            {
                filteredAP = fulldataAP.Copy();   // restore original
                totalrecordsAP = filteredAP.Rows.Count;
                currentpageAP = 1;

                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();
                return;
            }

            // otherwise apply search
            filteredAP = fulldataAP.Clone();

            foreach (DataRow row in fulldataAP.Rows)
            {
                foreach (DataColumn col in fulldataAP.Columns)
                {
                    if (row[col].ToString().ToLower().Contains(search))
                    {
                        filteredAP.ImportRow(row);
                        break;
                    }
                }
            }

            totalrecordsAP = filteredAP.Rows.Count;
            currentpageAP = 1;

            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();
        }

private void pctRefresh_Click(object sender, EventArgs e)
{
    clsUser obj = new clsUser();

    DataTable dt = obj.EventAP();

    if (dt == null || dt.Rows.Count == 0)
    {
        grdEvent.DataSource = null;
        MessageBox.Show("No orders found.");
        return;
    }

    // Reload data
    fulldataAP = dt.Copy();
    filteredAP = dt.Copy();

    // Reset to first page
    currentpageAP = 1;
    totalrecordsAP = filteredAP.Rows.Count;

    // Display first page
    DisplayPageAP(currentpageAP);
    GeneratePageButtonsAP();

    // Refresh charts
    GenerateChartFromGridAP();
    GenerateEventPieChartAP();

    // Clear search and hide filter panel
    txtSearchBox.Clear();
    pnlSearch.Visible = false;
}

        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            SerchBYDateTimeAP();
        }
        public void SerchBYDateTimeAP()
        {
            clsUser originalObj = new clsUser();
            originalObj.fromdateAP = dtpFrom.Value.Date;
            originalObj.todateAP = dtpTo.Value.Date;

            // Step 2: Create new object using copy constructor
            clsUser copyObj = new clsUser(originalObj);

            // Step 3: Call PaymentSerchAP() on the copy
            DataTable dt = copyObj.EventSerchAP();
            fulldataAP = dt;

            // Step 4: Update Grid + Charts
            if (dt != null && dt.Rows.Count > 0)
            {
                fulldataAP = dt.Copy();      // full filtered data
                filteredAP = dt.Copy();      // for paging and search

                totalrecordsAP = filteredAP.Rows.Count;
                currentpageAP = 1;

                DisplayPageAP(currentpageAP);   // show first page
                GeneratePageButtonsAP();        // regenerate buttons

                GenerateChartFromGridAP();
                GenerateEventPieChartAP();
            }
            else
            {
                grdEvent.DataSource = null;
                barEvent.Series.Clear();
                pieEvent.Series.Clear();
                totalrecordsAP = 0;
                currentpageAP = 1;
                GeneratePageButtonsAP();
                MessageBox.Show("No records found in this date range.");
            }
        }

        private void grdEvent_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pieEvent_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = pieEvent.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint &&
                result.PointIndex >= 0)
            {
                DataPoint point = pieEvent.Series[0].Points[result.PointIndex];

                if (point.Tag == null) return;

                string status = point.Tag.ToString();

                frmInfoShow frm;

                // ✅ SAME LOGIC AS BOOKING REPORT
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        status,
                        "EVENT_STATUS",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(status, "EVENT_STATUS");
                }

                frm.ShowDialog();
            }

        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;  // Toggle once

            if (pnlSearch.Visible)
            {
                pnlSearch.BringToFront();
            }
        }
    }
}
