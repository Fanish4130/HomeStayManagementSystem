//using GSTHMS;
using GSTHMS;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace demosidebar
{
    public partial class frmUIDesign : Form
    {
        private Button _activeSidebarButton;
        private bool sidebarexpand = true;
        private bool submenuExpanding = false;
        private int submenuFullHeight = 0;
        private bool isBookingVisible = false;
        private bool isTermsVisible = false;    
        public string userCodeVM;
        public string LoggedUserCodeVM { get; set; }

        public frmUIDesign()
        {
            InitializeComponent();
            RegisterSidebarEvents();
            customizeDesign();
            lblTitle.Text = " ";
            LoggedUserCodeVM = Program.UserName;

            lblReceptionistName.Text = Program.UserName;
        }

        public void customizeDesign()
        {
            
        }

        private void RegisterSidebarEvents()
        {
            foreach (Control ctrl in pnlSideBar.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.Click += SidebarButton_Click;
                    btn.BackColor = Color.Black;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Purple;
                    btn.FlatAppearance.BorderSize = 2;
                }
            }
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            if (_activeSidebarButton != null)
            {
                _activeSidebarButton.BackColor = Color.Black;
                _activeSidebarButton.ForeColor = Color.White;
            }

            Button clickedButton = sender as Button;
            if (clickedButton != null)
            {
                clickedButton.BackColor = Color.White;
                clickedButton.ForeColor = Color.Black;
                _activeSidebarButton = clickedButton;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            frmDashboardAM objA = new frmDashboardAM();
            LoadFormInPanelVM (objA);

            LoadProfileIconVM();


            //Notification
            clsUser obj = new clsUser();
            int UnreadCountVM = obj.GetUnreadCountVM();
            lblUnreadCountVM.Text = "" + UnreadCountVM;
            TimerNotifyAllVM.Start();
            ButtonOff();
            btndashboard.FillColor = Color.FromArgb(50, 100, 201);
            btndashboard.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btndashboard.Text;

            frmDashboardAM onj1 = new frmDashboardAM();
            LoadFormInPanelVM(onj1);

        }

        private void LoadFormInPanelVM(Form childForm) //tp
        {
            pnlopenfrm.Controls.Clear(); // Remove any existing form
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlopenfrm.Controls.Add(childForm);
            childForm.Show();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e) { }

        private void btndashboard_Click(object sender, EventArgs e) { }

        private void guna2Button1_Click(object sender, EventArgs e) { }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            sidebartransition.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                pnlSideBar.Width -= 10;
                if (pnlSideBar.Width <= 50)
                {
                    sidebarexpand = false;
                    sidebartransition.Stop();
                }
            }
            else
            {
                pnlSideBar.Width += 10;
                if (pnlSideBar.Width >= 220)
                {
                    sidebarexpand = true;
                    sidebartransition.Stop();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e) { }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
        }

        private void btnTermsNCondition_Click(object sender, EventArgs e) { }

        private void btnMaintenanceDetails_Click(object sender, EventArgs e) { }

        private void btnOfferDetails_Click(object sender, EventArgs e) { }

        private void guna2PictureBox6_Click(object sender, EventArgs e)
        {
            
            frmProfileSettingView pf = new frmProfileSettingView();
            pf.LoggedUserCodeVM = this.LoggedUserCodeVM;
            pf.StartPosition = FormStartPosition.Manual;
            pf.Location = Screen.PrimaryScreen.WorkingArea.Location;
            pf.Size = Screen.PrimaryScreen.WorkingArea.Size;
            pf.Show();

        }

        public void hidesubmenu()
        {
           
        }

        public void hidFilterPanel()
        {
        }

        // ✅ Rewritten: submenu expands INSIDE sidebar (animated)
        public void ToggleSubmenu(Panel subMenu)
        {
            if (submenuExpanding)
                return;

            submenuExpanding = true;

            // If another submenu is open, close it first
            foreach (Control ctrl in pnlSideBar.Controls)
            {
                if (ctrl is Panel panel && panel != subMenu && panel.Tag as string == "submenu")
                {
                    panel.Visible = false;
                    panel.Height = 0;
                }
            }

            if (!subMenu.Visible)
            {
                subMenu.Visible = true;
                submenuFullHeight = subMenu.PreferredSize.Height;
                Timer expandTimer = new Timer();
                expandTimer.Interval = 10;
                expandTimer.Tick += (s, e) =>
                {
                    if (subMenu.Height < submenuFullHeight)
                        subMenu.Height += 10;
                    else
                    {
                        expandTimer.Stop();
                        submenuExpanding = false;
                        subMenu.Height = submenuFullHeight;
                    }
                };
                expandTimer.Start();
            }
            else
            {
                Timer collapseTimer = new Timer();
                collapseTimer.Interval = 10;
                collapseTimer.Tick += (s, e) =>
                {
                    if (subMenu.Height > 0)
                        subMenu.Height -= 10;
                    else
                    {
                        collapseTimer.Stop();
                        submenuExpanding = false;
                        subMenu.Visible = false;
                    }
                };
                collapseTimer.Start();
            }
        }

        public void showFilterPanel(Panel subMenu)
        {
        }

        private void btnSubAssetInventory_Click(object sender, EventArgs e)
        {
            hidesubmenu();
        }

        private void btninventorymanagement_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e) { }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }


        private void pctFilter_Click(object sender, EventArgs e)
        {
          
        }

        private void pctPDF_Click(object sender, EventArgs e) { }

        private void pctFilter_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void pnlFilter_Paint(object sender, PaintEventArgs e)
        {
            // hidFilterPanel();
        }

        private void btn_Click(object sender, EventArgs e) { }

        private void btnGuestDetails_Click(object sender, EventArgs e)
        {

        }

        private void guna2Panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnbookingdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnbookingdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnbookingdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnbookingdetails.Text;
            if (!isBookingVisible) // OPEN
            {
                //LoadFormInPanelVM(new frmTodaysbooking());
                pnlopenfrm.Visible = true;
                pnlopenfrm.BringToFront();
                isBookingVisible = true;
            }
            else // CLOSE
            {
                pnlopenfrm.Visible = false;
                isBookingVisible = false;
            }
            frmBooking objFL = new frmBooking();
            LoadFormInPanelVM(objFL);
        }

        private void btnGdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnGdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnGdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnGdetails.Text;
            frmGuest objSC = new frmGuest();
            LoadFormInPanelVM(objSC);
        }

        //private void guna2GradientButton7_Click(object sender, EventArgs e)
        //{
        //    btndashboard.FillColor = Color.FromArgb(50, 100, 201);
        //    btndashboard.FillColor2 = Color.FromArgb(144, 117, 255);
        //}

        private void btnFeedBack_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btndashboard_Click_1(object sender, EventArgs e)
        {
            ButtonOff();
            btndashboard.FillColor = Color.FromArgb(50, 100, 201);
            btndashboard.FillColor2 = Color.FromArgb(144,117,255);
            lblTitle.Text = btndashboard.Text;

            frmDashboardAM onj1= new frmDashboardAM();
            LoadFormInPanelVM(onj1);
        }

        private void btnenquiryDetilas_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnenquiryDetilas.FillColor = Color.FromArgb(50, 100, 201);
            btnenquiryDetilas.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnenquiryDetilas.Text;
            frmEnquiry objAB = new frmEnquiry();
            LoadFormInPanelVM(objAB);
        }

        private void btnroomdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnroomdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnroomdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnroomdetails.Text;
            frmMainForm  objSY = new frmMainForm();
            LoadFormInPanelVM(objSY);
        }

        private void guna2GradientButton5_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btninventory.FillColor = Color.FromArgb(50, 100, 201);
            btninventory.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btninventory.Text;
            frmInventoryOverView  objVK = new frmInventoryOverView();
            LoadFormInPanelVM(objVK);
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnasset.FillColor = Color.FromArgb(50, 100, 201);
            btnasset.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnasset.Text;
            frmAssetInventoryManagement   objVK = new frmAssetInventoryManagement();
            LoadFormInPanelVM(objVK);
        }

        private void btnAdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnAdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnAdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnAdetails.Text;
            frmAgentMainForm objSJ = new frmAgentMainForm();
            LoadFormInPanelVM(objSJ);

        }

        private void btnmaintenance_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnmaintenance.FillColor = Color.FromArgb(50, 100, 201);
            btnmaintenance.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnmaintenance.Text;
            frmMaintenance objSJ = new frmMaintenance();
            LoadFormInPanelVM(objSJ);
            
        }

        private void btnservicesdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnservicesdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnservicesdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnservicesdetails.Text;
            frmFoodService objSM = new frmFoodService();
            LoadFormInPanelVM(objSM);
        }

        private void btnstaffdetails_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnstaffdetails.FillColor = Color.FromArgb(50, 100, 201);
            btnstaffdetails.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnstaffdetails.Text;
            frmLeaveRPcs objRP = new frmLeaveRPcs();
            LoadFormInPanelVM(objRP);
        }

        private void btnpayments_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnpayments.FillColor = Color.FromArgb(50, 100, 201);
            btnpayments.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnpayments.Text;
            frmPay  objSP = new frmPay();
            LoadFormInPanelVM(objSP);
        }


        private void btneventdetail_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btneventdetail.FillColor = Color.FromArgb(50, 100, 201);
            btneventdetail.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btneventdetail.Text;
            frmEventCalendar frmEventCalendar = new frmEventCalendar();
            LoadFormInPanelVM(frmEventCalendar);
           
        }

        private void btnoffer_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnoffer.FillColor = Color.FromArgb(50, 100, 201);
            btnoffer.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnoffer.Text;
            frmOffersDetails  objSM = new frmOffersDetails();
            LoadFormInPanelVM(objSM);
        }

        private void btnfeedback_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnfeedback.FillColor = Color.FromArgb(50, 100, 201);
            btnfeedback.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnfeedback.Text;
            frmFeedback objSP = new frmFeedback();
            LoadFormInPanelVM(objSP);
        }

        private void btnreports_Click(object sender, EventArgs e)
        {
            ButtonOff();
            btnreports.FillColor = Color.FromArgb(50, 100, 201);
            btnreports.FillColor2 = Color.FromArgb(144, 117, 255);
            lblTitle.Text = btnreports.Text;
            frmMainReport objAP = new frmMainReport();
            LoadFormInPanelVM(objAP);
        }

        public void ButtonOff()
        {

           btndashboard.FillColor = Color.Transparent;
           btndashboard.FillColor2 = Color.Transparent;

            btnenquiryDetilas.FillColor = Color.Transparent;
            btnenquiryDetilas.FillColor2 = Color.Transparent;

            btnroomdetails.FillColor = Color.Transparent;
            btnroomdetails.FillColor2 = Color.Transparent;

            btnGdetails.FillColor = Color.Transparent;
            btnGdetails.FillColor2 = Color.Transparent;

            btnbookingdetails.FillColor = Color.Transparent;
            btnbookingdetails.FillColor2 = Color.Transparent;

            btninventory.FillColor = Color.Transparent;
            btninventory.FillColor2 = Color.Transparent;

            btnasset.FillColor = Color.Transparent;
            btnasset.FillColor2 = Color.Transparent;

            btnAdetails.FillColor = Color.Transparent;
            btnAdetails.FillColor2 = Color.Transparent;

            btnmaintenance.FillColor = Color.Transparent;
            btnmaintenance.FillColor2 = Color.Transparent;

            btnmaintenance.FillColor = Color.Transparent;
            btnmaintenance.FillColor2 = Color.Transparent;

            btnservicesdetails.FillColor = Color.Transparent;
            btnservicesdetails.FillColor2 = Color.Transparent;

            btnstaffdetails.FillColor = Color.Transparent;
            btnstaffdetails.FillColor2 = Color.Transparent;

            btnpayments.FillColor = Color.Transparent;
            btnpayments.FillColor2 = Color.Transparent;

            btneventdetail.FillColor = Color.Transparent;
            btneventdetail.FillColor2 = Color.Transparent;

            btnoffer.FillColor = Color.Transparent;
            btnoffer.FillColor2 = Color.Transparent;

            btnfeedback.FillColor = Color.Transparent;
            btnfeedback.FillColor2 = Color.Transparent;

            btnreports.FillColor = Color.Transparent;
            btnreports.FillColor2 = Color.Transparent;
        }

        private void pnlMenuStrip_Paint(object sender, PaintEventArgs e)
        {

        }

        public void LoadProfileIconVM()
        {
            try
            {
                clsUser u = new clsUser();
                u.UserCodeVM = LoggedUserCodeVM;

                string path = u.GetProfileImagePathVM();

                if (!string.IsNullOrEmpty(path) && File.Exists(path))
                {
                    if (pctOpenProfile.Image != null)
                    {
                        pctOpenProfile.Image.Dispose();
                    }

                    using (var img = Image.FromFile(path))
                    {
                        pctOpenProfile.Image = new Bitmap(img);
                    }

                    pctOpenProfile.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
            catch
            {
            }
        }


        private void pctNotification_Click(object sender, EventArgs e)
        {
            frmNotifications notifForm = Application.OpenForms
                .OfType<frmNotifications>()
                .FirstOrDefault();

            // If already open and visible, just hide it
            if (notifForm != null && !notifForm.IsDisposed && notifForm.Visible)
            {
                notifForm.Hide();
                return;
            }

            Point iconScreenPos = pctNotification.PointToScreen(Point.Empty);
            Point formPos = new Point(iconScreenPos.X - 150, iconScreenPos.Y + pctNotification.Height + 5);

            notifForm = new frmNotifications();
            notifForm.StartPosition = FormStartPosition.Manual;
            notifForm.Location = formPos;
            notifForm.FormBorderStyle = FormBorderStyle.None;
            notifForm.TopMost = true;
            notifForm.ShowInTaskbar = false;

            // 🔥 Hide when clicking anywhere else
            notifForm.Deactivate += (s, args) =>
            {
                notifForm.Hide(); // ✅ no disposal, safe reuse
            };

            notifForm.Show();
        }

        private void pctContact_Click(object sender, EventArgs e)
        {
            frmContact   objPSS = new frmContact();
            LoadFormInPanelVM(objPSS);
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
        private frmEmail emailForm;
        private void pctEmail_Click(object sender, EventArgs e)
        {
            if (emailForm == null || emailForm.IsDisposed)
            {
                emailForm = new frmEmail();
                emailForm.StartPosition = FormStartPosition.CenterScreen;
                emailForm.Show();
            }
            else
            {
                if (emailForm.Visible)
                {
                    emailForm.Close(); // जर already open असेल तर close करणे
                }
                else
                {
                    emailForm = new frmEmail(); // नवीन instance create
                    emailForm.StartPosition = FormStartPosition.CenterScreen;
                    emailForm.Show();
                }
            }

        }

        private void TimerNotifyAllVM_Tick(object sender, EventArgs e)
        {
            clsUser obj = new clsUser();
            int unreadCount = obj.GetUnreadCountVM();   // fetch unread countz
            lblUnreadCountVM.Text = "" + unreadCount;
        }

        private void pnlopenfrm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            //frmLogin frmLogin = new frmLogin();
            //frmLogin.Show();
        }

        private void guna2PictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click_2(object sender, EventArgs e)
        {
            if (!isTermsVisible) // OPEN
            {
                //LoadFormInPanelVM(new frmTodaysbooking());
                pnlopenfrm.Visible = true;
                pnlopenfrm.BringToFront();
                isTermsVisible = true;
            }
            else // CLOSE
            {
                pnlopenfrm.Visible = false;
                isTermsVisible = false;
            }
            frmTerms_ConditionsVM termVM = new frmTerms_ConditionsVM();
            LoadFormInPanelVM(termVM);
        }

        private void guna2PictureBox2_Click_1(object sender, EventArgs e)
        {
            log frm = new log();
            frm.Show();
        }
    }
}
