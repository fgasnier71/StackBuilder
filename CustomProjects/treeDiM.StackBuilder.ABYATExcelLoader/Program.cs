#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.ABYATExcelLoader
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // setting unit system to cm/kg
            UnitsManager.CurrentUnitSystem = UnitsManager.UnitSystem.UNIT_METRIC2;

            WebClient webClient = new WebClient();
            try
            {
                string localFilePath = Path.ChangeExtension(Path.GetTempFileName(), "config");
                webClient.DownloadFile("http://www.plmpack.com/stackbuilder/ABYATExcelLoader.config", localFilePath);
            }
            catch (Exception /*ex*/)
            {
                MessageBox.Show("Please contact fgasnier@treedim.com");
                return;
            }

            Application.Run(new FormMain());
        }
    }
}
