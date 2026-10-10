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
using Font = System.Drawing.Font;
using Rectangle = System.Drawing.Rectangle;

namespace GSTHMS
{
    public partial class frmPaymentReport : Form
    {
        int pagesizeAP = 10;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;

        DateTime defaultFromDate;
        DateTime defaultToDate;
        public frmPaymentReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private void PaymentReport_Load(object sender, EventArgs e)
        {
          
            clsUser obj = new clsUser();
            DataTable dt = obj.PaymentAP();
            fulldataAP = obj.PaymentAP();
            filteredAP = obj.PaymentAP();

            defaultFromDate = dtpFrom.Value.Date;
            defaultToDate = dtpTodate.Value.Date;


            if (dt != null && dt.Rows.Count > 0)
            {

                grdPayment.DataSource = dt;
                CalculateTotalPaidAmount();
                GeneratebarFromGridAP();
                GeneratepieFromGridAP();
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
            grdPayment.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdPayment.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdPayment.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdPayment.GridColor = System.Drawing.Color.Gray;

            this.grdPayment.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdPayment.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
          //  guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");


        }
   
private void CalculateTotalPaidAmount()
        {
            decimal total = 0;

            foreach (DataRow row in filteredAP.Rows)
            {
                if (row["Paid Amount (₹)"] != DBNull.Value)
                {
                    decimal amt;

                    if (decimal.TryParse(
                        row["Paid Amount (₹)"].ToString()
                            .Replace("₹", "")
                            .Replace(",", ""),
                        out amt))
                    {
                        total += amt;
                    }
                }
            }

            lblTotalAmount.Text = "Total Amount : ₹ " + total.ToString("N2");
            lblTotalAmount.Visible = true;
        }


        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdPayment.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdPayment.AllowUserToAddRows = false;
            grdPayment.ReadOnly = false;
            grdPayment.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdPayment.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;

            Rectangle rect = grdPayment.GetCellDisplayRectangle(0, -1, true);
            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdPayment.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdPayment.EndEdit();
                grdPayment.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdPayment.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }
                }

