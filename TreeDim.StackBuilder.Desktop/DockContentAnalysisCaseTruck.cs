#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
// Docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCaseTruck : DockContentAnalysisEdit
    {
        #region Data members
        /// <summary>
        /// logger
        /// </summary>
        static readonly new ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisCaseTruck));
        #endregion

        #region Constructor
        public DockContentAnalysisCaseTruck()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!DesignMode)
                this.Text = _analysis.Name + " - " + _analysis.ParentDocument.Name;
        }
        #endregion

        #region Override DockContentAnalysisEdit
        public override void FillGrid()
        {
            // clear grid
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;
        }
        public override void UpdateGrid()
        {
            // remove all existing rows
            gridSolutions.Rows.Clear();

            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.Invalidate();
        }
        #endregion
    }
}
