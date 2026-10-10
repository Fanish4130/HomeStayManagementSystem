using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Rectangle = System.Drawing.Rectangle;

namespace GSTHMS
{
    public partial class frmstaffDetails : Form
    {
        int pagesizeRP = 15;
        int currentpageRP = 1;
        int totpageRP = 0;

        DataTable dt = new DataTable();
        DataTable dtFiltered = null;
        bool isFilterActive = false;

        CheckBox chkHeaderRP = null;
        HashSet<string> selectedStaffKeysRP = new HashSet<string>();
        bool isSettingStaffCheckRP = false;
        private string filePathRP;

        public frmstaffDetails()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmstaffDetails_Load(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = true;
                grdstaffDetails.ScrollBars = ScrollBars.None;

                btnNext.Click -= btnNext_Click;
                btnNext.Click += btnNext_Click;

                btnPrevious.Click -= btnPrevious_Click;
                btnPrevious.Click += btnPrevious_Click;

                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "Export PDF");
                toolTip1.SetToolTip(pctExcel, "Export Excel");
                toolTip1.SetToolTip(pctFilter, "Filters");

                dtpFromDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.CustomFormat = "dd MMMM yyyy";

                dtpToDate.Format = DateTimePickerFormat.Custom;
                dtpToDate.CustomFormat = "dd MMMM yyyy";

                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;

