using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmViewContact : Form
    {
        public long ContactNoPSS { get; set; }
        public string DescriptionPSS { get; set; }

        public string ContactNamePSS { get; set; }

        public string EmailPSS { get; set; }

        public string ContactTypePSS { get; set; }
        //  bool isExpanded = false;

        private string fullDescription;
        private string shortDescription;
        public frmViewContact()
        {
            InitializeComponent();
           
        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void lblEditContact_Click(object sender, EventArgs e)
        {

        }

        private void frmViewContact_Load(object sender, EventArgs e)
        {

            lblVContact.Text = ContactNoPSS.ToString();
            lblVName.Text = ContactNamePSS;
            lblVEmail.Text = EmailPSS;
            lblVType.Text = ContactTypePSS;
            rtbContact.Text = DescriptionPSS;

            ////// Show tooltip on description label
            //tipContact.SetToolTip(lblVDescription, DescriptionPSS);
            //lblVContact.Text = ContactNoPSS.ToString();
            //lblVName.Text = ContactNamePSS;
            //lblVEmail.Text = EmailPSS;

            fullDescription = DescriptionPSS;

            //// Short description (first 80 chars)
            //if (!string.IsNullOrEmpty(DescriptionPSS) && DescriptionPSS.Length > 10)
            //    shortDescription = DescriptionPSS.Substring(0, 10) + "...";
            //else
            //    shortDescription = DescriptionPSS;

            //// Show short version in label
            //lblVDescription.Text = shortDescription;

            //// Tooltip always contains full description
            tipContact.SetToolTip(rtbContact, fullDescription);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblVDescription_Click(object sender, EventArgs e)
        {
            tipContact.Show(fullDescription, rtbContact);
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
