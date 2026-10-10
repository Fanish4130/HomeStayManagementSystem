namespace GSTHMS
{
    partial class frmRoomList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRoomList));
            this.lblRoomList = new System.Windows.Forms.Label();
            this.grdRoomListShow = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.cmbbxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbbxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnRoomListPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnRoomListNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlRoomListNo = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRoomListFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.blfrmroomlist = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomListShow)).BeginInit();
            this.pnlRoomListFilter.SuspendLayout();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRoomList
            // 
            this.lblRoomList.AutoSize = true;
            this.lblRoomList.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomList.Location = new System.Drawing.Point(476, 22);
            this.lblRoomList.Name = "lblRoomList";
            this.lblRoomList.Size = new System.Drawing.Size(194, 42);
            this.lblRoomList.TabIndex = 1;
            this.lblRoomList.Text = "Room List";
            // 
            // grdRoomListShow
            // 
            this.grdRoomListShow.AllowUserToAddRows = false;
            this.grdRoomListShow.AllowUserToDeleteRows = false;
            this.grdRoomListShow.AllowUserToResizeColumns = false;
            this.grdRoomListShow.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.grdRoomListShow.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.grdRoomListShow.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdRoomListShow.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdRoomListShow.ColumnHeadersHeight = 35;
            this.grdRoomListShow.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdRoomListShow.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdRoomListShow.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdRoomListShow.Location = new System.Drawing.Point(22, 275);
            this.grdRoomListShow.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.grdRoomListShow.Name = "grdRoomListShow";
            this.grdRoomListShow.ReadOnly = true;
            this.grdRoomListShow.RowHeadersVisible = false;
            this.grdRoomListShow.RowHeadersWidth = 62;
            this.grdRoomListShow.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdRoomListShow.RowTemplate.Height = 28;
            this.grdRoomListShow.Size = new System.Drawing.Size(1120, 358);
            this.grdRoomListShow.TabIndex = 0;
            this.grdRoomListShow.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdRoomListShow.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdRoomListShow.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdRoomListShow.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdRoomListShow.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdRoomListShow.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdRoomListShow.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdRoomListShow.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdRoomListShow.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdRoomListShow.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRoomListShow.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdRoomListShow.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdRoomListShow.ThemeStyle.HeaderStyle.Height = 35;
            this.grdRoomListShow.ThemeStyle.ReadOnly = true;
            this.grdRoomListShow.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdRoomListShow.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdRoomListShow.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdRoomListShow.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdRoomListShow.ThemeStyle.RowsStyle.Height = 28;
            this.grdRoomListShow.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdRoomListShow.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdRoomListShow.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRoomListShow_CellContentClick);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 8;
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(364, 16);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 25);
            this.lblStatus.TabIndex = 3;
            this.lblStatus.Text = "Status";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(18, 16);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(122, 25);
            this.lblRoomType.TabIndex = 4;
            this.lblRoomType.Text = "Room Type";
            // 
            // cmbbxRoomType
            // 
            this.cmbbxRoomType.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxRoomType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxRoomType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxRoomType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxRoomType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxRoomType.ItemHeight = 30;
            this.cmbbxRoomType.Items.AddRange(new object[] {
            "Single",
            "Family",
            "Standard",
            "Hall"});
            this.cmbbxRoomType.Location = new System.Drawing.Point(159, 5);
            this.cmbbxRoomType.Margin = new System.Windows.Forms.Padding(2);
            this.cmbbxRoomType.Name = "cmbbxRoomType";
            this.cmbbxRoomType.Size = new System.Drawing.Size(200, 36);
            this.cmbbxRoomType.TabIndex = 5;
            this.cmbbxRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbbxRoomType_SelectedIndexChanged);
            this.cmbbxRoomType.SelectionChangeCommitted += new System.EventHandler(this.cmbbxRoomType_SelectionChangeCommitted);
            this.cmbbxRoomType.Click += new System.EventHandler(this.cmbbxRoomType_Click);
            // 
            // cmbbxStatus
            // 
            this.cmbbxStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxStatus.ItemHeight = 30;
            this.cmbbxStatus.Location = new System.Drawing.Point(443, 5);
            this.cmbbxStatus.Margin = new System.Windows.Forms.Padding(2);
            this.cmbbxStatus.Name = "cmbbxStatus";
            this.cmbbxStatus.Size = new System.Drawing.Size(200, 36);
            this.cmbbxStatus.TabIndex = 6;
            this.cmbbxStatus.SelectedIndexChanged += new System.EventHandler(this.cmbbxStatus_SelectedIndexChanged);
            this.cmbbxStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbbxStatus_SelectionChangeCommitted);
            this.cmbbxStatus.Click += new System.EventHandler(this.cmbbxStatus_Click);
            // 
            // btnRoomListPrevious
            // 
            this.btnRoomListPrevious.BorderColor = System.Drawing.Color.Orange;
            this.btnRoomListPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRoomListPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRoomListPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRoomListPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRoomListPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btnRoomListPrevious.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomListPrevious.ForeColor = System.Drawing.Color.White;
            this.btnRoomListPrevious.Location = new System.Drawing.Point(19, 658);
            this.btnRoomListPrevious.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoomListPrevious.Name = "btnRoomListPrevious";
            this.btnRoomListPrevious.Size = new System.Drawing.Size(140, 45);
            this.btnRoomListPrevious.TabIndex = 8;
            this.btnRoomListPrevious.Text = "Previous";
            this.btnRoomListPrevious.Click += new System.EventHandler(this.btnRoomListPrevious_Click);
            // 
            // btnRoomListNext
            // 
            this.btnRoomListNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRoomListNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRoomListNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRoomListNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRoomListNext.FillColor = System.Drawing.Color.DimGray;
            this.btnRoomListNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRoomListNext.ForeColor = System.Drawing.Color.White;
            this.btnRoomListNext.Location = new System.Drawing.Point(996, 658);
            this.btnRoomListNext.Margin = new System.Windows.Forms.Padding(2);
            this.btnRoomListNext.Name = "btnRoomListNext";
            this.btnRoomListNext.Size = new System.Drawing.Size(140, 45);
            this.btnRoomListNext.TabIndex = 9;
            this.btnRoomListNext.Text = "Next";
            this.btnRoomListNext.Click += new System.EventHandler(this.btnRoomListNext_Click);
            // 
            // pnlRoomListNo
            // 
            this.pnlRoomListNo.BackColor = System.Drawing.Color.Transparent;
            this.pnlRoomListNo.Location = new System.Drawing.Point(189, 658);
            this.pnlRoomListNo.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRoomListNo.Name = "pnlRoomListNo";
            this.pnlRoomListNo.Size = new System.Drawing.Size(775, 45);
            this.pnlRoomListNo.TabIndex = 10;
            // 
            // pnlRoomListFilter
            // 
            this.pnlRoomListFilter.BorderColor = System.Drawing.Color.Black;
            this.pnlRoomListFilter.BorderThickness = 1;
            this.pnlRoomListFilter.Controls.Add(this.lblStatus);
            this.pnlRoomListFilter.Controls.Add(this.lblRoomType);
            this.pnlRoomListFilter.Controls.Add(this.cmbbxRoomType);
            this.pnlRoomListFilter.Controls.Add(this.cmbbxStatus);
            this.pnlRoomListFilter.Location = new System.Drawing.Point(712, 100);
            this.pnlRoomListFilter.Margin = new System.Windows.Forms.Padding(2);
            this.pnlRoomListFilter.Name = "pnlRoomListFilter";
            this.pnlRoomListFilter.Size = new System.Drawing.Size(661, 50);
            this.pnlRoomListFilter.TabIndex = 15;
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
            this.pnlMenuBar.Location = new System.Drawing.Point(19, 97);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(677, 56);
            this.pnlMenuBar.TabIndex = 14;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(604, 7);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(47, 42);
            this.pctFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFilter.TabIndex = 10;
            this.pctFilter.TabStop = false;
            this.pctFilter.Click += new System.EventHandler(this.pctFilter_Click_1);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearchBox.Controls.Add(this.txtSearchBox);
            this.pnlSearchBox.Location = new System.Drawing.Point(63, 7);
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
            this.pctRefresh.Location = new System.Drawing.Point(391, 7);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(47, 42);
            this.pctRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctRefresh.TabIndex = 8;
            this.pctRefresh.TabStop = false;
            this.pctRefresh.Click += new System.EventHandler(this.pctRefresh_Click_1);
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
            this.pctExcel.Location = new System.Drawing.Point(530, 3);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(57, 50);
            this.pctExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pctExcel.TabIndex = 6;
            this.pctExcel.TabStop = false;
            this.pctExcel.Click += new System.EventHandler(this.pctExcel_Click_1);
            // 
            // pctPDF
            // 
            this.pctPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctPDF.BackColor = System.Drawing.Color.Transparent;
            this.pctPDF.Image = ((System.Drawing.Image)(resources.GetObject("pctPDF.Image")));
            this.pctPDF.ImageRotate = 0F;
            this.pctPDF.Location = new System.Drawing.Point(458, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click_1);
            // 
            // blfrmroomlist
            // 
            this.blfrmroomlist.BorderRadius = 2;
            this.blfrmroomlist.ContainerControl = this;
            this.blfrmroomlist.DockIndicatorTransparencyValue = 0.6D;
            this.blfrmroomlist.TransparentWhileDrag = true;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(58, 52);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 17;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // frmRoomList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1169, 738);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.pnlRoomListFilter);
            this.Controls.Add(this.pnlRoomListNo);
            this.Controls.Add(this.btnRoomListNext);
            this.Controls.Add(this.btnRoomListPrevious);
            this.Controls.Add(this.grdRoomListShow);
            this.Controls.Add(this.lblRoomList);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRoomList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRoomList";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRoomList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdRoomListShow)).EndInit();
            this.pnlRoomListFilter.ResumeLayout(false);
            this.pnlRoomListFilter.PerformLayout();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRoomList;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRoomType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxStatus;
        private Guna.UI2.WinForms.Guna2Button btnRoomListPrevious;
        private Guna.UI2.WinForms.Guna2Button btnRoomListNext;
        private Guna.UI2.WinForms.Guna2Panel pnlRoomListNo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        public Guna.UI2.WinForms.Guna2DataGridView grdRoomListShow;
        private Guna.UI2.WinForms.Guna2Panel pnlRoomListFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2BorderlessForm blfrmroomlist;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}