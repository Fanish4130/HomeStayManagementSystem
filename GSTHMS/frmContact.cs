using ClosedXML.Excel;
using Guna.UI2.WinForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmContact : Form
    {
        public int pageSizePSS = 20;
        public int currentPagePSS = 1;
        public int totalPagesPSS = 0;

        clsUser objUser = new clsUser();
        DataTable dt1 = new DataTable();
        CheckBox headerCheckBox = new CheckBox();
        DataTable dtFiltered = null;

        private DataTable CurrentData =>
            (dtFiltered != null && dtFiltered.Rows.Count > 0) ? dtFiltered : dt1;

        public frmContact()
        {
            InitializeComponent();
        }

        // ── Header checkbox ────────────────────────────────────────────────────────

        private void AddHeaderCheckBoxPSS()
        {
            try
            {
                if (!grdContact.Columns.Contains("check")) return;

                System.Drawing.Rectangle rect =
                    grdContact.GetCellDisplayRectangle(
                        grdContact.Columns["check"].Index, -1, true);

                headerCheckBox.Size = new System.Drawing.Size(16, 16);
                headerCheckBox.BackColor = System.Drawing.Color.Transparent;
                headerCheckBox.Cursor = Cursors.Hand;
                headerCheckBox.Location = new System.Drawing.Point(
                    rect.X + 58, rect.Y + (rect.Height - headerCheckBox.Height) / 2);

                headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
                headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

                if (!grdContact.Controls.Contains(headerCheckBox))
                    grdContact.Controls.Add(headerCheckBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding header checkbox: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                bool isChecked = headerCheckBox.Checked;
                grdContact.EndEdit();

                foreach (DataGridViewRow row in grdContact.Rows)
                {
                    DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                    if (chk != null)
                        chk.Value = isChecked;
                }

                grdContact.RefreshEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating checkboxes: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Paging ─────────────────────────────────────────────────────────────────

        private void LoadPagePSS()
        {
            try
            {
                int startIndex = (currentPagePSS - 1) * pageSizePSS;
                DataTable source = CurrentData;

                if (source == null || source.Rows.Count == 0)
                {
                    grdContact.DataSource = null;
                    return;
                }

                DataTable dtPage = source.Clone();
                for (int i = startIndex; i < startIndex + pageSizePSS && i < source.Rows.Count; i++)
                    dtPage.ImportRow(source.Rows[i]);

                grdContact.DataSource = null;
                grdContact.DataSource = dtPage;

                ApplyColumnSettingsPSS();
                AddHeaderCheckBoxPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyColumnSettingsPSS()
        {
            try
            {
                if (grdContact.Columns.Contains("ContactId"))
                    grdContact.Columns["ContactId"].Visible = false;

                if (!grdContact.Columns.Contains("imgView"))
                {
                    DataGridViewImageColumn imgView = new DataGridViewImageColumn();
                    imgView.Name = "imgView";
                    imgView.HeaderText = "View";
                    imgView.Image = Properties.Resources.view_icon;
                    imgView.ImageLayout = DataGridViewImageCellLayout.Zoom;
                    grdContact.Columns.Add(imgView);
                }

                grdContact.Columns["imgView"].DisplayIndex = grdContact.Columns.Count - 1;

                foreach (DataGridViewColumn col in grdContact.Columns)
                    col.ReadOnly = true;

                if (grdContact.Columns.Contains("Email"))
                    grdContact.Columns["Email"].ReadOnly = false;

                if (grdContact.Columns.Contains("Contact No"))
                    grdContact.Columns["Contact No"].ReadOnly = false;

                if (grdContact.Columns.Contains("check"))
                    grdContact.Columns["check"].ReadOnly = false;

                if (grdContact.Columns.Contains("imgView"))
                    grdContact.Columns["imgView"].ReadOnly = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying column settings: " + ex.Message,
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
                    currentPagePSS = Convert.ToInt32(btn.Text);
                    LoadPagePSS();
                    CreatePageButtonPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error navigating to page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreatePageButtonPSS()
        {
            try
            {
                int bwidth = 40, bheight = 35, spacing = 5, start = 10;
                pnlPages.Controls.Clear();

                int totalpages = (int)Math.Ceiling(
                    (double)CurrentData.Rows.Count / pageSizePSS);
                totalPagesPSS = totalpages;

                for (int i = 1; i <= totalpages; i++)
                {
                    var btnPage = new Guna2Button();
                    btnPage.Name = "btnPage" + i;
                    btnPage.Text = i.ToString();
                    btnPage.Size = new System.Drawing.Size(bwidth, bheight);
                    btnPage.Location = new System.Drawing.Point(start, 5);
                    btnPage.FillColor = (i == currentPagePSS)
                        ? System.Drawing.Color.Silver : System.Drawing.Color.White;
                    btnPage.ForeColor = (i == currentPagePSS)
                        ? System.Drawing.Color.White : System.Drawing.Color.Black;
                    btnPage.Click += btnPage_Click;
                    pnlPages.Controls.Add(btnPage);
                    start += bwidth + spacing;
                }

                btnPrevious.Enabled = currentPagePSS > 1;
                btnNext.Enabled = currentPagePSS < totalPagesPSS;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating page buttons: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Data loading ───────────────────────────────────────────────────────────

        public void LoadGridPSS()
        {
            try
            {
                clsUser SlotA1 = new clsUser();
                dt1 = SlotA1.ContactPaginationPSS();
                dtFiltered = null;
                currentPagePSS = 1;
                LoadPagePSS();
                CreatePageButtonPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading contact data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Form load ──────────────────────────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                LoadGridPSS();

                grdContact.DefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11);
                grdContact.ColumnHeadersDefaultCellStyle.Font =
                    new System.Drawing.Font("Arial", 11);
                grdContact.ColumnHeadersDefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                grdContact.DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;
                grdContact.CellBorderStyle = DataGridViewCellBorderStyle.Single;
                grdContact.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdContact.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                grdContact.GridColor = System.Drawing.Color.Gray;
                grdContact.AllowUserToAddRows = false;
                grdContact.EditMode = DataGridViewEditMode.EditOnEnter;

                // ── Wire inline-edit save event ────────────────────────────────
                grdContact.CellEndEdit += grdContact_CellEndEdit;

                tipContact.SetToolTip(pctRefresh, "Refresh");
                tipContact.SetToolTip(pctPDF, "Download The PDF");
                tipContact.SetToolTip(pctExcel, "Export To Excel");
                tipContact.SetToolTip(pctAddContact, "Add Contact");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during form load: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Navigation ─────────────────────────────────────────────────────────────

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPagePSS > 1)
                {
                    currentPagePSS--;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error going to previous page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentPagePSS < totalPagesPSS)
                {
                    currentPagePSS++;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error going to next page: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Grid events ────────────────────────────────────────────────────────────

        private void grdContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                var row = grdContact.Rows[e.RowIndex];

                if (grdContact.Columns[e.ColumnIndex].Name == "imgView")
                {
                    frmViewContact f = new frmViewContact();
                    f.ContactNoPSS = Convert.ToInt64(row.Cells["Contact No"].Value);
                    f.ContactNamePSS = row.Cells["Contact Name"].Value.ToString();
                    f.ContactTypePSS = row.Cells["Contact Type"].Value.ToString();
                    f.DescriptionPSS = row.Cells["Description"].Value.ToString();
                    f.EmailPSS = row.Cells["Email"].Value.ToString();
                    f.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening contact view: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdContact_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;
                if (grdContact.Columns[e.ColumnIndex].Name != "check") return;

                grdContact.EndEdit();

                int contactId = Convert.ToInt32(
                    grdContact.Rows[e.RowIndex].Cells["ContactId"].Value);
                bool isChecked = Convert.ToBoolean(
                    grdContact.Rows[e.RowIndex].Cells["check"].Value);

                DataTable source = (dtFiltered != null && dtFiltered.Rows.Count > 0)
                    ? dtFiltered : dt1;

                DataRow dr = source.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("ContactId") == contactId);

                if (dr != null)
                    dr["check"] = isChecked;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating checkbox state: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdContact_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // ── Inline Edit Save ───────────────────────────────────────────────────────

        private void grdContact_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                string colName = grdContact.Columns[e.ColumnIndex].Name;

                if (colName != "Email" && colName != "Contact No")
                    return;

                // ── Read ContactId ─────────────────────────────────────────────
                object contactIdObj = grdContact.Rows[e.RowIndex].Cells["ContactId"].Value;
                if (contactIdObj == null || contactIdObj == DBNull.Value)
                {
                    MessageBox.Show("ContactId not found. Please refresh.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int contactId = Convert.ToInt32(contactIdObj);

                // ── Read newly typed value ─────────────────────────────────────
                string newValue = grdContact.Rows[e.RowIndex]
                    .Cells[e.ColumnIndex].Value?.ToString()?.Trim() ?? "";

                // ── Validate Email ─────────────────────────────────────────────
                if (colName == "Email")
                {
                    if (string.IsNullOrWhiteSpace(newValue))
                    {
                        MessageBox.Show("Email cannot be empty.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RevertCellValuePSS(e.RowIndex, colName, contactId);
                        return;
                    }

                    if (!IsValidEmailPSS(newValue))
                    {
                        MessageBox.Show(
                            "Invalid email address.\n\nPlease enter a valid email (e.g. name@domain.com).",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RevertCellValuePSS(e.RowIndex, colName, contactId);
                        return;
                    }
                }

                // ── Validate Contact No ────────────────────────────────────────
                if (colName == "Contact No")
                {
                    if (string.IsNullOrWhiteSpace(newValue))
                    {
                        MessageBox.Show("Contact No cannot be empty.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RevertCellValuePSS(e.RowIndex, colName, contactId);
                        return;
                    }

                    // Only digits allowed
                    if (!newValue.All(char.IsDigit))
                    {
                        MessageBox.Show(
                            "Contact No must contain digits only.\nNo spaces, letters or symbols allowed.",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RevertCellValuePSS(e.RowIndex, colName, contactId);
                        return;
                    }

                    // Exactly 10 digits
                    if (newValue.Length != 10)
                    {
                        MessageBox.Show(
                            "Contact No must be exactly 10 digits.\n\nEntered: " + newValue.Length + " digit(s).",
                            "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        RevertCellValuePSS(e.RowIndex, colName, contactId);
                        return;
                    }
                }

                // ── Confirmation before saving ─────────────────────────────────
                string fieldLabel = (colName == "Email") ? "Email" : "Contact No";
                string contactName = grdContact.Rows[e.RowIndex]
                    .Cells["Contact Name"].Value?.ToString() ?? "";

                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to update " + fieldLabel + " for:\n\n" +
                    "Contact : " + contactName + "\n" +
                    "New " + fieldLabel + " : " + newValue,
                    "Confirm Update",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes)
                {
                    RevertCellValuePSS(e.RowIndex, colName, contactId);
                    return;
                }

                // ── Get other column value from master DataTable ───────────────
                DataTable source = (dtFiltered != null && dtFiltered.Rows.Count > 0)
                    ? dtFiltered : dt1;

                DataRow masterRow = source.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("ContactId") == contactId);

                if (masterRow == null)
                {
                    MessageBox.Show("Record not found in memory. Please refresh.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string finalEmail = (colName == "Email")
                    ? newValue
                    : masterRow["Email"].ToString();

                string finalContactNo = (colName == "Contact No")
                    ? newValue
                    : masterRow["Contact No"].ToString();

                // ── Save to DB ─────────────────────────────────────────────────
                clsUser obj = new clsUser();
                obj.CidPSS = contactId;
                obj.EmailPSS = finalEmail;
                obj.ContactNoPSS = Convert.ToInt64(finalContactNo);
                obj.UpdateContactInlinePSS();

                // ── Sync master DataTable ──────────────────────────────────────
                masterRow["Email"] = finalEmail;
                masterRow["Contact No"] = finalContactNo;

                // ── Success message ────────────────────────────────────────────
                MessageBox.Show(
                    fieldLabel + " updated successfully for " + contactName + ".",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving edit: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // ── Validation helper ──────────────────────────────────────────────────────

        private bool IsValidEmailPSS(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // ── Revert cell to original DB value on validation failure ─────────────────

        private void RevertCellValuePSS(int rowIndex, string colName, int contactId)
        {
            try
            {
                DataTable source = (dtFiltered != null && dtFiltered.Rows.Count > 0)
                    ? dtFiltered : dt1;

                DataRow dr = source.AsEnumerable()
                    .FirstOrDefault(r => r.Field<int>("ContactId") == contactId);

                if (dr != null)
                    grdContact.Rows[rowIndex].Cells[colName].Value = dr[colName];
            }
            catch { }
        }

        // ── Add contact ────────────────────────────────────────────────────────────

        private void OpenAddContactForm()
        {
            try
            {
                frmAddContact objfrmU = new frmAddContact();
                objfrmU.MdiParent = this.MdiParent;
                objfrmU.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening Add Contact form: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddContact_Click(object sender, EventArgs e) => OpenAddContactForm();
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) => OpenAddContactForm();

        // ── Search ─────────────────────────────────────────────────────────────────

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ApplySearchFilterPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplySearchFilterPSS()
        {
            try
            {
                string searchText = txtSearchBox.Text.Trim();

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    dtFiltered = null;
                    currentPagePSS = 1;
                    LoadPagePSS();
                    CreatePageButtonPSS();
                    return;
                }

                dtFiltered = dt1.Clone();

                HashSet<string> skipColumns =
                    new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                    { "SrNo", "check", "ContactId", "imgEdit", "imgView" };

                var filteredRows = dt1.AsEnumerable()
                    .Where(row =>
                        dt1.Columns.Cast<DataColumn>()
                           .Where(col => !skipColumns.Contains(col.ColumnName))
                           .Any(col =>
                           {
                               object value = row[col];
                               return value != DBNull.Value &&
                                      value.ToString().IndexOf(
                                          searchText,
                                          StringComparison.OrdinalIgnoreCase) >= 0;
                           })
                    );

                foreach (var row in filteredRows)
                    dtFiltered.ImportRow(row);

                currentPagePSS = 1;
                LoadPagePSS();
                CreatePageButtonPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error applying search filter: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Refresh ────────────────────────────────────────────────────────────────

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearchBox.Clear();
                LoadGridPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error refreshing data: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Delete ─────────────────────────────────────────────────────────────────

        private void pctDelete_Click(object sender, EventArgs e)
        {
            try
            {
                grdContact.EndEdit();

                var selectedRows = grdContact.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow &&
                                 Convert.ToBoolean(r.Cells["check"].Value) == true)
                    .ToList();

                if (selectedRows.Count == 0)
                {
                    MessageBox.Show("Please select at least one row to delete.",
                        "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show(
                        "Are you sure you want to delete the selected contact(s)?",
                        "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                    != DialogResult.Yes)
                    return;

                foreach (var row in selectedRows)
                {
                    try
                    {
                        int id = Convert.ToInt32(row.Cells["ContactId"].Value);
                        clsUser obj = new clsUser();
                        obj.CidPSS = id;
                        obj.DeleteContactPSS();
                    }
                    catch (Exception rowEx)
                    {
                        MessageBox.Show(
                            "Error deleting contact ID " +
                            row.Cells["ContactId"].Value + ": " + rowEx.Message,
                            "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                MessageBox.Show("Selected contact(s) deleted successfully.",
                    "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadGridPSS();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during delete operation: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Export PDF ─────────────────────────────────────────────────────────────

        private void ExportCheckedRowsToPDF()
        {
            try
            {
                grdContact.EndEdit();

                var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "check", "Action", "SrNo", "imgView", "imgEdit", "ContactId" };

                var exportColumns = grdContact.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (exportColumns.Count == 0)
                {
                    MessageBox.Show("No exportable columns found.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Determine rows to export ───────────────────────────────────────
                List<DataRow> rowsToExport;

                if (headerCheckBox.Checked)
                {
                    // Header checkbox → export ALL rows across all pages
                    rowsToExport = CurrentData.AsEnumerable().ToList();
                }
                else
                {
                    rowsToExport = grdContact.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow
                                 && r.Cells["check"].Value != null
                                 && Convert.ToBoolean(r.Cells["check"].Value))
                        .Select(r => ((DataRowView)r.DataBoundItem).Row)
                        .ToList();

                    if (rowsToExport.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "PDF file|*.pdf";
                    sfd.FileName = "Contact_Report.pdf";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    Document doc = null;
                    try
                    {
                        doc = new Document(PageSize.A4.Rotate(), 36f, 36f, 36f, 36f);
                        PdfWriter.GetInstance(
                            doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        // ── Fonts ──────────────────────────────────────────────────
                        Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, BaseColor.BLACK);
                        Font fontSmall = FontFactory.GetFont(FontFactory.HELVETICA, 10, BaseColor.BLACK);
                        Font fontSmallBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        Font fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, BaseColor.BLACK);
                        Font fontData = FontFactory.GetFont(FontFactory.HELVETICA, 9, BaseColor.BLACK);

                        // ── Colors ─────────────────────────────────────────────────
                        BaseColor headerBg = new BaseColor(220, 220, 220);
                        BaseColor borderColor = new BaseColor(180, 180, 180);
                        BaseColor rowAltBg = new BaseColor(245, 245, 245);

                        // ── Report header ──────────────────────────────────────────
                        PdfPTable headerTable = new PdfPTable(1);
                        headerTable.WidthPercentage = 100;

                        headerTable.AddCell(new PdfPCell(
                            new Phrase("Contact Report", fontTitle))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            PaddingBottom = 4f
                        });

                        headerTable.AddCell(new PdfPCell(
                            new Phrase("Generated On : " +
                                DateTime.Now.ToString("dd/MM/yyyy hh:mm tt"), fontSmall))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_RIGHT,
                            PaddingBottom = 2f
                        });

                        headerTable.AddCell(new PdfPCell(
                            new Phrase("Total Records : " + rowsToExport.Count, fontSmallBold))
                        {
                            Border = PdfPCell.NO_BORDER,
                            HorizontalAlignment = Element.ALIGN_LEFT,
                            PaddingBottom = 6f
                        });

                        headerTable.SpacingAfter = 10f;
                        doc.Add(headerTable);

                        // ── Data table ─────────────────────────────────────────────
                        PdfPTable table = new PdfPTable(exportColumns.Count + 1);
                        table.WidthPercentage = 100;

                        // Helper: header cell
                        Func<string, PdfPCell> MakeHeaderCell = text => new PdfPCell(
                            new Phrase(text, fontHeader))
                        {
                            BackgroundColor = headerBg,
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 6f,
                            BorderColor = borderColor,
                            BorderWidth = 0.5f
                        };

                        // Helper: data cell
                        Func<string, PdfPCell> MakeDataCell = text => new PdfPCell(
                            new Phrase(text, fontData))
                        {
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            VerticalAlignment = Element.ALIGN_MIDDLE,
                            Padding = 5f,
                            BorderColor = borderColor,
                            BorderWidth = 0.5f
                        };

                        // Header row
                        table.AddCell(MakeHeaderCell("SrNo"));
                        foreach (var col in exportColumns)
                            table.AddCell(MakeHeaderCell(col.HeaderText));

                        // Data rows — read from DataRow directly (all pages)
                        int srNo = 1;
                        foreach (DataRow row in rowsToExport)
                        {
                            bool isAlt = (srNo % 2 == 0);

                            PdfPCell srCell = MakeDataCell(srNo.ToString());
                            if (isAlt) srCell.BackgroundColor = rowAltBg;
                            table.AddCell(srCell);

                            foreach (var col in exportColumns)
                            {
                                object value = DBNull.Value;

                                if (!string.IsNullOrEmpty(col.DataPropertyName)
                                    && row.Table.Columns.Contains(col.DataPropertyName))
                                    value = row[col.DataPropertyName];
                                else if (row.Table.Columns.Contains(col.Name))
                                    value = row[col.Name];

                                string text = "";
                                if (value != DBNull.Value && value != null)
                                    text = (value is DateTime dt)
                                        ? dt.ToString("dd/MM/yyyy")
                                        : value.ToString();

                                PdfPCell dataCell = MakeDataCell(text);
                                if (isAlt) dataCell.BackgroundColor = rowAltBg;
                                table.AddCell(dataCell);
                            }

                            srNo++;
                        }

                        doc.Add(table);

                        MessageBox.Show(
                            "PDF generated successfully!\nTotal rows exported: " + rowsToExport.Count,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception pdfEx)
                    {
                        MessageBox.Show("Error writing PDF: " + pdfEx.Message,
                            "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        if (doc != null && doc.IsOpen()) doc.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctPDF_Click(object sender, EventArgs e) => ExportCheckedRowsToPDF();

        // ── Export Excel ───────────────────────────────────────────────────────────

        private void ExportCheckedRowsToExcel(DataGridView grid)
        {
            try
            {
                if (grid == null)
                {
                    MessageBox.Show("Grid not found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                grid.EndEdit();

                var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        { "check", "Action", "SrNo", "Edit", "View", "imgView", "imgEdit", "ContactId" };

                var exportColumns = grid.Columns.Cast<DataGridViewColumn>()
                    .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                    .OrderBy(c => c.DisplayIndex)
                    .ToList();

                if (exportColumns.Count == 0)
                {
                    MessageBox.Show("No exportable columns found.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ── Determine rows to export ───────────────────────────────────────
                List<DataRow> rowsToExport;

                if (headerCheckBox.Checked)
                {
                    // Header checkbox → export ALL rows across all pages
                    rowsToExport = CurrentData.AsEnumerable().ToList();
                }
                else
                {
                    rowsToExport = grid.Rows.Cast<DataGridViewRow>()
                        .Where(r => !r.IsNewRow
                                 && r.Cells["check"].Value != null
                                 && Convert.ToBoolean(r.Cells["check"].Value))
                        .Select(r => ((DataRowView)r.DataBoundItem).Row)
                        .ToList();

                    if (rowsToExport.Count == 0)
                    {
                        MessageBox.Show("Please select at least one row to export.",
                            "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Excel Files|*.xlsx";
                    sfd.FileName = "ContactDetails.xlsx";

                    if (sfd.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            var ws = workbook.Worksheets.Add("Contact Details");

                            int totalCols = exportColumns.Count + 1; // +1 for SrNo

                            // ── Row 1 : Title ──────────────────────────────────────
                            ws.Cell(1, 1).Value = "Contact Details";
                            ws.Range(1, 1, 1, totalCols).Merge();
                            ws.Row(1).Style
                                .Font.SetBold(true)
                                .Font.SetFontSize(16)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            ws.Row(1).Height = 28;

                            // ── Row 2 : Total Records (left) + Generated On (right) ─
                            ws.Cell(2, 1).Value = "Total Records : " + rowsToExport.Count;
                            ws.Cell(2, 1).Style
                                .Font.SetItalic(true)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

                            ws.Cell(2, totalCols).Value =
                                "Generated On: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm tt");
                            ws.Cell(2, totalCols).Style
                                .Font.SetBold(true)
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

                            // ── Row 3 : Column headers ─────────────────────────────
                            int headerRow = 3;
                            int currentRow = headerRow;
                            int currentCol = 1;

                            ws.Cell(currentRow, currentCol).Value = "SrNo";
                            ws.Cell(currentRow, currentCol).Style
                                .Font.SetBold(true)
                                .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                            currentCol++;

                            foreach (var col in exportColumns)
                            {
                                ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                                ws.Cell(currentRow, currentCol).Style
                                    .Font.SetBold(true)
                                    .Fill.SetBackgroundColor(XLColor.FromHtml("#DCDCDC"))
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                                    .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                                currentCol++;
                            }

                            ws.Row(headerRow).Height = 22;

                            // ── Rows 4+ : Data (reads DataRow directly, all pages) ──
                            int sr = 1;
                            XLColor altColor = XLColor.FromHtml("#F5F5F5");

                            foreach (DataRow row in rowsToExport)
                            {
                                currentRow++;
                                currentCol = 1;
                                bool isAlt = (sr % 2 == 0);

                                // SrNo
                                ws.Cell(currentRow, currentCol).Value = sr++;
                                ws.Cell(currentRow, currentCol).Style
                                    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                if (isAlt)
                                    ws.Cell(currentRow, currentCol).Style
                                        .Fill.SetBackgroundColor(altColor);
                                currentCol++;

                                foreach (var col in exportColumns)
                                {
                                    // Read from DataRow — not grid cell — so all pages work
                                    object cellValue = DBNull.Value;

                                    if (!string.IsNullOrEmpty(col.DataPropertyName)
                                        && row.Table.Columns.Contains(col.DataPropertyName))
                                        cellValue = row[col.DataPropertyName];
                                    else if (row.Table.Columns.Contains(col.Name))
                                        cellValue = row[col.Name];

                                    string displayText = "";
                                    if (cellValue != DBNull.Value && cellValue != null)
                                        displayText = (cellValue is DateTime dtVal)
                                            ? dtVal.ToString("dd/MM/yyyy")
                                            : cellValue.ToString();

                                    ws.Cell(currentRow, currentCol).Value = displayText;
                                    ws.Cell(currentRow, currentCol).Style
                                        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
                                    if (isAlt)
                                        ws.Cell(currentRow, currentCol).Style
                                            .Fill.SetBackgroundColor(altColor);
                                    currentCol++;
                                }
                            }

                            // ── Border on header + data block ──────────────────────
                            if (currentRow >= headerRow)
                            {
                                var dataRange = ws.Range(headerRow, 1, currentRow, totalCols);
                                dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                                dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                                dataRange.Style.Border.OutsideBorderColor = XLColor.Gray;
                                dataRange.Style.Border.InsideBorderColor = XLColor.Gray;
                            }

                            // ── Auto-fit + narrow SrNo ─────────────────────────────
                            ws.Columns().AdjustToContents();
                            ws.Column(1).Width = 8;

                            workbook.SaveAs(sfd.FileName);
                        }

                        MessageBox.Show(
                            "Excel file generated successfully!\nTotal rows exported: " + rowsToExport.Count,
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (IOException ioEx)
                    {
                        MessageBox.Show(
                            "File is already open or cannot be written.\n" + ioEx.Message,
                            "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception excelEx)
                    {
                        MessageBox.Show("Error writing Excel file: " + excelEx.Message,
                            "Excel Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pctExcel_Click(object sender, EventArgs e) =>
            ExportCheckedRowsToExcel(grdContact);

        // ── Misc unused event stubs ────────────────────────────────────────────────

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void maskedTextBox1_TabIndexChanged(object sender, EventArgs e) { }
        private void txtName_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void lblContact_Click(object sender, EventArgs e) { }
        private void pnlPages_Paint(object sender, PaintEventArgs e) { }
        private void chkAll_CheckedChanged(object sender, EventArgs e) { }
    }
}