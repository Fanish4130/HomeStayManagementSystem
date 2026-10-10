namespace GSTHMS
{
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPayment));
            this.lblPayment = new System.Windows.Forms.Label();
            this.lblBookingCode = new System.Windows.Forms.Label();
            this.lblcode = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.lbloff = new System.Windows.Forms.Label();
            this.lblOffer = new System.Windows.Forms.Label();
            this.lblPMode = new System.Windows.Forms.Label();
            this.lblFine = new System.Windows.Forms.Label();
            this.lblPAmt = new System.Windows.Forms.Label();
            this.lblAmtToPay = new System.Windows.Forms.Label();
            this.txtPAmt = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtAmtToPay = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnPay = new System.Windows.Forms.Button();
            this.rdbtnUPI = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdbtnCash = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdbtnBankTransfer = new Guna.UI2.WinForms.Guna2RadioButton();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblAccountNo = new System.Windows.Forms.Label();
            this.lblANO = new System.Windows.Forms.Label();
            this.lblBname = new System.Windows.Forms.Label();
            this.lblIFSCCode = new System.Windows.Forms.Label();
            this.lblUI = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblif = new System.Windows.Forms.Label();
            this.lblUPIID = new System.Windows.Forms.Label();
            this.cmbbxBank = new Guna.UI2.WinForms.Guna2ComboBox();
            this.txtRemaining = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblRemaning = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblfinediscription = new System.Windows.Forms.Label();
            this.rtfFineDiscription = new System.Windows.Forms.RichTextBox();
            this.grdinfo = new Guna.UI2.WinForms.Guna2DataGridView();
            this.txtFine = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtOffer = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblOfferDiscount = new System.Windows.Forms.Label();
            this.guna2ContainerControl1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2ContainerControl2 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdinfo)).BeginInit();
            this.guna2ContainerControl1.SuspendLayout();
            this.guna2ContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPayment
            // 
            this.lblPayment.AutoSize = true;
            this.lblPayment.BackColor = System.Drawing.Color.Transparent;
            this.lblPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPayment.Location = new System.Drawing.Point(429, 9);
            this.lblPayment.Name = "lblPayment";
            this.lblPayment.Size = new System.Drawing.Size(206, 42);
            this.lblPayment.TabIndex = 0;
            this.lblPayment.Text = "PAYMENT";
            // 
            // lblBookingCode
            // 
            this.lblBookingCode.AutoSize = true;
            this.lblBookingCode.BackColor = System.Drawing.Color.Transparent;
            this.lblBookingCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookingCode.Location = new System.Drawing.Point(20, 147);
            this.lblBookingCode.Name = "lblBookingCode";
            this.lblBookingCode.Size = new System.Drawing.Size(161, 25);
            this.lblBookingCode.TabIndex = 1;
            this.lblBookingCode.Text = "Booking Code :";
            this.lblBookingCode.Click += new System.EventHandler(this.lblBookingCode_Click);
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.BackColor = System.Drawing.Color.Transparent;
            this.lblcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(215, 147);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(136, 25);
            this.lblcode.TabIndex = 2;
            this.lblcode.Text = "BookingCode ";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.BackColor = System.Drawing.Color.Transparent;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.Location = new System.Drawing.Point(20, 57);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(144, 25);
            this.lblGuestName.TabIndex = 3;
            this.lblGuestName.Text = "Guest Name :";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.Transparent;
            this.lblname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.Location = new System.Drawing.Point(215, 57);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(126, 25);
            this.lblname.TabIndex = 4;
            this.lblname.Text = "Guest Name ";
            // 
            // lbloff
            // 
            this.lbloff.AutoSize = true;
            this.lbloff.BackColor = System.Drawing.Color.Transparent;
            this.lbloff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbloff.Location = new System.Drawing.Point(20, 226);
            this.lbloff.Name = "lbloff";
            this.lbloff.Size = new System.Drawing.Size(67, 25);
            this.lbloff.TabIndex = 9;
            this.lbloff.Text = "Offer:";
            // 
            // lblOffer
            // 
            this.lblOffer.AutoSize = true;
            this.lblOffer.BackColor = System.Drawing.Color.Transparent;
            this.lblOffer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffer.Location = new System.Drawing.Point(215, 226);
            this.lblOffer.Name = "lblOffer";
            this.lblOffer.Size = new System.Drawing.Size(55, 25);
            this.lblOffer.TabIndex = 10;
            this.lblOffer.Text = "Offer";
            // 
            // lblPMode
            // 
            this.lblPMode.AutoSize = true;
            this.lblPMode.BackColor = System.Drawing.Color.Transparent;
            this.lblPMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPMode.Location = new System.Drawing.Point(20, 303);
            this.lblPMode.Name = "lblPMode";
            this.lblPMode.Size = new System.Drawing.Size(181, 25);
            this.lblPMode.TabIndex = 11;
            this.lblPMode.Text = "Payment Method:";
            // 
            // lblFine
            // 
            this.lblFine.AutoSize = true;
            this.lblFine.BackColor = System.Drawing.Color.Transparent;
            this.lblFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFine.Location = new System.Drawing.Point(625, 461);
            this.lblFine.Name = "lblFine";
            this.lblFine.Size = new System.Drawing.Size(61, 25);
            this.lblFine.TabIndex = 14;
            this.lblFine.Text = "Fine:";
            // 
            // lblPAmt
            // 
            this.lblPAmt.AutoSize = true;
            this.lblPAmt.BackColor = System.Drawing.Color.Transparent;
            this.lblPAmt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPAmt.Location = new System.Drawing.Point(625, 531);
            this.lblPAmt.Name = "lblPAmt";
            this.lblPAmt.Size = new System.Drawing.Size(138, 25);
            this.lblPAmt.TabIndex = 16;
            this.lblPAmt.Text = "Amt To Pay :";
            // 
            // lblAmtToPay
            // 
            this.lblAmtToPay.AutoSize = true;
            this.lblAmtToPay.BackColor = System.Drawing.Color.Transparent;
            this.lblAmtToPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmtToPay.Location = new System.Drawing.Point(625, 665);
            this.lblAmtToPay.Name = "lblAmtToPay";
            this.lblAmtToPay.Size = new System.Drawing.Size(112, 25);
            this.lblAmtToPay.TabIndex = 17;
            this.lblAmtToPay.Text = "Total Amt:";
            this.lblAmtToPay.Click += new System.EventHandler(this.lblAmtToPay_Click);
            // 
            // txtPAmt
            // 
            this.txtPAmt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtPAmt.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPAmt.DefaultText = "";
            this.txtPAmt.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPAmt.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPAmt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPAmt.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPAmt.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPAmt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPAmt.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPAmt.Location = new System.Drawing.Point(865, 531);
            this.txtPAmt.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPAmt.Name = "txtPAmt";
            this.txtPAmt.PlaceholderText = "";
            this.txtPAmt.SelectedText = "";
            this.txtPAmt.Size = new System.Drawing.Size(284, 36);
            this.txtPAmt.TabIndex = 18;
            this.txtPAmt.TextChanged += new System.EventHandler(this.txtPAmt_TextChanged);
            this.txtPAmt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPAmt_KeyPress);
            // 
            // txtAmtToPay
            // 
            this.txtAmtToPay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtAmtToPay.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAmtToPay.DefaultText = "";
            this.txtAmtToPay.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtAmtToPay.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtAmtToPay.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmtToPay.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtAmtToPay.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmtToPay.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAmtToPay.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtAmtToPay.Location = new System.Drawing.Point(865, 665);
            this.txtAmtToPay.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtAmtToPay.Name = "txtAmtToPay";
            this.txtAmtToPay.PlaceholderText = "";
            this.txtAmtToPay.SelectedText = "";
            this.txtAmtToPay.Size = new System.Drawing.Size(284, 36);
            this.txtAmtToPay.TabIndex = 19;
            this.txtAmtToPay.TextChanged += new System.EventHandler(this.txtAmtToPay_TextChanged);
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(168)))), ((int)(((byte)(74)))));
            this.btnPay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPay.Location = new System.Drawing.Point(253, 720);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(217, 45);
            this.btnPay.TabIndex = 20;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // rdbtnUPI
            // 
            this.rdbtnUPI.AutoSize = true;
            this.rdbtnUPI.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnUPI.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnUPI.CheckedState.BorderThickness = 0;
            this.rdbtnUPI.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnUPI.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbtnUPI.CheckedState.InnerOffset = -4;
            this.rdbtnUPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnUPI.Location = new System.Drawing.Point(220, 348);
            this.rdbtnUPI.Name = "rdbtnUPI";
            this.rdbtnUPI.Size = new System.Drawing.Size(68, 29);
            this.rdbtnUPI.TabIndex = 21;
            this.rdbtnUPI.Text = "UPI";
            this.rdbtnUPI.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbtnUPI.UncheckedState.BorderThickness = 2;
            this.rdbtnUPI.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbtnUPI.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbtnUPI.UseVisualStyleBackColor = false;
            this.rdbtnUPI.CheckedChanged += new System.EventHandler(this.rdbtnUPI_CheckedChanged);
            // 
            // rdbtnCash
            // 
            this.rdbtnCash.AutoSize = true;
            this.rdbtnCash.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnCash.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnCash.CheckedState.BorderThickness = 0;
            this.rdbtnCash.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnCash.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbtnCash.CheckedState.InnerOffset = -4;
            this.rdbtnCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnCash.Location = new System.Drawing.Point(220, 303);
            this.rdbtnCash.Name = "rdbtnCash";
            this.rdbtnCash.Size = new System.Drawing.Size(84, 29);
            this.rdbtnCash.TabIndex = 22;
            this.rdbtnCash.Text = "Cash";
            this.rdbtnCash.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbtnCash.UncheckedState.BorderThickness = 2;
            this.rdbtnCash.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbtnCash.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbtnCash.UseVisualStyleBackColor = false;
            this.rdbtnCash.CheckedChanged += new System.EventHandler(this.rdbtnCash_CheckedChanged);
            // 
            // rdbtnBankTransfer
            // 
            this.rdbtnBankTransfer.AutoSize = true;
            this.rdbtnBankTransfer.BackColor = System.Drawing.Color.Transparent;
            this.rdbtnBankTransfer.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnBankTransfer.CheckedState.BorderThickness = 0;
            this.rdbtnBankTransfer.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbtnBankTransfer.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbtnBankTransfer.CheckedState.InnerOffset = -4;
            this.rdbtnBankTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtnBankTransfer.Location = new System.Drawing.Point(220, 415);
            this.rdbtnBankTransfer.Name = "rdbtnBankTransfer";
            this.rdbtnBankTransfer.Size = new System.Drawing.Size(163, 29);
            this.rdbtnBankTransfer.TabIndex = 23;
            this.rdbtnBankTransfer.Text = "BankTransfer";
            this.rdbtnBankTransfer.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbtnBankTransfer.UncheckedState.BorderThickness = 2;
            this.rdbtnBankTransfer.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbtnBankTransfer.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbtnBankTransfer.UseVisualStyleBackColor = false;
            this.rdbtnBankTransfer.CheckedChanged += new System.EventHandler(this.rdbtnBankTransfer_CheckedChanged);
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.BackColor = System.Drawing.Color.Transparent;
            this.lblBankName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.Location = new System.Drawing.Point(20, 492);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(130, 25);
            this.lblBankName.TabIndex = 24;
            this.lblBankName.Text = "Bank Name:";
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.AutoSize = true;
            this.lblAccountNo.BackColor = System.Drawing.Color.Transparent;
            this.lblAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNo.Location = new System.Drawing.Point(215, 609);
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Size = new System.Drawing.Size(131, 25);
            this.lblAccountNo.TabIndex = 25;
            this.lblAccountNo.Text = "Account No:";
            this.lblAccountNo.Click += new System.EventHandler(this.lblAccountNo_Click);
            // 
            // lblANO
            // 
            this.lblANO.AutoSize = true;
            this.lblANO.BackColor = System.Drawing.Color.Transparent;
            this.lblANO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblANO.Location = new System.Drawing.Point(376, 609);
            this.lblANO.Name = "lblANO";
            this.lblANO.Size = new System.Drawing.Size(108, 25);
            this.lblANO.TabIndex = 26;
            this.lblANO.Text = "account no";
            // 
            // lblBname
            // 
            this.lblBname.AutoSize = true;
            this.lblBname.Location = new System.Drawing.Point(357, 540);
            this.lblBname.Name = "lblBname";
            this.lblBname.Size = new System.Drawing.Size(0, 16);
            this.lblBname.TabIndex = 27;
            // 
            // lblIFSCCode
            // 
            this.lblIFSCCode.AutoSize = true;
            this.lblIFSCCode.BackColor = System.Drawing.Color.Transparent;
            this.lblIFSCCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFSCCode.Location = new System.Drawing.Point(215, 665);
            this.lblIFSCCode.Name = "lblIFSCCode";
            this.lblIFSCCode.Size = new System.Drawing.Size(127, 25);
            this.lblIFSCCode.TabIndex = 28;
            this.lblIFSCCode.Text = "IFSC Code:";
            this.lblIFSCCode.Click += new System.EventHandler(this.lblIFSCCode_Click);
            // 
            // lblUI
            // 
            this.lblUI.AutoSize = true;
            this.lblUI.BackColor = System.Drawing.Color.Transparent;
            this.lblUI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUI.Location = new System.Drawing.Point(215, 560);
            this.lblUI.Name = "lblUI";
            this.lblUI.Size = new System.Drawing.Size(81, 25);
            this.lblUI.TabIndex = 29;
            this.lblUI.Text = "UPI ID:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(548, 444);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 30;
            // 
            // lblif
            // 
            this.lblif.AutoSize = true;
            this.lblif.BackColor = System.Drawing.Color.Transparent;
            this.lblif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblif.Location = new System.Drawing.Point(376, 665);
            this.lblif.Name = "lblif";
            this.lblif.Size = new System.Drawing.Size(94, 25);
            this.lblif.TabIndex = 31;
            this.lblif.Text = "icsc code";
            // 
            // lblUPIID
            // 
            this.lblUPIID.AutoSize = true;
            this.lblUPIID.BackColor = System.Drawing.Color.Transparent;
            this.lblUPIID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUPIID.Location = new System.Drawing.Point(376, 560);
            this.lblUPIID.Name = "lblUPIID";
            this.lblUPIID.Size = new System.Drawing.Size(58, 25);
            this.lblUPIID.TabIndex = 32;
            this.lblUPIID.Text = "upi id";
            // 
            // cmbbxBank
            // 
            this.cmbbxBank.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxBank.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmbbxBank.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxBank.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxBank.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxBank.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxBank.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxBank.ItemHeight = 30;
            this.cmbbxBank.Location = new System.Drawing.Point(220, 483);
            this.cmbbxBank.Name = "cmbbxBank";
            this.cmbbxBank.Size = new System.Drawing.Size(250, 36);
            this.cmbbxBank.TabIndex = 33;
            this.cmbbxBank.SelectedIndexChanged += new System.EventHandler(this.cmbbxBank_SelectedIndexChanged);
            // 
            // txtRemaining
            // 
            this.txtRemaining.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtRemaining.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtRemaining.DefaultText = "";
            this.txtRemaining.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtRemaining.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtRemaining.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemaining.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtRemaining.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemaining.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRemaining.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtRemaining.Location = new System.Drawing.Point(865, 596);
            this.txtRemaining.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemaining.Name = "txtRemaining";
            this.txtRemaining.PlaceholderText = "";
            this.txtRemaining.SelectedText = "";
            this.txtRemaining.Size = new System.Drawing.Size(284, 36);
            this.txtRemaining.TabIndex = 38;
            this.txtRemaining.TextChanged += new System.EventHandler(this.txtRemaining_TextChanged);
            // 
            // lblRemaning
            // 
            this.lblRemaning.AutoSize = true;
            this.lblRemaning.BackColor = System.Drawing.Color.Transparent;
            this.lblRemaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemaning.Location = new System.Drawing.Point(625, 596);
            this.lblRemaning.Name = "lblRemaning";
            this.lblRemaning.Size = new System.Drawing.Size(200, 25);
            this.lblRemaning.TabIndex = 39;
            this.lblRemaning.Text = "Remaining Amount:";
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClear.Location = new System.Drawing.Point(689, 720);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(217, 45);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblfinediscription
            // 
            this.lblfinediscription.AutoSize = true;
            this.lblfinediscription.BackColor = System.Drawing.Color.Transparent;
            this.lblfinediscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfinediscription.Location = new System.Drawing.Point(625, 405);
            this.lblfinediscription.Name = "lblfinediscription";
            this.lblfinediscription.Size = new System.Drawing.Size(168, 25);
            this.lblfinediscription.TabIndex = 41;
            this.lblfinediscription.Text = "Fine Discription:";
            // 
            // rtfFineDiscription
            // 
            this.rtfFineDiscription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfFineDiscription.Location = new System.Drawing.Point(865, 386);
            this.rtfFineDiscription.Name = "rtfFineDiscription";
            this.rtfFineDiscription.Size = new System.Drawing.Size(284, 68);
            this.rtfFineDiscription.TabIndex = 42;
            this.rtfFineDiscription.Text = "";
            this.rtfFineDiscription.TextChanged += new System.EventHandler(this.rtfFineDiscription_TextChanged);
            this.rtfFineDiscription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfFineDiscription_KeyPress);
            // 
            // grdinfo
            // 
            this.grdinfo.AllowUserToResizeColumns = false;
            this.grdinfo.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.grdinfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.grdinfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Gray;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdinfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdinfo.ColumnHeadersHeight = 30;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdinfo.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdinfo.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdinfo.Location = new System.Drawing.Point(630, 57);
            this.grdinfo.Name = "grdinfo";
            this.grdinfo.ReadOnly = true;
            this.grdinfo.RowHeadersVisible = false;
            this.grdinfo.RowHeadersWidth = 51;
            this.grdinfo.RowTemplate.Height = 24;
            this.grdinfo.Size = new System.Drawing.Size(678, 271);
            this.grdinfo.TabIndex = 45;
            this.grdinfo.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdinfo.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdinfo.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdinfo.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdinfo.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdinfo.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.grdinfo.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdinfo.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdinfo.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdinfo.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdinfo.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdinfo.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdinfo.ThemeStyle.HeaderStyle.Height = 30;
            this.grdinfo.ThemeStyle.ReadOnly = true;
            this.grdinfo.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdinfo.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdinfo.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdinfo.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdinfo.ThemeStyle.RowsStyle.Height = 24;
            this.grdinfo.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdinfo.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdinfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdinfo_CellContentClick);
            this.grdinfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.grdinfo_CellFormatting);
            // 
            // txtFine
            // 
            this.txtFine.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtFine.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFine.DefaultText = "";
            this.txtFine.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtFine.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtFine.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFine.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtFine.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFine.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtFine.Location = new System.Drawing.Point(865, 461);
            this.txtFine.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtFine.Name = "txtFine";
            this.txtFine.PlaceholderText = "";
            this.txtFine.SelectedText = "";
            this.txtFine.Size = new System.Drawing.Size(284, 36);
            this.txtFine.TabIndex = 46;
            this.txtFine.TextChanged += new System.EventHandler(this.txtFine_TextChanged);
            this.txtFine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFine_KeyPress);
            // 
            // txtOffer
            // 
            this.txtOffer.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.txtOffer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtOffer.DefaultText = "";
            this.txtOffer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtOffer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtOffer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOffer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtOffer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOffer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtOffer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtOffer.Location = new System.Drawing.Point(865, 341);
            this.txtOffer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOffer.Name = "txtOffer";
            this.txtOffer.PlaceholderText = "";
            this.txtOffer.SelectedText = "";
            this.txtOffer.Size = new System.Drawing.Size(284, 36);
            this.txtOffer.TabIndex = 47;
            this.txtOffer.TextChanged += new System.EventHandler(this.txtOffer_TextChanged);
            // 
            // lblOfferDiscount
            // 
            this.lblOfferDiscount.AutoSize = true;
            this.lblOfferDiscount.BackColor = System.Drawing.Color.Transparent;
            this.lblOfferDiscount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOfferDiscount.Location = new System.Drawing.Point(625, 341);
            this.lblOfferDiscount.Name = "lblOfferDiscount";
            this.lblOfferDiscount.Size = new System.Drawing.Size(156, 25);
            this.lblOfferDiscount.TabIndex = 48;
            this.lblOfferDiscount.Text = "Discount_amt :";
            // 
            // guna2ContainerControl1
            // 
            this.guna2ContainerControl1.Controls.Add(this.guna2ContainerControl2);
            this.guna2ContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2ContainerControl1.FillColor = System.Drawing.Color.Gray;
            this.guna2ContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.guna2ContainerControl1.Name = "guna2ContainerControl1";
            this.guna2ContainerControl1.Size = new System.Drawing.Size(1407, 1055);
            this.guna2ContainerControl1.TabIndex = 49;
            this.guna2ContainerControl1.Text = "guna2ContainerControl1";
            this.guna2ContainerControl1.Click += new System.EventHandler(this.guna2ContainerControl1_Click);
            // 
            // guna2ContainerControl2
            // 
            this.guna2ContainerControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.guna2ContainerControl2.Controls.Add(this.guna2PictureBox1);
            this.guna2ContainerControl2.Controls.Add(this.lblRemaning);
            this.guna2ContainerControl2.Controls.Add(this.cmbbxBank);
            this.guna2ContainerControl2.Controls.Add(this.btnClear);
            this.guna2ContainerControl2.Controls.Add(this.lblPayment);
            this.guna2ContainerControl2.Controls.Add(this.lblcode);
            this.guna2ContainerControl2.Controls.Add(this.grdinfo);
            this.guna2ContainerControl2.Controls.Add(this.lblBookingCode);
            this.guna2ContainerControl2.Controls.Add(this.txtOffer);
            this.guna2ContainerControl2.Controls.Add(this.lblBankName);
            this.guna2ContainerControl2.Controls.Add(this.lblOfferDiscount);
            this.guna2ContainerControl2.Controls.Add(this.lblOffer);
            this.guna2ContainerControl2.Controls.Add(this.btnPay);
            this.guna2ContainerControl2.Controls.Add(this.lbloff);
            this.guna2ContainerControl2.Controls.Add(this.txtRemaining);
            this.guna2ContainerControl2.Controls.Add(this.lblname);
            this.guna2ContainerControl2.Controls.Add(this.txtPAmt);
            this.guna2ContainerControl2.Controls.Add(this.lblGuestName);
            this.guna2ContainerControl2.Controls.Add(this.txtFine);
            this.guna2ContainerControl2.Controls.Add(this.lblPAmt);
            this.guna2ContainerControl2.Controls.Add(this.rdbtnBankTransfer);
            this.guna2ContainerControl2.Controls.Add(this.lblUI);
            this.guna2ContainerControl2.Controls.Add(this.rdbtnCash);
            this.guna2ContainerControl2.Controls.Add(this.rtfFineDiscription);
            this.guna2ContainerControl2.Controls.Add(this.rdbtnUPI);
            this.guna2ContainerControl2.Controls.Add(this.lblUPIID);
            this.guna2ContainerControl2.Controls.Add(this.lblfinediscription);
            this.guna2ContainerControl2.Controls.Add(this.lblPMode);
            this.guna2ContainerControl2.Controls.Add(this.lblIFSCCode);
            this.guna2ContainerControl2.Controls.Add(this.lblif);
            this.guna2ContainerControl2.Controls.Add(this.lblAccountNo);
            this.guna2ContainerControl2.Controls.Add(this.lblANO);
            this.guna2ContainerControl2.Controls.Add(this.lblFine);
            this.guna2ContainerControl2.Controls.Add(this.txtAmtToPay);
            this.guna2ContainerControl2.Controls.Add(this.lblAmtToPay);
            this.guna2ContainerControl2.Location = new System.Drawing.Point(26, 28);
            this.guna2ContainerControl2.Name = "guna2ContainerControl2";
            this.guna2ContainerControl2.Size = new System.Drawing.Size(1338, 987);
            this.guna2ContainerControl2.TabIndex = 0;
            this.guna2ContainerControl2.Text = "guna2ContainerControl2";
            this.guna2ContainerControl2.Click += new System.EventHandler(this.guna2ContainerControl2_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(58, 52);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 49;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1407, 1055);
            this.Controls.Add(this.guna2ContainerControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblBname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.frmPayment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdinfo)).EndInit();
            this.guna2ContainerControl1.ResumeLayout(false);
            this.guna2ContainerControl2.ResumeLayout(false);
            this.guna2ContainerControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPayment;
        private System.Windows.Forms.Label lblBookingCode;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.Label lbloff;
        private System.Windows.Forms.Label lblOffer;
        private System.Windows.Forms.Label lblPMode;
        private System.Windows.Forms.Label lblFine;
        private System.Windows.Forms.Label lblPAmt;
        private System.Windows.Forms.Label lblAmtToPay;
        private Guna.UI2.WinForms.Guna2TextBox txtPAmt;
        private Guna.UI2.WinForms.Guna2TextBox txtAmtToPay;
        private System.Windows.Forms.Button btnPay;
        private Guna.UI2.WinForms.Guna2RadioButton rdbtnUPI;
        private Guna.UI2.WinForms.Guna2RadioButton rdbtnCash;
        private Guna.UI2.WinForms.Guna2RadioButton rdbtnBankTransfer;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.Label lblAccountNo;
        private System.Windows.Forms.Label lblANO;
        private System.Windows.Forms.Label lblBname;
        private System.Windows.Forms.Label lblIFSCCode;
        private System.Windows.Forms.Label lblUI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblif;
        private System.Windows.Forms.Label lblUPIID;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxBank;
        private Guna.UI2.WinForms.Guna2TextBox txtRemaining;
        private System.Windows.Forms.Label lblRemaning;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblfinediscription;
        private System.Windows.Forms.RichTextBox rtfFineDiscription;
        private Guna.UI2.WinForms.Guna2DataGridView grdinfo;
        private Guna.UI2.WinForms.Guna2TextBox txtFine;
        private Guna.UI2.WinForms.Guna2TextBox txtOffer;
        private System.Windows.Forms.Label lblOfferDiscount;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl1;
        private Guna.UI2.WinForms.Guna2ContainerControl guna2ContainerControl2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}