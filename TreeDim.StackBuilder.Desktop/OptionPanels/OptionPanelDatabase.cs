#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelDatabase : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelDatabase()
        {
            InitializeComponent();
        }
        #endregion

        #region OptionPanel override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // initialize
            chkbCloseAfterImport.Checked = Properties.Settings.Default.CloseDbBrowserAfterImport;
            // register event handler
            OptionsForm.OptionsSaving += new EventHandler(OptionsForm_OptionsSaving);
        }
        #endregion

        #region Handlers
        private void OptionsForm_OptionsSaving(object sender, EventArgs e)
        {
            Properties.Settings.Default.CloseDbBrowserAfterImport = chkbCloseAfterImport.Checked;
            Properties.Settings.Default.Save();            
        }
        #endregion
    }
}
