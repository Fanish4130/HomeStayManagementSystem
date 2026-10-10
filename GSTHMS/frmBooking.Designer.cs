namespace GSTHMS
{
    partial class frmBooking
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBooking));
            this.grdAllBookingsFL = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnCheckOut = new System.Windows.Forms.DataGridViewButtonColumn();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBoxFL = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbbxByBookingFL = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbbxRoomTypeFL = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblBookingRecordsFL = new System.Windows.Forms.Label();
            this.lblByRoomTypeFL = new System.Windows.Forms.Label();
            this.btnPreviousFL = new Guna.UI2.WinForms.Guna2Button();
            this.btnNextFL = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPagesFL = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.PctBackFL = new Guna.UI2.WinForms.Guna2PictureBox();
            this.timerRoom = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBookingsFL)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBackFL)).BeginInit();
            this.SuspendLayout();
            // 
            // grdAllBookingsFL
            // 
            this.grdAllBookingsFL.AllowUserToAddRows = false;
            this.grdAllBookingsFL.AllowUserToDeleteRows = false;
            this.grdAllBookingsFL.AllowUserToResizeColumns = false;
            this.grdAllBookingsFL.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            this.grdAllBookingsFL.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdAllBookingsFL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAllBookingsFL.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAllBookingsFL.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdAllBookingsFL.ColumnHeadersHeight = 25;
            this.grdAllBookingsFL.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.btnCheckOut});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAllBookingsFL.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdAllBookingsFL.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAllBookingsFL.Location = new System.Drawing.Point(11, 187);
            this.grdAllBookingsFL.Name = "grdAllBookingsFL";
            this.grdAllBookingsFL.RowHeadersVisible = false;
            this.grdAllBookingsFL.RowHeadersWidth = 51;
            this.grdAllBookingsFL.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdAllBookingsFL.RowTemplate.Height = 24;
            this.grdAllBookingsFL.Size = new System.Drawing.Size(1474, 617);
            this.grdAllBookingsFL.TabIndex = 0;
            this.grdAllBookingsFL.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAllBookingsFL.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdAllBookingsFL.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdAllBookingsFL.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdAllBookingsFL.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdAllBookingsFL.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdAllBookingsFL.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAllBookingsFL.ThemeStyle.HeaderStyle.Height = 25;
            this.grdAllBookingsFL.ThemeStyle.ReadOnly = false;
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.Height = 24;
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAllBookingsFL.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAllBookingsFL.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllBookingsFL_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.HeaderText = "CheckOut";
            this.btnCheckOut.MinimumWidth = 6;
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Text = "CheckOut";
            this.btnCheckOut.UseColumnTextForButtonValue = true;
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderRadius = 1;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.guna2PictureBox1);
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctExcel);
            this.pnlMenuBar.Controls.Add(this.pctPDF);
            this.pnlMenuBar.Location = new System.Drawing.Point(12, 85);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(685, 56);
            this.pnlMenuBar.TabIndex = 8;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(595, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(68, 49);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 11;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click_1);
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(550, 7);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(47, 42);
            this.pctFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctFilter.TabIndex = 10;
            this.pctFilter.TabStop = false;
            this.pctFilter.Click += new System.EventHandler(this.pctFilter_Click);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearchBox.Controls.Add(this.txtSearchBoxFL);
            this.pnlSearchBox.Location = new System.Drawing.Point(63, 7);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(301, 42);
            this.pnlSearchBox.TabIndex = 5;
            // 
            // txtSearchBoxFL
            // 
            this.txtSearchBoxFL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBoxFL.BorderColor = System.Drawing.Color.Black;
            this.txtSearchBoxFL.BorderRadius = 2;
            this.txtSearchBoxFL.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearchBoxFL.DefaultText = "";
            this.txtSearchBoxFL.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearchBoxFL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearchBoxFL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBoxFL.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearchBoxFL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBoxFL.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearchBoxFL.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearchBoxFL.Location = new System.Drawing.Point(3, 3);
            this.txtSearchBoxFL.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBoxFL.Name = "txtSearchBoxFL";
            this.txtSearchBoxFL.PlaceholderText = "Search";
            this.txtSearchBoxFL.SelectedText = "";
            this.txtSearchBoxFL.Size = new System.Drawing.Size(295, 35);
            this.txtSearchBoxFL.TabIndex = 3;
            this.txtSearchBoxFL.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(389, 7);
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
            this.pctSearchBox.Location = new System.Drawing.Point(6, 7);
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
            this.pctExcel.Location = new System.Drawing.Point(496, 7);
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
            this.pctPDF.Location = new System.Drawing.Point(443, 7);
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
            this.pnlFilter.BorderRadius = 1;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.cmbbxByBookingFL);
            this.pnlFilter.Controls.Add(this.cmbbxRoomTypeFL);
            this.pnlFilter.Controls.Add(this.lblBookingRecordsFL);
            this.pnlFilter.Controls.Add(this.lblByRoomTypeFL);
            this.pnlFilter.Location = new System.Drawing.Point(717, 85);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(768, 56);
            this.pnlFilter.TabIndex = 11;
            // 
            // cmbbxByBookingFL
            // 
            this.cmbbxByBookingFL.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxByBookingFL.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxByBookingFL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxByBookingFL.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxByBookingFL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxByBookingFL.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxByBookingFL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxByBookingFL.ItemHeight = 30;
            this.cmbbxByBookingFL.Items.AddRange(new object[] {
            "Today\'s Booking",
            "Active Booking",
            "All Booking"});
            this.cmbbxByBookingFL.Location = new System.Drawing.Point(543, 9);
            this.cmbbxByBookingFL.Name = "cmbbxByBookingFL";
            this.cmbbxByBookingFL.Size = new System.Drawing.Size(222, 36);
            this.cmbbxByBookingFL.TabIndex = 6;
            this.cmbbxByBookingFL.SelectedIndexChanged += new System.EventHandler(this.cmbbxByBookingFL_SelectedIndexChanged);
            // 
            // cmbbxRoomTypeFL
            // 
            this.cmbbxRoomTypeFL.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxRoomTypeFL.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxRoomTypeFL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxRoomTypeFL.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomTypeFL.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomTypeFL.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxRoomTypeFL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxRoomTypeFL.ItemHeight = 30;
            this.cmbbxRoomTypeFL.Location = new System.Drawing.Point(179, 9);
            this.cmbbxRoomTypeFL.Name = "cmbbxRoomTypeFL";
            this.cmbbxRoomTypeFL.Size = new System.Drawing.Size(222, 36);
            this.cmbbxRoomTypeFL.TabIndex = 6;
            this.cmbbxRoomTypeFL.SelectedIndexChanged += new System.EventHandler(this.cmbbxRoomTypeFL_SelectedIndexChanged);
            // 
            // lblBookingRecordsFL
            // 
            this.lblBookingRecordsFL.AutoSize = true;
            this.lblBookingRecordsFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingRecordsFL.Location = new System.Drawing.Point(407, 20);
            this.lblBookingRecordsFL.Name = "lblBookingRecordsFL";
            this.lblBookingRecordsFL.Size = new System.Drawing.Size(111, 25);
            this.lblBookingRecordsFL.TabIndex = 5;
            this.lblBookingRecordsFL.Text = "By Booking";
            // 
            // lblByRoomTypeFL
            // 
            this.lblByRoomTypeFL.AutoSize = true;
            this.lblByRoomTypeFL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblByRoomTypeFL.Location = new System.Drawing.Point(21, 19);
            this.lblByRoomTypeFL.Name = "lblByRoomTypeFL";
            this.lblByRoomTypeFL.Size = new System.Drawing.Size(141, 25);
            this.lblByRoomTypeFL.TabIndex = 5;
            this.lblByRoomTypeFL.Text = "By Room Type";
            // 
            // btnPreviousFL
            // 
            this.btnPreviousFL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousFL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPreviousFL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPreviousFL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPreviousFL.FillColor = System.Drawing.Color.DimGray;
            this.btnPreviousFL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousFL.ForeColor = System.Drawing.Color.White;
            this.btnPreviousFL.Location = new System.Drawing.Point(2, 850);
            this.btnPreviousFL.Name = "btnPreviousFL";
            this.btnPreviousFL.Size = new System.Drawing.Size(180, 45);
            this.btnPreviousFL.TabIndex = 13;
            this.btnPreviousFL.Text = "Previous";
            this.btnPreviousFL.Click += new System.EventHandler(this.btnPreviousFL_Click);
            // 
            // btnNextFL
            // 
            this.btnNextFL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextFL.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNextFL.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNextFL.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNextFL.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNextFL.FillColor = System.Drawing.Color.DimGray;
            this.btnNextFL.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNextFL.ForeColor = System.Drawing.Color.White;
            this.btnNextFL.Location = new System.Drawing.Point(1314, 850);
            this.btnNextFL.Name = "btnNextFL";
            this.btnNextFL.Size = new System.Drawing.Size(180, 45);
            this.btnNextFL.TabIndex = 15;
            this.btnNextFL.Text = "Next";
            this.btnNextFL.Click += new System.EventHandler(this.btnNextFL_Click);
            // 
            // pnlPagesFL
            // 
            this.pnlPagesFL.Location = new System.Drawing.Point(188, 850);
            this.pnlPagesFL.Name = "pnlPagesFL";
            this.pnlPagesFL.Size = new System.Drawing.Size(1120, 45);
            this.pnlPagesFL.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(689, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(279, 42);
            this.label1.TabIndex = 18;
            this.label1.Text = "ALL BOOKING";
            // 
            // PctBackFL
            // 
            this.PctBackFL.BackColor = System.Drawing.Color.Transparent;
            this.PctBackFL.Image = ((System.Drawing.Image)(resources.GetObject("PctBackFL.Image")));
            this.PctBackFL.ImageRotate = 0F;
            this.PctBackFL.Location = new System.Drawing.Point(12, 12);
            this.PctBackFL.Name = "PctBackFL";
            this.PctBackFL.Size = new System.Drawing.Size(47, 42);
            this.PctBackFL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PctBackFL.TabIndex = 11;
            this.PctBackFL.TabStop = false;
            this.PctBackFL.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // timerRoom
            // 
            this.timerRoom.Interval = 60000;
            this.timerRoom.Tick += new System.EventHandler(this.timerRoom_Tick);
            // 
            // frmBooking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1515, 918);
            this.Controls.Add(this.PctBackFL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pnlPagesFL);
            this.Controls.Add(this.btnNextFL);
            this.Controls.Add(this.btnPreviousFL);
            this.Controls.Add(this.pnlFilter);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.grdAllBookingsFL);
            this.Name = "frmBooking";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "All Booking";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBooking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdAllBookingsFL)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctBackFL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView grdAllBookingsFL;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBoxFL;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomTypeFL;
        private System.Windows.Forms.Label lblByRoomTypeFL;
        private Guna.UI2.WinForms.Guna2Button btnPreviousFL;
        private Guna.UI2.WinForms.Guna2Button btnNextFL;
        private System.Windows.Forms.FlowLayoutPanel pnlPagesFL;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2PictureBox PctBackFL;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxByBookingFL;
        private System.Windows.Forms.Label lblBookingRecordsFL;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewButtonColumn btnCheckOut;
        private System.Windows.Forms.Timer timerRoom;
    }
}