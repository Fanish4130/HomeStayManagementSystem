
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;

namespace GSTHMS
{
    public partial class frmLeaveRPcs : Form
    {
        public frmLeaveRPcs()
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

        private void grdyearlyleave_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void cmbbxname_Click(object sender, EventArgs e)
        {
            try
            {
                frmApplyLea leave = new frmApplyLea();
                leave.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmstaffDetails());
                SetActiveTab(btnstaffdetails, btnleave, btnAttendance, btnTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetActiveTab(Guna2Button active, params Guna2Button[] others)
        {
            try
            {
                active.FillColor = Color.DimGray;
                active.ForeColor = Color.White;

                foreach (var btn in others)
                {
                    btn.FillColor = Color.White;
                    btn.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLeaveRPcs_Load(object sender, EventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmStaffLea());
                SetActiveTab(btnleave, btnAttendance, btnTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormInPanel1(Form frm)
        {
            try
            {
                pnlRP.Controls.Clear();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlRP.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormInPanel2(frmstaffcalendar frm)
        {
            try
            {
                pnlRP.Controls.Clear();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlRP.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormInPanel3(frmAssignedTask frm)
        {
            try
            {
                pnlRP.Controls.Clear();
                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                pnlRP.Controls.Add(frm);
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmStaffLea());
                SetActiveTab(btnleave, btnstaffdetails, btnAttendance, btnTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmstaffcalendar());
                SetActiveTab(btnAttendance, btnstaffdetails, btnleave, btnTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmAssignedTask());
                SetActiveTab(btnTask, btnstaffdetails, btnleave, btnAttendance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnstaffdetails_Click(object sender, EventArgs e)
        {
            try
            {
                LoadFormInPanel1(new frmstaffDetails());
                SetActiveTab(btnstaffdetails, btnleave, btnAttendance, btnTask);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlRP_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}