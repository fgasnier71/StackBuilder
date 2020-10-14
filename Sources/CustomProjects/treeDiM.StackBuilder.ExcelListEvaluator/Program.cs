#region Using directives
using System;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;
using log4net.Config;

using treeDiM.Basics;
#endregion

namespace treeDiM.StackBuilder.ExcelListEvaluator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // set up a simple logging configuration
            XmlConfigurator.Configure();
            if (!LogManager.GetRepository().Configured)
                Debug.Fail("Logging not configured!\n Press ignore to continue");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // setting unit system to cm/kg
            UnitsManager.CurrentUnitSystem = UnitsManager.UnitSystem.UNIT_METRIC1;
            Application.Run(new FormMain());
        }
    }
}
