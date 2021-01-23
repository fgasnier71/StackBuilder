#region Using directives
using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    internal class ViewerLayeredBoxes : IDisposable
    {
        public ViewerLayeredBoxes(Vector2D dim)
        {
            Dimensions = dim;
        }
        public void Draw(Graphics2D graphics, IEnumerable<Box> boxes, bool selected, bool annotate)
        {
            graphics.NumberOfViews = 1;
            graphics.Clear(selected ? Color.LightBlue : Color.White);
            graphics.SetViewport(0.0f, 0.0f, (float)Dimensions.X, (float)Dimensions.Y);
            graphics.SetCurrentView(0);
            graphics.DrawRectangle(Vector2D.Zero, Dimensions, Color.Black);

            foreach (var b in boxes)
            {
                b.Draw(graphics);
            }

            // annotate thumbnail
            if (annotate)
                Annotate(graphics.Graphics, graphics.Size);

        }
        public void Draw(Graphics3D graphics, IEnumerable<Box> boxes, bool selected, bool annotate)
        {
            graphics.BackgroundColor = selected ? Color.LightBlue : Color.White;
            graphics.CameraPosition = Graphics3D.Corner_0;
            // draw boxes
            foreach (var box in boxes)
                graphics.AddBox(box);
            graphics.Flush();
            if (annotate)
                Annotate(graphics.Graphics, graphics.Size);
        }

        private void Annotate(System.Drawing.Graphics g, Size s)
        {
            Font tFont = new Font("Arial", FontSize);
            StringFormat sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };
            string annotation = $"{LayerNumber}";
            Size txtSize = g.MeasureString(annotation, tFont).ToSize();
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(s.Width - txtSize.Width - 2, s.Height - txtSize.Height - 2, txtSize.Width + 2, txtSize.Height + 2));
            g.DrawString(annotation, tFont, new SolidBrush(Color.White), new Point(s.Width - 3, s.Height - 3), sf);
        }

        public void Dispose() {}

        public Vector2D Dimensions { get; set; }
        public int LayerNumber { get; set; }
        public static int FontSize { get; set; } = 9;
    }
}
