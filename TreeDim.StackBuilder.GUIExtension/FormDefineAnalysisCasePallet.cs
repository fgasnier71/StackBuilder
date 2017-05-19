#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
using treeDiM.StackBuilder.GUIExtension.Properties;

using treeDiM.PLMPack.DBClient;
#endregion

namespace treeDiM.StackBuilder.GUIExtension
{
    public partial class FormDefineAnalysisCasePallet : Form, IDrawingContainer
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormDefineAnalysisCasePallet));
        private string _caseName;
        #endregion

        #region Constructor
        public FormDefineAnalysisCasePallet()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // initialize pallet combo
            cbPallet.Initialize();
            // initialize graphCtrlPallet
            graphCtrlPallet.DrawingContainer = this;

            uCtrlCaseOrientation.BProperties = BoxProperties;
            uCtrlCaseOrientation.AllowedOrientations = new bool[] { Settings.Default.AllowVerticalX, Settings.Default.AllowVerticalY, Settings.Default.AllowVerticalZ };
            uCtrlMaximumHeight.Value = Settings.Default.MaximumPalletHeight;
            uCtrlOptMaximumWeight.Value = new OptDouble(false, Settings.Default.MaximumPalletWeight);

            // event handling
            uCtrlLayerList.RefreshFinished += onLayerSelected;
            uCtrlLayerList.ButtonSizes = new Size(100, 100);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            Settings.Default.AllowVerticalX = uCtrlCaseOrientation.AllowedOrientations[0];
            Settings.Default.AllowVerticalY = uCtrlCaseOrientation.AllowedOrientations[1];
            Settings.Default.AllowVerticalZ = uCtrlCaseOrientation.AllowedOrientations[2];
            Settings.Default.MaximumPalletHeight = uCtrlMaximumHeight.Value;
            if (uCtrlOptMaximumWeight.Value.Activated)
                Settings.Default.MaximumPalletWeight = uCtrlOptMaximumWeight.Value.Value;

            Settings.Default.OverhangX = uCtrlOverhang.ValueX;
            Settings.Default.OverhangY = uCtrlOverhang.ValueY;
        }
        #endregion

        #region Implement IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            try
            {
                if (graphCtrlPallet == ctrl)
                {
                    using (ViewerPallet v = new ViewerPallet(cbPallet.SelectedPallet))
                        v.Draw(graphics, Transform3D.Identity);
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Public properties
        public double[] CaseDimensions
        {
            get { return new double[] { uCtrlDimensions.ValueX, uCtrlDimensions.ValueY, uCtrlDimensions.ValueZ }; }
            set
            {
                uCtrlDimensions.ValueX = value[0];
                uCtrlDimensions.ValueY = value[1];
                uCtrlDimensions.ValueZ = value[2];
            }
        }
        public string CaseName
        {
            set { _caseName = value; }
            get { return _caseName; }
        }
        #endregion

        #region Private properties
        private BoxProperties BoxProperties
        {
            get
            {
                BoxProperties bProperties = new BoxProperties(null, CaseDimensions);
                bProperties.ID.SetNameDesc(_caseName, _caseName);
                bProperties.SetColor(Color.Chocolate);
                bProperties.SetWeight( uCtrlMass.Value );
                return bProperties;
            }
        }
        private string DocumentName { get { return string.Format(""); } }
        private string DocumentDescription { get { return string.Format(""); } }

        #endregion

        #region Helpers
        private ConstraintSetCasePallet BuildConstraintSet()
        {
            // constraint set
            ConstraintSetCasePallet constraintSet = new ConstraintSetCasePallet();
            // overhang
            constraintSet.Overhang = new Vector2D(uCtrlOverhang.ValueX, uCtrlOverhang.ValueY);
            // orientations
            constraintSet.SetAllowedOrientations(uCtrlCaseOrientation.AllowedOrientations);
            // conditions
            constraintSet.SetMaxHeight(new OptDouble(true, uCtrlMaximumHeight.Value));
            constraintSet.OptMaxWeight = uCtrlOptMaximumWeight.Value;
            return constraintSet;
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

        private void onInputChanged(object sender, EventArgs e)
        {
            try
            {
                // get case / pallet
                Packable packable = BoxProperties;
                PalletProperties palletProperties = cbPallet.SelectedPallet;
                if (null == packable || null == palletProperties)
                    return;
                // compute
                ILayerSolver solver = new LayerSolver();
                List<Layer2D> layers = solver.BuildLayers(
                    packable.OuterDimensions
                    , new Vector2D(palletProperties.Length + 2.0*uCtrlOverhang.ValueX, palletProperties.Width + 2.0*uCtrlOverhang.ValueY)
                    , palletProperties.Height
                    , BuildConstraintSet()
                    , true
                    );
                // update control
                uCtrlLayerList.Packable = packable;
                uCtrlLayerList.ContainerHeight = uCtrlMaximumHeight.Value - palletProperties.Height;
                uCtrlLayerList.FirstLayerSelected = true;
                uCtrlLayerList.LayerList = LayerSolver.ConvertList(layers);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void onPalletChanged(object sender, EventArgs e)
        {
            graphCtrlPallet.Invalidate();
            onInputChanged(sender, e);
        }
        private void onNext(object sender, EventArgs e)
        {
            try
            {
                Close();

                List<LayerDesc> layerDescs = new List<LayerDesc>();
                foreach (ILayer2D layer2D in uCtrlLayerList.Selected)
                    layerDescs.Add(layer2D.LayerDescriptor);

                Packable packable = BoxProperties;
                PalletProperties palletProperties = cbPallet.SelectedPallet;
                if (null == packable || null == palletProperties) return;

                Document doc = new Document(DocumentName, DocumentDescription, WCFClientSingleton.Instance.User.Name, DateTime.Now, null);

                Solution.SetSolver(new LayerSolver());
                Analysis analysis = doc.CreateNewAnalysisCasePallet(
                    DocumentName, DocumentDescription
                    , packable, palletProperties, new List<InterlayerProperties>(), null, null, null
                    , BuildConstraintSet()
                    , layerDescs);
                FormBrowseSolution form = new FormBrowseSolution(doc, analysis);
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Status toolstrip updating
        public virtual void UpdateStatus(string message)
        {
            // status + message
            toolStripStatusLabelDef.ForeColor = string.IsNullOrEmpty(message) ? Color.Black : Color.Red;
            toolStripStatusLabelDef.Text = string.IsNullOrEmpty(message) ? Resources.ID_READY : message;
        }
        #endregion
    }
}
