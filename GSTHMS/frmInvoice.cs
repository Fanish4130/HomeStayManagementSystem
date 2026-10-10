using DocumentFormat.OpenXml.ExtendedProperties;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GSTHMS.clsUser;

namespace GSTHMS
{
    public partial class frmInvoice : Form
    {
        decimal total = 0m;
        decimal baseTotal = 0m;
        clsUser objInvoice = new clsUser();

        string guestNameSP, invoiceCodeSP;
        string bookingCodeSP { get; set; }

        public string GNMSP { get; set; }

        public string icodeSP { get; set; }
        public string UserName { get; set; }

        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();
        // --- Add this at the top of your class (outside any method) ---
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);



        public frmInvoice(string guestName, string invoiceCode, string bookingCode)
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            this.guestNameSP = guestName;
            this.invoiceCodeSP = invoiceCode;
            this.bookingCodeSP = bookingCode;


            icodeSP = invoiceCode;
            GNMSP = guestName;
            lblinvvv.Text = icodeSP;
            bookingCode = bookingCode;
            lblBCode.Text = bookingCode;
           this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
        }


        private void frmInvoice_Load(object sender, EventArgs e)
        {
            grdInvoiceDetails.ReadOnly = true;
            //grid horizontal and vertical border lines
            grdInvoiceDetails.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            grdInvoiceDetails.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInvoiceDetails.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            grdInvoiceDetails.GridColor = System.Drawing.Color.Gray;
            printDocument.PrintPage += printDocument1_PrintPage;
           
            grdInvoiceDetails.AllowUserToResizeColumns = false;
            this.grdInvoiceDetails.DefaultCellStyle.Font = new Font("Arial", 12);
            this.grdInvoiceDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 12);

            lblname.Text = guestNameSP;

            lblGenrated.Text = Program.UserName;

            lblIDate.Text = DateTime.Now.ToString("dd-MM-yyyy hh:mm tt");
            clsUser cls = new clsUser();
            cls.GuestNameSP = GNMSP;
            cls.invoicecodeSP = icodeSP;

            //DataTable dt = cls.PayInfoSP();
            //foreach (DataRow row in dt.Rows)
            //{
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        lblBCode.Text = row["BookingCode"].ToString();
            //        lbldiscount.Text = dt.Rows[0]["Discount_amt"].ToString();

            //    }
            //}
            cls.bookingcodeSP = lblBCode.Text;
            DataTable dt = cls.PayInfoSP();
            if (dt.Rows.Count > 0)
            {

                // Discount Amount
                string discountAmt = dt.Rows[0]["Discount_amt"] == DBNull.Value
                                     || string.IsNullOrWhiteSpace(dt.Rows[0]["Discount_amt"].ToString())
                                     ? "0.00"
                                     : Convert.ToDecimal(dt.Rows[0]["Discount_amt"]).ToString("0.00");
                lbldiscount.Text = discountAmt;
               
            }
            else
            {

                lbldiscount.Text = "0.00";
            }

            if (dt.Rows.Count > 0)
            {

                // Discount Amount
                string remaningAmt = dt.Rows[0]["RemainingAmount"] == DBNull.Value
                                     || string.IsNullOrWhiteSpace(dt.Rows[0]["RemainingAmount"].ToString())
                                     ? "0.00"
                                     : Convert.ToDecimal(dt.Rows[0]["RemainingAmount"]).ToString("0.00");
                lblremaning.Text = remaningAmt;

            }
            else
            {

                lbldiscount.Text = "0.00";
            }


            Decimal paidamisp = cls.GetCurrentPaidAmtSP(icodeSP);

            if (paidamisp == 0)
            {
                lblCpaid.Text = "0";

            }
            else
            {
                lblCpaid.Text = paidamisp.ToString();
            }

            DataTable dtI = cls.InvoiceInfoSP();
            if (dtI.Rows.Count > 0)
            {
                lblCheckdate.Text = dtI.Rows[0]["Checkin"].ToString();
                lblcheckOut.Text = dtI.Rows[0]["Checkout"].ToString();

            }
            else
            {
                MessageBox.Show("No Data Found");
            }
            LoadInvoiceGridSP();


        }

        private void LoadInvoiceGridSP()
        {
            try
            {
                clsUser objInvoice = new clsUser();
                objInvoice.bookingcodeSP = bookingCodeSP;
                DataTable dt = objInvoice.GetInvoiceDataSP();

                grdInvoiceDetails.DataSource = dt;

                // Calculate subtotal
                decimal subtotal = 0;
                foreach (DataRow row in dt.Rows)
                {
                    if (row["Amount"] != DBNull.Value)
                        subtotal += Convert.ToDecimal(row["Amount"]);
                }

                // Show subtotal with ₹
                var culture = new CultureInfo("en-IN");
                lbltot.Text = subtotal.ToString("C2", culture);

                // Discount
                decimal discount = 0;
                decimal.TryParse(lbldiscount.Text.Replace("₹", "").Replace(",", ""),
                                 NumberStyles.Number, CultureInfo.InvariantCulture, out discount);

                if (discount < 0) discount = 0;
                lbldiscount.Text = discount.ToString("C2", culture);
                // Final total without fine
                decimal total = subtotal - discount;
                if (total < 0) total = 0;

                // Show final total with ₹
                lblsubtotal.Text = total.ToString("C2", culture);
                // remening
                decimal remanig = 0;
                decimal.TryParse(lblremaning.Text.Replace("₹", "").Replace(",", ""),
                                 NumberStyles.Number, CultureInfo.InvariantCulture, out remanig);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred in invoice grid:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdInvoiceDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {

            // Fonts & Brushes
            Font titleFont = new Font("Segoe UI", 22, FontStyle.Bold);
            Font headerFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Font normalFont = new Font("Segoe UI", 10);
            Font boldFont = new Font("Segoe UI", 10, FontStyle.Bold);
            Brush black = Brushes.Black;
            Brush blue = new SolidBrush(Color.FromArgb(20, 60, 150));

            int pageWidth = e.PageBounds.Width;
            int tableWidth = 700;
            int x = (pageWidth - tableWidth) / 2; // Center table
            int y = 20;

            // ---------------- Logo ----------------
            try
            {
                Image logo = Image.FromFile(@"C:\Users\vedan\Downloads\Gemini_Generated_Image_xsls3axsls3axsls.png");
                int logoWidth = 200;
                int logoHeight = 100;
                e.Graphics.DrawImage(logo, (pageWidth - logoWidth) / 2, y, logoWidth, logoHeight);
                y += logoHeight + 10;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Logo not found: " + ex.Message);
            }

            // ---------------- Header Bar ----------------
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(20, 60, 150)), new Rectangle(0, y, pageWidth, 60));
            e.Graphics.DrawString("INVOICE", new Font("Segoe UI", 26, FontStyle.Bold), Brushes.White, (pageWidth - 150) / 2, y + 10);
            y += 70;

            // ---------------- Invoice Code Center ----------------
            Font invoiceFont = new Font("Segoe UI", 20, FontStyle.Bold | FontStyle.Underline);
            Brush invoiceBrush = new SolidBrush(Color.DarkRed);
            string invoiceCode = "Invoice :#" + lblinvvv.Text;
            SizeF invoiceSize = e.Graphics.MeasureString(invoiceCode, invoiceFont);
            float invoiceX = (pageWidth - invoiceSize.Width) / 2;
            e.Graphics.DrawString(invoiceCode, invoiceFont, invoiceBrush, invoiceX, y);
            y += 50; // extra spacing

            // ---------------- Property Details ----------------
            e.Graphics.DrawString("Tathastu Homestay", new Font("Segoe UI", 16, FontStyle.Bold), blue, x, y);
            y += 25;
            e.Graphics.DrawString("Anant Path, Mulshi, Pune", normalFont, black, x, y);
            y += 18;
            e.Graphics.DrawString("Email: Tathastu123@gmail.com | Ph: 08511763025", normalFont, black, x, y);
            y += 30;

            // ---------------- Booking Info (Right Side) ----------------
            int rightX = x + 400;

            // instead of y - 50 or y + 20, keep it closer
            int bookingY = y;   // ✅ start booking info right after property details
            lblGenrated.Text = Program.UserName;
            lblGenratedby.Text = Program.UserName;
            e.Graphics.DrawString("Booking Details", boldFont, black, rightX, bookingY);
            e.Graphics.DrawString("Booking Code: " + lblBCode.Text, normalFont, black, rightX, bookingY + 20);
            e.Graphics.DrawString("Invoice Date: " + lblIDate.Text, normalFont, black, rightX, bookingY + 40);
            e.Graphics.DrawString("Check-in: " + lblCheckdate.Text, normalFont, black, rightX, bookingY + 60);
            e.Graphics.DrawString("Check-out: " + lblcheckOut.Text, normalFont, black, rightX, bookingY + 80);
            e.Graphics.DrawString("Guests: " + lblname.Text, normalFont, black, rightX, bookingY + 100);
            e.Graphics.DrawString("Genrated By: " + lblGenratedby.Text, normalFont, black, rightX, bookingY + 120);

            // push y just below booking info
            y = bookingY + 140;

            // ---------------- Customer Info ----------------
            y += 20;   // small gap
            e.Graphics.DrawString("Booked By:", boldFont, black, x, y);
            y += 18;
            e.Graphics.DrawString(lblname.Text, normalFont, black, x, y);
            y += 25;

            // ---------------- Table Header ----------------
            // reduce gap before table
            y += 20;   // instead of 50
            int tableStartY = y;
            int rowHeight = 25;

            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220, 230, 250)), new Rectangle(x, tableStartY, tableWidth, rowHeight));
            e.Graphics.DrawRectangle(Pens.Gray, x, tableStartY, tableWidth, rowHeight);

            e.Graphics.DrawString("Sr. No.", boldFont, black, x + 5, tableStartY + 7);
            e.Graphics.DrawString("Description", boldFont, black, x + 100, tableStartY + 7);
            e.Graphics.DrawString("Unit Price", boldFont, black, x + 300, tableStartY + 7);
            e.Graphics.DrawString("Qty", boldFont, black, x + 420, tableStartY + 7);
            e.Graphics.DrawString("Amount", boldFont, black, x + 520, tableStartY + 7);

            y = tableStartY + rowHeight;

            // ---------------- Table Rows ----------------
            decimal originalTotal = 0;
            bool alternate = false;
            int srNo = 1;

            foreach (DataGridViewRow row in grdInvoiceDetails.Rows)
            {
                if (row.Cells["ItemName"].Value == null) continue;

                if (alternate)
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(245, 245, 245)),
                                             new Rectangle(x, y, tableWidth, rowHeight));
                alternate = !alternate;

                string itemName = row.Cells["ItemName"].Value.ToString();
                decimal unitPrice = Convert.ToDecimal(row.Cells["UnitPrice"].Value);
                int qty = Convert.ToInt32(row.Cells["Quantity"].Value);
                decimal amount = Convert.ToDecimal(row.Cells["Amount"].Value);

                e.Graphics.DrawString(srNo.ToString(), normalFont, black, x + 5, y + 7);
                e.Graphics.DrawString(itemName, normalFont, black, x + 100, y + 7);

                // Unit Price with ₹
                e.Graphics.DrawString(unitPrice.ToString("C2", new CultureInfo("en-IN")), normalFont, black, x + 300, y + 7);

                // Qty
                e.Graphics.DrawString(qty.ToString(), normalFont, black, x + 420, y + 7);

                // Amount with ₹
                e.Graphics.DrawString(amount.ToString("C2", new CultureInfo("en-IN")), normalFont, black, x + 520, y + 7);

                originalTotal += amount;
                srNo++;
                y += rowHeight;
            }
            e.Graphics.DrawRectangle(Pens.Gray, x, tableStartY, tableWidth, y - tableStartY);

            // ---------------- Totals ----------------
            // ---------------- Totals ----------------
            // Parse discount
            decimal discount = 0;
            decimal.TryParse(lbldiscount.Text.Replace("₹", "").Replace(",", ""),
                             NumberStyles.Number, CultureInfo.InvariantCulture, out discount);

            // Parse current paid amount
            decimal CurrentPaid = 0;
            decimal.TryParse(lblCpaid.Text.Replace("₹", "").Replace(",", ""),
                             NumberStyles.Number, CultureInfo.InvariantCulture, out CurrentPaid);

            // Final total after discount
            decimal finalTotal = originalTotal - discount;
            if (finalTotal < 0) finalTotal = 0;

            // Balance due
            decimal balanceDue = finalTotal - CurrentPaid;
            if (balanceDue < 0) balanceDue = 0;

            // Update subtotal label
            lblsubtotal.Text = finalTotal.ToString("C2", new CultureInfo("en-IN"));

            decimal remaning = 0;
            decimal.TryParse(lblremaning.Text.Replace("₹", "").Replace(",", ""),
                             NumberStyles.Number, CultureInfo.InvariantCulture, out remaning);

            // Print totals
            y += 40;
            int labelX = x + 400;
            int valueX = x + 580;
            int spacing = 30;

            Font labelFont = new Font("Segoe UI", 12, FontStyle.Bold);
            Font valueFont = new Font("Segoe UI", 12, FontStyle.Bold);

            // Grand Total
            e.Graphics.DrawString("Grand Total:", boldFont, black, labelX, y);
            e.Graphics.DrawString(originalTotal.ToString("C2", new CultureInfo("en-IN")), boldFont, black, valueX, y);
            y += spacing;

            // Offer Amount
            e.Graphics.DrawString("Offer Amount:", boldFont, black, labelX, y);
            e.Graphics.DrawString(discount.ToString("C2", new CultureInfo("en-IN")), boldFont, black, valueX, y);
            y += spacing;

            // Amt To Pay
            e.Graphics.DrawString("Amt To Pay:", labelFont, blue, labelX, y);
            e.Graphics.DrawString(finalTotal.ToString("C2", new CultureInfo("en-IN")), valueFont, blue, valueX, y);
            y += spacing;

            // Current PaidAmt
            e.Graphics.DrawString("Current Paid:", labelFont, blue, labelX, y);
            e.Graphics.DrawString(CurrentPaid.ToString("C2", new CultureInfo("en-IN")), valueFont, blue, valueX, y);
            y += spacing;

            // ✅ Remaining Amount
            e.Graphics.DrawString("Remaining Amt:", labelFont, blue, labelX, y);
            e.Graphics.DrawString(remaning.ToString("C2", new CultureInfo("en-IN")), valueFont, blue, valueX, y);
            y += spacing;


            string statusText;
            Brush statusBrush;

            //if (balanceDue == 0)
            //{
            //    statusText = "✔ Paid";   // Green tick for Paid
            //    statusBrush = new SolidBrush(Color.Green);
            //}
            //else
            //{
            //    statusText = "⏳ Pending"; // Hourglass for Pending
            //    statusBrush = new SolidBrush(Color.Orange);
            //}

            // e.Graphics.DrawString("Status:", labelFont, black, labelX, y);
            // e.Graphics.DrawString(statusText, valueFont, statusBrush, valueX, y);
            // ---------------- Footer ----------------
            y += 60;
            e.Graphics.DrawString("We look forward to welcoming you again.", new Font("Segoe UI", 10, FontStyle.Italic), black, x, y);


            // ---------------- PAID Stamp ----------------
            string stampText = "PAID";
            Font stampFont = new Font("Segoe UI", 48, FontStyle.Bold);
            Brush stampBrush = new SolidBrush(Color.FromArgb(100, Color.Red));

            SizeF stampSize = e.Graphics.MeasureString(stampText, stampFont);
            float stampX = (pageWidth - stampSize.Width) / 2;
            float stampY = y - 200;

            GraphicsState state = e.Graphics.Save();
            e.Graphics.TranslateTransform(stampX + stampSize.Width / 2, stampY + stampSize.Height / 2);
            e.Graphics.RotateTransform(-30);
            e.Graphics.DrawString(stampText, stampFont, stampBrush, -stampSize.Width / 2, -stampSize.Height / 2);
            e.Graphics.Restore(state);
        }

        // ---------------- Disable Scrollbars ----------------
        private void Form1_Load(object sender, EventArgs e)
        {
            grdInvoiceDetails.ScrollBars = ScrollBars.None;
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void grdInvoiceDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((grdInvoiceDetails.Columns[e.ColumnIndex].Name == "UnitPrice"
           || grdInvoiceDetails.Columns[e.ColumnIndex].Name == "Amount")
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblcheckin_Click(object sender, EventArgs e)
        {

        }

        private void lblinvvv_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ContainerControl1_Click(object sender, EventArgs e)
        {

        }

        private void lblremaning_Click(object sender, EventArgs e)
        {

        }

        private void btnGenrateReceipt_Click(object sender, EventArgs e)
        {
       
            try
            {
                // Close main Invoice Form immediately
                this.Close();

                // --- Preview form (Borderless + Draggable) ---
                Form previewForm = new Form
                {
                    Text = "Invoice Preview",
                    Size = new Size(900, 700),
                    StartPosition = FormStartPosition.CenterScreen,
                    BackColor = Color.White,
                    TopMost = false,
                    FormBorderStyle = FormBorderStyle.None   // ✅ Borderless
                };

                // --- Print Preview Control ---
                PrintPreviewControl previewControl = new PrintPreviewControl
                {
                    Document = printDocument,
                    Dock = DockStyle.Fill,
                    Zoom = 1.0
                };

                // --- Toolbar panel (Draggable area) ---
                Guna2Panel panel = new Guna2Panel
                {
                    Dock = DockStyle.Top,
                    Height = 50,
                    FillColor = Color.FromArgb(230, 235, 250)
                };

                // --- Make panel draggable ---
                panel.MouseDown += (s, ev) =>
                {
                    if (ev.Button == MouseButtons.Left)
                    {
                        ReleaseCapture();
                        SendMessage(previewForm.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
                    }
                };

                // --- Overlay ---
                Label overlay = new Label
                {
                    Text = "Printing… Please wait",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Font = new Font("Segoe UI", 16, FontStyle.Bold),
                    BackColor = Color.FromArgb(120, Color.White),
                    ForeColor = Color.DarkBlue,
                    Visible = false
                };
                previewForm.Controls.Add(overlay);

                // --- Print button ---
                Guna2Button btnPrint = new Guna2Button
                {
                    Text = "🖨 Print",
                    Size = new Size(100, 35),
                    Location = new Point(20, 7),
                    FillColor = Color.FromArgb(0, 120, 215)
                };

                btnPrint.Click += (s, ev) =>
                {
                    try
                    {
                        using (PrintDialog dlg = new PrintDialog())
                        {
                            dlg.Document = printDocument;
                            if (dlg.ShowDialog() == DialogResult.OK)
                            {
                                overlay.Visible = true;

                                previewForm.BeginInvoke(new Action(() =>
                                {
                                    try
                                    {
                                        printDocument.Print();
                                        overlay.Visible = false;
                                        MessageBox.Show("Invoice Printed Successfully ✅");

                                        previewForm.Close();
                                    }
                                    catch (Exception exPrint)
                                    {
                                        overlay.Visible = false;
                                        MessageBox.Show("Error while printing: " + exPrint.Message,
                                            "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }));
                            }
                        }
                    }
                    catch (Exception exDlg)
                    {
                        MessageBox.Show("Error opening print dialog: " + exDlg.Message,
                            "Print Dialog Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                // --- Zoom In ---
                Guna2Button btnZoomIn = new Guna2Button
                {
                    Text = "🔍 +",
                    Size = new Size(80, 35),
                    Location = new Point(140, 7)
                };
                btnZoomIn.Click += (s, ev) => previewControl.Zoom += 0.1;

                // --- Zoom Out ---
                Guna2Button btnZoomOut = new Guna2Button
                {
                    Text = "🔍 -",
                    Size = new Size(80, 35),
                    Location = new Point(230, 7)
                };
                btnZoomOut.Click += (s, ev) => previewControl.Zoom = Math.Max(0.1, previewControl.Zoom - 0.1);

                // --- Close Button (X) ---
                Guna2Button btnClose = new Guna2Button
                {
                    Text = "✖",
                    Size = new Size(50, 35),
                    Location = new Point(830, 7),
                    FillColor = Color.FromArgb(220, 80, 80)
                };
                btnClose.Click += (s, ev) => previewForm.Close();

                // --- Add controls ---
                panel.Controls.Add(btnPrint);
                panel.Controls.Add(btnZoomIn);
                panel.Controls.Add(btnZoomOut);
                panel.Controls.Add(btnClose);

                previewForm.Controls.Add(previewControl);
                previewForm.Controls.Add(panel);

                // --- Show Preview Form ---
                previewForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating invoice preview: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

