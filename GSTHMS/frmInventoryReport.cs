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

namespace GSTHMS
{
    public partial class frmInventoryReport : Form
    {

        int pagesizeAP = 10;
        int currentpageAP = 1;
        int totalrecordsAP = 0;
        DataTable fulldataAP;
        DataTable filteredAP;
        DateTime defaultFromDate;
        DateTime defaultToDate;
        public frmInventoryReport()
        {
            InitializeComponent();
        }
        private CheckBox HederCheckboxAP;
        private void InventoryReport_Load(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.InventoryAP();

            fulldataAP = obj.InventoryAP();

            filteredAP = obj.InventoryAP();

            defaultFromDate = dtpFrom.Value.Date;
            defaultToDate = dtpTo.Value.Date;
            if (dt != null)
            {
                grdInventory.DataSource = dt;
                GenerateChartFromGridAP();
                GeneratePieChartAP();
            }
            if (fulldataAP != null && fulldataAP.Rows.Count > 0)
            {

                totalrecordsAP = fulldataAP.Rows.Count;

                DisplayPageAP(currentpageAP);
                GeneratePageButtonsAP();
                MakeOnlyCheckBoxEditableAP();
            }
            else
            {
                MessageBox.Show("No orders found.");
            }

            grdInventory.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdInventory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInventory.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInventory.GridColor = System.Drawing.Color.Gray;

            this.grdInventory.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdInventory.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            guna2HtmlToolTip1.SetToolTip(pctRefresh, "Refresh");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            guna2HtmlToolTip1.SetToolTip(pctExcel, "Export To Exel");
            guna2HtmlToolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
           // guna2HtmlToolTip1.SetToolTip(pctDelete, "Delete Data");
            guna2HtmlToolTip1.SetToolTip(pctFilter, "Filters");
        }
        private void MakeOnlyCheckBoxEditableAP()
        {
            foreach (DataGridViewColumn col in grdInventory.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdInventory.AllowUserToAddRows = false;
            grdInventory.ReadOnly = false;
            grdInventory.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdInventory.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            HederCheckboxAP = new CheckBox();
            HederCheckboxAP.BackColor = Color.Transparent;

            System.Drawing.Rectangle rect = grdInventory.GetCellDisplayRectangle(0, -1, true);
            HederCheckboxAP.Size = new Size(18, 18);
            HederCheckboxAP.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdInventory.Controls.Add(HederCheckboxAP);

            HederCheckboxAP.CheckedChanged += (s, e2) =>
            {
                grdInventory.EndEdit();
                grdInventory.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool checkAll = HederCheckboxAP.Checked;

                foreach (DataGridViewRow row in grdInventory.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = checkAll;
                    }
                }
                grdInventory.RefreshEdit();
            };

            grdInventory.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdInventory.CurrentCell is DataGridViewCheckBoxCell)
                    grdInventory.CommitEdit(DataGridViewDataErrorContexts.Commit);
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

            grdInventory.DataSource = dt;
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
            barInventory.Series.Clear();
            barInventory.Titles.Clear();
            barInventory.ChartAreas.Clear();
            barInventory.Legends.Clear();

            // 🎯 Chart Area (clean look)
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            chartArea.AxisX.Interval = 1;
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

            chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 10);
            chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 9);

            barInventory.ChartAreas.Add(chartArea);

            // 🎯 Title (simple)
            barInventory.Titles.Add(new Title(
                "Inventory vs Asset Inventory",
                Docking.Top,
                new Font("Segoe UI", 14, FontStyle.Bold),
                Color.Black));

            // 🎯 Legend (minimal)
            Legend legend = new Legend();
            legend.Docking = Docking.Bottom;
            legend.Font = new Font("Segoe UI", 9);
            barInventory.Legends.Add(legend);

            // 🎯 Series
            Series series = new Series("Count");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Segoe UI", 9);

            // 🔥 Grouping
            var groupedData = fulldataAP.AsEnumerable()
                .GroupBy(row => row["SubTypeName"].ToString())
                .Select(g => new
                {
                    SubType = g.Key,
                    Count = g.Count()
                });

            foreach (var item in groupedData)
            {
                int index = series.Points.AddXY(item.SubType, item.Count);

                // 🎨 Soft professional colors
                if (item.SubType == "Inventory")
                    series.Points[index].Color = Color.SteelBlue;
                else
                    series.Points[index].Color = Color.Gray;
            }

            barInventory.Series.Add(series);
        }
        private void GeneratePieChartAP()
        {
            pieInventory.Series.Clear();
            pieInventory.Titles.Clear();
            pieInventory.ChartAreas.Clear();
            pieInventory.Legends.Clear();

            // Create Chart Area
            ChartArea chartArea = new ChartArea("MainArea");
            chartArea.BackColor = Color.White;
            pieInventory.ChartAreas.Add(chartArea);

            // Title
            pieInventory.Titles.Add(new Title("Inventory Status Overview",
                Docking.Top, new Font("Segoe UI", 11, FontStyle.Bold), Color.Black));

            // Create Series
            Series series = new Series("InventoryStatus");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series["PieLabelStyle"] = "Outside";
            series["DoughnutRadius"] = "30";
            series.BorderColor = Color.White;
            series.BorderWidth = 3;
            series.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // ---- COUNT STATUS ----
            int inStock = 0;
            int lowStock = 0;
            int outStock = 0;
            foreach (DataRow row in fulldataAP.Rows)
            {
                string status = row["Status"]?.ToString().Trim();

                if (status == "In-Stock")
                    inStock++;
                else if (status == "Low-Stock")
                    lowStock++;
                else if (status == "Out-of-Stock")
                    outStock++;
            }

            // ---- ADD POINTS ONLY IF > 0 ----
            if (inStock > 0)
            {
                int p = series.Points.AddXY("In-Stock", inStock);
                series.Points[p].Color = Color.MediumSeaGreen;
                series.Points[p].Tag = "In-Stock";
                series.Points[p].ToolTip = $"In-Stock: {inStock}";
            }

            if (lowStock > 0)
            {
                int p = series.Points.AddXY("Low Stock", lowStock);
                series.Points[p].Color = Color.Gold;
                series.Points[p].Tag = "Low-Stock";
                series.Points[p].ToolTip = $"Low Stock: {lowStock}";
            }

            if (outStock > 0)
            {
                int p = series.Points.AddXY("Out of Stock", outStock);
                series.Points[p].Color = Color.IndianRed;
                series.Points[p].Tag = "Out-of-Stock";
                series.Points[p].ToolTip = $"Out of Stock: {outStock}";
            }

            pieInventory.Series.Add(series);

            // ---- LEGEND ----
            Legend legend = new Legend("InventoryLegend");
            legend.Docking = Docking.Right;
            legend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            pieInventory.Legends.Add(legend);

            pieInventory.Legends[0].Title = "Status";
        }







        private void grdInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pieInventory_Click(object sender, EventArgs e)
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
            DataTable dtSelected = new DataTable();

            if (grdInventory.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select AT Least 1 Row........!!!!");
                return dtSelected;
            }

            // Columns required for export
            string[] allowedCols =
            {
        "InventoryTypeName",
        "InventoryName",
        "Quantity",
        "PurchaseDate",
        "Status"
    };

            // Add columns to DataTable
            foreach (string col in allowedCols)
                dtSelected.Columns.Add(col);

            grdInventory.EndEdit();

            // Selected rows only
            foreach (DataGridViewRow row in grdInventory.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dtSelected.NewRow();
                    int idx = 0;

                    foreach (string col in allowedCols)
                    {
                        string val = row.Cells[col].Value?.ToString() ?? "";

                        // Convert PurchaseDate → Only Date
                        if (col == "PurchaseDate")
                        {
                            if (DateTime.TryParse(val, out DateTime d))
                                val = d.ToString("dd-MM-yyyy");
                        }

                        dr[idx++] = val;
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
            sfd.FileName = "InventoryReport.xlsx";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Inventory Report");

                // Title
                ws.Cell(1, 1).Value = "Inventory Report";
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Font.FontSize = 18;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Range(1, 1, 1, dt.Columns.Count + 1).Merge();

                // Generated Date Only
                ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                ws.Cell(2, 1).Style.Font.Italic = true;
                ws.Range(2, 1, 2, dt.Columns.Count + 1).Merge();

                // Add SrNo column
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

                var header = ws.Range(4, 1, 4, dtExcel.Columns.Count);
                header.Style.Font.Bold = true;
                header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

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
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Files|*.pdf";
            save.FileName = "InventoryReport.pdf";

            if (save.ShowDialog() != DialogResult.OK)
                return;

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
            doc.Open();

            // Heading
            Paragraph title = new Paragraph("Inventory Report",
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 10;
            doc.Add(title);

            // Date Only
            Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 15;
            doc.Add(date);

            // Table with SrNo
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

            // Add Rows
            int sr = 1;
            foreach (DataRow row in dt.Rows)
            {
                table.AddCell(sr.ToString());
                sr++;

                foreach (var val in row.ItemArray)
                    table.AddCell(val.ToString());
            }

            doc.Add(table);
            doc.Close();

            MessageBox.Show("PDF File Saved Successfully!", "Success");
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            bool anyChecked = false;

            for (int i = grdInventory.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdInventory.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdInventory.Rows.RemoveAt(i);
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

// Add this variable at class level
private bool isRefreshing = false;

      
private void pctRefresh_Click(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.InventoryAP();

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

            clsUser copyObj = new clsUser(originalObj);
            DataTable dt = copyObj.InventorySearchAP();

            if (dt != null && dt.Rows.Count > 0)
            {
                fulldataAP = dt.Copy();
                filteredAP = fulldataAP.Copy();

                grdInventory.DataSource = null;
                DisplayPageAP(1);

                GenerateChartFromGridAP();   // uses fulldataAP
                GeneratePieChartAP();        // NOW ALSO uses fulldataAP

                totalrecordsAP = fulldataAP.Rows.Count;
                currentpageAP = 1;
                GeneratePageButtonsAP();
            }
            else
            {
                grdInventory.DataSource = null;
                barInventory.Series.Clear();
                pieInventory.Series.Clear();
                MessageBox.Show("No records found in this date range.");
            }
        }

        private void pieInventory_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = pieInventory.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // ✅ Status from Tag
                string status =
                    pieInventory.Series[0].Points[index].Tag.ToString();

                frmInfoShow frm;

                if (dtpFrom.Value.Date != defaultFromDate ||
                       dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        status,
                        "INVENTORY_STATUS",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(status, "INVENTORY_STATUS");
                }

                frm.ShowDialog();
            }
        }

        private void barInventory_Click(object sender, EventArgs e)
        {
            //HitTestResult result = barInventory.HitTest(e.X, e.Y);

            //if (result.ChartElementType == ChartElementType.DataPoint)
            //{
            //    int index = result.PointIndex;

            //    // Get clicked subtype name
            //    string subType =
            //        barInventory.Series[0].Points[index].AxisLabel;

            //    frmInfoShow frm;

            //    // Date Filter Applied
            //    if (dtpFrom.Value.Date != defaultFromDate ||
            //        dtpTo.Value.Date != defaultToDate)
            //    {
            //        frm = new frmInfoShow(
            //            subType,
            //            "INVENTORY_SUBTYPE",
            //            dtpFrom.Value.Date,
            //            dtpTo.Value.Date
            //        );
            //    }
            //    else
            //    {
            //        frm = new frmInfoShow(
            //            subType,
            //            "INVENTORY_SUBTYPE"
            //        );
            //    }

               // frm.ShowDialog();
            }

        private void barInventory_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = barInventory.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // Get clicked subtype name
                string subType =
                    barInventory.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                // Date Filter Applied
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        subType,
                        "INVENTORY_SUBTYPE",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(
                        subType,
                        "INVENTORY_SUBTYPE"
                    );
                }

                frm.ShowDialog();
            }
        }

        private void barInventory_MouseClick_1(object sender, MouseEventArgs e)
        {
            HitTestResult result = barInventory.HitTest(e.X, e.Y);

            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                int index = result.PointIndex;

                // Get clicked subtype name
                string subType =
                    barInventory.Series[0].Points[index].AxisLabel;

                frmInfoShow frm;

                // Date Filter Applied
                if (dtpFrom.Value.Date != defaultFromDate ||
                    dtpTo.Value.Date != defaultToDate)
                {
                    frm = new frmInfoShow(
                        subType,
                        "INVENTORY_SUBTYPE",
                        dtpFrom.Value.Date,
                        dtpTo.Value.Date
                    );
                }
                else
                {
                    frm = new frmInfoShow(
                        subType,
                        "INVENTORY_SUBTYPE"
                    );
                }

                frm.ShowDialog();
            }
        }
    }
}
