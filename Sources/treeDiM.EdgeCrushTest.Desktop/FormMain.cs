#region Using directive
using System;
using System.Reflection;
using System.Windows.Forms;

using log4net;
using WeifenLuo.WinFormsUI.Docking;
#endregion

namespace treeDiM.EdgeCrushTest.Desktop
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
            if (AssemblyConf == "debug")
                OnShowLogConsole(this, null);
            timerMain.Start();
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        #endregion
        #region Event handlers
        private void OnExit(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void OnAbout(object sender, EventArgs e)
        {
            using (AboutBox form = new AboutBox() {})
            { form.ShowDialog(); }
        }
        private void OnTimerTick(object sender, EventArgs e)
        {
            timerMain.Stop();
            var dockContentReverseBCT = new DockContentReverseBCT();
            dockContentReverseBCT.Show(dockPanel, DockState.Document);
            var dockContentComputeBCT = new DockContentComputeBCT();
            dockContentComputeBCT.Show(dockPanel, DockState.Document);
        }
        private void OnMode1(object sender, EventArgs e)
        {
            CloseAllDockedForms();
            var dockContentComputeBCT = new DockContentComputeBCT();
            dockContentComputeBCT.Show(dockPanel, DockState.Document);
        }
        private void OnMode2(object sender, EventArgs e)
        {
            CloseAllDockedForms();
            var dockContentReverseBCT = new DockContentReverseBCT();
            dockContentReverseBCT.Show(dockPanel, DockState.Document);
        }
        private void OnEditMaterialList(object sender, EventArgs e)
        {
            CloseAllDockedForms();
            ECT_Forms.EditMaterialList();
        }
        private void OnEditPalletList(object sender, EventArgs e)
        {
            CloseAllDockedForms();
            ECT_Forms.EditPalletList();
        }
        private void OnShowLogConsole(object sender, EventArgs e)
        {
            _logConsole = new DockContentLogConsole();
            _logConsole.Show(dockPanel, DockState.DockBottom);

        }
        #endregion
        #region Helpers
        private void CloseAllDockedForms()
        {
                if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
                {
                    foreach (Form form in MdiChildren)
                        form.Close();
                }
                else
                {
                    foreach (IDockContent document in dockPanel.DocumentsToArray())
                    {
                        // IMPORANT: dispose all panes.
                        document.DockHandler.DockPanel = null;
                        document.DockHandler.Close();
                    }
                }
        }
        #endregion

        #region Helpers
        public string AssemblyConf
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyConfigurationAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyConfigurationAttribute confAttribute = (AssemblyConfigurationAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (!string.IsNullOrEmpty(confAttribute.Configuration))
                        return confAttribute.Configuration.ToLower();
                }
                return "release";
            }
        }
        #endregion
        #region Data members
        private static ILog _log = LogManager.GetLogger(typeof(FormMain));
        private DockContentLogConsole _logConsole;
        #endregion


    }
}
