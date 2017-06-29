#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.Reporting;
using treeDiM.StackBuilder.GUIExtension.Properties;

using treeDiM.PLMPack.DBClient;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    internal partial class FormDefineAnalysisBundleCase : Form
    {
        #region Data members
        private static readonly ILog _log = LogManager.GetLogger(typeof(FormDefineAnalysisBundleCase));
        #endregion

        #region Constructor
        public FormDefineAnalysisBundleCase()
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
        {   get; set; }
        private string DocumentName { get { return BundleName; } }
        private string DocumentDescription
        {
            get
            {
                return string.Format("{0} / {1}x{2}x{3}",
                    BundleName, CaseInsideLength, CaseInsideWidth, CaseInsideHeight);
            }
        }
        public double BundleLength
        {
            get { return uCtrlFlatDimensions.ValueX; }
            set { uCtrlFlatDimensions.ValueX = value; }
        }
        public double BundleWidth
        {
            get { return uCtrlFlatDimensions.ValueY; }
            set { uCtrlFlatDimensions.ValueY = value; }
        }
        public double FlatThickness
        {
            get { return uCtrlFlatDimensions.ValueZ; }
            set { uCtrlFlatDimensions.ValueZ = value; }
        }
        public double FlatWeight
        {
            get { return uCtrlFlatWeight.Value; }
            set { uCtrlFlatWeight.Value = value; }
        }
        public int NoFlats
        {
            get { return (int)nudNumberOfFlats.Value; }
            set { nudNumberOfFlats.Value = (decimal)value; }
        }
        public double CaseInsideLength
        {
            get { return uCtrlCaseDimensions.ValueX; }
            set { uCtrlCaseDimensions.ValueX = value; }
        }
        public double CaseInsideWidth
        {
            get { return uCtrlCaseDimensions.ValueY; }
            set { uCtrlCaseDimensions.ValueY = value; }
        }
        public double CaseInsideHeight
        {
            get { return uCtrlCaseDimensions.ValueZ; }
            set { uCtrlCaseDimensions.ValueZ = value; }
        }
        public double CaseWeight
        {
            get { return uCtrlCaseWeight.Value; }
            set { uCtrlCaseWeight.Value = value; }
        }
        private BundleProperties BundleProp
        {
            get
            {
                return new BundleProperties(null, BundleName, BundleName
                    , BundleLength, BundleWidth, FlatThickness
                    , FlatWeight, NoFlats, Color.Gray);
            }
        }
        public string CaseName
        {
            get
            {
                return string.Format(
                    "{0} {1}x{2}x{3}"
                    , Resources.ID_CASE
                    , CaseInsideLength, CaseInsideWidth, CaseInsideHeight
                ); 
            }
        }
        #endregion

        #region Event handlers
        private void onInputValueChanged(object sender, EventArgs args)
        {
            try
            {
                Packable packable = BundleProp;
                // compute
                ILayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(CaseInsideLength, CaseInsideWidth)
                    , 0.0
                    , BuildConstraintSet()
                    , true
                    );
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = CaseInsideHeight;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = LayerSolver.ConvertList(layers);

            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onNext(object sender, EventArgs e)
        {
            try
            {
                Close();

                List<LayerDesc> layerDescs = new List<LayerDesc>();
                foreach (ILayer2D layer2D in uCtrlLayerList.Selected)
                    layerDescs.Add(layer2D.LayerDescriptor);


                Document doc = new Document(DocumentName, DocumentDescription, WCFClientSingleton.Instance.User.Name, DateTime.Now, null);

                Packable packable = doc.CreateNewPackable(BundleProp);
                BoxProperties caseProperties = doc.CreateNewCase(
                    CaseName, CaseName
                    , CaseInsideLength, CaseInsideWidth, CaseInsideHeight
                    , CaseInsideLength, CaseInsideWidth, CaseInsideHeight
                    , CaseWeight
                    , new Color[] {Color.Chocolate, Color.Chocolate, Color.Chocolate, Color.Chocolate, Color.Chocolate, Color.Chocolate }
                    );

                if (null == packable || null == caseProperties) return;

                Solution.SetSolver(new LayerSolver());
                Analysis analysis = doc.CreateNewAnalysisBoxCase(
                    DocumentName, DocumentDescription
                    , packable, caseProperties
                    , new List<InterlayerProperties>()
                    , BuildConstraintSet()
                    , layerDescs);
                FormBrowseSolution form = new FormBrowseSolution(doc, analysis);
                if (DialogResult.OK == form.ShowDialog()) { }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Helpers
        private ConstraintSetBoxCase BuildConstraintSet()
        {
            ConstraintSetBoxCase constraintSet = new ConstraintSetBoxCase(
                new BoxProperties(null
                    , CaseInsideLength, CaseInsideWidth, CaseInsideHeight
                    , CaseInsideLength, CaseInsideWidth, CaseInsideHeight));
            constraintSet.SetAllowedOrientations( new bool[] { false, false, true } );
            return constraintSet;
        }
        #endregion
    }
}
