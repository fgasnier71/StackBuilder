#region Using directives
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public static class LayeredCrateToImage
    {
        #region Drawing
        public static Bitmap Draw(IEnumerable<Box> boxes, Vector3D dimensions, bool selected, Size size)
        {
            var graphics = new Graphics3DImage(size) { MarginPercentage = 0.05 };
            graphics.SetViewport(-500.0f, -500.0f, 500.0f, 500.0f);
            using (var viewer = new ViewerHLayeredCrate(dimensions))
                viewer.Draw(graphics, boxes, selected);
            return graphics.Bitmap;
        }
        #endregion
    }
}
