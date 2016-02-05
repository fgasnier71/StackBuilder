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
        public static Bitmap Draw(Layer2D layer, Size size)
        {
            Graphics2DImage graphics = new Graphics2DImage(size);

            // draw all boxes


            return graphics.Bitmap;
        }
    }
}
