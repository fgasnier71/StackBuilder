#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisCylinderCase
        : FormNewAnalysis, IItemBaseFilter, IDrawingContainer
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisCylinderCase));
        #endregion

        #region Constructor
        public FormNewAnalysisCylinderCase(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {   get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbCylinders.Initialize(_document, this, null);
            cbCases.Initialize(_document, this, null);

            // initialize graphCtrlCylinder
            graphCtrlCylinder.DrawingContainer = this;

            // event handling
            uCtrlLayerList.LayerSelected += onLayerSelected;
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);

            if (null == AnalysisBase)
            {             
            }
            checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
        }
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            base.OnNext();
            try
            {
                LayerDesc layerDesc = null;
                _document.CreateNewAnalysisCylinderCase(
                    ItemName, ItemDescription
                    , SelectedCylinder, SelectedCase
                    , new List<InterlayerProperties>()
                    , BuildConstraintSet()
                    , layerDesc);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbCylinders)
            {
                return itemBase is CylinderProperties;
            }
            else if (ctrl == cbCases)
            {
                PackableBrick packable = itemBase as PackableBrick;
                return (null != packable) && (packable.IsCase);
            }
            return false;
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (graphCtrlCylinder == ctrl)
            {
                CylinderProperties cylProperties = cbCylinders.SelectedType as CylinderProperties;
                if (null == cylProperties) return;
                Cylinder cyl = new Cylinder(0, cylProperties);
                graphics.AddCylinder(cyl);
            }
        }
        #endregion

        #region Event handlers
        private void onLayerSelected(object sender, EventArgs e)
        {
            try
            {
                ILayer2D[] layers = uCtrlLayerList.Selected;
                UpdateStatus(layers.Length > 0 ? string.Empty : Resources.ID_SELECTATLEASTONELAYOUT);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onIputChanged(object sender, EventArgs e)
        {
            try
            {
                // get cylinder / case
                CylinderProperties cylinder = cbCylinders.SelectedType as CylinderProperties;
                BoxProperties caseProperties = cbCases.SelectedType as BoxProperties;
                if (null == cylinder || null == caseProperties)
                    return;
                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2DCyl> layers = solver.BuildLayers(
                    cylinder.RadiusOuter, cylinder.Height
                    , new Vector2D(caseProperties.InsideLength, caseProperties.InsideWidth)
                    , 0.0
                    , BuildConstraintSet()
                    , checkBoxBestLayersOnly.Checked
                    );
                uCtrlLayerList.Packable = cylinder;
                uCtrlLayerList.ContainerHeight = caseProperties.InsideHeight;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = LayerSolver.ConvertList(layers);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

        }
        #endregion

        #region Private properties
        private CylinderProperties SelectedCylinder
        {
            get { return cbCylinders.SelectedType as CylinderProperties; }
        }
        private BoxProperties SelectedCase
        {
            get { return cbCases.SelectedType as BoxProperties; }
        }
        #endregion

        #region Helpers
        private ConstraintSetCylinderCase BuildConstraintSet()
        {
            ConstraintSetCylinderCase constraintSet = new ConstraintSetCylinderCase(SelectedCase);
            return constraintSet;
        }
        #endregion
    }
}
