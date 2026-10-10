namespace GSTHMS
{
    partial class frmOffersDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOffersDetails));
            this.grdOffers = new Guna.UI2.WinForms.Guna2DataGridView();
            this.lbltotaloffer = new System.Windows.Forms.Label();
            this.lblTotalOffer1 = new System.Windows.Forms.Label();
            this.lblActiveoffers = new System.Windows.Forms.Label();
            this.lblActiveOffer1 = new System.Windows.Forms.Label();
            this.lblExpireOffers = new System.Windows.Forms.Label();
            this.lblupcomingoffers = new System.Windows.Forms.Label();
            this.lblInActiveoffers = new System.Windows.Forms.Label();
            this.lblInActiveOffers1 = new System.Windows.Forms.Label();
            this.dtpOfferfromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpOffertoDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblAllOffers = new System.Windows.Forms.Label();
            this.pnlMenuBar = new Guna.UI2.WinForms.Guna2Panel();
            this.pctFilter = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panelDataFilter = new Guna.UI2.WinForms.Guna2Panel();
            this.btmPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPage = new System.Windows.Forms.FlowLayoutPanel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cpnlTotaloffers = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cpnlActiveOffers = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cpnlExpiredOffers = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.cpnlinactiveoffers = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.grdOffers)).BeginInit();
            this.pnlMenuBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            this.panelDataFilter.SuspendLayout();
            this.cpnlTotaloffers.SuspendLayout();
            this.cpnlActiveOffers.SuspendLayout();
            this.cpnlExpiredOffers.SuspendLayout();
            this.cpnlinactiveoffers.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdOffers
            // 
            this.grdOffers.AllowUserToAddRows = false;
            this.grdOffers.AllowUserToDeleteRows = false;
            this.grdOffers.AllowUserToResizeColumns = false;
            this.grdOffers.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.grdOffers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.grdOffers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOffers.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOffers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdOffers.ColumnHeadersHeight = 30;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdOffers.DefaultCellStyle = dataGridViewCellStyle11;
            this.grdOffers.GridColor = System.Drawing.Color.Black;
            this.grdOffers.Location = new System.Drawing.Point(21, 369);
            this.grdOffers.Margin = new System.Windows.Forms.Padding(4);
            this.grdOffers.Name = "grdOffers";
            this.grdOffers.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdOffers.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.grdOffers.RowHeadersVisible = false;
            this.grdOffers.RowHeadersWidth = 35;
            this.grdOffers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdOffers.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.grdOffers.Size = new System.Drawing.Size(1820, 457);
            this.grdOffers.TabIndex = 0;
            this.grdOffers.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdOffers.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdOffers.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdOffers.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdOffers.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdOffers.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdOffers.ThemeStyle.GridColor = System.Drawing.Color.Black;
            this.grdOffers.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdOffers.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdOffers.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOffers.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdOffers.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdOffers.ThemeStyle.HeaderStyle.Height = 30;
            this.grdOffers.ThemeStyle.ReadOnly = true;
            this.grdOffers.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdOffers.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdOffers.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdOffers.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdOffers.ThemeStyle.RowsStyle.Height = 22;
            this.grdOffers.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdOffers.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdOffers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdOffers_CellContentClick);
            // 
            // lbltotaloffer
            // 
            this.lbltotaloffer.AutoSize = true;
            this.lbltotaloffer.BackColor = System.Drawing.Color.Transparent;
            this.lbltotaloffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotaloffer.Location = new System.Drawing.Point(121, 71);
            this.lbltotaloffer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotaloffer.Name = "lbltotaloffer";
            this.lbltotaloffer.Size = new System.Drawing.Size(39, 29);
            this.lbltotaloffer.TabIndex = 1;
            this.lbltotaloffer.Text = "00";
            // 
            // lblTotalOffer1
            // 
            this.lblTotalOffer1.AutoSize = true;
            this.lblTotalOffer1.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalOffer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalOffer1.Location = new System.Drawing.Point(57, 22);
            this.lblTotalOffer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalOffer1.Name = "lblTotalOffer1";
            this.lblTotalOffer1.Size = new System.Drawing.Size(193, 39);
            this.lblTotalOffer1.TabIndex = 0;
            this.lblTotalOffer1.Text = "Total Offers";
            // 
            // lblActiveoffers
            // 
            this.lblActiveoffers.AutoSize = true;
            this.lblActiveoffers.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveoffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveoffers.Location = new System.Drawing.Point(149, 71);
            this.lblActiveoffers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveoffers.Name = "lblActiveoffers";
            this.lblActiveoffers.Size = new System.Drawing.Size(39, 29);
            this.lblActiveoffers.TabIndex = 2;
            this.lblActiveoffers.Text = "00";
            // 
            // lblActiveOffer1
            // 
            this.lblActiveOffer1.AutoSize = true;
            this.lblActiveOffer1.BackColor = System.Drawing.Color.Transparent;
            this.lblActiveOffer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActiveOffer1.Location = new System.Drawing.Point(61, 18);
            this.lblActiveOffer1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblActiveOffer1.Name = "lblActiveOffer1";
            this.lblActiveOffer1.Size = new System.Drawing.Size(210, 39);
            this.lblActiveOffer1.TabIndex = 1;
            this.lblActiveOffer1.Text = "Active Offers";
            // 
            // lblExpireOffers
            // 
            this.lblExpireOffers.AutoSize = true;
            this.lblExpireOffers.BackColor = System.Drawing.Color.Transparent;
            this.lblExpireOffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpireOffers.Location = new System.Drawing.Point(145, 71);
            this.lblExpireOffers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpireOffers.Name = "lblExpireOffers";
            this.lblExpireOffers.Size = new System.Drawing.Size(39, 29);
            this.lblExpireOffers.TabIndex = 2;
            this.lblExpireOffers.Text = "00";
            // 
            // lblupcomingoffers
            // 
            this.lblupcomingoffers.AutoSize = true;
            this.lblupcomingoffers.BackColor = System.Drawing.Color.Transparent;
            this.lblupcomingoffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblupcomingoffers.Location = new System.Drawing.Point(25, 18);
            this.lblupcomingoffers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblupcomingoffers.Name = "lblupcomingoffers";
            this.lblupcomingoffers.Size = new System.Drawing.Size(271, 39);
            this.lblupcomingoffers.TabIndex = 1;
            this.lblupcomingoffers.Text = "Upcoming Offers";
            // 
            // lblInActiveoffers
            // 
            this.lblInActiveoffers.AutoSize = true;
            this.lblInActiveoffers.BackColor = System.Drawing.Color.Transparent;
            this.lblInActiveoffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInActiveoffers.Location = new System.Drawing.Point(155, 71);
            this.lblInActiveoffers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInActiveoffers.Name = "lblInActiveoffers";
            this.lblInActiveoffers.Size = new System.Drawing.Size(39, 29);
            this.lblInActiveoffers.TabIndex = 2;
            this.lblInActiveoffers.Text = "00";
            // 
            // lblInActiveOffers1
            // 
            this.lblInActiveOffers1.AutoSize = true;
            this.lblInActiveOffers1.BackColor = System.Drawing.Color.Transparent;
            this.lblInActiveOffers1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInActiveOffers1.Location = new System.Drawing.Point(55, 18);
            this.lblInActiveOffers1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInActiveOffers1.Name = "lblInActiveOffers1";
            this.lblInActiveOffers1.Size = new System.Drawing.Size(239, 39);
            this.lblInActiveOffers1.TabIndex = 1;
            this.lblInActiveOffers1.Text = "InActive Offers";
            // 
            // dtpOfferfromDate
            // 
            this.dtpOfferfromDate.BackColor = System.Drawing.SystemColors.Control;
            this.dtpOfferfromDate.BorderThickness = 1;
            this.dtpOfferfromDate.Checked = true;
            this.dtpOfferfromDate.FillColor = System.Drawing.Color.White;
            this.dtpOfferfromDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpOfferfromDate.ForeColor = System.Drawing.Color.Black;
            this.dtpOfferfromDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpOfferfromDate.Location = new System.Drawing.Point(108, 12);
            this.dtpOfferfromDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpOfferfromDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOfferfromDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOfferfromDate.Name = "dtpOfferfromDate";
            this.dtpOfferfromDate.Size = new System.Drawing.Size(215, 32);
            this.dtpOfferfromDate.TabIndex = 4;
            this.dtpOfferfromDate.Value = new System.DateTime(2025, 11, 10, 11, 31, 50, 366);
            this.dtpOfferfromDate.ValueChanged += new System.EventHandler(this.dtpOfferfromDate_ValueChanged);
            // 
            // dtpOffertoDate
            // 
            this.dtpOffertoDate.BorderThickness = 1;
            this.dtpOffertoDate.Checked = true;
            this.dtpOffertoDate.FillColor = System.Drawing.Color.White;
            this.dtpOffertoDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpOffertoDate.ForeColor = System.Drawing.Color.Black;
            this.dtpOffertoDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpOffertoDate.Location = new System.Drawing.Point(432, 12);
            this.dtpOffertoDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtpOffertoDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpOffertoDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpOffertoDate.Name = "dtpOffertoDate";
            this.dtpOffertoDate.Size = new System.Drawing.Size(212, 32);
            this.dtpOffertoDate.TabIndex = 5;
            this.dtpOffertoDate.Value = new System.DateTime(2025, 11, 10, 11, 31, 50, 366);
            this.dtpOffertoDate.ValueChanged += new System.EventHandler(this.dtpOffertoDate_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 12);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(88, 18);
            this.label13.TabIndex = 4;
            this.label13.Text = "From Date:-";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(348, 12);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 18);
            this.label14.TabIndex = 6;
            this.label14.Text = "To Date:-";
            // 
            // lblAllOffers
            // 
            this.lblAllOffers.AutoSize = true;
            this.lblAllOffers.BackColor = System.Drawing.Color.Transparent;
            this.lblAllOffers.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllOffers.Location = new System.Drawing.Point(630, 18);
            this.lblAllOffers.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAllOffers.Name = "lblAllOffers";
            this.lblAllOffers.Size = new System.Drawing.Size(299, 52);
            this.lblAllOffers.TabIndex = 7;
            this.lblAllOffers.Text = "ALL OFFERS";
            // 
            // pnlMenuBar
            // 
            this.pnlMenuBar.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBar.BorderThickness = 1;
            this.pnlMenuBar.Controls.Add(this.pctFilter);
            this.pnlMenuBar.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBar.Controls.Add(this.pctRefresh);
            this.pnlMenuBar.Controls.Add(this.pctSearchBox);
            this.pnlMenuBar.Location = new System.Drawing.Point(35, 274);
            this.pnlMenuBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMenuBar.Name = "pnlMenuBar";
            this.pnlMenuBar.Size = new System.Drawing.Size(504, 57);
            this.pnlMenuBar.TabIndex = 8;
            // 
            // pctFilter
            // 
            this.pctFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctFilter.BackColor = System.Drawing.Color.Transparent;
            this.pctFilter.Image = ((System.Drawing.Image)(resources.GetObject("pctFilter.Image")));
            this.pctFilter.ImageRotate = 0F;
            this.pctFilter.Location = new System.Drawing.Point(443, 7);
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
            this.txtSearchBox.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.PlaceholderText = "Search Here.....";
            this.txtSearchBox.SelectedText = "";
            this.txtSearchBox.Size = new System.Drawing.Size(301, 42);
            this.txtSearchBox.TabIndex = 3;
            this.txtSearchBox.TextChanged += new System.EventHandler(this.txtSearchBox_TextChanged);
            // 
            // pctRefresh
            // 
            this.pctRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh.Image")));
            this.pctRefresh.ImageRotate = 0F;
            this.pctRefresh.Location = new System.Drawing.Point(377, 7);
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
            this.pctSearchBox.Location = new System.Drawing.Point(3, 7);
            this.pctSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pctSearchBox.Name = "pctSearchBox";
            this.pctSearchBox.Size = new System.Drawing.Size(47, 42);
            this.pctSearchBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctSearchBox.TabIndex = 4;
            this.pctSearchBox.TabStop = false;
            // 
            // panelDataFilter
            // 
            this.panelDataFilter.Controls.Add(this.dtpOffertoDate);
            this.panelDataFilter.Controls.Add(this.dtpOfferfromDate);
            this.panelDataFilter.Controls.Add(this.label14);
            this.panelDataFilter.Controls.Add(this.label13);
            this.panelDataFilter.Location = new System.Drawing.Point(623, 274);
            this.panelDataFilter.Margin = new System.Windows.Forms.Padding(4);
            this.panelDataFilter.Name = "panelDataFilter";
            this.panelDataFilter.Size = new System.Drawing.Size(655, 57);
            this.panelDataFilter.TabIndex = 9;
            this.panelDataFilter.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDataFilter_Paint);
            // 
            // btmPrevious
            // 
            this.btmPrevious.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btmPrevious.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btmPrevious.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btmPrevious.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btmPrevious.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btmPrevious.FillColor = System.Drawing.Color.DimGray;
            this.btmPrevious.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmPrevious.ForeColor = System.Drawing.Color.White;
            this.btmPrevious.Location = new System.Drawing.Point(11, 844);
            this.btmPrevious.Margin = new System.Windows.Forms.Padding(4);
            this.btmPrevious.Name = "btmPrevious";
            this.btmPrevious.Size = new System.Drawing.Size(187, 55);
            this.btmPrevious.TabIndex = 10;
            this.btmPrevious.Text = "Previous";
            this.btmPrevious.Click += new System.EventHandler(this.btmPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNext.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnNext.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnNext.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnNext.FillColor = System.Drawing.Color.DimGray;
            this.btnNext.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(1353, 844);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(187, 55);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // pnlPage
            // 
            this.pnlPage.Location = new System.Drawing.Point(206, 844);
            this.pnlPage.Margin = new System.Windows.Forms.Padding(4);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(1139, 57);
            this.pnlPage.TabIndex = 12;
            // 
            // cpnlTotaloffers
            // 
            this.cpnlTotaloffers.BorderColor = System.Drawing.Color.Black;
            this.cpnlTotaloffers.BorderThickness = 1;
            this.cpnlTotaloffers.Controls.Add(this.lblTotalOffer1);
            this.cpnlTotaloffers.Controls.Add(this.lbltotaloffer);
            this.cpnlTotaloffers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlTotaloffers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlTotaloffers.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlTotaloffers.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlTotaloffers.Location = new System.Drawing.Point(38, 89);
            this.cpnlTotaloffers.Margin = new System.Windows.Forms.Padding(4);
            this.cpnlTotaloffers.Name = "cpnlTotaloffers";
            this.cpnlTotaloffers.Size = new System.Drawing.Size(339, 142);
            this.cpnlTotaloffers.TabIndex = 13;
            this.cpnlTotaloffers.Click += new System.EventHandler(this.cpnlTotaloffers_Click);
            // 
            // cpnlActiveOffers
            // 
            this.cpnlActiveOffers.BorderColor = System.Drawing.Color.Black;
            this.cpnlActiveOffers.BorderThickness = 1;
            this.cpnlActiveOffers.Controls.Add(this.lblActiveoffers);
            this.cpnlActiveOffers.Controls.Add(this.lblActiveOffer1);
            this.cpnlActiveOffers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlActiveOffers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlActiveOffers.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlActiveOffers.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlActiveOffers.Location = new System.Drawing.Point(425, 89);
            this.cpnlActiveOffers.Margin = new System.Windows.Forms.Padding(4);
            this.cpnlActiveOffers.Name = "cpnlActiveOffers";
            this.cpnlActiveOffers.Size = new System.Drawing.Size(339, 142);
            this.cpnlActiveOffers.TabIndex = 14;
            this.cpnlActiveOffers.Click += new System.EventHandler(this.cpnlActiveOffers_Click);
            // 
            // cpnlExpiredOffers
            // 
            this.cpnlExpiredOffers.BorderColor = System.Drawing.Color.Black;
            this.cpnlExpiredOffers.BorderThickness = 1;
            this.cpnlExpiredOffers.Controls.Add(this.lblExpireOffers);
            this.cpnlExpiredOffers.Controls.Add(this.lblupcomingoffers);
            this.cpnlExpiredOffers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlExpiredOffers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlExpiredOffers.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlExpiredOffers.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlExpiredOffers.Location = new System.Drawing.Point(803, 89);
            this.cpnlExpiredOffers.Margin = new System.Windows.Forms.Padding(4);
            this.cpnlExpiredOffers.Name = "cpnlExpiredOffers";
            this.cpnlExpiredOffers.Size = new System.Drawing.Size(339, 142);
            this.cpnlExpiredOffers.TabIndex = 15;
            this.cpnlExpiredOffers.Click += new System.EventHandler(this.cpnlExpiredOffers_Click);
            // 
            // cpnlinactiveoffers
            // 
            this.cpnlinactiveoffers.BorderColor = System.Drawing.Color.Black;
            this.cpnlinactiveoffers.BorderThickness = 1;
            this.cpnlinactiveoffers.Controls.Add(this.lblInActiveoffers);
            this.cpnlinactiveoffers.Controls.Add(this.lblInActiveOffers1);
            this.cpnlinactiveoffers.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlinactiveoffers.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.cpnlinactiveoffers.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlinactiveoffers.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.cpnlinactiveoffers.Location = new System.Drawing.Point(1176, 89);
            this.cpnlinactiveoffers.Margin = new System.Windows.Forms.Padding(4);
            this.cpnlinactiveoffers.Name = "cpnlinactiveoffers";
            this.cpnlinactiveoffers.Size = new System.Drawing.Size(339, 142);
            this.cpnlinactiveoffers.TabIndex = 16;
            this.cpnlinactiveoffers.Click += new System.EventHandler(this.cpnlinactiveoffers_Click);
            // 
            // frmOffersDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1541, 965);
            this.Controls.Add(this.cpnlinactiveoffers);
            this.Controls.Add(this.cpnlExpiredOffers);
            this.Controls.Add(this.lblAllOffers);
            this.Controls.Add(this.cpnlActiveOffers);
            this.Controls.Add(this.cpnlTotaloffers);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btmPrevious);
            this.Controls.Add(this.panelDataFilter);
            this.Controls.Add(this.pnlMenuBar);
            this.Controls.Add(this.grdOffers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmOffersDetails";
            this.Text = "frmOffersDetails";
            this.Load += new System.EventHandler(this.frmOffersDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOffers)).EndInit();
            this.pnlMenuBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            this.pnlSearchBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            this.panelDataFilter.ResumeLayout(false);
            this.panelDataFilter.PerformLayout();
            this.cpnlTotaloffers.ResumeLayout(false);
            this.cpnlTotaloffers.PerformLayout();
            this.cpnlActiveOffers.ResumeLayout(false);
            this.cpnlActiveOffers.PerformLayout();
            this.cpnlExpiredOffers.ResumeLayout(false);
            this.cpnlExpiredOffers.PerformLayout();
            this.cpnlinactiveoffers.ResumeLayout(false);
            this.cpnlinactiveoffers.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbltotaloffer;
        private System.Windows.Forms.Label lblTotalOffer1;
        private System.Windows.Forms.Label lblActiveoffers;
        private System.Windows.Forms.Label lblActiveOffer1;
        private System.Windows.Forms.Label lblExpireOffers;
        private System.Windows.Forms.Label lblupcomingoffers;
        private System.Windows.Forms.Label lblInActiveoffers;
        private System.Windows.Forms.Label lblInActiveOffers1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpOfferfromDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpOffertoDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblAllOffers;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBar;
        private Guna.UI2.WinForms.Guna2PictureBox pctFilter;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2Panel panelDataFilter;
        private Guna.UI2.WinForms.Guna2Button btmPrevious;
        private Guna.UI2.WinForms.Guna2Button btnNext;
        private System.Windows.Forms.FlowLayoutPanel pnlPage;
        private Guna.UI2.WinForms.Guna2DataGridView grdOffers;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel cpnlTotaloffers;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel cpnlActiveOffers;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel cpnlExpiredOffers;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel cpnlinactiveoffers;
    }
}