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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using CheckBox = System.Windows.Forms.CheckBox;
using Color = System.Drawing.Color;
using Control = System.Windows.Forms.Control;

namespace GSTHMS
{
    public partial class frmMaintenance : Form
    {
        DataTable dt1 = new DataTable();
        int pageSizeSJ = 20;
        int currentpageSJ = 1;
        int totrecoedsSJ = 0;
        int totpageSJ = 0;
        int PageNumber = 3;
        DataTable fulldata1;
        DataTable originalDataSJ = new DataTable();
        private int page;
        private int pagesize;
        DataTable dt12 = new DataTable();
        public DateTime formDateSJ { get; set; }
        public DateTime toDateSJ { get; set; }
        public string[] allowedcolumns;

        private Control currentSelectedControl = null;
        private Color defaultColor = Color.LightGray;
        private Color highlightColor = Color.FromArgb(0, 120, 215);
        private Color defaultForeColor = Color.Black;
        private Color highlightForeColor = Color.White;

        private string activeMenu = "";

        ToolStripMenuItem selectedMenu = null;

        private string currentModule = "";


        public frmMaintenance()
        {
            InitializeComponent();
        }
        Form background;
        private void roomMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentModule = "RoomMaintenance";
            lblMaintenanceDetails.Text = "Room Maintenance";

            HighlightMenu(RoomtoolStripMenuItem);

            clsUser obj1 = new clsUser();
            fulldata1 = obj1.DisplayRoomSJ();   // Get fresh data every time!
            if (fulldata1 != null) originalDataSJ = fulldata1.Copy();

            if (fulldata1 != null && fulldata1.Rows.Count > 0)
            {
                totrecoedsSJ = fulldata1.Rows.Count;   // FIXED
                totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);

                currentpageSJ = 1; // Important – reset page number
            }
            else
            {
                grdDisplayData.DataSource = null;   // Clear grid if no data  
            }

            LoadPageSJ();
            CreatePageButtonSJ();
            CheckBoxSJ();

