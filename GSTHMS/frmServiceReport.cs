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
using Rectangle = System.Drawing.Rectangle;
using System.Text.RegularExpressions;
using Font = System.Drawing.Font;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Security.Policy;

namespace GSTHMS
{
    public partial class frmServiceReport : Form
    {
        int pagesizeAP = 10;  //for  show how many Recors we display in one page
        int currentpageAP = 1; //show what is the current page
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;

        public frmServiceReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private bool isDateFilterApplied = false;
        private void frmServiceReport_Load(object sender, EventArgs e)
        {
            clsUser obj =new clsUser();
            DataTable dt = obj.ServiceAP();
            fulldataAP = obj.ServiceAP();
          //  fulldataAP = obj.GuestAP();
            filteredAP = fulldataAP.Copy();




            if (dt != null )
            {
                grdService.DataSource = dt;
                GenerateServiceBarChartAP();
                GeneratePieChartAP();

                MakeOnlyCheckBoxEditableAP();
            }
            if (fulldataAP != null && fulldataAP.Rows.Count > 0)
            {
                totalrecordsAP = fulldataAP.Rows.Count;

                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();
            }

            grdService.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdService.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdService.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdService.GridColor = System.Drawing.Color.Gray;

            this.grdService.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");


            barService.MouseClick += barService_MouseDoubleClick;
            pieService.MouseClick += pieService_MouseClick;



        }
        private void DisplayPageAP(int page)
        {
            DataTable source = filteredAP; // always use filtered or full

            int start = (page - 1) * pagesizeAP;
            int end = Math.Min(start + pagesizeAP, source.Rows.Count);

            DataTable dt = source.Clone();

            for (int i = start; i < end; i++)
                dt.ImportRow(source.Rows[i]);

            grdService.DataSource = dt;
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
            foreach (DataGridViewColumn col in grdService.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdService.AllowUserToAddRows = false;
            grdService.ReadOnly = false;
            grdService.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdService.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;

            Rectangle rect = grdService.GetCellDisplayRectangle(0, -1, true);
            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdService.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdService.EndEdit();
                grdService.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdService.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }
                }

                grdService.RefreshEdit();
            };

