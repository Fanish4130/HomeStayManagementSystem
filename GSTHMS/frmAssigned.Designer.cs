namespace GSTHMS
{
    partial class frmAssignedTask
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAssignedTask));
            this.grdAssignTask = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlPagination = new Guna.UI2.WinForms.Guna2Panel();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMenuBarAllGuest = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.dtpToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpFromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblToDate = new System.Windows.Forms.Label();
            this.lblFromDate = new System.Windows.Forms.Label();
            this.lblTask1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignTask)).BeginInit();
            this.pnlMenuBarAllGuest.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdAssignTask
            // 
            this.grdAssignTask.AllowUserToAddRows = false;
            this.grdAssignTask.AllowUserToDeleteRows = false;
            this.grdAssignTask.AllowUserToResizeColumns = false;
            this.grdAssignTask.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle29.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.Color.Black;
            this.grdAssignTask.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.grdAssignTask.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAssignTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.grdAssignTask.ColumnHeadersHeight = 30;
            this.grdAssignTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            this.grdAssignTask.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAssignTask.DefaultCellStyle = dataGridViewCellStyle31;
            this.grdAssignTask.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAssignTask.Location = new System.Drawing.Point(48, 167);
            this.grdAssignTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdAssignTask.Name = "grdAssignTask";
            this.grdAssignTask.ReadOnly = true;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAssignTask.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.grdAssignTask.RowHeadersVisible = false;
            this.grdAssignTask.RowHeadersWidth = 51;
            this.grdAssignTask.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAssignTask.RowTemplate.Height = 28;
            this.grdAssignTask.Size = new System.Drawing.Size(1603, 643);
            this.grdAssignTask.TabIndex = 2;
            this.grdAssignTask.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAssignTask.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdAssignTask.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdAssignTask.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdAssignTask.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdAssignTask.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdAssignTask.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAssignTask.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdAssignTask.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdAssignTask.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAssignTask.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdAssignTask.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAssignTask.ThemeStyle.HeaderStyle.Height = 30;
            this.grdAssignTask.ThemeStyle.ReadOnly = true;
            this.grdAssignTask.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAssignTask.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAssignTask.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAssignTask.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAssignTask.ThemeStyle.RowsStyle.Height = 28;
            this.grdAssignTask.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAssignTask.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAssignTask.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAssignTask_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // pnlPagination
            // 
            this.pnlPagination.Location = new System.Drawing.Point(206, 812);
            this.pnlPagination.Name = "pnlPagination";
            this.pnlPagination.Size = new System.Drawing.Size(1272, 45);
            this.pnlPagination.TabIndex = 3;
            // 
            // btnPrevious
            // 
            this.btnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevious.FillColor = System.Drawing.Color.Silver;
            this.btnPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(48, 815);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 45);
            this.btnPrevious.TabIndex = 4;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.Silver;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1511, 815);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 45);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlMenuBarAllGuest
            // 
            this.pnlMenuBarAllGuest.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBarAllGuest.BorderRadius = 1;
            this.pnlMenuBarAllGuest.BorderThickness = 1;
            this.pnlMenuBarAllGuest.Controls.Add(this.pctFilter);
            this.pnlMenuBarAllGuest.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctRefresh);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctSearchBox);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctExcel);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctPDF);
            this.pnlMenuBarAllGuest.Location = new System.Drawing.Point(48, 94);
            this.pnlMenuBarAllGuest.Name = "pnlMenuBarAllGuest";
            this.pnlMenuBarAllGuest.Size = new System.Drawing.Size(598, 56);
            this.pnlMenuBarAllGuest.TabIndex = 11;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(535, 7);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(48, 42);
            this.pctFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctFilter.TabIndex = 10;
            this.pctFilter.TabStop = false;
            this.pctFilter.Click += new System.EventHandler(this.pctFilter_Click);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearchBox.BorderThickness = 1;
            this.pnlSearchBox.Controls.Add(this.txtSearchBox);
            this.pnlSearchBox.Location = new System.Drawing.Point(63, 7);
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
            this.txtSearchBox.Location = new System.Drawing.Point(3, 3);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(295, 35);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(373, 7);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(48, 42);
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
            this.pctSearchBox.Location = new System.Drawing.Point(10, 7);
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
            this.pctExcel.Location = new System.Drawing.Point(481, 7);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(48, 42);
            this.pctExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.pctPDF.Location = new System.Drawing.Point(427, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderColor = System.Drawing.Color.Black;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.dtpToDate);
            this.pnlFilter.Controls.Add(this.dtpFromDate);
            this.pnlFilter.Controls.Add(this.lblToDate);
            this.pnlFilter.Controls.Add(this.lblFromDate);
            this.pnlFilter.Location = new System.Drawing.Point(664, 94);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(814, 50);
            this.pnlFilter.TabIndex = 15;
            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // dtpToDate
            // 
            this.dtpToDate.BackColor = System.Drawing.Color.Black;
            this.dtpToDate.BorderThickness = 1;
            this.dtpToDate.Checked = true;
            this.dtpToDate.FillColor = System.Drawing.Color.White;
            this.dtpToDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpToDate.ForeColor = System.Drawing.Color.Black;
            this.dtpToDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpToDate.Location = new System.Drawing.Point(540, 7);
            this.dtpToDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpToDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(263, 36);
            this.dtpToDate.TabIndex = 18;
            this.dtpToDate.Value = new System.DateTime(2025, 11, 9, 14, 42, 6, 18);
            this.dtpToDate.ValueChanged += new System.EventHandler(this.dtpToDate_ValueChanged);
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.BackColor = System.Drawing.Color.Black;
            this.dtpFromDate.BorderThickness = 1;
            this.dtpFromDate.Checked = true;
            this.dtpFromDate.FillColor = System.Drawing.Color.White;
            this.dtpFromDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.ForeColor = System.Drawing.Color.Black;
            this.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpFromDate.Location = new System.Drawing.Point(144, 7);
            this.dtpFromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpFromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(263, 36);
            this.dtpFromDate.TabIndex = 17;
            this.dtpFromDate.Value = new System.DateTime(2025, 11, 9, 14, 42, 6, 18);
            this.dtpFromDate.ValueChanged += new System.EventHandler(this.dtpFromDate_ValueChanged);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(432, 12);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(102, 25);
            this.lblToDate.TabIndex = 17;
            this.lblToDate.Text = "To Date :";
            // 
            // lblFromDate
            // 
            this.lblFromDate.AutoSize = true;
            this.lblFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Location = new System.Drawing.Point(3, 12);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(125, 25);
            this.lblFromDate.TabIndex = 16;
            this.lblFromDate.Text = "From Date :";
            // 
            // lblTask1
            // 
            this.lblTask1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblTask1.Location = new System.Drawing.Point(628, 20);
            this.lblTask1.Name = "lblTask1";
            this.lblTask1.Size = new System.Drawing.Size(375, 45);
            this.lblTask1.TabIndex = 16;
            this.lblTask1.Text = "ASSIGNED TASK";
            // 
            // frmAssignedTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 964);
            this.ControlBox = false;
            this.Controls.Add(this.lblTask1);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlMenuBarAllGuest);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.pnlPagination);
            this.Controls.Add(this.grdAssignTask);
            this.Name = "frmAssignedTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAssignedTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignTask)).EndInit();
            this.pnlMenuBarAllGuest.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public Guna.UI2.WinForms.Guna2DataGridView grdAssignTask;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private Guna.UI2.WinForms.Guna2Panel pnlPagination;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBarAllGuest;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.Label lblToDate;
        private System.Windows.Forms.Label lblFromDate;
        private System.Windows.Forms.Label lblTask1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpToDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpFromDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
    }
}