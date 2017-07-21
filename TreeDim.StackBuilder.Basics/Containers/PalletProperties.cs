#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public class PalletProperties : ItemBaseNamed
    {
        public PalletProperties(Document document, string typeName, double length, double width, double height)
            : base(document)
        {
            _typeName = typeName;
            _length = length;
            _width = width;
            _height = height;
        }

        public double[] Dimensions => new double[] { _length, _width, _height };
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
            set { _color = value; }
            get { return _color; }
        }
        public BBox3D BoundingBox => new BBox3D(Vector3D.Zero, new Vector3D(_length, _width, _height));

        public override string ToString()
        {
            var sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(string.Format("PalletProperties => Type {0} Length {1} Width {2} Height {3}", _typeName, _length, _width, _height));
            return sBuilder.ToString();
        }

        #region Non-Public Members

        double _length, _width, _height;
        double _weight;
        double _admissibleLoadWeight, _admissibleLoadHeight;
        private Color _color = Color.Yellow;
        private string _typeName = "Block";
        
        #endregion

    }
}
