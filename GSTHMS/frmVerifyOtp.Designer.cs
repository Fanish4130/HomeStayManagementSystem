namespace GSTHMS
{
    partial class frmVerifyOtp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVerifyOtp));
            this.lblotp = new System.Windows.Forms.Label();
            this.txtenterotp = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnverifyotp = new Guna.UI2.WinForms.Guna2Button();
            this.lblsecond = new System.Windows.Forms.Label();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnresendotp = new Guna.UI2.WinForms.Guna2Button();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblotp
            // 
            this.lblotp.AutoSize = true;
            this.lblotp.BackColor = System.Drawing.Color.Transparent;
            this.lblotp.Location = new System.Drawing.Point(26, 80);
            this.lblotp.Name = "lblotp";
            this.lblotp.Size = new System.Drawing.Size(57, 13);
            this.lblotp.TabIndex = 0;
            this.lblotp.Text = "Enter OTP";
            // 
            // txtenterotp
            // 
            this.txtenterotp.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtenterotp.DefaultText = "";
            this.txtenterotp.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtenterotp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtenterotp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtenterotp.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtenterotp.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtenterotp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtenterotp.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtenterotp.Location = new System.Drawing.Point(63, 96);
            this.txtenterotp.Name = "txtenterotp";
            this.txtenterotp.PlaceholderText = "";
            this.txtenterotp.SelectedText = "";
            this.txtenterotp.Size = new System.Drawing.Size(200, 36);
            this.txtenterotp.TabIndex = 1;
            this.txtenterotp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtenterotp_KeyPress);
            // 
            // btnverifyotp
            // 
            this.btnverifyotp.BackColor = System.Drawing.Color.Transparent;
            this.btnverifyotp.BorderRadius = 20;
            this.btnverifyotp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnverifyotp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnverifyotp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnverifyotp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnverifyotp.FillColor = System.Drawing.Color.LightSeaGreen;
            this.btnverifyotp.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverifyotp.ForeColor = System.Drawing.Color.White;
            this.btnverifyotp.Location = new System.Drawing.Point(48, 219);
            this.btnverifyotp.Name = "btnverifyotp";
            this.btnverifyotp.Size = new System.Drawing.Size(180, 45);
            this.btnverifyotp.TabIndex = 2;
            this.btnverifyotp.Text = "Verify Otp";
            this.btnverifyotp.Click += new System.EventHandler(this.btnverifyotp_Click);
            // 
            // lblsecond
            // 
            this.lblsecond.AutoSize = true;
            this.lblsecond.BackColor = System.Drawing.Color.Transparent;
            this.lblsecond.Location = new System.Drawing.Point(221, 138);
            this.lblsecond.Name = "lblsecond";
            this.lblsecond.Size = new System.Drawing.Size(42, 13);
            this.lblsecond.TabIndex = 3;
            this.lblsecond.Text = "second";
            this.lblsecond.Click += new System.EventHandler(this.lblsecond_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.DarkGray;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2Panel1.Controls.Add(this.btnresendotp);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.Controls.Add(this.txtenterotp);
            this.guna2Panel1.Controls.Add(this.lblsecond);
            this.guna2Panel1.Controls.Add(this.lblotp);
            this.guna2Panel1.Controls.Add(this.btnverifyotp);
            this.guna2Panel1.FillColor = System.Drawing.Color.AliceBlue;
            this.guna2Panel1.Location = new System.Drawing.Point(443, 122);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(286, 382);
            this.guna2Panel1.TabIndex = 4;
            // 
            // btnresendotp
            // 
            this.btnresendotp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnresendotp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnresendotp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnresendotp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnresendotp.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnresendotp.ForeColor = System.Drawing.Color.White;
            this.btnresendotp.Location = new System.Drawing.Point(29, 138);
            this.btnresendotp.Name = "btnresendotp";
            this.btnresendotp.Size = new System.Drawing.Size(89, 24);
            this.btnresendotp.TabIndex = 9;
            this.btnresendotp.Text = "Resend OTP";
            this.btnresendotp.Click += new System.EventHandler(this.btnresendotp_Click);
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2CirclePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.InitialImage")));
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(29, 96);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(37, 36);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 8;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(125, 122);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(323, 382);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmVerifyOtp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 575);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.guna2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmVerifyOtp";
            this.Text = "frmVerifyOtp";
            this.Load += new System.EventHandler(this.frmVerifyOtp_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblotp;
        private Guna.UI2.WinForms.Guna2TextBox txtenterotp;
        private Guna.UI2.WinForms.Guna2Button btnverifyotp;
        private System.Windows.Forms.Label lblsecond;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnresendotp;
    }
}