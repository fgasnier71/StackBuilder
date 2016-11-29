#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class LayerToImage
    {
        #region Enums
        public enum eGraphMode { GRAPH_2D, GRAPH_3D };
        #endregion
        #region Drawing
        public static Bitmap Draw(ILayer2D layer, Packable packable, double height, Size size, bool selected, eGraphMode eMode)
        {
            if (eGraphMode.GRAPH_2D == eMode)
            {
                Graphics2DImage graphics = new Graphics2DImage(size);
                using (SolutionViewerLayer solViewer = new SolutionViewerLayer(layer))
                { solViewer.Draw(graphics, packable, height, selected); }
                return graphics.Bitmap;
            }
            else
            {
                Graphics3DImage graphics = new Graphics3DImage(size);
                graphics.MarginPercentage = 0.05;
                using (SolutionViewerLayer solViewer = new SolutionViewerLayer(layer))
                { solViewer.Draw(graphics, packable, height, selected); }
                return graphics.Bitmap;
            }
        }
        #endregion
    }
}
