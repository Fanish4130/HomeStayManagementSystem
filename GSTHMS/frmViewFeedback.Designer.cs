namespace GSTHMS
{
    partial class frmViewFeedback
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
            this.connViewGrey = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connViewW = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.pctBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.lblEditContact = new System.Windows.Forms.Label();
            this.rtgOverallRating = new Guna.UI2.WinForms.Guna2RatingStar();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rtgInventory = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblInventory = new System.Windows.Forms.Label();
            this.rtgEvent = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblEvent = new System.Windows.Forms.Label();
            this.rtgParking = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblParking = new System.Windows.Forms.Label();
            this.rtgFood = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblFood = new System.Windows.Forms.Label();
            this.rtgRoom = new Guna.UI2.WinForms.Guna2RatingStar();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.tipFeedback = new Guna.UI2.WinForms.Guna2HtmlToolTip();
            this.connViewGrey.SuspendLayout();
            this.connViewW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).BeginInit();
            this.SuspendLayout();
            // 
            // connViewGrey
            // 
            this.connViewGrey.Controls.Add(this.connViewW);
            this.connViewGrey.FillColor = System.Drawing.Color.Gray;
            this.connViewGrey.Location = new System.Drawing.Point(-2, -8);
            this.connViewGrey.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connViewGrey.Name = "connViewGrey";
            this.connViewGrey.Size = new System.Drawing.Size(1100, 852);
            this.connViewGrey.TabIndex = 0;
            this.connViewGrey.Text = "connGrey";
            // 
            // connViewW
            // 
            this.connViewW.Controls.Add(this.rtbDescription);
            this.connViewW.Controls.Add(this.pctBack);
            this.connViewW.Controls.Add(this.lblEditContact);
            this.connViewW.Controls.Add(this.rtgOverallRating);
            this.connViewW.Controls.Add(this.label2);
            this.connViewW.Controls.Add(this.lblDate);
            this.connViewW.Controls.Add(this.label1);
            this.connViewW.Controls.Add(this.lblDescription);
            this.connViewW.Controls.Add(this.label6);
            this.connViewW.Controls.Add(this.rtgInventory);
            this.connViewW.Controls.Add(this.lblInventory);
            this.connViewW.Controls.Add(this.rtgEvent);
            this.connViewW.Controls.Add(this.lblEvent);
            this.connViewW.Controls.Add(this.rtgParking);
            this.connViewW.Controls.Add(this.lblParking);
            this.connViewW.Controls.Add(this.rtgFood);
            this.connViewW.Controls.Add(this.lblFood);
            this.connViewW.Controls.Add(this.rtgRoom);
            this.connViewW.Controls.Add(this.lblRoom);
            this.connViewW.Controls.Add(this.lblName);
            this.connViewW.Controls.Add(this.lblGuestName);
            this.connViewW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connViewW.Location = new System.Drawing.Point(46, 42);
            this.connViewW.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connViewW.Name = "connViewW";
            this.connViewW.Size = new System.Drawing.Size(1006, 759);
            this.connViewW.TabIndex = 0;
            this.connViewW.Text = "connWhite";
            this.connViewW.Click += new System.EventHandler(this.guna2ContainerControl2_Click);
            // 
            // rtbDescription
            // 
            this.rtbDescription.BackColor = System.Drawing.Color.White;
            this.rtbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbDescription.Location = new System.Drawing.Point(553, 660);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.ReadOnly = true;
            this.rtbDescription.Size = new System.Drawing.Size(332, 86);
            this.rtbDescription.TabIndex = 30;
            this.rtbDescription.Text = "";
            // 
            // pctBack
            // 
            this.pctBack.BackColor = System.Drawing.Color.Transparent;
            this.pctBack.Image = global::GSTHMS.Properties.Resources.icons8_back_100;
            this.pctBack.ImageRotate = 0F;
            this.pctBack.Location = new System.Drawing.Point(3, 4);
            this.pctBack.Name = "pctBack";
            this.pctBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pctBack.Size = new System.Drawing.Size(53, 52);
            this.pctBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBack.TabIndex = 29;
            this.pctBack.TabStop = false;
            this.pctBack.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // lblEditContact
            // 
            this.lblEditContact.AutoSize = true;
            this.lblEditContact.BackColor = System.Drawing.Color.Transparent;
            this.lblEditContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditContact.Location = new System.Drawing.Point(313, 16);
            this.lblEditContact.Name = "lblEditContact";
            this.lblEditContact.Size = new System.Drawing.Size(371, 52);
            this.lblEditContact.TabIndex = 27;
            this.lblEditContact.Text = "Feedback Details";
            // 
            // rtgOverallRating
            // 
            this.rtgOverallRating.BackColor = System.Drawing.Color.Transparent;
            this.rtgOverallRating.Location = new System.Drawing.Point(533, 515);
            this.rtgOverallRating.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgOverallRating.Name = "rtgOverallRating";
            this.rtgOverallRating.RatingColor = System.Drawing.Color.Gold;
            this.rtgOverallRating.ReadOnly = true;
            this.rtgOverallRating.Size = new System.Drawing.Size(297, 54);
            this.rtgOverallRating.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(172, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 29);
            this.label2.TabIndex = 25;
            this.label2.Text = "Overall Rating:";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BackColor = System.Drawing.Color.Transparent;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(548, 595);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(159, 29);
            this.lblDate.TabIndex = 24;
            this.lblDate.Text = "feedbackdate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(168, 583);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "FeedbackDate:";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(176, 657);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(153, 29);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Description:";
            this.lblDescription.Click += new System.EventHandler(this.lblDescription_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(189, 515);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 29);
            this.label6.TabIndex = 19;
            // 
            // rtgInventory
            // 
            this.rtgInventory.BackColor = System.Drawing.Color.Transparent;
            this.rtgInventory.Location = new System.Drawing.Point(533, 439);
            this.rtgInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgInventory.Name = "rtgInventory";
            this.rtgInventory.RatingColor = System.Drawing.Color.Gold;
            this.rtgInventory.ReadOnly = true;
            this.rtgInventory.Size = new System.Drawing.Size(297, 54);
            this.rtgInventory.TabIndex = 18;
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.BackColor = System.Drawing.Color.Transparent;
            this.lblInventory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInventory.Location = new System.Drawing.Point(176, 439);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(125, 29);
            this.lblInventory.TabIndex = 17;
            this.lblInventory.Text = "Inventory:";
            // 
            // rtgEvent
            // 
            this.rtgEvent.BackColor = System.Drawing.Color.Transparent;
            this.rtgEvent.Location = new System.Drawing.Point(533, 361);
            this.rtgEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgEvent.Name = "rtgEvent";
            this.rtgEvent.RatingColor = System.Drawing.Color.Gold;
            this.rtgEvent.ReadOnly = true;
            this.rtgEvent.Size = new System.Drawing.Size(297, 54);
            this.rtgEvent.TabIndex = 16;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.BackColor = System.Drawing.Color.Transparent;
            this.lblEvent.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEvent.Location = new System.Drawing.Point(176, 371);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(85, 29);
            this.lblEvent.TabIndex = 15;
            this.lblEvent.Text = "Event:";
            this.lblEvent.Click += new System.EventHandler(this.label4_Click);
            // 
            // rtgParking
            // 
            this.rtgParking.BackColor = System.Drawing.Color.Transparent;
            this.rtgParking.Location = new System.Drawing.Point(533, 290);
            this.rtgParking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgParking.Name = "rtgParking";
            this.rtgParking.RatingColor = System.Drawing.Color.Gold;
            this.rtgParking.ReadOnly = true;
            this.rtgParking.Size = new System.Drawing.Size(297, 54);
            this.rtgParking.TabIndex = 14;
            // 
            // lblParking
            // 
            this.lblParking.AutoSize = true;
            this.lblParking.BackColor = System.Drawing.Color.Transparent;
            this.lblParking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParking.Location = new System.Drawing.Point(172, 301);
            this.lblParking.Name = "lblParking";
            this.lblParking.Size = new System.Drawing.Size(109, 29);
            this.lblParking.TabIndex = 13;
            this.lblParking.Text = "Parking:";
            // 
            // rtgFood
            // 
            this.rtgFood.BackColor = System.Drawing.Color.Transparent;
            this.rtgFood.Location = new System.Drawing.Point(533, 216);
            this.rtgFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgFood.Name = "rtgFood";
            this.rtgFood.RatingColor = System.Drawing.Color.Gold;
            this.rtgFood.ReadOnly = true;
            this.rtgFood.Size = new System.Drawing.Size(297, 54);
            this.rtgFood.TabIndex = 12;
            // 
            // lblFood
            // 
            this.lblFood.AutoSize = true;
            this.lblFood.BackColor = System.Drawing.Color.Transparent;
            this.lblFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFood.Location = new System.Drawing.Point(176, 225);
            this.lblFood.Name = "lblFood";
            this.lblFood.Size = new System.Drawing.Size(81, 29);
            this.lblFood.TabIndex = 11;
            this.lblFood.Text = "Food:";
            // 
            // rtgRoom
            // 
            this.rtgRoom.BackColor = System.Drawing.Color.Transparent;
            this.rtgRoom.Location = new System.Drawing.Point(533, 151);
            this.rtgRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgRoom.Name = "rtgRoom";
            this.rtgRoom.RatingColor = System.Drawing.Color.Gold;
            this.rtgRoom.ReadOnly = true;
            this.rtgRoom.Size = new System.Drawing.Size(297, 54);
            this.rtgRoom.TabIndex = 10;
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.BackColor = System.Drawing.Color.Transparent;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.Location = new System.Drawing.Point(176, 151);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(89, 29);
            this.lblRoom.TabIndex = 3;
            this.lblRoom.Text = "Room:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(528, 99);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(147, 29);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "GuestName:";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.BackColor = System.Drawing.Color.Transparent;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.Location = new System.Drawing.Point(172, 99);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(157, 29);
            this.lblGuestName.TabIndex = 1;
            this.lblGuestName.Text = "GuestName:";
            // 
            // tipFeedback
            // 
            this.tipFeedback.AllowLinksHandling = true;
            this.tipFeedback.MaximumSize = new System.Drawing.Size(0, 0);
            // 
            // frmViewFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1096, 839);
            this.ControlBox = false;
            this.Controls.Add(this.connViewGrey);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmViewFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmViewFeedback_FormClosing);
            this.Load += new System.EventHandler(this.ViewFeedback_Load);
            this.connViewGrey.ResumeLayout(false);
            this.connViewW.ResumeLayout(false);
            this.connViewW.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ContainerControl connViewGrey;
        private Guna.UI2.WinForms.Guna2ContainerControl connViewW;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblRoom;
        private Guna.UI2.WinForms.Guna2RatingStar rtgRoom;
        private System.Windows.Forms.Label lblFood;
        private Guna.UI2.WinForms.Guna2RatingStar rtgFood;
        private System.Windows.Forms.Label lblParking;
        private Guna.UI2.WinForms.Guna2RatingStar rtgParking;
        private System.Windows.Forms.Label lblEvent;
        private Guna.UI2.WinForms.Guna2RatingStar rtgEvent;
        private System.Windows.Forms.Label lblInventory;
        private Guna.UI2.WinForms.Guna2RatingStar rtgInventory;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2RatingStar rtgOverallRating;
        private System.Windows.Forms.Label lblEditContact;
        private Guna.UI2.WinForms.Guna2HtmlToolTip tipFeedback;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pctBack;
        private System.Windows.Forms.RichTextBox rtbDescription;
    }
}