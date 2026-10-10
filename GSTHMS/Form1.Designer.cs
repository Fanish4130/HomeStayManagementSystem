namespace GSTHMS
{
    partial class Form1
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
            this.guestReortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviceReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bookingReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.paymentReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eventReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.roomReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.staffReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanneContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guestReortToolStripMenuItem
            // 
            this.guestReortToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.guestReortToolStripMenuItem.Checked = true;
            this.guestReortToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.guestReortToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.guestReortToolStripMenuItem.Name = "guestReortToolStripMenuItem";
            this.guestReortToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.guestReortToolStripMenuItem.Text = "Guest Report";
            this.guestReortToolStripMenuItem.Click += new System.EventHandler(this.guestReortToolStripMenuItem_Click);
            // 
            // serviceReportToolStripMenuItem
            // 
            this.serviceReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.serviceReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.serviceReportToolStripMenuItem.Name = "serviceReportToolStripMenuItem";
            this.serviceReportToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.serviceReportToolStripMenuItem.Text = "Service Report";
            this.serviceReportToolStripMenuItem.Click += new System.EventHandler(this.serviceReportToolStripMenuItem_Click);
            // 
            // bookingReportToolStripMenuItem
            // 
            this.bookingReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.bookingReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.bookingReportToolStripMenuItem.Name = "bookingReportToolStripMenuItem";
            this.bookingReportToolStripMenuItem.Size = new System.Drawing.Size(101, 20);
            this.bookingReportToolStripMenuItem.Text = "Booking Report";
            this.bookingReportToolStripMenuItem.Click += new System.EventHandler(this.bookingReportToolStripMenuItem_Click);
            // 
            // inventoryReportToolStripMenuItem
            // 
            this.inventoryReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.inventoryReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.inventoryReportToolStripMenuItem.Name = "inventoryReportToolStripMenuItem";
            this.inventoryReportToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.inventoryReportToolStripMenuItem.Text = "Inventory Report";
            this.inventoryReportToolStripMenuItem.Click += new System.EventHandler(this.inventoryReportToolStripMenuItem_Click);
            // 
            // paymentReportToolStripMenuItem
            // 
            this.paymentReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.paymentReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.paymentReportToolStripMenuItem.Name = "paymentReportToolStripMenuItem";
            this.paymentReportToolStripMenuItem.Size = new System.Drawing.Size(104, 20);
            this.paymentReportToolStripMenuItem.Text = "Payment Report";
            this.paymentReportToolStripMenuItem.Click += new System.EventHandler(this.paymentReportToolStripMenuItem_Click);
            // 
            // eventReportToolStripMenuItem
            // 
            this.eventReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.eventReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.eventReportToolStripMenuItem.Name = "eventReportToolStripMenuItem";
            this.eventReportToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.eventReportToolStripMenuItem.Text = "Event Report";
            this.eventReportToolStripMenuItem.Click += new System.EventHandler(this.eventReportToolStripMenuItem_Click);
            // 
            // roomReportToolStripMenuItem
            // 
            this.roomReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.roomReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.roomReportToolStripMenuItem.Name = "roomReportToolStripMenuItem";
            this.roomReportToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.roomReportToolStripMenuItem.Text = "Room Report";
            this.roomReportToolStripMenuItem.Click += new System.EventHandler(this.roomReportToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.DimGray;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guestReortToolStripMenuItem,
            this.serviceReportToolStripMenuItem,
            this.bookingReportToolStripMenuItem,
            this.inventoryReportToolStripMenuItem,
            this.paymentReportToolStripMenuItem,
            this.eventReportToolStripMenuItem,
            this.roomReportToolStripMenuItem,
            this.staffReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 17;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // staffReportToolStripMenuItem
            // 
            this.staffReportToolStripMenuItem.BackColor = System.Drawing.Color.DimGray;
            this.staffReportToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.staffReportToolStripMenuItem.Name = "staffReportToolStripMenuItem";
            this.staffReportToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.staffReportToolStripMenuItem.Text = "Staff Report";
            this.staffReportToolStripMenuItem.Click += new System.EventHandler(this.staffReportToolStripMenuItem_Click);
            // 
            // PanneContainer
            // 
            this.PanneContainer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanneContainer.Location = new System.Drawing.Point(0, 24);
            this.PanneContainer.Name = "PanneContainer";
            this.PanneContainer.Size = new System.Drawing.Size(1028, 585);
            this.PanneContainer.TabIndex = 18;
            this.PanneContainer.Paint += new System.Windows.Forms.PaintEventHandler(this.PanneContainer_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1028, 609);
            this.Controls.Add(this.PanneContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem guestReortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviceReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bookingReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paymentReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eventReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem roomReportToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem staffReportToolStripMenuItem;
        public Guna.UI2.WinForms.Guna2Panel PanneContainer;
    }
}