            grdDisplayData.AllowUserToResizeColumns = false;
            grdDisplayData.AllowUserToResizeRows = false;
            grdDisplayData.ColumnHeadersHeightSizeMode =
            DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        }
        private void serviceMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdDisplayData.ReadOnly = true;
            currentModule = "ServiceMaintenance";
            FilterGridByDateSJ();
            lblMaintenanceDetails.Text = "Service Maintenance";
            HighlightMenu(serviceMaintenanceToolStripMenuItem);

            clsUser obj3 = new clsUser();
            fulldata1 = obj3.DisplayServiceSJ(); // Fresh डेटा ग्लोबल व्हेरिएबलमध्ये घ्या
            if (fulldata1 != null) originalDataSJ = fulldata1.Copy();

            if (fulldata1 != null && fulldata1.Rows.Count > 0)
            {
                totrecoedsSJ = fulldata1.Rows.Count;
                totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);

                currentpageSJ = 1;

                LoadPageSJ();
                CreatePageButtonSJ();
                CheckBoxSJ();
            }
            else
            {
                grdDisplayData.DataSource = null; 
            }
        }
        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            currentModule = "InventoryMaintenance";
            FilterGridByDateSJ();
            lblMaintenanceDetails.Text = "Inventory Maintenance";
            HighlightMenu(inventoryToolStripMenuItem);

            clsUser obj1 = new clsUser();
            fulldata1 = obj1.DisplayInventorySJ(); // Fresh डेटा ग्लोबल व्हेरिएबलमध्ये घ्या
            if (fulldata1 != null) originalDataSJ = fulldata1.Copy();

            if (fulldata1 != null && fulldata1.Rows.Count > 0)
            {
                totrecoedsSJ = fulldata1.Rows.Count;
                totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);

                // 🔥 महत्त्वाचा फिक्स: पेज नंबर नेहमी १ वर रिसेट करा!
                currentpageSJ = 1;

                LoadPageSJ();
                CreatePageButtonSJ();
                CheckBoxSJ();
            }
            else
            {
                grdDisplayData.DataSource = null; // डेटा नसेल तर ग्रिड क्लिअर करा
            }
        }
        private void frmMaintenance_Load(object sender, EventArgs e)
        {

            menuStrip1.Renderer = new GreyMenuRenderer();


            //grid text font size
            this.grdDisplayData.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            this.grdDisplayData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);

            //  grid alignment
            grdDisplayData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in grdDisplayData.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //grid horizontal and vertical border lines
            grdDisplayData.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdDisplayData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayData.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayData.GridColor = System.Drawing.Color.Gray;

            toolTip2.SetToolTip(pctRefresh, "Refresh");
            toolTip2.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip2.SetToolTip(pctExcel, "Export To Exel");
            toolTip2.SetToolTip(pctPDF, "DownLoad The PDF");
            // toolTip2.SetToolTip(pctDelete, "Delete Data");
            toolTip2.SetToolTip(pctFilter, "Filters");
            currentModule = "RoomMaintenance";
            HighlightMenu(RoomtoolStripMenuItem);
            // RoomtoolStripMenuItem.BackColor = Color.Silver;            
            lblMaintenanceDetails.Text = "Room Maintenance";
            clsUser obj1 = new clsUser();
            fulldata1 = obj1.DisplayRoomSJ();
            if (fulldata1 != null) originalDataSJ = fulldata1.Copy();

            dt12 = fulldata1.Copy();
            totrecoedsSJ = fulldata1.Rows.Count;
            totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);
            LoadPageSJ();
            CreatePageButtonSJ();


            CheckBoxSJ();
            grdDisplayData.AllowUserToResizeColumns = false;
            grdDisplayData.AllowUserToResizeRows = false;
            grdDisplayData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            pnldtpShow.Visible=true;


            //HighlightControl(RoomtoolStripMenuItem);
        }
        /// /////////////for pagination/////////////
        private void LoadPageSJ()
        {

            int startIndex = (currentpageSJ - 1) * pageSizeSJ;
            DataTable tempTable = fulldata1.Clone();
            for (int i = startIndex; i < startIndex + pageSizeSJ && i < fulldata1.Rows.Count; i++)
            {
                tempTable.ImportRow(fulldata1.Rows[i]);

            }
            grdDisplayData.DataSource = tempTable;

        }
        private void CreatePageButtonSJ()
        {

            int bwidthSJ = 40;
            int bheightSJ = 35;
            int spacingSJ = 5;
            int startXSJ = 10;
            pnlPageFlow.Controls.Clear();

            foreach (System.Windows.Forms.Control ctr in pnlPageFlow.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
            {
                if (ctr.Name.StartsWith("btnPage"))
                {
                    pnlPageFlow.Controls.Remove(ctr);
                }
            }
            int totalPagesSJ = (int)Math.Ceiling((double)fulldata1.Rows.Count / pageSizeSJ);

            totpageSJ = totalPagesSJ;

            //  FOR FIXING SIZE AND POSITIONS AND SPACES IN BUTTONS FROM 1 TO N NUMBERS

            for (int i = 1; i <= totalPagesSJ; i++)
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidthSJ, bheightSJ);
                btnPage.Location = new Point(startXSJ, 5);
                btnPage.FillColor = (i == currentpageSJ) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                btnPage.ForeColor = (i == currentpageSJ) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                btnPage.Click += BtnPage_Click;

                // ADDING CONTROLS ON PAGINATION PANEL

                pnlPageFlow.Controls.Add(btnPage);
                startXSJ += bwidthSJ + spacingSJ;
                // SRNOAM();
            }

            // FOR ENABLE THE PREVIOUS BUTTTON WHEN 1ST NUMBER OF PAGE IS OPEN 

            btnPrevious.Enabled = currentpageSJ > 1;
            btnNext.Enabled = currentpageSJ < totpageSJ;
        }

        public void BtnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)
            {
                int pageNumberSJ = Convert.ToInt32(btn.Text);
                currentpageSJ = pageNumberSJ;
                LoadPageSJ();     // THIS METHOD DISPLAYS THE RECORDS IN DATA GRID VIEW 
                CreatePageButtonSJ(); // CREATE THE PAGE NUMBERS AT THE BASES OF DATATABLES RECORDS
                CheckBoxSJ();
            }
        }



        /// ///////for checkbox////////////
        public void CheckBoxSJ()
        {
            grdDisplayData.AllowUserToAddRows = false;
            grdDisplayData.ReadOnly = false;
            grdDisplayData.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdDisplayData.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            // 🔥 महत्त्वाचा बदल: आधीपासून असलेला जुना हेडर चेकबॉक्स डिलीट करा, 
            // जेणेकरून तो डबल होणार नाही!
            foreach (Control ctrl in grdDisplayData.Controls.OfType<System.Windows.Forms.CheckBox>().ToList())
            {
                if (ctrl.Name == "chkSelectAllHeader")
                {
                    grdDisplayData.Controls.Remove(ctrl);
                    ctrl.Dispose();
                }
            }

            System.Windows.Forms.CheckBox headerCheckBoxSJ = new System.Windows.Forms.CheckBox();
            headerCheckBoxSJ.Name = "chkSelectAllHeader"; // नाव दिले जेणेकरून नंतर ओळखता येईल
            headerCheckBoxSJ.BackColor = Color.Transparent;
            System.Drawing.Rectangle rect = grdDisplayData.GetCellDisplayRectangle(0, -1, true);

            headerCheckBoxSJ.Size = new Size(18, 18);
            headerCheckBoxSJ.Location = new Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

            grdDisplayData.Controls.Add(headerCheckBoxSJ);

            headerCheckBoxSJ.CheckedChanged += (s, e1) =>
            {
                grdDisplayData.EndEdit();
                grdDisplayData.CommitEdit(DataGridViewDataErrorContexts.Commit);
                bool chechAll = headerCheckBoxSJ.Checked;

                foreach (DataGridViewRow row in grdDisplayData.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                    {
                        chkCell.Value = chechAll;
                    }
                }
                grdDisplayData.RefreshEdit();
            };

            grdDisplayData.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdDisplayData.CurrentCell is DataGridViewCheckBoxCell)
                    grdDisplayData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            pnldtpShow.Visible = true;
            txtSearchBox.Text = "";

            menuStrip1.Renderer = new GreyMenuRenderer();

            // Grid formatting
            grdDisplayData.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            grdDisplayData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);
            grdDisplayData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in grdDisplayData.Columns)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdDisplayData.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdDisplayData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayData.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayData.GridColor = Color.Gray;

            toolTip2.SetToolTip(pctRefresh, "Refresh");
            toolTip2.SetToolTip(pctPDF, "Download The PDF");
            toolTip2.SetToolTip(pctExcel, "Export To Excel");
            toolTip2.SetToolTip(pctFilter, "Filters");

            // Load data based on current module
            clsUser obj = new clsUser();

            if (currentModule == "RoomMaintenance")
            {
                HighlightMenu(RoomtoolStripMenuItem);
                lblMaintenanceDetails.Text = "Room Maintenance";
                fulldata1 = obj.DisplayRoomSJ();
            }
            else if (currentModule == "ServiceMaintenance")
            {
                HighlightMenu(serviceMaintenanceToolStripMenuItem);
                lblMaintenanceDetails.Text = "Service Maintenance";
                fulldata1 = obj.DisplayServiceSJ();
            }
            else if (currentModule == "InventoryMaintenance")
            {
                HighlightMenu(inventoryToolStripMenuItem);
                lblMaintenanceDetails.Text = "Inventory Maintenance";
                fulldata1 = obj.DisplayInventorySJ();
            }

            if (fulldata1 != null) originalDataSJ = fulldata1.Copy();

            // ✅ Pagination — FIXED ORDER
            if (fulldata1 != null && fulldata1.Rows.Count > 0)
            {
                totrecoedsSJ = fulldata1.Rows.Count;

                currentpageSJ = 1;          //  SET FIRST
                CreatePageButtonSJ();       //  THEN CREATE BUTTONS
                LoadPageSJ();               //  THEN LOAD DATA
            }

            CheckBoxSJ();

            grdDisplayData.AllowUserToResizeColumns = false;
            grdDisplayData.AllowUserToResizeRows = false;
            grdDisplayData.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            //pnldtpShow.Hide();

        }



        //for search box//
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBox.Text?.Trim() ?? string.Empty;

                if (originalDataSJ == null || originalDataSJ.Rows.Count == 0)
                    return;

                if (string.IsNullOrEmpty(searchText) || searchText == "Search Here...")
                {
                    fulldata1 = originalDataSJ.Copy();
                    currentpageSJ = 1;
                    totrecoedsSJ = fulldata1.Rows.Count;
                    totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);

                    LoadPageSJ();
                    CreatePageButtonSJ();
                    CheckBoxSJ();
                    return;
                }

                string escapedSearchText = searchText.Replace("'", "''");

                List<string> filterList = new List<string>();
                foreach (DataColumn col in originalDataSJ.Columns)
                {
                    if (col.DataType == typeof(string) ||
                        col.DataType == typeof(int) ||
                        col.DataType == typeof(long) ||
                        col.DataType == typeof(decimal) ||
                        col.DataType == typeof(double) ||
                        col.DataType == typeof(DateTime))
                    {
                        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escapedSearchText}%'");
                    }
                }

                if (filterList.Count == 0)
                {
                    MessageBox.Show("No searchable columns found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string filter = string.Join(" OR ", filterList);

                DataView dv = originalDataSJ.DefaultView;
                dv.RowFilter = filter;
                fulldata1 = dv.ToTable();
                dv.RowFilter = string.Empty;

                currentpageSJ = 1;
                totrecoedsSJ = fulldata1.Rows.Count;
                totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);

                LoadPageSJ();
                CreatePageButtonSJ();
                CheckBoxSJ();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void GetSelectedRowsSJ()      //Method For Export to PDF and EXEL
        {

            {
                // 1. DataTable Initialization
                if (dt1 != null)
                    dt1.Clear();
                else
                    dt1 = new DataTable();

                dt1.Columns.Clear();
                dt1.Columns.Add("SrNo");

                string[] selectedHeaders = null; // original column names (no spaces)

                // Default fallback
                if (string.IsNullOrEmpty(currentModule))
                    currentModule = "RoomMaintenance";

                // Module-wise headers
                switch (currentModule.Trim().ToLower())
                {
                    case "roommaintenance":
                        selectedHeaders = new string[]
                        {
                "RoomName", "RoomTypeName", "ReportedDate",
                "StartDate", "EndDate", "Cost", "Description", "Status"
                        };
                        break;

                    case "servicemaintenance":
                        selectedHeaders = new string[]
                        {
                "ServiceType", "ReportedDate", "StartDate",
                "EndDate", "Cost", "Description", "Status"
                        };
                        break;

                    case "inventorymaintenance":
                        selectedHeaders = new string[]
                        {
                "InventoryName", "ReportedDate", "StartDate",
                "EndDate", "Cost", "Description", "Status"
                        };
                        break;

                    default:
                        MessageBox.Show("Invalid Module Selected for Export.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }

                // 🔹 ADD COLUMNS WITH FRIENDLY HEADERS (spaces)
                foreach (string colHeader in selectedHeaders)
                {
                    string friendlyHeader =
                        System.Text.RegularExpressions.Regex
                        .Replace(colHeader, "([A-Z])", " $1").Trim();

                    dt1.Columns.Add(friendlyHeader);
                }

                grdDisplayData.EndEdit();

                int srNoCounter = 1;

                foreach (DataGridViewRow row in grdDisplayData.Rows)
                {
                    if (row.Cells[0].Value != null &&
                        Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        DataRow dr = dt1.NewRow();
                        dr[0] = srNoCounter;

                        int dtColIndex = 1;

                        foreach (string header in selectedHeaders)
                        {
                            // 🔥 MAIN FIX: Find column using DataPropertyName (ACTUAL DATA SOURCE)
                            var col = grdDisplayData.Columns
                                .Cast<DataGridViewColumn>()
                                .FirstOrDefault(c =>
                                    string.Equals(c.DataPropertyName, header, StringComparison.OrdinalIgnoreCase) ||
                                    string.Equals(c.Name, header, StringComparison.OrdinalIgnoreCase) ||
                                    string.Equals(c.HeaderText.Replace(" ", ""), header, StringComparison.OrdinalIgnoreCase)
                                );

                            // 🔥 Assign ACTUAL cell value (not empty)
                            dr[dtColIndex] =
                                (col != null && row.Cells[col.Index].Value != null)
                                    ? row.Cells[col.Index].Value.ToString()
                                    : "";

                            dtColIndex++;
                        }

                        dt1.Rows.Add(dr);
                        srNoCounter++;
                    }
                }

                //if (dt1.Rows.Count == 0)
                //    MessageBox.Show("No rows selected for export!",
                //                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void pctPDF_Click(object sender, EventArgs e)
        {

            ExportToPDFSJ();
        }

        //excel//
        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelSJ();

        }
        public void ExportToExcelSJ()       // Export to Excel
        {


            GetSelectedRowsSJ();

            if (dt1 == null || dt1.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🔥 Clone datatable (as it is)
            DataTable filteredDt = dt1.Clone();

            // 🔥 REMOVE CHECKBOX COLUMN (0th column) (as it is)
            if (filteredDt.Columns.Count > 0)
            {
                filteredDt.Columns.RemoveAt(0);
            }

            // 🔥 ADD SrNo COLUMN (🔥 ONLY ADDITION)
            filteredDt.Columns.Add("SrNo", typeof(int));
            filteredDt.Columns["SrNo"].SetOrdinal(0); // SrNo first column

            int srNo = 1; // 🔥 Sequential SrNo

            // 🔥 Copy rows WITHOUT checkbox value (as it is)
            foreach (DataRow row in dt1.Rows)
            {
                bool isEmpty = row.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString()));
                if (!isEmpty)
                {
                    DataRow newRow = filteredDt.NewRow();

                    newRow["SrNo"] = srNo++; // 🔥 ONLY ADDITION

                    for (int i = 1; i < dt1.Columns.Count; i++) // start from index 1 (as it is)
                    {
                        newRow[i] = row[i];
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
                Filter = "Excel Workbook (*.xlsx)|*.xlsx",
                FileName = "SelectedData.xlsx"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Selected Rows");

                    int colCount = filteredDt.Columns.Count;

                    // 🔹 Title
                    ws.Cell(1, 1).Value = lblMaintenanceDetails.Text;
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, colCount).Merge();

                    // 🔹 Generated Date
                    ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(2, 1).Style.Font.Italic = true;
                    ws.Range(2, 1, 2, colCount).Merge();

                    ws.Row(3).Height = 10;

                    // 🔹 Insert Data
                    ws.Cell(4, 1).InsertTable(filteredDt, "ExportData", true);

                    // 🔹 Header Styling
                    var header = ws.Range(4, 1, 4, colCount);
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

        public void ExportToPDFSJ()
        {

            GetSelectedRowsSJ();

            if (dt1 == null || dt1.Rows.Count == 0)
            {
                MessageBox.Show("Please Select atleast One Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // SrNo अजूनही skip मध्ये आहे (कारण dt1 मध्ये नाही)
            List<string> columnsToSkip = new List<string> { "Details", "Actions", "SrNo" };

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "SelectedRows.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePathSM = saveFileDialog.FileName;

            var exportColumns = dt1.Columns.Cast<DataColumn>()
                                        .Where(c => !columnsToSkip.Contains(c.ColumnName))
                                        .ToList();

            if (exportColumns.Count == 0)
            {
                MessageBox.Show("Export PDF Column Is Not Available...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // PDF Document
            iTextSharp.text.Document docAB =
                new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(docAB, new FileStream(filePathSM, FileMode.Create));
            docAB.Open();

            // Title
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblMaintenanceDetails.Text,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            docAB.Add(title);

            // Date
            iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 10;
            docAB.Add(date);

            // 🔥 +1 column for SrNo
            PdfPTable table = new PdfPTable(exportColumns.Count + 1);
            table.WidthPercentage = 100;

            // ================= HEADER =================

            // SrNo Header
            PdfPCell srHeader = new PdfPCell(new Phrase("SrNo",
                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
            srHeader.BackgroundColor = new BaseColor(240, 240, 240);
            srHeader.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(srHeader);

            // Existing headers
            foreach (var column in exportColumns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                    FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            // ================= DATA =================

            int srNo = 1; // ✅ SEQUENTIAL SrNo (random selection असली तरी)

            foreach (DataRow row in dt1.Rows)
            {
                // SrNo Cell
                PdfPCell srCell = new PdfPCell(new Phrase(srNo.ToString(),
                    FontFactory.GetFont("Arial", 10)));
                srCell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(srCell);

                foreach (var column in exportColumns)
                {
                    string cellText = row[column]?.ToString() ?? "";
                    PdfPCell dataCell = new PdfPCell(
                        new Phrase(cellText, FontFactory.GetFont("Arial", 10)));
                    dataCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(dataCell);
                }

                srNo++;
            }

            docAB.Add(table);
            docAB.Close();

            MessageBox.Show("PDF Save Successfully....!\n" + filePathSM,
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }


        private void btnMaintenance_Click(object sender, EventArgs e)
        {
            frmSendMaintenance frm = new frmSendMaintenance();
            frm.Show();

        }
        private void HighlightMenu(ToolStripMenuItem menu)
        {
            // Reset previous menu highlight
            if (selectedMenu != null)
            {
                selectedMenu.BackColor = Color.Transparent;
                selectedMenu.ForeColor = Color.Black;
            }

            // Set new highlight color
            menu.BackColor = Color.Silver;   // Highlight color
            menu.ForeColor = Color.Black;

            selectedMenu = menu;  // Store currently selected item
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            pnldtpShow.Visible = !pnldtpShow.Visible;

            if (pnldtpShow.Visible)
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
        public void FilterGridByDateSJ()
        {
            DateTime fromDateSJ = dtpFromDate.Value.Date;
            DateTime toDateSJ = dtpToDate.Value.Date;

            clsUser objCls = new clsUser();
            objCls.fromDateSJ = fromDateSJ;
            objCls.toDateSJ = toDateSJ;


            switch (currentModule)
            {
                case "RoomMaintenance":
                    fulldata1 = objCls.DateTimeRoomSJ();
                    break;

                case "ServiceMaintenance":
                    fulldata1 = objCls.DateTimeServiceSJ();
                    break;

                case "InventoryMaintenance":
                    fulldata1 = objCls.DateTimeInventorySJ();
                    break;
            }

            if (fulldata1 != null)
            {
                originalDataSJ = fulldata1.Copy();
                grdDisplayData.DataSource = fulldata1;
            }
            LoadPageSJ();
            CreatePageButtonSJ();


        }
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            FilterGridByDateSJ();

        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            FilterGridByDateSJ();

        }

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            totpageSJ = (int)Math.Ceiling((double)totrecoedsSJ / pageSizeSJ);
            if (currentpageSJ < totpageSJ)
            {
                currentpageSJ++;
                LoadPageSJ();
                CreatePageButtonSJ();
            }
        }

        private void btnPrevious_Click_1(object sender, EventArgs e)
        {
            if (currentpageSJ > 1)
            {
                currentpageSJ--;
                LoadPageSJ();
                CreatePageButtonSJ();
            }
        }

        private void grdDisplayData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblMaintenanceDetails_Click(object sender, EventArgs e)
        {

        }
    }
    //give hover highlight color
    public class GreyMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Selected)
                e.Graphics.FillRectangle(Brushes.Silver, e.Item.ContentRectangle);
            else
                base.OnRenderMenuItemBackground(e);
        }
    }

}




