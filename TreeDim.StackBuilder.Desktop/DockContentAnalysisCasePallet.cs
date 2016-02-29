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
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisCasePallet : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        private IDocument _document;
        /// <summary>
        /// analysis
        /// </summary>
        private AnalysisCasePallet _analysis;
        /// <summary>
        /// solution
        /// </summary>
        private Solution _solution;

        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisCasePallet));
        #endregion

        #region Constructor
        public DockContentAnalysisCasePallet(IDocument document, AnalysisCasePallet analysis)
        {
            _document = document;

            _analysis = analysis;
            _analysis.AddListener(this);

            _solution = analysis.Solutions[0];

            InitializeComponent();

        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // initialize drawing container
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();

            graphCtrlSolution.VolumeSelected += onLayerSelected;
        }

        void onLayerSelected(int id)
        {
            _solution.SelectLayer(id);
        }
        #endregion

        #region IItemListener implementation
        public void Update(ItemBase item)
        {
            // draw
            Draw();
        }
        public void Kill(ItemBase item)
        {
            Close();
            _analysis.RemoveListener(this);
        }
        #endregion

        #region IView implementation
        public IDocument Document
        {
            get { return _document; }
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            bool showDimensions = true;
            ViewerSolution sv = new ViewerSolution( Solution);
            sv.Draw(graphics, showDimensions);
        }
        #endregion

        #region Public properties
        public AnalysisCasePallet Analysis
        {
            get { return _analysis; }
        }
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
        }
        #endregion

        #region Drawing
        private void Draw()
        {
            try
            {
                if (graphCtrlSolution.Size.Width < 1 || graphCtrlSolution.Size.Height < 1)
                    return;
                graphCtrlSolution.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion
    }
}
