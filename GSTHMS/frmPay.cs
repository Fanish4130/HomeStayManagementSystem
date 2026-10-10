using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;

using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Paragraph = iTextSharp.text.Paragraph;

namespace GSTHMS
{
    public partial class frmPay : Form
    {


        public frmPay()
        {
            InitializeComponent();
        }
        System.Data.DataTable dtPaymentMode = new System.Data.DataTable();
        clsUser objUser = new clsUser();
        System.Data.DataTable dt = new System.Data.DataTable();
        System.Windows.Forms.CheckBox headerCheckBox = new System.Windows.Forms.CheckBox();
        public int StatusIDSP { get; set; }
        public int PaymentMethodIDSP { get; set; }
        public int currentPage = 1;
        public int pageSize = 20;
        public int totalPages = 0;
        public int totalRecords = 0;
        public DataTable FullData;
        Form background;
        //public DateTime formDateSP { get; set; }
        //public DateTime toDateSP { get; set; }


        public string bookingcodeSP;
        public string guestnameSP;
        public string invnameSP;
        public string offernameSP;
        public double basepriceSP;
        public int fineSP;
        public string codeSP;
        

        // clsPayment obj = new clsPayment();
        private void Form1_Load(object sender, EventArgs e)
        {
            pnlfilter.Visible = true;

            //grid horizontal and vertical border lines
            grdFetchData.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdFetchData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdFetchData.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdFetchData.GridColor = System.Drawing.Color.Gray;
            ReorderGridColumns();

            grdFetchData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdFetchData.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            txtSearchBox.Text = "Search Here...";
            txtSearchBox.ForeColor = System.Drawing.Color.Gray;

            txtSearchBox.Enter += txtSearchBox_Enter;
            txtSearchBox.Leave += txtSearchBox_Leave;
           
            this.grdFetchData.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdFetchData.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

            MainLoadSP();

            if (grdFetchData.Columns.Contains("BookingCode"))
            {
                grdFetchData.Columns["BookingCode"].Visible = false;
            }
            // After binding your DataTable to the grid
            if (grdFetchData.Columns.Contains("StatusID"))
            {
                grdFetchData.Columns["StatusID"].Visible = false;   // Hide StatusID column
            }
            toolTip1.SetToolTip(pctRefresh, "Refresh");
            toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip1.SetToolTip(pctExcel, "Export To Exel");
            toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip1.SetToolTip(pctTodaysPayment, "TODAYS PAYMENT");
            toolTip1.SetToolTip(pctFilter, "Filters");
           
        }
      
        public void MainLoadSP()
        {

            grdFetchData.AllowUserToAddRows = false;
            pnlPages.Visible = true;
            //Checkbox column add 
            AddCheckBoxColumnSP();

            //Header checkbox
            AddHeaderCheckBoxSP();

            

            //Button initial state (white background)
            pctFilter.FillColor = System.Drawing.Color.White;
            pctFilter.ForeColor = System.Drawing.Color.Black;
            pctFilter.Text = "Show Filter";

            //Events 
            grdFetchData.CurrentCellDirtyStateChanged += GrdFetchData_CurrentCellDirtyStateChanged;
            grdFetchData.DataBindingComplete += GrdFetchData_DataBindingComplete;

            
            //main grid
            //grdFetchData.ReadOnly = true;
            //IsMdiContainer = true;
            clsUser cls = new clsUser();

            dt = cls.FetchPayDataSP();
            dt = cls.FetchPayDataSP();
            FullData = dt.Copy();

            // grdFetchData.DataSource = dtPaymentMode;
            // grdFetchData.Show();


            totalRecords = dt.Rows.Count;
            totalPages = (int)Math.Ceiling((Double)totalRecords / pageSize);

            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
            CalculateTotalFromAllPages(dt);


            // Add Pay icon column

            if (!grdFetchData.Columns.Contains("imgPay"))
            {
                DataGridViewImageColumn imgPay = new DataGridViewImageColumn();
                imgPay.Name = "imgPay";
                imgPay.HeaderText = "Payment";
                imgPay.Image = Properties.Resources.Pay; 
                imgPay.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grdFetchData.Columns.Add(imgPay);

            }

            // Add Invoice icon column 
            if (!grdFetchData.Columns.Contains("imgInvoice"))
            {
                DataGridViewImageColumn imgPay = new DataGridViewImageColumn();
                imgPay.Name = "imgInvoice";
                imgPay.HeaderText = "Invoice";
                imgPay.Image = Properties.Resources.Invoice; 
                imgPay.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grdFetchData.Columns.Add(imgPay);
            }

            //   Move Pay and Invoice columns to the end
            grdFetchData.Columns["imgPay"].DisplayIndex = grdFetchData.Columns.Count - 1;
            grdFetchData.Columns["imgInvoice"].DisplayIndex = grdFetchData.Columns.Count - 1;

        }

