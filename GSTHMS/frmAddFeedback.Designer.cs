namespace GSTHMS
{
    partial class frmAddFeedback
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
            this.connWhite = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.pctBack = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblstar1 = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFeedbackFor = new System.Windows.Forms.Label();
            this.clear = new Guna.UI2.WinForms.Guna2Button();
            this.btnSaveFeedback = new Guna.UI2.WinForms.Guna2Button();
            this.rtfDescriptionfeedback = new System.Windows.Forms.RichTextBox();
            this.rtgOverallRating = new Guna.UI2.WinForms.Guna2RatingStar();
            this.rtgInventory = new Guna.UI2.WinForms.Guna2RatingStar();
            this.rtgEvent = new Guna.UI2.WinForms.Guna2RatingStar();
            this.rtgParking = new Guna.UI2.WinForms.Guna2RatingStar();
            this.rtgFood = new Guna.UI2.WinForms.Guna2RatingStar();
            this.rtgRoom = new Guna.UI2.WinForms.Guna2RatingStar();
            this.cmbbxName = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblHomestayRating = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRoom = new System.Windows.Forms.Label();
            this.lblGuestName = new System.Windows.Forms.Label();
            this.connGrey = new Guna.UI2.WinForms.Guna2ContainerControl();
            this.connWhite.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).BeginInit();
            this.connGrey.SuspendLayout();
            this.SuspendLayout();
            // 
            // connWhite
            // 
            this.connWhite.Controls.Add(this.pctBack);
            this.connWhite.Controls.Add(this.label6);
            this.connWhite.Controls.Add(this.label1);
            this.connWhite.Controls.Add(this.lblstar1);
            this.connWhite.Controls.Add(this.lblDescription);
            this.connWhite.Controls.Add(this.lblFeedbackFor);
            this.connWhite.Controls.Add(this.clear);
            this.connWhite.Controls.Add(this.btnSaveFeedback);
            this.connWhite.Controls.Add(this.rtfDescriptionfeedback);
            this.connWhite.Controls.Add(this.rtgOverallRating);
            this.connWhite.Controls.Add(this.rtgInventory);
            this.connWhite.Controls.Add(this.rtgEvent);
            this.connWhite.Controls.Add(this.rtgParking);
            this.connWhite.Controls.Add(this.rtgFood);
            this.connWhite.Controls.Add(this.rtgRoom);
            this.connWhite.Controls.Add(this.cmbbxName);
            this.connWhite.Controls.Add(this.lblHomestayRating);
            this.connWhite.Controls.Add(this.label5);
            this.connWhite.Controls.Add(this.label4);
            this.connWhite.Controls.Add(this.label3);
            this.connWhite.Controls.Add(this.label2);
            this.connWhite.Controls.Add(this.lblRoom);
            this.connWhite.Controls.Add(this.lblGuestName);
            this.connWhite.Location = new System.Drawing.Point(40, 33);
            this.connWhite.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.connWhite.Name = "connWhite";
            this.connWhite.Size = new System.Drawing.Size(935, 751);
            this.connWhite.TabIndex = 0;
            this.connWhite.Text = "connAddFeedback";
            this.connWhite.Click += new System.EventHandler(this.guna2ContainerControl2_Click);
            // 
            // pctBack
            // 
            this.pctBack.BackColor = System.Drawing.Color.Transparent;
            this.pctBack.FillColor = System.Drawing.Color.Transparent;
            this.pctBack.Image = global::GSTHMS.Properties.Resources.icons8_back_100;
            this.pctBack.ImageRotate = 0F;
            this.pctBack.Location = new System.Drawing.Point(3, 3);
            this.pctBack.Name = "pctBack";
            this.pctBack.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.pctBack.Size = new System.Drawing.Size(53, 52);
            this.pctBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctBack.TabIndex = 25;
            this.pctBack.TabStop = false;
            this.pctBack.Click += new System.EventHandler(this.guna2CirclePictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(302, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(289, 46);
            this.label6.TabIndex = 24;
            this.label6.Text = "Add Feedback";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(294, 595);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 29);
            this.label1.TabIndex = 23;
            this.label1.Text = "*";
            // 
            // lblstar1
            // 
            this.lblstar1.AutoSize = true;
            this.lblstar1.BackColor = System.Drawing.Color.Transparent;
            this.lblstar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstar1.ForeColor = System.Drawing.Color.Red;
            this.lblstar1.Location = new System.Drawing.Point(303, 100);
            this.lblstar1.Name = "lblstar1";
            this.lblstar1.Size = new System.Drawing.Size(23, 29);
            this.lblstar1.TabIndex = 22;
            this.lblstar1.Text = "*";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(144, 610);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(153, 29);
            this.lblDescription.TabIndex = 21;
            this.lblDescription.Text = "Description:";
            // 
            // lblFeedbackFor
            // 
            this.lblFeedbackFor.AutoSize = true;
            this.lblFeedbackFor.BackColor = System.Drawing.Color.Transparent;
            this.lblFeedbackFor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFeedbackFor.ForeColor = System.Drawing.Color.Black;
            this.lblFeedbackFor.Location = new System.Drawing.Point(329, 145);
            this.lblFeedbackFor.Name = "lblFeedbackFor";
            this.lblFeedbackFor.Size = new System.Drawing.Size(183, 29);
            this.lblFeedbackFor.TabIndex = 18;
            this.lblFeedbackFor.Text = "Feedback For:";
            // 
            // clear
            // 
            this.clear.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.clear.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.clear.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.clear.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.clear.FillColor = System.Drawing.Color.Red;
            this.clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.clear.Location = new System.Drawing.Point(603, 683);
            this.clear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(217, 45);
            this.clear.TabIndex = 17;
            this.clear.Text = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // btnSaveFeedback
            // 
            this.btnSaveFeedback.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveFeedback.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSaveFeedback.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSaveFeedback.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSaveFeedback.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnSaveFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveFeedback.ForeColor = System.Drawing.Color.White;
            this.btnSaveFeedback.Location = new System.Drawing.Point(145, 683);
            this.btnSaveFeedback.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveFeedback.Name = "btnSaveFeedback";
            this.btnSaveFeedback.Size = new System.Drawing.Size(217, 45);
            this.btnSaveFeedback.TabIndex = 16;
            this.btnSaveFeedback.Text = "Save Feedbeck";
            this.btnSaveFeedback.Click += new System.EventHandler(this.btnSaveFeedback_Click);
            // 
            // rtfDescriptionfeedback
            // 
            this.rtfDescriptionfeedback.Location = new System.Drawing.Point(557, 595);
            this.rtfDescriptionfeedback.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtfDescriptionfeedback.Name = "rtfDescriptionfeedback";
            this.rtfDescriptionfeedback.Size = new System.Drawing.Size(284, 68);
            this.rtfDescriptionfeedback.TabIndex = 15;
            this.rtfDescriptionfeedback.Text = "";
            this.rtfDescriptionfeedback.TextChanged += new System.EventHandler(this.rtfDescriptionfeedback_TextChanged);
            this.rtfDescriptionfeedback.Enter += new System.EventHandler(this.rtfDescriptionfeedback_Enter);
            this.rtfDescriptionfeedback.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtfDescriptionfeedback_KeyPress);
            this.rtfDescriptionfeedback.Leave += new System.EventHandler(this.rtfDescriptionfeedback_Leave);
            // 
            // rtgOverallRating
            // 
            this.rtgOverallRating.BackColor = System.Drawing.Color.Transparent;
            this.rtgOverallRating.Location = new System.Drawing.Point(294, 522);
            this.rtgOverallRating.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgOverallRating.Name = "rtgOverallRating";
            this.rtgOverallRating.RatingColor = System.Drawing.Color.Gold;
            this.rtgOverallRating.Size = new System.Drawing.Size(297, 54);
            this.rtgOverallRating.TabIndex = 14;
            this.rtgOverallRating.ValueChanged += new System.EventHandler(this.rtgOverallRating_ValueChanged);
            this.rtgOverallRating.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtgOverallRating_KeyPress);
            this.rtgOverallRating.MouseClick += new System.Windows.Forms.MouseEventHandler(this.rtgOverallRating_MouseClick);
            // 
            // rtgInventory
            // 
            this.rtgInventory.BackColor = System.Drawing.Color.Transparent;
            this.rtgInventory.Location = new System.Drawing.Point(534, 413);
            this.rtgInventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgInventory.Name = "rtgInventory";
            this.rtgInventory.RatingColor = System.Drawing.Color.Gold;
            this.rtgInventory.Size = new System.Drawing.Size(297, 54);
            this.rtgInventory.TabIndex = 13;
            this.rtgInventory.ValueChanged += new System.EventHandler(this.rtgInventory_ValueChanged);
            // 
            // rtgEvent
            // 
            this.rtgEvent.BackColor = System.Drawing.Color.Transparent;
            this.rtgEvent.Location = new System.Drawing.Point(534, 351);
            this.rtgEvent.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgEvent.Name = "rtgEvent";
            this.rtgEvent.RatingColor = System.Drawing.Color.Gold;
            this.rtgEvent.Size = new System.Drawing.Size(297, 54);
            this.rtgEvent.TabIndex = 12;
            this.rtgEvent.ValueChanged += new System.EventHandler(this.rtgEvent_ValueChanged);
            // 
            // rtgParking
            // 
            this.rtgParking.BackColor = System.Drawing.Color.Transparent;
            this.rtgParking.Location = new System.Drawing.Point(534, 289);
            this.rtgParking.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgParking.Name = "rtgParking";
            this.rtgParking.RatingColor = System.Drawing.Color.Gold;
            this.rtgParking.Size = new System.Drawing.Size(297, 54);
            this.rtgParking.TabIndex = 11;
            this.rtgParking.ValueChanged += new System.EventHandler(this.rtgParking_ValueChanged);
            // 
            // rtgFood
            // 
            this.rtgFood.BackColor = System.Drawing.Color.Transparent;
            this.rtgFood.Location = new System.Drawing.Point(534, 227);
            this.rtgFood.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgFood.Name = "rtgFood";
            this.rtgFood.RatingColor = System.Drawing.Color.Gold;
            this.rtgFood.Size = new System.Drawing.Size(297, 54);
            this.rtgFood.TabIndex = 10;
            this.rtgFood.ValueChanged += new System.EventHandler(this.rtgFood_ValueChanged);
            // 
            // rtgRoom
            // 
            this.rtgRoom.BackColor = System.Drawing.Color.Transparent;
            this.rtgRoom.Location = new System.Drawing.Point(534, 165);
            this.rtgRoom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rtgRoom.Name = "rtgRoom";
            this.rtgRoom.RatingColor = System.Drawing.Color.Gold;
            this.rtgRoom.Size = new System.Drawing.Size(297, 54);
            this.rtgRoom.TabIndex = 9;
            this.rtgRoom.ValueChanged += new System.EventHandler(this.rtgRoom_ValueChanged);
            // 
            // cmbbxName
            // 
            this.cmbbxName.BackColor = System.Drawing.Color.Transparent;
            this.cmbbxName.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbbxName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbbxName.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cmbbxName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbbxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cmbbxName.ItemHeight = 30;
            this.cmbbxName.Location = new System.Drawing.Point(581, 93);
            this.cmbbxName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbbxName.Name = "cmbbxName";
            this.cmbbxName.Size = new System.Drawing.Size(250, 36);
            this.cmbbxName.TabIndex = 8;
            this.cmbbxName.DropDown += new System.EventHandler(this.cmbbxName_DropDown);
            this.cmbbxName.SelectedIndexChanged += new System.EventHandler(this.cmbbxName_SelectedIndexChanged);
            this.cmbbxName.Leave += new System.EventHandler(this.cmbbxName_Leave);
            // 
            // lblHomestayRating
            // 
            this.lblHomestayRating.AutoSize = true;
            this.lblHomestayRating.BackColor = System.Drawing.Color.Transparent;
            this.lblHomestayRating.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomestayRating.ForeColor = System.Drawing.Color.Black;
            this.lblHomestayRating.Location = new System.Drawing.Point(265, 489);
            this.lblHomestayRating.Name = "lblHomestayRating";
            this.lblHomestayRating.Size = new System.Drawing.Size(352, 29);
            this.lblHomestayRating.TabIndex = 6;
            this.lblHomestayRating.Text = "** Homestay Overall Rating**";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(140, 425);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 29);
            this.label5.TabIndex = 5;
            this.label5.Text = "Inventory";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(144, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 29);
            this.label4.TabIndex = 4;
            this.label4.Text = "Event";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(140, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Parking";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(140, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Food";
            // 
            // lblRoom
            // 
            this.lblRoom.AutoSize = true;
            this.lblRoom.BackColor = System.Drawing.Color.Transparent;
            this.lblRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoom.ForeColor = System.Drawing.Color.Black;
            this.lblRoom.Location = new System.Drawing.Point(140, 181);
            this.lblRoom.Name = "lblRoom";
            this.lblRoom.Size = new System.Drawing.Size(82, 29);
            this.lblRoom.TabIndex = 1;
            this.lblRoom.Text = "Room";
            // 
            // lblGuestName
            // 
            this.lblGuestName.AutoSize = true;
            this.lblGuestName.BackColor = System.Drawing.Color.Transparent;
            this.lblGuestName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGuestName.Location = new System.Drawing.Point(140, 100);
            this.lblGuestName.Name = "lblGuestName";
            this.lblGuestName.Size = new System.Drawing.Size(157, 29);
            this.lblGuestName.TabIndex = 0;
            this.lblGuestName.Text = "GuestName:";
            // 
            // connGrey
            // 
            this.connGrey.Controls.Add(this.connWhite);
            this.connGrey.FillColor = System.Drawing.Color.Gray;
            this.connGrey.Location = new System.Drawing.Point(-6, -1);
            this.connGrey.Name = "connGrey";
            this.connGrey.Size = new System.Drawing.Size(1018, 824);
            this.connGrey.TabIndex = 1;
            this.connGrey.Text = "guna2ContainerControl1";
            // 
            // frmAddFeedback
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1008, 814);
            this.ControlBox = false;
            this.Controls.Add(this.connGrey);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmAddFeedback";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAddFeedback_Load);
            this.connWhite.ResumeLayout(false);
            this.connWhite.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctBack)).EndInit();
            this.connGrey.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Guna.UI2.WinForms.Guna2ContainerControl connWhite;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRoom;
        private System.Windows.Forms.Label lblGuestName;
        private System.Windows.Forms.Label lblHomestayRating;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2Button clear;
        private Guna.UI2.WinForms.Guna2Button btnSaveFeedback;
        private System.Windows.Forms.RichTextBox rtfDescriptionfeedback;
        private Guna.UI2.WinForms.Guna2RatingStar rtgOverallRating;
        private Guna.UI2.WinForms.Guna2RatingStar rtgInventory;
        private Guna.UI2.WinForms.Guna2RatingStar rtgEvent;
        private Guna.UI2.WinForms.Guna2RatingStar rtgParking;
        private Guna.UI2.WinForms.Guna2RatingStar rtgFood;
        private Guna.UI2.WinForms.Guna2RatingStar rtgRoom;
        private Guna.UI2.WinForms.Guna2ComboBox cmbbxName;
        private System.Windows.Forms.Label lblFeedbackFor;
        private System.Windows.Forms.Label lblDescription;
        private Guna.UI2.WinForms.Guna2ContainerControl connGrey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblstar1;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2CirclePictureBox pctBack;
    }
}