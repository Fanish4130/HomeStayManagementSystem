using demosidebar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSTHMS
{
    internal static class Program
    {
            public static string UserName = "";
             public static string UserCode = "";


        // <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmPay());
            // Application.Run(new frmFeedback());

            //Application.Run(new frmUIDesign());
            // Application.Run(new frmUIDesign());
             Application.Run(new log());
            //Application.Run(new frmTerms_ConditionsVM());
            // Application.Run(new frmPay());
            // Application.Run(new frmDashboardAM());
            //Application.Run(new frmLeaveRPcs());
            //Application.Run(new Form1());
        }
    }
}