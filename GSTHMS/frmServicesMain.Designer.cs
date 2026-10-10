namespace GSTHMS
{
    partial class frmServicesMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewFoodServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provideFoodServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parkingServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMainServices = new Guna.UI2.WinForms.Guna2Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewFoodServiceToolStripMenuItem,
            this.provideFoodServiceToolStripMenuItem,
            this.parkingServiceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // viewFoodServiceToolStripMenuItem
            // 
            this.viewFoodServiceToolStripMenuItem.Name = "viewFoodServiceToolStripMenuItem";
            this.viewFoodServiceToolStripMenuItem.Size = new System.Drawing.Size(172, 29);
            this.viewFoodServiceToolStripMenuItem.Text = "View Food Service";
            this.viewFoodServiceToolStripMenuItem.Click += new System.EventHandler(this.viewFoodServiceToolStripMenuItem_Click);
            // 
            // provideFoodServiceToolStripMenuItem
            // 
            this.provideFoodServiceToolStripMenuItem.Name = "provideFoodServiceToolStripMenuItem";
            this.provideFoodServiceToolStripMenuItem.Size = new System.Drawing.Size(195, 29);
            this.provideFoodServiceToolStripMenuItem.Text = "Provide Food Service";
            this.provideFoodServiceToolStripMenuItem.Click += new System.EventHandler(this.provideFoodServiceToolStripMenuItem_Click);
            // 
            // parkingServiceToolStripMenuItem
            // 
            this.parkingServiceToolStripMenuItem.Name = "parkingServiceToolStripMenuItem";
            this.parkingServiceToolStripMenuItem.Size = new System.Drawing.Size(146, 29);
            this.parkingServiceToolStripMenuItem.Text = "Parking Service";
            this.parkingServiceToolStripMenuItem.Click += new System.EventHandler(this.parkingServiceToolStripMenuItem_Click);
            // 
            // pnlMainServices
            // 
            this.pnlMainServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMainServices.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlMainServices.Location = new System.Drawing.Point(0, 36);
            this.pnlMainServices.Name = "pnlMainServices";
            this.pnlMainServices.Size = new System.Drawing.Size(1145, 539);
            this.pnlMainServices.TabIndex = 1;
            this.pnlMainServices.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainServices_Paint);
            // 
            // frmServicesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1147, 682);
            this.Controls.Add(this.pnlMainServices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmServicesMain";
            this.Text = "frmServicesMain";
            this.Load += new System.EventHandler(this.frmServicesMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewFoodServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem provideFoodServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parkingServiceToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2Panel pnlMainServices;
    }
}