namespace GSTHMS
{
    partial class frmForgetPassward
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmForgetPassward));
            this.lblenterusername = new System.Windows.Forms.Label();
            this.lblmobilenumber = new System.Windows.Forms.Label();
            this.txtEnterusername = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnSendOTP = new Guna.UI2.WinForms.Guna2Button();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2CirclePictureBox3 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox1 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.guna2CirclePictureBox2 = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelotp = new Guna.UI2.WinForms.Guna2Panel();
            this.lblOtpsentsuccess = new System.Windows.Forms.Label();
            this.lblmsg = new System.Windows.Forms.Label();
            this.lblmsgs = new System.Windows.Forms.Label();
            this.pnlmsg = new Guna.UI2.WinForms.Guna2Panel();
            this.timerdragmsg = new System.Windows.Forms.Timer(this.components);
            this.pnlmsg2 = new Guna.UI2.WinForms.Guna2Panel();
            this.lblmsg2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).BeginInit();
            this.panelotp.SuspendLayout();
            this.pnlmsg.SuspendLayout();
            this.pnlmsg2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblenterusername
            // 
            this.lblenterusername.AutoSize = true;
            this.lblenterusername.BackColor = System.Drawing.Color.Transparent;
            this.lblenterusername.Location = new System.Drawing.Point(79, 117);
            this.lblenterusername.Name = "lblenterusername";
            this.lblenterusername.Size = new System.Drawing.Size(85, 13);
            this.lblenterusername.TabIndex = 0;
            this.lblenterusername.Text = "Enter UserName";
            // 
            // lblmobilenumber
            // 
            this.lblmobilenumber.AutoSize = true;
            this.lblmobilenumber.BackColor = System.Drawing.Color.Transparent;
            this.lblmobilenumber.Location = new System.Drawing.Point(79, 210);
            this.lblmobilenumber.Name = "lblmobilenumber";
            this.lblmobilenumber.Size = new System.Drawing.Size(46, 13);
            this.lblmobilenumber.TabIndex = 1;
            this.lblmobilenumber.Text = "Email ID";
            // 
            // txtEnterusername
            // 
            this.txtEnterusername.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEnterusername.DefaultText = "";
            this.txtEnterusername.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEnterusername.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEnterusername.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEnterusername.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEnterusername.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEnterusername.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEnterusername.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEnterusername.Location = new System.Drawing.Point(82, 133);
            this.txtEnterusername.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEnterusername.Name = "txtEnterusername";
            this.txtEnterusername.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtEnterusername.PlaceholderText = "Enter UserName ";
            this.txtEnterusername.SelectedText = "";
            this.txtEnterusername.Size = new System.Drawing.Size(200, 36);
            this.txtEnterusername.TabIndex = 2;
            this.txtEnterusername.TextChanged += new System.EventHandler(this.txtEnterusername_TextChanged);
            this.txtEnterusername.Click += new System.EventHandler(this.txtEnterusername_Click);
            // 
            // txtEmail
            // 
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(82, 226);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderForeColor = System.Drawing.Color.Gray;
            this.txtEmail.PlaceholderText = "Enter Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(200, 36);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.Click += new System.EventHandler(this.txtMobilenumber_Click);
            // 
            // btnSendOTP
            // 
            this.btnSendOTP.BackColor = System.Drawing.Color.Transparent;
            this.btnSendOTP.BorderRadius = 20;
            this.btnSendOTP.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSendOTP.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSendOTP.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSendOTP.FillColor = System.Drawing.Color.ForestGreen;
            this.btnSendOTP.Font = new System.Drawing.Font("Impact", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendOTP.ForeColor = System.Drawing.Color.White;
            this.btnSendOTP.Location = new System.Drawing.Point(71, 293);
            this.btnSendOTP.Name = "btnSendOTP";
            this.btnSendOTP.Size = new System.Drawing.Size(180, 45);
            this.btnSendOTP.TabIndex = 4;
            this.btnSendOTP.Text = "Send OTP";
            this.btnSendOTP.Click += new System.EventHandler(this.btnSendOTP_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.BackgroundImage")));
            this.guna2PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(86, 101);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(344, 397);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 5;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click);
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.guna2Panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("guna2Panel1.BackgroundImage")));
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox3);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox1);
            this.guna2Panel1.Controls.Add(this.guna2CirclePictureBox2);
            this.guna2Panel1.Controls.Add(this.label1);
            this.guna2Panel1.Controls.Add(this.txtEnterusername);
            this.guna2Panel1.Controls.Add(this.lblenterusername);
            this.guna2Panel1.Controls.Add(this.btnSendOTP);
            this.guna2Panel1.Controls.Add(this.txtEmail);
            this.guna2Panel1.Controls.Add(this.lblmobilenumber);
            this.guna2Panel1.Location = new System.Drawing.Point(425, 101);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(320, 397);
            this.guna2Panel1.TabIndex = 6;
            // 
            // guna2CirclePictureBox3
            // 
            this.guna2CirclePictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.guna2CirclePictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2CirclePictureBox3.ErrorImage = null;
            this.guna2CirclePictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox3.Image")));
            this.guna2CirclePictureBox3.ImageRotate = 0F;
            this.guna2CirclePictureBox3.Location = new System.Drawing.Point(151, 3);
            this.guna2CirclePictureBox3.Name = "guna2CirclePictureBox3";
            this.guna2CirclePictureBox3.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox3.Size = new System.Drawing.Size(58, 58);
            this.guna2CirclePictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox3.TabIndex = 14;
            this.guna2CirclePictureBox3.TabStop = false;
            this.guna2CirclePictureBox3.UseTransparentBackground = true;
            // 
            // guna2CirclePictureBox1
            // 
            this.guna2CirclePictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2CirclePictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2CirclePictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2CirclePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.Image")));
            this.guna2CirclePictureBox1.ImageRotate = 0F;
            this.guna2CirclePictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox1.InitialImage")));
            this.guna2CirclePictureBox1.Location = new System.Drawing.Point(48, 226);
            this.guna2CirclePictureBox1.Name = "guna2CirclePictureBox1";
            this.guna2CirclePictureBox1.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox1.Size = new System.Drawing.Size(37, 36);
            this.guna2CirclePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox1.TabIndex = 7;
            this.guna2CirclePictureBox1.TabStop = false;
            // 
            // guna2CirclePictureBox2
            // 
            this.guna2CirclePictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.guna2CirclePictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.guna2CirclePictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.guna2CirclePictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox2.Image")));
            this.guna2CirclePictureBox2.ImageRotate = 0F;
            this.guna2CirclePictureBox2.InitialImage = ((System.Drawing.Image)(resources.GetObject("guna2CirclePictureBox2.InitialImage")));
            this.guna2CirclePictureBox2.Location = new System.Drawing.Point(48, 133);
            this.guna2CirclePictureBox2.Name = "guna2CirclePictureBox2";
            this.guna2CirclePictureBox2.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.guna2CirclePictureBox2.Size = new System.Drawing.Size(37, 36);
            this.guna2CirclePictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2CirclePictureBox2.TabIndex = 6;
            this.guna2CirclePictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightPink;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "FORGOT PASSWORD";
            // 
            // panelotp
            // 
            this.panelotp.BackColor = System.Drawing.Color.White;
            this.panelotp.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panelotp.BorderRadius = 5;
            this.panelotp.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            this.panelotp.BorderThickness = 2;
            this.panelotp.Controls.Add(this.lblOtpsentsuccess);
            this.panelotp.CustomBorderColor = System.Drawing.Color.White;
            this.panelotp.Location = new System.Drawing.Point(294, 445);
            this.panelotp.Name = "panelotp";
            this.panelotp.Size = new System.Drawing.Size(205, 51);
            this.panelotp.TabIndex = 12;
            // 
            // lblOtpsentsuccess
            // 
            this.lblOtpsentsuccess.AutoSize = true;
            this.lblOtpsentsuccess.BackColor = System.Drawing.Color.White;
            this.lblOtpsentsuccess.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtpsentsuccess.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblOtpsentsuccess.Location = new System.Drawing.Point(20, 13);
            this.lblOtpsentsuccess.Name = "lblOtpsentsuccess";
            this.lblOtpsentsuccess.Size = new System.Drawing.Size(166, 20);
            this.lblOtpsentsuccess.TabIndex = 0;
            this.lblOtpsentsuccess.Text = "Sent OTP SuccessFully...!";
            // 
            // lblmsg
            // 
            this.lblmsg.AutoSize = true;
            this.lblmsg.Location = new System.Drawing.Point(480, 39);
            this.lblmsg.Name = "lblmsg";
            this.lblmsg.Size = new System.Drawing.Size(0, 13);
            this.lblmsg.TabIndex = 13;
            this.lblmsg.Visible = false;
            // 
            // lblmsgs
            // 
            this.lblmsgs.AutoSize = true;
            this.lblmsgs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsgs.Location = new System.Drawing.Point(17, 3);
            this.lblmsgs.Name = "lblmsgs";
            this.lblmsgs.Size = new System.Drawing.Size(57, 20);
            this.lblmsgs.TabIndex = 15;
            this.lblmsgs.Text = "label2";
            this.lblmsgs.Click += new System.EventHandler(this.lblmsgs_Click);
            // 
            // pnlmsg
            // 
            this.pnlmsg.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlmsg.Controls.Add(this.lblmsgs);
            this.pnlmsg.Location = new System.Drawing.Point(147, 116);
            this.pnlmsg.Name = "pnlmsg";
            this.pnlmsg.Size = new System.Drawing.Size(352, 33);
            this.pnlmsg.TabIndex = 16;
            // 
            // timerdragmsg
            // 
            this.timerdragmsg.Interval = 2000;
            this.timerdragmsg.Tick += new System.EventHandler(this.timerdragmsg_Tick);
            // 
            // pnlmsg2
            // 
            this.pnlmsg2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pnlmsg2.Controls.Add(this.lblmsg2);
            this.pnlmsg2.Location = new System.Drawing.Point(234, 184);
            this.pnlmsg2.Name = "pnlmsg2";
            this.pnlmsg2.Size = new System.Drawing.Size(221, 33);
            this.pnlmsg2.TabIndex = 17;
            // 
            // lblmsg2
            // 
            this.lblmsg2.AutoSize = true;
            this.lblmsg2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmsg2.Location = new System.Drawing.Point(17, 3);
            this.lblmsg2.Name = "lblmsg2";
            this.lblmsg2.Size = new System.Drawing.Size(57, 20);
            this.lblmsg2.TabIndex = 15;
            this.lblmsg2.Text = "label2";
            // 
            // frmForgetPassward
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(838, 575);
            this.Controls.Add(this.pnlmsg2);
            this.Controls.Add(this.pnlmsg);
            this.Controls.Add(this.panelotp);
            this.Controls.Add(this.lblmsg);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2PictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmForgetPassward";
            this.Text = "frmForgetPassward";
            this.Load += new System.EventHandler(this.frmForgetPassward_Load);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2CirclePictureBox2)).EndInit();
            this.panelotp.ResumeLayout(false);
            this.panelotp.PerformLayout();
            this.pnlmsg.ResumeLayout(false);
            this.pnlmsg.PerformLayout();
            this.pnlmsg2.ResumeLayout(false);
            this.pnlmsg2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblenterusername;
        private System.Windows.Forms.Label lblmobilenumber;
        private Guna.UI2.WinForms.Guna2TextBox txtEnterusername;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2Button btnSendOTP;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox2;
        private Guna.UI2.WinForms.Guna2Panel panelotp;
        private System.Windows.Forms.Label lblOtpsentsuccess;
        private System.Windows.Forms.Label lblmsg;
        private Guna.UI2.WinForms.Guna2CirclePictureBox guna2CirclePictureBox3;
        private System.Windows.Forms.Label lblmsgs;
        private Guna.UI2.WinForms.Guna2Panel pnlmsg;
        private System.Windows.Forms.Timer timerdragmsg;
        private Guna.UI2.WinForms.Guna2Panel pnlmsg2;
        private System.Windows.Forms.Label lblmsg2;
    }
}