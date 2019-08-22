#region Using directives
using System;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;
using log4net.Config;
using CrashReporterDotNET;
#endregion

namespace treeDiM.EdgeCrushTest.Desktop
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

            // *** crash reporting
            Application.ThreadException += (sender, threadargs) => SendCrashReport(threadargs.Exception);
            AppDomain.CurrentDomain.UnhandledException += (sender, threadargs) =>
            {
                SendCrashReport((Exception)threadargs.ExceptionObject);
                Environment.Exit(0);
            };
            // *** crash reporting

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormMain());
        }

        #region Exception reporting
        /// <summary>
        /// Report an exception
        /// </summary>
        public static void SendCrashReport(Exception exception)
        {
            var reportCrash = new ReportCrash("treedim@gmail.com")
            {
                FromEmail = "treedim@gmail.com",
                SmtpHost = "smtp.gmail.com",
                Port = 587,
                UserName = "treedim@gmail.com",
                Password = "Knowledge_1",
                EnableSSL = true,
            };

            reportCrash.Send(exception);
        }
        #endregion
    }
}
