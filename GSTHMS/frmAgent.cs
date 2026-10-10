using ClosedXML.Excel;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
//using Excel = Microsoft.Office.Interop.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
//using System.Xml.Linq;
using static Guna.UI2.Native.WinApi;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CheckBox = System.Windows.Forms.CheckBox; 
namespace GSTHMS
{
    public partial class frmAgent : Form
    {
        public DateTime formDateSJ { get; set; }
        public DateTime toDateSJ { get; set; }
        public int totalRecordsSJ = 0;
        public int totalPagesSJ = 0;
        public int pageSizeSJ = 10;
        public int currentPageSJ = 1;
        public int pageNumberSJ = 3;
        public System.Data.DataTable dt = new System.Data.DataTable();
        public string A_Name;
        public DataTable FullData;
       // DataTable dt = new DataTable();
        public frmAgent()
        {
            InitializeComponent();
        }
       
       // DataTable fulldata;
        private int page;
        private int pagesize;

            private void Form1_Load(object sender, EventArgs e)
            {
                try
                {
                pnlFilters.Show();
                grdDisplay.EnableHeadersVisualStyles = false;
                grdDisplay.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

                //grid text font size
                this.grdDisplay.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
                this.grdDisplay.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);

                //grid horizontal and vertical border lines
                grdDisplay.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdDisplay.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdDisplay.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdDisplay.GridColor = System.Drawing.Color.Gray;

                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To ExCel");
                //toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
                // toolTip1.SetToolTip(pctDelete, "Delete Data");
                toolTip1.SetToolTip(pctFilter, "Filters");
                
            
                    //set the forground color of the control pctFilter                       
                    pctFilter.ForeColor = System.Drawing.Color.Black;

                    //set the text displayed by the control named pctFilter              
                    pctFilter.Text = "Show Filter";
                    clsUser obj1 = new clsUser();
                   //pctFilter.show();
               


                dt = obj1.FetchDataSJ();
               
                totalRecordsSJ = dt.Rows.Count;
                totalPagesSJ = (int)Math.Ceiling((Double)totalRecordsSJ / pageSizeSJ);
                LoadPageSJ();
                CreatePageButtonSJ();
                FetchAgentDetailsSJ();

                    //This hides the gender column in the gridveiw
                    if (grdDisplay.Columns.Contains("Gender"))
                        grdDisplay.Columns["Gender"].Visible = false;

                    //this creates a new image colmn for the gridview
                    DataGridViewImageColumn actionColumn = new DataGridViewImageColumn();
                    actionColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    actionColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    //set the column tittle to action
                    actionColumn.HeaderText = "Action";
                    actionColumn.Name = "Action";

                    //it set the image that will display every row
                    try
                    {
                        actionColumn.Image = Properties.Resources.view_icon;
                    }
                    catch
                    {
                        // ignore if resource not found
                    }

                    // Add only if not already added
                    if (!grdDisplay.Columns.Contains("Action"))
                        grdDisplay.Columns.Add(actionColumn);

               
                    SetReadOnlyColumnsSJ();
                    CheckBoxSJ();
                    grdDisplay.AllowUserToResizeColumns = false;
                    grdDisplay.AllowUserToResizeRows = false;
                    grdDisplay.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                    grdDisplay.Columns["AgentName"].HeaderText = "Agent Name";
                    grdDisplay.Columns["ContactNo"].HeaderText = "Contact No";
                    grdDisplay.Columns["EmailID"].HeaderText = "Email ID";
                    grdDisplay.Columns["JoinDate"].HeaderText = "Join Date";

                    if (grdDisplay.Columns.Contains("Commission_Rs"))
                    {
                        grdDisplay.Columns["Commission_Rs"].Visible = false;
                    }
            }
            catch (Exception ex)
                {
                    MessageBox.Show("Error during form load: " + ex.Message, "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        public void LoadPageSJ()
        {
            try
            {
                int startIndex = (currentPageSJ - 1) * pageSizeSJ;


                System.Data.DataTable dtPage = dt.Clone();

                for (int i = startIndex; i < startIndex + pageSizeSJ && i < dt.Rows.Count; i++)
                {
                    dtPage.ImportRow(dt.Rows[i]);
                }
                grdDisplay.DataSource = dtPage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CreatePageButtonSJ()
        {
            try
            {
                int bwidth = 40;
                int bheight = 35;
                int spacing = 5;
                int start = 10;
                pnlCardInfo.Controls.Clear();

                foreach (System.Windows.Forms.Control ctr in pnlCardInfo.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlCardInfo.Controls.Remove(ctr);
                    }
                }
                int totalpages = (int)Math.Ceiling((double)dt.Rows.Count / pageSizeSJ);
                totalPagesSJ = totalpages;

                for (int i = 1; i <= totalpages; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new System.Drawing.Size(bwidth, bheight);
                    btnPage.Location = new System.Drawing.Point(start, 5);
                    btnPage.FillColor = (i == currentPageSJ) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentPageSJ) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    btnPage.Click += btnPage_Click;
                    pnlCardInfo.Controls.Add(btnPage);
                    start += bwidth + spacing;


                }
                btnPrevious.Enabled = currentPageSJ > 1;
                btnNext.Enabled = currentPageSJ < totalPagesSJ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void UpdateButtonState()
        {
            try
            {
                btnPrevious.Enabled = currentPageSJ > 1;
                btnNext.Enabled = currentPageSJ < totalPagesSJ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating button state: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                if (btn != null)

                {
                    int pageNumber = Convert.ToInt32(btn.Text);
                    currentPageSJ = pageNumber;
                    LoadPageSJ();
                    CreatePageButtonSJ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void grdDisplay_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                try
                {
                    if (e.RowIndex < 0) return;

                    if (grdDisplay.Columns[e.ColumnIndex].Name == "Action")
                    {
                        DataRow selectedRow = ((DataRowView)grdDisplay.Rows[e.RowIndex].DataBoundItem).Row;
                        A_Name = selectedRow["AgentName"].ToString();

                        frmAgentDetails obj = new frmAgentDetails(A_Name);
                        obj.Show();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error handling grid cell click: " + ex.Message, "Grid Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

            //Fetch Agent Details
        public void FetchAgentDetailsSJ()
        {
            
            try
            {
                clsUser obj = new clsUser();
                DataTable dt5 = obj.FetchDataSJ();
                grdDisplay.DataSource = dt5;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching agent details: " + ex.Message, "Fetch Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            private void SetReadOnlyColumnsSJ()
            {
                try
                {
                    if (grdDisplay.Columns.Contains("AgentName"))
                        grdDisplay.Columns["AgentName"].ReadOnly = true;
                    //if (grdDisplay.Columns.Contains("Commission_Rs"))
                    //    grdDisplay.Columns["Commission_Rs"].ReadOnly = true;
                    if (grdDisplay.Columns.Contains("ContactNo"))
                        grdDisplay.Columns["ContactNo"].ReadOnly = true;
                    if (grdDisplay.Columns.Contains("EmailID"))
                        grdDisplay.Columns["EmailID"].ReadOnly = true;
                    if (grdDisplay.Columns.Contains("JoinDate"))
                        grdDisplay.Columns["JoinDate"].ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error setting read-only columns: " + ex.Message, "Column Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void LoadDocumentsSJ()
            {
                try
                {
                    // Note: original logic used if (grdDisplay.SelectedRows.Count < 0) which never true.
                    // Keeping similar logic but using correct selection check.
                    if (grdDisplay.SelectedRows.Count > 0)
                    {
                        string AgentName = grdDisplay.SelectedRows[0].Cells["AgentName"].Value?.ToString();
                        if (!string.IsNullOrEmpty(AgentName))
                        {
                            clsUser obj = new clsUser();
                            obj.AgentCodeSJ = AgentName;
                            DataTable dtt = obj.GetDocumentSJ();
                            grdDisplay.DataSource = dtt;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading documents: " + ex.Message, "Load Documents Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            public void GetSelectedRowsSJ()
            {
                try
                {
                    dt = new DataTable();

                    string[] allowedColumns = {
                    "SrNo",
                    "AgentName",     
                    "ContactNo",
                    "EmailID",
                    "JoinDate"
                };

                    // Create DataTable columns
                    foreach (string col in allowedColumns)
                    {
                        if (!dt.Columns.Contains(col))
                            dt.Columns.Add(col);
                    }

                    grdDisplay.EndEdit();

                    // STEP: Detect checkbox column here
                    int checkBoxColumnIndex = -1;
                    foreach (DataGridViewColumn col in grdDisplay.Columns)
                    {
                        if (col is DataGridViewCheckBoxColumn)
                        {
                            checkBoxColumnIndex = col.Index;
                            break;
                        }
                    }

                    if (checkBoxColumnIndex == -1)
                    {
                        MessageBox.Show("Checkbox column not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int srNoCounter = 1;

                    // Now loop through rows using checkBoxColumnIndex
                    foreach (DataGridViewRow row in grdDisplay.Rows)
                    {
                        bool isSelected = false;
                        try
                        {
                            var cellVal = row.Cells[checkBoxColumnIndex].Value;
                            if (cellVal != null)
                            {
                                // Some values can be "True"/"False" or boolean
                                isSelected = Convert.ToBoolean(cellVal);
                            }
                        }
                        catch
                        {
                            isSelected = false;
                        }

                        if (isSelected)
                        {
                            DataRow dr = dt.NewRow();

                            for (int i = 0; i < allowedColumns.Length; i++)
                            {
                                string colName = allowedColumns[i];
                                if (colName == "SrNo")
                                {
                                    dr[i] = srNoCounter;
                                }
                                else
                                {
                                    try
                                    {
                                        dr[i] = row.Cells[colName].Value?.ToString() ?? "";
                                    }
                                    catch
                                    {
                                        dr[i] = "";
                                    }
                                }
                            }

                            dt.Rows.Add(dr);
                            srNoCounter++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting selected rows: " + ex.Message, "Selection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            ///////////////////For Excel//////////////////////
            public void ExportToExcelFileSJ()
            {
                try
                {
                    GetSelectedRowsSJ();

                if (dt == null || dt.Rows.Count == 0)
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

                            // Add a title
                            try
                            {
                                ws.Cell(1, 1).Value = lblAgentDetails.Text;
                            }
                            catch
                            {
                                ws.Cell(1, 1).Value = "Agent Details";
                            }

                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Font.FontSize = 16;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            ws.Range(1, 1, 1, dt.Columns.Count).Merge();

                            // Add current system date below title
                            ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                            ws.Cell(2, 1).Style.Font.Italic = true;
                            ws.Range(2, 1, 2, dt.Columns.Count).Merge();

                            // Add DataTable to worksheet (starting from row 4)
                            ws.Cell(4, 1).InsertTable(dt);

                            // Format header row
                            var header = ws.Range(4, 1, 4, dt.Columns.Count);
                            header.Style.Font.Bold = true;
                            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            // Auto adjust all columns
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
                    MessageBox.Show("Excel export failed: " + ex.Message, "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void pctExcel_Click(object sender, EventArgs e)
            {
                try
                {
                    ExportToExcelFileSJ();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in Excel click handler: " + ex.Message, "Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// ////////////////////////For PDF/////////////////////
            public void ConvertToPDFSJ()
            {
                try
                {
                    GetSelectedRowsSJ(); // DataTable dt

                    // No selection
                    if (dt == null || dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row to export!",
                            "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Save dialog
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                    saveFileDialog.Title = "Save PDF File";
                    saveFileDialog.FileName = "SelectedRows.pdf";

                    if (saveFileDialog.ShowDialog() != DialogResult.OK)
                        return;

                    string filePathSJ = saveFileDialog.FileName;

                    // Create PDF document
                    using (FileStream fs = new FileStream(filePathSJ, FileMode.Create, FileAccess.Write))
                    {

                    //Document docSJ = new Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);

                    iTextSharp.text.Document docSJ =
                     new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);

                    PdfWriter writer = PdfWriter.GetInstance(docSJ, fs);
                        docSJ.Open();

                    // ******** TITLE ********
                    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(
                            lblAgentDetails.Text ?? "Agent Details",
                            new iTextSharp.text.Font(
                                iTextSharp.text.Font.FontFamily.HELVETICA,
                                16,
                                iTextSharp.text.Font.BOLD
                            )
                        );
                        title.Alignment = Element.ALIGN_CENTER;
                        title.SpacingAfter = 10;
                        docSJ.Add(title);

                        // ******** DATE WITHOUT TIME ********
                        iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph(
                            "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                            new iTextSharp.text.Font(
                                iTextSharp.text.Font.FontFamily.HELVETICA,
                                10,
                                iTextSharp.text.Font.ITALIC
                            )
                        );
                        date.Alignment = Element.ALIGN_RIGHT;
                        date.SpacingAfter = 10;
                        docSJ.Add(date);

                        // ******** TABLE ********
                        PdfPTable table = new PdfPTable(dt.Columns.Count);
                        table.WidthPercentage = 100;

                        // Header row
                        foreach (DataColumn column in dt.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(
                                column.ColumnName,
                                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)
                            ));
                            headerCell.BackgroundColor = new BaseColor(230, 230, 230);
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.Padding = 5;
                            table.AddCell(headerCell);
                        }

                        // Data rows
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn col in dt.Columns)
                            {
                                string cellValue = row[col].ToString();

                                //// Add ₹ symbol to specific columns
                                //if (col.ColumnName == "Commission_Rs" ||
                                //    col.ColumnName == "Cost")
                                //{
                                //    cellValue = "₹ " + cellValue;
                                //}

                                PdfPCell dataCell = new PdfPCell(new Phrase(
                                    cellValue,
                                    FontFactory.GetFont("Arial", 10)
                                ));
                                dataCell.Padding = 5;
                                dataCell.HorizontalAlignment = Element.ALIGN_LEFT;

                                table.AddCell(dataCell);
                            }
                        }

                        docSJ.Add(table);
                        docSJ.Close();
                        writer.Close();
                    }

                    MessageBox.Show("PDF File Saved Successfully!\n" + filePathSJ,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF export failed: " + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void pctFilter_Click(object sender, EventArgs e)
            {
                try
                {
                    // Toggle visibility
                    pnlFilters.Visible = !pnlFilters.Visible;

                    if (pnlFilters.Visible)
                    {
                        // 🔹 When panel visible
                        pctFilter.Text = "Hide Filter";
                        pctFilter.FillColor = System.Drawing.Color.FromArgb(0, 120, 215); // Blue
                        pctFilter.ForeColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        // 🔹 When panel hidden
                        pctFilter.Text = "Show Filter";
                        pctFilter.FillColor = System.Drawing.Color.White; // White button
                        pctFilter.ForeColor = System.Drawing.Color.Black;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error toggling filter: " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void pctRefresh_Click(object sender, EventArgs e)
            {
                try
                {
                FilterGridByDateSJ();
                LoadPageSJ();  
                CreatePageButtonSJ();

                // Clear Search Box
                txtSearchBox.Text = "";
                 
                // Clear Filter on DataGrid
                if (grdDisplay.DataSource != null)
                {
                    DataTable dtLocal = (DataTable)grdDisplay.DataSource;
                    dtLocal.DefaultView.RowFilter = string.Empty; // remove previous search filter

                }
                }
                catch (Exception ex)
                {
                MessageBox.Show("Error refreshing grid: " + ex.Message, "Refresh Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //pnlFilters.Hide();
                // Reset pagination
                currentPageSJ = 1;
               // pnlCardInfo.Controls.Clear();
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (grdDisplay.DataSource == null)
            //        return;

            //    DataTable dtLocal = (DataTable)grdDisplay.DataSource;
            //    string searchText = txtSearchBox.Text.Trim().ToLower(); // fixed name

            //    if (string.IsNullOrEmpty(searchText))
            //    {
            //        dtLocal.DefaultView.RowFilter = string.Empty;
            //        return;
            //    }

            //    List<string> filterList = new List<string>();

            //    foreach (DataColumn col in dtLocal.Columns)
            //    {
            //    if (col.DataType == typeof(string)) // skip numbers/dates
            //    {
            //        string escaped = searchText.Replace("'", "''");
            //        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
            //    }
            //}

            //    string filter = string.Join(" OR ", filterList);
            //    dtLocal.DefaultView.RowFilter = filter;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Error during search: " + ex.Message, "Search Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //}



            clsUser cls = new clsUser();
            dt = cls.FetchDataSJ();
            FullData = dt.Copy();
            ApplySearch(txtSearchBox.Text);

        }
        public void ApplySearch(string searchText)
        {
            if (FullData == null)
                return;

            searchText = searchText.Trim().Replace("'", "''");

            DataView dv = new DataView(FullData);

            if (string.IsNullOrWhiteSpace(searchText))
            {
                dt = FullData.Copy();   // search box रिकामा → full data
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

                dt = dv.ToTable();      // filtered result
            }

            // search नंतर pagination reset
            currentPageSJ = 1;
            LoadPageSJ();
            CreatePageButtonSJ();
        }


        public void FilterGridByDateSJ()
        {
                try
                {
                    DateTime fromDateSJ = dtpFromDate.Value.Date;
                    DateTime toDateSJ = dtpToDate.Value.Date;

                    clsUser objCls = new clsUser();
                    objCls.fromDateSJ = fromDateSJ; // ✅ Corrected
                    objCls.toDateSJ = toDateSJ;

                    DataTable dtTime = objCls.FetchDateTimeSJ();
                    grdDisplay.DataSource = dtTime;

                    var srNoColumn = grdDisplay.Columns["SrNo"];
                    if (srNoColumn != null && srNoColumn.DisplayIndex != 1)
                    {
                        srNoColumn.DisplayIndex = 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtering grid by date: " + ex.Message, "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

            private void lblAgentDetails_Click(object sender, EventArgs e)
            {
                try
                {
                    // intentionally left blank - keep for future actions
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error in label click: " + ex.Message, "Label Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            public void CheckBoxSJ()
            {
                try
                {
                    grdDisplay.AllowUserToAddRows = false;
                    grdDisplay.ReadOnly = false;
                    grdDisplay.EditMode = DataGridViewEditMode.EditOnEnter;

                    // Contact No Read-Only - original code set read-only for all but first col
                    foreach (DataGridViewColumn col in grdDisplay.Columns)
                    {
                        col.ReadOnly = col.Index != 0;
                    }

                    System.Windows.Forms.CheckBox headerCheckBoxAB = new System.Windows.Forms.CheckBox();
                    headerCheckBoxAB.BackColor = System.Drawing.Color.Transparent;
                    System.Drawing.Rectangle rect = grdDisplay.GetCellDisplayRectangle(0, -1, true);

                    headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                    headerCheckBoxAB.Location = new System.Drawing.Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                    grdDisplay.Controls.Add(headerCheckBoxAB);

                    //CheckedChanged CurrentCellDirtyStateChanged Logic
                    headerCheckBoxAB.CheckedChanged += (s, e1) =>
                    {
                        try
                        {
                            grdDisplay.EndEdit();
                            grdDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit);
                            bool chechAll = headerCheckBoxAB.Checked;

                            foreach (DataGridViewRow row in grdDisplay.Rows)
                            {
                                DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                                if (chkCell != null)
                                {
                                    chkCell.Value = chechAll;
                                }
                            }
                            grdDisplay.RefreshEdit();
                        }
                        catch (Exception exInner)
                        {
                            MessageBox.Show("Error toggling header checkbox: " + exInner.Message, "Header Checkbox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };

                    grdDisplay.CurrentCellDirtyStateChanged += (s, e2) =>
                    {
                        try
                        {
                            if (grdDisplay.CurrentCell is DataGridViewCheckBoxCell)
                                grdDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        }
                        catch (Exception exInner)
                        {
                            MessageBox.Show("Error committing checkbox edit: " + exInner.Message, "Checkbox Commit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error setting up checkboxes: " + ex.Message, "Checkbox Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void dtpFromDate_ValueChanged(object sender, EventArgs e)
            {
                try
                {
                    FilterGridByDateSJ();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error handling from-date change: " + ex.Message, "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void dtpToDate_ValueChanged(object sender, EventArgs e)
            {
                try
                {
                    FilterGridByDateSJ();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error handling to-date change: " + ex.Message, "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void pctPDF_Click(object sender, EventArgs e)
            {
                try
                {
                    ConvertToPDFSJ();
                }      
                catch (Exception ex)
                {
                    MessageBox.Show("Error in PDF click handler: " + ex.Message, "Click Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try 
            {
                if (currentPageSJ > 1)
                {
                    currentPageSJ--;
                    LoadPageSJ();
                    CreatePageButtonSJ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on Previous button click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageSJ < totalPagesSJ)
                {
                    currentPageSJ++;
                    LoadPageSJ();
                    CreatePageButtonSJ();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on Next button click: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblFormDate_Click(object sender, EventArgs e)
        {

        }
    }
    }




