namespace GSTHMS
{
    partial class frmGuest
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGuest));
            this.grdGuestDetails = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctAddGuest = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblGuestDetails = new System.Windows.Forms.Label();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPages = new Guna.UI2.WinForms.Guna2Panel();
            this.tipGuest = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.grdGuestDetails)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctAddGuest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdGuestDetails
            // 
            this.grdGuestDetails.AllowUserToAddRows = false;
            this.grdGuestDetails.AllowUserToResizeColumns = false;
            this.grdGuestDetails.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.grdGuestDetails.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdGuestDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGuestDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGuestDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdGuestDetails.ColumnHeadersHeight = 30;
            this.grdGuestDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdGuestDetails.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdGuestDetails.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdGuestDetails.Location = new System.Drawing.Point(11, 150);
            this.grdGuestDetails.Name = "grdGuestDetails";
            this.grdGuestDetails.RightToLeft = System.Windows.Forms.RightToLeft.No;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdGuestDetails.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdGuestDetails.RowHeadersVisible = false;
            this.grdGuestDetails.RowHeadersWidth = 51;
            this.grdGuestDetails.RowTemplate.Height = 24;
            this.grdGuestDetails.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdGuestDetails.Size = new System.Drawing.Size(1585, 625);
            this.grdGuestDetails.TabIndex = 0;
            this.grdGuestDetails.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdGuestDetails.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdGuestDetails.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdGuestDetails.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdGuestDetails.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdGuestDetails.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdGuestDetails.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdGuestDetails.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdGuestDetails.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdGuestDetails.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdGuestDetails.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdGuestDetails.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdGuestDetails.ThemeStyle.HeaderStyle.Height = 30;
            this.grdGuestDetails.ThemeStyle.ReadOnly = false;
            this.grdGuestDetails.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdGuestDetails.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdGuestDetails.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdGuestDetails.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdGuestDetails.ThemeStyle.RowsStyle.Height = 24;
            this.grdGuestDetails.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdGuestDetails.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdGuestDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGuestDetails_CellClick);
            this.grdGuestDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdGuestDetails_CellContentClick);
            this.grdGuestDetails.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.grdGuestDetails_DataBindingComplete);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.txtSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctAddGuest);
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctExcel);
            this.pnlMenuBar.Controls.Add(this.pctPDF);
            this.pnlMenuBar.Location = new System.Drawing.Point(12, 78);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(761, 56);
            this.pnlMenuBar.TabIndex = 11;
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
            this.txtSearchBox.Location = new System.Drawing.Point(74, 7);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "Search Here...";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(295, 35);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctAddGuest
            // 
            this.pctAddGuest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctAddGuest.BackColor = System.Drawing.Color.Transparent;
            this.pctAddGuest.Image = ((System.Drawing.Image)(resources.GetObject("pctAddGuest.Image")));
            this.pctAddGuest.ImageRotate = 0F;
            this.pctAddGuest.Location = new System.Drawing.Point(691, 7);
            this.pctAddGuest.Name = "pctAddGuest";
            this.pctAddGuest.Size = new System.Drawing.Size(47, 42);
            this.pctAddGuest.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pctAddGuest.TabIndex = 12;
            this.pctAddGuest.TabStop = false;
            this.pctAddGuest.Click += new System.EventHandler(this.ptr_Click);
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(625, 7);
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
            this.pnlSearchBox.Location = new System.Drawing.Point(63, 7);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(0, 0);
            this.pnlSearchBox.TabIndex = 5;
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(406, 6);
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
            this.pctSearchBox.Location = new System.Drawing.Point(21, 6);
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
            this.pctExcel.Location = new System.Drawing.Point(553, 6);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(47, 42);
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
            this.pctPDF.Location = new System.Drawing.Point(472, 6);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // lblGuestDetails
            // 
            this.lblGuestDetails.AutoSize = true;
            this.lblGuestDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestDetails.Location = new System.Drawing.Point(670, 18);
            this.lblGuestDetails.Name = "lblGuestDetails";
            this.lblGuestDetails.Size = new System.Drawing.Size(252, 42);
            this.lblGuestDetails.TabIndex = 13;
            this.lblGuestDetails.Text = " Guest Details";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFromDate.ForeColor = System.Drawing.Color.Black;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFromDate.Location = new System.Drawing.Point(124, 9);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(234, 29);
            this.dtpFromDate.TabIndex = 15;
            this.dtpFromDate.Value = new System.DateTime(2025, 11, 25, 13, 0, 35, 751);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // dtpToDate
            // 
            this.dtpToDate.BackColor = System.Drawing.Color.White;
            this.dtpToDate.Checked = true;
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpToDate.ForeColor = System.Drawing.Color.Black;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpToDate.Location = new System.Drawing.Point(472, 9);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(244, 29);
            this.dtpToDate.TabIndex = 16;
            this.dtpToDate.Value = new System.DateTime(2025, 11, 25, 13, 0, 35, 751);
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderColor = System.Drawing.Color.Black;
            this.pnlFilter.BorderRadius = 1;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.label1);
            this.pnlFilter.Controls.Add(this.lblFromDate);
            this.pnlFilter.Controls.Add(this.dtpToDate);
            this.pnlFilter.Controls.Add(this.dtpFromDate);
            this.pnlFilter.ForeColor = System.Drawing.Color.Black;
            this.pnlFilter.Location = new System.Drawing.Point(798, 79);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(727, 55);
            this.pnlFilter.TabIndex = 17;
            this.pnlFilter.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(376, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "To Date:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(3, 12);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(104, 20);
            this.lblFromDate.TabIndex = 21;
            this.lblFromDate.Text = "From Date:";
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Black;
            this.btnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(12, 781);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(124, 42);
            this.btnPrevious.TabIndex = 18;
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
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1472, 781);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 42);
            this.btnNext.TabIndex = 19;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlPages
            // 
            this.pnlPages.BackColor = System.Drawing.Color.Transparent;
            this.pnlPages.BorderColor = System.Drawing.SystemColors.Control;
            this.pnlPages.Location = new System.Drawing.Point(142, 781);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(1324, 42);
            this.pnlPages.TabIndex = 20;
            this.pnlPages.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPages_Paint);
            // 
            // tipGuest
            // 
            this.tipGuest.AllowLinksHandling = true;
            this.tipGuest.BackColor = System.Drawing.Color.Transparent;
            this.tipGuest.BorderColor = System.Drawing.Color.Transparent;
            this.tipGuest.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // frmGuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1612, 931);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.lblGuestDetails);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.grdGuestDetails);
            this.Name = "frmGuest";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmGuest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdGuestDetails)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctAddGuest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView grdGuestDetails;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctAddGuest;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private System.Windows.Forms.Label lblGuestDetails;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Panel pnlPages;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2HtmlToolTip tipGuest;
    }
}