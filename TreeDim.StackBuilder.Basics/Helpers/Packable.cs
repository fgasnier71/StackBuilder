#region Using directives
using System;
using System.Text;

using log4net;
using Sharp3D.Math.Core;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    #region Packable
    public abstract class Packable : ItemBase
    {
        #region Constructor
        public Packable(Document doc)
            : base(doc)
        {
        }
        public Packable(Document document, string name, string description)
            : base(document, name, description)
        {
        }
        #endregion

        #region Detailed name
        abstract protected string TypeName { get; }
        /// <summary>
        /// Is actually formatted as TypeName(Name)
        /// </summary>
        public virtual string DetailedName { get { return string.Format("{0}({1})", TypeName, Name); } }
        #endregion

        #region OuterDimensions
        abstract public double Length { get; }
        abstract public double Width { get; }
        abstract public double Height { get; }
        public double Volume { get { return Length * Width * Height; } }
        public Vector3D OuterDimensions { get { return new Vector3D(Length, Width, Height); } }
        public double Dim(int index)
        {
            switch (index)
            {
                case 0: return Length;
                case 1: return Width;
                case 2: return Height;
                default: throw new Exception("Invalid index...");
            }
        }
        public double Dimension(HalfAxis.HAxis axis)
        {
            switch (axis)
            {
                case HalfAxis.HAxis.AXIS_X_N:
                case HalfAxis.HAxis.AXIS_X_P:
                    return Length;
                case HalfAxis.HAxis.AXIS_Y_N:
                case HalfAxis.HAxis.AXIS_Y_P:
                    return Width;
                case HalfAxis.HAxis.AXIS_Z_N:
                case HalfAxis.HAxis.AXIS_Z_P:
                    return Height;
                default:
                    return 0.0;
            }
        }
        #endregion

        #region Weight
        abstract public double Weight { get; }
        abstract public OptDouble NetWeight { get; }
        #endregion

        #region Authorized orientations
        public virtual bool OrientationAllowed(HalfAxis.HAxis axis) { return true; }
        #endregion

        #region Virtual methods
        public virtual bool InnerContent(ref Packable innerPackable, ref int number)
        {
            innerPackable = null;
            number = 0;
            return false;
        }
        #endregion

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(
                string.Format("BProperties => Length = {0}      Width = {1}     Height = {2}"
                , Length, Width, Height)
                );
            return sBuilder.ToString();
        }
        #endregion
    }
    #endregion
}