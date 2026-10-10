using DocumentFormat.OpenXml.ExtendedProperties;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using DocumentFormat.OpenXml.Vml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSTHMS.clsUser;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace GSTHMS
{


    public partial class frmPayment : Form
    {
        decimal alreadyPaidSP = 0;
        int installmentNoSP = 0;

        decimal roomChargesSP = 0;
        decimal inventoryChargesSP = 0;
        decimal foodChargesSP = 0;
        decimal eventChargesSP = 0;
        decimal fineSP = 0;
       

        string bookingCodeSP { get; set; }
       
        decimal baseTotal = 0m;
        decimal offerDiscount = 0m;
        decimal fineAmount = 0m;
        decimal lastRemaining = 0m;
        DataTable Payment = new DataTable();
        public event Action PaymentCompleted;
        public frmPayment(string guestname, int fine, string ic, string bookingCode)
        {
            InitializeComponent();
            this.GNMSP = guestname;
            this.invoiceCodeSP = invoiceCodeSP;
            
            this.bookingCodeSP = bookingCode;

            GNMSP = guestname;
            FINESP = fine;
            lblname.Text = GNMSP;
            txtFine.Text = FINESP.ToString();
            icodeSP = ic;
            bookingCode = bookingCode;
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

        }

        public string GNMSP { get; set; }
        public int FINESP { get; set; }
        public double basepriceSP { get; set; }
        public string bookingcodeSP { get; set; }
        public string inventorynameSP { get; set; }
        public string offernameSP { get; set; }
        public int orderfoodidSP { get; set; }
        public string serviceSP { get; set; }
        public string paymentmethodSP { get; set; }
        public int paymentmethodidSP { get; set; }
        public string statusSP { get; set; }
        public int statusidSP { get; set; }
        public string homestaybankSP { get; set; }
        public int homestaybankidSP { get; set; }
        public string icodeSP { get; set; }
        public string invoiceCodeSP { get; set; }
        public DataTable dtItemsSP { get; set; }
        public int oDiscountSP { get; set; }
        public string GuestCodeSP { get; set; }
        private void frmPayment_Load(object sender, EventArgs e)
        {

            txtAmtToPay.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtFine.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtPAmt.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtRemaining.Font = new Font("Segoe UI", 14, FontStyle.Regular);
            txtOffer.Font = new Font("Segoe UI", 14, FontStyle.Regular);

            grdinfo.ReadOnly = true;
            //grid horizontal and vertical border lines
            grdinfo.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdinfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdinfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdinfo.GridColor = System.Drawing.Color.Gray;
            txtOffer.ReadOnly = true;
            txtAmtToPay.ReadOnly = true;
            txtRemaining.ReadOnly = true;
            
            decimal baseTotal = 0;
            txtAmtToPay.Text = baseTotal.ToString("0.00");
            txtRemaining.Text = baseTotal.ToString("0.00");
            grdinfo.ReadOnly = true;
            this.grdinfo.DefaultCellStyle.Font = new Font("Arial", 12);
            this.grdinfo.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10);

            clsUser cls = new clsUser();
            DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            grdinfo.ReadOnly = true;
            ShowBankDetailsSP();

            LoadPayGridSP();
           
            decimal.TryParse(txtAmtToPay.Text, out baseTotal);

            cls.bookingcodeSP = lblcode.Text;
            DataTable dt1 = cls.GetRemPaidAmtSP();
            if (dt1.Rows.Count > 0)
            {
                int AmtToPay = Convert.ToInt32(dt1.Rows[0]["AmtToPay"]);
                int RemAmt = Convert.ToInt32(dt1.Rows[0]["RemainingAmount"]);
                if (AmtToPay > RemAmt)
                    cls.statusidSP = 22;
            }
 
            cls.GuestNameSP = GNMSP;
            cls.FineSP = FINESP;
            cls.invoicecodeSP = icodeSP;


            //ShowPay info on Form

            //cls.GuestNameSP = GNMSP;
            //cls.FineSP = FINESP;
            cls.bookingcodeSP = lblcode.Text;
            DataTable dt = cls.PayInfoSP();

            if (dt.Rows.Count > 0)
            {
                lblcode.Text = dt.Rows[0]["BookingCode"].ToString();

                // Offer Name
                string offerName = dt.Rows[0]["OfferName"] == DBNull.Value
                                   || string.IsNullOrWhiteSpace(dt.Rows[0]["OfferName"].ToString())
                                   ? "No Offer"
                                   : dt.Rows[0]["OfferName"].ToString();
                lblOffer.Text = offerName;

                // Fine Description
                string fineDesc = dt.Rows[0]["FineDescription"] == DBNull.Value
                                  ? string.Empty
                                  : dt.Rows[0]["FineDescription"].ToString();
                rtfFineDiscription.Text = fineDesc;

                // Discount Amount
                string discountAmt = dt.Rows[0]["Discount_amt"] == DBNull.Value
                                     || string.IsNullOrWhiteSpace(dt.Rows[0]["Discount_amt"].ToString())
                                     ? "0.00"
                                     : Convert.ToDecimal(dt.Rows[0]["Discount_amt"]).ToString("0.00");
                txtOffer.Text = discountAmt;
            }
            else
            {
                //MessageBox.Show("No Data Found");
                lblOffer.Text = "No Offer";
                txtOffer.Text = "0.00";
            }



        }
     
        //radio button
        private void rdbtnUPI_CheckedChanged(object sender, EventArgs e)
        {
            ShowBankDetailsSP();
        }
        private void rdbtnBankTransfer_CheckedChanged(object sender, EventArgs e)
        {
            ShowBankDetailsSP();
        }

        private void rdbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            ShowBankDetailsSP();
        }

        private void ShowBankDetailsSP()
        {
            if (rdbtnBankTransfer.Checked)
            {
                lblBankName.Visible = true;
                cmbbxBank.Visible = true;
                lblAccountNo.Visible = true;
                lblANO.Visible = true;
                lblIFSCCode.Visible = true;
                lblif.Visible = true;
                lblUI.Visible = true;
                lblUPIID.Visible = true;

                // Fetch on combobox
                clsUser objP = new clsUser();
                DataTable dt = objP.PaymentSP();

                cmbbxBank.DisplayMember = "BankName";
                cmbbxBank.ValueMember = "HomestayBankID";
                cmbbxBank.DataSource = dt;
                cmbbxBank.Show();
            }
            else if (rdbtnUPI.Checked)
            {
                lblBankName.Visible = true;
                cmbbxBank.Visible = true;
                lblAccountNo.Visible = false;
                lblANO.Visible = false;
                lblIFSCCode.Visible = false;
                lblif.Visible = false;
                lblUI.Visible = true;      // UPI fields visible
                lblUPIID.Visible = true;
                // Fetch on combobox
                clsUser objP = new clsUser();
                DataTable dt = objP.PaymentSP();

                cmbbxBank.DisplayMember = "BankName";
                cmbbxBank.ValueMember = "HomestayBankID";
                cmbbxBank.DataSource = dt;
                cmbbxBank.Show();
            }
            else if (rdbtnCash.Checked)
            {
                // Cash selected → hide all bank/UPI fields
                lblBankName.Visible = false;
                cmbbxBank.Visible = false;
                lblAccountNo.Visible = false;
                lblANO.Visible = false;
                lblIFSCCode.Visible = false;
                lblif.Visible = false;
                lblUI.Visible = false;
                lblUPIID.Visible = false;
            }
            else
            {
                // Nothing selected → hide everything
                lblBankName.Visible = false;
                cmbbxBank.Visible = false;
                lblAccountNo.Visible = false;
                lblANO.Visible = false;
                lblIFSCCode.Visible = false;
                lblif.Visible = false;
                lblUI.Visible = false;
                lblUPIID.Visible = false;
            }
        }

        private void cmbbxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbbxBank.SelectedValue != null)
            {
                homestaybankidSP = Convert.ToInt32(cmbbxBank.SelectedValue.ToString());

                clsUser objU = new clsUser();
                objU.homestaybankidSP = homestaybankidSP;
                DataTable dt = objU.AccountSP(); // return bank details

                if (dt.Rows.Count > 0)
                {
                    if(rdbtnBankTransfer.Checked)
                    {
                        lblAccountNo.Text = "Account No:";
                        lblBname.Text = dt.Rows[0]["BankName"].ToString();
                        lblANO.Text = dt.Rows[0]["AccountNo"].ToString();
                        lblif.Text = dt.Rows[0]["IFSCCode"].ToString();
                        lblUI.Text = "Branch Name:";
                        lblUPIID.Text = dt.Rows[0]["BranchName"].ToString();
                    }
                     else if(rdbtnUPI.Checked) 
                     {
                        lblUI.Text = "UPI ID  :";
                        lblUPIID.Text = dt.Rows[0]["UPIId"].ToString();
                    }
                    //lblBname.Text = dt.Rows[0]["BankName"].ToString();
                    //lblANO.Text = dt.Rows[0]["AccountNo"].ToString();
                    //lblif.Text = dt.Rows[0]["IFSCCode"].ToString();
                    //lblUPIID.Text =
                }
            }
        }

        private void txtAmtToPay_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void lblAmtToPay_Click(object sender, EventArgs e)
        {

        }

        //private void txtPAmt_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        decimal total = 0m;
        //        decimal paid = 0m;
        //        decimal remainingBase = 0m;
        //        decimal fine = 0;
        //        decimal.TryParse(txtAmtToPay.Text, out total);
        //        decimal.TryParse(txtPAmt.Text, out paid);
        //        decimal.TryParse(txtRemaining.Text, out remainingBase);

        //        // for Paid Amt Limit
        //        decimal maxPayable = lastRemaining > 0 ? lastRemaining : total;

        //        if (paid > maxPayable)
        //        {
        //            MessageBox.Show($"You can pay maximum ₹{maxPayable:0.00} only.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtPAmt.Text = maxPayable.ToString("0.00");
        //            paid = maxPayable;
        //        }

        //        //  Remaining  (fine consider not)
        //        decimal remaining = (lastRemaining > 0 ? lastRemaining : baseTotal) - paid;
        //        if (remaining < 0)
        //            remaining = 0;

        //        txtRemaining.Text = remaining.ToString("0.00");

        //        UpdateTotals();
        //    }


        //    catch (Exception ex)
        //    {
        //        // Handle gracefully: etc.
        //        MessageBox.Show("Error updating PAmt: " + ex.Message,
        //                        "UpdateTotals Error",
        //                        MessageBoxButtons.OK,
        //                        MessageBoxIcon.Error);
        //    }
        //}
        private void txtPAmt_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal total = 0m;
                decimal paid = 0m;
                decimal remainingBase = 0m;
                decimal fine = 0m;

                decimal.TryParse(txtAmtToPay.Text, out total);
                decimal.TryParse(txtPAmt.Text, out paid);
                decimal.TryParse(txtRemaining.Text, out remainingBase);
                decimal.TryParse(txtFine.Text, out fine); // assuming fine textbox

                // 
                decimal maxPayable = (lastRemaining > 0 ? lastRemaining : total) + fine;

                if (paid > maxPayable)
                {
                    MessageBox.Show($"You can pay maximum ₹{maxPayable:0.00} only.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPAmt.Text = maxPayable.ToString("0.00");
                    paid = maxPayable;
                }

                // 🔹 Remaining calculation (fine considered)
                decimal effectiveTotal = (lastRemaining > 0 ? lastRemaining : total) + fine;
                decimal remaining = effectiveTotal - paid;

                if (remaining < 0)
                    remaining = 0;

                txtRemaining.Text = remaining.ToString("0.00");

                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void UpdateTotals()
        {
            try
            {
                decimal discount = 0m;
                decimal fine = 0m;
                decimal payment = 0m;

                var culture = new CultureInfo("en-IN");

                // Parse Offer
                if (!string.IsNullOrWhiteSpace(txtOffer.Text))
                    decimal.TryParse(txtOffer.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out discount);

                // Parse Fine
                if (!string.IsNullOrWhiteSpace(txtFine.Text))
                    decimal.TryParse(txtFine.Text, out fine);
                else
                    txtFine.Text = 0m.ToString("0.00");

                // Parse Payment
                if (!string.IsNullOrWhiteSpace(txtPAmt.Text))
                    decimal.TryParse(txtPAmt.Text, out payment);

                //  Grand Total must be set from backend before calling this
                decimal grandTotal = baseTotal;

                //  Amt To Pay = Grand Total - Discount + Fine
                decimal amtToPay = Math.Max(0, grandTotal - discount + fine);
                txtAmtToPay.Text = amtToPay.ToString("C2", culture);

                ////  Remaining calculation
                //decimal remaining;
                //if (lastRemaining > 0)
                //{
                //    // Subsequent payments → use lastRemaining directly
                //    remaining = lastRemaining - payment;
                //}
                //else
                //{
                //    // First payment → AmtToPay - payment
                //    remaining = amtToPay - payment;
                //}

                //if (remaining < 0) remaining = 0;

                //txtRemaining.Text = remaining.ToString("C2", culture);

                //clsUser cls = new clsUser();
                //// 🔹 Pass to backend log/SP
                //cls.RemainingAmountSP = remaining;
                // Remaining calculation (fine considered)
                decimal remaining;

                if (lastRemaining > 0)
                {
                    // Subsequent payments → use lastRemaining + fine
                    remaining = (lastRemaining + fine) - payment;
                }
                else
                {
                    // First payment → AmtToPay + fine - payment
                    remaining = (amtToPay + fine) - payment;
                }

                if (remaining < 0) remaining = 0;

                txtRemaining.Text = remaining.ToString("C2", culture);

                clsUser cls = new clsUser();
                // 🔹 Pass to backend log/SP
                cls.RemainingAmountSP = remaining;
            }
            catch (Exception ex)
            {
                // Handle gracefully: log, show message, etc.
                MessageBox.Show("Error updating totals: " + ex.Message,
                                "UpdateTotals Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
           
            // 1) Clear all TextBox
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox)
                    ctrl.Text = string.Empty;

                if (ctrl is System.Windows.Forms.RichTextBox)
                    ctrl.Text = string.Empty;

                if (ctrl is System.Windows.Forms.ComboBox combo)
                    combo.SelectedIndex = -1;

            }

            // 2) Clear all Labels  
          //  lblname.Text = "";
            //lblcode.Text = "";
            //lblOffer.Text = "";
            lblAccountNo.Text = "";
            lblIFSCCode.Text = "";
            lblUPIID.Text = "";
            txtAmtToPay.Clear();
            txtFine.Clear();
            txtPAmt.Clear();
            //txtOffer.Clear();
            //txtRemaining.Clear();
            rdbtnBankTransfer.Checked = false;
            rdbtnCash.Checked = false;
            rdbtnUPI.Checked = false;
            rtfFineDiscription.ResetText();
            
          
        }

        private void txtPAmt_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as Guna.UI2.WinForms.Guna2TextBox;

            // Allow only digits, control keys (like backspace), and one dot
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric characters
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && txt.Text.Contains("."))
                e.Handled = true;

        }

        int Pending;
        Decimal a; Decimal p;
        string P1;String A1;
        private void btnPay_Click(object sender, EventArgs e)
        {

            try
            {
                // ---------------- Payment Method Validation ----------------
                if (!rdbtnBankTransfer.Checked && !rdbtnCash.Checked && !rdbtnUPI.Checked)
                {
                    MessageBox.Show("Please select a payment method.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ---------------- Paid Amount Validation ----------------
                if (string.IsNullOrWhiteSpace(txtPAmt.Text))
                {
                    MessageBox.Show("Please enter the Paid Amount.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPAmt.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPAmt.Text, out decimal paidAmount) || paidAmount <= 0)
                {
                    MessageBox.Show("Invalid Paid Amount. It must be greater than 0.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPAmt.Focus();
                    return;
                }

                // ---------------- Amount To Pay Validation ----------------
                if (string.IsNullOrWhiteSpace(txtAmtToPay.Text))
                {
                    MessageBox.Show("Amount To Pay is missing.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmtToPay.Focus();
                    return;
                }

                var culture = new CultureInfo("en-IN");
                if (!decimal.TryParse(txtAmtToPay.Text, NumberStyles.Currency, culture, out decimal totalAmount))
                {
                    MessageBox.Show("Invalid Amount To Pay.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAmtToPay.Focus();
                    return;
                }

                if (paidAmount > totalAmount)
                {
                    MessageBox.Show("Paid amount cannot be greater than Amount To Pay.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPAmt.Focus();
                    return;
                }

                // ---------------- Fine Validation ----------------
              
                decimal fine = 0m;
                if (!string.IsNullOrWhiteSpace(txtFine.Text))
                {
                    if (!decimal.TryParse(txtFine.Text, out fine) || fine < 0)
                    {
                        MessageBox.Show("Fine must be a valid non-negative number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFine.Focus();
                        return;
                    }
                }

                if (fine > 0)
                {
                    if (string.IsNullOrWhiteSpace(rtfFineDiscription.Text))
                    {
                        MessageBox.Show("Please enter a fine description.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        rtfFineDiscription.Focus();
                        return;
                    }
                }
                else
                {
                    // Default description when no fine
                    rtfFineDiscription.Text = "No fine";
                }
                // ---------------- Confirmation ----------------
                DialogResult dr = MessageBox.Show("Are you sure you want to proceed with the payment?", "Confirm Payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No) return;

                // ---------------- Set Payment Method ----------------
                string paymentmethodSP = string.Empty;
                if (rdbtnBankTransfer.Checked)
                    paymentmethodSP = "Bank";
                else if (rdbtnCash.Checked)
                    paymentmethodSP = "Cash";
                else if (rdbtnUPI.Checked)
                    paymentmethodSP = "UPI";

                // ---------------- Save Payment ----------------
                clsUser objReg = new clsUser
                {
                    bookingcodeSP = lblcode.Text,
                    paymentmethodSP = paymentmethodSP
                };

                int paymentmethodidSP = Convert.ToInt32(objReg.GetPaymentMenthodIdSP());
                objReg.PaymentMethodidSP = paymentmethodidSP;

                // P1 = txtRemaining.Text.Replace("₹", "").Trim();
                //if(P1=="0.00")
                //    objReg.statusidSP = 22;
                //else
                //    objReg.statusidSP = 4;
                string remainingText = txtRemaining.Text
    .Replace("₹", "")
    .Replace(",", "")
    .Trim();

                decimal remainingAmount = 0;

                decimal.TryParse(remainingText, out remainingAmount);

                if (remainingAmount <= 0)
                    objReg.statusidSP = 22;   // Paid
                else
                    objReg.statusidSP = 4;    // Pending

                objReg.homestaybankidSP = homestaybankidSP;
                objReg.orderfoodidSP = orderfoodidSP;
                //  objReg.PaidAmountSP = paidAmount;
                string rawAmtP = txtPAmt.Text.Replace("₹", "").Trim();
                objReg.PaidAmountSP = Convert.ToDecimal(rawAmtP);
                // objReg.FineSP = string.IsNullOrWhiteSpace(txtFine.Text) ? 0 : Convert.ToInt32(txtFine.Text);
                if (decimal.TryParse(txtFine.Text, out var fineVal))
                    objReg.FineSP = (int)Math.Round(fineVal); // or (int)fineVal if truncation is okay
                else
                    objReg.FineSP = 0;
                objReg.finediscriptionSP = rtfFineDiscription.Text;

                string rawAmt = txtAmtToPay.Text.Replace("₹", "").Trim();
                objReg.amttopaySP = Convert.ToDecimal(rawAmt);

                ////objReg.invoicecodeSP = icodeSP;
                ////// Save payment in main table

                ////objReg.PaySP();
                objReg.invoicecodeSP = icodeSP;

                // Save payment in main table
                objReg.PaySP();

                if (objReg.statusidSP == 22)
                {
                    objReg.UpdateAllPaymentPaidStatusSP();
                }

                // Save in log
                clsUser objLog = new clsUser
                {
                    GuestNameSP = lblname.Text
                };
               
                GuestCodeSP = objLog.GetGuestCodeSP();
                objLog.GuestCodeSP = GuestCodeSP;
                objLog.bookingcodeSP = lblcode.Text;
                P1 = txtRemaining.Text.Replace("₹", "").Replace(",", "").Trim();
                p = Convert.ToDecimal(P1);
                objLog.RemainingAmountSP = p;
                objLog.PayInLogSP();

                MessageBox.Show("Payment Successfully Completed ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PaymentCompleted?.Invoke();
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing payment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void lblInvCharge_Click(object sender, EventArgs e)
        {

        }

        private void grdinfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void ApplyInstallmentLogic()
        {
            try
            {
                foreach (DataGridViewRow row in grdinfo.Rows)
                {
                    if (row.IsNewRow) continue;

                    string type = row.Cells["ItemType"].Value.ToString();
                    decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);

                    // Installment 1 = फक्त ROOM चे 50%
                    if (installmentNoSP == 1)
                    {
                        if (type == "Room Stay")
                            row.Cells["Amount"].Value = amount * 0.5m;
                        else
                            row.Cells["Amount"].Value = 0;
                    }

                    // Installment 2 = FULL amount प्रत्येक ItemType चे
                    else if (installmentNoSP == 2)
                    {
                        row.Cells["Amount"].Value = amount; // Full amount
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing payment Instolment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            CalculateTotalAfterInstallment();
        }
        private void CalculateTotalAfterInstallment()
        {
            try
            {
                decimal subtotal = 0;

                foreach (DataGridViewRow row in grdinfo.Rows)
                {
                    if (!row.IsNewRow && row.Cells["Amount"].Value != null)
                        subtotal += Convert.ToDecimal(row.Cells["Amount"].Value);
                }
                // Offer / Discount
                decimal discount = 0;
                if (!string.IsNullOrWhiteSpace(txtOffer.Text))
                    decimal.TryParse(txtOffer.Text, NumberStyles.Number, CultureInfo.InvariantCulture, out discount);
                if (discount < 0) discount = 0;

                // Net Total = Subtotal - Offer
                decimal amtToPay = Math.Max(0, subtotal - discount);

                var culture = new CultureInfo("en-IN");
                txtAmtToPay.Text = amtToPay.ToString("C2", culture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing payment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadPayGridSP()
        {
            try
            {
                clsUser objInvoice = new clsUser();
                objInvoice.bookingcodeSP = bookingCodeSP;
                DataTable dt = objInvoice.GetPayDataSP();

                string OrderFood = "";
                lblcode.Text = bookingCodeSP;

                DataRow[] rows = dt.Select("ItemType = 'Food'");
                if (rows.Length > 0)
                {
                    OrderFood = rows[0]["ItemName"].ToString();
                }
                objInvoice.OrderFoodSP = OrderFood;
                orderfoodidSP = objInvoice.GetOrderFoodIdSP();

                grdinfo.DataSource = dt;

                // Subtotal (items only)
                decimal subtotal = dt.AsEnumerable()
                                     .Where(r => r["Amount"] != DBNull.Value)
                                     .Sum(r => Convert.ToDecimal(r["Amount"]));

                // ServiceCharge
                decimal tax = dt.AsEnumerable()
                                .Where(r => r["ItemType"].ToString() == "Tax")
                                .Sum(r => Convert.ToDecimal(r["Amount"]));

                decimal serviceCharge = dt.AsEnumerable()
                                          .Where(r => r["ItemType"].ToString() == "Service")
                                          .Sum(r => Convert.ToDecimal(r["Amount"]));

                // Grand Total
                baseTotal = subtotal + tax + serviceCharge;

                // Get remaining from log table
                lastRemaining = objInvoice.GetRemainingAmountSP();
                bookingcodeSP = objInvoice.bookingcodeSP;

                // Apply installment logic
                ApplyInstallmentLogic();

                // Unified calculation (Offer + Fine + Remaining)
                UpdateTotals();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing payment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbloff_Click(object sender, EventArgs e)
        {

        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }
        

        

        private void txtOffer_TextChanged(object sender, EventArgs e)
        {
            UpdateTotals();
        }

        private void lblBookingCode_Click(object sender, EventArgs e)
        {

        }

        private void lblIFSCCode_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl2_Click(object sender, EventArgs e)
        {

        }

        private void txtFine_KeyPress(object sender, KeyPressEventArgs e)
        {
            var txt = sender as Guna.UI2.WinForms.Guna2TextBox;

            // Allow only digits, control keys (like backspace), and one dot
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-numeric characters
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && txt.Text.Contains("."))
                e.Handled = true;
        }

        private void grdinfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if ((grdinfo.Columns[e.ColumnIndex].Name == "UnitPrice"
             || grdinfo.Columns[e.ColumnIndex].Name == "Amount")
            && e.Value != null)
                {
                    decimal val;
                    if (decimal.TryParse(e.Value.ToString(), out val))
                    {
                        e.Value = val.ToString("C2", new CultureInfo("en-IN"));
                        e.FormattingApplied = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while processing payment:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRemaining_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rtfFineDiscription_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtfFineDiscription_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lblAccountNo_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }
    }
}