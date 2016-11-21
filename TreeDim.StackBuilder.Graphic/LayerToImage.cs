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
        public static Bitmap Draw(Layer2D layer, Packable packable, double height, Size size, bool selected)
        {
            Graphics2DImage graphics = new Graphics2DImage(size);
            PackableBrick packableBrick = packable as PackableBrick;
            if (null != packableBrick)
            {
                using (SolutionViewerLayer solViewer = new SolutionViewerLayer(layer))
                { solViewer.Draw(graphics, packableBrick, height, selected); }
            }
            return graphics.Bitmap;
        }
    }
}
