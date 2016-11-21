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
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisBoxCase : FormNewAnalysis, IItemBaseFilter
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisBoxCase));
        private AnalysisBoxCase _analysis;
        #endregion

        #region Constructor
        public FormNewAnalysisBoxCase(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        { get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbBoxes.Initialize(_document, this, null);
            cbCases.Initialize(_document, this, null);

            // event handling
            uCtrlLayerList.LayerSelected += onLayerSelected;
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);

            if (null == _analysis)
            {
                uCtrlCaseOrientation.AllowedOrientations = new bool[]
                { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };

                checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Settings.Default.AllowVerticalX = uCtrlCaseOrientation.AllowedOrientations[0];
            Settings.Default.AllowVerticalY = uCtrlCaseOrientation.AllowedOrientations[1];
            Settings.Default.AllowVerticalZ = uCtrlCaseOrientation.AllowedOrientations[2];

            Settings.Default.KeepBestSolutions = checkBoxBestLayersOnly.Checked;
        }
        #endregion

        #region IItemBaseFilter implementation
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            if (ctrl == cbBoxes)
            {
                Packable packable = itemBase as Packable;
                return null != packable;
            }
            else if (ctrl == cbCases)
            {
                Packable packable = itemBase as Packable;
                return null != packable && packable.IsCase && (packable != SelectedBoxProperties);
            }
            return false;
        }
        #endregion

        #region Private properties
        private Packable SelectedBoxProperties
        {
            get { return cbBoxes.SelectedType as Packable; }
        }
        private BoxProperties SelectedCaseProperties
        {
            get { return cbCases.SelectedType as BoxProperties; }
        }
        #endregion

        #region Event handlers
        private void onBoxChanged(object sender, EventArgs e)
        {
            cbCases.Initialize(_document, this, null);
            onInputChanged(sender, e);
        }

        private void onInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get box / case
                PackableBrick packable = cbBoxes.SelectedType as PackableBrick;
                BoxProperties caseProperties = cbCases.SelectedType as BoxProperties;
                if (null == packable || null == caseProperties)
                    return;

                // update orientation control
                uCtrlCaseOrientation.BProperties = packable;

                // compute
                LayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(caseProperties.InsideLength, caseProperties.InsideWidth)
                    , 0.0 /* offsetZ */
                    , BuildContraintSet()
                    , checkBoxBestLayersOnly.Checked
                    );
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = caseProperties.InsideHeight;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = layers;
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        protected void onLayerSelected(object sender, EventArgs e)
        {
            try
            {
                Layer2D[] layers = uCtrlLayerList.Selected;
                UpdateStatus(layers.Length > 0 ? string.Empty : Resources.ID_SELECTATLEASTONELAYOUT);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }

        public override void OnNext()
        {
            base.OnNext();
            try
            {
                List<LayerDesc> layerDescs = new List<LayerDesc>();
                foreach (Layer2D layer2D in uCtrlLayerList.Selected)
                    layerDescs.Add(layer2D.LayerDescriptor);

                Solution.SetSolver(new LayerSolver());

                _analysis = _document.CreateNewAnalysisBoxCase(
                    ItemName, ItemDescription
                    , SelectedBoxProperties, SelectedCaseProperties
                    , new List<InterlayerProperties>()
                    , BuildContraintSet()
                    , layerDescs
                    );

                Close();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Helpers
        private ConstraintSetBoxCase BuildContraintSet()
        { 
            // constraint set
            ConstraintSetBoxCase constraintSet = new ConstraintSetBoxCase(SelectedCaseProperties);
            constraintSet.SetAllowedOrientations(uCtrlCaseOrientation.AllowedOrientations);
            return constraintSet;        
        }
        #endregion
    }
}
