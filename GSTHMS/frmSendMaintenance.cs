using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmSendMaintenance : Form
    {
        public frmSendMaintenance()
        {
            InitializeComponent();
        }

        public int RoomTypeIDSJ { get; set; }
        public int ServiceTypeIDSJ { get; set; }
        public int InventoryIDSJ { get; set; }

        private bool isSubmitting = false;

        // 1. ROOM MAINTENANCE SEND BUTTON
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (isSubmitting) return;

            try
            {
                // --- Validations ---
                if (cmbbxRoomType.DataSource == null || cmbbxRoomType.SelectedIndex < 0 || cmbbxRoomType.SelectedValue == null)
                {
                    MessageBox.Show("Please select the Room Type", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxRoomType.Focus();
                    return;
                }

                if (cmbbxRoomName.DataSource == null || cmbbxRoomName.SelectedIndex < 0 || cmbbxRoomName.SelectedValue == null)
                {
                    MessageBox.Show("Please select the Room Name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxRoomName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtfDescription.Text))
                {
                    MessageBox.Show("Please enter the Description for the maintenance request", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfDescription.Focus();
                    return;
                }

                if (!Regex.IsMatch(rtfDescription.Text.Trim(), @"^[A-Za-z ]+$"))
                {
                    MessageBox.Show("Only characters allowed in Description", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfDescription.Focus();
                    return;
                }

                // --- Save Process ---
                isSubmitting = true;

                clsUser clsUser = new clsUser();
                string AddedBySJ = "RCPT002";

                clsUser.IDSJ = Convert.ToInt32(cmbbxRoomName.SelectedValue);
                clsUser.RoomDateSJ = DateTime.Now;
                clsUser.AddedBySJ = AddedBySJ;
                clsUser.DescriptionSJ = rtfDescription.Text.Trim();

                clsUser.SaveRoomMaintenance();

                MessageBox.Show("Room Maintenance Request Sent Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while sending room maintenance request: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSubmitting = false;
            }
        }

        // 2. SERVICE MAINTENANCE SEND BUTTON
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (isSubmitting) return;

            try
            {
                // --- Validations ---
                if (string.IsNullOrWhiteSpace(txtServiceType.Text))
                {
                    MessageBox.Show("Service Type is missing.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtfDescription1.Text))
                {
                    MessageBox.Show("Please enter the Description for the service maintenance request", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfDescription1.Focus();
                    return;
                }

                // --- Save Process ---
                isSubmitting = true;

                clsUser clsUser = new clsUser();
                string AddedBySJ = "RCPT002";

                clsUser.ServiceDateSJ = DateTime.Now;
                clsUser.AddedBySJ = AddedBySJ;
                clsUser.DescriptionSJ = rtfDescription1.Text.Trim();


                clsUser.SaveServiceMaintenance();

                MessageBox.Show("Service Maintenance Request Sent Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while sending service maintenance request: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSubmitting = false;
            }
        }

        // 3. INVENTORY MAINTENANCE SEND BUTTON
        private void guna2Button3_Click(object sender, EventArgs e)
        {
            if (isSubmitting) return;

            try
            {
                // --- Validations ---
                if (cmbbxInventoryName.DataSource == null || cmbbxInventoryName.SelectedIndex < 0 || cmbbxInventoryName.SelectedValue == null)
                {
                    MessageBox.Show("Please select the Inventory Name", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbbxInventoryName.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(rtfDescription2.Text))
                {
                    MessageBox.Show("Please enter the Description for the inventory maintenance request", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    rtfDescription2.Focus();
                    return;
                }

                // --- Save Process ---
                isSubmitting = true;

                clsUser clsUser = new clsUser();
                string AddedBySJ = "RCPT002";

                clsUser.IDSJ = Convert.ToInt32(cmbbxInventoryName.SelectedValue);
                clsUser.InventoryDateSJ = DateTime.Now;
                clsUser.AddedBySJ = AddedBySJ;
                clsUser.DescriptionSJ = rtfDescription2.Text.Trim();

                clsUser.SaveInventoryMaintenance();

                MessageBox.Show("Inventory Maintenance Request Sent Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while sending inventory maintenance request: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                isSubmitting = false;
            }
        }

        // FORM LOAD
        private void frmSendMaintenance_Load(object sender, EventArgs e)
        {
            try
            {
                connRoomMaintenance.Visible = true;
                connInventoryMaintenance.Visible = false;
                connServiceMaintenance.Visible = false;

                // Bind Maintenance Type
                clsUser objm = new clsUser();
                DataTable dtm = objm.GetMaintenanceTypeSJ();
                cmbbxMaintenanceType.DisplayMember = "SubTypeName";
                cmbbxMaintenanceType.ValueMember = "TypeID";
                cmbbxMaintenanceType.DataSource = dtm;
                cmbbxMaintenanceType.SelectedIndex = -1;

                // Bind Room Type
                clsUser objr = new clsUser();
                DataTable dtr = objr.GetRoomTypeNameSJ();
                cmbbxRoomType.DisplayMember = "RoomTypeName";
                cmbbxRoomType.ValueMember = "RoomTypeID";
                cmbbxRoomType.DataSource = dtr;
                cmbbxRoomType.SelectedIndex = -1; 

                // Bind Service Type
                clsUser objs = new clsUser();
                DataTable dts = objs.GetServiceTypeNameSJ();
                dts.DefaultView.RowFilter = "ServiceType = 'Parking Service'";
                txtServiceType.Text = dts.DefaultView.Count > 0 ? dts.DefaultView[0]["ServiceType"].ToString() : "";

                // Bind Inventory
                clsUser obji = new clsUser();
                DataTable dti = obji.GetInventoryNameSJ();
                cmbbxInventoryName.DisplayMember = "InventoryName";
                cmbbxInventoryName.ValueMember = "InventoryID";
                cmbbxInventoryName.DataSource = dti;
                cmbbxInventoryName.SelectedIndex = -1;

                // Dates Reset & Disable
                ResetDates();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while initializing maintenance form: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetDates()
        {
            dtpReportDate.Value = DateTime.Today;
            dtpReportDate.Enabled = false;
            dtpReportDate1.Value = DateTime.Today;
            dtpReportDate1.Enabled = false;
            dtpReportedDate2.Value = DateTime.Today;
            dtpReportedDate2.Enabled = false;
        }

        private void cmbbxRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbbxRoomType.SelectedValue != null && int.TryParse(cmbbxRoomType.SelectedValue.ToString(), out int selectedId))
                {
                    RoomTypeIDSJ = selectedId;

                    clsUser objrm = new clsUser();
                    objrm.RoomTypeIDSJ = RoomTypeIDSJ;
                    DataTable dtrm = objrm.GetRoomNameSJ();

                    cmbbxRoomName.DisplayMember = "RoomName";
                    cmbbxRoomName.ValueMember = "RoomID";
                    cmbbxRoomName.DataSource = dtrm;
                    cmbbxRoomName.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading room names: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbbxMaintenanceType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                string selectedType = cmbbxMaintenanceType.Text;

             
                connRoomMaintenance.Visible = (selectedType == "Room Maintenance");
                connInventoryMaintenance.Visible = (selectedType == "Inventory Maintenance");
                connServiceMaintenance.Visible = (selectedType == "Service Maintenance");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while switching maintenance type: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- CLEAR BUTTONS ---
        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbbxRoomType.SelectedIndex = -1;
            cmbbxRoomName.DataSource = null; 
            rtfDescription.Clear();
            dtpReportDate.Value = DateTime.Today;
            cmbbxRoomType.Focus();
        }

        private void btnClearIN_Click(object sender, EventArgs e)
        {
            cmbbxInventoryName.SelectedIndex = -1;
            rtfDescription2.Clear();
            dtpReportedDate2.Value = DateTime.Today;
            cmbbxInventoryName.Focus();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            rtfDescription1.Clear();
            dtpReportDate1.Value = DateTime.Today;
        }

        private void pctExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // for not changing date
        private void dtpReportDate_ValueChanged(object sender, EventArgs e) => ResetDates();
        private void dtpReportDate1_ValueChanged(object sender, EventArgs e) => ResetDates();
        private void dtpReportedDate2_ValueChanged(object sender, EventArgs e) => ResetDates();

        private void rtfDescription_TextChanged(object sender, EventArgs e) { }
        private void txtServiceType_TextChanged(object sender, EventArgs e) { }
        private void cmbbxMaintenanceType_SelectedIndexChanged(object sender, EventArgs e) { }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}