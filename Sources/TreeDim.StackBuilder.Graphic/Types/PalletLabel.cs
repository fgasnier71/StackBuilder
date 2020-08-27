#region Using directives
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

using treeDiM.StackBuilder.Basics;
#endregion

namespace treeDiM.StackBuilder.Graphics
{
    public class PalletLabel : Drawable
    {
        public PalletLabel(uint pickId, PalletLabelProperties label, BoxPosition boxPosition)
            : base(pickId)
        {
            Dimensions = label.Dimensions;
            Color = label.Color;
            Bitmap = label.Bitmap;
            BoxPosition = boxPosition;
        }
        public override Vector3D[] Points
        {
            get
            {
                var points = new Vector3D[4];
                points[0] = Position;
                points[1] = Position + Dimensions.X * LengthAxis;
                points[2] = Position + Dimensions.X * LengthAxis + Dimensions.Y * WidthAxis;
                points[3] = Position + Dimensions.Y * WidthAxis;
                return points;
            }
        }
        public virtual Face Face
        {
            get
            {
                var points = Points;
                var face = new Face(PickId, new Vector3D[] { points[1], points[0], points[3], points[2] }) { ColorFill = Color, ColorPath = Color.Black  };
                if (null != Bitmap)
                    face.Textures = new List<Texture>() { new Texture(Bitmap, Vector2D.Zero, Dimensions, 0.0) };
                return face;
            }
        }
        public override void Draw(Graphics3D graphics)
        {
            graphics.Draw(Face, Graphics3D.FaceDir.FRONT);
        }

        private Vector2D Dimensions { get; set; }
        private Bitmap Bitmap { get; set; }
        private Color Color { get; set; }
        private BoxPosition BoxPosition { get; set; } = BoxPosition.Zero;
        private Vector3D Position => BoxPosition.Position;
        private Vector3D LengthAxis => HalfAxis.ToVector3D(BoxPosition.DirectionLength);
        private Vector3D WidthAxis => HalfAxis.ToVector3D(BoxPosition.DirectionWidth);

    }
}
