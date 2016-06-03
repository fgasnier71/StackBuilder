#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sharp3D.Math.Core;

using log4net;
#endregion

namespace treeDiM.StackBuilder.Basics
{
    public abstract class Analysis : ItemBase
    {
        #region Data members
        protected List<Solution> _solutions = new List<Solution>();
        protected ConstraintSetAbstract _constraintSet;
        protected List<InterlayerProperties> _interlayers;
        #endregion

        #region Constructor
        public Analysis(Document doc) : base(doc)
        {
            _interlayers = new List<InterlayerProperties>();
        }
        #endregion

        #region Public properties
        public abstract Vector3D ContentDimensions      { get; }
        public abstract double   ContentVolume          { get; }
        public abstract double   ContentWeight          { get; }

        public abstract Vector2D ContainerDimensions    { get; }
        public abstract Vector3D Offset                 { get; }
        public abstract double   ContainerWeight        { get; }
        public abstract double   ContainerLoadingVolume { get; }
        public List<Solution> Solutions
        { get { return _solutions; } }
        public ConstraintSetAbstract ConstraintSet
        {
            get { return _constraintSet; }
            set { _constraintSet = value;}
        }
        public List<InterlayerProperties> Interlayers { get { return _interlayers; } }
        #endregion

        #region Abstract methods
        public abstract BBox3D BBoxLoadWDeco(BBox3D loadBBox);
        public abstract BBox3D BBoxGlobal(BBox3D loadBBox);
        #endregion

        #region Public methods
        public int GetInterlayerIndex(InterlayerProperties interlayer)
        {
            if (null == interlayer) return -1;
            if (!_interlayers.Contains(interlayer))
                _interlayers.Add(interlayer);
            return _interlayers.FindIndex(item => item == interlayer);
        }
        public void Clear()
        {
            _solutions.Clear();
        }
        public virtual InterlayerProperties Interlayer(int index)
        {
            return null;
        }
        #endregion
    }
}
