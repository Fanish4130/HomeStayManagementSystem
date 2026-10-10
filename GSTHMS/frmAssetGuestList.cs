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

namespace GSTHMS
{
    public partial class frmAssetGuestList : Form
    {
        public frmAssetGuestList()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        int pagesizeVK = 20;
        int currentpageVK = 1;
        int totrecordsVK = 0;
        int totpageVK = 0;
        DataTable fulldataVK;
        public CheckBox headerCheckBoxAB;
        System.Data.DataTable dt = new DataTable();
        private void frmAssetGuestList_Load(object sender, EventArgs e)
        {
            try
            {
                grdAssetGuestList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAssetGuestList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //for grid text size 12
                this.grdAssetGuestList.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);
                this.grdAssetGuestList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);

                //for show names in icon
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Exel");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctFilter, "Filters");

                //grid horizontal and vertical border lines
                grdAssetGuestList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdAssetGuestList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAssetGuestList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAssetGuestList.GridColor = System.Drawing.Color.Gray;

                //pnlAssetguestfilter.Visible = false;

                // Display guest Name on combobox on Assetguestlist form filter
                clsUser obj1 = new clsUser();
                DataTable dt1 = obj1.GetGNameVK();

                DataRow dr = dt1.NewRow();
                dr["GuestID"] = 0;
                dr["GuestName"] = "- Select Guest name -";
                dt1.Rows.InsertAt(dr, 0);

                cmbbxGuestName.DataSource = dt1;
                cmbbxGuestName.DisplayMember = "GuestName";
                cmbbxGuestName.ValueMember = "GuestID";
                cmbbxGuestName.SelectedIndex = 0;

                cmbbxGuestName.DataSource = dt1;
                cmbbxGuestName.DisplayMember = "GuestName";
                cmbbxGuestName.ValueMember = "GuestID";

                // display active guest list in gridview
                clsUser obj = new clsUser();
                dt = obj.GetAssetGuestListVK();

                if (fulldataVK != null && fulldataVK.Rows.Count > 0)
                {
                    totrecordsVK = fulldataVK.Rows.Count;
                }
                else
                {
                    grdAssetGuestList.DataSource = fulldataVK;
                }
                fulldataVK = dt.Copy();              

                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);
                DisplayPageVK();
                GeneratePageButtonsVK();
                CheckBoxVK();
                AddProvideButton();

