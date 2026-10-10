namespace GSTHMS
{
    partial class frmFoodService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFoodService));
            this.lblMenuName = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.cmbbxMenuName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblService = new System.Windows.Forms.Label();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.grdFoodService = new Guna.UI2.WinForms.Guna2DataGridView();
            this.check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlPages = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewFoodServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provideFoodServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlService = new Guna.UI2.WinForms.Guna2Panel();
            ((System.ComponentModel.ISupportInitialize)(this.grdFoodService)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            this.pnlFilter.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.pnlService.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblMenuName
            // 
            this.lblMenuName.AutoSize = true;
            this.lblMenuName.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuName.Location = new System.Drawing.Point(20, 10);
            this.lblMenuName.Name = "lblMenuName";
            this.lblMenuName.Size = new System.Drawing.Size(128, 25);
            this.lblMenuName.TabIndex = 2;
            this.lblMenuName.Text = "Menu Type:";
            this.lblMenuName.Click += new System.EventHandler(this.lblMenuName_Click);
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(726, 134);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(0, 25);
            this.lblQty.TabIndex = 3;
            this.lblQty.Click += new System.EventHandler(this.label2_Click);
            // 
            // cmbbxMenuName
            // 
            this.cmbbxMenuName.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxMenuName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxMenuName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxMenuName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxMenuName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxMenuName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxMenuName.ForeColor = System.Drawing.Color.Black;
            this.cmbbxMenuName.ItemHeight = 30;
            this.cmbbxMenuName.Location = new System.Drawing.Point(158, 4);
            this.cmbbxMenuName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbbxMenuName.Name = "cmbbxMenuName";
            this.cmbbxMenuName.Size = new System.Drawing.Size(176, 36);
            this.cmbbxMenuName.TabIndex = 5;
            this.cmbbxMenuName.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.cmbbxMenuName_DrawItem);
            this.cmbbxMenuName.SelectedIndexChanged += new System.EventHandler(this.cmbbxMenuName_SelectedIndexChanged);
            // 
            // lblService
            // 
            this.lblService.AutoSize = true;
            this.lblService.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblService.Location = new System.Drawing.Point(454, 14);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(186, 31);
            this.lblService.TabIndex = 7;
            this.lblService.Text = "Food Service";
            this.lblService.Click += new System.EventHandler(this.lblService_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btnPrevious.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.ForeColor = System.Drawing.Color.White;
            this.btnPrevious.Location = new System.Drawing.Point(22, 607);
            this.btnPrevious.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(133, 48);
            this.btnPrevious.TabIndex = 11;
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
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(975, 607);
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 48);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // grdFoodService
            // 
            this.grdFoodService.AllowUserToAddRows = false;
            this.grdFoodService.AllowUserToDeleteRows = false;
            this.grdFoodService.AllowUserToResizeColumns = false;
            this.grdFoodService.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.grdFoodService.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdFoodService.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFoodService.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFoodService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdFoodService.ColumnHeadersHeight = 35;
            this.grdFoodService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFoodService.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdFoodService.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFoodService.Location = new System.Drawing.Point(13, 125);
            this.grdFoodService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdFoodService.Name = "grdFoodService";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFoodService.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grdFoodService.RowHeadersVisible = false;
            this.grdFoodService.RowHeadersWidth = 62;
            this.grdFoodService.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdFoodService.RowTemplate.Height = 28;
            this.grdFoodService.Size = new System.Drawing.Size(1087, 459);
            this.grdFoodService.TabIndex = 0;
            this.grdFoodService.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdFoodService.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdFoodService.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdFoodService.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdFoodService.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdFoodService.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdFoodService.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFoodService.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdFoodService.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdFoodService.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFoodService.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdFoodService.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdFoodService.ThemeStyle.HeaderStyle.Height = 35;
            this.grdFoodService.ThemeStyle.ReadOnly = false;
            this.grdFoodService.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdFoodService.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdFoodService.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFoodService.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdFoodService.ThemeStyle.RowsStyle.Height = 28;
            this.grdFoodService.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFoodService.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdFoodService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.guna2DataGridView1_CellContentClick_1);
            // 
            // check
            // 
            this.check.HeaderText = "";
            this.check.MinimumWidth = 8;
            this.check.Name = "check";
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pctPDF);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctExcel);
            this.pnlMenuBar.Location = new System.Drawing.Point(11, 54);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(630, 55);
            this.pnlMenuBar.TabIndex = 19;
            this.pnlMenuBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMenuBar_Paint);
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(571, 7);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(47, 38);
            this.pctFilter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctFilter.TabIndex = 24;
            this.pctFilter.TabStop = false;
            this.pctFilter.Click += new System.EventHandler(this.pctFilter_Click_1);
            // 
            // pctPDF
            // 
            this.pctPDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctPDF.BackColor = System.Drawing.Color.Transparent;
            this.pctPDF.Image = ((System.Drawing.Image)(resources.GetObject("pctPDF.Image")));
            this.pctPDF.ImageRotate = 0F;
            this.pctPDF.Location = new System.Drawing.Point(450, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 23;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click_1);
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlSearchBox.BorderColor = System.Drawing.Color.Black;
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
            this.txtSearchBox.BorderThickness = 0;
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
            this.txtSearchBox.PlaceholderText = "Search Here...";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(296, 35);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctSearchBox
            // 
            this.pctSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSearchBox.BackColor = System.Drawing.Color.Transparent;
            this.pctSearchBox.Image = ((System.Drawing.Image)(resources.GetObject("pctSearchBox.Image")));
            this.pctSearchBox.ImageRotate = 0F;
            this.pctSearchBox.Location = new System.Drawing.Point(11, 7);
            this.pctSearchBox.Name = "pctSearchBox";
            this.pctSearchBox.Size = new System.Drawing.Size(47, 42);
            this.pctSearchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSearchBox.TabIndex = 4;
            this.pctSearchBox.TabStop = false;
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(397, 7);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(47, 42);
            this.pctRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctRefresh.TabIndex = 8;
            this.pctRefresh.TabStop = false;
            this.pctRefresh.Click += new System.EventHandler(this.pctRefresh_Click);
            // 
            // pctExcel
            // 
            this.pctExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctExcel.BackColor = System.Drawing.Color.Transparent;
            this.pctExcel.Image = ((System.Drawing.Image)(resources.GetObject("pctExcel.Image")));
            this.pctExcel.ImageRotate = 0F;
            this.pctExcel.Location = new System.Drawing.Point(517, 7);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(48, 42);
            this.pctExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExcel.TabIndex = 6;
            this.pctExcel.TabStop = false;
            this.pctExcel.Click += new System.EventHandler(this.pctExcel_Click_1);
            // 
            // pnlFilter
            // 
            this.pnlFilter.BorderColor = System.Drawing.Color.Black;
            this.pnlFilter.BorderThickness = 1;
            this.pnlFilter.Controls.Add(this.cmbbxMenuName);
            this.pnlFilter.Controls.Add(this.lblMenuName);
            this.pnlFilter.Location = new System.Drawing.Point(659, 54);
            this.pnlFilter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(346, 49);
            this.pnlFilter.TabIndex = 20;
            this.pnlFilter.Visible = false;
            this.pnlFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlFilter_Paint);
            // 
            // pnlPages
            // 
            this.pnlPages.Location = new System.Drawing.Point(175, 607);
            this.pnlPages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(761, 48);
            this.pnlPages.TabIndex = 21;
            this.pnlPages.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewFoodServiceToolStripMenuItem,
            this.provideFoodServiceToolStripMenuItem,
            this.parkingServiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1111, 36);
            this.menuStrip1.TabIndex = 22;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked_1);
            // 
            // viewFoodServiceToolStripMenuItem
            // 
            this.viewFoodServiceToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.viewFoodServiceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewFoodServiceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.viewFoodServiceToolStripMenuItem.Name = "viewFoodServiceToolStripMenuItem";
            this.viewFoodServiceToolStripMenuItem.Size = new System.Drawing.Size(196, 32);
            this.viewFoodServiceToolStripMenuItem.Text = "View Food Details";
            this.viewFoodServiceToolStripMenuItem.Click += new System.EventHandler(this.viewFoodServiceToolStripMenuItem_Click);
            // 
            // provideFoodServiceToolStripMenuItem
            // 
            this.provideFoodServiceToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.provideFoodServiceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.provideFoodServiceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.provideFoodServiceToolStripMenuItem.Name = "provideFoodServiceToolStripMenuItem";
            this.provideFoodServiceToolStripMenuItem.Size = new System.Drawing.Size(225, 32);
            this.provideFoodServiceToolStripMenuItem.Text = "Provide Food Service";
            this.provideFoodServiceToolStripMenuItem.Click += new System.EventHandler(this.provideFoodServiceToolStripMenuItem_Click);
            // 
            // parkingServiceToolStripMenuItem
            // 
            this.parkingServiceToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.parkingServiceToolStripMenuItem.CheckOnClick = true;
            this.parkingServiceToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parkingServiceToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.parkingServiceToolStripMenuItem.Name = "parkingServiceToolStripMenuItem";
            this.parkingServiceToolStripMenuItem.Size = new System.Drawing.Size(170, 32);
            this.parkingServiceToolStripMenuItem.Text = "Parking Details";
            this.parkingServiceToolStripMenuItem.Click += new System.EventHandler(this.parkingServiceToolStripMenuItem_Click);
            // 
            // pnlService
            // 
            this.pnlService.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlService.BackColor = System.Drawing.Color.Transparent;
            this.pnlService.Controls.Add(this.grdFoodService);
            this.pnlService.Controls.Add(this.btnPrevious);
            this.pnlService.Controls.Add(this.pnlPages);
            this.pnlService.Controls.Add(this.lblService);
            this.pnlService.Controls.Add(this.btnNext);
            this.pnlService.Controls.Add(this.pnlFilter);
            this.pnlService.Controls.Add(this.pnlMenuBar);
            this.pnlService.Location = new System.Drawing.Point(0, 34);
            this.pnlService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlService.Name = "pnlService";
            this.pnlService.Size = new System.Drawing.Size(1111, 698);
            this.pnlService.TabIndex = 23;
            this.pnlService.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlService_Paint);
            // 
            // frmFoodService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1111, 742);
            this.Controls.Add(this.pnlService);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmFoodService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFoodService)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            this.pnlFilter.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlService.ResumeLayout(false);
            this.pnlService.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblMenuName;
        private System.Windows.Forms.Label lblQty;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxMenuName;
        private System.Windows.Forms.Label lblService;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Guna.UI2.WinForms.Guna2DataGridView grdFoodService;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2Panel pnlFilter;
        private System.Windows.Forms.FlowLayoutPanel pnlPages;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem provideFoodServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parkingServiceToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Panel pnlService;
        private System.Windows.Forms.ToolStripMenuItem viewFoodServiceToolStripMenuItem;
    }
}

