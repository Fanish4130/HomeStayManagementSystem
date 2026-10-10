using ClosedXML.Excel;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace GSTHMS
{
    public partial class frmcardsinfo : Form
    {
        public frmcardsinfo(string lable)
        {
            InitializeComponent();
            LableSY = lable;
        }
        public string LableSY { get; set; }
        public string RoomCapacitySY { get; set; }
        public int RoomIDSY { get; set; }

        public int RoomTypeIDSY { get; set; }
        public int StatusIDSY { get; set; }
        public string[] allowedColumns;

        private CheckBox headerCheckBoxSY;

        // ─── NEW: tracks which rows (by index in dtSY) are selected across ALL pages ───
        private HashSet<int> selectedRowIndicesSY = new HashSet<int>();
        // ────────────────────────────────────────────────────────────────────────────────

        int pagesizeSY = 12;
        int currentpageSY = 1;
        int totrecordsSY = 0;
        int totpageSY = 0;
        int CapacitySY;
        string RoomTypeSY;
        DataTable dtSY = new DataTable();
        public DataTable FullData;
        private void frmcardsinfo_Load(object sender, EventArgs e)
        {
            try
            {

                ShowDataOnGridSY();
                LoadPageSY();
                GeneratePageButtonsSY();
                CheckBoxSY();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in cardinfo: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void ShowDataOnGridSY()
        {
            try
            {

                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Exel");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctFilter, "Filters");

                grdCardInfoShow.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdCardInfoShow.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdCardInfoShow.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdCardInfoShow.GridColor = System.Drawing.Color.DarkGray;


                lblInfo.Text = LableSY;

                if (LableSY == "Total Rooms")
                {
                    clsUser clsUser = new clsUser();

                    dtSY = clsUser.showTotalRoomsinfoSY();
                    FullData = dtSY.Copy();


                }
                if (LableSY == "Available Rooms")
                {
                    clsUser clsUser = new clsUser();

                    dtSY = clsUser.showAvailableRoomsinfoSY();
                    FullData = dtSY.Copy();


                }
                if (LableSY == "Occupied Rooms")
                {
                    clsUser clsUser = new clsUser();
                    dtSY = clsUser.showOccupiedRoomsinfoSY();
                    FullData = dtSY.Copy();

                }

                if (LableSY == "Cleaning")
                {
                    clsUser clsUser = new clsUser();
                    dtSY = clsUser.showCleaningRoomsinfoSY();
                    FullData = dtSY.Copy();

                }
                if (LableSY == "Check-In-Today")
                {
                    clsUser clsUser = new clsUser();
                    dtSY = clsUser.ShowCheckInTodayinfoSY();
                    FullData = dtSY.Copy();

                }
                if (LableSY == "Check-Out-Today")
                {
                    clsUser clsUser = new clsUser();
                    dtSY = clsUser.ShowCheckOutTodayinfoSY();
                    FullData = dtSY.Copy();

                }

                // ─── NEW: clear cross-page selections whenever data is reloaded ───
                selectedRowIndicesSY.Clear();
                // ──────────────────────────────────────────────────────────────────

                FilterShow();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ShowDataOnGrid: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void colorizedSY()
        {
            try
            {

                foreach (DataGridViewRow row in grdCardInfoShow.Rows)
                {
                    if (row.Cells["Status"].Value != null)
                    {
                        string Status = row.Cells["Status"].Value.ToString();

                        switch (Status)
                        {
                            case "Available":
                                row.Cells["Status"].Style.ForeColor = Color.Green;
                                break;

                            case "Cleaning":
                                row.Cells["Status"].Style.ForeColor = Color.Orange;
                                break;

                            case "Occupied":
                                row.Cells["Status"].Style.ForeColor = Color.OrangeRed;
                                break;

                            case "Unclean":
                                row.Cells["Status"].Style.ForeColor = Color.Peru;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Colorized: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //public void AddBookingIcon()
        //{
        //    try
        //    {

        //        if (grdCardInfoShow.Columns.Contains("colBook"))
        //            return;
        //        // Booking icon add in column
        //        DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
        //        imgCol.HeaderText = "Booking";
        //        imgCol.Name = "colBook";
        //        imgCol.Image = Properties.Resources.book;
        //        imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

        //        grdCardInfoShow.Columns.Add(imgCol);


        //        grdCardInfoShow.ColumnHeadersDefaultCellStyle.Alignment =
        //            DataGridViewContentAlignment.MiddleCenter;

        //        grdCardInfoShow.DefaultCellStyle.Alignment =
        //            DataGridViewContentAlignment.MiddleCenter;

        //        string[] centerCols = { "Sr No", "Capacity", "Room Name", "Room Type Name", "Status", "Base Price", "Booking" };

        //        foreach (DataGridViewColumn col in grdCardInfoShow.Columns)
        //        {
        //            if (centerCols.Contains(col.HeaderText))
        //            {
        //                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in AddingBookingIcon: " + ex.Message, "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}
        public void CheckBoxSY()
        {
            try
            {
                grdCardInfoShow.AllowUserToAddRows = false;
                grdCardInfoShow.ReadOnly = false;
                grdCardInfoShow.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdCardInfoShow.Columns)
                {
                    col.ReadOnly = col.Index != 0;

                }
                headerCheckBoxSY = new CheckBox();
                headerCheckBoxSY.BackColor = Color.Transparent;
                System.Drawing.Rectangle rect = grdCardInfoShow.GetCellDisplayRectangle(0, -1, true);

                headerCheckBoxSY.Size = new Size(18, 18);
                headerCheckBoxSY.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                grdCardInfoShow.Controls.Add(headerCheckBoxSY);

                // ─── CHANGED: header checkbox now selects/deselects ALL rows in dtSY ───
                headerCheckBoxSY.CheckedChanged += (s, e1) =>
                {
                    grdCardInfoShow.EndEdit();
                    grdCardInfoShow.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool checkAll = headerCheckBoxSY.Checked;

                    // Update the master selection set for ALL rows across all pages
                    selectedRowIndicesSY.Clear();
                    if (checkAll)
                    {
                        for (int i = 0; i < dtSY.Rows.Count; i++)
                            selectedRowIndicesSY.Add(i);
                    }

                    // Reflect the change on the currently visible page rows
                    foreach (DataGridViewRow row in grdCardInfoShow.Rows)
                    {
                        DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (chkCell != null)
                            chkCell.Value = checkAll;
                    }
                    grdCardInfoShow.RefreshEdit();
                };
                // ─────────────────────────────────────────────────────────────────────

                // ─── CHANGED: individual checkbox click updates the master selection set ───
                grdCardInfoShow.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    if (grdCardInfoShow.CurrentCell is DataGridViewCheckBoxCell)
                    {
                        grdCardInfoShow.CommitEdit(DataGridViewDataErrorContexts.Commit);

                        // Find which dtSY index this grid row corresponds to
                        int gridRowIndex = grdCardInfoShow.CurrentCell.RowIndex;
                        if (gridRowIndex >= 0 && gridRowIndex < grdCardInfoShow.Rows.Count)
                        {
                            // The actual index in dtSY = page offset + grid row index
                            int dtSYIndex = (currentpageSY - 1) * pagesizeSY + gridRowIndex;
                            DataGridViewCheckBoxCell chk = grdCardInfoShow.CurrentCell as DataGridViewCheckBoxCell;
                            bool isChecked = chk.Value != null && Convert.ToBoolean(chk.Value);

                            if (isChecked)
                                selectedRowIndicesSY.Add(dtSYIndex);
                            else
                                selectedRowIndicesSY.Remove(dtSYIndex);
                        }
                    }
                };
                // ───────────────────────────────────────────────────────────────────────
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CheckBox: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnCardsInfoPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentpageSY > 1)
                {
                    currentpageSY--;
                    LoadPageSY();
                    GeneratePageButtonsSY();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in PreviousButton: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void btnCardsInfoNext_Click(object sender, EventArgs e)
        {
            try
            {
                int totalpagesSY = (int)Math.Ceiling((double)dtSY.Rows.Count / pagesizeSY);
                totpageSY = totalpagesSY;
                if (currentpageSY < totpageSY)
                {
                    currentpageSY++;
                    LoadPageSY();
                    GeneratePageButtonsSY();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in NextButton: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        DataTable dtpage;

        // ─── CHANGED: LoadPageSY now restores checkbox state from selectedRowIndicesSY ───
        private void LoadPageSY()
        {
            try
            {

                int startIndexSY = (currentpageSY - 1) * pagesizeSY;
                dtpage = dtSY.Clone();

                for (int i = startIndexSY; i < startIndexSY + pagesizeSY && i < dtSY.Rows.Count; i++)
                {
                    dtpage.ImportRow(dtSY.Rows[i]);
                }
                grdCardInfoShow.DataSource = dtpage;

                // Restore checkbox ticks for the rows on this page
                for (int rowIdx = 0; rowIdx < grdCardInfoShow.Rows.Count; rowIdx++)
                {
                    int dtSYIndex = startIndexSY + rowIdx;
                    DataGridViewCheckBoxCell chk = grdCardInfoShow.Rows[rowIdx].Cells[0] as DataGridViewCheckBoxCell;
                    if (chk != null)
                        chk.Value = selectedRowIndicesSY.Contains(dtSYIndex);
                }

                if (LableSY == "Total Rooms")
                {
                    colorizedSY();
                }
                if (LableSY == "Available Rooms")
                {
                  //  AddBookingIcon();

                    var BookingColumn = grdCardInfoShow.Columns["Booking"];
                    if (BookingColumn != null && BookingColumn.DisplayIndex != -1)
                    {
                        BookingColumn.DisplayIndex = -1;
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LoadPage: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        // ────────────────────────────────────────────────────────────────────────────────

        private void GeneratePageButtonsSY()
        {
            try
            {
                int bwidthSY = 40;
                int bheightSY = 35;
                int spacingSY = 5;
                int startXSY = 10;

                foreach (Control ctr in pnlCardInfoNo.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlCardInfoNo.Controls.Remove(ctr);
                    }

                }
                int totalpagesSY = (int)Math.Ceiling((double)dtSY.Rows.Count / pagesizeSY);
                totpageSY = totalpagesSY;

                for (int i = 1; i <= totalpagesSY; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidthSY, bheightSY);
                    btnPage.Location = new Point(startXSY, 5);
                    btnPage.FillColor = (i == currentpageSY) ? Color.Silver : Color.White;
                    btnPage.ForeColor = (i == currentpageSY) ? Color.White : Color.Black;
                    btnPage.Click += BtnPage_Click;


                    pnlCardInfoNo.Controls.Add(btnPage);
                    startXSY += bwidthSY + spacingSY;

                }
                btnCardsInfoPrevious.Enabled = currentpageSY > 1;
                btnCardsInfoNext.Enabled = currentpageSY < totpageSY;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GeneratePageButtons: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void BtnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                if (btn != null)
                {
                    int pageNumberSY = Convert.ToInt32(btn.Text);
                    currentpageSY = pageNumberSY;
                    LoadPageSY();
                    GeneratePageButtonsSY();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in BtnPage: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // ─── CHANGED: GetSelectedRowsSY now reads from selectedRowIndicesSY (all pages) ───
        public DataTable GetSelectedRowsSY()
        {
            DataTable dtSelectedSY = new DataTable();
            try
            {
                grdCardInfoShow.EndEdit();

                dtSelectedSY.Columns.Add("SrNo", typeof(int));

                if (lblInfo.Text == "Total Rooms")
                {
                    allowedColumns = new string[]{
                 "Room Name",
                 "Room Type",
                 "Base Price(₹)",
                 "Amenities",
                 "Capacity",
                 "Status",
                   };
                }
                else if (lblInfo.Text == "Available Rooms")
                {
                    allowedColumns = new string[]{
                 "Room Name",
                 "Room Type",
                 "Base Price(₹)",
                 "Capacity",
                 "Amenities",
                };
                }
                else if (lblInfo.Text == "Booked Rooms")
                {
                    allowedColumns = new string[]{
                 "Room Name",
                 "Room Type",
                 "Base Price(₹)",
                 "Capacity",
                 "Amenities",
                 };
                }
                else if (lblInfo.Text == "Cleaning")
                {
                    allowedColumns = new string[] {
                 "Room Name",
                 "Room Type",
                 "Base Price(₹)",
                 "Capacity",
                 "Amenities",
                };
                }
                else if (lblInfo.Text == "Check-In-Today")
                {
                    allowedColumns = new string[] {
                 "BookingCode",
                 "GuestName",
                 "RoomName",
                 "No_of_Guest",
                 "OfferName",
                };
                }
                else if (lblInfo.Text == "Check-Out-Today")
                {
                    allowedColumns = new string[] {
                 "BookingCode",
                 "GuestName",
                 "RoomName",
                 "No_of_Guest",
                 "OfferName",
                };
                }

                // Build column list from the grid (same logic as before)
                foreach (DataGridViewColumn col in grdCardInfoShow.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0 &&
                        col.Visible &&
                        !string.IsNullOrWhiteSpace(col.Name) &&
                        !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase) &&
                        !isIconCol &&
                        allowedColumns.Contains(col.Name))
                    {
                        if (!dtSelectedSY.Columns.Contains(col.Name))
                            dtSelectedSY.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                // ─── NEW: iterate over ALL selected indices in dtSY, not just the current page ───
                foreach (int dtSYIndex in selectedRowIndicesSY.OrderBy(i => i))
                {
                    if (dtSYIndex >= dtSY.Rows.Count) continue;

                    DataRow sourceDR = dtSY.Rows[dtSYIndex];
                    DataRow dr = dtSelectedSY.NewRow();
                    dr["SrNo"] = srNo++;

                    foreach (DataColumn col in dtSelectedSY.Columns)
                    {
                        if (col.ColumnName == "SrNo") continue;

                        if (dtSY.Columns.Contains(col.ColumnName))
                            dr[col.ColumnName] = sourceDR[col.ColumnName] ?? DBNull.Value;
                        else
                            dr[col.ColumnName] = DBNull.Value;
                    }

                    dtSelectedSY.Rows.Add(dr);
                }
                // ────────────────────────────────────────────────────────────────────────────────
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GetSelectedRows " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelectedSY;
        }
        // ────────────────────────────────────────────────────────────────────────────────

        public void ExportToExcelSY()
        {
            try
            {

                DataTable dtSelectRowSY = GetSelectedRowsSY();


                if (dtSelectRowSY == null || dtSelectRowSY.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = "SelectedGuestData.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Selected Rows");

                        ws.Cell(1, 1).Value = lblInfo.Text;
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, dtSelectRowSY.Columns.Count).Merge();

                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Range(2, 1, 2, dtSelectRowSY.Columns.Count).Merge();

                        ws.Cell(4, 1).InsertTable(dtSelectRowSY);

                        var header = ws.Range(4, 1, 4, dtSelectRowSY.Columns.Count);
                        header.Style.Font.Bold = true;
                        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Columns().AdjustToContents();

                        // Save the file
                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Selected rows exported to Excel successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ExportToExcel: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ConvertToPDF()
        {
            try
            {

                DataTable dtSelectedRowPDF = GetSelectedRowsSY();
                if (dtSelectedRowPDF == null || dtSelectedRowPDF.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
                System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                System.Drawing.Font normalFont = new System.Drawing.Font("Segoe UI", 10);
                System.Drawing.Font boldFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

                Brush black = Brushes.Black;
                Brush blue = new SolidBrush(Color.FromArgb(20, 60, 150));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathAM = saveFileDialog.FileName;

                Document docSY = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(docSY, new FileStream(filePathAM, FileMode.Create));
                docSY.Open();

                Paragraph title = new Paragraph(lblInfo.Text,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                title.Alignment = Element.ALIGN_CENTER;
                docSY.Add(title);

                Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
                date.Alignment = Element.ALIGN_RIGHT;
                date.SpacingAfter = 10;
                docSY.Add(date);

                PdfPTable table = new PdfPTable(dtSelectedRowPDF.Columns.Count);

                foreach (DataColumn column in dtSelectedRowPDF.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                foreach (DataRow row in dtSelectedRowPDF.Rows)
                {
                    foreach (var value in row.ItemArray)
                    {
                        table.AddCell(new Phrase(value.ToString(), FontFactory.GetFont("Arial", 10)));
                    }
                }

                docSY.Add(table);
                docSY.Close();

                MessageBox.Show("PDF File Saved Successfully!\n" + filePathAM, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ConvertToPDF: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelSY();
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ConvertToPDF();
        }



        private void txtSearchBox_TextChanged_1(object sender, EventArgs e)
        {
            ApplySearch(txtSearchBox.Text);

        }

        public void ApplySearch(string searchText)
        {
            try
            {

                if (FullData == null)
                    return;

                searchText = searchText.Trim().Replace("'", "''");

                DataView dv = new DataView(FullData);

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dtSY = FullData.Copy();
                }
                else
                {
                    string filter = "";

                    foreach (DataColumn col in FullData.Columns)
                    {
                        filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
                    }

                    filter = filter.Substring(0, filter.Length - 4);

                    dv.RowFilter = filter;

                    dtSY = dv.ToTable();
                }

                // ─── NEW: clear selections when search changes (data set changes) ───
                selectedRowIndicesSY.Clear();
                if (headerCheckBoxSY != null) headerCheckBoxSY.Checked = false;
                // ──────────────────────────────────────────────────────────────────

                currentpageSY = 1;
                LoadPageSY();
                GeneratePageButtonsSY();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ApplySearch " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void cmbbxCapacity_Click(object sender, EventArgs e)
        {
            try
            {

                clsUser clsUser = new clsUser();
                DataTable dt8 = clsUser.GetRoomCapacitySY();

                cmbbxCapacity.DataSource = dt8;

                cmbbxCapacity.ValueMember = "Capacity";
                cmbbxCapacity.DisplayMember = "Capacity";

                cmbbxCapacity.SelectedIndex = -1;

                if (LableSY == "Available Rooms")
                {
                    //grdCardInfoShow.Columns["colBook"].DisplayIndex = grdCardInfoShow.Columns.Count - 1;
                }
                var srNoColumn = grdCardInfoShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox Capacity Click " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        string RC;
        string RC1;




        private void cmbbxCapacity_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxCapacity.SelectedValue != null)
                {

                    System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxCapacity.SelectedItem;
                    RoomCapacitySY = SelectedRow["Capacity"].ToString();


                    if (RoomCapacitySY.Length > 0)
                    {
                        RC = RoomCapacitySY[0].ToString();
                        RC1 = RoomCapacitySY[1].ToString();
                    }
                    clsUser obj = new clsUser();

                    obj.CapacitySY = Convert.ToInt32(RC + RC1);

                    if (LableSY == "Total Rooms")
                    {
                        dtSY = obj.ShowRoomCapacitySY();
                    }
                    if (LableSY == "Available Rooms")
                    {
                        dtSY = obj.ShowAvailableRoomCapacitySY();
                    }
                    if (LableSY == "Occupied Rooms")
                    {
                        dtSY = obj.ShowOccupiedRoomCapacitySY();
                    }
                    if (LableSY == "Cleaning")
                    {
                        dtSY = obj.ShowCleaningRoomCapacitySY();
                    }

                    // ─── NEW: clear selections when filter changes ───
                    selectedRowIndicesSY.Clear();
                    if (headerCheckBoxSY != null) headerCheckBoxSY.Checked = false;
                    // ────────────────────────────────────────────────

                    LoadPageSY();
                    GeneratePageButtonsSY();

                    if (LableSY == "Available Rooms")
                    {
                        //grdCardInfoShow.Columns["colBook"].DisplayIndex = grdCardInfoShow.Columns.Count - 1;
                    }
                    var srNoColumn = grdCardInfoShow.Columns["SrNo"];
                    if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                    {
                        srNoColumn.DisplayIndex = 1;
                    }

                }
                else
                {
                    ShowDataOnGridSY();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox Capacity " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        public void FilterShow()
        {
            try
            {
                bool filtersAreVisible = pnlCapacity.Visible || pnlRoomName.Visible || pnlRoomType.Visible || pnlStatus.Visible;

                if (lblInfo.Text == "Total Rooms")

                {
                    pnlCapacity.Show();
                    pnlRoomType.Show();
                    pnlStatus.Show();
                }
                else if (lblInfo.Text == "Available Rooms" || lblInfo.Text == "Occupied Rooms" || lblInfo.Text == "Cleaning")
                {
                    pnlCapacity.Show();
                    pnlRoomType.Show();
                    pnlStatus.Hide();
                }

                else if (lblInfo.Text == "Check-In-Today" || lblInfo.Text == "Check-Out-Today")
                {
                    pnlRoomName.Show();
                    pnlStatus.Hide();
                    pnlCapacity.Hide();
                    pnlRoomType.Hide();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Filter " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnlCapacity.Hide();
            pnlRoomName.Hide();
            pnlRoomType.Hide();
            pnlStatus.Hide();

        }




        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {


                txtSearchBox.Text = null;
                txtSearchBox.PlaceholderText = "search Here";

                if (headerCheckBoxSY != null)
                    headerCheckBoxSY.Checked = false;

                cmbbxCapacity.DataSource = null;
                cmbbxCapacity.Items.Clear();

                cmbbxRoomName.DataSource = null;
                cmbbxRoomName.Items.Clear();

                cmbbxRoomType.DataSource = null;
                cmbbxRoomType.Items.Clear();

                cmbbxStatus.DataSource = null;
                cmbbxStatus.Items.Clear();

                currentpageSY = 1;

                // ─── NEW: clear cross-page selections on refresh ───
                selectedRowIndicesSY.Clear();
                // ──────────────────────────────────────────────────

                ShowDataOnGridSY();
                LoadPageSY();
                GeneratePageButtonsSY();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Refresh " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void cmbbxRoomName_Click(object sender, EventArgs e)
        {
            try
            {
                clsUser clsUser = new clsUser();
                DataTable dt9 = clsUser.GetRoomNameSY();
                cmbbxRoomName.DataSource = dt9;

                cmbbxRoomName.DisplayMember = "RoomName";
                cmbbxRoomName.ValueMember = "RoomID";

                cmbbxCapacity.SelectedIndex = -1;
                cmbbxRoomName.StartIndex = -1;

                var srNoColumn = grdCardInfoShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Combobox RoomName Click " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbbxRoomName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxRoomName.SelectedValue != null)
                {
                    System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxRoomName.SelectedItem;
                    RoomIDSY = Convert.ToInt32(SelectedRow["RoomID"]);

                }
                clsUser obj = new clsUser();
                obj.RoomIDSY = RoomIDSY;

                dtSY = obj.ShowRoomNameSY();

                // ─── NEW: clear selections when filter changes ───
                selectedRowIndicesSY.Clear();
                if (headerCheckBoxSY != null) headerCheckBoxSY.Checked = false;
                // ────────────────────────────────────────────────

                LoadPageSY();
                GeneratePageButtonsSY();

                var srNoColumn = grdCardInfoShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Combobox RoomName " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdCardInfoShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && grdCardInfoShow.Columns[e.ColumnIndex].Name == "colBook")
                {
                    frmAddbooking frm = new frmAddbooking();
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Booking validation: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxRoomType_Click(object sender, EventArgs e)
        {
            try
            {
                clsUser clsUser = new clsUser();
                DataTable dt8 = clsUser.GetRoomTypeSY();


                cmbbxRoomType.DataSource = dt8;
                cmbbxRoomType.ValueMember = "RoomTypeID";
                cmbbxRoomType.DisplayMember = "RoomTypeName";

                cmbbxRoomType.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox RoomType Click: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxRoomType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                ApplyRoomAndStatusFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox RoomType: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void ApplyRoomAndStatusFilter()
        {
            try
            {

                StatusIDSY = 0;
                RoomTypeIDSY = 0;
                dtSY = null;
                if (cmbbxRoomType.SelectedValue != null && cmbbxStatus.SelectedValue != null)
                {
                    System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxRoomType.SelectedItem;
                    System.Data.DataRowView SelectedRow1 = (System.Data.DataRowView)cmbbxStatus.SelectedItem;
                    RoomTypeIDSY = Convert.ToInt32(SelectedRow["RoomTypeID"]);
                    StatusIDSY = Convert.ToInt32(SelectedRow1["StatusID"]);

                }

                else if (cmbbxRoomType.SelectedValue != null && cmbbxRoomType.SelectedValue != DBNull.Value)
                {
                    System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxRoomType.SelectedItem;
                    RoomTypeIDSY = Convert.ToInt32(SelectedRow["RoomTypeID"]);
                }

                else if (cmbbxStatus.SelectedValue != null && cmbbxStatus.SelectedValue != DBNull.Value)
                {
                    System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxStatus.SelectedItem;
                    StatusIDSY = Convert.ToInt32(SelectedRow["StatusID"]);
                }



                if (StatusIDSY > 0 && RoomTypeIDSY > 0)
                {

                    clsUser clsUser = new clsUser();
                    clsUser.StatusIDSY = StatusIDSY;
                    clsUser.RoomTypeIDSY = RoomTypeIDSY;
                    dtSY = clsUser.showRoomTypeAndStatusWiseInfoSY();

                }
                else if (StatusIDSY > 0)
                {

                    clsUser clsUser = new clsUser();
                    clsUser.StatusIDSY = StatusIDSY;
                    dtSY = clsUser.ShowRoomTypeWiseStatusSY();

                }
                else if (RoomTypeIDSY > 0)
                {

                    clsUser clsUser = new clsUser();
                    clsUser.RoomTypeIDSY = RoomTypeIDSY;
                    dtSY = clsUser.ShowRoomTypeWiseInfoSY();

                    if (LableSY == "Available Rooms")
                    {
                        dtSY = clsUser.ShowAvailableRoomTypeWiseInfoSY();
                    }

                    if (LableSY == "Occupied Rooms")
                    {
                        dtSY = clsUser.ShowOccupiedRoomTypeWiseInfoSY();
                    }
                    if (LableSY == "Cleaning")
                    {
                        dtSY = clsUser.ShowCleaningRoomTypeWiseInfoSY();
                    }

                }

                // ─── NEW: clear selections when filter changes ───
                selectedRowIndicesSY.Clear();
                if (headerCheckBoxSY != null) headerCheckBoxSY.Checked = false;
                // ────────────────────────────────────────────────

                LoadPageSY();
                GeneratePageButtonsSY();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Filter: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbbxStatus_Click(object sender, EventArgs e)
        {
            try
            {

                clsUser clsUser = new clsUser();
                DataTable dt2 = clsUser.GetRoomStatusSY();

                cmbbxStatus.DataSource = dt2;
                cmbbxStatus.ValueMember = "StatusID";
                cmbbxStatus.DisplayMember = "Status";

                cmbbxStatus.SelectedIndex = -1;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox status click: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                ApplyRoomAndStatusFilter();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox status: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}