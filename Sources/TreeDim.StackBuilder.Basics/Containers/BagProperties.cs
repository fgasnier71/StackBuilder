#region Using directives
using Sharp3D.Math.Core;
using System.Drawing;
using System.Linq;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class BagProperties : BProperties
    {
        #region Constructor
        public BagProperties(Document doc) : base(doc)
        {
            _length = 0.0; _width = 0.0; _height = 0.0;
        }
        public BagProperties(Document doc, string name, string description,
            double length, double width, double height, double radius)
            : base(doc, name, description)
        {
            _length = length; _width = width; _height = height;
            Radius = new double[] { radius, 0.5 * length, 0.5 * width, 0.5 * height }.Min();
        }
        public BagProperties(Document doc, string name, string description,
            Vector3D dimensions, double radius)
            : base(doc, name, description)
        {
            _length = dimensions.X; _width = dimensions.Y; _height = dimensions.Z;
            Radius = new double[] { radius, 0.5 * _length, 0.5 * _width, 0.5 * _height }.Min();
        }
        #endregion

        #region Specific properties
        public double Radius { get; set; }
        public Color ColorFill { get; set; }
        #endregion

        #region Specific methods
        public void SetHeight(double height) { _height = height; Modify(); }
        #endregion

        #region Override BProperties
        public override Color[] Colors => Enumerable.Repeat(ColorFill, 6).ToArray();
        public override bool IsBundle => false;
        public override double Height => _height;
        protected override string TypeName => Properties.Resources.ID_NAMEBAG;
        public override Color GetColor(HalfAxis.HAxis axis) => ColorFill;
        public override void SetColor(Color color) => ColorFill = color;
        #endregion

        #region Data members
        private double _height;
        #endregion
    }
}
