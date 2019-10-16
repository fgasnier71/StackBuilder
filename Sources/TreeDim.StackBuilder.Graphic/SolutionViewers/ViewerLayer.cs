#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class ViewerILayer2D : IDisposable
    {
        #region Data members
        private ILayer2D _layer;
        private static int _fontSize = 9;
        #endregion

        #region Constructor
        public ViewerILayer2D(ILayer2D layer)
        {
            _layer = layer;
        }
        #endregion

        #region Implementation IDispose
        public void Dispose()
        { 
        }
        #endregion

        #region Public methods
        public void Draw(Graphics2D graphics, Packable packable, double height, bool selected, bool annotate)
        {
            graphics.NumberOfViews = 1;
            graphics.Clear(selected ? Color.LightBlue : Color.White);
            graphics.SetViewport(0.0f, 0.0f, (float)_layer.Length, (float)_layer.Width);
            graphics.SetCurrentView(0);
            graphics.DrawRectangle(Vector2D.Zero, new Vector2D(_layer.Length, _layer.Width), Color.Black);

            // draw layer (brick)
            if (_layer is Layer2D)
            {
                Layer2D layer2D = _layer as Layer2D;
                uint pickId = 0;
                foreach (var bPosition in layer2D)
                {
                    Box b = null;
                    if (packable is PackProperties)
                        b = new Pack(pickId++, packable as PackProperties, bPosition);
                    else if (packable is PackableBrick)
                        b = new Box(pickId++, packable as PackableBrick, bPosition);
                    if (null != b)
                        b.Draw(graphics);
                }
            }
            // draw layer (cylinder)
            else if (_layer is Layer2DCyl)
            {
                Layer2DCyl layer2DCyl = _layer as Layer2DCyl;
                uint pickId = 0;
                foreach (Vector2D pos in layer2DCyl)
                {
                    Cylinder c = new Cylinder(pickId++, packable as CylinderProperties, new CylPosition(new Vector3D(pos.X, pos.Y, 0.0), HalfAxis.HAxis.AXIS_Z_P));
                    graphics.DrawCylinder(c);
                }
            }
            // draw axes
            bool showAxis = false;
            if (showAxis)
            {
                // draw axis X
                graphics.DrawLine(Vector2D.Zero, new Vector2D(_layer.Length, 0.0), Color.Red);
                // draw axis Y
                graphics.DrawLine(Vector2D.Zero, new Vector2D(0.0, _layer.Width), Color.Green);
            }
            // annotate thumbnail
            if (annotate)
                Annotate(graphics.Graphics, graphics.Size, height);
        }
        public void Draw(Graphics3D graphics, Packable packable, double height, bool selected, bool annotate)
        {
            graphics.BackgroundColor = selected ? Color.LightBlue : Color.White;
            graphics.CameraPosition = Graphics3D.Corner_0;

            // draw layer (brick)
            if (_layer is Layer2D)
            {
                Layer2D layer2D = _layer as Layer2D;
                uint pickId = 0;
                foreach (var bPosition in layer2D)
                {
                    if (packable is PackProperties)
                        graphics.AddBox( new Pack(pickId++, packable as PackProperties, bPosition) );
                    else if (packable is PackableBrick)
                        graphics.AddBox( new Box(pickId++, packable as PackableBrick, bPosition) );
                }
            }
            // draw layer (cylinder)
            else if (_layer is Layer2DCyl)
            {
                Layer2DCyl layer2DCyl = _layer as Layer2DCyl;
                uint pickId = 0;
                foreach (Vector2D pos in layer2DCyl)
                {
                    Cylinder c = new Cylinder(pickId++, packable as CylinderProperties, new CylPosition(new Vector3D(pos.X, pos.Y, 0.0), HalfAxis.HAxis.AXIS_Z_P));
                    graphics.AddCylinder(c);
                }
            }
            graphics.Flush();
            // annotate thumbnail
            if (annotate)
                Annotate(graphics.Graphics, graphics.Size, height);
        }
        #endregion

        #region Private methods
        private void Annotate(System.Drawing.Graphics g, Size s, double height)
        {
            // *** Annotate : begin ***
            if (height > 0)
            {
                string annotation = string.Format(
                    "{0}*{1}={2}"
                    , _layer.Count
                    , _layer.NoLayers(height)
                    , _layer.CountInHeight(height));
                Font tfont = new Font("Arial", _fontSize);
                Color brushColor = Color.White;
                Color backgroundColor = Color.Black;
                StringFormat sf = new StringFormat
                {
                    Alignment = StringAlignment.Far,
                    LineAlignment = StringAlignment.Far
                };
                Size txtSize = g.MeasureString(annotation, tfont).ToSize();
                g.FillRectangle(new SolidBrush(backgroundColor), new Rectangle(s.Width - txtSize.Width - 2, s.Height - txtSize.Height - 2, txtSize.Width + 2, txtSize.Height + 2));
                g.DrawString(annotation, tfont, new SolidBrush(brushColor), new Point(s.Width - 3, s.Height - 3), sf);
            }
            // *** Annotate : end ***
        }
        #endregion
    }
}
