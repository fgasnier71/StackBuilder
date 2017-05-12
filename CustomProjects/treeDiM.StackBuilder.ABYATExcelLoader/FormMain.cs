#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using treeDiM.StackBuilder.ABYATExcelLoader.Properties;
#endregion

namespace treeDiM.StackBuilder.ABYATExcelLoader
{
    public partial class FormMain : Form
    {
        #region Constructor
        public FormMain()
        {
            InitializeComponent();
        }
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);


        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.PalletLength = 0.0;
            Settings.Default.PalletWidth = 0.0;
            Settings.Default.PalletHeight = 0.0;
            Settings.Default.PalletWeight = 0.0;
            Settings.Default.PalletMaximumHeight = 0.0;
            Settings.Default.PalletFactorForm = 0;
            Settings.Default.ContainerLength = 0.0;
            Settings.Default.ContainerWidth = 0.0;
            Settings.Default.ContainerHeight = 0.0;
        }
        #endregion

        #region Menu event handlers
        private void onSettings(object sender, EventArgs e)
        {

        }
        private void onExit(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
