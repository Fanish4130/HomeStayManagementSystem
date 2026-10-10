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
using System.Management.Instrumentation;

namespace GSTHMS
{
    public partial class frmStaffReport : Form
    {
        int pagesizeAP = 10;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;
        DateTime defaultFromDate;
        DateTime defaultToDate;
        DataTable dtAttend;
        public frmStaffReport()
        {
            InitializeComponent();
        }

        private void grdStaffReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private CheckBox HederCheckboxAP;
        private void frmStaffReport_Load(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.StaffAP();
            dtAttend = obj.staffattendAP();
            fulldataAP = obj.StaffAP();
           filteredAP = obj.StaffAP();

            defaultFromDate = dtpFrom.Value.Date;
            defaultToDate = dtpTo.Value.Date;
            if (dt != null && dt.Rows.Count > 0)
            {

                grdStaffReport.DataSource = dt;
                GenerateChartFromGridAP();
                GeneratePieFromGridAP();
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
            grdStaffReport.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdStaffReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdStaffReport.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdStaffReport.GridColor = System.Drawing.Color.Gray;

            this.grdStaffReport.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdStaffReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            //guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");
        }
        private void DisplayPageAP(int page)
        {
            DataTable source = filteredAP; // always use filtered or full

            int start = (page - 1) * pagesizeAP;
            int end = Math.Min(start + pagesizeAP, source.Rows.Count);

            DataTable dt = source.Clone();

            for (int i = start; i < end; i++)
                dt.ImportRow(source.Rows[i]);

            grdStaffReport.DataSource = dt;
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

        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdStaffReport.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdStaffReport.AllowUserToAddRows = false;
            grdStaffReport.ReadOnly = false;
            grdStaffReport.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdStaffReport.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;

            Rectangle rect = grdStaffReport.GetCellDisplayRectangle(0, -1, true);
            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdStaffReport.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdStaffReport.EndEdit();
                grdStaffReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdStaffReport.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }
                }

                grdStaffReport.RefreshEdit();
            };

            grdStaffReport.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdStaffReport.CurrentCell is DataGridViewCheckBoxCell)
                    grdStaffReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }


      

