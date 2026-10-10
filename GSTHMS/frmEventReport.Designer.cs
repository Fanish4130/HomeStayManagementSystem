namespace GSTHMS
{
    partial class frmEventReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventReport));
            this.barEvent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.grdEvent = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pieEvent = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlFlowPages = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearch = new Guna.UI2.WinForms.Guna2Panel();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblToDate = new System.Windows.Forms.Label();
            this.dtpTo = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFrom = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.guna2HtmlToolTip1 = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.barEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieEvent)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // barEvent
            // 
            this.barEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea3.Name = "ChartArea1";
            this.barEvent.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.barEvent.Legends.Add(legend3);
            this.barEvent.Location = new System.Drawing.Point(21, 439);
            this.barEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.barEvent.Name = "barEvent";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.barEvent.Series.Add(series3);
            this.barEvent.Size = new System.Drawing.Size(652, 316);
            this.barEvent.TabIndex = 20;
            this.barEvent.Text = "chart1";
            this.barEvent.Click += new System.EventHandler(this.barEvent_Click);
            // 
            // grdEvent
            // 
            this.grdEvent.AllowUserToAddRows = false;
            this.grdEvent.AllowUserToDeleteRows = false;
            this.grdEvent.AllowUserToResizeColumns = false;
            this.grdEvent.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.grdEvent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdEvent.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEvent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdEvent.ColumnHeadersHeight = 30;
            this.grdEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEvent.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdEvent.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEvent.Location = new System.Drawing.Point(21, 75);
            this.grdEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grdEvent.Name = "grdEvent";
            this.grdEvent.RowHeadersVisible = false;
            this.grdEvent.RowHeadersWidth = 51;
            this.grdEvent.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdEvent.Size = new System.Drawing.Size(1311, 321);
            this.grdEvent.TabIndex = 19;
            this.grdEvent.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdEvent.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdEvent.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdEvent.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdEvent.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdEvent.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdEvent.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEvent.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdEvent.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdEvent.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEvent.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdEvent.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdEvent.ThemeStyle.HeaderStyle.Height = 30;
            this.grdEvent.ThemeStyle.ReadOnly = false;
            this.grdEvent.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdEvent.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdEvent.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEvent.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdEvent.ThemeStyle.RowsStyle.Height = 22;
            this.grdEvent.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEvent.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdEvent.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEvent_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            // 
            // pieEvent
            // 
            this.pieEvent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "ChartArea1";
            this.pieEvent.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.pieEvent.Legends.Add(legend4);
            this.pieEvent.Location = new System.Drawing.Point(721, 439);
            this.pieEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pieEvent.Name = "pieEvent";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.pieEvent.Series.Add(series4);
            this.pieEvent.Size = new System.Drawing.Size(611, 316);
            this.pieEvent.TabIndex = 21;
            this.pieEvent.Text = "pieEvent";
            this.pieEvent.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pieEvent_MouseClick);
            // 
            // btnPrevious
            // 
            this.btnPrevious.AnimatedGIF = true;
            this.btnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(21, 389);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(160, 43);
            this.btnPrevious.TabIndex = 25;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.DimGray;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1172, 389);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(160, 43);
            this.btnNext.TabIndex = 26;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlFlowPages
            // 
            this.pnlFlowPages.AutoSize = true;
            this.pnlFlowPages.Location = new System.Drawing.Point(192, 389);
            this.pnlFlowPages.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFlowPages.Name = "pnlFlowPages";
            this.pnlFlowPages.Size = new System.Drawing.Size(972, 43);
            this.pnlFlowPages.TabIndex = 27;
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctExcel);
            this.pnlMenuBar.Controls.Add(this.pctPDF);
            this.pnlMenuBar.Location = new System.Drawing.Point(21, 12);
            this.pnlMenuBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(600, 57);
            this.pnlMenuBar.TabIndex = 28;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(551, 7);
            this.pctFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(47, 42);
            this.pctFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFilter.TabIndex = 10;
            this.pctFilter.TabStop = false;
            this.pctFilter.Click += new System.EventHandler(this.pctFilter_Click);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearchBox.Controls.Add(this.txtSearchBox);
            this.pnlSearchBox.Location = new System.Drawing.Point(63, 7);
            this.pnlSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(301, 42);
            this.pnlSearchBox.TabIndex = 5;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBox.BorderColor = System.Drawing.Color.Black;
            this.txtSearchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBox.DefaultText = "";
            this.txtSearchBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBox.Location = new System.Drawing.Point(3, 2);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "Search Here !";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(295, 34);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(385, 7);
            this.pctRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(47, 42);
            this.pctRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctRefresh.TabIndex = 8;
            this.pctRefresh.TabStop = false;
            this.pctRefresh.Click += new System.EventHandler(this.pctRefresh_Click);
            // 
            // pctSearchBox
            // 
            this.pctSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSearchBox.BackColor = System.Drawing.Color.Transparent;
            this.pctSearchBox.Image = ((System.Drawing.Image)(resources.GetObject("pctSearchBox.Image")));
            this.pctSearchBox.ImageRotate = 0F;
            this.pctSearchBox.Location = new System.Drawing.Point(11, 7);
            this.pctSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctSearchBox.Name = "pctSearchBox";
            this.pctSearchBox.Size = new System.Drawing.Size(47, 42);
            this.pctSearchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSearchBox.TabIndex = 4;
            this.pctSearchBox.TabStop = false;
            // 
            // pctExcel
            // 
            this.pctExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctExcel.BackColor = System.Drawing.Color.Transparent;
            this.pctExcel.Image = ((System.Drawing.Image)(resources.GetObject("pctExcel.Image")));
            this.pctExcel.ImageRotate = 0F;
            this.pctExcel.Location = new System.Drawing.Point(503, 10);
            this.pctExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(43, 37);
            this.pctExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExcel.TabIndex = 6;
            this.pctExcel.TabStop = false;
            this.pctExcel.Click += new System.EventHandler(this.pctExcel_Click);
            // 
            // pctPDF
            // 
            this.pctPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctPDF.BackColor = System.Drawing.Color.Transparent;
            this.pctPDF.Image = ((System.Drawing.Image)(resources.GetObject("pctPDF.Image")));
            this.pctPDF.ImageRotate = 0F;
            this.pctPDF.Location = new System.Drawing.Point(437, 7);
            this.pctPDF.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // pnlSearch
            // 
            this.pnlSearch.BackColor = System.Drawing.Color.Transparent;
            this.pnlSearch.Controls.Add(this.lblFromDate);
            this.pnlSearch.Controls.Add(this.lblToDate);
            this.pnlSearch.Controls.Add(this.dtpTo);
            this.pnlSearch.Controls.Add(this.dtpFrom);
            this.pnlSearch.Location = new System.Drawing.Point(628, 15);
            this.pnlSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Size = new System.Drawing.Size(727, 48);
            this.pnlSearch.TabIndex = 29;
            this.pnlSearch.Visible = false;
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(4, 14);
            this.lblFromDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(75, 20);
            this.lblFromDate.TabIndex = 28;
            this.lblFromDate.Text = "FromDate";
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblToDate.Location = new System.Drawing.Point(389, 14);
            this.lblToDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(57, 20);
            this.lblToDate.TabIndex = 29;
            this.lblToDate.Text = "ToDate";
            // 
            // dtpTo
            // 
            this.dtpTo.BackColor = System.Drawing.SystemColors.ControlText;
            this.dtpTo.Checked = true;
            this.dtpTo.FillColor = System.Drawing.Color.White;
            this.dtpTo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpTo.Location = new System.Drawing.Point(455, 0);
            this.dtpTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpTo.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpTo.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(272, 48);
            this.dtpTo.TabIndex = 28;
            this.dtpTo.Value = new System.DateTime(2026, 6, 11, 0, 0, 0, 0);
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // dtpFrom
            // 
            this.dtpFrom.Checked = true;
            this.dtpFrom.FillColor = System.Drawing.Color.White;
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFrom.Location = new System.Drawing.Point(87, 0);
            this.dtpFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFrom.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFrom.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(295, 48);
            this.dtpFrom.TabIndex = 0;
            this.dtpFrom.Value = new System.DateTime(2026, 6, 11, 0, 0, 0, 0);
            // 
            // guna2HtmlToolTip1
            // 
            this.guna2HtmlToolTip1.AllowLinksHandling = true;
            this.guna2HtmlToolTip1.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // frmEventReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 770);
            this.Controls.Add(this.pnlSearch);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.pnlFlowPages);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.pieEvent);
            this.Controls.Add(this.barEvent);
            this.Controls.Add(this.grdEvent);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmEventReport";
            this.Text = "EventReport";
            this.Load += new System.EventHandler(this.EventReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEvent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieEvent)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlSearch.ResumeLayout(false);
            this.pnlSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart barEvent;
        private Guna.UI2.WinForms.Guna2DataGridView grdEvent;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieEvent;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.FlowLayoutPanel pnlFlowPages;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2Panel pnlSearch;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpTo;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFrom;
        private Guna.UI2.WinForms.Guna2HtmlToolTip guna2HtmlToolTip1;
    }
}