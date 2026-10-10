using DocumentFormat.OpenXml.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmApplyLea : Form
    {
        public DateTime formDate { get; set; }
        public DateTime toDate { get; set; }
        public String StaffName { get; set; }

        string staffCode;

        public frmApplyLea()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public frmApplyLea(string StaffCode)
        {
            try
            {
                InitializeComponent();
                this.staffCode = StaffCode;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStaffNameRP()
        {
            try
            {
                clsUser obj = new clsUser();
                DataTable dt = obj.GetStaffNameRP();

                cmbbxname.DataSource = null;
                cmbbxname.Items.Clear();

                cmbbxname.DisplayMember = "FullName";
                cmbbxname.ValueMember = "FullCode";
                cmbbxname.DataSource = dt;

                cmbbxname.MaxDropDownItems = 15;
                cmbbxname.IntegralHeight = false;
                cmbbxname.DropDownHeight = 250;

                cmbbxname.SelectedIndex = -1;
                cmbbxname.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff name:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                lblposition.Text = "";
                lblposition.Visible = false;

                dtpstartdate.Value = DateTime.Now;
                dtpenddate.Value = DateTime.Now;

                clsUser name = new clsUser();

                DataTable dt = name.GetStaffNameRP();
                LoadStaffNameRP();

                if (dt == null || dt.Rows.Count == 0)
                {
                    cmbbxname.DataSource = null;
                    MessageBox.Show("No staff data available.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmbbxname.DisplayMember = "FullName";
                    cmbbxname.ValueMember = "FullCode";
                    cmbbxname.DataSource = dt;
                    cmbbxname.SelectedIndex = -1;
                }

                DataTable dtLT = name.FetchLeaveTypeRP();

                if (dtLT == null || dtLT.Rows.Count == 0)
                {
                    cmbbxleavetype.DataSource = null;
                    MessageBox.Show("No leave type data available.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmbbxleavetype.DisplayMember = "LeaveTypeName";
                    cmbbxleavetype.ValueMember = "LeaveTypeID";
                    cmbbxleavetype.DataSource = dtLT;
                    cmbbxleavetype.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading form data:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxname_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxname.SelectedIndex == -1 || cmbbxname.SelectedValue == null)
                {
                    lblposition.Text = "";
                    lblposition.Visible = false;
                    staffCode = null;
                    return;
                }

                staffCode = cmbbxname.SelectedValue.ToString();

                if (string.IsNullOrWhiteSpace(staffCode))
                {
                    lblposition.Text = "";
                    lblposition.Visible = false;
                    return;
                }

                clsUser obj = new clsUser();
                lblposition.Text = "";
                lblposition.Visible = false;

                obj.StaffCodeRP = staffCode;
                string position = obj.StaffPRP();

                if (!string.IsNullOrWhiteSpace(position))
                {
                    lblposition.Text = position;
                    lblposition.Visible = true;
                }
            }
            catch (Exception ex)
            {
                lblposition.Text = "";
                lblposition.Visible = false;

                MessageBox.Show("Error loading position:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxname.SelectedIndex == -1 || cmbbxname.SelectedValue == null)
                {
                    MessageBox.Show("Please select Staff Name", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cmbbxleavetype.SelectedIndex == -1 || cmbbxleavetype.SelectedValue == null)
                {
                    MessageBox.Show("Please select Leave Type", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpstartdate.Value.Date < DateTime.Today)
                {
                    MessageBox.Show("Start date must be today or later", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (dtpenddate.Value.Date < dtpstartdate.Value.Date)
                {
                    MessageBox.Show("End date cannot be before start date", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtfcomment.Text))
                {
                    MessageBox.Show("Description is required", "Validation",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfcomment.Focus();
                    return;
                }

                clsUser objCls = new clsUser();

                objCls.StaffCodeRP = cmbbxname.SelectedValue.ToString();
                objCls.LeaveTypeIDRP = Convert.ToInt32(cmbbxleavetype.SelectedValue);
                objCls.StartDateRP = dtpstartdate.Value;
                objCls.EndDateRP = dtpenddate.Value;
                objCls.ApplyDateRP = DateTime.Now;
                objCls.DiscriptionRP = rtfcomment.Text.Trim();

                objCls.ApplyLeaveRP();

                MessageBox.Show("Leave Applied Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "This staff has already applied for leave Today.\n\n" + ex.Message,
                    "Validation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            try
            {
                DialogResult dr = MessageBox.Show("Are you sure you want to clear all fields?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dr == DialogResult.No)
                    return;

                cmbbxname.SelectedIndex = -1;
                cmbbxname.SelectedItem = null;
                cmbbxname.Text = "";

                cmbbxleavetype.SelectedIndex = -1;
                cmbbxleavetype.SelectedItem = null;
                cmbbxleavetype.Text = "";

                lblposition.Text = "";
                lblposition.Visible = false;

                dtpstartdate.Value = DateTime.Today;
                dtpenddate.Value = DateTime.Today;

                rtfcomment.Clear();
                staffCode = null;

                MessageBox.Show("All fields cleared successfully!", "Clear Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error clearing form:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblname_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}