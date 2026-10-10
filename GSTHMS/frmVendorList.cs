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
    public partial class frmVendorList : Form
    {
        public string VendorNameVK;
        public frmVendorList()
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
        private CheckBox headerCheckBoxAB;

        System.Data.DataTable dt = new DataTable();
        private void frmVendorList_Load(object sender, EventArgs e)
        {
            try 
            {
                grdVendorList.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdVendorList.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //for grid text size 11
                this.grdVendorList.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                this.grdVendorList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                //for show names in icon
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Exel");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                //    toolTip1.SetToolTip(pctDelete, "Delete Data");
                toolTip1.SetToolTip(pctFilter, "Filters");

                //grid horizontal and vertical border lines
                grdVendorList.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdVendorList.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdVendorList.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdVendorList.GridColor = System.Drawing.Color.Gray;

              //  pnlVendorFilter.Visible = false;

                // Display Vendor Name on combobox on vendorlist form filter
                clsUser obj1 = new clsUser();
                DataTable dt1 = obj1.GetVendorNmVK();

                DataRow dr = dt1.NewRow();
                dr["VendorID"] = 0;
                dr["VendorName"] = "-- Select Vendor name --";
                dt1.Rows.InsertAt(dr, 0);

                cmbbxVendorName.DataSource = dt1;
                cmbbxVendorName.DisplayMember = "VendorName";
                cmbbxVendorName.ValueMember = "VendorID";
                cmbbxVendorName.SelectedIndex = 0;

                cmbbxVendorName.DataSource = dt1;
                cmbbxVendorName.DisplayMember = "VendorName";
                cmbbxVendorName.ValueMember = "VendorID";

                //For Display vendor List on GridView
                clsUser obj = new clsUser();
                dt = obj.GetVendorListVK();

                if (dt != null && dt.Rows.Count > 0)
                {
                    grdVendorList.DataSource = dt;
                }

                if (fulldataVK != null && fulldataVK.Rows.Count > 0)
                {
                    //totrecordsVK = fulldataVK.Rows.Count;

                    //DisplayPageVK();
                    //GeneratePageButtonsVK();
                    //CheckBoxVK();
                }
                fulldataVK = dt.Copy();

                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);
                DisplayPageVK();
                GeneratePageButtonsVK();
                CheckBoxVK();

                // columns are correctly showing size are not small or large
                grdVendorList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                grdVendorList.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdVendorList.AllowUserToResizeRows = false;
                grdVendorList.AllowUserToResizeColumns = false;

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
                grdVendorList.DataSource = dttempVK;
                SetVendorGridOrder();

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
                pnlFlow.Controls.Clear();

                foreach (System.Windows.Forms.Control ctr in pnlFlow.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlFlow.Controls.Remove(ctr);
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

                    pnlFlow.Controls.Add(btnPage);
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
        private void btnViewAllVendor_Click(object sender, EventArgs e)
        {
            try {
                frmVendorList obj = new frmVendorList();
                obj.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void btnViewAllInventory_Click(object sender, EventArgs e)
        {
            try {
                frmInventoryList obj = new frmInventoryList();
                obj.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try {
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

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try {
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
        private void cmbbxVendorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                clsUser obj = new clsUser();
                string name = cmbbxVendorName.Text;
                obj.VendorNameVK = name;
                DataTable dtfiltered = obj.GetVendorFilterVK();
                dt = dtfiltered.Copy();
                grdVendorList.DataSource = dt;

                // pagination reset
                fulldataVK = dt.Copy();
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
                SetVendorGridOrder();
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
                grdVendorList.AllowUserToAddRows = false;
                grdVendorList.ReadOnly = false;
                grdVendorList.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdVendorList.Columns)
                {
                    col.ReadOnly = col.Index != 0;
                }

                headerCheckBoxAB = new System.Windows.Forms.CheckBox();
                headerCheckBoxAB.BackColor = System.Drawing.Color.Transparent;
                System.Drawing.Rectangle rect = grdVendorList.GetCellDisplayRectangle(0, -1, true);


                headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                headerCheckBoxAB.Location = new System.Drawing.Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                grdVendorList.Controls.Add(headerCheckBoxAB);

                headerCheckBoxAB.CheckedChanged += (s, e1) =>
                {
                    grdVendorList.EndEdit();
                    grdVendorList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    bool chechAll = headerCheckBoxAB.Checked;

                    foreach (DataGridViewRow row in grdVendorList.Rows)
                    {
                        DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                        if (chkCell != null)
                        {
                            chkCell.Value = chechAll;
                        }
                    }
                    grdVendorList.RefreshEdit();

                };
                grdVendorList.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    if (grdVendorList.CurrentCell is DataGridViewCheckBoxCell)

                        grdVendorList.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void pctPDF_Click(object sender, EventArgs e)
        {
            try {
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

                grdVendorList.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                // Add columns except checkbox, SrNo, image, button
                foreach (DataGridViewColumn col in grdVendorList.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0 &&
                        col.Visible &&
                        !string.IsNullOrWhiteSpace(col.Name) &&
                        !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase) &&
                        !isIconCol)
                    {
                        dt.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                foreach (DataGridViewRow row in grdVendorList.Rows)
                {
                    if (row.Cells.Count > 0 &&
                        row.Cells[0].Value != null &&
                        Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dt.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grdVendorList.Columns.Contains(col.ColumnName))
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            else
                                dr[col.ColumnName] = DBNull.Value;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong during processing!\n\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return null; // VERY IMPORTANT
            }
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

                List<string> columnsToSkip = new List<string> { };

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

                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblVendorList.Text,
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
            try {
                System.Data.DataTable dt = GetSelectedRowsVK();

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string> { };

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
                        ws.Cell(1, 1).Value = lblVendorList.Text;
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
            try
            {
               // pnlVendorFilter.Visible = false;

                txtSearchBox.Text = null;
                txtSearchBox.PlaceholderText = "Search here...";

                if (headerCheckBoxAB != null)
                    headerCheckBoxAB.Checked = false;

                cmbbxVendorName.SelectedIndexChanged -= cmbbxVendorName_SelectedIndexChanged;
                cmbbxVendorName.SelectedIndex = 0;   // Default first item
                cmbbxVendorName.SelectedIndexChanged += cmbbxVendorName_SelectedIndexChanged;

                clsUser obj = new clsUser();
                dt = obj.GetVendorListVK();

                fulldataVK = dt.Copy();            // FULL DATA RESET
                totrecordsVK = fulldataVK.Rows.Count;
                totpageVK = (int)Math.Ceiling((double)totrecordsVK / pagesizeVK);

                currentpageVK = 1;
                DisplayPageVK();
                GeneratePageButtonsVK();
                SetVendorGridOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = grdVendorList.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdVendorList.Rows[i];


                    if (row.IsNewRow) continue;


                    DataGridViewCheckBoxCell chk = row.Cells["Check"] as DataGridViewCheckBoxCell;

                    if (chk != null && Convert.ToBoolean(chk.Value) == true)
                    {
                        grdVendorList.Rows.RemoveAt(i);
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
                // Toggle visibility
                pnlVendorFilter.Visible = !pnlVendorFilter.Visible;

                if (pnlVendorFilter.Visible)
                {
                    //  When panel visible
                    pctFilter.Text = "Hide Filter";
                    pctFilter.FillColor = System.Drawing.Color.FromArgb(0, 120, 215); // Blue
                    pctFilter.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    //  When panel hidden
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
                SetVendorGridOrder();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong during processing!");
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        public void SetVendorGridOrder()
        {
            grdVendorList.Columns["Check"].DisplayIndex = 0;
            grdVendorList.Columns["SrNo"].DisplayIndex = 1;
            grdVendorList.Columns["VendorName"].DisplayIndex = 2;
            grdVendorList.Columns["Address"].DisplayIndex = 3;
            grdVendorList.Columns["Contact_No"].DisplayIndex = 4;


            // HEADER TEXT

            grdVendorList.Columns["SrNo"].HeaderText = "Sr No";
            grdVendorList.Columns["VendorName"].HeaderText = "Vendor Name";
            grdVendorList.Columns["Contact_No"].HeaderText = "Contact No";
        }
    }
}
