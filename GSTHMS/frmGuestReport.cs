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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClosedXML.Excel;
using iTextSharp.text.pdf;
using iTextSharp.text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using CheckBox = System.Windows.Forms.CheckBox;
using Rectangle = System.Drawing.Rectangle;
using Font = System.Drawing.Font;


namespace GSTHMS
{
    public partial class frmGuestReport : Form
    {
        int pagesizeAP = 10;  //for  show how many Recors we display in one page
        int currentpageAP = 1; //show what is the current page
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable fulldataAP1;
        DataTable filterdAP1;
        DataTable filteredAP;
        // public DataTable FullData;
        DateTime defaultFromDate;
        DateTime defaultToDate; 

        public frmGuestReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private void frmGuestReport_Load(object sender, EventArgs e)
        {
            //grdGuestReport.Columns["Check"].HeaderCell.Style.BackColor = Color.Red;
            //grdGuestReport.Columns["Check"].HeaderCell.Style.ForeColor = Color.White;
            

            clsUser obj = new clsUser();
                   DataTable dt = obj.GuestAP();
                     fulldataAP = obj.GuestAP();
            filteredAP = fulldataAP.Copy();

            DataTable dt2=obj.EnquiryAP();
            fulldataAP1=obj.EnquiryAP();
            filterdAP1=fulldataAP1.Copy();

           

            defaultFromDate = dtpFrom.Value.Date;
            defaultToDate = dtpTo.Value.Date;

            // fulldataAP.Columns.Add("IsSelected", typeof(bool));
            if (dt != null && dt.Rows.Count > 0)
                    {
                        

                            grdGuestReport.DataSource = dt;
                
                            GenerateChartFromGridAP();

                            GeneratePieChartAP();
                        
                            MakeOnlyCheckBoxEditableAP();
                      }
                         
                    else
                    {
                             MessageBox.Show("No orders found.");
                    }

          
            if (fulldataAP!=null && fulldataAP.Rows.Count > 0) //count all records and display on frist page
                    {
                            totalrecordsAP = fulldataAP.Rows.Count;
                            DisplayPageAP(currentpageAP);
                            GeneratePageButtonsAP();

                    }


                    grdGuestReport.Columns["Action"].DisplayIndex = grdGuestReport.Columns.Count - 1;

            grdGuestReport.EnableHeadersVisualStyles = false;

            grdGuestReport.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdGuestReport.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdGuestReport.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdGuestReport.GridColor = System.Drawing.Color.Gray;

            ToolTip1.SetToolTip(pctRefresh, "Refresh");
            ToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            ToolTip1.SetToolTip(pctExcel, "Export To Exel");
            ToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
           // ToolTip1.SetToolTip(pctDelete, "Delete Data");
            ToolTip1.SetToolTip(pctFilter, "Filters");

           
            this.grdGuestReport.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdGuestReport.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            chartGuest.MouseClick += chartGuest_MouseClick;
            pieGuest.MouseClick += pieGuest_MouseClick;
            //grdGuestReport.ColumnHeadersDefaultCellStyle.BackColor = Color.Black;
            //grdGuestReport.RowsDefaultCellStyle.BackColor = Color.DimGray;

        }
        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdGuestReport.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdGuestReport.AllowUserToAddRows = false;
            grdGuestReport.ReadOnly = false;
            grdGuestReport.EditMode = DataGridViewEditMode.EditOnEnter;






