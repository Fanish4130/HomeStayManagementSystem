using System.Windows.Forms;

namespace GSTHMS
{
    partial class frmPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPay));
            this.grdFetchData = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbbxStatus = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbbxPMode = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblPayMode = new System.Windows.Forms.Label();
            this.lblByDate = new System.Windows.Forms.Label();
            this.btnPrevoius = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.lblToDate = new System.Windows.Forms.Label();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctTodaysPayment = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlfilter = new Guna.UI2.WinForms.Guna2Panel();
            this.dptTodate = new System.Windows.Forms.DateTimePicker();
            this.dptFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblPayInfo = new System.Windows.Forms.Label();
            this.pnlPages = new Guna.UI2.WinForms.Guna2Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblIncome = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.grdFetchData)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctTodaysPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlfilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdFetchData
            // 
            this.grdFetchData.AllowUserToResizeColumns = false;
            this.grdFetchData.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.grdFetchData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdFetchData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdFetchData.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdFetchData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdFetchData.ColumnHeadersHeight = 35;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdFetchData.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdFetchData.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFetchData.Location = new System.Drawing.Point(19, 221);
            this.grdFetchData.Name = "grdFetchData";
            this.grdFetchData.RowHeadersVisible = false;
            this.grdFetchData.RowHeadersWidth = 51;
            this.grdFetchData.RowTemplate.Height = 24;
            this.grdFetchData.Size = new System.Drawing.Size(1120, 639);
            this.grdFetchData.TabIndex = 0;
            this.grdFetchData.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdFetchData.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdFetchData.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdFetchData.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdFetchData.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdFetchData.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdFetchData.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFetchData.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdFetchData.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdFetchData.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFetchData.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdFetchData.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdFetchData.ThemeStyle.HeaderStyle.Height = 35;
            this.grdFetchData.ThemeStyle.ReadOnly = false;
            this.grdFetchData.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdFetchData.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdFetchData.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdFetchData.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdFetchData.ThemeStyle.RowsStyle.Height = 24;
            this.grdFetchData.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdFetchData.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdFetchData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFetchData_CellContentClick);
            this.grdFetchData.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.grdFetchData_CellPainting);
            this.grdFetchData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFetchData_CellValueChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(3, 80);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(118, 25);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "By Status :";
            // 
            // cmbbxStatus
            // 
            this.cmbbxStatus.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbbxStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxStatus.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxStatus.ItemHeight = 30;
            this.cmbbxStatus.Location = new System.Drawing.Point(144, 80);
            this.cmbbxStatus.Name = "cmbbxStatus";
            this.cmbbxStatus.Size = new System.Drawing.Size(200, 36);
            this.cmbbxStatus.TabIndex = 2;
            this.cmbbxStatus.SelectedIndexChanged += new System.EventHandler(this.cmbbxStatus_SelectedIndexChanged);
            this.cmbbxStatus.SelectionChangeCommitted += new System.EventHandler(this.cmbbxStatus_SelectionChangeCommitted);
            this.cmbbxStatus.Click += new System.EventHandler(this.cmbbxStatus_Click);
            // 
            // cmbbxPMode
            // 
            this.cmbbxPMode.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxPMode.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbbxPMode.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxPMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxPMode.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxPMode.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxPMode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxPMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxPMode.ItemHeight = 30;
            this.cmbbxPMode.Location = new System.Drawing.Point(628, 80);
            this.cmbbxPMode.Name = "cmbbxPMode";
            this.cmbbxPMode.Size = new System.Drawing.Size(200, 36);
            this.cmbbxPMode.TabIndex = 3;
            this.cmbbxPMode.SelectedIndexChanged += new System.EventHandler(this.cmbbxPMode_SelectedIndexChanged);
            this.cmbbxPMode.SelectionChangeCommitted += new System.EventHandler(this.cmbbxPMode_SelectionChangeCommitted);
            this.cmbbxPMode.Click += new System.EventHandler(this.cmbbxPMode_Click);
            // 
            // lblPayMode
            // 
            this.lblPayMode.AutoSize = true;
            this.lblPayMode.BackColor = System.Drawing.Color.Transparent;
            this.lblPayMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayMode.Location = new System.Drawing.Point(435, 80);
            this.lblPayMode.Name = "lblPayMode";
            this.lblPayMode.Size = new System.Drawing.Size(187, 25);
            this.lblPayMode.TabIndex = 4;
            this.lblPayMode.Text = "Payment Method :";
            // 
            // lblByDate
            // 
            this.lblByDate.AutoSize = true;
            this.lblByDate.BackColor = System.Drawing.Color.Transparent;
            this.lblByDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblByDate.Location = new System.Drawing.Point(3, 27);
            this.lblByDate.Name = "lblByDate";
            this.lblByDate.Size = new System.Drawing.Size(125, 25);
            this.lblByDate.TabIndex = 5;
            this.lblByDate.Text = "From Date :";
            // 
            // btnPrevoius
            // 
            this.btnPrevoius.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevoius.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnPrevoius.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnPrevoius.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnPrevoius.FillColor = System.Drawing.Color.DimGray;
            this.btnPrevoius.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrevoius.ForeColor = System.Drawing.Color.White;
            this.btnPrevoius.Location = new System.Drawing.Point(19, 866);
            this.btnPrevoius.Name = "btnPrevoius";
            this.btnPrevoius.Size = new System.Drawing.Size(120, 35);
            this.btnPrevoius.TabIndex = 6;
            this.btnPrevoius.Text = "Prevoius";
            this.btnPrevoius.Click += new System.EventHandler(this.btnPrevoius_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.DimGray;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1019, 866);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(120, 35);
            this.btnNext.TabIndex = 8;
            this.btnNext.Text = " Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblToDate
            // 
            this.lblToDate.AutoSize = true;
            this.lblToDate.BackColor = System.Drawing.Color.Transparent;
            this.lblToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblToDate.Location = new System.Drawing.Point(435, 27);
            this.lblToDate.Name = "lblToDate";
            this.lblToDate.Size = new System.Drawing.Size(102, 25);
            this.lblToDate.TabIndex = 11;
            this.lblToDate.Text = "To Date :";
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.pctTodaysPayment);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctExcel);
            this.pnlMenuBar.Controls.Add(this.pctPDF);
            this.pnlMenuBar.CustomBorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.Location = new System.Drawing.Point(19, 79);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(689, 56);
            this.pnlMenuBar.TabIndex = 13;
            // 
            // pctTodaysPayment
            // 
            this.pctTodaysPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctTodaysPayment.BackColor = System.Drawing.Color.Transparent;
            this.pctTodaysPayment.Image = ((System.Drawing.Image)(resources.GetObject("pctTodaysPayment.Image")));
            this.pctTodaysPayment.ImageRotate = 0F;
            this.pctTodaysPayment.Location = new System.Drawing.Point(626, 5);
            this.pctTodaysPayment.Name = "pctTodaysPayment";
            this.pctTodaysPayment.Size = new System.Drawing.Size(60, 46);
            this.pctTodaysPayment.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctTodaysPayment.TabIndex = 12;
            this.pctTodaysPayment.TabStop = false;
            this.pctTodaysPayment.UseTransparentBackground = true;
            this.pctTodaysPayment.Click += new System.EventHandler(this.pctTodaysPayment_Click);
            // 
            // pctSearchBox
            // 
            this.pctSearchBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctSearchBox.BackColor = System.Drawing.Color.Transparent;
            this.pctSearchBox.Image = ((System.Drawing.Image)(resources.GetObject("pctSearchBox.Image")));
            this.pctSearchBox.ImageRotate = 0F;
            this.pctSearchBox.Location = new System.Drawing.Point(15, 3);
            this.pctSearchBox.Name = "pctSearchBox";
            this.pctSearchBox.Size = new System.Drawing.Size(42, 46);
            this.pctSearchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSearchBox.TabIndex = 4;
            this.pctSearchBox.TabStop = false;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(572, 7);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(48, 42);
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
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(301, 42);
            this.pnlSearchBox.TabIndex = 5;
            this.pnlSearchBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSearchBox_Paint);
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
            this.txtSearchBox.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(301, 42);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            this.txtSearchBox.Enter += new System.EventHandler(this.txtSearchBox_Enter);
            this.txtSearchBox.Leave += new System.EventHandler(this.txtSearchBox_Leave);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(381, 7);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(47, 42);
            this.pctRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
            this.pctExcel.Location = new System.Drawing.Point(508, 7);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(48, 42);
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
            this.pctPDF.Location = new System.Drawing.Point(444, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(48, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // pnlfilter
            // 
            this.pnlfilter.BorderColor = System.Drawing.Color.Black;
            this.pnlfilter.BorderThickness = 1;
            this.pnlfilter.Controls.Add(this.dptTodate);
            this.pnlfilter.Controls.Add(this.dptFromDate);
            this.pnlfilter.Controls.Add(this.lblByDate);
            this.pnlfilter.Controls.Add(this.lblToDate);
            this.pnlfilter.Controls.Add(this.lblStatus);
            this.pnlfilter.Controls.Add(this.cmbbxPMode);
            this.pnlfilter.Controls.Add(this.lblPayMode);
            this.pnlfilter.Controls.Add(this.cmbbxStatus);
            this.pnlfilter.Location = new System.Drawing.Point(714, 79);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(890, 136);
            this.pnlfilter.TabIndex = 14;
            this.pnlfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlfilter_Paint);
            // 
            // dptTodate
            // 
            this.dptTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptTodate.Location = new System.Drawing.Point(579, 26);
            this.dptTodate.Name = "dptTodate";
            this.dptTodate.Size = new System.Drawing.Size(263, 30);
            this.dptTodate.TabIndex = 17;
            this.dptTodate.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // dptFromDate
            // 
            this.dptFromDate.CalendarForeColor = System.Drawing.Color.White;
            this.dptFromDate.CalendarMonthBackground = System.Drawing.Color.Black;
            this.dptFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dptFromDate.Location = new System.Drawing.Point(144, 30);
            this.dptFromDate.Name = "dptFromDate";
            this.dptFromDate.Size = new System.Drawing.Size(263, 30);
            this.dptFromDate.TabIndex = 16;
            this.dptFromDate.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // lblPayInfo
            // 
            this.lblPayInfo.AutoSize = true;
            this.lblPayInfo.BackColor = System.Drawing.Color.Transparent;
            this.lblPayInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayInfo.Location = new System.Drawing.Point(724, 9);
            this.lblPayInfo.Name = "lblPayInfo";
            this.lblPayInfo.Size = new System.Drawing.Size(437, 51);
            this.lblPayInfo.TabIndex = 13;
            this.lblPayInfo.Text = "PAYMENT DETAILS";
            this.lblPayInfo.Click += new System.EventHandler(this.lblPayInfo_Click);
            // 
            // pnlPages
            // 
            this.pnlPages.Location = new System.Drawing.Point(145, 866);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(868, 44);
            this.pnlPages.TabIndex = 15;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.SystemColors.Control;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(240, 166);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(102, 29);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "lblTotal";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // lblIncome
            // 
            this.lblIncome.AutoSize = true;
            this.lblIncome.BackColor = System.Drawing.SystemColors.Control;
            this.lblIncome.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncome.Location = new System.Drawing.Point(14, 166);
            this.lblIncome.Name = "lblIncome";
            this.lblIncome.Size = new System.Drawing.Size(209, 29);
            this.lblIncome.TabIndex = 17;
            this.lblIncome.Text = "Monthly Income :";
            this.lblIncome.Click += new System.EventHandler(this.lblIncome_Click);
            // 
            // frmPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 981);
            this.Controls.Add(this.lblIncome);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.lblPayInfo);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevoius);
            this.Controls.Add(this.grdFetchData);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmPay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdFetchData)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctTodaysPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlfilter.ResumeLayout(false);
            this.pnlfilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2DataGridView grdFetchData;
        private System.Windows.Forms.Label lblStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxStatus;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxPMode;
        private Label lblPayMode;
        private Label lblByDate;
        private Guna.UI2.WinForms.Guna2Button btnPrevoius;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private Label lblToDate;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private Guna.UI2.WinForms.Guna2Panel pnlfilter;
        private Label lblPayInfo;
        private Guna.UI2.WinForms.Guna2Panel pnlPages;
        private ToolTip toolTip1;
        private DateTimePicker dptTodate;
        private DateTimePicker dptFromDate;
        private Label lblTotal;
        private Label lblIncome;
        private Guna.UI2.WinForms.Guna2PictureBox pctTodaysPayment;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

