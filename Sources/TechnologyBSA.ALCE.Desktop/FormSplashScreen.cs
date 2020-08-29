#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    /// <summary>
    /// Splash screen form
    /// </summary>
    public partial class FormSplashScreen : Form
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public FormSplashScreen(Form parentForm)
        {
            // save parent form
            InitializeComponent();
            // make lower right pixel color transparent
            Bitmap b = new Bitmap(BackgroundImage);
            if (Transparent)
                TransparencyKey = b.GetPixel(1, 1); ;
            // version
            lblVersion.Text = $"{AssemblyVersion}";
        }
        #endregion

        #region Public properties
        /// <summary>
        /// retrieves assembly version
        /// </summary>
        public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();
        /// <summary>
        ///  set / get time interval after which the splash screen will close
        /// </summary>
        public int TimerInterval
        {
            set { timerClose.Interval = value;  }
            get { return timerClose.Interval; }
        }
        /// <summary>
        /// set / get transparency
        /// </summary>
        public bool Transparent { get; set; } = true;
        #endregion

        /// <summary>
        /// handles timer tick and closes splashscreen
        /// </summary>
        private void OnTimerTick(object sender, EventArgs e)
        {
            Close();
            ParentForm?.BringToFront();
        }
    }
}
