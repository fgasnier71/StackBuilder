using System;
using System.IO;
using treeDiM.StackBuilder.Desktop.Properties;

namespace treeDiM.StackBuilder.Desktop
{
    public partial class OptionPanelPlugins : GLib.Options.OptionsPanel
    {
        #region Constructor
        public OptionPanelPlugins()
        {
            InitializeComponent();

            CategoryPath = Resources.ID_OPTIONSPLUGINS;
            DisplayName = Resources.ID_DISPLAYPLUGINS;
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // initialize controls
            string pluginPath = Settings.Default.PluginPath;
            fileSelectPlugin.Filter = "Plugin (*.dll)|*.dll|All files (*.*)|*.*";
            fileSelectPlugin.FileName = pluginPath;
            chkbUsePlugin.Checked = File.Exists(pluginPath)
                && string.Equals(Path.GetExtension(pluginPath), ".dll", StringComparison.CurrentCultureIgnoreCase);
             // events
            OptionsForm.OptionsSaving += new EventHandler(OnOptionsSaving);
        }
        #endregion

        #region Handlers
        void OnOptionsSaving(object sender, EventArgs e)
        {
            Settings.Default.PluginPath = fileSelectPlugin.FileName;
            Settings.Default.Save();
        }
        private void OnCheckUsePlugin(object sender, EventArgs e)
        {
            fileSelectPlugin.Enabled = chkbUsePlugin.Checked;
        }
        #endregion
    }
}
