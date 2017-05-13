#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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

            Application.Run(new FormMain());
        }
    }
}
