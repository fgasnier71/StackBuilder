#region Using directives
using System;
using System.Drawing;

using log4net;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;


using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
using Sharp3D.Math.Core;
using System.Linq;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewBag
        : FormNewBase, IDrawingContainer
    {
        #region Constructor
        public FormNewBag(Document document, BagProperties bag)
            : base(document, bag)
        {
            InitializeComponent();
            if (DesignMode) return;
            // properties
            if (null != bag)
            {
                uCtrlOuterDimensions.ValueX = bag.Length;
                uCtrlOuterDimensions.ValueY = bag.Width;
                uCtrlOuterDimensions.ValueZ = bag.Height;
                uCtrlRadius.Value = bag.Radius;
                uCtrlWeight.Value = bag.Weight;
                uCtrlNetWeight.Value = bag.NetWeight;
                cbColor.Color = bag.ColorFill;
            }
            else
            {
                uCtrlOuterDimensions.ValueX = UnitsManager.ConvertLengthFrom(400.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                uCtrlOuterDimensions.ValueY = UnitsManager.ConvertLengthFrom(300.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                uCtrlOuterDimensions.ValueZ = UnitsManager.ConvertLengthFrom(200.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                uCtrlRadius.Value = UnitsManager.ConvertLengthFrom(100.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                uCtrlWeight.Value = UnitsManager.ConvertMassFrom(1.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                uCtrlNetWeight.Value = OptDouble.Zero;
                cbColor.Color = Color.Gray;
            }
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion
        #region FormNewBase override
        public override string ItemDefaultName => Resources.ID_BAG;
        #endregion
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.DrawingContainer = this;
            // enable / disable
            bnSendToDB.Enabled = WCFClient.IsConnected;
            // disable Ok button
            UpdateStatus(string.Empty);
        }
        #endregion
        #region Public properties
        public Vector3D OuterDimensions
        {
            get => uCtrlOuterDimensions.Value;
            set => uCtrlOuterDimensions.Value = value;
        }
        public double RoundingRadius
        {
            get => uCtrlRadius.Value;
            set => uCtrlRadius.Value = value;
        }
        public double Weight
        {
            get => uCtrlWeight.Value;
            set => uCtrlWeight.Value = value; 
        }
        public OptDouble NetWeight
        {
            get => uCtrlNetWeight.Value; 
            set => uCtrlNetWeight.Value = value; 
        }
        public Color ColorFill
        {
            get => cbColor.Color;
            set => cbColor.Color = value;
        }
        public double MinDimension => new double[]{ OuterDimensions.X, OuterDimensions.Y, OuterDimensions.Z }.Min();
        #endregion
        #region IDrawingContrainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            var bagProperties = new BagProperties(null, ItemName, ItemDescription, OuterDimensions, RoundingRadius)
            {
                ColorFill = ColorFill
            };
            var bag = new BoxRounded(0, bagProperties, BoxPosition.Zero);
            graphics.AddBox(bag);
        }
        #endregion
        #region Event handlers
        private void OnValueChanged(object sender, System.EventArgs args)
        {
            // update ok button status
            UpdateStatus(string.Empty);
            // update drawing
            graphCtrl.Invalidate();
        }
        public override void UpdateStatus(string message)
        {
            if (RoundingRadius > MinDimension)
                message = Resources.ID_INVALIDROUNDINGRADIUS;
            else if (Weight < 1.0E-06)
                message = Resources.ID_INVALIDMASS;
            base.UpdateStatus(message);
        }
        private void OnSaveToDatabase(object sender, System.EventArgs e)
        {

        }
        #endregion
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBag));
        #endregion
    }
}
