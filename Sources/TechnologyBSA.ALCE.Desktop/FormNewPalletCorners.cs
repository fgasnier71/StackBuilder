#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using log4net;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewPalletCorners : FormNewBase, IDrawingContainer
    {
        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPalletCorners));
        #endregion

        #region Constructor
        public FormNewPalletCorners(Document doc, PalletCornerProperties palletCorners)
            : base(doc, palletCorners)
        {
            InitializeComponent();

            if (null != palletCorners)
            {
                CornerLength = palletCorners.Length;
                CornerWidth = palletCorners.Width;
                CornerThickness = palletCorners.Thickness;
                CornerWeight = palletCorners.Weight;
                CornerColor = palletCorners.Color;
            }
            else
            { 
                CornerLength = UnitsManager.ConvertLengthFrom(1200.0, UnitsManager.UnitSystem.UNIT_METRIC1);;
                CornerWidth = UnitsManager.ConvertLengthFrom(40.0, UnitsManager.UnitSystem.UNIT_METRIC1);;
                CornerThickness = UnitsManager.ConvertLengthFrom(5.0, UnitsManager.UnitSystem.UNIT_METRIC1);
                CornerWeight = UnitsManager.ConvertMassFrom(0.050, UnitsManager.UnitSystem.UNIT_METRIC1);
                CornerColor = Color.Khaki;
            }
            UpdateStatus(string.Empty);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName
        {
            get { return Resources.ID_PALLETCORNERS; }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.DrawingContainer = this;
        }
        public override void UpdateStatus(string message)
        {
            if (CornerThickness >= CornerWidth)
                message = Resources.ID_INVALIDTHICKNESSWIDTHPAIR;

            base.UpdateStatus(message);
        }
        #endregion

        #region Public properties
        public double CornerLength
        {
            get { return uCtrlLength.Value; }
            set { uCtrlLength.Value = value; }
        }
        public double CornerWidth
        {
            get { return uCtrlWidth.Value; }
            set { uCtrlWidth.Value = value; }
        }
        public double CornerThickness
        {
            get { return uCtrlThickness.Value; }
            set { uCtrlThickness.Value = value; }
        }
        public double CornerWeight
        {
            get { return uCtrlWeight.Value; }
            set { uCtrlWeight.Value = value; }
        }
        public Color CornerColor
        {
            get { return cbColorCorners.Color; }
            set { cbColorCorners.Color = value; }
        }
        #endregion

        #region Handlers
        private void OnValueChanged(object sender, EventArgs e)
        {
            UpdateStatus(string.Empty);
            graphCtrl.Invalidate();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            if (CornerLength > 0 && CornerWidth > 0 && CornerThickness > 0
                && CornerThickness < CornerWidth)
            {
                // draw
                PalletCornerProperties palletCornerProperties = new PalletCornerProperties(
                    null, ItemName, ItemDescription, CornerLength, CornerWidth, CornerThickness,
                    CornerWeight, CornerColor);

                Corner palletCorner = new Corner(0, palletCornerProperties);
                palletCorner.Draw(graphics);
                graphics.AddDimensions(new DimensionCube(CornerWidth, CornerWidth, CornerLength));
            }
        }
        #endregion
    }
}
