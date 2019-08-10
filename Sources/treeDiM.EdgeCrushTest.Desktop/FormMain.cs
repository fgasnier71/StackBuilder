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
        public FormMain()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _dockContentComputeBCT.Show(dockPanel, DockState.Document);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        #region Data members
        private DockContentComputeBCT _dockContentComputeBCT = new DockContentComputeBCT();
        private static ILog _log = LogManager.GetLogger(typeof(FormMain));
        #endregion
    }
}
