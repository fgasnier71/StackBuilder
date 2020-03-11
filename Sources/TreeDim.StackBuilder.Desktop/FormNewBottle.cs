#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

using log4net;
using Sharp3D.Math.Core;

using treeDiM.Basics;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;

using treeDiM.PLMPack.DBClient;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewBottle : FormNewBase, IDrawingContainer
    {
        #region Constructor
        public FormNewBottle(Document document, BottleProperties bottle)
            : base(document, bottle)
        {
            InitializeComponent();
            cbBottleType.SelectedIndex = 0;

            if (null == bottle)
            {
                Initialize(0);
                Weight = 1.0;
                ColorBottle = Color.DeepSkyBlue;
            }
            else
            {
                Profile = bottle.Profile;
                Weight = bottle.Weight;
                ColorBottle = bottle.Color;
                FillGrid();
            }
        }
        #endregion

        #region FormNewBase overrides
        public override string ItemDefaultName => Resources.ID_BOTTLE;
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            graphCtrl.DrawingContainer = this;
            // enable / disable
            bnSendToDB.Enabled = false;
            // disable Ok button
            UpdateStatus(string.Empty);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }
        public override void UpdateStatus(string message)
        {
            if (!Program.IsSubscribed) message = Resources.ID_PREMIUMFEATURE;
            base.UpdateStatus(message);
        }
        #endregion

        #region Specific methods
        protected void Initialize(int index, bool showDialog = false)
        {
            Profile.Clear();
            double[,] v;

            switch (index)
            {
                case 0: // Wine 1 
                    v = new double[,]
                    {
                        { 0.0, 69.0 },
                        { 3.0, 71.0 },
                        { 6.0, 74.0 },
                        { 180.0, 74.0},
                        { 190.0, 73.0},
                        { 200.0, 67.0},
                        { 205, 59.0},
                        { 210.0, 52.0},
                        { 215.0, 37.0},
                        { 217.0, 34.0},
                        { 220.0, 32.0},
                        { 230.0, 30.5},
                        { 285.0, 27.6},
                        { 286.0, 29.6},
                        { 295.0, 29.6},
                        { 300.0, 27.3},
                        { 301.0, 25.0}
                    };
                    break;
                case 1: // Wine 2
                    v = new double[,]
                    {
                        { 0.0, 65.0 },
                        { 2.0, 68.0 },
                        { 5.0, 72.0 },
                        { 10.0, 75.0 },
                        { 120.0, 75.0},
                        { 135.0, 74.0},
                        { 160.0, 69.0},
                        { 185.0, 60.0},
                        { 210.0, 51.0},
                        { 250.0, 36.0},
                        { 314.0, 28.0},
                        { 315.0, 30.0},
                        { 325.0, 30.0},
                        { 326.0, 28.0},
                        { 329.0, 28.0},
                        { 330.0, 27.0}
                    };
                    break;
                case 2: // Milk
                    v = new double[,]
                    {
                        { 0.0, 70.0 },
                        { 2.0, 78.0 },
                        { 10.0, 84.0 },
                        { 20.0, 90.0 },
                        { 140.0, 90.0 },
                        { 160.0, 85.0 },
                        { 190.0, 60.0 },
                        { 220.0, 47.0 },
                        { 221.0, 48.0 },
                        { 240.0, 48.0 },
                        { 243.0, 43.0 }
                    };
                    break;
                case 3: // Water
                    v = new double[,]
                    {
                        { 0.0, 70.0 },
                        { 10.0, 76.0 },
                        { 40.0, 84.0 },
                        { 120.0, 84.0 },
                        { 150.0, 77.0 },
                        { 170.0, 63.0 },
                        { 195.0, 70.0 },
                        { 220.0, 83.0 },
                        { 241.0, 72.0 },
                        { 260.0, 49.0 },
                        { 272.0, 27.0 },
                        { 280.0, 27.0 },
                        { 281.0, 30.0 },
                        { 294.0, 30.0 },
                        { 295.0, 29.0 }
                    };
                    break;
                case 4: // coca-cola can  
                    v = new double[,]
                    {
                        { 0.0, 50.0 },
                        { 7.0, 64.0 },
                        { 100.0, 64.0 },
                        { 110.0, 53.0 },
                        { 111.0, 53.0 },
                        { 112.0, 54.0 },
                        { 115.0, 54.0 }
                    };
                    break;
                default:
                    v = new double[,]
                    {
                        { 0.0, 69.0 },
                        { 3.0, 71.0 },
                        { 6.0, 74.0 },
                        { 180.0, 74.0},
                        { 190.0, 73.0},
                        { 200.0, 67.0},
                        { 205, 59.0},
                        { 210.0, 52.0},
                        { 215.0, 37.0},
                        { 217.0, 34.0},
                        { 220.0, 32.0},
                        { 230.0, 30.5},
                        { 285.0, 27.6},
                        { 286.0, 29.6},
                        { 295.0, 29.6},
                        { 300.0, 27.3},
                        { 301.0, 25.0}
                    };
                    break;
            }

            var profile = new List<Vector2D>();
            for (int i = 0; i < v.Length / 2; ++i)
                profile.Add(
                    new Vector2D(
                        UnitsManager.ConvertLengthFrom(v[i, 0], UnitsManager.UnitSystem.UNIT_METRIC1),
                        UnitsManager.ConvertLengthFrom(v[i, 1], UnitsManager.UnitSystem.UNIT_METRIC1)
                        )
                    );

            // get maxDiameter and maxHeight to apply
            double maxDiameterInit = profile.Max(p => p.Y);
            double maxHeightInit = profile.Max(p => p.X);
            double maxDiameter = maxDiameterInit;
            double maxHeight = maxHeightInit;
            if (showDialog)
            {
                using (var form = new FormBottleInitialize() { MaxDiameter = maxDiameter, MaxHeight = maxHeight })
                {
                    if (DialogResult.OK == form.ShowDialog())
                    {
                        maxDiameter = form.MaxDiameter;
                        maxHeight = form.MaxHeight;
                    }
                }
            }

            Profile.Clear();
            foreach (var vec in profile)
                Profile.Add(new Vector2D(vec.X * maxHeight / maxHeightInit, vec.Y * maxDiameter / maxDiameterInit));

            FillGrid();
        }
        #endregion

        #region Grid
        private void FillGrid()
        {
            // clear grid
            gridProfile.Rows.Clear();
            // border
            gridProfile.BorderStyle = BorderStyle.FixedSingle;
            gridProfile.ColumnsCount = 2;
            // *** IViews
            // caption header
            DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.SteelBlue,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader
            {
                Background = veHeaderCaption,
                ForeColor = Color.Black,
                Font = new Font("Arial", GridFontSize + 2, FontStyle.Bold),
                TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter
            };
            // viewRowHeader
            DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader
            {
                Background = backHeader,
                ForeColor = Color.Black,
                Font = new Font("Arial", GridFontSize, FontStyle.Regular)
            };
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***

            int iRow = -1;
            // ### sol items : begin
            gridProfile.Rows.Insert(++iRow);
            gridProfile[iRow, 0] = new SourceGrid.Cells.RowHeader($"{Resources.ID_HEIGHT} ({UnitsManager.LengthUnitString})") { View = captionHeader };
            gridProfile[iRow, 1] = new SourceGrid.Cells.RowHeader($"{Resources.ID_DIAMETER} ({UnitsManager.LengthUnitString})") { View = captionHeader };

            foreach (var item in Profile)
            {
                gridProfile.Rows.Insert(++iRow);
                gridProfile[iRow, 0] = new SourceGrid.Cells.Cell($"{item.X}");
                gridProfile[iRow, 1] = new SourceGrid.Cells.Cell($"{item.Y}");
            }

            gridProfile.AutoSizeCells();
            gridProfile.AutoStretchColumnsToFitWidth = true;
            gridProfile.Invalidate();
        }
        private void SaveGrid()
        { 
        }
        #endregion

        #region Public properties
        public Color ColorBottle
        {
            get => cbColorTop.Color;
            set => cbColorTop.Color = value;
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
        public double Diameter => Profile.Max(p => p.Y);
        public double Radius => 0.5 * Diameter;
        public double CylinderHeight => Profile.Max(p => p.X);
        public List<Vector2D> Profile { get; } = new List<Vector2D>();
        public double MaxDiameter => Profile.Max(p => p.Y);
        public double MaxHeight => Profile.Max(p => p.X);
        protected int GridFontSize => Settings.Default.GridFontSize;
        #endregion

        #region Draw bottle
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            Bottle bottle = new Bottle(0, Profile, ColorBottle);
            graphics.AddCylinder(bottle);
            graphics.AddDimensions(new DimensionCube(
                new Vector3D(-Radius, -Radius, 0.0)
                , Diameter, Diameter, CylinderHeight,
                Color.Black, false)
                );
        }
        #endregion

        #region Send to database
        private void OnSendToDatabase(object sender, EventArgs e)
        {
            try
            {
                FormSetItemName form = new FormSetItemName()
                {
                    ItemName = ItemName
                };
                if (DialogResult.OK == form.ShowDialog())
                {
                    using (WCFClient wcfClient = new WCFClient())
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Update handling
        #endregion

        #region Events
        private void OnInitialize(object sender, EventArgs e)
        {
            Initialize(cbBottleType.SelectedIndex, true);
            graphCtrl.Invalidate();
        }
        private void OnRowInsert(object sender, EventArgs e)
        {
            OnInputChanged(sender, e);
        }
        private void OnRowRemove(object sender, EventArgs e)
        {
            OnInputChanged(sender, e);
        }
        private void OnInputChanged(object sender, EventArgs e)
        {
            lbHeightValue.Text = $": {MaxHeight} {UnitsManager.LengthUnitString}";
            lbMaxDiameterValue.Text = $": {MaxDiameter} {UnitsManager.LengthUnitString}";
            graphCtrl.Invalidate();
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(FormNewBottle));
        #endregion
    }
}
