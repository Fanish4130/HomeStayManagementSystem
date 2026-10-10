using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static GSTHMS.clsUser;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmViewEnquiry : Form
    {
        public string G_Name1AB;
        public string G_CodeAB;
        public frmViewEnquiry(string gname,string g_code)
        {
            InitializeComponent();
            G_Name1AB = gname;
            G_CodeAB = g_code;
        }

        private void frmViewEnquiry_Load(object sender, EventArgs e)
        {
            try
            {
                FetchGuestDetailsAB();
                FetchFollowUpHistoryAB();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading form:\n" + ex.Message,
                                "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fetch GuestDetails
        public void FetchGuestDetailsAB()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestNameAB = G_Name1AB;
                obj.EnquiryCodeAB = G_CodeAB; 
                DataTable dt = obj.DisplayDataAB();

                if (dt.Rows.Count > 0)
                {
                    lblGuestName1.Text = dt.Rows[0]["GuestName"].ToString();
                    //lblEnquiryCode.Text = dt.Rows[0]["EnquiryCode"].ToString();
                    //lblEnquiryCode.Visible = true;
                    lblEmail1.Text = dt.Rows[0]["EmailID"].ToString();
                    lblContact1.Text = dt.Rows[0]["ContactNo"].ToString();
                    lblGender1.Text = dt.Rows[0]["Gender"].ToString();
                    lblAddress1.Text = dt.Rows[0]["Address"].ToString();
                    lblReasonOfEnquiry1.Text = dt.Rows[0]["Reason"].ToString();
                    lblSystemDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
                    lblpincode2.Text = dt.Rows[0]["Pincode"].ToString();

                    if (dt.Rows[0]["EnquiryDate"] != DBNull.Value)
                    {
                        DateTime enquiryDate = Convert.ToDateTime(dt.Rows[0]["EnquiryDate"]);
                        lblDateOfEnquiry1.Text = enquiryDate.ToString("dd-MM-yyyy");
                    }
                }
                else
                {
                    MessageBox.Show("No guest details found.", "Info",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching guest details:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FetchFollowUpHistoryAB()
        {
            try
            {
                clsUser obj = new clsUser();
                obj.GuestNameAB = G_Name1AB;
                obj.EnquiryCodeAB = G_CodeAB;
                DataTable dt = obj.FetchFollowUpAB();

                lstvwFollowUpHistory.BeginUpdate(); // Optimization: Stops UI flickering
                lstvwFollowUpHistory.Items.Clear();

                foreach (DataRow dr in dt.Rows)
                {
                    string formattedDate = "";
                    // Use "FollowUpDate" consistently
                    if (dr["FollowUpDate"] != DBNull.Value)
                    {
                        formattedDate = Convert.ToDateTime(dr["FollowUpDate"]).ToString("dd-MM-yyyy");
                    }

                    string formattedNextDate = "";
                    if (dr["NextDate"] != DBNull.Value)
                    {
                        formattedNextDate = Convert.ToDateTime(dr["NextDate"]).ToString("dd-MM-yyyy");
                    }

                    // Creating the row
                    ListViewItem item = new ListViewItem(formattedDate);
                    item.SubItems.Add(dr["FollowUpNote"].ToString());
                    
                    item.SubItems.Add(formattedNextDate);
                    item.SubItems.Add(dr["Status"].ToString());
                    lstvwFollowUpHistory.Items.Add(item);
                }
                lstvwFollowUpHistory.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching follow-up history:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblContact_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void connViewDetails1_Click(object sender, EventArgs e)
        {

        }

        private void lstvwFollowUpHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
