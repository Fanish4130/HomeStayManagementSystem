namespace GSTHMS
{
    partial class frmcardsinfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmcardsinfo));
            this.grdCardInfoShow = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblInfo = new System.Windows.Forms.Label();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlCapacity = new Guna.UI2.WinForms.Guna2Panel();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.cmbbxCapacity = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlRoomName = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.cmbbxRoomName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnCardsInfoNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlCardInfoNo = new Guna.UI2.WinForms.Guna2Panel();
            this.btnCardsInfoPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.pnlRoomType = new Guna.UI2.WinForms.Guna2Panel();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cmbbxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.pnlStatus = new Guna.UI2.WinForms.Guna2Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbbxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdCardInfoShow)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlCapacity.SuspendLayout();
            this.pnlRoomName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.pnlRoomType.SuspendLayout();
            this.pnlStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdCardInfoShow
            // 
            this.grdCardInfoShow.AllowUserToAddRows = false;
            this.grdCardInfoShow.AllowUserToDeleteRows = false;
            this.grdCardInfoShow.AllowUserToResizeColumns = false;
            this.grdCardInfoShow.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.grdCardInfoShow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdCardInfoShow.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdCardInfoShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdCardInfoShow.ColumnHeadersHeight = 35;
            this.grdCardInfoShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdCardInfoShow.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdCardInfoShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdCardInfoShow.Location = new System.Drawing.Point(89, 288);
            this.grdCardInfoShow.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdCardInfoShow.Name = "grdCardInfoShow";
            this.grdCardInfoShow.ReadOnly = true;
            this.grdCardInfoShow.RowHeadersVisible = false;
            this.grdCardInfoShow.RowHeadersWidth = 62;
            this.grdCardInfoShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdCardInfoShow.RowTemplate.Height = 28;
            this.grdCardInfoShow.Size = new System.Drawing.Size(1120, 463);
            this.grdCardInfoShow.TabIndex = 0;
            this.grdCardInfoShow.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdCardInfoShow.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdCardInfoShow.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdCardInfoShow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdCardInfoShow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdCardInfoShow.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdCardInfoShow.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdCardInfoShow.ThemeStyle.HeaderStyle.Height = 35;
            this.grdCardInfoShow.ThemeStyle.ReadOnly = true;
            this.grdCardInfoShow.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdCardInfoShow.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdCardInfoShow.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdCardInfoShow.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdCardInfoShow.ThemeStyle.RowsStyle.Height = 28;
            this.grdCardInfoShow.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdCardInfoShow.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdCardInfoShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdCardInfoShow_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 8;
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.lblInfo.Location = new System.Drawing.Point(603, 9);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(124, 42);
            this.lblInfo.TabIndex = 1;
            this.lblInfo.Text = "label1";
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
            this.pnlMenuBar.Location = new System.Drawing.Point(51, 107);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(676, 56);
            this.pnlMenuBar.TabIndex = 13;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(610, 7);
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
            this.pnlSearchBox.Controls.Add(this.txtSearchBox);
            this.pnlSearchBox.Location = new System.Drawing.Point(65, 7);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(301, 42);
            this.pnlSearchBox.TabIndex = 5;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchBox.BorderColor = System.Drawing.Color.WhiteSmoke;
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
            this.txtSearchBox.PlaceholderText = "Search Here";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(295, 35);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged_1);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(384, 7);
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
            this.pctSearchBox.Location = new System.Drawing.Point(3, 7);
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
            this.pctExcel.Location = new System.Drawing.Point(533, 3);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(57, 50);
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
            this.pctPDF.Location = new System.Drawing.Point(456, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // pnlCapacity
            // 
            this.pnlCapacity.BackColor = System.Drawing.Color.Transparent;
            this.pnlCapacity.BorderColor = System.Drawing.Color.Black;
            this.pnlCapacity.BorderThickness = 1;
            this.pnlCapacity.Controls.Add(this.lblCapacity);
            this.pnlCapacity.Controls.Add(this.cmbbxCapacity);
            this.pnlCapacity.Location = new System.Drawing.Point(100, 200);
            this.pnlCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCapacity.Name = "pnlCapacity";
            this.pnlCapacity.Size = new System.Drawing.Size(317, 67);
            this.pnlCapacity.TabIndex = 12;
            this.pnlCapacity.UseWaitCursor = true;
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCapacity.ForeColor = System.Drawing.Color.Black;
            this.lblCapacity.Location = new System.Drawing.Point(0, 17);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(97, 25);
            this.lblCapacity.TabIndex = 14;
            this.lblCapacity.Text = "Capacity";
            this.lblCapacity.UseWaitCursor = true;
            // 
            // cmbbxCapacity
            // 
            this.cmbbxCapacity.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxCapacity.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxCapacity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxCapacity.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxCapacity.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxCapacity.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbbxCapacity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxCapacity.ItemHeight = 30;
            this.cmbbxCapacity.Items.AddRange(new object[] {
            "select capacity"});
            this.cmbbxCapacity.Location = new System.Drawing.Point(115, 10);
            this.cmbbxCapacity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbxCapacity.Name = "cmbbxCapacity";
            this.cmbbxCapacity.Size = new System.Drawing.Size(189, 36);
            this.cmbbxCapacity.TabIndex = 0;
            this.cmbbxCapacity.UseWaitCursor = true;
            this.cmbbxCapacity.SelectionChangeCommitted += new System.EventHandler(this.cmbbxCapacity_SelectionChangeCommitted);
            this.cmbbxCapacity.Click += new System.EventHandler(this.cmbbxCapacity_Click);
            // 
            // pnlRoomName
            // 
            this.pnlRoomName.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoomName.BorderColor = System.Drawing.Color.Black;
            this.pnlRoomName.BorderThickness = 1;
            this.pnlRoomName.Controls.Add(this.lblRoomName);
            this.pnlRoomName.Controls.Add(this.cmbbxRoomName);
            this.pnlRoomName.Location = new System.Drawing.Point(487, 206);
            this.pnlRoomName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRoomName.Name = "pnlRoomName";
            this.pnlRoomName.Size = new System.Drawing.Size(344, 61);
            this.pnlRoomName.TabIndex = 15;
            this.pnlRoomName.UseWaitCursor = true;
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(1, 15);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(129, 25);
            this.lblRoomName.TabIndex = 14;
            this.lblRoomName.Text = "Room Name";
            this.lblRoomName.UseWaitCursor = true;
            // 
            // cmbbxRoomName
            // 
            this.cmbbxRoomName.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxRoomName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxRoomName.DropDownHeight = 150;
            this.cmbbxRoomName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxRoomName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxRoomName.IntegralHeight = false;
            this.cmbbxRoomName.ItemHeight = 30;
            this.cmbbxRoomName.Location = new System.Drawing.Point(149, 11);
            this.cmbbxRoomName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbxRoomName.MaxDropDownItems = 5;
            this.cmbbxRoomName.Name = "cmbbxRoomName";
            this.cmbbxRoomName.Size = new System.Drawing.Size(190, 36);
            this.cmbbxRoomName.TabIndex = 0;
            this.cmbbxRoomName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cmbbxRoomName.TextOffset = new System.Drawing.Point(2, 2);
            this.cmbbxRoomName.UseWaitCursor = true;
            this.cmbbxRoomName.SelectionChangeCommitted += new System.EventHandler(this.cmbbxRoomName_SelectionChangeCommitted);
            this.cmbbxRoomName.Click += new System.EventHandler(this.cmbbxRoomName_Click);
            // 
            // btnCardsInfoNext
            // 
            this.btnCardsInfoNext.BorderColor = System.Drawing.Color.Orange;
            this.btnCardsInfoNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCardsInfoNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCardsInfoNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCardsInfoNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCardsInfoNext.FillColor = System.Drawing.Color.DimGray;
            this.btnCardsInfoNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsInfoNext.ForeColor = System.Drawing.Color.White;
            this.btnCardsInfoNext.Location = new System.Drawing.Point(1094, 777);
            this.btnCardsInfoNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCardsInfoNext.Name = "btnCardsInfoNext";
            this.btnCardsInfoNext.Size = new System.Drawing.Size(140, 45);
            this.btnCardsInfoNext.TabIndex = 12;
            this.btnCardsInfoNext.Text = "Next";
            this.btnCardsInfoNext.UseWaitCursor = true;
            this.btnCardsInfoNext.Click += new System.EventHandler(this.btnCardsInfoNext_Click);
            // 
            // pnlCardInfoNo
            // 
            this.pnlCardInfoNo.BackColor = System.Drawing.Color.Transparent;
            this.pnlCardInfoNo.Location = new System.Drawing.Point(244, 777);
            this.pnlCardInfoNo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlCardInfoNo.Name = "pnlCardInfoNo";
            this.pnlCardInfoNo.Size = new System.Drawing.Size(828, 45);
            this.pnlCardInfoNo.TabIndex = 11;
            this.pnlCardInfoNo.UseWaitCursor = true;
            // 
            // btnCardsInfoPrevious
            // 
            this.btnCardsInfoPrevious.BackColor = System.Drawing.SystemColors.Control;
            this.btnCardsInfoPrevious.BorderColor = System.Drawing.Color.Orange;
            this.btnCardsInfoPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCardsInfoPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCardsInfoPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCardsInfoPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCardsInfoPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btnCardsInfoPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsInfoPrevious.ForeColor = System.Drawing.Color.White;
            this.btnCardsInfoPrevious.Location = new System.Drawing.Point(86, 777);
            this.btnCardsInfoPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCardsInfoPrevious.Name = "btnCardsInfoPrevious";
            this.btnCardsInfoPrevious.Size = new System.Drawing.Size(140, 45);
            this.btnCardsInfoPrevious.TabIndex = 9;
            this.btnCardsInfoPrevious.Text = "Previous";
            this.btnCardsInfoPrevious.UseWaitCursor = true;
            this.btnCardsInfoPrevious.Click += new System.EventHandler(this.btnCardsInfoPrevious_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(9, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(58, 52);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 16;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // pnlRoomType
            // 
            this.pnlRoomType.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoomType.BorderColor = System.Drawing.Color.Black;
            this.pnlRoomType.BorderThickness = 1;
            this.pnlRoomType.Controls.Add(this.lblRoomType);
            this.pnlRoomType.Controls.Add(this.cmbbxRoomType);
            this.pnlRoomType.Location = new System.Drawing.Point(487, 204);
            this.pnlRoomType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRoomType.Name = "pnlRoomType";
            this.pnlRoomType.Size = new System.Drawing.Size(348, 67);
            this.pnlRoomType.TabIndex = 15;
            this.pnlRoomType.UseWaitCursor = true;
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.ForeColor = System.Drawing.Color.Black;
            this.lblRoomType.Location = new System.Drawing.Point(3, 17);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(122, 25);
            this.lblRoomType.TabIndex = 14;
            this.lblRoomType.Text = "Room Type";
            this.lblRoomType.UseWaitCursor = true;
            // 
            // cmbbxRoomType
            // 
            this.cmbbxRoomType.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxRoomType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbbxRoomType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxRoomType.ItemHeight = 30;
            this.cmbbxRoomType.Items.AddRange(new object[] {
            "select capacity"});
            this.cmbbxRoomType.Location = new System.Drawing.Point(138, 10);
            this.cmbbxRoomType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbxRoomType.Name = "cmbbxRoomType";
            this.cmbbxRoomType.Size = new System.Drawing.Size(200, 36);
            this.cmbbxRoomType.TabIndex = 0;
            this.cmbbxRoomType.UseWaitCursor = true;
            this.cmbbxRoomType.SelectionChangeCommitted += new System.EventHandler(this.cmbbxRoomType_SelectionChangeCommitted);
            this.cmbbxRoomType.Click += new System.EventHandler(this.cmbbxRoomType_Click);
            // 
            // pnlStatus
            // 
            this.pnlStatus.BackColor = System.Drawing.Color.Transparent;
            this.pnlStatus.BorderColor = System.Drawing.Color.Black;
            this.pnlStatus.BorderThickness = 1;
            this.pnlStatus.Controls.Add(this.lblStatus);
            this.pnlStatus.Controls.Add(this.cmbbxStatus);
            this.pnlStatus.Location = new System.Drawing.Point(888, 206);
            this.pnlStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlStatus.Name = "pnlStatus";
            this.pnlStatus.Size = new System.Drawing.Size(304, 65);
            this.pnlStatus.TabIndex = 16;
            this.pnlStatus.UseWaitCursor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Black;
            this.lblStatus.Location = new System.Drawing.Point(3, 18);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 25);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Status";
            this.lblStatus.UseWaitCursor = true;
            // 
            // cmbbxStatus
            // 
            this.cmbbxStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbbxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxStatus.ItemHeight = 30;
            this.cmbbxStatus.Items.AddRange(new object[] {
            "select capacity"});
            this.cmbbxStatus.Location = new System.Drawing.Point(92, 7);
            this.cmbbxStatus.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbxStatus.Name = "cmbbxStatus";
            this.cmbbxStatus.Size = new System.Drawing.Size(200, 36);
            this.cmbbxStatus.TabIndex = 0;
            this.cmbbxStatus.UseWaitCursor = true;
            this.cmbbxStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbbxStatus_SelectionChangeCommitted);
            this.cmbbxStatus.Click += new System.EventHandler(this.cmbbxStatus_Click);
            // 
            // frmcardsinfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1330, 848);
            this.Controls.Add(this.pnlStatus);
            this.Controls.Add(this.pnlRoomType);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.btnCardsInfoNext);
            this.Controls.Add(this.pnlCapacity);
            this.Controls.Add(this.pnlCardInfoNo);
            this.Controls.Add(this.btnCardsInfoPrevious);
            this.Controls.Add(this.pnlRoomName);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.grdCardInfoShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmcardsinfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmcardsinfo";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmcardsinfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCardInfoShow)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlCapacity.ResumeLayout(false);
            this.pnlCapacity.PerformLayout();
            this.pnlRoomName.ResumeLayout(false);
            this.pnlRoomName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.pnlRoomType.ResumeLayout(false);
            this.pnlRoomType.PerformLayout();
            this.pnlStatus.ResumeLayout(false);
            this.pnlStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        public Guna.UI2.WinForms.Guna2DataGridView grdCardInfoShow;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2Panel pnlCapacity;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxCapacity;
        private System.Windows.Forms.Label lblCapacity;
        private Guna.UI2.WinForms.Guna2Panel pnlRoomName;
        private System.Windows.Forms.Label lblRoomName;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomName;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2Button btnCardsInfoNext;
        private Guna.UI2.WinForms.Guna2Panel pnlCardInfoNo;
        private Guna.UI2.WinForms.Guna2Button btnCardsInfoPrevious;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2Panel pnlRoomType;
        private System.Windows.Forms.Label lblRoomType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomType;
        private Guna.UI2.WinForms.Guna2Panel pnlStatus;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxStatus;
    }
}