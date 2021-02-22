#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using log4net;
using WeifenLuo.WinFormsUI.Docking;
using SourceGrid;

using treeDiM.StackBuilder.WCFService.Test.SB_SR;
#endregion

namespace treeDiM.StackBuilder.WCFService.Test
{
    public partial class FormTestHeterogeneous : DockContent
    {
        #region Constructor
        public FormTestHeterogeneous()
        {
            InitializeComponent();
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PalletLength = 1200.0; PalletWidth = 1000.0; PalletHeight = 144.0;
            PalletWeight = 22.0;
            MaxPalletHeight = 1700.0;

            Items.Add(
                new DCSBContentItem()
                {
                    Number = 1,
                    Orientation = new DCSBBool3()
                    {
                        X = false,
                        Y = false,
                        Z = true
                    },
                    Case = new DCSBCase()
                    {
                        Name = "Case",
                        Description = "Default case",
                        DimensionsOuter = new DCSBDim3D() { M0 = 400.0, M1 = 300.0, M2 = 200.0 },
                        HasInnerDims = false,
                        DimensionsInner = null,
                        Weight = 1.0,
                        MaxWeight = 100.0,
                        NetWeight = 0.9,
                        ShowTape = true,
                        TapeWidth = 50.0,
                        TapeColor = Color.Beige.ToArgb(),
                        Colors = Enumerable.Repeat(Color.Chocolate.ToArgb(), 6).ToArray()
                    }
                }
                );
            // handling content grid events
            _checkBoxEvent.Click += new EventHandler(OnDataModified);
            _numUpDownEvent.ValueChanged += new EventHandler(OnDataModified);
            FillGridContent();
        }
        #endregion

        #region Grid
        private void FillGridContent()
        {
            try
            {
                // remove existing rows
                gridContent.Rows.Clear();
                // viewColumnHeader
                SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
                {
                    Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                    {
                        BackColor = Color.LightGray,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder
                    },
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Regular)
                };
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                var viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***
                // set first row
                gridContent.BorderStyle = BorderStyle.FixedSingle;
                gridContent.ColumnsCount = 5;
                gridContent.FixedRows = 1;

                // header
                int iCol = 0;
                gridContent.Rows.Insert(0);
                gridContent[0, iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NUMBER)
                {
                    AutomaticSortEnabled = false,
                    View = viewColumnHeader
                };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("X") { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("Y") { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("Z") { AutomaticSortEnabled = false, View = viewColumnHeader };

                // content
                int iIndex = 0;
                foreach (var ci in Items)
                {
                    // insert row
                    gridContent.Rows.Insert(++iIndex);
                    iCol = 0;
                    // name
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell(ci.Case.Name) { View = viewNormal, Tag = ci.Case.Name };
                    // number
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.Cell((int)ci.Number) { View = viewNormal };
                    SourceGrid.Cells.Editors.NumericUpDown l_NumericUpDownEditor = new SourceGrid.Cells.Editors.NumericUpDown(typeof(int), 10000, 0, 1);
                    l_NumericUpDownEditor.SetEditValue((int)ci.Number);
                    gridContent[iIndex, iCol].Editor = l_NumericUpDownEditor;
                    gridContent[iIndex, iCol].AddController(_numUpDownEvent);
                    // orientation X
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.Orientation.X);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                    // orientation Y
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.Orientation.Y);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                    // orientation Z
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.Orientation.Z);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                }
                gridContent.AutoSizeCells();
                gridContent.Columns.StretchToFit();
                gridContent.AutoStretchColumnsToFitWidth = true;
                gridContent.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        private void UpdateItems()
        {
            for (int iRow = 1; iRow < gridContent.RowsCount; ++iRow)
            {
                try
                {
                    SourceGrid.Cells.Editors.NumericUpDown upDownEditor = gridContent[iRow, 1].Editor as SourceGrid.Cells.Editors.NumericUpDown;
                    SourceGrid.Cells.CheckBox checkBoxX = gridContent[iRow, 2] as SourceGrid.Cells.CheckBox;
                    SourceGrid.Cells.CheckBox checkBoxY = gridContent[iRow, 3] as SourceGrid.Cells.CheckBox;
                    SourceGrid.Cells.CheckBox checkBoxZ = gridContent[iRow, 4] as SourceGrid.Cells.CheckBox;

                    Items[iRow - 1].Number = Convert.ToUInt32(upDownEditor.GetEditedValue());
                    Items[iRow - 1].Orientation = new DCSBBool3() { X = (bool)checkBoxX.Value, Y = (bool)checkBoxY.Value, Z = (bool)checkBoxZ.Value };
                }
                catch (Exception ex)
                {
                    _log.Error(ex.ToString());
                }
            }
        }

        internal class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
        {
            public CellBackColorAlternate(Color firstColor, Color secondColor)
            {
                FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
                SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
            }
            public DevAge.Drawing.VisualElements.IVisualElement FirstBackground { get; set; }
            public DevAge.Drawing.VisualElements.IVisualElement SecondBackground { get; set; }

            protected override void PrepareView(CellContext context)
            {
                base.PrepareView(context);

                if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                    Background = FirstBackground;
                else
                    Background = SecondBackground;
            }