        private void grdFetchData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdFetchData.Columns.Contains("BookingCode"))
            {
                grdFetchData.Columns["BookingCode"].Visible = false;
            }
            // After binding your DataTable to the grid
            if (grdFetchData.Columns.Contains("StatusID"))
            {
                grdFetchData.Columns["StatusID"].Visible = false;
            }

            // Center header text
            grdFetchData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Center all rows text
            foreach (DataGridViewColumn col in grdFetchData.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            string[] readOnlyColumns =
            {
                "SrNo", "InvoiceCode", "GuestName", "PaidAmt",
                "AmtToPay", "Status", "Fine", "PaymentMethodType", "PaymentDate"
            };

            foreach (var colName in readOnlyColumns)
            {
                if (grdFetchData.Columns.Contains(colName))
                {
                    grdFetchData.Columns[colName].ReadOnly = true;
                }
            }

            if (grdFetchData.Columns.Contains("BookingCode"))
            {
                grdFetchData.Columns["BookingCode"].Visible = false;
            }

            //  When Pay button clicked
            if (e.RowIndex >= 0 && grdFetchData.Columns[e.ColumnIndex].Name == "imgPay")
            {
                DataGridViewRow row = grdFetchData.Rows[e.RowIndex];


                decimal remainingAmt = 0;

                if (row.Cells["RemainingAmount"].Value != null)
                {
                    string raw = row.Cells["RemainingAmount"].Value.ToString()
                                    .Replace("₹", "")
                                    .Replace(",", "")
                                    .Trim();

                    decimal.TryParse(raw, out remainingAmt);
                }
                string status = row.Cells["Status"]?.Value?.ToString() ?? "";

                if (status.Equals("Paid", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Full payment already completed. No further installments allowed.",
                                    "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                string guestname = row.Cells["GuestName"]?.Value?.ToString() ?? string.Empty;

                string fineText = string.Empty;
                int fineSP = 0;
                if (grdFetchData.Columns.Contains("Fine") && row.Cells["Fine"].Value != null)
                {
                    fineText = row.Cells["Fine"].Value.ToString()
                        .Replace("₹", "")
                        .Replace("?", "")
                        .Trim();
                    int.TryParse(fineText, out fineSP);
                }

                string invoiceC = row.Cells["InvoiceCode"]?.Value?.ToString() ?? string.Empty;
                string bookingCode = row.Cells["BookingCode"]?.Value?.ToString() ?? string.Empty;
                
                // Now safely use all variables
                frmPayment frmPayment = new frmPayment(guestname, fineSP, invoiceC, bookingCode);
                frmPayment.PaymentCompleted += () =>
                {
                    RefreshClickSP();
                };
                frmPayment.Show();
            }

            else if (e.RowIndex >= 0 && grdFetchData.Columns[e.ColumnIndex].Name == "imgInvoice")
            {
                DataGridViewRow row = grdFetchData.Rows[e.RowIndex];

                string guestName = row.Cells["GuestName"]?.Value?.ToString() ?? string.Empty;
                string invoiceCode = row.Cells["InvoiceCode"]?.Value?.ToString() ?? string.Empty;

                // --------- NEW CONDITION (Do not open invoice if payment is complete) ----------
                string status = row.Cells["Status"]?.Value?.ToString() ?? "";

                if (status.Equals("Co", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Payment is complete. Invoice cannot be generated again.",
                        "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                clsUser obj = new clsUser
                {
                    invoicecodeSP = invoiceCode
                };

                // Fetch booking code
                string bookingCode = obj.GetBookingCodeByInvoiceSP();

                // Create invoice form
                frmInvoice invoiceForm = new frmInvoice(guestName, invoiceCode, bookingCode)
                {
                    StartPosition = FormStartPosition.CenterParent
                };

                // Show invoice normally (NO DIM BACKGROUND)
                invoiceForm.ShowDialog(this);

                // Bring main form back to front
                this.Activate();
            }
            }

        ///Show All Total
        private void CalculateTotalFromAllPages(DataTable dt, bool isFilterApplied = false)
        {
            decimal totalIncome = 0;

            foreach (DataRow row in dt.Rows)
            {
                string raw = row["PaidAmount"]?.ToString()
                                .Replace("₹", "")
                                .Replace(",", "")
                                .Trim();

                if (decimal.TryParse(raw, out decimal amt))
                {
                    if (isFilterApplied)
                    {
                        // जर filter apply केला असेल → सर्व rows घ्या
                        totalIncome += amt;
                    }
                    else
                    {
                        // Default → फक्त चालू महिन्याचं income
                        if (row["PaymentDate"] != DBNull.Value)
                        {
                            DateTime paidDate = Convert.ToDateTime(row["PaymentDate"]);
                            if (paidDate.Month == DateTime.Now.Month && paidDate.Year == DateTime.Now.Year)
                            {
                                totalIncome += amt;
                            }
                        }
                    }
                }
            }

            lblTotal.Text = "₹ " + totalIncome.ToString("N2");
        }


        //for status filter
        private void cmbbxStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ApplyPaymentModeAndStatusFilter();
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
        }

        //for payment mode filter
        private void cmbbxPMode_SelectionChangeCommitted(object sender, EventArgs e)
        {        
            ApplyPaymentModeAndStatusFilter();
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
        }
      

        private void btnNext_Click(object sender, EventArgs e)
        {
            totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadPageSP();
                CreatePageButtonSP();
               // ReorderGridColumns();
            }
        }

        private void btnPrevoius_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadPageSP();
                CreatePageButtonSP();
               // ReorderGridColumns();
            }
        }
        //Adding Pagination
        public void LoadPageSP()
        {

            int startIndex = (currentPage - 1) * pageSize;
             DataTable dtpages = dt.Clone();

            for (int i = startIndex; i < startIndex + pageSize && i < dt.Rows.Count; i++)
            {
                dtpages.ImportRow(dt.Rows[i]);
            }
            grdFetchData.DataSource = dtpages;

        }

