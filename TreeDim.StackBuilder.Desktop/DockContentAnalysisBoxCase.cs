#region Using directives
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// Docking
using WeifenLuo.WinFormsUI.Docking;
// log4net
using log4net;

using Sharp3D.Math.Core;
using treeDiM.StackBuilder.Basics;
using treeDiM.StackBuilder.Graphics;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    public partial class DockContentAnalysisBoxCase : DockContentAnalysisEdit
    {
        #region Data members
        /// <summary>
        /// logger
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(DockContentAnalysisBoxCase));
        #endregion

        #region Constructor
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
            // text
            this.Text = _analysis.Name + " - " + _analysis.ParentDocument.Name;
        }
        #endregion

        #region Override DockContentAnalysisEdit
        public override void FillGrid()
        {
            // clear grid
            gridSolutions.Rows.Clear();
            // border
            gridSolutions.BorderStyle = BorderStyle.FixedSingle;
            gridSolutions.ColumnsCount = 2;
            gridSolutions.FixedColumns = 1;

            // header
            SourceGrid.Cells.RowHeader rowHeader;

            SourceGrid.Cells.Views.RowHeader viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
            DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader();
            backHeader.BackColor = Color.LightGray;
            backHeader.Border = DevAge.Drawing.RectangleBorder.NoBorder;
            viewRowHeader.Background = backHeader;
            viewRowHeader.ForeColor = Color.Black;
            viewRowHeader.Font = new Font("Arial", 10, FontStyle.Regular);

            int iRow = -1;
            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Layer #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Interlayer #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

            gridSolutions.Rows.Insert(++iRow);
            rowHeader = new SourceGrid.Cells.RowHeader("Case #");
            rowHeader.View = viewRowHeader;
            gridSolutions[iRow, 0] = rowHeader;

        }
        public override void UpdateGrid()
        {
            if (gridSolutions.ColumnsCount < 2 && gridSolutions.Rows.Count < 4)
                return;

            CellBackColorAlternate viewNormal = new CellBackColorAlternate(Color.LightBlue, Color.White);

            BBox3D bboxGlobal = _solution.BBoxGlobal;
            BBox3D bboxLoad = _solution.BBoxLoad;
            int iRow = 0;

            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.LayerCount);
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.InterlayerCount);
            gridSolutions[iRow++, 1] = new SourceGrid.Cells.Cell(_solution.ItemCount);

            for (int i = 0; i < iRow; ++i)
            {
                gridSolutions[i, 1].View = viewNormal;
                gridSolutions[i, 1].View.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
            }

            gridSolutions.AutoStretchColumnsToFitWidth = true;
            gridSolutions.AutoSizeCells();
            gridSolutions.Invalidate();
        }
        #endregion
    }
}
