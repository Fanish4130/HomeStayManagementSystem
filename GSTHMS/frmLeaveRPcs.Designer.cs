namespace GSTHMS
{
    partial class frmLeaveRPcs
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
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlRP = new Guna.UI2.WinForms.Guna2Panel();
            this.btnleave = new Guna.UI2.WinForms.Guna2Button();
            this.btnAttendance = new Guna.UI2.WinForms.Guna2Button();
            this.btnTask = new Guna.UI2.WinForms.Guna2Button();
            this.label5 = new System.Windows.Forms.Label();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.btnstaffdetails = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Controls.Add(this.btnstaffdetails);
            this.guna2Panel2.Controls.Add(this.pnlRP);
            this.guna2Panel2.Controls.Add(this.btnleave);
            this.guna2Panel2.Controls.Add(this.btnAttendance);
            this.guna2Panel2.Controls.Add(this.btnTask);
            this.guna2Panel2.Controls.Add(this.label5);
            this.guna2Panel2.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2Panel2.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1284, 816);
            this.guna2Panel2.TabIndex = 4;
            this.guna2Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.guna2Panel2_Paint);
            // 
            // pnlRP
            // 
            this.pnlRP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlRP.Location = new System.Drawing.Point(3, 72);
            this.pnlRP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlRP.Name = "pnlRP";
            this.pnlRP.Size = new System.Drawing.Size(1277, 741);
            this.pnlRP.TabIndex = 45;
            // 
            // btnleave
            // 
            this.btnleave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnleave.Animated = true;
            this.btnleave.BorderColor = System.Drawing.Color.DimGray;
            this.btnleave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnleave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnleave.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnleave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnleave.FillColor = System.Drawing.Color.DimGray;
            this.btnleave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnleave.ForeColor = System.Drawing.Color.White;
            this.btnleave.Location = new System.Drawing.Point(614, 22);
            this.btnleave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnleave.Name = "btnleave";
            this.btnleave.PressedColor = System.Drawing.Color.DimGray;
            this.btnleave.Size = new System.Drawing.Size(180, 46);
            this.btnleave.TabIndex = 44;
            this.btnleave.Text = "Leave";
            this.btnleave.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this.btnleave.Click += new System.EventHandler(this.guna2Button4_Click);
            // 
            // btnAttendance
            // 
            this.btnAttendance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttendance.BorderColor = System.Drawing.Color.DimGray;
            this.btnAttendance.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendance.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAttendance.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAttendance.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAttendance.FillColor = System.Drawing.Color.DimGray;
            this.btnAttendance.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnAttendance.ForeColor = System.Drawing.Color.White;
            this.btnAttendance.Location = new System.Drawing.Point(800, 22);
            this.btnAttendance.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAttendance.Name = "btnAttendance";
            this.btnAttendance.Size = new System.Drawing.Size(180, 46);
            this.btnAttendance.TabIndex = 43;
            this.btnAttendance.Text = "Attendance";
            this.btnAttendance.Click += new System.EventHandler(this.guna2Button3_Click);
            // 
            // btnTask
            // 
            this.btnTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTask.BorderColor = System.Drawing.Color.DimGray;
            this.btnTask.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTask.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTask.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTask.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTask.FillColor = System.Drawing.Color.DimGray;
            this.btnTask.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnTask.ForeColor = System.Drawing.Color.White;
            this.btnTask.Location = new System.Drawing.Point(986, 22);
            this.btnTask.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTask.Name = "btnTask";
            this.btnTask.Size = new System.Drawing.Size(180, 46);
            this.btnTask.TabIndex = 42;
            this.btnTask.Text = "Task";
            this.btnTask.Click += new System.EventHandler(this.guna2Button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(685, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 16);
            this.label5.TabIndex = 20;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(283, 11);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(3, 2);
            this.guna2HtmlLabel2.TabIndex = 9;
            this.guna2HtmlLabel2.Text = null;
            // 
            // btnstaffdetails
            // 
            this.btnstaffdetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnstaffdetails.Animated = true;
            this.btnstaffdetails.BorderColor = System.Drawing.Color.DimGray;
            this.btnstaffdetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnstaffdetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnstaffdetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnstaffdetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnstaffdetails.FillColor = System.Drawing.Color.DimGray;
            this.btnstaffdetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnstaffdetails.ForeColor = System.Drawing.Color.White;
            this.btnstaffdetails.Location = new System.Drawing.Point(428, 22);
            this.btnstaffdetails.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnstaffdetails.Name = "btnstaffdetails";
            this.btnstaffdetails.PressedColor = System.Drawing.Color.DimGray;
            this.btnstaffdetails.Size = new System.Drawing.Size(180, 46);
            this.btnstaffdetails.TabIndex = 46;
            this.btnstaffdetails.Text = "Staff Details";
            this.btnstaffdetails.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            // 
            // frmLeaveRPcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 816);
            this.Controls.Add(this.guna2Panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmLeaveRPcs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmLeaveRPcs_Load);
            this.guna2Panel2.ResumeLayout(false);
            this.guna2Panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Button btnleave;
        private Guna.UI2.WinForms.Guna2Button btnAttendance;
        private Guna.UI2.WinForms.Guna2Button btnTask;
        private Guna.UI2.WinForms.Guna2Panel pnlRP;
        private Guna.UI2.WinForms.Guna2Button btnstaffdetails;
    }
}