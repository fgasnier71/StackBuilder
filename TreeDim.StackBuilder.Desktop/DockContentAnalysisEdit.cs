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
    public partial class DockContentAnalysisEdit : DockContent, IView, IItemListener
    {
        #region Data members
        /// <summary>
        /// document
        /// </summary>
        protected IDocument _document;
        /// <summary>
        /// analysis
        /// </summary>
        protected Analysis _analysis;
        /// <summary>
        /// solution
        /// </summary>
        protected Solution _solution;
        #endregion

        #region Constructor
        public DockContentAnalysisEdit(IDocument document, Analysis analysis)
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
        }
        #endregion

        #region Private properties
        #endregion

        #region IItemListener implementation
        public void Update(ItemBase item)
        {
            graphCtrlSolution.Invalidate();
        }
        public void Kill(ItemBase item)
        {
            Close();
            _analysis.RemoveListener(this);
        }
        #endregion

        #region Public properties
        public Analysis Analysis
        {
            get { return _analysis; }
        }
        public Solution Solution
        {
            get { return _solution; }
            set { _solution = value; }
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
            ViewerSolution sv = new ViewerSolution(Solution);
            sv.Draw(graphics, showDimensions);
        }
        #endregion
    }
}
