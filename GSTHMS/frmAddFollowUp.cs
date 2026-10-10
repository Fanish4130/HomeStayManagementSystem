using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.Design;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace GSTHMS
{
    public partial class frmAddFollowUp : Form
    {
        DateTime lastNextDate = DateTime.MinValue;
        static  public string GuestNameAB;
        public string rcodeAB;
        public string receptionstnmAB;
        public string EnquiryCodeAB;
        public string UserNameAB;
        public string SubjectofenquiryAB;
        

        public frmAddFollowUp(string guestnm, string e_code)
        {
            InitializeComponent();
            GuestNameAB = guestnm;
            EnquiryCodeAB = e_code;
        }
        private void frmAddFollowUp_Load(object sender, EventArgs e)
        {
            try
            {
               

                // Assigning values passed from previous form
                txtGuestName.Text = GuestNameAB;
                txtGuestCode.Text = EnquiryCodeAB;
                GetEnquiryStatusAB();
                // Static display data
                lblReceptionist11.Text = Program.UserName;

                // UI Tweaks
                txtGuestCode.Visible = false;
                txtGuestName.Enabled = false;
                FetchFollowUpHistoryAB();
               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error while loading form: {ex.Message}", "Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void bttnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validation for Note
                if (string.IsNullOrWhiteSpace(rtfSubjectofEnquiry.Text))
                {
                    MessageBox.Show("Please enter follow-up note.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfSubjectofEnquiry.Focus();
                    return;
                }

                // 2. Validation for Dropdown (Prevents NullReferenceException)
                if (cmbbxEnquiry1.SelectedValue == null || cmbbxEnquiry1.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select a valid enquiry status.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DialogResult dr = MessageBox.Show("Are you sure you want to save this follow-up?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                clsUser obj = new clsUser();

                
                obj.EnquiryCodeAB = EnquiryCodeAB ?? "";
                obj.FollowUpNoteAB = rtfSubjectofEnquiry.Text.Trim();
                obj.StatusIDAB = Convert.ToInt32(cmbbxEnquiry1.SelectedValue);
                obj.Date1AB = DateTime.Now;
                obj.stNameAB = lblReceptionist11.Text;
                obj.StaffCodeAB = obj.GetRecNMAB();
                obj.NextDate = dtpNextDate.Value;
                obj.AddFollowUpAB();
                MessageBox.Show("Follow-up saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //obj.FetchEnquiryDetailsAB();
                //this.Close();
                FetchFollowUpHistoryAB();
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("An object was not initialized. Check if the ComboBox or Database connection is ready.\n\nDetails: " + ex.Message, "Null Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnClear_Click(object sender, EventArgs e)
        {
            rtfSubjectofEnquiry.Clear();
            if (cmbbxEnquiry1.Items.Count > 0) cmbbxEnquiry1.SelectedIndex = 0;
        }

        // Fetch Status
        public void GetEnquiryStatusAB()
        {
            try
            {
                clsUser obj1 = new clsUser();
                DataTable dt = obj1.FetchEnquiryStatusAB();

                if (dt != null && dt.Rows.Count > 0)
                {
                    
                    DataRow placeholderRow = dt.NewRow();
                    placeholderRow["StatusID"] = 0;
                    placeholderRow["Status"] = "-- Select Status --";
                    dt.Rows.InsertAt(placeholderRow, 0);

                    cmbbxEnquiry1.DataSource = dt;
                    cmbbxEnquiry1.DisplayMember = "Status";
                    cmbbxEnquiry1.ValueMember = "StatusID";
                    cmbbxEnquiry1.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Enquiry status list is empty.", "Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading status dropdown: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Fetch FollowUpHistory
        public void FetchFollowUpHistoryAB()
        {
            try
            {
                clsUser obj = new clsUser();
                
                obj.GuestNameAB = GuestNameAB;
                obj.EnquiryCodeAB = EnquiryCodeAB;
                DataTable dt = obj.FetchFollowUpAB();
                lstvwFollowUpHistory.Items.Clear();

                //foreach (DataRow dr in dt.Rows)
                //{

                //    string formattedDate = "";
                //    if (dr["Date"] != DBNull.Value)
                //    {
                //        formattedDate = Convert.ToDateTime(dr["Date"]).ToString("dd-MM-yyyy");
                //    }
                //    string formattedNextDate = "";
                //    if (dr["NextDate"] != DBNull.Value )
                //    {
                //        formattedNextDate = Convert.ToDateTime(dr["NextDate"]).ToString("dd-MM-yyyy");
                //    }
                //    ListViewItem item = new ListViewItem(formattedDate); 
                //    item.SubItems.Add(dr["FollowUpNote"].ToString());    
                //    item.SubItems.Add(formattedNextDate);               

                //    lstvwFollowUpHistory.Items.Add(item);
                //}
                foreach (DataRow dr in dt.Rows)
                {
                    string formattedDate = "";
                    // Change "Date" to "FollowUpDate" to match your SQL SELECT
                    if (dr["FollowUpDate"] != DBNull.Value)
                    {
                        formattedDate = Convert.ToDateTime(dr["FollowUpDate"]).ToString("dd-MM-yyyy");
                    }

                    string formattedNextDate = "";
                    if (dr["NextDate"] != DBNull.Value)
                    {
                        DateTime nextDt = Convert.ToDateTime(dr["NextDate"]);
                        if (nextDt > lastNextDate)
                        {
                            lastNextDate = nextDt;
                        }
                        formattedNextDate = nextDt.ToString("dd-MM-yyyy");
                    }

                    ListViewItem item = new ListViewItem(formattedDate);
                    item.SubItems.Add(dr["FollowUpNote"].ToString());
                    item.SubItems.Add(formattedNextDate);
                    item.SubItems.Add(dr["Status"].ToString());
                    lstvwFollowUpHistory.Items.Add(item);
                }
                if (lastNextDate != DateTime.MinValue)
                {
                    dtpNextDate.MinDate = lastNextDate.AddDays(1);
                    dtpNextDate.Value = lastNextDate.AddDays(1);
                }
                else
                {
                    dtpNextDate.MinDate = DateTime.Now.Date;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while fetching follow-up history:\n" + ex.Message,
                                "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void lblReceptionist1_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void connAddFollowUp1_Click(object sender, EventArgs e)
        {

        }

        private void dtpNextDate_ValueChanged(object sender, EventArgs e)
        {
            if (dtpNextDate.Value.Date <= lastNextDate.Date)
            {
                MessageBox.Show("Please select next valid date",
                                "Invalid Date",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);

                dtpNextDate.Value = lastNextDate.AddDays(1);
            }
        }

        private void lblNextDate_Click(object sender, EventArgs e)
        {

        }

        private void lblReceptionist11_Click(object sender, EventArgs e)
        {

        }
    }
 }

