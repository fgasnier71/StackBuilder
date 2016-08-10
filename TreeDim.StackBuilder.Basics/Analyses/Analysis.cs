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
        protected Packable _packable;

        static readonly ILog _log = LogManager.GetLogger(typeof(Analysis));
        #endregion

        #region Constructor
        public Analysis(Document doc, Packable packable) : base(doc)
        {
            _packable = packable;
            _interlayers = new List<InterlayerProperties>();
        }
        #endregion

        #region Public properties
        public Packable Content
        {
            get { return _packable; }
            set
            {
                if (value == _packable) return;
                if (null != _packable) _packable.RemoveDependancy(this);
                _packable = value;
                _packable.AddDependancy(this);
            }
        }
        public virtual Vector3D ContentDimensions      { get { return _packable.OuterDimensions; } }
        public virtual double ContentVolume            { get { return _packable.Volume; } }
        public virtual double ContentWeight            { get { return _packable.Weight; } }

        public List<Solution> Solutions                 { get { return _solutions; } }
        public ConstraintSetAbstract ConstraintSet      { get { return _constraintSet; } set { _constraintSet = value; } }
        public List<InterlayerProperties> Interlayers   { get { return _interlayers; } }
        #endregion

        #region Abstract properties
        public abstract Vector2D ContainerDimensions    { get; }
        public abstract Vector3D Offset                 { get; }
        public abstract double   ContainerWeight        { get; }
        public abstract double   ContainerLoadingVolume { get; }
        #endregion

        #region Abstract methods
        public abstract BBox3D BBoxLoadWDeco(BBox3D loadBBox);
        public abstract BBox3D BBoxGlobal(BBox3D loadBBox);
        #endregion

        #region Public methods
        public void AddInterlayer(InterlayerProperties interlayer)
        {
            _interlayers.Add(interlayer);
            interlayer.AddDependancy(this);
        }
        public void AddSolution(List<LayerDesc> layers)
        {
            _solutions.Add(new Solution(this, layers));
        }
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
