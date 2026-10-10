namespace GSTHMS
{
    partial class frmupdateAttendance
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmupdateAttendance));
            this.connAttendance = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connAttendace1 = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.lblcheckin = new System.Windows.Forms.Label();
            this.lbldate11 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblstaffname1 = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnupdate1 = new Guna.UI2.WinForms.Guna2Button();
            this.dtpCheckout = new Guna.UI2.WinForms.Guna2DateTimePicker();
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
            this.connAttendance.FillColor = System.Drawing.Color.DimGray;
            this.connAttendance.Location = new System.Drawing.Point(2, -10);
            this.connAttendance.Name = "connAttendance";
            this.connAttendance.Size = new System.Drawing.Size(731, 732);
            this.connAttendance.TabIndex = 29;
            // 
            // connAttendace1
            // 
            this.connAttendace1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connAttendace1.Controls.Add(this.lblcheckin);
            this.connAttendace1.Controls.Add(this.lbldate11);
            this.connAttendace1.Controls.Add(this.guna2PictureBox1);
            this.connAttendace1.Controls.Add(this.lblstaffname1);
            this.connAttendace1.Controls.Add(this.btnClear);
            this.connAttendace1.Controls.Add(this.btnupdate1);
            this.connAttendace1.Controls.Add(this.dtpCheckout);
            this.connAttendace1.Controls.Add(this.lblCheckout);
            this.connAttendace1.Controls.Add(this.lblCheckinn);
            this.connAttendace1.Controls.Add(this.lblDate);
            this.connAttendace1.Controls.Add(this.lblStaffname);
            this.connAttendace1.Controls.Add(this.lblAddAttendance);
            this.connAttendace1.Location = new System.Drawing.Point(39, 43);
            this.connAttendace1.Name = "connAttendace1";
            this.connAttendace1.Size = new System.Drawing.Size(652, 615);
            this.connAttendace1.TabIndex = 29;
            this.connAttendace1.Click += new System.EventHandler(this.connAttendace1_Click);
            // 
            // lblcheckin
            // 
            this.lblcheckin.AutoSize = true;
            this.lblcheckin.BackColor = System.Drawing.Color.Transparent;
            this.lblcheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcheckin.Location = new System.Drawing.Point(337, 329);
            this.lblcheckin.Name = "lblcheckin";
            this.lblcheckin.Size = new System.Drawing.Size(66, 25);
            this.lblcheckin.TabIndex = 51;
            this.lblcheckin.Text = "DATE";
            // 
            // lbldate11
            // 
            this.lbldate11.AutoSize = true;
            this.lbldate11.BackColor = System.Drawing.Color.Transparent;
            this.lbldate11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate11.Location = new System.Drawing.Point(337, 244);
            this.lbldate11.Name = "lbldate11";
            this.lbldate11.Size = new System.Drawing.Size(66, 25);
            this.lbldate11.TabIndex = 50;
            this.lbldate11.Text = "DATE";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(3, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(47, 47);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 47;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // lblstaffname1
            // 
            this.lblstaffname1.AutoSize = true;
            this.lblstaffname1.BackColor = System.Drawing.Color.Transparent;
            this.lblstaffname1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstaffname1.Location = new System.Drawing.Point(337, 151);
            this.lblstaffname1.Name = "lblstaffname1";
            this.lblstaffname1.Size = new System.Drawing.Size(64, 25);
            this.lblstaffname1.TabIndex = 16;
            this.lblstaffname1.Text = "label1";
            // 
            // btnClear
            // 
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(342, 534);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(250, 45);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnupdate1
            // 
            this.btnupdate1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnupdate1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnupdate1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnupdate1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnupdate1.FillColor = System.Drawing.Color.Blue;
            this.btnupdate1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnupdate1.ForeColor = System.Drawing.Color.White;
            this.btnupdate1.Location = new System.Drawing.Point(55, 534);
            this.btnupdate1.Name = "btnupdate1";
            this.btnupdate1.Size = new System.Drawing.Size(250, 45);
            this.btnupdate1.TabIndex = 13;
            this.btnupdate1.Text = "Update";
            this.btnupdate1.Click += new System.EventHandler(this.btnupdate1_Click);
            // 
            // dtpCheckout
            // 
            this.dtpCheckout.Checked = true;
            this.dtpCheckout.FillColor = System.Drawing.Color.White;
            this.dtpCheckout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckout.ForeColor = System.Drawing.Color.Black;
            this.dtpCheckout.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpCheckout.Location = new System.Drawing.Point(342, 397);
            this.dtpCheckout.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpCheckout.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpCheckout.Name = "dtpCheckout";
            this.dtpCheckout.ShowUpDown = true;
            this.dtpCheckout.Size = new System.Drawing.Size(200, 36);
            this.dtpCheckout.TabIndex = 9;
            this.dtpCheckout.Value = new System.DateTime(2025, 11, 20, 11, 22, 2, 925);
            // 
            // lblCheckout
            // 
            this.lblCheckout.AutoSize = true;
            this.lblCheckout.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblCheckout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckout.Location = new System.Drawing.Point(68, 408);
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
            this.lblCheckinn.Location = new System.Drawing.Point(68, 329);
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
            this.lblDate.Location = new System.Drawing.Point(68, 244);
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
            this.lblStaffname.Location = new System.Drawing.Point(68, 151);
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
            this.lblAddAttendance.Location = new System.Drawing.Point(110, 33);
            this.lblAddAttendance.Name = "lblAddAttendance";
            this.lblAddAttendance.Size = new System.Drawing.Size(462, 42);
            this.lblAddAttendance.TabIndex = 0;
            this.lblAddAttendance.Text = "UPDATE  ATTENDANCE";
            // 
            // frmupdateAttendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 672);
            this.ControlBox = false;
            this.Controls.Add(this.connAttendance);
            this.Name = "frmupdateAttendance";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmupdateAttendance_Load);
            this.connAttendance.ResumeLayout(false);
            this.connAttendace1.ResumeLayout(false);
            this.connAttendace1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl connAttendance;
        private Guna.UI2.WinForms.Guna2ContainerControl connAttendace1;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnupdate1;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpCheckout;
        private System.Windows.Forms.Label lblCheckout;
        private System.Windows.Forms.Label lblCheckinn;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblStaffname;
        private System.Windows.Forms.Label lblAddAttendance;
        private System.Windows.Forms.Label lblstaffname1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lbldate11;
        private System.Windows.Forms.Label lblcheckin;
    }
}