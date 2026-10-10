namespace GSTHMS
{
    partial class frmInventoryOverView
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
            this.btnViewAllVendor = new Guna.UI2.WinForms.Guna2Button();
            this.btnViewAllInventory = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddNewInventory = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstLowStockAlert = new System.Windows.Forms.ListView();
            this.InvName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblTotalStockValue = new System.Windows.Forms.Label();
            this.guna2PictureBox3 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblLowStockItems = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbltotalcount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CustomGradientPanel3 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel2 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel2.SuspendLayout();
            this.guna2CustomGradientPanel3.SuspendLayout();
            this.guna2CustomGradientPanel2.SuspendLayout();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewAllVendor
            // 
            this.btnViewAllVendor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllVendor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllVendor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewAllVendor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewAllVendor.FillColor = System.Drawing.Color.DimGray;
            this.btnViewAllVendor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewAllVendor.ForeColor = System.Drawing.Color.White;
            this.btnViewAllVendor.Location = new System.Drawing.Point(643, 300);
            this.btnViewAllVendor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewAllVendor.Name = "btnViewAllVendor";
            this.btnViewAllVendor.Size = new System.Drawing.Size(240, 55);
            this.btnViewAllVendor.TabIndex = 1;
            this.btnViewAllVendor.Text = "View All Vendor";
            this.btnViewAllVendor.Click += new System.EventHandler(this.btnViewAllVendor_Click);
            // 
            // btnViewAllInventory
            // 
            this.btnViewAllInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnViewAllInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnViewAllInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnViewAllInventory.FillColor = System.Drawing.Color.DimGray;
            this.btnViewAllInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnViewAllInventory.ForeColor = System.Drawing.Color.White;
            this.btnViewAllInventory.Location = new System.Drawing.Point(984, 300);
            this.btnViewAllInventory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnViewAllInventory.Name = "btnViewAllInventory";
            this.btnViewAllInventory.Size = new System.Drawing.Size(240, 55);
            this.btnViewAllInventory.TabIndex = 2;
            this.btnViewAllInventory.Text = "View All Inventory";
            this.btnViewAllInventory.Click += new System.EventHandler(this.btnViewAllInventory_Click);
            // 
            // btnAddNewInventory
            // 
            this.btnAddNewInventory.BorderColor = System.Drawing.Color.DimGray;
            this.btnAddNewInventory.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInventory.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddNewInventory.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddNewInventory.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddNewInventory.FillColor = System.Drawing.Color.DimGray;
            this.btnAddNewInventory.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnAddNewInventory.ForeColor = System.Drawing.Color.White;
            this.btnAddNewInventory.Location = new System.Drawing.Point(316, 300);
            this.btnAddNewInventory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddNewInventory.Name = "btnAddNewInventory";
            this.btnAddNewInventory.Size = new System.Drawing.Size(240, 55);
            this.btnAddNewInventory.TabIndex = 3;
            this.btnAddNewInventory.Text = "+ Add New Inventory";
            this.btnAddNewInventory.Click += new System.EventHandler(this.btnAddNewInventory_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 42);
            this.label3.TabIndex = 9;
            this.label3.Text = "Inventory Overview";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.IndianRed;
            this.label1.Location = new System.Drawing.Point(107, 404);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(306, 39);
            this.label1.TabIndex = 10;
            this.label1.Text = "! Low Stock Alerts";
            // 
            // lstLowStockAlert
            // 
            this.lstLowStockAlert.AllowColumnReorder = true;
            this.lstLowStockAlert.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.InvName,
            this.Quantity});
            this.lstLowStockAlert.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLowStockAlert.FullRowSelect = true;
            this.lstLowStockAlert.GridLines = true;
            this.lstLowStockAlert.HideSelection = false;
            this.lstLowStockAlert.Location = new System.Drawing.Point(351, 460);
            this.lstLowStockAlert.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstLowStockAlert.Name = "lstLowStockAlert";
            this.lstLowStockAlert.Size = new System.Drawing.Size(800, 355);
            this.lstLowStockAlert.TabIndex = 11;
            this.lstLowStockAlert.UseCompatibleStateImageBehavior = false;
            this.lstLowStockAlert.View = System.Windows.Forms.View.Details;
            this.lstLowStockAlert.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstLowStockAlert_AfterLabelEdit);
            this.lstLowStockAlert.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lstLowStockAlert_BeforeLabelEdit);
            this.lstLowStockAlert.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.lstLowStockAlert_DrawColumnHeader);
            this.lstLowStockAlert.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.lstLowStockAlert_DrawItem);
            this.lstLowStockAlert.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.lstLowStockAlert_DrawSubItem);
            this.lstLowStockAlert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lstLowStockAlert_KeyDown);
            this.lstLowStockAlert.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lstLowStockAlert_MouseDown);
            // 
            // InvName
            // 
            this.InvName.Text = "Inventory Name";
            this.InvName.Width = 300;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Quantity.Width = 300;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(32, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(218, 29);
            this.label7.TabIndex = 3;
            this.label7.Text = "Total Stock Value";
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = global::GSTHMS.Properties.Resources.icons8_stock_share_48;
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(271, 12);
            this.guna2PictureBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(49, 44);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 14;
            this.guna2PictureBox2.TabStop = false;
            // 
            // lblTotalStockValue
            // 
            this.lblTotalStockValue.AutoSize = true;
            this.lblTotalStockValue.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalStockValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalStockValue.ForeColor = System.Drawing.Color.Black;
            this.lblTotalStockValue.Location = new System.Drawing.Point(125, 86);
            this.lblTotalStockValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalStockValue.Name = "lblTotalStockValue";
            this.lblTotalStockValue.Size = new System.Drawing.Size(86, 31);
            this.lblTotalStockValue.TabIndex = 2;
            this.lblTotalStockValue.Text = "label6";
            this.lblTotalStockValue.Click += new System.EventHandler(this.lblTotalStockValue_Click);
            // 
            // guna2PictureBox3
            // 
            this.guna2PictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox3.Image = global::GSTHMS.Properties.Resources.icons8_low_price_50__1_;
            this.guna2PictureBox3.ImageRotate = 0F;
            this.guna2PictureBox3.Location = new System.Drawing.Point(275, 23);
            this.guna2PictureBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PictureBox3.Name = "guna2PictureBox3";
            this.guna2PictureBox3.Size = new System.Drawing.Size(53, 33);
            this.guna2PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox3.TabIndex = 15;
            this.guna2PictureBox3.TabStop = false;
            // 
            // lblLowStockItems
            // 
            this.lblLowStockItems.AutoSize = true;
            this.lblLowStockItems.BackColor = System.Drawing.Color.Transparent;
            this.lblLowStockItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockItems.ForeColor = System.Drawing.Color.Black;
            this.lblLowStockItems.Location = new System.Drawing.Point(132, 86);
            this.lblLowStockItems.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLowStockItems.Name = "lblLowStockItems";
            this.lblLowStockItems.Size = new System.Drawing.Size(86, 31);
            this.lblLowStockItems.TabIndex = 14;
            this.lblLowStockItems.Text = "label8";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label5.Location = new System.Drawing.Point(23, 23);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 29);
            this.label5.TabIndex = 2;
            this.label5.Text = "Items Low in Stock";
            // 
            // lbltotalcount
            // 
            this.lbltotalcount.AutoSize = true;
            this.lbltotalcount.BackColor = System.Drawing.Color.Transparent;
            this.lbltotalcount.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalcount.ForeColor = System.Drawing.Color.Black;
            this.lbltotalcount.Location = new System.Drawing.Point(124, 86);
            this.lbltotalcount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltotalcount.Name = "lbltotalcount";
            this.lbltotalcount.Size = new System.Drawing.Size(86, 31);
            this.lbltotalcount.TabIndex = 0;
            this.lbltotalcount.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(87, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 29);
            this.label4.TabIndex = 1;
            this.label4.Text = "Total Items";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::GSTHMS.Properties.Resources.icons8_item_50;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(257, 23);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(53, 30);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 14;
            this.guna2PictureBox1.TabStop = false;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2Panel2.BackColor = System.Drawing.Color.Snow;
            this.guna2Panel2.BorderColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.BorderRadius = 1;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.guna2CustomGradientPanel3);
            this.guna2Panel2.Controls.Add(this.guna2CustomGradientPanel2);
            this.guna2Panel2.Controls.Add(this.guna2CustomGradientPanel1);
            this.guna2Panel2.FillColor = System.Drawing.Color.Transparent;
            this.guna2Panel2.Location = new System.Drawing.Point(16, 46);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1505, 188);
            this.guna2Panel2.TabIndex = 14;
            // 
            // guna2CustomGradientPanel3
            // 
            this.guna2CustomGradientPanel3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel3.Controls.Add(this.lblTotalStockValue);
            this.guna2CustomGradientPanel3.Controls.Add(this.guna2PictureBox2);
            this.guna2CustomGradientPanel3.Controls.Add(this.label7);
            this.guna2CustomGradientPanel3.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel3.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel3.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel3.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel3.ForeColor = System.Drawing.Color.Black;
            this.guna2CustomGradientPanel3.Location = new System.Drawing.Point(1053, 16);
            this.guna2CustomGradientPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CustomGradientPanel3.Name = "guna2CustomGradientPanel3";
            this.guna2CustomGradientPanel3.Size = new System.Drawing.Size(339, 142);
            this.guna2CustomGradientPanel3.TabIndex = 15;
            // 
            // guna2CustomGradientPanel2
            // 
            this.guna2CustomGradientPanel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel2.Controls.Add(this.guna2PictureBox3);
            this.guna2CustomGradientPanel2.Controls.Add(this.lblLowStockItems);
            this.guna2CustomGradientPanel2.Controls.Add(this.label5);
            this.guna2CustomGradientPanel2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel2.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel2.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel2.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel2.ForeColor = System.Drawing.Color.Black;
            this.guna2CustomGradientPanel2.Location = new System.Drawing.Point(583, 16);
            this.guna2CustomGradientPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CustomGradientPanel2.Name = "guna2CustomGradientPanel2";
            this.guna2CustomGradientPanel2.Size = new System.Drawing.Size(339, 142);
            this.guna2CustomGradientPanel2.TabIndex = 16;
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2CustomGradientPanel1.Controls.Add(this.label4);
            this.guna2CustomGradientPanel1.Controls.Add(this.guna2PictureBox1);
            this.guna2CustomGradientPanel1.Controls.Add(this.lbltotalcount);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel1.FillColor4 = System.Drawing.Color.FromArgb(((int)(((byte)(144)))), ((int)(((byte)(117)))), ((int)(((byte)(255)))));
            this.guna2CustomGradientPanel1.ForeColor = System.Drawing.Color.Black;
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(113, 16);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(339, 142);
            this.guna2CustomGradientPanel1.TabIndex = 15;
            this.guna2CustomGradientPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2CustomGradientPanel1_Paint);
            // 
            // frmInventoryOverView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1537, 860);
            this.ControlBox = false;
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.lstLowStockAlert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAddNewInventory);
            this.Controls.Add(this.btnViewAllInventory);
            this.Controls.Add(this.btnViewAllVendor);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmInventoryOverView";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel2.ResumeLayout(false);
            this.guna2CustomGradientPanel3.ResumeLayout(false);
            this.guna2CustomGradientPanel3.PerformLayout();
            this.guna2CustomGradientPanel2.ResumeLayout(false);
            this.guna2CustomGradientPanel2.PerformLayout();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button btnViewAllVendor;
        private Guna.UI2.WinForms.Guna2Button btnViewAllInventory;
        private Guna.UI2.WinForms.Guna2Button btnAddNewInventory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lstLowStockAlert;
        private System.Windows.Forms.ColumnHeader InvName;
        private System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTotalStockValue;
        private System.Windows.Forms.Label lblLowStockItems;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbltotalcount;
        private System.Windows.Forms.Label label4;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox3;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel2;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel3;
    }
}

