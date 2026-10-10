using ClosedXML.Excel;
using demosidebar;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
//using Microsoft.Office.Interop.Excel;
//using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Xml.Linq;
using TheArtOfDevHtmlRenderer.Adapters.Entities;
using static GSTHMS.clsUser;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using CheckBox = System.Windows.Forms.CheckBox;
using Color = System.Drawing.Color;
using DataTable = System.Data.DataTable;
using Document = iTextSharp.text.Document;
//using Excel = Microsoft.Office.Interop.Excel;
using PageSize = iTextSharp.text.PageSize;
using Paragraph = iTextSharp.text.Paragraph;
using Point = System.Drawing.Point;

namespace GSTHMS
{
    public partial class frmEnquiry : Form
    {

        public frmEnquiry()
        {
            InitializeComponent();
        }

        public frmEnquiry(DateTime startdate, DateTime ToDate)
        {
            StartDateAB = startdate;
            ToDateAB = ToDate;
        }

        public string G_NameAB = "";
        public string EMailAB = "";
        public int ContactAB;
        public string genderAB = "";
        public DateTime DateOfEnquiryAB;
        public static string AddressAB = "";
        public static string ReasonOfEnquiryAB = "";
        public string guestEnquiryCodeAB;
        public int IDAB;
        public string StatusIDAB;
        public string FollowupNoteAB;
        public int totalRecordsAB = 0;
        public int totalPagesAB = 0;
        public int pageSizeAB = 20;
        public int currentPageAB = 1;
        public int pageNumberAB = 3;
        public System.Data.DataTable dt = new System.Data.DataTable();
        public DateTime StartDateAB;
        public DateTime ToDateAB;
        Form background;

        public HashSet<string> selectedEnquiryCodesAB = new HashSet<string>();

        //  FORM LOAD
        public void FrmEnquiry_Load(object sender, EventArgs e)
        { 
            try
            {
                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "Download The PDF");
                toolTip1.SetToolTip(pctExcel, "Export To Excel");
                toolTip1.SetToolTip(pctFilter, "Filters");
                toolTip1.SetToolTip(pctAddNewEnquiry, "Add Enquiry");

                txtSearchBox.Text = "Search Here...";
                txtSearchBox.ForeColor = Color.Gray;

                txtSearchBox.Enter += txtSearchBox_Enter;
                txtSearchBox.Leave += txtSearchBox_Leave;

                clsUser obj = new clsUser();
                dt = obj.FetchEnquiryDetailsAB();

                // Bind Grid
                grdAllGuestDetails.DataSource = dt;

                // Hide Columns
                grdAllGuestDetails.Columns["Gender"].Visible = false;
                grdAllGuestDetails.Columns["EnquiryCode"].Visible = false;

                // Header Text
                grdAllGuestDetails.Columns["GuestName"].HeaderText = "Guest Name";
                grdAllGuestDetails.Columns["FollowUpNote"].HeaderText = "FollowUp Note";
                grdAllGuestDetails.Columns["EnquiryDate"].HeaderText = "Enquiry Date";

                // Center Headers
                grdAllGuestDetails.EnableHeadersVisualStyles = false;
                grdAllGuestDetails.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // Center All Data Columns
                foreach (DataGridViewColumn col in grdAllGuestDetails.Columns)
                {
                    col.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;
                }

                // Guna2 Grid Alignment
                grdAllGuestDetails.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                grdAllGuestDetails.RowsDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                //grdAllGuestDetails.ThemeStyle.RowsStyle.Alignment =
                //    DataGridViewContentAlignment.MiddleCenter;

                //grdAllGuestDetails.ThemeStyle.HeaderStyle.Alignment =
                //    DataGridViewContentAlignment.MiddleCenter;

                // Fonts
                grdAllGuestDetails.DefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Regular);

                grdAllGuestDetails.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11, System.Drawing.FontStyle.Bold);

                // Disable Resize
                grdAllGuestDetails.AllowUserToResizeRows = false;
                grdAllGuestDetails.AllowUserToResizeColumns = false;

                // Grid Borders
                grdAllGuestDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdAllGuestDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAllGuestDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAllGuestDetails.GridColor = Color.Gray;

