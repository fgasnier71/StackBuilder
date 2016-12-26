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
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisPalletTruck : DockContentView
    {
        #region Data members
        /// <summary>
        /// analysis
        /// </summary>
        private AnalysisPalletTruck _analysis;
        /// <summary>
        /// solution
        /// </summary>
        private Solution _solution;
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisPalletTruck));
        #endregion

        #region Constructor
        public DockContentAnalysisPalletTruck(IDocument document, AnalysisPalletTruck analysis)
            : base(document)
        {
            _analysis = analysis;
            _analysis.AddListener(this);

            _solution = analysis.Solution;

            InitializeComponent();
        }
        #endregion

        #region IItemListener implementation
        public override void Update(ItemBase item)
        {
            base.Update(item);
        }
        public override void Kill(ItemBase item)
        {
            base.Kill(item);
            _analysis.RemoveListener(this);
        }
        #endregion

        #region Public properties
        public AnalysisPalletTruck Analysis
        {
            get { return _analysis; }  
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // --- window caption
            this.Text = _analysis.Name + " _ " + _analysis.ParentDocument.Name;
            // --- initialize drawing container
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();
            // --- initialize grid control
            FillGrid();
            UpdateGrid();
            // ---
        }
        #endregion

        #region Grid filling
        private void FillGrid()
        {
            // clear grid
            gridSolution.Rows.Clear();
            // border
            gridSolution.BorderStyle = BorderStyle.FixedSingle;
            gridSolution.ColumnsCount = 2;
            gridSolution.FixedColumns = 1;
        }
        private void UpdateGrid()
        {
            try
            {
                // sanity check
                if (gridSolution.ColumnsCount < 2)
                    return;
                // remove all existing rows
                gridSolution.Rows.Clear();
                // *** IViews
                // captionHeader

            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Helpers
        private string BuildLayerCaption(List<int> layerIndexes)
        {
            StringBuilder sb = new StringBuilder();
            return sb.ToString();
        }
        #endregion
    }
}
