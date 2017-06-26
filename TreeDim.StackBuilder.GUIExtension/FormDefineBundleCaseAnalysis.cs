#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using treeDiM.StackBuilder.GUIExtension.Properties;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;

using log4net;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    internal partial class FormDefineBundleCaseAnalysis : Form, IDrawingContainer
    {
        #region Data members
        private string _name;
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormDefineBundleCaseAnalysis));
        private AnalysisBoxCase _analysis = null;
        private Document _doc = null;
        #endregion

        #region Constructor
        public FormDefineBundleCaseAnalysis()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            FlatWeight = Settings.Default.BoxFlatWeight;
            NoFlats = Settings.Default.NoFlatsInBundle;
            
            CaseInsideLength = Settings.Default.CaseLength;
            CaseInsideWidth = Settings.Default.CaseWidth;
            CaseInsideHeight = Settings.Default.CaseHeight;
            CaseWeight = Settings.Default.CaseWeight;

            graphCtrlSolution.DrawingContainer = this;

            Compute();
            gridSolutions.Selection.SelectionChanged += onGridSolutionSelectionChanged;
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            Settings.Default.BoxFlatWeight = FlatWeight;
            Settings.Default.NoFlatsInBundle = NoFlats;

            Settings.Default.CaseLength = CaseInsideLength;
            Settings.Default.CaseWidth = CaseInsideWidth;
            Settings.Default.CaseHeight = CaseInsideHeight;
            Settings.Default.CaseWeight = CaseWeight;
        }
        #endregion

        #region Public properties
        public string BundleName
        {
            get { return _name; }
            set { _name = value; }
        }
        public double BundleLength
        {
            get { return (double)nudFlatLength.Value; }
            set { nudFlatLength.Value = (decimal)value; }
        }
        public double BundleWidth
        {
            get { return (double)nudFlatWidth.Value; }
            set { nudFlatWidth.Value = (decimal)value; }
        }
        public double FlatThickness
        {
            get { return (double)nudFlatThickness.Value; }
            set { nudFlatThickness.Value = (decimal)value; }
        }
        public double FlatWeight
        {
            get { return (double)nudFlatWeight.Value; }
            set { nudFlatWeight.Value = (decimal)value; }
        }
        public int NoFlats
        {
            get { return (int)nudNumberOfFlats.Value; }
            set { nudNumberOfFlats.Value = (decimal)value; }
        }
        public double CaseInsideLength
        {
            get { return (double)nudCaseLength.Value; }
            set { nudCaseLength.Value = (decimal)value; }
        }
        public double CaseInsideWidth
        {
            get { return (double)nudCaseWidth.Value; }
            set { nudCaseWidth.Value = (decimal)value; }
        }
        public double CaseInsideHeight
        {
            get { return (double)nudCaseHeight.Value; }
            set { nudCaseHeight.Value = (decimal)value; }
        }
        public double CaseWeight
        {
            get { return (double)nudCaseWeight.Value; }
            set { nudCaseWeight.Value = (decimal)value; }
        }
        #endregion

        #region IDrawingContainer implementation
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (null == CurrentSolution) return;
            BoxCaseSolutionViewer sv = new BoxCaseSolutionViewer(CurrentSolution);
            sv.Draw(graphics);
        }
        #endregion

        #region Grid
        protected void Compute()
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void FillGrid()
        {
        }
        #endregion

        #region Helpers
        private int CurrentSolutionIndex
        {
            get
            {
                SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                // no selection -> exit
                if (indexes.Length == 0) return -1;
                // return index
                return indexes[0] - 1;
            }
        }
        private BoxCaseSolution CurrentSolution
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region Event handlers
        /// <summary>
        /// SourceGrid row selection change handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onGridSolutionSelectionChanged(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            SourceGrid.RangeRegion region = gridSolutions.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return;
            // redraw
            graphCtrlSolution.Invalidate();
        }
        private void DimensionChanged(object sender, EventArgs e)
        {
            gridSolutions.Rows.Clear();
            // restart timer
            timerRefresh.Stop();
            timerRefresh.Start();
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            // compute analysis
            Compute();
        }
        private void bnRefresh_Click(object sender, EventArgs e)
        {
            Compute();
        }
        private void ToolsGenerateReport(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void ToolsGenerateStackBuilderProject(object sender, EventArgs e)
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
