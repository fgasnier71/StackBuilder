#region Using directives
using System;
using System.Drawing;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class BitmapHelpers
    {
        public static Bitmap Crop(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            bool AllWhiteRow(int row)
            {
                Color color;
                for (int i = 0; i < w; ++i)
                {
                    color = bmp.GetPixel(i, row);
                    if (color.R != 255 || color.G != 255 || color.B != 255)
                        return false;
                }

                return true;
            }

            bool AllWhiteColumn(int col)
            {
                Color color;
                for (int i = 0; i < h; ++i)
                {
                    color = bmp.GetPixel(col, i); 
                    if (color.R != 255 || color.G != 255 || color.B != 255)
                        return false;
                }

                return true;
            }

            int topmost = 0;
            for (int row = 0; row < h; ++row)
            {
                if (AllWhiteRow(row))
                    topmost = row;
                else break;
            }

            int bottommost = 0;
            for (int row = h - 1; row >= 0; --row)
            {
                if (AllWhiteRow(row))
                    bottommost = row;
                else break;
            }

            int leftmost = 0, rightmost = 0;
            for (int col = 0; col < w; ++col)
            {
                if (AllWhiteColumn(col))
                    leftmost = col;
                else
                    break;
            }

            for (int col = w - 1; col >= 0; --col)
            {
                if (AllWhiteColumn(col))
                    rightmost = col;
                else
                    break;
            }

            if (rightmost == 0) rightmost = w; // As reached left
            if (bottommost == 0) bottommost = h; // As reached top.

            int croppedWidth = rightmost - leftmost;
            int croppedHeight = bottommost - topmost;

            if (croppedWidth == 0) // No border on left or right
            {
                leftmost = 0;
                croppedWidth = w;
            }

            if (croppedHeight == 0) // No border on top or bottom
            {
                topmost = 0;
                croppedHeight = h;
            }

            try
            {
                var target = new Bitmap(croppedWidth, croppedHeight);
                using (var g = System.Drawing.Graphics.FromImage(target))
                {
                    g.DrawImage(bmp,
                      new RectangleF(0, 0, croppedWidth, croppedHeight),
                      new RectangleF(leftmost, topmost, croppedWidth, croppedHeight),
                      GraphicsUnit.Pixel);
                }
                return target;
            }
            catch (Exception ex)
            {
                throw new Exception(
                    $"Values are topmost={topmost} btm={bottommost} left={leftmost} right={rightmost} croppedWidth={croppedWidth} croppedHeight={croppedHeight}",
                  ex);
            }
        }
    }
}