                // Add View Column
                if (!grdAllGuestDetails.Columns.Contains("ViewDetails"))
                {
                    DataGridViewImageColumn imgView = new DataGridViewImageColumn();
                    imgView.Name = "ViewDetails";
                    imgView.HeaderText = "View";
                    imgView.Image = Properties.Resources.view_icon;
                    imgView.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgView);
                }

                // Add Edit Column
                if (!grdAllGuestDetails.Columns.Contains("EditDetails"))
                {
                    DataGridViewImageColumn imgEdit = new DataGridViewImageColumn();
                    imgEdit.Name = "EditDetails";
                    imgEdit.HeaderText = "Edit";
                    imgEdit.Image = Properties.Resources.Edit_icon;
                    imgEdit.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgEdit);
                }

                // Add FollowUp Column
                if (!grdAllGuestDetails.Columns.Contains("AddFollowUpDetails"))
                {
                    DataGridViewImageColumn imgFollowUp = new DataGridViewImageColumn();
                    imgFollowUp.Name = "AddFollowUpDetails";
                    imgFollowUp.HeaderText = "Add FollowUp";
                    imgFollowUp.Image = Properties.Resources.AddFollowUp;
                    imgFollowUp.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgFollowUp);
                }

                // Center Image Columns
                grdAllGuestDetails.Columns["ViewDetails"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                grdAllGuestDetails.Columns["EditDetails"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                grdAllGuestDetails.Columns["AddFollowUpDetails"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                // Display Order
                int viewIndex = grdAllGuestDetails.Columns["ViewDetails"].DisplayIndex;
                grdAllGuestDetails.Columns["EditDetails"].DisplayIndex = viewIndex + 1;
                grdAllGuestDetails.Columns["AddFollowUpDetails"].DisplayIndex = viewIndex + 2;

                totalRecordsAB = dt.Rows.Count;
                totalPagesAB = (int)Math.Ceiling((double)totalRecordsAB / pageSizeAB);

                LoadPageAB();
                CreatePageButtonAB();
                CheckBoxAB();

                grdAllGuestDetails.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"An error occurred during form load: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public void RestoreColumnsAB()
        {
            try
            {
                // ---- Hide system columns ----
                if (grdAllGuestDetails.Columns.Contains("Gender"))
                    grdAllGuestDetails.Columns["Gender"].Visible = false;
                if (grdAllGuestDetails.Columns.Contains("EnquiryCode"))
                    grdAllGuestDetails.Columns["EnquiryCode"].Visible = false;

                // ---- Re-add ViewDetails if missing ----
                if (!grdAllGuestDetails.Columns.Contains("ViewDetails"))
                {
                    DataGridViewImageColumn imgview = new DataGridViewImageColumn();
                    imgview.Name = "ViewDetails";
                    imgview.HeaderText = "View";
                    imgview.Image = Properties.Resources.view_icon;
                    imgview.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgview);
                }

                // ---- Re-add EditDetails if missing ----
                if (!grdAllGuestDetails.Columns.Contains("EditDetails"))
                {
                    DataGridViewImageColumn imgUpdate = new DataGridViewImageColumn();
                    imgUpdate.Name = "EditDetails";
                    imgUpdate.HeaderText = "Edit";
                    imgUpdate.Image = Properties.Resources.Edit_icon;
                    imgUpdate.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgUpdate);
                }

                // ---- Re-add AddFollowUpDetails if missing ----
                if (!grdAllGuestDetails.Columns.Contains("AddFollowUpDetails"))
                {
                    DataGridViewImageColumn imgAddFollowUp = new DataGridViewImageColumn();
                    imgAddFollowUp.Name = "AddFollowUpDetails";
                    imgAddFollowUp.HeaderText = "Add FollowUp";
                    imgAddFollowUp.Image = Properties.Resources.AddFollowUp;
                    imgAddFollowUp.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdAllGuestDetails.Columns.Add(imgAddFollowUp);
                }

                // ---- Fix display order ----
                if (grdAllGuestDetails.Columns.Contains("ViewDetails") &&
                    grdAllGuestDetails.Columns.Contains("EditDetails") &&
                    grdAllGuestDetails.Columns.Contains("AddFollowUpDetails"))
                {
                    int viewIndex = grdAllGuestDetails.Columns["ViewDetails"].DisplayIndex;
                    grdAllGuestDetails.Columns["EditDetails"].DisplayIndex = viewIndex + 1;
                    grdAllGuestDetails.Columns["AddFollowUpDetails"].DisplayIndex = viewIndex + 2;
                }

                // ---- Re-apply fonts ----
                grdAllGuestDetails.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdAllGuestDetails.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                // ---- Re-apply column alignments ----
                foreach (DataGridViewColumn col in grdAllGuestDetails.Columns)
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                if (grdAllGuestDetails.Columns.Contains("GuestName"))
                {
                    grdAllGuestDetails.Columns["GuestName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdAllGuestDetails.Columns["GuestName"].HeaderText = "Guest Name";
                }
                if (grdAllGuestDetails.Columns.Contains("Address"))
                    grdAllGuestDetails.Columns["Address"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                if (grdAllGuestDetails.Columns.Contains("FollowUpNote"))
                {
                    grdAllGuestDetails.Columns["FollowUpNote"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                    grdAllGuestDetails.Columns["FollowUpNote"].HeaderText = "FollowUp Note";
                }
                if (grdAllGuestDetails.Columns.Contains("EnquiryDate"))
                {
                    grdAllGuestDetails.Columns["EnquiryDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    grdAllGuestDetails.Columns["EnquiryDate"].HeaderText = "Enquiry Date";
                }

                grdAllGuestDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // ---- Re-apply resize restrictions ----
                grdAllGuestDetails.AllowUserToResizeRows = false;
                grdAllGuestDetails.AllowUserToResizeColumns = false;

                // ---- Re-apply grid borders ----
                grdAllGuestDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdAllGuestDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAllGuestDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAllGuestDetails.GridColor = System.Drawing.Color.Gray;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred restoring columns: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  LOAD GRID (full refresh from DB)
        public void LoadGrid()
        {
            clsUser obj = new clsUser();
            dt = obj.FetchEnquiryDetailsAB();
            totalRecordsAB = dt.Rows.Count;
            totalPagesAB = (int)Math.Ceiling((double)totalRecordsAB / pageSizeAB);
            currentPageAB = 1;
            LoadPageAB();
            CreatePageButtonAB();
        }

        public void LoadEnquiryGrid()
        {
            clsUser obj = new clsUser();
            dt = obj.FetchEnquiryDetailsAB();
            totalRecordsAB = dt.Rows.Count;
            totalPagesAB = (int)Math.Ceiling((double)totalRecordsAB / pageSizeAB);
            currentPageAB = 1;
            LoadPageAB();
            CreatePageButtonAB();
        }

        //  DATE PICKERS
        
        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value;
                if (dtpToDate.Value < dtpFromDate.Value)
                {
                    dtpToDate.Value = dtpFromDate.Value;
                    MessageBox.Show(
                        "To Date cannot be earlier than From Date.\n\nIt has been automatically adjusted to match the selected From Date.",
                        "Invalid Date Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                FetchFromDateToDateAB();
            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}"); }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                    dtpToDate.Enabled = true;

                dtpToDate.MinDate = dtpFromDate.Value;
                grdAllGuestDetails.AutoGenerateColumns = false;
                FetchFromDateToDateAB();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

   
        //  GRID CELL CLICK (View / Edit / FollowUp)
      
        public void grdAllGuestDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                DataRow selectedRow = ((DataRowView)grdAllGuestDetails.Rows[e.RowIndex].DataBoundItem).Row;
                G_NameAB = selectedRow["GuestName"].ToString();
                genderAB = selectedRow["Gender"].ToString();
                guestEnquiryCodeAB = selectedRow["EnquiryCode"].ToString();

                string clickedColumnName = grdAllGuestDetails.Columns[e.ColumnIndex].Name;

                if (clickedColumnName == "ViewDetails")
                {
                    frmViewEnquiry f1 = new frmViewEnquiry(G_NameAB, guestEnquiryCodeAB);
                    f1.FormClosed += (s, args) => { LoadGrid(); };
                    f1.Show();
                }
                else if (clickedColumnName == "EditDetails")
                {
                    frmUpdate f2 = new frmUpdate(G_NameAB);
                    f2.FormClosed += (s, args) => { LoadGrid(); };
                    
                    
                    f2.Show();
                }
                else if (clickedColumnName == "AddFollowUpDetails")
                {
                    clsUser obj = new clsUser();
                    obj.EnquiryCodeAB = guestEnquiryCodeAB;

                    frmAddFollowUp f = new frmAddFollowUp(G_NameAB, guestEnquiryCodeAB);
                    f.FormClosed += (s, args) => { LoadGrid(); };
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while clicking grid cell: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  FETCH BY DATE RANGE
        public void FetchFromDateToDateAB()
        {
            try
            {
                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                if (fromDate < new DateTime(1753, 1, 1)) fromDate = DateTime.Now.Date;
                if (toDate < new DateTime(1753, 1, 1)) toDate = DateTime.Now.Date;

                clsUser obj = new clsUser();
                obj.StartDateAB = fromDate;
                obj.ToDateAB = toDate;

                dt = obj.FetchGuestDetailsByDateAB();
                totalRecordsAB = dt.Rows.Count;
                totalPagesAB = (int)Math.Ceiling((Double)totalRecordsAB / pageSizeAB);
                currentPageAB = 1;

                LoadPageAB();
                CreatePageButtonAB();
                CheckBoxAB();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while fetching data by date: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CheckBoxAB()
        {
            try
            {
                grdAllGuestDetails.AllowUserToAddRows = false;
                grdAllGuestDetails.ReadOnly = false;
                grdAllGuestDetails.EditMode = DataGridViewEditMode.EditOnEnter;


                if (!grdAllGuestDetails.Columns.Contains("Check"))
                {
                    MessageBox.Show("'Check' column not found in grid!", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int checkColIndex = grdAllGuestDetails.Columns["Check"].Index;

                // Only Check column is editable
                foreach (DataGridViewColumn col in grdAllGuestDetails.Columns)
                {
                    col.ReadOnly = col.Index != checkColIndex;
                }

                // Avoid duplicate header checkbox
                if (grdAllGuestDetails.Controls.OfType<CheckBox>().Count() == 0)
                {
                    CheckBox headerCheckBoxAB = new CheckBox();
                    headerCheckBoxAB.BackColor = Color.Transparent;

                    System.Drawing.Rectangle rect =
                        grdAllGuestDetails.GetCellDisplayRectangle(checkColIndex, -1, true);

                    headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                    headerCheckBoxAB.Location = new Point(
                        rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                    grdAllGuestDetails.Controls.Add(headerCheckBoxAB);

                    bool isUpdating = false;

                    headerCheckBoxAB.CheckedChanged += (s, e) =>
                    {
                        if (isUpdating) return;
                        isUpdating = true;
                        grdAllGuestDetails.EndEdit();

                        bool checkAll = headerCheckBoxAB.Checked;

                        if (dt != null)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                string code = dr["EnquiryCode"]?.ToString() ?? "";
                                if (!string.IsNullOrEmpty(code))
                                {
                                    if (checkAll)
                                        selectedEnquiryCodesAB.Add(code);
                                    else
                                        selectedEnquiryCodesAB.Remove(code);
                                }
                            }
                        }

                        foreach (DataGridViewRow row in grdAllGuestDetails.Rows)
                        {
                            if (row.IsNewRow) continue;
                            var chk = row.Cells[checkColIndex] as DataGridViewCheckBoxCell;
                            if (chk != null) chk.Value = checkAll;
                        }

                        grdAllGuestDetails.RefreshEdit();
                        isUpdating = false;
                    };

                    grdAllGuestDetails.CellValueChanged += (s, e) =>
                    {
                        if (isUpdating) return;

                        if (e.ColumnIndex == checkColIndex && e.RowIndex >= 0)
                        {
                            DataGridViewRow row = grdAllGuestDetails.Rows[e.RowIndex];
                            bool isChecked = Convert.ToBoolean(
                                row.Cells[checkColIndex].Value ?? false);

                            string enquiryCode =
                                row.Cells["EnquiryCode"].Value?.ToString() ?? "";

                            if (!string.IsNullOrEmpty(enquiryCode))
                            {
                                if (isChecked)
                                    selectedEnquiryCodesAB.Add(enquiryCode);
                                else
                                    selectedEnquiryCodesAB.Remove(enquiryCode);
                            }

                            bool allChecked = dt != null &&
                                dt.Rows.Count > 0 &&
                                dt.Rows.Cast<DataRow>().All(dr =>
                                {
                                    string c = dr["EnquiryCode"]?.ToString() ?? "";
                                    return string.IsNullOrEmpty(c) || selectedEnquiryCodesAB.Contains(c);
                                });

                            isUpdating = true;
                            headerCheckBoxAB.Checked = allChecked;
                            isUpdating = false;
                        }
                    };
                }

                grdAllGuestDetails.CurrentCellDirtyStateChanged += (s, e) =>
                {
                    if (grdAllGuestDetails.CurrentCell is DataGridViewCheckBoxCell)
                        grdAllGuestDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //  PAGINATION — LoadPageAB  
        public void LoadPageAB()
        {
            try
            {
                int startIndex = (currentPageAB - 1) * pageSizeAB;
                System.Data.DataTable dtPage = dt.Clone();

                for (int i = startIndex; i < startIndex + pageSizeAB && i < dt.Rows.Count; i++)
                    dtPage.ImportRow(dt.Rows[i]);

                grdAllGuestDetails.DataSource = dtPage;

                RestoreColumnsAB();

                if (grdAllGuestDetails.Columns.Contains("Check") &&
                    grdAllGuestDetails.Columns.Contains("EnquiryCode"))
                {
                    int checkColIndex = grdAllGuestDetails.Columns["Check"].Index;

                    // Make Check column editable
                    foreach (DataGridViewColumn col in grdAllGuestDetails.Columns)
                        col.ReadOnly = col.Index != checkColIndex;

                    foreach (DataGridViewRow row in grdAllGuestDetails.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string code = row.Cells["EnquiryCode"].Value?.ToString() ?? "";

                        if (!string.IsNullOrEmpty(code) &&
                            selectedEnquiryCodesAB.Contains(code))
                        {
                            row.Cells[checkColIndex].Value = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading page: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //  PAGINATION — Page Buttons
        public void CreatePageButtonAB()
        {
            try
            {
                int bwidth = 40;
                int bheight = 35;
                int spacing = 5;
                int start = 10;
                pnlPage.Controls.Clear();

                foreach (System.Windows.Forms.Control ctr in
                    pnlPage.Controls.OfType<Guna.UI2.WinForms.Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                        pnlPage.Controls.Remove(ctr);
                }

                int totalpages = (int)Math.Ceiling((double)dt.Rows.Count / pageSizeAB);
                totalPagesAB = totalpages;

                for (int i = 1; i <= totalpages; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new System.Drawing.Size(bwidth, bheight);
                    btnPage.Location = new System.Drawing.Point(start, 5);
                    btnPage.FillColor = (i == currentPageAB)
                        ? System.Drawing.Color.Silver
                        : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentPageAB)
                        ? System.Drawing.Color.White
                        : System.Drawing.Color.Black;
                    btnPage.Click += btnPage_Click;
                    pnlPage.Controls.Add(btnPage);
                    start += bwidth + spacing;
                }

                btnPrevious.Enabled = currentPageAB > 1;
                btnNext.Enabled = currentPageAB < totalPagesAB;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred creating page buttons: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                if (btn != null)
                {
                    currentPageAB = Convert.ToInt32(btn.Text);
                    LoadPageAB();
                    CreatePageButtonAB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on page button click: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateButtonState()
        {
            try
            {
                btnPrevious.Enabled = currentPageAB > 1;
                btnNext.Enabled = currentPageAB < totalPagesAB;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating button state: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageAB > 1)
                {
                    currentPageAB--;
                    LoadPageAB();
                    CreatePageButtonAB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on Previous button click: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageAB < totalPagesAB)
                {
                    currentPageAB++;
                    LoadPageAB();
                    CreatePageButtonAB();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred on Next button click: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      
        public System.Data.DataTable GetSelectedRowsAB()
        {
            System.Data.DataTable result = new System.Data.DataTable();

            try
            {
                grdAllGuestDetails.EndEdit();

                if (selectedEnquiryCodesAB.Count == 0)
                    return result;

                List<string> skipCols = new List<string>
                {
                    "ViewDetails", "EditDetails", "AddFollowUpDetails",
                    "Gender", "Check"
                };

                // Add columns from full dt
                foreach (DataColumn col in dt.Columns)
                {
                    if (!skipCols.Contains(col.ColumnName))
                        result.Columns.Add(col.ColumnName, typeof(object));
                }

                int srNo = 1;

                foreach (DataRow row in dt.Rows)
                {
                    string code = row["EnquiryCode"]?.ToString() ?? "";

                    if (selectedEnquiryCodesAB.Contains(code))
                    {
                        DataRow dr = result.NewRow();

                        if (result.Columns.Contains("SrNo"))
                            dr["SrNo"] = srNo++;

                        foreach (DataColumn col in result.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            dr[col.ColumnName] = row.Table.Columns.Contains(col.ColumnName)
                                ? row[col.ColumnName]
                                : DBNull.Value;
                        }

                        result.Rows.Add(dr);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting selected rows: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        //  EXPORT TO PDF

        public void ExportToPDFAB()
        {
            try
            {
                grdAllGuestDetails.EndEdit();
                grdAllGuestDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                System.Data.DataTable exportDt = GetSelectedRowsAB();

                if (exportDt == null || exportDt.Rows.Count == 0)
                {
                    MessageBox.Show("No selected data found to export!\n\nPlease select at least one row using the checkbox.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string>
                {
                    "ViewDetails", "EditDetails", "AddFollowUpDetails", "Gender", "Check","EnquiryCode"
                };

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                    PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    // Title
                    Paragraph title = new Paragraph(lblAllGuestDetails.Text,
                        FontFactory.GetFont("Arial", 16, iTextSharp.text.Font.BOLD));
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);

                    // Date
                    Paragraph date = new Paragraph(
                        "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt"),
                        FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC));
                    date.Alignment = Element.ALIGN_RIGHT;
                    date.SpacingAfter = 10;
                    doc.Add(date);

                    int visibleColumnCount = exportDt.Columns.Cast<DataColumn>()
                        .Count(c => !columnsToSkip.Contains(c.ColumnName));

                    PdfPTable table = new PdfPTable(visibleColumnCount);
                    table.WidthPercentage = 100;

                    // Headers
                    foreach (DataColumn column in exportDt.Columns)
                    {
                        if (columnsToSkip.Contains(column.ColumnName)) continue;

                        PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                            FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                        cell.BackgroundColor = new BaseColor(240, 240, 240);
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    // Rows
                    foreach (DataRow row in exportDt.Rows)
                    {
                        foreach (DataColumn column in exportDt.Columns)
                        {
                            if (columnsToSkip.Contains(column.ColumnName)) continue;

                            string value = row[column]?.ToString() ?? "";

                            if (column.ColumnName == "EnquiryDate" &&
                                DateTime.TryParse(value, out DateTime dtVal))
                            {
                                value = dtVal.ToString("dd-MM-yyyy");
                            }

                            table.AddCell(new Phrase(value,
                                FontFactory.GetFont("Arial", 10)));
                        }
                    }

                    doc.Add(table);
                    doc.Close();
                }

                MessageBox.Show($"PDF Exported Successfully!\n{exportDt.Rows.Count} record(s) exported.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

 
        //  EXPORT TO EXCEL

        public void ExportToExcelAB()
        {
            try
            {
                grdAllGuestDetails.EndEdit();
                grdAllGuestDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);

                DataTable exportDt = GetSelectedRowsAB();

                if (exportDt == null || exportDt.Rows.Count == 0)
                {
                    MessageBox.Show("No selected data found to export!\n\nPlease select at least one row using the checkbox.",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> columnsToSkip = new List<string>
                {
                    "ViewDetails", "EditDetails", "AddFollowUpDetails", "Gender", "Check","EnquiryCode"
                };

                DataTable filteredDt = new DataTable();

                foreach (DataColumn col in exportDt.Columns)
                {
                    if (!columnsToSkip.Contains(col.ColumnName))
                        filteredDt.Columns.Add(col.ColumnName);
                }

                foreach (DataRow row in exportDt.Rows)
                {
                    DataRow newRow = filteredDt.NewRow();
                    foreach (DataColumn col in filteredDt.Columns)
                    {
                        if (col.ColumnName == "EnquiryDate" &&
                            DateTime.TryParse(row[col.ColumnName]?.ToString(), out DateTime dtVal))
                        {
                            newRow[col.ColumnName] = dtVal.ToString("dd-MM-yyyy");
                        }
                        else 
                        {
                            newRow[col.ColumnName] = row[col.ColumnName];
                        }
                    }
                    filteredDt.Rows.Add(newRow);
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel (*.xlsx)|*.xlsx",
                    FileName = "SelectedData.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add("Data");

                        ws.Cell(1, 1).Value = lblAllGuestDetails.Text;
                        ws.Range(1, 1, 1, filteredDt.Columns.Count).Merge();

                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss tt");
                        ws.Range(2, 1, 2, filteredDt.Columns.Count).Merge();

                        ws.Cell(4, 1).InsertTable(filteredDt);
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show($"Excel Exported Successfully!\n{filteredDt.Rows.Count} record(s) exported.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelAB();
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            ExportToPDFAB();
        }

  
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdAllGuestDetails.DataSource == null ||
                    !(grdAllGuestDetails.DataSource is System.Data.DataTable))
                    return;

                string searchText = txtSearchBox.Text.Trim();

                if (string.IsNullOrEmpty(searchText) || searchText == "Search Here...")
                {
                    LoadPageAB();
                    return;
                }

                if (dt == null) return;

                string escapedSearchText = searchText.Replace("'", "''");
                List<string> filterList = new List<string>();

                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(string) ||
                        col.DataType == typeof(int) ||
                        col.DataType == typeof(long) ||
                        col.DataType == typeof(decimal) ||
                        col.DataType == typeof(double) ||
                        col.DataType == typeof(DateTime))
                    {
                        filterList.Add(
                            $"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escapedSearchText}%'");
                    }
                }

                string filter = string.Join(" OR ", filterList);
                dt.DefaultView.RowFilter = filter;

                totalRecordsAB = dt.DefaultView.Count;
                totalPagesAB = (int)Math.Ceiling((Double)totalRecordsAB / pageSizeAB);
                currentPageAB = 1;

                System.Data.DataTable filteredResultsDt = dt.DefaultView.ToTable();
                dt.DefaultView.RowFilter = string.Empty;

                System.Data.DataTable originalDt = dt;
                dt = filteredResultsDt;

                LoadPageAB();
                CreatePageButtonAB();

                dt = originalDt;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during search: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pctFilter_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = !pnlFilter.Visible;

                if (pnlFilter.Visible)
                {
                    pctFilter.Text = "Hide Filter";
                    pctFilter.FillColor = System.Drawing.Color.FromArgb(0, 120, 215);
                    pctFilter.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    pctFilter.Text = "Show Filter";
                    pctFilter.FillColor = System.Drawing.Color.White;
                    pctFilter.ForeColor = System.Drawing.Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during filter click: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                clsUser obj = new clsUser();
                dt = obj.FetchEnquiryDetailsAB();
                currentPageAB = 1;

        
                selectedEnquiryCodesAB.Clear();

                LoadPageAB();
                CreatePageButtonAB();
                txtSearchBox.Text = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during refresh: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = grdAllGuestDetails.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdAllGuestDetails.Rows[i];
                    if (row.IsNewRow) continue;

                    DataGridViewCheckBoxCell chk = row.Cells["Check"] as DataGridViewCheckBoxCell;
                    if (chk != null && Convert.ToBoolean(chk.Value) == true)
                        grdAllGuestDetails.Rows.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during deletion: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void OpenAddNewEnquiryForm()
        {
            frmAddNewEnquiry frm = new frmAddNewEnquiry();
            frm.Show();
        }

        private void pctAddNewEnquiry_Click(object sender, EventArgs e)
        {
            try
            {
                frmAddNewEnquiry obj = new frmAddNewEnquiry();
                obj.EnquiryAdded += NewEnquiryForm_EnquiryAdded;
                obj.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the form: " + ex.Message);
            }
        }

        private void NewEnquiryForm_EnquiryAdded(object sender, EventArgs e)
        {
            LoadEnquiryGrid();
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

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