            public static CellBackColorAlternate ViewAliceBlueWhite
            {
                get
                {
                    // CellBackColorAlternate view
                    DevAge.Drawing.BorderLine border = new DevAge.Drawing.BorderLine(Color.LightBlue, 1);
                    DevAge.Drawing.RectangleBorder cellBorder = new DevAge.Drawing.RectangleBorder(border, border);
                    return new CellBackColorAlternate(Color.AliceBlue, Color.White) { Border = cellBorder };
                }
            }
        }
        #endregion

        #region Event handlers
        private void OnDataModified(object sender, EventArgs e)
        {
            UpdateItems();
            OnCompute(sender, e);
        }
        private void OnBoxesAdd(object sender, EventArgs e)
        {
            var form = new FormAddItem();
            if (DialogResult.OK == form.ShowDialog())
            {
                Items.Add(
                   new DCSBContentItem()
                   {
                       Number = form.Number,
                       Orientation = new DCSBBool3()
                       {
                           X = form.AllowX,
                           Y = form.AllowY,
                           Z = form.AllowZ
                       },
                       Case = new DCSBCase()
                       {
                           Name = form.CaseName,
                           Description = form.CaseName,
                           DimensionsOuter = new DCSBDim3D() { M0 = form.CaseLength, M1 = form.CaseWidth, M2 = form.CaseHeight },
                           HasInnerDims = false,
                           DimensionsInner = null,
                           Weight = form.CaseWeight,
                           MaxWeight = 1000.0,
                           NetWeight = form.CaseWeight,
                           ShowTape = true,
                           TapeWidth = 50.0,
                           TapeColor = Color.Beige.ToArgb(),
                           Colors = Enumerable.Repeat(form.ColorFaces.ToArgb(), 6).ToArray()
                       }
                   }
                   );
                FillGridContent();
                OnCompute(sender, e);
            }
        }
        private void OnBoxesRemove(object sender, EventArgs e)
        {
            RangeRegion region = gridContent.Selection.GetSelectionRegion();
            int[] indexes = region.GetRowsIndex();
            // no selection -> exit
            if (indexes.Length == 0) return;
            Items.RemoveAt(indexes[0] - 1);
            FillGridContent();
            OnCompute(sender, e);
        }
        private void OnCompute(object sender, EventArgs e)
        {
            try
            {
                DateTime dt0 = DateTime.Now;
                using (StackBuilderClient client = new StackBuilderClient())
                {
                    _log.Info($"Calling web service method");

                    var hSolution = client.SB_GetHSolutionBestCasePallet(
                        Items.ToArray(),
                        new DCSBPallet()
                        {
                            Name = "EUR2",
                            Description = "EUR2",
                            PalletType = "EUR2",
                            Color = Color.Yellow.ToArgb(),
                            Dimensions = PalletDimensions,
                            Weight = PalletWeight
                        },
                        new DCSBHConstraintSet()
                        {
                            MaxHeight = new DCSBConstraintDouble() { Active = true, Value_d = MaxPalletHeight },
                            MaxWeight = new DCSBConstraintDouble() { Active = false, Value_d = 1000.0 },
                            Overhang = PalletOverhang
                        },
                        new DCCompFormat()
                        {
                            Size = new DCCompSize()
                            {
                                CX = pbStackbuilder.Size.Width,
                                CY = pbStackbuilder.Size.Height
                            },
                            Format = OutFormat.IMAGE
                        },
                        false
                        );

                    // image
                    pbStackbuilder.Image = null;
                    if (null != hSolution.OutFile)
                    {
                        using (var ms = new System.IO.MemoryStream(hSolution.OutFile.Bytes))
                        {
                            Image img = Image.FromStream(ms);
                            pbStackbuilder.Image = img;
                        }
                    }
                    DateTime dt1 = DateTime.Now;
                    _log.Info($"Web service answered in {(dt1 - dt0).TotalMilliseconds} ms");
                }
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Properties
        // pallet
        private double PalletLength { get => (double)nudPalletDimX.Value; set => nudPalletDimX.Value = (decimal)value; }
        private double PalletWidth { get => (double)nudPalletDimY.Value; set => nudPalletDimY.Value = (decimal)value; }
        private double PalletHeight { get => (double)nudPalletDimZ.Value; set => nudPalletDimZ.Value = (decimal)value; }
        private double PalletWeight { get => (double)nudPalletWeight.Value; set => nudPalletWeight.Value = (decimal)value; }
        private double MaxPalletHeight { get => (double)nudMaxPalletHeight.Value; set => nudMaxPalletHeight.Value = (decimal)value; }
        private double OverhangX { get => (double)nudOverhangX.Value; }
        private double OverhangY { get => (double)nudOverhangY.Value; }
        private DCSBDim3D PalletDimensions => new DCSBDim3D() { M0 = PalletLength, M1 = PalletWidth, M2 = PalletHeight };
        private DCSBDim2D PalletOverhang => new DCSBDim2D() { M0 = OverhangX, M1 = OverhangY };
        private List<DCSBContentItem> Items { get; } = new List<DCSBContentItem>();

        protected SourceGrid.Cells.Controllers.CustomEvents _checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        protected SourceGrid.Cells.Controllers.CustomEvents _numUpDownEvent = new SourceGrid.Cells.Controllers.CustomEvents();

        private ILog _log = LogManager.GetLogger(typeof(FormTestHeterogeneous));
        #endregion
    }
}
