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
    public partial class frmMenuList : Form
    {
        public frmMenuList()
        {
            InitializeComponent();
        }

        private void frmMenuList_Load(object sender, EventArgs e)
        {
            this.grdFoodMenuList.DefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.grdFoodMenuList.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 11);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            clsUser obj = new clsUser();

            DataTable dt = obj.GetMenuListSRM();

            grdFoodMenuList.DataSource = dt;

            grdFoodMenuList.AllowUserToAddRows = false;
            grdFoodMenuList.ScrollBars = ScrollBars.None;
            grdFoodMenuList.AllowUserToAddRows = false;
            grdFoodMenuList.ReadOnly = true;
            grdFoodMenuList.RowHeadersVisible = false;
            grdFoodMenuList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grdFoodMenuList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grdFoodMenuList.MultiSelect = false;

            grdFoodMenuList.RowTemplate.Height = 30;
            grdFoodMenuList.ColumnHeadersHeight = 30;

            int totalHeight =
                grdFoodMenuList.ColumnHeadersHeight +
                (grdFoodMenuList.RowTemplate.Height * grdFoodMenuList.Rows.Count) + 5;

            grdFoodMenuList.Height = totalHeight;

            this.Height = grdFoodMenuList.Bottom + 20;
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void grdFoodMenuList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
