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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmFoodService : Form
    {
        ToolStripMenuItem activeMenuItem = null;
        DataTable filteredDT = null;
        public int pageSizeSRM = 15;   //number of rows
        public int currentPageSRM = 1;
        public int totalPageNumberSRM = 3;
        public int totalRecordsSRM = 0;
        public int totalPagesSRM = 0;
        public int startIndexSRM = 1;
        public int endindexSRM;
        public bool IsMenuPreviewSRM = false;
        public DataTable FullData;

        //Form background;
        //public Panel DimPanel { get; set; }

        public System.Data.DataTable dt = new System.Data.DataTable();
        CheckBox headerCheckBox = new CheckBox();
        public frmFoodService()
        {
            InitializeComponent();
            //DimPanel = new Panel
            //{
            //    BackColor = Color.FromArgb(150, 0, 0, 0),
            //    Dock = DockStyle.Fill,
            //    Visible = false
            //};
            //this.Controls.Add(DimPanel);
            //DimPanel.BringToFront();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void AddIconSRM()
        {
            if (grdFoodService.Columns.Contains("Action"))
                return;

            DataGridViewImageColumn col = new DataGridViewImageColumn();
            col.Name = "Action";
            col.HeaderText = "Action";
            col.Image = Properties.Resources.view_icon;
            col.ImageLayout = DataGridViewImageCellLayout.Zoom;

            int index = grdFoodService.Columns.Count;

            if (grdFoodService.Columns.Contains("FoodPrice"))
                index = grdFoodService.Columns["FoodPrice"].Index + 1;

            if (index > grdFoodService.Columns.Count)
                index = grdFoodService.Columns.Count;

            if (index < 0)
                index = 0;

            grdFoodService.Columns.Insert(index, col);

            // ❗ Set alignment here
            grdFoodService.Columns["Action"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            grdFoodService.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdFoodService.RowTemplate.Height = 25;
        }

        //private Form CreateDimBackgroundSRM(Form popup)g

        //{
        //    Form bg = new Form();
        //    bg.StartPosition = FormStartPosition.Manual;
        //    bg.FormBorderStyle = FormBorderStyle.None;
        //    bg.Opacity = 0.6;
        //    bg.BackColor = Color.Black;
        //    bg.WindowState = FormWindowState.Maximized;
        //    bg.TopMost = true;
        //    bg.Click += (s, e) =>
        //    {
        //        popup.Close(); // close popup
        //        bg.Close();    // close background
        //    };   
        //    return bg;
        //}

        DataTable dt1 = new DataTable();

        private void Form1_Load(object sender, EventArgs e)
        {
           
            pnlFilter.Visible = true;

            lblMenuName.Visible = true;
            cmbbxMenuName.Visible = true;
           

            toolTip1.SetToolTip(pctRefresh, "Refresh");
            toolTip1.SetToolTip(pctPDF, "Download The PDF");
            toolTip1.SetToolTip(pctExcel, "Export To Excel");
            toolTip1.SetToolTip(pctFilter, "Filters");

            grdFoodService.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdFoodService.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdFoodService.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdFoodService.GridColor = Color.Gray;
            grdFoodService.GridColor = System.Drawing.Color.Gray;
            this.grdFoodService.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdFoodService.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            // Load Menu Names
            clsUser food = new clsUser();
            DataTable dt2 = food.FetchMenuNameSRM();

            DataRow dr = dt2.NewRow();
            dr["FoodTypeID"] = 0;             // placeholder value
            dr["Food Type Name"] = "-- Select --"; // placeholder text
            dt2.Rows.InsertAt(dr, 0);

            cmbbxMenuName.DisplayMember = "Food Type Name";
            cmbbxMenuName.ValueMember = "FoodTypeID";
            cmbbxMenuName.DataSource = dt2;

            cmbbxMenuName.SelectedIndex = 0;


            // Load all Food data
            dt1 = food.DisplayFoodSRM();
            FullData = dt1.Copy();

            //// Add global SrNo directly
            //if (!FullData.Columns.Contains("SrNo"))
            //    FullData.Columns.Add("SrNo", typeof(int));

            //for (int i = 0; i < FullData.Rows.Count; i++)
            //    FullData.Rows[i]["SrNo"] = i + 1; // global SrNo


            // ❗ Initialize filteredDT
            filteredDT = dt1.Copy();

            grdFoodService.AllowUserToAddRows = false;

            // Pagination setup
            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);
            currentPageSRM = 1;

            // 1) Load first page
            LoadPageSRM();

            //if (grdFoodService.Columns.Contains("FoodPrice"))
            //{
            //    grdFoodService.Columns["FoodPrice"].HeaderText = "Food Price (₹)";
            //}

            // 2) Add icon column
            AddIconSRM();

            // 3) Add header checkbox (after layout)
            this.BeginInvoke(new Action(() => AddHeaderCheckBoxSRM()));

            // 4) Make all columns readonly except checkbox
            foreach (DataGridViewColumn col in grdFoodService.Columns)
                col.ReadOnly = true;

            if (grdFoodService.Columns.Contains("Check"))
                grdFoodService.Columns["Check"].ReadOnly = false;

            // 5) Create pagination buttons
            CreatePageButtonSRM();

            // 6) Show panel and bring on top
            pnlPages.Visible = true;
            pnlPages.BringToFront();

            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.Silver;
                activeMenuItem.ForeColor = Color.White;
            }
            // 🔹 Set this one as active
            activeMenuItem = viewFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;
        }

        public void LoadPageSRM()
        {
            if (filteredDT == null)
                filteredDT = dt1.Copy();

            startIndexSRM = (currentPageSRM - 1) * pageSizeSRM;

            DataTable dtPage = filteredDT.Clone();

            for (int i = startIndexSRM; i < startIndexSRM + pageSizeSRM && i < filteredDT.Rows.Count; i++)
            {
                dtPage.ImportRow(filteredDT.Rows[i]);
            }

            grdFoodService.DataSource = dtPage;
            // 🔹 ADD RUPEES SIGN IN COLUMN HEADER (IMPORTANT)


            // 🔹 OPTIONAL: better UI
            // grdFoodService.ColumnHeadersDefaultCellStyle.Font =
            // new Font("Segoe UI", 11F, FontStyle.Bold);

            AddSrNoSRM();
        }
        private void AddSrNoSRM()
        {

            // if (grdFoodService.Rows.Count == 0) return;

            int startNumber = ((currentPageSRM - 1) * pageSizeSRM) + 1;

            for (int i = 0; i < grdFoodService.Rows.Count; i++)
            {
                grdFoodService.Rows[i].Cells["Sr No"].Value = startNumber + i;
            }
        }


        public void CreatePageButtonSRM()
        {
            int btnWidth = 40;
            int btnHeight = 35;
            int spacing = 5;
            int x = 10;

            // Remove old page buttons
            foreach (Control c in pnlPages.Controls.OfType<Guna2Button>().ToList())
            {
                if (c.Name.StartsWith("btnPage"))
                    pnlPages.Controls.Remove(c);
            }

            int totalItems = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalItems / pageSizeSRM);

            if (totalPagesSRM < 1)
                totalPagesSRM = 1;

            for (int i = 1; i <= totalPagesSRM; i++)
            {
                Guna2Button btn = new Guna2Button();
                btn.Name = "btnPage" + i;
                btn.Text = i.ToString();
                btn.Size = new Size(btnWidth, btnHeight);
                btn.Location = new Point(x, 5);
                btn.FillColor = (i == currentPageSRM) ? Color.DimGray : Color.White;
                btn.ForeColor = (i == currentPageSRM) ? Color.White : Color.Black;

                btn.Click += btnPage_Click;

                pnlPages.Controls.Add(btn);

                x += btnWidth + spacing;
            }

            btnPrevious.Enabled = currentPageSRM > 1;
            btnNext.Enabled = currentPageSRM < totalPagesSRM;

            pnlPages.Visible = true;
            pnlPages.BringToFront();
        }



        public void btnPage_Click(object sender, EventArgs e)
        {
            Guna2Button btn = sender as Guna2Button;
            if (btn != null)

            {
                int pageNumber = Convert.ToInt32(btn.Text);
                currentPageSRM = pageNumber;
                LoadPageSRM();
                CreatePageButtonSRM();
            }
        }

        private void HeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            bool isChecked = headerCheckBox.Checked;
            grdFoodService.EndEdit();
            foreach (DataGridViewRow row in grdFoodService.Rows)
            {

                DataGridViewCheckBoxCell chk = row.Cells["check"] as DataGridViewCheckBoxCell;
                if (chk != null)
                    chk.Value = isChecked;
            }


            grdFoodService.RefreshEdit();
        }

        private void AddHeaderCheckBoxSRM()
        {
            if (!grdFoodService.Columns.Contains("check"))
                return;

            grdFoodService.Refresh();

            int colIndex = grdFoodService.Columns["check"].Index;

            // Get the rectangle of the header cell
            System.Drawing.Rectangle rect = grdFoodService.GetCellDisplayRectangle(colIndex, -1, true);

            headerCheckBox.Size = new Size(18, 18); // checkbox size

            // ---- CENTERING THE CHECKBOX ----
            int x = rect.X + (rect.Width - headerCheckBox.Width) / 2;
            int y = rect.Y + (rect.Height - headerCheckBox.Height) / 2;

            headerCheckBox.Location = new Point(x, y);
            headerCheckBox.BackColor = Color.Transparent;
            headerCheckBox.Cursor = Cursors.Hand;

            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            if (!grdFoodService.Controls.Contains(headerCheckBox))
                grdFoodService.Controls.Add(headerCheckBox);

            headerCheckBox.BringToFront();
        }


        private void ExportCheckedRowsToExcelSRM(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("Grid not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit(); // Commit checkbox state

            // Skip checkbox & icon columns
            var skipColumns = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "check", "Action", "Sr No", "Edit", "View", "Details", "Apply"
            };

            var exportColumns = grid.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumns.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (exportColumns.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Only selected rows
            var selectedRows = grid.Rows
                .Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow && Convert.ToBoolean(r.Cells["check"].Value) == true)
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export.",
                    "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "SelectedRows.xlsx";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string filePath = sfd.FileName;

                using (var workbook = new XLWorkbook())
                {
                    var ws = workbook.Worksheets.Add("Selected Rows");

                    int currentRow = 1;

                    ws.Cell(currentRow, 1).Value = "Total Active Guest";
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Cell(currentRow, 1).Style.Font.FontSize = 16;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow++;

                    ws.Cell(currentRow, 1).Value = "Genarated Date: " + DateTime.Now.ToString("dd-MM-yyyy");
                    ws.Cell(currentRow, 1).Style.Font.Bold = true;
                    ws.Range(currentRow, 1, currentRow, exportColumns.Count + 1).Merge().Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentRow += 2; // space after date

                    // -------------------------------
                    //  ADD TABLE HEADERS (SrNo + columns)
                    // -------------------------------

                    int currentCol = 1;

                    ws.Cell(currentRow, currentCol).Value = "SrNo";
                    ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                    ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                    ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                    currentCol++;

                    foreach (var col in exportColumns)
                    {
                        ws.Cell(currentRow, currentCol).Value = col.HeaderText;
                        ws.Cell(currentRow, currentCol).Style.Font.Bold = true;
                        ws.Cell(currentRow, currentCol).Style.Fill.BackgroundColor = XLColor.LightGray;
                        ws.Cell(currentRow, currentCol).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        currentCol++;
                    }

                    // -------------------------------
                    //  ADD DATA ROWS
                    // -------------------------------
                    int srNo = 1;

                    foreach (var row in selectedRows)
                    {
                        currentRow++;
                        currentCol = 1;

                        // Add SrNo
                        ws.Cell(currentRow, currentCol).Value = srNo++;
                        currentCol++;

                        foreach (var col in exportColumns)
                        {
                            ws.Cell(currentRow, currentCol).Value = row.Cells[col.Index].Value?.ToString() ?? "";
                            currentCol++;
                        }
                    }

                    // Auto-fit
                    ws.Columns().AdjustToContents();

                    workbook.SaveAs(filePath);
                }

                MessageBox.Show("Excel file generated successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblFood_Click(object sender, EventArgs e)
        {

        }

        private void lblMenuName_Click(object sender, EventArgs e)
        {

        }

        private void cmbbxMenuName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxMenuName.SelectedIndex != -1)
            {
                string foodType = cmbbxMenuName.Text.Trim();
                ApplyFoodTypeFilterSRM(foodType);
            }
            LoadPageSRM();
            CreatePageButtonSRM();
        }
        private void ApplyFoodTypeFilterSRM(string foodType)
        {
            // If no data, just clear grid and exit (NO MESSAGE)
            if (dt1 == null || dt1.Rows.Count == 0)
            {
                filteredDT = new DataTable();
                LoadPageSRM();
                CreatePageButtonSRM();
                return;
            }

            DataView dv = new DataView(dt1);

            string safeFoodType = foodType.Replace("'", "''").Trim();

            // Exact match filter
            dv.RowFilter = $"[Food Type Name] = '{safeFoodType}'";

            filteredDT = dv.ToTable();

            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);
            currentPageSRM = 1;

            LoadPageSRM();
            CreatePageButtonSRM();
        }

        private void cmbbxQty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }

        private void btnFood_Click(object sender, EventArgs e)
        {

        }


        private void btnview_Click(object sender, EventArgs e)
        {

        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            {
                if (currentPageSRM > 1)
                {
                    currentPageSRM--;
                    LoadPageSRM();
                    CreatePageButtonSRM();
                    BringToFront();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (currentPageSRM < totalPagesSRM)
            {
                currentPageSRM++;
                LoadPageSRM();
                CreatePageButtonSRM();
                BringToFront();
            }
        }

        private void cmbbxMenuType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void pctExcel_Click(object sender, EventArgs e)
        {

        }


        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

            // ❗ If checkbox clicked → do nothing
            if (grdFoodService.Columns[e.ColumnIndex].Name == "check")
                return;

            // ❗ If Details icon clicked → open form
            if (grdFoodService.Columns[e.ColumnIndex].Name == "Action")
            {
                if (grdFoodService.CurrentRow == null)
                {
                    MessageBox.Show("Please select a food item first.");
                    return;
                }

                string menuType = grdFoodService.CurrentRow.Cells["Food Type Name"].Value.ToString();
                string menuName = grdFoodService.CurrentRow.Cells["Food Name"].Value.ToString();

                clsUser viewfood = new clsUser();
                viewfood.FoodNameSRM = menuName;

                DataTable dt = viewfood.ViewFoodSRM();

                decimal price = 0;
                string description = "";
                string foodimage = "";

                if (dt.Rows.Count > 0)
                {
                    decimal.TryParse(dt.Rows[0]["FoodPrice"].ToString(), out price);
                    description = dt.Rows[0]["Description"].ToString();
                    foodimage = dt.Rows[0]["FoodImage"].ToString();
                }

                frmViewFood orderfood = new frmViewFood();
                orderfood.MenuTypeSRM = menuType;
                orderfood.MenuNameSRM = menuName;
                orderfood.PriceSRM = price;
                orderfood.DescriptionSRM = description;
                orderfood.FoodImageSRM = foodimage;
                orderfood.ParentFoodServiceForm = this;


                //orderfood.StartPosition = FormStartPosition.CenterScreen;
                //orderfood.TopMost = true;

                //// Create background & pass popup
                //background = CreateDimBackgroundSRM(orderfood);
                //background.Show();

                //// Close background when popup closes
                //orderfood.FormClosed += (s, args) =>
                //{
                //    if (background != null)
                //        background.Close();
                //};

                orderfood.Show();

            }
        }



        private void pctExcel_Click_1(object sender, EventArgs e)
        {
            ExportCheckedRowsToExcelSRM(grdFoodService);
        }

        private void ExportCheckedRowsToPDFSRM(DataGridView grid)
        {
            if (grid == null)
            {
                MessageBox.Show("No grid provided.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            grid.EndEdit();

            var skipColumnNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "Select", "check", "Action","imgView","Sr No","imgEdit","Apply","Details",
    };

            var orderedCols = grid.Columns.Cast<DataGridViewColumn>()
                .Where(c => c.Visible && !skipColumnNames.Contains(c.Name))
                .OrderBy(c => c.DisplayIndex)
                .ToList();

            if (orderedCols.Count == 0)
            {
                MessageBox.Show("No exportable columns found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewColumn checkCol = null;
            foreach (var name in new[] { "Select", "check" })
            {
                checkCol = grid.Columns.Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => string.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase));
                if (checkCol != null) break;
            }

            if (checkCol == null)
                checkCol = grid.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c is DataGridViewCheckBoxColumn);

            if (checkCol == null)
            {
                MessageBox.Show("Checkbox column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRows = grid.Rows.Cast<DataGridViewRow>()
                .Where(r => !r.IsNewRow &&
                            r.Cells[checkCol.Index].Value != null &&
                            Convert.ToBoolean(r.Cells[checkCol.Index].Value))
                .ToList();

            if (selectedRows.Count == 0)
            {
                MessageBox.Show("Please select at least one row to export.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PDF file|*.pdf";
                sfd.FileName = this.Text.Replace(" ", "_");

                if (sfd.ShowDialog() != DialogResult.OK) return;

                string filePath = sfd.FileName;

                Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // ---------------- FONT SETUP ----------------
                iTextSharp.text.Font headerFont = GetUnicodeFont(16, iTextSharp.text.Font.BOLD);
                iTextSharp.text.Font normalFont = GetUnicodeFont(10, iTextSharp.text.Font.NORMAL);
                iTextSharp.text.Font boldFont = GetUnicodeFont(11, iTextSharp.text.Font.BOLD);

                // ---------------- HEADER ----------------
                PdfPTable headerTable = new PdfPTable(1);
                headerTable.WidthPercentage = 100;

                PdfPCell titleCell = new PdfPCell(new Phrase("Food List", headerFont));
                titleCell.Border = PdfPCell.NO_BORDER;
                titleCell.HorizontalAlignment = Element.ALIGN_CENTER;
                headerTable.AddCell(titleCell);

                string dateOnly = "Genarated Date: " + DateTime.Now.ToString("dd-MM-yyyy");
                PdfPCell dateCell = new PdfPCell(new Phrase(dateOnly, boldFont));
                dateCell.Border = PdfPCell.NO_BORDER;
                dateCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                headerTable.AddCell(dateCell);

                headerTable.SpacingAfter = 15;
                doc.Add(headerTable);

                // ---------------- SrNo COLUMN ----------------
                bool hasSrNo = orderedCols.Any(c =>
                    c.HeaderText.Equals("SrNo", StringComparison.OrdinalIgnoreCase) ||
                    c.Name.Equals("SrNo", StringComparison.OrdinalIgnoreCase));

                if (!hasSrNo)
                {
                    orderedCols.Insert(0,
                        new DataGridViewTextBoxColumn { Name = "SrNo", HeaderText = "SrNo" });
                }

                // ---------------- TABLE -----------------
                PdfPTable table = new PdfPTable(orderedCols.Count);
                table.WidthPercentage = 100;

                // Header cells
                foreach (var col in orderedCols)
                {
                    var headerCell = new PdfPCell(new Phrase(col.HeaderText ?? col.Name, boldFont));
                    headerCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(headerCell);
                }

                // Data rows with SrNo starting from 1
                int sr = 1;

                foreach (var row in selectedRows)
                {
                    foreach (var col in orderedCols)
                    {
                        string value = "";

                        if (col.HeaderText.Equals("SrNo", StringComparison.OrdinalIgnoreCase) ||
                            col.Name.Equals("SrNo", StringComparison.OrdinalIgnoreCase))
                        {
                            value = sr.ToString();
                        }
                        else if (col.HeaderText.Equals("FoodPrice", StringComparison.OrdinalIgnoreCase) ||
                                 col.Name.Equals("FoodPrice", StringComparison.OrdinalIgnoreCase))
                        {
                            // Format FoodPrice with rupees
                            decimal price;
                            if (decimal.TryParse(row.Cells[col.Index].Value?.ToString(), out price))
                            {
                                value = "₹ " + price.ToString("N2");
                            }
                            else
                            {
                                value = row.Cells[col.Index].Value?.ToString() ?? "";
                            }
                        }
                        else
                        {
                            value = row.Cells[col.Index].Value?.ToString() ?? "";
                        }

                        var cell = new PdfPCell(new Phrase(value, normalFont));
                        cell.HorizontalAlignment = Element.ALIGN_CENTER;
                        table.AddCell(cell);
                    }

                    sr++;
                }

                doc.Add(table);

                doc.Close();

                MessageBox.Show("PDF generated successfully!\nSaved at: " + filePath,
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ---------------- HELPER METHOD FOR UNICODE FONT ----------------
        private iTextSharp.text.Font GetUnicodeFont(float size = 10, int style = iTextSharp.text.Font.NORMAL)
        {
            // Ensure this font exists on the system
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
            BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            return new iTextSharp.text.Font(bf, size, style);
        }


        private void pctFilter_Click(object sender, EventArgs e)
        {
            cmbbxMenuName.Visible = !cmbbxMenuName.Visible;
            lblMenuName.Visible = cmbbxMenuName.Visible;   // show label only when visible

            // Optional: bring it above grid
            cmbbxMenuName.BringToFront();
            lblMenuName.BringToFront();

        }

        private void pctRefresh_Click(object sender, EventArgs e)
        {
            txtSearchBox.Text = "";
            cmbbxMenuName.SelectedIndex = 0;   // Make sure first index is "-- Select --"

            // 🔹 2. Load all food data again
            clsUser food = new clsUser();
            dt1 = food.DisplayFoodSRM();

            // 🔹 3. Reset FullData & filtered data
            FullData = dt1.Copy();
            filteredDT = dt1.Copy();

            // 🔹 4. Reset pagination values
            currentPageSRM = 1;
            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // 🔹 5. Load the first page again
            LoadPageSRM();

            // 🔹 6. Recreate page buttons
            CreatePageButtonSRM();

            // 🔹 7. Reset header checkbox
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;

            // 🔹 8. Uncheck all row checkboxes
            foreach (DataGridViewRow row in grdFoodService.Rows)
            {
                if (row.Cells["check"] is DataGridViewCheckBoxCell chk)
                    chk.Value = false;
            }
            pnlFilter.Visible = true;
            lblMenuName.Visible = true;
            cmbbxMenuName.Visible = true;
        }

        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            ApplySearchSRM(txtSearchBox.Text);
        }


        public void ApplySearchSRM(string searchText)
        {
            if (FullData == null || FullData.Rows.Count == 0)
                return;

            searchText = (searchText ?? "").Trim().ToLower();

            IEnumerable<DataRow> filteredRows;

            if (string.IsNullOrEmpty(searchText))
            {
                filteredRows = FullData.AsEnumerable();
            }
            else
            {
                filteredRows = FullData.AsEnumerable()
                    .Where(row =>
                    {
                        // Check SrNo column for exact numeric match
                        if (row.Table.Columns.Contains("SrNo"))
                        {
                            if (int.TryParse(searchText, out int srNoSearch))
                            {
                                if (row["SrNo"] != DBNull.Value &&
                                    Convert.ToInt32(row["SrNo"]) == srNoSearch)
                                    return true;
                            }
                        }

                        // Check other columns with partial match
                        foreach (DataColumn col in FullData.Columns)
                        {
                            if (col.ColumnName.Equals("SrNo", StringComparison.OrdinalIgnoreCase))
                                continue;

                            string cellValue = row[col]?.ToString().ToLower() ?? "";
                            if (cellValue.Contains(searchText))
                                return true;
                        }

                        return false;
                    });
            }

            // Convert to DataTable
            filteredDT = filteredRows.Any() ? filteredRows.CopyToDataTable() : FullData.Clone();

            // Recalculate SrNo for filtered data
            for (int i = 0; i < filteredDT.Rows.Count; i++)
                filteredDT.Rows[i]["Sr No"] = i + 1;

            // Reset pagination
            totalRecordsSRM = filteredDT.Rows.Count;
            totalPagesSRM = (int)Math.Ceiling((double)totalRecordsSRM / pageSizeSRM);

            // Find the page number of the first match
            int pageToShow = 1;
            if (!string.IsNullOrEmpty(searchText))
            {
                DataRow firstMatch = filteredDT.AsEnumerable()
                    .FirstOrDefault(row =>
                    {
                        foreach (DataColumn col in filteredDT.Columns)
                        {
                            if (col.ColumnName.Equals("SrNo", StringComparison.OrdinalIgnoreCase))
                            {
                                if (int.TryParse(searchText, out int srNoSearch) &&
                                    row["SrNo"] != DBNull.Value &&
                                    Convert.ToInt32(row["SrNo"]) == srNoSearch)
                                    return true;
                            }
                            else
                            {
                                string value = row[col]?.ToString().ToLower() ?? "";
                                if (value.Contains(searchText))
                                    return true;
                            }
                        }
                        return false;
                    });

                if (firstMatch != null)
                {
                    int rowIndex = filteredDT.Rows.IndexOf(firstMatch);
                    pageToShow = (rowIndex / pageSizeSRM) + 1;  // correct page
                }
            }

            currentPageSRM = pageToShow;

            // Load page containing first match
            LoadPageSRM();
            CreatePageButtonSRM();

            // Reset header checkbox
            headerCheckBox.CheckedChanged -= HeaderCheckBox_CheckedChanged;
            headerCheckBox.Checked = false;
            headerCheckBox.CheckedChanged += HeaderCheckBox_CheckedChanged;
        }



        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening_1(object sender, CancelEventArgs e)
        {

        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void lblService_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContextMenuStrip1_Opening_2(object sender, CancelEventArgs e)
        {

        }

        private void pnlMenuBar_Paint(object sender, PaintEventArgs e)
        {

        }



        private void cmbbxMenuName_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pctFilter_Click_1(object sender, EventArgs e)
        {
            pnlFilter.Visible = !pnlFilter.Visible;

            lblMenuName.Visible = pnlFilter.Visible;
            cmbbxMenuName.Visible = pnlFilter.Visible;

        }

        private void pctPDF_Click_1(object sender, EventArgs e)
        {
            ExportCheckedRowsToPDFSRM(grdFoodService);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void viewFoodServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.Silver;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = viewFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmFoodService());

        }

        private void provideFoodServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = provideFoodServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;

            LoadFromInPannel(new frmActiveGuest());
        }

        private void parkingServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (activeMenuItem != null)
            {
                activeMenuItem.BackColor = Color.DimGray;
                activeMenuItem.ForeColor = Color.White;
            }

            // 🔹 Set this one as active
            activeMenuItem = parkingServiceToolStripMenuItem;
            activeMenuItem.BackColor = Color.Silver;
            activeMenuItem.ForeColor = Color.White;


            // frmParking obj=new frmParking();


            LoadFromInPannel(new frmParking());
        }
        public void LoadFromInPannel(Form frm)
        {
            pnlService.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            // Hide any MenuStrip inside child forms
            foreach (Control c in frm.Controls)
            {
                if (c is MenuStrip)
                    c.Visible = false;
            }

            frm.MainMenuStrip = null;

            pnlService.Controls.Add(frm);
            frm.Show();
        }


        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void pnlService_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}