using ClosedXML.Excel;
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
using PageSize = iTextSharp.text.PageSize;
using Guna.UI2.WinForms;

namespace GSTHMS
{
    public partial class frmStaffLea : Form
    {

        int pageSizeRP = 4;

        int yearlyPageRP = 1;
        int dailyPageRP = 1;
        int positionPageRP = 1;

        DataTable dtYearlyPageRP = new DataTable();
        DataTable dtDailyPageRP = new DataTable();
        DataTable dtPositionPageRP = new DataTable();
        HashSet<string> selectedYearlyRP = new HashSet<string>();
        HashSet<string> selectedDailyRP = new HashSet<string>();
        HashSet<string> selectedPositionRP = new HashSet<string>();
        bool isSettingCheckRP = false;

        bool isFormLoaded = false;
        DataTable dt = new DataTable();
        public DateTime formDateRP { get; set; }
        public DateTime toDateRP { get; set; }
        public frmStaffLea()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            try
            {
                isFormLoaded = false;

                toolTip1.SetToolTip(pctRefresh, "Refresh");
                toolTip1.SetToolTip(pctPDF, "Export PDF");
                toolTip1.SetToolTip(pctExcel, "Export Excel");
                toolTip1.SetToolTip(pctFilter, "Filters");

                MainFormLoadRP();

                pnlFilter.Visible = true;

                grdyearlyleave.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdyearlyleave.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdyearlyleave.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdyearlyleave.GridColor = System.Drawing.Color.Gray;
                grdyearlyleave.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdyearlyleave.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdyearlyleave.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grdyearlyleave.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                grddailyleave.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grddailyleave.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grddailyleave.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grddailyleave.GridColor = System.Drawing.Color.Gray;
                grddailyleave.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grddailyleave.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grddailyleave.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grddailyleave.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                grdpositionwiseleave.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdpositionwiseleave.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdpositionwiseleave.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdpositionwiseleave.GridColor = System.Drawing.Color.Gray;
                grdpositionwiseleave.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdpositionwiseleave.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                grdpositionwiseleave.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
                grddailyleave.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);

                pnlFilter.Visible = true;

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetRowKeyRP(DataRow row)
        {
            return string.Join("|", row.ItemArray.Select(x => x == DBNull.Value ? "" : x.ToString()));
        }

