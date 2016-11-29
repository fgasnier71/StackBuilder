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
        #endregion

        #region Detailed name
        abstract protected string TypeName { get; }
        /// <summary>
        /// Is actually formatted as "TypeName(Name)"
        /// </summary>
        public virtual string DetailedName { get { return string.Format("{0}({1})", TypeName, ID.Name); } }
        #endregion


        #region Weight
        abstract public double Weight { get; }
        abstract public OptDouble NetWeight { get; }
        abstract public double Volume { get; }
        abstract public Vector3D OuterDimensions { get; }
        #endregion


        #region Filtering properties
        public virtual bool IsCase { get { return false; } }
        public virtual bool IsPallet { get { return false; } }
        public virtual bool IsTruck { get { return false; } }
        #endregion

        #region Virtual methods
        public virtual bool InnerAnalysis(ref Analysis analysis)
        {
            analysis = null;
            return false;
        }
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
                string.Format("Packable => Weight = {0}  NetWeight = {1}\n"
                , Weight, NetWeight)
                );
            return sBuilder.ToString();
        }
        #endregion
    }
    #endregion

    #region PackableBrick
    public abstract class PackableBrick : Packable
    {
        #region Constructor
        public PackableBrick(Document doc)
            : base(doc)
        { 
        }
        #endregion

        #region Authorized orientations
        public virtual bool OrientationAllowed(HalfAxis.HAxis axis) { return true; }
        #endregion

        #region OuterDimensions
        public override double Volume { get { return Length * Width * Height; } }
        abstract public double Length { get; }
        abstract public double Width { get; }
        abstract public double Height { get; }
        public override Vector3D OuterDimensions { get { return new Vector3D(Length, Width, Height); } }
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

        #region Object override
        public override string ToString()
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(base.ToString());
            sBuilder.Append(
                string.Format("Packable => Length = {0}      Width = {1}     Height = {2}"
                , Length, Width, Height)
                );
            return sBuilder.ToString();
        }
        #endregion
    }
    #endregion

    #region PackableSimple
    public abstract class PackableNamed : Packable
    {
        #region Data members
        protected GlobID _id = new GlobID();
        protected double _weight;
        protected OptDouble _netWeight = OptDouble.Zero; 
        #endregion

        #region Constructor
        public PackableNamed(Document parentDocument)
            : base(parentDocument)
        { 
        }
        public PackableNamed(Document parentDocument, string name, string description)
            : base(parentDocument)
        {
            ID.SetNameDesc(name, description);
        }
        #endregion

        #region Public methods
        public void SetWeight(double weight)
        { _weight = weight; Modify(); }
        public void SetNetWeight(OptDouble netWeight)
        { _netWeight = netWeight; }
        #endregion

        #region Override Packable
        public override double Weight
        { get { return _weight; } }
        public override OptDouble NetWeight
        { get { return _netWeight; } }
        #endregion

        #region Override ItemBase
        public override GlobID ID { get { return _id; } }
        #endregion
    }
    #endregion

    #region PackableBrickNamed
    public abstract class PackableBrickNamed : PackableBrick
    {
        #region Data members
        protected GlobID _id = new GlobID();
        protected double _weight;
        protected OptDouble _netWeight = OptDouble.Zero; 
        #endregion

        #region Constructor
        public PackableBrickNamed(Document parentDocument)
            : base(parentDocument)
        { 
        }
        public PackableBrickNamed(Document parentDocument, string name, string description)
            : base(parentDocument)
        {
            ID.SetNameDesc(name, description);
        }
        #endregion

        #region Public methods
        public virtual void SetWeight(double weight)
        { _weight = weight; Modify(); }
        public virtual void SetNetWeight(OptDouble netWeight)
        { _netWeight = netWeight; Modify(); }
        #endregion

        #region Override Packable
        public override double Weight
        { get { return _weight; } }
        public override OptDouble NetWeight
        { get { return _netWeight; } }
        #endregion

        #region Override ItemBase
        public override GlobID ID { get { return _id; } }
        #endregion        
    }
    #endregion
}