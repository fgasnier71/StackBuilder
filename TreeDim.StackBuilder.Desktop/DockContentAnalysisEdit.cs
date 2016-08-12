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
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisEdit : DockContent, IView, IItemListener, IDrawingContainer, IItemBaseFilter
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

            // initialize drawing container
            graphCtrlSolution.DrawingContainer = this;
            graphCtrlSolution.Viewer = new ViewerSolution(_solution);
            graphCtrlSolution.Invalidate();

            graphCtrlSolution.VolumeSelected += onLayerSelected;

            FillGrid();
            UpdateGrid();

            FillLayerControls();
            UpdateControls();
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

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            InterlayerProperties interlayer = itemBase as InterlayerProperties;
            if (ctrl == cbInterlayer && null != interlayer)
                return _analysis.AllowInterlayer(interlayer);
            return false;
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

        #region Virtual functions
        public virtual void FillGrid()      {}
        public virtual void UpdateGrid()    {}
        #endregion

        #region Event handlers
        private void onLayerSelected(int id)
        {
            try
            {
                _solution.SelectLayer(id);
                UpdateControls();
            }
            catch (Exception /*ex*/)
            {
            }
        }
        private void onLayerTypeChanged(object sender, EventArgs e)
        {
            try
            {
                int iLayerType = cbLayerType.SelectedIndex;
                // get selected layer
                _solution.SetLayerTypeOnSelected(iLayerType);
                // redraw
                graphCtrlSolution.Invalidate();
                UpdateGrid();
            }
            catch (Exception /*ex*/)
            {
            }
        }
        private void onInterlayerChanged(object sender, EventArgs e)
        {
            try
            {
                // get index of interlayer
                InterlayerProperties interlayer = null;
                if (chkbInterlayer.Checked)
                    interlayer = cbInterlayer.SelectedType as InterlayerProperties;
                _solution.SetInterlayerOnSelected(interlayer);
                graphCtrlSolution.Invalidate();
                UpdateGrid();
            }
            catch (Exception /*ex*/)
            {
            }
        }
        private void onReflectionX(object sender, EventArgs e)
        {
            _solution.ApplySymetryOnSelected(0);
            graphCtrlSolution.Invalidate();
        }
        private void onReflectionY(object sender, EventArgs e)
        {
            _solution.ApplySymetryOnSelected(1);
            graphCtrlSolution.Invalidate();
        }
        private void onChkbInterlayerClicked(object sender, EventArgs e)
        {
            cbInterlayer.Enabled = chkbInterlayer.Checked;
            onInterlayerChanged(null, null);
            UpdateGrid();
        }
        #endregion

        #region Layer controls
        private void FillLayerControls()
        {
            try
            {
                cbLayerType.BoxProperties = _analysis.Content;
                // build layers and fill CCtrl
                foreach (LayerDesc layerDesc in _solution.LayerDescriptors)
                {
                    LayerSolver solver = new LayerSolver();
                    Layer2D layer = solver.BuildLayer(_analysis.ContentDimensions, _analysis.ContainerDimensions, layerDesc);
                    cbLayerType.Items.Add(layer);
                }
                if (cbLayerType.Items.Count > 0)
                    cbLayerType.SelectedIndex = 0;

                // fill combo cbInterlayer
                Document document = _document as Document;
                cbInterlayer.Initialize(document, this, null);
            }
            catch (Exception /*ex*/)
            {
            }
        }
        protected void UpdateControls()
        {
            try
            {
                int index = _solution.SelectedLayerIndex;
                bnSymmetryX.Enabled = (index != -1);
                bnSymetryY.Enabled = (index != -1);
                cbLayerType.Enabled = (index != -1);
                chkbInterlayer.Enabled = (index != -1) && (cbInterlayer.Items.Count > 0);

                gbLayer.Text = index != -1 ? string.Format("Selected layer : {0}", index) : "Double-click a layer";

                if (index != -1)
                {
                    tbClickLayer.Hide();
                    gbLayer.Show();

                    // get selected solution item
                    SolutionItem selItem = _solution.SelectedSolutionItem;
                    if (null != selItem)
                    {
                        // set current layer
                        cbLayerType.SelectedIndex = selItem.LayerIndex;
                        // set interlayer
                        chkbInterlayer.Checked = selItem.HasInterlayer;
                        onChkbInterlayerClicked(null, null);
                    }
                    // select combo box
                    int selIndex = 0;
                    foreach (object o in cbInterlayer.Items)
                    {
                        InterlayerProperties interlayerProp = o as InterlayerProperties;
                        if (interlayerProp == _solution.SelectedInterlayer)
                            break;
                        ++selIndex;
                    }
                    if (selIndex < cbInterlayer.Items.Count)
                        cbInterlayer.SelectedIndex = selIndex;
                }
                else
                {
                    gbLayer.Hide();
                    tbClickLayer.Show();
                }
            }
            catch (Exception /*ex*/)
            {
            }
        }
        #endregion
    }
}
