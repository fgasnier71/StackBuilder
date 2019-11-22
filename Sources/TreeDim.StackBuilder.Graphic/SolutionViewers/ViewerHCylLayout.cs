#region Using directives
using System;
using System.Drawing;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerHCylLayout : IDisposable
    {
        public ViewerHCylLayout(HCylLayout cylLayout)
        {
            Layout = cylLayout;
        }
        public void Draw(Graphics3D graphics, CylinderProperties cylProperties, double height, bool selected, bool annotate)
        {
            graphics.BackgroundColor = selected ? Color.LightBlue : Color.White;
            graphics.CameraPosition = Graphics3D.Corner_0;

            uint pickId = 0;
            foreach (var cp in Layout.Positions)
            {   graphics.AddCylinder(new Cylinder(pickId++, cylProperties, cp)) ;  }
            graphics.Flush();

            if (annotate)
                Annotate(graphics.Graphics, graphics.Size, height);
        }

        public void Dispose()
        {
        }
        #region Private methods
        private void Annotate(System.Drawing.Graphics g, Size s, double height)
        {
            // *** Annotate : begin ***
            if (height > 0)
            {
                string annotation = $"{Layout.Positions.Count}";
                Font tfont = new Font("Arial", FontSize);
                Size txtSize = g.MeasureString(annotation, tfont).ToSize();
                StringFormat sf = new StringFormat { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far };
                g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(s.Width - txtSize.Width - 2, s.Height - txtSize.Height - 2, txtSize.Width + 2, txtSize.Height + 2));
                g.DrawString(annotation, tfont, new SolidBrush(Color.White), new Point(s.Width - 3, s.Height - 3), sf);
            }
            // *** Annotate : end ***

        }
        #endregion

        private HCylLayout Layout { get; set; }
        private static int FontSize { get; set; } = 9;
    }
}
