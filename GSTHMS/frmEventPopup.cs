using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmEventPopup : Form
    {
        private Button btnClose;

        public frmEventPopup(
            string title,
            string description,
            DateTime date,
            TimeSpan? startTime,
            TimeSpan? endTime,
            string eventStatus
        )
        {
            try
            {
                InitializeComponent();

                // -------- FORM STYLE --------
                FormBorderStyle = FormBorderStyle.None;
                BackColor = Color.White;
                StartPosition = FormStartPosition.CenterScreen;
                Padding = new Padding(25);
                Width = 580;
                Height = 320;

                // -------- LABEL STYLES --------
                lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                lblDescription.Font = new Font("Segoe UI", 11);
                lblDate.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblTime.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lblStatus11.Font = new Font("Segoe UI", 15F, FontStyle.Bold);

                lblDescription.ForeColor = Color.DimGray;
                lblDate.ForeColor = Color.FromArgb(0, 102, 204);
                lblTime.ForeColor = Color.FromArgb(0, 102, 204);

                // -------- SET TEXT --------
                lblTitle.Text = title;
                lblDescription.Text = description;
                lblDate.Text = date.ToString("dd MMM yyyy");

                if (eventStatus == "No Event")
                {
                    lblTitle.ForeColor = Color.DarkGray;
                    lblDescription.ForeColor = Color.Gray;
                }

                // -------- TIME --------
                if (startTime != null && endTime != null)
                {
                    DateTime s = date.Date.Add(startTime.Value);
                    DateTime e = date.Date.Add(endTime.Value);

                    if (endTime < startTime)
                        e = e.AddDays(1);

                    lblTime.Text = $"{s:hh:mm tt} - {e:hh:mm tt}";
                }
                else if (startTime != null)
                {
                    lblTime.Text = $"{date.Date.Add(startTime.Value):hh:mm tt}";
                }
                else
                {
                    lblTime.Visible = false;
                }

                // -------- STATUS --------
                lblStatus11.Text = eventStatus;

                if (eventStatus == "Active")
                {
                    lblStatus11.ForeColor = Color.Green;
                }
                else if (eventStatus == "Upcoming")
                {
                    lblStatus11.ForeColor = Color.RoyalBlue;
                }
                else if (eventStatus == "No Event")
                {
                    lblStatus11.ForeColor = Color.Gray;
                }
                else
                {
                    lblStatus11.ForeColor = Color.Red;
                }

                // -------- CLOSE BUTTON --------
                btnClose = new Button
                {
                    Text = "X",
                    Font = new Font("Segoe UI", 12, FontStyle.Bold),
                    ForeColor = Color.White,
                    BackColor = Color.Red,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(40, 40),
                    Location = new Point(Width - 55, 10)
                };

                btnClose.FlatAppearance.BorderSize = 0;
                btnClose.Click += (s, e) => Close();

                Controls.Add(btnClose);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // -------- CENTER --------
        protected override void OnPaint(PaintEventArgs e)
        {
            try
            {
                base.OnPaint(e);

                CenterLabels();

                int r = 25;
                Rectangle rect = new Rectangle(0, 0, Width, Height);
                var path = new System.Drawing.Drawing2D.GraphicsPath();

                path.AddArc(0, 0, r, r, 180, 90);
                path.AddArc(Width - r, 0, r, r, 270, 90);
                path.AddArc(Width - r, Height - r, r, r, 0, 90);
                path.AddArc(0, Height - r, r, r, 90, 90);
                path.CloseFigure();

                Region = new Region(path);

                e.Graphics.DrawPath(
                    new Pen(Color.Black, 4),
                    path
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CenterLabels()
        {
            try
            {
                lblTitle.Left = (ClientSize.Width - lblTitle.Width) / 2;
                lblTitle.Top = 40;

                lblDescription.Left = (ClientSize.Width - lblDescription.Width) / 2;
                lblDescription.Top = lblTitle.Bottom + 15;

                lblDate.Left = (ClientSize.Width - lblDate.Width) / 2;
                lblDate.Top = lblDescription.Bottom + 20;

                lblTime.Left = (ClientSize.Width - lblTime.Width) / 2;
                lblTime.Top = lblDate.Bottom + 10;

                lblStatus11.Left = (ClientSize.Width - lblStatus11.Width) / 2;
                lblStatus11.Top = lblTime.Bottom + 15;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // -------- DRAG --------
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern int SendMessage(
            IntPtr hWnd,
            int Msg,
            int wParam,
            int lParam
        );

        protected override void OnMouseDown(MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    ReleaseCapture();
                    SendMessage(
                        Handle,
                        WM_NCLBUTTONDOWN,
                        HTCAPTION,
                        0
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
            {
                if (keyData == Keys.Escape)
                {
                    Close();
                    return true;
                }

                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false;
            }
        }

        private void frmEventPopup_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}