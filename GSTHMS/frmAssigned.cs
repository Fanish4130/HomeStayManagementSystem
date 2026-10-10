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
    public partial class frmAssignedTask : Form
    {
        int pagesizeRP = 20;
        int currentpageRP = 1;
        int totrecordsRP = 0;
        int totpageRP = 0;
        int CapacityRP;
        string RoomTypeRP;
        DataTable dtFiltered = null;
        bool isFormLoaded = false;
        bool isUpdatingDate = false;
        DataTable dt = new DataTable();
        bool isFilterActive = false;
        HashSet<string> selectedTaskKeysRP = new HashSet<string>();
        bool isSettingCheckRP = false;
        CheckBox chkHeaderRP = null;
        private string filePathRP;
        private bool headerCheckboxAdded = false;
        public frmAssignedTask()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAssignedTask_Load(object sender, EventArgs e)
        {
            try
            {
                isFormLoaded = false;

                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "dd MMMM yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "dd MMMM yyyy";

                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;
                grdAssignTask.ScrollBars = ScrollBars.None;

                MainLoadRP();

                isFormLoaded = true;


                pnlFilter.Visible = true;
                grdAssignTask.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdAssignTask.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAssignTask.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdAssignTask.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAssignTask.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdAssignTask.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 9);
                grdAssignTask.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 9);
                grdAssignTask.GridColor = System.Drawing.Color.Gray;
                grdAssignTask.RowTemplate.Height = 24;
                grdAssignTask.ColumnHeadersHeight = 28;
                grdAssignTask.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

                toolTip2.SetToolTip(pctRefresh, "Refresh");
                toolTip2.SetToolTip(pctPDF, "Export PDF");
                toolTip2.SetToolTip(pctExcel, "Export Excel");
                toolTip2.SetToolTip(pctFilter, "Filters");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainLoadRP()
        {
            try
            {
                this.grdAssignTask.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 10);

                clsUser cls = new clsUser();
                dt = cls.AssignedTaskRP();

                dt.DefaultView.RowFilter = string.Empty;

                currentpageRP = 1;
                LoadPageRP();
                CreatePagiButtonRP();
                LockGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddHeaderCheckBoxRP()
        {
            try
            {
                if (grdAssignTask.Columns == null) return;
                if (grdAssignTask.Columns.Count == 0) return;

                if (grdAssignTask.Columns.Contains("Check"))
                    grdAssignTask.Columns["Check"].HeaderText = "";

                grdAssignTask.Columns["Check"].Width = 105;

                if (chkHeaderRP == null)
                {
                    chkHeaderRP = new CheckBox();
                    chkHeaderRP.Size = new Size(15, 15);
                    chkHeaderRP.BackColor = Color.Transparent;
                    grdAssignTask.Controls.Add(chkHeaderRP);

                    chkHeaderRP.CheckedChanged += ChkHeaderRP_CheckedChanged;
                }

                System.Drawing.Rectangle rect =
     grdAssignTask.GetCellDisplayRectangle(
     grdAssignTask.Columns["Check"].Index, -1, true);

                // Checkbox size
                chkHeaderRP.Size = new Size(15, 15);

                // Perfect center alignment
                chkHeaderRP.Location = new Point(
                    rect.X + (rect.Width - chkHeaderRP.Width) / 2,
                    rect.Y + (rect.Height - chkHeaderRP.Height) / 2
                );

                grdAssignTask.CellClick -= grdAssignTask_CellClick;
                grdAssignTask.CellClick += grdAssignTask_CellClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding checkbox:\n" + ex.Message);
            }
        }

        private void ChkHeaderRP_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (isSettingCheckRP) return;

                isSettingCheckRP = true;

                bool checkAll = chkHeaderRP.Checked;
                DataTable source = isFilterActive ? dtFiltered : dt;

                selectedTaskKeysRP.Clear();

                if (checkAll && source != null)
                {
                    foreach (DataRow dr in source.Rows)
                        selectedTaskKeysRP.Add(GetRowKeyRP(dr));
                }

                foreach (DataGridViewRow row in grdAssignTask.Rows)
                {
                    if (row.IsNewRow) continue;
                    row.Cells["Check"].Value = checkAll;
                }

                grdAssignTask.Refresh();
                isSettingCheckRP = false;
            }
            catch
            {
                isSettingCheckRP = false;
            }
        }
        private void grdAssignTask_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (grdAssignTask.Columns[e.ColumnIndex].Name != "Check") return;

                DataGridViewRow row = grdAssignTask.Rows[e.RowIndex];

                bool currentValue = false;

                if (row.Cells["Check"].Value != null &&
                    row.Cells["Check"].Value != DBNull.Value)
                {
                    currentValue = Convert.ToBoolean(row.Cells["Check"].Value);
                }

                bool newValue = !currentValue;
                row.Cells["Check"].Value = newValue;

                string key = GetRowKeyRP(row);

                if (newValue)
                    selectedTaskKeysRP.Add(key);
                else
                    selectedTaskKeysRP.Remove(key);

                grdAssignTask.Refresh();
            }
            catch { }
        }

        //private void grdAssignTask_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && grdAssignTask.Columns[e.ColumnIndex].Name == "Check")
        //    {
        //        grdAssignTask.EndEdit();

        //        bool isChecked = Convert.ToBoolean(
        //            grdAssignTask.Rows[e.RowIndex].Cells["Check"].Value ?? false
        //        );

        //        string key = GetRowKeyRP(grdAssignTask.Rows[e.RowIndex]);

        //        if (isChecked)
        //            selectedTaskKeysRP.Add(key);
        //        else
        //            selectedTaskKeysRP.Remove(key);

        //        UpdateHeaderCheckBoxRP();
        //    }
        //}

        private string GetRowKeyRP(DataRow dr)
        {
            if (dr.Table.Columns.Contains("Sr.No"))
                return dr["Sr.No"].ToString();

            return dr[0].ToString();
        }

        private string GetRowKeyRP(DataGridViewRow row)
        {
            if (grdAssignTask.Columns.Contains("Sr.No"))
                return row.Cells["Sr.No"].Value.ToString();

            return row.Cells[1].Value.ToString();
        }

        private void ApplySavedCheckStateRP()
        {
            try
            {
                isSettingCheckRP = true;

                foreach (DataGridViewRow row in grdAssignTask.Rows)
                {
                    string key = GetRowKeyRP(row);
                    row.Cells["Check"].Value = selectedTaskKeysRP.Contains(key);
                }

                isSettingCheckRP = false;
            }
            catch
            {
                isSettingCheckRP = false;
            }
        }

        private void grdAssignTask_CurrentCellDirtyStateChangedRP(object sender, EventArgs e)
        {
            try
            {
                if (grdAssignTask.IsCurrentCellDirty)
                {
                    grdAssignTask.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {

            }
        }

        private void grdAssignTask_CellValueChangedRP(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (isSettingCheckRP) return;
            //    if (e.RowIndex < 0) return;
            //    if (grdAssignTask.Columns[e.ColumnIndex].Name != "Check") return;

            //    string key = GetRowKeyRP(grdAssignTask.Rows[e.RowIndex]);
            //    bool isChecked = Convert.ToBoolean(grdAssignTask.Rows[e.RowIndex].Cells["Check"].Value ?? false);

            //    if (isChecked)
            //        selectedTaskKeysRP.Add(key);
            //    else
            //        selectedTaskKeysRP.Remove(key);

            //    UpdateHeaderCheckBoxRP();
            //}
            //catch { }
        }

        public void LockGrid()
        {
            try
            {
                grdAssignTask.ReadOnly = false;
                grdAssignTask.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdAssignTask.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (grdAssignTask.Columns.Contains("Check"))
                    grdAssignTask.Columns["Check"].ReadOnly = true;

                grdAssignTask.EditMode = DataGridViewEditMode.EditProgrammatically;

                grdAssignTask.AllowUserToAddRows = false;
                grdAssignTask.AllowUserToDeleteRows = false;
                grdAssignTask.AllowUserToResizeRows = false;
                grdAssignTask.AllowUserToResizeColumns = false;
                grdAssignTask.MultiSelect = false;
                grdAssignTask.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error locking grid:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadPageRP()
        {
            try
            {
                DataTable source = isFilterActive ? dtFiltered : dt;
                if (source == null) return;

                int startIndex = (currentpageRP - 1) * pagesizeRP;

                DataTable temp = new DataTable();
                temp.Columns.Add("Check", typeof(bool));

                foreach (DataColumn col in source.Columns)
                {
                    if (col.ColumnName != "Check")
                        temp.Columns.Add(col.ColumnName, col.DataType);
                }

                for (int i = startIndex; i < startIndex + pagesizeRP && i < source.Rows.Count; i++)
                {
                    DataRow newRow = temp.NewRow();

                    string key = GetRowKeyRP(source.Rows[i]);
                    newRow["Check"] = selectedTaskKeysRP.Contains(key);

                    foreach (DataColumn col in source.Columns)
                    {
                        if (col.ColumnName != "Check")
                            newRow[col.ColumnName] = source.Rows[i][col.ColumnName];
                    }

                    temp.Rows.Add(newRow);
                }

                grdAssignTask.DataSource = null;
                grdAssignTask.Columns.Clear();
                grdAssignTask.DataSource = temp;

                AddHeaderCheckBoxRP();
                SetGridColumnWidthRP();
                LockGrid();
                UpdateHeaderCheckBoxRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page:\n" + ex.Message);
            }
        }

        public void CreatePagiButtonRP()
        {
            try
            {
                int bwidthRP = 40;
                int bheightRP = 35;
                int spacingRP = 5;
                int startXRP = 10;

                pnlPagination.Controls.Clear();

                foreach (Control ctr in pnlPagination.Controls.OfType<Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlPagination.Controls.Remove(ctr);
                    }
                }

                int recordCount = isFilterActive ? dtFiltered.Rows.Count : dt.Rows.Count;
                int totalPagesRP = (int)Math.Ceiling((double)recordCount / pagesizeRP);

                if (totalPagesRP <= 1)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    pnlPagination.Visible = false;
                    return;
                }
                else
                {
                    pnlPagination.Visible = true;
                }

                totpageRP = totalPagesRP;

                for (int i = 1; i <= totalPagesRP; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidthRP, bheightRP);
                    btnPage.Location = new Point(startXRP, 5);
                    btnPage.FillColor = (i == currentpageRP) ? Color.Gray : Color.White;
                    btnPage.ForeColor = (i == currentpageRP) ? Color.White : Color.Black;
                    btnPage.Click += BtnPage_Click;

                    pnlPagination.Controls.Add(btnPage);
                    startXRP += bwidthRP + spacingRP;
                }

                btnPrevious.Enabled = currentpageRP > 1;
                btnNext.Enabled = currentpageRP < totpageRP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating pagination:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetGridColumnWidthRP()
        {
            try
            {
                if (grdAssignTask.Columns.Count == 0)
                    return;

                grdAssignTask.Columns[0].Width = 70;
                grdAssignTask.Columns["Sr.No"].Width = 70;
                grdAssignTask.Columns["StaffName"].Width = 140;
                grdAssignTask.Columns["AssignedDate"].Width = 120;
                grdAssignTask.Columns["DueDate"].Width = 120;
                grdAssignTask.Columns["Description_Task"].Width = 200;
                grdAssignTask.Columns["Status"].Width = 140;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting column width:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BtnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;

                if (btn != null)
                {
                    int pageNumberRP = Convert.ToInt32(btn.Text);
                    currentpageRP = pageNumberRP;
                    LoadPageRP();
                    CreatePagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing page:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentpageRP > 1)
                {
                    currentpageRP--;
                    LoadPageRP();
                    CreatePagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentpageRP < totpageRP)
                {
                    currentpageRP++;
                    LoadPageRP();
                    CreatePagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSelectedRowsRP()
        {
            DataTable dtSelected = new DataTable();

            try
            {
                DataTable source = isFilterActive ? dtFiltered : dt;
                dtSelected = source.Clone();

                foreach (DataRow dr in source.Rows)
                {
                    if (selectedTaskKeysRP.Contains(GetRowKeyRP(dr)))
                        dtSelected.ImportRow(dr);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelected;
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            Document docRP = null;

            try
            {
                DataTable dtRP = GetSelectedRowsRP();

                if (dtRP == null || dtRP.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = " Staff Details.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                docRP = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(saveFileDialog.FileName, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph("Assigned Task",
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16, iTextSharp.text.Font.BOLD));
                title.Alignment = Element.ALIGN_CENTER;
                docRP.Add(title);

                Paragraph date = new Paragraph("Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                    new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10, iTextSharp.text.Font.ITALIC));
                date.Alignment = Element.ALIGN_RIGHT;
                date.SpacingAfter = 10;
                docRP.Add(date);

                PdfPTable table = new PdfPTable(dtRP.Columns.Count);
                table.WidthPercentage = 100;

                foreach (DataColumn column in dtRP.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName,
                        FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }

                foreach (DataRow row in dtRP.Rows)
                {
                    foreach (DataColumn col in dtRP.Columns)
                    {
                        object value = row[col];
                        string displayValue = value.ToString();

                        if (col.ColumnName == "AssignedDate" || col.ColumnName == "DueDate")
                        {
                            if (DateTime.TryParse(value.ToString(), out DateTime dt))
                            {
                                displayValue = dt.ToString("dd-MM-yyyy");
                            }
                        }

                        PdfPCell cell = new PdfPCell(
                            new Phrase(displayValue, FontFactory.GetFont("Arial", 8)));

                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }
                }

                docRP.Add(table);
                docRP.Close();

                MessageBox.Show("PDF File Saved Successfully!\n" + filePathRP,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                if (docRP != null && docRP.IsOpen())
                    docRP.Close();

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcelRP()
        {
            try
            {
                DataTable dtRP = GetSelectedRowsRP();

                if (dtRP == null || dtRP.Rows.Count == 0)
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

                        ws.Cell(1, 1).Value = lblTask1.Text;
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

                    MessageBox.Show("Excel File Saved Successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel Export Error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcelRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChecked = false;

                for (int i = grdAssignTask.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdAssignTask.Rows[i];

                    if (row.Cells["Check"].Value != null &&
                        Convert.ToBoolean(row.Cells["Check"].Value) == true)
                    {
                        grdAssignTask.Rows.RemoveAt(i);
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearchBox.Text.Trim().ToLower();

                if (dt == null || dt.Rows.Count == 0)
                    return;

                if (string.IsNullOrEmpty(searchText))
                {
                    isFilterActive = false;
                    dtFiltered = null;
                }
                else
                {
                    var rows = dt.AsEnumerable()
                        .Where(row => row.ItemArray.Any(value =>
                            value != null &&
                            value != DBNull.Value &&
                            value.ToString().ToLower().Contains(searchText)));

                    dtFiltered = rows.Any()
                        ? rows.CopyToDataTable()
                        : dt.Clone();

                    isFilterActive = true;
                }

                currentpageRP = 1;
                LoadPageRP();
                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshAssignedTask()
        {
            try
            {

                selectedTaskKeysRP.Clear();

                if (chkHeaderRP != null)
                {
                    isSettingCheckRP = true;
                    chkHeaderRP.Checked = false;
                    isSettingCheckRP = false;
                }

                isFormLoaded = false;

                txtSearchBox.TextChanged -= txtSearchBox_TextChanged;
                txtSearchBox.Text = "";
                txtSearchBox.TextChanged += txtSearchBox_TextChanged;

                dtpFromDate.Value = DateTime.Today;
                dtpFromDate.MaxDate = DateTimePicker.MaximumDateTime;
                dtpToDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpToDate.Value = DateTime.Today;

                isFilterActive = false;
                dtFiltered = null;

                pnlFilter.Visible = true;

                currentpageRP = 1;

                MainLoadRP();

                grdAssignTask.ClearSelection();

                foreach (Control c in grdAssignTask.Controls)
                {
                    if (c is CheckBox chk)
                    {
                        chk.Checked = false;
                        break;
                    }
                }

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                isFilterActive = false;
                dtFiltered = null;

                txtSearchBox.TextChanged -= txtSearchBox_TextChanged;
                txtSearchBox.Text = "";
                txtSearchBox.TextChanged += txtSearchBox_TextChanged;

                currentpageRP = 1;
                MainLoadRP();
                isFormLoaded = true;
                RefreshAssignedTask();

                if (dt != null)
                    dt.DefaultView.RowFilter = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ApplyDateFilterRP()
        {
            try
            {
                if (dt == null || dt.Rows.Count == 0)
                    return;

                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                var filteredRows = dt.AsEnumerable()
                    .Where(r =>
                    {
                        if (r["AssignedDate"] == DBNull.Value)
                            return false;

                        DateTime assignedDate = Convert.ToDateTime(r["AssignedDate"]).Date;

                        return assignedDate >= fromDate && assignedDate <= toDate;
                    });

                dtFiltered = filteredRows.Any()
                    ? filteredRows.CopyToDataTable()
                    : dt.Clone();

                isFilterActive = true;

                currentpageRP = 1;
                LoadPageRP();
                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Date Filter Error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadFilteredPageRP()
        {
            try
            {
                if (dtFiltered == null)
                    return;

                int startIndex = (currentpageRP - 1) * pagesizeRP;
                DataTable temp = dtFiltered.Clone();

                for (int i = startIndex; i < startIndex + pagesizeRP && i < dtFiltered.Rows.Count; i++)
                {
                    temp.ImportRow(dtFiltered.Rows[i]);
                }

                grdAssignTask.DataSource = temp;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = !pnlFilter.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;

                dtpToDate.MinDate = dtpFromDate.Value.Date;
                ApplyDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;

                dtpFromDate.MaxDate = dtpToDate.Value.Date;
                ApplyDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlPagination_Paint(object sender, PaintEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblTask1_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateHeaderCheckBoxRP()
        {
            try
            {
                if (chkHeaderRP == null)
                    return;

                // Header checkbox cha state same thev
                chkHeaderRP.Refresh();
            }
            catch
            {
                isSettingCheckRP = false;
            }
        }

        private void grdAssignTask_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //   if (e.RowIndex < 0) return;
            //   if (grdAssignTask.Columns[e.ColumnIndex].Name != "Check") return;

            //       grdAssignTask.CommitEdit(DataGridViewDataErrorContexts.Commit);
            //      grdAssignTask.EndEdit();

            //       bool isChecked = Convert.ToBoolean(grdAssignTask.Rows[e.RowIndex].Cells["Check"].Value ?? false);
            //       string key = GetRowKeyRP(grdAssignTask.Rows[e.RowIndex]);

            //       if (isChecked)
            //         selectedTaskKeysRP.Add(key);
            //        else
            //            selectedTaskKeysRP.Remove(key);

            //        UpdateHeaderCheckBoxRP();
            //   }
            //   catch (Exception ex)
            //   {
            //        MessageBox.Show(ex.Message);
            //   }
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}