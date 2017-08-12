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

using treeDiM.PLMPack.DBClient;
using treeDiM.PLMPack.DBClient.PLMPackSR;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormShowDatabase : Form, IDrawingContainer
    {
        #region Constructor
        public FormShowDatabase()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
 	        base.OnLoad(e);
            graphCtrl.DrawingContainer = this;

            bnImport.Enabled = (null != _doc);

            gridPallets.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridPalletCorners.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridPalletCaps.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridPalletFilms.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridBoxes.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridCases.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridBundles.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridCylinders.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridInterlayers.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);
            gridTrucks.Selection.SelectionChanged += new SourceGrid.RangeRegionChangedEventHandler(onSelChangeGrid);

            tabCtrlDBItems.SelectedIndex = 0;
            onSelectedTabChanged(this, null);
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)        
        {
            try
            {
                if (null == _selectedItem)
                    return;
                // get unit system
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)_selectedItem.UnitSystem;
                // pallet
                DCSBPallet dcsbPallet = _selectedItem as DCSBPallet;
                if (null != dcsbPallet)
                {
                    double palletLength = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M0, us);
                    double palletWidth = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M1, us);
                    double palletHeight = UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M2, us);

                    PalletProperties palletProperties = new PalletProperties(null, dcsbPallet.PalletType, palletLength, palletWidth, palletHeight)
                    {
                        Color = Color.FromArgb(dcsbPallet.Color)
                    };
                    Pallet pallet = new Pallet(palletProperties);
                    pallet.Draw(graphics, Transform3D.Identity);
                    graphics.AddDimensions(new DimensionCube(palletLength, palletWidth, palletHeight));
                }
                // pallet cap
                DCSBPalletCap dcsbCap = _selectedItem as DCSBPalletCap;
                if (null != dcsbCap)
                {
                    double length = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M0, us);
                    double width = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M1, us);
                    double height = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M2, us);
                    double innerLength = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M0, us);
                    double innerWidth = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M1, us);
                    double innerHeight = UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M2, us);
                    double weight = UnitsManager.ConvertMassFrom(dcsbCap.Weight, us);

                    PalletCapProperties palletCapProperties = new PalletCapProperties(
                        null, dcsbCap.Name, dcsbCap.Description, length, width, height,
                        innerLength, innerWidth, innerHeight,
                        weight, Color.FromArgb(dcsbCap.Color));
                    PalletCap palletCap = new PalletCap(0, palletCapProperties, BoxPosition.Zero);
                    palletCap.Draw(graphics);
                    graphics.AddDimensions(new DimensionCube(length, width, height));
                }
                // pallet corner
                DCSBPalletCorner dcsbCorner = _selectedItem as DCSBPalletCorner;
                if (null != dcsbCorner)
                { 
                    double length = UnitsManager.ConvertLengthFrom(dcsbCorner.Length, us);
                    double width = UnitsManager.ConvertLengthFrom(dcsbCorner.Width, us);
                    double thickness = UnitsManager.ConvertLengthFrom(dcsbCorner.Thickness, us);
                    double weight = UnitsManager.ConvertMassFrom(dcsbCorner.Weight, us);

                    PalletCornerProperties palletCornerProperties = new PalletCornerProperties(
                        null, dcsbCorner.Name, dcsbCorner.Description,
                        length, width, thickness,
                        weight, Color.FromArgb(dcsbCorner.Color));
                    Corner palletCorner = new Corner(0, palletCornerProperties);
                    palletCorner.Draw(graphics);
                    graphics.AddDimensions(new DimensionCube(width, width, length));
                }
                // pallet film
                DCSBPalletFilm dcsbFilm = _selectedItem as DCSBPalletFilm;
                if (null != dcsbFilm)
                {
                }
                // interlayer
                DCSBInterlayer dcsbInterlayer = _selectedItem as DCSBInterlayer;
                if (null != dcsbInterlayer)
                {
                    double length = UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M0, us);
                    double width = UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M1, us);
                    double thickness = UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M2, us);
                    double weight = UnitsManager.ConvertMassFrom(dcsbInterlayer.Weight, us);

                    InterlayerProperties interlayerProperties = new InterlayerProperties(
                        null, dcsbInterlayer.Name, dcsbInterlayer.Description
                        , length, width, thickness
                        , weight, Color.FromArgb(dcsbInterlayer.Color));
                    Box box = new Box(0, interlayerProperties);
                    graphics.AddBox(box);
                    graphics.AddDimensions(new DimensionCube(length, width, thickness));
                }
                // case
                DCSBCase dcsbCase = _selectedItem as DCSBCase;
                if (null != dcsbCase)
                {
                    double length = UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M0, us);
                    double width = UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M1, us);
                    double height = UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M2, us);
                    Color[] faceColors = new Color[6];
                    for (int i = 0; i < 6; ++i)
                        faceColors[i] = Color.FromArgb(dcsbCase.Colors[i]);
                    List<Pair<HalfAxis.HAxis, Texture>> textures = new List<Pair<HalfAxis.HAxis, Texture>>();

                    BoxProperties boxProperties = new BoxProperties(null, length, width, height);
                    boxProperties.SetAllColors(faceColors);
                    boxProperties.TextureList = textures;
                    boxProperties.TapeWidth = new OptDouble(dcsbCase.ShowTape, UnitsManager.ConvertLengthFrom(dcsbCase.TapeWidth, us));
                    boxProperties.TapeColor = Color.FromArgb(dcsbCase.TapeColor);
                    Box box = new Box(0, boxProperties);
                    graphics.AddBox(box);
                    graphics.AddDimensions(new DimensionCube(length, width, height));
                }
                // bundle
                DCSBBundle dcsbBundle = _selectedItem as DCSBBundle;
                if (null != dcsbBundle)
                { 
                    double length = UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M0, us);
                    double width = UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M1, us);
                    double unitThickness = UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M2, us);

                    BundleProperties bundleProperties = new BundleProperties(
                        null, dcsbBundle.Name, dcsbBundle.Description
                        , length, width, unitThickness
                        , dcsbBundle.UnitWeight, dcsbBundle.Number
                        , Color.FromArgb(dcsbBundle.Color));
                    Box box = new Box(0, bundleProperties);
                    graphics.AddBox(box);
                    graphics.AddDimensions(new DimensionCube(length, width, unitThickness * dcsbBundle.Number));
                }
                // cylinder
                DCSBCylinder dcsbCylinder = _selectedItem as DCSBCylinder;
                if (null != dcsbCylinder)
                {
                    double height = UnitsManager.ConvertLengthFrom(dcsbCylinder.Height, us);
                    double radiusOuter = UnitsManager.ConvertLengthFrom(dcsbCylinder.RadiusOuter, us);
                    double radiusInner = UnitsManager.ConvertLengthFrom(dcsbCylinder.RadiusInner, us);
                    double weight = UnitsManager.ConvertMassFrom(dcsbCylinder.Weight, us);

                    CylinderProperties cylProperties = new CylinderProperties(
                        null, dcsbCylinder.Name, dcsbCylinder.Description
                        , radiusOuter, radiusInner, height, weight
                        , Color.FromArgb(dcsbCylinder.ColorTop)
                        , Color.FromArgb(dcsbCylinder.ColorOuter)
                        , Color.FromArgb(dcsbCylinder.ColorInner)
                        );
                    Cylinder cyl = new Cylinder(0, cylProperties);
                    graphics.AddCylinder(cyl);
                    graphics.AddDimensions(new DimensionCube(new Vector3D(-radiusOuter, -radiusOuter, 0.0), 2.0 * radiusOuter, 2.0 * radiusOuter, height, Color.Black, false));
                }
                // truck
                DCSBTruck dcsbtruck = _selectedItem as DCSBTruck;
                if (null != dcsbtruck)
                {
                    double truckLength = dcsbtruck.DimensionsInner.M0;
                    double truckWidth = dcsbtruck.DimensionsInner.M1;
                    double truckHeight = dcsbtruck.DimensionsInner.M2;
                    TruckProperties truckProperties = new TruckProperties(null, truckLength, truckWidth, truckHeight)
                    {
                        Color = Color.FromArgb(dcsbtruck.Color)
                    };
                    Truck truck = new Truck(truckProperties);
                    truck.DrawBegin(graphics);
                    truck.DrawEnd(graphics);
                    graphics.AddDimensions(new DimensionCube(truckLength, truckWidth, truckHeight));
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Public properties
        public Document Document
        {
            set { _doc = value; }
        }
        #endregion 

        #region Data grids
        #region Helpers
        private void GridInitialize(SourceGrid.Grid grid, List<string> captions)
        {
            // remove all existing rows
            grid.Rows.Clear();
            // *** IViews 
            // captionHeader
            SourceGrid.Cells.Views.RowHeader captionHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.SteelBlue,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            captionHeader.Background = veHeaderCaption;
            captionHeader.ForeColor = Color.Black;
            captionHeader.Font = new Font("Arial", 10, FontStyle.Bold);
            captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // viewRowHeader
            SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader();
            DevAge.Drawing.VisualElements.ColumnHeader backHeader = new DevAge.Drawing.VisualElements.ColumnHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewColumnHeader.Background = backHeader;
            viewColumnHeader.ForeColor = Color.Black;
            viewColumnHeader.Font = new Font("Arial", 10, FontStyle.Regular);
            viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***
            // set first row
            grid.BorderStyle = BorderStyle.FixedSingle;
            grid.ColumnsCount = 4 + captions.Count;
            grid.FixedRows = 1;
            grid.Rows.Insert(0);
            // header
            int iCol = 0;
            SourceGrid.Cells.ColumnHeader columnHeader;
            // name
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
            // description
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DESCRIPTION)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
            // listed captions
            foreach (string s in captions)
            {
                columnHeader = new SourceGrid.Cells.ColumnHeader(s)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                grid[0, iCol++] = columnHeader;
            }
            // auto import
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_AUTOIMPORT)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
            // delete
            columnHeader = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_DELETE)
            {
                AutomaticSortEnabled = false,
                View = viewColumnHeader
            };
            grid[0, iCol++] = columnHeader;
        }
        private void GridFinalize(SourceGrid.Grid grid)
        {
            grid.AutoStretchColumnsToFitWidth = true;
            grid.AutoSizeCells();
            grid.Columns.StretchToFit();

            // select first solution
            if (grid.RowsCount > 1)
                grid.Selection.SelectRow(1, true);
            else
            {
                // grid empty -> clear drawing
                _selectedItem = null;
                graphCtrl.Invalidate();
            }
        }
        #endregion

        #region Pallets
        void FillGridPallets()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_DIMENSIONS, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridPallets, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _pallets = WCFClientSingleton.Instance.Client.GetAllPallets();
            int iIndex = 0;
            foreach (DCSBPallet p in _pallets)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)p.UnitSystem;

                gridPallets.Rows.Insert(++iIndex);
                int iCol = 0;
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(p.Name);
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(p.Description);
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M0, us),
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M1, us),
                        UnitsManager.ConvertLengthFrom(p.Dimensions.M2, us))
                    );
                gridPallets[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                       string.Format("{0:0.###}", UnitsManager.ConvertMassFrom(p.Weight, us))
                    );
                gridPallets[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, p.AutoInsert);
                gridPallets[iIndex, iCol++].AddController(checkBoxEvent);
                gridPallets[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridPallets[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridPallets);
        }
        #endregion
        #region Interlayers
        private void FillGridInterlayers()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_DIMENSIONS, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridInterlayers, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _interlayers = WCFClientSingleton.Instance.Client.GetAllInterlayers();
            int iIndex = 0;
            foreach (DCSBInterlayer i in _interlayers)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)i.UnitSystem;

                gridInterlayers.Rows.Insert(++iIndex);
                int iCol = 0;
                gridInterlayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(i.Name);
                gridInterlayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(i.Description);
                gridInterlayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(i.Dimensions.M0, us),
                        UnitsManager.ConvertLengthFrom(i.Dimensions.M1, us),
                        UnitsManager.ConvertLengthFrom(i.Dimensions.M2, us))
                    );
                gridInterlayers[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                        UnitsManager.ConvertMassFrom(i.Weight, us)
                    );
                gridInterlayers[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, i.AutoInsert);
                gridInterlayers[iIndex, iCol++].AddController(checkBoxEvent);
                gridInterlayers[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridInterlayers[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridInterlayers);
        }
        #endregion
        #region PalletCaps
        private void FillGridPalletCaps()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_DIMEXT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_DIMINT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridPalletCaps, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _palletCaps = WCFClientSingleton.Instance.Client.GetAllPalletCaps();
            int iIndex = 0;
            foreach (DCSBPalletCap pc in _palletCaps)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)pc.UnitSystem;

                gridPalletCaps.Rows.Insert(++iIndex);
                int iCol = 0;
                gridPalletCaps[iIndex, iCol++] = new SourceGrid.Cells.Cell(pc.Name);
                gridPalletCaps[iIndex, iCol++] = new SourceGrid.Cells.Cell(pc.Description);
                gridPalletCaps[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(pc.DimensionsOuter.M0, us),
                        UnitsManager.ConvertLengthFrom(pc.DimensionsOuter.M1, us),
                        UnitsManager.ConvertLengthFrom(pc.DimensionsOuter.M2, us)));
                gridPalletCaps[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(pc.DimensionsInner.M0, us),
                        UnitsManager.ConvertLengthFrom(pc.DimensionsInner.M1, us),
                        UnitsManager.ConvertLengthFrom(pc.DimensionsInner.M2, us)));
                gridPalletCaps[iIndex, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.###}", UnitsManager.ConvertMassFrom(pc.Weight, us)));
                gridPalletCaps[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, pc.AutoInsert);
                gridPalletCaps[iIndex, iCol++].AddController(checkBoxEvent);
                gridPalletCaps[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridPalletCaps[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridPalletCaps);
        }
        #endregion
        #region PalletCormers
        private void FillGridPalletCorners()
        { 
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_LENGTH_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WIDTH_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_THICKNESS_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridPalletCorners, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _palletCorners = WCFClientSingleton.Instance.Client.GetAllPalletCorners();
            int iIndex = 0;
            foreach (DCSBPalletCorner c in _palletCorners)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)c.UnitSystem;
                gridPalletCorners.Rows.Insert(++iIndex);
                int iCol = 0;
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Name);
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Description);
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.##}", UnitsManager.ConvertLengthFrom(c.Length, us)));
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.##}", UnitsManager.ConvertLengthFrom(c.Width, us)));
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.##}", UnitsManager.ConvertLengthFrom(c.Thickness, us)));
                gridPalletCorners[iIndex, iCol++] = new SourceGrid.Cells.Cell(string.Format("{0:0.###}", UnitsManager.ConvertMassFrom(c.Weight, us)));
                gridPalletCorners[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, c.AutoInsert);
                gridPalletCorners[iIndex, iCol++].AddController(checkBoxEvent);
                gridPalletCorners[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridPalletCorners[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridPalletCorners);
        }
        #endregion
        #region PalletFilms
        private void FillGridPalletFilms()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(Properties.Resources.ID_TRANSPARENCY);
            captions.Add(string.Format(Properties.Resources.ID_HATCHINGSPACING, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(Properties.Resources.ID_HATCHINGANGLE);
            GridInitialize(gridPalletFilms, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _palletFilms = WCFClientSingleton.Instance.Client.GetAllPalletFilms();
            int iIndex = 0;
            foreach (DCSBPalletFilm c in _palletFilms)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)c.UnitSystem;
                gridPalletFilms.Rows.Insert(++iIndex);
                int iCol = 0;
                gridPalletFilms[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Name);
                gridPalletFilms[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Description);
                gridPalletFilms[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.UseTransparency);
                gridPalletFilms[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.UseHatching ? string.Format("{0:0.#}", c.HatchingSpace) : "-");
                gridPalletFilms[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.UseHatching ? string.Format("{0:0.#}", c.HatchingAngle) : "-");
                gridPalletFilms[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, c.AutoInsert);
                gridPalletFilms[iIndex, iCol++].AddController(checkBoxEvent);
                gridPalletFilms[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridPalletFilms[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridPalletFilms);
        }
        #endregion
        #region Boxes
        private void FillGridBoxes()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_DIMEXT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridBoxes, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _boxes = WCFClientSingleton.Instance.Client.GetAllBoxes();
            int iIndex = 0;
            foreach (DCSBCase c in _boxes)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)c.UnitSystem;

                gridBoxes.Rows.Insert(++iIndex);
                int iCol = 0;
                gridBoxes[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Name);
                gridBoxes[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Description);
                gridBoxes[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M0, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M1, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M2, us)));
                gridBoxes[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertMassFrom(c.Weight, us));
                gridBoxes[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, c.AutoInsert);
                gridBoxes[iIndex, iCol++].AddController(checkBoxEvent);
                gridBoxes[iIndex, iCol] = new SourceGrid.Cells.Button("") { Image = Properties.Resources.Delete };
                gridBoxes[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridBoxes);
        }
        #endregion
        #region Cases
        private void FillGridCases()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_DIMEXT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_DIMINT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridCases, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _cases = WCFClientSingleton.Instance.Client.GetAllCases();
            int iIndex = 0;
            foreach (DCSBCase c in _cases)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)c.UnitSystem;

                gridCases.Rows.Insert(++iIndex);
                int iCol = 0;
                gridCases[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Name);
                gridCases[iIndex, iCol++] = new SourceGrid.Cells.Cell(c.Description);
                gridCases[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M0, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M1, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsOuter.M2, us)));
                gridCases[iIndex, iCol++] = new SourceGrid.Cells.Cell(
                    c.HasInnerDims ? 
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                        UnitsManager.ConvertLengthFrom(c.DimensionsInner.M0, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsInner.M1, us),
                        UnitsManager.ConvertLengthFrom(c.DimensionsInner.M2, us)): "-");
                gridCases[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertMassFrom(c.Weight, us));
                gridCases[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, c.AutoInsert);
                gridCases[iIndex, iCol++].AddController(checkBoxEvent);
                gridCases[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridCases[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridCases);
        }
        #endregion
        #region Bundles
        private void FillGridBundles()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_LENGTH_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WIDTH_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_THICKNESS_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_NUMBER));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridBundles, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _bundles = WCFClientSingleton.Instance.Client.GetAllBundles();
            int iIndex = 0;
            foreach (DCSBBundle b in _bundles)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)b.UnitSystem;

                gridBundles.Rows.Insert(++iIndex);
                int iCol = 0;
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(b.Name);
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(b.Description);
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(b.DimensionsUnit.M0, us));
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(b.DimensionsUnit.M1, us));
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(b.DimensionsUnit.M2, us));
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(b.Number);
                gridBundles[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertMassFrom(b.Number * b.UnitWeight, us));
                gridBundles[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, b.AutoInsert);
                gridBundles[iIndex, iCol++].AddController(checkBoxEvent);
                gridBundles[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridBundles[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridBundles);
        }
        #endregion
        #region Cylinders
        void FillGridCylinders()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add(string.Format(Properties.Resources.ID_HEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_DIAMETEROUTER_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_DIAMETERINNER_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)));
            captions.Add(string.Format(Properties.Resources.ID_WEIGHT_WU, UnitsManager.UnitString(UnitsManager.UnitType.UT_MASS)));
            GridInitialize(gridCylinders, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);

            _cylinders = WCFClientSingleton.Instance.Client.GetAllCylinders();
            int iIndex = 0;
            foreach (DCSBCylinder cyl in _cylinders)
            {
                UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)cyl.UnitSystem;

                gridCylinders.Rows.Insert(++iIndex);
                int iCol = 0;
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(cyl.Name);
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(cyl.Description);
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(cyl.Height, us));
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(2.0 * cyl.RadiusOuter, us));
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertLengthFrom(2.0 * cyl.RadiusInner, us));
                gridCylinders[iIndex, iCol++] = new SourceGrid.Cells.Cell(UnitsManager.ConvertMassFrom(cyl.Weight, us));
                gridCylinders[iIndex, iCol] = new SourceGrid.Cells.CheckBox(null, cyl.AutoInsert);
                gridCylinders[iIndex, iCol++].AddController(checkBoxEvent);
                gridCylinders[iIndex, iCol] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridCylinders[iIndex, iCol++].AddController(buttonDelete);
            }
            GridFinalize(gridCylinders);
        }
        #endregion
        #region Trucks
        private void FillGridTrucks()
        {
            // initialize grid
            List<string> captions = new List<string>();
            captions.Add( string.Format(Properties.Resources.ID_DIMENSIONS, UnitsManager.UnitString(UnitsManager.UnitType.UT_LENGTH)) );
            GridInitialize(gridTrucks, captions);
            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(onAutoImport);
            // handling delete event
            SourceGrid.Cells.Controllers.CustomEvents buttonDelete = new SourceGrid.Cells.Controllers.CustomEvents();
            buttonDelete.Click += new EventHandler(onDeleteItem);
            // get all trucks
            _trucks = WCFClientSingleton.Instance.Client.GetAllTrucks();
            int iIndex = 0;
            foreach (DCSBTruck t in _trucks)
            {
                gridTrucks.Rows.Insert(++iIndex);
                gridTrucks[iIndex, 0] = new SourceGrid.Cells.Cell(t.Name);
                gridTrucks[iIndex, 1] = new SourceGrid.Cells.Cell(t.Description);
                gridTrucks[iIndex, 2] = new SourceGrid.Cells.Cell(
                    string.Format("{0:0.##} x {1:0.##} x {2:0.##}",
                    UnitsManager.ConvertLengthFrom(t.DimensionsInner.M0, (UnitsManager.UnitSystem)t.UnitSystem),
                    UnitsManager.ConvertLengthFrom(t.DimensionsInner.M1, (UnitsManager.UnitSystem)t.UnitSystem),
                    UnitsManager.ConvertLengthFrom(t.DimensionsInner.M2, (UnitsManager.UnitSystem)t.UnitSystem))
                    );
                gridTrucks[iIndex, 3] = new SourceGrid.Cells.CheckBox(null, t.AutoInsert);
                gridTrucks[iIndex, 3].AddController(checkBoxEvent);
                gridTrucks[iIndex, 4] = new SourceGrid.Cells.Button("")
                {
                    Image = Properties.Resources.Delete
                };
                gridTrucks[iIndex, 4].AddController(buttonDelete);
            }
            GridFinalize(gridTrucks);
        }
        #endregion
        #endregion

        #region Event handlers
        private void onAutoImport(object sender, EventArgs e)
        {
            try
            {
                SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
                int iSel = context.Position.Row - 1;
                SourceGrid.Grid g = context.Grid as SourceGrid.Grid;

                if (g == gridPallets)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TPallet, _pallets[iSel].ID, !_pallets[iSel].AutoInsert);
                    FillGridPallets();
                }
                else if (g == gridPalletCorners)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TPalletCorner, _palletCorners[iSel].ID, !_palletCorners[iSel].AutoInsert);
                    FillGridPalletCorners();
                }
                else if (g == gridPalletCaps)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TPalletCap, _palletCaps[iSel].ID, !_palletCaps[iSel].AutoInsert);
                    FillGridPalletCaps();
                }
                else if (g == gridPalletFilms)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TPalletFilm, _palletFilms[iSel].ID, !_palletFilms[iSel].AutoInsert);
                    FillGridPalletFilms();
                }
                else if (g == gridInterlayers)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TInterlayer, _interlayers[iSel].ID, !_interlayers[iSel].AutoInsert);
                    FillGridInterlayers();
                }
                else if (g == gridBoxes)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TCase, _boxes[iSel].ID, !_boxes[iSel].AutoInsert);
                    FillGridBoxes();
                }
                else if (g == gridCases)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TCase, _cases[iSel].ID, !_cases[iSel].AutoInsert);
                    FillGridCases();
                }
                else if (g == gridBundles)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TBundle, _bundles[iSel].ID, !_bundles[iSel].AutoInsert);
                    FillGridBundles();
                }
                else if (g == gridCylinders)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TCylinder, _cylinders[iSel].ID, !_cylinders[iSel].AutoInsert);
                    FillGridCylinders();
                }
                else if (g == gridTrucks)
                {
                    WCFClientSingleton.Instance.Client.SetAutoInsert(DCSBTypeEnum.TTruck, _trucks[iSel].ID, !_trucks[iSel].AutoInsert);
                    FillGridTrucks();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onDeleteItem(object sender, EventArgs e)
        {
            try
            {
                SourceGrid.CellContext context = (SourceGrid.CellContext)sender;
                int iSel = context.Position.Row - 1;
                SourceGrid.Grid g = context.Grid as SourceGrid.Grid;

                if (g == gridPallets)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TPallet, _pallets[iSel].ID);
                    FillGridPallets();
                }
                else if (g == gridPalletCorners)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TPalletCorner, _palletCorners[iSel].ID);
                    FillGridPalletCorners();
                }
                else if (g == gridPalletCaps)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TPalletCap, _palletCaps[iSel].ID);
                    FillGridPalletCaps();
                }
                else if (g == gridPalletFilms)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TPalletFilm, _palletFilms[iSel].ID);
                    FillGridPalletFilms();
                }
                else if (g == gridBoxes)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TCase, _boxes[iSel].ID);
                    FillGridBoxes();
                }
                else if (g == gridCases)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TCase, _cases[iSel].ID);
                    FillGridCases();
                }
                else if (g == gridBundles)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TBundle, _bundles[iSel].ID);
                    FillGridBundles();
                }
                else if (g == gridCylinders)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TCylinder, _cylinders[iSel].ID);
                    FillGridCylinders();
                }
                else if (g == gridTrucks)
                {
                    WCFClientSingleton.Instance.Client.RemoveItemById(DCSBTypeEnum.TTruck, _trucks[iSel].ID);
                    FillGridTrucks();
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onSelectedTabChanged(object sender, EventArgs e)
        {
            try
            {
                string tabName = tabCtrlDBItems.SelectedTab.Name;
                if (string.Equals(tabName, "tabPagePallet"))
                    FillGridPallets();
                else if (string.Equals(tabName, "tabPagePalletCorner"))
                    FillGridPalletCorners();
                else if (string.Equals(tabName, "tabPagePalletCap"))
                    FillGridPalletCaps();
                else if (string.Equals(tabName, "tabPagePalletFilm"))
                    FillGridPalletFilms();
                else if (string.Equals(tabName, "tabPageInterlayer"))
                    FillGridInterlayers();
                else if (string.Equals(tabName, "tabPageBundle"))
                    FillGridBundles();
                else if (string.Equals(tabName, "tabPageBox"))
                    FillGridBoxes();
                else if (string.Equals(tabName, "tabPageCase"))
                    FillGridCases();
                else if (string.Equals(tabName, "tabPageCylinder"))
                    FillGridCylinders();
                else if (string.Equals(tabName, "tabPageTruck"))
                    FillGridTrucks();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }            
        }
        private void onSelChangeGrid(object sender, SourceGrid.RangeRegionChangedEventArgs e)
        {
            try
            {
                SourceGrid.Selection.RowSelection select = sender as SourceGrid.Selection.RowSelection;
                SourceGrid.Grid g = select.Grid as SourceGrid.Grid;

                SourceGrid.RangeRegion region = g.Selection.GetSelectionRegion();
                int[] indexes = region.GetRowsIndex();
                if (indexes.Length < 1 || indexes[0] < 1)
                    _selectedItem = null;
                else
                {
                    int iSel = indexes[0] - 1;
                    if (g == gridPallets)       _selectedItem = _pallets[iSel];
                    if (g == gridPalletCorners) _selectedItem = _palletCorners[iSel];
                    if (g == gridPalletCaps)    _selectedItem = _palletCaps[iSel];
                    if (g == gridPalletFilms)   _selectedItem = _palletFilms[iSel];
                    if (g == gridInterlayers)   _selectedItem = _interlayers[iSel];
                    if (g == gridBoxes)         _selectedItem = _boxes[iSel];
                    if (g == gridCases)         _selectedItem = _cases[iSel];
                    if (g == gridBundles)       _selectedItem = _bundles[iSel];
                    if (g == gridCylinders)     _selectedItem = _cylinders[iSel];
                    if (g == gridTrucks)        _selectedItem = _trucks[iSel];
                }
                graphCtrl.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        private void onImport(object sender, EventArgs e)
        {
            // sanity check
            if (null == _doc || null == _selectedItem) return;
            // checking name
            string name = _selectedItem.Name;
            if (!GetValidName(ref name)) return; // user exited without entering a valid name
            // unit system
            UnitsManager.UnitSystem us = (UnitsManager.UnitSystem)_selectedItem.UnitSystem;
            try
            {
                // pallet
                DCSBPallet dcsbPallet = _selectedItem as DCSBPallet;
                if (null != dcsbPallet)
                {
                    PalletProperties palletProperties = _doc.CreateNewPallet(
                        name, dcsbPallet.Description,
                        dcsbPallet.PalletType,
                        UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbPallet.Dimensions.M2, us),
                        UnitsManager.ConvertMassFrom(dcsbPallet.Weight, us),
                        Color.FromArgb(dcsbPallet.Color)
                        );
                    if (dcsbPallet.AdmissibleLoad.HasValue)
                        palletProperties.AdmissibleLoadWeight = UnitsManager.ConvertMassFrom(dcsbPallet.AdmissibleLoad.Value, us);
                }
                // interlayer
                DCSBInterlayer dcsbInterlayer = _selectedItem as DCSBInterlayer;
                if (null != dcsbInterlayer)
                {
                    InterlayerProperties interlayerProp = _doc.CreateNewInterlayer(
                        name, dcsbInterlayer.Description,
                        UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbInterlayer.Dimensions.M2, us),
                        UnitsManager.ConvertMassFrom(dcsbInterlayer.Weight, us),
                        Color.FromArgb(dcsbInterlayer.Color)
                        );
                }
                // case
                DCSBCase dcsbCase = _selectedItem as DCSBCase;
                if (null != dcsbCase)
                {
                    Color[] colors = new Color[6];
                    for (int i=0; i<6; ++i)
                         colors[i] = Color.FromArgb(dcsbCase.Colors[i]);

                    BoxProperties bProperties = null;
                    if (dcsbCase.IsCase)
                        bProperties = _doc.CreateNewCase(name, dcsbCase.Description,
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M0, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M1, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M2, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsInner.M0, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsInner.M1, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsInner.M2, us),
                            UnitsManager.ConvertMassFrom(dcsbCase.Weight, us),
                            colors);
                    else
                        bProperties = _doc.CreateNewBox(
                            name, dcsbCase.Description,
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M0, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M1, us),
                            UnitsManager.ConvertLengthFrom(dcsbCase.DimensionsOuter.M2, us),
                            UnitsManager.ConvertMassFrom(dcsbCase.Weight, us),
                            colors);
                    bProperties.TapeWidth = new OptDouble(dcsbCase.IsCase && dcsbCase.ShowTape, UnitsManager.ConvertLengthFrom(dcsbCase.TapeWidth, us));
                    bProperties.TapeColor = Color.FromArgb(dcsbCase.TapeColor);
                    bProperties.SetNetWeight(
                        new OptDouble(!dcsbCase.HasInnerDims && dcsbCase.NetWeight.HasValue
                            , dcsbCase.NetWeight.HasValue ? dcsbCase.NetWeight.Value : 0.0) );
                    List<Pair<HalfAxis.HAxis, Texture>> textures = new List<Pair<HalfAxis.HAxis,Texture>>();
                    bProperties.TextureList = textures;
                }
                // bundle
                DCSBBundle dcsbBundle = _selectedItem as DCSBBundle;
                if (null != dcsbBundle)
                {
                    BundleProperties bundle = _doc.CreateNewBundle(name, dcsbBundle.Description,
                        UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbBundle.DimensionsUnit.M2, us),
                        UnitsManager.ConvertMassFrom(dcsbBundle.UnitWeight, us),
                        Color.FromArgb(dcsbBundle.Color),
                        dcsbBundle.Number);
                }
                // cylinder
                DCSBCylinder dcsbCylinder = _selectedItem as DCSBCylinder;
                if (null != dcsbCylinder)
                { 
                    CylinderProperties cylProp = _doc.CreateNewCylinder(
                        name, dcsbCylinder.Description,
                        UnitsManager.ConvertLengthFrom(dcsbCylinder.RadiusOuter, us),
                        UnitsManager.ConvertLengthFrom(dcsbCylinder.RadiusInner, us),
                        UnitsManager.ConvertLengthFrom(dcsbCylinder.Height, us),
                        UnitsManager.ConvertMassFrom(dcsbCylinder.Weight, us),
                        Color.FromArgb(dcsbCylinder.ColorTop), Color.FromArgb(dcsbCylinder.ColorOuter), Color.FromArgb(dcsbCylinder.ColorInner)
                        );                
                }
                // trucks
                DCSBTruck dcsbTruck = _selectedItem as DCSBTruck;
                if (null != dcsbTruck)
                {
                    TruckProperties truckProp = _doc.CreateNewTruck(
                        name, dcsbTruck.Description,
                        UnitsManager.ConvertLengthFrom(dcsbTruck.DimensionsInner.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbTruck.DimensionsInner.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbTruck.DimensionsInner.M2, us),
                        UnitsManager.ConvertMassFrom(dcsbTruck.AdmissibleLoad, us),
                        Color.FromArgb(dcsbTruck.Color)
                        );
                }
                // pallet cap
                DCSBPalletCap dcsbCap = _selectedItem as DCSBPalletCap;
                if (null != dcsbCap)
                {
                    PalletCapProperties palletCapProperties = _doc.CreateNewPalletCap(
                        dcsbCap.Name, dcsbCap.Description,
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsOuter.M2, us),
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M0, us),
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M1, us),
                        UnitsManager.ConvertLengthFrom(dcsbCap.DimensionsInner.M2, us),
                        UnitsManager.ConvertMassFrom(dcsbCap.Weight, us),
                        Color.FromArgb(dcsbCap.Color)
                        );
                }
                // pallet corner
                DCSBPalletCorner dcsbPalletCorner = _selectedItem as DCSBPalletCorner;
                if (null != dcsbPalletCorner)
                {
                    PalletCornerProperties palletCornerProperties = _doc.CreateNewPalletCorners(
                        name, dcsbPalletCorner.Description,
                        UnitsManager.ConvertLengthFrom(dcsbPalletCorner.Length, us),
                        UnitsManager.ConvertLengthFrom(dcsbPalletCorner.Width, us),
                        UnitsManager.ConvertLengthFrom(dcsbPalletCorner.Thickness, us),
                        UnitsManager.ConvertMassFrom(dcsbPalletCorner.Weight, us),
                        Color.FromArgb(dcsbPalletCorner.Color)
                        );
                }
                // pallet film
                DCSBPalletFilm dcsbPalletFilm = _selectedItem as DCSBPalletFilm;
                if (null != dcsbPalletFilm)
                {
                    PalletFilmProperties palletFilm = _doc.CreateNewPalletFilm(name, dcsbPalletFilm.Description,
                        dcsbPalletFilm.UseTransparency, dcsbPalletFilm.UseHatching,
                        dcsbPalletFilm.HatchingSpace, dcsbPalletFilm.HatchingAngle,
                        Color.FromArgb(dcsbPalletFilm.Color));
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
            if (Properties.Settings.Default.CloseDbBrowserAfterImport)
                Close();
        }

        private bool GetValidName(ref string name)
        {
            if (_doc.IsValidNewTypeName(name, null))
                return true;
            // not a valid name, show dialog box
            FormValidTypeName form = new FormValidTypeName(_doc)
            {
                ItemName = name
            };
            if (DialogResult.OK == form.ShowDialog())
            {
                name = form.ItemName;
                return true;
            }
            else
                return false;
        }
        #endregion

        #region Data members
        protected static ILog _log = LogManager.GetLogger(typeof(FormShowDatabase));
        private DCSBItem _selectedItem;

        private DCSBPallet[] _pallets = null;
        private DCSBPalletCap[] _palletCaps = null;
        private DCSBPalletCorner[] _palletCorners = null;
        private DCSBPalletFilm[] _palletFilms = null;
        private DCSBBundle[] _bundles = null;
        private DCSBCase[] _cases = null;
        private DCSBCase[] _boxes = null;
        private DCSBCylinder[] _cylinders = null;
        private DCSBInterlayer[] _interlayers = null;
        private DCSBTruck[] _trucks = null;

        private Document _doc;
        #endregion
    }
}
