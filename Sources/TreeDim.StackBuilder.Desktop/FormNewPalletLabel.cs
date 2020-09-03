#region Using directives
using System;
using System.Drawing;
using System.Windows.Forms;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Desktop.Properties;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewPalletLabel : FormNewBase, IDrawingContainer
    {
        #region Constructor
        public FormNewPalletLabel(Document doc, PalletLabelProperties item)
            : base(doc, item)
        {
            InitializeComponent();

            UpdateStatus(string.Empty);
            // units
            UnitsManager.AdaptUnitLabels(this);
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName => Resources.ID_PALLETLABEL;
        #endregion

        #region Form overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Graphics3DControl
            graphCtrl.DrawingContainer = this;

            if (null != Item)
            {
                PalletLabelProperties palletLabel = Item as PalletLabelProperties;
                Color = palletLabel.Color;
                Dimensions = palletLabel.Dimensions;
                Weight = palletLabel.Weight;
                Bitmap = palletLabel.Bitmap;
            }
            else
            {
                Color = Color.White;
                Dimensions = new Vector2D(
                    UnitsManager.ConvertLengthFrom(210, UnitsManager.UnitSystem.UNIT_METRIC1),
                    UnitsManager.ConvertLengthFrom(297, UnitsManager.UnitSystem.UNIT_METRIC1));
                Weight = 0.0;
                Bitmap = Resources.PalletLabelDefault;
            }
        }
        #endregion

        #region Public properties
        public double Weight
        {
            get => uCtrlWeight.Value;
            set => uCtrlWeight.Value = value;
        }
        public Bitmap Bitmap { get; set; }
        public Vector2D Dimensions
        {
            get => uCtrlDimensions.Value;
            set => uCtrlDimensions.Value = value;
        }
        public Color Color
        {
            get => cbColor.Color;
            set => cbColor.Color = value;
        }
        #endregion
        #region Event handler
        private void OnLoadImage(object sender, EventArgs e)
        {
            try
            {
                openFileDialog.FileName = string.Empty;
                if (DialogResult.OK == openFileDialog.ShowDialog())
                {
                    Bitmap = new Bitmap(openFileDialog.FileName);
                }
                graphCtrl.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnRemoveImage(object sender, EventArgs e)
        {
            Bitmap = null;
            graphCtrl.Invalidate();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            // build label
            var labelProperties = new PalletLabelProperties(
                null,
                ItemName, ItemDescription,
                Dimensions, Weight,
                Color, Bitmap
                );
            PalletLabel label = new PalletLabel(0, labelProperties, new BoxPosition(Vector3D.Zero, HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Z_P));
            graphics.AddLabel(label);
            graphics.AddDimensions(
                new DimensionCube(
                    Vector3D.Zero,
                    labelProperties.Dimensions.X, 0.0, labelProperties.Dimensions.Y,
                    Color.Red, false)
                );
        }
        private void OnColorChanged(object sender, EventArgs e)
        {
            graphCtrl.Invalidate();
        }
        #endregion

        #region Send to database
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewPalletLabel));

        #endregion


    }
}
