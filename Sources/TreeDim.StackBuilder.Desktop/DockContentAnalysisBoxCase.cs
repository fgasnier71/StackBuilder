#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

// Docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;
// Sharp3D
using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisBoxCase : DockContentAnalysisEdit
    {
        #region Data members
        #endregion

        #region Constructor
        public DockContentAnalysisBoxCase()
            : base()
        {
            InitializeComponent();
        }
        public DockContentAnalysisBoxCase(IDocument document, Analysis analysis)
            : base(document, analysis)
        {
            InitializeComponent();
        }
        #endregion
 
        #region Form override
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        #endregion

        #region Override DockContentAnalysisEdit
        public override string GridCaption
        {   get { return Resources.ID_CASE; } }
        public override void FillGrid()
        {
            // clear grid
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;
        }
        public override void UpdateGrid()
        {
            // remove all existing rows
            gridSolutions.Rows.Clear();
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
            captionHeader.Font = new Font("Arial", 9, FontStyle.Bold);
            captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            // viewRowHeader
            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader()
            {
                BackColor = Color.LightGray,
                Border = DevAge.Drawing.RectangleBorder.NoBorder
            };
            viewRowHeader.Background = backHeader;
            viewRowHeader.ForeColor = Color.Black;
            viewRowHeader.Font = new Font("Arial", 9, FontStyle.Regular);
            // viewNormal
            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);
            // ***
            
            SourceGrid.Cells.RowHeader rowHeader;
            int iRow = -1;
            // case caption
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_CASECOUNT)
            {
                ColumnSpan = 2,
                View = captionHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            // layer #
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_LAYERCOUNT)
            {
                View = viewRowHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
            // interlayer #
            if (_solution.InterlayerCount > 0)
            {
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_INTERLAYERCOUNT)
                {
                    View = viewRowHeader
                };
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
            }
            // *** Item # (recursive count)
            Packable content = _analysis.Content;
            int itemCount = _solution.ItemCount;
            int number = 1;
            do
            {
                itemCount *= number;
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(string.Format("{0} #", content.DetailedName))
                {
                    View = viewRowHeader
                };
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
            }
            while (null != content && content.InnerContent(ref content, ref number));
            // ***
            // load dimensions
            BBox3D bboxLoad = _solution.BBoxLoad;
            // ---
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(
                string.Format(Resources.ID_LOADDIMENSIONS, UnitsManager.LengthUnitString))
            {
                View = viewRowHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#} x {1:0.#} x {2:0.#}", bboxLoad.Length, bboxLoad.Width, bboxLoad.Height));
            // net weight
            if (_solution.HasNetWeight)
            {
                rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format(Resources.ID_NETWEIGHT_WU, UnitsManager.MassUnitString))
                {
                    View = viewRowHeader
                };
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.NetWeight));
            }
            // load weight
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(
                string.Format(Resources.ID_LOADWEIGHT_WU, UnitsManager.MassUnitString))
            {
                View = viewRowHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LoadWeight));
            // total weight
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(
                string.Format(Resources.ID_TOTALWEIGHT_WU, UnitsManager.MassUnitString))
            {
                View = viewRowHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.Weight));
            // volume efficiency
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader(Resources.ID_VOLUMEEFFICIENCY)
            {
                View = viewRowHeader
            };
            gridSolutions[iRow, 0] = rowHeader;
            gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.VolumeEfficiency));

            int noLayerTypesUsed = 0;
            for (int i = 0; i < _solution.Layers.Count; ++i)
                noLayerTypesUsed += _solution.Layers[i].BoxCount > 0 ? 1 : 0;

            // ### layers : begin
            for (int i = 0; i < _solution.NoLayerTypesUsed; ++i)
            {
                // layer caption
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(_solution.LayerCaption(i))
                {
                    ColumnSpan = 2,
                    View = captionHeader
                };
                gridSolutions[iRow, 0] = rowHeader;

                // *** Item # (recursive count)
                content = _analysis.Content;
                itemCount = _solution.LayerBoxCount(i);
                number = 1;
                do
                {
                    itemCount *= number;

                    gridSolutions.Rows.Insert(++iRow);
                    rowHeader = new SourceGrid.Cells.RowHeader(
                        string.Format("{0} #", content.DetailedName))
                    {
                        View = viewRowHeader
                    };
                    gridSolutions[iRow, 0] = rowHeader;
                    gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(itemCount);
                }
                while (null != content && content.InnerContent(ref content, ref number));
                // ***

                // layer weight
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(string.Format(Resources.ID_WEIGHT_WU, UnitsManager.MassUnitString))
                {
                    View = viewRowHeader
                };
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerWeight(i)));
                // layer space
                gridSolutions.Rows.Insert(++iRow);
                rowHeader = new SourceGrid.Cells.RowHeader(string.Format(Resources.ID_SPACES_WU, UnitsManager.LengthUnitString))
                {
                    View = viewRowHeader
                };
                gridSolutions[iRow, 0] = rowHeader;
                gridSolutions[iRow, 1] = new SourceGrid.Cells.Cell(
                    string.Format(CultureInfo.InvariantCulture, "{0:0.#}", _solution.LayerMaximumSpace(i)));
            }

            gridSolutions.AutoSizeCells();
            gridSolutions.Columns.StretchToFit();
            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.Invalidate();
        }
        #endregion
    }
}
