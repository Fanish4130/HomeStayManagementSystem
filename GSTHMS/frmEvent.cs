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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using CheckBox = System.Web.UI.WebControls.CheckBox;
using System.Globalization;
using DrawingRectangle = System.Drawing.Rectangle;

namespace GSTHMS
{
    public partial class frmEvent : Form
    {
        public int pageSizeRP = 10;
        public int currentPageRP = 1;

        public int totalRecordsRP = 0;
        public int totalPagesRP = 0;
        public int totalPageNumberRP = 0;

        bool isFormLoaded = false;
        bool isFilterActive = false;

        DataTable dt1 = new DataTable();
        DataTable dtFiltered = new DataTable();

        CheckBox headerCheckBox = new CheckBox();
        bool isHeaderCheckBoxClicked = false;

        HashSet<string> selectedEventKeysRP = new HashSet<string>();
        bool isSettingEventCheckRP = false;
        System.Windows.Forms.CheckBox chkEventHeaderRP = null;
        private string filePathRP;

        public frmEvent()
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

        public void LoadPageRP()
        {
            try
            {
                int startIndex = (currentPageRP - 1) * pageSizeRP;
                DataTable dtPage = dtFiltered.Clone();

                for (int i = startIndex; i < startIndex + pageSizeRP && i < dtFiltered.Rows.Count; i++)
                    dtPage.ImportRow(dtFiltered.Rows[i]);

                grdevents.DataSource = dtPage;

                CheckBoxAB();
                ApplySavedEventCheckStateRP();
                LockGridRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void AddHeaderCheckBoxRP()
        {
            try
            {
                foreach (DataGridViewColumn col in grdevents.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                grdevents.AllowUserToAddRows = false;
                grdevents.ReadOnly = true;
                grdevents.EditMode = DataGridViewEditMode.EditProgrammatically;

                foreach (DataGridViewColumn col in grdevents.Columns)
                {
                    col.ReadOnly = col.Index != 0;
                }

                System.Windows.Forms.CheckBox chkHeader = new System.Windows.Forms.CheckBox();
                chkHeader.Size = new Size(15, 15);
                chkHeader.BackColor = Color.Transparent;

                grdevents.Controls.Add(chkHeader);

                grdevents.CellPainting += (s, e) =>
                {
                    try
                    {
                        if (e.RowIndex == -1 && e.ColumnIndex == 0)
                        {
                            System.Drawing.Rectangle rect = grdevents.GetCellDisplayRectangle(0, -1, true);

                            chkHeader.Location = new Point(
                                rect.X + (rect.Width - chkHeader.Width) / 2,
                                rect.Y + (rect.Height - chkHeader.Height) / 2
                            );
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding header checkbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePageButtonRP()
        {
            try
            {
                pnlPages.Controls.Clear();

                int totalpages = (int)Math.Ceiling((double)dtFiltered.Rows.Count / pageSizeRP);
                totalPagesRP = totalpages;

                int bwidth = 40, bheight = 35, spacing = 5, start = 10;

                for (int i = 1; i <= totalpages; i++)
                {
                    Guna2Button btnPage = new Guna2Button();
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
                MessageBox.Show("Error creating page buttons:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcelRP()
        {
            try
            {
                DataTable dtRP = AddRupeeSignRP(GetSelectedRowsRP());

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

                        ws.Cell(1, 1).Value = lblEvent.Text;
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

                    MessageBox.Show("Selected rows exported to Excel successfully!",
                                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel Export Error:\n" + ex.Message,
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
                    int pageNumber = Convert.ToInt32(btn.Text);
                    currentPageRP = pageNumber;
                    LoadPageRP();
                    CreatePageButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error changing page:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridRP()
        {
            try
            {
                clsUser objfe = new clsUser();
                selectedEventKeysRP.Clear();
                dt1 = objfe.EventRP();
                dtFiltered = dt1.Copy();

                isFilterActive = false;
                currentPageRP = 1;

                LoadPageRP();
                CreatePageButtonRP();
                LockGridRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event grid:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CheckBoxAB()
        {
            try
            {
                if (!grdevents.Columns.Contains("Check"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "Check";
                    chk.HeaderText = "";
                    chk.Width = 40;
                    chk.TrueValue = true;
                    chk.FalseValue = false;
                    grdevents.Columns.Insert(0, chk);
                }

                foreach (Control c in grdevents.Controls.OfType<System.Windows.Forms.CheckBox>().ToList())
                    grdevents.Controls.Remove(c);

                chkEventHeaderRP = new System.Windows.Forms.CheckBox();
                chkEventHeaderRP.BackColor = Color.Transparent;
                chkEventHeaderRP.Size = new Size(18, 18);

                System.Drawing.Rectangle rect = grdevents.GetCellDisplayRectangle(0, -1, true);
                chkEventHeaderRP.Location = new Point(
                    rect.X + (rect.Width - chkEventHeaderRP.Width) / 2,
                    rect.Y + (rect.Height - chkEventHeaderRP.Height) / 2
                );

                grdevents.Controls.Add(chkEventHeaderRP);

                chkEventHeaderRP.CheckedChanged += (s, e1) =>
                {
                    try
                    {
                        if (isSettingEventCheckRP) return;

                        isSettingEventCheckRP = true;

                        if (chkEventHeaderRP.Checked)
                        {
                            selectedEventKeysRP.Clear();

                            foreach (DataRow dr in dtFiltered.Rows)
                                selectedEventKeysRP.Add(GetEventKeyRP(dr));
                        }
                        else
                        {
                            selectedEventKeysRP.Clear();
                        }

                        grdevents.EndEdit();

                        foreach (DataGridViewRow row in grdevents.Rows)
                        {
                            if (row.IsNewRow) continue;

                            row.Cells["Check"].Value = chkEventHeaderRP.Checked;

                            DataRowView drv = row.DataBoundItem as DataRowView;
                            if (drv != null && drv.Row.Table.Columns.Contains("Check"))
                            {
                                drv.Row["Check"] = chkEventHeaderRP.Checked;
                            }
                        }

                        grdevents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        grdevents.RefreshEdit();
                        grdevents.Refresh();
                        isSettingEventCheckRP = false;
                    }
                    catch (Exception ex)
                    {
                        isSettingEventCheckRP = false;
                        MessageBox.Show(ex.Message);
                    }
                };

                grdevents.CurrentCellDirtyStateChanged -= grdevents_CurrentCellDirtyStateChangedRP;
                grdevents.CurrentCellDirtyStateChanged += grdevents_CurrentCellDirtyStateChangedRP;

                grdevents.CellValueChanged -= grdevents_CellValueChangedRP;
                grdevents.CellValueChanged += grdevents_CellValueChangedRP;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding checkbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdevents_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ApplySavedEventCheckStateRP();

            if (chkEventHeaderRP != null)
            {
                isSettingEventCheckRP = true;

                chkEventHeaderRP.Checked =
                    grdevents.Rows.Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .All(r => Convert.ToBoolean(r.Cells["Check"].Value ?? false));

                isSettingEventCheckRP = false;
            }
        }
        private string GetEventKeyRP(DataRow dr)
        {
            if (dr.Table.Columns.Contains("EventID"))
                return dr["EventID"].ToString();

            if (dr.Table.Columns.Contains("EventName"))
                return dr["EventName"].ToString();

            return dr[0].ToString();
        }

        private string GetEventKeyRP(DataGridViewRow row)
        {
            if (grdevents.Columns.Contains("EventID"))
                return row.Cells["EventID"].Value.ToString();

            if (grdevents.Columns.Contains("EventName"))
                return row.Cells["EventName"].Value.ToString();

            return row.Cells[1].Value.ToString();
        }

        private void ApplySavedEventCheckStateRP()
        {
            try
            {
                isSettingEventCheckRP = true;

                foreach (DataGridViewRow row in grdevents.Rows)
                {
                    string key = GetEventKeyRP(row);
                    row.Cells["Check"].Value = selectedEventKeysRP.Contains(key);
                }

                isSettingEventCheckRP = false;
            }
            catch
            {
                isSettingEventCheckRP = false;
            }
        }

        private void grdevents_CurrentCellDirtyStateChangedRP(object sender, EventArgs e)
        {
            try
            {
                if (grdevents.IsCurrentCellDirty)
                {
                    grdevents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {

            }
        }

        private void grdevents_CellValueChangedRP(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isSettingEventCheckRP) return;
                if (e.RowIndex < 0) return;
                if (grdevents.Columns[e.ColumnIndex].Name != "Check") return;

                string key = GetEventKeyRP(grdevents.Rows[e.RowIndex]);
                bool isChecked = Convert.ToBoolean(grdevents.Rows[e.RowIndex].Cells["Check"].Value);

                if (isChecked)
                    selectedEventKeysRP.Add(key);
                else
                    selectedEventKeysRP.Remove(key);
            }
            catch { }
        }
        private void LockGridRP()
        {
            try
            {
                grdevents.ReadOnly = false;
                grdevents.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grdevents.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (grdevents.Columns.Count > 0)
                {
                    grdevents.Columns[0].ReadOnly = false;
                }

                grdevents.AllowUserToAddRows = false;
                grdevents.AllowUserToDeleteRows = false;
                grdevents.AllowUserToResizeRows = false;
                grdevents.AllowUserToResizeColumns = false;
                grdevents.MultiSelect = false;
                grdevents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error locking grid:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmEvent_Load(object sender, EventArgs e)
        {
            try
            {
                isFormLoaded = false;

                pnlFilter.Visible = true;
                txtSearchBox.Text = "";


                LoadGridRP();
                CheckBoxAB();

                isFormLoaded = true;

                grdevents.DataBindingComplete -= grdevents_DataBindingComplete;
                grdevents.DataBindingComplete += grdevents_DataBindingComplete;



                grdevents.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdevents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdevents.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdevents.GridColor = System.Drawing.Color.Gray;
                grdevents.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdevents.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdevents.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdevents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);



                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctFilter, "Filter");
                toolTip1.SetToolTip(pctPDF, "Export PDF");
                toolTip1.SetToolTip(pctExcel, "Export Excel");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading event form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CheckBoxRP()
        {
            try
            {
                grdevents.AllowUserToAddRows = false;
                grdevents.ReadOnly = true;
                grdevents.EditMode = DataGridViewEditMode.EditProgrammatically;

                foreach (DataGridViewColumn col in grdevents.Columns)
                {
                    col.ReadOnly = col.Index != 0;
                }

                System.Windows.Forms.CheckBox headerCheckBoxAB = new System.Windows.Forms.CheckBox();
                headerCheckBoxAB.BackColor = System.Drawing.Color.Transparent;
                System.Drawing.Rectangle rect = grdevents.GetCellDisplayRectangle(0, -1, true);

                headerCheckBoxAB.Size = new System.Drawing.Size(18, 18);
                headerCheckBoxAB.Location = new System.Drawing.Point(rect.X + (rect.Width / 2) - 8, rect.Y + 5);

                grdevents.Controls.Add(headerCheckBoxAB);

                headerCheckBoxAB.CheckedChanged += (s, e1) =>
                {
                    try
                    {
                        grdevents.EndEdit();
                        grdevents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        bool chechAll = headerCheckBoxAB.Checked;

                        foreach (DataGridViewRow row in grdevents.Rows)
                        {
                            DataGridViewCheckBoxCell chkCell = row.Cells[0] as DataGridViewCheckBoxCell;

                            if (chkCell != null)
                            {
                                chkCell.Value = chechAll;
                            }
                        }

                        grdevents.RefreshEdit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                grdevents.CurrentCellDirtyStateChanged += (s, e2) =>
                {
                    try
                    {
                        if (grdevents.CurrentCell is DataGridViewCheckBoxCell)
                            grdevents.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error setting checkbox:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ClearAllFilters()
        {
            try
            {
                isFormLoaded = false;

                txtSearchBox.Text = "";

                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpFromDate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpToDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpToDate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;

                dtpToDate.MinDate = dtpFromDate.Value;

                isFilterActive = false;
                dtFiltered = dt1.Copy();

                currentPageRP = 1;

                LoadPageRP();
                CreatePageButtonRP();

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing filters:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show("Previous page error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Next page error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnParticipate_Click(object sender, EventArgs e)
        {
            try
            {
                //frmEventsService frm = new frmEventsService();
                // frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdevents_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void ResetGridStateRP()
        {
            try
            {
                currentPageRP = 1;

                pnlPages.Controls.Clear();

                foreach (Control c in grdevents.Controls
                         .OfType<System.Windows.Forms.CheckBox>().ToList())
                {
                    grdevents.Controls.Remove(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error resetting grid:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string status = e.Row.Cells[5].Text;

                    if (status == "Up-coming")
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Yellow;

                    if (status == "Active")
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Blue;

                    if (status == "Completed")
                        e.Row.Cells[5].BackColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlPages_Paint(object sender, PaintEventArgs e)
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

        public void MainLoadRP()
        {
            try
            {
                this.grdevents.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 10);

                clsUser cls = new clsUser();
                dt1 = cls.AssignedTaskRP();

                grdevents.DataSource = dt1;
                AddHeaderCheckBoxRP();

                LoadPageRP();

                CreatePagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error main loading:\n" + ex.Message,
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
                    currentPageRP = pageNumberRP;
                    LoadPageRP();
                    CreatePagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Page button error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                pnlPages.Controls.Clear();

                foreach (Control ctr in pnlPages.Controls.OfType<Guna2Button>().ToList())
                {
                    if (ctr.Name.StartsWith("btnPage"))
                    {
                        pnlPages.Controls.Remove(ctr);
                    }
                }

                int totalPagesRP = (int)Math.Ceiling((double)dt1.Rows.Count / pageSizeRP);

                if (totalPagesRP <= 1)
                {
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = false;
                    pnlPages.Visible = false;
                    return;
                }
                else
                {
                    pnlPages.Visible = true;
                }

                for (int i = 1; i <= totalPagesRP; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidthRP, bheightRP);
                    btnPage.Location = new Point(startXRP, 5);
                    btnPage.FillColor = (i == currentPageRP) ? Color.DeepSkyBlue : Color.White;
                    btnPage.ForeColor = (i == currentPageRP) ? Color.White : Color.Black;
                    btnPage.Click += BtnPage_Click;

                    pnlPages.Controls.Add(btnPage);
                    startXRP += bwidthRP + spacingRP;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating pagination:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable AddRupeeSignRP(DataTable dt)
        {
            DataTable newDt = dt.Copy();

            foreach (DataColumn col in newDt.Columns)
            {
                if (col.ColumnName.ToLower().Contains("charge"))
                {
                    foreach (DataRow row in newDt.Rows)
                    {
                        if (row[col] != DBNull.Value && row[col].ToString() != "")
                        {
                            string val = row[col].ToString().Replace("₹", "").Trim();
                            row[col] = "₹ " + val;
                        }
                    }
                }
            }

            return newDt;
        }
        public DataTable GetSelectedRowsRP()
        {
            DataTable dtSelected = new DataTable();

            try
            {
                if (dtFiltered == null || dtFiltered.Rows.Count == 0)
                    return dtSelected;

                dtSelected = dtFiltered.Clone();

                foreach (DataRow dr in dtFiltered.Rows)
                {
                    if (selectedEventKeysRP.Contains(GetEventKeyRP(dr)))
                        dtSelected.ImportRow(dr);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error getting selected rows:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dtSelected;
        }

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                bool anyChecked = false;

                for (int i = grdevents.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = grdevents.Rows[i];

                    if (row.Cells["Check"].Value != null &&
                        Convert.ToBoolean(row.Cells["Check"].Value) == true)
                    {
                        grdevents.Rows.RemoveAt(i);
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
                MessageBox.Show("Delete error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grdevents.DataSource == null)
                    return;

                DataTable dt = (DataTable)grdevents.DataSource;
                string searchText = txtSearchBox.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(searchText))
                {
                    dt.DefaultView.RowFilter = string.Empty;
                    return;
                }

                List<string> filterList = new List<string>();

                foreach (DataColumn col in dt.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        string escaped = searchText.Replace("'", "''");
                        filterList.Add($"CONVERT([{col.ColumnName}], 'System.String') LIKE '%{escaped}%'");
                    }
                }

                string filter = string.Join(" OR ", filterList);
                dt.DefaultView.RowFilter = filter;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnparticipateevent_Click(object sender, EventArgs e)
        {
            try
            {
                frmEventService frm = new frmEventService();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening event service:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctFilter_Click(object sender, EventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
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
                MessageBox.Show("From date error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("To date error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ApplyDateFilterRP()
        {
            try
            {
                if (!isFormLoaded) return;
                if (dt1 == null || dt1.Rows.Count == 0) return;

                DateTime fromDate = dtpFromDate.Value.Date;
                DateTime toDate = dtpToDate.Value.Date;

                var filteredRows = dt1.AsEnumerable()
                    .Where(r =>
                    {
                        if (r["Start Date"] == DBNull.Value)
                            return false;

                        DateTime d = Convert.ToDateTime(r["Start Date"]).Date;
                        return d >= fromDate && d <= toDate;
                    });

                dtFiltered = filteredRows.Any()
                    ? filteredRows.CopyToDataTable()
                    : dt1.Clone();

                currentPageRP = 1;

                LoadPageRP();
                CreatePageButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Date filter error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                selectedEventKeysRP.Clear();
                isSettingEventCheckRP = false;

                ResetGridStateRP();

                isFormLoaded = false;

                pnlFilter.Visible = true;
                txtSearchBox.Text = "";

                dtpFromDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpFromDate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpToDate.MinDate = DateTimePicker.MinimumDateTime;
                dtpToDate.MaxDate = DateTimePicker.MaximumDateTime;

                dtpFromDate.Value = DateTime.Today;
                dtpToDate.Value = DateTime.Today;
                dtpToDate.MinDate = dtpFromDate.Value;

                isFilterActive = false;

                LoadGridRP();

                currentPageRP = 1;
                LoadPageRP();
                CreatePageButtonRP();

                if (chkEventHeaderRP != null)
                    chkEventHeaderRP.Checked = false;

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Refresh error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblToDate_Click(object sender, EventArgs e)
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

        private void pctFilter_Click_1(object sender, EventArgs e)
        {
            try
            {
                pnlFilter.Visible = !pnlFilter.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filter error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdevents_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
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

        private void dtpFromDate_ValueChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;

                isFilterActive = true;
                dtpFromDate.MaxDate = dtpToDate.Value.Date;
                ApplyDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("From date filter error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpToDate_ValueChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;

                isFilterActive = true;
                dtpToDate.MinDate = dtpFromDate.Value.Date;
                ApplyDateFilterRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show("To date filter error:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlFilter_Paint_1(object sender, PaintEventArgs e)
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

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pctPDF_Click(object sender, EventArgs e)
        {

        }

        private void pctExcel_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}