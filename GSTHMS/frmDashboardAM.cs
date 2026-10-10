using DocumentFormat.OpenXml.VariantTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static GSTHMS.clsUser;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GSTHMS
{
    public partial class frmDashboardAM : Form
    {
        public frmDashboardAM()
        {
            InitializeComponent();
        }



        public int OnLeaveAM { get; set; } = 0;
        public int PendingAM { get; set; } = 0;
        public int PaidAM { get; set; } = 0;
        public int InStockCAM { get; set; } = 0;
        public int LowStockCAM { get; set; }
        public int OutOfStockCAM { get; set; }
        public int PresentAM { get; set; } = 0;
        public int AbsentAM { get; set; } = 0;


        private void frmDashboardAM_Load(object sender, EventArgs e)
        {
            try
            {
                guna2HtmlToolTip1.BackColor = Color.Black;
                guna2HtmlToolTip2.BackColor = Color.Black;
                MainFormLoadAM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MainFormLoadAM()
        {
            try
            {

                clsUser obj = new clsUser();

                lblTodayDate.Text = DateTime.Today.ToString("dd/MM/yyyy");

                dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

                lblTotalGuestCount.Text = obj.GetGuestCountAM().ToString();
                lblActiveBookingCount.Text = obj.GetActiveBookingCountAM().ToString();
                lblPendingPaymentCount.Text = obj.GetTotalPaymentCountAM().ToString();
                lblTodaysEventCounts.Text = obj.GetTodaysEventsCountAM().ToString();
                lblTotalsCheckOutCounts.Text = obj.GetTodaysCheckOutCountAM().ToString();
                lblTotalInventoryCount.Text = obj.GetTotalInventoryCountAM().ToString();
                obj.FromDAM = dtpFrom.Value;
                obj.ToDAM = dtpTo.Value;
                // Total Payment Info
                DataTable dAM = obj.GetTotalPaymentInfoAM();
                if (dAM == null)
                {
                    dAM = new DataTable();
                }
                CalculateTotalFromAllPagesAM(dAM);

                // Payment Status
                DataTable dt1 = obj.GuestPaymentCountByStatusAM();
                if (dt1 == null)
                {
                    dt1 = new DataTable();
                }
                PiePaymentStatus(dt1);

                // Parking Status
                DataTable dt2 = obj.ParkingCountByStatusAM();
                if (dt2 == null)
                {
                    dt2 = new DataTable();
                }
                PollParkingStatus(dt2);

                // Room Status
                DataTable dt1AM = obj.RoomCountByStatusAM();
                if (dt1AM == null)
                {
                    dt1AM = new DataTable();
                }
                DataView dv1AM = new DataView(dt1AM);
                DougnutChartRoomStatusAM(dv1AM.ToTable());

                // Inventory Count
                DataTable d3 = obj.GetInventoryCountAM();
                if (d3 == null)
                {
                    d3 = new DataTable();
                }
                CardInventoryCount(d3);

                // Attendance Count
                DataTable d4 = obj.GetAttendanceCountAM();
                if (d4 == null)
                {
                    d4 = new DataTable();
                }
                CardAttendanceCount(d4);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CardInventoryCount(DataTable dtAM)
        {
            try
            {
                if (dtAM == null || dtAM.Rows.Count == 0)
                {
                    MessageBox.Show("No record found of inventory!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                InStockCAM = Convert.ToInt32(dtAM.Select("Status = 'In-Stock'")[0]["InventoryCount"]);
                LowStockCAM = Convert.ToInt32(dtAM.Select("Status = 'Low-Stock'")[0]["InventoryCount"]);
                OutOfStockCAM = Convert.ToInt32(dtAM.Select("Status = 'Out-of-Stock'")[0]["InventoryCount"]);

                lblInStockCount.Text = InStockCAM.ToString();
                lblLowStockCount.Text = LowStockCAM.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CardAttendanceCount(DataTable dtAM)
        {
            try
            {
                if (dtAM == null || dtAM.Rows.Count == 0)
                {
                    MessageBox.Show("No record found of inventory!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                PresentAM = dtAM.Select("Status = 'Present'").Length > 0
                    ? Convert.ToInt32(dtAM.Select("Status = 'Present'")[0]["Attendance Count"])
                    : 0;

                AbsentAM = dtAM.Select("Status = 'Absent'").Length > 0
                    ? Convert.ToInt32(dtAM.Select("Status = 'Absent'")[0]["Attendance Count"])
                    : 0;

                OnLeaveAM = dtAM.Select("Status = 'OnLeave'").Length > 0
                    ? Convert.ToInt32(dtAM.Select("Status = 'OnLeave'")[0]["Attendance Count"])
                    : 0;


                lblPresentCount.Text = PresentAM.ToString();
                lblAbsentCount.Text = AbsentAM.ToString();
                lblOnLeaveCount.Text = OnLeaveAM.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void PiePaymentStatus(DataTable dtAM)
        {
            try
            {
                int PaidAM = 0;
                int PendingAM = 0;

                DataRow[] paidRows = dtAM.Select("Status = 'Paid'");
                if (paidRows.Length > 0)
                {
                    int.TryParse(paidRows[0]["Payment Count"].ToString(), out PaidAM);
                }

                DataRow[] pendingRows = dtAM.Select("Status = 'Pending'");
                if (pendingRows.Length > 0)
                {
                    int.TryParse(pendingRows[0]["Payment Count"].ToString(), out PendingAM);
                }

                int total = PaidAM + PendingAM;

                piePaymentByStatus.Series.Clear();
                piePaymentByStatus.ChartAreas.Clear();
                piePaymentByStatus.Titles.Clear();
                piePaymentByStatus.Legends.Clear();
                piePaymentByStatus.Annotations.Clear();

                ChartArea area = new ChartArea("Main");
                area.BackColor = Color.Transparent;
                piePaymentByStatus.ChartAreas.Add(area);

                Series series = new Series("Payment Status");
                series.ChartType = SeriesChartType.Pie;
                series["DoughnutRadius"] = "50";
                series["PieLabelStyle"] = "Outside";
                series.LabelForeColor = Color.White;

                Color paidColor = Color.FromArgb(22, 160, 133);
                Color pendingColor = Color.FromArgb(231, 76, 60);

                void AddPoint(string lbl, int val, Color clr)
                {
                    if (val <= 0)
                        return;

                    DataPoint p = new DataPoint();
                    p.SetValueXY(lbl, val);
                    p.Color = clr;
                    p.BorderColor = Color.White;
                    p.BorderWidth = 2;

                    p.Label = $"{lbl} ({val})";
                    p.LabelForeColor = Color.Black;
                    p.Font = new Font("Arial", 9, FontStyle.Bold);

                    p.ToolTip = $"{lbl} Payments : {val}";
                    p.LegendText = lbl;

                    series.Points.Add(p);
                }

                AddPoint("Paid", PaidAM, paidColor);
                AddPoint("Pending", PendingAM, pendingColor);

                // If both are 0, show a dummy point
                if (series.Points.Count == 0)
                {
                    DataPoint p = new DataPoint();
                    p.SetValueXY("No Data", 1);
                    p.Color = Color.LightGray;
                    p.Label = "No Data";
                    p.LegendText = "No Data";
                    series.Points.Add(p);
                }

                piePaymentByStatus.Series.Add(series);

                Legend legend = new Legend();
                legend.Docking = Docking.Bottom;
                legend.Alignment = StringAlignment.Center;
                legend.Font = new Font("Arial", 10, FontStyle.Bold);
                legend.BackColor = Color.Transparent;
                legend.LegendStyle = LegendStyle.Row;
                legend.ItemColumnSpacing = 20;
                piePaymentByStatus.Legends.Add(legend);

                Title topTitle = new Title();
                topTitle.Text = "Guest Payments";
                topTitle.Font = new Font("Arial", 13, FontStyle.Bold);
                topTitle.ForeColor = Color.FromArgb(44, 62, 80);
                topTitle.Docking = Docking.Top;
                topTitle.Alignment = ContentAlignment.TopLeft;
                piePaymentByStatus.Titles.Add(topTitle);

                piePaymentByStatus.BackColor = Color.White;
                piePaymentByStatus.AntiAliasing = AntiAliasingStyles.All;
                piePaymentByStatus.TextAntiAliasingQuality = TextAntiAliasingQuality.High;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }



        private void DougnutChartRoomStatusAM(DataTable dtAM)
        {
            try
            {
                if (dtAM == null || dtAM.Rows.Count == 0)
                {
                    MessageBox.Show("No record found of rooms !", "Information",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int GetCount(string status)
                {
                    DataRow[] rows = dtAM.Select($"Status = '{status}'");
                    return rows.Length > 0 ? Convert.ToInt32(rows[0]["Room Count"]) : 0;
                }

                int available = GetCount("Available");
                int cleaning = GetCount("Cleaning");
                int unclean = GetCount("Unclean");
                int occupied = GetCount("Occupied");

                int total = available + cleaning + unclean + occupied;

                dnutRoomWiseStatus.Series.Clear();
                dnutRoomWiseStatus.Titles.Clear();
                dnutRoomWiseStatus.Legends.Clear();
                dnutRoomWiseStatus.ChartAreas.Clear();
                dnutRoomWiseStatus.Annotations.Clear();

                if (total == 0) return;

                ChartArea area = new ChartArea("Main");
                area.BackColor = Color.Transparent;
                area.InnerPlotPosition.Auto = false;
                area.InnerPlotPosition.X = 20;
                area.InnerPlotPosition.Y = 5;
                area.InnerPlotPosition.Width = 60;
                area.InnerPlotPosition.Height = 80;
                dnutRoomWiseStatus.ChartAreas.Add(area);

                Series s = new Series("Rooms");
                s.ChartType = SeriesChartType.Doughnut;
                s["DoughnutRadius"] = "50";
                s["PieLabelStyle"] = "Outside";
                s["PieLineColor"] = "White";

                s.SmartLabelStyle.Enabled = true;
                s.SmartLabelStyle.AllowOutsidePlotArea = LabelOutsidePlotAreaStyle.Yes;
                s.SmartLabelStyle.MinMovingDistance = 10;
                s.SmartLabelStyle.MaxMovingDistance = 25;

                Color cAvailable = Color.FromArgb(0, 184, 148);
                Color cCleaning = Color.FromArgb(253, 203, 110);
                Color cUnclean = Color.FromArgb(72, 126, 176);
                Color cOccupied = Color.FromArgb(255, 107, 107);

                void AddPoint(string lbl, int val, Color clr)
                {
                    if (val <= 0) return;

                    DataPoint p = new DataPoint();
                    p.SetValueXY(lbl, val);
                    p.Color = clr;
                    p.BorderColor = Color.White;
                    p.BorderWidth = 3;

                    p.Label = $"{lbl} \n({val})";
                    p.LabelForeColor = Color.Black;
                    p.Font = new Font("Arial", 9, FontStyle.Regular);
                    p.ToolTip = $"{lbl} Rooms : {val} \n  ({(val * 100.0 / total):F1}%)";

                    p.LegendText = lbl;

                    s.Points.Add(p);
                }

                AddPoint("Available", available, cAvailable);
                AddPoint("Cleaning", cleaning, cCleaning);
                AddPoint("Unclean", unclean, cUnclean);
                AddPoint("Occupied", occupied, cOccupied);

                dnutRoomWiseStatus.Series.Add(s);

                Legend lg = new Legend();
                lg.Docking = Docking.Right;
                lg.Font = new Font("Arial", 9, FontStyle.Bold);
                lg.BackColor = Color.Transparent;
                dnutRoomWiseStatus.Legends.Add(lg);

                TextAnnotation ta = new TextAnnotation();
                ta.Text = total.ToString();
                ta.Font = new Font("Arial", 32, FontStyle.Bold);
                ta.ForeColor = Color.Black;
                ta.AnchorDataPoint = s.Points[0];
                ta.AnchorAlignment = ContentAlignment.TopLeft;
                ta.X = 50;
                ta.Y = 50;
                ta.Alignment = ContentAlignment.MiddleCenter;
                dnutRoomWiseStatus.Annotations.Add(ta);

                Title chartTitle = new Title();
                chartTitle.Text = "All Rooms  ";
                chartTitle.Font = new Font("Arial", 13, FontStyle.Bold);
                chartTitle.ForeColor = Color.FromArgb(44, 62, 80);
                chartTitle.Docking = Docking.Top;
                chartTitle.Alignment = ContentAlignment.MiddleCenter;
                dnutRoomWiseStatus.Titles.Add(chartTitle);

                dnutRoomWiseStatus.BackColor = Color.White;
                dnutRoomWiseStatus.AntiAliasing = AntiAliasingStyles.All;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void PollParkingStatus(DataTable dtParking)
        {
            try
            {
                pollParkingSlot.Series.Clear();
                pollParkingSlot.Titles.Clear();
                pollParkingSlot.Legends.Clear();
                pollParkingSlot.ChartAreas.Clear();

                ChartArea chartArea = new ChartArea();

                chartArea.AxisY.Title = "Parking Slots (Capacity)";
                chartArea.AxisY.LabelStyle.Font = new Font("Arial", 13);
                chartArea.AxisY.Interval = 1;
                chartArea.AxisY.MajorGrid.Enabled = false;

                chartArea.AxisX.Title = "Parking Slots";
                chartArea.AxisX.LabelStyle.Font = new Font("Arial", 13);
                chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;

                pollParkingSlot.ChartAreas.Add(chartArea);

                // Chart title
                pollParkingSlot.Titles.Add(new Title
                {
                    Text = "Parking Slot Usage",
                    Font = new Font("Arial", 13, FontStyle.Bold),
                    ForeColor = Color.FromArgb(44, 62, 80),
                    Docking = Docking.Top,
                    Alignment = ContentAlignment.TopLeft
                });

                // Legend
                Legend legend = new Legend
                {
                    Docking = Docking.Top
                };
                pollParkingSlot.Legends.Add(legend);

                if (dtParking.Rows.Count == 0)
                {
                    MessageBox.Show("No parking data available.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Used series (red)
                Series usedSeries = new Series("Used")
                {
                    ChartType = SeriesChartType.StackedBar,
                    Color = Color.Red,
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.Black,
                    XValueType = ChartValueType.String,
                    LegendText = "Used"
                };

                // Available series (faint green)
                Series availableSeries = new Series("Available")
                {
                    ChartType = SeriesChartType.StackedBar,
                    Color = Color.FromArgb(46, 139, 87),  // faint green
                    IsValueShownAsLabel = true,
                    LabelForeColor = Color.Black,
                    XValueType = ChartValueType.String,
                    LegendText = "Available"
                };

                pollParkingSlot.Series.Add(usedSeries);
                pollParkingSlot.Series.Add(availableSeries);

                foreach (DataRow row in dtParking.Rows)
                {
                    string slotName = row["SlotName"].ToString();
                    int usedCount = Convert.ToInt32(row["UsedCount"]);
                    int capacity = Convert.ToInt32(row["Capacity"]);
                    int availableCount = capacity - usedCount;

                    // Used
                    int idxUsed = usedSeries.Points.AddXY(slotName, usedCount);
                    usedSeries.Points[idxUsed].ToolTip = $"Slot: {slotName}\nUsed: {usedCount}\nCapacity: {capacity}";
                    usedSeries.Points[idxUsed].Label = usedCount.ToString();

                    // Available
                    int idxAvail = availableSeries.Points.AddXY(slotName, availableCount);
                    availableSeries.Points[idxAvail].ToolTip = $"Slot: {slotName}\nAvailable: {availableCount}\nCapacity: {capacity}";
                    availableSeries.Points[idxAvail].Label = availableCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void bntTotalGuest_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            // FOR DISPLAY GRID OF TOTAL GUEST WHEN CLICK ON MORE INFO BUTTON OF TOTOL GUEST
            frmInformationAM objAM = new frmInformationAM(lblTotalGuest.Text, fromDate, toDate);
            objAM.Show();

        }

        private void bntActiveBooking_Click(object sender, EventArgs e)
        {
            //FOR DISPLAY GRID OF ACTIVE BOOKING  WHEN CLICK ON MORE INFO BUTTON OF ACTIVE BOOKING 

            frmInformationAM objAM = new frmInformationAM(lblActiveBookings.Text);
            objAM.Show();

        }

        public void FilterGridByDateAM()
        {
            try
            {
                DateTime fromDate = dtpFrom.Value.Date;
                DateTime toDate = dtpTo.Value.Date;

                if (fromDate > toDate)
                {
                    MessageBox.Show("From Date cannot be greater than To Date");
                    return;
                }

                clsUser obj1 = new clsUser();
                obj1.FromDAM = fromDate;
                obj1.ToDAM = toDate;

                DataTable d1 = obj1.GuestPaymentCountByStatusDTAM();
                PiePaymentStatus(d1);

                lblPendingPaymentCount.Text = (obj1.GetTotalPaymentCountDTAM().ToString());
                lblTotalGuestCount.Text = obj1.GetGuestCountDTAM().ToString();
                DataTable dAM = obj1.GetTotalPaymentInfoFilterAM();
                CalculateTotalFromAllPagesAM(dAM);




                //DataTable d2 = obj1.ParkingCountByStatusDTAM();
                //PollParkingStatus(d2);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pctRefresh_Click(object sender, EventArgs e)
        {
            dtpFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpTo.Value = DateTime.Now;
            MainFormLoadAM();
        }

        private void btnTodaysEvents_Click(object sender, EventArgs e)
        {
            //FOR DISPLAY GRID OF TODAYS EVENTS WHEN CLICK ON MORE INFO BUTTON OF TOTOL GUEST
            frmInformationAM objAM = new frmInformationAM(lblTodaysEvents.Text);
            objAM.Show();
        }

        private void btnPendingPayment_Click(object sender, EventArgs e)
        {
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            //FOR DISPLAY GRID OF PENDING PAYMENT OF GUEST WHEN CLICK ON MORE INFO BUTTON OF PENDING PEYMENT
            frmInformationAM objAM = new frmInformationAM(lblTotalPayment.Text, fromDate, toDate);
            objAM.Show();
        }

        private void btnTodaysCheckOuts_Click(object sender, EventArgs e)
        {

            frmInformationAM objAM = new frmInformationAM(lblTodaysCheckOuts.Text);
            objAM.Show();
        }

        private void lblLowStockCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("Low-Stock Inventory List");
            objAM.Show();
        }

        private void lblInStockCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("In-Stock Inventory List");
            objAM.Show();
        }

        private void lblOutOfStockCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("Out Of Stock Inventory List");
            objAM.Show();
        }

        private void dtpFrom_ValueChanged_1(object sender, EventArgs e)
        {
            FilterGridByDateAM();

        }

        private void dtpTo_ValueChanged_1(object sender, EventArgs e)
        {
            FilterGridByDateAM();

        }

        private void lblPresentCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("Present Employee Count");
            objAM.Show();
        }

        public string StatusAM; public int indexAM;
        private void lblAbsentCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("Absent Employee Count");
            objAM.Show();
        }

        //public void StatusWisePaymwntInfoAM(string method)
        //{
        //    frmInformationAM objAM = new frmInformationAM(method);
        //    objAM.Show();
        //}
        private void piePaymentByStatus_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = piePaymentByStatus.HitTest(e.X, e.Y);
            if (result.ChartElementType == ChartElementType.DataPoint)
            {
                indexAM = result.PointIndex;

                StatusAM = piePaymentByStatus.Series[0].Points[indexAM].AxisLabel;
            }
            DateTime fromDate = dtpFrom.Value.Date;
            DateTime toDate = dtpTo.Value.Date;
            if (StatusAM == "Pending")
            {

                frmInformationAM objAM = new frmInformationAM("Pending Payment Information", fromDate, toDate);
                objAM.Show();
            }
            else
            {
                frmInformationAM objAM = new frmInformationAM("Paid Payment Information", fromDate, toDate);
                objAM.Show();
            }

        }
        public string lbl;
        private void dnutRoomWiseStatus_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result1 = dnutRoomWiseStatus.HitTest(e.X, e.Y);
            if (result1.ChartElementType == ChartElementType.DataPoint)
            {
                indexAM = result1.PointIndex;
                StatusAM = dnutRoomWiseStatus.Series[0].Points[indexAM].AxisLabel;
            }
            if (StatusAM == "Occupied")
            {
                lbl = "Occupied Room Information";
                frmInformationAM frm = new frmInformationAM(lbl);
                frm.Show();
            }
            else if (StatusAM == "Available")
            {
                lbl = "Available Room Information";
                frmInformationAM objAM = new frmInformationAM(lbl);
                objAM.Show();
            }
            else if (StatusAM == "Cleaning")
            {
                lbl = "Cleaning Room Information";
                frmInformationAM objAM = new frmInformationAM(lbl);
                objAM.Show();
            }
            else if (StatusAM == "Unclean")
            {
                lbl = "Unclean Room Information";
                frmInformationAM objAM = new frmInformationAM(lbl);
                objAM.Show();
            }


        }

        private void lblOnLeaveCount_Click(object sender, EventArgs e)
        {
            frmInformationAM objAM = new frmInformationAM("On Leave Employee Count");
            objAM.Show();
        }

        //private void pollParkingSlot_MouseClick(object sender, MouseEventArgs e)
        //{
        //    HitTestResult result = pollParkingSlot.HitTest(e.X, e.Y);

        //    if (true)
        //    {
        //        string slotName = result.Series.Points[result.PointIndex].AxisLabel;
        //        string seriesName = result.Series.Name;
        //        if (seriesName == "Used")
        //        {
        //            if (slotName == "Slot-A1")
        //            {
        //                frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - A1");
        //                objAM.Show();
        //            }
        //            else if (slotName == "Slot-A2")
        //            {
        //                frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - A2");
        //                objAM.Show();
        //            }
        //            else if (slotName == "Slot-B1")
        //            {
        //                frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - B1");
        //                objAM.Show();
        //            }
        //            else if (slotName == "Slot-B2")
        //            {
        //                frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - B2");
        //                objAM.Show();
        //            }
        //            else if (slotName == "Slot-C1")
        //            {
        //                frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - C1");
        //                objAM.Show();
        //            }
        //        }

        //    }
        //}

        private void pollParkingSlot_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                HitTestResult result = pollParkingSlot.HitTest(e.X, e.Y);

                // Null किंवा invalid result check
                if (result != null && result.Series != null && result.PointIndex >= 0)
                {
                    string slotName = result.Series.Points[result.PointIndex].AxisLabel;
                    string seriesName = result.Series.Name;

                    if (seriesName == "Used")
                    {
                        if (slotName == "Slot-A1")
                        {
                            frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - A1");
                            objAM.Show();
                        }
                        else if (slotName == "Slot-A2")
                        {
                            frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - A2");
                            objAM.Show();
                        }
                        else if (slotName == "Slot-B1")
                        {
                            frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - B1");
                            objAM.Show();
                        }
                        else if (slotName == "Slot-B2")
                        {
                            frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - B2");
                            objAM.Show();
                        }
                        else if (slotName == "Slot-C1")
                        {
                            frmInformationAM objAM = new frmInformationAM("Parking Information Of Slot - C1");
                            objAM.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Exception handle करून user ला माहिती दे
                MessageBox.Show("Error while opening parking information.\nDetails: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
     

        }
        private void CalculateTotalFromAllPagesAM(DataTable dt)
        {
            HashSet<string> seenBookings = new HashSet<string>();
            decimal totalIncome = 0;

            foreach (DataRow row in dt.Rows)
            {
                string raw = row["Paid Amount (₹)"]?.ToString()
                                .Replace("₹", "")
                                .Replace(",", "")
                                .Trim();

                if (decimal.TryParse(raw, out decimal amt))
                {
                    totalIncome += amt;
                }

            }
            lblAmount.Text = "₹" + totalIncome.ToString("N2");

        }
    }
}

