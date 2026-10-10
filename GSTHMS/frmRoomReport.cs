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
using Guna.UI2.WinForms;

namespace GSTHMS
{

    public partial class frmRoomReport : Form
    {
        int pagesizeAP = 12;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;
        DateTime defaultFromDate;
        DateTime defaultToDate;
        public frmRoomReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private void frmRoomReport_Load(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.RoomAP();
            fulldataAP = obj.RoomAP();
            filteredAP = obj.RoomAP();
           
            if (dt != null && dt.Rows.Count > 0)
            {

                grdRoom.DataSource = dt;
              //  GenerateChartFromGridAP();
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
            grdRoom.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdRoom.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdRoom.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdRoom.GridColor = System.Drawing.Color.Gray;


            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
         //   guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");

          //  pieRoom.MouseClick += pieRoom_MouseClick;


            this.grdRoom.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdRoom.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
        }
        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdRoom.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdRoom.AllowUserToAddRows = false;
            grdRoom.ReadOnly = false;
            grdRoom.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdRoom.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;

            Rectangle rect = grdRoom.GetCellDisplayRectangle(0, -1, true);
            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdRoom.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdRoom.EndEdit();
                grdRoom.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdRoom.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }
                }

                grdRoom.RefreshEdit();
            };

            grdRoom.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdRoom.CurrentCell is DataGridViewCheckBoxCell)
                    grdRoom.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            grdRoom.DataSource = dt;
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

        //private void GenerateChartFromGridAP()
        //{
        //    barRoom.Series.Clear();
        //    barRoom.Titles.Clear();
        //    barRoom.ChartAreas.Clear();
        //    barRoom.Legends.Clear();

        //    // ===== Chart Area (Clean & Flat) =====
        //    ChartArea area = new ChartArea("MainArea");
        //    area.BackColor = Color.White;
        //    area.AxisX.Interval = 1;

        //    // Axis look (simple)
        //    area.AxisX.LineWidth = 1;
        //    area.AxisY.LineWidth = 1;
        //    area.AxisX.LineColor = Color.Gainsboro;
        //    area.AxisY.LineColor = Color.Gainsboro;

        //    area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9);
        //    area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);
        //    area.AxisX.LabelStyle.Angle = -20;
        //    area.AxisX.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);
        //    area.AxisY.LabelStyle.ForeColor = Color.FromArgb(80, 80, 80);

        //    // No grid noise
        //    area.AxisX.MajorGrid.Enabled = false;
        //    area.AxisY.MajorGrid.Enabled = false;

        //    // No ticks
        //    area.AxisX.MajorTickMark.Enabled = false;
        //    area.AxisY.MajorTickMark.Enabled = false;

        //    // Axis titles
        //    area.AxisX.Title = "Room Name";
        //    area.AxisY.Title = "Base Price (₹)";
        //    area.AxisX.TitleFont = new Font("Segoe UI Semibold", 10);
        //    area.AxisY.TitleFont = new Font("Segoe UI Semibold", 10);
        //    area.AxisX.TitleForeColor = Color.FromArgb(70, 70, 70);
        //    area.AxisY.TitleForeColor = Color.FromArgb(70, 70, 70);

        //    barRoom.ChartAreas.Add(area);

        //    // ===== Chart Title =====
        //    Title title = new Title(
        //        "Room Price Distribution",
        //        Docking.Top,
        //        new Font("Segoe UI Semibold", 14),
        //        Color.FromArgb(45, 45, 45)
        //    );
        //    barRoom.Titles.Add(title);

        //    // ===== Series (Flat Bars) =====
        //    Series series = new Series("Room Price");
        //    series.ChartType = SeriesChartType.Column;
        //    series.IsValueShownAsLabel = true;
        //    series.Font = new Font("Segoe UI", 9, FontStyle.Bold);
        //    series.LabelForeColor = Color.FromArgb(45, 45, 45);

        //    // Wider flat bars
        //    series.CustomProperties = "PointWidth=0.55";

        //    // Dark professional color (Blue-Gray)
        //    Color barColor = Color.FromArgb(120, 160, 210);
        //    series.Color = barColor;

        //    // ===== Data binding from grid =====
        //    foreach (DataGridViewRow row in grdRoom.Rows)
        //    {
        //        if (!row.IsNewRow &&
        //            row.Cells["RoomName"].Value != null &&
        //            row.Cells["BasePrice (₹)"].Value != null)
        //        {
        //            string roomName = row.Cells["RoomName"].Value.ToString();

        //            if (double.TryParse(row.Cells["BasePrice (₹)"].Value.ToString(), out double basePrice))
        //            {
        //                int idx = series.Points.AddXY(roomName, basePrice);
        //                series.Points[idx].BorderWidth = 0;
        //                series.Points[idx].ToolTip =
        //                    $"Room : {roomName}\nBase Price : ₹ {basePrice:0.00}";
        //            }
        //        }
        //    }

        //    barRoom.Series.Add(series);
        //    barRoom.Invalidate();
        //}



        private void GeneratePieChartAP()
        {
            pieRoom.Series.Clear();
            pieRoom.Titles.Clear();

            // --- Title ---
            Title title = new Title("Room Status Distribution", Docking.Top,
                new Font("Segoe UI", 12, FontStyle.Bold), Color.DimGray);
            pieRoom.Titles.Add(title);

            // --- Pie Series Setup ---
            Series pieSeries = new Series("Room Status");
            pieSeries.ChartType = SeriesChartType.Doughnut;
            pieSeries["DoughnutRadius"] = "30";
            pieSeries.IsValueShownAsLabel = true;
            pieSeries["PieLabelStyle"] = "Outside";
            pieSeries.LabelForeColor = Color.DimGray;
            pieSeries.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // --- Count status occurrences from filtered data ---
            Dictionary<string, int> statusCount = new Dictionary<string, int>();

            foreach (DataRow row in filteredAP.Rows) // ✅ filteredAP वरून
            {
                if (row["Status"] != null)
                {
                    string status = row["Status"].ToString().Trim();

                    if (statusCount.ContainsKey(status))
                        statusCount[status]++;
                    else
                        statusCount[status] = 1;
                }
            }

            // --- Add data to pie chart ---
            foreach (var item in statusCount)
            {
                int pointIndex = pieSeries.Points.AddXY(item.Key, item.Value);
                pieSeries.Points[pointIndex].ToolTip = $"Status: {item.Key}\nNo_Of_Rooms: {item.Value}";
                pieSeries.Points[pointIndex].Tag = item.Key; // ✅ Filtered Status assign
            }

            // --- Colors ---
            Color[] colors = new Color[]
            {
        Color.FromArgb(0, 122, 255),
        Color.FromArgb(255, 99, 132),
        Color.FromArgb(111, 66, 193),
        Color.FromArgb(255, 205, 86),
        Color.FromArgb(144, 238, 144)
            };

            for (int i = 0; i < pieSeries.Points.Count; i++)
                pieSeries.Points[i].Color = colors[i % colors.Length];

            pieRoom.BackColor = Color.White;

            ChartArea area = new ChartArea();
            area.BackColor = Color.White;
            pieRoom.ChartAreas.Clear();
            pieRoom.ChartAreas.Add(area);  // ✅ ChartArea assign before adding series

            pieRoom.Series.Add(pieSeries);
            pieRoom.Invalidate();
        }



        private void grdRoom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void barRoom_Click(object sender, EventArgs e)
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




        // ------------------- Method 1: Get Selected Rows -------------------
        public DataTable GetSelectedRowsAP()
        {
            DataTable dtSelected = new DataTable();

            if (grdRoom.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select at least 1 row!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dtSelected;
            }

            // 👉 Required columns for ROOM REPORT (same format as booking)
            string[] allowedColumns =
            {
        "RoomName",
        "RoomTypeName",

        "BasePrice",
        "Status",

    };

            // Add Columns
            foreach (string col in allowedColumns)
                dtSelected.Columns.Add(col);

            grdRoom.EndEdit();

            foreach (DataGridViewRow row in grdRoom.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dtSelected.NewRow();
                    int index = 0;

                    foreach (string col in allowedColumns)
                    {
                        string value = row.Cells[col].Value?.ToString() ?? "";
                        dr[index++] = value;
                    }

                    dtSelected.Rows.Add(dr);
                }
            }

            return dtSelected;
        }

        // ------------------- Method 2: Export to Excel -------------------
        public void ExportToExcelAP()
        {
            DataTable dt = GetSelectedRowsAP();

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "RoomReport.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var workbook = new XLWorkbook())
            {
                var ws = workbook.Worksheets.Add("Room Report");

                // Title
                ws.Cell(1, 1).Value = "Room Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 18;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                // Date
                ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                // New table with SrNo
                DataTable dtExcel = new DataTable();
                dtExcel.Columns.Add("SrNo");

                foreach (DataColumn col in dt.Columns)
                    dtExcel.Columns.Add(col.ColumnName);

                int sr = 1;
                foreach (DataRow row in dt.Rows)
                {
                    DataRow nr = dtExcel.NewRow();
                    nr[0] = sr++;

                    for (int i = 0; i < dt.Columns.Count; i++)
                        nr[i + 1] = row[i];

                    dtExcel.Rows.Add(nr);
                }

                // Insert table into excel
                ws.Cell(4, 1).InsertTable(dtExcel);

                // Header style
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

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = "RoomReport.pdf";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
            doc.Open();

            // Title
            Paragraph title = new Paragraph("Room Report",
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


        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdRoom.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdRoom.Rows[i];

                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdRoom.Rows.RemoveAt(i);
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

            DataTable dt = obj.RoomAP();

            if (dt == null || dt.Rows.Count == 0)
            {
                grdRoom.DataSource = null;
                MessageBox.Show("No orders found.");
                return;
            }

            // Reload data
            fulldataAP = dt.Copy();
            filteredAP = dt.Copy();

            // Reset pagination
            currentpageAP = 1;
            totalrecordsAP = filteredAP.Rows.Count;

            // Display first page
            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();

            // Refresh chart
            GeneratePieChartAP();

            // Clear search
            txtSearchBox.Clear();

            // Hide filter panel
            pnlSearch.Visible = false;
        }


        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlSearch.Visible = !pnlSearch.Visible;  // Toggle once

            if (pnlSearch.Visible)
            {
                pnlSearch.BringToFront();
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clsUser obj2= new clsUser(cmbRoomType.Text);

            FilterByRoomType();
        }
      //  DataTable filteredRoomTable = new DataTable();  // GLOBAL VARIABLE

        private void FilterByRoomType()
        {
            clsUser obj = new clsUser();
            obj.roomtypenameAP = cmbRoomType.Text.Trim();

            DataTable dt = obj.SerachRoomAP();

            // Assign to global filtered table
            filteredAP = dt.Copy();

            // Bind to grid
            grdRoom.DataSource = filteredAP;

            // Update charts
           // GenerateChartFromGridAP();
            GeneratePieChartAP();
        }

        private void pieRoom_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = pieRoom.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint &&
                result.PointIndex >= 0)
            {
                DataPoint point = pieRoom.Series[0].Points[result.PointIndex];

                if (point.Tag != null)
                {
                    string status = point.Tag.ToString();

                    // ✅ Filtered data based on current filteredAP
                    frmInfoShow frm = new frmInfoShow(status, "ROOMSTATUS", filteredAP);
                    frm.Show();
                }
            }
        }
    }
}
