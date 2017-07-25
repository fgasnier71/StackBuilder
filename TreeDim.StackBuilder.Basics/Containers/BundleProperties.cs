using System;
using System.Collections.Generic;
using System.Drawing;

namespace treeDiM.StackBuilder.Basics
{
    public class BundleProperties : BProperties
    {
        public BundleProperties(Document document, string name, string description,
            double length, double width
            , double unitThickness
            , double unitWeight
            , int noFlats
            , Color color)
            : base(document, name, description)
        {
            _length = length;
            _width = width;
            _unitThickness = unitThickness;
            _unitWeight = unitWeight;
            _noFlats = noFlats;
            _color = color;
        }

        public override double Height => _unitThickness * _noFlats;
        public override double Weight => _unitWeight * _noFlats;
        public override OptDouble NetWeight => new OptDouble(false, 0.0);
        public override bool OrientationAllowed(HalfAxis.HAxis axis) =>
            (axis == HalfAxis.HAxis.AXIS_Z_N) || (axis == HalfAxis.HAxis.AXIS_Z_P);
        public override bool IsCase => false;

        // TODO - use either property or "accessor methods", not both
        public Color Color
        {
            get { return _color; }
            set { _color = value; Modify(); }
        }

        public override Color[] Colors
        {
            get
            {
                Color[] colors = new Color[6];
                for (int i = 0; i < 6; ++i)
                    colors[i] = _color;
                return colors;
            }
        }
        // TODO - use either property or "accessor methods", not both
        public override Color GetColor(HalfAxis.HAxis axis)
        {
            return _color;
        }
        // TODO - use either property or "accessor methods", not both
        public override void SetColor(Color color)
        {
            _color = color;
        }

        public double UnitThickness
        {
            get { return _unitThickness; }
            set { _unitThickness = value; Modify(); }
        }
        public double UnitWeight
        {
            get { return _unitWeight; }
            set { _unitWeight = value; Modify(); }
        }
        public int NoFlats
        {
            get { return _noFlats; }
            set { _noFlats = value; Modify(); }
        }

        public override bool IsBundle => true;

        #region Non-Public Members

        private double _unitThickness = 0.0, _unitWeight = 0.0;
        private int _noFlats;
        private Color _color;

        protected override string TypeName => Properties.Resources.ID_NAMEBUNDLE;

        #endregion

    }
}