        private void SetupGridCheckBoxRP(DataGridView grid, DataTable source, HashSet<string> selectedSet)
        {
            try
            {
                if (!grid.Columns.Contains("Check"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "Check";
                    chk.HeaderText = "";
                    chk.Width = 40;
                    chk.TrueValue = true;
                    chk.FalseValue = false;
                    grid.Columns.Insert(0, chk);
                }

                foreach (Control c in grid.Controls.OfType<CheckBox>().ToList())
                    grid.Controls.Remove(c);

                CheckBox header = new CheckBox();
                header.BackColor = Color.Transparent;
                header.Size = new Size(18, 18);

                System.Drawing.Rectangle rect = grid.GetCellDisplayRectangle(0, -1, true);
                header.Location = new System.Drawing.Point(
                    rect.X + (rect.Width - header.Width) / 2,
                    rect.Y + (rect.Height - header.Height) / 2
                );

                grid.Controls.Add(header);

                header.CheckedChanged += (s, e) =>
                {
                    try
                    {
                        if (isSettingCheckRP) return;

                        isSettingCheckRP = true;

                        bool checkAll = header.Checked;

                        if (checkAll)
                        {
                            selectedSet.Clear();
                            foreach (DataRow dr in source.Rows)
                                selectedSet.Add(GetRowKeyRP(dr));
                        }
                        else
                        {
                            selectedSet.Clear();
                        }

                        grid.EndEdit();

                        foreach (DataGridViewRow row in grid.Rows)
                        {
                            if (row.IsNewRow) continue;

                            row.Cells["Check"].Value = checkAll;

                            DataRowView drv = row.DataBoundItem as DataRowView;
                            if (drv != null && drv.Row.Table.Columns.Contains("Check"))
                            {
                                drv.Row["Check"] = checkAll;
                            }
                        }

                        grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                        grid.RefreshEdit();
                        grid.Refresh();

                        isSettingCheckRP = false;
                    }
                    catch
                    {
                        isSettingCheckRP = false;
                    }
                };

                grid.CurrentCellDirtyStateChanged -= Grid_CurrentCellDirtyStateChangedRP;
                grid.CurrentCellDirtyStateChanged += Grid_CurrentCellDirtyStateChangedRP;

                grid.CellValueChanged -= Grid_CellValueChangedRP;
                grid.CellValueChanged += Grid_CellValueChangedRP;

                ApplySavedCheckRP(grid, selectedSet);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Grid_CurrentCellDirtyStateChangedRP(object sender, EventArgs e)
        {
            try
            {
                DataGridView grid = sender as DataGridView;

                if (grid != null && grid.IsCurrentCellDirty)
                {
                    grid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
            catch
            {

            }
        }

        private void Grid_CellValueChangedRP(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (isSettingCheckRP) return;

                DataGridView grid = sender as DataGridView;
                if (grid == null) return;

                if (e.RowIndex < 0) return;
                if (grid.Columns[e.ColumnIndex].Name != "Check") return;

                DataGridViewRow row = grid.Rows[e.RowIndex];
                DataRowView drv = row.DataBoundItem as DataRowView;
                if (drv == null) return;

                string key = GetRowKeyRP(drv.Row);

                bool isChecked = false;
                if (row.Cells["Check"].Value != null)
                    isChecked = Convert.ToBoolean(row.Cells["Check"].Value);

                if (grid == grdyearlyleave)
                {
                    if (isChecked) selectedYearlyRP.Add(key);
                    else selectedYearlyRP.Remove(key);
                }
                else if (grid == grddailyleave)
                {
                    if (isChecked) selectedDailyRP.Add(key);
                    else selectedDailyRP.Remove(key);
                }
                else if (grid == grdpositionwiseleave)
                {
                    if (isChecked) selectedPositionRP.Add(key);
                    else selectedPositionRP.Remove(key);
                }
            }
            catch
            {

            }
        }
        private void ApplySavedCheckRP(DataGridView grid, HashSet<string> selectedSet)
        {
            try
            {
                isSettingCheckRP = true;

                foreach (DataGridViewRow row in grid.Rows)
                {
                    DataRowView drv = row.DataBoundItem as DataRowView;
                    if (drv == null) continue;

                    string key = GetRowKeyRP(drv.Row);
                    row.Cells["Check"].Value = selectedSet.Contains(key);
                }

                isSettingCheckRP = false;
            }
            catch
            {
                isSettingCheckRP = false;
            }
        }
        void AddCheckColumn(DataGridView grid)
        {
            try
            {
                if (!grid.Columns.Contains("Check"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
                    chk.Name = "Check";
                    chk.HeaderText = "";
                    chk.Width = 40;
                    chk.ReadOnly = false;
                    chk.TrueValue = true;
                    chk.FalseValue = false;

                    grid.Columns.Insert(0, chk);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainFormLoadRP()
        {
            try
            {
                isFormLoaded = false;

                clsUser obj = new clsUser();

                yearlyPageRP = 1;
                dailyPageRP = 1;
                positionPageRP = 1;

                dtYearlyPageRP = obj.YearLeaveRP();
                dtDailyPageRP = obj.DailyLeaveRP();
                dtPositionPageRP = obj.PositionWiseLeaveRP();

                LoadGridPageRP(grdyearlyleave, dtYearlyPageRP, yearlyPageRP);
                LoadGridPageRP(grddailyleave, dtDailyPageRP, dailyPageRP);
                LoadGridPageRP(grdpositionwiseleave, dtPositionPageRP, positionPageRP);

                CreateYearlyPagiButtonRP();
                CreateDailyPagiButtonRP();
                CreatePositionPagiButtonRP();

                BindNameCombo();
                BindPositionCombo();

                CheckBoxYearlyLeave();
                CheckBoxDailyLeave();
                CheckBoxPositionWise();

                LockGrid(grdyearlyleave);
                LockGrid(grddailyleave);
                LockGrid(grdpositionwiseleave);

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LockGrid(DataGridView grid)
        {
            try
            {
                grid.ReadOnly = false;
                grid.EditMode = DataGridViewEditMode.EditOnEnter;

                foreach (DataGridViewColumn col in grid.Columns)
                {
                    col.ReadOnly = true;
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (grid.Columns.Contains("Check"))
                    grid.Columns["Check"].ReadOnly = false;

                grid.AllowUserToAddRows = false;
                grid.AllowUserToDeleteRows = false;
                grid.MultiSelect = false;
                grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable GetSelectedFromSourceRP(DataTable source, HashSet<string> selectedSet)
        {
            DataTable result = new DataTable();

            result.Columns.Add("SrNo", typeof(int));

            foreach (DataColumn col in source.Columns)
            {
                if (!string.Equals(col.ColumnName, "SrNo", StringComparison.OrdinalIgnoreCase))
                    result.Columns.Add(col.ColumnName, typeof(object));
            }

            int sr = 1;

            foreach (DataRow row in source.Rows)
            {
                if (selectedSet.Contains(GetRowKeyRP(row)))
                {
                    DataRow dr = result.NewRow();
                    dr["SrNo"] = sr++;

                    foreach (DataColumn col in source.Columns)
                    {
                        if (result.Columns.Contains(col.ColumnName))
                            dr[col.ColumnName] = row[col.ColumnName];
                    }

                    result.Rows.Add(dr);
                }
            }

            return result;
        }


        private void BindNameCombo()
        {
            try
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetnameRP();

                cmbbxname.DataSource = dt;
                cmbbxname.DisplayMember = "StaffName";
                cmbbxname.ValueMember = "StaffCode";
                cmbbxname.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindPositionCombo()
        {
            try
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetpositionRP();

                cmbbxpositionYearly.DataSource = dt;
                cmbbxpositionYearly.DisplayMember = "PositionName";
                cmbbxpositionYearly.ValueMember = "PositionID";
                cmbbxpositionYearly.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtptodate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // FilterGridByDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpfromdate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                // FilterGridByDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void YearlyStaffName()
        {
            try
            {
                cmbbxname.SelectedIndex = -1;

                clsUser obj = new clsUser();
                DataTable dt = obj.GetnameRP();

                cmbbxname.DisplayMember = "StaffName";
                cmbbxname.ValueMember = "StaffCode";
                cmbbxname.SelectedIndex = -1;
                cmbbxname.DataSource = dt;
                cmbbxname.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DailyStaffName()
        {
            try
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetnameRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmApplyLea leave = new frmApplyLea();
                leave.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public int positionid;

        private void pctFilter_Click(object sender, EventArgs e)
        {
            try
            {
                // pnlfilter.Visible = !pnlfilter.Visible;
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
                string search = txtSearchBox.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(search))
                {
                    MainFormLoadRP();
                    return;
                }

                // YEARLY
                var yearlyRows = dtYearlyPageRP.AsEnumerable()
                    .Where(r => r.ItemArray.Any(x =>
                        x != null &&
                        x.ToString().ToLower().Contains(search)));

                DataTable yearlyFiltered = yearlyRows.Any()
                    ? yearlyRows.CopyToDataTable()
                    : dtYearlyPageRP.Clone();

                yearlyPageRP = 1;
                LoadGridPageRP(grdyearlyleave, yearlyFiltered, yearlyPageRP);

                // DAILY
                var dailyRows = dtDailyPageRP.AsEnumerable()
                    .Where(r => r.ItemArray.Any(x =>
                        x != null &&
                        x.ToString().ToLower().Contains(search)));

                DataTable dailyFiltered = dailyRows.Any()
                    ? dailyRows.CopyToDataTable()
                    : dtDailyPageRP.Clone();

                dailyPageRP = 1;
                LoadGridPageRP(grddailyleave, dailyFiltered, dailyPageRP);

                // POSITION
                var positionRows = dtPositionPageRP.AsEnumerable()
                    .Where(r => r.ItemArray.Any(x =>
                        x != null &&
                        x.ToString().ToLower().Contains(search)));

                DataTable positionFiltered = positionRows.Any()
                    ? positionRows.CopyToDataTable()
                    : dtPositionPageRP.Clone();

                positionPageRP = 1;
                LoadGridPageRP(grdpositionwiseleave, positionFiltered, positionPageRP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                frmApplyLea frm = new frmApplyLea();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    MainFormLoadRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string staffIDRP = "";
        int PositionIDRP;
        DataTable dt1 = new DataTable();
        private string filePathRP;

        public void ApplyNameAndPositionFilter()
        {
            try
            {
                if (!isFormLoaded) return;

                string staffID = "";
                int positionID = 0;

                if (cmbbxname.SelectedIndex >= 0 && cmbbxname.SelectedValue != null)
                    staffID = cmbbxname.SelectedValue.ToString();

                if (cmbbxpositionYearly.SelectedIndex >= 0 && cmbbxpositionYearly.SelectedValue != null)
                    positionID = Convert.ToInt32(cmbbxpositionYearly.SelectedValue);

                clsUser obj = new clsUser();

                if (staffID != "" && positionID > 0)
                {
                    obj.StaffCodeRP = staffID;
                    obj.PositionId = positionID;

                    grdyearlyleave.DataSource = obj.YearLeaveFPWiseRP();
                    grddailyleave.DataSource = obj.DailyLeaveFPWiseRP();
                    grdpositionwiseleave.DataSource = obj.PositionWiseLeavePWiseRP();
                }
                else if (staffID != "")
                {
                    obj.StaffCodeRP = staffID;

                    grdyearlyleave.DataSource = obj.YearLeaveNameWiseRP();
                    grddailyleave.DataSource = obj.DailyLeaveNameWiseRP();
                    grdpositionwiseleave.DataSource = obj.PositionWiseLeaveRP();
                }
                else if (positionID > 0)
                {
                    obj.PositionId = positionID;

                    grdyearlyleave.DataSource = obj.YearLeavePWiseRP();
                    grddailyleave.DataSource = obj.DailyLeavePWiseRP();
                    grdpositionwiseleave.DataSource = obj.PositionWiseLeavePWiseRP();
                }
                else
                {
                    grdyearlyleave.DataSource = obj.YearLeaveRP();
                    grddailyleave.DataSource = obj.DailyLeaveRP();
                    grdpositionwiseleave.DataSource = obj.PositionWiseLeaveRP();
                }

                CheckBoxYearlyLeave();
                CheckBoxDailyLeave();
                CheckBoxPositionWise();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void CheckBoxYearlyLeave()
        {
            try
            {
                SetupGridCheckBoxRP(grdyearlyleave, dtYearlyPageRP, selectedYearlyRP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CheckBoxDailyLeave()
        {
            try
            {
                SetupGridCheckBoxRP(grddailyleave, dtDailyPageRP, selectedDailyRP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void CheckBoxPositionWise()
        {
            try
            {
                SetupGridCheckBoxRP(grdpositionwiseleave, dtPositionPageRP, selectedPositionRP);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
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

        private void cmbbxname_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ApplyNameAndPositionFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxpositionYearly_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                ApplyNameAndPositionFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxname_Click(object sender, EventArgs e)
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

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                isFormLoaded = false;

                selectedYearlyRP.Clear();
                selectedDailyRP.Clear();
                selectedPositionRP.Clear();
                isSettingCheckRP = false;

                txtSearchBox.Text = "";

                cmbbxname.DataSource = null;
                cmbbxpositionYearly.DataSource = null;

                foreach (Control c in grdyearlyleave.Controls.OfType<CheckBox>().ToList())
                    grdyearlyleave.Controls.Remove(c);

                foreach (Control c in grddailyleave.Controls.OfType<CheckBox>().ToList())
                    grddailyleave.Controls.Remove(c);

                foreach (Control c in grdpositionwiseleave.Controls.OfType<CheckBox>().ToList())
                    grdpositionwiseleave.Controls.Remove(c);

                pnlFilter.Visible = true;

                MainFormLoadRP();

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxpositionYearly_Click(object sender, EventArgs e)
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

        public DataTable GetSelectedRows1RP()
        {
            DataTable dt = new DataTable();

            try
            {
                grdyearlyleave.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                foreach (DataGridViewColumn col in grdyearlyleave.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0 && col.Visible && !string.IsNullOrWhiteSpace(col.Name)
                        && !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase)
                        && !isIconCol)
                    {
                        dt.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                foreach (DataGridViewRow row in grdyearlyleave.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dt.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grdyearlyleave.Columns.Contains(col.ColumnName))
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            else
                                dr[col.ColumnName] = DBNull.Value;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Select At Least 1 Row........!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void pdf1RP()
        {
            Document docRP = null;

            try
            {
                DataTable dtRP = GetSelectedRows1RP();

                System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
                System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                System.Drawing.Font normalFont = new System.Drawing.Font("Segoe UI", 10);
                System.Drawing.Font boldFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

                Brush black = Brushes.Black;
                Brush blue = new SolidBrush(Color.FromArgb(20, 60, 150));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathRP = saveFileDialog.FileName;

                docRP = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(filePathRP, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph(label12.Text,
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
                if (docRP != null && docRP.IsOpen())
                    docRP.Close();

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSelectedRows2RP()
        {
            DataTable dt = new DataTable();

            try
            {
                grddailyleave.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                foreach (DataGridViewColumn col in grddailyleave.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0 && col.Visible && !string.IsNullOrWhiteSpace(col.Name)
                        && !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase)
                        && !isIconCol)
                    {
                        dt.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                foreach (DataGridViewRow row in grddailyleave.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dt.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grddailyleave.Columns.Contains(col.ColumnName))
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            else
                                dr[col.ColumnName] = DBNull.Value;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Select At Least 1 Row........!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void pdf2RP()
        {
            Document docRP = null;

            try
            {
                DataTable dtRP = GetSelectedRows2RP();

                System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
                System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                System.Drawing.Font normalFont = new System.Drawing.Font("Segoe UI", 10);
                System.Drawing.Font boldFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

                Brush black = Brushes.Black;
                Brush blue = new SolidBrush(Color.FromArgb(20, 60, 150));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathRP = saveFileDialog.FileName;

                docRP = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(filePathRP, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph(label13.Text,
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
                if (docRP != null && docRP.IsOpen())
                    docRP.Close();

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSelectedRows3RP()
        {
            DataTable dt = new DataTable();

            try
            {
                grdpositionwiseleave.EndEdit();

                dt.Columns.Add("SrNo", typeof(int));

                foreach (DataGridViewColumn col in grdpositionwiseleave.Columns)
                {
                    bool isIconCol = col is DataGridViewImageColumn || col is DataGridViewButtonColumn;

                    if (col.Index != 0 && col.Visible && !string.IsNullOrWhiteSpace(col.Name)
                        && !string.Equals(col.Name, "SrNo", StringComparison.OrdinalIgnoreCase)
                        && !isIconCol)
                    {
                        dt.Columns.Add(col.Name, typeof(object));
                    }
                }

                int srNo = 1;

                foreach (DataGridViewRow row in grdpositionwiseleave.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                    {
                        DataRow dr = dt.NewRow();

                        dr["SrNo"] = srNo++;

                        foreach (DataColumn col in dt.Columns)
                        {
                            if (col.ColumnName == "SrNo") continue;

                            if (grdpositionwiseleave.Columns.Contains(col.ColumnName))
                                dr[col.ColumnName] = row.Cells[col.ColumnName].Value ?? DBNull.Value;
                            else
                                dr[col.ColumnName] = DBNull.Value;
                        }

                        dt.Rows.Add(dr);
                    }
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Select At Least 1 Row........!!!!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public void pdf3RP()
        {
            Document docRP = null;

            try
            {
                DataTable dtRP = GetSelectedRows3RP();

                System.Drawing.Font titleFont = new System.Drawing.Font("Segoe UI", 22, FontStyle.Bold);
                System.Drawing.Font headerFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
                System.Drawing.Font normalFont = new System.Drawing.Font("Segoe UI", 10);
                System.Drawing.Font boldFont = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);

                Brush black = Brushes.Black;
                Brush blue = new SolidBrush(Color.FromArgb(20, 60, 150));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (.pdf)|.pdf";
                saveFileDialog.Title = "Save PDF File";
                saveFileDialog.FileName = "SelectedRows.pdf";

                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;

                string filePathRP = saveFileDialog.FileName;

                docRP = new Document(PageSize.A4, 10, 10, 10, 10);
                PdfWriter.GetInstance(docRP, new FileStream(filePathRP, FileMode.Create));
                docRP.Open();

                Paragraph title = new Paragraph(label13.Text,
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
                if (docRP != null && docRP.IsOpen())
                    docRP.Close();

                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable yearly = GetSelectedFromSourceRP(dtYearlyPageRP, selectedYearlyRP);
                DataTable daily = GetSelectedFromSourceRP(dtDailyPageRP, selectedDailyRP);
                DataTable position = GetSelectedFromSourceRP(dtPositionPageRP, selectedPositionRP);

                if (yearly.Rows.Count == 0 && daily.Rows.Count == 0 && position.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "PDF Files (*.pdf)|*.pdf";
                save.FileName = "Staff Leave.pdf";

                if (save.ShowDialog() != DialogResult.OK) return;

                Document doc = new Document(PageSize.A4.Rotate(), 10, 10, 10, 10);
                PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
                doc.Open();

                Paragraph mainTitle = new Paragraph("Staff Leave",
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA,
                        16,
                        iTextSharp.text.Font.BOLD));

                mainTitle.Alignment = Element.ALIGN_CENTER;
                mainTitle.SpacingAfter = 5;
                doc.Add(mainTitle);

                Paragraph generatedDate = new Paragraph(
                    "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt"),
                    new iTextSharp.text.Font(
                        iTextSharp.text.Font.FontFamily.HELVETICA,
                        10,
                        iTextSharp.text.Font.ITALIC));

                generatedDate.Alignment = Element.ALIGN_RIGHT;
                generatedDate.SpacingAfter = 10;
                doc.Add(generatedDate);

                AddPdfTableRP(doc, "Yearly Leave Report", yearly);
                AddPdfTableRP(doc, "Daily Leave Report", daily);
                AddPdfTableRP(doc, "Position Wise Leave Report", position);

                doc.Close();

                MessageBox.Show("PDF File Saved Successfully!\n" + filePathRP,
                  "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPdfTableRP(Document doc, string titleText, DataTable tableData)
        {
            if (tableData == null || tableData.Rows.Count == 0) return;

            Paragraph title = new Paragraph(titleText,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingBefore = 10;
            title.SpacingAfter = 10;
            doc.Add(title);

            PdfPTable table = new PdfPTable(tableData.Columns.Count);
            table.WidthPercentage = 100;

            foreach (DataColumn col in tableData.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(col.ColumnName,
                    FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
                cell.BackgroundColor = new BaseColor(240, 240, 240);
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }

            foreach (DataRow row in tableData.Rows)
            {
                foreach (DataColumn col in tableData.Columns)
                {
                    object val = row[col];
                    string displayValue = val == null ? "" : val.ToString();

                    if (col.ColumnName == "StartDate" ||
                        col.ColumnName == "EndDate")
                    {
                        DateTime dt;

                        if (DateTime.TryParse(displayValue, out dt))
                        {
                            displayValue = dt.ToString("dd-MM-yyyy");
                        }
                    }

                    table.AddCell(
                        new Phrase(displayValue,
                        FontFactory.GetFont("Arial", 8)));
                }
            }

            doc.Add(table);
        }

        private bool IsAnyRowChecked(DataGridView grid)
        {
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool HasSelectedRows(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[0].Value != null && Convert.ToBoolean(row.Cells[0].Value))
                        return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable yearly = GetSelectedFromSourceRP(dtYearlyPageRP, selectedYearlyRP);
                DataTable daily = GetSelectedFromSourceRP(dtDailyPageRP, selectedDailyRP);
                DataTable position = GetSelectedFromSourceRP(dtPositionPageRP, selectedPositionRP);

                if (yearly.Rows.Count == 0 && daily.Rows.Count == 0 && position.Rows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to export!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel File (*.xlsx)|*.xlsx";
                save.FileName = "Staff Leave.xlsx";

                if (save.ShowDialog() != DialogResult.OK) return;

                using (XLWorkbook wb = new XLWorkbook())
                {
                    var ws = wb.Worksheets.Add("Staff Leave");

                    int currentRow = 1;

                    if (yearly.Rows.Count > 0)
                        currentRow = AddExcelTableSameSheetRP(ws, yearly, "Yearly Leave Report", currentRow);

                    if (daily.Rows.Count > 0)
                        currentRow = AddExcelTableSameSheetRP(ws, daily, "Daily Leave Report", currentRow);

                    if (position.Rows.Count > 0)
                        currentRow = AddExcelTableSameSheetRP(ws, position, "Position Wise Leave Report", currentRow);

                    ws.Columns().AdjustToContents();

                    wb.SaveAs(save.FileName);
                }

                MessageBox.Show("Excel File Saved Successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int AddExcelTableSameSheetRP(IXLWorksheet ws, DataTable dt, string title, int startRow)
        {
            ws.Cell(startRow, 1).Value = title;
            ws.Cell(startRow, 1).Style.Font.Bold = true;
            ws.Cell(startRow, 1).Style.Font.FontSize = 16;
            ws.Range(startRow, 1, startRow, dt.Columns.Count).Merge();
            ws.Cell(startRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(startRow + 1, 1).Value =
                "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");

            ws.Range(startRow + 1, 1, startRow + 1, dt.Columns.Count).Merge();

            ws.Cell(startRow + 3, 1).InsertTable(dt);

            return startRow + dt.Rows.Count + 6;
        }
        private void AddExcelSheetRP(XLWorkbook wb, DataTable dt, string sheetName, string title)
        {
            var ws = wb.Worksheets.Add(sheetName);

            ws.Cell(1, 1).Value = title;
            ws.Cell(1, 1).Style.Font.Bold = true;
            ws.Cell(1, 1).Style.Font.FontSize = 16;
            ws.Range(1, 1, 1, dt.Columns.Count).Merge();
            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            ws.Cell(2, 1).Value = "Generated on: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            ws.Range(2, 1, 2, dt.Columns.Count).Merge();

            ws.Cell(4, 1).InsertTable(dt);

            ws.Columns().AdjustToContents();
        }
        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteFromActiveGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ExportToExcel(DataTable dt, string title)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "Excel File (*.xlsx)|*.xlsx";
                save.FileName = title + ".xlsx";

                if (save.ShowDialog() != DialogResult.OK)
                    return;

                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Report");

                    ws.Cell(1, 1).Value = title;
                    ws.Cell(1, 1).Style.Font.Bold = true;
                    ws.Cell(1, 1).Style.Font.FontSize = 18;
                    ws.Range(1, 1, 1, dt.Columns.Count).Merge().Style.Alignment
                        .SetHorizontal(XLAlignmentHorizontalValues.Center);

                    ws.Cell(2, 1).Value = "Generated On: " + DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
                    ws.Range(2, 1, 2, dt.Columns.Count).Merge().Style.Alignment
                        .SetHorizontal(XLAlignmentHorizontalValues.Right);

                    ws.Cell(4, 1).InsertTable(dt);

                    workbook.SaveAs(save.FileName);
                }

                MessageBox.Show("Excel File Saved Successfully!\n" + filePathRP,
      "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteFromActiveGrid()
        {
            try
            {
                DataGridView activeGrid = null;

                if (grdyearlyleave.Visible)
                    activeGrid = grdyearlyleave;
                else if (grddailyleave.Visible)
                    activeGrid = grddailyleave;
                else if (grdpositionwiseleave.Visible)
                    activeGrid = grdpositionwiseleave;

                if (activeGrid == null)
                    return;

                DataGridViewCheckBoxColumn checkColumn = activeGrid
                    .Columns
                    .OfType<DataGridViewCheckBoxColumn>()
                    .FirstOrDefault();

                if (checkColumn == null)
                {
                    MessageBox.Show("No checkbox column found in this grid.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int checkColumnIndex = checkColumn.Index;
                bool anyChecked = false;

                for (int i = activeGrid.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow row = activeGrid.Rows[i];

                    bool isChecked = false;

                    if (row.Cells[checkColumnIndex].Value != null &&
                        bool.TryParse(row.Cells[checkColumnIndex].Value.ToString(), out isChecked) &&
                        isChecked)
                    {
                        activeGrid.Rows.RemoveAt(i);
                        anyChecked = true;
                    }
                }

                if (!anyChecked)
                {
                    MessageBox.Show("Please select at least one row to delete!",
                        "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
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
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
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

        private void cmbbxname_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;
                ApplyNameAndPositionFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxpositionYearly_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;
                ApplyNameAndPositionFilter();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdyearlyleave_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (positionPageRP > 1)
                {
                    positionPageRP--;

                    LoadGridPageRP(grdpositionwiseleave, dtPositionPageRP, positionPageRP);
                    CheckBoxPositionWise();
                    LockGrid(grdpositionwiseleave);

                    CreatePositionPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGridPageRP(DataGridView grid, DataTable source, int pageNo)
        {
            try
            {
                if (source == null || source.Rows.Count == 0)
                {
                    grid.DataSource = null;
                    return;
                }

                int startIndex = (pageNo - 1) * pageSizeRP;

                DataTable pageTable = source.Clone();

                for (int i = startIndex; i < startIndex + pageSizeRP && i < source.Rows.Count; i++)
                {
                    pageTable.ImportRow(source.Rows[i]);
                }

                grid.DataSource = pageTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDailyPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (dailyPageRP > 1)
                {
                    dailyPageRP--;

                    LoadGridPageRP(grddailyleave, dtDailyPageRP, dailyPageRP);
                    CheckBoxDailyLeave();
                    LockGrid(grddailyleave);

                    CreateDailyPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDailyNext_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)dtDailyPageRP.Rows.Count / pageSizeRP);

                if (dailyPageRP < totalPages)
                {
                    dailyPageRP++;

                    LoadGridPageRP(grddailyleave, dtDailyPageRP, dailyPageRP);
                    CheckBoxDailyLeave();
                    LockGrid(grddailyleave);

                    CreateDailyPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYearlyPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (yearlyPageRP > 1)
                {
                    yearlyPageRP--;

                    LoadGridPageRP(grdyearlyleave, dtYearlyPageRP, yearlyPageRP);
                    CheckBoxYearlyLeave();
                    LockGrid(grdyearlyleave);

                    CreateYearlyPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnYearlyNext_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)dtYearlyPageRP.Rows.Count / pageSizeRP);

                if (yearlyPageRP < totalPages)
                {
                    yearlyPageRP++;

                    LoadGridPageRP(grdyearlyleave, dtYearlyPageRP, yearlyPageRP);
                    CheckBoxYearlyLeave();
                    LockGrid(grdyearlyleave);

                    CreateYearlyPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPositionNext_Click(object sender, EventArgs e)
        {
            try
            {
                int totalPages = (int)Math.Ceiling((double)dtPositionPageRP.Rows.Count / pageSizeRP);

                if (positionPageRP < totalPages)
                {
                    positionPageRP++;

                    LoadGridPageRP(grdpositionwiseleave, dtPositionPageRP, positionPageRP);
                    CheckBoxPositionWise();
                    LockGrid(grdpositionwiseleave);

                    CreatePositionPagiButtonRP();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateYearlyPagiButtonRP()
        {
            try
            {
                CreatePagiButtonsCommonRP(
                    pnlYearlyPage,
                    dtYearlyPageRP,
                    yearlyPageRP,
                    BtnYearlyPage_Click,
                    btnYearlyPrevious,
                    btnYearlyNext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateDailyPagiButtonRP()
        {
            try
            {
                CreatePagiButtonsCommonRP(
                    pnlDailyPage,
                    dtDailyPageRP,
                    dailyPageRP,
                    BtnDailyPage_Click,
                    btnDailyPrevious,
                    btnDailyNext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePositionPagiButtonRP()
        {
            try
            {
                CreatePagiButtonsCommonRP(
                    pnlPositionPage,
                    dtPositionPageRP,
                    positionPageRP,
                    BtnPositionPage_Click,
                    btnPositionPrevious,
                    btnPositionNext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CreatePagiButtonsCommonRP(
            Guna2Panel panel,
            DataTable source,
            int currentPage,
            EventHandler pageClick,
            Guna2Button previousButton,
            Guna2Button nextButton)
        {
            try
            {
                int bwidthRP = 40;
                int bheightRP = 30;
                int spacingRP = 5;
                int startXRP = 10;

                panel.Controls.Clear();

                int totalPagesRP = source == null || source.Rows.Count == 0
                    ? 1
                    : (int)Math.Ceiling((double)source.Rows.Count / pageSizeRP);

                panel.Visible = true;

                for (int i = 1; i <= totalPagesRP; i++)
                {
                    Guna2Button btnPage = new Guna2Button();

                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new Size(bwidthRP, bheightRP);
                    btnPage.Location = new System.Drawing.Point(startXRP, 0);

                    btnPage.FillColor = (i == currentPage) ? Color.Gray : Color.White;
                    btnPage.ForeColor = (i == currentPage) ? Color.White : Color.Black;
                    btnPage.BorderThickness = 0;
                    btnPage.BorderRadius = 0;

                    btnPage.Click += pageClick;

                    panel.Controls.Add(btnPage);

                    startXRP += bwidthRP + spacingRP;
                }

                previousButton.Enabled = currentPage > 1;
                nextButton.Enabled = currentPage < totalPagesRP;

                previousButton.Visible = true;
                nextButton.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnYearlyPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                yearlyPageRP = Convert.ToInt32(btn.Text);

                LoadGridPageRP(grdyearlyleave, dtYearlyPageRP, yearlyPageRP);
                CheckBoxYearlyLeave();
                LockGrid(grdyearlyleave);

                CreateYearlyPagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDailyPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                dailyPageRP = Convert.ToInt32(btn.Text);

                LoadGridPageRP(grddailyleave, dtDailyPageRP, dailyPageRP);
                CheckBoxDailyLeave();
                LockGrid(grddailyleave);

                CreateDailyPagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPositionPage_Click(object sender, EventArgs e)
        {
            try
            {
                Guna2Button btn = sender as Guna2Button;
                positionPageRP = Convert.ToInt32(btn.Text);

                LoadGridPageRP(grdpositionwiseleave, dtPositionPageRP, positionPageRP);
                CheckBoxPositionWise();
                LockGrid(grdpositionwiseleave);

                CreatePositionPagiButtonRP();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



