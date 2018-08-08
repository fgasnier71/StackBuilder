#region Using directives
using System;
using System.Linq;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;

using log4net;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Engine;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class FormNewHAnalysis : Form, IDrawingContainer
    {
        #region Constructor
        public FormNewHAnalysis()
        {
            InitializeComponent();
        }
        public FormNewHAnalysis(Document doc, HAnalysis analysis)
        {
            InitializeComponent();
            _document = doc;
            _analysis = analysis;

            if (null == _analysis)
            {
                _analysis = new HAnalysisPallet(_document);
                _analysis.ID.SetNameDesc(doc.GetValidNewAnalysisName("HAnalysis"), string.Empty);
            }
        }
        #endregion

        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // initialize graphic control 
            graphCtrl.DrawingContainer = this;
            /*
                        lBoxes.Add( _document.CreateNewBox("Case 400x300x200", string.Empty, 400, 300, 200, 5.0, Enumerable.Repeat(Color.Chocolate, 6).ToArray()) );
                        lBoxes.Add( _document.CreateNewBox("Case 300x200x50", string.Empty, 300, 200, 50, 5.0, Enumerable.Repeat(Color.BurlyWood, 6).ToArray()) );
                        lBoxes.Add( _document.CreateNewBox("Case 400x250x150", string.Empty, 400, 250, 200, 5.0, Enumerable.Repeat(Color.Chartreuse, 6).ToArray()) );
            */
            lBoxes.Add(_document.CreateNewBox("Case 150x100x150", string.Empty, 150, 100, 150, 5.0, Enumerable.Repeat(Color.Chocolate, 6).ToArray()));
            lBoxes.Add(_document.CreateNewBox("Case 500x500x500", string.Empty, 500, 500, 500, 5.0, Enumerable.Repeat(Color.BurlyWood, 6).ToArray()));
            lBoxes.Add(_document.CreateNewBox("Case 500x550x700", string.Empty, 500, 550, 700, 5.0, Enumerable.Repeat(Color.Chartreuse, 6).ToArray()));
            lBoxes.Add(_document.CreateNewBox("Case 350x350x350", string.Empty, 350, 350, 350, 5.0, Enumerable.Repeat(Color.BurlyWood, 6).ToArray()));
            lBoxes.Add(_document.CreateNewBox("Case 650x750x850", string.Empty, 650, 750, 850, 5.0, Enumerable.Repeat(Color.Chartreuse, 6).ToArray()));

            _analysis.ClearContent();
            _analysis.AddContent(lBoxes[0], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[1], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[2], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[3], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[4], 1, new bool[] { true, true, true });

            // handling checkbox event
            SourceGrid.Cells.Controllers.CustomEvents checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
            checkBoxEvent.Click += new EventHandler(OnDataModified);
            UpdateGrid();

            OnDataModified(this, null);
        }
        #endregion

        #region IDrawingContainer
        public void Draw(Graphics3DControl ctrl, Graphics3D graphics)
        {
            HSolution sol = SelectedSolution;
            if (null != sol)
            {
                ViewerHSolution sv = new ViewerHSolution(sol);
                sv.Draw(graphics, Transform3D.Identity);
            }
        }
        #endregion

        #region Content grid
        private void UpdateGrid()
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
                    Font = new Font("Arial", 10, FontStyle.Regular),
                };
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // ***
                // set first row
                gridContent.BorderStyle = BorderStyle.FixedSingle;
                gridContent.ColumnsCount = 5;
                gridContent.FixedRows = 1;

                // header
                int iCol = 0;
                gridContent.Rows.Insert(0);
                gridContent[0, iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NAME) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_NUMBER) { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("X") { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("Y") { AutomaticSortEnabled = false, View = viewColumnHeader };
                gridContent[0, ++iCol] = new SourceGrid.Cells.ColumnHeader("Z") { AutomaticSortEnabled = false, View = viewColumnHeader };

                // content
                int iIndex = 0;
                foreach (ContentItem ci in _analysis.Content)
                {
                    // insert row
                    gridContent.Rows.Insert(++iIndex);
                    iCol = 0;
                    // name
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell(ci.Pack.Name) { View = viewNormal };
                    // number
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.Cell("NumericUpDown") { View = viewNormal };
                    gridContent[iIndex, iCol] = new SourceGrid.Cells.Cell((int)ci.Number) { View = viewNormal };
                    SourceGrid.Cells.Editors.NumericUpDown l_NumericUpDownEditor = new SourceGrid.Cells.Editors.NumericUpDown(typeof(int), 50, 1, 1);
                    l_NumericUpDownEditor.SetEditValue((int)ci.Number);
                    gridContent[iIndex, iCol].Editor = l_NumericUpDownEditor;
                    // orientation X
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.AllowOrientX);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                    // orientation Y
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.AllowOrientY);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                    // orientation Z
                    gridContent[iIndex, ++iCol] = new SourceGrid.Cells.CheckBox(null, ci.AllowOrientZ);
                    gridContent[iIndex, iCol].AddController(_checkBoxEvent);
                }

                gridContent.AutoSizeCells();
                gridContent.Columns.StretchToFit();
                gridContent.AutoStretchColumnsToFitWidth = true;
                gridContent.Invalidate();
            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }

        private void UpdateResultGrid()
        {
            try
            {
                // remove existing rows
                gridSolutions.Rows.Clear();
                // viewColumnHeader
                SourceGrid.Cells.Views.ColumnHeader viewColumnHeader = new SourceGrid.Cells.Views.ColumnHeader()
                {
                    Background = new DevAge.Drawing.VisualElements.ColumnHeader()
                    {
                        BackColor = Color.LightGray,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder
                    },
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 10, FontStyle.Regular),
                };
                viewColumnHeader.ElementSort.SortStyle = DevAge.Drawing.HeaderSortStyle.None;
                // viewNormal
                CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
                // set first row
                gridSolutions.BorderStyle = BorderStyle.FixedSingle;
                gridSolutions.ColumnsCount = 5;
                gridSolutions.FixedRows = 1;

                // header
                int iCol = 0;
                gridSolutions.Rows.Insert(0);
                gridSolutions[0, iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_ALGORITHM) { View = viewColumnHeader };
                gridSolutions[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_LOADEDCASES) { View = viewColumnHeader };
                gridSolutions[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_UNLOADEDCASES) { View = viewColumnHeader };
                gridSolutions[0, ++iCol] = new SourceGrid.Cells.ColumnHeader(Properties.Resources.ID_LOADEDVOLUMEPERCENTAGE) { View = viewColumnHeader };

                // solutions
                int iIndex = 0;
                foreach (HSolution sol in _solutions)
                {
                    // insert row
                    gridSolutions.Rows.Insert(++iIndex);
                    iCol = 0;
                    // name
                    gridSolutions[iIndex, iCol] = new SourceGrid.Cells.Cell(sol.Algorithm) { View = viewNormal };
                    gridSolutions[iIndex, ++iCol] = new SourceGrid.Cells.Cell(sol.LoadedCasesCount) { View = viewNormal };
                    gridSolutions[iIndex, ++iCol] = new SourceGrid.Cells.Cell(sol.UnloadedCasesCount) { View = viewNormal };
                    gridSolutions[iIndex, ++iCol] = new SourceGrid.Cells.Cell(sol.LoadedVolumePercentage) { View = viewNormal };
                }

                gridSolutions.AutoSizeCells();
                gridSolutions.Columns.StretchToFit();
                gridSolutions.AutoStretchColumnsToFitWidth = true;
                gridSolutions.Invalidate();

            }
            catch (Exception ex)
            {
                _log.Error(ex.Message);
            }
        }
        #endregion

        #region Computation
        protected virtual Vector3D DimContainer { get; }
        protected virtual HConstraintSet ConstraintSet { get; }

        protected virtual List<ContentItem> GetContentItems()
        {
            // initialise analysis

            _analysis.ClearContent();
            _analysis.AddContent(lBoxes[0], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[1], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[2], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[3], 1, new bool[] { true, true, true });
            _analysis.AddContent(lBoxes[4], 1, new bool[] { true, true, true });

            return new List<ContentItem>(_analysis.Content);
        }

        protected void Compute()
        {
            try
            {
                HSolver solver = new HSolver();
                _solutions = solver.BuildSolutions(_analysis);
                //_solutions = solver.BuildSolutions(DimContainer, GetContentItems(), ConstraintSet);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }

            /*
            HSolItem solItem = SelectedSolution.CreateSolItem();
            solItem.InsertContainedElt(0, new BoxPosition(new Vector3D(0.0, 0.0, 150.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(0, new BoxPosition(new Vector3D(600.0, 0.0, 150.0), HalfAxis.HAxis.AXIS_Z_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(0, new BoxPosition(new Vector3D(300.0, 300.0, 150.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            solItem.InsertContainedElt(0, new BoxPosition(new Vector3D(600.0, 300.0, 150.0), HalfAxis.HAxis.AXIS_Y_P, HalfAxis.HAxis.AXIS_X_N));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 50.0, 350.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 250.0, 350.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 450.0, 350.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 50.0, 400.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 250.0, 400.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(1, new BoxPosition(new Vector3D(50.0, 450.0, 400.0), HalfAxis.HAxis.AXIS_X_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(2, new BoxPosition(new Vector3D(600.0, 0.0, 550.0), HalfAxis.HAxis.AXIS_Z_P, HalfAxis.HAxis.AXIS_Y_P));
            solItem.InsertContainedElt(2, new BoxPosition(new Vector3D(600.0, 250, 550.0), HalfAxis.HAxis.AXIS_Z_P, HalfAxis.HAxis.AXIS_Y_P));
            */
        }
        #endregion

        #region Event handlers
        private void OnDataModified(object sender, EventArgs e)
        {
            Compute();
            UpdateResultGrid();
        }
        private void OnAddRow(object sender, EventArgs e)
        {
            try
            {
                Packable p = GetNextPackable();
                if (null != p)
                    _analysis.AddContent(p);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
            }
            UpdateGrid();
        }
        #endregion

        private HSolution SelectedSolution
        {
            get
            {
                if (_solutions.Count > 0)
                    return _solutions[0];
                else
                    return null;
            }
        }

        #region Helpers
        private Packable GetNextPackable()
        {
            Packable p = null;
            foreach (BoxProperties b in _document.Bricks)
            {
                if (!ContentItemsContainsPackable(b))
                    p = b;
                break;
            }
            return p;
        }
        private bool ContentItemsContainsPackable(Packable p)
        {
            return (null != _contentItems.Find(ci => ci.Pack == p));
        }
        #endregion

        #region Data members
        protected Document _document;
        protected HAnalysis _analysis;
        protected List<HSolution> _solutions = new List<HSolution>();
        protected List<ContentItem> _contentItems;
        protected SourceGrid.Cells.Controllers.CustomEvents _checkBoxEvent = new SourceGrid.Cells.Controllers.CustomEvents();
        protected static ILog _log = LogManager.GetLogger(typeof(FormNewHAnalysis));
        protected List<BoxProperties> lBoxes = new List<BoxProperties>();
        #endregion
    }
}