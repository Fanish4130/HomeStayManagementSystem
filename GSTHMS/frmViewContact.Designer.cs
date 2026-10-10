namespace GSTHMS
{
    partial class frmViewContact
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
            this.lblEditContact = new System.Windows.Forms.Label();
            this.connGrey = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connWhite = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.lblVType = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.rtbContact = new System.Windows.Forms.RichTextBox();
            this.pctBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblVEmail = new System.Windows.Forms.Label();
            this.lblVContact = new System.Windows.Forms.Label();
            this.lblVName = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tipContact = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.connGrey.SuspendLayout();
            this.connWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEditContact
            // 
            this.lblEditContact.AutoSize = true;
            this.lblEditContact.BackColor = System.Drawing.Color.Transparent;
            this.lblEditContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditContact.Location = new System.Drawing.Point(395, 24);
            this.lblEditContact.Name = "lblEditContact";
            this.lblEditContact.Size = new System.Drawing.Size(342, 52);
            this.lblEditContact.TabIndex = 2;
            this.lblEditContact.Text = " Contact Details";
            this.lblEditContact.Click += new System.EventHandler(this.lblEditContact_Click);
            // 
            // connGrey
            // 
            this.connGrey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.connGrey.Controls.Add(this.connWhite);
            this.connGrey.FillColor = System.Drawing.Color.Gray;
            this.connGrey.Location = new System.Drawing.Point(-2, -1);
            this.connGrey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connGrey.Name = "connGrey";
            this.connGrey.Size = new System.Drawing.Size(1150, 728);
            this.connGrey.TabIndex = 3;
            this.connGrey.Text = "guna2ContainerControl1";
            this.connGrey.Click += new System.EventHandler(this.guna2ContainerControl1_Click);
            // 
            // connWhite
            // 
            this.connWhite.Controls.Add(this.lblVType);
            this.connWhite.Controls.Add(this.lblType);
            this.connWhite.Controls.Add(this.rtbContact);
            this.connWhite.Controls.Add(this.pctBack);
            this.connWhite.Controls.Add(this.lblVEmail);
            this.connWhite.Controls.Add(this.lblVContact);
            this.connWhite.Controls.Add(this.lblVName);
            this.connWhite.Controls.Add(this.lblDescription);
            this.connWhite.Controls.Add(this.lblEmail);
            this.connWhite.Controls.Add(this.lblContact);
            this.connWhite.Controls.Add(this.lblName);
            this.connWhite.Controls.Add(this.lblEditContact);
            this.connWhite.Location = new System.Drawing.Point(43, 31);
            this.connWhite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connWhite.Name = "connWhite";
            this.connWhite.Size = new System.Drawing.Size(1064, 655);
            this.connWhite.TabIndex = 0;
            this.connWhite.Text = "guna2ContainerControl2";
            this.connWhite.Click += new System.EventHandler(this.guna2ContainerControl2_Click);
            // 
            // lblVType
            // 
            this.lblVType.AutoSize = true;
            this.lblVType.BackColor = System.Drawing.Color.Transparent;
            this.lblVType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVType.Location = new System.Drawing.Point(660, 229);
            this.lblVType.Name = "lblVType";
            this.lblVType.Size = new System.Drawing.Size(84, 29);
            this.lblVType.TabIndex = 23;
            this.lblVType.Text = "Name:";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.BackColor = System.Drawing.Color.Transparent;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblType.Location = new System.Drawing.Point(255, 229);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(167, 29);
            this.lblType.TabIndex = 22;
            this.lblType.Text = "ContactType:";
            // 
            // rtbContact
            // 
            this.rtbContact.BackColor = System.Drawing.Color.White;
            this.rtbContact.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbContact.Location = new System.Drawing.Point(668, 486);
            this.rtbContact.Name = "rtbContact";
            this.rtbContact.ReadOnly = true;
            this.rtbContact.Size = new System.Drawing.Size(284, 68);
            this.rtbContact.TabIndex = 21;
            this.rtbContact.Text = "nn";
            // 
            // pctBack
            // 
            this.pctBack.BackColor = System.Drawing.Color.Transparent;
            this.pctBack.Image = global::GSTHMS.Properties.Resources.icons8_back_100;
            this.pctBack.ImageRotate = 0F;
            this.pctBack.Location = new System.Drawing.Point(12, 14);
            this.pctBack.Name = "pctBack";
            this.pctBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pctBack.Size = new System.Drawing.Size(53, 52);
            this.pctBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBack.TabIndex = 20;
            this.pctBack.TabStop = false;
            this.pctBack.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // lblVEmail
            // 
            this.lblVEmail.AutoSize = true;
            this.lblVEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblVEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVEmail.Location = new System.Drawing.Point(660, 405);
            this.lblVEmail.Name = "lblVEmail";
            this.lblVEmail.Size = new System.Drawing.Size(74, 29);
            this.lblVEmail.TabIndex = 17;
            this.lblVEmail.Text = "Email";
            // 
            // lblVContact
            // 
            this.lblVContact.AutoSize = true;
            this.lblVContact.BackColor = System.Drawing.Color.Transparent;
            this.lblVContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVContact.Location = new System.Drawing.Point(660, 323);
            this.lblVContact.Name = "lblVContact";
            this.lblVContact.Size = new System.Drawing.Size(126, 29);
            this.lblVContact.TabIndex = 16;
            this.lblVContact.Text = "ContactNo";
            // 
            // lblVName
            // 
            this.lblVName.AutoSize = true;
            this.lblVName.BackColor = System.Drawing.Color.Transparent;
            this.lblVName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVName.Location = new System.Drawing.Point(650, 148);
            this.lblVName.Name = "lblVName";
            this.lblVName.Size = new System.Drawing.Size(84, 29);
            this.lblVName.TabIndex = 15;
            this.lblVName.Text = "Name:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(251, 486);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(153, 29);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "Description:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(251, 405);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 29);
            this.lblEmail.TabIndex = 5;
            this.lblEmail.Text = "Email:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(255, 312);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(149, 29);
            this.lblContact.TabIndex = 4;
            this.lblContact.Text = "Contact No:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(255, 148);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 29);
            this.lblName.TabIndex = 3;
            this.lblName.Text = "Name:";
            this.lblName.Click += new System.EventHandler(this.lblName_Click);
            // 
            // tipContact
            // 
            this.tipContact.AllowLinksHandling = true;
            this.tipContact.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // frmViewContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 716);
            this.ControlBox = false;
            this.Controls.Add(this.connGrey);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmViewContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmViewContact_Load);
            this.connGrey.ResumeLayout(false);
            this.connWhite.ResumeLayout(false);
            this.connWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblEditContact;
        private Guna.UI2.WinForms.Guna2ContainerControl connGrey;
        private Guna.UI2.WinForms.Guna2ContainerControl connWhite;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblVEmail;
        private System.Windows.Forms.Label lblVContact;
        private System.Windows.Forms.Label lblVName;
        private Guna.UI2.WinForms.Guna2HtmlToolTip tipContact;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pctBack;
        private System.Windows.Forms.RichTextBox rtbContact;
        private System.Windows.Forms.Label lblVType;
        private System.Windows.Forms.Label lblType;
    }
}