using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2013.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
//using HMSLibrary;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GSTHMS
{
    public partial class frmOffersDetails : Form
    {
        public int totalRecordsSM = 0;
        public int totalPagesSM = 0;
        public int pageSizeSM = 15;
        public int currentPageSM = 1;
        public int pageNumberSM = 3;

        Form background;

        DataTable dtSelected;
        System.Windows.Forms.CheckBox headerCheckBoxSM;
        public System.Data.DataTable dt = new System.Data.DataTable();
        DataTable dtp = new DataTable();

        DataTable FullDataTableSM = new DataTable();  //Search text page
        DataTable PagedDataSM = new DataTable();       // paged data
        int PageSizeSM = 15;
        int PageNoSM = 1;

        public frmOffersDetails()
        {
            InitializeComponent();
        }

     

        public void frmOffersDetails_Load(object sender, EventArgs e)
        {
            panelDataFilter.Visible = !panelDataFilter.Visible;
            this.grdOffers.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdOffers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdOffers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdOffers.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //grid horizontal and vertical border lines
           
            //grid horizontal and vertical border lines
            grdOffers.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdOffers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdOffers.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdOffers.GridColor = System.Drawing.Color.Gray;

            //this.AutoScroll = false;
            //grdOffers.ScrollBars = ScrollBars.None;


            MainFormLoadSM();

            //  grid alignment 
            grdOffers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in grdOffers.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            toolTip1.SetToolTip(pctRefresh, "Refresh");
         //   toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
         //   toolTip1.SetToolTip(pctExcel, "Export To Exel");
         //   toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
       //     toolTip1.SetToolTip(pctDelete, "Delete Data");
            toolTip1.SetToolTip(pctFilter, "Filters");


            //grid text font size
            this.grdOffers.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);
            this.grdOffers.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 12);


           
        }


        public void MainFormLoadSM()
        {
           

        clsUser obj = new clsUser();
        DataTable dt = obj.DisplayOffersSM();
        grdOffers.DataSource = dt;
        grdOffers.Show();


            FullDataTableSM = dt.Copy();

        TotalOfferSM();
        ActiveOfferSM();
        InActiveOfferDateSM();
        UpcomingOfferSM();
        FilterGridByDateSM();
             


            //   ExportToExcel();
            panelDataFilter.Visible = false;

           
            if (dt != null && dt.Rows.Count > 0)      // pagination condition
            {
                totalRecordsSM = dt.Rows.Count;
 
                totalPagesSM = (int) Math.Ceiling((Double) totalRecordsSM / pageSizeSM);

      //  CheckBoxSM();
        LoadPageSM(currentPageSM);
        CreatePageButtonSM();

               
            }
            else
            {
                
                grdOffers.DataSource = null;
                pnlPage.Controls.Clear();
                btmPrevious.Enabled = false;
                btnNext.Enabled = false;
                totalPagesSM = 0;
                totalRecordsSM = 0;
            }


            //  grid alignment 
            grdOffers.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in grdOffers.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }


        }
        private void TotalOfferSM()      //Show count for totaloffers
        {
            clsUser obj = new clsUser();
            DataTable dt = obj.DisplaytotalofferSM();

            if (dt.Rows.Count > 0)
            {
                lbltotaloffer.Text = dt.Rows[0]["Totaloffers"].ToString();
            }
            else
            {
                lbltotaloffer.Text = "0";
            }

        }

        private void ActiveOfferSM()    //Show count for ActiveOffers
        {
            clsUser obj1 = new clsUser();
            DataTable dt = obj1.DisplayActiveofferSM();

            if (dt.Rows.Count > 0)
            {
                lblActiveoffers.Text = dt.Rows[0]["Activeoffer"].ToString();
            }
            else
            {
                lblActiveoffers.Text = "0";
            }
        }

        private void UpcomingOfferSM()    //Shoe Expired Offers For COunt
        {
            clsUser obj1 = new clsUser();
            DataTable dt = obj1.DisplayUpcomingofferSM();

            if (dt.Columns.Contains("UpcomingOffer"))
            {
                lblExpireOffers.Text = dt.Rows[0]["UpcomingOffer"].ToString();
            }
            else
            {
                lblExpireOffers.Text = "0";
            }
        }

        private void InActiveOfferDateSM()   //Show inactive Offers Counts
        {
            clsUser obj1 = new clsUser();
            DataTable dt = obj1.DisplayInActiveofferSM();

            if (dt.Rows.Count > 0)
            {
                lblInActiveoffers.Text = dt.Rows[0]["InActiveOffer"].ToString();
            }
            else
            {
                lblInActiveoffers.Text = "0";
            }
        }
      
      public void LoadOffersSM()        //Fetch Offers by Dates
        {
           
        }

   
        
      
      
     
        private void dtpOfferfromDate_ValueChanged(object sender, EventArgs e)
        {
            FilterGridByDateSM();

        }

        private void dtpOffertoDate_ValueChanged(object sender, EventArgs e)
        {
              FilterGridByDateSM();
           
        }



        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
         
            try
            {
                string searchText = txtSearchBox.Text?.Trim() ?? string.Empty;

                
                if (string.IsNullOrEmpty(searchText) || searchText == "Search Here...")
                {
                   
                    LoadPageSM(currentPageSM);
                    return;
                }

                // Ensure dt exists (global full DataTable)
                if (dt == null)
                {
                    MessageBox.Show("No data available to search.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Escape single quotes in user input
                string escapedSearchText = searchText.Replace("'", "''");

              
                List<string> filterList = new List<string>();
                foreach (DataColumn col in dt.Columns)
                {
                    //find simple types search
                    if (col.DataType == typeof(string) ||
                        col.DataType == typeof(int) ||
                        col.DataType == typeof(long) ||
                        col.DataType == typeof(decimal) ||
                        col.DataType == typeof(double) ||
                        col.DataType == typeof(DateTime))
                    {
                        // Convert to string conver LIKE 
                        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escapedSearchText}%'");
                    }
                }

                if (filterList.Count == 0)
                {
                    MessageBox.Show("No searchable columns found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string filter = string.Join(" OR ", filterList);

                
                dt.DefaultView.RowFilter = filter;
                DataTable filteredResultsDt = dt.DefaultView.ToTable();
                dt.DefaultView.RowFilter = string.Empty; 

               
                grdOffers.DataSource = filteredResultsDt;

                // pagination variables update 
                totalRecordsSM = filteredResultsDt.Rows.Count;
                totalPagesSM = (int)Math.Ceiling((double)totalRecordsSM / pageSizeSM);
                currentPageSM = 1;

               
                CreatePageButtonSM();

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during search: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }







        private void guna2Panel3_Click(object sender, EventArgs e)
        {
            frmTotalOffers obj = new frmTotalOffers(lblExpireOffers.Text);
            obj.Show();
        }

        private void guna2Panel4_Click(object sender, EventArgs e)
        {
            frmTotalOffers obj = new frmTotalOffers(lblInActiveoffers.Text);
            obj.Show();
        }



        //public void CheckBoxSM()      //Checkbox Selected Method
        //{
        //    foreach (DataGridViewColumn col in grdOffers.Columns)
        //    {
        //        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    grdOffers.AllowUserToAddRows = false;
        //    grdOffers.ReadOnly = false;
        //    grdOffers.EditMode = DataGridViewEditMode.EditOnEnter;

        //    foreach (DataGridViewColumn col in grdOffers.Columns)
        //    {
        //        col.ReadOnly = col.Index != 0;
        //    }

        //    System.Windows.Forms.CheckBox chkHeader = new System.Windows.Forms.CheckBox();
        //    chkHeader.Size = new Size(15, 15);
        //    chkHeader.BackColor = System.Drawing.Color.Transparent;

        //    grdOffers.Controls.Add(chkHeader);

        //    grdOffers.CellPainting += (s, e) =>
        //    {
        //        if (e.RowIndex == -1 && e.ColumnIndex == 0)
        //        {
        //            System.Drawing.Rectangle rect = grdOffers.GetCellDisplayRectangle(0, -1, true);

        //            chkHeader.Location = new Point(
        //                rect.X + (rect.Width - chkHeader.Width) / 2,
        //                rect.Y + (rect.Height - chkHeader.Height) / 2
        //            );
        //        }
        //    };

        //    chkHeader.CheckedChanged += (s, e1) =>
        //    {
        //        foreach (DataGridViewRow row in grdOffers.Rows)
        //        {
        //            DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
        //            if (chkCell != null)
        //                chkCell.Value = chkHeader.Checked;
        //        }
        //        grdOffers.RefreshEdit();
        //    };

        //    grdOffers.CurrentCellDirtyStateChanged += (s, e2) =>
        //    {
        //        if (grdOffers.CurrentCell is DataGridViewCheckBoxCell)
        //            grdOffers.CommitEdit(DataGridViewDataErrorContexts.Commit);
        //    };
        //}





        private void pctFilter_Click(object sender, EventArgs e)
        {
            panelDataFilter.Visible = !panelDataFilter.Visible;
        }



        public DataTable GetSelectedRowsSM()
        {
             dt = new DataTable();

            // Allowed columns
            string[] allowedColumns = {
        "SrNo",
        "OfferName",
        "Discount_rs",
        "StartDate",
        "EndDate",
        "Status",
        "Description"
    };

            // Create columns
            foreach (string col in allowedColumns)
            {
                dt.Columns.Add(col);
            }

            grdOffers.EndEdit();

            int srNoCounter = 1;

            foreach (DataGridViewRow row in grdOffers.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                {
                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < allowedColumns.Length; i++)
                    {
                        string colName = allowedColumns[i];
                        
        
       

                        if (colName == "SrNo")
                        {
                            dr[i] = srNoCounter;   // Serial no
                        }
                        else
                        {
                            dr[i] = row.Cells[colName]?.Value?.ToString() ?? "";
                        }
                    }

                    dt.Rows.Add(dr);
                    srNoCounter++;
                }
            }

            return dt;
        }

        public void ExportToPDFSM()    //  Export to PDF 
        {


        

           DataTable dt = GetSelectedRowsSM();   // <<< FIXED

            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<string> columnsToSkip = new List<string> { "Details", "Actions" };

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "SelectedRows.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePathSM = saveFileDialog.FileName;

            // Create PDF document
            iTextSharp.text.Document docAB = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(docAB, new FileStream(filePathSM, FileMode.Create));
            docAB.Open();

            // Title
            iTextSharp.text.Paragraph title = new iTextSharp.text.Paragraph(lblAllOffers.Text,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            docAB.Add(title);

            // Date
            iTextSharp.text.Paragraph date = new iTextSharp.text.Paragraph("Generated on: " +
                DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 10;
            docAB.Add(date);

            // Filter unwanted columns
            var finalColumns = dt.Columns.Cast<DataColumn>()
                                 .Where(col => !columnsToSkip.Contains(col.ColumnName))
                                 .ToList();

            // Table
            PdfPTable table = new PdfPTable(finalColumns.Count);
            table.WidthPercentage = 100;

            // Add Headers
            foreach (var column in finalColumns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                                FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));

                cell.BackgroundColor = new BaseColor(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 5;

                table.AddCell(cell);
            }

            // Add Data
            foreach (DataRow row in dt.Rows)
            {
                foreach (var column in finalColumns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString(),
                                    FontFactory.GetFont("Arial", 10)));
                    cell.Padding = 5;
                    table.AddCell(cell);
                }
            }

            docAB.Add(table);
            docAB.Close();

            MessageBox.Show("PDF File Saved Successfully!\n" + filePathSM,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelSM();
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
          ExportToPDFSM();
        }

        public void ExportToExcelSM()       //Export to Exel 
        {
         DataTable dt =   GetSelectedRowsSM();

          

            List<string> columnsToSkip = new List<string> { "SrNo" };


            System.Data.DataTable filteredDt = dt.Clone();


            foreach (string col in columnsToSkip)
            {
                if (filteredDt.Columns.Contains(col))
                    filteredDt.Columns.Remove(col);
            }


            foreach (DataRow row in dt.Rows)
            {
                bool isEmpty = row.ItemArray.All(x => x == null || string.IsNullOrWhiteSpace(x.ToString()));
                if (!isEmpty)
                {
                    DataRow newRow = filteredDt.NewRow();
                    foreach (DataColumn col in filteredDt.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }
                    filteredDt.Rows.Add(newRow);
                }
            }


            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
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


                    ws.Cell(1, 1).Value = lblAllOffers.Text;
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, filteredDt.Columns.Count).Merge();


                    ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    ws.Cell(2, 1).Style.Font.Italic = true;
                    ws.Range(2, 1, 2, filteredDt.Columns.Count).Merge();

                    ws.Row(3).Height = 10;


                    ws.Cell(4, 1).InsertTable(filteredDt, "GuestData", true);


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

        public void DeleteSelectedRowsSM()     //Delete Selected Rows
        {

            for (int i = grdOffers.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdOffers.Rows[i];


                if (row.IsNewRow) continue;


                DataGridViewCheckBoxCell chk = row.Cells["Check"] as DataGridViewCheckBoxCell;

                if (chk != null && Convert.ToBoolean(chk.Value) == true)
                {

                    grdOffers.Rows.RemoveAt(i);
                
                }
            }
        }

        public void FilterGridByDateSM()
        {
            DateTime fromDateSM = dtpOfferfromDate.Value.Date;
            DateTime toDateSM = dtpOffertoDate.Value.Date;

            clsUser objSM = new clsUser();
            objSM.FromDateSM = fromDateSM;
            objSM.ToDateSM = toDateSM;

            DataTable dtsm = objSM.GetDatabydatarangeSM();

            if (dtsm != null && dtsm.Rows.Count > 0)
            {
                grdOffers.DataSource = dtsm;
            }
            else
            {
                grdOffers.DataSource = null; // No records
            }

            //totalRecordsSM = dtsm.Rows.Count;
            //totalPagesSM = (int)Math.Ceiling((double)totalRecordsSM / pageSizeSM);

            //currentPageSM = 1;
            //LoadPageSM(currentPageSM);
            //CreatePageButtonSM();
            //CheckBoxSM();
        }


       



        private void pctDelete_Click_1(object sender, EventArgs e)
        {
            DeleteSelectedRowsSM();
        }

        public void LoadGuestDetailsDataSM()   //Refresh page
        {
            


            //currentPageSM = 1;


            //LoadPageSM();



            //CreatePageButtonSM();
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
      
            MainFormLoadSM();
          
        }


        public void CreatePageButtonSM()   //Pagination 
        {
            int bwidth = 40;
            int bheight = 35;
            int spacing = 5;
            int start = 10;
            pnlPage.Controls.Clear();

            for (int i = 1; i <= totalPagesSM; i++) // Use totalPagesSM instead of recalculating
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new System.Drawing.Size(bwidth, bheight);
                btnPage.Location = new System.Drawing.Point(start, 5);
                // Highlight the current page button
                btnPage.FillColor = (i == currentPageSM) ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                btnPage.ForeColor = (i == currentPageSM) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                btnPage.Click += btnPage_Click;
                pnlPage.Controls.Add(btnPage);
                start += bwidth + spacing;
            }
            UpdateButtonStateSM();

            //btmPrevious.Enabled = currentPageSM > 1;
            //btnNext.Enabled = currentPageSM < totalPagesSM;
        }

        public void LoadPageSM(int pageNumber) 
        {
            clsUser obj1 = new clsUser();
            dt = obj1.DisplayOffersSM();
            int startIndex = (pageNumber - 1) * pageSizeSM;

            System.Data.DataTable dtPage = dt.Clone();

            for (int i = startIndex; i < startIndex + pageSizeSM && i < dt.Rows.Count; i++)
            {
                dtPage.ImportRow(dt.Rows[i]);
            }
            grdOffers.DataSource = dtPage;
          //  CheckBoxSM();
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPageSM = pageNumber;
                LoadPageSM(currentPageSM);
                CreatePageButtonSM();
            }
        }
        public void UpdateButtonStateSM()
        {
            btmPrevious.Enabled = currentPageSM > 1;
            btnNext.Enabled = currentPageSM < totalPagesSM;
        }


        private void btmPrevious_Click(object sender, EventArgs e)
        {
            if (currentPageSM > 1)
            {
                currentPageSM--;
                LoadPageSM(currentPageSM);
                CreatePageButtonSM();
            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPageSM < totalPagesSM)
            {
                currentPageSM++;
                LoadPageSM(currentPageSM);
                CreatePageButtonSM();
            }

        }

 
       
        private void pnlExpiredOffer_Click(object sender, EventArgs e)
        {
            
            //obj.Show();

            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmTotalOffers f = new frmTotalOffers(lblupcomingoffers.Text);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void pnlAcrtiveoffers_Click(object sender, EventArgs e)
        {
          
            //obj.Show();
          
        }

        private void pnlInActiveOffers_Click(object sender, EventArgs e)
        { 

           
        }

        private void pnltotaloffers_Click(object sender, EventArgs e)
        {
            //frmTotalOffers obj = new frmTotalOffers(lblTotalOffer1.Text);
            //obj.Show();
           
        }

        private void grdOffers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         //   FilterGridByDateSM(); 
        }

        private void cpnlTotaloffers_Click(object sender, EventArgs e)
        {
            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmTotalOffers f = new frmTotalOffers(lblTotalOffer1.Text);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void cpnlActiveOffers_Click(object sender, EventArgs e)
        {
            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmTotalOffers f = new frmTotalOffers(lblActiveOffer1.Text);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void cpnlExpiredOffers_Click(object sender, EventArgs e)
        {
            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmTotalOffers f = new frmTotalOffers(lblupcomingoffers.Text);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void cpnlinactiveoffers_Click(object sender, EventArgs e)
        {
            background = new Form();
            background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.6;
            background.BackColor = System.Drawing.Color.Black;
            background.WindowState = FormWindowState.Maximized;
            background.TopMost = true;
            background.Show();

            frmTotalOffers f = new frmTotalOffers(lblInActiveOffers1.Text);
            f.StartPosition = FormStartPosition.CenterScreen;
            f.TopMost = true;
            f.FormClosed += (s, args) =>
            {
                background.Close(); // close dim background
                this.Enabled = true;
                this.Opacity = 1;
            };
            f.Show();
        }

        private void panelDataFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
