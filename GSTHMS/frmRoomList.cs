using ClosedXML.Excel;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmRoomList : Form
    {
        public frmRoomList()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.TopMost = true;
        }
        public int RoomTypeIDSY { get; set; }
        public int StatusIDSY { get; set; }

        private CheckBox headerCheckBoxSY;

        int pageSizeSY = 9;
        int currentpageSY = 1;
        int totrecordsSY = 0;
        int totpageSY = 0;
        int capacitySY;
        string RoomTypeSY;
        DataTable dtSY = new DataTable();
        public DataTable FullData;

        private void frmRoomList_Load(object sender, EventArgs e)
        {
            MainFormLoadSY();
            CheckBoxSY();
        }



        public void MainFormLoadSY()
        {
            try
            {
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Exel");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctFilter, "Filters");


                grdRoomListShow.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdRoomListShow.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdRoomListShow.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdRoomListShow.GridColor = System.Drawing.Color.DarkGray;

                


                clsUser clsUser = new clsUser();

                dtSY = clsUser.ShowRoomListinfoSY();
                FullData = dtSY.Copy();
               // grdRoomListShow.DataSource = dtSY;

                pnlRoomListFilter.Visible = false;

                  
                LoadPageSY();
                GeneratePageButtonsSY();
                AddBookingIcon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in MainFormLoad: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void AddBookingIcon()
        {
            try
            {
                // Booking icon add in column
                DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                imgCol.HeaderText = "Booking";
                imgCol.Name = "colBook";
                imgCol.Image = Properties.Resources.book;
                imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;

                grdRoomListShow.Columns.Add(imgCol);


                grdRoomListShow.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                grdRoomListShow.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                string[] centerCols = { "Sr No", "Capacity", "Room Name", "Room Type Name", "Status", "Base Price", "Booking" };

                foreach (DataGridViewColumn col in grdRoomListShow.Columns)
                {
                    if (centerCols.Contains(col.HeaderText))
                    {
                        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in AddingBookingIcon: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CheckBoxSY()
        {
            try
            {
                grdRoomListShow.AllowUserToAddRows = false;
                grdRoomListShow.ReadOnly = false;
                grdRoomListShow.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdRoomListShow.Columns)
                {
                    col.ReadOnly = col.Index != 0;

                }
                headerCheckBoxSY = new CheckBox();
                headerCheckBoxSY.BackColor = Color.Transparent;
                System.Drawing.Rectangle rect = grdRoomListShow.GetCellDisplayRectangle(0, -1, true);

                headerCheckBoxSY.Size = new Size(18, 18);
                headerCheckBoxSY.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                grdRoomListShow.Controls.Add(headerCheckBoxSY);

                headerCheckBoxSY.CheckedChanged += (s, e1) =>
                {
                    grdRoomListShow.EndEdit();
                    grdRoomListShow.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool chechAll = headerCheckBoxSY.Checked;

                    foreach (DataGridViewRow row in grdRoomListShow.Rows)
                    {
                        DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (chkCell != null)
                        {
                            chkCell.Value = chechAll;
                        }
                    }
                    grdRoomListShow.RefreshEdit();

                };
                grdRoomListShow.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    if (grdRoomListShow.CurrentCell is DataGridViewCheckBoxCell)

                        grdRoomListShow.CommitEdit(DataGridViewDataErrorContexts.Commit);

                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in CheckBox: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void colorizedSY()
        {
            try
            {

                foreach (DataGridViewRow row in grdRoomListShow.Rows)
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

                            case "Dirty":
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

        private void grdRoomListShow_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && grdRoomListShow.Columns[e.ColumnIndex].Name == "colBook")
                {
                    string Status = grdRoomListShow.Rows[e.RowIndex].Cells["Status"].Value.ToString();
                    if (Status == "Available")
                    {
                        frmAddbooking obj = new frmAddbooking();
                        obj.TopMost = true;
                        obj.ShowDialog();


                    }
                    else
                    {
                        switch (Status)
                        {

                            case "Cleaning":
                                MessageBox.Show("This Room is under cleaning");
                                break;

                            case "Occupied":
                                MessageBox.Show("This Room is currently occupied");
                                break;

                            case "Dirty":
                                MessageBox.Show("This Room need cleaning before booking");
                                break;

                        }

                    }

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

                grdRoomListShow.Columns["colBook"].DisplayIndex = grdRoomListShow.Columns.Count - 1;
                var srNoColumn = grdRoomListShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
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

                grdRoomListShow.Columns["colBook"].DisplayIndex = grdRoomListShow.Columns.Count - 1;
                var srNoColumn = grdRoomListShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }

                ApplyRoomAndStatusFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox RoomType: " + ex.Message, "Error",
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

                grdRoomListShow.Columns["colBook"].DisplayIndex = grdRoomListShow.Columns.Count - 1;
                var srNoColumn = grdRoomListShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
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

                grdRoomListShow.Columns["colBook"].DisplayIndex = grdRoomListShow.Columns.Count - 1;
                var srNoColumn = grdRoomListShow.Columns["SrNo"];
                if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                {
                    srNoColumn.DisplayIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in combobox status: " + ex.Message, "Error",
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

                }



                LoadPageSY();
                GeneratePageButtonsSY();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Filter: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbbxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            colorizedSY();

        }

        private void cmbbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            colorizedSY();

        }

        private void LoadPageSY()
        {
            try
            {

                int startIndex = (currentpageSY - 1) * pageSizeSY;
                DataTable dtpage = dtSY.Clone();
                for (int i = startIndex; i < startIndex + pageSizeSY && i < dtSY.Rows.Count; i++)
                {
                    dtpage.ImportRow(dtSY.Rows[i]);
                }
                grdRoomListShow.DataSource = dtpage;

                colorizedSY();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in LoadPage: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void GeneratePageButtonsSY()
        {
            try
            {
                int bwidthSY = 40;
                int bheightSY = 35;
                int spacingSY = 5;
                int startXSY = 10;
                pnlRoomListNo.Controls.Clear();

                foreach (Control ctr in pnlRoomListNo.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                        pnlRoomListNo.Controls.Remove(ctr);
                }
                int totalpagesSY = (int)Math.Ceiling((double)dtSY.Rows.Count / pageSizeSY);
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


                    pnlRoomListNo.Controls.Add(btnPage);
                    startXSY += bwidthSY + spacingSY;

                }
                btnRoomListPrevious.Enabled = currentpageSY > 1;
                btnRoomListNext.Enabled = currentpageSY < totpageSY;

                colorizedSY();
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
                    int pageNumberAM = Convert.ToInt32(btn.Text);
                    currentpageSY = pageNumberAM;
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

        private void btnRoomListPrevious_Click(object sender, EventArgs e)
        {
            if (currentpageSY > 1)
            {
                currentpageSY--;
                LoadPageSY();
                GeneratePageButtonsSY();
            }
        }

        private void btnRoomListNext_Click(object sender, EventArgs e)
        {
            int totalpagesSY = (int)Math.Ceiling((double)dtSY.Rows.Count / pageSizeSY);
            totpageSY = totalpagesSY;
            if (currentpageSY < totpageSY)
            {
                currentpageSY++;
                LoadPageSY();
                GeneratePageButtonsSY();

            }
        }



        public DataTable GetSelectedRowsSY()
        {
            DataTable dtSelectedSY = new DataTable();

            try
            {
                grdRoomListShow.EndEdit();

                dtSelectedSY.Columns.Add("SrNo", typeof(int));

                string[] allowedColumns = {
                 "Room Name",
                 "Room Type",
                 "Status",
                 "Base Price (₹)",
                 "Capacity",
                 };

                foreach (DataGridViewColumn col in grdRoomListShow.Columns)
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

                foreach (DataGridViewRow row in grdRoomListShow.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dtSelectedSY.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dtSelectedSY.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grdRoomListShow.Columns.Contains(col.ColumnName))
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            else
                                dr[col.ColumnName] = DBNull.Value;
                        }

                        dtSelectedSY.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GetSelectedRows: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelectedSY;
        }


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

                        ws.Cell(1, 1).Value = lblRoomList.Text;
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

                //int x = 50, y = 40;

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

                Paragraph title = new Paragraph(lblRoomList.Text,
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


                currentpageSY = 1;
                LoadPageSY();
                GeneratePageButtonsSY();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in ApplySearch : " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pctRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {

                txtSearchBox.Text = "";
                txtSearchBox.PlaceholderText = "search Here";

                clsUser clsUser = new clsUser();
                dtSY = clsUser.ShowRoomListinfoSY();

                if(headerCheckBoxSY!=null)
                    headerCheckBoxSY.Checked = false;



                cmbbxRoomType.DataSource = null;
                cmbbxRoomType.Items.Clear();

                cmbbxStatus.DataSource = null;
                cmbbxStatus.Items.Clear();

                pnlRoomListFilter.Hide();

                currentpageSY = 1;
              

                LoadPageSY();
                GeneratePageButtonsSY();


                colorizedSY();
                grdRoomListShow.Columns["colBook"].DisplayIndex = grdRoomListShow.Columns.Count - 1;
                grdRoomListShow.Columns["Sr No"].DisplayIndex = grdRoomListShow.Columns.Count - 7;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Refresh: " + ex.Message, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void pctPDF_Click_1(object sender, EventArgs e)
        {
            ConvertToPDF();
        }

        private void pctExcel_Click_1(object sender, EventArgs e)
        {
            ExportToExcelSY();
        }

        //private void pctDelete_Click_1(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        bool anyChecked = false;

        //        for (int i = grdRoomListShow.Rows.Count - 1; i >= 0; i--)
        //        {
        //            DataGridViewRow row = grdRoomListShow.Rows[i];
        //            if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
        //            {
        //                grdRoomListShow.Rows.RemoveAt(i);
        //                anyChecked = true;
        //                MessageBox.Show("Row Deleted Successfully");
        //            }

        //        }

        //        if (!anyChecked)
        //        {
        //            MessageBox.Show("plz select a row to delete!", "Warning",
        //            MessageBoxButtons.OK,
        //            MessageBoxIcon.Warning);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error in Delete: " + ex.Message, "Error",
        //                        MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }

        //}

        private void pctFilter_Click_1(object sender, EventArgs e)
        {
            pnlRoomListFilter.Visible = !pnlRoomListFilter.Visible;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
  



