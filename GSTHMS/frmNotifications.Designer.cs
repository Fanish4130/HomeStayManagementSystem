namespace GSTHMS
{
    partial class frmNotifications
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.flpNotificationsVM = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHeaderNotificationVM = new Guna.UI2.WinForms.Guna2Panel();
            this.lblUnreadNotificationsVM = new System.Windows.Forms.Label();
            this.lblRecentNotificationVM = new System.Windows.Forms.Label();
            this.btnViewAllVM = new Guna.UI2.WinForms.Guna2Button();
            this.pnlMainVM = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlHeaderNotificationVM.SuspendLayout();
            this.pnlMainVM.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // flpNotificationsVM
            // 
            this.flpNotificationsVM.AutoScroll = true;
            this.flpNotificationsVM.BackColor = System.Drawing.Color.Gray;
            this.flpNotificationsVM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpNotificationsVM.Location = new System.Drawing.Point(3, 50);
            this.flpNotificationsVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpNotificationsVM.Name = "flpNotificationsVM";
            this.flpNotificationsVM.Size = new System.Drawing.Size(661, 235);
            this.flpNotificationsVM.TabIndex = 0;
            // 
            // pnlHeaderNotificationVM
            // 
            this.pnlHeaderNotificationVM.BackColor = System.Drawing.Color.Black;
            this.pnlHeaderNotificationVM.Controls.Add(this.lblUnreadNotificationsVM);
            this.pnlHeaderNotificationVM.Controls.Add(this.lblRecentNotificationVM);
            this.pnlHeaderNotificationVM.Location = new System.Drawing.Point(3, 4);
            this.pnlHeaderNotificationVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlHeaderNotificationVM.Name = "pnlHeaderNotificationVM";
            this.pnlHeaderNotificationVM.Size = new System.Drawing.Size(662, 40);
            this.pnlHeaderNotificationVM.TabIndex = 0;
            // 
            // lblUnreadNotificationsVM
            // 
            this.lblUnreadNotificationsVM.AutoSize = true;
            this.lblUnreadNotificationsVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnreadNotificationsVM.ForeColor = System.Drawing.Color.Red;
            this.lblUnreadNotificationsVM.Location = new System.Drawing.Point(469, 5);
            this.lblUnreadNotificationsVM.Name = "lblUnreadNotificationsVM";
            this.lblUnreadNotificationsVM.Size = new System.Drawing.Size(138, 32);
            this.lblUnreadNotificationsVM.TabIndex = 1;
            this.lblUnreadNotificationsVM.Text = "! Unread ";
            // 
            // lblRecentNotificationVM
            // 
            this.lblRecentNotificationVM.AutoSize = true;
            this.lblRecentNotificationVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecentNotificationVM.ForeColor = System.Drawing.Color.White;
            this.lblRecentNotificationVM.Location = new System.Drawing.Point(3, 5);
            this.lblRecentNotificationVM.Name = "lblRecentNotificationVM";
            this.lblRecentNotificationVM.Size = new System.Drawing.Size(288, 32);
            this.lblRecentNotificationVM.TabIndex = 0;
            this.lblRecentNotificationVM.Text = "Recent Notifications";
            // 
            // btnViewAllVM
            // 
            this.btnViewAllVM.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnViewAllVM.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllVM.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllVM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewAllVM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewAllVM.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnViewAllVM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAllVM.ForeColor = System.Drawing.Color.White;
            this.btnViewAllVM.Location = new System.Drawing.Point(233, 289);
            this.btnViewAllVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnViewAllVM.Name = "btnViewAllVM";
            this.btnViewAllVM.Size = new System.Drawing.Size(180, 45);
            this.btnViewAllVM.TabIndex = 1;
            this.btnViewAllVM.Text = "View All";
            this.btnViewAllVM.Click += new System.EventHandler(this.btnViewAll_Click);
            // 
            // pnlMainVM
            // 
            this.pnlMainVM.AutoScroll = true;
            this.pnlMainVM.Controls.Add(this.flpNotificationsVM);
            this.pnlMainVM.Controls.Add(this.btnViewAllVM);
            this.pnlMainVM.Controls.Add(this.pnlHeaderNotificationVM);
            this.pnlMainVM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainVM.Location = new System.Drawing.Point(0, 0);
            this.pnlMainVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainVM.Name = "pnlMainVM";
            this.pnlMainVM.Size = new System.Drawing.Size(681, 345);
            this.pnlMainVM.TabIndex = 2;
            this.pnlMainVM.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainVM_Paint);
            // 
            // frmNotifications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 345);
            this.Controls.Add(this.pnlMainVM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmNotifications";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "frmNotificationsVM";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmNotifications_Load);
            this.pnlHeaderNotificationVM.ResumeLayout(false);
            this.pnlHeaderNotificationVM.PerformLayout();
            this.pnlMainVM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.FlowLayoutPanel flpNotificationsVM;
        private Guna.UI2.WinForms.Guna2Panel pnlHeaderNotificationVM;
        private System.Windows.Forms.Label lblUnreadNotificationsVM;
        private System.Windows.Forms.Label lblRecentNotificationVM;
        private Guna.UI2.WinForms.Guna2Button btnViewAllVM;
        private Guna.UI2.WinForms.Guna2Panel pnlMainVM;
    }
}