private void GenerateChartFromGridAP()
        {
            ChartStaff.Series.Clear();
            ChartStaff.Titles.Clear();
            ChartStaff.ChartAreas.Clear();
            ChartStaff.Legends.Clear();

            // ===== Chart Area (Clean HR Dashboard Look) =====
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            area.AxisX.Interval = 1;

            // Axis lines
            area.AxisX.LineWidth = 1;
            area.AxisY.LineWidth = 1;
            area.AxisX.LineColor = Color.Gainsboro;
            area.AxisY.LineColor = Color.Gainsboro;

            // Axis labels
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
            area.AxisX.LabelStyle.Angle = -30;
            area.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);
            area.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);

            // Remove grid
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;

            // Remove ticks
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisY.MajorTickMark.Enabled = false;

            ChartStaff.ChartAreas.Add(area);

            // ===== Title =====
            Title title = new Title(
                "Staff Count by Position",
                Docking.Top,
                new Font("Segoe UI Semibold", 13),
                Color.FromArgb(45, 45, 45));

            ChartStaff.Titles.Add(title);

            // ===== Series =====
            Series series = new Series("Staff Count");
            series.ChartType = SeriesChartType.Doughnut;

            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            series.LabelForeColor = Color.Black;

            // Keep your existing property
            series.CustomProperties = "PointWidth=0.5";

            series.Color = Color.FromArgb(150, 180, 220);

            // ===== Count staff by position =====
            Dictionary<string, int> count = new Dictionary<string, int>();

            foreach (DataRow row in fulldataAP.Rows)
            {
                string position = row["PositionName"]?.ToString()?.Trim();

                if (!string.IsNullOrEmpty(position))
                {
                    if (count.ContainsKey(position))
                        count[position]++;
                    else
                        count[position] = 1;
                }
            }

            // ===== Add Points =====
            foreach (var item in count)
            {
                int idx = series.Points.AddY(item.Value);

                // DON'T REMOVE (Click event depends on this)
                series.Points[idx].AxisLabel = item.Key;

                // Added only label
                series.Points[idx].Label = item.Key + "\n" + item.Value.ToString();

                // Existing tooltip
                series.Points[idx].ToolTip =
                    $"Position : {item.Key}\nStaff Count : {item.Value}";
            }

            ChartStaff.Series.Add(series);

            ChartStaff.Invalidate();
        }


        private void GeneratePieFromGridAP()
        {
            // ===== CLEAR OLD DATA =====
            pieStaffReport.Series.Clear();
            pieStaffReport.ChartAreas.Clear();
            pieStaffReport.Titles.Clear();
            pieStaffReport.Legends.Clear();

            // ===== CHECK DATA =====
            if (dtAttend == null || dtAttend.Rows.Count == 0)
            {
                MessageBox.Show("No attendance data found!");
                return;
            }

            // ===== CHART AREA =====
            ChartArea area = new ChartArea("MainArea");

            area.BackColor = Color.White;

            // X Axis
            area.AxisX.Title = "Staff Name";
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);

            // Y Axis
            area.AxisY.Title = "Present Days Count";
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

            // Grid Style
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Remove Tick Marks
            area.AxisX.MajorTickMark.Enabled = false;
            area.AxisY.MajorTickMark.Enabled = false;

            pieStaffReport.ChartAreas.Add(area);

            // ===== TITLE =====
            Title title = new Title();
            title.Text = "Staff Present Attendance Year Wise";
            title.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            title.ForeColor = Color.Black;

            pieStaffReport.Titles.Add(title);

            // ===== DISTINCT YEARS =====
            var years = dtAttend.AsEnumerable()
                .Select(r => Convert.ToInt32(r["Year"]))
                .Distinct()
                .OrderBy(y => y)
                .ToList();

            // ===== DISTINCT STAFF =====
            var staffList = dtAttend.AsEnumerable()
                .Select(r => r["StaffName"].ToString())
                .Distinct()
                .ToList();

            // ===== CREATE SERIES YEAR WISE =====
            Dictionary<int, Series> seriesDict =
                new Dictionary<int, Series>();

            foreach (int year in years)
            {
                Series s = new Series(year.ToString());

                // COLUMN BAR GRAPH
                s.ChartType = SeriesChartType.Column;

                // Show Values
                s.IsValueShownAsLabel = true;

                // Label Font
                s.Font = new Font("Segoe UI", 8, FontStyle.Bold);

                // Bar Width
                s["PointWidth"] = "0.6";

                // Tooltip
                s.ToolTip = "#VALX : #VAL Present Days";

                // Border
                s.BorderWidth = 1;

                // Different Colors Per Year
                if (year % 4 == 0)
                    s.Color = Color.SteelBlue;
                else if (year % 4 == 1)
                    s.Color = Color.SeaGreen;
                else if (year % 4 == 2)
                    s.Color = Color.Orange;
                else
                    s.Color = Color.IndianRed;

                seriesDict.Add(year, s);

                pieStaffReport.Series.Add(s);
            }

            // ===== GROUP DATA =====
            var grouped = dtAttend.AsEnumerable()
                .GroupBy(r => new
                {
                    Staff = r["StaffName"].ToString(),
                    Year = Convert.ToInt32(r["Year"])
                })
                .Select(g => new
                {
                    Staff = g.Key.Staff,
                    Year = g.Key.Year,

                    // ONLY PRESENT COUNT
                    TotalPresent = g.Sum(x =>
                        Convert.ToInt32(x["Present_Count"]))
                });

            // ===== ADD DATA =====
            foreach (string staff in staffList)
            {
                foreach (int year in years)
                {
                    var record = grouped.FirstOrDefault(x =>
                        x.Staff == staff &&
                        x.Year == year);

                    int value = record != null
                        ? record.TotalPresent
                        : 0;

                    seriesDict[year].Points.AddXY(staff, value);
                }
            }

            // ===== LEGEND =====
            Legend legend = new Legend();

            legend.Docking = Docking.Top;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Segoe UI", 9);

            pieStaffReport.Legends.Add(legend);

            // ===== REFRESH =====
            pieStaffReport.Invalidate();
        }
        private void ChartStaff_Click(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentpageAP < Math.Ceiling((double)totalrecordsAP / pagesizeAP))
            {
                currentpageAP++;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();


            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentpageAP > 1)
            {
                currentpageAP--;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();  
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
            DataTable dt = new DataTable();

            // Columns you want to export in order
            string[] allowedColumns =
            {
        "StaffCode",
        "StaffName",
        "Gender",
        "ContactNo",
        "Email",
        "CityName",
        "Address",
        "Pincode",
        "JoinDate",
        "PositionName",
        "Bloodgroup"
    };

            // Create DataTable columns
            foreach (string col in allowedColumns)
                dt.Columns.Add(col);

            if (grdStaffReport.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least one row!", "Warning");
                return dt;
            }

            grdStaffReport.EndEdit();

            // Add selected rows
            foreach (DataGridViewRow row in grdStaffReport.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dt.NewRow();
                    int i = 0;

                    foreach (string col in allowedColumns)
                    {
                        string val = row.Cells[col].Value?.ToString() ?? "";

                        // Convert JoinDate to DATE ONLY
                        if (col == "JoinDate")
                        {
                            if (DateTime.TryParse(val, out DateTime dtJoin))
                                val = dtJoin.ToString("dd-MM-yyyy");
                        }

                        dr[i++] = val;
                    }

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        public void ExportToExcelAP()
        {
            DataTable dt = GetSelectedRowsAP();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row!", "Warning");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "StaffReport.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Staff Report");

                // Title
                ws.Cell(1, 1).Value = "Staff Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 18;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                // Date
                ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                // Add SrNo + Data
                DataTable dtExcel = new DataTable();
                dtExcel.Columns.Add("SrNo");

                foreach (DataColumn col in dt.Columns)
                    dtExcel.Columns.Add(col.ColumnName);

                int sr = 1;
                foreach (DataRow r in dt.Rows)
                {
                    DataRow nr = dtExcel.NewRow();
                    nr[0] = sr++;

                    for (int i = 0; i < dt.Columns.Count; i++)
                        nr[i + 1] = r[i];

                    dtExcel.Rows.Add(nr);
                }

                // Insert
                ws.Cell(4, 1).InsertTable(dtExcel);

                // Style header
                var header = ws.Range(4, 1, 4, dtExcel.Columns.Count);
                header.Style.Font.Bold = true;
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Auto size
                ws.Columns().AdjustToContents();

                wb.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Excel Exported Successfully!", "Success");
        }

        public void ConvertToPDFAP()
        {
            DataTable dt = GetSelectedRowsAP();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row!", "Warning");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF Files|*.pdf";
            sfd.FileName = "StaffReport.pdf";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            doc.Open();

            // Title
            Paragraph title = new Paragraph("Staff Report",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            doc.Add(title);

            // Date
            Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 15;
            doc.Add(date);

            // Table + SrNo
            PdfPTable table = new PdfPTable(dt.Columns.Count + 1);
            table.WidthPercentage = 100;

            // SrNo header
            PdfPCell srHead = new PdfPCell(new Phrase("SrNo",
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
            srHead.BackgroundColor = new BaseColor(220, 220, 220);
            srHead.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(srHead);

            // Other headers
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell h = new PdfPCell(new Phrase(col.ColumnName,
                    FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                h.BackgroundColor = new BaseColor(220, 220, 220);
                h.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(h);
            }

            // Data
            int sr = 1;
            foreach (DataRow row in dt.Rows)
            {
                // SrNo
                table.AddCell(sr.ToString());
                sr++;

                // Row values
                foreach (var val in row.ItemArray)
                    table.AddCell(val.ToString());
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF Saved Successfully!", "Success");
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdStaffReport.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdStaffReport.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdStaffReport.Rows.RemoveAt(i);
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

            DataTable dt = obj.StaffAP();
            dtAttend = obj.staffattendAP();

            fulldataAP = dt.Copy();
            filteredAP = dt.Copy();

            totalrecordsAP = filteredAP.Rows.Count;
            currentpageAP = 1;

            // Clear search first
            txtSearchBox.Clear();

            // Hide filter panel
            pnlSearch.Visible = false;

            // Display first page
            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();

            // Refresh charts
            GenerateChartFromGridAP();
            GeneratePieFromGridAP();
        }





        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;  // Toggle once

            if (pnlSearch.Visible)
            {
                pnlSearch.BringToFront();
            }
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

            // Create copy object
            clsUser copyObj = new clsUser(originalObj);

            // Get filtered data
            DataTable dt = copyObj.StaffSerchAP();

            fulldataAP = dt;
            filteredAP = dt;

            if (dt != null && dt.Rows.Count > 0)
            {
                // Pagination
                totalrecordsAP = fulldataAP.Rows.Count;
                currentpageAP = 1;

                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

                // Charts
                GenerateChartFromGridAP();
                GeneratePieFromGridAP();
            }
            else
            {
                grdStaffReport.DataSource = null;

                ChartStaff.Series.Clear();
                ChartStaff.Titles.Clear();

                pieStaffReport.Series.Clear();
                pieStaffReport.Titles.Clear();

                MessageBox.Show(
                    "No records found in this date range.",
                    "Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }

        private void ChartStaff_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = ChartStaff.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                string position =
                    ChartStaff.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        position,
                        "STAFF_POSITION",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(position, "STAFF_POSITION");
                }

                frm.ShowDialog();
            }

        }

        private void pieStaffReport_Click(object sender, EventArgs e)
        {

        }
    }
}
