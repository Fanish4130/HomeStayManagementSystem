using ClosedXML.Excel;
using DocumentFormat.OpenXml.VariantTypes;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmDayWiseAttendanceOverViewRP : Form
    {
        int pagesizeRP = 9;
        int currentpageRP = 1;
        int totpageRP = 0;
        DataTable dt = new DataTable();

        public string S_NameRP;
        public DateTime S_Attenddate;
        public DateTime Checkout;
        public string S_StaffCodeRP;
        string code;

        internal DateTime SelectedDate;
        HashSet<string> selectedAttendanceRP = new HashSet<string>();
        bool isHeaderClickRP = false;
        CheckBox chkHeaderRP = null;
        private bool headerEventsAdded = false;
        private string filePathRP;

        public frmDayWiseAttendanceOverViewRP(DateTime selectedDate)
        {
            try
            {
                InitializeComponent();
                SelectedDate = selectedDate;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        private void frmDayWiseAttendanceOverView_Load(object sender, EventArgs e)
        {
            try
            {
                toolTip1.SetToolTip(pctRefresh1, "Refresh");
                toolTip1.SetToolTip(pctPDF1, "Export PDF");
                toolTip1.SetToolTip(pctExcel1, "Export Excel");


                grdDatWiseAttendanceO.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdDatWiseAttendanceO.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdDatWiseAttendanceO.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdDatWiseAttendanceO.GridColor = System.Drawing.Color.Gray;
                grdDatWiseAttendanceO.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatWiseAttendanceO.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdDatWiseAttendanceO.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdDatWiseAttendanceO.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                grdDatWiseAttendanceO.CellPainting -= grdDatWiseAttendanceO_CellPainting;
                grdDatWiseAttendanceO.CellPainting += grdDatWiseAttendanceO_CellPainting;

                lblDayWiseAttendance.Text = "Attendance for " + SelectedDate.ToString("dd-MM-yyyy");

                MainLoadRP();

                this.FormBorderStyle = FormBorderStyle.None;

                this.Region = System.Drawing.Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20)
                );


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading day wise attendance:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDatWiseAttendanceO_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (grdDatWiseAttendanceO.Columns[e.ColumnIndex].Name != "Select") return;

                e.PaintBackground(e.CellBounds, true);

                bool isChecked = false;

                if (e.Value != null && e.Value != DBNull.Value)
                    isChecked = Convert.ToBoolean(e.Value);

                CheckBoxState state = isChecked
                    ? CheckBoxState.CheckedNormal
                    : CheckBoxState.UncheckedNormal;

                Size checkSize = CheckBoxRenderer.GetGlyphSize(e.Graphics, state);

                int x = e.CellBounds.Left + (e.CellBounds.Width - checkSize.Width) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - checkSize.Height) / 2;

                CheckBoxRenderer.DrawCheckBox(e.Graphics, new Point(x, y), state);

                e.Handled = true;
            }
            catch
            {

            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);

                int radius = 20;
                int borderThickness = 1;
                Color borderColor = Color.Black;

                using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.StartFigure();

                    path.AddArc(1, 1, radius, radius, 180, 90);
                    path.AddArc(this.Width - radius - 2, 1, radius, radius, 270, 90);
                    path.AddArc(this.Width - radius - 2, this.Height - radius - 2, radius, radius, 0, 90);
                    path.AddArc(1, this.Height - radius - 2, radius, radius, 90, 90);

                    path.CloseFigure();

                    using (Pen pen = new Pen(borderColor, borderThickness))
                    {
                        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LockGrid()
        {
            try
            {
                grdDatWiseAttendanceO.ReadOnly = false;
                grdDatWiseAttendanceO.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdDatWiseAttendanceO.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (grdDatWiseAttendanceO.Columns.Contains("Select"))
                {
                    grdDatWiseAttendanceO.Columns["Select"].ReadOnly = false;
                }

                if (grdDatWiseAttendanceO.Columns.Contains("EditDetails"))
                {
                    grdDatWiseAttendanceO.Columns["EditDetails"].ReadOnly = true;
                }

                grdDatWiseAttendanceO.AllowUserToAddRows = false;
                grdDatWiseAttendanceO.AllowUserToDeleteRows = false;
                grdDatWiseAttendanceO.AllowUserToResizeRows = false;
                grdDatWiseAttendanceO.AllowUserToResizeColumns = false;
                grdDatWiseAttendanceO.MultiSelect = false;
                grdDatWiseAttendanceO.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error locking grid:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDatWiseAttendanceO_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void AddEditColumnAtLast()
        {
            try
            {

                string editColumnName = "EditDetails";

                if (grdDatWiseAttendanceO.Columns.Contains(editColumnName))
                    grdDatWiseAttendanceO.Columns.Remove(editColumnName);

                DataGridViewImageColumn imgUpdate = new DataGridViewImageColumn();
                imgUpdate.Name = editColumnName;
                imgUpdate.HeaderText = "Edit";
                imgUpdate.Image = Properties.Resources.Edit_icon;
                imgUpdate.ImageLayout = DataGridViewImageCellLayout.Zoom;
                imgUpdate.Width = 70;
                imgUpdate.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                grdDatWiseAttendanceO.Columns.Add(imgUpdate);

                int lastIndex = grdDatWiseAttendanceO.Columns.Count - 1;
                grdDatWiseAttendanceO.Columns[editColumnName].DisplayIndex = lastIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding edit column:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AlignCheckBoxColumnRP()
        {


            grdDatWiseAttendanceO.Columns["Select"].DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            grdDatWiseAttendanceO.Columns["Select"].HeaderCell.Style.Alignment =
                DataGridViewContentAlignment.MiddleCenter;
        }
        public void AddHeaderCheckBoxRP()
        {
            try
            {
                if (chkHeaderRP != null)
                {
                    grdDatWiseAttendanceO.Controls.Remove(chkHeaderRP);
                    chkHeaderRP.Dispose();
                    chkHeaderRP = null;
                }

                if (!grdDatWiseAttendanceO.Columns.Contains("Select"))
                    return;

                chkHeaderRP = new CheckBox();
                chkHeaderRP.Size = new Size(15, 15);
                chkHeaderRP.BackColor = Color.Transparent;
                chkHeaderRP.Tag = "HeaderCheck";

                grdDatWiseAttendanceO.Controls.Add(chkHeaderRP);

                System.Drawing.Rectangle rect =
                    grdDatWiseAttendanceO.GetCellDisplayRectangle(
                        grdDatWiseAttendanceO.Columns["Select"].Index, -1, true);

                chkHeaderRP.Location = new Point(
                    rect.X + (rect.Width - chkHeaderRP.Width) / 2,
                    rect.Y + (rect.Height - chkHeaderRP.Height) / 2
                );

                chkHeaderRP.CheckedChanged += (s, e) =>
                {
                    try
                    {
                        isHeaderClickRP = true;

                        bool checkAll = chkHeaderRP.Checked;

                        selectedAttendanceRP.Clear();

                        if (checkAll)
                        {
                            foreach (DataRow dr in dt.Rows)
                                selectedAttendanceRP.Add(GetAttendanceKeyRP(dr));
                        }

                        grdDatWiseAttendanceO.EndEdit();

                        foreach (DataGridViewRow row in grdDatWiseAttendanceO.Rows)
                        {
                            if (row.IsNewRow) continue;

                            row.Cells["Select"].Value = checkAll;

                            DataRowView drv = row.DataBoundItem as DataRowView;
                            if (drv != null && drv.Row.Table.Columns.Contains("Select"))
                            {
                                drv.Row["Select"] = checkAll;
                            }
                        }

                        grdDatWiseAttendanceO.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        grdDatWiseAttendanceO.RefreshEdit();
                        grdDatWiseAttendanceO.Refresh();

                        isHeaderClickRP = false;
                    }
                    catch (Exception ex)
                    {
                        isHeaderClickRP = false;
                        MessageBox.Show(ex.Message);
                    }
                };

                grdDatWiseAttendanceO.CurrentCellDirtyStateChanged -= grdDatWiseAttendanceO_CurrentCellDirtyStateChangedRP;
                grdDatWiseAttendanceO.CurrentCellDirtyStateChanged += grdDatWiseAttendanceO_CurrentCellDirtyStateChangedRP;

                grdDatWiseAttendanceO.CellValueChanged -= grdDatWiseAttendanceO_CellValueChangedRP;
                grdDatWiseAttendanceO.CellValueChanged += grdDatWiseAttendanceO_CellValueChangedRP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding header checkbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetAttendanceKeyRP(DataRow dr)
        {
            if (dr.Table.Columns.Contains("StaffCode"))
                return dr["StaffCode"].ToString();

            return dr[0].ToString();
        }

        private string GetAttendanceKeyRP(DataGridViewRow row)
        {
            if (grdDatWiseAttendanceO.Columns.Contains("StaffCode"))
                return row.Cells["StaffCode"].Value.ToString();

            return row.Cells[1].Value.ToString();
        }

        private void ApplySavedAttendanceCheckStateRP()
        {
            try
            {
                isHeaderClickRP = true;

                foreach (DataGridViewRow row in grdDatWiseAttendanceO.Rows)
                {
                    string key = GetAttendanceKeyRP(row);
                    row.Cells["Select"].Value = selectedAttendanceRP.Contains(key);
                }

                isHeaderClickRP = false;
            }
            catch
            {
                isHeaderClickRP = false;
            }
        }

        private void grdDatWiseAttendanceO_CurrentCellDirtyStateChangedRP(object sender, EventArgs e)
        {
            try
            {
                if (grdDatWiseAttendanceO.IsCurrentCellDirty)
                {
                    grdDatWiseAttendanceO.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {

            }
        }

        private void grdDatWiseAttendanceO_CellValueChangedRP(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isHeaderClickRP) return;
                if (e.RowIndex < 0) return;
                if (grdDatWiseAttendanceO.Columns[e.ColumnIndex].Name != "Select") return;

                string key = GetAttendanceKeyRP(grdDatWiseAttendanceO.Rows[e.RowIndex]);
                bool isChecked = Convert.ToBoolean(grdDatWiseAttendanceO.Rows[e.RowIndex].Cells["Select"].Value);

                if (isChecked)
                    selectedAttendanceRP.Add(key);
                else
                    selectedAttendanceRP.Remove(key);
            }
            catch
            {

            }
        }
        public void MainLoadRP()
        {
            try
            {
                this.grdDatWiseAttendanceO.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 10);

                clsUser cls = new clsUser();
                cls.AttendDateRP = SelectedDate;
                dt = cls.DayWiseAttendanceOverViewRP();

                EnsureAttendDateIsDateTime(dt);

                dt.DefaultView.RowFilter =
                    $"AttendDate <= #{DateTime.Today:MM/dd/yyyy}#";

                dt = dt.DefaultView.ToTable();

                SortDataTableByAttendDateDesc(dt);

                RemoveHeaderCheckBox();
                grdDatWiseAttendanceO.DataSource = null;
                grdDatWiseAttendanceO.Columns.Clear();

                grdDatWiseAttendanceO.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                grdDatWiseAttendanceO.RowTemplate.Height = 40;
                grdDatWiseAttendanceO.ColumnHeadersHeightSizeMode =
                    DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                grdDatWiseAttendanceO.ColumnHeadersHeight = 38;

                AddCheckBoxColumn();
                grdDatWiseAttendanceO.DataSource = dt;

                AddEditColumnAtLast();

                foreach (DataGridViewRow row in grdDatWiseAttendanceO.Rows)
                {
                    row.Height = 28;
                }
                grdDatWiseAttendanceO.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                grdDatWiseAttendanceO.Columns["Select"].Width = 80;
                grdDatWiseAttendanceO.Columns["Select"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                grdDatWiseAttendanceO.Columns["StaffCode"].Width = 110;
                grdDatWiseAttendanceO.Columns["StaffName"].Width = 130;
                grdDatWiseAttendanceO.Columns["CheckIn"].Width = 100;
                grdDatWiseAttendanceO.Columns["CheckOut"].Width = 100;
                grdDatWiseAttendanceO.Columns["Status"].Width = 100;
                grdDatWiseAttendanceO.Columns["AttendDate"].Width = 120;

                grdDatWiseAttendanceO.Columns["EditDetails"].Width = 97;
                grdDatWiseAttendanceO.Columns["EditDetails"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                LockGrid();
                AlignCheckBoxColumnRP();

                AddHeaderCheckBoxRP();
                ApplySavedAttendanceCheckStateRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading attendance data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void RemoveHeaderCheckBox()
        {
            try
            {
                var chkBoxes = grdDatWiseAttendanceO.Controls
                    .OfType<System.Windows.Forms.CheckBox>()
                    .Where(c => c.Tag?.ToString() == "HeaderCheck")
                    .ToList();

                foreach (var chk in chkBoxes)
                {
                    grdDatWiseAttendanceO.Controls.Remove(chk);
                    chk.Dispose();
                }

                headerEventsAdded = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error removing header checkbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAllAttendance()
        {
            try
            {
                clsUser cls = new clsUser();
                dt = cls.DayWiseAttendanceOverViewRP();

                EnsureAttendDateIsDateTime(dt);
                SortDataTableByAttendDateDesc(dt);

                grdDatWiseAttendanceO.DataSource = dt;
                AddHeaderCheckBoxRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading all attendance:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctRefresh1_Click(object sender, EventArgs e)
        {
            try
            {
                selectedAttendanceRP.Clear();
                txtSearchBox1.Text = "";
                MainLoadRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Refresh error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
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

        private void txtSearchBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdDatWiseAttendanceO.DataSource == null)
                    return;

                DataTable dtLocal = (DataTable)grdDatWiseAttendanceO.DataSource;
                string searchText = txtSearchBox1.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(searchText))
                {
                    dtLocal.DefaultView.RowFilter = string.Empty;
                    return;
                }

                List<string> filterList = new List<string>();

                foreach (DataColumn col in dtLocal.Columns)
                {
                    string escaped = searchText.Replace("'", "''");
                    filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
                }

                string filter = string.Join(" OR ", filterList);
                dtLocal.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSelectedRowsRP()
        {
            DataTable dtSelected1RP = new DataTable();

            try
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No rows available.");
                    return dtSelected1RP;
                }

                foreach (DataColumn col in dt.Columns)
                {
                    dtSelected1RP.Columns.Add(col.ColumnName);
                }

                foreach (DataRow sourceRow in dt.Rows)
                {
                    string key = GetAttendanceKeyRP(sourceRow);

                    if (selectedAttendanceRP.Contains(key))
                    {
                        DataRow drRP = dtSelected1RP.NewRow();

                        foreach (DataColumn col in dt.Columns)
                        {
                            drRP[col.ColumnName] = sourceRow[col.ColumnName];
                        }

                        dtSelected1RP.Rows.Add(drRP);
                    }
                }



                return dtSelected1RP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting selected rows:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return dtSelected1RP;
            }
        }

        private void pctPDF1_Click(object sender, EventArgs e)
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
                saveFileDialog.FileName = "Staff Attendance.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;

                docRP = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(saveFileDialog.FileName, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph("Staff Attendance",
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

                        if (col.ColumnName == "AttendDate")
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

        private void pctExcel1_Click(object sender, EventArgs e)
        {
            try
            {
                ExportToExcelRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel click error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                sfd.FileName = "Staff Attendance.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var ws = workbook.Worksheets.Add("Selected Rows");

                        ws.Cell(1, 1).Value = "Staff Attendance";
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, dtRP.Columns.Count).Merge();

                        ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy");
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Range(2, 1, 2, dtRP.Columns.Count).Merge();

                        DataTable exportDt = dtRP.Copy();

                        foreach (DataRow row in exportDt.Rows)
                        {
                            if (exportDt.Columns.Contains("AttendDate"))
                            {
                                row["AttendDate"] =
                                    Convert.ToDateTime(row["AttendDate"])
                                    .ToString("dd-MM-yyyy");
                            }
                        }

                        ws.Cell(4, 1).InsertTable(exportDt);

                        var header = ws.Range(4, 1, 4, dtRP.Columns.Count);
                        header.Style.Font.Bold = true;
                        header.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                        ws.Columns().AdjustToContents();

                        workbook.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Excel File Saved Successfully!\n" + filePathRP,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel Export Error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctDelete1_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChecked = false;

                for (int i = grdDatWiseAttendanceO.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdDatWiseAttendanceO.Rows[i];

                    try
                    {
                        object chk = row.Cells[0].Value;
                        bool isChecked = chk != null && chk != DBNull.Value && Convert.ToBoolean(chk) == true;

                        if (isChecked)
                        {
                            grdDatWiseAttendanceO.Rows.RemoveAt(i);
                            anyChecked = true;
                        }
                    }
                    catch
                    {

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
                MessageBox.Show("Delete error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdDatWiseAttendanceO_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

                string clickedColumnName = grdDatWiseAttendanceO.Columns[e.ColumnIndex].Name;

                if (clickedColumnName != "EditDetails") return;

                if (grdDatWiseAttendanceO.Rows[e.RowIndex].DataBoundItem == null) return;

                DataRow selectedRow =
                    ((DataRowView)grdDatWiseAttendanceO.Rows[e.RowIndex].DataBoundItem).Row;

                string staffCode = selectedRow["StaffCode"]?.ToString();
                string staffName = selectedRow["StaffName"] == DBNull.Value ? "" : selectedRow["StaffName"].ToString();
                string checkin = selectedRow["CheckIn"]?.ToString();
                string status = selectedRow["Status"] == DBNull.Value ? "" : selectedRow["Status"].ToString();

                DateTime attendDate = selectedRow["AttendDate"] == DBNull.Value
                    ? DateTime.MinValue
                    : Convert.ToDateTime(selectedRow["AttendDate"]);

                if (attendDate.Date != DateTime.Today)
                {
                    MessageBox.Show(
                        "You can update only Today's attendance.",
                        "Edit Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (status == "Absent" || status == "On Leave")
                {
                    MessageBox.Show(
                        "You can update Attendance only for Present staff.",
                        "Not Allowed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(staffName))
                {
                    MessageBox.Show(
                        "Cannot update attendance. Staff name is missing.",
                        "Data Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }

                S_NameRP = staffName;
                S_Attenddate = attendDate;
                code = staffCode;

                frmupdateAttendance f22 =
                    new frmupdateAttendance(code, S_NameRP, S_Attenddate, checkin);

                if (f22.ShowDialog() == DialogResult.OK)
                {
                    MainLoadRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Edit attendance error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Helper Methods

        private void EnsureAttendDateIsDateTime(DataTable table)
        {
            try
            {
                if (table == null || table.Columns.Count == 0)
                    return;

                if (!table.Columns.Contains("AttendDate"))
                    return;

                if (table.Columns["AttendDate"].DataType == typeof(DateTime))
                    return;

                string rawName = "AttendDateRaw";

                if (table.Columns.Contains(rawName))
                    rawName = Guid.NewGuid().ToString("N");

                table.Columns["AttendDate"].ColumnName = rawName;
                table.Columns.Add("AttendDate", typeof(DateTime));

                string[] formats = new[]
                {
                    "dd-MM-yyyy",
                    "dd MMMM yyyy",
                    "yyyy-MM-dd",
                    "dd/MM/yyyy",
                    "M/d/yyyy",
                    "MM/dd/yyyy",
                    "yyyy/MM/dd",
                    "dd-MM-yyyy HH:mm:ss",
                    "yyyy-MM-dd HH:mm:ss",
                    "dd/MM/yyyy HH:mm:ss",
                    "MM/dd/yyyy HH:mm:ss",
                    "yyyy/MM/dd HH:mm:ss"
                };

                foreach (DataRow row in table.Rows)
                {
                    try
                    {
                        object rawVal = row[rawName];

                        if (rawVal == null || rawVal == DBNull.Value)
                        {
                            row["AttendDate"] = DateTime.MinValue;
                            continue;
                        }

                        if (rawVal is DateTime dtVal)
                        {
                            row["AttendDate"] = dtVal;
                            continue;
                        }

                        string raw = rawVal.ToString().Trim();
                        DateTime parsed;

                        if (DateTime.TryParseExact(raw, formats, CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out parsed))
                        {
                            row["AttendDate"] = parsed;
                            continue;
                        }

                        if (DateTime.TryParse(raw, CultureInfo.InvariantCulture,
                            DateTimeStyles.None, out parsed))
                        {
                            row["AttendDate"] = parsed;
                            continue;
                        }

                        if (DateTime.TryParse(raw, CultureInfo.CurrentCulture,
                            DateTimeStyles.None, out parsed))
                        {
                            row["AttendDate"] = parsed;
                            continue;
                        }

                        row["AttendDate"] = DateTime.MinValue;
                    }
                    catch
                    {
                        row["AttendDate"] = DateTime.MinValue;
                    }
                }

                try
                {
                    table.Columns.Remove(rawName);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Date conversion error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SortDataTableByAttendDateDesc(DataTable table)
        {
            try
            {
                if (table == null || table.Columns.Count == 0)
                    return;

                if (!table.Columns.Contains("AttendDate"))
                    return;

                if (table.Columns["AttendDate"].DataType != typeof(DateTime))
                {
                    EnsureAttendDateIsDateTime(table);
                }

                try
                {
                    table.DefaultView.Sort = "AttendDate DESC";
                    DataTable sorted = table.DefaultView.ToTable();

                    table.Clear();
                    table.Merge(sorted);
                }
                catch
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sorting error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCheckBoxColumn()
        {
            try
            {
                if (!grdDatWiseAttendanceO.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn chk =
                        new DataGridViewCheckBoxColumn();

                    chk.Name = "Select";
                    chk.HeaderText = "";
                    chk.Width = 35;   // 60 नको

                    chk.DefaultCellStyle.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    chk.HeaderCell.Style.Alignment =
                        DataGridViewContentAlignment.MiddleCenter;

                    grdDatWiseAttendanceO.Columns.Insert(0, chk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblDayWiseAttendance_Click(object sender, EventArgs e)
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
    }
}