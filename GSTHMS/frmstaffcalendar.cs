using DocumentFormat.OpenXml.Bibliography;
using Guna.UI2.AnimatorNS;
using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmstaffcalendar : Form
    {
        int month, year;

        public frmstaffcalendar()
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

        private void frmstaffcalendar_Load(object sender, EventArgs e)
        {
            try
            {
                btnprevious.UseVisualStyleBackColor = false;
                btnnext.UseVisualStyleBackColor = false;

                btnprevious.FlatStyle = FlatStyle.Flat;
                btnnext.FlatStyle = FlatStyle.Flat;

                btnprevious.FlatAppearance.BorderColor = Color.LightGray;
                btnnext.FlatAppearance.BorderColor = Color.LightGray;

                btnprevious.FlatAppearance.MouseOverBackColor = Color.DimGray;
                btnnext.FlatAppearance.MouseOverBackColor = Color.DimGray;

                btnprevious.FlatAppearance.MouseDownBackColor = Color.DimGray;
                btnnext.FlatAppearance.MouseDownBackColor = Color.DimGray;

                clsUser obj = new clsUser();

                obj.AutoMarkAbsentAfter12RP();

                DateTime now = DateTime.Now;
                month = now.Month;
                year = now.Year;

                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        DisplayDays();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));

                btnprevious.UseVisualStyleBackColor = false;
                btnnext.UseVisualStyleBackColor = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDays()
        {
            try
            {
                lblDate.Text = DateTimeFormatInfo.CurrentInfo.GetMonthName(month) + " " + year;

                DateTime startOfMonth = new DateTime(year, month, 1);
                int days = DateTime.DaysInMonth(year, month);
                int dayOfWeek = ((int)startOfMonth.DayOfWeek + 6) % 7;

                daycontainer.Controls.Clear();

                for (int i = 0; i < dayOfWeek; i++)
                {
                    daycontainer.Controls.Add(new UserControlBlank());
                }

                for (int i = 1; i <= days; i++)
                {
                    UserControlDays day = new UserControlDays();
                    day.SetDayNumber(i);
                    day.FullDate = new DateTime(year, month, i);

                    day.BorderStyle = BorderStyle.FixedSingle;

                    if (day.FullDate.Date > DateTime.Today)
                    {
                        day.Enabled = false;
                        day.BackColor = Color.LightGray;
                    }
                    else
                    {
                        day.Click += Day_Click;
                    }

                    if (day.FullDate.Date == DateTime.Today)
                    {
                        day.BackColor = Color.FromArgb(255, 230, 150);
                        day.BorderStyle = BorderStyle.FixedSingle;
                    }

                    daycontainer.Controls.Add(day);
                }

                daycontainer.PerformLayout();
                daycontainer.Refresh();

                this.BeginInvoke(new Action(() =>
                {
                    try
                    {
                        AddCalendarBorderRP();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Day_Click(object sender, EventArgs e)
        {
            try
            {
                UserControlDays day = sender as UserControlDays;
                if (day == null) return;

                DateTime selectedDate = day.FullDate.Date;

                if (selectedDate > DateTime.Today)
                {
                    MessageBox.Show(
                        "Attendance is not available for future dates.",
                        "Attendance",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                    return;
                }

                frmDayWiseAttendanceOverViewRP frm =
                    new frmDayWiseAttendanceOverViewRP(selectedDate);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFormInPanel(Form frm)
        {
            try
            {
                panel1.Controls.Clear();

                frm.TopLevel = false;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                panel1.Controls.Add(frm);

                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnnext_Click(object sender, EventArgs e)
        {
            try
            {
                month++;
                if (month > 12) { month = 1; year++; }

                btnnext.BackColor = Color.DimGray;
                btnnext.ForeColor = Color.White;

                btnprevious.BackColor = Color.White;
                btnprevious.ForeColor = Color.Black;

                DisplayDays();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnprevious_Click(object sender, EventArgs e)
        {
            try
            {
                month--;
                if (month < 1) { month = 12; year--; }

                btnprevious.BackColor = Color.DimGray;
                btnprevious.ForeColor = Color.White;

                btnnext.BackColor = Color.White;
                btnnext.ForeColor = Color.Black;

                DisplayDays();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
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

        private void panel13_Paint(object sender, PaintEventArgs e)
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

        private void label1_Click(object sender, EventArgs e)
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

        private void btnattendance_Click(object sender, EventArgs e)
        {
            try
            {
                frmAttendance frmAttendance = new frmAttendance();
                frmAttendance.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            try
            {
                new frmAttendance().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        Panel topBorderRP;
        Panel bottomBorderRP;
        Panel leftBorderRP;
        Panel rightBorderRP;

        private void AddCalendarBorderRP()
        {
            try
            {
                if (daycontainer.Controls.Count == 0)
                    return;

                var dayControls = daycontainer.Controls
                    .Cast<Control>()
                    .Where(c => c is UserControlDays)
                    .ToList();

                if (dayControls.Count == 0)
                    return;

                int minLeft = dayControls.Min(c => c.Left);
                int minTop = dayControls.Min(c => c.Top);
                int maxRight = dayControls.Max(c => c.Right);
                int maxBottom = dayControls.Max(c => c.Bottom);

                int gap = 8;
                int borderSize = 2;
                Color borderColor = Color.Gray;

                int x = daycontainer.Left + minLeft - gap;
                int y = daycontainer.Top + minTop - gap;
                int w = (maxRight - minLeft) + (gap * 2);
                int h = (maxBottom - minTop) + (gap * 2);

                if (topBorderRP == null)
                {
                    topBorderRP = new Panel();
                    bottomBorderRP = new Panel();
                    leftBorderRP = new Panel();
                    rightBorderRP = new Panel();

                    this.Controls.Add(topBorderRP);
                    this.Controls.Add(bottomBorderRP);
                    this.Controls.Add(leftBorderRP);
                    this.Controls.Add(rightBorderRP);
                }

                topBorderRP.Location = new Point(x, y);
                topBorderRP.Size = new Size(w, borderSize);

                bottomBorderRP.Location = new Point(x, y + h - borderSize);
                bottomBorderRP.Size = new Size(w, borderSize);

                leftBorderRP.Location = new Point(x, y);
                leftBorderRP.Size = new Size(borderSize, h);

                rightBorderRP.Location = new Point(x + w - borderSize, y);
                rightBorderRP.Size = new Size(borderSize, h);

                topBorderRP.BackColor = borderColor;
                bottomBorderRP.BackColor = borderColor;
                leftBorderRP.BackColor = borderColor;
                rightBorderRP.BackColor = borderColor;

                topBorderRP.BringToFront();
                bottomBorderRP.BringToFront();
                leftBorderRP.BringToFront();
                rightBorderRP.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}