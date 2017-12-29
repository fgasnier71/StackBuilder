#region Using directives
using System;
using System.Drawing;

using log4net;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class LayerToImage
    {
        #region Enums
        public enum EGraphMode { GRAPH_2D, GRAPH_3D };
        #endregion
        #region Drawing
        public static Bitmap Draw(ILayer2D layer, Packable packable, double height, Size size, bool selected, EGraphMode eMode, bool annotate)
        {
            if (EGraphMode.GRAPH_2D == eMode)
            {
                Graphics2DImage graphics = new Graphics2DImage(size);
                using (ViewerILayer2D solViewer = new ViewerILayer2D(layer))
                { solViewer.Draw(graphics, packable, height, selected, annotate); }
                return graphics.Bitmap;
            }
            else
            {
                Graphics3DImage graphics = new Graphics3DImage(size) { MarginPercentage = 0.05 };
                using (ViewerILayer2D solViewer = new ViewerILayer2D(layer))
                { solViewer.Draw(graphics, packable, height, selected, annotate); }
                return graphics.Bitmap;
            }
        }
        public static Bitmap DrawEx(ILayer2D layer, Packable packable, double height, Size size, bool selected, EGraphMode eMode, bool annotate)
        {
            try
            {
                return LayerToImage.Draw(layer, packable, height, size, selected, eMode, annotate);
            }
            catch (Exception ex)
            {
                _log.Error(ex.ToString());
                return Properties.Resources.QuestionMark;
            }
        }
        #endregion

        #region Data members
        private static ILog _log = LogManager.GetLogger(typeof(LayerToImage));
        #endregion
    }
}
