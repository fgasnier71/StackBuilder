#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Graphics.Controls;

using treeDiM.StackBuilder.Desktop.Properties;
using System.Windows.Forms;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewPack : FormNewBase, IDrawingContainer, IItemBaseFilter
    {
        #region Data members
        private PackProperties PackProp { get; set; }
        public StrapperSet StrapperSet { get; } = new StrapperSet();
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewPack));
        #endregion

        #region Constructor
        public FormNewPack(Document doc, PackProperties packProperties)
            : base(doc, packProperties)
        {
            InitializeComponent();
            PackProp = packProperties;
            StrapperSet = null != PackProp ? PackProp.StrapperSet.Clone() : new StrapperSet();
        }
        #endregion

        #region FormNewBase overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Graphics3DControl
            graphCtrl.DrawingContainer = this;

            // list of packs
            cbInnerPackable.Initialize(_document, this, PackProp?.Content);

            // arrangement
            if (null != PackProp)
            {
                cbDir.SelectedIndex = (int)(PackProp.BoxOrientation);
                RevSolidLayout = PackProp.RevSolidLayout;
                Arrangement = PackProp.Arrangement;
                Wrapper = PackProp.Wrap;
                Tray = PackProp.Tray;
                uCtrlOuterDimensions.Checked = PackProp.HasForcedOuterDimensions;
                OuterDimensions = PackProp.OuterDimensions;
                Bulge = PackProp.Bulge;
            }
            else
            {
                cbDir.SelectedIndex = 5; // HalfAxis.HAxis.AXIS_Z_P
                RevSolidLayout = PackProperties.EnuRevSolidLayout.ALIGNED;
                Arrangement = new PackArrangement(3, 2, 1);
                Wrapper = new WrapperPolyethilene(0.1, 0.010, Color.LightGray) {};
                Tray = new PackTray(UnitsManager.ConvertLengthFrom(40, UnitsManager.UnitSystem.UNIT_METRIC1), 0.050, Color.Chocolate)
                {
                    UnitThickness = UnitsManager.ConvertLengthFrom(1.0, UnitsManager.UnitSystem.UNIT_METRIC1)
                };
            }
            // set StrapperSet
            ctrlStrapperSet.StrapperSet = StrapperSet;

            // disable Ok button
            UpdateStatus(string.Empty);
        }

        public override string ItemDefaultName
        { get { return Resources.ID_PACK; } }

        public override void UpdateStatus(string message)
        {
            if (!DesignMode)
            {
                double length = 0.0, width = 0.0, height = 0.0;
                PackProperties.GetDimensions(
                    SelectedPackable as BoxProperties,
                    BoxOrientation,
                    Arrangement,
                    ref length, ref width, ref height);
                if (uCtrlOuterDimensions.Checked && (uCtrlOuterDimensions.X < length || uCtrlOuterDimensions.Y < width || uCtrlOuterDimensions.Z < height))
                    message = Resources.ID_INVALIDOUTERDIMENSION;
            }
            base.UpdateStatus(message);
        }
        #endregion

        #region Implementation IItemBaseFilter
        public bool Accept(Control ctrl, ItemBase itemBase)
        {
            return (itemBase is PackableBrick || itemBase is RevSolidProperties)
                && itemBase != PackProp;
        }
        #endregion

        #region Public properties
        public List<BoxProperties> Boxes { set; get; } = new List<BoxProperties>();
        public Packable SelectedPackable => cbInnerPackable.SelectedType as Packable;
        public HalfAxis.HAxis BoxOrientation
        {
            get
            {
                HalfAxis.HAxis[] axes
                    = {
                           HalfAxis.HAxis.AXIS_X_N,
                           HalfAxis.HAxis.AXIS_X_P,
                           HalfAxis.HAxis.AXIS_Y_N,
                           HalfAxis.HAxis.AXIS_Y_P,
                           HalfAxis.HAxis.AXIS_Z_N,
                           HalfAxis.HAxis.AXIS_Z_P
                      };
                return axes[cbDir.SelectedIndex != -1 ? cbDir.SelectedIndex : 5];
            }
        }
        public PackProperties.EnuRevSolidLayout RevSolidLayout
        {
            get => (PackProperties.EnuRevSolidLayout)cbCylLayoutType.SelectedIndex;
            set => cbCylLayoutType.SelectedIndex = (int)value;
        }
        public PackArrangement Arrangement
        {
            get
            {
                return new PackArrangement(uCtrlLayout.NoX, uCtrlLayout.NoY, uCtrlLayout.NoZ);
            }
            set
            {
                uCtrlLayout.NoX = value.Length;
                uCtrlLayout.NoY = value.Width;
                uCtrlLayout.NoZ = value.Height;
            }
        }
        public PackWrapper Wrapper
        {
            get
            {
                PackWrapper wrapper = null;
                if (chkbWrapper.Checked)
                {
                    switch (cbType.SelectedIndex)
                    {
                        case 0:
                            wrapper = new WrapperPolyethilene(
                                uCtrlWrapperThickness.Value, uCtrlWrapperWeight.Value, cbWrapperColor.Color);
                            break;
                        case 1:
                            wrapper = new WrapperPaper(
                                uCtrlWrapperThickness.Value, uCtrlWrapperWeight.Value, cbWrapperColor.Color
                                );
                            break;
                        case 2:
                            {
                                WrapperCardboard wrapperCardboard = new WrapperCardboard(
                                    uCtrlWrapperThickness.Value, uCtrlWrapperWeight.Value, cbWrapperColor.Color
                                    );
                                wrapperCardboard.SetNoWalls(uCtrlWrapperWalls.NoX, uCtrlWrapperWalls.NoY, uCtrlWrapperWalls.NoZ);
                                wrapper = wrapperCardboard;
                            }
                            break;
                        default:
                            break;
                    }
                }
                return wrapper;
            }
            set
            {
                PackWrapper wrapper = value;
                chkbWrapper.Checked = (null != wrapper);
                if (null != wrapper)
                {
                    cbType.SelectedIndex = (int)wrapper.Type;
                    OnWrapperTypeChanged(this, null);

                    uCtrlWrapperThickness.Value = wrapper.UnitThickness;
                    uCtrlWrapperWeight.Value = wrapper.Weight;
                    cbWrapperColor.Color = wrapper.Color;

                    switch (wrapper.Type)
                    {
                        case PackWrapper.WType.WT_POLYETHILENE:
                            break;
                        case PackWrapper.WType.WT_PAPER:
                            break;
                        case PackWrapper.WType.WT_CARDBOARD:
                            {
                                WrapperCardboard wrapperCardboard = wrapper as WrapperCardboard;
                                uCtrlWrapperWalls.NoX = wrapperCardboard.Wall(0);
                                uCtrlWrapperWalls.NoY = wrapperCardboard.Wall(1);
                                uCtrlWrapperWalls.NoZ = wrapperCardboard.Wall(2);
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public PackTray Tray
        {
            get
            {
                if (chkbTray.Checked)
                {
                    var packTray = new PackTray(TrayHeight, TrayWeight, TrayColor) { UnitThickness = uCtrlTrayUnitThickness.Value };
                    packTray.SetNoWalls(new int[] { uCtrlTrayWalls.NoX, uCtrlTrayWalls.NoY, uCtrlTrayWalls.NoZ });
                    return packTray;
                }
                else
                    return null;
            }
            set
            {
                var packTray = value;
                chkbTray.Checked = (null != packTray);
                EnableDisableTray();
                if (null != packTray)
                {
                    TrayHeight = value.Height;
                    TrayWeight = value.Weight;
                    TrayColor = value.Color;
                    uCtrlTrayWalls.NoX = packTray.Wall(0);
                    uCtrlTrayWalls.NoY = packTray.Wall(1);
                    uCtrlTrayWalls.NoZ = packTray.Wall(2);
                }
            }
        }
        private double TrayHeight
        {
            get => uCtrlTrayHeight.Value;
            set => uCtrlTrayHeight.Value = value;
        }
        private double TrayWeight
        {
            get => uCtrlTrayWeight.Value;
            set => uCtrlTrayWeight.Value = value;
        }
        private Color TrayColor
        {
            get => cbTrayColor.Color;
            set => cbTrayColor.Color = value;
        }

        public bool HasForcedOuterDimensions
        { get { return uCtrlOuterDimensions.Checked; } }
        public Vector3D OuterDimensions
        {
            get
            {
                return new Vector3D(
                    uCtrlOuterDimensions.X,
                    uCtrlOuterDimensions.Y,
                    uCtrlOuterDimensions.Z);
            }
            set
            {
                uCtrlOuterDimensions.X = value.X;
                uCtrlOuterDimensions.Y = value.Y;
                uCtrlOuterDimensions.Z = value.Z;
            }
        }
        public Vector3D Bulge
        {
            get => uCtrlOptBulge.Checked ? uCtrlOptBulge.Value : Vector3D.Zero;
            set
            {
                uCtrlOptBulge.Checked = value.GetLength() > 0;
                uCtrlOptBulge.Value = value;
            }
        }
        #endregion

        #region Enable/disable
        private void EnableDisableWrapper()
        {
            bool enable = chkbWrapper.Checked;
            cbType.Enabled = enable;
            lbWrapperColor.Enabled = enable;
            cbWrapperColor.Enabled = enable;
            uCtrlWrapperWeight.Enabled = enable;
            uCtrlWrapperWalls.Enabled = enable;
            uCtrlWrapperThickness.Enabled = enable;
        }
        private void EnableDisableTray()
        {
            bool enable = chkbTray.Enabled;
            cbTrayColor.Enabled = enable;
            uCtrlTrayHeight.Enabled = enable;
            uCtrlTrayWeight.Enabled = enable;
            uCtrlTrayWalls.Enabled = enable;
            uCtrlTrayUnitThickness.Enabled = enable;
        }
        #endregion

        #region Event handlers
        private void OnWrapperChecked(object sender, EventArgs e) { EnableDisableWrapper(); graphCtrl.Invalidate(); }
        private void OnTrayChecked(object sender, EventArgs e) { EnableDisableTray(); graphCtrl.Invalidate(); }
        private void OnContentChanged(object sender, EventArgs e)
        {
            bool isBox = SelectedPackable is PackableBrick;
            lbDir.Visible = isBox;
            cbDir.Visible = isBox;
            lbCylLayoutType.Visible = !isBox;
            cbCylLayoutType.Visible = !isBox;

            OnPackChanged(sender, e);
        }
        private void OnPackChanged(object sender, EventArgs e)
        {
            try
            {
                if (sender != uCtrlOuterDimensions && !this.DesignMode)
                {
                    double length = 0.0, width = 0.0, height = 0.0;
                    if (SelectedPackable is BoxProperties boxProperties)
                        PackProperties.GetDimensions(boxProperties, BoxOrientation, Arrangement, ref length, ref width, ref height);
                    else if (SelectedPackable is RevSolidProperties revSolidProperties)
                        PackProperties.GetDimensions(revSolidProperties, RevSolidLayout, Arrangement, ref length, ref width, ref height);
                    uCtrlOuterDimensions.X = length;
                    uCtrlOuterDimensions.Y = width;
                    uCtrlOuterDimensions.Z = height;
                }
                graphCtrl.Invalidate();
                UpdateStatus(string.Empty);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void OnWrapperTypeChanged(object sender, EventArgs e)
        {
            uCtrlWrapperWalls.Visible = cbType.SelectedIndex == 2;
            graphCtrl.Invalidate();
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            StrapperSet.SetDimension(OuterDimensions);
            // build pack
            PackProperties packProperties = new PackProperties(
                    null, SelectedPackable, Arrangement, BoxOrientation, RevSolidLayout, Wrapper, Tray)
                {
                    StrapperSet = StrapperSet
                };
            if (uCtrlOuterDimensions.Checked)
                packProperties.ForceOuterDimensions(
                    new Vector3D(uCtrlOuterDimensions.X, uCtrlOuterDimensions.Y, uCtrlOuterDimensions.Z));
            Pack pack = new Pack(0, packProperties)
            {
                ForceTransparency = true
            };
            graphics.AddBox(pack);
            graphics.AddDimensions(new DimensionCube(Vector3D.Zero, pack.Length, pack.Width, pack.Height, Color.Black, true));
            if (null != packProperties.Wrap && packProperties.Wrap.Transparent)
                graphics.AddDimensions(
                    new DimensionCube(
                        packProperties.InnerOffset
                        , packProperties.InnerLength, packProperties.InnerWidth, packProperties.InnerHeight
                        , Color.Red, false));
        }

        #endregion
    }
}
