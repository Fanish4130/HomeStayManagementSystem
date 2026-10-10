namespace GSTHMS
{
    partial class log
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(log));
            this.txtUsername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtPassward = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnhidepass = new Guna.UI2.WinForms.Guna2Button();
            this.btnLogin = new Guna.UI2.WinForms.Guna2Button();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnShowpass = new Guna.UI2.WinForms.Guna2Button();
            this.panelerroe = new Guna.UI2.WinForms.Guna2Panel();
            this.lblerror = new System.Windows.Forms.Label();
            this.panelsuccess = new Guna.UI2.WinForms.Guna2Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblsuccess = new System.Windows.Forms.Label();
            this.timerdrag = new System.Windows.Forms.Timer(this.components);
            this.pnlforgate = new Guna.UI2.WinForms.Guna2Panel();
            this.lblforgate = new System.Windows.Forms.Label();
            this.panelerroe.SuspendLayout();
            this.panelsuccess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlforgate.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Transparent;
            this.txtUsername.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(221)))), ((int)(((byte)(221)))));
            this.txtUsername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUsername.DefaultText = "";
            this.txtUsername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUsername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUsername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUsername.FillColor = System.Drawing.Color.Gainsboro;
            this.txtUsername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.ForeColor = System.Drawing.Color.RosyBrown;
            this.txtUsername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUsername.Location = new System.Drawing.Point(1355, 431);
            this.txtUsername.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtUsername.PlaceholderText = "Enter The UserName";
            this.txtUsername.SelectedText = "";
            this.txtUsername.Size = new System.Drawing.Size(411, 70);
            this.txtUsername.TabIndex = 1;
            this.txtUsername.WordWrap = false;
            this.txtUsername.TextChanged += new System.EventHandler(this.txtUsername_TextChanged);
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave_1);
            // 
            // txtPassward
            // 
            this.txtPassward.BackColor = System.Drawing.Color.LightGray;
            this.txtPassward.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtPassward.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassward.DefaultText = "";
            this.txtPassward.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassward.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassward.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassward.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassward.FillColor = System.Drawing.Color.LightGray;
            this.txtPassward.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassward.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassward.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassward.Location = new System.Drawing.Point(1355, 571);
            this.txtPassward.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtPassward.Name = "txtPassward";
            this.txtPassward.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtPassward.PlaceholderText = "Enter The Password";
            this.txtPassward.SelectedText = "";
            this.txtPassward.Size = new System.Drawing.Size(411, 70);
            this.txtPassward.TabIndex = 2;
            this.txtPassward.WordWrap = false;
            this.txtPassward.TextChanged += new System.EventHandler(this.txtPassward_TextChanged);
            this.txtPassward.Enter += new System.EventHandler(this.txtPassward_Enter);
            this.txtPassward.Leave += new System.EventHandler(this.txtPassward_Leave);
            // 
            // btnhidepass
            // 
            this.btnhidepass.BackColor = System.Drawing.Color.Gray;
            this.btnhidepass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnhidepass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnhidepass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnhidepass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnhidepass.FillColor = System.Drawing.Color.Gainsboro;
            this.btnhidepass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnhidepass.ForeColor = System.Drawing.Color.White;
            this.btnhidepass.Image = ((System.Drawing.Image)(resources.GetObject("btnhidepass.Image")));
            this.btnhidepass.Location = new System.Drawing.Point(1695, 571);
            this.btnhidepass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnhidepass.Name = "btnhidepass";
            this.btnhidepass.Size = new System.Drawing.Size(71, 70);
            this.btnhidepass.TabIndex = 15;
            this.btnhidepass.Click += new System.EventHandler(this.btnhidepass_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnLogin.BorderColor = System.Drawing.Color.DarkSeaGreen;
            this.btnLogin.BorderRadius = 20;
            this.btnLogin.BorderThickness = 2;
            this.btnLogin.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogin.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogin.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogin.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnLogin.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(1220, 729);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 79);
            this.btnLogin.TabIndex = 16;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.Transparent;
            this.btnClear.BorderColor = System.Drawing.Color.IndianRed;
            this.btnClear.BorderRadius = 20;
            this.btnClear.BorderThickness = 2;
            this.btnClear.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Tomato;
            this.btnClear.Font = new System.Drawing.Font("Arial Rounded MT Bold", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(1543, 729);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(260, 79);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(1420, 847);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(197, 29);
            this.linkLabel1.TabIndex = 18;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnShowpass
            // 
            this.btnShowpass.BackColor = System.Drawing.Color.Transparent;
            this.btnShowpass.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnShowpass.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnShowpass.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnShowpass.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnShowpass.FillColor = System.Drawing.Color.Gainsboro;
            this.btnShowpass.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnShowpass.ForeColor = System.Drawing.Color.White;
            this.btnShowpass.Image = ((System.Drawing.Image)(resources.GetObject("btnShowpass.Image")));
            this.btnShowpass.Location = new System.Drawing.Point(1695, 571);
            this.btnShowpass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnShowpass.Name = "btnShowpass";
            this.btnShowpass.Size = new System.Drawing.Size(71, 70);
            this.btnShowpass.TabIndex = 19;
            this.btnShowpass.Click += new System.EventHandler(this.btnShowpass_Click);
            // 
            // panelerroe
            // 
            this.panelerroe.AutoSize = true;
            this.panelerroe.BackColor = System.Drawing.Color.White;
            this.panelerroe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelerroe.BorderRadius = 5;
            this.panelerroe.BorderThickness = 1;
            this.panelerroe.Controls.Add(this.lblerror);
            this.panelerroe.Location = new System.Drawing.Point(943, 258);
            this.panelerroe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelerroe.Name = "panelerroe";
            this.panelerroe.Size = new System.Drawing.Size(331, 52);
            this.panelerroe.TabIndex = 20;
            this.panelerroe.Visible = false;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.BackColor = System.Drawing.Color.White;
            this.lblerror.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblerror.ForeColor = System.Drawing.Color.Red;
            this.lblerror.Location = new System.Drawing.Point(19, 14);
            this.lblerror.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(275, 23);
            this.lblerror.TabIndex = 0;
            this.lblerror.Text = "Invalid UserName And Password.. !";
            // 
            // panelsuccess
            // 
            this.panelsuccess.BackColor = System.Drawing.Color.White;
            this.panelsuccess.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelsuccess.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.panelsuccess.BorderThickness = 1;
            this.panelsuccess.Controls.Add(this.pictureBox1);
            this.panelsuccess.Location = new System.Drawing.Point(868, 530);
            this.panelsuccess.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelsuccess.Name = "panelsuccess";
            this.panelsuccess.Size = new System.Drawing.Size(365, 213);
            this.panelsuccess.TabIndex = 21;
            this.panelsuccess.Visible = false;
            this.panelsuccess.Paint += new System.Windows.Forms.PaintEventHandler(this.panelsuccess_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(363, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 23;
            this.pictureBox1.TabStop = false;
            // 
            // lblsuccess
            // 
            this.lblsuccess.AutoSize = true;
            this.lblsuccess.BackColor = System.Drawing.Color.White;
            this.lblsuccess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.lblsuccess.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsuccess.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblsuccess.Location = new System.Drawing.Point(243, 638);
            this.lblsuccess.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblsuccess.Name = "lblsuccess";
            this.lblsuccess.Size = new System.Drawing.Size(261, 32);
            this.lblsuccess.TabIndex = 0;
            this.lblsuccess.Text = "Login SuccessFully....!";
            this.lblsuccess.Visible = false;
            // 
            // timerdrag
            // 
            this.timerdrag.Interval = 2000;
            this.timerdrag.Tick += new System.EventHandler(this.timerdrag_Tick);
            // 
            // pnlforgate
            // 
            this.pnlforgate.AutoSize = true;
            this.pnlforgate.BackColor = System.Drawing.Color.White;
            this.pnlforgate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlforgate.BorderRadius = 5;
            this.pnlforgate.BorderThickness = 1;
            this.pnlforgate.Controls.Add(this.lblforgate);
            this.pnlforgate.Location = new System.Drawing.Point(943, 335);
            this.pnlforgate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlforgate.Name = "pnlforgate";
            this.pnlforgate.Size = new System.Drawing.Size(295, 52);
            this.pnlforgate.TabIndex = 22;
            this.pnlforgate.Visible = false;
            // 
            // lblforgate
            // 
            this.lblforgate.AutoSize = true;
            this.lblforgate.BackColor = System.Drawing.Color.White;
            this.lblforgate.Font = new System.Drawing.Font("Impact", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblforgate.ForeColor = System.Drawing.Color.Red;
            this.lblforgate.Location = new System.Drawing.Point(19, 14);
            this.lblforgate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblforgate.Name = "lblforgate";
            this.lblforgate.Size = new System.Drawing.Size(0, 23);
            this.lblforgate.TabIndex = 0;
            // 
            // log
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1545, 886);
            this.Controls.Add(this.pnlforgate);
            this.Controls.Add(this.lblsuccess);
            this.Controls.Add(this.panelsuccess);
            this.Controls.Add(this.panelerroe);
            this.Controls.Add(this.btnShowpass);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnhidepass);
            this.Controls.Add(this.txtPassward);
            this.Controls.Add(this.txtUsername);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "log";
            this.Text = "log";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.log_Load);
            this.panelerroe.ResumeLayout(false);
            this.panelerroe.PerformLayout();
            this.panelsuccess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlforgate.ResumeLayout(false);
            this.pnlforgate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2TextBox txtUsername;
        private Guna.UI2.WinForms.Guna2TextBox txtPassward;
        private Guna.UI2.WinForms.Guna2Button btnhidepass;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private Guna.UI2.WinForms.Guna2Button btnShowpass;
        private Guna.UI2.WinForms.Guna2Panel panelerroe;
        private System.Windows.Forms.Label lblerror;
        private Guna.UI2.WinForms.Guna2Panel panelsuccess;
        private System.Windows.Forms.Label lblsuccess;
        private System.Windows.Forms.Timer timerdrag;
        private Guna.UI2.WinForms.Guna2Panel pnlforgate;
        private System.Windows.Forms.Label lblforgate;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}