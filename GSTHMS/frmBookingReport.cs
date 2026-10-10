using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CheckBox = System.Windows.Forms.CheckBox;
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;


namespace GSTHMS
{
    public partial class frmBookingReport : Form
    {
        int pagesizeAP = 10;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;
        DateTime defaultFromDate;
        DateTime defaultToDate;
        public frmBookingReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private bool isDateFilterApplied = false;
        private void BookingReport_Load(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.BookingAP();
            fulldataAP = obj.BookingAP();
            filteredAP = fulldataAP.Copy();

            if (dt != null && dt.Rows.Count > 0)
            {

                grdBooking.DataSource = dt;
                GenerateChartFromGridAP();
                GeneratePieChartAP();

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

            // grdBooking.Columns["Check"].DisplayIndex = grdBooking.Columns.Count - 7;
            grdBooking.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdBooking.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdBooking.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdBooking.GridColor = System.Drawing.Color.Gray;

            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
           // guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");


            this.grdBooking.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdBooking.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            //grdBooking.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
            //grdBooking.RowsDefaultCellStyle.BackColor = Color.Silver;
       
        }
        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdBooking.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdBooking.AllowUserToAddRows = false;
            grdBooking.ReadOnly = false;
            grdBooking.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdBooking.Columns)
            {
                col.ReadOnly = col.Index != 0;

            }
            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;
            Rectangle rect = grdBooking.GetCellDisplayRectangle(0, -1, true);

            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdBooking.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdBooking.EndEdit();
                grdBooking.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdBooking.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }

                }
                grdBooking.RefreshEdit();
            };
            grdBooking.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdBooking.CurrentCell is DataGridViewCheckBoxCell)
                    grdBooking.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            grdBooking.DataSource = dt;
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
            Chart1.Series.Clear();
            Chart1.Titles.Clear();

            var chartArea = Chart1.ChartAreas[0];
            chartArea.BackColor = Color.White;

            chartArea.Position = new ElementPosition(5, 10, 90, 80);
            chartArea.InnerPlotPosition = new ElementPosition(12, 15, 75, 65);

            Chart1.Titles.Add(new Title(
                "2026 Month-wise Guest Check-ins",
                Docking.Top,
                new Font("Segoe UI", 11, FontStyle.Bold),
                Color.Black));

            Series series = new Series("Check-ins (2026)");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;

            Color barColor = Color.FromArgb(79, 129, 189);
            series.Color = barColor;

            Dictionary<int, int> monthCounts = new Dictionary<int, int>();

            foreach (DataRow row in fulldataAP.Rows)
            {
                if (row["Checkin"] != DBNull.Value &&
                    DateTime.TryParse(row["Checkin"].ToString(), out DateTime checkIn))
                {
                    if (checkIn.Year == 2026)   // ✅ CHANGE
                    {
                        int month = checkIn.Month;

                        if (monthCounts.ContainsKey(month))
                            monthCounts[month]++;
                        else
                            monthCounts[month] = 1;
                    }
                }
            }

            for (int m = 1; m <= 12; m++)
            {
                int count = monthCounts.ContainsKey(m) ? monthCounts[m] : 0;
                string monthName = new DateTime(2026, m, 1).ToString("MMM");

                int idx = series.Points.AddXY(monthName, count);

                series.Points[idx].Tag = new DateTime(2026, m, 1);
                series.Points[idx].Color = barColor;
                series.Points[idx].ToolTip = $"{monthName} 2026 : {count}";
            }

            Chart1.Series.Add(series);

            var axisX = chartArea.AxisX;
            axisX.Interval = 1;
            axisX.LabelStyle.Angle = -90;
            axisX.MajorGrid.Enabled = false;

            var axisY = chartArea.AxisY;
            axisY.MajorGrid.LineColor = Color.Gainsboro;
        }

        private void GeneratePieChartAP()
        {
            piebooking.Series.Clear();
            piebooking.ChartAreas.Clear();
            piebooking.Titles.Clear();
            piebooking.Legends.Clear();

            ChartArea ca = new ChartArea("MainArea");

            // Medium size (perfect fit)
            ca.Position = new ElementPosition(5, 10, 65, 75);
            ca.InnerPlotPosition = new ElementPosition(10, 10, 80, 80);

            ca.BackColor = Color.White;
            piebooking.ChartAreas.Add(ca);

            // 👉 Step 1: Month wise count
            Dictionary<string, int> monthCounts = new Dictionary<string, int>();

            foreach (DataRow row in fulldataAP.Rows)
            {
                if (row["Checkin"] != DBNull.Value &&
                    DateTime.TryParse(row["Checkin"].ToString(), out DateTime date))
                {
                    string month = date.ToString("MMM");

                    if (monthCounts.ContainsKey(month))
                        monthCounts[month]++;
                    else
                        monthCounts[month] = 1;
                }
            }

            if (monthCounts.Count == 0) return;

            // 👉 Step 2: Top 3 months
            var topMonths = monthCounts
                .OrderByDescending(x => x.Value)
                .Take(3)
                .ToList();

            int othersCount = monthCounts
                .Except(topMonths)
                .Sum(x => x.Value);

            int total = monthCounts.Values.Sum();

            Series s = new Series();
            s.ChartType = SeriesChartType.Doughnut;
            s.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            s.IsValueShownAsLabel = true;

            // 👉 Add Top 3 months
            int index = 0;
            foreach (var item in topMonths)
            {
                double percent = (item.Value * 100.0) / total;

                s.Points.AddXY(item.Key, item.Value);
                s.Points[index].Label = $"{item.Key}\n{percent:F1}%";

                index++;
            }

            // 👉 Add Others
            if (othersCount > 0)
            {
                double percent = (othersCount * 100.0) / total;

                s.Points.AddXY("Others", othersCount);
                s.Points[index].Label = $"Others\n{percent:F1}%";
            }

            // 🎨 Colors (clean theme)
            Color[] colors =
            {
        Color.SteelBlue,
        Color.MediumSeaGreen,
        Color.Orange,
        Color.Gray
    };

            for (int i = 0; i < s.Points.Count; i++)
            {
                s.Points[i].Color = colors[i % colors.Length];
                s.Points[i].BorderColor = Color.White;
                s.Points[i].BorderWidth = 2;
            }

            // UI Improvements
            s["DoughnutRadius"] = "40";
            s["PieLabelStyle"] = "Outside";

            piebooking.Series.Add(s);

            // 👉 Title (medium)
            Title t = new Title();
            t.Text = "Top Booking Months vs Others";
            t.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            t.Alignment = ContentAlignment.TopCenter;

            piebooking.Titles.Add(t);

            // 👉 Legend (right side)
            Legend legend = new Legend();
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 10);

            piebooking.Legends.Add(legend);
        }
        private void grdBooking_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Chart1_Click(object sender, EventArgs e)
        {


        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentpageAP < Math.Ceiling((double)totalrecordsAP / pagesizeAP))
            {
                currentpageAP++;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdBooking.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdBooking.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdBooking.Rows.RemoveAt(i);
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
            isDateFilterApplied = false;

            clsUser obj = new clsUser();
            DataTable dt = obj.BookingAP();

            fulldataAP = dt.Copy();
            filteredAP = dt.Copy();

            totalrecordsAP = filteredAP.Rows.Count;
            currentpageAP = 1;

            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();

            GenerateChartFromGridAP();
            GeneratePieChartAP();

            txtSearchBox.Clear();
            pnlSearch.Visible = false;
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

            if (grdBooking.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select AT Least 1 Row........!!!!");
                return dtSelected;
            }

            // Columns required in the export
                  string[] allowedColumns =
                   {
                        "GuestName",
                        "RoomName",
                        "Checkin",
                        "Checkout",
                        "No_of_Guest",
                        "Status"
                    };

            // Add columns
            foreach (string col in allowedColumns)
                dtSelected.Columns.Add(col);

            grdBooking.EndEdit();

            foreach (DataGridViewRow row in grdBooking.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dtSelected.NewRow();
                    int index = 0;

                    foreach (string col in allowedColumns)
                    {
                        string value = row.Cells[col].Value?.ToString() ?? "";

                        // 👉 Convert Checkin / Checkout to Only Date
                        if (col == "Checkin" || col == "Checkout")
                        {
                            if (DateTime.TryParse(value, out DateTime d))
                                value = d.ToString("dd-MM-yyyy");
                        }

                        dr[index++] = value;
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
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "BookingReport.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Booking Report");

                // Title
                ws.Cell(1, 1).Value = "Booking Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 18;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                // Generated Date
                ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                // Add SrNo manually
                DataTable dtExcel = new DataTable();
                dtExcel.Columns.Add("SrNo");

                foreach (DataColumn col in dt.Columns)
                    dtExcel.Columns.Add(col.ColumnName);

                int sr = 1;
                foreach (DataRow row in dt.Rows)
                {
                    DataRow newRow = dtExcel.NewRow();
                    newRow[0] = sr++;

                    for (int i = 0; i < dt.Columns.Count; i++)
                        newRow[i + 1] = row[i];

                    dtExcel.Rows.Add(newRow);
                }

                ws.Cell(4, 1).InsertTable(dtExcel);

                // Header Style
                var header = ws.Range(4, 1, 4, dtExcel.Columns.Count);
                header.Style.Font.Bold = true;
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                ws.Columns().AdjustToContents();

                workbook.SaveAs(sfd.FileName);
            }

            MessageBox.Show("Excel Exported Successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ConvertToPDFAP()
        {
            DataTable dt = GetSelectedRowsAP();

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = "BookingReport.pdf";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
            doc.Open();

            // Title
            Paragraph title = new Paragraph("Booking Report",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            doc.Add(title);

            // Date only
            Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 15;
            doc.Add(date);

            // Table
            PdfPTable table = new PdfPTable(dt.Columns.Count + 1);
            table.WidthPercentage = 100;

            // SrNo Header
            PdfPCell h1 = new PdfPCell(new Phrase("SrNo",
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
            h1.BackgroundColor = new BaseColor(220, 220, 220);
            h1.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(h1);

            // Other Headers
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell h = new PdfPCell(new Phrase(col.ColumnName,
                    FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                h.BackgroundColor = new BaseColor(220, 220, 220);
                h.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(h);
            }

            // Rows
            int sr = 1;
            foreach (DataRow row in dt.Rows)
            {
                table.AddCell(sr.ToString());
                sr++;

                foreach (var item in row.ItemArray)
                    table.AddCell(item.ToString());
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF File Saved Successfully!", "Success");
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

            isDateFilterApplied = true;

            clsUser originalObj = new clsUser();
            originalObj.fromdateAP = dtpFrom.Value.Date;
            originalObj.todateAP = dtpTo.Value.Date;

            // Step 2: Create new object using copy constructor
            clsUser copyObj = new clsUser(originalObj);

            // Step 3: Call PaymentSerchAP() on the copy
            DataTable dt = copyObj.BookingSearchAP();
            fulldataAP = dt;
            fulldataAP=fulldataAP.Copy();

            // Step 4: Update Grid + Charts
            if (dt != null && dt.Rows.Count > 0)
            {
                grdBooking.DataSource = dt;



                GenerateChartFromGridAP();
                GeneratePieChartAP();

                totalrecordsAP = fulldataAP.Rows.Count;
                currentpageAP = 1;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

            }
            else
            {
                grdBooking.DataSource = null;
                Chart1.Series.Clear();
                piebooking.Series.Clear();
                MessageBox.Show("No records found in this date range.");

            }

        }
        private void OpenYearInfo(string year)
        {
            frmInfoShow frm = new frmInfoShow(year, "YEAR");
            frm.Show();
        }
        private void piebooking_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult result = piebooking.HitTest(e.X, e.Y);

            //if (result.ChartElementType == ChartElementType.DataPoint)
            //{
            //    DataPoint point = piebooking.Series[0].Points[result.PointIndex];

            //    // Read year from Tag (SAFE)
            //    string year = point.Tag.ToString();

            //    OpenYearInfo(year);
            //}
        }

        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = Chart1.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                DateTime monthDate =
                    (DateTime)Chart1.Series[0].Points[index].Tag;

                frmInfoShow frm;

                if (isDateFilterApplied)
                {
                    frm = new frmInfoShow(
                        monthDate.Month.ToString(),
                        "BOOKING_MONTH",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(
                        monthDate.Month.ToString(),
                        "BOOKING_MONTH"
                    );
                }

                frm.ShowDialog();
            }
        
    }

        private void lblToDate_Click(object sender, EventArgs e)
        {

        }
    }
}
