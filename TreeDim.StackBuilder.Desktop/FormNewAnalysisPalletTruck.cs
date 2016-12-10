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

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Graphics.Controls;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewAnalysisPalletTruck : FormNewAnalysis, IItemBaseFilter
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewAnalysisPalletTruck));
        #endregion

        #region Constructor
        public FormNewAnalysisPalletTruck(Document doc, Analysis analysis)
            : base(doc, analysis)
        {
            InitializeComponent();
        }
        #endregion

        #region FormNewBase override
        public override string ItemDefaultName
        { get { return Resources.ID_ANALYSIS; } }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            cbPallets.Initialize(_document, this, null != AnalysisBase ? AnalysisBase.Content : null);
            cbTrucks.Initialize(_document, this, null != AnalysisBase ? AnalysisBase.Container : null);

            // event handling
            uCtrlLayerList.LayerSelected += onLayerSelected;
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(400, 100);

            if (null == AnalysisBase)
            {
                tbName.Text = _document.GetValidNewAnalysisName(ItemDefaultName);
                tbDescription.Text = tbName.Text;

                checkBoxBestLayersOnly.Checked = Settings.Default.KeepBestSolutions;
            }
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        #endregion

        #region FormNewAnalysis override
        public override void OnNext()
        {
            base.OnNext();
            try
            {
                List<LayerDesc> layerDescs = new List<LayerDesc>();

                Solution.SetSolver(new LayerSolver());

                AnalysisBase = _document.CreateNewAnalysisPalletTruck(
                    ItemName, ItemDescription
                    , SelectedLoadedPallet, SelectedTruckProperties
                    , BuildConstraintSet()
                    , layerDescs);
                Close();
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
            if (ctrl == cbPallets)
            {
                return itemBase is LoadedPallet;
            }
            else if (ctrl == cbTrucks)
            {
                return itemBase is TruckProperties; 
            }
            return false;
        }
        #endregion

        #region Private properties
        private Packable SelectedLoadedPallet
        {
            get { return cbPallets.SelectedType as Packable; }
        }
        private TruckProperties SelectedTruckProperties
        {
            get { return cbTrucks.SelectedType as TruckProperties; }
        }
        #endregion

        #region Event handlers
        private void onInputChanged(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Helpers
        private ConstraintSetPalletTruck BuildConstraintSet()
        {
            ConstraintSetPalletTruck constraintSet = new ConstraintSetPalletTruck(SelectedTruckProperties);
            return constraintSet;
        }
        #endregion
    }
}
