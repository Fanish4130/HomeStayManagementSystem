using ClosedXML.Excel;
using DocumentFormat.OpenXml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Color = System.Drawing.Color;

namespace GSTHMS
{
    public partial class frmEventService : Form
    {
        public int pageSizeRP = 5;
        public int currentPageRP = 1;
        public int totalPagesRP = 0;

        private DataTable dtFiltered = new DataTable();
        public string BookingCodeRP { get; set; }
        public string EventNameRP { get; set; }
        public int EventIDRP { get; set; }
        public int TotalCharges { get; set; }
        public  Decimal Charges { get; set; }
        
        // Keep one DataTable for the form
        private DataTable dt = new DataTable();

        // Track whether we already added the header checkbox (prevents duplicates)
        private bool headerCheckboxAdded = false;
        private CheckBox chkHeaderBox = null;

        public frmEventService()
        {
            InitializeComponent();
        }

        private void LoadEventNames()
        {
            clsUser clsUser = new clsUser();
            DataTable dtLocal = clsUser.GetEventNameRP();

            cmbbxEventname.DataSource = dtLocal;
            cmbbxEventname.ValueMember = "EventID";
            cmbbxEventname.DisplayMember = "EventName";
            cmbbxEventname.SelectedIndex = -1;

            //DataRow dr = dtLocal.NewRow();
            //dr["EventName"] = "Select Event Name";
            //dr["EventID"] = 0;
            //dtLocal.Rows.InsertAt(dr, 0);
        }

        private void LoadCustomerNames()
        {
            clsUser clsUser = new clsUser();
            DataTable dt = clsUser.GetGuestNameRP();

            if (dt.Rows.Count > 0)
            {
                cmbbxcustomername.DataSource = dt;
                cmbbxcustomername.DisplayMember = "GuestName";
                cmbbxcustomername.ValueMember = "BookingCode"; // 🔥 IMPORTANT

                cmbbxcustomername.SelectedIndex = -1;   // ✅ ADD THIS
                cmbbxcustomername.Text = "";            // ✅ ADD THIS (extra safety)
            }
        }

        private bool isFormLoaded = false;

        private void frmEventService_Load(object sender, EventArgs e)
        {
            ResetEventForm();
            LoadEventNames();
            LoadCustomerNames();
            txtTotalChargesRP.Text = "";
            grdEventService.ScrollBars = ScrollBars.None;


            isFormLoaded = true; // ✅ VERY IMPORTANT
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = " ";

            // End Date
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";

            toolTip1.SetToolTip(pctRefresh, "Refresh");
            toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            toolTip1.SetToolTip(pctExcel, "Export To Exel");
            toolTip1.SetToolTip(pctPDF, "DownLoad The PDF");
            // toolTip1.SetToolTip(pctDelete, "Delete Data");
       

            MainLoadRP();
            grdEventService.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdEventService.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdEventService.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdEventService.GridColor = System.Drawing.Color.Gray;
            grdEventService.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdEventService.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grdEventService.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            grdEventService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

        }



