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
    #region Analysis
    public abstract class Analysis : ItemBaseNamed
    {
        #region Data members
        /// <summary>
        /// Solution
        /// </summary>
        protected Solution _solution;
        /// <summary>
        /// Constraint set
        /// </summary>
        protected ConstraintSetAbstract _constraintSet;
        /// <summary>
        /// Interlayers
        /// </summary>
        protected List<InterlayerProperties> _interlayers;
        /// <summary>
        /// Content
        /// </summary>
        protected Packable _packable;
        /// <summary>
        /// Logging
        /// </summary>
        static readonly ILog _log = LogManager.GetLogger(typeof(Analysis));
        #endregion

        #region Constructor
        public Analysis(Document doc, Packable packable) : base(doc)
        {
            Content = packable;
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

        public Solution Solution                        { get { return _solution; } }
        public ConstraintSetAbstract ConstraintSet      { get { return _constraintSet; } set { _constraintSet = value; } }
        public List<InterlayerProperties> Interlayers   { get { return _interlayers; } }
        /// <summary>
        /// can analysis solution be reused in other analysis
        /// </summary>
        public abstract bool HasEquivalentPackable { get; }
        /// <summary>
        /// get equivalent packable
        /// </summary>
        public abstract PackableLoaded EquivalentPackable { get; }
        #endregion

        #region Abstract properties
        public abstract ItemBase Container              { get; }
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
        public virtual bool AllowInterlayer(InterlayerProperties interlayer)
        {
            if (null == interlayer)
                return false;
            return true;    
        }
        public void AddInterlayer(InterlayerProperties interlayer)
        {
            _interlayers.Add(interlayer);
            interlayer.AddDependancy(this);
        }
        public void AddSolution(List<LayerDesc> layers)
        {
            _solution = new Solution(this, layers);
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
        }
        public virtual InterlayerProperties Interlayer(int index)
        {
            return _interlayers[index];
        }
        #endregion
    }
    #endregion

    #region Packable loaded
    public abstract class PackableLoaded : PackableBrick
    {
        #region Constructor
        public PackableLoaded(Analysis analysis)
            : base(analysis.ParentDocument)
        {
            _analysis = analysis;
        }
        #endregion

        #region ItemBase override
        public override GlobID ID { get { return _analysis.ID; } }
        #endregion

        #region Packable override
        public override double Weight
        { get { return ParentSolution.Weight; } }
        public override OptDouble NetWeight
        { get { return ParentSolution.NetWeight; } }
        #endregion

        #region Data members
        public Analysis ParentAnalysis      { get { return _analysis; } }
        protected Solution ParentSolution   { get { return _analysis.Solution; } }
        protected Analysis _analysis;
        #endregion
    }
    #endregion
}
