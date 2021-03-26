#region Using directives
using System;
using System.Drawing;
using System.Collections.Generic;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ImageTiling
    {
        public static Size TileSize(Size imageSize, int number) => new Size(imageSize.Width / Columns(number), imageSize.Height / Rows(number));
        public static int Columns(int number)
        {
            int sr = (int)Math.Floor(Math.Sqrt(number));
            if (number > sr) return sr + 1; else return sr;
        }
        public static int Rows(int number)
        {
            int cols = Columns(number);
            return number / cols + ((number % cols == 0) ? 0 : 1);
        }

        public static Bitmap TileImage(Size imageSize, List<Bitmap> bitmaps)
        {
            var resBitmap = new Bitmap(imageSize.Width, imageSize.Height);
            var graphics = System.Drawing.Graphics.FromImage(resBitmap);

            int index = 0;
            foreach (var bmp in bitmaps)
            {
                graphics.DrawImage(bmp, DestRectangle(imageSize, bitmaps.Count, index));
                ++index;
            }
            return resBitmap;
        }

        public static Rectangle DestRectangle(Size imageSize, int number, int index)
        {
            int rows = Rows(number);
            int cols = Columns(number);

            int rowIndex = index / cols;
            int colIndex = index - rowIndex * cols;

            Size tileSize = TileSize(imageSize, number);

            return new Rectangle(colIndex * tileSize.Width, rowIndex * tileSize.Height, tileSize.Width, tileSize.Height);
        }
    }
}
