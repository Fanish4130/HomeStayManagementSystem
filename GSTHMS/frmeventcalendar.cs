using ClosedXML.Excel;
using DocumentFormat.OpenXml.Vml.Spreadsheet;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Font = System.Drawing.Font;

namespace GSTHMS
{
    public class frmEventCalendar : Form
    {
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Color Color { get; set; }

        public TimeSpan? Time { get; set; }
        public TimeSpan? StartTime { get; set; }
        public TimeSpan? EndTime { get; set; }
        public string Status { get; set; }

        private int currentYear;
        private int currentMonth;
        private DateTime selectedDate;
        bool isFormLoaded = false;
        bool isFilterActive = false;
        bool isSearching = false;

        private enum ViewMode { Month, Day }
        private ViewMode currentView = ViewMode.Month;

        private List<CalendarEvent> events = new List<CalendarEvent>();
        private TableLayoutPanel monthGrid;

        private string GetEventStatus(CalendarEvent ev)
        {
            try
            {
                DateTime today = DateTime.Today;

                if (ev.Date.Date < today)
                    return "Inactive";

                if (ev.Date.Date == today)
                    return "Active";

                return "Upcoming";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }

        private void frmEventCalendar_Load(object sender, EventArgs e)
        {
            try
            {
                this.BackColor = Color.WhiteSmoke;
                panel1.BackColor = Color.FromArgb(240, 242, 245);
                panel1.Padding = new Padding(10);

                btnDay.UseVisualStyleBackColor = false;
                btnMonth.UseVisualStyleBackColor = false;
                btnPrevious.UseVisualStyleBackColor = false;
                btnNext.UseVisualStyleBackColor = false;

                toolTip1.SetToolTip(guna2PictureBox2, "Search");
                toolTip1.SetToolTip(pctRefresh1, "Refresh");
                toolTip1.SetToolTip(guna2PictureBox1, "Filter");

                SetDefaultView();
                pnlfilter.Visible = true;

                isFormLoaded = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading calendar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultView()
        {
            try
            {
                btnDay.UseVisualStyleBackColor = false;
                btnMonth.UseVisualStyleBackColor = false;
                btnPrevious.UseVisualStyleBackColor = false;
                btnNext.UseVisualStyleBackColor = false;

                SetDefaultNavigation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDefaultNavigation()
        {
            try
            {
                HighlightNavigationButton(btnNext);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadEventsFromDatabase(bool loadAll = false)
        {
            try
            {
                events.Clear();

                DateTime fromDate;
                DateTime toDate;

                if (loadAll)
                {
                    fromDate = new DateTime(2000, 1, 1);
                    toDate = new DateTime(2100, 12, 31);
                }
                else
                {
                    DateTime firstDay = new DateTime(currentYear, currentMonth, 1);
                    fromDate = firstDay;
                    toDate = firstDay.AddMonths(1).AddDays(-1);
                }

                DataTable dt = FetchCalendarEvents(fromDate, toDate);

                foreach (DataRow row in dt.Rows)
                {
                    events.Add(new CalendarEvent
                    {
                        Date = Convert.ToDateTime(row["StartDate"]),
                        Title = row["EventName"].ToString(),
                        Description = row["Description"].ToString(),
                        Color = Color.LightSkyBlue,

                        StartTime = row["StartTime"] == DBNull.Value
                            ? (TimeSpan?)null
                            : TimeSpan.Parse(row["StartTime"].ToString()),

                        EndTime = row["EndTime"] == DBNull.Value
                            ? (TimeSpan?)null
                            : TimeSpan.Parse(row["EndTime"].ToString())
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading events from database:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable FetchCalendarEvents(DateTime fromDate, DateTime toDate)
        {
            DataTable dt = new DataTable();

            try
            {
                clsUser obj = new clsUser();
                dt = obj.FetchCalendarEvents(fromDate, toDate);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching calendar events:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        public frmEventCalendar()
        {
            try
            {
                InitializeComponent();

                currentYear = DateTime.Now.Year;
                currentMonth = DateTime.Now.Month;
                selectedDate = DateTime.Now.Date;

                LoadEventsFromDatabase();
                currentView = ViewMode.Month;

                panel1.SizeChanged += (s, e) =>
                {
                    try
                    {
                        ShowCurrentView();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                ShowCurrentView();
                HighlightActiveButton(btnMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing calendar:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EventClickHandler(object sender, EventArgs e)
        {
            try
            {
                CalendarEvent ev = (CalendarEvent)((Control)sender).Tag;
                OpenEventPopup(ev);
                MessageBox.Show("Event Clicked!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenEventPopup(CalendarEvent ev)
        {
            try
            {
                TimeSpan? start = ev.StartTime ?? ev.Time;
                TimeSpan? end = ev.EndTime ?? ev.Time;

                string status;

                if (ev.Date.Date < DateTime.Today)
                    status = "Inactive";
                else if (ev.Date.Date == DateTime.Today)
                    status = "Active";
                else
                    status = "Upcoming";

                frmEventPopup popup = new frmEventPopup(
                    ev.Title,
                    ev.Description,
                    ev.Date,
                    start,
                    end,
                    status
                );

                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening event popup:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class CalendarEvent
        {
            public DateTime Date { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public Color Color { get; set; }

            public TimeSpan? Time { get; set; }
            public TimeSpan? StartTime { get; set; }
            public TimeSpan? EndTime { get; set; }
            public string Status { get; internal set; }
        }

        public void AddEventToCalendar(CalendarEvent ev)
        {
            try
            {
                if (ev == null) return;

                events.Add(ev);
                ShowCurrentView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding event:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadSampleEvents()
        {
            try
            {
                events.Clear();

                events.AddRange(new List<CalendarEvent>()
                {

                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowCurrentView()
        {
            try
            {
                switch (currentView)
                {
                    case ViewMode.Month:
                        DisplayMonthView();
                        HighlightActiveButton(btnMonth);
                        break;

                    case ViewMode.Day:
                        currentYear = selectedDate.Year;
                        currentMonth = selectedDate.Month;
                        DisplayDayView();
                        HighlightActiveButton(btnDay);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error showing current view:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayMonthView()
        {
            try
            {
                panel1.Controls.Clear();

                if (!isSearching)
                    LoadEventsFromDatabase(false);

                monthGrid = new TableLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    ColumnCount = 7,
                    RowCount = 6,
                    Margin = new Padding(0),
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    BackColor = Color.White
                };

                monthGrid.ColumnStyles.Clear();

                for (int c = 0; c < 7; c++)
                    monthGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / 7f));

                monthGrid.RowStyles.Clear();

                for (int r = 0; r < 6; r++)
                    monthGrid.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / 6f));

                DateTime firstDay = new DateTime(currentYear, currentMonth, 1);
                int daysInMonth = DateTime.DaysInMonth(currentYear, currentMonth);
                int startDay = (int)firstDay.DayOfWeek;

                int cellIndex = 0;
                int day = 1;

                for (int r = 0; r < 6; r++)
                {
                    for (int c = 0; c < 7; c++)
                    {
                        Panel cell = new Panel
                        {
                            Dock = DockStyle.Fill,
                            Margin = new Padding(3),
                            BackColor = Color.White,
                            Padding = new Padding(5),
                        };

                        List<CalendarEvent> dailyEvents = new List<CalendarEvent>();

                        cell.Paint += (s, e) =>
                        {
                            try
                            {
                                var rect = cell.ClientRectangle;
                                rect.Width -= 1;
                                rect.Height -= 1;

                                using (Pen p = new Pen(Color.FromArgb(200, 200, 200), 1))
                                {
                                    e.Graphics.DrawRectangle(p, rect);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        if (cellIndex >= startDay && day <= daysInMonth)
                        {
                            DateTime date = new DateTime(currentYear, currentMonth, day);
                            dailyEvents = events.Where(ev => ev.Date.Date == date.Date).ToList();
                            bool hasEvents = dailyEvents.Any();

                            if (date.Date == DateTime.Today)
                            {
                                cell.BackColor = Color.FromArgb(230, 240, 255);
                            }
                            else if (hasEvents)
                            {
                                cell.BackColor = Color.FromArgb(230, 240, 255);
                            }

                            Label lbl = new Label
                            {
                                Text = day.ToString(),
                                AutoSize = false,
                                Height = 22,
                                Dock = DockStyle.Top,
                                TextAlign = ContentAlignment.MiddleLeft,
                                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                                ForeColor = date.Date == DateTime.Today
                                    ? Color.DodgerBlue
                                    : Color.Black
                            };

                            cell.Controls.Add(lbl);

                            cell.MouseLeave += (s, e) =>
                            {
                                try
                                {
                                    if (date.Date == DateTime.Today)
                                        cell.BackColor = Color.FromArgb(230, 240, 255);
                                    else if (dailyEvents.Any())
                                        cell.BackColor = Color.FromArgb(230, 240, 255);
                                    else
                                        cell.BackColor = Color.White;
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            };

                            foreach (var ev in dailyEvents.Take(3).Reverse())
                            {
                                Label chip = new Label
                                {
                                    Text = "  " + ev.Title,
                                    AutoSize = false,
                                    Height = 20,
                                    Dock = DockStyle.Bottom,
                                    TextAlign = ContentAlignment.MiddleLeft,
                                    BackColor = Color.FromArgb(0, 120, 215),
                                    Font = new Font("Segoe UI", 7, FontStyle.Bold),
                                    ForeColor = Color.White,
                                    Padding = new Padding(6, 0, 0, 0),
                                    AutoEllipsis = true
                                };

                                chip.Click += (s, e) =>
                                {
                                    try
                                    {
                                        OpenEventPopup(ev);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                };

                                cell.Controls.Add(chip);
                            }

                            cell.Click += (s, e) =>
                            {
                                try
                                {
                                    var cellEvents = events.Where(ev => ev.Date.Date == date.Date).ToList();

                                    if (cellEvents.Count == 1)
                                    {
                                        OpenEventPopup(cellEvents[0]);
                                    }
                                    else if (cellEvents.Count > 1)
                                    {
                                        selectedDate = date;
                                        currentView = ViewMode.Day;
                                        ShowCurrentView();
                                    }
                                    else
                                    {
                                        OpenEventPopup(date);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            };

                            day++;
                        }
                        else
                        {
                            Label lblEmpty = new Label
                            {
                                Text = "",
                                Dock = DockStyle.Fill
                            };

                            cell.Controls.Add(lblEmpty);
                            cell.BackColor = Color.FromArgb(245, 245, 245);
                        }

                        monthGrid.Controls.Add(cell, c, r);
                        cellIndex++;
                    }
                }

                label1.Text = new DateTime(currentYear, currentMonth, 1)
                    .ToString("MMMM yyyy");

                label1.Font = new Font("Segoe UI", 20, FontStyle.Bold);
                label1.ForeColor = Color.FromArgb(50, 50, 50);

                panel1.Controls.Add(monthGrid);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying month view:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDayView()
        {
            try
            {
                panel1.Controls.Clear();

                label1.Text = $"{selectedDate:dddd, dd MMM yyyy}";

                var dailyEvents = events
                    .Where(e => e.Date.Date == selectedDate.Date)
                    .OrderBy(e => e.Time ?? TimeSpan.Zero)
                    .ToList();

                FlowLayoutPanel flow = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(8)
                };

                if (!dailyEvents.Any())
                {
                    Label msg = new Label
                    {
                        Text = "No Events for this day",
                        AutoSize = false,
                        Width = panel1.Width - 40,
                        Height = 90,
                        TextAlign = ContentAlignment.BottomCenter,
                        Font = new Font("Segoe UI", 12, FontStyle.Bold),
                        ForeColor = Color.Gray
                    };

                    flow.Controls.Add(msg);
                }
                else
                {
                    foreach (var ev in dailyEvents)
                    {
                        Panel p = new Panel
                        {
                            Width = Math.Min(700, panel1.Width - 40),
                            Height = 60,
                            BackColor = ev.Color,
                            Margin = new Padding(8)
                        };

                        Label lbl = new Label
                        {
                            Text = $"{(ev.Time.HasValue ? ev.Time.Value.ToString(@"hh\:mm") + " - " : "")}{ev.Title}",
                            Dock = DockStyle.Fill,
                            TextAlign = ContentAlignment.MiddleLeft,
                            Padding = new Padding(8, 0, 0, 0)
                        };

                        p.Controls.Add(lbl);

                        p.Click += (s, e) =>
                        {
                            try { OpenEventPopup(ev); }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        lbl.Click += (s, e) =>
                        {
                            try { OpenEventPopup(ev); }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        };

                        flow.Controls.Add(p);
                    }
                }

                panel1.Controls.Add(flow);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error displaying day view:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMonth_Click_1(object sender, EventArgs e)
        {
            try
            {
                currentView = ViewMode.Month;
                ShowCurrentView();
                HighlightActiveButton(btnMonth);
                HighlightNavigationButton(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnWeek_Click_1(object sender, EventArgs e)
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

        private void btnDay_Click_1(object sender, EventArgs e)
        {
            try
            {
                currentView = ViewMode.Day;
                ShowCurrentView();
                HighlightActiveButton(btnDay);
                HighlightNavigationButton(null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightNavigationButton(Button activeBtn)
        {
            try
            {
                ApplyButtonStyle(btnPrevious, btnPrevious == activeBtn);
                ApplyButtonStyle(btnNext, btnNext == activeBtn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyButtonStyle(Button btn, bool isActive)
        {
            try
            {
                if (isActive)
                {
                    btn.BackColor = Color.DimGray;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.LightGray;
                    btn.ForeColor = Color.Black;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightActiveButton(Button activeBtn)
        {
            try
            {
                ApplyButtonStyle(btnDay, btnDay == activeBtn);
                ApplyButtonStyle(btnMonth, btnMonth == activeBtn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MovePrevious()
        {
            try
            {
                if (currentView == ViewMode.Month)
                {
                    currentMonth--;

                    if (currentMonth < 1)
                    {
                        currentMonth = 12;
                        currentYear--;
                    }
                }
                else if (currentView == ViewMode.Day)
                {
                    selectedDate = selectedDate.AddDays(-1);
                    currentYear = selectedDate.Year;
                    currentMonth = selectedDate.Month;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MoveNext()
        {
            try
            {
                if (currentView == ViewMode.Month)
                {
                    currentMonth++;

                    if (currentMonth > 12)
                    {
                        currentMonth = 1;
                        currentYear++;
                    }
                }
                else if (currentView == ViewMode.Day)
                {
                    selectedDate = selectedDate.AddDays(1);
                    currentYear = selectedDate.Year;
                    currentMonth = selectedDate.Month;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CalendarEvent GetEventByDate(DateTime date)
        {
            try
            {
                using (var db = new YourDbContext())
                {
                    return events.FirstOrDefault(e => e.Date.Date == date.Date);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void OpenEventPopup(DateTime date)
        {
            try
            {
                var evt = GetEventByDate(date);

                string title;
                string description;
                TimeSpan? startTime = null;
                TimeSpan? endTime = null;
                string status;

                if (evt != null)
                {
                    title = evt.Title;
                    description = evt.Description;
                    startTime = evt.StartTime;
                    endTime = evt.EndTime;
                    status = evt.Status;
                }
                else
                {
                    title = "No Event";
                    description = "There is no event scheduled for this day.";
                    status = "No Event";
                }

                frmEventPopup popup = new frmEventPopup(
                    title,
                    description,
                    date,
                    startTime,
                    endTime,
                    status
                );

                popup.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            try
            {
                MovePrevious();
                ShowCurrentView();
                HighlightNavigationButton(btnPrevious);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                MoveNext();
                ShowCurrentView();
                HighlightNavigationButton(btnNext);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
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
        // -------------------- Designer fields & InitializeComponent --------------------
        private Panel panel1;
        private Button btnDay;
        private Label label1;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnMonth;
        private PictureBox pctFilter;
        private PictureBox pctDelete;
        private Panel pnlSearchBox;
        private TextBox txtSearchBox;
        private PictureBox pctRefresh;
        private PictureBox pctSearchBox;
        private PictureBox pctExcel;
        private PictureBox pctPDF;



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEventCalendar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnDay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.pctFilter = new System.Windows.Forms.PictureBox();
            this.pctDelete = new System.Windows.Forms.PictureBox();
            this.pnlSearchBox = new System.Windows.Forms.Panel();
            this.txtSearchBox = new System.Windows.Forms.TextBox();
            this.pctRefresh = new System.Windows.Forms.PictureBox();
            this.pctSearchBox = new System.Windows.Forms.PictureBox();
            this.pctExcel = new System.Windows.Forms.PictureBox();
            this.pctPDF = new System.Windows.Forms.PictureBox();
            this.btneventdetails = new Guna.UI2.WinForms.Guna2Button();
            this.pnlfilter = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.pctRefresh1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox2 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2TextBox2 = new Guna.UI2.WinForms.Guna2TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDelete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).BeginInit();
            this.pnlfilter.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.guna2Panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(21, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 561);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnDay
            // 
            this.btnDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDay.Location = new System.Drawing.Point(24, 10);
            this.btnDay.Name = "btnDay";
            this.btnDay.Size = new System.Drawing.Size(80, 40);
            this.btnDay.TabIndex = 1;
            this.btnDay.Text = "Day";
            this.btnDay.UseVisualStyleBackColor = true;
            this.btnDay.Click += new System.EventHandler(this.btnDay_Click_1);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 40);
            this.label1.TabIndex = 50;
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // btnPrevious
            // 
            this.btnPrevious.Location = new System.Drawing.Point(1002, 105);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(80, 40);
            this.btnPrevious.TabIndex = 3;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(1100, 104);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(80, 40);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(119, 10);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(80, 40);
            this.btnMonth.TabIndex = 5;
            this.btnMonth.Text = "Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click_1);
            // 
            // pctFilter
            // 
            this.pctFilter.Location = new System.Drawing.Point(0, 0);
            this.pctFilter.Name = "pctFilter";
            this.pctFilter.Size = new System.Drawing.Size(100, 50);
            this.pctFilter.TabIndex = 0;
            this.pctFilter.TabStop = false;
            // 
            // pctDelete
            // 
            this.pctDelete.Location = new System.Drawing.Point(0, 0);
            this.pctDelete.Name = "pctDelete";
            this.pctDelete.Size = new System.Drawing.Size(100, 50);
            this.pctDelete.TabIndex = 0;
            this.pctDelete.TabStop = false;
            // 
            // pnlSearchBox
            // 
            this.pnlSearchBox.Location = new System.Drawing.Point(0, 0);
            this.pnlSearchBox.Name = "pnlSearchBox";
            this.pnlSearchBox.Size = new System.Drawing.Size(200, 100);
            this.pnlSearchBox.TabIndex = 0;
            // 
            // txtSearchBox
            // 
            this.txtSearchBox.Location = new System.Drawing.Point(0, 0);
            this.txtSearchBox.Name = "txtSearchBox";
            this.txtSearchBox.Size = new System.Drawing.Size(100, 22);
            this.txtSearchBox.TabIndex = 0;
            // 
            // pctRefresh
            // 
            this.pctRefresh.Location = new System.Drawing.Point(0, 0);
            this.pctRefresh.Name = "pctRefresh";
            this.pctRefresh.Size = new System.Drawing.Size(100, 50);
            this.pctRefresh.TabIndex = 0;
            this.pctRefresh.TabStop = false;
            // 
            // pctSearchBox
            // 
            this.pctSearchBox.Location = new System.Drawing.Point(0, 0);
            this.pctSearchBox.Name = "pctSearchBox";
            this.pctSearchBox.Size = new System.Drawing.Size(100, 50);
            this.pctSearchBox.TabIndex = 0;
            this.pctSearchBox.TabStop = false;
            // 
            // pctExcel
            // 
            this.pctExcel.Location = new System.Drawing.Point(0, 0);
            this.pctExcel.Name = "pctExcel";
            this.pctExcel.Size = new System.Drawing.Size(100, 50);
            this.pctExcel.TabIndex = 0;
            this.pctExcel.TabStop = false;
            // 
            // pctPDF
            // 
            this.pctPDF.Location = new System.Drawing.Point(0, 0);
            this.pctPDF.Name = "pctPDF";
            this.pctPDF.Size = new System.Drawing.Size(100, 50);
            this.pctPDF.TabIndex = 0;
            this.pctPDF.TabStop = false;
            // 
            // btneventdetails
            // 
            this.btneventdetails.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btneventdetails.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btneventdetails.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btneventdetails.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btneventdetails.FillColor = System.Drawing.Color.DimGray;
            this.btneventdetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.btneventdetails.ForeColor = System.Drawing.Color.White;
            this.btneventdetails.Location = new System.Drawing.Point(1000, 31);
            this.btneventdetails.Name = "btneventdetails";
            this.btneventdetails.Size = new System.Drawing.Size(180, 45);
            this.btneventdetails.TabIndex = 41;
            this.btneventdetails.Text = "Event Details";
            this.btneventdetails.Click += new System.EventHandler(this.btneventdetails_Click);
            // 
            // pnlfilter
            // 
            this.pnlfilter.BorderColor = System.Drawing.Color.Black;
            this.pnlfilter.BorderRadius = 1;
            this.pnlfilter.BorderThickness = 1;
            this.pnlfilter.Controls.Add(this.btnMonth);
            this.pnlfilter.Controls.Add(this.btnDay);
            this.pnlfilter.Location = new System.Drawing.Point(533, 94);
            this.pnlfilter.Name = "pnlfilter";
            this.pnlfilter.Size = new System.Drawing.Size(236, 57);
            this.pnlfilter.TabIndex = 42;
            this.pnlfilter.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlfilter_Paint);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.BorderColor = System.Drawing.Color.Black;
            this.guna2Panel2.BorderRadius = 1;
            this.guna2Panel2.BorderThickness = 1;
            this.guna2Panel2.Controls.Add(this.pctRefresh1);
            this.guna2Panel2.Controls.Add(this.guna2PictureBox2);
            this.guna2Panel2.Controls.Add(this.guna2PictureBox1);
            this.guna2Panel2.Controls.Add(this.guna2Panel3);
            this.guna2Panel2.Location = new System.Drawing.Point(31, 94);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(496, 56);
            this.guna2Panel2.TabIndex = 43;
            // 
            // pctRefresh1
            // 
            this.pctRefresh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pctRefresh1.BackColor = System.Drawing.Color.Transparent;
            this.pctRefresh1.Image = ((System.Drawing.Image)(resources.GetObject("pctRefresh1.Image")));
            this.pctRefresh1.ImageRotate = 0F;
            this.pctRefresh1.Location = new System.Drawing.Point(377, 7);
            this.pctRefresh1.Name = "pctRefresh1";
            this.pctRefresh1.Size = new System.Drawing.Size(47, 42);
            this.pctRefresh1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctRefresh1.TabIndex = 44;
            this.pctRefresh1.TabStop = false;
            this.pctRefresh1.Click += new System.EventHandler(this.pctRefresh1_Click);
            // 
            // guna2PictureBox2
            // 
            this.guna2PictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox2.Image")));
            this.guna2PictureBox2.ImageRotate = 0F;
            this.guna2PictureBox2.Location = new System.Drawing.Point(10, 7);
            this.guna2PictureBox2.Name = "guna2PictureBox2";
            this.guna2PictureBox2.Size = new System.Drawing.Size(47, 42);
            this.guna2PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox2.TabIndex = 44;
            this.guna2PictureBox2.TabStop = false;
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("guna2PictureBox1.Image")));
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(430, 9);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(47, 42);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 44;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.Click += new System.EventHandler(this.guna2PictureBox1_Click_2);
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.guna2Panel3.Controls.Add(this.guna2TextBox2);
            this.guna2Panel3.Location = new System.Drawing.Point(63, 7);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(301, 42);
            this.guna2Panel3.TabIndex = 5;
            // 
            // guna2TextBox2
            // 
            this.guna2TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2TextBox2.BorderColor = System.Drawing.Color.Black;
            this.guna2TextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.guna2TextBox2.DefaultText = "";
            this.guna2TextBox2.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.guna2TextBox2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.guna2TextBox2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.guna2TextBox2.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.guna2TextBox2.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.guna2TextBox2.Location = new System.Drawing.Point(3, 3);
            this.guna2TextBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2TextBox2.Name = "guna2TextBox2";
            this.guna2TextBox2.PlaceholderText = "";
            this.guna2TextBox2.SelectedText = "";
            this.guna2TextBox2.Size = new System.Drawing.Size(295, 35);
            this.guna2TextBox2.TabIndex = 3;
            this.guna2TextBox2.TextChanged += new System.EventHandler(this.guna2TextBox2_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(391, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(503, 45);
            this.label9.TabIndex = 44;
            this.label9.Text = "EVENTS  CALENDAR";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(71, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 25);
            this.label8.TabIndex = 45;
            this.label8.Text = "Sunday";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(229, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 25);
            this.label2.TabIndex = 46;
            this.label2.Text = "Monday";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(390, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 25);
            this.label3.TabIndex = 47;
            this.label3.Text = "Tuesday";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(546, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 25);
            this.label7.TabIndex = 48;
            this.label7.Text = "Wednesday";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(725, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 25);
            this.label5.TabIndex = 49;
            this.label5.Text = "Thursday";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(897, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Friday";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1048, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Saturday";
            // 
            // frmEventCalendar
            // 
            this.ClientSize = new System.Drawing.Size(1211, 789);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.pnlfilter);
            this.Controls.Add(this.btneventdetails);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "frmEventCalendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event Calendar";
            this.Load += new System.EventHandler(this.frmEventCalendar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctFilter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctDelete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctSearchBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctExcel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctPDF)).EndInit();
            this.pnlfilter.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pctRefresh1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.guna2Panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private Guna.UI2.WinForms.Guna2Button btneventdetails;

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                pnlfilter.Visible = !pnlfilter.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btneventdetails_Click(object sender, EventArgs e)
        {
            try
            {
                frmEvent frm = new frmEvent();
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Guna.UI2.WinForms.Guna2Panel pnlfilter;

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SearchEvents(guna2TextBox2.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchEvents(string keyword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(keyword))
                {
                    ShowCurrentView();
                    return;
                }

                keyword = keyword.ToLower();

                var filtered = events
                    .Where(ev => ev.Title.ToLower().Contains(keyword))
                    .OrderBy(ev => ev.Date)
                    .ThenBy(ev => ev.Time ?? TimeSpan.Zero)
                    .ToList();

                panel1.Controls.Clear();

                FlowLayoutPanel flow = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true,
                    FlowDirection = FlowDirection.TopDown,
                    WrapContents = false,
                    Padding = new Padding(10)
                };

                if (filtered.Count == 0)
                {
                    flow.Controls.Add(new Label()
                    {
                        Text = "No matching events found",
                        AutoSize = false,
                        Height = 40,
                        Width = panel1.Width - 40,
                        TextAlign = ContentAlignment.MiddleCenter,
                        ForeColor = Color.Gray
                    });

                    panel1.Controls.Add(flow);
                    return;
                }

                foreach (var ev in filtered)
                {
                    Panel p = new Panel
                    {
                        Width = Math.Min(700, panel1.Width - 40),
                        Height = 65,
                        BackColor = ev.Color,
                        Margin = new Padding(8),
                        Padding = new Padding(10)
                    };

                    Label lbl = new Label
                    {
                        Text = $"{ev.Date:dd MMM yyyy}  {(ev.Time.HasValue ? ev.Time.Value.ToString(@"hh\\:mm") + " - " : "")}{ev.Title}",
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleLeft
                    };

                    p.Controls.Add(lbl);
                    flow.Controls.Add(p);
                }

                panel1.Controls.Add(flow);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox2;

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {
            try
            {
                pnlfilter.Visible = !pnlfilter.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!isFormLoaded) return;

                string keyword = guna2TextBox2.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    isSearching = false;
                    LoadEventsFromDatabase(false);
                    ShowCurrentView();
                }
                else
                {
                    isSearching = true;
                    LoadEventsFromDatabase(true);
                    SearchEvents(keyword);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;

        private void guna2PictureBox1_Click_2(object sender, EventArgs e)
        {
            try
            {
                pnlfilter.Visible = !pnlfilter.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox2;

        private void pnlfilter_Paint(object sender, PaintEventArgs e)
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

        private Guna.UI2.WinForms.Guna2PictureBox pctRefresh1;

        private void pctRefresh1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadEventsFromDatabase();

                guna2TextBox2.Text = "";

                pnlfilter.Visible = true;

                selectedDate = DateTime.Today;

                currentView = ViewMode.Month;

                currentYear = selectedDate.Year;
                currentMonth = selectedDate.Month;

                ShowCurrentView();

                HighlightActiveButton(btnMonth);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Label label9;

        private void btnback_Click(object sender, EventArgs e)
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

        private Label label8;
        private Label label2;
        private Label label3;
        private Label label7;
        private Label label5;
        private Label label4;
        private Label label6;
        private ToolTip toolTip1;
        private System.ComponentModel.IContainer components;

        private void label9_Click(object sender, EventArgs e)
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

        private void label1_Click_1(object sender, EventArgs e)
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
