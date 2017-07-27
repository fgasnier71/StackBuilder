using System;
using System.Collections.Generic;
using System.Drawing;

using Sharp3D.Math.Core;

namespace treeDiM.StackBuilder.Basics
{
    public class TruckProperties : ItemBaseNamed, IPackContainer
    {
        public TruckProperties(Document document)
            : base(document)
        { 
        }

        public TruckProperties(Document document, double length, double width, double height)
            : base(document)
        {
            _length = length;
            _width = width;
            _height = height;
        }

        public double AdmissibleLoadWeight
        {
            get { return _admissibleLoadWeight; }
            set { _admissibleLoadWeight = value; Modify(); }
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
        public double Volume
        {
            get { return _length * _width * _height; }
        }
        public Color Color
        {
            get { return _color;  }
            set { _color = value; Modify();}
        }

        public bool HasInsideDimensions => true;
        public double InsideLength => _length;
        public double InsideWidth => _width;
        public double InsideHeight => _height;
        public Vector3D InsideDimensions => new Vector3D(_length, _width, _height);
        public double[] InsideDimensionsArray => new double[3] { _length, _width, _height };

        public override string ToString()
        {
            var sBuilder = new System.Text.StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("TruckProperties => Length {0} Width {0} Height {0}", _length, _width, _height));
            return sBuilder.ToString();
        }

        #region Non-Public Members

        private double _admissibleLoadWeight;
        private double _length, _width, _height;
        private Color _color = Color.Red;
        
        #endregion
    }
}
