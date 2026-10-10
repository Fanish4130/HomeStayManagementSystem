namespace GSTHMS
{
    partial class frmTermsVM
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
            this.toolTip1VM = new System.Windows.Forms.ToolTip(this.components);
            this.rtfTermsAndConditionsVM = new System.Windows.Forms.RichTextBox();
            this.lblTermsnCondVM = new System.Windows.Forms.Label();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.SuspendLayout();
            // 
            // rtfTermsAndConditionsVM
            // 
            this.rtfTermsAndConditionsVM.BackColor = System.Drawing.Color.White;
            this.rtfTermsAndConditionsVM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtfTermsAndConditionsVM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtfTermsAndConditionsVM.ForeColor = System.Drawing.Color.Black;
            this.rtfTermsAndConditionsVM.Location = new System.Drawing.Point(95, 67);
            this.rtfTermsAndConditionsVM.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtfTermsAndConditionsVM.Name = "rtfTermsAndConditionsVM";
            this.rtfTermsAndConditionsVM.Size = new System.Drawing.Size(965, 765);
            this.rtfTermsAndConditionsVM.TabIndex = 1;
            this.rtfTermsAndConditionsVM.Text = "";
            // 
            // lblTermsnCondVM
            // 
            this.lblTermsnCondVM.AutoSize = true;
            this.lblTermsnCondVM.Font = new System.Drawing.Font("Microsoft YaHei UI", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTermsnCondVM.Location = new System.Drawing.Point(388, 9);
            this.lblTermsnCondVM.Name = "lblTermsnCondVM";
            this.lblTermsnCondVM.Size = new System.Drawing.Size(430, 50);
            this.lblTermsnCondVM.TabIndex = 0;
            this.lblTermsnCondVM.Text = "Terms and Conditions";
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // frmTermsVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1132, 840);
            this.Controls.Add(this.rtfTermsAndConditionsVM);
            this.Controls.Add(this.lblTermsnCondVM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmTermsVM";
            this.Load += new System.EventHandler(this.frmTerms_Conditions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1VM;
        private System.Windows.Forms.RichTextBox rtfTermsAndConditionsVM;
        private System.Windows.Forms.Label lblTermsnCondVM;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
    }
}