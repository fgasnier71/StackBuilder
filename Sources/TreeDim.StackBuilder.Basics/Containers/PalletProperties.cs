#region Using directives
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletProperties : ItemBaseNamed, IContainer
    {
        public PalletProperties(Document document, string typeName, double length, double width, double height)
            : base(document)
        {
            _typeName = typeName;
            _length = length;
            _width = width;
            _height = height;
        }
        public double Length
        {
            get { return _length; }
            set { _length = value; Modify(); }
        }
        public double Width
        {
            get { return _width; }
            set { _width = value; Modify(); }
        }
        public double Height
        {
            get { return _height; }
            set { _height = value; Modify(); }
        }
        public double Weight
        {
            get { return _weight; }
            set { _weight = value; Modify(); }
        }
        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; Modify(); }
        }
        public double AdmissibleLoadHeight
        {
            get { return _admissibleLoadHeight; }
            set { _admissibleLoadHeight = value; Modify(); }
        }
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; Modify(); }
        }
        public Color Color
        {
            get { return _color; }
            set { _color = value; Modify(); }
        }

        #region Computed properties
        public double[] Dimensions => new double[] { Length, Width, Height };
        public BBox3D BoundingBox => new BBox3D(Vector3D.Zero, new Vector3D(Length, Width, Height));
        #endregion

        #region IContainer implementation
        public Vector3D GetOffset(ConstraintSetAbstract constraintSet)
        {
            if (!(constraintSet is ConstraintSetPackablePallet constraintSetPackablePallet))
                throw new InvalidConstraintSetException();
            return new Vector3D(-constraintSetPackablePallet.Overhang.X, -constraintSetPackablePallet.Overhang.Y, Height);
        }
        public Vector3D GetStackingDimensions(ConstraintSetAbstract constraintSet)
        {
            if (!(constraintSet is ConstraintSetPackablePallet constraintSetPackablePallet))
                throw new InvalidConstraintSetException();
            double stackingHeight = 0.0;
            if (constraintSetPackablePallet.OptMaxHeight.Activated)
                stackingHeight = constraintSetPackablePallet.OptMaxHeight.Value - Height;

            return new Vector3D(
                _length + 2.0 * constraintSetPackablePallet.Overhang.X
                , _width + 2.0 * constraintSetPackablePallet.Overhang.Y
                , stackingHeight);
        }
        #endregion

        public override string ToString()
        {
            var sBuilder = new System.Text.StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append($"PalletProperties => Type {TypeName} ({Length} x {Width} x {Height})");
            return sBuilder.ToString();
        }

        #region Non-Public Members
        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        Color _color = Color.Yellow;
        string _typeName = "Block";
        #endregion
    }
}
