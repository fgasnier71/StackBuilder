#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisBoxCase : DockContentAnalysisEdit
    {
        #region Data members
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisBoxCase));
        #endregion

        #region Constructor
        public DockContentAnalysisBoxCase(IDocument document, Analysis analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion
 
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region Private properties
        #endregion

        #region Event handlers
        private void FillGrid()
        { 
        }

        private void UpdateGrid()
        {
        }
        private void onLayerSelected(int id)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