            grdService.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdService.CurrentCell is DataGridViewCheckBoxCell)
                    grdService.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }
        private bool IsValidService(string value)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Trim() != "No Services" &&
                   value.Trim() != "--";
        }
        private void GenerateServiceBarChartAP()
        {
            barService.Series.Clear();
            barService.ChartAreas.Clear();
            barService.Titles.Clear();
            barService.Legends.Clear();

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            barService.ChartAreas.Add(area);

            int inventoryCount = 0;
            int foodCount = 0;
            int parkingCount = 0;

            // ✅ USE FULL DATA (NOT GRID)
            foreach (DataRow row in fulldataAP.Rows)
            {
                if (IsValidService(row["Inventory"]?.ToString()))
                    inventoryCount++;

                if (IsValidService(row["Food"]?.ToString()))
                    foodCount++;

                if (IsValidService(row["Parking"]?.ToString()))
                    parkingCount++;
            }

            Series series = new Series("Service Usage");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 12, FontStyle.Bold);

            series.Points.AddXY("Inventory", inventoryCount);
            series.Points.AddXY("Food", foodCount);
            series.Points.AddXY("Parking", parkingCount);

            barService.Series.Add(series);
            barService.Titles.Add("Service Utilization Report");
        }
        private void GeneratePieChartAP()
        {
            pieService.Series.Clear();
            pieService.ChartAreas.Clear();
            pieService.Legends.Clear();
            pieService.Titles.Clear();

            // ==========================
            // CHART AREA
            // ==========================
            ChartArea area = new ChartArea("PieArea");
            area.BackColor = Color.White;

            area.Position = new ElementPosition(3, 5, 72, 85);
            area.InnerPlotPosition = new ElementPosition(10, 10, 80, 80);

            pieService.ChartAreas.Add(area);

            // ==========================
            // COUNT SERVICES
            // ==========================
            int inventoryCount = 0;
            int foodCount = 0;
            int parkingCount = 0;

            foreach (DataRow row in fulldataAP.Rows)
            {
                if (IsValidService(row["Inventory"]?.ToString()))
                    inventoryCount++;

                if (IsValidService(row["Food"]?.ToString()))
                    foodCount++;

                if (IsValidService(row["Parking"]?.ToString()))
                    parkingCount++;
            }

            int total =
                inventoryCount +
                foodCount +
                parkingCount;

            double inventoryPer =
                total > 0 ? (inventoryCount * 100.0) / total : 0;

            double foodPer =
                total > 0 ? (foodCount * 100.0) / total : 0;

            double parkingPer =
                total > 0 ? (parkingCount * 100.0) / total : 0;

            // ==========================
            // SERIES
            // ==========================
            Series s = new Series("Services");

            s.ChartType = SeriesChartType.Doughnut;
            s.ChartArea = "PieArea";

            s.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            s.IsValueShownAsLabel = true;

            s["DoughnutRadius"] = "45";
            s["PieLabelStyle"] = "Outside";
            s["PieLineColor"] = "Gray";

            s.SmartLabelStyle.Enabled = true;
            s.SmartLabelStyle.AllowOutsidePlotArea =
                LabelOutsidePlotAreaStyle.Yes;

            // ==========================
            // INVENTORY
            // ==========================
            int p1 = s.Points.AddY(inventoryCount);

            s.Points[p1].LegendText = "Inventory";

            s.Points[p1].Label =
                inventoryCount +
                "\n(" +
                inventoryPer.ToString("0.0") +
                "%)";

            s.Points[p1].ToolTip =
                "Inventory\nCount : " +
                inventoryCount;

            s.Points[p1].Color =
                Color.FromArgb(52, 152, 219);

            // ==========================
            // FOOD
            // ==========================
            int p2 = s.Points.AddY(foodCount);

            s.Points[p2].LegendText = "Food";

            s.Points[p2].Label =
                foodCount +
                "\n(" +
                foodPer.ToString("0.0") +
                "%)";

            s.Points[p2].ToolTip =
                "Food\nCount : " +
                foodCount;

            s.Points[p2].Color =
                Color.FromArgb(46, 204, 113);

            // ==========================
            // PARKING
            // ==========================
            int p3 = s.Points.AddY(parkingCount);

            s.Points[p3].LegendText = "Parking";

            s.Points[p3].Label =
                parkingCount +
                "\n(" +
                parkingPer.ToString("0.0") +
                "%)";

            s.Points[p3].ToolTip =
                "Parking\nCount : " +
                parkingCount;

            s.Points[p3].Color =
                Color.FromArgb(243, 156, 18);

            // ==========================
            // BORDER
            // ==========================
            foreach (DataPoint point in s.Points)
            {
                point.BorderColor = Color.White;
                point.BorderWidth = 3;
            }

            pieService.Series.Add(s);

            // ==========================
            // TITLE
            // ==========================
            Title title = new Title();

            title.Text = "Service Distribution Report";

            title.Font =
                new Font("Segoe UI", 15, FontStyle.Bold);

            title.ForeColor = Color.Black;

            title.Alignment =
                ContentAlignment.TopCenter;

            pieService.Titles.Add(title);

            // ==========================
            // LEGEND
            // ==========================
            Legend legend = new Legend();

            legend.Docking = Docking.Right;

            legend.Alignment = StringAlignment.Center;

            legend.BackColor = Color.White;

            legend.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            legend.BorderColor = Color.LightGray;

            pieService.Legends.Add(legend);

            // ==========================
            // FINAL LOOK
            // ==========================
            pieService.BackColor = Color.White;

            pieService.BorderlineColor =
                Color.LightGray;

            pieService.BorderlineDashStyle =
                ChartDashStyle.Solid;

            pieService.BorderlineWidth = 1;
        }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            //if (grdService.DataSource == null)
            //    return;

            //DataTable dt = (DataTable)grdService.DataSource;
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

        private void guna2Button1_Click(object sender, EventArgs e)
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

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            isDateFilterApplied = false;

            clsUser obj = new clsUser();

            fulldataAP = obj.ServiceAP();
            filteredAP = fulldataAP.Copy();

            totalrecordsAP = filteredAP.Rows.Count;
            currentpageAP = 1;   // Important

            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();

            GenerateServiceBarChartAP();
            GeneratePieChartAP();

            pnlSearch.Visible = false;
            txtSearchBox.Clear();
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

            if (grdService.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least 1 row.");
                return dt;
            }

            // Your SQL column names
            string[] columns =
            {
        "BookingCode",
        "GuestName",
        "FromDate",
        "ToDate",
        "Services"
    };

            foreach (string c in columns)
                dt.Columns.Add(c);

            grdService.EndEdit();

            foreach (DataGridViewRow row in grdService.Rows)
            {
                if (row.Cells[0].Value != null &&
                    Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    DataRow dr = dt.NewRow();

                    foreach (string c in columns)
                    {
                        dr[c] = row.Cells[c].Value?.ToString() ?? "";
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
            Paragraph title = new Paragraph("Service Report",
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
            DataTable dt = copyObj.ServiceSerchAP();
            fulldataAP = dt;
            filteredAP = fulldataAP.Copy();


            // Step 4: Update Grid + Charts
            if (dt != null && dt.Rows.Count > 0)
            {

                grdService.DataSource = dt;




                GeneratePieChartAP();
                GenerateServiceBarChartAP();

                totalrecordsAP = fulldataAP.Rows.Count;
                currentpageAP = 1;
                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();

            }
            else
            {
                grdService.DataSource = null;
                barService.Series.Clear();
                pieService.Series.Clear();
                MessageBox.Show("NO RECORDS FOUND !!");

            }

        }
        private void OpenYearInfo(string services)
        {
            frmInfoShow frm = new frmInfoShow(services, "Services");
            frm.Show();
        }
        private void Chart1_MouseClick(object sender, MouseEventArgs e)
        {

           

        }

        private void barService_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = barService.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;
                string service = barService.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                if (isDateFilterApplied)
                {
                    frm = new frmInfoShow(
                        service,
                        "Services",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date);
                }
                else
                {
                    frm = new frmInfoShow(
                        service,
                        "Services");
                }

                frm.Show();
            }
        }
        private void pieService_MouseClick(object sender, MouseEventArgs e)
        {
            //HitTestResult result = pieService.HitTest(e.X, e.Y);

            //if (result.ChartElementType == ChartElementType.DataPoint)
            //{
            //    int index = result.PointIndex;
            //    string service = pieService.Series[0].Points[index].AxisLabel;

            //    OpenYearInfo(service);   // same function as bar
            //}
        }

        private void pieService_MouseClick_1(object sender, MouseEventArgs e)
        {

        }
    }
}
