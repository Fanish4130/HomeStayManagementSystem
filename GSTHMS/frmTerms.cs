using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    public partial class frmTermsVM : Form
    {
        public string DescriptionVM;
        public frmTermsVM()
        {
            InitializeComponent();
        }

        public void frmTerms_Conditions_Load(object sender, EventArgs e)
        {
            rtfTermsAndConditionsVM.ReadOnly = true; 
            rtfTermsAndConditionsVM.Clear();
            clsUser clsUser = new clsUser();
            DataTable dt = new DataTable();
            dt = clsUser.FetchTermsAndConditionsTableVM();
            foreach (DataRow row in dt.Rows)
            {
                string descriptionVM = row["Description"]?.ToString();
                if (!string.IsNullOrWhiteSpace(descriptionVM))
                {
                    rtfTermsAndConditionsVM.AppendText(descriptionVM + Environment.NewLine + Environment.NewLine);
                }
            }

        }

    }
}