        private void grdEventService_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (grdEventService.IsCurrentCellDirty)
                grdEventService.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void MainLoadRP()
        {
            try
            {
                clsUser cls = new clsUser();
                dt = cls.EventServiceRP();

                if (dt == null || dt.Rows.Count == 0)
                {
                    grdEventService.DataSource = null;
                    pnlPages.Controls.Clear();
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;

                    MessageBox.Show("No event service data available.",
                        "No Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dtFiltered = dt.Copy();
                currentPageRP = 1;

                LoadPageRP();
                CreatePageButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event service data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePageButtonRP()
        {
            try
            {
                pnlPages.Controls.Clear();

                if (dtFiltered == null || dtFiltered.Rows.Count == 0)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    return;
                }

                int totalpages = (int)Math.Ceiling((double)dtFiltered.Rows.Count / pageSizeRP);
                totalPagesRP = totalpages;

                int bwidth = 40, bheight = 35, spacing = 5, start = 10;

                for (int i = 1; i <= totalpages; i++)
                {
                    Guna.UI2.WinForms.Guna2Button btnPage =
                        new Guna.UI2.WinForms.Guna2Button();

                    btnPage.Text = i.ToString();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Size = new Size(bwidth, bheight);
                    btnPage.Location = new Point(start, 5);

                    btnPage.FillColor = (i == currentPageRP) ? Color.Gray : Color.White;
                    btnPage.ForeColor = (i == currentPageRP) ? Color.White : Color.Black;

                    btnPage.Click += btnPage_Click;

                    pnlPages.Controls.Add(btnPage);
                    start += bwidth + spacing;
                }

                btnPrevious.Enabled = currentPageRP > 1;
                btnNext.Enabled = currentPageRP < totalPagesRP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pagination error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddHeaderCheckBoxRP()
        {
            // Guard: grid must have columns
            if (grdEventService.Columns == null)
                return;

            // If there are zero columns (no datasource) nothing to do
            if (grdEventService.Columns.Count == 0)
                return;

            // Ensure first column is a checkbox column. If not, insert one at index 0.
            if (!grdEventService.Columns.Contains("Check"))
            {
                var chkCol = new DataGridViewCheckBoxColumn
                {
                    Name = "Check",
                    HeaderText = "",
                    Width = 30
                };
                grdEventService.Columns.Insert(0, chkCol);
            }


            // Align all columns center
            foreach (DataGridViewColumn col in grdEventService.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // grid behavior
            grdEventService.AllowUserToAddRows = false;
            grdEventService.ReadOnly = false;
            grdEventService.EditMode = DataGridViewEditMode.EditProgrammatically;

            // Make only the checkbox column editable (index 0)
            for (int i = 0; i < grdEventService.Columns.Count; i++)
            {
                grdEventService.Columns[i].ReadOnly = (i != 0);
            }

            // Add header checkbox & handlers only once
            if (!headerCheckboxAdded)
            {
                chkHeaderBox = new CheckBox
                {
                    Size = new Size(15, 15),
                    BackColor = System.Drawing.Color.Transparent,
                    Name = "chkHeaderRP"
                };

                // Add checkbox control to grid's Controls collection
                grdEventService.Controls.Add(chkHeaderBox);

                // Position checkbox when header is painted
                grdEventService.CellPainting += GrdEventService_CellPainting_ForHeaderCheckBox;

                // When header checkbox is toggled, set all rows checkboxes
                chkHeaderBox.CheckedChanged += ChkHeaderBox_CheckedChanged;

                // Commit checkbox cell changes immediately
                grdEventService.CurrentCellDirtyStateChanged += GrdEventService_CurrentCellDirtyStateChanged;

                headerCheckboxAdded = true;
            }

            // Force a refresh so checkbox correct location is calculated
            grdEventService.Invalidate();
        }

        public void LockGrid()
        {
            grdEventService.ReadOnly = true;
            grdEventService.EditMode = DataGridViewEditMode.EditProgrammatically;

            foreach (DataGridViewColumn col in grdEventService.Columns)
            {
                col.ReadOnly = true;
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            // allow checkbox column
            if (grdEventService.Columns.Contains("Check"))
            {
                grdEventService.Columns["Check"].ReadOnly = false;
            }

            grdEventService.AllowUserToAddRows = false;
            grdEventService.AllowUserToDeleteRows = false;
            grdEventService.AllowUserToResizeRows = false;
            grdEventService.AllowUserToResizeColumns = false;
            grdEventService.MultiSelect = false;
            grdEventService.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void GrdEventService_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdEventService.CurrentCell is DataGridViewCheckBoxCell)
                {
                    grdEventService.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {
                // ignore
            }
        }

        private void ChkHeaderBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = chkHeaderBox.Checked;
                foreach (DataGridViewRow row in grdEventService.Rows)
                {
                    if (row.IsNewRow) continue;
                    var chkCell = row.Cells[0] as DataGridViewCheckBoxCell;
                    if (chkCell != null)
                        chkCell.Value = isChecked;
                }
                grdEventService.RefreshEdit();
            }
            catch
            {
                // ignore
            }
        }

        private void GrdEventService_CellPainting_ForHeaderCheckBox(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex == -1 && e.ColumnIndex == 0 && chkHeaderBox != null)
                {
                    System.Drawing.Rectangle rect = grdEventService.GetCellDisplayRectangle(0, -1, true);
                    chkHeaderBox.Location = new Point(
                        rect.X + (rect.Width - chkHeaderBox.Width) / 2,
                        rect.Y + (rect.Height - chkHeaderBox.Height) / 2
                    );
                }
            }
            catch
            {
                // ignore
            }
        }

        private void cmbbxEventname_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbbxEventname_SelectedIndexChanged(sender, e, grdEventService.CurrentRow);
        }

        private void cmbbxEventname_SelectedIndexChanged(object sender, EventArgs e, DataGridViewRow currentRow)
        {
            try
            {
                if (!isFormLoaded) return;
                if (cmbbxEventname.SelectedIndex == -1) return;

                if (cmbbxEventname.SelectedItem is DataRowView drv)
                {
                    if (drv["StartDate"] != DBNull.Value)
                        dtpStartDate.Value = Convert.ToDateTime(drv["StartDate"]);

                    if (drv["EndDate"] != DBNull.Value)
                        dtpEndDate.Value = Convert.ToDateTime(drv["EndDate"]);

                    if (drv["Charges"] != DBNull.Value)
                    {
                        decimal charges = Convert.ToDecimal(drv["Charges"]);
                        txtCharges.Text = "₹ " + charges.ToString("0.00");
                    }
                }

                dtpStartDate.Enabled = false;
                dtpEndDate.Enabled = false;
                txtCharges.ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public int EID;

      
        private void btnParticipate_Click(object sender, EventArgs e)
        {
            try
            {
                // Validation
                if (cmbbxEventname.SelectedIndex == -1)
                {
                    MessageBox.Show(
                      "Please select Event Name",
                      "Validation",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Warning
                  );
                    return;
                }

                if (cmbbxcustomername.SelectedIndex == -1)
                {
                    MessageBox.Show(
                     "Please select Customer Name",
                     "Validation",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning
                 );
                    return;
                }

                if (!int.TryParse(TxtTotalMember.Text, out int noOfGuest) || noOfGuest <= 0)
                {
                    MessageBox.Show(
                     "Enter valid guest count",
                     "Validation",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning
                 );
                    return;
                }

                if (noOfGuest > 6)
                {
                    MessageBox.Show(
                     "Max 6 members allowed",
                     "Validation",
                     MessageBoxButtons.OK,
                     MessageBoxIcon.Warning
                 );
                    return;
                }

                string bookingCode = cmbbxcustomername.SelectedValue.ToString();

                clsUser obj = new clsUser();
                obj.bookingcodeRP = bookingCode;
                obj.eventIDRP = Convert.ToInt32(cmbbxEventname.SelectedValue);
                obj.NoOfGuestRP = noOfGuest;

                obj.ProvideEventRP();

                MainLoadRP();
                ResetEventForm();

                MessageBox.Show(
                 "Event Provided Successfully",
                 "Success",
                 MessageBoxButtons.OK,
                 MessageBoxIcon.Information
             );
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNoOfGuest_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow only numbers & backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            // Prevent value > 6
            if (char.IsDigit(e.KeyChar))
            {
                string text = TxtTotalMember.Text + e.KeyChar;
                if (int.TryParse(text, out int value) && value > 6)
                {
                    e.Handled = true;
                    MessageBox.Show(
                        "Maximum 6 members allowed",
                        "Limit",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to clear all fields?",
                                                "Confirmation",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);
                // Reset form fields
                cmbbxEventname.SelectedIndex = -1;
                cmbbxEventname.SelectedItem = null;
                cmbbxEventname.Text = string.Empty;
                dtpStartDate.CustomFormat = " ";
                dtpEndDate.CustomFormat = " ";
                cmbbxcustomername.SelectedIndex = -1;
                cmbbxcustomername.SelectedItem = null;
                cmbbxcustomername.Text = string.Empty;

                txtCharges.Text = string.Empty;
                TxtTotalMember.Text = string.Empty;

                MessageBox.Show("All fields cleared successfully!",
                             "Clear Complete",
                             MessageBoxButtons.OK,
                             MessageBoxIcon.Information);
            }
            catch { /* ignore */ }
        }

        private void cmbbxcustomername_SelectedIndexChanged(object sender, EventArgs e)
        {
            // optional: handle selected customer change
        }

        // Keep for compatibility: reloads grid
        public void MainLoadRP1()
        {
            MainLoadRP();
        }

        // No pagination required - keep empty but safe
        private void CreatePagiButtonRP()
        {
            // intentionally left empty (no pagination)
        }

        // Reload the grid from your clsUser method
        private void LoadPageRP()
        {
            try
            {
                if (dtFiltered == null || dtFiltered.Rows.Count == 0)
                {
                    grdEventService.DataSource = null;
                    return;
                }

                int startIndex = (currentPageRP - 1) * pageSizeRP;

                DataTable dtPage = dtFiltered.Clone();

                for (int i = startIndex; i < startIndex + pageSizeRP && i < dtFiltered.Rows.Count; i++)
                {
                    dtPage.ImportRow(dtFiltered.Rows[i]);
                }

                grdEventService.DataSource = dtPage;

                if (grdEventService.Columns.Contains("Charges"))
                {
                    grdEventService.Columns["Charges"].DefaultCellStyle.Format = "₹ #,##0.00";
                    grdEventService.Columns["Charges"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                if (grdEventService.Columns.Contains("TotalCharges"))
                {
                    grdEventService.Columns["TotalCharges"].DefaultCellStyle.Format = "₹ #,##0.00";
                    grdEventService.Columns["TotalCharges"].DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleRight;
                }

                LockGrid();
                AddHeaderCheckBoxRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdEventService.DataSource == null)
                    return;

                DataTable dtLocal = grdEventService.DataSource as DataTable;
                if (dtLocal == null) return;

                string searchText = txtSearchBox.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    dtLocal.DefaultView.RowFilter = string.Empty;
                    return;
                }

                // Build filter for string columns only
                List<string> filterList = new List<string>();
                foreach (DataColumn col in dtLocal.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        string escaped = searchText.Replace("'", "''");
                        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
                    }
                }

                string filter = string.Join(" OR ", filterList);
                dtLocal.DefaultView.RowFilter = filter;
            }
            catch { /* ignore */ }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            // ✅ RESET HEADER CHECKBOX STATE
            headerCheckboxAdded = false;

            if (chkHeaderBox != null)
            {
                grdEventService.Controls.Remove(chkHeaderBox);
                chkHeaderBox.Dispose();
                chkHeaderBox = null;
            }
            MainLoadRP1();
        }

        public DataTable GetSelectedRowsRP()
        {
            DataTable dtSelected1RP = new DataTable();

            // Add all columns except checkbox (index 0)
            if (grdEventService.Columns.Count <= 1)
            {
                MessageBox.Show("No data columns found.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return dtSelected1RP;
            }

            for (int i = 1; i < grdEventService.Columns.Count; i++)
            {
                dtSelected1RP.Columns.Add(grdEventService.Columns[i].HeaderText);
            }

            // Add selected (checked) rows only
            grdEventService.EndEdit();
            foreach (DataGridViewRow row in grdEventService.Rows)
            {
                try
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                    {
                        DataRow drRP = dtSelected1RP.NewRow();
                        for (int i = 1; i < grdEventService.Columns.Count; i++)
                        {
                            drRP[i - 1] = row.Cells[i].Value == null ? "" : row.Cells[i].Value.ToString();
                        }
                        dtSelected1RP.Rows.Add(drRP);
                    }
                }
                catch { /* ignore conversion errors per row */ }
            }

            return dtSelected1RP;
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtRP = GetSelectedRowsRP();
                if (dtRP == null || dtRP.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "PDF Files (.pdf)|.pdf",
                    Title = "Save PDF File",
                    FileName = "SelectedRows.pdf"
                };

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathRP = saveFileDialog.FileName;

                Document docRP = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(filePathRP, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph(pctPDF.Text,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                title.Alignment = Element.ALIGN_CENTER;
                docRP.Add(title);

                Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
                date.Alignment = Element.ALIGN_RIGHT;
                date.SpacingAfter = 10;
                docRP.Add(date);

                PdfPTable table = new PdfPTable(dtRP.Columns.Count);

                foreach (DataColumn column in dtRP.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName, FontFactory.GetFont("Arial", 11, iTextSharp.text.Font.BOLD)));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                foreach (DataRow row in dtRP.Rows)
                {
                    foreach (var value in row.ItemArray)
                    {
                        table.AddCell(new Phrase(value.ToString(), FontFactory.GetFont("Arial", 10)));
                    }
                }

                docRP.Add(table);
                docRP.Close();

                MessageBox.Show("PDF File Saved Successfully!\n" + filePathRP, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcelRP()
        {
            try
            {
                DataTable dtRP = GetSelectedRowsRP();

                if (dtRP == null || dtRP.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog
                {
                    Filter = "Excel Workbook|*.xlsx",
                    FileName = "SelectedGuestData.xlsx"
                };

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Selected Rows");

                        ws.Cell(1, 1).Value = pctExcel.Text;
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, dtRP.Columns.Count).Merge();

                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Range(2, 1, 2, dtRP.Columns.Count).Merge();

                        ws.Cell(4, 1).InsertTable(dtRP);

                        var header = ws.Range(4, 1, 4, dtRP.Columns.Count);
                        header.Style.Font.Bold = true;
                        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Selected rows exported to Excel successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            ExportToExcelRP();
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChecked = false;

                for (int i = grdEventService.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdEventService.Rows[i];
                    try
                    {
                        if (row.Cells.Count > 0 && row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value) == true)
                        {
                            grdEventService.Rows.RemoveAt(i);
                            anyChecked = true;
                        }
                    }
                    catch { /* ignore per-row errors */ }
                }

                if (!anyChecked)
                {
                    MessageBox.Show("plz select a row to delete!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting rows: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctDelete_Click_1(object sender, EventArgs e)
        {
            bool anyChecked = false;


            for (int i = grdEventService.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = grdEventService.Rows[i];
                if (Convert.ToBoolean(row.Cells["Check"].Value) == true)
                {
                    grdEventService.Rows.RemoveAt(i);
                    anyChecked = true;
                }

            }
            if (!anyChecked)
            {
                MessageBox.Show("plz select a row to delete!", "Warning",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            }
        }

        private void dtpEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = "dd MMMM yyyy";
        }

        private void TxtTotalMember_TextChanged(object sender, EventArgs e)
        {
            // STEP 1: Clean ₹ symbol
            string chargeText = txtCharges.Text.Replace("₹", "").Trim();

            // STEP 2: Validation + Calculation
            if (!string.IsNullOrWhiteSpace(TxtTotalMember.Text) &&
                decimal.TryParse(TxtTotalMember.Text, out decimal member) &&
                decimal.TryParse(chargeText, out decimal charges))
            {
                decimal total = member * charges;
                txtTotalChargesRP.Text = "₹ " + total.ToString("0.00");
            }
            else
            {
                txtTotalChargesRP.Text = "";
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdEventService_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (grdEventService.Columns[e.ColumnIndex].Name == "NoOfGuest")
                {
                    DataGridViewRow row = grdEventService.Rows[e.RowIndex];

                    // Read numeric values directly
                    if (decimal.TryParse(row.Cells["Charges"].Value?.ToString(), out decimal charges) &&
                        int.TryParse(row.Cells["NoOfGuest"].Value?.ToString(), out int participants))
                    {
                        decimal totalCharges = charges * participants;

                        // Set numeric value (NOT formatted string)
                        row.Cells["TotalCharges"].Value = totalCharges;

                        // Format textbox only
                        txtTotalChargesRP.Text = "₹ " + totalCharges.ToString("N2");
                    }
                    else
                    {
                        row.Cells["TotalCharges"].Value = DBNull.Value;
                        txtTotalChargesRP.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dtpStartDate_ValueChanged(object sender, EventArgs e)
        {

            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = "dd MMMM yyyy";
        }
        private void ResetEventForm()
        {
            // ===============================
            // ComboBoxes
            // ===============================
            cmbbxEventname.SelectedIndex = -1;
            cmbbxcustomername.SelectedIndex = -1;

            // ===============================
            // TextBoxes
            // ===============================
            txtCharges.Clear();
            TxtTotalMember.Clear();
            txtTotalChargesRP.Text = "";
            txtSearchBox.Clear();

            // ===============================
            // DateTimePickers (IMPORTANT)
            // ===============================
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.CustomFormat = " ";

            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.CustomFormat = " ";

            // ===============================
            // Focus
            // ===============================
            cmbbxEventname.Focus();
        }

        private void grdEventService_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {

            try
            {
                if (currentPageRP > 1)
                {
                    currentPageRP--;
                    LoadPageRP();
                    CreatePageButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Previous page error:\n" + ex.Message);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPageRP < totalPagesRP)
                {
                    currentPageRP++;
                    LoadPageRP();
                    CreatePageButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Next page error:\n" + ex.Message);
            }
        }
        private void btnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna.UI2.WinForms.Guna2Button btn =
                    sender as Guna.UI2.WinForms.Guna2Button;

                if (btn != null)
                {
                    currentPageRP = Convert.ToInt32(btn.Text);
                    LoadPageRP();
                    CreatePageButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Page change error:\n" + ex.Message);
            }
        }

        private void pnlPages_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
