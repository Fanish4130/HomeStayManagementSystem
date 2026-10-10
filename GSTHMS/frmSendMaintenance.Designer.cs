namespace GSTHMS
{
    partial class frmSendMaintenance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSendMaintenance));
            this.lblMaintenanceType = new System.Windows.Forms.Label();
            this.cmbbxMaintenanceType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.connInventoryMaintenance = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.cmbbxInventoryName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.dtpReportedDate2 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnClearIN = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendInventory = new Guna.UI2.WinForms.Guna2Button();
            this.rtfDescription2 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInventoryName = new System.Windows.Forms.Label();
            this.lblInventoryMaintenance = new System.Windows.Forms.Label();
            this.connRoomMaintenance = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.cmbbxRoomName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnClearRoom = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendRoom = new Guna.UI2.WinForms.Guna2Button();
            this.dtpReportDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.rtfDescription = new System.Windows.Forms.RichTextBox();
            this.cmbbxRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSendMaintenance = new System.Windows.Forms.Label();
            this.lblReportDate = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblRoomName = new System.Windows.Forms.Label();
            this.lblRoomType = new System.Windows.Forms.Label();
            this.connServiceMaintenance = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.txtServiceType = new Guna.UI2.WinForms.Guna2TextBox();
            this.rtfDescription1 = new System.Windows.Forms.RichTextBox();
            this.lblServiceMaintenance = new System.Windows.Forms.Label();
            this.dtpReportDate1 = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.btnClearInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnSendService = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.pctExcel = new Guna.UI2.WinForms.Guna2PictureBox();
            this.connInventoryMaintenance.SuspendLayout();
            this.connRoomMaintenance.SuspendLayout();
            this.connServiceMaintenance.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMaintenanceType
            // 
            this.lblMaintenanceType.AutoSize = true;
            this.lblMaintenanceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaintenanceType.Location = new System.Drawing.Point(37, 42);
            this.lblMaintenanceType.Name = "lblMaintenanceType";
            this.lblMaintenanceType.Size = new System.Drawing.Size(144, 18);
            this.lblMaintenanceType.TabIndex = 2;
            this.lblMaintenanceType.Text = "Maintenance Type";
            // 
            // cmbbxMaintenanceType
            // 
            this.cmbbxMaintenanceType.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxMaintenanceType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxMaintenanceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxMaintenanceType.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxMaintenanceType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxMaintenanceType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxMaintenanceType.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxMaintenanceType.ItemHeight = 30;
            this.cmbbxMaintenanceType.Location = new System.Drawing.Point(187, 33);
            this.cmbbxMaintenanceType.Name = "cmbbxMaintenanceType";
            this.cmbbxMaintenanceType.Size = new System.Drawing.Size(250, 36);
            this.cmbbxMaintenanceType.TabIndex = 3;
            this.cmbbxMaintenanceType.SelectedIndexChanged += new System.EventHandler(this.cmbbxMaintenanceType_SelectedIndexChanged);
            this.cmbbxMaintenanceType.SelectionChangeCommitted += new System.EventHandler(this.cmbbxMaintenanceType_SelectionChangeCommitted);
            // 
            // connInventoryMaintenance
            // 
            this.connInventoryMaintenance.Controls.Add(this.cmbbxInventoryName);
            this.connInventoryMaintenance.Controls.Add(this.dtpReportedDate2);
            this.connInventoryMaintenance.Controls.Add(this.btnClearIN);
            this.connInventoryMaintenance.Controls.Add(this.btnSendInventory);
            this.connInventoryMaintenance.Controls.Add(this.rtfDescription2);
            this.connInventoryMaintenance.Controls.Add(this.label5);
            this.connInventoryMaintenance.Controls.Add(this.label4);
            this.connInventoryMaintenance.Controls.Add(this.lblInventoryName);
            this.connInventoryMaintenance.Controls.Add(this.lblInventoryMaintenance);
            this.connInventoryMaintenance.Location = new System.Drawing.Point(27, 85);
            this.connInventoryMaintenance.Name = "connInventoryMaintenance";
            this.connInventoryMaintenance.Size = new System.Drawing.Size(410, 447);
            this.connInventoryMaintenance.TabIndex = 0;
            this.connInventoryMaintenance.Text = "guna2ContainerControl3";
            // 
            // cmbbxInventoryName
            // 
            this.cmbbxInventoryName.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxInventoryName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxInventoryName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxInventoryName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxInventoryName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxInventoryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxInventoryName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxInventoryName.ItemHeight = 30;
            this.cmbbxInventoryName.Location = new System.Drawing.Point(164, 72);
            this.cmbbxInventoryName.MaxDropDownItems = 5;
            this.cmbbxInventoryName.Name = "cmbbxInventoryName";
            this.cmbbxInventoryName.Size = new System.Drawing.Size(182, 36);
            this.cmbbxInventoryName.TabIndex = 19;
            // 
            // dtpReportedDate2
            // 
            this.dtpReportedDate2.Checked = true;
            this.dtpReportedDate2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportedDate2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpReportedDate2.Location = new System.Drawing.Point(164, 239);
            this.dtpReportedDate2.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReportedDate2.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReportedDate2.Name = "dtpReportedDate2";
            this.dtpReportedDate2.Size = new System.Drawing.Size(182, 36);
            this.dtpReportedDate2.TabIndex = 7;
            this.dtpReportedDate2.Value = new System.DateTime(2025, 10, 31, 15, 59, 32, 698);
            // 
            // btnClearIN
            // 
            this.btnClearIN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClearIN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClearIN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClearIN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClearIN.FillColor = System.Drawing.Color.Red;
            this.btnClearIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearIN.ForeColor = System.Drawing.Color.White;
            this.btnClearIN.Location = new System.Drawing.Point(219, 335);
            this.btnClearIN.Name = "btnClearIN";
            this.btnClearIN.Size = new System.Drawing.Size(144, 45);
            this.btnClearIN.TabIndex = 18;
            this.btnClearIN.Text = "Clear";
            this.btnClearIN.Click += new System.EventHandler(this.btnClearIN_Click);
            // 
            // btnSendInventory
            // 
            this.btnSendInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendInventory.FillColor = System.Drawing.Color.Blue;
            this.btnSendInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendInventory.ForeColor = System.Drawing.Color.White;
            this.btnSendInventory.Location = new System.Drawing.Point(33, 335);
            this.btnSendInventory.Name = "btnSendInventory";
            this.btnSendInventory.Size = new System.Drawing.Size(143, 45);
            this.btnSendInventory.TabIndex = 17;
            this.btnSendInventory.Text = "Send";
            this.btnSendInventory.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // rtfDescription2
            // 
            this.rtfDescription2.Location = new System.Drawing.Point(164, 142);
            this.rtfDescription2.Name = "rtfDescription2";
            this.rtfDescription2.Size = new System.Drawing.Size(211, 59);
            this.rtfDescription2.TabIndex = 16;
            this.rtfDescription2.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(30, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "ReportDate:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description:";
            // 
            // lblInventoryName
            // 
            this.lblInventoryName.AutoSize = true;
            this.lblInventoryName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInventoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryName.Location = new System.Drawing.Point(30, 82);
            this.lblInventoryName.Name = "lblInventoryName";
            this.lblInventoryName.Size = new System.Drawing.Size(119, 16);
            this.lblInventoryName.TabIndex = 12;
            this.lblInventoryName.Text = "Inventory Name:";
            // 
            // lblInventoryMaintenance
            // 
            this.lblInventoryMaintenance.AutoSize = true;
            this.lblInventoryMaintenance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInventoryMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventoryMaintenance.Location = new System.Drawing.Point(54, 22);
            this.lblInventoryMaintenance.Name = "lblInventoryMaintenance";
            this.lblInventoryMaintenance.Size = new System.Drawing.Size(291, 20);
            this.lblInventoryMaintenance.TabIndex = 11;
            this.lblInventoryMaintenance.Text = "Maintenance Request for Inventory";
            // 
            // connRoomMaintenance
            // 
            this.connRoomMaintenance.Controls.Add(this.cmbbxRoomName);
            this.connRoomMaintenance.Controls.Add(this.btnClearRoom);
            this.connRoomMaintenance.Controls.Add(this.btnSendRoom);
            this.connRoomMaintenance.Controls.Add(this.dtpReportDate);
            this.connRoomMaintenance.Controls.Add(this.rtfDescription);
            this.connRoomMaintenance.Controls.Add(this.cmbbxRoomType);
            this.connRoomMaintenance.Controls.Add(this.lblSendMaintenance);
            this.connRoomMaintenance.Controls.Add(this.lblReportDate);
            this.connRoomMaintenance.Controls.Add(this.lblDescription);
            this.connRoomMaintenance.Controls.Add(this.lblRoomName);
            this.connRoomMaintenance.Controls.Add(this.lblRoomType);
            this.connRoomMaintenance.Location = new System.Drawing.Point(24, 79);
            this.connRoomMaintenance.Name = "connRoomMaintenance";
            this.connRoomMaintenance.Size = new System.Drawing.Size(421, 450);
            this.connRoomMaintenance.TabIndex = 3;
            this.connRoomMaintenance.Text = "guna2ContainerControl1";
            // 
            // cmbbxRoomName
            // 
            this.cmbbxRoomName.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxRoomName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxRoomName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxRoomName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxRoomName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxRoomName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxRoomName.ItemHeight = 30;
            this.cmbbxRoomName.Location = new System.Drawing.Point(176, 141);
            this.cmbbxRoomName.Name = "cmbbxRoomName";
            this.cmbbxRoomName.Size = new System.Drawing.Size(200, 36);
            this.cmbbxRoomName.TabIndex = 14;
            // 
            // btnClearRoom
            // 
            this.btnClearRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClearRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClearRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClearRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClearRoom.FillColor = System.Drawing.Color.Red;
            this.btnClearRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearRoom.ForeColor = System.Drawing.Color.White;
            this.btnClearRoom.Location = new System.Drawing.Point(216, 363);
            this.btnClearRoom.Name = "btnClearRoom";
            this.btnClearRoom.Size = new System.Drawing.Size(140, 41);
            this.btnClearRoom.TabIndex = 13;
            this.btnClearRoom.Text = "Clear";
            this.btnClearRoom.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSendRoom
            // 
            this.btnSendRoom.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendRoom.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendRoom.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendRoom.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendRoom.FillColor = System.Drawing.Color.Blue;
            this.btnSendRoom.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendRoom.ForeColor = System.Drawing.Color.White;
            this.btnSendRoom.Location = new System.Drawing.Point(30, 363);
            this.btnSendRoom.Name = "btnSendRoom";
            this.btnSendRoom.Size = new System.Drawing.Size(142, 41);
            this.btnSendRoom.TabIndex = 12;
            this.btnSendRoom.Text = "Send";
            this.btnSendRoom.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // dtpReportDate
            // 
            this.dtpReportDate.Checked = true;
            this.dtpReportDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpReportDate.Location = new System.Drawing.Point(176, 209);
            this.dtpReportDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReportDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReportDate.Name = "dtpReportDate";
            this.dtpReportDate.Size = new System.Drawing.Size(180, 36);
            this.dtpReportDate.TabIndex = 11;
            this.dtpReportDate.Value = new System.DateTime(2025, 10, 31, 13, 50, 40, 677);
            this.dtpReportDate.ValueChanged += new System.EventHandler(this.dtpReportDate_ValueChanged);
            // 
            // rtfDescription
            // 
            this.rtfDescription.Location = new System.Drawing.Point(176, 273);
            this.rtfDescription.Name = "rtfDescription";
            this.rtfDescription.Size = new System.Drawing.Size(206, 68);
            this.rtfDescription.TabIndex = 10;
            this.rtfDescription.Text = "";
            this.rtfDescription.TextChanged += new System.EventHandler(this.rtfDescription_TextChanged);
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
            this.cmbbxRoomType.Location = new System.Drawing.Point(176, 72);
            this.cmbbxRoomType.Name = "cmbbxRoomType";
            this.cmbbxRoomType.Size = new System.Drawing.Size(200, 36);
            this.cmbbxRoomType.TabIndex = 8;
            this.cmbbxRoomType.SelectedIndexChanged += new System.EventHandler(this.cmbbxRoomType_SelectedIndexChanged);
            // 
            // lblSendMaintenance
            // 
            this.lblSendMaintenance.AutoSize = true;
            this.lblSendMaintenance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSendMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSendMaintenance.Location = new System.Drawing.Point(66, 24);
            this.lblSendMaintenance.Name = "lblSendMaintenance";
            this.lblSendMaintenance.Size = new System.Drawing.Size(264, 20);
            this.lblSendMaintenance.TabIndex = 5;
            this.lblSendMaintenance.Text = "Maintenance Request for Room";
            // 
            // lblReportDate
            // 
            this.lblReportDate.AutoSize = true;
            this.lblReportDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblReportDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportDate.Location = new System.Drawing.Point(27, 220);
            this.lblReportDate.Name = "lblReportDate";
            this.lblReportDate.Size = new System.Drawing.Size(95, 16);
            this.lblReportDate.TabIndex = 4;
            this.lblReportDate.Text = "Report Date:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(27, 292);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(90, 16);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // lblRoomName
            // 
            this.lblRoomName.AutoSize = true;
            this.lblRoomName.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRoomName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomName.Location = new System.Drawing.Point(27, 147);
            this.lblRoomName.Name = "lblRoomName";
            this.lblRoomName.Size = new System.Drawing.Size(97, 16);
            this.lblRoomName.TabIndex = 2;
            this.lblRoomName.Text = "Room Name:";
            // 
            // lblRoomType
            // 
            this.lblRoomType.AutoSize = true;
            this.lblRoomType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRoomType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoomType.Location = new System.Drawing.Point(27, 85);
            this.lblRoomType.Name = "lblRoomType";
            this.lblRoomType.Size = new System.Drawing.Size(92, 16);
            this.lblRoomType.TabIndex = 1;
            this.lblRoomType.Text = "Room Type:";
            // 
            // connServiceMaintenance
            // 
            this.connServiceMaintenance.BackColor = System.Drawing.Color.AliceBlue;
            this.connServiceMaintenance.Controls.Add(this.txtServiceType);
            this.connServiceMaintenance.Controls.Add(this.rtfDescription1);
            this.connServiceMaintenance.Controls.Add(this.lblServiceMaintenance);
            this.connServiceMaintenance.Controls.Add(this.dtpReportDate1);
            this.connServiceMaintenance.Controls.Add(this.btnClearInventory);
            this.connServiceMaintenance.Controls.Add(this.btnSendService);
            this.connServiceMaintenance.Controls.Add(this.label3);
            this.connServiceMaintenance.Controls.Add(this.label2);
            this.connServiceMaintenance.Controls.Add(this.lblServiceType);
            this.connServiceMaintenance.Location = new System.Drawing.Point(27, 82);
            this.connServiceMaintenance.Name = "connServiceMaintenance";
            this.connServiceMaintenance.Size = new System.Drawing.Size(410, 447);
            this.connServiceMaintenance.TabIndex = 0;
            this.connServiceMaintenance.Text = "guna2ContainerControl2";
            // 
            // txtServiceType
            // 
            this.txtServiceType.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServiceType.DefaultText = "";
            this.txtServiceType.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtServiceType.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtServiceType.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServiceType.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtServiceType.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServiceType.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtServiceType.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtServiceType.Location = new System.Drawing.Point(164, 76);
            this.txtServiceType.Name = "txtServiceType";
            this.txtServiceType.PlaceholderText = "";
            this.txtServiceType.SelectedText = "";
            this.txtServiceType.Size = new System.Drawing.Size(200, 36);
            this.txtServiceType.TabIndex = 15;
            this.txtServiceType.TextChanged += new System.EventHandler(this.txtServiceType_TextChanged);
            // 
            // rtfDescription1
            // 
            this.rtfDescription1.Location = new System.Drawing.Point(163, 132);
            this.rtfDescription1.Name = "rtfDescription1";
            this.rtfDescription1.Size = new System.Drawing.Size(213, 65);
            this.rtfDescription1.TabIndex = 14;
            this.rtfDescription1.Text = "";
            // 
            // lblServiceMaintenance
            // 
            this.lblServiceMaintenance.AutoSize = true;
            this.lblServiceMaintenance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblServiceMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceMaintenance.Location = new System.Drawing.Point(63, 17);
            this.lblServiceMaintenance.Name = "lblServiceMaintenance";
            this.lblServiceMaintenance.Size = new System.Drawing.Size(276, 20);
            this.lblServiceMaintenance.TabIndex = 10;
            this.lblServiceMaintenance.Text = "Maintenance Request for Service";
            // 
            // dtpReportDate1
            // 
            this.dtpReportDate1.Checked = true;
            this.dtpReportDate1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpReportDate1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpReportDate1.Location = new System.Drawing.Point(163, 229);
            this.dtpReportDate1.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpReportDate1.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpReportDate1.Name = "dtpReportDate1";
            this.dtpReportDate1.Size = new System.Drawing.Size(200, 36);
            this.dtpReportDate1.TabIndex = 13;
            this.dtpReportDate1.Value = new System.DateTime(2025, 10, 31, 15, 43, 1, 274);
            this.dtpReportDate1.ValueChanged += new System.EventHandler(this.dtpReportDate1_ValueChanged);
            // 
            // btnClearInventory
            // 
            this.btnClearInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClearInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClearInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClearInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClearInventory.FillColor = System.Drawing.Color.Red;
            this.btnClearInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearInventory.ForeColor = System.Drawing.Color.White;
            this.btnClearInventory.Location = new System.Drawing.Point(209, 335);
            this.btnClearInventory.Name = "btnClearInventory";
            this.btnClearInventory.Size = new System.Drawing.Size(154, 45);
            this.btnClearInventory.TabIndex = 12;
            this.btnClearInventory.Text = "Clear";
            this.btnClearInventory.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // btnSendService
            // 
            this.btnSendService.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendService.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendService.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendService.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendService.FillColor = System.Drawing.Color.Blue;
            this.btnSendService.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendService.ForeColor = System.Drawing.Color.White;
            this.btnSendService.Location = new System.Drawing.Point(23, 335);
            this.btnSendService.Name = "btnSendService";
            this.btnSendService.Size = new System.Drawing.Size(145, 45);
            this.btnSendService.TabIndex = 11;
            this.btnSendService.Text = "Send";
            this.btnSendService.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Report Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Description:";
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblServiceType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.Location = new System.Drawing.Point(28, 86);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(100, 16);
            this.lblServiceType.TabIndex = 2;
            this.lblServiceType.Text = "Service Type";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BorderThickness = 10;
            this.guna2Panel1.Controls.Add(this.connRoomMaintenance);
            this.guna2Panel1.Controls.Add(this.pctExcel);
            this.guna2Panel1.Controls.Add(this.connServiceMaintenance);
            this.guna2Panel1.Controls.Add(this.cmbbxMaintenanceType);
            this.guna2Panel1.Controls.Add(this.connInventoryMaintenance);
            this.guna2Panel1.Controls.Add(this.lblMaintenanceType);
            this.guna2Panel1.Location = new System.Drawing.Point(12, 12);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(463, 558);
            this.guna2Panel1.TabIndex = 2;
            this.guna2Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel1_Paint);
            // 
            // pctExcel
            // 
            this.pctExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctExcel.BackColor = System.Drawing.Color.Transparent;
            this.pctExcel.Image = ((System.Drawing.Image)(resources.GetObject("pctExcel.Image")));
            this.pctExcel.ImageRotate = 0F;
            this.pctExcel.Location = new System.Drawing.Point(2, 2);
            this.pctExcel.Margin = new System.Windows.Forms.Padding(2);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(34, 31);
            this.pctExcel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctExcel.TabIndex = 46;
            this.pctExcel.TabStop = false;
            this.pctExcel.Click += new System.EventHandler(this.pctExcel_Click);
            // 
            // frmSendMaintenance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(488, 583);
            this.ControlBox = false;
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSendMaintenance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmSendMaintenance_Load);
            this.connInventoryMaintenance.ResumeLayout(false);
            this.connInventoryMaintenance.PerformLayout();
            this.connRoomMaintenance.ResumeLayout(false);
            this.connRoomMaintenance.PerformLayout();
            this.connServiceMaintenance.ResumeLayout(false);
            this.connServiceMaintenance.PerformLayout();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblMaintenanceType;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxMaintenanceType;
        private Guna.UI2.WinForms.Guna2ContainerControl connInventoryMaintenance;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReportedDate2;
        private Guna.UI2.WinForms.Guna2Button btnClearIN;
        private Guna.UI2.WinForms.Guna2Button btnSendInventory;
        private System.Windows.Forms.RichTextBox rtfDescription2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInventoryName;
        private System.Windows.Forms.Label lblInventoryMaintenance;
        private Guna.UI2.WinForms.Guna2ContainerControl connServiceMaintenance;
        private System.Windows.Forms.RichTextBox rtfDescription1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReportDate1;
        private Guna.UI2.WinForms.Guna2Button btnClearInventory;
        private Guna.UI2.WinForms.Guna2Button btnSendService;
        private System.Windows.Forms.Label lblServiceMaintenance;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblServiceType;
        private Guna.UI2.WinForms.Guna2ContainerControl connRoomMaintenance;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomName;
        private Guna.UI2.WinForms.Guna2Button btnClearRoom;
        private Guna.UI2.WinForms.Guna2Button btnSendRoom;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpReportDate;
        private System.Windows.Forms.RichTextBox rtfDescription;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxRoomType;
        private System.Windows.Forms.Label lblSendMaintenance;
        private System.Windows.Forms.Label lblReportDate;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblRoomName;
        private System.Windows.Forms.Label lblRoomType;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxInventoryName;
        private Guna.UI2.WinForms.Guna2PictureBox pctExcel;
        private Guna.UI2.WinForms.Guna2TextBox txtServiceType;
    }
}