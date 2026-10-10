using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
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
using CheckBox = System.Windows.Forms.CheckBox;

namespace GSTHMS
{
    public partial class frmGuestList : Form
    {
        public frmGuestList()
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

        private void frmGuestList_Load(object sender, EventArgs e)
        {
                MainFormLoadVK();
        }
        public void MainFormLoadVK()
        {
            try
            {
                grdGuestList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdGuestList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //for grid text size 11
                this.grdGuestList.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                this.grdGuestList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                //for show names in icon
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Exel");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                //  toolTip1.SetToolTip(pctDelete, "Delete Data");
                toolTip1.SetToolTip(pctFilter, "Filters");

                //grid horizontal and vertical border lines
                grdGuestList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdGuestList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdGuestList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdGuestList.GridColor = System.Drawing.Color.Gray;

               // pnlGuestFilter.Visible = false;

                // Display guest Name on combobox on guestlist form filter
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

               // display active guest list in grid view
               clsUser obj = new clsUser();
               dt = obj.GetGuestListVK();

               if (fulldataVK != null && fulldataVK.Rows.Count > 0)
               {
                 totrecordsVK = fulldataVK.Rows.Count;
               }
               else
               {
                 grdGuestList.DataSource = fulldataVK;
               }
               fulldataVK = dt.Copy();

               totrecordsVK = fulldataVK.Rows.Count;
               totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

               DisplayPageVK();
               GeneratePageButtonsVK();
               CheckBoxVK();
               AddProvideButtonVK();
                SetGuestGridSizeVK();

                // columns are correctly showing size are not small or large
                grdGuestList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                grdGuestList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdGuestList.AllowUserToResizeRows = false;
                grdGuestList.AllowUserToResizeColumns = false;
                grdGuestList.RowTemplate.Height = 35;

                //grdGuestList.AutoGenerateColumns = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void SetGuestGridSizeVK()
        {
            grdGuestList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            grdGuestList.Columns["Provide"].HeaderText = "Action";

            grdGuestList.Columns["SrNo"].HeaderText = "Sr No";
            grdGuestList.Columns["GuestName"].HeaderText = "Guest Name";
            grdGuestList.Columns["RoomName"].HeaderText = "Room Name";
            grdGuestList.Columns["ContactNo"].HeaderText = "Contact No";

            // FIX COLUMN ORDER
            grdGuestList.Columns["Check"].DisplayIndex = 0;
            grdGuestList.Columns["SrNo"].DisplayIndex = 1;
            grdGuestList.Columns["GuestName"].DisplayIndex = 2;
            grdGuestList.Columns["RoomName"].DisplayIndex = 3;
            grdGuestList.Columns["Email"].DisplayIndex = 4;
            grdGuestList.Columns["Address"].DisplayIndex = 5;
            grdGuestList.Columns["ContactNo"].DisplayIndex = 6;
            grdGuestList.Columns["Provide"].DisplayIndex = 7;

            grdGuestList.AllowUserToResizeColumns = false;
        }
        private void AddProvideButtonVK()
        {
            // Add provide button in gridview
            try 
            {
                if (!grdGuestList.Columns.Contains("Provide"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn();
                    imgCol.HeaderText = "Action";
                    imgCol.Name = "Provide";

                    // Add your resource image
                    imgCol.Image = Properties.Resources.Provide_icon;
                    imgCol.ImageLayout = DataGridViewImageCellLayout.Zoom;  // Fit image nicely
                    imgCol.Width = 40;  // Adjust as needed

                    imgCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    imgCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    grdGuestList.Columns.Add(imgCol);
                }
                //  ALWAYS keep Action column LAST
                grdGuestList.Columns["Provide"].DisplayIndex =
                grdGuestList.Columns.Count - 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void grdGuestList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                // Header
                if (e.RowIndex < 0)
                    return;

                // Provide icon check click
                if (grdGuestList.Columns[e.ColumnIndex].Name == "Provide")
                {
                    string guestname = grdGuestList.Rows[e.RowIndex].Cells["GuestName"].Value.ToString();

                    frmProvideToGuest obj = new frmProvideToGuest();
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
            //for checkbox
            try 
            {
                // old header checkbox remove 
                if (headerCheckBoxAB != null)
                {
                    grdGuestList.Controls.Remove(headerCheckBoxAB);
                    headerCheckBoxAB.Dispose();
                    headerCheckBoxAB = null;
                }

                grdGuestList.AllowUserToAddRows = false;
                grdGuestList.ReadOnly = false;
                grdGuestList.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdGuestList.Columns)
                {
                    col.ReadOnly = col.Index != 0;

                }
                headerCheckBoxAB = new System.Windows.Forms.CheckBox();
                headerCheckBoxAB.BackColor = System.Drawing.Color.Transparent;
                System.Drawing.Rectangle rect = grdGuestList.GetCellDisplayRectangle(0, -1, true);

                headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                headerCheckBoxAB.Location = new System.Drawing.Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                grdGuestList.Controls.Add(headerCheckBoxAB);

                headerCheckBoxAB.CheckedChanged += (s, e1) =>
                {
                    grdGuestList.EndEdit();
                    grdGuestList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool chechAll = headerCheckBoxAB.Checked;

                    foreach (DataGridViewRow row in grdGuestList.Rows)
                    {
                        DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (chkCell != null)
                        {
                            chkCell.Value = chechAll;
                        }
                    }
                    grdGuestList.RefreshEdit();

                };
                grdGuestList.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    if (grdGuestList.CurrentCell is DataGridViewCheckBoxCell)

                        grdGuestList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };

                grdGuestList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdGuestList.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdGuestList.Columns[0].Width = 40;
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
                DataTable dttempVK = fulldataVK.Clone();
                for (int i = startIndexVK; i < startIndexVK + pagesizeVK && i < fulldataVK.Rows.Count; i++)
                {
                    dttempVK.ImportRow(fulldataVK.Rows[i]);

                }
                grdGuestList.DataSource = dttempVK;

                CheckBoxVK();
                AddProvideButtonVK();
                SetGuestGridSizeVK();
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
                pnlGuest.Controls.Clear();

                foreach (System.Windows.Forms.Control ctr in pnlGuest.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlGuest.Controls.Remove(ctr);
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

                    pnlGuest.Controls.Add(btnPage);
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
            try {
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
                }
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
            try {
                System.Data.DataTable dt = new System.Data.DataTable();

                grdGuestList.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                foreach (DataGridViewColumn col in grdGuestList.Columns)
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

                foreach (DataGridViewRow row in grdGuestList.Rows)
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


                            if (grdGuestList.Columns.Contains(col.ColumnName))
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
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
               // return dt;
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

                List<string> columnsToSkip = new List<string> { "Actions" };

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

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblGuestList.Text,
                        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    docAB.Add(title);

                    iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy "),
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
            try {
                System.Data.DataTable dt = GetSelectedRowsVK();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string> { "Actions" };

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
                        ws.Cell(1, 1).Value = lblGuestList.Text;
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
        private void cmbbxGuestName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                clsUser obj = new clsUser();
                string name = cmbbxGuestName.Text;
                obj.GuestNameVK = name;
                DataTable dtfiltered = obj.VGuestListVK();
                dt = dtfiltered.Copy();
                grdGuestList.DataSource = dt;

                fulldataVK = dt.Copy();
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

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
        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try 
            {
               // pnlGuestFilter.Visible = false;

                // cmbbxGuestName.SelectedValue = "";

                if (headerCheckBoxAB != null)
                    headerCheckBoxAB.Checked = false;

                clsUser obj = new clsUser();
                dt = obj.GetGuestListVK();

                cmbbxGuestName.SelectedIndexChanged -= cmbbxGuestName_SelectedIndexChanged;
                // cmbbxGuestName.SelectedIndex = 0;   // Default first item
                cmbbxGuestName.SelectedIndexChanged += cmbbxGuestName_SelectedIndexChanged;

                fulldataVK = dt.Copy();            // FULL DATA RESET
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
                CheckBoxVK();
                AddProvideButtonVK();
                SetGuestGridSizeVK();

                txtSearchBox.Text = null;
                txtSearchBox.PlaceholderText = "Search here...";
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void pctDelete_Click(object sender, EventArgs e)
        {
            try {
                for (int i = grdGuestList.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdGuestList.Rows[i];


                    if (row.IsNewRow) continue;


                    DataGridViewCheckBoxCell chk = row.Cells["Check"] as DataGridViewCheckBoxCell;

                    if (chk != null && Convert.ToBoolean(chk.Value) == true)
                    {

                        grdGuestList.Rows.RemoveAt(i);
                        MessageBox.Show("delete successfully...");
                    }
                }
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
                pnlGuestFilter.Visible = !pnlGuestFilter.Visible;

                if (pnlGuestFilter.Visible)
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
                fulldataVK = dt.Copy();
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
        private void guna2CirclePictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                // for back
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
   
