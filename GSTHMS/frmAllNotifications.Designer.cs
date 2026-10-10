namespace GSTHMS
{
    partial class frmAllNotificationsVM
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlMainAllNotificationVM = new Guna.UI2.WinForms.Guna2Panel();
            this.cmbbxFilterVM = new Guna.UI2.WinForms.Guna2ComboBox();
            this.btnCloseVM = new Guna.UI2.WinForms.Guna2Button();
            this.lblAllNotificationsVM = new System.Windows.Forms.Label();
            this.grdAllNotificationsVM = new Guna.UI2.WinForms.Guna2DataGridView();
            this.pnlMainAllNotificationVM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllNotificationsVM)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainAllNotificationVM
            // 
            this.pnlMainAllNotificationVM.Controls.Add(this.cmbbxFilterVM);
            this.pnlMainAllNotificationVM.Controls.Add(this.btnCloseVM);
            this.pnlMainAllNotificationVM.Controls.Add(this.lblAllNotificationsVM);
            this.pnlMainAllNotificationVM.Controls.Add(this.grdAllNotificationsVM);
            this.pnlMainAllNotificationVM.Location = new System.Drawing.Point(0, 0);
            this.pnlMainAllNotificationVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainAllNotificationVM.Name = "pnlMainAllNotificationVM";
            this.pnlMainAllNotificationVM.Size = new System.Drawing.Size(1147, 682);
            this.pnlMainAllNotificationVM.TabIndex = 0;
            this.pnlMainAllNotificationVM.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlMainAllNotificationVM_Paint);
            // 
            // cmbbxFilterVM
            // 
            this.cmbbxFilterVM.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxFilterVM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxFilterVM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxFilterVM.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxFilterVM.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxFilterVM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbbxFilterVM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxFilterVM.ItemHeight = 30;
            this.cmbbxFilterVM.Items.AddRange(new object[] {
            "All",
            "Read",
            "Unread"});
            this.cmbbxFilterVM.Location = new System.Drawing.Point(873, 31);
            this.cmbbxFilterVM.Name = "cmbbxFilterVM";
            this.cmbbxFilterVM.Size = new System.Drawing.Size(250, 36);
            this.cmbbxFilterVM.TabIndex = 4;
            this.cmbbxFilterVM.SelectedIndexChanged += new System.EventHandler(this.cmbbxFilterVM_SelectedIndexChanged);
            // 
            // btnCloseVM
            // 
            this.btnCloseVM.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseVM.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCloseVM.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCloseVM.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCloseVM.FillColor = System.Drawing.Color.Red;
            this.btnCloseVM.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseVM.ForeColor = System.Drawing.Color.White;
            this.btnCloseVM.Location = new System.Drawing.Point(509, 604);
            this.btnCloseVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCloseVM.Name = "btnCloseVM";
            this.btnCloseVM.Size = new System.Drawing.Size(180, 45);
            this.btnCloseVM.TabIndex = 0;
            this.btnCloseVM.Text = "Close";
            this.btnCloseVM.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblAllNotificationsVM
            // 
            this.lblAllNotificationsVM.AutoSize = true;
            this.lblAllNotificationsVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAllNotificationsVM.Location = new System.Drawing.Point(12, 31);
            this.lblAllNotificationsVM.Name = "lblAllNotificationsVM";
            this.lblAllNotificationsVM.Size = new System.Drawing.Size(338, 52);
            this.lblAllNotificationsVM.TabIndex = 3;
            this.lblAllNotificationsVM.Text = "All Notifications";
            // 
            // grdAllNotificationsVM
            // 
            this.grdAllNotificationsVM.AllowUserToResizeColumns = false;
            this.grdAllNotificationsVM.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.grdAllNotificationsVM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.grdAllNotificationsVM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAllNotificationsVM.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAllNotificationsVM.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.grdAllNotificationsVM.ColumnHeadersHeight = 30;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdAllNotificationsVM.DefaultCellStyle = dataGridViewCellStyle8;
            this.grdAllNotificationsVM.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdAllNotificationsVM.Location = new System.Drawing.Point(12, 131);
            this.grdAllNotificationsVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdAllNotificationsVM.Name = "grdAllNotificationsVM";
            this.grdAllNotificationsVM.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.ButtonShadow;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdAllNotificationsVM.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.grdAllNotificationsVM.RowHeadersVisible = false;
            this.grdAllNotificationsVM.RowHeadersWidth = 62;
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.grdAllNotificationsVM.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.grdAllNotificationsVM.RowTemplate.Height = 28;
            this.grdAllNotificationsVM.Size = new System.Drawing.Size(1120, 433);
            this.grdAllNotificationsVM.TabIndex = 0;
            this.grdAllNotificationsVM.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAllNotificationsVM.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.grdAllNotificationsVM.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.grdAllNotificationsVM.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.grdAllNotificationsVM.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.grdAllNotificationsVM.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.grdAllNotificationsVM.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdAllNotificationsVM.ThemeStyle.HeaderStyle.Height = 30;
            this.grdAllNotificationsVM.ThemeStyle.ReadOnly = true;
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.Height = 28;
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.grdAllNotificationsVM.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.grdAllNotificationsVM.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllNotifications_CellClick);
            this.grdAllNotificationsVM.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.grdAllNotifications_RowPrePaint);
            // 
            // frmAllNotificationsVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1147, 682);
            this.ControlBox = false;
            this.Controls.Add(this.pnlMainAllNotificationVM);
            this.Location = new System.Drawing.Point(1237, 99);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAllNotificationsVM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAllNotifications_Load);
            this.pnlMainAllNotificationVM.ResumeLayout(false);
            this.pnlMainAllNotificationVM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllNotificationsVM)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnlMainAllNotificationVM;
        private Guna.UI2.WinForms.Guna2Button btnCloseVM;
        private System.Windows.Forms.Label lblAllNotificationsVM;
        private Guna.UI2.WinForms.Guna2DataGridView grdAllNotificationsVM;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxFilterVM;
    }
}