                LoadPositionComboRP();
                MainLoadRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPositionComboRP()
        {
            try
            {
                cmbPosition.SelectedIndexChanged -= cmbPosition_SelectedIndexChanged;

                clsUser obj = new clsUser();
                DataTable dtPosition = obj.GetPositionRP();

                cmbPosition.DataSource = null;
                cmbPosition.Items.Clear();

                cmbPosition.DisplayMember = "PositionName";
                cmbPosition.ValueMember = "PositionID";
                cmbPosition.DataSource = dtPosition;

                cmbPosition.SelectedIndex = -1;
                cmbPosition.Text = "";

                cmbPosition.SelectedIndexChanged += cmbPosition_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainLoadRP()
        {
            try
            {
                clsUser obj = new clsUser();
                dt = obj.ShowStaffDetailsRP();

                currentpageRP = 1;
                isFilterActive = false;
                dtFiltered = null;

                LoadPageRP();
                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    string key = GetStaffKeyRP(source.Rows[i]);
                    newRow["Check"] = selectedStaffKeysRP.Contains(key);

                    foreach (DataColumn col in source.Columns)
                    {
                        if (col.ColumnName != "Check")
                            newRow[col.ColumnName] = source.Rows[i][col.ColumnName];
                    }

                    temp.Rows.Add(newRow);
                }

                grdstaffDetails.DataSource = null;
                grdstaffDetails.Columns.Clear();
                grdstaffDetails.DataSource = temp;

                GridDesignRP();
                AddHeaderCheckBoxRP();
                LockGridRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void GridDesignRP()
        {
            try
            {
                if (grdstaffDetails.Columns.Count == 0) return;

                grdstaffDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                grdstaffDetails.RowHeadersVisible = false;

                grdstaffDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdstaffDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdstaffDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdstaffDetails.GridColor = Color.Gray;

                grdstaffDetails.EnableHeadersVisualStyles = false;
                grdstaffDetails.ColumnHeadersDefaultCellStyle.BackColor = Color.DimGray;
                grdstaffDetails.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                grdstaffDetails.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdstaffDetails.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdstaffDetails.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdstaffDetails.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                grdstaffDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.Gainsboro;
                grdstaffDetails.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                grdstaffDetails.DefaultCellStyle.SelectionForeColor = Color.Black;
                grdstaffDetails.RowTemplate.Height = 35;

                if (grdstaffDetails.Columns.Contains("Check"))
                {
                    grdstaffDetails.Columns["Check"].Width = 60;
                    grdstaffDetails.Columns["Check"].HeaderText = "";
                }
                else
                    grdstaffDetails.Columns[0].Width = 45;

                if (grdstaffDetails.Columns.Contains("StaffID"))
                    grdstaffDetails.Columns["StaffID"].Width = 70;

                if (grdstaffDetails.Columns.Contains("StaffCode"))
                    grdstaffDetails.Columns["StaffCode"].Width = 90;

                if (grdstaffDetails.Columns.Contains("StaffName"))
                    grdstaffDetails.Columns["StaffName"].Width = 100;

                if (grdstaffDetails.Columns.Contains("Gender"))
                    grdstaffDetails.Columns["Gender"].Width = 70;

                if (grdstaffDetails.Columns.Contains("ContactNo"))
                    grdstaffDetails.Columns["ContactNo"].Width = 100;

                if (grdstaffDetails.Columns.Contains("Email"))
                    grdstaffDetails.Columns["Email"].Width = 200;

                if (grdstaffDetails.Columns.Contains("Address"))
                    grdstaffDetails.Columns["Address"].Width = 100;

                if (grdstaffDetails.Columns.Contains("PinCode"))
                    grdstaffDetails.Columns["PinCode"].Width = 70;

                if (grdstaffDetails.Columns.Contains("JoinDate"))
                    grdstaffDetails.Columns["JoinDate"].Width = 91;

                if (grdstaffDetails.Columns.Contains("PositionName"))
                    grdstaffDetails.Columns["PositionName"].Width = 100;

                if (grdstaffDetails.Columns.Contains("BloodGroup"))
                    grdstaffDetails.Columns["BloodGroup"].Width = 90;

                if (grdstaffDetails.Columns.Contains("Status"))
                    grdstaffDetails.Columns["Status"].Width = 90;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddHeaderCheckBoxRP()
        {
            try
            {
                if (chkHeaderRP != null)
                {
                    grdstaffDetails.Controls.Remove(chkHeaderRP);
                    chkHeaderRP.Dispose();
                    chkHeaderRP = null;
                }

                if (!grdstaffDetails.Columns.Contains("Check"))
                    return;

                grdstaffDetails.Columns["Check"].HeaderText = "";
                grdstaffDetails.Columns["Check"].Width = 50;
                grdstaffDetails.Columns["Check"].ReadOnly = false;

                chkHeaderRP = new CheckBox();
                chkHeaderRP.Size = new Size(15, 15);
                chkHeaderRP.BackColor = Color.Transparent;

                grdstaffDetails.Controls.Add(chkHeaderRP);

                Rectangle rect = grdstaffDetails.GetCellDisplayRectangle(
                    grdstaffDetails.Columns["Check"].Index, -1, true);

                chkHeaderRP.Location = new Point(
                    rect.X + (rect.Width - chkHeaderRP.Width) / 2,
                    rect.Y + (rect.Height - chkHeaderRP.Height) / 2
                );

                chkHeaderRP.CheckedChanged += (s, e) =>
                {
                    try
                    {
                        if (isSettingStaffCheckRP) return;

                        isSettingStaffCheckRP = true;

                        bool checkAll = chkHeaderRP.Checked;

                        selectedStaffKeysRP.Clear();

                        DataTable source = isFilterActive ? dtFiltered : dt;

                        if (checkAll)
                        {
                            foreach (DataRow dr in source.Rows)
                                selectedStaffKeysRP.Add(GetStaffKeyRP(dr));
                        }

                        grdstaffDetails.EndEdit();

                        foreach (DataGridViewRow row in grdstaffDetails.Rows)
                        {
                            if (row.IsNewRow) continue;

                            row.Cells["Check"].Value = checkAll;

                            DataRowView drv = row.DataBoundItem as DataRowView;
                            if (drv != null && drv.Row.Table.Columns.Contains("Check"))
                            {
                                drv.Row["Check"] = checkAll;
                            }
                        }

                        grdstaffDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        grdstaffDetails.RefreshEdit();
                        grdstaffDetails.Refresh();

                        isSettingStaffCheckRP = false;
                    }
                    catch (Exception ex)
                    {
                        isSettingStaffCheckRP = false;
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                grdstaffDetails.CurrentCellDirtyStateChanged -= grdstaffDetails_CurrentCellDirtyStateChangedRP;
                grdstaffDetails.CurrentCellDirtyStateChanged += grdstaffDetails_CurrentCellDirtyStateChangedRP;

                grdstaffDetails.CellValueChanged -= grdstaffDetails_CellValueChangedRP;
                grdstaffDetails.CellValueChanged += grdstaffDetails_CellValueChangedRP;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetStaffKeyRP(DataRow dr)
        {
            if (dr.Table.Columns.Contains("StaffCode"))
                return dr["StaffCode"].ToString();

            if (dr.Table.Columns.Contains("StaffID"))
                return dr["StaffID"].ToString();

            return dr[0].ToString();
        }

        private string GetStaffKeyRP(DataGridViewRow row)
        {
            if (row.Cells["StaffCode"].Value != null)
                return row.Cells["StaffCode"].Value.ToString();

            if (row.Cells["StaffID"].Value != null)
                return row.Cells["StaffID"].Value.ToString();

            return "";
        }

        private void ApplySavedStaffCheckStateRP()
        {
            try
            {
                isSettingStaffCheckRP = true;

                foreach (DataGridViewRow row in grdstaffDetails.Rows)
                {
                    if (row.IsNewRow) continue;

                    string key = GetStaffKeyRP(row);
                    row.Cells["Check"].Value = selectedStaffKeysRP.Contains(key);
                }

                grdstaffDetails.Refresh();

                isSettingStaffCheckRP = false;
            }
            catch
            {
                isSettingStaffCheckRP = false;
            }
        }

        private void grdstaffDetails_CurrentCellDirtyStateChangedRP(object sender, EventArgs e)
        {
            try
            {
                if (grdstaffDetails.IsCurrentCellDirty)
                {
                    grdstaffDetails.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch { }
        }

        private void grdstaffDetails_CellValueChangedRP(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isSettingStaffCheckRP) return;
                if (e.RowIndex < 0) return;
                if (grdstaffDetails.Columns[e.ColumnIndex].Name != "Check") return;

                string key = GetStaffKeyRP(grdstaffDetails.Rows[e.RowIndex]);
                bool isChecked = Convert.ToBoolean(grdstaffDetails.Rows[e.RowIndex].Cells["Check"].Value);

                if (isChecked)
                    selectedStaffKeysRP.Add(key);
                else
                    selectedStaffKeysRP.Remove(key);
            }
            catch { }
        }


        public void LockGridRP()
        {
            try
            {
                grdstaffDetails.ReadOnly = false;
                grdstaffDetails.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdstaffDetails.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (grdstaffDetails.Columns.Contains("Check"))
                {
                    grdstaffDetails.Columns["Check"].ReadOnly = false;
                }

                grdstaffDetails.AllowUserToAddRows = false;
                grdstaffDetails.AllowUserToDeleteRows = false;
                grdstaffDetails.AllowUserToResizeRows = false;
                grdstaffDetails.AllowUserToResizeColumns = false;
                grdstaffDetails.MultiSelect = false;
                grdstaffDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                DataTable source = isFilterActive ? dtFiltered : dt;
                int recordCount = source == null ? 0 : source.Rows.Count;
                int totalPagesRP = (int)Math.Ceiling((double)recordCount / pagesizeRP);

                if (totalPagesRP <= 1)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    pnlPagination.Visible = false;
                    return;
                }

                pnlPagination.Visible = true;
                totpageRP = totalPagesRP;

                for (int i = 1; i <= totalPagesRP; i++)
                {
                    Guna2Button btnPage = new Guna2Button();

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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;

                if (btn != null)
                {
                    currentpageRP = Convert.ToInt32(btn.Text);
                    LoadPageRP();
                    CreatePagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dt == null) return;

                string searchText = txtSearchBox.Text.Trim();

                if (string.IsNullOrEmpty(searchText))
                {
                    isFilterActive = false;
                    dtFiltered = null;
                    currentpageRP = 1;
                    LoadPageRP();
                    CreatePagiButtonRP();
                    return;
                }

                string escaped = searchText.Replace("'", "''");
                List<string> filterList = new List<string>();

                foreach (DataColumn col in dt.Columns)
                {
                    filterList.Add("CONVERT([" + col.ColumnName + "], 'System.String') LIKE '%" + escaped + "%'");
                }

                DataView dv = new DataView(dt);
                dv.RowFilter = string.Join(" OR ", filterList);

                dtFiltered = dv.ToTable();
                isFilterActive = true;
                currentpageRP = 1;

                LoadPageRP();
                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                isSettingStaffCheckRP = true;

                selectedStaffKeysRP.Clear();

                if (chkHeaderRP != null)
                {
                    chkHeaderRP.Checked = false;
                    grdstaffDetails.Controls.Remove(chkHeaderRP);
                    chkHeaderRP.Dispose();
                    chkHeaderRP = null;
                }

                foreach (Control c in grdstaffDetails.Controls.OfType<CheckBox>().ToList())
                {
                    grdstaffDetails.Controls.Remove(c);
                    c.Dispose();
                }

                txtSearchBox.TextChanged -= txtSearchBox_TextChanged;
                txtSearchBox.Text = "";
                txtSearchBox.TextChanged += txtSearchBox_TextChanged;

                pnlFilter.Visible = true;
                isFilterActive = false;
                dtFiltered = null;
                currentpageRP = 1;

                isSettingStaffCheckRP = false;

                MainLoadRP();

                grdstaffDetails.ClearSelection();
            }
            catch (Exception ex)
            {
                isSettingStaffCheckRP = false;
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSelectedRowsRP()
        {
            DataTable dtSelectedRP = new DataTable();

            try
            {
                DataTable source = isFilterActive ? dtFiltered : dt;
                if (source == null || source.Rows.Count == 0)
                    return dtSelectedRP;

                dtSelectedRP = source.Clone();

                foreach (DataRow dr in source.Rows)
                {
                    if (selectedStaffKeysRP.Contains(GetStaffKeyRP(dr)))
                        dtSelectedRP.ImportRow(dr);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelectedRP;
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

                Paragraph title = new Paragraph(" Staff Details",
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

                        if (col.ColumnName == "JoinDate")
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

        private void pctExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcelRP();
            }
            catch (Exception ex)
            {
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
                    MessageBox.Show("Please select at least one row to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = " Staff Details.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add(" Staff Details");

                        ws.Cell(1, 1).Value = " Staff Details";
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, dtRP.Columns.Count).Merge();

                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Range(2, 1, 2, dtRP.Columns.Count).Merge();

                        ws.Cell(4, 1).InsertTable(dtRP);
                        ws.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Excel File Saved Successfully!\n" + filePathRP,
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdstaffDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPosition.SelectedIndex == -1 || dt == null || dt.Rows.Count == 0)
                    return;

                if (cmbPosition.SelectedIndex == -1)
                    return;

                string pos = cmbPosition.Text.Replace("'", "''");

                DataView dv = new DataView(dt);
                dv.RowFilter = "PositionName = '" + pos + "'";

                dtFiltered = dv.ToTable();
                isFilterActive = true;
                currentpageRP = 1;

                LoadPageRP();
                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpFromDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpToDate.MinDate = dtpFromDate.Value.Date;
                ApplyJoinDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpToDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                dtpFromDate.MaxDate = dtpToDate.Value.Date;
                ApplyJoinDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyJoinDateFilterRP()
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
                        if (r["JoinDate"] == DBNull.Value)
                            return false;

                        DateTime joinDate = Convert.ToDateTime(r["JoinDate"]).Date;

                        return joinDate >= fromDate && joinDate <= toDate;
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click_1(object sender, EventArgs e)
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}