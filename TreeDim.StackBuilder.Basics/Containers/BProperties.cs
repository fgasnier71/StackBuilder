#region Using directives
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class BProperties : PackableBrickNamed
    {
        #region Data members
        protected double _length, _width;
        #endregion

        #region Constructor
        public BProperties(Document document)
            : base(document)
        { 
        }
        public BProperties(Document document, string name, string description)
            : base(document, name, description)
        { 
        }
        #endregion

        #region Override Packable
        public override double Length
        { get { return _length; } }
        public override double Width
        { get { return _width; } }
        public override double Weight
        { get { return _weight; } }
        #endregion

        #region Public accessors
        public virtual void SetLength(double length)
        { _length = length; Modify(); }
        public virtual void SetWidth(double width)
        { _width = width; Modify(); }
        #endregion

        #region Public methods
        abstract public Color[] Colors { get; }
        abstract public void SetColor(Color color);
        abstract public Color GetColor(HalfAxis.HAxis axis);

        abstract public bool IsBundle { get; }
        #endregion
    }
}
