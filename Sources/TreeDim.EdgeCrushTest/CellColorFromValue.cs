using System;
using System.Drawing;

using log4net;

namespace treeDiM.EdgeCrushTest
{
    #region CellColorFromValue for grid view
    internal class CellColorFromValue : SourceGrid.Cells.Views.Cell
    {
        #region Data members
        private double _lowestAdmissibleValue;
        #endregion
        #region Constructor
        public CellColorFromValue(double lowestAdmissibleValue)
        {
            _lowestAdmissibleValue = lowestAdmissibleValue;
            correctValueBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(Color.White);
            insufficientValueBackground = new DevAge.Drawing.VisualElements.BackgroundSolid(Color.Red);
        }
        #endregion
        #region Public properties
        public DevAge.Drawing.VisualElements.IVisualElement correctValueBackground { get; set; }
        public DevAge.Drawing.VisualElements.IVisualElement insufficientValueBackground { get; set; }
        #endregion
        #region SourceGrid.Cells.Views.Cell override
        protected override void PrepareView(SourceGrid.CellContext context)
        {
            base.PrepareView(context);
            string sText = context.DisplayText;
            // sTest might not be a number
            // -> exceptions might be thrown when attempting to parse it
            try
            {
                double doubleValue = double.Parse(sText);
                if (doubleValue < _lowestAdmissibleValue)
                    Background = insufficientValueBackground;
                else
                    Background = correctValueBackground;
            }
            catch (System.Exception ex)
            {
                _log.Error(ex.ToString());
            }
        }
        #endregion

        #region Data members
        static readonly ILog _log = LogManager.GetLogger(typeof(CellColorFromValue));
        #endregion
    }
    #endregion

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
}
