#region Using directives
using Sharp3D.Math.Core;

using System.Drawing;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletLabelProperties : ItemBaseNamed
    {
        #region Constructors
        public PalletLabelProperties(Document doc)
            : base(doc)
        { 
        }
        public PalletLabelProperties(Document doc, string name, string description,
            Vector2D dimensions, Color color, Bitmap bmp)
            : base(doc, name, description)
        {
            Dimensions = dimensions;
            Color = color;
            Bitmap = bmp;
        }
        #endregion

        #region Public properties
        public Vector2D Dimensions { get; set; }
        public Color Color { get; set; } = Color.White;
        public Bitmap Bitmap { get; set; }
        #endregion
    }

    public class PalletLabelInst
    {
        public PalletLabelInst(PalletLabelProperties palletLabelProperties, Vector2D position, HalfAxis.HAxis side)
        {
            PalletLabelProperties = palletLabelProperties;
            Position = position;
            Side = side;
        }
        public PalletLabelProperties PalletLabelProperties { get; set; }
        public Vector2D Position { get; set; }
        public HalfAxis.HAxis Side { get; set; }
    }
}
