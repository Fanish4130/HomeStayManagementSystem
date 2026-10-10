using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2021.MipLabelMetaData;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
//using HMSLibrary;
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
    public partial class frmTotalOffers : Form
    {
        System.Windows.Forms.CheckBox headerCheckBoxSM;
        public System.Data.DataTable dt = new System.Data.DataTable();
        public string LableSM { get; set; }

        public int totalRecordsSM = 0;
        public int totalpagesSM = 0;
        public int pagesizeSM = 15;
        public int currentPageSM = 1;
        public int pageNumberSM = 3;
        DataTable dtSM = new DataTable();

        DataTable FullDataTableSM = new DataTable();  //Search text page
        DataTable PagedDataSM = new DataTable();       // paged data
        int PageSizeSM = 15;
        int PageNoSM = 1;

        public frmTotalOffers(string lable)
        {
            InitializeComponent();
            LableSM = lable;
        }

       

        private void frmTotalOffers_Load(object sender, EventArgs e)
        {

            //toolTip1.SetToolTip(pctRefresh, "Refresh");   //tooltip
            //toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            //toolTip1.SetToolTip(pctExcel, "Export To Exel");
            //toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            //toolTip1.SetToolTip(pctDelete, "Delete Data");
            //toolTip1.SetToolTip(pctFilter, "Filters");


            FormLoad();

            //  grid alignment 
            grdDisplayToffer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in grdDisplayToffer.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


            grdDisplayToffer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;    //grid row column not large
            grdDisplayToffer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            grdDisplayToffer.AllowUserToResizeRows = false;
            grdDisplayToffer.AllowUserToResizeColumns = false;


            //grdDisplayToffer.ReadOnly = true;


            this.grdDisplayToffer.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdDisplayToffer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdDisplayToffer.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdDisplayToffer.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grid horizontal and vertical border lines

            //grid horizontal and vertical border lines
            grdDisplayToffer.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdDisplayToffer.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayToffer.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdDisplayToffer.GridColor =System.Drawing.Color.Gray;


            //grid text font size
            this.grdDisplayToffer.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            this.grdDisplayToffer.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);


        }
        public void FormLoad()
        {
                 clsUser objsm = new clsUser();

            lblInfo.Text = LableSM;


            if (lblInfo.Text == "Total Offers")
            {
                dtSM = objsm.DisplayOffersSM();
                // grdDisplayToffer.DataSource = dt;
               
            }
            else if (lblInfo.Text == "Active Offers")
            {
                dtSM = objsm.DisplayActiveoffergridSM();
                // grdDisplayToffer.DataSource = dt;
            }
            else if (lblInfo.Text == "Upcoming Offers")
            {
                dtSM = objsm.DisplayUpcomingoffergridSM();
                // grdDisplayToffer.DataSource = dt;
            }
            else if (lblInfo.Text == "InActive Offers")
            {
                dtSM = objsm.DisplayInactivoffergridSM();
                // grdDisplayToffer.DataSource = dt;
            }
            totalRecordsSM = dtSM.Rows.Count;
            totalpagesSM = (int)Math.Ceiling((double)totalRecordsSM / pagesizeSM);


            FullDataTableSM = dt.Copy();  //search



         //   panelDataFilter.Visible = false;


            LoadPageSM();
            CreatePageButtonSM();


          
        }




        //public void CheckBoxSM()      //Checkbox Selected Method
        //{
        //    foreach (DataGridViewColumn col in grdDisplayToffer.Columns)
        //    {
        //        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    grdDisplayToffer.AllowUserToAddRows = false;
        //    grdDisplayToffer.ReadOnly = false;
        //    grdDisplayToffer.EditMode = DataGridViewEditMode.EditOnEnter;

        //    foreach (DataGridViewColumn col in grdDisplayToffer.Columns)
        //    {
        //        col.ReadOnly = col.Index != 0;
        //    }

        //    System.Windows.Forms.CheckBox chkHeader = new System.Windows.Forms.CheckBox();
        //    chkHeader.Size = new Size(15, 15);
        //    chkHeader.BackColor = System.Drawing.Color.Transparent;

        //    grdDisplayToffer.Controls.Add(chkHeader);

        //    grdDisplayToffer.CellPainting += (s, e) =>
        //    {
        //        if (e.RowIndex == -1 && e.ColumnIndex == 0)
        //        {
        //            System.Drawing.Rectangle rect = grdDisplayToffer.GetCellDisplayRectangle(0, -1, true);

        //            chkHeader.Location = new Point(
        //                rect.X + (rect.Width - chkHeader.Width) / 2,
        //                rect.Y + (rect.Height - chkHeader.Height) / 2
        //            );
        //        }
        //    };

        //    chkHeader.CheckedChanged += (s, e1) =>
        //    {
        //        foreach (DataGridViewRow row in grdDisplayToffer.Rows)
        //        {
        //            DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
        //            if (chkCell != null)
        //                chkCell.Value = chkHeader.Checked;
        //        }
        //        grdDisplayToffer.RefreshEdit();
        //    };

        //    grdDisplayToffer.CurrentCellDirtyStateChanged += (s, e2) =>
        //    {
        //        if (grdDisplayToffer.CurrentCell is DataGridViewCheckBoxCell)
        //            grdDisplayToffer.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    };
        //}

       

        //public void DownLoadToPDFSM()    //  Export to PDF 
        //{
        //    DataTable dt = GetSelectedRowsSM();   // <<< FIXED

        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Please select at least one row to export!",
        //                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    List<string> columnsToSkip = new List<string> { "Details", "Actions" };

        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
        //    saveFileDialog.Title = "Save PDF File";
        //    saveFileDialog.FileName = "SelectedRows.pdf";

        //    if (saveFileDialog.ShowDialog() != DialogResult.OK)
        //        return;

        //    string filePathSM = saveFileDialog.FileName;

        //    // Create PDF document
        //    iTextSharp.text.Document docAB = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
        //    PdfWriter.GetInstance(docAB, new FileStream(filePathSM, FileMode.Create));
        //    docAB.Open();

        //    // Title
        //    iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblInfo.Text,
        //        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
        //    title.Alignment = Element.ALIGN_CENTER;
        //    docAB.Add(title);

        //    // Date
        //    iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " +
        //        DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
        //        new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
        //    date.Alignment = Element.ALIGN_RIGHT;
        //    date.SpacingAfter = 10;
        //    docAB.Add(date);

        //    // Filter unwanted columns
        //    var finalColumns = dt.Columns.Cast<DataColumn>()
        //                         .Where(col => !columnsToSkip.Contains(col.ColumnName))
        //                         .ToList();

        //    // Table
        //    PdfPTable table = new PdfPTable(finalColumns.Count);
        //    table.WidthPercentage = 100;

        //    // Add Headers
        //    foreach (var column in finalColumns)
        //    {
        //        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
        //                        FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));

        //        cell.BackgroundColor = new BaseColor(240, 240, 240);
        //        cell.HorizontalAlignment = Element.ALIGN_CENTER;
        //        cell.Padding = 5;

        //        table.AddCell(cell);
        //    }

        //    // Add Data
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        foreach (var column in finalColumns)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString(),
        //                            FontFactory.GetFont("Arial", 10)));
        //            cell.Padding = 5;
        //            table.AddCell(cell);
        //        }
        //    }

        //    docAB.Add(table);
        //    docAB.Close();

        //    MessageBox.Show("PDF File Saved Successfully!\n" + filePathSM,
        //                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}





    //    public DataTable GetSelectedRowsSM()      //Method For Export to PDF and EXEL
    //    {

    //        dt = new DataTable();

    //        // Allowed columns
    //        string[] allowedColumns = {
    //    "SrNo",
    //    "OfferName",
    //    "Discount_rs",
    //    "StartDate",
    //    "EndDate",
    //    "Status",
    //    "Description"
    //};

    //        // Create columns
    //        foreach (string col in allowedColumns)
    //        {
    //            dt.Columns.Add(col);
    //        }

    //        grdDisplayToffer.EndEdit();

    //        int srNoCounter = 1;

    //        foreach (DataGridViewRow row in grdDisplayToffer.Rows)
    //        {
    //            if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
    //            {
    //                DataRow dr = dt.NewRow();

    //                for (int i = 0; i < allowedColumns.Length; i++)
    //                {
    //                    string colName = allowedColumns[i];




    //                    if (colName == "SrNo")
    //                    {
    //                        dr[i] = srNoCounter;   // Serial no
    //                    }
    //                    else
    //                    {
    //                        dr[i] = row.Cells[colName]?.Value?.ToString() ?? "";
    //                    }
    //                }

    //                dt.Rows.Add(dr);
    //                srNoCounter++;
    //            }
    //        }

    //        return dt;
    //    }

        

        //public void ExportToExcelSM()       //Export to Exel 
        //{
        //    DataTable dt = GetSelectedRowsSM();



        //    List<string> columnsToSkip = new List<string> { "SrNo" };


        //    System.Data.DataTable filteredDt = dt.Clone();


        //    foreach (string col in columnsToSkip)
        //    {
        //        if (filteredDt.Columns.Contains(col))
        //            filteredDt.Columns.Remove(col);
        //    }


        //    foreach (DataRow row in dt.Rows)
        //    {
        //        bool isEmpty = row.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString()));
        //        if (!isEmpty)
        //        {
        //            DataRow newRow = filteredDt.NewRow();
        //            foreach (DataColumn col in filteredDt.Columns)
        //            {
        //                newRow[col.ColumnName] = row[col.ColumnName];
        //            }
        //            filteredDt.Rows.Add(newRow);
        //        }
        //    }


        //    if (dt == null || dt.Rows.Count == 0)
        //    {
        //        MessageBox.Show("Please select at least one row to export!",
        //                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }


        //    SaveFileDialog sfd = new SaveFileDialog
        //    {
        //        Filter = "Excel Workbook (.xlsx)|.xlsx",
        //        FileName = "SelectedGuestData.xlsx"
        //    };

        //    if (sfd.ShowDialog() == DialogResult.OK)
        //    {
        //        using (var workbook = new XLWorkbook())
        //        {
        //            var ws = workbook.Worksheets.Add("Selected Rows");


        //            ws.Cell(1, 1).Value = lblInfo.Text;
        //            ws.Cell(1, 1).Style.Font.Bold = true;
        //            ws.Cell(1, 1).Style.Font.FontSize = 16;
        //            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //            ws.Range(1, 1, 1, filteredDt.Columns.Count).Merge();


        //            ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
        //            ws.Cell(2, 1).Style.Font.Italic = true;
        //            ws.Range(2, 1, 2, filteredDt.Columns.Count).Merge();

        //            ws.Row(3).Height = 10;


        //            ws.Cell(4, 1).InsertTable(filteredDt, "GuestData", true);


        //            var header = ws.Range(4, 1, 4, filteredDt.Columns.Count);
        //            header.Style.Font.Bold = true;
        //            header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
        //            header.Style.Fill.BackgroundColor = XLColor.LightGray;

        //            ws.Columns().AdjustToContents();

        //            workbook.SaveAs(sfd.FileName);
        //        }

        //        MessageBox.Show("Selected rows exported to Excel successfully!",
        //                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void pctExcel_Click(object sender, EventArgs e)
        //{
        //    ExportToExcelSM();
        //}

      //  private void pctPDF_Click(object sender, EventArgs e)
        //{
        //    DownLoadToPDFSM();
        //}

        //public void DeleteSelectedRowsSM()     //Delete Selected Rows
        //{

        //    for (int i = grdDisplayToffer.Rows.Count - 1; i >= 0; i--)
        //    {
        //        DataGridViewRow row = grdDisplayToffer.Rows[i];


        //        if (row.IsNewRow) continue;


        //        DataGridViewCheckBoxCell chk = row.Cells["Check"] as DataGridViewCheckBoxCell;

        //        if (chk != null && Convert.ToBoolean(chk.Value) == true)
        //        {

        //            grdDisplayToffer.Rows.RemoveAt(i);
        //        }
        //    }
        //}

        //private void pctDelete_Click(object sender, EventArgs e)
        //{
        //    DeleteSelectedRowsSM();
        //}

      
        //private void txtSearchBox_TextChanged(object sender, EventArgs e)
        //{
        //    if (FullDataTableSM == null || FullDataTableSM.Rows.Count == 0)
        //        return;

        //    DataTable dt = FullDataTableSM;  // FULL TABLE
        //    string searchText = txtSearchBox.Text.Trim().ToLower();

        //    if (string.IsNullOrEmpty(searchText))
        //    {
        //        grdDisplayToffer.DataSource = dt;  // full data
        //        return;
        //    }

        //    List<string> filterList = new List<string>();
        //    string escaped = searchText.Replace("'", "''");

        //    foreach (DataColumn col in dt.Columns)
        //    {
        //        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
        //    }

        //    string filter = string.Join(" OR ", filterList);

        //    DataView dv = dt.DefaultView;
        //    dv.RowFilter = filter;

        //    grdDisplayToffer.DataSource = dv.ToTable();
        
          
        //}
       
        //private void pctFilter_Click(object sender, EventArgs e)
        //{
        //    panelDataFilter.Visible = !panelDataFilter.Visible;
        //}

        //public void FilterGridByDateSM()
        //{
        //    DateTime fromDate = dtpOfferfromDate.Value.Date;
        //    DateTime toDate = dtpOffertoDate.Value.Date;

        //    clsUser obj = new clsUser();
        //    obj.FromDateSM = fromDate;
        //    obj.ToDateSM = toDate;

        //    DataTable dtsm = obj.GetDatabydatarangeSM();

        //    grdDisplayToffer.DataSource = dtsm;

        //    //totalRecordsSM = dtsm.Rows.Count;
        //    //totalpagesSM = (int)Math.Ceiling((double)totalRecordsSM / pagesizeSM);

        //    //currentPageSM = 1;
        //    //LoadPageSM();
        //    //CreatePageButtonSM();
        //    //CheckBoxSM();
        //}



        //private void dtpOfferfromDate_ValueChanged(object sender, EventArgs e)
        //{
        //    FilterGridByDateSM();
        //}

        //private void dtpOffertoDate_ValueChanged(object sender, EventArgs e)
        //{
        //   FilterGridByDateSM();
        //}

        private void pctRefresh_Click(object sender, EventArgs e)    //Refresh Button
        {
            //  FormLoad();
         //   lblInfo.Text = LableSM;



            FormLoad();
         //   CheckBoxSM();

            //grdDisplayToffer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;    //grid row column not large
            //grdDisplayToffer.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            //grdDisplayToffer.AllowUserToResizeRows = false;
            //grdDisplayToffer.AllowUserToResizeColumns = false;


            //grdDisplayToffer.ReadOnly = true;
        }

        private void grdDisplayToffer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public void CreatePageButtonSM()   //Pagination 
        {
            int bwidthSM = 40;
            int bheightSM = 35;
            int spacingSM = 5;
            int startXSM = 10;
            pnlPage.Controls.Clear();

            foreach (System.Windows.Forms.Control ctr in pnlPage.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
            {
                if (ctr.Name.StartsWith("btnPage"))
                {
                    pnlPage.Controls.Remove(ctr);
                }
            }
            int totalPagesSM = (int)Math.Ceiling((double)dtSM.Rows.Count / pagesizeSM);

            totalpagesSM = totalPagesSM;

            //  FOR FIXING SIZE AND POSITIONS AND SPACES IN BUTTONS FROM 1 TO N NUMBERS

            for (int i = 1; i <= totalPagesSM; i++)
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidthSM, bheightSM);
                btnPage.Location = new Point(startXSM, 5);
                btnPage.FillColor = (i == currentPageSM) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                btnPage.ForeColor = (i == currentPageSM) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                btnPage.Click += btnPage_Click;

                // ADDING CONTROLS ON PAGINATION PANEL

                pnlPage.Controls.Add(btnPage);
                startXSM += bwidthSM + spacingSM;
                // UpdateButtonStateSM();

                //btmPrevious.Enabled = currentPageSM > 1;
                //btnNext.Enabled = currentPageSM < totalPagesSM;
            }
        }

        public void LoadPageSM()
        {
            
            int startIndex = (currentPageSM - 1) * pagesizeSM;

            DataTable dtPage = dtSM.Clone();

            for (int i = startIndex; i < startIndex + pagesizeSM && i < dtSM.Rows.Count; i++)
            {
                dtPage.ImportRow(dtSM.Rows[i]);
            }
            grdDisplayToffer.DataSource = dtPage;
        //    CheckBoxSM();
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPageSM = pageNumber;
                LoadPageSM();
                CreatePageButtonSM();
            }
        }
        public void UpdateButtonStateSM()
        {
            btnPrevious.Enabled = currentPageSM > 1;
            btnNext.Enabled = currentPageSM < totalpagesSM;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (currentPageSM > 1)
            {
                currentPageSM--;
                LoadPageSM();
                CreatePageButtonSM();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            totalpagesSM = (int)Math.Ceiling((double)totalRecordsSM / pagesizeSM);
            if (currentPageSM < totalpagesSM)
            {
                currentPageSM++;
                LoadPageSM();
                CreatePageButtonSM();
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pnlPage_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