        public void CreatePageButtonSP()
        {
            int bwidth = 40;
            int bheight = 35;
            int spacing = 5;
            int start = 10;

            pnlPages.Controls.Clear();
            foreach (System.Windows.Forms.Control ctr in pnlPages.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
            {
                if (ctr.Name.StartsWith("btnPage"))
                {
                    pnlPages.Controls.Remove(ctr);
                }
            }

            int totalpages = (int)Math.Ceiling((double)dt.Rows.Count / pageSize);
            totalPages = totalpages;

            for (int i = 1; i <= totalpages; i++)
            {
                var btnPage = new Guna2Button();
                btnPage.Name = "btnPage" + i;
                btnPage.Text = i.ToString();
                btnPage.Size = new Size(bwidth, bheight);
                btnPage.Location = new Point(start, 5);
                btnPage.FillColor = (i == currentPage) ? System.Drawing.Color.Silver: System.Drawing.Color.White;
                btnPage.ForeColor = (i == currentPage) ? System.Drawing.Color.White : System.Drawing.Color.Black;
                btnPage.Click += btnPage_Click;

                pnlPages.Controls.Add(btnPage);
                start += bwidth + spacing;
            }
            btnPrevoius.Enabled = currentPage > 1;
            btnNext.Enabled = currentPage < totalPages;
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPage = pageNumber;
                LoadPageSP();
                CreatePageButtonSP();
                ReorderGridColumns();
            }
        }

      
        private void grdFetchData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

        }
       
        ///All code for check box in grid
        private void AddCheckBoxColumnSP()
        {
            // CHECK aadich asel tr punha add nahi honar
            if (!grdFetchData.Columns.Contains("CheckBox"))
            {
                DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                chk.Name = "CheckBox";
                chk.HeaderText = "";
                chk.Width = 50;
                chk.ReadOnly = false;
                grdFetchData.Columns.Insert(0, chk);
            }
        }
        private void AddHeaderCheckBoxSP()
        {
            foreach (DataGridViewColumn col in grdFetchData.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            grdFetchData.AllowUserToAddRows = false;
            grdFetchData.ReadOnly = false;
            grdFetchData.EditMode = DataGridViewEditMode.EditOnEnter;

            foreach (DataGridViewColumn col in grdFetchData.Columns)
            {
                col.ReadOnly = col.Index != 0;
            }

            System.Windows.Forms.CheckBox chkHeader = new System.Windows.Forms.CheckBox();
            chkHeader.Size = new Size(15, 15);
            chkHeader.BackColor = System.Drawing.Color.Transparent;

            grdFetchData.Controls.Add(chkHeader);

            grdFetchData.CellPainting += (s, e) =>
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0)
                {
                    System.Drawing.Rectangle rect = grdFetchData.GetCellDisplayRectangle(0, -1, true);

                    chkHeader.Location = new System.Drawing.Point(
                        rect.X + (rect.Width - chkHeader.Width) / 2,
                        rect.Y + (rect.Height - chkHeader.Height) / 2
                    );
                }

            };

            chkHeader.CheckedChanged += (s, e1) =>
            {
                foreach (DataGridViewRow row in grdFetchData.Rows)
                {
                    DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                        chkCell.Value = chkHeader.Checked;
                }
                grdFetchData.RefreshEdit();
            };

            grdFetchData.CurrentCellDirtyStateChanged += (s, e2) =>
            {
                if (grdFetchData.CurrentCell is DataGridViewCheckBoxCell)
                    grdFetchData.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };
        }
        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = headerCheckBox.Checked;

            foreach (DataGridViewRow row in grdFetchData.Rows)
            {
                DataGridViewCheckBoxCell chk = row.Cells["CheckBox"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = isChecked;
            }

            RefreshPayGridSP();
            ReorderGridColumns();
        }
        private void GrdFetchData_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdFetchData.IsCurrentCellDirty)
                grdFetchData.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void GrdFetchData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            AddHeaderCheckBoxSP();
            ReorderGridColumns();
        }

        private void cmbbxPMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
        }
        public void RefreshPayGridSP()
        {
            clsUser obj = new clsUser();

            grdFetchData.DataSource = obj.FetchPayDataSP();
            grdFetchData.Refresh();
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            lblPayInfo.Text = "PAYMENT DETAILS";
            lblIncome.Visible = true;
            lblTotal.Visible = true;
            txtSearchBox.Text = "";
            txtSearchBox.PlaceholderText = "Search Here.......";
            MainLoadSP();
            RefreshClickSP();
        }
        public void RefreshClickSP()
        {
            cmbbxPMode.DataSource = null;
            cmbbxPMode.Items.Clear();
            cmbbxStatus.DataSource = null;
            cmbbxStatus.Items.Clear();
            // Reset pagination
            currentPage = 1;
            pnlPages.Controls.Clear();

            MainLoadSP();
            ReorderGridColumns();
        }
        public System.Data.DataTable GetSelectedRowsSP()
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            grdFetchData.EndEdit();

            // Always add fresh SrNo for export (reset numbering)
            dt.Columns.Add("SrNo", typeof(int));

            // Add all columns except:
            // - Checkbox (index 0)
            // - SrNo
            // - Icon/Image/Button columns
            // BUT ALWAYS include BookingCode even if hidden
            foreach (DataGridViewColumn col in grdFetchData.Columns)
            {
                bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;
                bool isBookingCode = col.Name.Equals("BookingCode", StringComparison.OrdinalIgnoreCase);

                if (col.Index != 0 &&
                    !string.IsNullOrWhiteSpace(col.Name) &&
                    !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase) &&
                    !isIconCol &&
                    (col.Visible || isBookingCode))   // <-- KEY FIX
                {
                    dt.Columns.Add(col.Name, typeof(object));
                }
            }

            int srNo = 1;

            foreach (DataGridViewRow row in grdFetchData.Rows)
            {
                if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                {
                    DataRow dr = dt.NewRow();

                    // Assign fresh SrNo
                    dr["SrNo"] = srNo++;

                    // Copy other columns
                    foreach (DataColumn col in dt.Columns)
                    {
                        if (col.ColumnName == "SrNo")
                            continue;

                        if (grdFetchData.Columns.Contains(col.ColumnName))
                            dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                        else
                            dr[col.ColumnName] = DBNull.Value;
                    }

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = GetSelectedRowsSP();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
            saveFileDialog.Title = "Save PDF File";
            saveFileDialog.FileName = "SelectedRows.pdf";

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string filePathAM = saveFileDialog.FileName;

            iTextSharp.text.Document docAM = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10);
            PdfWriter.GetInstance(docAM, new FileStream(filePathAM, FileMode.Create));
            docAM.Open();

            // Title
            Paragraph title = new Paragraph(lblPayInfo.Text,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            docAM.Add(title);

            // Generated Date
            Paragraph date = new Paragraph("Generated on: " +
                DateTime.Now.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
            date.Alignment = Element.ALIGN_RIGHT;
            date.SpacingAfter = 5;
            docAM.Add(date);

            // 👉 User selected date range (उदा. दोन DateTimePicker controls)
            DateTime fromDate = dptFromDate.Value.Date;
            DateTime toDate = dptTodate.Value.Date;

            Paragraph dateRange = new Paragraph(
                "Data Exported From: " + fromDate.ToString("dd-MM-yyyy") +
                " To: " + toDate.ToString("dd-MM-yyyy"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.NORMAL));
            dateRange.Alignment = Element.ALIGN_RIGHT;
            dateRange.SpacingAfter = 10;
            docAM.Add(dateRange);

            // ---- TOTAL ----
            decimal totalIncome = 0;
            foreach (DataRow row in dt.Rows)
            {
                string raw = row["PaidAmount"]?.ToString()
                                .Replace("₹", "")
                                .Replace(",", "")
                                .Trim();
                if (decimal.TryParse(raw, out decimal amt))
                    totalIncome += amt;
            }

            Paragraph totalPara = new Paragraph(
                "Total Amount: ₹ " + totalIncome.ToString("N2"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD));
            totalPara.Alignment = Element.ALIGN_RIGHT;
            totalPara.SpacingAfter = 10;
            docAM.Add(totalPara);

            // ---- TABLE ----
            PdfPTable table = new PdfPTable(dt.Columns.Count - 1); // minus BookingCode
            foreach (DataColumn column in dt.Columns)
            {
                if (column.ColumnName == "BookingCode") continue;
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
                    if (column.ColumnName == "BookingCode") continue;
                    string rawValue = row[column].ToString();
                    string displayValue = rawValue;

                    if (column.ColumnName.ToLower().Contains("date"))
                    {
                        if (DateTime.TryParse(rawValue, out DateTime dtValue))
                            displayValue = dtValue.ToString("dd-MM-yyyy");
                    }
                    else if (column.ColumnName.Equals("PaidAmount", StringComparison.OrdinalIgnoreCase))
                    {
                        string cleaned = rawValue.Replace("₹", "").Replace(",", "").Trim();
                        if (decimal.TryParse(cleaned, out decimal amt))
                            displayValue = "₹ " + amt.ToString("N2");
                    }
                    table.AddCell(new Phrase(displayValue, FontFactory.GetFont("Arial", 10)));
                }
            }

            docAM.Add(table);
            docAM.Close();

            MessageBox.Show("PDF File Saved Successfully!\n" + filePathAM,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            System.Data.DataTable dt = GetSelectedRowsSP();
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export!",
                                "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // User selected dates (उदा. दोन DateTimePicker controls)
            DateTime fromDate = dptFromDate.Value.Date;
            DateTime toDate = dptTodate.Value.Date;

            // Total Income
            decimal totalIncome = 0;
            foreach (DataRow row in dt.Rows)
            {
                string raw = row["PaidAmount"]?.ToString()
                                .Replace("₹", "")
                                .Replace(",", "")
                                .Trim();
                if (decimal.TryParse(raw, out decimal amt))
                    totalIncome += amt;
            }

            // Format Export Data
            DataTable exportDt = dt.Copy();
            if (exportDt.Columns.Contains("BookingCode"))
                exportDt.Columns.Remove("BookingCode");

            foreach (DataRow row in exportDt.Rows)
            {
                foreach (DataColumn column in exportDt.Columns)
                {
                    string colName = column.ColumnName;
                    if (colName.ToLower().Contains("date"))
                    {
                        if (DateTime.TryParse(row[colName].ToString(), out DateTime dtValue))
                            row[colName] = dtValue.ToString("dd-MM-yyyy");
                    }
                    else if (colName.Equals("PaidAmount", StringComparison.OrdinalIgnoreCase))
                    {
                        string raw = row[colName].ToString().Replace("₹", "").Replace(",", "").Trim();
                        if (decimal.TryParse(raw, out decimal amt))
                            row[colName] = "₹ " + amt.ToString("N2");
                    }
                }
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Workbook|*.xlsx";
            sfd.FileName = "SelectedGuestData.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Selected Rows");

                    // Title
                    ws.Cell(1, 1).Value = lblPayInfo.Text;
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 16;
                    ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    ws.Range(1, 1, 1, exportDt.Columns.Count).Merge();

                    // Generated Date
                    ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(2, 1).Style.Font.Italic = true;
                    ws.Range(2, 1, 2, exportDt.Columns.Count).Merge();

                    // Selected Date Range
                    ws.Cell(3, 1).Value = "Data Exported From: " + fromDate.ToString("dd-MM-yyyy") +
                                          " To: " + toDate.ToString("dd-MM-yyyy");
                    ws.Cell(3, 1).Style.Font.Bold = true;
                    ws.Range(3, 1, 3, exportDt.Columns.Count).Merge();

                    // Total Income
                    ws.Cell(4, 1).Value = "Total Amount: ₹ " + totalIncome.ToString("N2");
                    ws.Cell(4, 1).Style.Font.Bold = true;
                    ws.Cell(4, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                    ws.Range(4, 1, 4, exportDt.Columns.Count).Merge();

                    // Insert table
                    var table = ws.Cell(6, 1).InsertTable(exportDt);
                    table.Theme = XLTableTheme.TableStyleMedium9;
                    table.ShowAutoFilter = false;

                    ws.Columns().AdjustToContents();
                    workbook.SaveAs(sfd.FileName);
                }

                MessageBox.Show("Excel Export Successful!\n" +
                                "Data From: " + fromDate.ToString("dd-MM-yyyy") +
                                " To: " + toDate.ToString("dd-MM-yyyy") +
                                "\nTotal Income: ₹ " + totalIncome.ToString("N2"),
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            if (pnlfilter.Visible)
            {
                pnlfilter.Visible = false;
            }
            else
            {
                pnlfilter.Visible = true;
            }
        }


        private void pctDelete_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in grdFetchData.Rows)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["CheckBox"];
                if (Convert.ToBoolean(chk.Value) == true)
                {
                    grdFetchData.Rows.Remove(row);
                }
            }
            MessageBox.Show("Delete Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
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
                dt = FullData.Copy();   
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
                dt = dv.ToTable();
            }

            if (dt == null || dt.Rows.Count == 0)
            {
                // Dummy DataTable
                DataTable dummy = new DataTable();
                dummy.Columns.Add("Message", typeof(string));

                DataRow dr = dummy.NewRow();
                dr["Message"] = "NO RECORD FOUND";
                dummy.Rows.Add(dr);

                // Grid bind 
                grdFetchData.AutoGenerateColumns = false;
                grdFetchData.Columns.Clear();

                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.DataPropertyName = "Message";
                col.HeaderText = "";
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                grdFetchData.Columns.Add(col);

                grdFetchData.DataSource = dummy;

                // Style
                grdFetchData.Rows[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdFetchData.Rows[0].DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                grdFetchData.Rows[0].DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold);

                grdFetchData.Rows[0].ReadOnly = true;
                grdFetchData.Rows[0].Selected = false;

                //  Total Income 
                lblTotal.Text = "0";
                return;   
            }

            // Normal data bind 
            grdFetchData.AutoGenerateColumns = true;
            grdFetchData.DataSource = dt;

            currentPage = 1;
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();

            // Recalculate total for filtered data
            CalculateTotalFromAllPages(dt);

        }
        private void cmbbxStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
           LoadPageSP();
           CreatePageButtonSP();
           ReorderGridColumns();
        }

        private void txtSearchBox_Enter(object sender, EventArgs e)
        {
            if (txtSearchBox.Text == "Search Here...")
            {
                txtSearchBox.Text = "";
                txtSearchBox.ForeColor = System.Drawing.Color.Black;
            }

        }

        private void txtSearchBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearchBox.Text))
            {
                txtSearchBox.Text = "Search Here...";
                txtSearchBox.ForeColor = System.Drawing.Color.Gray;
            }

        }

        private void pnlSearchBox_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbbxStatus_Click(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            System.Data.DataTable dtt = new System.Data.DataTable();
            dtt = obj.StatusSP();

            cmbbxStatus.DisplayMember = "Status";
            cmbbxStatus.ValueMember = "StatusID";
            cmbbxStatus.SelectedIndex = -1;
            
            cmbbxStatus.DataSource = dtt;
            cmbbxStatus.Show();
        }
      
        private void cmbbxPMode_Click(object sender, EventArgs e)
        {
            //cmbbxPaymentMode Fetch
            clsUser Pay = new clsUser();
            System.Data.DataTable dtP = new System.Data.DataTable();
            dtP = Pay.FiterPaymentMethodSP();
            cmbbxPMode.DisplayMember = "PaymentMethodType";
            cmbbxPMode.ValueMember = "PaymentMethodID";
            cmbbxPMode.SelectedIndex = -1;
            cmbbxPMode.Text = "select Payment Mode";
            cmbbxPMode.DataSource = dtP;
            cmbbxPMode.Show();
            ReorderGridColumns();
            
        }
       
        public void ApplyPaymentModeAndStatusFilter()
        {
            StatusIDSP = 0;
            PaymentMethodIDSP = 0;
            dt = null;
            if (cmbbxPMode.SelectedValue != null && cmbbxStatus.SelectedValue != null)
            {
                System.Data.DataRowView SelectedRow1 = (System.Data.DataRowView)cmbbxStatus.SelectedItem;
                System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxPMode.SelectedItem;
                StatusIDSP = Convert.ToInt32(SelectedRow1["StatusID"]);
                PaymentMethodIDSP = Convert.ToInt32(SelectedRow["PaymentMethodID"]);

            }

            else if (cmbbxStatus.SelectedValue != null && cmbbxStatus.SelectedValue != DBNull.Value)
            {
                System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxStatus.SelectedItem;
                StatusIDSP = Convert.ToInt32(SelectedRow["StatusID"]);
            }

            else if (cmbbxPMode.SelectedValue != null && cmbbxPMode.SelectedValue != DBNull.Value)
            {
                System.Data.DataRowView SelectedRow = (System.Data.DataRowView)cmbbxPMode.SelectedItem;
                PaymentMethodIDSP = Convert.ToInt32(SelectedRow["PaymentMethodID"]);
            }

            if (StatusIDSP > 0 && PaymentMethodIDSP > 0)
            {

                clsUser clsUser = new clsUser();
                clsUser.statusidSP = StatusIDSP;
                clsUser.PaymentMethodidSP = PaymentMethodIDSP;
                dt = clsUser.FetchPayDataByStatusBothSP();
            }
            else if (StatusIDSP > 0)
            {

                clsUser clsUser = new clsUser();
                clsUser.statusidSP = StatusIDSP;
                dt = clsUser.FetchPayDataByStatusSP();

            }
            else if (PaymentMethodIDSP > 0)
            {

                clsUser clsUser = new clsUser();
                clsUser.PaymentMethodidSP = PaymentMethodIDSP;
                dt = clsUser.FetchPayDataByPaymentModeSP();

            }   
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();        
        }
        private void ReorderGridColumns()
        {
            // Hide unwanted columns
            if (grdFetchData.Columns.Contains("BookingCode"))
                grdFetchData.Columns["BookingCode"].Visible = false;

            if (grdFetchData.Columns.Contains("StatusID"))
                grdFetchData.Columns["StatusID"].Visible = false;
            if (grdFetchData.Columns.Contains("Fine"))
                grdFetchData.Columns["Fine"].Visible = false;

            // Define desired column order
            string[] desiredOrder = {
          "CheckBox", "SrNo","InvoiceCode", "GuestName", "PaymentDate", "PaymentMethodType", "Status",
          "Fine", "TotalAmount", "PaidAmount", "RemainingAmount", "imgInvoice", "imgPay"
    };

            int index = 0;
            foreach (string colName in desiredOrder)
            {
                if (grdFetchData.Columns.Contains(colName))
                {
                    grdFetchData.Columns[colName].DisplayIndex = index++;
                }
            }

            // Optional: Set header text cleanup
            if (grdFetchData.Columns.Contains("RemainingAmount"))
                grdFetchData.Columns["RemainingAmount"].HeaderText = "Remaining(₹)";

            if (grdFetchData.Columns.Contains("TotalAmount"))
                grdFetchData.Columns["TotalAmount"].HeaderText = "Total Amount(₹)";

            if (grdFetchData.Columns.Contains("PaidAmount"))
                grdFetchData.Columns["PaidAmount"].HeaderText = "Paid Amount(₹)";

            if (grdFetchData.Columns.Contains("InvoiceCode"))
                grdFetchData.Columns["InvoiceCode"].HeaderText = "Invoice Code";

            if (grdFetchData.Columns.Contains("GuestName"))
                grdFetchData.Columns["GuestName"].HeaderText = "Guest Name";

            if (grdFetchData.Columns.Contains("PaymentDate"))
                grdFetchData.Columns["PaymentDate"].HeaderText = "Payment Date";

            if (grdFetchData.Columns.Contains("SrNo"))
                grdFetchData.Columns["SrNo"].HeaderText = "Sr No";

            if (grdFetchData.Columns.Contains("Fine"))
                grdFetchData.Columns["Fine"].HeaderText = "Fine(₹)";

            if (grdFetchData.Columns.Contains("PaymentMethodType"))
                grdFetchData.Columns["PaymentMethodType"].HeaderText = "Payment Mode";
      
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            ReorderGridColumns();
            FilterGridByDateSP();          
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            ReorderGridColumns();
            FilterGridByDateSP();
            
        }

        //FOR DATE
        public void FilterGridByDateSP()
        {
            try
            {
                DateTime today = DateTime.Today;
                DateTime fromDateSP = dptFromDate.Value.Date;
                DateTime toDateSP = dptTodate.Value.Date;

                if (fromDateSP > toDateSP)
                {
                    MessageBox.Show("From Date cannot be greater than To Date.");
                    dptFromDate.Value = today;
                    return;
                }

                if (fromDateSP > today)
                {
                    MessageBox.Show("From Date cannot be greater than today's date.");
                    dptFromDate.Value = today;
                    return;
                }

                if (toDateSP > today)
                {
                    MessageBox.Show("To Date cannot be greater than today's date.");
                    dptTodate.Value = today;
                    return;
                }

                clsUser objCls = new clsUser();
                objCls.fromDateSP = fromDateSP;
                objCls.toDateSP = toDateSP;

                // Fetch filtered data
                dt = objCls.FetchPaymentsByDateSP();

                // No result found check
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No result found for selected date range.",
                                    "Search",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                    grdFetchData.DataSource = null;
                    lblTotal.Text = "₹ 0.00";
                    return;
                }

                //  Bind first page
                LoadPageSP();
                CreatePageButtonSP();

                //  Reorder special columns
                if (grdFetchData.Columns.Contains("imgInvoice"))
                    grdFetchData.Columns["imgInvoice"].DisplayIndex = grdFetchData.Columns.Count - 1;

                if (grdFetchData.Columns.Contains("imgPay"))
                    grdFetchData.Columns["imgPay"].DisplayIndex = grdFetchData.Columns.Count - 2;

                if (grdFetchData.Columns.Contains("SrNo"))
                    grdFetchData.Columns["SrNo"].DisplayIndex = 1;

                ReorderGridColumns();

                // Recalculate total for filtered data
                CalculateTotalFromAllPages(dt, true);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while filtering data:\n" + ex.Message);
            }
        }

        private void grdFetchData_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
       {

            if (dt.Rows.Count == 1 && dt.Rows[0].IsNull(0) && e.RowIndex == 0 && e.ColumnIndex == 0)
            {
                e.Graphics.FillRectangle(new SolidBrush(grdFetchData.DefaultCellStyle.BackColor), e.CellBounds);

                TextRenderer.DrawText(
                    e.Graphics,
                    "No Record Found",
                    new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                    e.CellBounds,
                    System.Drawing.Color.Red,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
                e.Handled = true;
            }
        }

        private void pctTodaysPayment_Click(object sender, EventArgs e)
        {
            clsUser o1 = new clsUser();
            lblPayInfo.Text = "TODAYS PAYMENT";
            lblIncome.Visible = false;
            lblTotal.Visible = false;         
            dt = o1.GetTodaysBookingSP();
            grdFetchData.DataSource = dt;
            LoadPageSP();
            CreatePageButtonSP();
            ReorderGridColumns();
        }

        private void lblIncome_Click(object sender, EventArgs e)
        {

        }

        private void lblPayInfo_Click(object sender, EventArgs e)
        {

        }

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }
    }
 }
    
    

    