            foreach (DataGridViewColumn col in grdGuestReport.Columns)
            {
                col.ReadOnly = col.Index != 0;

            }
            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;
            Rectangle rect = grdGuestReport.GetCellDisplayRectangle(0, -1, true);

            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdGuestReport.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdGuestReport.EndEdit();
                grdGuestReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdGuestReport.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }

                }
                grdGuestReport.RefreshEdit();
            };

            grdGuestReport.CurrentCellDirtyStateChanged += (s, e2) =>
                    {
                        if (grdGuestReport.CurrentCell is DataGridViewCheckBoxCell)
                            grdGuestReport.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            grdGuestReport.DataSource = dt;
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
            chartGuest.Series.Clear();
            chartGuest.Titles.Clear();

            chartGuest.Titles.Add(new Title(
                "Guest Check-ins (Month Wise)",
                Docking.Top,
                new Font("Segoe UI", 16, FontStyle.Bold),
                Color.Black));

            Dictionary<int, Dictionary<int, int>> data =
                new Dictionary<int, Dictionary<int, int>>();

            foreach (DataGridViewRow row in grdGuestReport.Rows)
            {
                if (row.IsNewRow) continue;

                if (row.Cells["RegistrationDate"].Value != null &&
                    DateTime.TryParse(row.Cells["RegistrationDate"].Value.ToString(), out DateTime regDate))
                {
                    int year = regDate.Year;
                    int month = regDate.Month;

                    if (year != 2024 && year != 2025 && year != 2026)
                        continue;

                    if (!data.ContainsKey(year))
                        data[year] = new Dictionary<int, int>();

                    if (data[year].ContainsKey(month))
                        data[year][month]++;
                    else
                        data[year][month] = 1;
                }
            }

            Dictionary<int, Color> yearColors = new Dictionary<int, Color>()
    {
        { 2024, Color.FromArgb(70, 130, 255) },
        { 2025, Color.FromArgb(255, 99, 132) },
        { 2026, Color.FromArgb(60, 179, 113) }
    };

            foreach (var yearEntry in data.OrderBy(x => x.Key))
            {
                Series series = new Series(yearEntry.Key.ToString());
                series.ChartType = SeriesChartType.Line;
                series.BorderWidth = 3;
                series.Color = yearColors[yearEntry.Key];

                series["LineTension"] = "0.4";

                series.MarkerStyle = MarkerStyle.Circle;
                series.MarkerSize = 9;
                series.MarkerColor = Color.White;
                series.MarkerBorderWidth = 2;
                series.MarkerBorderColor = series.Color;

                int maxValue = 0;
                int maxIndex = -1;

                for (int m = 1; m <= 12; m++)
                {
                    int count = yearEntry.Value.ContainsKey(m)
                                ? yearEntry.Value[m]
                                : 0;

                    string monthName = new DateTime(2024, m, 1).ToString("MMM");

                    int index = series.Points.AddXY(monthName, count);

                    // 🔥 TOOLTIP (Hover)
                    series.Points[index].ToolTip =
                        $"Year: {yearEntry.Key}\nMonth: {monthName}\nGuests: {count}";

                    // 🔥 Find MAX (highlight)
                    if (count > maxValue)
                    {
                        maxValue = count;
                        maxIndex = index;
                    }
                }

                // 🔥 Highlight Highest Month
                if (maxIndex >= 0)
                {
                    series.Points[maxIndex].MarkerSize = 14;
                    series.Points[maxIndex].MarkerColor = Color.Yellow;
                    series.Points[maxIndex].Label = "Peak";
                }

                chartGuest.Series.Add(series);
            }

            // ✅ UI Styling
            ChartArea ca = chartGuest.ChartAreas[0];
            ca.BackColor = Color.White;

            ca.AxisX.MajorGrid.Enabled = false;
            ca.AxisY.MajorGrid.LineColor = Color.LightGray;

            ca.AxisX.Title = "Month";
            ca.AxisY.Title = "Guest Count";

            ca.AxisX.Interval = 1;

            chartGuest.Legends[0].Docking = Docking.Bottom;
            chartGuest.Legends[0].Font = new Font("Segoe UI", 10);

            // 🔥 Smooth Animation
            foreach (var s in chartGuest.Series)
            {
                s["AnimationStyle"] = "EaseOut";
                s["AnimationDuration"] = "800";
            }
        }

        private void GeneratePieChartAP()
        {
            pieGuest.Series.Clear();
            pieGuest.Titles.Clear();

            pieGuest.Titles.Add(new Title(
                "Guest vs Enquiry (%)",
                Docking.Top,
                new Font("Segoe UI", 16, FontStyle.Bold),
                Color.Black));

            Series pieSeries = new Series("Data");
            pieSeries.ChartType = SeriesChartType.Doughnut;
            pieSeries.IsValueShownAsLabel = true;
            pieSeries["PieLabelStyle"] = "Outside";

            pieGuest.ChartAreas[0].BackColor = Color.White;

            // ✅ COUNT GUESTS
            int guestCount = 0;
            if (filteredAP != null)
                guestCount = filteredAP.Rows.Count;

            // ✅ COUNT ENQUIRIES
            int enquiryCount = 0;
            if (filterdAP1 != null)
                enquiryCount = filterdAP1.Rows.Count;

            int total = guestCount + enquiryCount;

            if (total == 0)
                return;

            // ✅ CALCULATE %
            double guestPercent = (guestCount * 100.0) / total;
            double enquiryPercent = (enquiryCount * 100.0) / total;

            // ✅ ADD DATA
            int gIndex = pieSeries.Points.AddXY("Guests", guestCount);
            int eIndex = pieSeries.Points.AddXY("Enquiries", enquiryCount);

            // ✅ LABELS (IMPORTANT)
            pieSeries.Points[gIndex].Label = $"Guests ({guestPercent:F1}%)";
            pieSeries.Points[eIndex].Label = $"Enquiries ({enquiryPercent:F1}%)";

            // ✅ TOOLTIP
            pieSeries.Points[gIndex].ToolTip = $"Guests: {guestCount} ({guestPercent:F1}%)";
            pieSeries.Points[eIndex].ToolTip = $"Enquiries: {enquiryCount} ({enquiryPercent:F1}%)";

            // ✅ COLORS
            pieSeries.Points[gIndex].Color = Color.MediumSeaGreen;
            pieSeries.Points[eIndex].Color = Color.Orange;

            pieSeries.Points[gIndex].BorderColor = Color.White;
            pieSeries.Points[eIndex].BorderColor = Color.White;

            pieSeries.Points[gIndex].BorderWidth = 2;
            pieSeries.Points[eIndex].BorderWidth = 2;

            pieGuest.Series.Add(pieSeries);

            // ✅ LEGEND
            pieGuest.Legends[0].Enabled = true;
            pieGuest.Legends[0].Docking = Docking.Right;
        }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        //private void OpenYearInfo(string year)
        //{
        //    frmInfoShow frm = new frmInfoShow(year, "YEAR");
        //    frm.Show();
        //}
        //private void OpenGenderInfo(string gender)
        //{
        //    frmInfoShow frm = new frmInfoShow(gender, "GENDER");
        //    frm.Show();
        //}
        private void chartGuest_Click(object sender, EventArgs e)
        {

        }
        private void chartGuest_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult result = chartGuest.HitTest(e.X, e.Y);

            //if (result.ChartElementType == ChartElementType.DataPoint)
            //{
            //    int index = result.PointIndex;
            //    string year = chartGuest.Series[0].Points[index].AxisLabel;

            //    frmInfoShow frm;

            //    // ✅ Date selected?
            //    if (dtpFrom.Value.Date != defaultFromDate ||
            //        dtpTo.Value.Date != defaultToDate)
            //    {
            //        frm = new frmInfoShow(
            //            year,
            //            "YEAR",
            //            dtpFrom.Value.Date,
            //            dtpTo.Value.Date
            //        );
            //    }
            //    else
            //    {
            //        // ✅ No date selected → ALL DATA
            //        frm = new frmInfoShow(year, "YEAR");
            //    }

            //    frm.ShowDialog();
            }


        
        private void FilterGridByYear(int year)
        {
            DataTable dt = fulldataAP.Clone();

            foreach (DataRow row in fulldataAP.Rows)
            {
                if (DateTime.TryParse(row["RegistrationDate"].ToString(), out DateTime date))
                {
                    if (date.Year == year)
                        dt.ImportRow(row);
                }
            }

            grdGuestReport.DataSource = dt;
        }
        private void piebooking_Click(object sender, EventArgs e)
        {

        }
        private void pieGuest_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = pieGuest.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // Guests / Enquiries
                string selected = pieGuest.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                // Date filter applied
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        selected,
                        "GUEST_ENQUIRY",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(selected, "GUEST_ENQUIRY");
                }

                frm.ShowDialog();
            }
        }

        private void FilterGridByGender(string gender)
        {
            DataTable dt = fulldataAP.Clone();

            foreach (DataRow row in fulldataAP.Rows)
            {
                if (row["Gender"].ToString().Equals(gender, StringComparison.OrdinalIgnoreCase))
                {
                    dt.ImportRow(row);
                }
            }

            grdGuestReport.DataSource = dt;
        }
        private void pieGuest_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void grdGuestReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

                    if (e.RowIndex >= 0 && grdGuestReport.Columns[e.ColumnIndex].Name == "Action")
                    {
                        string guestname = grdGuestReport.CurrentRow.Cells["GuestName"].Value.ToString();
                        string email = grdGuestReport.CurrentRow.Cells["Email"].Value.ToString();
                        string gender=grdGuestReport.CurrentRow.Cells["Gender"].Value.ToString();
                        string checkin = Convert.ToDateTime(grdGuestReport.CurrentRow.Cells["RegistrationDate"].Value).ToString("dd-MM-yyyy");

                       // string checkout = Convert.ToDateTime( grdGuestReport.CurrentRow.Cells["Checkout"].Value ).ToString("dd-MM-yyyy");




                frmViewGuest view = new frmViewGuest();
                        view.GuestNameAP = guestname;
                        view.EmailAP = email;
                        view.GenderAP = gender;
                        view.CheckIn = checkin;
                       // view.CheckOut = checkout;
                        view.ShowDialog();
                    }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
                    if(currentpageAP<Math.Ceiling((double)totalrecordsAP/pagesizeAP))
                    {
                        currentpageAP++;
                        DisplayPageAP(currentpageAP);
                        GeneratePageButtonsAP();
                    }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
                    if (currentpageAP >1)
                    {
                        currentpageAP--;
                        DisplayPageAP(currentpageAP);
                        GeneratePageButtonsAP();
                    }
        }

        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        public DataTable GetSelectedRowsAP()
        {
                    DataTable dtSelected = new DataTable();

                    if (grdGuestReport.SelectedRows.Count == 0)
                    {
                        MessageBox.Show("Select At Least 1 Row........!!!!");
                        return dtSelected;
                    }

                    // Columns that we want to export (WITHOUT SrNo & View column)
                    string[] allowedColumns =
                    {
                "GuestName",
                "Email",
                "Gender",
                "RegistrationDate"
                                 };

                    // Create DataTable columns
                    foreach (string col in allowedColumns)
                        dtSelected.Columns.Add(col);

                    grdGuestReport.EndEdit();

                    foreach (DataGridViewRow row in grdGuestReport.Rows)
                    {
                        if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                        {
                            DataRow dr = dtSelected.NewRow();
                            int index = 0;

                            foreach (string col in allowedColumns)
                            {
                                dr[index] = row.Cells[col].Value?.ToString() ?? "";
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
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✔ Convert FromDate & ToDate → DATE ONLY
            if (dt.Columns.Contains("FromDate"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (DateTime.TryParse(r["FromDate"].ToString(), out DateTime d))
                        r["FromDate"] = d.ToString("dd-MM-yyyy");
                }
            }

            if (dt.Columns.Contains("ToDate"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (DateTime.TryParse(r["ToDate"].ToString(), out DateTime d))
                        r["ToDate"] = d.ToString("dd-MM-yyyy");
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "ServiceReport.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Service Report");

                    // ⭐ TITLE
                    ws.Cell(1, 1).Value = "Service Report";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 18;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                    // ⭐ GENERATED DATE
                    ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(2, 1).Style.Font.Italic = true;
                    ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                    // Build custom DataTable with SrNo
                    DataTable finalDT = new DataTable();
                    finalDT.Columns.Add("SrNo");

                    foreach (DataColumn col in dt.Columns)
                        finalDT.Columns.Add(col.ColumnName);

                    int sr = 1;
                    foreach (DataRow r in dt.Rows)
                    {
                        DataRow newRow = finalDT.NewRow();
                        newRow[0] = sr++;

                        for (int i = 0; i < dt.Columns.Count; i++)
                            newRow[i + 1] = r[i];

                        finalDT.Rows.Add(newRow);
                    }

                    ws.Cell(4, 1).InsertTable(finalDT);

                    var header = ws.Range(4, 1, 4, finalDT.Columns.Count);
                    header.Style.Font.Bold = true;
                    header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    header.Style.Fill.BackgroundColor = XLColor.LightGray;

                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel Exported Successfully!");
            }
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

            // ✔ Convert FromDate & ToDate → DATE ONLY
            if (dt.Columns.Contains("FromDate"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (DateTime.TryParse(r["FromDate"].ToString(), out DateTime d))
                        r["FromDate"] = d.ToString("dd-MM-yyyy");
                }
            }

            if (dt.Columns.Contains("ToDate"))
            {
                foreach (DataRow r in dt.Rows)
                {
                    if (DateTime.TryParse(r["ToDate"].ToString(), out DateTime d))
                        r["ToDate"] = d.ToString("dd-MM-yyyy");
                }
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = "ServiceReport.pdf";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
            doc.Open();

            // TITLE
            Paragraph title = new Paragraph("Guest Report",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            doc.Add(title);

            // DATE
            Paragraph date = new Paragraph(
                "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 12;
            doc.Add(date);

            PdfPTable table = new PdfPTable(dt.Columns.Count + 1);
            table.WidthPercentage = 100;

            // SrNo Header
            PdfPCell srHeader = new PdfPCell(new Phrase("SrNo",
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
            srHeader.BackgroundColor = new BaseColor(200, 200, 200);
            srHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(srHeader);

            // Other Headers
            foreach (DataColumn col in dt.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName,
                    FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                cell.BackgroundColor = new BaseColor(200, 200, 200);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // Rows
            int sr = 1;
            foreach (DataRow row in dt.Rows)
            {
                table.AddCell(new Phrase(sr++.ToString(), FontFactory.GetFont("Arial", 10)));

                foreach (var val in row.ItemArray)
                {
                    table.AddCell(new Phrase(val.ToString(),
                         FontFactory.GetFont("Arial", 10)));
                }
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF Saved Successfully!");
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ConvertToPDFAP();
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelAP();
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdGuestReport.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdGuestReport.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdGuestReport.Rows.RemoveAt(i);
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

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.GuestAP();
            fulldataAP = obj.GuestAP();


            if (dt != null && dt.Rows.Count > 0)
            {

                grdGuestReport.DataSource = dt;

                GenerateChartFromGridAP();

                GeneratePieChartAP();
               // MakeOnlyCheckBoxEditable();
            }
            else
            {
                MessageBox.Show("No orders found.");
            }
            if (fulldataAP != null && fulldataAP.Rows.Count > 0) //count all records and display on frist page
            {
                totalrecordsAP = fulldataAP.Rows.Count;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

            }
            loadrefresh();

            grdGuestReport.Columns["Action"].DisplayIndex = grdGuestReport.Columns.Count - 1;
            pnlSearch.Visible = false;
            txtSearchBox.Clear();

            //dtpFrom.ResetText();
            //dtpTo.ResetText();  
          
        }
        
        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;  // Toggle once

            if (pnlSearch.Visible)
            {
                pnlSearch.BringToFront();
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            //if (grdGuestReport.DataSource == null)
            //    return;

            //DataTable dt = (DataTable)grdGuestReport.DataSource;
            //string searchText = txtSearchBox.Text.Trim().ToLower(); // fixed name

            //if (string.IsNullOrEmpty(searchText))
            //{
            //    dt.DefaultView.RowFilter = string.Empty;
            //    return;
            //}

            //List<string> filterList = new List<string>();

            //foreach (DataColumn col in dt.Columns)
            //{
            //    if (col.DataType == typeof(string)) // skip numbers/dates
            //    {
            //        string escaped = searchText.Replace("'", "''");
            //        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
            //    }
            //}

            //string filter = string.Join(" OR ", filterList);
            //dt.DefaultView.RowFilter = filter;


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
        public void  loadrefresh()
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

        

        //public void ApplySearch(string searchText)
        //{


        //    if (FullData == null)
        //        return;

        //    searchText = searchText.Trim().Replace("'", "''");

        //    DataView dv = new DataView(FullData);

        //    if (string.IsNullOrWhiteSpace(searchText))
        //    {
        //        dt = FullData.Copy();   // search box रिकामा → full data
        //    }
        //    else
        //    {
        //        string filter = "";

        //        foreach (DataColumn col in FullData.Columns)
        //        {
        //            filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
        //        }

        //        filter = filter.Substring(0, filter.Length - 4);

        //        dv.RowFilter = filter;

        //        dt = dv.ToTable();      // filtered result
        //    }

        //    // search नंतर pagination reset
        //    currentpageAP = 1;
        //    DisplayPageAP(currentpageAP);
        //    GeneratePageButtonsAP();
        //}
        private void lblFromDate_Click(object sender, EventArgs e)
        {

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

            clsUser copyObj = new clsUser(originalObj);
            DataTable dt = copyObj.GuestSerchAP();
            fulldataAP = dt;
            filteredAP = fulldataAP.Copy();

            if (dt != null && dt.Rows.Count > 0)
            {
                grdGuestReport.DataSource = dt;

                grdGuestReport.Columns["Action"].DisplayIndex = grdGuestReport.Columns.Count - 1;

                GenerateChartFromGridAP();
                GeneratePieChartAP();

                totalrecordsAP = fulldataAP.Rows.Count;
                currentpageAP = 1;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

                // OPTIONAL: जर Search नंतर first bar open करायचा असेल
                //if (chartGuest.Series[0].Points.Count > 0)
                //{
                //    string year = chartGuest.Series[0].Points[0].AxisLabel;
                //    OpenYearInfo(year);
                //}
            }
            else
            {
                grdGuestReport.DataSource = null;
                chartGuest.Series.Clear();
                pieGuest.Series.Clear();
                MessageBox.Show("No records found in this date range.");
            }
        }


    }
}