                grdPayment.RefreshEdit();
            };

            grdPayment.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdPayment.CurrentCell is DataGridViewCheckBoxCell)
                    grdPayment.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            grdPayment.DataSource = dt;
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

        private void GeneratepieFromGridAP()
        {
            piePayment.Series.Clear();
            piePayment.ChartAreas.Clear();
            piePayment.Titles.Clear();
            piePayment.Legends.Clear();

            // ---- Chart Area ----
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;
            piePayment.ChartAreas.Add(area);

            // ---- Count Data ----
            int paid = 0, pending = 0;

            foreach (DataRow row in filteredAP.Rows)
            {
                string status = row["Status"]?.ToString()?.Trim();

                if (status == "Paid")
                    paid++;

                else if (status == "Pending")
                    pending++;
            }

            int total = paid + pending;

            // ---- Series ----
            Series series = new Series("Payment Status");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#";
            series.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Add Values
            int p0 = series.Points.AddXY("Paid", paid);
            series.Points[p0].Tag = "Paid";

            int p1 = series.Points.AddXY("Pending", pending);
            series.Points[p1].Tag = "Pending";

            // Professional Colors
            series.Points[0].Color = Color.FromArgb(198, 239, 206); // Green
            series.Points[1].Color = Color.FromArgb(0, 168, 107);   // Dark Green

            // Tooltips
            series.Points[0].ToolTip = $"Paid Payments : {paid}";
            series.Points[1].ToolTip = $"Pending Payments : {pending}";

            // Make it look modern
            series["PieLabelStyle"] = "Outside";
            series["DoughnutRadius"] = "60";
            series.BorderWidth = 3;
            series.BorderColor = Color.White;

            piePayment.Series.Add(series);

            // ---- Legend (Right Side) ----
            Legend legend = new Legend("LegendStatus");
            legend.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            legend.Docking = Docking.Right;
            legend.IsTextAutoFit = true;
            legend.BackColor = Color.White;

            piePayment.Legends.Add(legend);

            // ---- Title ----
            Title title = new Title(
                "Payment Status Report",
                Docking.Top,
                new Font("Segoe UI", 16, FontStyle.Bold),
                Color.Black);

            piePayment.Titles.Add(title);

            piePayment.ApplyPaletteColors();
        }


        private void GeneratebarFromGridAP()
        {
            barPayment.Series.Clear();
            barPayment.ChartAreas.Clear();
            barPayment.Titles.Clear();
            barPayment.Legends.Clear();

            // ---- Chart Area ----
            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.White;

            // More spacing
            area.AxisX.Interval = 1;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);

            barPayment.ChartAreas.Add(area);

            // ---- Count Data ----
            int cash = 0, upi = 0, bank = 0;

            foreach (DataRow row in filteredAP.Rows)
            {
                string mode = row["PaymentMethodType"].ToString().Trim();

                if (mode == "Cash") cash++;
                else if (mode == "UPI") upi++;
                else if (mode == "Bank") bank++;
            }

            int total = cash + upi + bank;

            // ---- SERIES ----
            Series series = new Series("Payment Mode");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.LabelFormat = "#";
            series.Font = new Font("Segoe UI", 12, FontStyle.Bold);
         //   series.CustomProperties = "DrawingStyle=Cylinder"; // Modern 3D look

            // Add Values
            int c0 = series.Points.AddXY("Cash", cash);
            series.Points[c0].Tag = "Cash";

            int c1 = series.Points.AddXY("UPI", upi);
            series.Points[c1].Tag = "UPI";

            int c2 = series.Points.AddXY("Bank", bank);
            series.Points[c2].Tag = "Bank";

            // Colors
            // Base color
            Color baseColor = Color.FromArgb(30, 136, 229); // Blue

            // Light/Dark shades for slices
            series.Points[0].Color = baseColor;                                 // Darkest
            series.Points[1].Color = ControlPaint.Light(baseColor, 0.3f);       // Lighter (30% lighter)
            series.Points[2].Color = ControlPaint.Light(baseColor, 0.6f);       // Even lighter (60% lighter)


            // Tooltips with % Calculation
            series.Points[0].ToolTip = $"Payment Using Cash:{cash}";
            series.Points[1].ToolTip = $" Payment Using UPI:{upi}";
            series.Points[2].ToolTip = $" Payment Using Bank:{bank}";

            // Bar Borders for clean look
            series.BorderWidth = 2;
            series.BorderColor = Color.White;

            barPayment.Series.Add(series);

            // ---- LEGEND ----
            Legend legend = new Legend();
            legend.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            legend.Docking = Docking.Bottom;
            legend.BackColor = Color.White;
            legend.BorderColor = Color.Silver;
            legend.BorderDashStyle = ChartDashStyle.Solid;
            barPayment.Legends.Add(legend);

            // ---- TITLE ----
            Title title = new Title("Payment Summary Report",
                Docking.Top,
                new Font("Segoe UI", 16, FontStyle.Bold),
                Color.Black);

            barPayment.Titles.Add(title);

            // Animation
            barPayment.Series[0]["Animation"] = "True";
        }



        private void barPayment_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

          
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.PaymentAP();
            fulldataAP = obj.PaymentAP();

            if (dt != null && dt.Rows.Count > 0)
            {

                grdPayment.DataSource = dt;
                GeneratebarFromGridAP();
                GeneratepieFromGridAP();
            }

            if (fulldataAP != null && fulldataAP.Rows.Count > 0)
            {

                totalrecordsAP = fulldataAP.Rows.Count;

                DisplayPageAP(currentpageAP);
            }
            else
            {
                MessageBox.Show("No orders found.");
            }
        }

        private void lblFromDate_Click(object sender, EventArgs e)
        {

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

            if (grdPayment.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select AT Least 1 Row........!!!!");
                return dtSelected;
            }

            // Add SrNo manually
            dtSelected.Columns.Add("Sr No");

            // Add all grid columns except checkbox (0 index)
            for (int i = 1; i < grdPayment.Columns.Count; i++)
                dtSelected.Columns.Add(grdPayment.Columns[i].HeaderText);

            grdPayment.EndEdit();
            int sr = 1;

            foreach (DataGridViewRow row in grdPayment.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dtSelected.NewRow();
                    dr[0] = sr++;  // Auto Sr No

                    for (int i = 1; i < grdPayment.Columns.Count; i++)
                    {
                        var val = row.Cells[i].Value;

                        // ***** DATE ONLY FORMAT *****
                        if (val is DateTime dt)
                            dr[i] = dt.ToString("dd-MM-yyyy");
                        else
                            dr[i] = val?.ToString() ?? "";
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
            sfd.FileName = "PaymentReport.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Payment Report");

                    // Report Title
                    ws.Cell(1, 1).Value = "Guest Payment Report";
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 18;
                    ws.Range(1, 1, 1, dt.Columns.Count).Merge();

                    // Generated Date
                    ws.Cell(2, 1).Value = "Generated On: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(2, 1).Style.Font.Italic = true;
                    ws.Range(2, 1, 2, dt.Columns.Count).Merge();

                    ws.Cell(4, 1).InsertTable(dt);

                    // Header Formatting
                    var header = ws.Range(4, 1, 4, dt.Columns.Count);
                    header.Style.Font.Bold = true;
                    header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    ws.Columns().AdjustToContents();
                    wb.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel exported successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF File|*.pdf";
            sfd.FileName = "PaymentReport.pdf";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            // --------------------------
            // Prepare fonts (safe way)
            // --------------------------
            iTextSharp.text.Font titleFont;
            iTextSharp.text.Font headerFont;
            iTextSharp.text.Font normalFont;
            iTextSharp.text.Font italicFont;

            try
            {
                // Try to load Arial from system fonts (embedded)
                string fontPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                if (System.IO.File.Exists(fontPath))
                {
                    iTextSharp.text.pdf.BaseFont bfArial = iTextSharp.text.pdf.BaseFont.CreateFont(fontPath, iTextSharp.text.pdf.BaseFont.IDENTITY_H, iTextSharp.text.pdf.BaseFont.EMBEDDED);
                    titleFont = new iTextSharp.text.Font(bfArial, 18, iTextSharp.text.Font.BOLD);
                    headerFont = new iTextSharp.text.Font(bfArial, 11, iTextSharp.text.Font.BOLD);
                    normalFont = new iTextSharp.text.Font(bfArial, 10, iTextSharp.text.Font.NORMAL);
                    italicFont = new iTextSharp.text.Font(bfArial, 10, iTextSharp.text.Font.ITALIC);
                }
                else
                {
                    // Fallback to built-in Helvetica if arial.ttf not found
                    iTextSharp.text.pdf.BaseFont bfHelv = iTextSharp.text.pdf.BaseFont.CreateFont(iTextSharp.text.pdf.BaseFont.HELVETICA, iTextSharp.text.pdf.BaseFont.CP1252, false);
                    titleFont = new iTextSharp.text.Font(bfHelv, 18, iTextSharp.text.Font.BOLD);
                    headerFont = new iTextSharp.text.Font(bfHelv, 11, iTextSharp.text.Font.BOLD);
                    normalFont = new iTextSharp.text.Font(bfHelv, 10, iTextSharp.text.Font.NORMAL);
                    italicFont = new iTextSharp.text.Font(bfHelv, 10, iTextSharp.text.Font.ITALIC);
                }
            }
            catch
            {
                // Ultimate fallback (shouldn't reach normally)
                titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11, iTextSharp.text.Font.BOLD);
                normalFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL);
                italicFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC);
            }

            // --------------------------
            // Create PDF
            // --------------------------
            iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            iTextSharp.text.pdf.PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
            doc.Open();

            // Title
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph("Guest Payment Report", titleFont);
            title.Alignment = iTextSharp.text.Element.ALIGN_CENTER;
            title.SpacingAfter = 8f;
            doc.Add(title);

            // Generated date (only date)
            iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"), italicFont);
            date.Alignment = iTextSharp.text.Element.ALIGN_RIGHT;
            date.SpacingAfter = 8f;
            doc.Add(date);

            // Table (use column count from DataTable)
            iTextSharp.text.pdf.PdfPTable table = new iTextSharp.text.pdf.PdfPTable(dt.Columns.Count);
            table.WidthPercentage = 100;

            // Add header cells
            foreach (DataColumn col in dt.Columns)
            {
                iTextSharp.text.pdf.PdfPCell hdr = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(col.ColumnName, headerFont));
                hdr.BackgroundColor = new iTextSharp.text.BaseColor(235, 235, 235);
                hdr.HorizontalAlignment = iTextSharp.text.Element.ALIGN_CENTER;
                hdr.Padding = 4f;
                table.AddCell(hdr);
            }

            // Add data rows
            foreach (DataRow row in dt.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    // Null-safety
                    string text = item?.ToString() ?? "";

                    // If this value is a date-like string and you want to ensure date-only,
                    // you can try parse and reformat (optional). Comment/uncomment as needed:
                    /*
                    if (DateTime.TryParse(text, out DateTime d))
                        text = d.ToString("dd-MM-yyyy");
                    */

                    iTextSharp.text.pdf.PdfPCell cell = new iTextSharp.text.pdf.PdfPCell(new iTextSharp.text.Phrase(text, normalFont));
                    cell.HorizontalAlignment = iTextSharp.text.Element.ALIGN_LEFT;
                    cell.Padding = 4f;
                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF Saved Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdPayment.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdPayment.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdPayment.Rows.RemoveAt(i);
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
            DataTable dt = obj.PaymentAP();

            fulldataAP = dt.Copy();
            filteredAP = dt.Copy();

            totalrecordsAP = filteredAP.Rows.Count;

            // Always go to first page
            currentpageAP = 1;

            DisplayPageAP(currentpageAP);
            GeneratePageButtonsAP();

            CalculateTotalPaidAmount();
            GeneratebarFromGridAP();
            GeneratepieFromGridAP();

            txtSearchBox.Clear();
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

        private void dtpTodate_ValueChanged(object sender, EventArgs e)
        {
            SerchBYDateTimeAP();
        }

                       public void SerchBYDateTimeAP()
                {
                    clsUser obj = new clsUser();

                    obj.fromdateAP = dtpFrom.Value.Date;
                    obj.todateAP   = dtpTodate.Value.Date.AddDays(1).AddSeconds(-1);

                    DataTable dt = obj.PaymentSerchAP();

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        fulldataAP = dt.Copy();
                        filteredAP = fulldataAP.Copy();

                        currentpageAP = 1;
                        totalrecordsAP = fulldataAP.Rows.Count;

                        DisplayPageAP(currentpageAP);
                        GeneratePageButtonsAP();
                        GeneratebarFromGridAP();
                        GeneratepieFromGridAP();
                    }
                    else
                    {
                        grdPayment.DataSource = null;
                        barPayment.Series.Clear();
                        piePayment.Series.Clear();
                        MessageBox.Show("No records found in this date range.");
                    }
                            CalculateTotalPaidAmount();
                }


        private void piePayment_Click(object sender, EventArgs e)
        {
            
        }

        private void piePayment_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = piePayment.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // 🔹 Status (Paid / Pending / Cancelled)
                string paymentStatus = piePayment.Series[0]
                                                    .Points[index]
                                                    .AxisLabel;

                frmInfoShow frm;

                // ✅ Date filter applied?
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTodate.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        paymentStatus,
                        "PAYMENT_STATUS",
                        dtpFrom.Value.Date,
                        dtpTodate.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(paymentStatus, "PAYMENT_STATUS");
                }

                frm.ShowDialog();
            }

        }

        private void barPayment_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = barPayment.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // 🔹 Mode (Cash / Online / Card etc.)
                string paymentMode = barPayment.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                // ✅ Date filter changed?
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTodate.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        paymentMode,
                        "PAYMENT_MODE",
                        dtpFrom.Value.Date,
                        dtpTodate.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(paymentMode, "PAYMENT_MODE");
                }

                frm.ShowDialog();
            }
        }

        private void lblTotalAmount_Click(object sender, EventArgs e)
        {

        }
    }
}

