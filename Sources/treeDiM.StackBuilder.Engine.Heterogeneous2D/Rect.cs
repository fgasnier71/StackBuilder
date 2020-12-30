#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace treeDiM.StackBuilder.Engine.Heterogeneous2D
{
    public struct RectSize
    {
        public RectSize(int width, int height) { Width = width; Height = height; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public struct Rect
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public static bool IsContainedIn(Rect a, Rect b)
        {
            return a.X >= b.X && a.Y >= b.Y
                && a.X + a.Width <= b.X + b.Width
                && a.Y + a.Height <= b.Y + b.Height;
        }
    }
}
