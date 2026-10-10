namespace GSTHMS
{
    partial class frmAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAttendance));
            this.connAttendance = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connAttendace1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.cmbxemployeid = new Guna.UI2.WinForms.Guna2ComboBox();
            this.rdbbtnonleave = new Guna.UI2.WinForms.Guna2RadioButton();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnAdd = new Guna.UI2.WinForms.Guna2Button();
            this.rdbbtnAbsent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rdbbtnPresent = new Guna.UI2.WinForms.Guna2RadioButton();
            this.dtpCheckout = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpCheckin = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.dtpDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCheckout = new System.Windows.Forms.Label();
            this.lblCheckinn = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblStaffname = new System.Windows.Forms.Label();
            this.lblAddAttendance = new System.Windows.Forms.Label();
            this.connAttendance.SuspendLayout();
            this.connAttendace1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // connAttendance
            // 
            this.connAttendance.Controls.Add(this.connAttendace1);
            this.connAttendance.FillColor = System.Drawing.Color.Gray;
            this.connAttendance.Location = new System.Drawing.Point(-8, -12);
            this.connAttendance.Name = "connAttendance";
            this.connAttendance.Size = new System.Drawing.Size(742, 762);
            this.connAttendance.TabIndex = 28;
            // 
            // connAttendace1
            // 
            this.connAttendace1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connAttendace1.Controls.Add(this.guna2PictureBox1);
            this.connAttendace1.Controls.Add(this.cmbxemployeid);
            this.connAttendace1.Controls.Add(this.rdbbtnonleave);
            this.connAttendace1.Controls.Add(this.btnClear);
            this.connAttendace1.Controls.Add(this.btnAdd);
            this.connAttendace1.Controls.Add(this.rdbbtnAbsent);
            this.connAttendace1.Controls.Add(this.rdbbtnPresent);
            this.connAttendace1.Controls.Add(this.dtpCheckout);
            this.connAttendace1.Controls.Add(this.dtpCheckin);
            this.connAttendace1.Controls.Add(this.dtpDate);
            this.connAttendace1.Controls.Add(this.lblStatus);
            this.connAttendace1.Controls.Add(this.lblCheckout);
            this.connAttendace1.Controls.Add(this.lblCheckinn);
            this.connAttendace1.Controls.Add(this.lblDate);
            this.connAttendace1.Controls.Add(this.lblStaffname);
            this.connAttendace1.Controls.Add(this.lblAddAttendance);
            this.connAttendace1.Location = new System.Drawing.Point(43, 48);
            this.connAttendace1.Name = "connAttendace1";
            this.connAttendace1.Size = new System.Drawing.Size(659, 619);
            this.connAttendace1.TabIndex = 29;
            this.connAttendace1.Click += new System.EventHandler(this.connAttendace1_Click_1);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(47, 47);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 29;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // cmbxemployeid
            // 
            this.cmbxemployeid.BackColor = System.Drawing.Color.Transparent;
            this.cmbxemployeid.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbxemployeid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxemployeid.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxemployeid.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbxemployeid.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbxemployeid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbxemployeid.ItemHeight = 30;
            this.cmbxemployeid.Location = new System.Drawing.Point(333, 151);
            this.cmbxemployeid.Name = "cmbxemployeid";
            this.cmbxemployeid.Size = new System.Drawing.Size(250, 36);
            this.cmbxemployeid.TabIndex = 16;
            this.cmbxemployeid.SelectedIndexChanged += new System.EventHandler(this.cmbxemployeid_SelectedIndexChanged);
            // 
            // rdbbtnonleave
            // 
            this.rdbbtnonleave.AutoSize = true;
            this.rdbbtnonleave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbbtnonleave.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnonleave.CheckedState.BorderThickness = 0;
            this.rdbbtnonleave.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnonleave.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbbtnonleave.CheckedState.InnerOffset = -4;
            this.rdbbtnonleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbbtnonleave.Location = new System.Drawing.Point(511, 492);
            this.rdbbtnonleave.Name = "rdbbtnonleave";
            this.rdbbtnonleave.Size = new System.Drawing.Size(119, 29);
            this.rdbbtnonleave.TabIndex = 15;
            this.rdbbtnonleave.Text = "On Leave";
            this.rdbbtnonleave.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbbtnonleave.UncheckedState.BorderThickness = 2;
            this.rdbbtnonleave.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbbtnonleave.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbbtnonleave.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(350, 557);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(217, 45);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAdd.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(47, 557);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(217, 45);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rdbbtnAbsent
            // 
            this.rdbbtnAbsent.AutoSize = true;
            this.rdbbtnAbsent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbbtnAbsent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnAbsent.CheckedState.BorderThickness = 0;
            this.rdbbtnAbsent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnAbsent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbbtnAbsent.CheckedState.InnerOffset = -4;
            this.rdbbtnAbsent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbbtnAbsent.Location = new System.Drawing.Point(398, 492);
            this.rdbbtnAbsent.Name = "rdbbtnAbsent";
            this.rdbbtnAbsent.Size = new System.Drawing.Size(95, 29);
            this.rdbbtnAbsent.TabIndex = 12;
            this.rdbbtnAbsent.Text = "Absent";
            this.rdbbtnAbsent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbbtnAbsent.UncheckedState.BorderThickness = 2;
            this.rdbbtnAbsent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbbtnAbsent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbbtnAbsent.UseVisualStyleBackColor = false;
            this.rdbbtnAbsent.CheckedChanged += new System.EventHandler(this.rdbbtnAbsent_CheckedChanged);
            // 
            // rdbbtnPresent
            // 
            this.rdbbtnPresent.AutoSize = true;
            this.rdbbtnPresent.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdbbtnPresent.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnPresent.CheckedState.BorderThickness = 0;
            this.rdbbtnPresent.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rdbbtnPresent.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rdbbtnPresent.CheckedState.InnerOffset = -4;
            this.rdbbtnPresent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbbtnPresent.Location = new System.Drawing.Point(276, 492);
            this.rdbbtnPresent.Name = "rdbbtnPresent";
            this.rdbbtnPresent.Size = new System.Drawing.Size(100, 29);
            this.rdbbtnPresent.TabIndex = 10;
            this.rdbbtnPresent.Text = "Present";
            this.rdbbtnPresent.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rdbbtnPresent.UncheckedState.BorderThickness = 2;
            this.rdbbtnPresent.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rdbbtnPresent.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rdbbtnPresent.UseVisualStyleBackColor = false;
            // 
            // dtpCheckout
            // 
            this.dtpCheckout.Checked = true;
            this.dtpCheckout.FillColor = System.Drawing.Color.White;
            this.dtpCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckout.ForeColor = System.Drawing.Color.Black;
            this.dtpCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCheckout.Location = new System.Drawing.Point(333, 408);
            this.dtpCheckout.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckout.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckout.Name = "dtpCheckout";
            this.dtpCheckout.ShowUpDown = true;
            this.dtpCheckout.Size = new System.Drawing.Size(200, 36);
            this.dtpCheckout.TabIndex = 9;
            this.dtpCheckout.Value = new System.DateTime(2025, 11, 20, 11, 22, 2, 925);
            // 
            // dtpCheckin
            // 
            this.dtpCheckin.Checked = true;
            this.dtpCheckin.FillColor = System.Drawing.Color.White;
            this.dtpCheckin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckin.ForeColor = System.Drawing.Color.Black;
            this.dtpCheckin.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCheckin.Location = new System.Drawing.Point(333, 320);
            this.dtpCheckin.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckin.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckin.Name = "dtpCheckin";
            this.dtpCheckin.ShowUpDown = true;
            this.dtpCheckin.Size = new System.Drawing.Size(200, 36);
            this.dtpCheckin.TabIndex = 8;
            this.dtpCheckin.Value = new System.DateTime(2025, 11, 20, 11, 22, 2, 925);
            this.dtpCheckin.ValueChanged += new System.EventHandler(this.dtpCheckin_ValueChanged);
            // 
            // dtpDate
            // 
            this.dtpDate.BorderColor = System.Drawing.Color.White;
            this.dtpDate.Checked = true;
            this.dtpDate.FillColor = System.Drawing.Color.White;
            this.dtpDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.ForeColor = System.Drawing.Color.Black;
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpDate.Location = new System.Drawing.Point(333, 233);
            this.dtpDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(263, 36);
            this.dtpDate.TabIndex = 7;
            this.dtpDate.Value = new System.DateTime(2025, 11, 20, 11, 22, 2, 925);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(64, 492);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(87, 25);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Status :";
            // 
            // lblCheckout
            // 
            this.lblCheckout.AutoSize = true;
            this.lblCheckout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckout.Location = new System.Drawing.Point(64, 408);
            this.lblCheckout.Name = "lblCheckout";
            this.lblCheckout.Size = new System.Drawing.Size(130, 25);
            this.lblCheckout.TabIndex = 4;
            this.lblCheckout.Text = "Check-Out :";
            // 
            // lblCheckinn
            // 
            this.lblCheckinn.AutoSize = true;
            this.lblCheckinn.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCheckinn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckinn.Location = new System.Drawing.Point(64, 331);
            this.lblCheckinn.Name = "lblCheckinn";
            this.lblCheckinn.Size = new System.Drawing.Size(113, 25);
            this.lblCheckinn.TabIndex = 3;
            this.lblCheckinn.Text = "Check-In :";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(64, 244);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(70, 25);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "Date :";
            // 
            // lblStaffname
            // 
            this.lblStaffname.AutoSize = true;
            this.lblStaffname.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblStaffname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStaffname.Location = new System.Drawing.Point(64, 151);
            this.lblStaffname.Name = "lblStaffname";
            this.lblStaffname.Size = new System.Drawing.Size(132, 25);
            this.lblStaffname.TabIndex = 1;
            this.lblStaffname.Text = "Staff Name :";
            // 
            // lblAddAttendance
            // 
            this.lblAddAttendance.AutoSize = true;
            this.lblAddAttendance.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAddAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.lblAddAttendance.Location = new System.Drawing.Point(136, 26);
            this.lblAddAttendance.Name = "lblAddAttendance";
            this.lblAddAttendance.Size = new System.Drawing.Size(386, 42);
            this.lblAddAttendance.TabIndex = 0;
            this.lblAddAttendance.Text = " ADD ATTENDANCE";
            // 
            // frmAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 679);
            this.ControlBox = false;
            this.Controls.Add(this.connAttendance);
            this.Name = "frmAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAttendance_Load);
            this.connAttendance.ResumeLayout(false);
            this.connAttendace1.ResumeLayout(false);
            this.connAttendace1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl connAttendance;
        private Guna.UI2.WinForms.Guna2ContainerControl connAttendace1;
        private System.Windows.Forms.Label lblAddAttendance;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.Label lblCheckinn;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStaffname;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDate;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckout;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckin;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnAdd;
        private Guna.UI2.WinForms.Guna2RadioButton rdbbtnAbsent;
        private Guna.UI2.WinForms.Guna2RadioButton rdbbtnPresent;
        private Guna.UI2.WinForms.Guna2RadioButton rdbbtnonleave;
        private Guna.UI2.WinForms.Guna2ComboBox cmbxemployeid;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}