                // columns are correctly showing size are not small or large
                grdAssetGuestList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grdAssetGuestList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdAssetGuestList.AllowUserToResizeRows = false;
                grdAssetGuestList.AllowUserToResizeColumns = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void SetGuestGridColumnsVK()
        {
            grdAssetGuestList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdAssetGuestList.Columns["Check"].DisplayIndex = 0;
            grdAssetGuestList.Columns["SrNo"].DisplayIndex = 1;
            grdAssetGuestList.Columns["GuestName"].DisplayIndex = 2;
            grdAssetGuestList.Columns["RoomName"].DisplayIndex = 3;        
            grdAssetGuestList.Columns["Email"].DisplayIndex = 4;
            grdAssetGuestList.Columns["Address"].DisplayIndex = 5;
            grdAssetGuestList.Columns["ContactNo"].DisplayIndex = 6;
            grdAssetGuestList.Columns["Provide"].DisplayIndex = 7;

            grdAssetGuestList.Columns["SrNo"].HeaderText = "Sr No";
            grdAssetGuestList.Columns["GuestName"].HeaderText = "Guest Name";
            grdAssetGuestList.Columns["RoomName"].HeaderText = "Room Name";
            grdAssetGuestList.Columns["ContactNo"].HeaderText = "Contact No";
            grdAssetGuestList.Columns["Provide"].HeaderText = "Action";

            grdAssetGuestList.AllowUserToResizeColumns = false;
        }
        private void AddProvideButton()
        {
            try
            {
                // Add provide button in gridview
                if (!grdAssetGuestList.Columns.Contains("Provide"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.HeaderText = "Action";
                    imgCol.Name = "Provide";

                    // Add your resource image
                    imgCol.Image = Properties.Resources.Provide_icon;

                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;  // Fit image nicely
                    imgCol.Width = 40;  // Adjust as needed

                    grdAssetGuestList.Columns.Add(imgCol);
                }
                grdAssetGuestList.Columns["Provide"].DisplayIndex =
                grdAssetGuestList.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void grdAssetGuestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;
                // pass the guest name and open the form of provide to guest
                if (grdAssetGuestList.Columns[e.ColumnIndex].Name == "Provide")
                {
                    string guestname = grdAssetGuestList.Rows[e.RowIndex].Cells["GuestName"].Value.ToString();

                    frmAssetInventoryProvide obj = new frmAssetInventoryProvide();
                    obj.GuestNameVK = guestname;
                    obj.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void CheckBoxVK()
        {
            try
            {
                // old header checkbox remove 
                if (headerCheckBoxAB != null)
                {
                    grdAssetGuestList.Controls.Remove(headerCheckBoxAB);
                    headerCheckBoxAB.Dispose();
                    headerCheckBoxAB = null;
                }

                grdAssetGuestList.AllowUserToAddRows = false;
                grdAssetGuestList.ReadOnly = false;
                grdAssetGuestList.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdAssetGuestList.Columns)
                {
                    col.ReadOnly = col.Index != 0;

                }
                headerCheckBoxAB = new System.Windows.Forms.CheckBox();
                headerCheckBoxAB.BackColor = System.Drawing.Color.Transparent;
                System.Drawing.Rectangle rect = grdAssetGuestList.GetCellDisplayRectangle(0, -1, true);

                headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                headerCheckBoxAB.Location = new System.Drawing.Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);
                 

                grdAssetGuestList.Controls.Add(headerCheckBoxAB);
                // Scroll position maintain
                grdAssetGuestList.Scroll += (s, e) =>
                {
                    System.Drawing.Rectangle rect2 = grdAssetGuestList.GetCellDisplayRectangle(0, -1, true);

                    int x = rect2.X + (rect2.Width - headerCheckBoxAB.Width) / 2;
                    int y = rect2.Y + (rect2.Height - headerCheckBoxAB.Height) / 2;

                    headerCheckBoxAB.Location = new System.Drawing.Point(x, y);
                };

                // Column resize then position maintain
                grdAssetGuestList.ColumnWidthChanged += (s, e) =>
                {
                    System.Drawing.Rectangle rect3 = grdAssetGuestList.GetCellDisplayRectangle(0, -1, true);

                    int x = rect3.X + (rect3.Width - headerCheckBoxAB.Width) / 2;
                    int y = rect3.Y + (rect3.Height - headerCheckBoxAB.Height) / 2;

                    headerCheckBoxAB.Location = new System.Drawing.Point(x, y);
                };


                headerCheckBoxAB.CheckedChanged += (s, e1) =>
                {
                    grdAssetGuestList.EndEdit();
                    grdAssetGuestList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool chechAll = headerCheckBoxAB.Checked;

                    foreach (DataGridViewRow row in grdAssetGuestList.Rows)
                    {
                        DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (chkCell != null)
                        {
                            chkCell.Value = chechAll;
                        }
                    }
                    grdAssetGuestList.RefreshEdit();

                };
                grdAssetGuestList.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    if (grdAssetGuestList.CurrentCell is DataGridViewCheckBoxCell)

                        grdAssetGuestList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);
                if (currentpageVK < totpageVK)
                {
                    currentpageVK++;
                    DisplayPageVK();
                    GeneratePageButtonsVK();
                    SetGuestGridColumnsVK();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentpageVK > 1)
                {
                    currentpageVK--;
                    DisplayPageVK();
                    GeneratePageButtonsVK();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void GeneratePageButtonsVK()
        {
            try {
                int bwidthVK = 40;
                int bheightVK = 35;
                int spacingVK = 5;
                int startXVK = 10;
                pnlAssetGuest.Controls.Clear();

                foreach (System.Windows.Forms.Control ctr in pnlAssetGuest.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlAssetGuest.Controls.Remove(ctr);
                    }
                }
                int totalPagesVK = (int)Math.Ceiling((double)fulldataVK.Rows.Count / pagesizeVK);

                totpageVK = totalPagesVK;

                //  FOR FIXING SIZE AND POSITIONS AND SPACES IN BUTTONS FROM 1 TO N NUMBERS

                for (int i = 1; i <= totalPagesVK; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidthVK, bheightVK);
                    btnPage.Location = new Point(startXVK, 5);
                    btnPage.FillColor = (i == currentpageVK) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentpageVK) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    btnPage.Click += BtnPage_Click;

                    // ADDING CONTROLS ON PAGINATION PANEL

                    pnlAssetGuest.Controls.Add(btnPage);
                    startXVK += bwidthVK + spacingVK;
                }

                // FOR ENABLE THE PREVIOUS BUTTTON WHEN 1ST NUMBER OF PAGE IS OPEN 

                btnPrevious.Enabled = currentpageVK > 1;
                btnNext.Enabled = currentpageVK < totpageVK;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void BtnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                if (btn != null)
                {
                    int pageNumberVK = Convert.ToInt32(btn.Text);
                    currentpageVK = pageNumberVK;
                    DisplayPageVK();     // THIS METHOD DISPLAYS THE RECORDS IN DATA GRID VIEW 
                    GeneratePageButtonsVK();      // CREATE THE PAGE NUMBERS AT THE BASES OF DATATABLES RECORDS
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void DisplayPageVK()
        {
            try {
                int startIndexVK = (currentpageVK - 1) * pagesizeVK;
                DataTable dttempVK = dt.Clone();
                for (int i = startIndexVK; i < startIndexVK + pagesizeVK && i < dt.Rows.Count; i++)
                {
                    dttempVK.ImportRow(dt.Rows[i]);

                }
                grdAssetGuestList.DataSource = dttempVK;
                AddProvideButton();
                SetGuestGridColumnsVK();

                // AddProvideButton        //ensure Action column exists
                //grdAssetGuestList.Columns["Provide"].DisplayIndex =
                //    grdAssetGuestList.Columns.Count - 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToPDFVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcelVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public System.Data.DataTable GetSelectedRowsVK()
        {   
            System.Data.DataTable dt = new System.Data.DataTable();

            try
            {
                grdAssetGuestList.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                foreach (DataGridViewColumn col in grdAssetGuestList.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0
                        && col.Visible
                        && !string.IsNullOrWhiteSpace(col.Name)
                        && !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase)
                        && !isIconCol)
                    {
                        dt.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                foreach (DataGridViewRow row in grdAssetGuestList.Rows)
                {
                    if (row.Cells.Count > 0
                        && row.Cells[0].Value != null
                        && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dt.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grdAssetGuestList.Columns.Contains(col.ColumnName))
                            {
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            }
                            else
                            {
                                dr[col.ColumnName] = DBNull.Value;
                            }
                        }

                        dt.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                // File.AppendAllText("error_log.txt", DateTime.Now + " - " + ex.ToString());

                MessageBox.Show("Error while selecting rows: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Return empty table instead of breaking
                return dt;
            }

            return dt;
        }

        public void ExportToPDFVK()
        {
            try {
                System.Data.DataTable dt = GetSelectedRowsVK();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found to export!", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string> { "Action" };

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathAM = saveFileDialog.FileName;

                using (FileStream fs = new FileStream(filePathAM, FileMode.Create))
                {
                    iTextSharp.text.Document docAB = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
                    PdfWriter writerAB = PdfWriter.GetInstance(docAB, fs);
                    docAB.Open();

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblAssetGuest.Text,
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    docAB.Add(title);

                    iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
                    date.Alignment = Element.ALIGN_RIGHT;
                    date.SpacingAfter = 10;
                    docAB.Add(date);

                    int visibleColumnCount = dt.Columns.Cast<DataColumn>().Count(c => !columnsToSkip.Contains(c.ColumnName));
                    PdfPTable table = new PdfPTable(visibleColumnCount);
                    table.WidthPercentage = 100;

                    foreach (DataColumn column in dt.Columns)
                    {
                        if (columnsToSkip.Contains(column.ColumnName))
                            continue;

                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                                                   FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;

                        table.AddCell(cell);
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (DataColumn column in dt.Columns)
                        {
                            if (columnsToSkip.Contains(column.ColumnName))
                                continue;

                            string cellValue = row[column].ToString();

                            if (column.ColumnName == "EnquiryDate")
                            {
                                if (DateTime.TryParse(cellValue, out DateTime enquiryDate))
                                {
                                    cellValue = enquiryDate.ToString("dd-MM-yyyy");
                                }
                            }

                            table.AddCell(new Phrase(cellValue,
                                                     FontFactory.GetFont("Arial", 10)));
                        }
                    }

                    docAB.Add(table);
                    docAB.Close();

                }
                MessageBox.Show("PDF File Saved Successfully!\n" + filePathAM,
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void ExportToExcelVK()
        {
            try
            {
                System.Data.DataTable dt = GetSelectedRowsVK();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string> { "Action" };

                System.Data.DataTable filteredDt = new System.Data.DataTable();

                foreach (DataColumn col in dt.Columns)
                {
                    if (!columnsToSkip.Contains(col.ColumnName))
                    {
                        if (col.ColumnName == "EnquiryDate")
                        {
                            filteredDt.Columns.Add(col.ColumnName, typeof(string));
                        }
                        else
                        {
                            filteredDt.Columns.Add(col.ColumnName, col.DataType);
                        }
                    }
                }

                foreach (DataRow row in dt.Rows)
                {
                    bool isEmpty = row.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString()));
                    if (!isEmpty)
                    {
                        DataRow newRow = filteredDt.NewRow();
                        foreach (DataColumn col in filteredDt.Columns)
                        {
                            string columnName = col.ColumnName;
                            object originalValue = row[columnName];

                            if (columnName == "EnquiryDate" && originalValue != DBNull.Value)
                            {
                                if (DateTime.TryParse(originalValue.ToString(), out DateTime enquiryDate))
                                {

                                    newRow[columnName] = enquiryDate.ToString("dd-MM-yyyy");
                                }
                                else
                                {
                                    newRow[columnName] = originalValue.ToString(); // Fallback
                                }
                            }
                            else
                            {
                                newRow[columnName] = originalValue;
                            }
                        }
                        filteredDt.Rows.Add(newRow);
                    }
                }

                if (filteredDt.Rows.Count == 0)
                {
                    MessageBox.Show("No valid data found to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook (.xlsx)|.xlsx",
                    FileName = "SelectedGuestData.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Selected Rows");

                        // Title
                        ws.Cell(1, 1).Value = lblAssetGuest.Text;
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, filteredDt.Columns.Count).Merge();

                        // Date
                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Range(2, 1, 2, filteredDt.Columns.Count).Merge();

                        ws.Row(3).Height = 10;

                        ws.Cell(4, 1).InsertTable(filteredDt, "GuestData", true);

                        // Header styling
                        var header = ws.Range(4, 1, 4, filteredDt.Columns.Count);
                        header.Style.Font.Bold = true;
                        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        header.Style.Fill.BackgroundColor = XLColor.LightGray;

                        ws.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }
                    MessageBox.Show("Selected rows exported to Excel successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try {
               // pnlAssetguestfilter.Visible = false;
                //cmbbxGuestName.SelectedValue = "";

                if (headerCheckBoxAB != null)
                    headerCheckBoxAB.Checked = false;

                clsUser obj = new clsUser();
                dt = obj.GetAssetGuestListVK();

                cmbbxGuestName.SelectedIndexChanged -= cmbbxGuestName_SelectedIndexChanged;
                cmbbxGuestName.SelectedIndex = 0;   // Default first item
                cmbbxGuestName.SelectedIndexChanged += cmbbxGuestName_SelectedIndexChanged;

                fulldataVK = dt.Copy();            // FULL DATA RESET
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
                SetGuestGridColumnsVK();

                txtSearchBox.Text = null;
                txtSearchBox.PlaceholderText = "Search Here...";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            try {
                // Toggle visibility
                pnlAssetguestfilter.Visible = !pnlAssetguestfilter.Visible;

                if (pnlAssetguestfilter.Visible)
                {
                    // When panel visible
                    pctFilter.Text = "Hide Filter";
                    pctFilter.FillColor = System.Drawing.Color.FromArgb(0, 120, 215); // Blue
                    pctFilter.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    // When panel hidden
                    pctFilter.Text = "Show Filter";
                    pctFilter.FillColor = System.Drawing.Color.White; // White button
                    pctFilter.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ApplySearch(txtSearchBox.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void ApplySearch(string searchText)
        {
            try {
                if (fulldataVK == null)
                    return;

                searchText = searchText.Trim().Replace("'", "''");

                DataView dv = new DataView(fulldataVK);

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dt = fulldataVK.Copy();   // search box empty→ full data
                }
                else
                {
                    string filter = "";

                    foreach (DataColumn col in fulldataVK.Columns)
                    {
                        filter += $"CONVERT([{col.ColumnName}], System.String) LIKE '%{searchText}%' OR ";
                    }

                    filter = filter.Substring(0, filter.Length - 4);

                    dv.RowFilter = filter;

                    dt = dv.ToTable();      // filtered result
                }
                //fulldataVK = dt.Copy();
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);
                // search then pagination reset
                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void cmbbxGuestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                clsUser obj = new clsUser();
                string name = cmbbxGuestName.Text;
                obj.GuestNameVK = name;
                DataTable dtfiltered = obj.GetAGLVK();
                dt = dtfiltered.Copy();
                grdAssetGuestList.DataSource = dt;

                // pagination reset
                fulldataVK = dt.Copy();
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
                SetGuestGridColumnsVK();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}

