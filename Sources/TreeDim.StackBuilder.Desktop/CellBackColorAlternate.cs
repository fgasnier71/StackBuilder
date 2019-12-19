#region Using directives
using System;
using System.Drawing;

using treeDiM.StackBuilder.Desktop.Properties;
#endregion

namespace treeDiM.StackBuilder.Desktop
{
    internal class CellBackColorAlternate : SourceGrid.Cells.Views.Cell
    {
        public CellBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }
        public DevAge.Drawing.VisualElements.IVisualElement FirstBackground { get; set; }
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground { get; set; }

        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);

            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }
    internal class CheckboxBackColorAlternate : SourceGrid.Cells.Views.CheckBox
    {
        public CheckboxBackColorAlternate(Color firstColor, Color secondColor)
        {
            FirstBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(firstColor);
            SecondBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(secondColor);
        }
        public DevAge.Drawing.VisualElements.IVisualElement FirstBackground { get; set; }
        public DevAge.Drawing.VisualElements.IVisualElement SecondBackground { get; set; }

        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);

            if (Math.IEEERemainder(context.Position.Row, 2) == 0)
                Background = FirstBackground;
            else
                Background = SecondBackground;
        }
    }

    internal class CellProperties
    {
        public static SourceGrid.Cells.Views.RowHeader VisualPropHeader
        {
            get
            {
                if (null == _captionHeader)
                {
                    _captionHeader = new SourceGrid.Cells.Views.RowHeader();
                    DevAge.Drawing.VisualElements.RowHeader veHeaderCaption = new DevAge.Drawing.VisualElements.RowHeader()
                    {
                        BackColor = Color.SteelBlue,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder,
                    };
                    _captionHeader.Background = veHeaderCaption;
                    _captionHeader.ForeColor = Color.Black;
                    _captionHeader.Font = new Font("Arial", GridFontSize, FontStyle.Bold);
                    _captionHeader.TextAlignment = DevAge.Drawing.ContentAlignment.MiddleCenter;
                }
                return _captionHeader;
            }
        }
        public static SourceGrid.Cells.Views.RowHeader VisualPropValue
        {
            get
            {
                if (null == _viewRowHeader)
                {
                    _viewRowHeader = new SourceGrid.Cells.Views.RowHeader();
                    DevAge.Drawing.VisualElements.RowHeader backHeader = new DevAge.Drawing.VisualElements.RowHeader()
                    {
                        BackColor = Color.LightGray,
                        Border = DevAge.Drawing.RectangleBorder.NoBorder
                    };
                    _viewRowHeader.Background = backHeader;
                    _viewRowHeader.ForeColor = Color.Black;
                    _viewRowHeader.Font = new Font("Arial", GridFontSize, FontStyle.Regular);
                }
                return _viewRowHeader;
            }
        }

        private static SourceGrid.Cells.Views.RowHeader _captionHeader, _viewRowHeader;
        private static int GridFontSize => Settings.Default.GridFontSize;
    }
}
