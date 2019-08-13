#region Using directive
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;
using WeifenLuo.WinFormsUI.Docking;

using treeDiM.EdgeCrushTest;
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
            _dockContentComputeBCT.Show(dockPanel, DockState.Document);
        }
        #endregion

        #region Data members
        private DockContentComputeBCT _dockContentComputeBCT = new DockContentComputeBCT();
        private static ILog _log = LogManager.GetLogger(typeof(FormMain));
        #endregion

    }
}
