namespace GSTHMS
{
    partial class frmEventService
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventService));
            this.grdEventService = new Guna.UI2.WinForms.Guna2DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lblEventName = new System.Windows.Forms.Label();
            this.lblBookingCode = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblTotalMember = new System.Windows.Forms.Label();
            this.lblCharges = new System.Windows.Forms.Label();
            this.cmbbxEventname = new Guna.UI2.WinForms.Guna2ComboBox();
            this.cmbbxcustomername = new Guna.UI2.WinForms.Guna2ComboBox();
            this.TxtTotalMember = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtCharges = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnParticipate = new Guna.UI2.WinForms.Guna2Button();
            this.btnCancel = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMenuBarAllGuest = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSearchBox = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearchBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.pctRefresh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctSearchBox = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.pctPDF = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblDayWiseAttendance = new System.Windows.Forms.Label();
            this.dtpStartDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpEndDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalChargesRP = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnPrevious = new Guna.UI2.WinForms.Guna2Button();
            this.pnlPages = new Guna.UI2.WinForms.Guna2Panel();
            this.btnNext = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdEventService)).BeginInit();
            this.pnlMenuBarAllGuest.SuspendLayout();
            this.pnlSearchBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grdEventService
            // 
            this.grdEventService.AllowUserToAddRows = false;
            this.grdEventService.AllowUserToDeleteRows = false;
            this.grdEventService.AllowUserToResizeColumns = false;
            this.grdEventService.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.grdEventService.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdEventService.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEventService.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdEventService.ColumnHeadersHeight = 30;
            this.grdEventService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check});
            this.grdEventService.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdEventService.DefaultCellStyle = dataGridViewCellStyle3;
            this.grdEventService.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEventService.Location = new System.Drawing.Point(12, 570);
            this.grdEventService.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdEventService.Name = "grdEventService";
            this.grdEventService.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdEventService.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grdEventService.RowHeadersVisible = false;
            this.grdEventService.RowHeadersWidth = 51;
            this.grdEventService.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdEventService.RowTemplate.Height = 28;
            this.grdEventService.Size = new System.Drawing.Size(1423, 212);
            this.grdEventService.TabIndex = 2;
            this.grdEventService.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdEventService.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdEventService.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdEventService.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdEventService.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdEventService.ThemeStyle.BackColor = System.Drawing.SystemColors.Control;
            this.grdEventService.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEventService.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdEventService.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdEventService.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEventService.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdEventService.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdEventService.ThemeStyle.HeaderStyle.Height = 30;
            this.grdEventService.ThemeStyle.ReadOnly = true;
            this.grdEventService.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdEventService.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdEventService.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdEventService.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdEventService.ThemeStyle.RowsStyle.Height = 28;
            this.grdEventService.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdEventService.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdEventService.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEventService_CellContentClick);
            this.grdEventService.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEventService_CellValueChanged);
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.MinimumWidth = 6;
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            // 
            // lblEventName
            // 
            this.lblEventName.AutoSize = true;
            this.lblEventName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEventName.Location = new System.Drawing.Point(397, 110);
            this.lblEventName.Name = "lblEventName";
            this.lblEventName.Size = new System.Drawing.Size(142, 25);
            this.lblEventName.TabIndex = 3;
            this.lblEventName.Text = "Event Name :";
            // 
            // lblBookingCode
            // 
            this.lblBookingCode.AutoSize = true;
            this.lblBookingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingCode.Location = new System.Drawing.Point(397, 165);
            this.lblBookingCode.Name = "lblBookingCode";
            this.lblBookingCode.Size = new System.Drawing.Size(180, 25);
            this.lblBookingCode.TabIndex = 4;
            this.lblBookingCode.Text = "Customer Name :";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(397, 224);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(122, 25);
            this.lblStartDate.TabIndex = 5;
            this.lblStartDate.Text = "Start Date :";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(397, 279);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(114, 25);
            this.lblEndDate.TabIndex = 6;
            this.lblEndDate.Text = "End Date :";
            // 
            // lblTotalMember
            // 
            this.lblTotalMember.AutoSize = true;
            this.lblTotalMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMember.Location = new System.Drawing.Point(397, 388);
            this.lblTotalMember.Name = "lblTotalMember";
            this.lblTotalMember.Size = new System.Drawing.Size(158, 25);
            this.lblTotalMember.TabIndex = 7;
            this.lblTotalMember.Text = "Total Member :";
            // 
            // lblCharges
            // 
            this.lblCharges.AutoSize = true;
            this.lblCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharges.Location = new System.Drawing.Point(397, 332);
            this.lblCharges.Name = "lblCharges";
            this.lblCharges.Size = new System.Drawing.Size(107, 25);
            this.lblCharges.TabIndex = 8;
            this.lblCharges.Text = "Charges :";
            // 
            // cmbbxEventname
            // 
            this.cmbbxEventname.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxEventname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxEventname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxEventname.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxEventname.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxEventname.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbbxEventname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxEventname.ItemHeight = 30;
            this.cmbbxEventname.Location = new System.Drawing.Point(836, 99);
            this.cmbbxEventname.Name = "cmbbxEventname";
            this.cmbbxEventname.Size = new System.Drawing.Size(250, 36);
            this.cmbbxEventname.TabIndex = 9;
            this.cmbbxEventname.SelectedIndexChanged += new System.EventHandler(this.cmbbxEventname_SelectedIndexChanged);
            // 
            // cmbbxcustomername
            // 
            this.cmbbxcustomername.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxcustomername.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxcustomername.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxcustomername.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxcustomername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxcustomername.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbbxcustomername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxcustomername.ItemHeight = 30;
            this.cmbbxcustomername.Location = new System.Drawing.Point(836, 154);
            this.cmbbxcustomername.Name = "cmbbxcustomername";
            this.cmbbxcustomername.Size = new System.Drawing.Size(250, 36);
            this.cmbbxcustomername.TabIndex = 10;
            this.cmbbxcustomername.SelectedIndexChanged += new System.EventHandler(this.cmbbxcustomername_SelectedIndexChanged);
            // 
            // TxtTotalMember
            // 
            this.TxtTotalMember.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtTotalMember.DefaultText = "";
            this.TxtTotalMember.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TxtTotalMember.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TxtTotalMember.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtTotalMember.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TxtTotalMember.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtTotalMember.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTotalMember.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.TxtTotalMember.Location = new System.Drawing.Point(836, 388);
            this.TxtTotalMember.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TxtTotalMember.Name = "TxtTotalMember";
            this.TxtTotalMember.PlaceholderText = "";
            this.TxtTotalMember.SelectedText = "";
            this.TxtTotalMember.Size = new System.Drawing.Size(250, 36);
            this.TxtTotalMember.TabIndex = 13;
            this.TxtTotalMember.TextChanged += new System.EventHandler(this.TxtTotalMember_TextChanged);
            // 
            // txtCharges
            // 
            this.txtCharges.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCharges.DefaultText = "";
            this.txtCharges.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtCharges.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtCharges.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCharges.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtCharges.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCharges.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharges.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtCharges.Location = new System.Drawing.Point(836, 332);
            this.txtCharges.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCharges.Name = "txtCharges";
            this.txtCharges.PlaceholderText = "";
            this.txtCharges.SelectedText = "";
            this.txtCharges.Size = new System.Drawing.Size(250, 36);
            this.txtCharges.TabIndex = 14;
            // 
            // btnParticipate
            // 
            this.btnParticipate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnParticipate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnParticipate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnParticipate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnParticipate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(148)))), ((int)(((byte)(198)))));
            this.btnParticipate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnParticipate.ForeColor = System.Drawing.Color.White;
            this.btnParticipate.Location = new System.Drawing.Point(351, 504);
            this.btnParticipate.Name = "btnParticipate";
            this.btnParticipate.Size = new System.Drawing.Size(254, 45);
            this.btnParticipate.TabIndex = 15;
            this.btnParticipate.Text = "Participate To Event";
            this.btnParticipate.Click += new System.EventHandler(this.btnParticipate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Red;
            this.btnCancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCancel.FillColor = System.Drawing.Color.Red;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(855, 504);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(217, 45);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Clear";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlMenuBarAllGuest
            // 
            this.pnlMenuBarAllGuest.BorderColor = System.Drawing.Color.Black;
            this.pnlMenuBarAllGuest.BorderRadius = 1;
            this.pnlMenuBarAllGuest.BorderThickness = 1;
            this.pnlMenuBarAllGuest.Controls.Add(this.pnlSearchBox);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctRefresh);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctSearchBox);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctExcel);
            this.pnlMenuBarAllGuest.Controls.Add(this.pctPDF);
            this.pnlMenuBarAllGuest.Location = new System.Drawing.Point(12, 41);
            this.pnlMenuBarAllGuest.Name = "pnlMenuBarAllGuest";
            this.pnlMenuBarAllGuest.Size = new System.Drawing.Size(547, 56);
            this.pnlMenuBarAllGuest.TabIndex = 18;
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
            this.pctRefresh.InitialImage = ((System.Drawing.Image)(resources.GetObject("pctRefresh.InitialImage")));
            this.pctRefresh.Location = new System.Drawing.Point(381, 7);
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
            this.pctExcel.Location = new System.Drawing.Point(487, 7);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(47, 42);
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
            this.pctPDF.Location = new System.Drawing.Point(434, 7);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(47, 42);
            this.pctPDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctPDF.TabIndex = 7;
            this.pctPDF.TabStop = false;
            this.pctPDF.Click += new System.EventHandler(this.pctPDF_Click);
            // 
            // lblDayWiseAttendance
            // 
            this.lblDayWiseAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblDayWiseAttendance.Location = new System.Drawing.Point(565, 9);
            this.lblDayWiseAttendance.Name = "lblDayWiseAttendance";
            this.lblDayWiseAttendance.Size = new System.Drawing.Size(423, 45);
            this.lblDayWiseAttendance.TabIndex = 19;
            this.lblDayWiseAttendance.Text = "EVENT SERVICE";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Checked = true;
            this.dtpStartDate.FillColor = System.Drawing.Color.White;
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStartDate.ForeColor = System.Drawing.Color.Black;
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpStartDate.Location = new System.Drawing.Point(836, 224);
            this.dtpStartDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpStartDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(263, 36);
            this.dtpStartDate.TabIndex = 20;
            this.dtpStartDate.Value = new System.DateTime(2025, 11, 9, 14, 42, 6, 18);
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.dtpStartDate_ValueChanged);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Checked = true;
            this.dtpEndDate.FillColor = System.Drawing.Color.White;
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEndDate.ForeColor = System.Drawing.Color.Black;
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpEndDate.Location = new System.Drawing.Point(836, 279);
            this.dtpEndDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpEndDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(263, 36);
            this.dtpEndDate.TabIndex = 21;
            this.dtpEndDate.Value = new System.DateTime(2025, 11, 9, 14, 42, 6, 18);
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(397, 442);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 25);
            this.label1.TabIndex = 23;
            this.label1.Text = "Total Charges :";
            // 
            // txtTotalChargesRP
            // 
            this.txtTotalChargesRP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtTotalChargesRP.DefaultText = "";
            this.txtTotalChargesRP.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtTotalChargesRP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtTotalChargesRP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalChargesRP.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtTotalChargesRP.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalChargesRP.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalChargesRP.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtTotalChargesRP.Location = new System.Drawing.Point(836, 442);
            this.txtTotalChargesRP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTotalChargesRP.Name = "txtTotalChargesRP";
            this.txtTotalChargesRP.PlaceholderText = "";
            this.txtTotalChargesRP.SelectedText = "";
            this.txtTotalChargesRP.Size = new System.Drawing.Size(250, 36);
            this.txtTotalChargesRP.TabIndex = 25;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 110);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(47, 47);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 30;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
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
            this.btnPrevious.Location = new System.Drawing.Point(12, 797);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(140, 45);
            this.btnPrevious.TabIndex = 31;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // pnlPages
            // 
            this.pnlPages.Location = new System.Drawing.Point(164, 797);
            this.pnlPages.Name = "pnlPages";
            this.pnlPages.Size = new System.Drawing.Size(1125, 45);
            this.pnlPages.TabIndex = 32;
            this.pnlPages.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPages_Paint);
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
            this.btnNext.Location = new System.Drawing.Point(1295, 797);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(140, 45);
            this.btnNext.TabIndex = 12;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // frmEventService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1448, 854);
            this.ControlBox = false;
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.pnlPages);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.txtTotalChargesRP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblDayWiseAttendance);
            this.Controls.Add(this.pnlMenuBarAllGuest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnParticipate);
            this.Controls.Add(this.txtCharges);
            this.Controls.Add(this.TxtTotalMember);
            this.Controls.Add(this.cmbbxcustomername);
            this.Controls.Add(this.cmbbxEventname);
            this.Controls.Add(this.lblCharges);
            this.Controls.Add(this.lblTotalMember);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.lblBookingCode);
            this.Controls.Add(this.lblEventName);
            this.Controls.Add(this.grdEventService);
            this.Name = "frmEventService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEventService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdEventService)).EndInit();
            this.pnlMenuBarAllGuest.ResumeLayout(false);
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

        public Guna.UI2.WinForms.Guna2DataGridView grdEventService;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.Label lblEventName;
        private System.Windows.Forms.Label lblBookingCode;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblTotalMember;
        private System.Windows.Forms.Label lblCharges;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxEventname;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxcustomername;
        private Guna.UI2.WinForms.Guna2TextBox TxtTotalMember;
        private Guna.UI2.WinForms.Guna2TextBox txtCharges;
        private Guna.UI2.WinForms.Guna2Button btnParticipate;
        private Guna.UI2.WinForms.Guna2Button btnCancel;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBarAllGuest;
        private Guna.UI2.WinForms.Guna2Panel pnlSearchBox;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh;
        private Guna.UI2.WinForms.Guna2PictureBox pctSearchBox;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2PictureBox pctPDF;
        private System.Windows.Forms.Label lblDayWiseAttendance;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpStartDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpEndDate;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtTotalChargesRP;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnPrevious;
        private Guna.UI2.WinForms.Guna2Panel pnlPages;
        private Guna.UI2.WinForms.Guna2Button btnNext;
    }
}