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
    public partial class frmNotifications : Form
    {
        clsUser obj = new clsUser();
        public static bool IsCardClickingVM = false;
        public int UnreadCountVM { get; set; }

        public frmNotifications()
        {
            InitializeComponent();
        }

        private void LoadNotificationsVM()
        {
            try
            {
                flpNotificationsVM.Controls.Clear(); 

                DataTable dt = obj.GetNotificationsVM();

                if (dt == null || dt.Rows.Count == 0)
                {
                    flpNotificationsVM.Controls.Add(CreateFallbackCardVM("No notifications found."));
                    flpNotificationsVM.PerformLayout();
                    flpNotificationsVM.Visible = true;
                    return;
                }

                // DEBUG: Show all rows
                foreach (DataRow row in dt.Rows)
                {
                    string debugVM = $"ID: {row["Sr.No"]}, Title: {row["Title"]}, Desc: {row["Description"]}, IsSeen: {row["IsSeen"]}, CreatedAt: {row["Date"]}";
                    Console.WriteLine(debugVM);
                }

                // Filter unread notifications safely
                var topUnread = dt.AsEnumerable()
                                  .Where(row =>
                                      row["IsSeen"] != DBNull.Value &&
                                      row["IsSeen"].ToString().ToUpper() == "FALSE"
                                  )
                                  .OrderByDescending(row =>
                                  {
                                      DateTime created;
                                      return DateTime.TryParse(row["Date"]?.ToString(), out created)
                                          ? created
                                          : DateTime.MinValue;
                                  })
                                  .Take(3)
                                  .ToArray();

                UnreadCountVM = obj.GetUnreadCountVM();
                lblUnreadNotificationsVM.Text = "Unread: " + UnreadCountVM;

                if (topUnread.Length > 0)
                {
                    foreach (var row in topUnread)
                    {
                        try
                        {
                            Panel card = CreateNotificationCardVM(row);
                            flpNotificationsVM.Controls.Add(card);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error creating card: " + ex.Message,
                                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    flpNotificationsVM.Controls.Add(CreateFallbackCardVM("No unread notifications available."));
                }

                // Invisible spacer to trigger layout
                Panel spacer = new Panel
                {
                    Width = 0,
                    Height = 0,
                    Visible = false
                };
                flpNotificationsVM.Controls.Add(spacer);

                flpNotificationsVM.PerformLayout();
                flpNotificationsVM.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while loading notifications: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Panel CreateFallbackCardVM(string message)
        {
            try
            {
                int cardWidth = flpNotificationsVM.ClientSize.Width > 0 ? flpNotificationsVM.ClientSize.Width - 20 : 280;

                Panel fallbackCardVM = new Panel
                {
                    Width = cardWidth,
                    Height = 100,
                    BackColor = Color.LightYellow,
                    Margin = new Padding(10)
                };

                Label lblFallbackVM = new Label
                {
                    Text = message,
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    Location = new Point(10, 10),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                fallbackCardVM.Controls.Add(lblFallbackVM);
                return fallbackCardVM;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating fallback card: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Panel();
            }
        }

        private Panel CreateNotificationCardVM(DataRow row)
        {
            try
            {
                int cardWidthVM = flpNotificationsVM.ClientSize.Width > 0 ? flpNotificationsVM.ClientSize.Width - 20 : 280;

                Panel cardVM = new Panel
                {
                    Width = cardWidthVM,
                    Height = 100,
                    BackColor = Color.WhiteSmoke,
                    Margin = new Padding(10),
                    Tag = row["NotificationID"],
                    Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
                };

                cardVM.MouseEnter += (s, e) => cardVM.BackColor = Color.LightBlue;
                cardVM.MouseLeave += (s, e) => cardVM.BackColor = Color.WhiteSmoke;

                Label lblTitleVM = new Label
                {
                    Text = row["Title"].ToString(),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label lblDescVM = new Label
                {
                    Text = row["Description"].ToString(),
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Label lblTimeVM = new Label
                {
                    Text = Convert.ToDateTime(row["Date"]).ToString("g"),
                    Location = new Point(10, 60),
                    AutoSize = true,
                    ForeColor = Color.Gray
                };

                cardVM.Controls.Add(lblTitleVM);
                cardVM.Controls.Add(lblDescVM);
                cardVM.Controls.Add(lblTimeVM);

                cardVM.Click += (s, e) =>
                {
                    try
                    {
                        timer1.Stop(); 

                        int id = Convert.ToInt32(cardVM.Tag);

                        obj.notificationIdVM = id;
                        obj.MarkAsReadVM();

                        //Form topForm = this.TopLevelControl as Form;
                        MessageBox.Show(this, "Notification marked as read!",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        this.BeginInvoke((MethodInvoker)delegate
                        {
                            LoadNotificationsVM(); 
                            timer1.Start(); 
                        });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while marking notification: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                return cardVM;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating notification card: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Panel();
            }
        }

        private void frmNotifications_Load(object sender, EventArgs e)
        {
            try
            {
                LoadNotificationsVM();
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during form load: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                LoadNotificationsVM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error during auto-refresh: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                this.Visible = false;
                frmAllNotificationsVM allForm = new frmAllNotificationsVM();
                allForm.ShowDialog();
                this.Visible = true;
                LoadNotificationsVM();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening all notifications: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pnlMainVM_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}