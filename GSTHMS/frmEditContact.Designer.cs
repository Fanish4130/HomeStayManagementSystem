namespace GSTHMS
{
    partial class frmEditContact
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
            this.lblEName = new System.Windows.Forms.Label();
            this.btnClear = new Guna.UI2.WinForms.Guna2Button();
            this.btnUpdateContact = new Guna.UI2.WinForms.Guna2Button();
            this.rtfDescription = new System.Windows.Forms.RichTextBox();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.txtContact = new Guna.UI2.WinForms.Guna2TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblEditContact = new System.Windows.Forms.Label();
            this.connGrey = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connWhite = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.lblEType = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pctBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAddContact = new System.Windows.Forms.Label();
            this.connGrey.SuspendLayout();
            this.connWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEName
            // 
            this.lblEName.AutoSize = true;
            this.lblEName.BackColor = System.Drawing.Color.Transparent;
            this.lblEName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEName.Location = new System.Drawing.Point(631, 105);
            this.lblEName.Name = "lblEName";
            this.lblEName.Size = new System.Drawing.Size(84, 29);
            this.lblEName.TabIndex = 14;
            this.lblEName.Text = "Name:";
            // 
            // btnClear
            // 
            this.btnClear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClear.FillColor = System.Drawing.Color.Red;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(636, 509);
            this.btnClear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(217, 45);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnUpdateContact
            // 
            this.btnUpdateContact.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateContact.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnUpdateContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnUpdateContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnUpdateContact.FillColor = System.Drawing.Color.Blue;
            this.btnUpdateContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateContact.ForeColor = System.Drawing.Color.White;
            this.btnUpdateContact.Location = new System.Drawing.Point(212, 509);
            this.btnUpdateContact.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnUpdateContact.Name = "btnUpdateContact";
            this.btnUpdateContact.Size = new System.Drawing.Size(217, 45);
            this.btnUpdateContact.TabIndex = 12;
            this.btnUpdateContact.Text = "Update Contact";
            this.btnUpdateContact.Click += new System.EventHandler(this.btnUpdateContact_Click);
            // 
            // rtfDescription
            // 
            this.rtfDescription.BackColor = System.Drawing.Color.White;
            this.rtfDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtfDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfDescription.Location = new System.Drawing.Point(636, 414);
            this.rtfDescription.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtfDescription.Name = "rtfDescription";
            this.rtfDescription.ReadOnly = true;
            this.rtfDescription.Size = new System.Drawing.Size(284, 68);
            this.rtfDescription.TabIndex = 11;
            this.rtfDescription.Text = "sds";
            this.rtfDescription.TextChanged += new System.EventHandler(this.rtfDescription_TextChanged);
            this.rtfDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfDescription_KeyPress);
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
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(636, 335);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Enter Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(284, 47);
            this.txtEmail.TabIndex = 10;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // txtContact
            // 
            this.txtContact.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtContact.DefaultText = "";
            this.txtContact.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtContact.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtContact.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContact.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtContact.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtContact.Location = new System.Drawing.Point(636, 258);
            this.txtContact.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.txtContact.Name = "txtContact";
            this.txtContact.PlaceholderText = "Enter Contact";
            this.txtContact.SelectedText = "";
            this.txtContact.Size = new System.Drawing.Size(250, 36);
            this.txtContact.TabIndex = 10;
            this.txtContact.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtContact_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(232, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(153, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Description:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.BackColor = System.Drawing.Color.Transparent;
            this.lblEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(226, 335);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(86, 29);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.BackColor = System.Drawing.Color.Transparent;
            this.lblContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(226, 258);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(149, 29);
            this.lblContact.TabIndex = 3;
            this.lblContact.Text = "Contact No:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(229, 105);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 29);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "Name:";
            // 
            // lblEditContact
            // 
            this.lblEditContact.AutoSize = true;
            this.lblEditContact.BackColor = System.Drawing.Color.Transparent;
            this.lblEditContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditContact.Location = new System.Drawing.Point(368, 25);
            this.lblEditContact.Name = "lblEditContact";
            this.lblEditContact.Size = new System.Drawing.Size(269, 52);
            this.lblEditContact.TabIndex = 1;
            this.lblEditContact.Text = "Edit Contact";
            // 
            // connGrey
            // 
            this.connGrey.Controls.Add(this.connWhite);
            this.connGrey.FillColor = System.Drawing.Color.Gray;
            this.connGrey.Location = new System.Drawing.Point(-1, 0);
            this.connGrey.Name = "connGrey";
            this.connGrey.Size = new System.Drawing.Size(1149, 682);
            this.connGrey.TabIndex = 15;
            this.connGrey.Text = "guna2ContainerControl1";
            // 
            // connWhite
            // 
            this.connWhite.Controls.Add(this.lblEType);
            this.connWhite.Controls.Add(this.label3);
            this.connWhite.Controls.Add(this.pctBack);
            this.connWhite.Controls.Add(this.label2);
            this.connWhite.Controls.Add(this.label1);
            this.connWhite.Controls.Add(this.lblEditContact);
            this.connWhite.Controls.Add(this.btnClear);
            this.connWhite.Controls.Add(this.lblName);
            this.connWhite.Controls.Add(this.btnUpdateContact);
            this.connWhite.Controls.Add(this.lblEName);
            this.connWhite.Controls.Add(this.rtfDescription);
            this.connWhite.Controls.Add(this.lblContact);
            this.connWhite.Controls.Add(this.txtEmail);
            this.connWhite.Controls.Add(this.label5);
            this.connWhite.Controls.Add(this.txtContact);
            this.connWhite.Controls.Add(this.lblEmail);
            this.connWhite.Location = new System.Drawing.Point(38, 27);
            this.connWhite.Name = "connWhite";
            this.connWhite.Size = new System.Drawing.Size(1069, 627);
            this.connWhite.TabIndex = 0;
            this.connWhite.Text = "guna2ContainerControl2";
            this.connWhite.Click += new System.EventHandler(this.connWhite_Click);
            // 
            // lblEType
            // 
            this.lblEType.AutoSize = true;
            this.lblEType.BackColor = System.Drawing.Color.Transparent;
            this.lblEType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEType.Location = new System.Drawing.Point(631, 183);
            this.lblEType.Name = "lblEType";
            this.lblEType.Size = new System.Drawing.Size(84, 29);
            this.lblEType.TabIndex = 20;
            this.lblEType.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(226, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 29);
            this.label3.TabIndex = 19;
            this.label3.Text = "Contact Type:";
            // 
            // pctBack
            // 
            this.pctBack.BackColor = System.Drawing.Color.Transparent;
            this.pctBack.Image = global::GSTHMS.Properties.Resources.icons8_back_100;
            this.pctBack.ImageRotate = 0F;
            this.pctBack.Location = new System.Drawing.Point(13, 5);
            this.pctBack.Name = "pctBack";
            this.pctBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pctBack.Size = new System.Drawing.Size(53, 52);
            this.pctBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBack.TabIndex = 18;
            this.pctBack.TabStop = false;
            this.pctBack.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(318, 326);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 29);
            this.label2.TabIndex = 17;
            this.label2.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(381, 258);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 16;
            this.label1.Text = "*";
            // 
            // lblAddContact
            // 
            this.lblAddContact.AutoSize = true;
            this.lblAddContact.Location = new System.Drawing.Point(14, 832);
            this.lblAddContact.Name = "lblAddContact";
            this.lblAddContact.Size = new System.Drawing.Size(98, 20);
            this.lblAddContact.TabIndex = 1;
            this.lblAddContact.Text = "Add Contact";
            // 
            // frmEditContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 682);
            this.ControlBox = false;
            this.Controls.Add(this.connGrey);
            this.Controls.Add(this.lblAddContact);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmEditContact";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmEditContact_Load);
            this.connGrey.ResumeLayout(false);
            this.connWhite.ResumeLayout(false);
            this.connWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEName;
        private Guna.UI2.WinForms.Guna2Button btnClear;
        private Guna.UI2.WinForms.Guna2Button btnUpdateContact;
        private System.Windows.Forms.RichTextBox rtfDescription;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtContact;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblEditContact;
        private Guna.UI2.WinForms.Guna2ContainerControl connGrey;
        private Guna.UI2.WinForms.Guna2ContainerControl connWhite;
        private System.Windows.Forms.Label lblAddContact;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pctBack;
        private System.Windows.Forms.Label lblEType;
        private System.Windows.Forms.Label label3;
    }
}